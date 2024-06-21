public static class Input
{
    public static DateTime InputDateTime(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime date))
            {
                return date;
            }
            else
                Console.WriteLine("Please enter the correct date format: yyy-mm-dd");
        }
    }

    public static string InputString(string prompt)
    {

        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
                Console.WriteLine("The input can't be empty");
        }
    }

    public static int InputInt(string prompt, int minValue, int maxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= minValue && value <= maxValue)
            {
                return value;
            }
            else
                Console.WriteLine("You have typed the wrong input values");
        }

    }

}