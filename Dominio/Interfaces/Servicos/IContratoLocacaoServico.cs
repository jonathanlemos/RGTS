using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Servicos
{
    public interface IContratoLocacaoServico : IServicoBase<ContratoLocacao>
    {
        ContratoLocacao GetByIdInstrumento(int idInstrumento);
    }
}
