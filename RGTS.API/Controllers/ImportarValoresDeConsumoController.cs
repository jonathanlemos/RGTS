using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ValueType;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RGTS.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RGTS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportarValoresDeConsumoController : ControllerBase
    {
        //servico
        IValoresFaturadoServico valoresFaturadoServico;

        public ImportarValoresDeConsumoController(IValoresFaturadoServico valoresFaturadoServico)
        {
            this.valoresFaturadoServico = valoresFaturadoServico;
        }

        [HttpPost]
        public NotificacaoPost Post(ImportarValoresDeConsumoModel[] dadosImportacao)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();

            try
            {
                foreach (var _itensNd in dadosImportacao)
                {
                    if (_itensNd.ValoresFaturado.ValorFaturado == null)
                    {
                        notificacaoPost.Mensagem = "Valor faturado não encontrado.";
                    }

                    if (_itensNd.Luc.NomeLuc == null)
                    {
                        notificacaoPost.Mensagem = "Unidade não encontrada.";
                    }

                    if (_itensNd.Rubrica == null || _itensNd.Rubrica.Id <= 0)
                    {
                        notificacaoPost.Mensagem = "Rubrica não encontrada.";
                    }

                    if (notificacaoPost.Mensagem != null)
                    {
                        notificacaoPost.Sucesso = false;
                        return notificacaoPost;
                    }

                    valoresFaturadoServico.SalvarImportacaoDeUnidades(_itensNd.Luc.NomeLuc, _itensNd.Rubrica.Id, (double)_itensNd.ValoresFaturado.ValorFaturado);
                }

                notificacaoPost.Sucesso = true;
                notificacaoPost.Mensagem = "Unidades cadastradas com sucesso.";

                return notificacaoPost;
            }
            catch (Exception e)
            {
                notificacaoPost.Sucesso = false;
                notificacaoPost.Mensagem = "Erro: " + e.Message;

                return notificacaoPost;
            }
        }

    }
}
