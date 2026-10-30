# Step 02 — Variables, Input, Math, and Formatting (C#)

**What you'll build:** Snack Bar Order — a program that asks for one order and prints a receipt with tax.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Variables and data types](#variables-and-data-types)
- [Reading what the user types](#reading-what-the-user-types)
- [Converting text to numbers](#converting-text-to-numbers)
- [Math operators](#math-operators)
- [The whole-number division trap](#the-whole-number-division-trap)
- [Named constants](#named-constants)
- [Putting values into text](#putting-values-into-text)
- [Formatting money](#formatting-money)
- [A complete example](#a-complete-example)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Snack Bar Order](#the-challenge-snack-bar-order)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to make variables and pick the right data type (`string`, `int`, `double`, `decimal`, `bool`)
- How to ask a question and read the answer with `Console.Write` and `Console.ReadLine`
- How to turn text into a number with `int.Parse` and `decimal.Parse`
- Math operators, including `%` and `+=`
- Why `7 / 2` is `3` in C#, and how to get `3.5`
- How to make a named constant with `const`
- How to put variables into text with `$"..."` (string interpolation)
- How to show money with exactly 2 decimal places using `:F2`

## Variables and data types

A **variable** is a named box that holds a value. In C# you must say what **type** of value the box holds when you make it. After that, the box can only hold that type.

```csharp
string studentName = "Jordan";   // text
int age = 17;                    // whole number
double heightFeet = 5.75;        // decimal number (general use)
decimal price = 2.75m;           // decimal number for MONEY (note the m)
bool isSenior = true;            // true or false
char grade = 'A';                // one single character (single quotes)
```

| Type | Holds | Example values |
|---|---|---|
| `string` | text | `"Jordan"`, `"Room 112"`, `""` (empty) |
| `int` | whole numbers (no decimal point) | `17`, `0`, `-5`, `2000000` |
| `double` | numbers with a decimal point | `5.75`, `3.14159`, `-0.5` |
| `decimal` | exact decimal numbers — use for **money** | `2.75m`, `0.07m` |
| `bool` | `true` or `false` | `true` |
| `char` | one character | `'A'`, `'7'`, `'?'` |

The pattern is always: **type**, **name**, `=`, **value**, `;`.

You can change a variable's value later. You don't write the type again:

```csharp
int score = 10;   // make the variable
score = 25;       // change it - no "int" this time
```

**Names:** C# variables use **camelCase** — start lower-case, capitalize each new word: `studentName`, `totalCost`, `itemCount`. Use names that say what the value is. `subtotal` is better than `s` or `x`. BPA graders check naming.

**Why `decimal` for money?** A `double` stores numbers in binary, and some decimals can't be stored exactly. `0.1 + 0.2` as doubles prints `0.30000000000000004`. A `decimal` stores them exactly, so money adds up to the cent. The `m` after a number (`2.75m`) tells C# "this number is a decimal." Without the `m`, C# thinks it is a `double` and gives you an error when you put it in a `decimal` box.

You may see `var` in other people's code: `var count = 5;`. `var` means "C#, figure out the type from the value." It is legal, but these lessons always write the type so you can see it.

## Reading what the user types

To ask a question:
1. Print the question with `Console.Write` (not `WriteLine`) so the cursor stays on the same line.
2. Read the answer with `Console.ReadLine()`. It waits for the user to type something and press Enter, then gives you what they typed **as a string**.

```csharp
Console.Write("What is your name? ");
string name = Console.ReadLine() ?? "";
Console.WriteLine("Hi, " + name + "!");
```

If the user types `Avery`, the screen shows:

```text
What is your name? Avery
Hi, Avery!
```

What is `?? ""`? `ReadLine()` can sometimes give back **null**, which means "nothing at all" (it happens if the input ends, for example when a program is tested with a file instead of a keyboard). `??` means "if the thing on the left is null, use the thing on the right instead." So `Console.ReadLine() ?? ""` means "what the user typed, or empty text if there was nothing." It also makes the yellow warning in Visual Studio go away. Use it every time you call `ReadLine`.

Notice the space at the end of `"What is your name? "`. Without it, the answer would be squished against the question mark.

**Try it:**
- Ask for a favorite color and print `Your favorite color is blue.` (with whatever they typed).

## Converting text to numbers

`ReadLine` always gives you a **string**, even if the user types `42`. You can't do math with text. You have to **convert** it:

| What you type | What it does |
|---|---|
| `int.Parse(text)` | turns text like `"42"` into the whole number `42` |
| `double.Parse(text)` | turns text like `"5.75"` into the double `5.75` |
| `decimal.Parse(text)` | turns text like `"2.75"` into the decimal `2.75` |

```csharp
Console.Write("How many tickets? ");
int tickets = int.Parse(Console.ReadLine() ?? "");

Console.Write("Price per ticket: ");
decimal ticketPrice = decimal.Parse(Console.ReadLine() ?? "");

decimal cost = ticketPrice * tickets;
Console.WriteLine("Cost: " + cost);
```

With `4` and `8.50` typed in, this prints `Cost: 34.00`.

**Warning:** if the user types something that is not a number (like `four`), `Parse` **crashes** the program:

```text
Unhandled exception. System.FormatException: The input string 'four' was not in a correct format.
```

That is OK for now. Assume the user types good numbers. **Step 10** shows how to make input crash-proof with `int.TryParse`.

## Math operators

| Operator | Meaning | Example | Result |
|---|---|---|---|
| `+` | add | `7 + 2` | `9` |
| `-` | subtract | `7 - 2` | `5` |
| `*` | multiply | `7 * 2` | `14` |
| `/` | divide | `7.0 / 2` | `3.5` |
| `%` | remainder (modulo) | `7 % 2` | `1` |

C# follows the normal order of operations: `*`, `/`, `%` before `+` and `-`. Use parentheses to be clear: `(a + b) * 2`.

Shortcuts for changing a variable:

| What you type | Same as |
|---|---|
| `total += 5;` | `total = total + 5;` |
| `total -= 5;` | `total = total - 5;` |
| `total *= 2;` | `total = total * 2;` |
| `count++;` | `count = count + 1;` |
| `count--;` | `count = count - 1;` |

`%` gives the remainder after dividing. `17 % 5` is `2` because 17 ÷ 5 is 3 with 2 left over. It is handy for checking even/odd (`n % 2 == 0` means even) and you will use it in Step 7.

## The whole-number division trap

When you divide an `int` by an `int`, C# gives you an `int`. It **chops off** the decimal part. It does not round.

```csharp
int totalPoints = 7;
int games = 2;

Console.WriteLine(totalPoints / games);           // int / int = int
Console.WriteLine((double)totalPoints / games);   // turn one into a double first
Console.WriteLine(7.0 / 2);                       // 7.0 is a double already
```

It prints:

```text
3
3.5
3.5
```

`(double)totalPoints` is called a **cast**. It means "treat this value as a double." As long as **one** side of the `/` is a `double` (or `decimal`), you get a decimal answer. You will use this for averages in Step 6.

## Named constants

A **constant** is a value that never changes while the program runs. Give it a name instead of typing the number all over your code:

```csharp
const decimal SALES_TAX = 0.0725m;
```

- `const` means "this can't be changed." If you try `SALES_TAX = 0.08m;` later, you get an error.
- Constants are often written in ALL_CAPS with underscores so they stand out.
- Put constants **inside the class but above `Main`**, so every part of the class can use them:

```csharp
internal class Program
{
    const decimal SALES_TAX = 0.0725m;   // here - inside the class, outside Main

    static void Main(string[] args)
    {
        // ...code that uses SALES_TAX...
    }
}
```

Why bother? If the tax rate changes, you change one line. And `subtotal * SALES_TAX` is easier to read than `subtotal * 0.0725m`.

## Putting values into text

There are two ways to mix variables into text.

**1. Joining with `+` (concatenation):**

```csharp
string name = "Casey";
int points = 140;
Console.WriteLine("Player " + name + " has " + points + " points.");
```

**2. String interpolation with `$"..."`** — put a `$` right before the opening quote, then put variables inside `{ }`:

```csharp
Console.WriteLine($"Player {name} has {points} points.");
```

Both print `Player Casey has 140 points.` Interpolation is easier to read and is what these lessons use most. You can even put math inside the braces: `$"Next year: {points + 10}"`.

## Formatting money

Inside the `{ }` you can add a **format specifier** after a colon:

| What you type | What it shows (for the value 8.8275) |
|---|---|
| `{total}` | `8.8275` |
| `{total:F2}` | `8.83` — **F**ixed, **2** decimal places (rounds) |
| `{total:F1}` | `8.8` |
| `{total:N2}` | `8.83` — like F2 but adds commas: `1,234.50` |
| `{total:C}` | `$8.83` — **C**urrency (uses the computer's country settings) |

For money we use `F2` and type the dollar sign ourselves, because the output then looks the same on every computer:

```csharp
decimal total = 8.8275m;
Console.WriteLine($"Total: ${total:F2}");
```

This prints `Total: $8.83`. Look closely at `$"Total: ${total:F2}"`. The **first** `$` (before the quote) turns on interpolation. The **second** `$` is inside the quotes, so it is just a dollar sign that gets printed. Then `{total:F2}` is the value.

You can also format a number by itself with `ToString`: `total.ToString("F2")` gives the text `"8.83"`. You will use this in Step 5.

## A complete example

This program works out the gas cost of a round trip. It uses every idea above. (It is not the challenge — the challenge is below.)

<!-- input: Cedar Point|75|28.5|3.19 -->
```csharp
// Name: Example
// Date: 2026-11-06
// Program: Trip Gas Cost
// Description: Asks about a trip and prints the gas cost for the round trip.

using System;

namespace TripCost
{
    internal class Program
    {
        // Named constant: a round trip is 2 times the one-way distance
        const int TRIPS = 2;

        static void Main(string[] args)
        {
            // Input: trip name, distance, gas mileage, and gas price
            Console.Write("Trip name: ");
            string tripName = Console.ReadLine() ?? "";

            Console.Write("Miles (one way): ");
            int miles = int.Parse(Console.ReadLine() ?? "");

            Console.Write("Miles per gallon: ");
            decimal milesPerGallon = decimal.Parse(Console.ReadLine() ?? "");

            Console.Write("Gas price per gallon: ");
            decimal gasPrice = decimal.Parse(Console.ReadLine() ?? "");

            // Processing: total miles, gallons used, and cost
            int totalMiles = miles * TRIPS;
            decimal gallons = totalMiles / milesPerGallon;   // decimal division, not int
            decimal cost = gallons * gasPrice;

            // Output: the trip summary
            Console.WriteLine();
            Console.WriteLine($"--- {tripName} ---");
            Console.WriteLine($"Round trip:  {totalMiles} miles");
            Console.WriteLine($"Gas used:    {gallons:F1} gallons");
            Console.WriteLine($"Gas cost:    ${cost:F2}");
        }
    }
}
```

It prints (user typing shown after each question):

```text
Trip name: Cedar Point
Miles (one way): 75
Miles per gallon: 28.5
Gas price per gallon: 3.19

--- Cedar Point ---
Round trip:  150 miles
Gas used:    5.3 gallons
Gas cost:    $16.79
```

Notice the three labeled blocks: **Input**, **Processing**, **Output**. Your challenge should look the same.

**Try it:**
- Add a question `How many people? ` and print the cost per person with 2 decimal places.

## Common mistakes

**Forgetting to convert.**
You write `int quantity = Console.ReadLine();` and see `CS0029 Cannot implicitly convert type 'string' to 'int'`.
Fix: `ReadLine` gives text. Wrap it: `int.Parse(Console.ReadLine() ?? "")`.

**A money number without `m`.**
You write `decimal price = 2.75;` and see `CS0664 Literal of type double cannot be implicitly converted to type 'decimal'; use an 'M' suffix to create a literal of this type`.
Fix: write `2.75m`.

**Mixing `double` and `decimal`.**
You multiply a `decimal` by a `double` and see `CS0019 Operator '*' cannot be applied to operands of type 'decimal' and 'double'`.
Fix: pick one type for money and stick to it. In these lessons money is always `decimal`.

**Using `WriteLine` for a question.**
The answer ends up on the line below the question, so your output doesn't match the sample.
Fix: use `Console.Write` for questions.

**Missing space after the prompt.**
The sample shows `Price: 2.75`, yours shows `Price:2.75`.
Fix: the prompt text is `"Price: "` with a space before the closing quote.

**Typing a letter where a number is expected.**
The program crashes with `System.FormatException`. That's expected in this step — Step 10 fixes it.

**Forgetting the `$` before the quote.**
You write `Console.WriteLine("Total: {total:F2}");` and it prints `Total: {total:F2}` — the braces show up as plain text.
Fix: put `$` right before the opening quote: `$"Total: ${total:F2}"`.

## How this shows up at BPA

- Every BPA program starts by reading input. At the 2026 regional the input came from text boxes instead of the console, but the idea is the same: the input is **text**, and you convert it to a number.
- The loan-payment and interest buttons at the regional are formulas just like this step: read values, do the math in the right order, show money with 2 decimal places.
- Graders look for **meaningful variable names** and **named constants** instead of unexplained numbers.
- Input / Processing / Output comments are worth points every time.

## The challenge: Snack Bar Order

Write a program that takes one snack bar order and prints a receipt.

**Requirements:**
1. Header comment.
2. Ask for the customer's name, the item, the price (decimal), and the quantity (whole number) using the exact prompts below.
3. Store the tax rate in a named constant (`TAX_RATE = 0.07`).
4. Calculate subtotal (price × quantity), tax (subtotal × TAX_RATE), and total (subtotal + tax).
5. Print the receipt exactly as shown, money with 2 decimal places.
6. Input / Processing / Output comments on each block.

**Sample run (exact):**
```text
Customer name: Jordan
Item: Pretzel
Price: 2.75
Quantity: 3

--- Receipt for Jordan ---
Item:      Pretzel
Quantity:  3
Subtotal:  $8.25
Tax (7%):  $0.58
Total:     $8.83
```

**Hints:**
- In C# the constant is `const decimal TAX_RATE = 0.07m;` placed inside the class, above `Main`.
- Use `decimal` for the price, subtotal, tax, and total. Use `int` for the quantity.
- The blank line after `Quantity: 3` is a `Console.WriteLine();` with nothing in it.
- Count the spaces after each label. `Item:` is followed by 6 spaces, `Subtotal:` by 2.
- Tax is `0.5775`. `:F2` rounds it to `0.58`. The total is `8.25 + 0.5775 = 8.8275`, which shows as `8.83`. Don't round in the middle — only when you print.
- No input checking yet. If someone types letters the program crashes. Step 10 makes it crash-proof.

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step02`.
2. Put your whole Visual Studio project folder (`Step02`) in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 2 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `TAX_RATE` is a named constant
- [ ] Money uses `decimal` and prints with 2 decimal places
- [ ] Prompts use `Console.Write` so answers stay on the same line
- [ ] Pushed to `bpaPrep/csharp_step02`
