#nullable disable

namespace Hopital.Model
{
    public class Medecin
    {
        public int MedecinId { get; set; }
        public string Nom { get; set; }  = string.Empty;
        public string Prenom { get; set; }  = string.Empty;
        public string Sexe { get; set; }  = string.Empty;
        public string Telephone { get; set; }  = string.Empty;
        public string Address { get; set; }  = string.Empty;
        public string Email { get; set; }  = string.Empty;
        public string Specialite { get; set; }  = string.Empty;
        public List<Consultation> Consultation { get; set; }

    }
}