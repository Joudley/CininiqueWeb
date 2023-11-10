using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace Hopital.Model
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        public int ConsultationId { get; set; }
        public Consultation Consultation { get; set; }
        public string Prescrire { get; set; }   = string.Empty;

    }
}