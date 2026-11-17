# Builds for Step 01 — Output and Comments (Python)

These are BPA-style programs that use the Step 1 skills together with everything before it. They are bigger than the practice problems, and closer to what the BPA test asks for.

**Do these after you finish Steps 1–3 (lessons and practice).** Use the [Step 1 Study Guide](../step01_outputAndComments/step01_StudyGuide.md) for help.

## Table of Contents
- [Build 1A: Event Welcome Screen](#build-1a-event-welcome-screen)
- [Build 1B: Class Schedule Card](#build-1b-class-schedule-card)
- [Build 1C: Food Truck Menu Board](#build-1c-food-truck-menu-board)
- [Build 1D: Program Help Screen](#build-1d-program-help-screen)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Build 1A: Event Welcome Screen
Write a program that prints the welcome screen for MCCC Game Night.

**Requirements**
1. Header comment at the top (name, date, program name, description).
2. Print exactly the welcome screen below.
3. Use at least one `\n` inside a single print statement to make two lines.
4. An `Output:` comment (in your language's comment style) above the printing block.

**Sample run (exact)**
```
==============================
   MCCC GAME NIGHT
   Friday, 6:00 PM - Room 112
==============================
Events tonight:
  1. Board Games
  2. Video Game Tournament
  3. Trivia
Bring a friend!
```

**Hints**
- The line of `=` signs is 30 characters long. You can type them, or use `"=" * 30`.
- `MCCC GAME NIGHT` and the `Friday` line each start with 3 spaces. The numbered events each start with 2 spaces.
- For requirement 3, pick any two lines that are next to each other and print them with one `print` and a `\n` between them.

---

## Build 1B: Class Schedule Card
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

## Build 1C: Food Truck Menu Board
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

## Build 1D: Program Help Screen
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
1. In your `bpaPrep` repo, make a folder named `python_builds` (one folder for all builds).
2. Save the builds as `build01A.py`, `build01B.py`, `build01C.py`, and `build01D.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run (count the spaces)
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments (for this step, an `Output:` comment)
- [ ] At least one `print` uses `\n` to make two lines
- [ ] Pushed to `bpaPrep/python_builds`
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Repeated characters use `*` with a number, not typed out
- [ ] Header comment and `Output:` comments in each file
- [ ] Build 1D's debug line is commented out and does not print
