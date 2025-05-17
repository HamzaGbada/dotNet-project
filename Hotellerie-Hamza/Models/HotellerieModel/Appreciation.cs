using System.ComponentModel.DataAnnotations;

namespace Hotellerie_Hamza.Models.HotellerieModel
{
    public class Appreciation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nom Personne est obligatoire.")]
        [Display(Name = "Nom Personne")]
        public string NomPers { get; set; }

        [Required(ErrorMessage = "Le commentaire est obligatoire.")]
        [DataType(DataType.MultilineText)]
        public string Commentaire { get; set; }

        public int? HotelId { get; set; }  // Foreign key to Hotel
        public Hotel Hotel { get; set; }   // Navigation property

        [Required(ErrorMessage = "La note est obligatoire.")]
        [Range(1, 10, ErrorMessage = "La note doit être entre 1 et 10.")]
        public int Note { get; set; } = 5;  // Default value of 5
    }
}
