# Task B — "Score Report" — Grading Rubric (100 pts)

*Modeled on the BPA Event 355 three-section rubric.*

## Section 1 — Solution & Project (10 pts)
- [ ] Program present and named `ScoreReport` (5)
- [ ] Contestant-number comment at the top (5)

## Section 2 — Program Execution (45 pts)  — *hard gate: if it does not run, this section = 0*
- [ ] Runs from the drive without editing (8)
- [ ] Asks how many scores and reads exactly that many (8)
- [ ] Writes all scores to `scores.txt`, one per line (8)
- [ ] Reads `scores.txt` back and prints the report (7)
- [ ] Count, highest, lowest correct (7)
- [ ] Average and pass rate correct, each to 2 decimals (7)

## Section 3 — Source Code Review (45 pts)
- [ ] Analysis in a separate, documented `summarize()`-style function (10)
- [ ] Works on an arbitrary `scores.txt` (not hard-coded to the sample) (10)
- [ ] Files opened and closed properly (`with open`) (8)
- [ ] Average uses real division and is formatted to 2 dp (6)
- [ ] Every function documented (purpose, parameters, return) (6)
- [ ] Consistent naming convention (5)

**Teacher check:** with the provided `scores.txt` (95, 58, 72, 88):
count 4, highest 95, lowest 58, average 78.25, pass rate 75.00%.
