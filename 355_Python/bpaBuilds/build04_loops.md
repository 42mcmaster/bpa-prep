# Builds for Step 04 — Loops (Python)

These are BPA-style programs that use the Step 4 skills together with everything before it. They are bigger than the practice problems, and closer to what the BPA test asks for.

**Do these after you finish Steps 1–7 (lessons and practice).** Use the [Step 4 Study Guide](../step04_loops/step04_StudyGuide.md) for help.

## Table of Contents
- [Build 4A: Number Guessing Game](#build-4a-number-guessing-game)
- [Build 4B: Times Table Builder](#build-4b-times-table-builder)
- [Build 4C: Savings Goal Tracker](#build-4c-savings-goal-tracker)
- [Build 4D: Rock Paper Scissors](#build-4d-rock-paper-scissors)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Build 4A: Number Guessing Game
The computer picks a secret number and the player keeps guessing. After each game, the player can play again.

**Requirements**
1. Header comment.
2. The computer picks a secret whole number from 1 to 100.
3. Keep asking `Your guess (1-100): ` until the player guesses it. Print `Too low!` or `Too high!` after each wrong guess.
4. If a guess is below 1 or above 100, print `Please guess between 1 and 100.` — this does **not** count as a guess.
5. When they get it, print `You got it in N guesses!` (use `guess` instead of `guesses` when N is 1).
6. Use a `for` loop to print a guess chart: `Guess chart: ` followed by one `*` per guess.
7. Ask `Play again? (y/n): `. `y` or `Y` starts a new game with a new secret number; anything else ends it.
8. When the player stops, print `Thanks for playing! Games played: N`.
9. Input / Processing / Output comments.

**Sample run** (the secret number was 42 here — yours will be random)
```
I'm thinking of a number from 1 to 100.
Your guess (1-100): 50
Too high!
Your guess (1-100): 150
Please guess between 1 and 100.
Your guess (1-100): 25
Too low!
Your guess (1-100): 42
You got it in 3 guesses!
Guess chart: ***
Play again? (y/n): n
Thanks for playing! Games played: 1
```
The first line, `I'm thinking of a number from 1 to 100.`, prints at the start of **every** game.

Typing letters instead of a number will crash it. That's expected for now — Step 10 fixes it.

**Hints**
- Structure: an outer `while` loop for "play again," and an inner `while` loop for guessing.
- The apostrophe in `I'm` is fine inside double quotes: `"I'm thinking..."`.
- Inside the inner loop: get the guess → if out of range, print the message and `continue` → otherwise add 1 to the guess counter → print too low / too high.
- Test with a fixed secret of 42 (see [Testing a program that uses random numbers](../step04_loops/step04_StudyGuide.md#random-numbers)), then put `randint` back.
- Test a game where you get it on the first guess. It should say `You got it in 1 guess!`.

---

## Build 4B: Times Table Builder
Write a program that prints times tables. The user can make as many tables as they want.

**Requirements**
1. Header comment.
2. Ask for a number with the prompt `Number (1-12): `. If it is below 1 or above 12, print `Please enter 1 to 12.` and ask again. Keep asking until it is good. Use a `while` loop.
3. Ask how many rows with the prompt `How many rows (1-20): `. Check it the same way, with the message `Please enter 1 to 20.`
4. Print `Times table for N`, then use a `for` loop with `range` to print one line per row: `7 x 1 = 7`, `7 x 2 = 14`, and so on.
5. While the `for` loop runs, keep:
   - a **running total** of all the answers
   - a **counter** of how many answers are even (use `%`)
6. After the table, print `Sum of all answers: N` and `Even answers: N of ROWS`.
7. Ask `Make another table? (y/n): `. `y` or `Y` makes another table. Anything else ends the program.
8. When the program ends, print `Tables made: N`.
9. Input / Processing / Output comments.

**Sample run**
```
Number (1-12): 7
How many rows (1-20): 5

Times table for 7
7 x 1 = 7
7 x 2 = 14
7 x 3 = 21
7 x 4 = 28
7 x 5 = 35
Sum of all answers: 105
Even answers: 2 of 5

Make another table? (y/n): y
Number (1-12): 15
Please enter 1 to 12.
Number (1-12): 0
Please enter 1 to 12.
Number (1-12): 4
How many rows (1-20): 3

Times table for 4
4 x 1 = 4
4 x 2 = 8
4 x 3 = 12
Sum of all answers: 24
Even answers: 3 of 3

Make another table? (y/n): n
Tables made: 2
```

**Hints**
- Structure: an outer `while` loop for "make another," and inside it two small `while` loops to check the input, then the `for` loop.
- To check input until it is good: ask once before the `while`, and ask again at the bottom of the `while`.
- `range(1, rows + 1)` counts from 1 up to and including `rows`.
- Set the total and the even counter back to 0 at the **start of each table**, not once at the top of the program. Otherwise the second table's totals include the first table.
- Put `print()` before `Times table for` and before `Make another table?` to get the blank lines.

**Test these too:** 1 row, 20 rows, number 12, and an odd number with only 1 row (`Even answers: 0 of 1`).

---

## Build 4C: Savings Goal Tracker
Write a program that tracks weekly deposits until a savings goal is reached.

**Requirements**
1. Header comment.
2. Ask for the saver's name and the savings goal (decimal).
3. Use a `while` loop that keeps going **while** the amount saved is less than the goal. Each time, ask `Week N deposit: ` where N is the week number.
4. If a deposit is 0 or less, print `Deposits must be more than $0.` and ask again for the **same** week. It does not count as a week. Use `continue`.
5. For good deposits, keep:
   - a **counter** of weeks
   - a **running total** of the amount saved
   - the **biggest** deposit so far (use an `if`)
6. After each good deposit, if the goal is not reached yet, print `  Saved so far: $X.XX ($Y.YY to go)` (2 spaces at the start).
7. When the goal is reached, print the results exactly as shown:
   - `You reached your goal in 1 week.` for one week, `in N weeks.` for more
   - the total saved, biggest deposit, and average deposit (total ÷ weeks)
   - `You went over your goal by $X.XX.` only if they saved more than the goal
8. Use a `for` loop to build a chart string with one `$` per week, and print `Weeks: ` followed by the chart.
9. Input / Processing / Output comments.

**Sample run 1**
```
Your name: Jordan
Savings goal: 100
Week 1 deposit: 25
  Saved so far: $25.00 ($75.00 to go)
Week 2 deposit: 0
Deposits must be more than $0.
Week 2 deposit: 30
  Saved so far: $55.00 ($45.00 to go)
Week 3 deposit: 20
  Saved so far: $75.00 ($25.00 to go)
Week 4 deposit: 40

Way to go, Jordan!
You reached your goal in 4 weeks.
Total saved:      $115.00
Biggest deposit:  $40.00
Average deposit:  $28.75
You went over your goal by $15.00.
Weeks: $$$$
```

**Sample run 2**
```
Your name: Mia
Savings goal: 50
Week 1 deposit: 60

Way to go, Mia!
You reached your goal in 1 week.
Total saved:      $60.00
Biggest deposit:  $60.00
Average deposit:  $60.00
You went over your goal by $10.00.
Weeks: $
```

**Hints**
- The prompt uses the **next** week number: `f"Week {weeks + 1} deposit: "`. Since `weeks` only goes up for good deposits, a bad deposit asks for the same week again.
- Start `biggest` at `0.0`. Any good deposit is bigger than that.
- After the loop ends, the goal is reached, so you do not need to check it again.
- The chart is like the guess chart in Build 4A: start with `chart = ""` and add `"$"` each time through a `for` loop.

**Test these too:** a goal reached exactly (no "went over" line), and a negative deposit like `-5`.

---

## Build 4D: Rock Paper Scissors
Play Rock Paper Scissors against the computer. The first player to win 3 rounds wins the match. The player can play more than one match.

**Requirements**
1. Header comment, and `import random` at the top.
2. Store the number of wins needed in a constant: `WINS_NEEDED = 3`.
3. At the start of each match, print `First to 3 wins!` (use the constant in an f-string).
4. Keep playing rounds **while** neither the player nor the computer has 3 wins. Use `and` in the `while` condition.
5. Each round, ask `Rock, paper, or scissors? (r/p/s): `. Accept capital or lowercase letters.
   - If the answer is not `r`, `p`, or `s`, print `Please type r, p, or s.` and ask again. It does **not** count as a round. Use `continue`.
6. The computer picks with `random.randint(1, 3)`: 1 is rock, 2 is paper, 3 is scissors.
7. Print `Round N: You picked X. Computer picked Y.` using the full words (rock, paper, scissors).
8. Decide the round and print one of these (2 spaces at the start), then the score:
   - `  Tie!`
   - `  You win the round!`
   - `  Computer wins the round.`
   - `  Score: You N - Computer N`

   Rock beats scissors, scissors beats paper, paper beats rock.
9. Count the ties. When the match ends, print one of these:
   - `You won the match in N rounds! (Ties: N)`
   - `The computer won the match in N rounds. (Ties: N)`
10. Ask `Play another match? (y/n): `, then print a blank line. `y` or `Y` starts a new match with all match scores back at 0.
11. When the player stops, print `Matches played: N` and `Matches won: N`.
12. Input / Processing / Output comments.

**Sample run** (the computer's picks are random, so yours will be different)
```
First to 3 wins!
Rock, paper, or scissors? (r/p/s): x
Please type r, p, or s.
Rock, paper, or scissors? (r/p/s): r
Round 1: You picked rock. Computer picked scissors.
  You win the round!
  Score: You 1 - Computer 0
Rock, paper, or scissors? (r/p/s): r
Round 2: You picked rock. Computer picked rock.
  Tie!
  Score: You 1 - Computer 0
Rock, paper, or scissors? (r/p/s): p
Round 3: You picked paper. Computer picked rock.
  You win the round!
  Score: You 2 - Computer 0
Rock, paper, or scissors? (r/p/s): r
Round 4: You picked rock. Computer picked scissors.
  You win the round!
  Score: You 3 - Computer 0
You won the match in 4 rounds! (Ties: 1)
Play another match? (y/n): y

First to 3 wins!
Rock, paper, or scissors? (r/p/s): r
Round 1: You picked rock. Computer picked paper.
  Computer wins the round.
  Score: You 0 - Computer 1
Rock, paper, or scissors? (r/p/s): s
Round 2: You picked scissors. Computer picked rock.
  Computer wins the round.
  Score: You 0 - Computer 2
Rock, paper, or scissors? (r/p/s): p
Round 3: You picked paper. Computer picked rock.
  You win the round!
  Score: You 1 - Computer 2
Rock, paper, or scissors? (r/p/s): s
Round 4: You picked scissors. Computer picked rock.
  Computer wins the round.
  Score: You 1 - Computer 3
The computer won the match in 4 rounds. (Ties: 0)
Play another match? (y/n): n

Matches played: 2
Matches won: 1
```

**Hints**
- Make the answer lowercase right away: `pick = input("...").lower()`.
- Checking for a bad answer: `if pick != "r" and pick != "p" and pick != "s":`
- Turn the computer's number into a letter with an `if`/`elif`/`else` chain. Then turn both letters into words for printing with two more chains.
- There are three ways for the player to win. Put each one in parentheses and join them with `or`:
  `(pick == "r" and computer == "s") or (...) or (...)`
- To test without randomness, put `random.seed(42)` right after `import random`. You should get the same computer picks as the sample run. **Take it out before you turn it in.**

---

## Turn it in
1. In your `bpaPrep` repo, make a folder named `python_builds` (one folder for all builds).
2. Save the builds as `build04A.py`, `build04B.py`, `build04C.py`, and `build04D.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run when the secret is 42
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Secret is random again (test line removed)
- [ ] Out-of-range guesses print the message and don't count
- [ ] `1 guess` vs `N guesses`
- [ ] Guess chart is built with a `for` loop
- [ ] `y` and `Y` both play again; the game count is right
- [ ] Pushed to `bpaPrep/python_builds`
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] I tested the extra inputs listed under Builds 4B and 4C
- [ ] Each program uses at least one `while` loop and one `for` loop (Build 4D only needs `while`)
- [ ] Input / Processing / Output comments in each file
- [ ] `random.seed` is removed from Build 4D
