using System;
using System.IO;
namespace Slutprojekt
{
    class Program
    {
        static string menyVal = "";

        // Den ska fylla i alla tomma platser i Todo-Listan
        static string TomTodoLista = "plan, datum, deadline, klar";



        // Filen för att lagra dagliga planer
        static string Filnamn1 = "dagligFil.csv";

        //Array för innehållet i filnamn1
        static string[] DagligaTodos;


        static void Main(string[] args)
        {

            //program för en TODO-List
            Console.WriteLine("Detta är en Todo-Lista");


            //Meny

            //string menyVal = "";
            while (menyVal != "5")
            {
                VisaMeny(menyVal);

                //switch
                switch (menyVal)
                {
                    case "1":
                        SparaDagligTodo();
                        break;
                    case "2":
                        AvklaradeTodos();
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
        static string VisaMeny(string text)
        {
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine("1. Spara planer");
            Console.WriteLine("2. Markera avklarade planer");
            Console.WriteLine("3. Visa planer");
            Console.WriteLine("4. Ta bort planer");
            Console.WriteLine("5. Avsluta");
            menyVal = Console.ReadLine();
            return menyVal;
        }
        //SparaDagligTodo()
        /// <summary>
        /// Metoden skapar planer i en fil
        /// </summary>
        static void SparaDagligTodo()
        {
            int svar = 0, planNr = 0, deadline = 0;
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

            //Lägg till avklarad-status
            string avklarad = "inte klar";
            //datum
            string datum = DateTime.Now.ToString("dd MMMM h:mm");
            // dateNow = delar[1];

            //Fråga om deadline (vecka 1-52)
            Console.WriteLine("Ange veckan du ska vara klar (v.1 - v.52)");
            while (!int.TryParse(Console.ReadLine(), out svar) || svar < 1 || svar > 53)
            {
                Console.WriteLine("Icke giltigt, vg försök igen");
            }
            deadline = svar;

            // Spara i arrayen
            DagligaTodos[planNr - 1] = $"{plan},{datum},{deadline},{avklarad}";

            // Lagra i filen
            File.WriteAllLines(Filnamn1, DagligaTodos);
            Console.WriteLine("Dina planer sparades");
        }
        //AvklaradeTodos
        static void AvklaradeTodos()
        {

            if (File.Exists(Filnamn1))
            {
                // Läs in alla rader
                DagligaTodos = File.ReadAllLines(Filnamn1);
                int planNr = 0, svar = 0;
                // Fråga planNr
                Console.WriteLine("Vilken plan från 1-20 är du klar med?");
                while (!int.TryParse(Console.ReadLine(), out svar) || svar < 1 || svar > 21)
                {
                    Console.WriteLine("Icke giltigt, vg försök igen");
                }
                planNr = svar;


                string[] delar = DagligaTodos[planNr - 1].Split(',');
                string plan = delar[0];
                string datum = delar[1];
                string deadline = delar[2];
                string avklarad = "KLAR";



                // Spara i arrayen
                DagligaTodos[planNr - 1] = $"{plan},{datum},{deadline},{avklarad} ";

                // Lagra i filen
                File.WriteAllLines(Filnamn1, DagligaTodos);
                Console.WriteLine("Dina planer sparades");
            }
            else
            {
                // be användaren lägga till planer först
                Console.WriteLine("Fil med planer saknas, en ny fil med planer skapas via <Spara planer>");
            }



        }

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
            }
            for (int i = 0; i < antalPlaner; i++)
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
                    string deadline = delar[2];
                    string avklarad = delar[3];



                    Console.WriteLine($" {i + 1} - Plan: {plan}, Ändrad: {datum}, Deadline: vecka {deadline}, status: {avklarad}");




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

