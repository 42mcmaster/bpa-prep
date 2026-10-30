# Step 08 — Nested Data (C++)

**What you'll build:** Team Scoreboard — a program that stores 3 round scores for each player in a table, sorts the players by total, and prints a formatted leaderboard with an analysis.
**Time:** about one and a half class periods (3 hours). This step is longer than most.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Rows and columns](#rows-and-columns)
- [A 2D array](#a-2d-array)
- [A vector of vectors](#a-vector-of-vectors)
- [Nested loops](#nested-loops)
- [Row totals and column averages](#row-totals-and-column-averages)
- [Parallel lists](#parallel-lists)
- [Sorting rows yourself: selection sort](#sorting-rows-yourself-selection-sort)
- [Changing data inside a function: references](#changing-data-inside-a-function-references)
- [Formatting a table with setw](#formatting-a-table-with-setw)
- [Finding the best cell and the best column](#finding-the-best-cell-and-the-best-column)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Team Scoreboard](#the-challenge-team-scoreboard)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to store a table of numbers: a 2D array `int sales[3][4]` and a `vector<vector<int>>`
- Nested loops: a loop inside a loop
- Totals across a row and averages down a column
- Keeping a list of names and a table of scores in sync ("parallel lists")
- How selection sort works, step by step, and how to swap two rows at once
- Passing vectors by reference (`&`) so a function can change them
- Printing neat columns with `setw`, `left`, `fixed`, and `setprecision`

---

## Rows and columns

Some data is a **table**: several things, each with several values. In this step, each **row** is a player and each **column** is a round.

```
            round 1  round 2  round 3
player 0      80       90       70
player 1      95       85       88
player 2      60       75      100
```

To get one value you need **two** index numbers: the row, then the column. `scores[1][2]` means row 1, column 2: the value 88. Both start at 0.

---

## A 2D array

When the number of rows and columns is fixed, a **2D array** works.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Processing: 3 stores (rows) x 4 days (columns) of sales
    const int STORES = 3;
    const int DAYS = 4;
    int sales[STORES][DAYS] = {
        { 12, 15, 9, 20 },   // store 0
        { 8, 11, 14, 10 },   // store 1
        { 17, 13, 16, 18 }   // store 2
    };

    // Output: one value - row first, then column
    cout << "Store 1, day 2: " << sales[1][2] << endl;

    // Processing: change one value
    sales[0][0] = 13;
    cout << "Store 0, day 0 is now: " << sales[0][0] << endl;
    return 0;
}
```

What it prints:
```
Store 1, day 2: 14
Store 0, day 0 is now: 13
```

`int sales[3][4]` makes 3 rows of 4 columns. Like a 1D array, the size is fixed and must be a constant. That is a problem for the challenge, where the user chooses 1 to 6 players. You could make `int scores[6][3]` (room for the most players) and only use the first rows, keeping the real count in a variable. That works, but a vector of vectors is cleaner.

---

## A vector of vectors

A **vector of vectors** is a vector where each item is itself a `vector<int>`: one inner vector per row. It can grow like any vector.

```cpp
#include <iostream>
#include <vector>
using namespace std;

int main()
{
    // Processing: start with an empty table
    vector<vector<int>> sales;

    // Processing: build each row as its own vector, then add the row
    vector<int> storeA = { 12, 15, 9, 20 };
    vector<int> storeB = { 8, 11, 14, 10 };
    sales.push_back(storeA);
    sales.push_back(storeB);

    // Output: sizes and one value
    cout << "Rows: " << sales.size() << endl;
    cout << "Columns in row 0: " << sales[0].size() << endl;
    cout << "Row 1, column 2: " << sales[1][2] << endl;
    return 0;
}
```

What it prints:
```
Rows: 2
Columns in row 0: 4
Row 1, column 2: 14
```

| What you type | What it means |
|---|---|
| `vector<vector<int>> table;` | A vector whose items are `vector<int>` rows |
| `table.push_back(row);` | Add a whole row |
| `table.size()` | Number of rows |
| `table[r].size()` | Number of columns in row `r` |
| `table[r]` | Row `r` (a whole `vector<int>`) |
| `table[r][c]` | One value: row `r`, column `c` |

---

## Nested loops

A **nested loop** is a loop inside a loop. The outer loop picks a row; the inner loop goes across that row's columns. The inner loop runs **all the way through** for each pass of the outer loop.

```cpp
#include <iostream>
#include <vector>
using namespace std;

int main()
{
    vector<vector<int>> sales = {
        { 12, 15, 9, 20 },
        { 8, 11, 14, 10 },
        { 17, 13, 16, 18 }
    };

    // Output: outer loop = rows (stores), inner loop = columns (days)
    for (size_t store = 0; store < sales.size(); store++)
    {
        cout << "Store " << store << ":";
        for (size_t day = 0; day < sales[store].size(); day++)
        {
            cout << " " << sales[store][day];
        }
        cout << endl;   // end the row after the inner loop finishes
    }
    return 0;
}
```

What it prints:
```
Store 0: 12 15 9 20
Store 1: 8 11 14 10
Store 2: 17 13 16 18
```

Name the counters after what they count (`store`, `day`, `player`, `round`) instead of `i` and `j`. With two loops it is easy to mix up `i` and `j`; with real names you can't.

### Filling a table from input

Build each row in the inner loop, then `push_back` the finished row in the outer loop:

```cpp
#include <iostream>
#include <vector>
using namespace std;

int main()
{
    // Input: 2 stores x 2 days of sales
    vector<vector<int>> sales;
    for (int store = 1; store <= 2; store++)
    {
        vector<int> row;   // a new, empty row for this store
        for (int day = 1; day <= 2; day++)
        {
            int amount = 0;
            cout << "Store " << store << ", day " << day << ": ";
            cin >> amount;
            row.push_back(amount);
        }
        sales.push_back(row);   // add the finished row to the table
    }

    // Output: confirm
    cout << "Last value entered: " << sales[1][1] << endl;
    return 0;
}
```

Sample run:
```
Store 1, day 1: 5
Store 1, day 2: 7
Store 2, day 1: 3
Store 2, day 2: 9
Last value entered: 9
```

The challenge uses this same shape, with a re-ask `while` loop (Step 4) inside the inner loop for the 0 to 100 check.

---

## Row totals and column averages

- A **row total** adds across one row. Loop over the columns of that row.
- A **column average** adds down one column. Loop over the rows, keeping the column fixed.

```cpp
#include <iostream>
#include <vector>
#include <iomanip>
using namespace std;

int main()
{
    vector<vector<int>> sales = {
        { 12, 15, 9, 20 },
        { 8, 11, 14, 10 },
        { 17, 13, 16, 18 }
    };

    // Processing + Output: total for each row (store)
    for (size_t store = 0; store < sales.size(); store++)
    {
        int rowTotal = 0;
        for (size_t day = 0; day < sales[store].size(); day++)
        {
            rowTotal = rowTotal + sales[store][day];
        }
        cout << "Store " << store << " total: " << rowTotal << endl;
    }

    // Processing + Output: average for each column (day) - outer loop is now the column
    cout << fixed << setprecision(2);
    for (size_t day = 0; day < 4; day++)
    {
        int columnTotal = 0;
        for (size_t store = 0; store < sales.size(); store++)
        {
            columnTotal = columnTotal + sales[store][day];
        }
        double average = static_cast<double>(columnTotal) / sales.size();
        cout << "Day " << day << " average: " << average << endl;
    }
    return 0;
}
```

What it prints:
```
Store 0 total: 56
Store 1 total: 43
Store 2 total: 64
Day 0 average: 12.33
Day 1 average: 13.00
Day 2 average: 13.00
Day 3 average: 16.00
```

For the column averages the loops **swap**: the outer loop is the column, the inner loop goes down the rows.

---

## Parallel lists

The scores table only holds numbers. The names go in a separate `vector<string>`. The two lists are **parallel**: position 0 in `names` is the player whose scores are in row 0 of `scores`, and so on.

```
names[0] = "Jordan"   <->   scores[0] = { 80, 90, 70 }
names[1] = "Taylor"   <->   scores[1] = { 95, 85, 88 }
names[2] = "Sam"      <->   scores[2] = { 60, 75, 100 }
```

The rule: **whatever you do to one list, do to the other.** If you sort the scores but not the names, Jordan gets Taylor's scores. Step 11 shows a cleaner way (a class that holds the name and the scores together), but parallel lists are common on BPA tests and graders understand them.

---

## Sorting rows yourself: selection sort

`sort` (Step 6) can't easily sort two parallel lists together. Writing the sort yourself solves that, and **graders like seeing the algorithm**. Selection sort is the easiest to understand.

**The idea:** for each position from the top, find the biggest remaining value and swap it into that position.

Example with totals `240, 268, 235`, sorting highest first:

| Pass | Position being filled | Search these | Biggest found | Swap | Result |
|---|---|---|---|---|---|
| 1 | 0 | 240, 268, 235 | 268 (index 1) | swap index 0 and 1 | 268, 240, 235 |
| 2 | 1 | 240, 235 | 240 (index 1) | already there, no swap | 268, 240, 235 |
| 3 | 2 | 235 | 235 | nothing to do | 268, 240, 235 |

Here it is on a simple vector, with a parallel list of names:

```cpp
#include <iostream>
#include <vector>
#include <string>
using namespace std;

int main()
{
    vector<string> stores = { "North", "South", "East" };
    vector<int> totals = { 56, 43, 64 };

    // Processing: selection sort, highest first
    for (size_t i = 0; i < totals.size(); i++)
    {
        // find the biggest value from position i to the end
        size_t biggest = i;
        for (size_t j = i + 1; j < totals.size(); j++)
        {
            if (totals[j] > totals[biggest])
            {
                biggest = j;
            }
        }

        // swap it into position i - in BOTH lists so they stay matched
        swap(totals[i], totals[biggest]);
        swap(stores[i], stores[biggest]);
    }

    // Output
    for (size_t i = 0; i < totals.size(); i++)
    {
        cout << stores[i] << " " << totals[i] << endl;
    }
    return 0;
}
```

What it prints:
```
East 64
North 56
South 43
```

| What you type | What it means |
|---|---|
| `swap(a, b);` | Trade the values of `a` and `b`. Works on ints, strings, and whole vector rows. |
| `swap(scores[i], scores[best]);` | Trade two entire rows of the scores table |

`swap` is in the standard library (it comes in with `<vector>` and `<string>`; `<utility>` is its official home). Without it, a swap needs a temporary variable:

```cpp
int temp = totals[i];
totals[i] = totals[biggest];
totals[biggest] = temp;
```

To sort **highest first**, use `>` when searching. For lowest first, use `<`.

In the challenge, the value being compared is each player's **total**, so the comparison is `calculateTotal(scores[j]) > calculateTotal(scores[best])`.

---

## Changing data inside a function: references

In Step 6 you passed vectors as `const vector<int>&` because the functions only read them. A sort function must **change** the caller's vectors, so drop the `const`:

```cpp
void sortByTotal(vector<string>& names, vector<vector<int>>& scores)
```

The `&` means the function works on `main`'s actual vectors (Step 5: passing by reference). Without the `&`, the function would sort **copies**, the copies would be thrown away when the function ends, and `main` would see no change at all. That bug produces **no error message**, only an unsorted table.

| Parameter | Use when |
|---|---|
| `const vector<int>& v` | The function only reads `v` (print, total, find) |
| `vector<int>& v` | The function must change the caller's `v` (sort, fill, add) |
| `vector<int> v` | The function wants its own copy to change (rare) |

A function can also **return** a whole vector. `vector<vector<int>> getScores(const vector<string>& names)` can build the table and return it: `vector<vector<int>> scores = getScores(names);`.

---

## Formatting a table with setw

`<iomanip>` has `setw` ("set width") to print each value in a column of a fixed width.

```cpp
#include <iostream>
#include <iomanip>
#include <string>
using namespace std;

int main()
{
    // Output: header row - each piece padded to its column width, left-aligned
    cout << left;
    cout << setw(8) << "Store" << setw(6) << "Day1" << setw(6) << "Day2" << "Avg" << endl;
    cout << string(23, '-') << endl;

    // Output: data rows
    cout << fixed << setprecision(2);
    cout << setw(8) << "North" << setw(6) << 12 << setw(6) << 15 << 13.5 << endl;
    cout << setw(8) << "East" << setw(6) << 117 << setw(6) << 9 << 63.0 << endl;
    return 0;
}
```

What it prints:
```
Store   Day1  Day2  Avg
-----------------------
North   12    15    13.50
East    117   9     63.00
```

| What you type | What it means |
|---|---|
| `setw(8)` | Print the **next** value using at least 8 characters, adding spaces to fill. Applies to **one** value only. |
| `left` | Put the padding spaces on the right (text lines up on the left). Stays on. |
| `right` | Padding on the left (numbers line up on the right). Stays on. This is the default. |
| `fixed << setprecision(2)` | 2 decimal places (Step 2). Stays on. |
| `string(39, '-')` | A string made of 39 dashes. Quicker than typing them. |

Rules to remember:
- `setw` must come **right before each value**. It resets after one value.
- If a value is longer than the width, it is printed in full and pushes the rest of the line over. Make columns wide enough.
- Leave the **last** column without `setw`, so there are no trailing spaces.

Python comparison: `f"{name:<10}"` is `left << setw(10) << name`.

In the challenge: Name 10 wide, R1/R2/R3 5 wide each, Total 7 wide, then Average.

---

## Finding the best cell and the best column

**Best single value in the whole table:** remember **two** index numbers, the row and the column of the best value so far.

```cpp
#include <iostream>
#include <vector>
using namespace std;

int main()
{
    vector<vector<int>> sales = {
        { 12, 15, 9, 20 },
        { 8, 11, 14, 10 },
        { 17, 13, 16, 20 }
    };

    // Processing: scan every cell, top to bottom, left to right
    size_t bestStore = 0;
    size_t bestDay = 0;
    for (size_t store = 0; store < sales.size(); store++)
    {
        for (size_t day = 0; day < sales[store].size(); day++)
        {
            if (sales[store][day] > sales[bestStore][bestDay])   // > keeps the FIRST one on a tie
            {
                bestStore = store;
                bestDay = day;
            }
        }
    }

    // Output: add 1 so people see day 1 instead of day 0
    cout << "Best: store " << bestStore << ", day " << (bestDay + 1)
         << " (" << sales[bestStore][bestDay] << ")" << endl;
    return 0;
}
```

What it prints:
```
Best: store 0, day 4 (20)
```

Store 2 also has a 20, but `>` (not `>=`) means a tie does not replace the first one found. The challenge uses the same rule: **first one found wins**, scanning the sorted table top to bottom and rounds left to right.

**Best column:** compute each column's average (the column loop from [Row totals and column averages](#row-totals-and-column-averages)) and keep the highest, the same way you found the highest score in Step 6.

**Showing numbers to people:** index numbers start at 0, but people count rounds from 1. Store the index, and print `index + 1`.

---

## Common mistakes

**1. Row and column swapped**
- Looks like: `scores[round][player]`
- Result: wrong numbers or a crash (`vector subscript out of range`).
- Fix: always `[row][column]`, which here is `[player][round]`.

**2. Sorting one parallel list but not the other**
- Result: names next to the wrong scores.
- Fix: every swap swaps both.

**3. Sort function without `&`**
- Result: no error, but the table is not sorted.
- Fix: `vector<string>& names, vector<vector<int>>& scores`.

**4. `setw` only on the first value**
- Result: columns run together, like `Taylor    958588`.
- Fix: `setw` before each value.

**5. Re-ask loop asks the wrong round**
- Looks like: after `Score must be 0 to 100.`, it moves on to the next round.
- Fix: re-ask in a `while` loop **inside** the round loop, before `push_back`.

**6. `getline` skipped for the first name**
- Looks like: `Player 1 name: Player 2 name:` on one line.
- Fix: `cin.ignore(1000, '\n');` after reading the number of players (Step 7).

**7. Integer division in the averages**
- Fix: `static_cast<double>(total) / ROUNDS`.

---

## How this shows up at BPA

- The 2026 regional displayed CSV data "in a neatly aligned table with headers." Column formatting with `setw` is how you do that in C++, and it carried 40 execution points plus 50 code review points.
- The 2024 rubric gave 40 points for "Output is coded correctly to maintain the four columns."
- Graders award points for algorithms they can see: a sort you wrote, a nested loop that finds a maximum.
- Data structures are a graded item. A 2D vector with parallel names is a reasonable, clear choice. Name things clearly.

---

## The challenge: Team Scoreboard

Write a program that records 3 round scores for each player and prints a sorted leaderboard and analysis.

**Requirements**
1. Header comment.
2. Ask `How many players? ` (1 to 6; if outside print `Please enter 1 to 6.` and ask again).
3. Ask each player's name: `Player 1 name: `, …
4. For each player, ask 3 round scores: `<name>, round 1 score: ` … Scores must be 0 to 100; if not, print `Score must be 0 to 100.` and ask that same round again.
5. Store names in a list/array and scores in a 2D structure (one row per player, one column per round).
6. Print a leaderboard sorted by total, highest first, in the exact column format below: Name (10 wide, left), R1, R2, R3 (5 wide each, left), Total (7 wide, left), Average (2 decimals). A line of 39 dashes under the header.
7. Print the winner (highest total), the best single round (player, round number, score), and the highest scoring round (round with the highest average across all players, 2 decimals). If there's a tie, the first one found wins.
8. Use functions for: getting scores, calculating a player's total, sorting, printing the table, and the analysis. Function comments and Input / Processing / Output comments.

(In C++: names in a `vector<string>`, scores in a `vector<vector<int>>`.)

**Sample run (exact)**
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
Check: round averages R1 = (80+95+60)/3 = 78.33, R2 = (90+85+75)/3 = 83.33, R3 = (70+88+100)/3 = 86.00.
Tie rule: "first one found" means scanning rows top to bottom in the **sorted** table, rounds left to right.

**Hints**
- Put `const int ROUNDS = 3;` above `main`.
- Suggested functions:
  - `vector<vector<int>> getScores(const vector<string>& names)`
  - `int calculateTotal(const vector<int>& playerScores)`
  - `void sortByTotal(vector<string>& names, vector<vector<int>>& scores)`
  - `void printTable(const vector<string>& names, const vector<vector<int>>& scores)`
  - `void printAnalysis(const vector<string>& names, const vector<vector<int>>& scores)`
- Sort **before** you print the table and the analysis. Then the winner is simply row 0.
- Read names with `getline` (after `cin.ignore`), so a name like `Mary Kate` works.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step08`.
2. Put `step08.cpp` in it. (Visual Studio: push the whole project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 8 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run, including column spacing
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Names in a `vector<string>`, scores in a `vector<vector<int>>`
- [ ] Bad scores re-ask the same round
- [ ] Your own sort (selection sort) that swaps names and score rows together
- [ ] Functions for getting scores, total, sort, table, and analysis, each with a comment block
- [ ] Pushed to `bpaPrep/cpp_step08`
