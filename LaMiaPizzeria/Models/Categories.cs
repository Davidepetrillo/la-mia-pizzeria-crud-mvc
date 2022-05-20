using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models
{
    public class Categories
    {
        [Key]
        [Required(ErrorMessage="Il campo è obbligatorio")]
        public int Id { get; set; }
        [StringLength (75, ErrorMessage="Il titolo della categoria non può superare i 75 caratteri")]
        public string NomeCategoria { get; set; }
        public List<Pizze> Pizze { get; set; }

        public Categories()
        {

        }


    }
}
