using Newtonsoft.Json;
//wymagane do serializacji i deserializacji
using System;
using System.ComponentModel.Design;



namespace Restauracja
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WyswietlInterfejs();
        }

        public static void WyswietlInterfejs()
        {
            Console.WriteLine("Witaj!\nWybierz dostępną opcje:");
            Console.WriteLine("Wyświetl menu - wpisz 1");
            Console.WriteLine("Dodaj Posiłek/Deser - wpisz 2");
            Console.WriteLine("Usuń Posiłek/Deser - wpisz 3");
            Console.WriteLine("Wyjdź - wpisz 4");

            if (int.TryParse(Console.ReadLine(), out int wybor)) 
            {
                //sprawdzenie czy wprowadzona wartosc jest liczba jesli tak to idzie do inta 'wybor'
                switch (wybor)
                {
                    case 1:
                        WyswietlMenu();
                        break;
                    case 2:
                        DodajDoMenu();
                        break;
                    case 3:
                        //UsunPosilek();
                        break;
                    case 4:
                        Console.WriteLine("Do zobaczenia!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór!");
                        break;
                }
            }
            else
            {
                //jesli wprowadzona wartosc nie jest liczba
                Console.WriteLine("Niepoprawny wybór!");
                Environment.Exit(0);
            }

        }

        public static void WyswietlMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu: \n\n");
            Console.WriteLine("Posiłki: \n"); 

            string jsonposilki = File.ReadAllText("Posilki.json");
            //odczyt pliku z posilkami json do stringa jsonposilki

            List<PosilkiModel> posilki = JsonConvert.DeserializeObject<List<PosilkiModel>>(jsonposilki);
            //deserializacja jsona do listy z PosilkiModel

            foreach (var posilek in posilki)
            {
                Console.WriteLine(
                    $"Numer Dania: {posilek.ID}\n" +
                    $"Nazwa: {posilek.Nazwa}\n" +
                    $"Cena: {posilek.Cena}zł\n");
            }

            Console.WriteLine("Desery: \n");

            string jsondesery = File.ReadAllText("Desery.json");
            //odczyt pliku z deserami json do stringa jsondesery

            List<DeserModel> desery = JsonConvert.DeserializeObject<List<DeserModel>>(jsondesery);
            //deserializacja jsona do listy z DeserModel

            foreach (var deser in desery)
            {
                Console.WriteLine(
                    $"Numer Deseru: {deser.ID}\n" +
                    $"Nazwa: {deser.Nazwa}\n" +
                    $"Cena: {deser.Cena}zł\n" +
                    $"Gramatura: {deser.Gramatura}g\n" +
                    $"Opis: {deser.Opis}\n");
            }
        }

        public static void DodajDoMenu()
        {
            Console.Clear();
            Console.WriteLine("Wybierz co chcesz dodać: \n");
            Console.WriteLine("Posiłek - wpisz 1");
            Console.WriteLine("Deser - wpisz 2");
            
            if(int.TryParse(Console.ReadLine(), out int wybor))
            {
                switch (wybor)
                {
                    case 1:
                        string jsonposilki = File.ReadAllText("Posilki.json");
                        List<PosilkiModel> posilki = JsonConvert.DeserializeObject<List<PosilkiModel>>(jsonposilki);
                        //deserializacja jsona do listy z PosilkiModel
                        
                        Console.WriteLine("Podaj nazwę posiłku: ");
                        string nazwa = Console.ReadLine(); // odczytanie nazwy posiłku

                        Console.WriteLine("Podaj cenę posiłku: (używając '.')");
                        float cena = float.Parse(Console.ReadLine()); // odczytanie ceny posiłku

                        posilki.Add(new PosilkiModel
                        {
                            ID = (uint)posilki.Count + 1,
                            Nazwa = nazwa,
                            Cena = cena
                        }); 
                        // Dodanie nowego posiłku do listy

                        jsonposilki = JsonConvert.SerializeObject(posilki);
                        File.WriteAllText("Posilki.json", jsonposilki);
                        //zapiseanie zmian w pliku json

                        Console.WriteLine($"Posilek: {nazwa} o cenie {cena}zł został dodany i oznaczony numerem {posilki.Count}");
                        break;
                    case 2:
                        string jsondesery = File.ReadAllText("Desery.json");
                        List<DeserModel> desery = JsonConvert.DeserializeObject<List<DeserModel>>(jsondesery);

                        Console.WriteLine("Podaj nazwę deseru: ");
                        string nazwaD = Console.ReadLine(); // odczytanie nazwy deseru
                        Console.Clear();

                        Console.WriteLine("Podaj cene deseru: (np. 14.99)");
                        float cenaD = float.Parse(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Podaj gramaturę deseru: (l. calkowita)");
                        int gramatura = int.Parse(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Podaj opis deseru: ");
                        string opis = Console.ReadLine();
                        Console.Clear();

                        jsondesery = JsonConvert.SerializeObject(desery);
                        File.WriteAllText("Desery.json", jsondesery);

                        Console.WriteLine($"Deser: {nazwaD} o cenie {cenaD}zł, gramaturze {gramatura}g i opisie: {opis} został dodany i oznaczony numerem {desery.Count}.");
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór!");
                Environment.Exit(0);
            }

        }


    }

}
