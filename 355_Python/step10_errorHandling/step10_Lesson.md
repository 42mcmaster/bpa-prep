# Step 10 — Error Handling (Python)

**What you'll build:** Ticket Order — a ticket ordering program that never crashes on bad input, built from reusable input functions, and saves the order to a file.
**Time:** about two class periods. The input functions you write here are the most useful code you can bring to BPA.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [What an exception is](#what-an-exception-is)
- [Reading a traceback](#reading-a-traceback)
- [try and except](#try-and-except)
- [Catching specific errors](#catching-specific-errors)
- [else and finally](#else-and-finally)
- [Why int input crashes and how to stop it](#why-int-input-crashes-and-how-to-stop-it)
- [The ask-until-valid loop](#the-ask-until-valid-loop)
- [Reusable input functions](#reusable-input-functions)
- [Blank answers and strip](#blank-answers-and-strip)
- [Yes or no questions](#yes-or-no-questions)
- [Handling file errors](#handling-file-errors)
- [Testing your error handling](#testing-your-error-handling)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Ticket Order](#the-challenge-ticket-order)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What an exception is and what a crash looks like
- How to read a traceback to find the line and the reason
- How `try` and `except` catch an error so the program keeps going
- How to catch **specific** errors: `ValueError`, `FileNotFoundError`, `OSError`
- What `else` and `finally` do in a `try`
- How to keep asking until the user types a valid answer
- How to write reusable input functions: `get_text`, `get_int`, `get_yes_no`
- How to save a file without crashing if something goes wrong

## What an exception is

An **exception** is an error that happens **while the program is running**. (A syntax error, from Step 1, stops the program before it starts. An exception happens partway through.)

When an exception isn't handled, the program **crashes**: it stops right there and prints a red **traceback**. Everything after that line never runs.

You've already seen several:

| Exception | What caused it | Example |
|---|---|---|
| `ValueError` | the value is the wrong kind for the job | `int("two")`, `int("2.5")`, `int("")` |
| `FileNotFoundError` | opening a file that isn't there for reading | `open("nope.csv")` |
| `OSError` | any file or system problem (FileNotFoundError is one kind of OSError) | the folder is read-only, the disk is full |
| `IndexError` | a list index that doesn't exist | `scores[10]` on a 5-item list |
| `ZeroDivisionError` | dividing by zero | `total / 0` |
| `TypeError` | the wrong type for an operation | `"5" + 5` |
| `NameError` | a name that doesn't exist (often a typo) | `pritn("hi")` |

Some of these mean **your code has a bug** (`NameError`, `TypeError`, `IndexError`) — fix the code. Others happen because **the user or the computer did something unexpected** (`ValueError` from typing letters, `FileNotFoundError` from a missing file) — **handle** those with `try`/`except`.

## Reading a traceback

```
Traceback (most recent call last):
  File "C:\bpaPrep\python_step10\step10.py", line 41, in <module>
    main()
  File "C:\bpaPrep\python_step10\step10.py", line 30, in main
    quantity = int(input("Quantity (1-10): "))
ValueError: invalid literal for int() with base 10: '2.5'
```

How to read it:
1. **Start at the bottom.** The last line is the error type and the reason: `ValueError` because `'2.5'` isn't a whole number.
2. **The line above it** is the exact code that failed, and above that is its file and line number (`line 30, in main`).
3. The lines higher up show **how the program got there**: line 41 called `main()`, and inside `main`, line 30 failed. "Most recent call last" means the deepest call is at the bottom.

In IDLE, you can **right-click** a `File "...", line 30` line in the Shell and choose **Go to file/line** to jump to it.

## try and except

```python
# Processing: try something that might fail
try:
    number = int("forty")
    print("This line is skipped.")
except ValueError:
    print("That was not a whole number.")

print("The program is still running.")
```

It prints:

```text
That was not a whole number.
The program is still running.
```

How it works:
1. Python runs the lines in the `try` block.
2. If a `ValueError` happens, Python **stops the try block at that line** and jumps to the `except ValueError:` block.
3. If **no** error happens, the `except` block is skipped.
4. Either way, the program continues after the whole `try`/`except`.

| Part | What it means |
|---|---|
| `try:` | "Try these lines. They might fail." |
| `except ValueError:` | "If a ValueError happens, run this instead of crashing." |
| `except (ValueError, ZeroDivisionError):` | catch either of two error types |
| `except ValueError as error:` | also store the error so you can print its message: `print(error)` |

C++, Java, and C# use the words `try` and `catch` for the same thing.

## Catching specific errors

You can have more than one `except`, one for each kind of error. Python uses the first one that matches.

<!-- input: 0 -->
```python
total_points = 120

# Input: how many games were played
games_text = input("Games played: ")

# Processing: two different things could go wrong
try:
    games = int(games_text)
    average = total_points / games
    print(f"Average: {average:.2f}")
except ValueError:
    print("Games must be a whole number.")
except ZeroDivisionError:
    print("Games cannot be 0.")
```

It prints (user typed `0`):

```text
Games played: 0
Games cannot be 0.
```

**Don't catch everything.** You'll sometimes see a bare `except:` with no error name. It catches **every** error, including typos in your own code (`NameError`), so bugs get hidden and the program does strange things with no message. Always name the error you expect. Graders look for this too: "uses try/except to catch entry error" means a specific, sensible catch.

## else and finally

Two optional parts:

```python
try:
    value = int("25")
except ValueError:
    print("Not a number.")
else:
    print(f"Converted: {value}")      # runs only if there was NO error
finally:
    print("Check finished.")          # ALWAYS runs, error or not
```

It prints:

```text
Converted: 25
Check finished.
```

- `else` runs only when the `try` block had no error.
- `finally` always runs — it's used for clean-up, like closing a file. Since `with` already closes files for you, you won't need `finally` often. Just know what it is if you see it.

## Why int input crashes and how to stop it

`int(input("Quantity: "))` does two things in one line: gets text, converts it. The convert step is where it crashes. The fix:
1. Read the answer as text (this can't fail).
2. **Try** to convert it.
3. If the convert fails, catch the `ValueError` and show a message.

`int()` is strict, which is exactly what you want for a whole-number question. It rejects:

| Typed | `int()` result |
|---|---|
| `3` | `3` |
| ` 3 ` (spaces around it) | `3` — spaces at the ends are allowed |
| `-3` | `-3` — it's a whole number; your **range check** must reject it |
| `2.5` | `ValueError` |
| `two` | `ValueError` |
| (blank — just Enter) | `ValueError` |
| `3abc` | `ValueError` |

So `try`/`except ValueError` handles letters, decimals, and blanks, and a range check handles negatives and numbers that are too big.

## The ask-until-valid loop

Put the try/except inside a loop that only ends when the answer is good. This version uses `while True` — a loop that would run forever — and leaves with `return` the moment the answer is valid:

<!-- input: abc|7|3.6 -->
```python
def get_float(prompt, low, high):
    """Purpose: ask until the user types a number (decimals allowed) from low to high.
    Parameters: prompt (str) - the question
                low (float), high (float) - the allowed range
    Returns: the number (float)
    """
    while True:
        answer = input(prompt)
        # try/except catches ValueError: float() fails on letters and blanks
        try:
            number = float(answer)
            if number >= low and number <= high:
                return number           # good answer - leave the function (and the loop)
        except ValueError:
            pass                        # "pass" means do nothing; fall through to the message
        print(f"Please enter a number from {low} to {high}.")

# Input: a GPA from 0 to 4
gpa = get_float("GPA (0-4): ", 0, 4)

# Output
print(f"Saved GPA {gpa:.2f}")
```

It prints (user typed `abc`, `7`, `3.6`):

```text
GPA (0-4): abc
Please enter a number from 0 to 4.
GPA (0-4): 7
Please enter a number from 0 to 4.
GPA (0-4): 3.6
Saved GPA 3.60
```

Walk through the logic once for each kind of answer:
- `abc` → `float` fails → jump to `except` → `pass` → print the message → loop again.
- `7` → converts fine → range check is False → skip `return` → print the message → loop again.
- `3.6` → converts → in range → `return 3.6`. The function ends. The message is never printed.

The message is printed in **one** place, after the `try`/`except`, so both kinds of bad answer get the same message. That's what the challenge asks for.

## Reusable input functions

A **reusable** function works in any program because everything that changes (the question, the range) is a parameter. Write it once, print it, bring it to BPA, and use it for every input in every test.

For the challenge you'll write three:

| Function | Keeps asking until... | Message on a bad answer | Returns |
|---|---|---|---|
| `get_text(prompt)` | the answer isn't blank | `This cannot be blank.` | the answer, with spaces trimmed off the ends |
| `get_int(prompt, low, high)` | the answer is a whole number from low to high | `Please enter a whole number from <low> to <high>.` | the number as an `int` |
| `get_yes_no(prompt)` | the answer is y, Y, n, or N | `Please enter y or n.` | `True` for y/Y, `False` for n/N |

`get_int` is `get_float` from above with `int()` instead of `float()` and the message changed. Once you have these, the main program gets very short:

```python
name = get_text("Name: ")
seats = get_int("Seats (1-4): ", 1, 4)
if get_yes_no("Print tickets? (y/n): "):
    ...
```

Notice what happens to all the `while` loops from Steps 4, 6, and 8: they move **into** these functions, so `main` doesn't need any.

## Blank answers and strip

A user who presses the space bar and then Enter typed `"   "`, not `""`. To treat that as blank, `strip()` the answer first (Step 7): `"   ".strip()` is `""`.

<!-- input: |   |Lab B -->
```python
def get_room(prompt):
    """Purpose: ask for a room name until it isn't blank.
    Parameters: prompt (str)
    Returns: the trimmed room name (str)
    """
    answer = input(prompt).strip()
    while answer == "":
        print("Room cannot be blank.")
        answer = input(prompt).strip()
    return answer

room = get_room("Room: ")
print(f"Booked {room}.")
```

It prints (user pressed Enter, then typed three spaces, then `Lab B`):

```text
Room: 
Room cannot be blank.
Room:    
Room cannot be blank.
Room: Lab B
Booked Lab B.
```

This uses the "ask before the loop, ask again at the bottom" pattern from Step 4. Your `get_text` is the same shape with a different message.

## Yes or no questions

`get_yes_no` returns a `bool`, so the caller can use it straight in an `if` or a `while`:

```python
def get_yes_no(prompt):
    """Purpose: ask a yes/no question until the answer is y or n.
    Parameters: prompt (str)
    Returns: True for y or Y, False for n or N
    """
    while True:
        answer = input(prompt).strip()
        if answer == "y" or answer == "Y":
            return True
        if answer == "n" or answer == "N":
            return False
        print("Please enter y or n.")
```

Then a "do it again" loop reads like English:

<!-- input: x|y|n -->
```python
def get_yes_no(prompt):
    while True:
        answer = input(prompt).strip()
        if answer == "y" or answer == "Y":
            return True
        if answer == "n" or answer == "N":
            return False
        print("Please enter y or n.")

laps = 0
running = True
while running:
    laps = laps + 1
    print(f"Lap {laps} done.")
    running = get_yes_no("Another lap? (y/n): ")
print(f"Total laps: {laps}")
```

It prints (user typed `x`, `y`, `n`):

```text
Lap 1 done.
Another lap? (y/n): x
Please enter y or n.
Another lap? (y/n): y
Lap 2 done.
Another lap? (y/n): n
Total laps: 2
```

## Handling file errors

Writing a file can fail too: the folder might be read-only, or the file might be open in another program. All of those raise an `OSError`. Catch it so the user gets a message instead of a crash.

A good way: make a save function that returns `True` if it worked and `False` if it didn't. The caller decides what to print.

```python
def save_lines(file_name, lines):
    """Purpose: write a list of strings to a file, one per line.
    Parameters: file_name (str), lines (list of str)
    Returns: True if the file was saved, False if writing failed
    """
    # try/except catches OSError: the file could not be opened or written
    try:
        with open(file_name, "w") as out_file:
            for line in lines:
                out_file.write(line + "\n")
        return True
    except OSError:
        return False

if save_lines("signups.txt", ["Avery,Chess", "Blake,Trivia"]):
    print("Saved signups.txt")
else:
    print("Error: could not save signups.txt")
```

It prints:

```text
Saved signups.txt
```

`FileNotFoundError` is a kind of `OSError`, so `except OSError` also catches a missing file. Use `FileNotFoundError` when you mean exactly "the file isn't there" (reading, Step 9), and `OSError` for "anything went wrong with the file" (writing).

**Comment every try/except.** The challenge asks for a comment on each one saying what error it catches, like `# try/except catches OSError: the file could not be written`. Graders look for it.

## Testing your error handling

For every number question, try all of these. None should crash:

| Type this | Expect |
|---|---|
| a good number | accepted |
| the lowest allowed and the highest allowed | accepted (check your `<=` and `>=`) |
| one below the lowest, one above the highest | message, asked again |
| `0`, `-1` | message (unless in range) |
| `2.5` | message |
| `abc` | message |
| just Enter | message |

For text: just Enter, and a few spaces then Enter. For y/n: `Y`, `n`, `yes`, `maybe`, just Enter.

**Try it:** go back to your **Step 4** guessing game. Copy in `get_int` and replace `int(input("Your guess (1-100): "))` with `get_int("Your guess (1-100): ", 1, 100)`. Now letters can't crash it. (The message changes to the `get_int` one, and you can delete your old range check.)

## Common mistakes

**1. Converting outside the try**
```python
answer = int(input(prompt))    # MISTAKE - crashes here, before the try
try:
    ...
```
Fix: read with `input()` outside, convert with `int()` **inside** the `try`.

**2. Range check in the except**
If the range check is inside `except ValueError:`, it only runs when the convert failed. `150` sails through. Fix: do the range check right after the convert, inside `try` (or after the whole `try`/`except`).

**3. Bare `except:`**
Catches your own typos too and hides them. Fix: `except ValueError:`.

**4. Forgetting to return the value**
A `get_int` that checks everything but never `return`s gives back `None`. Then `TICKET_PRICES[choice - 1]` fails with `TypeError: unsupported operand type(s) for -: 'NoneType' and 'int'`. Fix: `return number` when it's valid.

**5. `while True` with no way out**
If the `return` is in the wrong place (or the check can never be True), the loop never ends. Press **Ctrl+C** to stop it, then trace the logic with a good answer.

**6. Not stripping blank answers**
`"   " == ""` is `False`. Fix: `input(prompt).strip()`.

**7. Comparing `get_yes_no` to a string**
`if get_yes_no(...) == "y":` is always False, because the function returns `True`/`False`. Fix: `if get_yes_no(...):`.

## How this shows up at BPA
- This is the heaviest-scored skill on recent Python regionals. On the 2024 test, "uses try/except to catch entry error" was worth **40 points** for each of two inputs, and "does not accept letters; forces user to re-enter" was another **30 points** each. That's well over 100 points for input checking.
- The 2026 regional: "Validate that each entry is a valid integer between 1 and 10. Re-prompt on invalid input." That's exactly `get_int(prompt, 1, 10)`.
- "Names cannot be blank" is `get_text`.
- Graders run your program with junk input. **A single crash** on a letter can cost the whole execution section if it stops the program before the rest can be graded.
- **Print `get_text`, `get_int`, and `get_yes_no` and bring them.** Printed code is allowed. Copying them in at the start of the test saves 10–15 minutes.

## The challenge: Ticket Order

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

## Turn it in
1. In your `bpaPrep` repo make a folder `python_step10`.
2. Put `step10.py` and the `orders.txt` your program made in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 10 done*.

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
- [ ] Pushed to `bpaPrep/python_step10`
