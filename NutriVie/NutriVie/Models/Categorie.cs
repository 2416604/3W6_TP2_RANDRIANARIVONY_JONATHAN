using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

public class Categorie
{
    [Key]
    public int Id { get; set; }

    public string Nom { get; set; }

    [ValidateNever]
    public List<Recette>? Recettes { get; set; }

}