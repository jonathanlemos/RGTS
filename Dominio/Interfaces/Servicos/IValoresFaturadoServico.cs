using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.ValueType;

namespace Dominio.Interfaces.Servicos
{
    public interface IValoresFaturadoServico : IServicoBase<ValoresFaturado>
    {
        public NotificacaoPost SalvarImportacaoDeUnidades(string pNomeUnidade, int pIdRubrica, double pValorFaturado);
    }
}
