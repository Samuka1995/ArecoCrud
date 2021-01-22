using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class PrivacyModel : PageModel
    {
        //private readonly ILogger<PrivacyModel> _logger;

        //public PrivacyModel(ILogger<PrivacyModel> logger)
        //{
        //    _logger = logger;
        //}
        
        public object DescreveTitulo { get; set; }
        static void OnClickSalvaTarefa()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QFEDCV;Initial Catalog=tarefas;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tarefa(IdTarefa, Titulo, Descricao, DataTarefa, HoraInicio, HoraFim, Prioridade, TarefaFinalizada) VALUES(@IdTarefa, @Titulo, @Descricao)", con))
                {
                    cmd.Parameters.AddWithValue("IdTarefa", 0);
                    cmd.Parameters.AddWithValue("Titulo", "ssss");
                    cmd.Parameters.AddWithValue("Descricao", "x");
                    cmd.Parameters.AddWithValue("DataTarefa", "14/03/1992");
                    cmd.Parameters.AddWithValue("HoraInicio", "10:00");
                    cmd.Parameters.AddWithValue("HoraFim", "12:00");
                    cmd.Parameters.AddWithValue("Prioridade", "Alta");
                    cmd.Parameters.AddWithValue("TarefaFinalizada", "Sim");
                }
            }
        }
    }
}