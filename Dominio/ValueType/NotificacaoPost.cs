using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.ValueType
{
    public class NotificacaoPost
    {
        private string mensagem = "Salvo com sucesso.";
        private bool sucesso = true;

        public bool Sucesso { get { return sucesso; } set { sucesso = value; } }

        

        public string Mensagem { get { return mensagem; } set { mensagem = value; } }
    }
}
