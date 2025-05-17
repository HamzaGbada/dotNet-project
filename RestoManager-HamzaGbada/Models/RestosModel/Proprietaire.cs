namespace RestoManager_HamzaGbada.Models.RestosModel
{
    public class Proprietaire
    {
        public int Numero { get; set; }
        public string Nom { get; set; } = null!;
        public string Email { get; set; } = null!; 
        public string Gsm { get; set; } = null!; 

        public virtual ICollection<Restaurant> Restaurants { get; set; } 

    }
}
