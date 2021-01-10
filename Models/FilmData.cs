using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect1.Models
{
    public class FilmData
    {
        public IEnumerable<Film> Filme { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<FilmCategory> FilmCategories { get; set; }




    }
}
