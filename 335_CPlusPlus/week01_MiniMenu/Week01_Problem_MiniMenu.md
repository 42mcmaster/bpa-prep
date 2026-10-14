# BPA 335 C++ — Week 1 Practice: Mini Menu

**Time: 40 minutes. Individual. Contest conditions.**

This is a scaled-down version of the real regional format — the 2026 regional was a
5-option console menu where every option is its own function and every input is validated.
This practice uses the same structure with 3 options.

## Setup (graded)

1. Create a folder named with your Contestant ID (practice: class period + initials, e.g. `P2_RM`).
2. Create **`Week01_MiniMenu.cpp`** in it. Contestant ID as a **comment at the top**.

## What the program does

When it starts, the console shows a menu:

```
===== MINI MENU =====
1. Reverse a Sentence
2. Average Calculator
3. Exit
Choose an option (1-3):
```

The menu repeats after each option finishes, until the user exits. Any input that is not
1, 2, or 3 gets an error message and a re-prompt — the program never crashes.

**Option 1 — Reverse a Sentence (function `reverseSentence`, takes nothing, returns nothing)**
- Prompt the user for a sentence, then display it reversed — spaces and punctuation included.
- If the user enters nothing, prompt again for a valid sentence.

**Option 2 — Average Calculator (function `averageNumbers`, takes nothing, returns nothing)**
- Ask how many numbers to average: whole number 1 to 5 inclusive, re-prompt on letters,
  symbols, decimals, negatives, or out-of-range.
- Read that many decimal numbers (re-prompt on non-numeric input).
- Display the average to 2 decimal places.

**Option 3 — Exit (function `exitProgram`, takes nothing, RETURNS A BOOL)**
- Ask the user to confirm (y/n). Return `true` to end the program, `false` to go back to
  the menu. The menu loop uses this return value — same pattern as the 2026 regional.

## Development standards (graded in Source Code Review)

- Each menu option is its own function, named exactly as specified.
- **Input / Processing / Output comments** on every major block: where data comes from,
  what the logic does, where results go. This is the 2026 grading standard.
- Consistent naming convention; no repeated blocks that a loop or function could replace.

## Assumptions

- Console application only; no files this week.
- Use `getline` for sentence input so spaces are kept.

**If your program does not compile and run when time is up, the entire Program Execution
section scores zero. Keep a compiling version at all times — comment out broken work.**
