using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeria.Models
{
    public class Pizze
    {
        [Key]
        public int Id { get; internal set; }
        
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Url(ErrorMessage ="L'Url inserito non è valido")]
        public string Immagine { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Il campo è obbligatorio")]
        [Column(TypeName = "text")]
        public string Descrizione { get; set; }
        public string Prezzo { get; set; }

        public Pizze()
        {

        }
        
        public Pizze(string immagine, string nome, string descrizione, string prezzo)
        {
            this.Immagine = immagine;
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Prezzo = prezzo;
        }
    }
}