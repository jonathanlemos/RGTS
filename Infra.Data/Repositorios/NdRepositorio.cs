using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class NdRepositorio : RepositorioBase<Nd>, INdRepositorio
    {
        public List<Nd> filter(int tipoInstrumento, int[] lucs, int[] marcas, DateTime vencimentoDe, DateTime vencimentoAte)
        {
            var nds = (from nd in contexto.Nd
                       join it in contexto.Instrumento on nd.IdInstrumento equals it.Id
                       join cl in contexto.ContratoLocacao on it.IdInstrumentoContrato equals cl.IdInstrumento
                       join cn in contexto.ContratoLuc on cl.IdInstrumento equals cn.IdInstrumento
                       join lu in contexto.Luc on cn.IdLuc equals lu.Id
                       join mc in contexto.Marca on cl.IdMarca equals mc.Id
                       where
                       cl.EAtivo == true &&
                       nd.IdCobranca == 1 &&
                       nd.IdLiquidacao < 2 &&
                       ((lucs.Count() == 0) || (lucs.Count() > 0 && lucs.Contains(lu.Id))) &&
                       ((marcas.Count() == 0) || (marcas.Count() > 0 && marcas.Contains(mc.Id))) &&
                       ((vencimentoDe.Date == new DateTime(1901, 2, 1)) || (nd.Vencimento >= vencimentoDe && vencimentoDe.Date != new DateTime(1901, 2, 1))) &&
                       ((vencimentoAte.Date == new DateTime(1901, 2, 1)) || (nd.Vencimento <= vencimentoAte && vencimentoAte.Date != new DateTime(1901, 2, 1))) &&
                       (it.IdTipoInstrumento == tipoInstrumento)
                       select new
                       {
                           Id = nd.Id,
                           IdInstrumento = nd.IdInstrumento,
                           AnoProcessamento = nd.AnoProcessamento,
                           MesProcessamento = nd.MesProcessamento,
                           Vencimento = nd.Vencimento,
                           ValorOriginal = nd.ValorOriginal,
                           ValorPrincipal = nd.ValorPrincipal,
                           ValorSaldo = nd.ValorSaldo,
                           Remessa = nd.Remessa
                       })
                        .ToList().Select(a => new Nd
                        {
                            Id = a.Id,
                            IdInstrumento = a.IdInstrumento,
                            AnoProcessamento = a.AnoProcessamento,
                            MesProcessamento = a.MesProcessamento,
                            Vencimento = a.Vencimento,
                            ValorOriginal = a.ValorOriginal,
                            ValorPrincipal = a.ValorPrincipal,
                            ValorSaldo = a.ValorSaldo,
                            Remessa = a.Remessa
                        }).ToList();
            return nds;
        }
    }
}
