// Contestant ID: ____________
// BPA 330 Week 1 Practice — Button Logic Trainer
// Fill in each method. Keep the program compiling at all times.

using System;

class Program
{
    // Purpose: return the input text reversed.
    // Parameters: input — the text to reverse.  Returns: the reversed string.
    static string ReverseText(string input)
    {
        // Processing: build the string back-to-front (loop or Array.Reverse)
        // TODO
        return input;
    }

    // Purpose: return the input with all vowels (a e i o u, both cases) removed.
    // Parameters: input — the original text.  Returns: text without vowels.
    static string RemoveVowels(string input)
    {
        // Processing: keep only characters that are not vowels
        // TODO
        return input;
    }

    // Purpose: compute simple interest.
    // Parameters: principal (dollars), rate (percent, e.g. 5 for 5%), years.
    // Returns: the interest amount only.
    static decimal SimpleInterest(decimal principal, double rate, int years)
    {
        // Processing: principal * (rate / 100) * years
        // TODO
        return 0m;
    }

    static void Main()
    {
        bool done = false;
        while (!done)
        {
            // Output: the "buttons"
            Console.WriteLine("\n===== BUTTON TRAINER =====");
            Console.WriteLine("1. Reverse Text");
            Console.WriteLine("2. Remove Vowels");
            Console.WriteLine("3. Simple Interest");
            Console.WriteLine("Q. Quit");
            Console.Write("Pick a button: ");

            // Input: menu choice — validate; letters other than q/Q re-prompt
            // TODO: read the choice, call the right method, print results.
            // Button 3: prompt for principal/rate/years with TryParse re-prompt
            // loops, then print interest and total with ToString("C").
            done = true; // remove once the loop is implemented
        }
    }
}
