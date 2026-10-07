namespace CinemaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Controls the infinite menu loop until option 0 is chosen
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n Navigera genom att skriva in en siffra (0-4):");
                Console.WriteLine("0. Stäng av programmet");
                Console.WriteLine("1. Ungdom eller pensionär (Pris för 1 person)");
                Console.WriteLine("2. Räkna ut pris för ett helt sällskap");
                Console.WriteLine("3. Upprepa text tio gånger");
                Console.WriteLine("4. Hitta det tredje ordet");
                Console.Write("Ditt val: ");

                string? input = Console.ReadLine();

                // Route user input to the selected feature
                switch (input)
                {
                    case "0":
                        isRunning = false;
                        Console.WriteLine("Programmet avslutas.");
                        break;

                    case "1":
                        CheckSingleTicketPrice();
                        break;

                    case "2":
                        CalculateGroupTicketPrice();
                        break;

                    case "3":
                        RepeatTextTenTimes();
                        break;

                    case "4":
                        ExtractThirdWord();
                        break;

                    default:
                        Console.WriteLine("Felaktig inmatning! Vänligen välj en siffra mellan 0 och 4.");
                        break;
                }
            }
        }

        // Returns ticket price based on age
        static int GetTicketPrice(int age)
        {
            if (age < 20)
            {
                return 80;
            }
            else if (age > 64)
            {
                return 90;
            }
            else
            {
                return 120;
            }
        }

        // Case 1: Evaluates ticket price for a single person
        static void CheckSingleTicketPrice()
        {
            Console.WriteLine("\n--- 1. Priskoll (Enkelbiljett) ---");
            Console.Write("Ange din ålder i siffror: ");

            if (int.TryParse(Console.ReadLine(), out int age) && age >= 0 && age <= 125)
            {
                int price = GetTicketPrice(age);

                if (price == 80)
                {
                    Console.WriteLine("Ungdomspris: 80kr");
                }
                else if (price == 90)
                {
                    Console.WriteLine("Pensionärspris: 90kr");
                }
                else
                {
                    Console.WriteLine("Standardpris: 120kr");
                }
            }
            else
            {
                Console.WriteLine("Felaktig ålder! Du måste ange ett positivt heltal.");
            }
        }

        // Case 2: Calculates total price and head count for a group
        static void CalculateGroupTicketPrice()
        {
            Console.WriteLine("\n--- 2. Räkna ut pris för sällskap ---");
            Console.Write("Hur många personer är ni i sällskapet? ");

            if (int.TryParse(Console.ReadLine(), out int numberOfPeople) && numberOfPeople > 0)
            {
                int totalCost = 0;

                for (int i = 1; i <= numberOfPeople; i++)
                {
                    while (true)
                    {
                        Console.Write($"Ange ålder för person #{i}: ");

                        if (int.TryParse(Console.ReadLine(), out int age) && age >= 0 && age <= 125)
                        {
                            totalCost += GetTicketPrice(age);
                            break;
                        }

                        Console.WriteLine("Felaktig ålder! Ange ett positivt heltal.");
                    }
                }

                Console.WriteLine("\n--- Sammanfattning ---");
                Console.WriteLine($"Antal personer: {numberOfPeople}");
                Console.WriteLine($"Totalkostnad för hela sällskapet: {totalCost}kr");
            }
            else
            {
                Console.WriteLine("Felaktigt antal personer! Ange ett heltal större än 0.");
            }
        }

        // Case 3: Repeats user input 10 times on a single line
        static void RepeatTextTenTimes()
        {
            Console.WriteLine("\n--- 3. Upprepa text tio gånger ---");
            Console.Write("Skriv in en valfri text att upprepa: ");

            string? userText = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(userText))
            {
                Console.WriteLine("\nResultat:");

                for (int i = 1; i <= 10; i++)
                {
                    Console.Write($"{i}. {userText}");

                    if (i < 10)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Texten kan inte vara tom!");
            }
        }

        // Case 4: Splits a sentence by space and retrieves the third word
        static void ExtractThirdWord()
        {
            Console.WriteLine("\n--- 4. Det tredje ordet ---");
            Console.Write("Skriv en mening med minst 3 ord: ");

            string? sentence = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(sentence))
            {
                
                var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (words.Length >= 3)
                {
                    
                    Console.WriteLine($"\nDet tredje ordet är: \"{words[2]}\"");
                }
                else
                {
                    Console.WriteLine($"Meningen hade bara {words.Length} ord. Du måste ange minst 3 ord!");
                }
            }
            else
            {
                Console.WriteLine("Ingen mening angiven!");
            }
        }
    }
}