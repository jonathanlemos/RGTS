using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ValueType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace RGTS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NDController : ControllerBase
    {
        INdServico _ndServico;
        IServicoCobrancaServico _SCServico;
        IPessoaServico _pessoaServico;
        IPartilhaBancariaServico _partilhaServico;
        IItensNdPartilhadosServico _itensNdPartilhadosServico;
        IRubricaServico _rubricaServico;

        public NDController(INdServico ndServico,
                            IServicoCobrancaServico sCServico,
                            IPessoaServico pessoaServico,
                            IPartilhaBancariaServico partilhaServico,
                            IItensNdPartilhadosServico itensNdPartilhadosServico,
                            IRubricaServico rubricaServico
        )
        {
            this._ndServico = ndServico;
            this._SCServico = sCServico;
            this._pessoaServico = pessoaServico;
            this._partilhaServico = partilhaServico;
            this._itensNdPartilhadosServico = itensNdPartilhadosServico;
            this._rubricaServico = rubricaServico;
        }

        [HttpPost]
        [Route("gerarArquivoRemessa/{idServico}/mensagem/{idMensagem}/instrucao/{idInstrucao}")]
        public FileStreamResult GerarArquivoRemessa([FromBody] Nd[] nds, int idServico, int idMensagem, int idInstrucao)
        {

            var arquivoTextBuilder = new StringBuilder();
            string nomeArquivo = string.Empty;

            if (idServico > 0)
            {
                ServicoCobranca _servicoCobranca = new ServicoCobranca();
                _servicoCobranca = _SCServico.GetById(idServico);
                nomeArquivo = geraNomeArquivoRem(_servicoCobranca, "BRADESCO");

                try
                {
                    int sequencial = 1;

                    #region Registro HEADER
                    var headerBuilder = new StringBuilder(400, 400);
                    //Identificacao do registro fixo (0)HEADER
                    headerBuilder.Append("0");
                    //Identif. do arquivo de remessa fixo (1)
                    headerBuilder.Append("1");
                    //literal fixo Remessa
                    headerBuilder.Append("REMESSA");
                    //Codigo de servico fixo (01) Cobranca
                    headerBuilder.Append("01");
                    //Litera Serviço -fixo Cobrança
                    headerBuilder.Append("COBRANCA".PadRight(15, ' '));
                    //Codigo Convenio - 20 digitos
                    headerBuilder.Append(_servicoCobranca.Convenio.PadLeft(20, '0'));
                    //Nome da empresa
                    headerBuilder.Append(_servicoCobranca.Empresa.PadRight(30, ' ').Substring(0, 30));
                    //Número Bradesco Compensaçao - Fixo 237
                    headerBuilder.Append("237");
                    //Nome do Banco por extenso - fixo Bradesco
                    headerBuilder.Append("BRADESCO".PadRight(15, ' '));
                    //data de gravação do arquivo
                    headerBuilder.Append(DateTime.Now.ToString("ddMMyy"));
                    //espaços em branco (8)
                    headerBuilder.Append(string.Empty.PadLeft(8, ' ').ToString());
                    //Identificaçao do Sistema - fixo MX
                    headerBuilder.Append("MX");
                    //Sequencial do arquivo
                    headerBuilder.Append(_servicoCobranca.SequencialArquivoRemessa.ToString().PadLeft(7, '0'));
                    //espaços em branco (277)
                    headerBuilder.Append(string.Empty.PadLeft(277, ' ').ToString());
                    //Sequencial do registro
                    headerBuilder.Append(sequencial.ToString().PadLeft(6, '0').ToString());

                    arquivoTextBuilder.AppendLine(headerBuilder.ToString());
                    #endregion

                    nds.ToList().ForEach(item =>
                    {
                        var nd = _ndServico.GetById(item.Id);
                        sequencial++;
                        var nossoNumeroDV = geraNNDVBradesco(_servicoCobranca.Carteira, nd.Id);
                        var nossoNumeroSemDV = nd.Id.ToString().PadLeft(11, '0').ToString();
                        var nossoNumero = string.Format("{0}{1}", nossoNumeroSemDV, nossoNumeroDV);
                        decimal valorTitulo = 0;

                        valorTitulo = Convert.ToDecimal(nd.ValorPrincipal.GetValueOrDefault());

                        #region Registro Detalhes
                        var pessoaSacado = _pessoaServico.GetById(nd.PessoaPagador.GetValueOrDefault());

                        if (pessoaSacado == null)
                            throw new Exception(string.Format("Impossível Localizar o SACADO do título {0}", nd.Id));
                        var detalhesBuilder = new StringBuilder(400, 400);
                        //identificaçao do registro - fixo (1) Detalhes
                        detalhesBuilder.Append("1");
                        //agencia de debito automatico
                        detalhesBuilder.Append(string.Empty.PadLeft(5, '0').ToString());
                        //digito agencia debito automatico
                        detalhesBuilder.Append("0");
                        //razao conta corrente debito automatico
                        detalhesBuilder.Append(string.Empty.PadLeft(5, '0').ToString());
                        //numero da conta corrente debito automatico
                        detalhesBuilder.Append(string.Empty.PadLeft(7, '0').ToString());
                        //digito da conta corrente debito automatico
                        detalhesBuilder.Append("0");
                        //identificacao do cedente - (0)(Carteira)(Agencia)(ContaCorrente)
                        detalhesBuilder.Append("0");
                        detalhesBuilder.Append(_servicoCobranca.Carteira.ToString().PadLeft(3, '0').Substring(0, 3));
                        detalhesBuilder.Append(_servicoCobranca.contaCorrente.Agencia.ToString().PadLeft(5, '0').Substring(0, 5));
                        detalhesBuilder.Append(_servicoCobranca.contaCorrente.NumeroContaCorrente.ToString().PadLeft(7, '0').Substring(0, 7));
                        detalhesBuilder.Append(_servicoCobranca.contaCorrente.DvContaCorrente);
                        //Numero de controle do participante - sem dados
                        detalhesBuilder.Append(string.Empty.PadLeft(25, '0'));
                        //numero do banco fixo (237)
                        detalhesBuilder.Append("237");
                        //zeros fixos
                        detalhesBuilder.Append("00000");
                        //Identificação - Nosso numero
                        detalhesBuilder.Append(nossoNumero);
                        //Valor desconto bonificacao/dia
                        detalhesBuilder.Append(string.Empty.PadLeft(10, '0'));
                        //Condição de Emissao - 1=Banco; 2=cliente
                        detalhesBuilder.Append(_servicoCobranca.IdTipoEmissao);
                        //ident. se emite papeleta debito automatico
                        detalhesBuilder.Append(" ");
                        //identificacao operacao do Banco
                        detalhesBuilder.Append(string.Empty.PadLeft(10, '0').ToString());
                        //identificador rateio credito
                        detalhesBuilder.Append(_servicoCobranca.tipoServicoCobranca.ePartilhado.GetValueOrDefault() ? "R" : " ");
                        //identificador para aviso do debito automatico fixo 1;2 PARA NAO AVISO; 0 para nao aviso
                        detalhesBuilder.Append("2");
                        //branco
                        detalhesBuilder.Append("  ");
                        //identificacao da ocorrencia - 01 REMESSA
                        detalhesBuilder.Append("01");
                        //numero do documento
                        detalhesBuilder.Append(nd.Id.ToString().PadLeft(10, '0'));
                        //data de vencimento do titulo
                        detalhesBuilder.Append(nd.Vencimento.GetValueOrDefault().ToString("ddMMyy"));
                        //valor do titulo
                        detalhesBuilder.Append(valorTitulo.ToString("N2").Replace(".", "").Replace(",", "").PadLeft(13, '0'));
                        //banco encarregado da cobranca (num febraban banco da conta)
                        detalhesBuilder.Append(string.Empty.PadLeft(3, '0'));
                        //agencia depositaria (agencia do banco da conta)
                        detalhesBuilder.Append(string.Empty.PadLeft(5, '0'));
                        //especie do titulo
                        detalhesBuilder.Append("01");
                        //identificacao fixo A
                        detalhesBuilder.Append("A");
                        //data de emissao do titulo
                        detalhesBuilder.Append(nd.DataEmissao != DateTime.MinValue ? nd.DataEmissao.GetValueOrDefault().ToString("ddMMyy") : DateTime.Now.ToString("ddMMyy"));
                        //primeira instruçao fixo 09
                        detalhesBuilder.Append("09");
                        //segunda instrucao fixo 00
                        detalhesBuilder.Append("00");
                        //valor cobrado por dia atraso
                        detalhesBuilder.Append(string.Empty.PadLeft(13, '0').ToString());
                        //data limite para concessao de desconto
                        detalhesBuilder.Append(string.Empty.PadLeft(6, ' '));
                        //valor do desconto
                        detalhesBuilder.Append(string.Empty.PadLeft(13, '0').ToString());
                        //valor do IOF
                        detalhesBuilder.Append(string.Empty.PadLeft(13, '0').ToString());
                        //valor do abatimento a ser concedido
                        detalhesBuilder.Append(string.Empty.PadLeft(13, '0').ToString());
                        //identificacao do tipo de pessoa do sacado
                        detalhesBuilder.Append(pessoaSacado.TipoPessoa == 2 ? "02" : "01");
                        //numero de inscricao do sacado
                        detalhesBuilder.Append(pessoaSacado.CpfCnpj.PadLeft(14, '0').Substring(0, 14));
                        //nome do sacado
                        detalhesBuilder.Append(pessoaSacado.RazaoSocial.PadRight(40, ' ').Substring(0, 40));
                        //endereco do sacado
                        detalhesBuilder.Append(pessoaSacado.Logradouro.PadRight(40, ' ').Substring(0, 40));
                        //primeira mensagem
                        detalhesBuilder.Append(string.Empty.PadLeft(12, ' ').ToString());
                        //prefixo cep sacado
                        detalhesBuilder.Append(pessoaSacado.Cep.Replace("-", "").PadLeft(8, '0').Substring(0, 8));
                        //decomposicao sacador/avalista ou mensagem 2
                        detalhesBuilder.Append(string.Empty.PadLeft(60, ' ').ToString());
                        //sequencial
                        detalhesBuilder.Append(sequencial.ToString().PadLeft(6, '0').ToString());
                        arquivoTextBuilder.AppendLine(detalhesBuilder.ToString());
                        #endregion


                        if (_servicoCobranca.tipoServicoCobranca.ePartilhado.GetValueOrDefault())
                        {
                            #region Registro Rateio

                            var _partilhas = _partilhaServico.Get(p => p.IdServicoCobranca == idServico).ToList();

                            List<ItensNdPartilhado> resultado = new List<ItensNdPartilhado>();

                            nd.ItensNds.ToList().ForEach(i =>
                            {
                                var partilhaItem = _partilhas.Where(p => p.IdRubrica == i.IdRubrica).ToList();

                                if (partilhaItem.Count == 0)
                                    throw new Exception("A partilha não está configurada para a rubrica \"" + _rubricaServico.GetById(i.IdRubrica.GetValueOrDefault()).NomeRubrica + "\" do serviço selecionado. Por favor, configure e tente novamente.");

                                partilhaItem.ForEach(p =>
                                {
                                    resultado.Add(new ItensNdPartilhado
                                    {
                                        IdItemNd = i.Id,
                                        IdPartilhaBancaria = p.Id,
                                        IdShopping = p.IdShopping.GetValueOrDefault(),
                                        Data = DateTime.Now,
                                        Percentual = p.PercentualPartilha.GetValueOrDefault(),
                                        Valor = Convert.ToDecimal(i.ValorPrincipalRubrica.GetValueOrDefault()),
                                        partilhaBancarium = p
                                    });
                                });
                            });

                            if (resultado.Count == 0)
                                throw new Exception(string.Format("O Item de Cobrança do Título {0} não está configurado para a partilha do Servço de Cobrança {1}", nd.Id, _servicoCobranca.NomeServico));

                            var listaItensNdPartilhadosRateio = resultado.GroupBy(
                                                                            itp => new
                                                                            {
                                                                                itp.partilhaBancarium.contaCorrente.Agencia,
                                                                                itp.partilhaBancarium.contaCorrente.DvAgencia,
                                                                                itp.partilhaBancarium.contaCorrente.NumeroContaCorrente,
                                                                                itp.partilhaBancarium.contaCorrente.DvContaCorrente,
                                                                                itp.partilhaBancarium.contaCorrente.IdPessoaTitular
                                                                            }).Select(group => new ItensNdPartilhado
                                                                            {
                                                                                partilhaBancarium = new PartilhaBancarium
                                                                                {
                                                                                    contaCorrente = new ContaCorrente
                                                                                    {
                                                                                        Agencia = group.Key.Agencia,
                                                                                        DvAgencia = group.Key.DvAgencia,
                                                                                        NumeroContaCorrente = group.Key.NumeroContaCorrente,
                                                                                        DvContaCorrente = group.Key.DvContaCorrente,
                                                                                        IdPessoaTitular = group.Key.IdPessoaTitular
                                                                                    }
                                                                                },
                                                                                Valor = group.Sum(itpr => itpr.Valor)
                                                                            }).ToList<ItensNdPartilhado>();

                            if (listaItensNdPartilhadosRateio.Count > 0 && (Math.Round((listaItensNdPartilhadosRateio.Sum(itp => itp.Valor)).GetValueOrDefault(), 2) != Math.Round(valorTitulo, 2)))
                                throw new Exception(string.Format("O somatório total da partilha é diferente do valor total do título {0}: Soma Partilha:{1} - Valor do Título:{2}", nd.Id, listaItensNdPartilhadosRateio.Sum(itp => itp.Valor), nd.ValorPrincipal));

                            var rateioBuilder = new StringBuilder(400, 400);
                            listaItensNdPartilhadosRateio.ForEach(itp =>
                            {
                                //cria nova linha caso seja o primeiro de 3 em 3 beneficiarios
                                //neste caso nao precisamos adicionar 1 ao indexof, pois teremos que criar a quebra no quarto item ou seja item de indexof 3
                                if (listaItensNdPartilhadosRateio.IndexOf(itp) == 0 || listaItensNdPartilhadosRateio.IndexOf(itp) % 3 == 0)
                                {

                                    rateioBuilder = new StringBuilder(400, 400);
                                    //identificacao do registro fixo 3
                                    rateioBuilder.Append("3");
                                    //identificacao da empresa no banco - info cedente (carteira/agencia/conta)
                                    rateioBuilder.Append(_servicoCobranca.Carteira.ToString().PadLeft(3, '0'));
                                    rateioBuilder.Append(_servicoCobranca.contaCorrente.Agencia.ToString().PadLeft(5, '0'));
                                    rateioBuilder.Append(_servicoCobranca.contaCorrente.NumeroContaCorrente.ToString().PadLeft(7, '0').Substring(0, 7));
                                    rateioBuilder.Append(_servicoCobranca.contaCorrente.DvContaCorrente);
                                    //nosso numero
                                    rateioBuilder.Append(nossoNumero);
                                    //codigo de calculo do rateio
                                    rateioBuilder.Append(_servicoCobranca.IdTipoRateio);
                                    //tipo valor informado Por Valor / Por % 
                                    rateioBuilder.Append((_servicoCobranca.IdTipoRateio == 1) ? 1 : 2);
                                    //brancos
                                    rateioBuilder.Append(string.Empty.PadLeft(12, ' '));
                                }
                                //codigo banco FIxo Bradesco 237
                                rateioBuilder.Append("237");
                                //codigo da agencia
                                rateioBuilder.Append(itp.partilhaBancarium.contaCorrente.Agencia.PadLeft(5, '0'));
                                //digito agencia
                                rateioBuilder.Append(itp.partilhaBancarium.contaCorrente.DvAgencia);
                                //codigo da conta corrente
                                rateioBuilder.Append(itp.partilhaBancarium.contaCorrente.NumeroContaCorrente.PadLeft(12, '0'));
                                //digito da conta corrente
                                rateioBuilder.Append(itp.partilhaBancarium.contaCorrente.DvContaCorrente);
                                //valor ou % para rateio
                                rateioBuilder.Append((_servicoCobranca.IdTipoRateio != 1) ? Math.Round(itp.Valor.GetValueOrDefault(), 2).ToString("N2").Replace(".", "").Replace(",", "").PadLeft(15, '0') : Math.Round((Convert.ToDecimal(itp.Valor) / Convert.ToDecimal(nd.ValorPrincipal)) * 100, 3).ToString("N2").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
                                //nome beneficiario
                                rateioBuilder.Append(_pessoaServico.GetById(itp.partilhaBancarium.contaCorrente.IdPessoaTitular.GetValueOrDefault()).RazaoSocial.PadLeft(40, ' ').Substring(0, 40));
                                //brancos
                                rateioBuilder.Append(string.Empty.PadLeft(31, ' '));
                                //parcela
                                rateioBuilder.Append(string.Empty.PadLeft(6, '0'));
                                //dias credito beneficiario
                                rateioBuilder.Append(_servicoCobranca.DiasRepasse.ToString().PadLeft(3, '0'));
                                //adicionando 1 ao indexof, pois comeca em 0 o primeiro item, assim sendo o terceiro item seria o 2, precisamos somar 1 para ajustar
                                if (listaItensNdPartilhadosRateio.IndexOf(itp) != 0 && (listaItensNdPartilhadosRateio.IndexOf(itp) + 1) % 3 == 0)
                                {
                                    //sequencial
                                    sequencial++;
                                    rateioBuilder.Append(sequencial.ToString().PadLeft(6, '0').ToString());
                                    arquivoTextBuilder.AppendLine(rateioBuilder.ToString());
                                }
                            });
                            var resto = listaItensNdPartilhadosRateio.Count % 3;
                            if (resto != 0)
                            {
                                //sequencial
                                for (int i = 3 - resto; i > 0; i--)
                                {
                                    //codigo banco FIxo Bradesco 237
                                    rateioBuilder.Append("237");
                                    //codigo da agencia
                                    rateioBuilder.Append(string.Empty.PadLeft(5, '0'));
                                    //digito agencia
                                    rateioBuilder.Append("0");
                                    //codigo da conta corrente
                                    rateioBuilder.Append(string.Empty.PadLeft(12, '0'));
                                    //digito da conta corrente
                                    rateioBuilder.Append("0");
                                    //valor ou % para rateio
                                    rateioBuilder.Append(string.Empty.PadLeft(15, '0'));
                                    //nome beneficiario
                                    rateioBuilder.Append(string.Empty.PadLeft(40, ' '));
                                    //brancos
                                    rateioBuilder.Append(string.Empty.PadLeft(31, ' '));
                                    //parcela
                                    rateioBuilder.Append(string.Empty.PadLeft(6, '0'));
                                    //dias credito beneficiario
                                    rateioBuilder.Append(string.Empty.PadLeft(3, '0'));

                                }
                                sequencial++;
                                rateioBuilder.Append(sequencial.ToString().PadLeft(6, '0'));
                                arquivoTextBuilder.AppendLine(rateioBuilder.ToString());
                            }

                            //Salvar o ItemTituloPartilhado gerado
                            resultado.ForEach(itp =>
                            {
                                _itensNdPartilhadosServico.Add(itp);
                            });
                            #endregion
                        }
                        nd.IdCobranca = 1;
                        nd.IdServicoCobranca = _servicoCobranca.Id;
                        nd.NossoNumero = nossoNumeroSemDV;
                        nd.DigitoNossoNumero = nossoNumeroDV;
                        nd.GeracaoArquivoRemessa = DateTime.Now;
                        nd.ArquivoRemessa = nomeArquivo;
                        _ndServico.Update(nd);
                        nd = _ndServico.GetById(item.Id);
                        nd.CodigoBarras = this.CBBraedesco(nd);
                        nd.LinhaDigitavel = this.LinhaDGBradesco(nd);
                        _ndServico.Update(nd);
                    });
                    #region Registro Trailler
                    var traillerBuilder = new StringBuilder(400, 400);
                    traillerBuilder.Append("9");
                    traillerBuilder.Append(string.Empty.PadLeft(393, ' '));
                    sequencial++;
                    traillerBuilder.Insert(394, sequencial.ToString().PadLeft(6, '0').ToString());
                    arquivoTextBuilder.AppendLine(traillerBuilder.ToString());

                    #endregion
                }
                catch (Exception)
                {
                    throw;
                }
            }

            var contentDisposition = new ContentDispositionHeaderValue("attachment");
            contentDisposition.SetHttpFileName(nomeArquivo);
            Response.Headers[HeaderNames.ContentDisposition] = contentDisposition.ToString();
            Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            var content = new System.IO.MemoryStream(Encoding.ASCII.GetBytes(arquivoTextBuilder.ToString()));
            var contentType = "APPLICATION/octet-stream";            
            return File(content, contentType, nomeArquivo);
        }

        private string geraNNDVBradesco(string carteira, int id)
        {
            string num = string.Format("{0}{1}", carteira.PadLeft(2, '0').ToString(), id.ToString().PadLeft(11, '0').ToString());
            int multiplicador = 2;
            int tot = 0;
            foreach (var character in num.Reverse())
            {
                tot += (int)Char.GetNumericValue(character) * multiplicador;
                if (multiplicador == 7)
                    multiplicador = 2;
                else
                    multiplicador++;
            }
            return (tot % 11) == 0 ? "0" : (tot % 11) == 1 ? "P" : (11 - (tot % 11)).ToString();
        }

        private string geraNomeArquivoRem(ServicoCobranca servicoCobranca, string nomeBanco)
        {
            var seq = string.IsNullOrEmpty(servicoCobranca.SequencialArquivoRemessa) ? new char[] { '0', '0' } : servicoCobranca.SequencialArquivoRemessa.ToCharArray();
            if (seq[1] >= '9')
            {
                if ((seq[0] >= '0' && seq[0] < '9') || (seq[0] >= 'A' && seq[0] < 'Z'))
                    seq[0]++;
                else
                    if (seq[0] >= '9' && seq[0] < 'A')
                    seq[0] = 'A';
                else
                    seq[0] = '0';

                if (seq[1] < 'A' || seq[1] >= 'Z')
                    if (seq[1] >= 'Z')
                        seq[1] = '0';
                    else
                        seq[1] = 'A';
            }
            else
                seq[1]++;

            var nomeArqRem = string.Format("{0}{1}{2}{3}{4}{5}.{6}", servicoCobranca.PrefixoArquivoRemessa, servicoCobranca.IdShopping.ToString().PadLeft(3, '0'), servicoCobranca.Id, DateTime.Now.ToString("ddMMyy"), seq[0], seq[1], servicoCobranca.ExtensaoArquivoRemessa);

            servicoCobranca.SequencialArquivoRemessa = string.Format("{0}{1}", seq[0], seq[1]);
            if (nomeBanco == "BRADESCO")
            {
                servicoCobranca.SequencialArquivoRemessaBradesco += 1;
                if (nomeArqRem.Length > 20)
                    nomeArqRem = string.Format("{0}{1}{2}{3}{4}.{5}", servicoCobranca.PrefixoArquivoRemessa, servicoCobranca.IdShopping.ToString().PadLeft(2, '0'), DateTime.Now.ToString("ddMM"), seq[0], seq[1], servicoCobranca.ExtensaoArquivoRemessa);
            }
            else if (nomeBanco == "ITAU")
            {
                if (nomeArqRem.Length > 8)
                    nomeArqRem = string.Format("{0}{1}{2}{3}.{4}", servicoCobranca.IdShopping.ToString().PadLeft(2, '0'), DateTime.Now.ToString("ddMM"), seq[0], seq[1], servicoCobranca.ExtensaoArquivoRemessa);
            }

            var achouArquivo = true;
            while (achouArquivo)
            {
                var nds = _ndServico.Get(nd => nd.ArquivoRemessa == nomeArqRem).ToList();

                if (nds.Any())
                {
                    seq[1]++;
                    servicoCobranca.SequencialArquivoRemessa = string.Format("{0}{1}", seq[0], seq[1]);
                    nomeArqRem = string.Format("{0}{1}{2}{3}.{4}", servicoCobranca.IdShopping.ToString().PadLeft(2, '0'), DateTime.Now.ToString("ddMM"), seq[0], seq[1], servicoCobranca.ExtensaoArquivoRemessa);
                }
                else
                    achouArquivo = false;
            }

            _SCServico.Update(servicoCobranca);

            return nomeArqRem;
        }

        private string CBBraedesco(Nd nd)
        {
            DateTime fatorVencimento = new DateTime(1997, 10, 7);
            string fatorDias = (nd.Vencimento.GetValueOrDefault() - fatorVencimento).Days.ToString().PadLeft(4, '0');
            string NuBanco = nd.servicoCobranca.contaCorrente.banco.NumeroBanco.ToString().PadLeft(3, '0');
            string valor = nd.ValorSaldo.GetValueOrDefault().ToString("N2").Replace(".", "").Replace(",", "").PadLeft(10, '0');
            string agencia = nd.servicoCobranca.contaCorrente.Agencia.PadLeft(4, '0');
            string conta = nd.servicoCobranca.contaCorrente.NumeroContaCorrente.PadLeft(7, '0');
            string carteira = nd.servicoCobranca.Carteira.PadLeft(2, '0');
            string nossoNumero = nd.NossoNumero.PadLeft(11, '0');

            string DAC_CB = this.DACMod11(NuBanco +
                                          "9" +
                                          fatorDias +
                                          valor +
                                          agencia +
                                          carteira +
                                          nossoNumero +
                                          conta + "0");

            string numeroDaBarra = NuBanco + "9" + DAC_CB + fatorDias + valor + agencia + carteira + nossoNumero + conta + "0";

            return this.GeraBarra(numeroDaBarra);
        }

        private string LinhaDGBradesco(Nd nd)
        {
            DateTime fatorVencimento = new DateTime(1997, 10, 7);
            string fatorDias = (nd.Vencimento.GetValueOrDefault() - fatorVencimento).Days.ToString().PadLeft(4, '0');
            string NuBanco = nd.servicoCobranca.contaCorrente.banco.NumeroBanco.ToString().PadLeft(3, '0');
            string valor = nd.ValorSaldo.GetValueOrDefault().ToString("N2").Replace(".", "").Replace(",", "").PadLeft(10, '0');
            string agencia = nd.servicoCobranca.contaCorrente.Agencia.PadLeft(4, '0');
            string conta = nd.servicoCobranca.contaCorrente.NumeroContaCorrente.PadLeft(7, '0');
            string carteira = nd.servicoCobranca.Carteira.PadLeft(2, '0');
            string nossoNumero = nd.NossoNumero.PadLeft(11, '0');
            string convenio = nd.servicoCobranca.Convenio;

            string campoLivre;
            string campo1;
            string DVcampo1;
            string campo2;
            string DVcampo2;
            string campo3;
            string DVcampo3;
            string campo4;
            string campo5;

            campoLivre = string.Format("{0}{1}{2}{3}{4}", agencia, carteira, nossoNumero, conta, "0");

            campo1 = string.Format("{0}{1}{2}", NuBanco, "9", campoLivre.Substring(0, 5));
            DVcampo1 = this.DvModulo10(campo1);

            campo2 = campoLivre.Substring(5, 10);
            DVcampo2 = this.DvModulo10(campo2);

            campo3 = campoLivre.Substring(15, 10);
            DVcampo3 = this.DvModulo10(campo3);

            campo4 = this.DACMod11(NuBanco +
                                    "9" +
                                    fatorDias +
                                    valor +
                                    agencia +
                                    carteira +
                                    nossoNumero +
                                    conta + "0");

            campo5 = string.Format("{0}{1}", fatorDias, valor);

            return string.Format("{0}.{1}{2} {3}.{4}{5} {6}.{7}{8} {9} {10}", campo1.Substring(0, 5), campo1.Substring(5, 4), DVcampo1, campo2.Substring(0, 5), campo2.Substring(5, 5), DVcampo2, campo3.Substring(0, 5), campo3.Substring(5, 5), DVcampo3, campo4, campo5);

        }

        private string DvModulo10(string campo)
        {            
            int soma = 0, peso = 2;
            foreach (char _char in campo.Reverse())
            {
                int numero = (int.Parse(_char.ToString())) * peso;
                if (numero > 9)
                    soma += int.Parse(numero.ToString()[0].ToString()) + int.Parse(numero.ToString()[1].ToString());
                else
                    soma += numero;
                if (peso == 2)
                    peso = 1;
                else
                    peso = 2;
            }
            soma = ((soma / 10) + 1) * 10 - soma;
            return (soma == 10) ? "0" : soma.ToString();
        }

        private string DACMod11(string barra)
        {
            int sum = 0;
            int vak = 2;

            for (var Indice = barra.Length - 1; Indice >= 0; Indice--)
            {
                if (vak > 9)
                    vak = 2;
                sum += (Convert.ToInt32(barra.Substring(Indice, 1)) * vak);
                vak++;
            }
            var resto = sum % 11;
            if ((resto == 10) || (resto == 1) || (resto == 0))
                return "1";
            else
                return (11 - resto).ToString();
        }

        private string GeraBarra(string nuBarra)
        {
            string start = "00";
            string end = "20";

            string P1 = string.Empty;
            string P2 = string.Empty;
            string P3 = string.Empty;

            int a = 0;
            int b = 0;

            string[] vCd25 = new string[] { "00110", "10001", "01001", "11000", "00101", "10100", "01100", "00011", "10010", "01010" };
            string[] vtNuB = new string[] { "00", "01", "10", "11" };
            string nuBarraCodigo = start;

            if (nuBarra.Length % 2 != 0)
                nuBarra = "0" + nuBarra;

            for (var Ind_i = 0; Ind_i <= nuBarra.Length - 1; Ind_i += 2)
            {
                a = Convert.ToInt32(nuBarra.Substring(Ind_i, 1));
                b = Convert.ToInt32(nuBarra.Substring(Ind_i + 1, 1));
                P1 = vCd25[a];
                P2 = vCd25[b];
                for (var Ind_j = 0; Ind_j <= 4; Ind_j++)
                {
                    P3 = P1.Substring(Ind_j, 1) + P2.Substring(Ind_j, 1);
                    nuBarraCodigo += Array.FindIndex(vtNuB, v => v.Equals(P3)).ToString().PadLeft(1, '0');
                }
            }
            nuBarraCodigo += end;

            return nuBarraCodigo;
        }

        [HttpPost]
        [Route("filtro")]
        public IActionResult filter([FromBody] dynamic nd)
        {
            var converter = new ExpandoObjectConverter();
            var objExpandoObject = JsonConvert.DeserializeObject<ExpandoObject>(nd.ToString(), converter) as dynamic;
            var nds = new List<Nd>();
            try
            {
                int _tipoLocacaoFiltro = (int)objExpandoObject.tipoLocacaoFiltro;
                int[] _lucsFiltro = new int[] { };
                if (objExpandoObject.lucsFiltro.Count > 0)
                {
                    _lucsFiltro = new int[objExpandoObject.lucsFiltro.Count];
                    for (var i = 0; i < objExpandoObject.lucsFiltro.Count; i++)
                    {
                        _lucsFiltro[i] = (int)objExpandoObject.lucsFiltro[i];
                    }
                }
                int[] _marcasFiltro = new int[] { };
                if (objExpandoObject.marcasFiltro.Count > 0)
                {
                    _marcasFiltro = new int[objExpandoObject.marcasFiltro.Count];
                    for (var i = 0; i < objExpandoObject.marcasFiltro.Count; i++)
                    {
                        _marcasFiltro[i] = (int)objExpandoObject.marcasFiltro[i];
                    }
                }
                DateTime _vencimentoNDFiltroDe = (DateTime)objExpandoObject.vencimentoNDFiltroDe;
                DateTime _vencimentoNDFiltroAte = (DateTime)objExpandoObject.vencimentoNDFiltroAte;

                nds = _ndServico.filter(_tipoLocacaoFiltro, _lucsFiltro, _marcasFiltro, _vencimentoNDFiltroDe, _vencimentoNDFiltroAte);
                return Ok(nds);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("boletos")]
        public IActionResult gerarBoletos([FromBody] int[] idsNds)
        {
            try
            {               
                var _nds = _ndServico.Get(n => idsNds.Contains(n.Id)).ToList();
                return Ok(_nds);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
