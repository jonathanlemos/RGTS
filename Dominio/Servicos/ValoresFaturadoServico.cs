using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System.Linq;
using Dominio.ValueType;

namespace Dominio.Servicos
{
    public class ValoresFaturadoServico : ServicoBase<ValoresFaturado>, IValoresFaturadoServico
    {
        private readonly IValoresFaturadoRepositorio valoresFaturadosRepositorio;
        private readonly ILucServico lucServico;
        private readonly IContratoLucServico contratoLucServico;
        private readonly IContratoLocacaoServico contratoLocacaoServico;
        private readonly IRubricaServico rubricaServico;
        private readonly IMarcaServico marcaServico;

        //repositorio
        ILucRepositorio lucRepositorio;

        public ValoresFaturadoServico(
            IValoresFaturadoRepositorio valoresFaturadosRepositorio,
            ILucServico lucServico,
            IContratoLucServico contratoUnidadeServico,
            IContratoLocacaoServico contratoLocacaoServico,
            ILucRepositorio lucRepositorio,
            IRubricaServico rubricaServico,
            IMarcaServico marcaServico
            ) : base(valoresFaturadosRepositorio)
        {
            this.lucServico = lucServico;
            this.contratoLucServico = contratoUnidadeServico;
            this.contratoLocacaoServico = contratoLocacaoServico;
            this.lucRepositorio = lucRepositorio;
            this.rubricaServico = rubricaServico;
            this.marcaServico = marcaServico;
        }

        public NotificacaoPost SalvarImportacaoDeUnidades(string pNomeUnidade, int pIdRubrica, double pValorFaturado)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();

            try
            {   
                Luc luc = lucRepositorio.GetPorNome(pNomeUnidade).Result;

                ContratoLuc unidades = contratoLucServico.GetAll()
                        .Where(i => i.IdLuc.Value == luc.Id && i.EUnidadePrincipal.Value == true)
                        .FirstOrDefault();

                ContratoLocacao contratoLocacao = contratoLocacaoServico.GetAll()
                    .Where(i => i.IdInstrumento == unidades.IdInstrumento
                    && i.EAtivo == true
                    && (i.DataInicioVigencia >= DateTime.Now && i.DataFimVigencia <= DateTime.Now
                    || i.DataFimVigencia >= DateTime.Now && i.DataBaseReajuste == null)
                    )
                    .FirstOrDefault();

                if (contratoLocacao.IdMarca == null)
                {
                    notificacaoPost.Sucesso = false;
                    notificacaoPost.Mensagem = "Marca não encontrada";
                    return notificacaoPost;
                }

                Marca marca = marcaServico.GetById((int)contratoLocacao.IdMarca);
                Rubrica rubrica = rubricaServico.GetById(pIdRubrica);

                ValoresFaturado valoresFaturado = new ValoresFaturado();
                valoresFaturado.IdRubrica = rubrica.Id;
                valoresFaturado.MesCompetencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(rubrica.EVencido.Value ? 0 : 1).Month;
                valoresFaturado.AnoCompetencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(rubrica.EVencido.Value ? 0 : 1).Year;
                valoresFaturado.MesProcessamento = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Month;
                valoresFaturado.AnoProcessamento = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Year;
                valoresFaturado.ValorFaturado = pValorFaturado;
                //valoresFaturado.VencimentoNd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, rubrica. .DiaVencimento).AddMonth((bool)rubrica.EVencido ? 0 : 1).year;
                //valoresFaturado.IdSerie = rubrica.IdSerie
                valoresFaturado.EAprovado = false;
                valoresFaturado.IdSeqAltContratoLocacao = contratoLocacao.Id;
                valoresFaturado.IdInstrumento = contratoLocacao.IdInstrumento;

                Add(valoresFaturado);
                notificacaoPost.Sucesso = true;
                notificacaoPost.Mensagem = "Salvo com sucesso.";
                return notificacaoPost;
            }
            catch (Exception e)
            {
                notificacaoPost.Sucesso = false;
                notificacaoPost.Mensagem = "Erro ao salvar. "+ e.Message;
                return notificacaoPost;
            }
        }
    }
}
