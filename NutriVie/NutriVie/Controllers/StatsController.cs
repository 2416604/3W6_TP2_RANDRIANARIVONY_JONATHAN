
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriVie.Models;
using NutriVie.Models.Data;

namespace NutriVie.Controllers
{
    public class StatsController : Controller
    {
        private readonly NutriVieDbContext _context;

        public StatsController(NutriVieDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            StatVM vm = new StatVM();

            vm.Recettes3Aliments = await _context.Recettes
                .CountAsync(r => r.AlimentRecettes.Count == 3);

            vm.AlimentPlusCalorique = await _context.Aliments
                .OrderByDescending(a => a.CaloriesPour100g)
                .Select(a => a.Nom)
                .FirstOrDefaultAsync();

            vm.RecettesPlusRapides = await _context.Recettes
                .OrderBy(r => r.TempsPreparation + r.TempsCuisson)
                .Take(4).ToListAsync();

            vm.CaloriesRecetteFrancaiseMoinsCalorique = await _context.Recettes
                .Where(r => r.Categorie.Nom == "Française")
                .MinAsync(r => r.AlimentRecettes.Sum(a =>
                    a.Poids * a.Aliment.CaloriesPour100g / 100));

            return View(vm);
        }
    }
}
