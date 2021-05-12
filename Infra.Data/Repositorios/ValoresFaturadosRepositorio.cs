using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infra.Data.Repositorios
{
    public class ValoresFaturadosRepositorio : RepositorioBase<ValoresFaturado>, IValoresFaturadosRepositorio
    {

        public List<ValoresFaturado> filter(int tipoInstrumento, int anoMesProcDe, int anoMesProcAte, int[] lucs, int[] marcas, DateTime vencimentoDe, DateTime vencimentoAte, bool? enviados)
        {
            var vrfs = (from vf in contexto.ValoresFaturado
                        join cn in contexto.ContratoLuc on vf.IdInstrumento equals cn.IdInstrumento
                        join cl in contexto.ContratoLocacao on cn.IdInstrumento equals cl.IdInstrumento
                        join it in contexto.Instrumento on cl.IdInstrumento equals it.Id
                        join lu in contexto.Luc on cn.IdLuc equals lu.Id
                        join mc in contexto.Marca on cl.IdMarca equals mc.Id
                        where
                        ((anoMesProcDe == 0) || (vf.AnoProcessamento * 100 + vf.MesProcessamento >= anoMesProcDe && anoMesProcDe > 0)) &&
                        ((anoMesProcAte == 0) || (vf.AnoProcessamento * 100 + vf.MesProcessamento <= anoMesProcAte && anoMesProcAte > 0)) &&
                        ((lucs.Count() == 0) || (lucs.Count() > 0 && lucs.Contains(lu.Id))) &&
                        ((marcas.Count() == 0) || (marcas.Count() > 0 && marcas.Contains(mc.Id))) &&
                        ((vencimentoDe.Date == new DateTime(1901, 2, 1)) || (vf.VencimentoNd >= vencimentoDe && vencimentoDe.Date != new DateTime(1901, 2, 1))) &&
                        ((vencimentoAte.Date == new DateTime(1901, 2, 1)) || (vf.VencimentoNd <= vencimentoAte && vencimentoAte.Date != new DateTime(1901, 2, 1))) &&
                        (it.IdTipoInstrumento == tipoInstrumento) &&
                        ((enviados == true && vf.IdNd > 0) || (enviados == false && (vf.IdNd == null || vf.IdNd == 0)) || (enviados == null))
                        select new
                        {
                            Id = vf.Id,
                            IdRubrica = vf.IdRubrica,
                            IdInstrumento = vf.IdInstrumento,
                            MesCompetencia = vf.MesCompetencia,
                            AnoCompetencia = vf.AnoCompetencia,
                            AnoProcessamento = vf.AnoProcessamento,
                            MesProcessamento = vf.MesProcessamento,
                            IdNd = vf.IdNd,
                            VencimentoNd = vf.VencimentoNd,
                            ValorCalculado = vf.ValorCalculado,
                            eAprovado = vf.eAprovado,
                            IdItemNd = vf.IdItemNd,
                            IdRemessa = vf.IdRemessa,
                            IdSeqAltContratoLocacao = vf.IdSeqAltContratoLocacao,
                            IdDescricaoAlternativa = vf.IdDescricaoAlternativa,
                            ValorFaturado = vf.ValorFaturado
                        })
                        .ToList().Select(a => new ValoresFaturado
                        {
                            Id = a.Id,
                            IdRubrica = a.IdRubrica,
                            IdInstrumento = a.IdInstrumento,
                            MesCompetencia = a.MesCompetencia,
                            AnoCompetencia = a.AnoCompetencia,
                            AnoProcessamento = a.AnoProcessamento,
                            MesProcessamento = a.MesProcessamento,
                            IdNd = a.IdNd,
                            VencimentoNd = a.VencimentoNd,
                            ValorCalculado = a.ValorCalculado,
                            eAprovado = a.eAprovado,
                            IdItemNd = a.IdItemNd,
                            IdRemessa = a.IdRemessa,
                            IdSeqAltContratoLocacao = a.IdSeqAltContratoLocacao,
                            IdDescricaoAlternativa = a.IdDescricaoAlternativa,
                            ValorFaturado = a.ValorFaturado
                        }).ToList();
            return vrfs;
        }
    }

}
