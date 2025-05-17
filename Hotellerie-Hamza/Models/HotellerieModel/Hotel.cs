using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hotellerie_Hamza.Models.HotellerieModel
{
    public class Hotel
    {
        [Key]
        public int id { get; set; }
        
        [Required(ErrorMessage =" This Field is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="String Length should be less then 20 and more than 3 chars")]
        public string name { get; set; }

        [Range(1,5, ErrorMessage = "Stars should be between 1 and 5")]
        public int? stars { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }
        [Required(ErrorMessage = "WebSite is required")]
        [Url(ErrorMessage ="This should be a valid URL")]
        [DisplayName("Web Site")]
        public string website { get; set; }

        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string Tel { get; set; } // This is the new property

        // Add navigation property for appreciations
        public ICollection<Appreciation> Appreciations { get; set; }  // Navigation property
        public string Pays { get; set; } = "Tunisie";  // Default value

    }
}
