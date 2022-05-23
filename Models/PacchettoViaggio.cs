using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;




namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Il nome del pacchetto è obbligatorio")]
        [StringLength(20, ErrorMessage ="Il nome del pacchetto non può contenere più di 20 caratteri")]
        public string NomePacchetto { get; set; }

        [Required(ErrorMessage = "E' obbligatoria una descrizione del pacchetto viaggio")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage ="E' necessario inserire il costo del pacchetto")]
        public int Prezzo { get; set; }

        [Required(ErrorMessage ="E' obbligatorio inserire un'immagine")]
        [Url(ErrorMessage = "URL non valido")]
        public string UrlImmagine { get; set; }

        public PacchettoViaggio ()
        { }

        public PacchettoViaggio (int Id, string NomePacchetto, string Descrizione, int Prezzo, string UrlImmagine)
        {
            this.Id = Id;
            this.NomePacchetto = NomePacchetto;
            this.Descrizione = Descrizione;
            this.Prezzo = Prezzo;
            this.UrlImmagine = UrlImmagine;
        }













    }
}
