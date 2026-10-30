namespace NutriVie.Models
{
    public class StatVM
    {

        public int Recettes3Aliments { get; set; }
        public string AlimentPlusCalorique { get; set; }
        public List<Recette> RecettesPlusRapides { get; set; }
        public double CaloriesRecetteFrancaiseMoinsCalorique { get; set; }

    }
}
