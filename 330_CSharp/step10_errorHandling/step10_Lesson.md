# Step 10 — Error Handling (C#)

**What you'll build:** Ticket Order — a ticket-ordering program that can't be crashed by bad typing, and that saves its orders to a file safely.
**Time:** one to two class periods. This is one of the most useful steps for BPA.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [What an exception is](#what-an-exception-is)
- [Reading a crash message](#reading-a-crash-message)
- [try and catch](#try-and-catch)
- [Catching specific exceptions](#catching-specific-exceptions)
- [finally](#finally)
- [TryParse: the C# way to check numbers](#tryparse-the-c-way-to-check-numbers)
- [The out keyword](#the-out-keyword)
- [Reusable input methods](#reusable-input-methods)
- [Saving a file safely](#saving-a-file-safely)
- [A complete example](#a-complete-example)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Ticket Order](#the-challenge-ticket-order)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What an exception is and how to read a crash message
- How to catch an exception with `try` / `catch` so the program keeps running
- Which exceptions you'll meet most: `FormatException`, `OverflowException`, `IOException`, `FileNotFoundException`, `UnauthorizedAccessException`
- What `finally` does
- How `int.TryParse` checks a number **without** an exception, and what `out` means
- How to write **reusable input methods** that keep asking until the answer is good — the most valuable skill for BPA
- How to save a file inside a `try` / `catch`

## What an exception is

An **exception** is an error that happens **while the program is running** (not a typing mistake that stops it from building — that's a syntax error, Step 1). Examples:
- `int.Parse("two")` — the text isn't a number.
- Reading a file that isn't there.
- `list[10]` on a list with 3 items.

When an exception happens and nothing **catches** it, the program **crashes**: it stops and prints a message. At BPA, a crash during grading costs you the points for that part — and if the graders can't get past it, more.

## Reading a crash message

Here is what you see if the Step 2 snack bar gets `abc` for the price:

```text
Price: abc
Unhandled exception. System.FormatException: The input string 'abc' was not in a correct format.
   at System.Number.ThrowFormatException[TChar](ReadOnlySpan`1 value)
   at System.Decimal.Parse(String s)
   at Step02.Program.Main(String[] args) in C:\...\Step02\Program.cs:line 29
```

How to read it:
- **The exception type** comes first: `System.FormatException`. That's the name you'd catch.
- **The message** says what went wrong: the text `'abc'` isn't in the right format.
- **The list of `at` lines** (called the stack trace) shows where it happened. Look for **your** file: `Program.cs:line 29`. The lines above it are inside C#'s own code — skip them.

In Visual Studio, when you run with F5, the program stops on the bad line and highlights it with an "Exception Unhandled" box. Press Shift+F5 to stop.

## try and catch

Put code that might fail inside `try`. If an exception happens, C# jumps straight to `catch` instead of crashing:

```csharp
Console.Write("Age: ");
string text = Console.ReadLine() ?? "";

try
{
    int age = int.Parse(text);              // might throw FormatException
    Console.WriteLine($"Next year you'll be {age + 1}.");
}
catch (FormatException)
{
    Console.WriteLine("That was not a whole number.");
}
Console.WriteLine("Done.");
```

| Typed | Output |
|---|---|
| `16` | `Next year you'll be 17.` then `Done.` |
| `sixteen` | `That was not a whole number.` then `Done.` |

When `int.Parse` fails, the rest of the `try` block is **skipped** (the "Next year" line never runs). Then the program carries on after the `catch`.

| Part | What it means |
|---|---|
| `try { }` | "Try this code." |
| `catch (FormatException) { }` | "If a `FormatException` happens in the try, run this instead of crashing." |
| `catch (FormatException ex)` | Same, and `ex` holds details. `ex.Message` is the message text. |

## Catching specific exceptions

Catch the exceptions you **expect**, by name. You can have several `catch` blocks; C# uses the first one that matches.

| Exception | When it happens |
|---|---|
| `FormatException` | `int.Parse`, `double.Parse`, `decimal.Parse` get text that isn't a number (`"abc"`, `"2.5"` for an int, `""`) |
| `OverflowException` | the number is too big for the type (`int.Parse("99999999999")`) |
| `FileNotFoundException` | reading a file that doesn't exist |
| `IOException` | a file problem: locked by another program, disk error. (`FileNotFoundException` is a kind of `IOException`.) |
| `UnauthorizedAccessException` | no permission to read or write that file or folder |
| `IndexOutOfRangeException` / `ArgumentOutOfRangeException` | an index past the end of an array / list |
| `Exception` | the parent of **all** of them — catches anything |

```csharp
try
{
    string[] lines = File.ReadAllLines("prices.csv");
    decimal first = decimal.Parse(lines[1].Split(',')[1]);
    Console.WriteLine($"First price: {first:F2}");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Error: prices.csv is missing.");
}
catch (FormatException)
{
    Console.WriteLine("Error: a price in the file is not a number.");
}
catch (Exception ex)
{
    Console.WriteLine("Something else went wrong: " + ex.Message);
}
```

Put the more specific ones **first** and `Exception` **last**. (If `Exception` came first, it would catch everything and the others would never run — C# gives error `CS0160 A previous catch clause already catches all exceptions of this or of a super type` to stop you.)

Catching plain `Exception` everywhere is a bad habit: it hides bugs. Use it as a last safety net, not instead of the specific ones. Graders look for **specific** exception handling with a comment saying what it catches.

## finally

A `finally` block runs **no matter what** — after the `try` succeeds, or after a `catch` runs.

```csharp
try
{
    Console.WriteLine("Saving...");
    File.WriteAllText("log.txt", "saved");
}
catch (IOException)
{
    Console.WriteLine("Could not save.");
}
finally
{
    Console.WriteLine("Save attempt finished.");
}
```

`finally` is for clean-up that must always happen. With files, a `using` block (Step 9) already does the closing for you, so you won't need `finally` often. Know what it means if you see it.

## TryParse: the C# way to check numbers

`try` / `catch` works for bad numbers, but C# has a simpler tool made just for this: **`TryParse`**. It tries to convert the text and tells you whether it worked, **without** throwing an exception.

```csharp
string text = "42";
if (int.TryParse(text, out int number))
{
    Console.WriteLine($"Got the number {number}.");
}
else
{
    Console.WriteLine("Not a whole number.");
}
```

`int.TryParse(text, out int number)`:
- returns `true` if `text` is a whole number, and puts the number in `number`;
- returns `false` if it isn't (letters, decimals like `2.5`, blank, too big), and `number` is set to `0`.

| Text | `int.TryParse` | `double.TryParse` | `decimal.TryParse` |
|---|---|---|---|
| `"42"` | true, 42 | true, 42 | true, 42 |
| `"-5"` | true, -5 | true, -5 | true, -5 |
| `"2.5"` | **false** | true, 2.5 | true, 2.5 |
| `"abc"` | false | false | false |
| `""` | false | false | false |
| `" 7 "` | true, 7 (spaces at the ends are allowed) | true, 7 | true, 7 |

Notice `int.TryParse("2.5")` is **false** — so it rejects decimals for you. Negative numbers parse fine, so you still check the range yourself:

```csharp
if (int.TryParse(text, out int qty) && qty >= 1 && qty <= 10)
{
    // good: a whole number from 1 to 10
}
```

The `&&` checks left to right and stops at the first `false`, so the range checks only run when the parse worked.

**Which should you use?** For checking what a user typed, **`TryParse` is the preferred C# way** — it is shorter and doesn't use exceptions for something that happens all the time. Use `try` / `catch` for things you can't check ahead of time, like files. BPA graders accept both; the 2026 regional asked for message boxes on invalid input, and `TryParse` is the cleanest way to do that.

## The out keyword

A method can only `return` one value. `TryParse` needs to give back two things: "did it work?" and "the number." It returns the `bool`, and hands back the number through an **`out` parameter**.

- `out int number` in the call **makes a new variable** called `number`, and the method fills it in.
- After the call, you use `number` like any other variable.

You can also make the variable first:

```csharp
int number;
bool ok = int.TryParse(text, out number);
```

Both forms are fine. You can write your own methods with `out` parameters too — the Step 11 forms use one.

## Reusable input methods

Here is the most important idea in this step. Instead of checking input in ten places, write **one method** that keeps asking until the answer is good, and **returns** the good answer. Then every question in your program is one line.

The pattern is a `while (true)` loop. It looks like it runs forever — but `return` ends the method (and the loop) as soon as the answer is good:

```csharp
// Purpose: ask until the user types a decimal number from low to high.
// Parameters: prompt - the question; low, high - the allowed range.
// Returns: the valid number.
static decimal GetDecimal(string prompt, decimal low, decimal high)
{
    while (true)
    {
        // Input: one line of text
        Console.Write(prompt);
        string answer = Console.ReadLine() ?? "";

        // Processing: accept it only if it converts AND is in range
        if (decimal.TryParse(answer, out decimal value) && value >= low && value <= high)
        {
            return value;   // good - leave the method with the number
        }

        // Output: explain the problem; the loop asks again
        Console.WriteLine($"Please enter a number from {low} to {high}.");
    }
}
```

Now a whole question is:

```csharp
decimal donation = GetDecimal("Donation amount: ", 1, 500);
```

The challenge needs three of these: `GetText`, `GetInt`, and `GetYesNo`. Write them once, test them well, and **print them** — you can bring them to BPA and reuse them in every event program.

Ideas for the other two:
- **GetText:** read the line, `.Trim()` it. If it equals `""`, print the error and loop. Otherwise return it.
- **GetYesNo:** read the line, trim it, `.ToLower()` it. Return `true` for `"y"`, `false` for `"n"`, otherwise print the error and loop.

## Saving a file safely

Writing a file can fail: the file might be open in another program, or the folder might be read-only. Put the save inside `try` / `catch`, and say in a comment what you are catching:

```csharp
// Output: save the list. This try/catch catches IOException (file locked or
// disk problem) and UnauthorizedAccessException (no permission to write).
try
{
    File.WriteAllLines("names.txt", names);
    Console.WriteLine("Saved names.txt");
}
catch (IOException)
{
    Console.WriteLine("Error: could not save names.txt");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Error: could not save names.txt");
}
```

`File.WriteAllLines(path, list)` writes a `List<string>` (or `string[]`) with one item per line.

## A complete example

This program collects fundraiser donations with crash-proof input and saves them. (It is not the challenge, but it uses the same pattern.)

<!-- input: 50 dollars|25|y|-3|12.50|n -->
```csharp
// Name: Example
// Date: 2026-11-06
// Program: Fundraiser Donations
// Description: Collects donations with crash-proof input, prints the total,
//              and saves each donation to donations.txt.

using System;
using System.Collections.Generic;
using System.IO;

namespace Fundraiser
{
    internal class Program
    {
        const string SAVE_FILE = "donations.txt";

        // Purpose: ask until the user types a decimal number from low to high.
        // Parameters: prompt - the question; low, high - the allowed range.
        // Returns: the valid number.
        static decimal GetDecimal(string prompt, decimal low, decimal high)
        {
            while (true)
            {
                // Input: one line
                Console.Write(prompt);
                string answer = Console.ReadLine() ?? "";

                // Processing: TryParse returns false for letters and blanks (no crash)
                if (decimal.TryParse(answer, out decimal value) && value >= low && value <= high)
                {
                    return value;
                }

                // Output: error, then ask again
                Console.WriteLine($"Please enter a number from {low} to {high}.");
            }
        }

        // Purpose: ask a question until the answer is "y" or "n" (either case).
        // Parameters: prompt - the question.
        // Returns: true for y, false for n.
        static bool AskYesNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string answer = (Console.ReadLine() ?? "").Trim().ToLower();
                if (answer == "y" || answer == "n")
                {
                    return answer == "y";
                }
                Console.WriteLine("Please answer y or n.");
            }
        }

        static void Main(string[] args)
        {
            // Processing: running total and the lines to save
            decimal total = 0;
            List<string> lines = new List<string>();

            bool more = true;
            while (more)
            {
                // Input: one donation, validated
                decimal amount = GetDecimal("Donation amount (1-500): ", 1, 500);

                // Processing: add it up and remember it
                total += amount;
                lines.Add($"{amount:F2}");

                // Input: another?
                more = AskYesNo("Another donation? (y/n): ");
            }

            // Output: the total
            Console.WriteLine($"Donations: {lines.Count}  Total: ${total:F2}");

            // Output: save. Catches IOException (file locked / disk problem) and
            // UnauthorizedAccessException (no permission to write here).
            try
            {
                File.WriteAllLines(SAVE_FILE, lines);
                Console.WriteLine($"Saved {SAVE_FILE}");
            }
            catch (IOException)
            {
                Console.WriteLine($"Error: could not save {SAVE_FILE}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Error: could not save {SAVE_FILE}");
            }
        }
    }
}
```

It prints:

```text
Donation amount (1-500): 50 dollars
Please enter a number from 1 to 500.
Donation amount (1-500): 25
Another donation? (y/n): y
Donation amount (1-500): -3
Please enter a number from 1 to 500.
Donation amount (1-500): 12.50
Another donation? (y/n): n
Donations: 2  Total: $37.50
Saved donations.txt
```

`donations.txt` contains two lines: `25.00` and `12.50`.

**Try it:**
- Go back to your **Step 4** guessing game and replace each `int.Parse(Console.ReadLine() ?? "")` with a call to your new `GetInt`. Now typing letters can't crash it.
- Open `donations.txt` in Notepad, leave it open, and look up how to make a file read-only (right-click → Properties → Read-only). Run the program again — you should see the error message, not a crash.

## Common mistakes

**Catching too much.**
`catch (Exception)` around your whole program hides real bugs — the program "works" but does the wrong thing silently.
Fix: catch the specific exception you expect, around the specific line that can throw it.

**The variable made in `try` isn't available after it.**
`CS0103 The name 'age' does not exist in the current context`.
Fix: a variable made inside `{ }` only lives there. Make it before the `try`, or do the work inside the `try`.

**Using `int.Parse` inside an input method.**
It crashes on letters unless you add try/catch.
Fix: use `int.TryParse` and an `if`.

**Forgetting `out`.**
`int.TryParse(text, number)` gives `CS1620 Argument 2 must be passed with the 'out' keyword`.
Fix: `int.TryParse(text, out number)` or `out int number`.

**Blank input slips through.**
The user types spaces and `GetText` accepts them.
Fix: `.Trim()` before checking `== ""`.

**Wrong order of catch blocks.**
`CS0160 A previous catch clause already catches all exceptions of this or of a super type ('Exception')`.
Fix: put `catch (Exception)` last.

**Infinite loop in an input method.**
The method keeps printing the error forever without waiting.
Fix: the `Console.ReadLine()` must be **inside** the loop, so each pass reads a new answer.

## How this shows up at BPA

- The 2026 C# regional gave **separate points for invalid input handling** on four buttons (Monthly Payment, Add Evens, Digit Types, Distance Converter): show a message box instead of crashing. That's `TryParse` plus an `if`.
- The C++ regional said input must reject letters, symbols, decimals, and negatives where whole numbers are expected — exactly what `GetInt` does.
- "Exception handling" is a graded item in the Source Code Review for every programming event. A comment saying **what** your try/catch catches earns the comment points too.
- Print your `GetText`, `GetInt`, and `GetYesNo` methods and bring them. They fit almost any BPA console program.

## The challenge: Ticket Order

Write a crash-proof ticket order program.

**Requirements:**
1. Header comment.
2. Write these reusable functions:
   - `get_text(prompt)` → keeps asking until the answer is not blank; on blank prints `This cannot be blank.`
   - `get_int(prompt, low, high)` → keeps asking until the answer is a whole number from low to high; otherwise prints `Please enter a whole number from <low> to <high>.` Must reject letters, decimals like `2.5`, blanks, and out-of-range numbers without crashing.
   - `get_yes_no(prompt)` → returns true for `y`/`Y`, false for `n`/`N`; anything else prints `Please enter y or n.` and asks again.
3. Ask for the name with `get_text`, then repeat: show the ticket types, ask ticket type (1–3) and quantity (1–10) with `get_int`, add to the order, ask `Another order? (y/n): ` with `get_yes_no`.
   - Ticket types and prices: 1-Student $5.00, 2-Adult $8.50, 3-Senior $6.25.
4. At the end print total tickets and total cost.
5. Save the order to `orders.txt` inside a try/catch. One line per order in the form `Jordan,Adult,3,25.50`. On success print `Order saved to orders.txt`; if writing fails print `Error: could not save orders.txt` (no crash).
6. Function comments and Input / Processing / Output comments, including a comment on each try/catch saying what error it catches.

In C# the methods are `GetText(string prompt)`, `GetInt(string prompt, int low, int high)`, and `GetYesNo(string prompt)`.

**Sample run (exact):**
```text
Name: 
This cannot be blank.
Name: Jordan
Ticket types: 1-Student $5.00  2-Adult $8.50  3-Senior $6.25
Ticket type (1-3): two
Please enter a whole number from 1 to 3.
Ticket type (1-3): 2
Quantity (1-10): 2.5
Please enter a whole number from 1 to 10.
Quantity (1-10): 3
Another order? (y/n): maybe
Please enter y or n.
Another order? (y/n): y
Ticket types: 1-Student $5.00  2-Adult $8.50  3-Senior $6.25
Ticket type (1-3): 1
Quantity (1-10): 2
Another order? (y/n): n

Total tickets: 5
Total cost: $35.50
Order saved to orders.txt
```

`orders.txt`:
```text
Jordan,Adult,3,25.50
Jordan,Student,2,10.00
```
(The first line `Name: ` with nothing typed means the user pressed Enter. Whitespace-only counts as blank — trim it.)

**Hints:**
- Keep the ticket names and prices in two parallel arrays: `{ "Student", "Adult", "Senior" }` and `{ 5.00m, 8.50m, 6.25m }`. Ticket type 1 is index 0.
- Build each order line as you go (`$"{name},{ticketName},{quantity},{cost:F2}"`) and add it to a `List<string>`. Save the list at the end with `File.WriteAllLines`.
- `orders.txt` ends up in `bin\Debug\net8.0\`.
- Test every bad input in the sample run, plus `-1`, `0`, `11`, and `3abc`.

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step10`.
2. Put your whole Visual Studio project folder (`Step10`) in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 10 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] `orders.txt` matches the sample
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `GetText`, `GetInt`, `GetYesNo` exist, each with a purpose / parameters / returns comment
- [ ] No input can crash it (letters, decimals, blanks, negatives)
- [ ] The file save is inside `try` / `catch` with a comment saying what it catches
- [ ] Pushed to `bpaPrep/csharp_step10`
