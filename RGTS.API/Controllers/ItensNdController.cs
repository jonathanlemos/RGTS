using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.ValueType;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Threading.Tasks;

namespace RGTS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItensNdController : ControllerBase
    {
        IItensNdServico itensNdServico;

        private struct RetornoUploadFile{
            public string Unidade { get; set; }
            public String Valor { get; set; }
        }

        public ItensNdController(IItensNdServico itensNdServico)
        {
            this.itensNdServico = itensNdServico;
        }

        [HttpGet]
        [Route("GetIdItensNdEDescricaoAlternativa")]
        public async Task<dynamic> GetIdItensNdEDescricaoAlternativa()
        {
            try
            {
                return await itensNdServico.GetIdItensNdEDescricaoAlternativa();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<dynamic> Upload(ICollection<IFormFile> arquivos, string teste)
        {
            try
            {
                List<RetornoUploadFile> retornoUploadFiles = new List<RetornoUploadFile>();

                if (!Request.HasFormContentType)
                    return BadRequest();

                // create wwwroot\files directory if needed
                //if (!directory.exists(_hostenvironment.webrootpath))
                //{
                //    directoryinfo di =
                //        directory.createdirectory(_hostenvironment.webrootpath);
                //}

                var rootfolder = @"c:\temp\arquivosrgts";

                foreach (IFormFile arquivo in arquivos)
                {
                    RetornoUploadFile retornoUploadFile = new RetornoUploadFile();

                    if (arquivo.Length <= 0)
                        return BadRequest("Arquivo não encontrado.");

                    string fileextension = Path.GetExtension(arquivo.FileName);
                    if (fileextension != ".xls" && fileextension != ".xlsx")
                        return BadRequest("Arquivo .xls ou .xlsx não localizado.");

                    var filename = arquivo.FileName;
                    var filepath = Path.Combine(rootfolder, filename);
                    var filelocation = new FileInfo(filepath);

                    using (OleDbConnection conn = new OleDbConnection())
                    {
                        DataTable dt = new DataTable();
                        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath
                        + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;IMEX=1'";
                        using (OleDbCommand comm = new OleDbCommand())
                        {
                            comm.CommandText = "Select * from [UnidadesValores$]";
                            comm.Connection = conn;
                            using (OleDbDataAdapter da = new OleDbDataAdapter())
                            {
                                da.SelectCommand = comm;
                                da.Fill(dt);

                                foreach (DataRow linha in dt.Rows)
                                {
                                    retornoUploadFile.Unidade = linha["Unidade"].ToString();
                                    retornoUploadFile.Valor = linha["Valor"].ToString();
                                }
                            }
                        }
                    }

                    retornoUploadFiles.Add(retornoUploadFile);
                }

                return retornoUploadFiles;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
