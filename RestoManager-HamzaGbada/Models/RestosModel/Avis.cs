using System.ComponentModel.DataAnnotations;

namespace RestoManager_HamzaGbada.Models.RestosModel
{
    public class Avis
    {
        public int CodeAvis { get; set; }
        public string NomPersonne { get; set; } = null!;
        [Range(1,5)]
        public int Note { get; set; }
        public DateOnly DateArr { get; set; }
        public string Commentaire { get; set; } = null!;
        
        public int NumResto { get; set; }

        public Restaurant? Restaurant { get; set; }
    }
}
