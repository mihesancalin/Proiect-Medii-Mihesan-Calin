using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect1.Data;
using Proiect1.Models;

namespace Proiect1.Pages.Filme
{
    public class CreateModel : FilmCategoriesPageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public CreateModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");

            var film = new Film();
            film.FilmCategories = new List<FilmCategory>();
            PopulateAssignedCategoryData(_context, film);

            return Page();
        }

        [BindProperty]
        public Film Film { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newFilm = new Film();
            if (selectedCategories != null)
            {
                newFilm.FilmCategories = new List<FilmCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new FilmCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newFilm.FilmCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Film>(
            newFilm,
            "Film",
            i => i.Titlu, i => i.Regizor,
            i => i.Pret, i => i.DataLansarii, i => i.ProducatorID))
            {
                _context.Film.Add(newFilm);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newFilm);
            return Page();
        }
    }
}

    
