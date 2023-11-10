#nullable disable

namespace Hopital.Model
{
    public class Consultation
    {
        public int ConsultationId { get; set; }
        public int MedecinId { get; set; }
        public Medecin Medecin { get; set; }   
        public int CodePatient { get; set; }  
        public string Poids { get; set; }   = string.Empty;
        public string Hauteur { get; set; }   = string.Empty;
        public string Diagnostique { get; set; }   = string.Empty;
        public DateTime ConsultationDate { get; set; }
        public List<Prescription> Prescription { get; set; }
        public List<DossierPatient> DossierPatient { get; set; }

        
    }
}