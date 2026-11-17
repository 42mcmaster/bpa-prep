# Step 08 Practice — Nested Data (Python)

**Do these after the [Step 8 lesson](step08_Lesson.md).** Each problem is short and uses one idea from the lesson.

**Time:** about one class period for Problems 1–12. The Challenge at the end takes longer.

**Need help?** Use the [Step 8 Study Guide](step08_StudyGuide.md). Every problem lists the study guide section that shows how.

Problems marked **(review)** use skills from earlier steps, so you keep practicing them.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: One seat](#problem-1-one-seat)
- [Problem 2: Print the chart](#problem-2-print-the-chart)
- [Problem 3: Row totals](#problem-3-row-totals)
- [Problem 4: Column totals](#problem-4-column-totals)
- [Problem 5: Names and ages](#problem-5-names-and-ages)
- [Problem 6: The oldest](#problem-6-the-oldest)
- [Problem 7: Scores from input](#problem-7-scores-from-input)
- [Problem 8: Times table grid](#problem-8-times-table-grid)
- [Problem 9: A lined-up table](#problem-9-a-lined-up-table)
- [Problem 10: Menu lookup](#problem-10-menu-lookup)
- [Problem 11: Count the votes](#problem-11-count-the-votes)
- [Problem 12: Total of a table with a function](#problem-12-total-of-a-table-with-a-function)
- [Challenge: Gradebook Table](#challenge-gradebook-table)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step08_p01.py`, `step08_p02.py`, and so on.
2. Start each file with a header comment (name, date, program name).
3. Every function gets a Purpose / Parameters / Returns comment.
4. Use the **exact** prompts and output shown. Same words, same spaces.
5. Run your program with the sample input and compare your output to the sample run, line by line.

---

## Problem 1: One seat
Use this seating chart:

```python
seats = [["A1", "A2", "A3"],
         ["B1", "B2", "B3"],
         ["C1", "C2", "C3"]]
```

Print the seat in the middle of the chart, the last seat in row A, and the whole of row C.

**Sample run**
```
Middle seat: B2
End of row A: A3
Row C: ['C1', 'C2', 'C3']
```

**Hint:** It's `seats[row][column]`, and both start at 0.

**Study guide:** [Reading one value from a row and column](step08_StudyGuide.md#reading-one-value-from-a-row-and-column)

---

## Problem 2: Print the chart
Use the same seating chart. Use a loop inside a loop to print each row on its own line, with a space between the seats.

**Sample run**
```
A1 A2 A3
B1 B2 B3
C1 C2 C3
```

**Hints**
- The outer loop goes through the rows. The inner loop goes through the seats in one row.
- Build each line as a string, then `.strip()` the extra space at the end before you print.

**Study guide:** [Nested loops](step08_StudyGuide.md#nested-loops)

---

## Problem 3: Row totals
Each row is one week of a student's reading minutes:

```python
minutes = [[30, 45, 20],
           [60, 10, 35],
           [25, 25, 30]]
```

Print the total for each week.

**Sample run**
```
Week 1: 95 minutes
Week 2: 105 minutes
Week 3: 80 minutes
```

**Hint:** `total = 0` goes **inside** the outer loop, so each week starts over.

**Study guide:** [Row totals and column averages](step08_StudyGuide.md#row-totals-and-column-averages)

---

## Problem 4: Column totals
Use the same `minutes` table. This time, each **column** is one day. Print the total for each day.

**Sample run**
```
Day 1: 115 minutes
Day 2: 80 minutes
Day 3: 85 minutes
```

**Hints**
- Now the **outer** loop goes through the columns, and the inner loop goes down the rows.
- Use indexes: `minutes[row][col]`.

**Study guide:** [Row totals and column averages](step08_StudyGuide.md#row-totals-and-column-averages)

---

## Problem 5: Names and ages
Use these parallel lists:

```python
names = ["Avery", "Blake", "Casey", "Devon"]
ages = [16, 17, 15, 18]
```

Print each name with its age.

**Sample run**
```
Avery is 16
Blake is 17
Casey is 15
Devon is 18
```

**Hint:** Loop over the indexes with `range(len(names))`. Index `i` works in both lists.

**Study guide:** [Parallel lists](step08_StudyGuide.md#parallel-lists)

---

## Problem 6: The oldest
*(review: Step 6 finding the highest)*

Use the same two lists. Find the oldest person and print their name.

**Sample run**
```
Oldest: Devon (18)
```

**Hint:** Keep the **index** of the oldest, like Step 6. Then use that index in `names`.

**Study guide:** [Parallel lists](step08_StudyGuide.md#parallel-lists)

---

## Problem 7: Scores from input
Ask for 2 players. For each one, ask for the name and 3 round scores. Store the names in a list and the scores in a list of lists, then print both lists.

**Sample run**
```
Name: Avery
  Round 1: 88
  Round 2: 92
  Round 3: 79
Name: Blake
  Round 1: 95
  Round 2: 67
  Round 3: 84
['Avery', 'Blake']
[[88, 92, 79], [95, 67, 84]]
```

**Hint:** Make `row = []` inside the outer loop, fill it, then `scores.append(row)`.

**Study guide:** [Building a list of lists from input](step08_StudyGuide.md#building-a-list-of-lists-from-input)

---

## Problem 8: Times table grid
*(review: Step 4 for loops)*

Use two `for` loops to print a 5 x 5 times table. Each number takes 4 spaces, right-aligned.

**Sample run**
```
   1   2   3   4   5
   2   4   6   8  10
   3   6   9  12  15
   4   8  12  16  20
   5  10  15  20  25
```

**Hints**
- `f"{value:>4}"` puts the number on the right side of a space 4 characters wide.
- Build one line per row, then print it.

**Study guide:** [Formatting a table in columns](step08_StudyGuide.md#formatting-a-table-in-columns)

---

## Problem 9: A lined-up table
Use these parallel lists:

```python
items = ["Pencils", "Notebooks", "Glue sticks"]
prices = [0.25, 1.99, 0.89]
```

Print them as a table. The item column is 14 wide, left-aligned. The price column is 7 wide, right-aligned, with 2 decimals.

**Sample run**
```
Item            Price
---------------------
Pencils          0.25
Notebooks        1.99
Glue sticks      0.89
```

**Hints**
- Header: `f"{'Item':<14}{'Price':>7}"`. Rows use the same widths.
- `{price:>7.2f}`: 2 decimals, right-aligned in 7 spaces.

**Study guide:** [Formatting a table in columns](step08_StudyGuide.md#formatting-a-table-in-columns)

---

## Problem 10: Menu lookup
*(review: Step 7 string methods)*

Store this menu in a dictionary: `burger` 6.50, `fries` 2.75, `shake` 4.00. Ask for an item. Print its price, or `Not on the menu.` if it isn't there.

**Sample run 1**
```
What would you like? Fries
A fries is $2.75
```

**Sample run 2**
```
What would you like? salad
Not on the menu.
```

**Hints**
- `if item in menu:` checks for the key before you look it up.
- `.strip().lower()` makes `Fries` match `fries`.

**Study guide:** [Dictionaries (another way)](step08_StudyGuide.md#dictionaries-another-way)

---

## Problem 11: Count the votes
Use this list of votes: `["pizza", "tacos", "pizza", "wings", "tacos", "pizza"]`. Use a dictionary to count the votes for each food, then print the counts.

**Sample run**
```
pizza: 3
tacos: 2
wings: 1
```

**Hints**
- Start with an empty dictionary: `counts = {}`.
- If the food is already a key, add 1. If not, set it to 1.

**Study guide:** [Dictionaries (another way)](step08_StudyGuide.md#dictionaries-another-way)

---

## Problem 12: Total of a table with a function
*(review: Step 5 functions)*

Write a function `table_total(table)` that returns the total of every number in a list of lists. Call it on two tables.

**Sample run**
```
10
78
```

**Hint:** Start `total = 0` **before** both loops, since you want one total for the whole table.

**Study guide:** [Nested loops](step08_StudyGuide.md#nested-loops)

---

## Challenge: Gradebook Table
This one puts the pieces together: parallel lists, a list of lists filled from input, an ask-again loop, row averages, the best student, and a lined-up table.

**Requirements**
1. Header comment, Input / Processing / Output comments, and a `main()` function.
2. Named constants: `STUDENTS = 3` and `TESTS = 3`.
3. Store the names in a list and the scores in a list of lists (one row per student).
4. Write `get_score(prompt)`: ask until the score is 0 to 100, then return it. A bad score prints `Scores must be 0 to 100.`
5. Write `row_average(row)`: return the average of one row, using your own loop.
6. Print the table exactly as shown. Widths: name 10 left; each test 5 right; average 7 right with 1 decimal.
7. Print the student with the highest average. If there is a tie, the first one wins.

**Sample run**
```
Student name: Avery
  Test 1: 88
  Test 2: 92
  Test 3: 79
Student name: Blake
  Test 1: 95
  Test 2: 105
Scores must be 0 to 100.
  Test 2: 67
  Test 3: 84
Student name: Casey
  Test 1: 72
  Test 2: 85
  Test 3: 90

Name         T1   T2   T3    Avg
--------------------------------
Avery        88   92   79   86.3
Blake        95   67   84   82.0
Casey        72   85   90   82.3
--------------------------------
Top student: Avery
```

**Hints**
- `get_score` takes the prompt as a parameter, so the same function works for Test 1, 2, and 3.
- Keep the **index** of the best student, then print `names[best]`.

**Study guide:** [Formatting a table in columns](step08_StudyGuide.md#formatting-a-table-in-columns)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step08` folder.
2. Save the problems as `step08_p01.py` through `step08_p12.py`, and the challenge as `step08_challenge.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step08`
