# Step 08 — Nested Data (C#)

**What you'll build:** Team Scoreboard — a program that stores 3 round scores for each player, sorts the players by total, and prints a lined-up leaderboard with a short analysis.
**Time:** one to two class periods. This is a bigger step.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Rows and columns](#rows-and-columns)
- [Rectangular arrays: int[,]](#rectangular-arrays-int)
- [Jagged arrays: int[][]](#jagged-arrays-int)
- [Which one to use](#which-one-to-use)
- [Nested loops](#nested-loops)
- [Row totals and column averages](#row-totals-and-column-averages)
- [Parallel arrays](#parallel-arrays)
- [Sorting rows with selection sort](#sorting-rows-with-selection-sort)
- [Lining up columns](#lining-up-columns)
- [A complete example](#a-complete-example)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Team Scoreboard](#the-challenge-team-scoreboard)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to store a table of numbers (rows and columns) in C#
- The two kinds of 2D arrays: rectangular `int[,]` and jagged `int[][]`
- How to use a loop inside a loop to visit every cell
- How to add up a row and average a column
- How to keep a names array and a scores table in step ("parallel arrays")
- How to sort rows with a selection sort you write yourself
- How to print columns that line up, using `{value,-10}` and `:F2`

## Rows and columns

Some data is a table. Here, each **row** is a player and each **column** is a round:

| | Round 1 (col 0) | Round 2 (col 1) | Round 3 (col 2) |
|---|---|---|---|
| **row 0** | 80 | 90 | 70 |
| **row 1** | 95 | 85 | 88 |
| **row 2** | 60 | 75 | 100 |

To find a score you need two numbers: the row and the column. Row 2, column 2 is `100`. Both start at 0, just like a list.

## Rectangular arrays: int[,]

C# has a built-in table type. The comma inside the brackets means "two dimensions":

```csharp
int[,] grid = new int[3, 4];   // 3 rows, 4 columns, all 0
grid[0, 2] = 7;                // row 0, column 2

int[,] seats =
{
    { 1, 0, 1 },
    { 0, 0, 1 }
};
Console.WriteLine(seats[1, 2]);          // 1
Console.WriteLine(seats.GetLength(0));   // 2 rows
Console.WriteLine(seats.GetLength(1));   // 3 columns
```

| What you type | What it means |
|---|---|
| `int[,]` | a rectangular 2D array of ints |
| `new int[3, 4]` | 3 rows by 4 columns |
| `grid[r, c]` | the cell at row `r`, column `c` |
| `grid.GetLength(0)` | number of rows |
| `grid.GetLength(1)` | number of columns |

Every row has the same number of columns. That's why it is called rectangular.

## Jagged arrays: int[][]

A **jagged array** is an array whose items are arrays — an "array of rows." Each row is its own `int[]`.

```csharp
int[][] table = new int[3][];   // 3 rows, but the rows don't exist yet
table[0] = new int[4];          // make row 0 with 4 columns
table[1] = new int[4];
table[2] = new int[4];
table[1][3] = 9;                // row 1, column 3

int[][] quick =
{
    new int[] { 5, 6, 7 },
    new int[] { 8, 9, 10 }
};
Console.WriteLine(quick[1][0]);       // 8
Console.WriteLine(quick.Length);      // 2 rows
Console.WriteLine(quick[0].Length);   // 3 columns in row 0
```

| What you type | What it means |
|---|---|
| `int[][]` | an array of `int[]` rows |
| `new int[3][]` | room for 3 rows (each row still has to be made) |
| `table[r] = new int[4];` | make row `r` with 4 columns |
| `table[r][c]` | row `r`, column `c` — two sets of brackets |
| `table.Length` | number of rows |
| `table[r].Length` | number of columns in row `r` |
| `table[r]` | the whole row, as an `int[]` |

The name "jagged" comes from the fact that rows **can** have different lengths. In our programs they will all be the same.

If you forget to make a row and then use it, you get `System.NullReferenceException: Object reference not set to an instance of an object.` — the row is still `null` (nothing).

## Which one to use

Both work. The challenge uses **jagged `int[][]`** for one reason: you can grab or swap a **whole row** in one step.

```csharp
int[] firstRow = table[0];   // the whole row - works with int[][]
```

With `int[,]` there is no way to grab a row. To swap two players you'd need a loop that swaps each column. With `int[][]` you swap the rows like swapping two variables (shown below in the sort). Java's 2D arrays and Python's list of lists work the same way as C#'s jagged arrays, so this also matches the other languages.

You may also see `List<int[]>` — a growable list of rows. Step 9 uses it while reading a file, when you don't know how many rows there will be.

## Nested loops

To visit every cell, put a loop inside a loop. The **outer** loop goes through the rows. The **inner** loop goes through the columns of that row.

```csharp
int[][] marks =
{
    new int[] { 3, 5 },
    new int[] { 4, 1 },
    new int[] { 2, 2 }
};

for (int r = 0; r < marks.Length; r++)          // each row
{
    for (int c = 0; c < marks[r].Length; c++)   // each column in that row
    {
        Console.Write(marks[r][c] + " ");
    }
    Console.WriteLine();                         // end of the row
}
```

It prints:

```text
3 5 
4 1 
2 2 
```

The inner loop runs **all the way through** for each pass of the outer loop. With 3 rows and 2 columns, the inner `Console.Write` runs 6 times.

## Row totals and column averages

**A row total** (one player's total) — loop across the columns of one row:

```csharp
int rowTotal = 0;
for (int c = 0; c < marks[1].Length; c++)
{
    rowTotal += marks[1][c];
}
// rowTotal is 5 (4 + 1)
```

A whole row is an `int[]`, so a method can take it: `static int AddRow(int[] row)`. Call it with `AddRow(marks[1])`.

**A column average** (one round's average) — loop **down** the rows, staying in one column:

```csharp
int colTotal = 0;
for (int r = 0; r < marks.Length; r++)
{
    colTotal += marks[r][0];   // column 0 every time
}
double colAverage = (double)colTotal / marks.Length;
// (3 + 4 + 2) / 3 = 3.0
```

To find the **best** column, wrap that in another loop over the columns and keep the highest average (the "highest so far" idea from Step 6).

## Parallel arrays

The scores table holds only numbers. The names go in a separate `string[]`. Row `i` of the scores belongs to `names[i]`:

```text
names[0] = "Jordan"     scores[0] = { 80, 90, 70 }
names[1] = "Taylor"     scores[1] = { 95, 85, 88 }
names[2] = "Sam"        scores[2] = { 60, 75, 100 }
```

These are called **parallel arrays**: the same index in each one describes the same player. The rule: **whenever you move something in one, move the matching thing in the other.** If you sort the scores but not the names, Taylor's scores end up next to Jordan's name.

(In Step 11 you'll learn a cleaner way: a class that holds a name **and** scores together. Parallel arrays are still common and graders like seeing you keep them in sync.)

## Sorting rows with selection sort

`Array.Sort` can sort one array, but it can't keep two parallel arrays together by a total. So write your own sort. **Selection sort** is the easiest to understand:

1. Look at position 0. Search the whole list for the **biggest** total. Swap it into position 0.
2. Look at position 1. Search from position 1 to the end for the biggest. Swap it into position 1.
3. Keep going until the second-to-last position. The last one is then in place by itself.

Here it is sorting players by total, highest first, swapping the name **and** the row together:

```csharp
// Purpose: sort players by total, highest first (selection sort).
// Parameters: names, scores - parallel arrays; both are changed in place.
// Returns: nothing.
static void SortByTotal(string[] names, int[][] scores)
{
    for (int i = 0; i < names.Length - 1; i++)
    {
        // Processing: find the biggest total from position i to the end
        int biggest = i;
        for (int j = i + 1; j < names.Length; j++)
        {
            if (AddRow(scores[j]) > AddRow(scores[biggest]))
            {
                biggest = j;
            }
        }

        // Processing: swap the name at i with the name at biggest
        string tempName = names[i];
        names[i] = names[biggest];
        names[biggest] = tempName;

        // Processing: swap the score rows the same way (a jagged array swaps whole rows)
        int[] tempRow = scores[i];
        scores[i] = scores[biggest];
        scores[biggest] = tempRow;
    }
}
```

A **swap** needs a temporary variable. If you wrote `a = b; b = a;`, both would end up as `b`'s value. The temp holds `a` safely while `a` is overwritten.

Walk through it with totals `[240, 268, 235]` (Jordan, Taylor, Sam):

| Pass | i | Biggest found from i on | After the swap |
|---|---|---|---|
| 1 | 0 | 268 at index 1 | `[268, 240, 235]` (Taylor, Jordan, Sam) |
| 2 | 1 | 240 at index 1 (itself) | no change |
| done | | | Taylor, Jordan, Sam |

Using `>` (not `>=`) means that when two totals tie, the one that was first stays first.

Arrays are passed to methods the same way lists are: the method works on **the same array**, so the sort changes the caller's arrays. That is why this method can be `void`.

## Lining up columns

To make a table line up, every value in a column must take up the same width. C# does this inside the `{ }` with a comma and a width:

| What you type | Means | Example output (between the bars) |
|---|---|---|
| `{name,-10}` | 10 characters wide, **left**-aligned (minus sign) | `\|Sam       \|` |
| `{name,10}` | 10 wide, **right**-aligned | `\|       Sam\|` |
| `{avg,-8:F2}` | 8 wide, left, and 2 decimals | `\|78.33   \|` |
| `{"Total",-7}` | works with plain text too | `\|Total  \|` |

You can also pad a string with methods: `name.PadRight(10)` and `name.PadLeft(10)`.

To make a line of dashes, `new string('-', 39)` gives 39 dashes without counting them by hand.

```csharp
Console.WriteLine($"{"Item",-8}{"Qty",-5}Price");
Console.WriteLine(new string('-', 18));
Console.WriteLine($"{"Pen",-8}{12,-5}{0.5,5:F2}");
Console.WriteLine($"{"Notebook",-8}{3,-5}{2.25,5:F2}");
```

It prints:

```text
Item    Qty  Price
------------------
Pen     12    0.50
Notebook3     2.25
```

Notice `Notebook` is exactly 8 letters, so there is no space after it — it runs into the next column. Pick widths a little wider than your longest value.

## A complete example

This program keeps a reading log: pages read by 4 students over 4 weeks. It uses a jagged array, parallel arrays, a selection sort, nested loops, and a lined-up table. The data is typed into the code so you can focus on the table. (It is not the challenge.)

```csharp
// Name: Example
// Date: 2026-11-06
// Program: Reading Log
// Description: Sorts students by total pages read and prints a table
//              with each week's average.

using System;

namespace ReadingLog
{
    internal class Program
    {
        const int WEEKS = 4;

        // Purpose: add up one student's pages.
        // Parameters: row - pages for each week.
        // Returns: the total pages.
        static int AddRow(int[] row)
        {
            int total = 0;
            foreach (int pages in row)
            {
                total += pages;
            }
            return total;
        }

        // Purpose: sort students by total pages, highest first (selection sort).
        // Parameters: names, pages - parallel arrays, both changed in place.
        // Returns: nothing.
        static void SortByTotal(string[] names, int[][] pages)
        {
            for (int i = 0; i < names.Length - 1; i++)
            {
                int biggest = i;
                for (int j = i + 1; j < names.Length; j++)
                {
                    if (AddRow(pages[j]) > AddRow(pages[biggest]))
                    {
                        biggest = j;
                    }
                }
                string tempName = names[i];
                names[i] = names[biggest];
                names[biggest] = tempName;

                int[] tempRow = pages[i];
                pages[i] = pages[biggest];
                pages[biggest] = tempRow;
            }
        }

        // Purpose: print the table, one row per student, then the weekly averages.
        // Parameters: names, pages - the sorted parallel arrays.
        // Returns: nothing.
        static void PrintTable(string[] names, int[][] pages)
        {
            // Output: header
            Console.WriteLine($"{"Student",-9}{"W1",-5}{"W2",-5}{"W3",-5}{"W4",-5}Total");
            Console.WriteLine(new string('-', 34));

            // Output: one row per student (nested loop: students, then weeks)
            for (int s = 0; s < names.Length; s++)
            {
                Console.Write($"{names[s],-9}");
                for (int w = 0; w < WEEKS; w++)
                {
                    Console.Write($"{pages[s][w],-5}");
                }
                Console.WriteLine(AddRow(pages[s]));
            }

            // Processing + Output: the average of each week (go down each column)
            Console.Write($"{"Average",-9}");
            for (int w = 0; w < WEEKS; w++)
            {
                int weekTotal = 0;
                for (int s = 0; s < names.Length; s++)
                {
                    weekTotal += pages[s][w];
                }
                double weekAverage = (double)weekTotal / names.Length;
                Console.Write($"{weekAverage,-5:F0}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Input: data typed into the program (parallel arrays)
            string[] names = { "Avery", "Blake", "Casey", "Devon" };
            int[][] pages =
            {
                new int[] { 40, 55, 30, 60 },
                new int[] { 80, 20, 45, 50 },
                new int[] { 25, 35, 40, 30 },
                new int[] { 90, 70, 65, 85 }
            };

            // Processing: sort by total
            SortByTotal(names, pages);

            // Output: the table and the top reader
            PrintTable(names, pages);
            Console.WriteLine();
            Console.WriteLine($"Top reader: {names[0]} ({AddRow(pages[0])} pages)");
        }
    }
}
```

It prints:

```text
Student  W1   W2   W3   W4   Total
----------------------------------
Devon    90   70   65   85   310
Blake    80   20   45   50   195
Avery    40   55   30   60   185
Casey    25   35   40   30   130
Average  59   45   45   56   

Top reader: Devon (310 pages)
```

Blake (195) is above Avery (185) even though Avery came first in the original data — the sort moved Blake's name **and** Blake's row together. `:F0` rounds the averages to whole numbers (58.75 shows as 59).

Always check a sorted table by eye. It is the fastest way to catch a sort that swaps the names but not the rows (or the other way around).

**Try it:**
- Change `>` to `<` in `SortByTotal`. What order do you get?
- Add a line that prints which week had the highest average.

## Common mistakes

**Mixing up `[r, c]` and `[r][c]`.**
Using `scores[0, 1]` on a jagged array gives `CS0022 Wrong number of indices inside []; expected 1`.
Fix: jagged arrays use `scores[0][1]`. Rectangular arrays use `scores[0, 1]`.

**Forgetting to make each row of a jagged array.**
`System.NullReferenceException: Object reference not set to an instance of an object.`
Fix: `scores[p] = new int[3];` before you fill row `p`.

**Swapping the names but not the scores (or the reverse).**
The table prints, but the names and numbers don't match up.
Fix: every swap in the sort swaps **both** arrays.

**Inner and outer loops mixed up.**
Your column averages come out as row averages.
Fix: for a column average, the column stays fixed and the **row** changes in the loop.

**Columns don't line up.**
Fix: use the same widths in the header line and the data lines. Use `-` for left-aligned. Count against the sample run.

**Whole-number averages.**
`235 / 3` prints `78`.
Fix: `(double)total / 3`, then `:F2`.

**Re-asking the wrong thing after a bad score.**
After `Score must be 0 to 100.` your program moves on to the next round.
Fix: re-ask the **same** round with a `while` loop until the score is valid — a helper method that asks until the value is in range works well.

## How this shows up at BPA

- The 2026 Python regional stored players' scores in a nested structure and printed a leaderboard with totals and averages in columns. The C++ regional printed a CSV as an aligned table. Lined-up columns are a skill every event checks.
- Graders look for the **algorithm**: a sort you wrote, loops that total rows and average columns.
- "Find the best" questions (winner, hardest hole, highest round) are the "highest so far" pattern from Step 6, applied to rows or columns.

## The challenge: Team Scoreboard

Write a program that collects 3 round scores for each player and prints a sorted leaderboard.

**Requirements:**
1. Header comment.
2. Ask `How many players? ` (1 to 6; if outside print `Please enter 1 to 6.` and ask again).
3. Ask each player's name: `Player 1 name: `, …
4. For each player, ask 3 round scores: `<name>, round 1 score: ` … Scores must be 0 to 100; if not, print `Score must be 0 to 100.` and ask that same round again.
5. Store names in a list/array and scores in a 2D structure (one row per player, one column per round).
6. Print a leaderboard sorted by total, highest first, in the exact column format below: Name (10 wide, left), R1, R2, R3 (5 wide each, left), Total (7 wide, left), Average (2 decimals). A line of 39 dashes under the header.
7. Print the winner (highest total), the best single round (player, round number, score), and the highest scoring round (round with the highest average across all players, 2 decimals). If there's a tie, the first one found wins.
8. Use functions for: getting scores, calculating a player's total, sorting, printing the table, and the analysis. Function comments and Input / Processing / Output comments.

In C#: names in a `string[]`, scores in a jagged `int[][]`.

**Sample run (exact):**
```text
How many players? 3
Player 1 name: Jordan
Player 2 name: Taylor
Player 3 name: Sam
Jordan, round 1 score: 80
Jordan, round 2 score: 90
Jordan, round 3 score: 70
Taylor, round 1 score: 95
Taylor, round 2 score: 85
Taylor, round 3 score: 88
Sam, round 1 score: 60
Sam, round 2 score: 75
Sam, round 3 score: 105
Score must be 0 to 100.
Sam, round 3 score: 100

Name      R1   R2   R3   Total  Average
---------------------------------------
Taylor    95   85   88   268    89.33
Jordan    80   90   70   240    80.00
Sam       60   75   100  235    78.33

Winner: Taylor (268 points)
Best single round: Sam, round 3 (100)
Highest scoring round: Round 3 (average 86.00)
```
Check: round averages R1 = (80+95+60)/3 = 78.33, R2 = (90+85+75)/3 = 83.33, R3 = (70+88+100)/3 = 86.00. The highest single score is 100 (Sam, round 3).

**Tie rule:** "first one found" means scanning rows top to bottom in the **sorted** table, rounds left to right. Use `>` (not `>=`) when comparing, so a later tie doesn't replace the first one.

**Hints:**
- Suggested methods: `GetScores(string[] names, int[][] scores)`, `CalculateTotal(int[] row)`, `SortByTotal(...)`, `PrintTable(...)`, `PrintAnalysis(...)`. A helper like `AskInRange(string prompt, int low, int high, string errorMessage)` handles both the player count and each score.
- The header line can be built with the same widths: `$"{"Name",-10}{"R1",-5}{"R2",-5}{"R3",-5}{"Total",-7}Average"`.
- Do the analysis **after** sorting. Then the winner is simply row 0.
- For "best single round," keep two variables: the best row and the best column. Remember to print `round + 1` (rounds are numbered from 1 for people, from 0 in the array).

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step08`.
2. Put your whole Visual Studio project folder (`Step08`) in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 8 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run, including column spacing
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Names in a `string[]`, scores in an `int[][]` (one row per player)
- [ ] Bad scores re-ask the same round
- [ ] Your own sort swaps names and score rows together
- [ ] Methods for getting scores, total, sorting, printing the table, and analysis — each with a comment
- [ ] Pushed to `bpaPrep/csharp_step08`
