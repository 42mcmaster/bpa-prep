# Step 08 — Nested Data: 2D Arrays (Java)

**What you'll build:** Team Scoreboard — collect 3 round scores for each player and print a sorted leaderboard table with analysis.
**Time:** about one and a half class periods (2-3 hours). This step is longer than most.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Rows and columns](#rows-and-columns)
- [Creating a 2D array](#creating-a-2d-array)
- [Nested loops](#nested-loops)
- [Row totals](#row-totals)
- [Column averages](#column-averages)
- [Parallel arrays: names and scores](#parallel-arrays-names-and-scores)
- [Sorting by hand: selection sort](#sorting-by-hand-selection-sort)
- [Formatting a table in columns](#formatting-a-table-in-columns)
- [Finding the best item in a 2D array](#finding-the-best-item-in-a-2d-array)
- [Other ways to store nested data](#other-ways-to-store-nested-data)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Team Scoreboard](#the-challenge-team-scoreboard)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- 2D arrays (`int[][]`): a grid of rows and columns
- Nested loops to fill and read a grid
- Row totals and column averages
- Keeping a `names` array and a `scores` grid in sync (parallel arrays)
- Writing a selection sort that swaps both the name and the score row
- Printing a table in fixed-width columns with `printf` / `String.format` (`%-10s`, `%-5d`)
- Finding the best value in a grid, with a clear tie rule

---

## Rows and columns

Some data is a table. Here is how many hours three workers volunteered on three days:

|        | Day 1 | Day 2 | Day 3 |
|--------|-------|-------|-------|
| Avery  | 2     | 3     | 1     |
| Blake  | 4     | 0     | 2     |
| Casey  | 1     | 5     | 3     |

A **2D array** stores a grid like this. Each **row** is one worker; each **column** is one day. You find a value by giving its row and its column: the hours for Blake (row 1) on Day 3 (column 2) is `hours[1][2]`, which is 2.

Remember indexes start at 0, so "Day 1" is column 0 and "Avery" is row 0.

---

## Creating a 2D array

```java
int[][] hours = new int[3][3];      // 3 rows, 3 columns, all 0
hours[1][2] = 2;                    // row 1, column 2

int[][] filled = {                  // create and fill in one step
    {2, 3, 1},                      // row 0
    {4, 0, 2},                      // row 1
    {1, 5, 3}                       // row 2
};
```

| What you type | What it means |
|---|---|
| `int[][]` | An array of arrays of `int` - a grid. |
| `new int[rows][cols]` | Make a grid with that many rows and columns. |
| `grid[r][c]` | The value in row `r`, column `c`. **Row first, then column.** |
| `grid.length` | The number of **rows**. |
| `grid[0].length` | The number of **columns** (the length of row 0). |
| `grid[r]` | The whole row `r`, as a 1D `int[]` array. |

That last line is important: in Java a 2D array really **is** an array of rows. `filled[1]` is the array `{4, 0, 2}`. You can pass one row to a method that takes an `int[]`, and you can swap whole rows (which makes sorting easy).

---

## Nested loops

To visit every cell, use a loop inside a loop. The **outer loop** goes through the rows; the **inner loop** goes through the columns in that row.

```java
public class VolunteerHours {
    public static void main(String[] args) {
        int[][] hours = {
            {2, 3, 1},
            {4, 0, 2},
            {1, 5, 3}
        };

        // Output: outer loop = rows, inner loop = columns
        for (int row = 0; row < hours.length; row++) {
            System.out.print("Worker " + (row + 1) + ":");
            for (int col = 0; col < hours[row].length; col++) {
                System.out.print(" " + hours[row][col]);
            }
            System.out.println();   // end of this row
        }
    }
}
```

Output:

```
Worker 1: 2 3 1
Worker 2: 4 0 2
Worker 3: 1 5 3
```

The inner loop runs all the way through for **each** pass of the outer loop. With 3 rows and 3 columns, the inner body runs 3 × 3 = 9 times.

**Filling a grid from input** uses the same nested loops, with a prompt inside:

```java
for (int row = 0; row < 2; row++) {
    for (int col = 0; col < 3; col++) {
        System.out.print("Row " + (row + 1) + ", seat " + (col + 1) + ": ");
        grid[row][col] = Integer.parseInt(keyboard.nextLine());
    }
}
```

The prompts come out in order: row 1 seat 1, row 1 seat 2, row 1 seat 3, row 2 seat 1...

---

## Row totals

A row total adds up one row. Write it as a method that takes **one row** (an `int[]`). This is the Step 6 running-total loop:

```java
/*
 * Purpose: add up the values in one row.
 * Parameters: row - one row of the grid
 * Returns: the total
 */
static int rowTotal(int[] row) {
    int total = 0;
    for (int value : row) {
        total += value;
    }
    return total;
}
```

Call it with one row: `rowTotal(hours[2])` gives 1 + 5 + 3 = 9.

---

## Column averages

To total a **column**, swap the loops: the **outer** loop goes through the columns and the **inner** loop goes down the rows.

```java
// Processing: average hours for each day (column)
for (int col = 0; col < 3; col++) {
    int columnTotal = 0;
    for (int row = 0; row < hours.length; row++) {
        columnTotal += hours[row][col];
    }
    double average = (double) columnTotal / hours.length;
    System.out.printf("Day %d average: %.2f%n", col + 1, average);
}
```

Output:

```
Day 1 average: 2.33
Day 2 average: 2.67
Day 3 average: 2.00
```

Day 1 is (2 + 4 + 1) / 3 = 2.33.

---

## Parallel arrays: names and scores

The 2D array only holds numbers. The names go in a separate `String[]` array. **Row `i` of the grid belongs to `names[i]`.** Two arrays used together like this are called **parallel arrays**.

```java
String[] names = {"Avery", "Blake", "Casey"};
int[][] hours = { {2, 3, 1}, {4, 0, 2}, {1, 5, 3} };
// names[1] is "Blake" and hours[1] is Blake's row
```

The rule: **whenever you move a name, move its row the same way.** If you sort the names but not the rows, every player ends up with someone else's scores.

---

## Sorting by hand: selection sort

In Step 6 you used `Collections.sort`. Here you need to sort **two** arrays together by a calculated value (the row total), so you write the sort yourself. Graders like seeing the algorithm.

**Selection sort, highest first:**
1. Look at position 0. Find the **biggest** item from position 0 to the end. Swap it into position 0.
2. Look at position 1. Find the biggest from position 1 to the end. Swap it into position 1.
3. Keep going until the second-to-last position. The last one is then already in place.

Example, sorting the totals `[5, 9, 7]`:

```
Start:            [5, 9, 7]
Position 0: biggest from 0 to end is 9 (index 1). Swap index 0 and 1 -> [9, 5, 7]
Position 1: biggest from 1 to end is 7 (index 2). Swap index 1 and 2 -> [9, 7, 5]
Done.
```

**Swapping** two values needs a temporary variable, because the moment you overwrite one, its old value is gone:

```java
String temp = names[0];   // 1. save the first
names[0] = names[1];      // 2. copy the second into the first
names[1] = temp;          // 3. put the saved one into the second
```

Here is a complete program that sorts parallel arrays by price, highest first:

```java
public class SortParallel {

    /*
     * Purpose: sort items by price, highest first, keeping names and prices together.
     * Parameters: names - item names; prices - item prices (both are changed in place)
     * Returns: nothing (void)
     */
    static void sortByPrice(String[] names, double[] prices) {
        for (int i = 0; i < names.length - 1; i++) {
            // Processing: find the index of the highest price from i to the end
            int maxIndex = i;
            for (int j = i + 1; j < names.length; j++) {
                if (prices[j] > prices[maxIndex]) {
                    maxIndex = j;
                }
            }
            // Processing: swap position i and maxIndex in BOTH arrays
            String tempName = names[i];
            names[i] = names[maxIndex];
            names[maxIndex] = tempName;

            double tempPrice = prices[i];
            prices[i] = prices[maxIndex];
            prices[maxIndex] = tempPrice;
        }
    }

    public static void main(String[] args) {
        String[] names = {"Pencil", "Backpack", "Binder", "Calculator"};
        double[] prices = {0.99, 34.50, 4.25, 18.00};

        sortByPrice(names, prices);

        // Output
        for (int i = 0; i < names.length; i++) {
            System.out.printf("%-12s$%.2f%n", names[i], prices[i]);
        }
    }
}
```

Output:

```
Backpack    $34.50
Calculator  $18.00
Binder      $4.25
Pencil      $0.99
```

For the challenge, compare **row totals** instead of prices, and swap the **whole row** of the 2D array. Because each row is an `int[]`, swapping rows is the same three lines:

```java
int[] tempRow = scores[i];
scores[i] = scores[maxIndex];
scores[maxIndex] = tempRow;
```

Notice the `if` uses `>` (strictly greater). When two totals are equal, the one that came first stays first.

Methods that receive an array can change it, and the caller sees the change (Step 6). So `sortByPrice` doesn't need to return anything.

---

## Formatting a table in columns

To line up columns, give each value a **width**. `printf` and `String.format` pad the value with spaces to fill the width.

| Placeholder | Meaning | `"Sam"` or `75` becomes |
|---|---|---|
| `%-10s` | String, 10 wide, **left**-aligned (the `-` means left) | `"Sam       "` (Sam + 7 spaces) |
| `%10s` | String, 10 wide, right-aligned | `"       Sam"` |
| `%-5d` | int, 5 wide, left | `"75   "` |
| `%5d` | int, 5 wide, right | `"   75"` |
| `%-7.2f` | double, 7 wide, left, 2 decimals | `"78.33  "` |
| `%8.2f` | double, 8 wide, right, 2 decimals | `"   78.33"` |

If the value is longer than the width, it is **not** cut off - it just pushes the columns over. Pick widths bigger than your longest value.

```java
public class ShowTable {
    public static void main(String[] args) {
        // Output: header row, a line of dashes, then data rows
        System.out.printf("%-10s%-6s%s%n", "Class", "Room", "Teacher");
        System.out.println("-".repeat(24));
        System.out.printf("%-10s%-6d%s%n", "Java", 112, "Moore");
        System.out.printf("%-10s%-6d%s%n", "Web", 204, "Tanski");
    }
}
```

Output:

```
Class     Room  Teacher
------------------------
Java      112   Moore
Web       204   Tanski
```

`"-".repeat(24)` makes a String of 24 dashes (Java 11 and newer). It is easier than counting dashes in quotes.

For the challenge's header row, every column title is a String, so use `%-5s` for "R1" and `%-7s` for "Total" - same widths as the numbers in the rows below.

---

## Finding the best item in a 2D array

To find the single highest value in a grid, use nested loops and remember **where** you found it (row and column), not just the value:

```java
int best = hours[0][0];
int bestRow = 0;
int bestCol = 0;
for (int row = 0; row < hours.length; row++) {
    for (int col = 0; col < hours[row].length; col++) {
        if (hours[row][col] > best) {      // > means ties keep the first one found
            best = hours[row][col];
            bestRow = row;
            bestCol = col;
        }
    }
}
System.out.println("Most hours: " + names[bestRow] + " on day " + (bestCol + 1) + " (" + best + ")");
```

With the volunteer data, this prints `Most hours: Casey on day 2 (5)`.

**Tie rule for the challenge:** "first one found" means scanning rows top to bottom in the **sorted** table, and columns left to right. Using `>` (not `>=`) gives exactly that.

**Try it:**
1. Using the volunteer grid, print each worker's total with `rowTotal`.
2. Find which day had the **lowest** average.

---

## Other ways to store nested data

You will see these in other programs. You don't need them for the challenge.

- **`ArrayList<int[]>`** - a growable list where each item is one row. Useful when you don't know how many rows there will be: `rows.add(new int[]{80, 90, 70});` and `rows.get(0)[1]` is 90.
- **Jagged arrays** - rows can have different lengths: `int[][] j = new int[3][];` then `j[0] = new int[2];` and so on.
- **A list of objects** - a `Player` class with a name and a score array, stored in an `ArrayList<Player>`. That keeps the name and scores together automatically, so they can't get out of sync. Step 11 teaches classes.

---

## Common mistakes

**1. Row and column swapped**
- Looks like: `scores[col][row]`
- Error (sometimes): `ArrayIndexOutOfBoundsException`, or wrong numbers in the wrong places.
- Fix: always **row first**, then column.

**2. Inner loop uses the wrong length**
- Looks like: `for (int col = 0; col < scores.length; col++)` - that is the number of **rows**.
- Fix: `col < scores[row].length` (or a constant like `ROUNDS`).

**3. Sorting names but not scores**
- Looks like: Taylor shows Jordan's scores.
- Fix: every swap swaps both `names` and `scores` rows.

**4. Forgetting the temporary variable in a swap**
- Looks like: `names[i] = names[maxIndex]; names[maxIndex] = names[i];` - both end up the same name.
- Fix: save one in a `temp` first.

**5. Missing `%n` in `printf`**
- Looks like: the whole table comes out on one line.
- Fix: end each row's format string with `%n`.

**6. Columns don't line up**
- Looks like: `Sam 60 75 100 235 78.33` instead of the spaced-out table.
- Fix: use `%-10s` for the name, `%-5d` for each round, `%-7d` for the total, `%.2f` for the average. Header uses the same widths.

**7. Validation re-asks the wrong question**
- Looks like: after `Score must be 0 to 100.` the program moves on to the next round, or asks for round 1 again.
- Fix: put the "ask again" `while` loop **inside** the inner loop, around just that one score.

---

## How this shows up at BPA

- The 2026 Python regional (same skills as Java) had players in a list, scores in a nested structure, and a leaderboard with totals and averages in columns. That is this challenge.
- "Formatted in columns" with exact widths is graded on the output. `printf` with `%-10s` is the tool.
- Graders award points for data structures (2D array, parallel arrays) and algorithms (a sort you wrote, a max search). Comment them clearly.
- Clear tie rules matter when graders run test data.

---

## The challenge: Team Scoreboard

Write a program that collects 3 round scores for each player and prints a sorted leaderboard.

**Requirements**
1. Header comment.
2. Ask `How many players? ` (1 to 6; if outside print `Please enter 1 to 6.` and ask again).
3. Ask each player's name: `Player 1 name: `, …
4. For each player, ask 3 round scores: `<name>, round 1 score: ` … Scores must be 0 to 100; if not, print `Score must be 0 to 100.` and ask that same round again.
5. Store names in a list/array and scores in a 2D structure (one row per player, one column per round). (In Java: a `String[]` and an `int[][]`.)
6. Print a leaderboard sorted by total, highest first, in the exact column format below: Name (10 wide, left), R1, R2, R3 (5 wide each, left), Total (7 wide, left), Average (2 decimals). A line of 39 dashes under the header.
7. Print the winner (highest total), the best single round (player, round number, score), and the highest scoring round (round with the highest average across all players, 2 decimals). If there's a tie, the first one found wins.
8. Use methods for: getting scores, calculating a player's total, sorting, printing the table, and the analysis. Method comments and Input / Processing / Output comments.

**Sample run (exact):**
```
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

Tie rule: "first one found" means scanning rows top to bottom in the **sorted** table, rounds left to right.

**Hints**
- Class `Step08` in `Step08.java`. Add `static final int ROUNDS = 3;` at the class level.
- Suggested method headers:
  - `static int[][] getScores(String[] names)` - makes the grid, fills it with nested loops, returns it
  - `static int calculateTotal(int[] playerScores)` - one row in, total out
  - `static void sortByTotal(String[] names, int[][] scores)` - selection sort, swaps both
  - `static void printTable(String[] names, int[][] scores)`
  - `static void printAnalysis(String[] names, int[][] scores)`
- Row format: `"%-10s%-5d%-5d%-5d%-7d%.2f%n"`. Header format: `"%-10s%-5s%-5s%-5s%-7s%s%n"`.
- After sorting, the winner is simply row 0.
- Average for a player is `(double) total / ROUNDS`.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step08`.
2. Put `Step08.java` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 8 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Names in a `String[]`, scores in an `int[][]`
- [ ] Bad scores re-ask the same round
- [ ] Your own selection sort swaps both the name and the score row
- [ ] Table columns line up exactly (10 / 5 / 5 / 5 / 7) with 39 dashes
- [ ] Methods for getting scores, total, sorting, table, and analysis - each with a purpose / parameters / returns comment
- [ ] Pushed to `bpaPrep/java_step08`
