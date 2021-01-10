using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect1.Data;


namespace Proiect1.Models
{
    public class FilmCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect1Context context,
        Film film)
        {
            var allCategories = context.Category;
            var filmCategories = new HashSet<int>(
            film.FilmCategories.Select(c => c.FilmID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = filmCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateFilmCategories(Proiect1Context context,
        string[] selectedCategories, Film filmToUpdate)
        {
            if (selectedCategories == null)
            {
                filmToUpdate.FilmCategories = new List<FilmCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var filmCategories = new HashSet<int>
            (filmToUpdate.FilmCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!filmCategories.Contains(cat.ID))
                    {
                        filmToUpdate.FilmCategories.Add(
                        new FilmCategory
                        {
                            FilmID = filmToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (filmCategories.Contains(cat.ID))
                    {
                        FilmCategory courseToRemove
                        = filmToUpdate
                        .FilmCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
            {
            }
        }
    }
}
