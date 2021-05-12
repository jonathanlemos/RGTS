using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Servicos
{
    public interface IContratoLucsServico : IServicoBase<ContratoLuc>
    {
        ContratoLuc GetInstrumentoIdByLucId(int idLuc);
        ContratoLuc GetLucIdByInstrumentoId(int idInstrumento);
    }
}
