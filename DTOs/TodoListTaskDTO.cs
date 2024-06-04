using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TodoListTaskDTO
    {
        public int TaskId { get; set; }

        public int ListId { get; set; }

        public string? Detail { get; set; }

        public bool IsComplete { get; set; }

        public DateTime CreatedDateTime { get; set; }


    }
}
