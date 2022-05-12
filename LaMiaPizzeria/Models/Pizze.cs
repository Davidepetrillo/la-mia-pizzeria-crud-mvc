namespace LaMiaPizzeria.Models
{
    public class Pizze
    {
        public string Immagine { get; set; }
        public string Nome { get; set; }
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