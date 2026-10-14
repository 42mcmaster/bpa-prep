# Week 1 Rubric — Club Quiz Tracker (100 points)

| Category | Description | Points |
|---|---|---|
| Project Setup | Folder named with Contestant ID; file named `QuizTracker.py`; ID comment at top | 5 |
| **Program Execution** | **Runs without errors. If it does not run, everything below this line in the Execution section scores ZERO.** | 10 |
| Member setup | Count validated (1–6, whole numbers only); blank names rejected | 10 |
| Score entry | All scores validated (0–100 int, re-prompt); stored in a loopable structure | 15 |
| Leaderboard | Totals and averages correct; averages to 2 decimals; aligned columns with header | 20 |
| Analysis | Top scorer correct; hardest quiz correct; each in its own function | 15 |
| Results file | `quiz_results.txt` written with date/time, leaderboard, analysis; file closed properly | 10 |
| **Source Code Review** | snake_case throughout; functions documented (purpose/params/return); Input-Processing-Output comments on major blocks | 10 |
| Design | No large repeated blocks — loops/functions instead | 5 |

**Grading notes (teacher):** run it twice — once with clean input, once feeding it junk
(letters for counts, 101 for a score, blank name). Validation points require the re-prompt
loop to actually work. Partial credit within each row is fine.
