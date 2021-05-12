using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;

namespace Dominio.Serviços
{
    public class MensagemBoletoServico : ServicoBase<MensagemBoleto>, IMensagemBoletoServico
    {
        private readonly IMensagemBoletoRepositorio _mensagemBoletoRepositorio;

        public MensagemBoletoServico(IMensagemBoletoRepositorio mensagemBoletoRepositorio) : base(mensagemBoletoRepositorio)
        {
            this._mensagemBoletoRepositorio = mensagemBoletoRepositorio;
        }
    }
}
