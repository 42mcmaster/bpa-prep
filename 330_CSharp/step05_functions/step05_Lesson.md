# Step 05 — Functions (Methods) (C#)

**What you'll build:** Snack Bar with Functions — the Step 2 snack bar rebuilt so an order can have several items, with each job done by its own method.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Why use methods](#why-use-methods)
- [Writing a method](#writing-a-method)
- [What static means](#what-static-means)
- [Parameters and arguments](#parameters-and-arguments)
- [Return values](#return-values)
- [void methods](#void-methods)
- [Local variables and scope](#local-variables-and-scope)
- [Main is a method too](#main-is-a-method-too)
- [The method comment block](#the-method-comment-block)
- [A complete example](#a-complete-example)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Snack Bar with Functions](#the-challenge-snack-bar-with-functions)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- Why programs are split into methods (C#'s name for functions)
- How to write a `static` method and call it from `Main`
- How to pass values in (parameters) and get a value back (`return`)
- What `void` means
- Where a variable "lives" (scope)
- What `static void Main(string[] args)` really means
- How to write the comment block graders look for on every method

## Why use methods

A **method** is a named block of code that does one job. You write it once and **call** it (run it) by name as many times as you want. Python and C++ call these "functions." In C# and Java they are called **methods**, because they always live inside a class. Same idea.

Why bother?
- **No repeated code.** If you need the same calculation in three places, write it once.
- **Easier to read.** `PrintReceipt(name, count, subtotal)` says what it does. Twenty lines of `Console.WriteLine` don't.
- **Easier to fix.** A bug in the tax math is fixed in one place.
- **BPA requires it.** The rubrics say each major part of the program should be its own method, and they grade the method comments.

## Writing a method

Here is a method that squares a number, and `Main` calling it:

```csharp
using System;

namespace SquareDemo
{
    internal class Program
    {
        // Purpose: multiply a number by itself.
        // Parameters: number - the number to square.
        // Returns: number times number.
        static int Square(int number)
        {
            return number * number;
        }

        static void Main(string[] args)
        {
            int result = Square(6);          // call the method, keep the answer
            Console.WriteLine(result);
            Console.WriteLine(Square(9));    // use the answer directly
        }
    }
}
```

It prints:

```text
36
81
```

The first line of a method is its **signature**. Each part means something:

| Part | In the example | What it means |
|---|---|---|
| `static` | `static` | explained in the next section — for now, every method in a console program gets it |
| return type | `int` | the type of value the method hands back. `void` means it hands back nothing. |
| name | `Square` | C# method names use **PascalCase** — every word starts with a capital: `CalculateTax`, `PrintReceipt` |
| parameters | `(int number)` | the values the method needs, each with a type and a name. Empty `()` if it needs none. |
| body | `{ return number * number; }` | the code that runs |

Methods go **inside the class** and **outside `Main`** — next to `Main`, not inside it. In C# the order doesn't matter: a method can be above or below `Main`. (In C++ the order does matter. Not here.)

## What static means

`static` means "this method belongs to the class itself, so you can call it without making an object first."

`Main` is `static`, because C# needs to start the program before any objects exist. A static method can only call other methods directly if they are static too. So in a console program, **every method you write next to `Main` gets `static`**.

If you leave it off, you get: `CS0120 An object reference is required for the non-static field, method, or property 'Program.Square(int)'`. The fix is to add `static`.

In Step 11 (Windows Forms) your methods will **not** be static, because they belong to the form — an object. That is the only time it changes.

## Parameters and arguments

- A **parameter** is the variable in the method's signature: `int number`.
- An **argument** is the actual value you pass when you call it: the `6` in `Square(6)`.

A method can have several parameters, separated by commas. The arguments must come in the **same order** with matching **types**:

```csharp
// Purpose: build a full name.
// Parameters: first - first name; last - last name.
// Returns: "Last, First".
static string FormatName(string first, string last)
{
    return last + ", " + first;
}
```

`FormatName("Avery", "Smith")` returns `"Smith, Avery"`. `FormatName("Smith", "Avery")` returns `"Avery, Smith"` — order matters.

The parameter gets a **copy** of the value. If the method changes its parameter, the caller's variable doesn't change. (Lists and arrays are different — Step 6 covers that.)

## Return values

`return` does two things: it hands a value back to the caller, and it **ends the method right away**.

```csharp
// Purpose: say whether a number is even.
// Parameters: n - the number to check.
// Returns: true if n is even, otherwise false.
static bool IsEven(int n)
{
    if (n % 2 == 0)
    {
        return true;
    }
    return false;
}
```

The caller can store the returned value, print it, or use it in a condition:

```csharp
bool check = IsEven(10);
Console.WriteLine(IsEven(7));     // prints False
if (IsEven(4))
{
    Console.WriteLine("4 is even");
}
```

C# prints a `bool` as `True` or `False` with a capital letter.

Every path through a non-void method must reach a `return`. If one path doesn't, you get `CS0161 'Program.IsEven(int)': not all code paths return a value`.

## void methods

A method that **does** something (like printing) but doesn't hand back an answer has the return type `void`:

```csharp
// Purpose: print a line of dashes.
// Parameters: length - how many dashes.
// Returns: nothing.
static void PrintLine(int length)
{
    for (int i = 0; i < length; i++)
    {
        Console.Write("-");
    }
    Console.WriteLine();
}
```

You call it on its own line: `PrintLine(20);`. You can't store its result — there isn't one. Writing `int x = PrintLine(20);` gives `CS0029 Cannot implicitly convert type 'void' to 'int'`.

A useful rule: **methods that calculate should return**; **methods that print should be void**. Keep the math and the printing separate. That way the same calculation can be printed, saved to a file, or shown on a form.

## Local variables and scope

A variable made inside a method is a **local variable**. It only exists inside that method, from the line it is made until the closing `}` of its block. This is called its **scope**.

```csharp
// This example has an error on purpose
static void Main(string[] args)
{
    int total = 5;
    ShowTotal();
}

static void ShowTotal()
{
    Console.WriteLine(total);   // ERROR: total does not exist here
}
```

You get `CS0103 The name 'total' does not exist in the current context`. `total` lives in `Main`. `ShowTotal` can't see it. The fix is to **pass it in** as a parameter: `static void ShowTotal(int total)` and call `ShowTotal(total);`.

Two different methods can each have their own variable named `total`. They are separate boxes that happen to have the same name.

Constants made at the class level (like `TAX_RATE` above `Main`) can be used by every method in the class.

## Main is a method too

Now `static void Main(string[] args)` makes sense:

| Part | Meaning |
|---|---|
| `static` | belongs to the class, so C# can run it before any objects exist |
| `void` | returns nothing |
| `Main` | the special name C# looks for to start the program |
| `string[] args` | an array of strings that can be passed in when the program is started from a command line. We don't use it, but leave it in. |

A good pattern: `Main` is short. It asks the questions, calls the other methods, and shows the results. The detailed work happens in the other methods.

## The method comment block

Put a comment above **every** method saying its purpose, its parameters, and what it returns. BPA graders look for this.

```csharp
// Purpose: work out the area of a rectangle.
// Parameters: width - width in feet; height - height in feet.
// Returns: the area in square feet.
static double CalculateArea(double width, double height)
```

Keep using Input / Processing / Output comments **inside** the methods.

## A complete example

This program estimates paint for a room with any number of walls. Each job is its own method. (It is not the challenge, but the shape is similar.)

<!-- input: Den|12|8|y|14|8|n -->
```csharp
// Name: Example
// Date: 2026-11-06
// Program: Paint Estimate
// Description: Adds up the area of several walls and estimates the paint cost.

using System;

namespace PaintEstimate
{
    internal class Program
    {
        const double COVERAGE = 100.0;       // square feet one gallon covers
        const decimal GALLON_PRICE = 32.99m;

        // Purpose: work out the area of one wall.
        // Parameters: width, height - the wall size in feet.
        // Returns: the area in square feet.
        static double CalculateArea(double width, double height)
        {
            // Processing: width times height
            return width * height;
        }

        // Purpose: work out how many whole gallons are needed.
        // Parameters: area - total square feet to paint.
        // Returns: gallons, rounded UP to a whole number.
        static int CalculateGallons(double area)
        {
            // Processing: Math.Ceiling rounds up (2.08 becomes 3)
            return (int)Math.Ceiling(area / COVERAGE);
        }

        // Purpose: print the estimate.
        // Parameters: room - room name; walls - number of walls; area - total area.
        // Returns: nothing.
        static void PrintEstimate(string room, int walls, double area)
        {
            // Processing: gallons and cost
            int gallons = CalculateGallons(area);
            decimal cost = gallons * GALLON_PRICE;

            // Output: the estimate
            Console.WriteLine();
            Console.WriteLine($"--- Paint for {room} ---");
            Console.WriteLine($"Walls: {walls}");
            Console.WriteLine($"Area:  {area:F1} sq ft");
            Console.WriteLine($"Paint: {gallons} gallons");
            Console.WriteLine($"Cost:  ${cost:F2}");
        }

        // Purpose: ask about the room and its walls, then print the estimate.
        // Parameters: args - not used.
        // Returns: nothing.
        static void Main(string[] args)
        {
            // Input: room name
            Console.Write("Room: ");
            string room = Console.ReadLine() ?? "";

            // Processing: running totals
            double totalArea = 0;
            int wallCount = 0;
            string another = "y";

            while (another == "y" || another == "Y")
            {
                // Input: one wall
                Console.Write("Wall width (feet): ");
                double width = double.Parse(Console.ReadLine() ?? "");
                Console.Write("Wall height (feet): ");
                double height = double.Parse(Console.ReadLine() ?? "");

                // Processing: add this wall to the totals
                totalArea += CalculateArea(width, height);
                wallCount++;

                // Input: another wall?
                Console.Write("Another wall? (y/n): ");
                another = Console.ReadLine() ?? "";
            }

            // Output: the estimate
            PrintEstimate(room, wallCount, totalArea);
        }
    }
}
```

It prints:

```text
Room: Den
Wall width (feet): 12
Wall height (feet): 8
Another wall? (y/n): y
Wall width (feet): 14
Wall height (feet): 8
Another wall? (y/n): n

--- Paint for Den ---
Walls: 2
Area:  208.0 sq ft
Paint: 3 gallons
Cost:  $98.97
```

Notice:
- `CalculateArea` and `CalculateGallons` **return** answers. `PrintEstimate` **prints** and is `void`.
- `PrintEstimate` calls `CalculateGallons` — methods can call other methods.
- `Main` keeps the running totals and passes them to `PrintEstimate`.
- `Math.Ceiling` is a built-in method that rounds **up**. `Math` has many more: `Math.Round`, `Math.Pow` (powers — used for loan payments), `Math.Sqrt`, `Math.Abs`.

**Try it:**
- Add a method `static decimal AddTax(decimal amount)` that returns the amount plus 7% tax, and print the cost with tax.

## Common mistakes

**Missing `static`.**
You see `CS0120 An object reference is required for the non-static field, method, or property 'Program.CalculateTax(decimal)'`.
Fix: add `static` to the start of the method.

**Method written inside `Main`.**
You get a pile of confusing errors, or a "local function" you didn't mean to make.
Fix: methods go inside the class, next to `Main`. Check your braces: `Main`'s closing `}` comes before the next method starts.

**Not all code paths return a value.**
You see `CS0161 'Program.CalculateTax(decimal)': not all code paths return a value`.
Fix: every non-void method needs a `return` that is reached no matter what.

**Calling the method but ignoring the answer.**
You write `CalculateTax(subtotal);` on its own line. It runs, but the answer is thrown away.
Fix: store or use it: `decimal tax = CalculateTax(subtotal);`.

**Wrong argument types or order.**
You see `CS1503 Argument 1: cannot convert from 'int' to 'string'`, or the numbers come out swapped.
Fix: pass arguments in the same order and type as the parameters.

**Using another method's variable.**
You see `CS0103 The name 'subtotal' does not exist in the current context`.
Fix: pass the value in as a parameter.

## How this shows up at BPA

- The C# regional gives you **method signatures** you must fill in, like `private void btn_Backwards_Click(object sender, EventArgs e)` and `private void UpdateCounterDisplay()`. Both the Add and Subtract buttons had to call `UpdateCounterDisplay` — one method used from two places.
- The Python and Java regionals say "each major part must be its own documented function." Graders check the purpose/parameters/return comments.
- Separating calculation (return a value) from display (print or show) makes the "grader button" possible — a button that calls your other code to test it.

## The challenge: Snack Bar with Functions

Rebuild the Step 2 snack bar so an order can have several items, using methods.

**Requirements:**
1. Header comment.
2. Rebuild the Step 2 snack bar so an order can have **several items**: after each item ask `Add another item? (y/n): `.
3. Write these functions (names in your language's style):
   - `calculate_subtotal(price, quantity)` → returns price × quantity
   - `calculate_tax(subtotal)` → returns subtotal × TAX_RATE
   - `format_money(amount)` → returns text like `$12.04`
   - `print_receipt(name, item_count, subtotal)` → prints the receipt (calls `calculate_tax` and `format_money`), returns nothing
   - `main()` → asks the questions, keeps the running subtotal and item count, calls `print_receipt`
4. Every function has a comment with its purpose, parameters, and return value.
5. Input / Processing / Output comments.

In C# style the method names are `CalculateSubtotal`, `CalculateTax`, `FormatMoney`, `PrintReceipt`, and `Main`.

**Sample run (exact):**
```text
Customer name: Jordan
Item: Pretzel
Price: 2.75
Quantity: 3
Add another item? (y/n): y
Item: Lemonade
Price: 1.50
Quantity: 2
Add another item? (y/n): n

--- Receipt for Jordan ---
Items ordered: 5
Subtotal:  $11.25
Tax (7%):  $0.79
Total:     $12.04
```
(`Items ordered` is the total quantity: 3 + 2.)

**Hints:**
- Signatures to aim for: `static decimal CalculateSubtotal(decimal price, int quantity)`, `static decimal CalculateTax(decimal subtotal)`, `static string FormatMoney(decimal amount)`, `static void PrintReceipt(string name, int itemCount, decimal subtotal)`.
- `FormatMoney` can return `"$" + amount.ToString("F2")`.
- In `Main`, use a play-again style loop from Step 4: start `another` as `"y"`.
- The item name is asked for but not printed on the receipt. You still need to read it.
- Keep `TAX_RATE` as a constant above `Main` (`const decimal TAX_RATE = 0.07m;`).

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step05`.
2. Put your whole Visual Studio project folder (`Step05`) in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 5 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `CalculateSubtotal`, `CalculateTax`, `FormatMoney`, `PrintReceipt` all exist and are used
- [ ] `PrintReceipt` calls `CalculateTax` and `FormatMoney`
- [ ] Every method has a purpose / parameters / returns comment
- [ ] Pushed to `bpaPrep/csharp_step05`
