# Step 12 — Timed Builds (Python)

**What you'll do:** practice the real event — build a whole program from a printed problem in 90 minutes, then grade it with the rubric.
**Time:** one class period per timed build. Do as many as you can before the regional.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [How the BPA Python event works](#how-the-bpa-python-event-works)
- [How it is scored](#how-it-is-scored)
- [Rules that cost people points](#rules-that-cost-people-points)
- [A plan for the 90 minutes](#a-plan-for-the-90-minutes)
- [Build a running skeleton first](#build-a-running-skeleton-first)
- [The SC comment flags](#the-sc-comment-flags)
- [What graders look for](#what-graders-look-for)
- [What to print and bring](#what-to-print-and-bring)
- [How to practice](#how-to-practice)
- [The timed builds in this folder](#the-timed-builds-in-this-folder)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What happens at the BPA 355 Python Programming event, start to finish
- How the program is scored, and the rules that cost the most points
- A minute-by-minute plan for 90 minutes
- How to keep a program that **always runs**, even when it's unfinished
- What graders look for in source code review
- How to practice on your own and grade yourself

## How the BPA Python event works

- **90 minutes**, one program, by yourself.
- You get a printed test booklet with the problem, the requirements, and the rubric (how many points each part is worth). **Read the rubric.** It tells you exactly what's being graded.
- You use your own computer with a **local** Python IDE: IDLE, VS Code, PyCharm, or Visual Studio. **No online interpreters.** No internet, no AI.
- **Printed reference materials and printed code are allowed.** Electronic files are not, and old BPA tests are not allowed in the room.
- You make a folder named with your **Contestant ID**, put the program in it with the **exact file name** the test gives (for example `RegionalPython.py`), and turn the folder in on a flash drive or as a zip upload.
- Your Contestant ID goes in a comment at the top of the file. **Your name and school must not appear anywhere.**

## How it is scored

Past Python regionals have been scored in three parts:

| Part | What it checks |
|---|---|
| **Solution and project** | The folder is named with your Contestant ID; the file is named exactly right and is in that folder. |
| **Program execution** | The grader runs your program and tries each requirement — good input, bad input, letters, out-of-range numbers. |
| **Source code review** | The grader reads your code: comments (including Input / Processing / Output), naming, functions, data structures, try/except, classes, and file handling. |

**If the program does not run, the execution section scores zero.** Not "partial credit for what you wrote" — zero for that whole section. Graders will not fix or debug your code. A program that runs and does half the requirements beats a program that would do everything but has one syntax error.

## Rules that cost people points

- **Name on the work.** Contestant ID only.
- **Wrong file name or folder name.** `regionalpython.py` is not `RegionalPython.py`.
- **Full file paths.** `open("C:\\Users\\me\\Desktop\\data.csv")` fails on the grader's computer. Use `open("data.csv")` — "the flash drive letter may change."
- **Program doesn't run.** See above. Save a running version often.
- **Output that doesn't match.** When the test shows sample output, match it — spacing, capital letters, `$` and 2 decimals.
- **A crash on bad input.** Graders type letters into number questions on purpose. On the 2024 regional, try/except and re-prompting were worth over 100 points.
- **Missing files.** If the program writes a results file, it must be created with the exact name. Turn in the whole folder.

## A plan for the 90 minutes

| Time | What to do |
|---|---|
| **0:00–0:10** | **Read everything.** The whole problem, every requirement, and the rubric. Circle exact prompts, file names, and formats. Note which parts are worth the most points. Make the folder and the file with the exact names. Put your Contestant ID comment at the top. |
| **0:10–0:25** | **Running skeleton.** Copy in your printed input functions (`get_text`, `get_int`, `get_yes_no`). Write the class (if there is one), empty functions for every part, and `main()` — a menu loop if it's a menu program. **Run it.** It should run with no errors even though it does nothing yet. |
| **0:25–1:10** | **Fill in requirements, easiest and highest-points first.** Finish one function, run it, then go to the next. Write the comments **as you go** (function comment, Input / Processing / Output, `#SC` flags). Every 10–15 minutes, make sure it still runs. |
| **1:10–1:20** | **Harder or lower-point parts.** If something isn't working, comment it out so the rest runs. A working program with one missing feature scores better than a broken one. |
| **1:20–1:30** | **Stop adding.** Run the whole program once with good input and once with junk input. Check the output file exists and has the right name. Check the Contestant ID comment, no name anywhere, and the `#SC` flags. Save. Copy the **whole folder** to the flash drive (or zip and upload). |

Write the start time on your booklet and the times for 0:25, 1:10, and 1:20 next to it.

## Build a running skeleton first

A skeleton is the whole program's structure with nothing filled in. It runs, so you always have something that scores execution points. Here's what one looks like for a menu program:

```python
# Contestant ID: 12-3456-7890
# Program: (name from the test)

import datetime


def get_int(prompt, low, high):
    """Purpose: ask until the answer is a whole number from low to high.
    Parameters: prompt (str), low (int), high (int)
    Returns: the number (int)
    """
    while True:
        answer = input(prompt)
        # try/except catches ValueError: int() fails on letters, decimals, blanks
        try:
            number = int(answer)
            if number >= low and number <= high:
                return number
        except ValueError:
            pass
        print(f"Please enter a whole number from {low} to {high}.")


def option_one(data):
    """Purpose: (fill in). Parameters: data (list). Returns: nothing"""
    print("TODO option 1")


def option_two(data):
    """Purpose: (fill in). Parameters: data (list). Returns: nothing"""
    print("TODO option 2")


def main():
    """Purpose: run the menu until Quit. Parameters: none. Returns: nothing"""
    data = []
    choice = 0
    while choice != 3:
        print()
        print("1. Option one")
        print("2. Option two")
        print("3. Quit")
        choice = get_int("Choose an option (1-3): ", 1, 3)
        if choice == 1:
            option_one(data)
        elif choice == 2:
            option_two(data)
    print("Goodbye!")


if __name__ == "__main__":
    main()
```

From here, you replace one `print("TODO ...")` at a time with real code, running after each.

**Debugging under time pressure:** if something breaks and you can't see why in 5 minutes, put a `#` in front of the broken lines, add `print("TODO")`, make sure the program runs, and move on. Come back if there's time.

## The SC comment flags

Some BPA tests (the 2024 Python regional, for one) list the graded parts of the code as **SC1, SC2, SC3...** in the rubric. You must put a comment with that flag right next to the code for each one, like:

```python
#SC1 constructor with the three required parameters
def __init__(self, name, price, quantity):
    ...
```

**No flag, no credit** — even if the code is right. If the test uses flags, add them as you write each part, not at the end. Timed Build 2 in this folder uses flags so you can practice.

## What graders look for

Use this as your final-ten-minutes checklist:

- [ ] Contestant ID in a comment at the top; no name or school anywhere
- [ ] Folder and file named exactly as told
- [ ] Program runs from start to finish with no errors
- [ ] Every prompt and output line matches the test's wording and format
- [ ] Every number input rejects letters, decimals, blanks, and out-of-range values **and asks again** (no crash)
- [ ] Text inputs that can't be blank are checked
- [ ] Money shows as `$` with 2 decimal places; averages rounded as the test says
- [ ] Each major part is its own function
- [ ] **Every** function has a comment: purpose, parameters, return value
- [ ] Input / Processing / Output comments on each major block
- [ ] snake_case names, used the same way throughout
- [ ] A data structure (list, list of lists, dictionary, or list of objects) where the test asks for one
- [ ] Class: constructor with the required parameters, required methods (if the test has a class)
- [ ] Files: relative path, exact file name, opened with `with` (closed properly), date and time if asked
- [ ] `#SC` flags, if the test uses them
- [ ] Loops instead of repeated code

## What to print and bring

Printed materials are allowed. Bring:
1. The [355 Python reference guide](../355_Python_Programming_Reference_Guide.md).
2. Your own `get_text`, `get_int`, and `get_yes_no` from Step 10, with their comments.
3. Your Step 11 Club Manager — it has a class, a menu, file loading and saving, a leaderboard, and a search. Most of a regional is some version of these parts.
4. Your Step 9 file reading and date/time code.
5. The [What graders look for](#what-graders-look-for) checklist above.

Practice **typing from your printouts** during timed builds, so you know where everything is on the page.

## How to practice

1. Print the problem file and the rubric. Don't look at them on screen.
2. Close the browser. No Google, no AI, no old code on the computer — only your printouts.
3. Set a **90-minute timer**. Follow the [plan](#a-plan-for-the-90-minutes).
4. When the timer ends, stop. Even if you're not done.
5. **Grade yourself with the rubric.** Run it with good input and with junk. Be honest. Write your score at the top of the rubric.
6. Look at what you lost points on. That's what to practice next time.

Your teacher will also hand out **printed** past BPA regional tests for more practice. Those stay printed and stay in class — old tests can't be brought to the event.

## The timed builds in this folder

| Build | Folder | What it practices | Turn-in folder |
|---|---|---|---|
| Timed Build 1 — Club Quiz Tracker | [timedBuild01_QuizTracker](timedBuild01_QuizTracker/timedBuild01.md) | validated input, a dictionary or list of lists, a leaderboard with averages, analysis functions, a results file with the date | `python_timed01` |
| Timed Build 2 — Food Truck Sales | [timedBuild02_FoodTruck](timedBuild02_FoodTruck/timedBuild02.md) | a class, a CSV file, a 6-option menu, a formatted table with totals, search, a dated report, `#SC` flags | `python_timed02` |
| Practice Task A — Secret Message | [practice/TaskA_SecretMessage](practice/TaskA_SecretMessage/TaskA_SecretMessage_Problem.md) | string and cipher work, file read and write | (see the task) |
| Practice Task B — Score Report | [practice/TaskB_ScoreReport](practice/TaskB_ScoreReport/TaskB_ScoreReport_Problem.md) | write, read, and summarize a data file | (see the task) |
| Practice Task C — Ticket Order | [practice/TaskC_TicketOrder](practice/TaskC_TicketOrder/TaskC_TicketOrder_Problem.md) | a class with `__str__`, random prices, try/except validation | (see the task) |

Each build has its own instructions file (problem, starter, rubric). Do Timed Build 1 and 2 in order; the practice tasks can be done any time after Step 11. More about the practice tasks: [practice/README.md](practice/README.md).

## Turn it in
1. In your `bpaPrep` repo make a folder for the build: `python_timed01`, `python_timed02` (or `python_practiceA`, `python_practiceB`, `python_practiceC` for the practice tasks).
2. Put your `.py` file, any data file it reads, and any file it writes in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python timed build 2 done* (or whichever one), with your self-graded rubric score.

## Checklist
- [ ] Program runs with no errors
- [ ] Every requirement in the problem file attempted
- [ ] Header comment with your name (Contestant ID at the real event), date, program, description
- [ ] Input / Processing / Output comments
- [ ] Every function has a Purpose / Parameters / Returns comment
- [ ] `#SC` flags where the rubric asks for them
- [ ] Graded yourself with the rubric
- [ ] Pushed to `bpaPrep/python_timed01` (or `_timed02`, `_practiceA`...)
