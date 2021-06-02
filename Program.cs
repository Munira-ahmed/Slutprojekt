using System;
using System.IO;
namespace Slutprojekt
{
    class Program
    {
        static int antalPlaner = 20;

        //static string MenyVal = "";

        // Den ska fylla i alla tomma platser i Todo-Listan
        static string TomTodoLista = "plan, datum, deadline, klar";

        // Filen för att lagra planer
        static string Filnamn = "dagligFil.csv";

        //Array för innehållet i filnamn1
        static string[] Todos;


        static void Main(string[] args)
        {

            //program för en TODO-List & Berätta om programmet
            System.Console.WriteLine("---------------------------");
            Console.WriteLine("Detta är en Todo-Lista");
            Console.WriteLine("<Spara dina planer.");
            Console.WriteLine("Endast 20 planer i taget. >");
            System.Console.WriteLine();

            //Meny
      
           string menyVal = "";
            while (menyVal != "5")
            {
                menyVal = VisaMeny();
               // VisaMeny(menyVal);

                //switch
                switch (menyVal)
                {
                    case "1":
                        SparaTodos();
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
        static string VisaMeny()
        {
            string val = "";
            System.Console.WriteLine("--------------------------");
            Console.WriteLine("Välj ett alternativ (1-5) :");
            Console.WriteLine("1. Spara planer");
            Console.WriteLine("2. Markera avklarade planer");
            Console.WriteLine("3. Visa planer");
            Console.WriteLine("4. Ta bort planer");
            Console.WriteLine("5. Avsluta");
            val = Console.ReadLine();
            return val;
        }

        //SparaTodos()
        /// <summary>
        /// Metoden skapar planer i en fil
        /// </summary>
        static void SparaTodos()

        {
            int svar = 0, planNr = 0, deadline = 0;
            string plan = "";
            SkapaFil();

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
            string avklarad = "❌";

            //datum
            string datum = DateTime.Now.ToString("dd MMMM h:mm");

            //Fråga om deadline (vecka 1-52)
            Console.WriteLine("Ange veckan du ska vara klar (v.1 - v.52)");
            while (!int.TryParse(Console.ReadLine(), out svar) || svar < 1 || svar > 53)
            {
                Console.WriteLine("Icke giltigt, vg försök igen");
            }
            deadline = svar;

            // Spara i arrayen
            Todos[planNr - 1] = $"{plan},{datum},{deadline},{avklarad}";

            // Lagra i filen
            File.WriteAllLines(Filnamn, Todos);
            Console.WriteLine("Dina planer sparades");
        }

        //AvklaradeTodos
        /// <summary>
        /// Metoden lägger till en "Checkmark" på den valda planen
        /// </summary>
        static void AvklaradeTodos()
        {

            if (File.Exists(Filnamn))
            {
                // Läs in alla rader
                Todos = File.ReadAllLines(Filnamn);
                int planNr = 0, svar = 0;
                // Fråga planNr
                Console.WriteLine("Vilken plan från 1-20 är du klar med?");
                while (!int.TryParse(Console.ReadLine(), out svar) || svar < 1 || svar > 21)
                {
                    Console.WriteLine("Icke giltigt, vg försök igen");
                }
                planNr = svar;


                string[] delar = Todos[planNr - 1].Split(',');
                string plan = delar[0];
                string datum = delar[1];
                string deadline = delar[2];
                string avklarad = "✔️";



                // Spara i arrayen
                Todos[planNr - 1] = $"{plan},{datum},{deadline},{avklarad} ";

                // Lagra i filen
                File.WriteAllLines(Filnamn, Todos);
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
            SkapaFil();
            for (int i = 0; i < antalPlaner; i++)
            {

                if (Todos[i] == TomTodoLista)
                {
                    //  tomt
                    Console.WriteLine($"{i + 1} - Ingen plan");
                }
                else
                {
                    // Plocka ut plan och datum
                    string[] delar = Todos[i].Split(',');
                    string plan = delar[0];
                    string datum = delar[1];
                    string deadline = delar[2];
                    string avklarad = delar[3];

                    Console.OutputEncoding = System.Text.Encoding.UTF8;

                    Console.WriteLine($" {i + 1} - Plan: {plan}, Ändrad: {datum}, Deadline: vecka {deadline}, avklarad: {avklarad}");

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
            SkapaFil();

            // Fråga planNr
            Console.WriteLine("Vilken plan från 1-20 vill du Ta bort?");
            while (!int.TryParse(Console.ReadLine(), out svar) || svar < 1 || svar > 21)
            {
                Console.WriteLine("Icke giltigt, vg försök igen");
            }
            planNr = svar;


            // Spara i arrayen
            Todos[planNr - 1] = TomTodoLista;

            // Lagra i filen
            File.WriteAllLines(Filnamn, Todos);
            Console.WriteLine("Dina planer sparades");
        }

        static void SkapaFil()
        {

            //Skapa filen om den inte redan finns
            if (File.Exists(Filnamn))
            {
                // Läs in alla rader
                Todos = File.ReadAllLines(Filnamn);
            }
            else
            {
                // Skapa en tom Todolista i arrayen
                // Lagra detta i filen
                Todos = new string[antalPlaner];

                // Fyll arrayen med tomma platser
                for (int i = 0; i < antalPlaner; i++)
                {
                    Todos[i] = TomTodoLista;
                }

                // Lagra i filen
                File.WriteAllLines(Filnamn, Todos);
                Console.WriteLine("Fil med planer saknas, en ny fil skapades");
            }

        }

    }
}

