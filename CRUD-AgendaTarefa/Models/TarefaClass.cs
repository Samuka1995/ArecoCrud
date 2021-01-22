using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUD_AgendaTarefas.Models
{
    public class TarefaClass
    {
        [Key]
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataTarefa { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string Prioridade { get; set; }
        public string TarefaFinalizada { get; set; }
    }
}
