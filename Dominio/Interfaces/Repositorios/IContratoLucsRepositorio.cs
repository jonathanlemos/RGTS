using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Repositorios
{
    public interface IContratoLucsRepositorio : IRepositorioBase<ContratoLuc>
    {
        ContratoLuc GetInstrumentoIdByLucId(int idLuc);
        ContratoLuc GetLucIdByInstrumentoId(int idInstrumento);
    }
}
