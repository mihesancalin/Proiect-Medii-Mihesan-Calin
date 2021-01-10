using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect1.Data;
using Proiect1.Models;

namespace Proiect1.Pages.Filme
{
    public class EditModel : FilmCategoriesPageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public EditModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Film Film { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            Film = await _context.Film
 .Include(b => b.Producator)
 .Include(b => b.FilmCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            if (Film == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Film);

            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var filmToUpdate = await _context.Film
            .Include(i => i.Producator)
            .Include(i => i.FilmCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (filmToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Film>(
            filmToUpdate,
            "Film",
            i => i.Titlu, i => i.Regizor,
            i => i.Pret, i => i.DataLansarii, i => i.Producator))
            {
                UpdateFilmCategories(_context, selectedCategories, filmToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateFilmCategories pentru a aplica informatiile din checkboxuri la entitatea Filme care
            //este editata
            UpdateFilmCategories(_context, selectedCategories, filmToUpdate);
            PopulateAssignedCategoryData(_context, filmToUpdate);
            return Page();
        }
    }
}


