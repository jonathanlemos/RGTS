using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Data.Repositorios
{
    public class ContratoLocacaoRepositorio : RepositorioBase<ContratoLocacao>, IContratoLocacaoRepositorio
    {
        public ContratoLocacao GetByIdInstrumento(int idInstrumento)
        {
            return this.contexto.ContratoLocacao.Where(l => l.IdInstrumento == idInstrumento).FirstOrDefault();
        }
    }

}