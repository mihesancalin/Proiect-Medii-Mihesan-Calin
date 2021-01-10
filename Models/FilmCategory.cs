using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect1.Models
{
    public class FilmCategory
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public Film Film { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
