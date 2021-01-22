using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using CRUD_AgendaTarefas.Models;

namespace CRUD_AgendaTarefa.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public IEnumerable<TarefaClass> GetTarefa { get; set; }

        public void OnGet()
        {
            GetTarefa = LerRetornoTarefa();
        }

        public static List<TarefaClass> LerRetornoTarefa()
        {
            List<TarefaClass> ListaTarefas = new List<TarefaClass>();
            string conexao = "Data Source=DESKTOP-9QFEDCV;Initial Catalog=tarefas;Integrated Security=True";
            using (SqlConnection sqlconexao = new SqlConnection(conexao))
            {
                using (SqlCommand sqlcomando = new SqlCommand("select * from tarefa", sqlconexao))
                {
                    sqlconexao.Open();
                    using (SqlDataReader sdr = sqlcomando.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            TarefaClass tc = new TarefaClass();
                            tc.IdTarefa = Convert.ToInt32(sdr["IdTarefa"]);
                            tc.Titulo = Convert.ToString(sdr["Titulo"]);
                            tc.Descricao = ((string)sdr["Descricao"]);
                            tc.DataTarefa = (DateTime)(sdr["DataTarefa"]);
                            tc.HoraInicio = (TimeSpan)(sdr["HoraInicio"]);
                            tc.HoraFim = (TimeSpan)(sdr["HoraFim"]);
                            tc.Prioridade = ((string)sdr["Prioridade"]);
                            tc.TarefaFinalizada = (string)(sdr["TarefaFinalizada"]);
                            ListaTarefas.Add(tc);
                        }
                    }
                    return ListaTarefas;
                }
            }
        }

      //IEnumerable<TarefaClass> PostTarefa { get; set; }
      //  public void OnPost()
      //  {
      //      PostTarefa = PostagemAssincrona;
      //  }

        public IActionResult PostagemAssincrona(TarefaClass tcinsert)
        {
            string conexao = "Data Source=DESKTOP-9QFEDCV;Initial Catalog=tarefas;Integrated Security=True";
            using (SqlConnection sqlconexao = new SqlConnection(conexao))
            {
                string InserirDados = "Insert into tarefa Values('" + tcinsert.IdTarefa + "','" + tcinsert.Titulo + "','" + tcinsert.Descricao + "','" + tcinsert.DataTarefa + "','" + tcinsert.HoraInicio + "','" + tcinsert.HoraFim + "','" + tcinsert.Prioridade + "','" + tcinsert.TarefaFinalizada + "')";
                using (SqlCommand sqlcomando = new SqlCommand(InserirDados, sqlconexao))
                {
                    sqlconexao.Open();
                    sqlcomando.ExecuteNonQuery();
                }
            }
            return RedirectToPage("Index");
        }
    }
}

