# 355 Python Programming

**Format:** One program, 90 minutes. You bring your own computer with one of these IDEs: IDLE, Visual Studio, Visual Studio Code, PyCharm. Graded on: does it run (if it does not run, the execution section scores zero), does it do what the spec says, and source code review (comments, naming, required functions). Put your contestant ID in a comment at the top. Use relative file paths only.
**Reference materials in the real test:** **Yes, including printed code.** You may bring printed reference materials and printed pre-written code. Nothing electronic, no online interpreters.

The 2026 regional was a tournament manager: validated input, nested lists, a leaderboard with totals and averages, a results file with the date and time, and documented functions.

## Start here

- **[Setup_Guide.md](Setup_Guide.md)** — install Python, run your first program in IDLE, read an error, push to `bpaPrep`.
- **Study guide:** [355_Python_Programming_Reference_Guide.md](355_Python_Programming_Reference_Guide.md) — print it.

## The 12 steps

Do the steps in order. Each step from Step 4 on has three files:

1. **Lesson** — a short walkthrough of the new skills, one piece at a time.
2. **Practice** — 10 to 13 short problems, plus one harder Challenge at the end. Some problems review earlier steps.
3. **Study Guide** — the full explanation with more examples and commented code. Print these for BPA.

| Step | Folder | What you learn | Practice challenge |
|---|---|---|---|
| 1 | [step01_outputAndComments](step01_outputAndComments/step01_Lesson.md) | `print`, escape sequences, comments, the header comment, running in IDLE, reading a syntax error | Event Welcome Screen |
| 2 | [step02_variablesAndInput](step02_variablesAndInput/step02_Lesson.md) | variables, data types, `input`, `int`/`float`, math, constants, money with 2 decimals | Snack Bar Order |
| 3 | [step03_ifStatements](step03_ifStatements/step03_Lesson.md) | comparisons, `if`/`elif`/`else`, `and`/`or`/`not`, nested if, comparing text | Grade Checker |
| 4 | [step04_loops](step04_loops/step04_Lesson.md) | `while` and `for` loops, `range`, counters, running totals, asking again until the answer is good | Class Score Summary |
| 5 | [step05_functions](step05_functions/step05_Lesson.md) | `def`, parameters, `return`, the function comment, `main()` | Pizza Order |
| 6 | [step06_listsAndArrays](step06_listsAndArrays/step06_Lesson.md) | lists, indexes, loops over lists, totals, highest and lowest by hand, sorting | Daily Steps Tracker |
| 7 | [step07_strings](step07_strings/step07_Lesson.md) | indexing and slicing, looping over characters, character checks, string methods, `split` | Password Check |
| 8 | [step08_nestedData](step08_nestedData/step08_Lesson.md) | lists of lists, nested loops, parallel lists, lined-up columns, dictionaries | Gradebook Table |
| 9 | [step09_files](step09_files/step09_Lesson.md) | reading and writing files, CSV, relative paths, missing files, date and time | Quiz Report From a File |
| 10 | [step10_errorHandling](step10_errorHandling/step10_Lesson.md) | `try`/`except`, asking until valid, reusable input functions | Field Trip Signup |
| 11 | [step11_menuProgram](step11_menuProgram/step11_Lesson.md) | menu loops, one function per option, classes, methods, lists of objects | Snack Stand Manager |
| 12 | [step12_timedBuilds](step12_timedBuilds/step12_Lesson.md) | how the event is scored, a 90-minute plan, self-grading | Timed Builds 1 and 2, plus three practice tasks |

## BPA builds

The **[bpaBuilds](bpaBuilds/)** folder has the bigger, BPA-style programs. Each one uses many skills together, like a real BPA test.

| Builds | Start them after | Includes |
|---|---|---|
| [Step 4 builds](bpaBuilds/build04_loops.md) | Step 7 | Number Guessing Game, Times Table Builder, Savings Goal Tracker, Rock Paper Scissors |
| [Step 5 builds](bpaBuilds/build05_functions.md) | Step 7 | Snack Bar with Functions, Temperature Converter, Class Grade Report, Phone Bill Calculator |
| [Step 6 builds](bpaBuilds/build06_listsAndArrays.md) | Step 7 | Score Stats, Weekly Temperature Log, Shopping List, Test Curve |
| [Step 7 builds](bpaBuilds/build07_strings.md) | Step 7 | Secret Message, Username Generator, Password Checker, Sentence Analyzer |
| [Step 8 builds](bpaBuilds/build08_nestedData.md) | Step 8 | Team Scoreboard, Step Challenge, Theater Seats, Vote Counter |
| [Step 9 builds](bpaBuilds/build09_files.md) | Step 9 | Scoreboard From a File, Honor Roll Report, Monthly Sales Report, Supply Reorder |
| [Step 10 builds](bpaBuilds/build10_errorHandling.md) | Step 10 | Ticket Order, Crash-Proof Calculator, Gym Membership Signup, Gradebook With a Messy File |
| [Step 11 builds](bpaBuilds/build11_menuProgram.md) | Step 11 | Club Manager, To-Do List, Library Checkout, Gradebook Manager |

## How to turn in

1. In your **`bpaPrep`** GitHub repo, make one folder per step: `python_step01`, `python_step02`, and so on. Builds go in one folder named `python_builds`. Timed builds go in `python_timed01` and `python_timed02`.
2. Name the files the way the step says (for example, `step04_p01.py` or `build04A.py`). Include any data files the program reads or writes.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## How to keep moving

- Do your **next** step. You keep track of which step you're on.
- Lesson first, then the practice. Use the study guide whenever you get stuck.
- After Step 7, start working on the builds alongside Steps 8–11.
- After Step 11, do the timed builds in Step 12 until the regional.
