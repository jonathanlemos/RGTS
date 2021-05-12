using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Repositorios
{
    public interface IContratoLocacaoRepositorio : IRepositorioBase<ContratoLocacao>
    {
        ContratoLocacao GetByIdInstrumento(int idInstrumento);
    }
}
