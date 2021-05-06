using System;
using System.IO;
namespace Slutprojekt
{
    class Program
    {
        /// <summary>
        /// Den ska fylla i alla tomma platser i Todo-Listan
        /// </summary>
        static string TomTodoLista = "plan, datum";
        /// <summary>
        /// Filen för att lagra dagliga planer
        /// </summary>
        static string Filnamn1 = "dagligFil.csv";
        /// <summary>
        /// Array för innehållet i filnamn1
        /// </summary>
        static string[] DagligaTodos;
        static void Main(string[] args)
        {

            //program för en TODO-List
            Console.WriteLine("Detta är en Todo-Lista");
            // DateTime dateNow = DateTime.Now; Visar tiden just nu

            // Console.WriteLine(dateNow);
            //Meny
            string menyVal = "";
            while (menyVal != "5")
            {
                VisaMeny();
                menyVal = Console.ReadLine();
                //switch
                switch (menyVal)
                {
                    case "1":
                        SparaDagligTodo();
                        break;
                    case "2":
                        //  SparaViktigTodo();
                        break;
                    case "3":
                        //VisaTodo();
                        break;
                    case "4":
                        //TaBortTodo();
                        break;
                    case "5":
                        //Avsluta
                        break;
                    default:
                        break;
                }

            }
        }
        /// <summary>
        /// Metoden ska visa menyn
        /// </summary>
        static void VisaMeny()
        {
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine("1. Dagliga planer");
            Console.WriteLine("2. Viktiga planer");
            Console.WriteLine("3. Visa planer");
            Console.WriteLine("4. Ta bort planer");
            Console.WriteLine("5. Avsluta");
        }
        //SparaDagligTodo()
        static void SparaDagligTodo()
        {
            int svar = 0, planNr = 0;
            //string[] delar;
            string plan = "";
            int antalPlaner = 20;
            //Berätta om programmet
            Console.WriteLine("<Spara dina dagliga planer.");
            Console.WriteLine("Endast 20 planer i taget. ");
            Console.WriteLine("Hantera med 'Visa planer' & 'Ta bort planer' i menyn.>");          

            //Skapa filen om den inte redan finns
            if (File.Exists(Filnamn1))
            {
                // Läs in alla rader
                DagligaTodos = File.ReadAllLines(Filnamn1);
            }
            else
            {
                // Skapa en tom Todolista i arrayen
                // Lagra detta i filen
                DagligaTodos = new string[antalPlaner];

                // Fyll arrayen med tomma platser
                for (int i = 0; i < antalPlaner; i++)
                {
                    DagligaTodos[i] = TomTodoLista;
                }

                // Lagra i filen
                File.WriteAllLines(Filnamn1, DagligaTodos);
                Console.WriteLine("Fil med planer saknas, en ny fil skapades");
            }
            //Fråga användaren om en plan
            Console.WriteLine();
            // Ändra innehållet i DagligaTodos

            //Spara det i filen

            // Fråga planNr
            Console.WriteLine("Vilken plan från 1-20 vill du ändra på/lägga till?");
            while (!int.TryParse(Console.ReadLine(), out svar) || svar < 1 || svar > 21)
            {
                Console.WriteLine("Icke giltigt, vg försök igen");
            }
            planNr = svar;

            // Fråga plan
            Console.WriteLine("Ange en plan");
            plan = Console.ReadLine();

            //datum
            string dateNow = DateTime.Now.ToString("dddd, dd MMMM h:mm");
           // dateNow = delar[1];

            // Spara i arrayen
            DagligaTodos[planNr - 1] = $"{plan},{dateNow}";

            // Lagra i filen
            File.WriteAllLines(Filnamn1, DagligaTodos);
            Console.WriteLine("Dina planer sparades");
        }
        //SparaViktigTodo()

        //VisaTodo()
        /*  static void VisaTodo()
          {
              for (int i = 0; i < 20; i++)
              {
                  if (File.Exists(Filnamn1))
                  {
                      // Läs in alla rader
                      DagligaTodos = File.ReadAllLines(Filnamn1);

                  }
                  string[] delar = DagligaTodos[i].Split(',');
                  if (DagligaTodos[i] == TomTodoLista)
                  {
                      // Finns ingen plan
                      Console.WriteLine($"{i + 1} - Tomt");
                  }
                  else
                  {
                      // Planen finns
                      // Plocka ut planen och datumet
                      string plan = delar[0];


                      // Skriv ut informationen
                      Console.WriteLine($"{i + 1} - {plan}");
                  }
              }*/


        //TaBortTodo()

    }
}

