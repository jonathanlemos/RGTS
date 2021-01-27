using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.ValueType
{
    public class NotificacaoPost
    {
        public bool Sucesso { get { return true; } set { Sucesso = value; } }

        public string Mensagem { get { return "Salvo com sucesso.";  } set { Mensagem = value; } }
    }
}
