using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class ServicoCobrancaServico : ServicoBase<ServicoCobranca>, IServicoCobrancaServico
    {
        private readonly IServicoCobrancaRepositorio servicoCobrancaRepositorio;

        public ServicoCobrancaServico(IServicoCobrancaRepositorio servicoCobrancaRepositorio) : base(servicoCobrancaRepositorio)
        {
            this.servicoCobrancaRepositorio = servicoCobrancaRepositorio;
        }
    }
}
