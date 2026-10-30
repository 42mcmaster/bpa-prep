# Step 04 — Loops (C#)

**What you'll build:** Number Guessing Game — the computer picks a secret number and the player guesses until they get it, then can play again.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [while loops](#while-loops)
- [Counters and running totals](#counters-and-running-totals)
- [for loops](#for-loops)
- [break and continue](#break-and-continue)
- [Re-asking until the input is in range](#re-asking-until-the-input-is-in-range)
- [Random numbers](#random-numbers)
- [A play-again loop](#a-play-again-loop)
- [A complete example](#a-complete-example)
- [Testing a program that uses random numbers](#testing-a-program-that-uses-random-numbers)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Number Guessing Game](#the-challenge-number-guessing-game)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How a `while` loop repeats code as long as a condition is true
- How to count things and keep a running total inside a loop
- How a `for` loop counts from one number to another
- What `break` and `continue` do
- How to keep asking until the user types a number in range
- How to make random numbers with `Random`
- How to put a whole program inside a "play again?" loop

## while loops

A `while` loop is like an `if` that keeps repeating. It checks its condition; if it is true, it runs the block, then goes back and checks again. It stops when the condition is false.

```csharp
int countdown = 3;

while (countdown > 0)
{
    Console.WriteLine(countdown);
    countdown--;   // subtract 1 - without this the loop never ends
}
Console.WriteLine("Go!");
```

It prints:

```text
3
2
1
Go!
```

Step by step: `countdown` is 3, so the block runs (prints 3, countdown becomes 2). Back to the top: 2 > 0, run again. Then 1. Then `countdown` is 0, `0 > 0` is false, and the loop ends.

If nothing inside the loop ever makes the condition false, the loop runs forever. That is called an **infinite loop**. If your program seems stuck, press **Shift+F5** in Visual Studio (or close the console window) to stop it.

## Counters and running totals

Two patterns show up in almost every loop:
- A **counter** counts how many times something happened: start at `0`, add `1` each time (`count++`).
- A **running total** (also called an accumulator) adds up values: start at `0`, add each value (`total += value`).

```csharp
int total = 0;
int count = 0;
int number = 5;

while (number <= 25)
{
    total += number;   // running total
    count++;           // counter
    number += 5;
}
Console.WriteLine($"Added {count} numbers. Total: {total}");
```

This prints `Added 5 numbers. Total: 75` (5 + 10 + 15 + 20 + 25).

## for loops

A `for` loop is the best choice when you know **how many times** to repeat. All the counting parts sit on one line:

```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Lap {i}");
}
```

It prints:

```text
Lap 1
Lap 2
Lap 3
Lap 4
Lap 5
```

| Part | Example | What it does |
|---|---|---|
| start | `int i = 1` | runs **once** before the loop starts |
| condition | `i <= 5` | checked before **every** pass; the loop stops when it is false |
| update | `i++` | runs at the **end** of every pass |

`i` is the usual name for a loop counter. It only exists inside the loop.

Other ways to count:

```csharp
for (int i = 0; i < 5; i++)    { }   // 0, 1, 2, 3, 4  (5 passes - very common)
for (int i = 10; i >= 0; i--)  { }   // 10 down to 0
for (int i = 2; i <= 10; i += 2) { } // 2, 4, 6, 8, 10 (even numbers)
```

A `for` loop can build a row of symbols. `Console.Write` keeps everything on one line:

```csharp
int stars = 4;
Console.Write("Rating: ");
for (int i = 0; i < stars; i++)
{
    Console.Write("*");
}
Console.WriteLine();   // end the line
```

This prints `Rating: ****`. You'll use this pattern for the guess chart.

**Try it:**
- Print the 7 times table: `7 x 1 = 7` through `7 x 10 = 70`.
- Add up the numbers 1 to 100 with a `for` loop. (The answer is 5050.)

## break and continue

| What you type | What it does |
|---|---|
| `break;` | leaves the loop right now. The program continues after the loop. |
| `continue;` | skips the rest of **this pass** and goes back to the top of the loop (the condition is checked again). |

```csharp
for (int i = 1; i <= 10; i++)
{
    if (i % 3 == 0)
    {
        continue;   // skip multiples of 3
    }
    if (i > 7)
    {
        break;      // stop completely after 7
    }
    Console.Write(i + " ");
}
Console.WriteLine();
```

This prints `1 2 4 5 7 `. Use them sparingly. A loop with a clear condition is easier to read than one with lots of `break`s.

C# also has a `do { ... } while (condition);` loop. It runs the block **once first** and checks the condition after. You won't need it for the challenges, but you may see it in the reference guide.

## Re-asking until the input is in range

A `while` loop can keep asking a question until the answer is good:

<!-- input: 12|0|4 -->
```csharp
using System;

namespace RangeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input: ask for a team size from 1 to 5
            Console.Write("Team size (1-5): ");
            int size = int.Parse(Console.ReadLine() ?? "");

            // Processing: keep asking while it is out of range
            while (size < 1 || size > 5)
            {
                Console.WriteLine("Team size must be 1 to 5.");
                Console.Write("Team size (1-5): ");
                size = int.Parse(Console.ReadLine() ?? "");
            }

            // Output: the accepted value
            Console.WriteLine($"Team of {size} saved.");
        }
    }
}
```

With `12`, then `0`, then `4` typed in, it prints:

```text
Team size (1-5): 12
Team size must be 1 to 5.
Team size (1-5): 0
Team size must be 1 to 5.
Team size (1-5): 4
Team of 4 saved.
```

This still crashes if the user types letters. Step 10 fixes that with `int.TryParse`.

## Random numbers

C# makes random numbers with a **`Random` object**:

```csharp
Random rng = new Random();          // make the random number maker (do this ONCE)
int roll = rng.Next(1, 7);          // a whole number from 1 to 6
int card = rng.Next(1, 14);         // 1 to 13
double chance = rng.NextDouble();   // a decimal from 0.0 up to (not including) 1.0
```

| What you type | What it means |
|---|---|
| `Random rng = new Random();` | `new` **creates an object** — here, a random number maker named `rng`. You will learn more about objects in Step 11. |
| `rng.Next(1, 7)` | a random whole number **from 1 up to, but not including, 7** — so 1 to 6. |

**The second number is NOT included.** For 1 to 100, write `rng.Next(1, 101)`. This trips up almost everyone the first time.

Make the `Random` object **once** at the top of `Main` and reuse it. Don't make a new one inside a loop.

## A play-again loop

To let the user play again, put the whole game inside a `while` loop that checks their answer:

```csharp
string again = "y";
while (again == "y" || again == "Y")
{
    // ... the whole game goes here ...

    Console.Write("Play again? (y/n): ");
    again = Console.ReadLine() ?? "";
}
Console.WriteLine("Bye!");
```

Start `again` as `"y"` so the loop runs the first time. Any answer other than `y` or `Y` ends it. This is a loop **inside** which other loops can run — the guessing loop goes inside the play-again loop.

## A complete example

This program figures out how many weeks it takes to save up for something, shows a chart, and lets you try again. (It is not the challenge.)

<!-- input: Headphones|80|900|30|y|Game|60|25|n -->
```csharp
// Name: Example
// Date: 2026-11-06
// Program: Savings Goal
// Description: Works out how many weeks of saving it takes to reach a goal.

using System;

namespace SavingsGoal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int plansMade = 0;
            string again = "y";

            // Processing: outer loop - one pass per savings plan
            while (again == "y" || again == "Y")
            {
                // Input: what to save for and how much
                Console.Write("Saving for: ");
                string item = Console.ReadLine() ?? "";
                Console.Write("Cost: ");
                int cost = int.Parse(Console.ReadLine() ?? "");

                // Input: weekly amount, re-asked until it is 1 to 500
                Console.Write("Save per week (1-500): ");
                int weekly = int.Parse(Console.ReadLine() ?? "");
                while (weekly < 1 || weekly > 500)
                {
                    Console.WriteLine("Please enter 1 to 500.");
                    Console.Write("Save per week (1-500): ");
                    weekly = int.Parse(Console.ReadLine() ?? "");
                }

                // Processing: add the weekly amount until the goal is reached
                int saved = 0;
                int weeks = 0;
                while (saved < cost)
                {
                    saved += weekly;
                    weeks++;
                }
                plansMade++;

                // Output: result and a chart with one # per week
                Console.WriteLine($"{item}: {weeks} weeks (saved ${saved})");
                Console.Write("Weeks: ");
                for (int i = 0; i < weeks; i++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();

                // Input: try again?
                Console.Write("Another plan? (y/n): ");
                again = Console.ReadLine() ?? "";
            }

            // Output: final message
            Console.WriteLine($"Plans made: {plansMade}");
        }
    }
}
```

It prints:

```text
Saving for: Headphones
Cost: 80
Save per week (1-500): 900
Please enter 1 to 500.
Save per week (1-500): 30
Headphones: 3 weeks (saved $90)
Weeks: ###
Another plan? (y/n): y
Saving for: Game
Cost: 60
Save per week (1-500): 25
Game: 3 weeks (saved $75)
Weeks: ###
Another plan? (y/n): n
Plans made: 2
```

**Try it:**
- Change the chart to print one `#` for every $10 saved instead of every week.

## Testing a program that uses random numbers

Random numbers make testing hard, because you can't predict the answer. While you are building the guessing game, **temporarily print the secret number** right after you pick it:

```csharp
int secret = rng.Next(1, 101);
Console.WriteLine($"(TESTING - secret is {secret})");   // REMOVE before turning in
```

Now you can guess too high, too low, and correct on purpose and check each message. **Delete that line before you turn it in** — the sample run doesn't show it.

Another trick: `new Random(42)` (with a number inside) gives the **same** "random" numbers every time you run. That is handy while testing. Change it back to `new Random()` when you are done.

## Common mistakes

**The loop never ends.**
The console keeps printing or waits forever.
Fix: make sure something inside the loop changes the variable in the condition (`countdown--`, reading a new guess, and so on). Press Shift+F5 to stop it.

**Off by one with `Next`.**
`rng.Next(1, 100)` never picks 100.
Fix: the second number is not included. Use `rng.Next(1, 101)` for 1 to 100.

**Making `new Random()` inside the loop.**
It works, but it is wasteful and not what graders expect.
Fix: make it once at the start of `Main`.

**Counting the out-of-range guess.**
`150` gets counted, so the player sees "4 guesses" instead of 3.
Fix: when the guess is out of range, print the message and use `continue` (or an `else`) so the counter line is skipped.

**Chart printed on separate lines.**
You used `Console.WriteLine("*")` inside the `for` loop, so each star is on its own line.
Fix: use `Console.Write("*")` inside the loop and one `Console.WriteLine()` after it.

**Typing letters crashes the game.**
You see `System.FormatException: The input string 'abc' was not in a correct format.`
That is expected in this step. Step 10 makes it crash-proof (and its "Try it" asks you to come back and fix this game).

**Variable made inside the loop is "not found" after it.**
You see `CS0103 The name 'guessCount' does not exist in the current context`.
Fix: a variable made inside `{ }` only exists inside those braces. Make it before the loop if you need it after.

## How this shows up at BPA

- The 2026 regional's "Add Evens" button was a loop: add up every even number from 2 up to the number typed in. That is a `for` loop with `i += 2` and a running total.
- The "Random Font" button used `Random` to pick a size, a style, and red/green/blue color values. Remember `Next(8, 21)` for 8 to 20.
- The Java and C++ regionals use `while` loops for menus and for re-asking bad input.
- Graders look for loop logic you wrote yourself — a counter, a running total, a clear stop condition.

## The challenge: Number Guessing Game

Write a guessing game with a play-again loop.

**Requirements:**
1. Header comment.
2. The computer picks a secret whole number from 1 to 100.
3. Keep asking `Your guess (1-100): ` until the player guesses it. Print `Too low!` or `Too high!` after each wrong guess.
4. If a guess is below 1 or above 100, print `Please guess between 1 and 100.` — this does **not** count as a guess.
5. When they get it, print `You got it in N guesses!` (use `guess` instead of `guesses` when N is 1).
6. Use a `for` loop to print a guess chart: `Guess chart: ` followed by one `*` per guess.
7. Ask `Play again? (y/n): `. `y` or `Y` starts a new game with a new secret number; anything else ends it.
8. When the player stops, print `Thanks for playing! Games played: N`.
9. Input / Processing / Output comments.

**Sample run** (the secret number was 42 here — yours will be random):
```text
I'm thinking of a number from 1 to 100.
Your guess (1-100): 50
Too high!
Your guess (1-100): 150
Please guess between 1 and 100.
Your guess (1-100): 25
Too low!
Your guess (1-100): 42
You got it in 3 guesses!
Guess chart: ***
Play again? (y/n): n
Thanks for playing! Games played: 1
```
The first line `I'm thinking of a number from 1 to 100.` prints at the start of every game.

**Hints:**
- Two loops: an outer play-again loop, and inside it a loop that runs `while (guess != secret)`. Start `guess` at `0` so the inner loop runs the first time.
- Pick the secret **inside** the outer loop, so each game gets a new number.
- Reset the guess counter to 0 at the start of each game.
- Print the secret while testing (see above), then remove it.
- Letters will crash it. That's OK for now — Step 10 fixes it.

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step04`.
2. Put your whole Visual Studio project folder (`Step04`) in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 4 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run (with your own secret number)
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Secret uses `Random` and `Next(1, 101)`
- [ ] Out-of-range guesses don't count
- [ ] "guess" for 1, "guesses" for more
- [ ] Guess chart uses a `for` loop
- [ ] New secret number each game; games counted
- [ ] Testing line that prints the secret is removed
- [ ] Pushed to `bpaPrep/csharp_step04`
