using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect1.Data;
using Proiect1.Models;

namespace Proiect1.Pages.Filme
{
    public class IndexModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public IndexModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        public IList<Film> Film { get; set; }
        public FilmData FilmD { get; set; }
        public int FilmID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            FilmD = new FilmData();

            FilmD.Filme = await _context.Film
            .Include(b => b.Producator)
            .Include(b => b.FilmCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Titlu)
            .ToListAsync();
            if (id != null)
            {
                FilmID = id.Value;
                Film film = FilmD.Filme
                .Where(i => i.ID == id.Value).Single();
                FilmD.Categories = film.FilmCategories.Select(s => s.Category);
            }
        }
    }
}