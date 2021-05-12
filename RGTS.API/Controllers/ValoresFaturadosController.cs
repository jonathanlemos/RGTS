using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.ValueType;
using System.Reflection;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;

namespace RGTS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValoresFaturadosController : ControllerBase
    {
        IValoresFaturadosServico valoresFaturadosServico;
        IContratoLocacaoServico contratoLocacaoServico;
        IPessoaPapelInstrumentoServico pessoaPapelInstrumentoServico;
        INdServico ndServico;

        public ValoresFaturadosController(IValoresFaturadosServico valoresFaturadosServico, IPessoaPapelInstrumentoServico pessoaPapelInstrumentoServico, IContratoLocacaoServico contratoLocacaoServico, INdServico ndServico)
        {
            this.valoresFaturadosServico = valoresFaturadosServico;
            this.pessoaPapelInstrumentoServico = pessoaPapelInstrumentoServico;
            this.contratoLocacaoServico = contratoLocacaoServico;
            this.ndServico = ndServico;
        }

        [HttpGet]
        public ValoresFaturado[] Get()
        {
            try
            {
                return valoresFaturadosServico.GetAll()
                    .Select(i => new ValoresFaturado { Id = i.Id, AnoCompetencia = i.AnoCompetencia })
                    .ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ValoresFaturado valorFaturado)
        {
            try
            {
                valoresFaturadosServico.Add(valorFaturado);
                return Ok(valorFaturado);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ValoresFaturado valorFaturado)
        {
            try
            {
                valoresFaturadosServico.Update(valorFaturado);
                return Ok(valorFaturado);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var vlrf = valoresFaturadosServico.GetById(id);
                valoresFaturadosServico.Remove(vlrf);
                return Ok(vlrf);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("deletarValores")]
        public IActionResult DeleteValores([FromBody] dynamic[] valoresFaturados)
        {
            try
            {
                for (var i = 0; i < valoresFaturados.Length; i++)
                {
                    var converter = new ExpandoObjectConverter();
                    var objExpandoObject = JsonConvert.DeserializeObject<ExpandoObject>(valoresFaturados[i].ToString(), converter) as dynamic;
                    var valorFaturado = new ValoresFaturado();

                    valorFaturado.Id = (int)objExpandoObject.id;
                    valoresFaturadosServico.Remove(valorFaturado);
                }
                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("filtro")]
        public IActionResult filter([FromBody] dynamic valorFaturado)
        {

            var converter = new ExpandoObjectConverter();
            var objExpandoObject = JsonConvert.DeserializeObject<ExpandoObject>(valorFaturado.ToString(), converter) as dynamic;
            var valoresFaturados = new List<ValoresFaturado>();

            try
            {
                int _tipoLocacaoFiltro = (int)objExpandoObject.tipoLocacaoFiltro;
                int _anoMesProcessamentoFiltroDe = (int)objExpandoObject.anoMesProcessamentoFiltroDe;
                int _anoMesProcessamentoFiltroAte = (int)objExpandoObject.anoMesProcessamentoFiltroAte;
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
                
                bool? _enviados = null;
                
                if (objExpandoObject.enviados == true)
                    _enviados = true;
                else if(objExpandoObject.enviados == false)
                    _enviados = false;

                DateTime _vencimentoNDFiltroDe = (DateTime)objExpandoObject.vencimentoNDFiltroDe;
                DateTime _vencimentoNDFiltroAte = (DateTime)objExpandoObject.vencimentoNDFiltroAte;

                valoresFaturados = valoresFaturadosServico.GetFilter(_tipoLocacaoFiltro, _anoMesProcessamentoFiltroDe, _anoMesProcessamentoFiltroAte, _lucsFiltro, _marcasFiltro, _vencimentoNDFiltroDe, _vencimentoNDFiltroAte, _enviados);
                return Ok(valoresFaturados);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("enviarValores")]
        public IActionResult EnviarValores([FromBody] dynamic[] valoresFaturados)
        {
            try
            {
                List<ValoresFaturado> _valoresFaturados = new List<ValoresFaturado>();
                for (var i = 0; i < valoresFaturados.Length; i++)
                {
                    var converter = new ExpandoObjectConverter();
                    var objExpandoObject = JsonConvert.DeserializeObject<ExpandoObject>(valoresFaturados[i].ToString(), converter) as dynamic;
                    var valorFaturado = new ValoresFaturado();

                    valorFaturado.Id = (int)objExpandoObject.id;
                    valorFaturado.IdShopping = (int)objExpandoObject.idShopping;
                    valorFaturado.IdInstrumento = (int)objExpandoObject.idInstrumento;
                    valorFaturado.IdRubrica = (int)objExpandoObject.idRubrica;
                    valorFaturado.MesCompetencia = (int)objExpandoObject.mesCompetencia;
                    valorFaturado.AnoCompetencia = (int)objExpandoObject.anoCompetencia;
                    valorFaturado.MesProcessamento = (int)objExpandoObject.mesProcessamento;
                    valorFaturado.AnoProcessamento = (int)objExpandoObject.anoProcessamento;
                    valorFaturado.ValorCalculado = objExpandoObject.valorCalculado == null ? 0.00 : (double)objExpandoObject.valorCalculado;
                    valorFaturado.ValorFaturado = (double)objExpandoObject.valorFaturado;
                    valorFaturado.VencimentoNd = (DateTime)objExpandoObject.vencimentoNd;
                    valorFaturado.IdSerie = (int)objExpandoObject.idSerie;
                    valorFaturado.eAprovado = (Boolean)objExpandoObject.eAprovado;
                    valorFaturado.IdSeqAltContratoLocacao = objExpandoObject.idSeqAltContratoLocacao == null ? 1 : (int)objExpandoObject.idSeqAltContratoLocacao;
                    valorFaturado.IdDescricaoAlternativa = objExpandoObject.idDescricaoAlternativa == null ? 0 : (int)objExpandoObject.idDescricaoAlternativa;

                    _valoresFaturados.Add(valorFaturado);
                }

                var remessa = this.ndServico.GetAll().LastOrDefault();

                var Nds = _valoresFaturados.GroupBy(a => new
                {
                    IdShopping = a.IdShopping,
                    VencimentoNd = a.VencimentoNd,
                    IdSerie = a.IdSerie,
                    MesProcessamento = a.MesProcessamento,
                    AnoProcessamento = a.AnoProcessamento,
                    IdInstrumento = a.IdInstrumento
                }).Select(b => new Nd
                {
                    IdShopping = b.Key.IdShopping,
                    Vencimento = b.Key.VencimentoNd,
                    IdInstrumento = b.Key.IdInstrumento,
                    ValorOriginal = b.Sum(c => c.ValorFaturado),
                    ValorPrincipal = b.Sum(c => c.ValorFaturado),
                    ValorSaldo = b.Sum(c => c.ValorFaturado),
                    MesProcessamento = b.Key.MesProcessamento,
                    AnoProcessamento = b.Key.AnoProcessamento,
                    IdSerie = b.Key.IdSerie,
                    IdCobranca = 1, //Cobrável
                    IdLiquidacao = 0, //Não liquidado
                    Remessa = remessa == null ? 1 : remessa.Remessa + 1
                }).ToList();

                foreach (var nd in Nds)
                {
                    var pessoasInstrumento = this.pessoaPapelInstrumentoServico.Get(p => p.IdInstrumento == nd.IdInstrumento).ToList();
                    nd.PessoaPagador = pessoasInstrumento.Where(p => p.IdPapel == 1).FirstOrDefault().IdPessoa;
                    nd.PessoaBeneficiario = pessoasInstrumento.Where(p => p.IdPapel == 2).FirstOrDefault().IdPessoa;

                    var itensNd = _valoresFaturados.Where(v => v.VencimentoNd == nd.Vencimento && v.IdSerie == nd.IdSerie && v.IdInstrumento == nd.IdInstrumento && v.MesProcessamento == nd.MesProcessamento && v.AnoProcessamento == nd.AnoProcessamento).Select(i => new ItensNd
                    {
                        IdShopping = i.IdShopping,
                        IdRubrica = i.IdRubrica,
                        AnoCompetencia = i.AnoCompetencia,
                        MesCompetencia = i.MesCompetencia,
                        ValorOriginalRubrica = i.ValorFaturado,
                        ValorPrincipalRubrica = i.ValorFaturado,
                        ValorSaldoRubrica = i.ValorFaturado,
                        ENegociado = false
                    }).ToList();

                    nd.ItensNds = new List<ItensNd>();

                    nd.ItensNds.ToList().AddRange(itensNd);

                    this.ndServico.Add(nd);

                    _valoresFaturados.Where(v => v.IdShopping == nd.IdShopping && v.VencimentoNd == nd.Vencimento && v.IdSerie == nd.IdSerie && v.IdInstrumento == nd.IdInstrumento && v.MesProcessamento == nd.MesProcessamento && v.AnoProcessamento == nd.AnoProcessamento).ToList().ForEach(v =>
                    {
                        v.IdNd = nd.Id;
                        v.IdRemessa = nd.Remessa;
                        v.IdItemNd = nd.ItensNds.ToList().Where(it => it.IdShopping == v.IdShopping && it.IdRubrica == v.IdRubrica && it.MesCompetencia == v.MesCompetencia && it.AnoCompetencia == v.AnoCompetencia).FirstOrDefault().Id;
                    });
                }

                foreach (var vlrFaturado in _valoresFaturados)
                {
                    this.valoresFaturadosServico.Update(vlrFaturado);
                }

                return Ok(_valoresFaturados);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("retornarValores")]
        public IActionResult retornarValores([FromBody] dynamic[] valoresFaturados)
        {
            try
            {
                List<ValoresFaturado> _valoresFaturados = new List<ValoresFaturado>();
                for (var i = 0; i < valoresFaturados.Length; i++)
                {
                    var converter = new ExpandoObjectConverter();
                    var objExpandoObject = JsonConvert.DeserializeObject<ExpandoObject>(valoresFaturados[i].ToString(), converter) as dynamic;
                    var valorFaturado = new ValoresFaturado();

                    valorFaturado.Id = (int)objExpandoObject.id;
                    valorFaturado.IdShopping = (int)objExpandoObject.idShopping;
                    valorFaturado.IdInstrumento = (int)objExpandoObject.idInstrumento;
                    valorFaturado.IdRubrica = (int)objExpandoObject.idRubrica;
                    valorFaturado.MesCompetencia = (int)objExpandoObject.mesCompetencia;
                    valorFaturado.AnoCompetencia = (int)objExpandoObject.anoCompetencia;
                    valorFaturado.MesProcessamento = (int)objExpandoObject.mesProcessamento;
                    valorFaturado.AnoProcessamento = (int)objExpandoObject.anoProcessamento;
                    valorFaturado.ValorCalculado = objExpandoObject.valorCalculado == null ? 0.00 : (double)objExpandoObject.valorCalculado;
                    valorFaturado.ValorFaturado = (double)objExpandoObject.valorFaturado;
                    valorFaturado.VencimentoNd = (DateTime)objExpandoObject.vencimentoNd;
                    valorFaturado.IdSerie = (int)objExpandoObject.idSerie;
                    valorFaturado.eAprovado = (Boolean)objExpandoObject.eAprovado;
                    valorFaturado.IdSeqAltContratoLocacao = objExpandoObject.idSeqAltContratoLocacao == null ? 1 : (int)objExpandoObject.idSeqAltContratoLocacao;
                    valorFaturado.IdDescricaoAlternativa = objExpandoObject.idDescricaoAlternativa == null ? 0 : (int)objExpandoObject.idDescricaoAlternativa;
                    valorFaturado.IdNd = (int)objExpandoObject.idNd;

                    _valoresFaturados.Add(valorFaturado);
                }

                var idnd = 0;

                foreach (var vlrFaturado in _valoresFaturados)
                {
                    if (vlrFaturado.IdNd != idnd)
                    {
                        var nd = this.ndServico.GetById(vlrFaturado.IdNd.GetValueOrDefault());
                        idnd = nd.Id;
                        if (nd.IdLiquidacao > 0)
                            throw new Exception("O Título " + idnd + (nd.IdLiquidacao == 1 ? " possui baixa parcial. " : " já foi liquidado. ") + "Favor reverter a baixa antes de retornar.");
                        nd.IdCobranca = 0; //Exclusão lógica.
                        this.ndServico.Update(nd);
                        this.valoresFaturadosServico.Get(v => v.IdNd == nd.Id).ToList().ForEach(l =>
                        {
                            l.IdNd = null;
                            l.IdItemNd = null;
                            l.IdRemessa = null;
                            this.valoresFaturadosServico.Update(l);
                        });
                    }
                }

                return Ok(_valoresFaturados);
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message);
            }
        }

        [HttpPost]
        [Route("aprovarValores")]
        public IActionResult AprovarValores([FromBody] dynamic[] valoresFaturados)
        {
            try
            {
                List<ValoresFaturado> _valoresFaturados = new List<ValoresFaturado>();
                for (var i = 0; i < valoresFaturados.Length; i++)
                {
                    var converter = new ExpandoObjectConverter();
                    var objExpandoObject = JsonConvert.DeserializeObject<ExpandoObject>(valoresFaturados[i].ToString(), converter) as dynamic;
                    var valorFaturado = new ValoresFaturado();

                    valorFaturado.Id = (int)objExpandoObject.id;
                    valorFaturado.IdShopping = (int)objExpandoObject.idShopping;
                    valorFaturado.IdInstrumento = (int)objExpandoObject.idInstrumento;
                    valorFaturado.IdRubrica = (int)objExpandoObject.idRubrica;
                    valorFaturado.MesCompetencia = (int)objExpandoObject.mesCompetencia;
                    valorFaturado.AnoCompetencia = (int)objExpandoObject.anoCompetencia;
                    valorFaturado.MesProcessamento = (int)objExpandoObject.mesProcessamento;
                    valorFaturado.AnoProcessamento = (int)objExpandoObject.anoProcessamento;
                    valorFaturado.ValorCalculado = objExpandoObject.valorCalculado == null ? 0.00 : (double)objExpandoObject.valorCalculado;
                    valorFaturado.ValorFaturado = (double)objExpandoObject.valorFaturado;
                    valorFaturado.VencimentoNd = (DateTime)objExpandoObject.vencimentoNd;
                    valorFaturado.IdSerie = (int)objExpandoObject.idSerie;
                    valorFaturado.eAprovado = true;
                    valorFaturado.IdSeqAltContratoLocacao = objExpandoObject.idSeqAltContratoLocacao == null ? 1 : (int)objExpandoObject.idSeqAltContratoLocacao;
                    valorFaturado.IdDescricaoAlternativa = objExpandoObject.idDescricaoAlternativa == null ? 0 : (int)objExpandoObject.idDescricaoAlternativa;

                    this.valoresFaturadosServico.Update(valorFaturado);
                }
                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

