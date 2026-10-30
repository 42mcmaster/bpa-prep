# BPA 355 Python — Week 1 Practice: Club Quiz Tracker

**Time: 40 minutes. Individual. Contest conditions — local IDE only, no online interpreters, no AI.**

This task is a scaled-down version of the real regional format (the 2026 regional was a
"tournament manager" of exactly this shape: validated input → stored data → calculations →
formatted output → results file).

## Setup (do this exactly — it's graded)

1. Create a folder named with your Contestant ID (use your class period + initials for practice, e.g. `P2_RM`).
2. Inside it, create **`QuizTracker.py`** — all your code goes in this one file.
3. Put your Contestant ID as a **comment at the top** of the file.

## What the program does

Your robotics club took 3 quizzes and needs a score report.

**Requirement 1 — Member setup (15 pts)**
- Ask how many members are being entered. Must be a whole number from 1 to 6 —
  re-prompt on anything else (letters, decimals, 0, negatives, 7+).
- For each member, ask for their name. Names cannot be blank — re-prompt if empty.

**Requirement 2 — Score entry (20 pts)**
- For each member, ask for their score on each of the 3 quizzes.
- Each score must be a whole number from 0 to 100 — re-prompt on invalid input.
- Store everything in a structure you can loop over (list of lists, or a dictionary).

**Requirement 3 — Score report (25 pts)**
- Print a leaderboard: each member's name, total points, and average (2 decimal places).
- Format it in aligned columns with a header, like:

```
Name        Total   Average
--------    -----   -------
Jordan      265     88.33
Sam         241     80.33
```

**Requirement 4 — Analysis (20 pts)**
- Print the top scorer (highest total).
- Print the hardest quiz — the quiz (1, 2, or 3) with the LOWEST average across all members.
- Use a separate function for each of these.

**Requirement 5 — Results file (10 pts)**
- Write the leaderboard and the two analysis lines to **`quiz_results.txt`**.
- Include the current date and time at the top (use the `datetime` module).
- Open and close the file properly.

## Development standards (graded in Source Code Review — 10 pts)

- snake_case naming, consistent throughout.
- Major parts of the program in functions; each function has a comment/docstring with
  purpose, parameters, and return value.
- **Input / Processing / Output comments:** each major block gets a comment saying how data
  comes in, what the logic does, and where results go. This is the 2026 grading standard.

## Assumptions you may make

- The user is cooperative after a valid entry (no need to handle Ctrl-C, file permissions, etc.).
- Quiz count is always exactly 3.

**A starter file is provided (`QuizTracker_starter.py`). If it does not run when time is up,
the Program Execution section scores zero — always keep a runnable version.**
