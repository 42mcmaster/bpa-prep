# Step 08 — Nested Data (Python)

**What you'll build:** Team Scoreboard — collect 3 round scores for each player, then print a sorted leaderboard and an analysis.
**Time:** about two class periods. This step is the closest one yet to a real BPA regional.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [A list of lists](#a-list-of-lists)
- [Reading one value from a row and column](#reading-one-value-from-a-row-and-column)
- [Nested loops](#nested-loops)
- [Building a list of lists from input](#building-a-list-of-lists-from-input)
- [Row totals and column averages](#row-totals-and-column-averages)
- [Parallel lists](#parallel-lists)
- [Dictionaries (another way)](#dictionaries-another-way)
- [Writing your own sort](#writing-your-own-sort)
- [Formatting a table in columns](#formatting-a-table-in-columns)
- [Finding the best value in a table](#finding-the-best-value-in-a-table)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Team Scoreboard](#the-challenge-team-scoreboard)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to store a table of data as a **list of lists** (rows and columns)
- How to read and change one value with `table[row][column]`
- How to use a loop inside a loop (nested loops)
- How to add up a row and average a column
- How to keep a list of names and a table of scores matched up (parallel lists)
- What a dictionary is, as another way to store the same data
- How to write a bubble sort that keeps two lists in sync
- How to print a table in fixed-width columns with f-strings
- How to find the best value in a table and remember where it was

## A list of lists

In Step 6, a list held numbers. A list can also hold **other lists**. That gives you a table: each inner list is one **row**.

Say three students logged the pages they read each week for four weeks:

```python
# Processing: one row per student, one column per week
pages = [
    [30, 45, 20, 50],     # row 0 - Avery
    [60, 10, 35, 40],     # row 1 - Blake
    [25, 25, 30, 25],     # row 2 - Casey
]

print(pages[1])           # the whole second row
print(len(pages))         # number of rows
print(len(pages[0]))      # number of columns in row 0
```

It prints:

```text
[60, 10, 35, 40]
3
4
```

Picture it as a grid:

|  | week 1 (col 0) | week 2 (col 1) | week 3 (col 2) | week 4 (col 3) |
|---|---|---|---|---|
| **row 0** | 30 | 45 | 20 | 50 |
| **row 1** | 60 | 10 | 35 | 40 |
| **row 2** | 25 | 25 | 30 | 25 |

Other languages call this a **2D array** (C++ `int pages[3][4]`, Java `int[][]`, C# `int[,]`).

## Reading one value from a row and column

Use two indexes: **row first, then column**.

```python
pages = [
    [30, 45, 20, 50],
    [60, 10, 35, 40],
    [25, 25, 30, 25],
]
print(pages[1][0])        # row 1, column 0
print(pages[2][3])        # row 2, column 3

# Processing: change one value
pages[0][2] = 22
print(pages[0])
```

It prints:

```text
60
25
[30, 45, 22, 50]
```

Read `pages[1][0]` in two steps: `pages[1]` is the row `[60, 10, 35, 40]`, and `[0]` of that row is `60`.

## Nested loops

To visit every value in a table, put a loop inside a loop. The **outer** loop goes through the rows. The **inner** loop goes through the columns of the current row.

```python
pages = [
    [30, 45, 20, 50],
    [60, 10, 35, 40],
    [25, 25, 30, 25],
]
# Output: every value, one row per line
for row in range(len(pages)):
    for col in range(len(pages[row])):
        print(pages[row][col], end=" ")
    print()     # end of the row - go to a new line
```

It prints:

```text
30 45 20 50 
60 10 35 40 
25 25 30 25 
```

The inner loop runs **all the way through** for each pass of the outer loop. 3 rows × 4 columns = 12 values printed.

You can also use for-each loops when you don't need the index numbers:

```python
pages = [[30, 45], [60, 10]]
for row in pages:          # each row is a list
    for value in row:      # each value in that row
        print(value, end=" ")
    print()
```

It prints:

```text
30 45 
60 10 
```

## Building a list of lists from input

Build each row as its own list, then append the finished row to the table:

<!-- input: 2|7|9|6|8 -->
```python
NUM_DAYS = 2

# Input: how many workers, then hours for each day
workers = int(input("Workers: "))
hours = []                         # the whole table
for worker in range(1, workers + 1):
    row = []                       # a NEW empty row for each worker
    for day in range(1, NUM_DAYS + 1):
        row.append(int(input(f"Worker {worker}, day {day}: ")))
    hours.append(row)              # add the finished row to the table

# Output
print(hours)
```

It prints (user typed `2`, then `7`, `9`, `6`, `8`):

```text
Workers: 2
Worker 1, day 1: 7
Worker 1, day 2: 9
Worker 2, day 1: 6
Worker 2, day 2: 8
[[7, 9], [6, 8]]
```

`row = []` must be **inside** the outer loop. If it's above the loop, every worker's hours go into the same row.

## Row totals and column averages

A **row total** adds across one row (one student's pages for all weeks). A **column average** adds down one column (all students' pages for one week) and divides by the number of rows.

```python
pages = [
    [30, 45, 20, 50],
    [60, 10, 35, 40],
    [25, 25, 30, 25],
]

def row_total(row):
    """Purpose: add up one row.
    Parameters: row (list of int)
    Returns: the total (int)
    """
    total = 0
    for value in row:
        total = total + value
    return total

def column_average(table, col):
    """Purpose: average one column of a table.
    Parameters: table (list of lists of int), col (int) - column index
    Returns: the average (float)
    """
    total = 0
    for row in table:              # go DOWN the rows...
        total = total + row[col]   # ...taking the same column each time
    return total / len(table)

# Output
print(row_total(pages[0]))
print(f"{column_average(pages, 1):.2f}")
```

It prints:

```text
145
26.67
```

Check by hand: row 0 is 30 + 45 + 20 + 50 = 145. Column 1 is (45 + 10 + 25) / 3 = 26.67.

**Try it**
1. Print the total for every row with a loop.
2. Print the average of every column with a loop. Which week had the most reading?

## Parallel lists

The names aren't in the number table. A common way to connect them is **parallel lists**: two lists where the **same index** means the same person.

```python
names = ["Avery", "Blake", "Casey"]
pages = [
    [30, 45, 20, 50],
    [60, 10, 35, 40],
    [25, 25, 30, 25],
]
# Output: index i in names goes with row i in pages
for i in range(len(names)):
    total = 0
    for value in pages[i]:
        total = total + value
    print(f"{names[i]} read {total} pages")
```

It prints:

```text
Avery read 145 pages
Blake read 145 pages
Casey read 105 pages
```

The rule with parallel lists: **anything you do to one list, you do to the other.** If you sort the scores but not the names, every name ends up next to someone else's scores. The sort below swaps both.

## Dictionaries (another way)

A **dictionary** stores **key → value** pairs. The key is how you look a value up — like a name in a phone book. You can store the same data as `{name: [scores]}`:

```python
# Processing: each name (key) holds a list of pages (value)
reading = {
    "Avery": [30, 45, 20, 50],
    "Blake": [60, 10, 35, 40],
}
reading["Casey"] = [25, 25, 30, 25]    # add a new key

print(reading["Blake"])                # look up by name
print(reading["Blake"][0])             # first week for Blake
for name in reading:                   # a loop gives the keys
    print(name, reading[name])
```

It prints:

```text
[60, 10, 35, 40]
60
Avery [30, 45, 20, 50]
Blake [60, 10, 35, 40]
Casey [25, 25, 30, 25]
```

| What you type | What it means |
|---|---|
| `{}` | an empty dictionary |
| `data["key"] = value` | add or replace a value |
| `data["key"]` | look up a value (crashes with `KeyError` if the key isn't there) |
| `"key" in data` | True if the key exists |
| `for key in data:` | loop over the keys |

Dictionaries are handy, and the existing timed build QuizTracker uses one. **The challenge uses parallel lists** (`names` + a list of lists), because that's the same in every language and it's what you need to write your own sort.

## Writing your own sort

In Step 6 you used `sort()`. Here you'll write a sort yourself. Graders like seeing the algorithm, and you need it to move the **names and the score rows together**.

**Bubble sort** idea (for high-to-low):
1. Compare the first two items. If the first is **smaller** than the second, swap them.
2. Move one step right and compare the next pair. Keep going to the end. After this pass, the smallest item has "bubbled" to the last spot.
3. Do another pass, but stop one spot earlier (the last spot is done).
4. After `count - 1` passes, the list is sorted.

**Swapping two values** needs a temporary variable — otherwise the first value is lost:

```python
a = "first"
b = "second"
temp = a      # save a
a = b         # overwrite a
b = temp      # put the saved value in b
print(a, b)
```

It prints:

```text
second first
```

Here's a bubble sort on parallel lists of names and **single** numbers. In the challenge you'll compare the **totals** of score rows instead of single numbers, and swap whole rows.

```python
def sort_high_to_low(names, values):
    """Purpose: bubble sort two parallel lists by values, highest first.
             Every swap is done in BOTH lists so they stay matched.
    Parameters: names (list of str), values (list of int)
    Returns: nothing - the lists are changed in place
    """
    count = len(values)
    for pass_number in range(count - 1):
        # each pass can stop one spot earlier than the last
        for i in range(count - 1 - pass_number):
            if values[i] < values[i + 1]:
                # swap the values
                temp = values[i]
                values[i] = values[i + 1]
                values[i + 1] = temp
                # swap the names the SAME way
                temp = names[i]
                names[i] = names[i + 1]
                names[i + 1] = temp

players = ["Avery", "Blake", "Casey", "Devon"]
points = [12, 30, 7, 18]
sort_high_to_low(players, points)
print(players)
print(points)
```

It prints:

```text
['Blake', 'Devon', 'Avery', 'Casey']
[30, 18, 12, 7]
```

Trace the first pass on `[12, 30, 7, 18]`:
- i=0: 12 < 30 → swap → `[30, 12, 7, 18]`
- i=1: 12 < 7? no → `[30, 12, 7, 18]`
- i=2: 7 < 18 → swap → `[30, 12, 18, 7]` — the smallest (7) is now last

Second pass (stops before the last spot): 30 < 12? no; 12 < 18 → swap → `[30, 18, 12, 7]`. Third pass: no swaps. Done.

Because it uses `<` (not `<=`), two equal values are never swapped, so ties stay in the order they were entered.

Python can swap in one line: `a, b = b, a`. Either way is fine. The temp-variable way is what C++, Java, and C# use, so graders recognize it everywhere.

## Formatting a table in columns

To line up columns, give each value a **fixed width** in the f-string. Text shorter than the width is padded with spaces.

| What you type | Means | `"Avery"` / `95` becomes |
|---|---|---|
| `{name:<10}` | left-aligned in 10 spaces | `"Avery     "` |
| `{name:>10}` | right-aligned in 10 spaces | `"     Avery"` |
| `{name:^10}` | centered in 10 spaces | `"  Avery   "` |
| `{score:<5}` | number, left-aligned in 5 | `"95   "` |
| `{average:<8.2f}` | 2 decimals, left-aligned in 8 | `"89.33   "` |
| `{'Name':<10}` | a fixed word, padded the same way | `"Name      "` |

Using the **same widths** for the header and for every row is what makes the columns line up.

```python
names = ["Avery", "Blake"]
laps = [[4, 6], [5, 5]]

# Output: header, a line of dashes, then the rows
print(f"{'Runner':<8}{'Day1':<6}{'Day2':<6}Avg")
print("-" * 23)
for i in range(len(names)):
    avg = (laps[i][0] + laps[i][1]) / 2
    print(f"{names[i]:<8}{laps[i][0]:<6}{laps[i][1]:<6}{avg:.2f}")
```

It prints:

```text
Runner  Day1  Day2  Avg
-----------------------
Avery   4     6     5.00
Blake   5     5     5.00
```

How to work out the widths from a sample: in the challenge header `Name      R1   R2   R3   Total  Average`, `Name` plus its spaces takes 10 characters, each `R` column takes 5, and `Total` plus 2 spaces takes 7. The last column has no width — it's the end of the line. The spec lists the widths for you.

If a name is **longer** than the width, Python doesn't cut it; it pushes the rest of the row over. BPA tests use short names.

## Finding the best value in a table

In Step 6 you kept the **index** of the best item. In a table, keep **both** indexes — the row and the column.

```python
names = ["Avery", "Blake", "Casey"]
pages = [
    [30, 45, 20, 50],
    [60, 10, 35, 40],
    [25, 25, 30, 25],
]
# Processing: best so far starts at row 0, column 0
best_row = 0
best_col = 0
for row in range(len(pages)):
    for col in range(len(pages[row])):
        if pages[row][col] > pages[best_row][best_col]:
            best_row = row
            best_col = col

# Output: +1 so "column 0" shows as "week 1"
print(f"Most in one week: {names[best_row]}, week {best_col + 1} ({pages[best_row][best_col]})")
```

It prints:

```text
Most in one week: Blake, week 1 (60)
```

**Ties: first one found wins.** Using `>` (not `>=`) means a later value that only **equals** the best doesn't replace it. Since the loops go row by row, top to bottom, and left to right in each row, the first one found is the top-most, left-most one. The challenge uses this rule, scanning the table **after it's sorted**.

For "which column has the highest average," loop over the columns, use a `column_average` like the one above, and keep the best column the same way.

## Common mistakes

**1. Row and column swapped**
`scores[round][player]` instead of `scores[player][round]` — wrong numbers or `IndexError: list index out of range`. Rule: **row first**. In this step, rows are players.

**2. Creating the row outside the loop**
```python
row = []                  # MISTAKE - only one row for everyone
for name in names:
    for r in range(3):
        row.append(int(input("Score: ")))
    scores.append(row)
```
Result: every player shares one 9-score row. Fix: `row = []` goes inside the outer loop.

**3. Sorting only one of the parallel lists**
No error — names end up next to the wrong scores. Every swap must happen in both lists.

**4. Swapping without a temp variable**
```python
names[i] = names[i + 1]
names[i + 1] = names[i]   # MISTAKE - both are now the same name
```
Fix: save one value in `temp` first.

**5. Column widths that don't match the header**
The header uses `{'R1':<5}` but rows use `{row[0]:<4}`. The table looks crooked. Use the same widths in both.

**6. Re-asking the wrong thing after a bad score**
After `Score must be 0 to 100.`, ask for **the same round** again, not the next round. The `while` loop for the range check goes **inside** the round loop (or in a `get_score` function).

**7. Off-by-one in the output**
Rounds are stored at index 0, 1, 2 but shown as round 1, 2, 3. Add 1 when you print.

## How this shows up at BPA
- The 2026 regional: "Store the results in a **nested structure** (e.g., dictionary or list of lists)." This step is that requirement.
- That test's leaderboard showed name, total, and average in aligned columns, and the analysis asked for the winner and the hole with the highest average — a row total and a column average.
- "Use functions for each major analysis component" — one function per analysis job, each with its comment.
- Writing the sort yourself is the kind of "method algorithm" listed in BPA source code review.

## The challenge: Team Scoreboard

Collect scores for up to 6 players over 3 rounds, then print a sorted leaderboard and an analysis.

**Requirements**
1. Header comment.
2. Ask `How many players? ` (1 to 6; if outside print `Please enter 1 to 6.` and ask again).
3. Ask each player's name: `Player 1 name: `, …
4. For each player, ask 3 round scores: `<name>, round 1 score: ` … Scores must be 0 to 100; if not, print `Score must be 0 to 100.` and ask that same round again.
5. Store names in a list and scores in a 2D structure (one row per player, one column per round).
6. Print a leaderboard sorted by total, highest first, in the exact column format below: Name (10 wide, left), R1, R2, R3 (5 wide each, left), Total (7 wide, left), Average (2 decimals). A line of 39 dashes under the header.
7. Print the winner (highest total), the best single round (player, round number, score), and the highest scoring round (round with the highest average across all players, 2 decimals). If there's a tie, the first one found wins.
8. Use functions for: getting scores, calculating a player's total, sorting, printing the table, and the analysis. Function comments and Input / Processing / Output comments.

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
Check: round averages R1 = (80+95+60)/3 = 78.33, R2 = (90+85+75)/3 = 83.33, R3 = (70+88+100)/3 = 86.00. The highest single score is 100 (Sam, round 3).

Tie rule: "first one found" means scanning rows top to bottom in the **sorted** table, rounds left to right.

**Hints**
- All the names are asked **first**, then all the scores (look at the sample run).
- A constant `NUM_ROUNDS = 3` at the top keeps the 3 from being typed all over.
- A small helper like `get_whole_number(prompt, low, high, error_message)` can do both the player count and each score with one `while` loop.
- Sort **before** you print the table and **before** the analysis. Then the winner is simply row 0.
- Suggested functions: `get_scores(names)`, `calculate_total(row)`, `sort_by_total(names, scores)`, `print_table(names, scores)`, `print_analysis(names, scores)`, and `main()`.

## Turn it in
1. In your `bpaPrep` repo make a folder `python_step08`.
2. Put `step08.py` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 8 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run, including spacing in the table
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Names in a list; scores in a list of lists (one row per player)
- [ ] Bad counts and bad scores are re-asked with the right message
- [ ] Your own sort, swapping names and score rows together
- [ ] Functions for getting scores, total, sorting, table, analysis — each with a Purpose / Parameters / Returns comment
- [ ] Pushed to `bpaPrep/python_step08`
