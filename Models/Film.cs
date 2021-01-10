using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect1.Models
{
    public class Film
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Titlul Filmului")]
        public string Titlu { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Regizor")]
        public string Regizor { get; set; }


        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLansarii { get; set; }
        public int ProducatorID { get; set; }
        public Producator Producator { get; set; }

        public ICollection<FilmCategory> FilmCategories { get; set; }



    }
}
