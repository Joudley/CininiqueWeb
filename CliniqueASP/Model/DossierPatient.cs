#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Hopital.Model
{
    public class DossierPatient
    {
        [Key]
        public int Code { get; set; }
        public string Nom { get; set; }  = string.Empty;
        public string Prenom { get; set; }  = string.Empty;
        public string Sexe { get; set; }  = string.Empty;
        public string Telephone { get; set; }  = string.Empty;
        public string Adresse { get; set; }  = string.Empty;
        public DateTime ConsultationDate { get; set; }
        public List<Consultation> Consultation { get; set; }

    }
}