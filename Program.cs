using System;
using System.IO;
namespace Slutprojekt
{
    class Program
    {

        // Den ska fylla i alla tomma platser i Todo-Listan
        static string TomTodoLista = "plan, datum";

        // Filen för att lagra dagliga planer
        static string Filnamn1 = "dagligFil.csv";

        //Array för innehållet i filnamn1
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
                        SparaDagligTodo(); //Lägg till Deadline istället för datum
                        break;
                    case "2":
                        //Lägg till när en TOdo är klar 
                        //  SparaViktigTodo();
                        break;
                    case "3":
                        VisaTodo();
                        break;
                    case "4":
                        TaBortTodo();
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
        /// <summary>
        /// Metoden skapar planer i en fil
        /// </summary>
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
            string datum = DateTime.Now.ToString("dddd, dd MMMM h:mm");
            // dateNow = delar[1];

            // Spara i arrayen
            DagligaTodos[planNr - 1] = $"{plan},{datum}";

            // Lagra i filen
            File.WriteAllLines(Filnamn1, DagligaTodos);
            Console.WriteLine("Dina planer sparades");
        }
        //x()
        
        //VisaTodo()
        /// <summary>
        /// Metoden visar planerna i filen
        /// </summary>
        static void VisaTodo()
        {
            int antalPlaner = 20;
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
            }for (int i = 0; i < antalPlaner; i++)
            {
                if (DagligaTodos[i] == TomTodoLista)
                {
                    //  tomt
                    Console.WriteLine($"{i + 1} - Ingen plan");
                }
                else
                {
                 // Plocka ut plan och datum
                    string[] delar = DagligaTodos[i].Split(',');
                    string plan = delar[0];
                    string datum = delar[1];

                    Console.WriteLine($" {i + 1} - Plan: {plan}, Datum: {datum}");
                }
            }
        }

        //TaBortTodo()
        /// <summary>
        /// Metoden tar bort planer från filen
        /// </summary>
        static void TaBortTodo()
        {
            int svar = 0, planNr = 0;
            int antalPlaner = 20;

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

            // Fråga planNr
            Console.WriteLine("Vilken plan från 1-20 vill du Ta bort?");
            while (!int.TryParse(Console.ReadLine(), out svar) || svar < 1 || svar > 21)
            {
                Console.WriteLine("Icke giltigt, vg försök igen");
            }
            planNr = svar;


            // Spara i arrayen
            DagligaTodos[planNr - 1] = TomTodoLista;

            // Lagra i filen
            File.WriteAllLines(Filnamn1, DagligaTodos);
            Console.WriteLine("Dina planer sparades");
        }

    }
}

