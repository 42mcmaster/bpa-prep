# Step 06 — Lists and Arrays (C#)

**What you'll build:** Score Stats — a program that stores a set of scores and prints the highest, lowest, average, and the scores sorted.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Arrays](#arrays)
- [Lists: List of int](#lists-list-of-int)
- [Array or List: which to use](#array-or-list-which-to-use)
- [Looping through a list](#looping-through-a-list)
- [Finding the highest value with your own loop](#finding-the-highest-value-with-your-own-loop)
- [Counting items that match](#counting-items-that-match)
- [Sorting](#sorting)
- [Passing a list to a method](#passing-a-list-to-a-method)
- [Printing a list on one line](#printing-a-list-on-one-line)
- [A complete example](#a-complete-example)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Score Stats](#the-challenge-score-stats)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to make an array and a `List<int>`, and how they are different
- That positions (indexes) start at **0**
- How to add items, count them, and read them by position
- How to loop through a list with `for` and with `foreach`
- How to find the highest, lowest, and average **with your own loop**
- How to count items that match a condition
- How to sort a list (low to high, then high to low) without losing the original order
- How to pass a list to a method

## Arrays

An **array** holds a fixed number of values of the same type, in numbered slots.

```csharp
int[] laps = new int[4];              // 4 slots, all start at 0
laps[0] = 62;                          // put 62 in the first slot
laps[1] = 58;

string[] days = { "Mon", "Tue", "Wed" };   // make and fill in one step

Console.WriteLine(days[0]);            // Mon
Console.WriteLine(days.Length);        // 3
Console.WriteLine(laps[3]);            // 0 (never set)
```

| What you type | What it means |
|---|---|
| `int[]` | "an array of ints." The `[]` means array. |
| `new int[4]` | make a new array with 4 slots. Number slots start at 0, text slots start at `null`. |
| `{ "Mon", "Tue", "Wed" }` | make an array already filled with these values |
| `days[0]` | the value at **index** 0 — the first one |
| `days.Length` | how many slots (no parentheses) |

**Indexes start at 0.** An array of 3 has indexes 0, 1, 2. The last index is always `Length - 1`. Asking for `days[3]` crashes with:

```text
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
```

An array **can't grow**. Once you make it with 4 slots, it has 4 slots forever.

## Lists: List of int

A **List** is like an array that can grow and shrink. You add items one at a time.

`List` lives in a library called `System.Collections.Generic`. Add this line at the top with the other `using` line:

```csharp
using System.Collections.Generic;
```

A .NET 8 project already includes it behind the scenes (like `using System;`), so your code works even if you forget it. Write it anyway — it shows the grader what your program uses, and older project types need it.

```csharp
List<int> points = new List<int>();   // an empty list of ints
points.Add(15);                        // add to the end
points.Add(22);
points.Add(9);

Console.WriteLine(points.Count);       // 3
Console.WriteLine(points[1]);          // 22
points[1] = 25;                        // change the item at index 1
points.RemoveAt(0);                    // remove the item at index 0 (the 15)
Console.WriteLine(points[0]);          // 25 (everything moved up)
Console.WriteLine(points.Contains(9)); // True
```

| What you type | What it means |
|---|---|
| `List<int>` | "a list of ints." The type inside `< >` is what the list holds: `List<string>`, `List<double>`, `List<decimal>`. |
| `new List<int>()` | make a new, empty list |
| `.Add(x)` | put `x` on the end |
| `.Count` | how many items (a List uses `Count`, an array uses `Length`) |
| `list[i]` | the item at index `i` (starts at 0, just like arrays) |
| `.RemoveAt(i)` | remove the item at index `i` |
| `.Remove(x)` | remove the first item equal to `x` |
| `.Contains(x)` | `true` if `x` is in the list |
| `.Insert(i, x)` | put `x` at index `i`, pushing the rest down |
| `.Clear()` | remove everything |

## Array or List: which to use

| Use an **array** when… | Use a **List** when… |
|---|---|
| you know exactly how many items there are, and it won't change (7 days, 12 months, 3 rounds) | you don't know how many items there will be, or items get added and removed |
| | you are reading items from the user or a file |

In BPA programs, **`List` is usually the better choice**. The 2026 regional asked for "a `List<string>` or equivalent data structure." The challenge uses `List<int>`.

## Looping through a list

There are two ways. A `for` loop uses the index:

```csharp
List<string> players = new List<string> { "Avery", "Blake", "Casey" };

for (int i = 0; i < players.Count; i++)
{
    Console.WriteLine($"{i + 1}. {players[i]}");
}
```

A **`foreach`** loop gives you each item in turn, without an index:

```csharp
foreach (string player in players)
{
    Console.WriteLine(player);
}
```

The first prints `1. Avery`, `2. Blake`, `3. Casey`. The second prints the three names.

Read `foreach (string player in players)` as "for each string, call it `player`, in the list `players`."

- Use **`for`** when you need the position number (`i + 1` for numbering, or to compare with a neighbor).
- Use **`foreach`** when you just need each value. It is simpler and can't go out of range.
- You can't add or remove items from a list **while** a `foreach` loop is going through it.

Notice `new List<string> { "Avery", "Blake", "Casey" }` — you can fill a list when you make it, like an array.

## Finding the highest value with your own loop

C# has built-in shortcuts like `.Max()`, `.Min()`, `.Sum()`, and `.Average()`. **Don't use them for the challenge.** BPA graders want to see that you can write the algorithm yourself, and it is good practice.

The idea for "highest":
1. Assume the **first** item is the highest so far.
2. Look at every item. If one is bigger than the highest so far, it becomes the new highest.
3. When the loop ends, you have the highest.

```csharp
List<double> temps = new List<double> { 61.5, 70.2, 58.0, 73.4, 66.1 };

double warmest = temps[0];           // step 1: assume the first is the highest
foreach (double t in temps)          // step 2: check every item
{
    if (t > warmest)
    {
        warmest = t;                 // found a bigger one
    }
}
Console.WriteLine($"Warmest: {warmest}");   // step 3
```

This prints `Warmest: 73.4`.

Why start with `temps[0]` and not `0`? If every value were negative, starting at `0` would give the wrong answer. Starting with a real item always works.

"Lowest" is the same with `<`. "Average" is a running total (Step 4) divided by the count — and remember the **whole-number division trap** from Step 2: if the total and count are both `int`, cast one to `double` first.

## Counting items that match

A counter with an `if` inside the loop:

```csharp
int warmDays = 0;
foreach (double t in temps)
{
    if (t >= 65)
    {
        warmDays++;
    }
}
Console.WriteLine($"Days 65 or warmer: {warmDays}");
```

This prints `Days 65 or warmer: 3`.

## Sorting

```csharp
List<int> nums = new List<int> { 40, 10, 30, 20 };
nums.Sort();      // low to high:  10 20 30 40
nums.Reverse();   // flip it:      40 30 20 10
```

For an array: `Array.Sort(myArray);` and `Array.Reverse(myArray);`.

**Sorting changes the list itself.** The original order is gone. If you still need the original order, **sort a copy**:

```csharp
List<int> sorted = new List<int>(nums);   // a new list with the same items
sorted.Sort();
sorted.Reverse();
// nums is still in its original order
```

`new List<int>(nums)` makes a **separate** list. Changing `sorted` does not change `nums`.

Be careful: `List<int> sorted = nums;` does **not** copy. It makes a second name for the **same** list. Sorting `sorted` would sort `nums` too.

## Passing a list to a method

A method can take a list as a parameter:

```csharp
// Purpose: add up all the values in a list.
// Parameters: values - the numbers to add.
// Returns: the total.
static int AddUp(List<int> values)
{
    int total = 0;
    foreach (int v in values)
    {
        total += v;
    }
    return total;
}
```

Call it with `AddUp(nums)`. Unlike an `int` (which is copied), a list is passed so the method works with **the same list**. If the method calls `values.Add(5)` or `values.Sort()`, the caller's list changes too. Methods that only read the list (like this one) are safe.

## Printing a list on one line

Two ways to print `40 30 20 10`:

```csharp
// Way 1: string.Join puts the separator between the items
Console.WriteLine(string.Join(" ", nums));

// Way 2: your own loop, then trim the extra space off the end
string line = "";
foreach (int n in nums)
{
    line += n + " ";
}
Console.WriteLine(line.Trim());
```

Both print the same thing. `string.Join(separator, list)` is short and handy; the loop shows you how it works.

## A complete example

This program logs daily temperatures. It uses a `List<double>`, a range check, a method that takes the list, a counter, and a sorted copy. (It is not the challenge.)

<!-- input: 9|4|61.5|70.2|58.0|73.4 -->
```csharp
// Name: Example
// Date: 2026-11-06
// Program: Temperature Log
// Description: Stores daily temperatures and prints simple stats.

using System;
using System.Collections.Generic;

namespace TemperatureLog
{
    internal class Program
    {
        // Purpose: find the warmest temperature with a loop.
        // Parameters: temps - the list of temperatures (at least one).
        // Returns: the highest value.
        static double FindWarmest(List<double> temps)
        {
            // Processing: keep the biggest value seen so far
            double warmest = temps[0];
            foreach (double t in temps)
            {
                if (t > warmest)
                {
                    warmest = t;
                }
            }
            return warmest;
        }

        // Purpose: run the program.
        // Parameters: args - not used.
        // Returns: nothing.
        static void Main(string[] args)
        {
            // Input: how many days, 1 to 7
            Console.Write("How many days? ");
            int days = int.Parse(Console.ReadLine() ?? "");
            while (days < 1 || days > 7)
            {
                Console.WriteLine("Please enter 1 to 7.");
                Console.Write("How many days? ");
                days = int.Parse(Console.ReadLine() ?? "");
            }

            // Input: one temperature per day, added to the list
            List<double> temps = new List<double>();
            for (int i = 1; i <= days; i++)
            {
                Console.Write($"Day {i} temperature: ");
                temps.Add(double.Parse(Console.ReadLine() ?? ""));
            }

            // Processing: count the warm days
            int warmDays = 0;
            foreach (double t in temps)
            {
                if (t >= 65)
                {
                    warmDays++;
                }
            }

            // Processing: sorted copy, coldest first
            List<double> sorted = new List<double>(temps);
            sorted.Sort();

            // Output: results
            Console.WriteLine();
            Console.WriteLine("Temps: " + string.Join(" ", temps));
            Console.WriteLine($"Warmest: {FindWarmest(temps):F1}");
            Console.WriteLine($"Days 65 or warmer: {warmDays}");
            Console.WriteLine("Coldest to warmest: " + string.Join(" ", sorted));
        }
    }
}
```

It prints:

```text
How many days? 9
Please enter 1 to 7.
How many days? 4
Day 1 temperature: 61.5
Day 2 temperature: 70.2
Day 3 temperature: 58.0
Day 4 temperature: 73.4

Temps: 61.5 70.2 58 73.4
Warmest: 73.4
Days 65 or warmer: 2
Coldest to warmest: 58 61.5 70.2 73.4
```

Notice `58.0` printed as `58`. A `double` doesn't remember trailing zeros. Use a format like `:F1` when you want a fixed number of decimal places.

**Try it:**
- Add a `FindColdest` method.
- Print the average with 1 decimal place (add up with a loop, divide by `temps.Count`).

## Common mistakes

**Index out of range.**
You see `System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.` (List) or `System.IndexOutOfRangeException: Index was outside the bounds of the array.` (array).
Fix: indexes go from `0` to `Count - 1`. A loop should be `i < list.Count`, not `i <= list.Count`.

**Missing the `using` line in an older project.**
In a ".NET Framework" project (or with implicit usings turned off) you see `CS0246 The type or namespace name 'List<>' could not be found (are you missing a using directive or an assembly reference?)`.
Fix: add `using System.Collections.Generic;` at the top. It is a good habit in every project.

**`Length` vs `Count`.**
You see `CS1061 'List<int>' does not contain a definition for 'Length'`.
Fix: Lists use `.Count`. Arrays use `.Length`.

**Average comes out as a whole number.**
`407 / 5` gives `81`, not `81.4`.
Fix: `(double)total / scores.Count`.

**Sorting wrecks the original order.**
Your "Scores:" line comes out sorted.
Fix: print it before sorting, or sort a copy made with `new List<int>(scores)`.

**Starting the highest at 0.**
Works for scores, but gives wrong answers for lists that could be all negative.
Fix: start with `list[0]`.

**Using `.Max()` or `.Average()`.**
It works (if `using System.Linq;` is there), but the challenge says to write your own loop.
Fix: write the loop. Graders look for it.

## How this shows up at BPA

- The 2026 C# regional's first button stored vocabulary words in a `List<string>` and copied them into a list box — "Code that stores the list of Strings" was a graded item.
- The "Backwards" button had to use a **data structure** to reverse a string — for example, a `char` array and `Array.Reverse`, or a loop that goes from the last index down to 0.
- The Python regional stored players in a list and averaged scores. Graders look for loops you wrote, not just built-in functions.

## The challenge: Score Stats

Write a program that reads scores into a `List<int>` and prints stats.

**Requirements:**
1. Header comment.
2. Ask `How many scores? ` (assume a whole number from 1 to 20; if it is outside that range print `Please enter 1 to 20.` and ask again).
3. Ask for each score with `Score 1: `, `Score 2: `, … and store them in a list/array.
4. Write these functions, each taking the list/array as a parameter: `find_highest`, `find_lowest`, `calculate_average`. **Use your own loop** in each — no built-in max/min/sum/average.
5. Print the results exactly as shown: all scores in the order entered, highest, lowest, average (2 decimals), how many scores are above the average, and the scores sorted high to low.
6. Function comments and Input / Processing / Output comments.

In C# the list is a `List<int>` and the methods are `FindHighest`, `FindLowest`, and `CalculateAverage`.

**Sample run (exact):**
```text
How many scores? 5
Score 1: 88
Score 2: 92
Score 3: 75
Score 4: 92
Score 5: 60

Scores: 88 92 75 92 60
Highest: 92
Lowest: 60
Average: 81.40
Above average: 3
Sorted high to low: 92 92 88 75 60
```
(Sorting must not change the "Scores:" line — print that line before sorting, or sort a copy.)

**Hints:**
- Signatures: `static int FindHighest(List<int> scores)`, `static int FindLowest(List<int> scores)`, `static double CalculateAverage(List<int> scores)`.
- "Above average" means **greater than** the average (81.40). 88, 92, and 92 are above it, so the answer is 3.
- For the sorted line, copy the list, `Sort()`, then `Reverse()`.
- `{average:F2}` prints `81.40`.

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step06`.
2. Put your whole Visual Studio project folder (`Step06`) in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 6 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Scores are stored in a `List<int>`
- [ ] `FindHighest`, `FindLowest`, `CalculateAverage` each take the list and use your own loop
- [ ] "Scores:" line is in the original order
- [ ] Pushed to `bpaPrep/csharp_step06`
