using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Data.Repositorios
{
    public class ContratoLucsRepositorio : RepositorioBase<ContratoLuc>, IContratoLucsRepositorio
    {
        public ContratoLuc GetInstrumentoIdByLucId(int idLuc)
        {
            return contexto.ContratoLuc.Where(c => c.IdLuc == idLuc).FirstOrDefault();
        }

        public ContratoLuc GetLucIdByInstrumentoId(int idInstrumento)
        {
            return contexto.ContratoLuc.Where(c => c.IdInstrumento == idInstrumento).FirstOrDefault();            
        }
    }
}