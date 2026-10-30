# Timed Build 1 Rubric — Rock Paper Scissors Match (100 points)

## Solution and Project (10 points)

| Item | Points |
|---|---|
| `RockPaperScissors.java` is in the turn-in folder (`java_timed01`; at BPA, the Contestant ID folder); class name matches the file | 5 |
| Contestant ID (name, for practice) in a comment at the top | 5 |
| **Subtotal** | **10** |

## Program Execution (50 points)

| Item | Points |
|---|---|
| **Program runs without errors. If it does not run, everything else in this section scores ZERO.** | 10 |
| Both starting prompts match exactly and accept input | 5 |
| Starting message is correct (blank line, name, wins needed) | 5 |
| Each round prints `Round N`; the computer's choice is random and can be 1, 2, or 3; both choices are printed in the exact format | 5 |
| Round result is correct for every combination (tie, player win, computer win), with the exact messages | 10 |
| An invalid choice (0, 4, -1, 9) prints `Please choose 1, 2, or 3.`, asks again, and does not count as a round | 5 |
| Score line is correct after every round | 5 |
| Match ends exactly when a player reaches the wins needed; the correct final message prints with the scores in the right order; `Rounds played` is correct | 5 |
| **Subtotal** | **50** |

## Source Code Review (40 points)

| Item | Points |
|---|---|
| Input / Processing / Output comments on the major blocks; `choiceToWord` has a purpose / parameter / return comment | 10 |
| **Variable names** (pick one): all 9 named exactly, with `xx` replaced by the ID digits (10) · all named exactly but `xx` not replaced (7) · some named as given (3) · none (0) | 10 |
| SC1 Scanner created | 2 |
| SC2 Random object created | 2 |
| SC3 computer's choice picked with the Random object, range 1-3 | 2 |
| SC4 `choiceToWord` uses a switch and returns the word | 4 |
| SC5 match while loop; ends by its condition (no `break`) | 4 |
| SC6 second while loop re-asks an invalid choice (no `break`) | 2 |
| SC7 if / else if / else decides the round and adds to the right win count | 2 |
| SC8 if / else prints the final message | 1 |
| SC9 Scanner closed | 1 |
| **Subtotal** | **40** |

Flags: the `SC` flag must be in a comment right next to the code. No flag, no credit. The code must work to get credit.

## Total: ______ / 100

**Grading notes (teacher):** Run it at least twice, with 1 and with 3 as the wins needed. Type an invalid choice (`4`, `0`) at least once. Because the computer is random, you can't match a sample run line for line - check that each round's result message is right for the two choices printed (Rock beats Scissors, Scissors beats Paper, Paper beats Rock). For the variable names, search the file for `xx` - any left over means the 7-point line at best. Partial credit within a row is fine.

Convert to the 5-point scale: 90–100 = 5, 80–89 = 4, 65–79 = 3, started but far off = 2, not turned in = 0.
