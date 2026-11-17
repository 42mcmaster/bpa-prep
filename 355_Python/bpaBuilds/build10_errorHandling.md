# Builds for Step 10 — Error Handling (Python)

These are BPA-style programs that use the Step 10 skills together with everything before it. They are bigger than the practice problems, and closer to what the BPA test asks for.

**Do these after you finish the Step 10 lesson and practice.** Use the [Step 10 Study Guide](../step10_errorHandling/step10_StudyGuide.md) for help.

**Rules for every build in this file**
- No bad input can crash the program: letters, decimals where a whole number is needed, blanks, and out-of-range numbers.
- Copy `get_text`, `get_int`, and `get_yes_no` from your Build 10A (Ticket Order) where a task needs them. Use the same messages.
- Every `try`/`except` has a comment saying what error it catches, like `# try/except catches ValueError: float() fails on letters`.
- Name the error in every `except`. No bare `except:`.
- Every function has a purpose / parameters / returns comment.
- End the file with `if __name__ == "__main__":` and `main()`.

## Table of Contents
- [Build 10A: Ticket Order](#build-10a-ticket-order)
- [Build 10B: Crash-Proof Calculator](#build-10b-crash-proof-calculator)
- [Build 10C: Gym Membership Signup](#build-10c-gym-membership-signup)
- [Build 10D: Gradebook With a Messy File](#build-10d-gradebook-with-a-messy-file)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Build 10A: Ticket Order
Take ticket orders that can't be crashed by bad input, then save them to a file.

**Requirements**
1. Header comment.
2. Write these reusable functions:
   - `get_text(prompt)` → keeps asking until the answer is not blank; on blank prints `This cannot be blank.`
   - `get_int(prompt, low, high)` → keeps asking until the answer is a whole number from low to high; otherwise prints `Please enter a whole number from <low> to <high>.` Must reject letters, decimals like `2.5`, blanks, and out-of-range numbers without crashing.
   - `get_yes_no(prompt)` → returns True for `y`/`Y`, False for `n`/`N`; anything else prints `Please enter y or n.` and asks again.
3. Ask for the name with `get_text`, then repeat: show the ticket types, ask ticket type (1–3) and quantity (1–10) with `get_int`, add to the order, ask `Another order? (y/n): ` with `get_yes_no`.
   - Ticket types and prices: 1-Student $5.00, 2-Adult $8.50, 3-Senior $6.25.
4. At the end print total tickets and total cost.
5. Save the order to `orders.txt` inside a try/except. One line per order in the form `Jordan,Adult,3,25.50`. On success print `Order saved to orders.txt`; if writing fails print `Error: could not save orders.txt` (no crash).
6. Function comments and Input / Processing / Output comments, including a comment on each try/except saying what error it catches.

**Sample run (exact)**
```
Name: 
This cannot be blank.
Name: Jordan
Ticket types: 1-Student $5.00  2-Adult $8.50  3-Senior $6.25
Ticket type (1-3): two
Please enter a whole number from 1 to 3.
Ticket type (1-3): 2
Quantity (1-10): 2.5
Please enter a whole number from 1 to 10.
Quantity (1-10): 3
Another order? (y/n): maybe
Please enter y or n.
Another order? (y/n): y
Ticket types: 1-Student $5.00  2-Adult $8.50  3-Senior $6.25
Ticket type (1-3): 1
Quantity (1-10): 2
Another order? (y/n): n

Total tickets: 5
Total cost: $35.50
Order saved to orders.txt
```
The first line `Name: ` with nothing after it means the user just pressed Enter. Whitespace-only counts as blank — trim it.

**`orders.txt`**
```
Jordan,Adult,3,25.50
Jordan,Student,2,10.00
```

**Hints**
- Store the ticket names and prices in two parallel lists (Step 8): `TICKET_NAMES = ["Student", "Adult", "Senior"]` and `TICKET_PRICES = [5.00, 8.50, 6.25]`. Ticket type 2 is index 1.
- Keep each order as a small list like `["Adult", 3, 25.50]` and append it to an `orders` list. Then the save function loops over `orders`.
- In the file, money has 2 decimals but no `$`: `f"{cost:.2f}"`.
- The ticket types line has **two** spaces between types.
- Test the save failure: create a **folder** named `orders.txt` next to your program, then run it. Python can't write a file where a folder is. You should see the error message, not a crash. Delete the folder after.

---

## Build 10B: Crash-Proof Calculator
Write a calculator that cannot be crashed, including by dividing by zero.

**Requirements**
1. Header comment.
2. Write these functions:

   | Function | What it does |
   |---|---|
   | `get_float(prompt)` | keeps asking until the answer is a number (decimals OK). On a bad answer prints `Please enter a number.` |
   | `get_operator(prompt)` | keeps asking until the answer is `+`, `-`, `*`, or `/`. Otherwise prints `Please enter +, -, *, or /.` |
   | `get_yes_no(prompt)` | from Build 10A |
   | `calculate(first, operator, second)` | returns the answer. It does **not** check for zero. |
   | `main()` | runs the program |

3. Each round, ask for the first number, the operator, and the second number.
4. Call `calculate` inside a `try`. If it raises `ZeroDivisionError`, print `Error: you cannot divide by zero.` and count it as an error. Otherwise print the problem and answer, all with **2** decimal places, and count it.
5. Ask `Another? (y/n): ` and print a blank line. Keep going while the answer is yes.
6. At the end print how many calculations worked and how many errors were caught.
7. Input / Processing / Output comments.

**Sample run**
```
First number: 12
Operator (+ - * /): x
Please enter +, -, *, or /.
Operator (+ - * /): *
Second number: abc
Please enter a number.
Second number: 3.5
12.00 * 3.50 = 42.00
Another? (y/n): y

First number: 10
Operator (+ - * /): /
Second number: 0
Error: you cannot divide by zero.
Another? (y/n): y

First number: 7
Operator (+ - * /): -
Second number: 2.25
7.00 - 2.25 = 4.75
Another? (y/n): maybe
Please enter y or n.
Another? (y/n): n

Calculations: 2
Errors caught: 1
```

**Hints**
- `get_float` is the Step 10 study guide's `get_float` without the range check: `try: return float(answer)`.
- Let `calculate` divide by zero on purpose. The `try`/`except` in `main` catches it. That's the point of the task.
- `get_operator` doesn't need `try` at all. It's a `while` loop that checks the text.

**Test these too:** a blank number, `-5` (negative numbers are fine), and `0 / 5` (that one works: 0.00).

---

## Build 10C: Gym Membership Signup
Sign up gym members with input that can't be crashed, price each plan, and save the signups to a file.

**Requirements**
1. Header comment. Constants:
   ```python
   PLAN_NAMES = ["Basic", "Plus", "Premium"]
   PLAN_PRICES = [19.99, 29.99, 44.99]
   LOCKER_PRICE = 5.00
   TRAINER_PRICE = 25.00
   STUDENT_DISCOUNT = 0.15
   FILE_NAME = "signups.txt"
   ```
2. Use `get_text`, `get_int`, and `get_yes_no` for every question.
3. For each member, ask:
   - name (`get_text`)
   - age, 14 to 99 (`get_int`)
   - print the plans line exactly as shown, then plan 1 to 3 (`get_int`)
   - locker (y/n), trainer (y/n)
   - **only if the age is 22 or under**, `Student ID? (y/n): `
4. Write `monthly_cost(plan, locker, trainer, student)`: start with the plan price, add the locker and trainer if chosen, then take 15% off the whole thing for a student.
5. Print `<name>: <plan> plan, $X.XX per month`, plus `  (15% student discount applied)` for students. Save each signup as a small list `[name, plan name, cost]` in a list of signups.
6. Ask `Sign up another member? (y/n): ` and print a blank line.
7. At the end, print the number of members and the monthly total, then save the file.
8. Write `save_signups(signups)` that writes one line per member like `Jordan,Plus,29.74` inside a `try`/`except OSError`. Print `Signups saved to signups.txt` or `Error: could not save signups.txt`.
9. Input / Processing / Output comments.

**Sample run** (the first `Member name:` is blank because the user just pressed Enter)
```
Member name: 
This cannot be blank.
Member name: Jordan
Age (14-99): sixteen
Please enter a whole number from 14 to 99.
Age (14-99): 17
Plans: 1-Basic $19.99  2-Plus $29.99  3-Premium $44.99
Plan (1-3): 2
Add a locker for $5.00? (y/n): y
Add a trainer for $25.00? (y/n): n
Student ID? (y/n): y
Jordan: Plus plan, $29.74 per month
  (15% student discount applied)
Sign up another member? (y/n): y

Member name: Sam Lee
Age (14-99): 35
Plans: 1-Basic $19.99  2-Plus $29.99  3-Premium $44.99
Plan (1-3): 3
Add a locker for $5.00? (y/n): n
Add a trainer for $25.00? (y/n): y
Sam Lee: Premium plan, $69.99 per month
Sign up another member? (y/n): n

Members signed up: 2
Monthly total: $99.73
Signups saved to signups.txt
```

**`signups.txt`**
```
Jordan,Plus,29.74
Sam Lee,Premium,69.99
```

**Hints**
- Check Jordan's price: Plus 29.99 + locker 5.00 = 34.99. 15% off: 34.99 − 5.2485 = 29.74.
- Plan 2 is index 1: `PLAN_PRICES[plan - 1]`.
- Set `student = False` before the age check, so it has a value for members over 22.
- Test the save error: make a **folder** named `signups.txt` next to your program and run it. You should see the error message, not a crash. Delete the folder after.

---

## Build 10D: Gradebook With a Messy File
Real data files have mistakes. Load grades from a file that may be **missing** or may have **bad lines**, let the user add grades, then save the file back.

**Data file:** [grades.csv](grades.csv) — it has two bad lines on purpose:
```
Name,Score
Avery,88
Blake,ninety
Casey,95
Devon
Emery,72
```

**Requirements**
1. Header comment. Constant: `FILE_NAME = "grades.csv"`.
2. Write `load_grades(file_name)` that returns two parallel lists, names and scores:
   - If the file is missing (`FileNotFoundError`), print `No grades.csv found. Starting a new gradebook.` and return empty lists.
   - Skip the header. For each line, try to read the score with `int(parts[1])`.
   - If the score is not a number (`ValueError`) **or** the line has no comma (`IndexError`), print `Skipped bad line N: <the line>` and keep going. N is the line number in the file (the header is line 1).
   - At the end, print `Loaded N grades from grades.csv`.
3. Print a blank line, then keep asking `Add a grade? (y/n): `. For yes, ask the student name (`get_text`) and the score 0 to 100 (`get_int`).
4. Write `print_summary(names, scores)` that prints the count, average (1 decimal), highest, and lowest, or `No grades yet.` if there are none.
5. Write `save_grades(file_name, names, scores)` that writes the header and every grade, inside `try`/`except OSError`. Print `Saved N grades to grades.csv`. The bad lines are **not** saved, so the file is clean afterward.
6. Input / Processing / Output comments.

**Sample run**
```
Skipped bad line 3: Blake,ninety
Skipped bad line 5: Devon
Loaded 3 grades from grades.csv

Add a grade? (y/n): y
Student name: Finley
Score (0-100): 105
Please enter a whole number from 0 to 100.
Score (0-100): 81
Add a grade? (y/n): n

Grades: 4
Average: 84.0
Highest: Casey (95)
Lowest: Emery (72)
Saved 4 grades to grades.csv
```

**`grades.csv` after the run**
```
Name,Score
Avery,88
Casey,95
Emery,72
Finley,81
```

**Hints**
- There are **two** `try` blocks in `load_grades`: an outer one around the whole file for `FileNotFoundError`, and an inner one around each line for the bad data.
- `"Devon".split(",")` is `["Devon"]`, so `parts[1]` raises `IndexError` (the list has no index 1). That's a new error type, but it works just like `ValueError`. Give it its own `except IndexError:` block.
- Keep a `line_number` counter. Start it at 1 for the header and add 1 for each line you read.
- The `while` loop can call `get_yes_no` right in its condition: `while get_yes_no("Add a grade? (y/n): "):`
- **Make a backup copy of `grades.csv` before you test.** Your program rewrites it, so the bad lines will be gone after the first run.

**Test these too:** rename `grades.csv` (you should get the "Starting a new gradebook" message), add a grade with a blank name, and add a score of `abc`.

---

## Turn it in
1. In your `bpaPrep` repo, make a folder named `python_builds` (one folder for all builds).
2. Save the builds as `build10A.py`, `build10B.py`, `build10C.py`, and `build10D.py`. Put any data files the build uses next to the program.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] `orders.txt` matches
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `get_text`, `get_int`, `get_yes_no` written and used for every input
- [ ] Letters, `2.5`, blanks, and out-of-range numbers never crash it
- [ ] Each try/except has a comment saying what error it catches
- [ ] Save failure prints the error message instead of crashing
- [ ] Every function has a Purpose / Parameters / Returns comment
- [ ] Pushed to `bpaPrep/python_builds`
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] I tried to crash each program with letters, blanks, decimals, and out-of-range numbers, and it never crashed
- [ ] Every `try`/`except` names its error and has a comment saying what it catches
- [ ] Input / Processing / Output comments in each file
