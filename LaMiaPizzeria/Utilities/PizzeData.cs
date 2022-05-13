using LaMiaPizzeria.Models;

namespace LaMiaPizzeria.Utilities
{
    public static class PizzeData
    {
        private static List<Pizze> pizze;


        public static List<Pizze> GetPizze()
        {
            if(PizzeData.pizze != null)
            {
                return PizzeData.pizze;
            }
            List<Pizze> nuovaListaPizze = new List<Pizze>();

            for(int i =0; i <5; i++)
            {
                Pizze NuovaPizza = new Pizze(i, "https://picsum.photos/id/" + i + "/300/200", "Nome della Pizza", "Descrizione della pizza", "prezzo");
                nuovaListaPizze.Add(NuovaPizza);
            }
            PizzeData.pizze = nuovaListaPizze;
            return PizzeData.pizze;
        }
    }
}
