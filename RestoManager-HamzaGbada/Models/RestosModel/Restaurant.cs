namespace RestoManager_HamzaGbada.Models.RestosModel
{
    public class Restaurant
    {
        public int CodeResto { get; set; }
        public string NomResto { get; set; } = null!;
        public string Specialite { get; set; } = null!;
        public string Ville { get; set; } = null!;

        public string Tel { get; set; } = null!;

        public int NumProp { get; set; }

        public virtual Proprietaire? Proprietaire { get; set; } 
        public virtual ICollection<Avis> Avis { get; set; }
    }
}
