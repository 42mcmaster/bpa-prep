# BPA Practice — Event 355 Python Programming
# Practice Task B: "Score Report" (Write, Read & Summarize a File)

**Format:** Individual production problem · ~90 minutes · one working program.
**Archetype:** collect N inputs → write one-per-line → read back → count / max / average / rate.
*Original practice problem modeled on the BPA Event 355 format. Not reproduced from BPA materials.*

---

## Scenario

A teacher wants a quick tool to record a set of test scores and print a summary. Your program
gathers scores from the user, saves them to a file, then reads the file back and reports on it.
**Judges may replace your `scores.txt` with their own**, so your analysis must work on *any* valid file.

## Required Program Behavior

1. Name the program **`ScoreReport`** (this file).
2. Ask the user **how many scores** they want to enter (a whole number, at least 1).
3. Read exactly that many scores, one at a time (each a whole number 0–100), and write them to
   **`scores.txt`**, one score per line.
4. **Read `scores.txt` back** and print a report with:
   - the **count** of scores,
   - the **highest** score,
   - the **lowest** score,
   - the **average**, formatted to **2 decimal places**,
   - the **pass rate** — the percent of scores that are 60 or above, to 2 decimals.
5. Put the analysis in a documented function, e.g. `summarize(scores)`, separate from the input code.
6. Open and close every file properly (`with open(...)`).
7. Include a comment with your **contestant number** at the top.

## Sample Run

```
How many scores? 4
Score 1: 95
Score 2: 58
Score 3: 72
Score 4: 88

--- Score Report ---
Count:     4
Highest:   95
Lowest:    58
Average:   78.25
Pass rate: 75.00%
```

## Assumptions
- The user enters valid whole numbers when prompted (no error handling required for input type,
  though a bounds check on the count is good practice).
- Every score in `scores.txt` is a whole number on its own line.

## Development Standards
- Consistent naming; every function documented (purpose, parameters, return).
- Optional `#SC1`, `#SC2`, … comment flags on gradable blocks.

See `TaskB_Rubric.md` for scoring.
