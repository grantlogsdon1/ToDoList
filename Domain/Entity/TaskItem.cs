using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class TaskItem
    {
        public int ListItemId { get; set; }

        public int ListId { get; set; }

        public string? Detail { get; set; }

        public bool IsComplete { get; set; }

    }
}
