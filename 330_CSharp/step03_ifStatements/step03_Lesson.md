# Step 03 — If Statements (C#)

**What you'll build:** Grade Checker — a program that turns a score into a letter grade and says whether the student passed.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Comparison operators](#comparison-operators)
- [if and else](#if-and-else)
- [else if chains](#else-if-chains)
- [Logical operators: and, or, not](#logical-operators-and-or-not)
- [Nested if statements](#nested-if-statements)
- [Comparing text](#comparing-text)
- [The switch statement](#the-switch-statement)
- [A complete example](#a-complete-example)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Grade Checker](#the-challenge-grade-checker)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- The six comparison operators (`==`, `!=`, `<`, `>`, `<=`, `>=`)
- How to make decisions with `if`, `else if`, and `else`
- How to combine conditions with `&&` (and), `||` (or), and `!` (not)
- How to put one `if` inside another (nested if)
- How to compare text, including upper and lower case
- How to use a `switch` statement to pick from a list of exact values

## Comparison operators

A **comparison** asks a yes/no question. The answer is a `bool`: `true` or `false`.

| Operator | Means | Example (score is 85) | Result |
|---|---|---|---|
| `==` | is equal to | `score == 85` | `true` |
| `!=` | is not equal to | `score != 85` | `false` |
| `<` | is less than | `score < 60` | `false` |
| `>` | is greater than | `score > 90` | `false` |
| `<=` | is less than or equal to | `score <= 85` | `true` |
| `>=` | is greater than or equal to | `score >= 80` | `true` |

**`=` and `==` are different.** One `=` **puts** a value in a variable (`score = 85;`). Two `==` **asks** whether two values are equal (`score == 85`).

## if and else

An `if` statement runs a block of code only when its condition is `true`.

```csharp
int temperature = 38;

if (temperature < 40)
{
    Console.WriteLine("Wear a coat.");
}
else
{
    Console.WriteLine("No coat needed.");
}
Console.WriteLine("Have a good day.");
```

It prints:

```text
Wear a coat.
Have a good day.
```

- The condition goes in **parentheses** `( )`.
- The code to run goes in **curly braces** `{ }`.
- `else` is optional. It runs when the condition is `false`.
- There is **no semicolon** after `if (...)`.
- The last line is outside the if/else, so it always runs.

## else if chains

When there are more than two choices, chain them with `else if`. C# checks the conditions **from the top down** and runs **only the first one that is true**. Then it skips the rest.

```csharp
int speed = 47;
string message;

if (speed > 65)
{
    message = "Too fast";
}
else if (speed > 45)
{
    message = "A little fast";
}
else if (speed >= 25)
{
    message = "Just right";
}
else
{
    message = "Too slow";
}
Console.WriteLine(message);
```

This prints `A little fast`. Speed 47 is not over 65, but it is over 45, so the second block runs and the rest are skipped.

Because C# stops at the first true condition, **order matters**. If you checked `speed >= 25` first, every speed above 25 — even 80 — would print "Just right." Put the most restrictive test first.

Notice that `message` was made with no value (`string message;`) and every branch gives it one. C# allows that because it can see the `else` covers every other case.

**Try it:**
- Change `speed` to 70, 30, and 10 and predict the output before you run it.

## Logical operators: and, or, not

Combine conditions with logical operators:

| Operator | Name | True when… |
|---|---|---|
| `&&` | and | **both** sides are true |
| `\|\|` | or | **at least one** side is true |
| `!` | not | flips true to false and false to true |

```csharp
int age = 16;
bool hasPermit = true;

// && - both must be true
if (age >= 16 && hasPermit)
{
    Console.WriteLine("You may drive with an adult.");
}

// || - either one is enough
int month = 7;
if (month == 6 || month == 7 || month == 8)
{
    Console.WriteLine("Summer break.");
}

// ! - not
if (!hasPermit)
{
    Console.WriteLine("Get a permit first.");
}
```

It prints:

```text
You may drive with an adult.
Summer break.
```

A common use of `||` is checking whether a number is **outside** a range:

```csharp
if (hours < 0 || hours > 24)
{
    Console.WriteLine("Hours must be 0 to 24.");
}
```

A common use of `&&` is checking whether a number is **inside** a range: `hours >= 0 && hours <= 24`.

You can't write `0 <= hours <= 24` in C# like you would in math. You must write two comparisons joined by `&&`.

## Nested if statements

An `if` can go inside another `if`. The inner one is only checked when the outer one is true.

```csharp
int hoursWorked = 45;
bool isHourly = true;

if (isHourly)
{
    if (hoursWorked > 40)
    {
        Console.WriteLine($"Overtime hours: {hoursWorked - 40}");
    }
    else
    {
        Console.WriteLine("No overtime.");
    }
}
```

This prints `Overtime hours: 5`. Nesting is useful for "first check that the input is valid, and only then decide what it means." That is exactly what the challenge does.

## Comparing text

In C#, you can compare strings with `==` and `!=`:

```csharp
string answer = "yes";
if (answer == "yes")
{
    Console.WriteLine("Great!");
}
```

(If you also learn Java: in Java you must use `.equals()` for strings, because `==` doesn't compare the letters there. In C#, `==` does compare the letters, so it's fine.)

Comparisons are **case-sensitive**. `"Yes" == "yes"` is `false`. If the user might type any mix of upper and lower case, change their answer to lower case first with `.ToLower()`:

```csharp
Console.Write("Continue? (yes/no): ");
string reply = (Console.ReadLine() ?? "").ToLower();

if (reply == "yes")
{
    Console.WriteLine("Continuing.");
}
```

Now `YES`, `Yes`, and `yes` all work. (`.ToUpper()` does the opposite.) Another way is `reply.Equals("yes", StringComparison.OrdinalIgnoreCase)`, which compares while ignoring case. Both are fine; `ToLower` is shorter.

## The switch statement

When you are comparing **one** variable against a list of **exact** values, a `switch` can be cleaner than a long `else if` chain.

```csharp
int dayNumber = 3;
string dayName;

switch (dayNumber)
{
    case 1:
        dayName = "Monday";
        break;
    case 2:
        dayName = "Tuesday";
        break;
    case 3:
        dayName = "Wednesday";
        break;
    case 4:
    case 5:
        dayName = "Thursday or Friday";   // two cases can share one block
        break;
    default:
        dayName = "Weekend";
        break;
}
Console.WriteLine(dayName);
```

This prints `Wednesday`.

| Part | What it means |
|---|---|
| `switch (dayNumber)` | the variable being checked |
| `case 3:` | "if it equals 3, start here" |
| `break;` | "done — jump out of the switch." **C# requires a `break`** at the end of every case block. Forgetting it is an error. |
| `default:` | runs when no case matches (like a final `else`) |

`switch` also works with strings: `case "e":`. It does **not** work with ranges like "80 to 89" in this simple form, so for the grade challenge an `else if` chain is the right tool. You will use `switch` again for menu choices.

## A complete example

This program prices a movie ticket. It uses `if`/`else if`, `&&`, `||`, `switch`, and a text comparison. (It is not the challenge.)

<!-- input: Tue|15 -->
```csharp
// Name: Example
// Date: 2026-11-06
// Program: Movie Ticket Price
// Description: Prices a movie ticket from the day and the customer's age.

using System;

namespace MovieTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input: day and age
            Console.Write("Day (Mon-Sun): ");
            string day = (Console.ReadLine() ?? "").ToLower();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine() ?? "");

            // Processing: check that the age makes sense (|| = or)
            if (age < 0 || age > 120)
            {
                // Output: error only
                Console.WriteLine("Error: age must be 0 to 120.");
            }
            else
            {
                // Processing: base price by age
                decimal price;
                if (age < 12)
                {
                    price = 6.00m;
                }
                else if (age >= 65)
                {
                    price = 7.00m;
                }
                else
                {
                    price = 10.00m;
                }

                // Processing: Tuesday discount for ages 12-64 (&& = and)
                if (day == "tue" && age >= 12 && age < 65)
                {
                    price -= 2.00m;
                }

                // Processing: pick the message for the day
                string note;
                switch (day)
                {
                    case "fri":
                    case "sat":
                        note = "Weekend crowd - arrive early.";
                        break;
                    case "tue":
                        note = "Discount Tuesday!";
                        break;
                    default:
                        note = "Enjoy the show.";
                        break;
                }

                // Output: price and note
                Console.WriteLine($"Ticket price: ${price:F2}");
                Console.WriteLine(note);
            }
        }
    }
}
```

It prints:

```text
Day (Mon-Sun): Tue
Age: 15
Ticket price: $8.00
Discount Tuesday!
```

**Try it:**
- Run it with `sat` and `70`, then with `mon` and `200`. Predict the output first.
- Add a `case "sun":` that prints `Matinee special at noon.`

## Common mistakes

**`=` instead of `==` in a condition.**
You write `if (score = 100)` and see `CS0029 Cannot implicitly convert type 'int' to 'bool'`.
Fix: use `==` to compare.

**A semicolon after the `if`.**
You write `if (score >= 60);` — the program builds, but the "passed" line prints for every score. Visual Studio shows warning `CS0642 Possible mistaken empty statement`.
Fix: no `;` after `if (...)`. The `;` ends the if with nothing in it.

**Wrong order in an `else if` chain.**
You check `score >= 60` before `score >= 90`, and every passing score gets a D.
Fix: check the highest range first and work down.

**Writing a range like math.**
You write `if (90 <= score <= 100)` and get `CS0019 Operator '<=' cannot be applied to operands of type 'bool' and 'int'`.
Fix: `if (score >= 90 && score <= 100)`.

**Forgetting `break` in a switch.**
You see `CS0163 Control cannot fall through from one case label ('case 1:') to another`.
Fix: end each case block with `break;`.

**Case doesn't match.**
The user types `Y` but your code checks `answer == "y"`, so nothing happens.
Fix: compare `answer.ToLower() == "y"`, or check both with `||`.

**"Use of unassigned local variable".**
You see `CS0165 Use of unassigned local variable 'letter'`.
Fix: make sure every path through your if/else gives the variable a value — usually by ending the chain with a plain `else`.

## How this shows up at BPA

- Almost every button at the 2026 regional needed an `if` to **check the input first** and show an error message when it was bad. "Is it a number? Is it in range?" is the first thing graders test.
- The distance converter button used **radio buttons**: `if (rdb_Miles.Checked) ... else ...`. That is an if/else on a `bool`.
- The counter buttons changed a label's color with an if: blue for zero or positive, red for negative.
- The Java and C++ events use `switch` for menus; you'll use it the same way in C# console menus.

## The challenge: Grade Checker

Write a program that reads a student name and score and prints the letter grade.

**Requirements:**
1. Header comment.
2. Ask for the student name and a score (whole number) with the exact prompts.
3. If the score is below 0 or above 100, print `Error: score must be 0 to 100.` and nothing else. Use a logical operator (or / `||`) in this check.
4. Otherwise print `<name> got a <letter>.` — 90–100 A, 80–89 B, 70–79 C, 60–69 D, below 60 F. Use "an" instead of "a" before A and F (`got an A.`, `got an F.`).
5. Then print `<name> passed.` for 60 or higher, otherwise `<name> did not pass.`
6. If the score is exactly 100, also print `Perfect score!` as the last line.
7. Input / Processing / Output comments.

**Sample run 1:**
```text
Student name: Taylor
Score (0-100): 87
Taylor got a B.
Taylor passed.
```
**Sample run 2:**
```text
Student name: Sam
Score (0-100): 105
Error: score must be 0 to 100.
```
**Sample run 3:**
```text
Student name: Riley
Score (0-100): 100
Riley got an A.
Riley passed.
Perfect score!
```
**Sample run 4:**
```text
Student name: Max
Score (0-100): 42
Max got an F.
Max did not pass.
```

**Hints:**
- Do the range check first. Put everything else inside its `else` (a nested if).
- Use an `else if` chain to set a `string letter` variable.
- Make a second variable for the word before the letter: start with `"a"` and change it to `"an"` when the letter is `"A"` or `"F"`. Then print `$"{name} got {article} {letter}."`.
- Test all four sample runs. Also try 0, 59, 60, 89, and 90 — the edges of each range are where mistakes hide.

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step03`.
2. Put your whole Visual Studio project folder (`Step03`) in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 3 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches all four sample runs
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] The range check uses `||`
- [ ] "an" before A and F, "a" before B, C, D
- [ ] `Perfect score!` only for exactly 100
- [ ] Pushed to `bpaPrep/csharp_step03`
