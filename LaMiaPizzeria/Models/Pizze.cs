using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models
{
    public class Pizze
    {
        public int Id { get; internal set; }
        
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Url(ErrorMessage ="L'Url inserito non è valido")]
        public string Immagine { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Il campo è obbligatorio")]
        public string Descrizione { get; set; }
        public string Prezzo { get; set; }

        public Pizze()
        {

        }
        
        public Pizze(int id, string immagine, string nome, string descrizione, string prezzo)
        {
            this.Id = id;
            this.Immagine = immagine;
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Prezzo = prezzo;
        }
    }
}