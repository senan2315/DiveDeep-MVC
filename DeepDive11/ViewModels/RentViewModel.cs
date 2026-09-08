using DeepDive11.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DeepDive11.ViewModels
{
    public class RentViewModel
    {
        [ValidateNever]
        public Products? Product { get; set; }

        public string? SelectedSize { get; set; }

        [Range(1, 100, ErrorMessage = "Antal skal være mindst 1.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Du skal vælge en startdato.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Du skal vælge en slutdato.")]
        public DateTime? EndDate { get; set; }

        public int TotalPrice { get; set; }
    }
}
