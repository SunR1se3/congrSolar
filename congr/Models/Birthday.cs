using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace congr.Models
{
    public class Birthday
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public string Photo { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }



    }
}
