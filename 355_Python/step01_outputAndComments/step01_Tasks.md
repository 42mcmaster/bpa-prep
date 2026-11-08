# Step 01 Tasks — Output and Comments (Python)

**Do these after the [Step 1 lesson](step01_Lesson.md).** The lesson's Event Welcome Screen is the walkthrough. These three tasks are extra practice with the same skills.

Every task is graded the way BPA grades: the output has to match **exactly**. Count the spaces, check the capital letters, and check the punctuation.

## Table of Contents
- [Task A: Class Schedule Card](#task-a-class-schedule-card)
- [Task B: Food Truck Menu Board](#task-b-food-truck-menu-board)
- [Task C: Program Help Screen](#task-c-program-help-screen)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Task A: Class Schedule Card

Write a program that prints a daily schedule card for the IT Academy.

**Requirements**
1. Header comment (name, date, program name, description).
2. Print exactly the card below.
3. The two lines of `*` (34 stars) and the line of `-` (34 dashes) must use `*` with a number, like `"*" * 34`. Do not type them out.
4. Print the six schedule lines using **three** `print` statements. Each one prints two lines using `\n`.
5. The last line has quote marks inside it. Use `\"`.
6. An `Output:` comment above each block (title, schedule, footer).

**Sample run (exact)**
```
**********************************
  MEDINA COUNTY CAREER CENTER
  IT Academy - Daily Schedule
**********************************
7:30  Homeroom
7:45  Software Engineering Lab
10:15 Break
10:30 Software Engineering Lab
12:15 Lunch
12:45 Academics
----------------------------------
Room 112 - "Bring your laptop!"
```

**Hints**
- The two title lines each start with 2 spaces.
- `7:30` and `7:45` are followed by **2** spaces so the class names line up with the `10:15` lines, which have **1** space.
- Check your stars: copy one line of your output into a text editor and count, or trust `"*" * 34`.

---

## Task B: Food Truck Menu Board

Write a program that prints the menu board for the Byte Bites food truck.

**Requirements**
1. Header comment.
2. Print exactly the menu below.
3. The three border lines are a `+`, then 38 dashes, then a `+`. Build each one with `"+" + "-" * 38 + "+"`.
4. Print two of the items in each of the **SIDES** and **DRINKS** sections with one `print` and a `\n` (two items, one `print`, for each section).
5. Use `print()` with nothing in it for the blank lines.
6. The `Debugger` line uses `\"` for the quote marks. The `combo` line uses single quote marks inside double-quoted text (no backslash needed).
7. An `Output:` comment above each block (header, menu items, footer).

**Sample run (exact)**
```
+--------------------------------------+
|          BYTE BITES FOOD TRUCK       |
+--------------------------------------+
  MAINS
    Cheeseburger ............ $6.50
    Chicken Tenders ......... $5.75
    Veggie Wrap ............. $5.25

  SIDES
    Fries ................... $2.50
    Onion Rings ............. $3.00

  DRINKS
    Lemonade ................ $2.00
    Bottled Water ........... $1.25
+--------------------------------------+
Today's special: the "Debugger" Burger
Ask about our 'combo' deals!
```

**Hints**
- The box title line is `|`, then 10 spaces, then `BYTE BITES FOOD TRUCK`, then 7 spaces, then `|`. That makes it the same width as the border lines (40 characters).
- Section names (`MAINS`, `SIDES`, `DRINKS`) start with 2 spaces. Items start with 4 spaces.
- Every price line is the same width. The dots fill the space between the item and the price.
- `Today's` has an apostrophe. Inside double quotes, that is fine.

---

## Task C: Program Help Screen

Command-line programs print a help screen when you type `-h`. Write a program that prints the help screen for a pretend tool called `gradebook`.

**Requirements**
1. Header comment.
2. Print exactly the help screen below.
3. The three `=` lines are 44 characters and the `-` line is 44 characters. Use `"=" * 44` and `"-" * 44`.
4. Use `\n` in **at least two** `print` statements to print two lines at once.
5. The Windows file path must print with single backslashes: `C:\BPA\scores.txt`. Use `\\` in your code.
6. `"Quiz 3"` must print with its quote marks. Use `\"`.
7. Add this line to the **end** of your program, then turn it off by commenting it out. It must **not** print:
   ```python
   print("Debug mode is on.")
   ```
8. An `Output:` comment above each block. Use at least **5** of them (title, usage, options, examples, footer).

**Sample run (exact)**
```
============================================
  GRADEBOOK  version 1.0
  A tool for tracking class scores
============================================
USAGE:
  gradebook [option] [file]

OPTIONS:
  -a    Add a new score
  -l    List all scores
  -r    Print a report
  -h    Show this help screen

EXAMPLES:
  gradebook -l C:\BPA\scores.txt
  gradebook -a "Quiz 3"

--------------------------------------------
Tip: options are case sensitive.
-A is not the same as -a.
============================================
```

**Hints**
- `GRADEBOOK  version 1.0` has **2** spaces between `GRADEBOOK` and `version`.
- The option lines are: 2 spaces, the option, 4 spaces, the description.
- If your path prints as `C:BPAscores.txt` or something odd, you used one backslash instead of two. `\s` and `\B` are not real escape sequences, so Python may also warn you.
- In IDLE, select a line and press **Alt+3** to comment it out.

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step01` folder.
2. Save the tasks as `step01_taskA.py`, `step01_taskB.py`, and `step01_taskC.py`.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 1 tasks done*.

## Checklist
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Repeated characters use `*` with a number, not typed out
- [ ] Header comment and `Output:` comments in each file
- [ ] Task C's debug line is commented out and does not print
- [ ] Pushed to `bpaPrep/python_step01`
