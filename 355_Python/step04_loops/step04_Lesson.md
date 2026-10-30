# Step 04 — Loops (Python)

**What you'll build:** Number Guessing Game — the computer picks a secret number and the player guesses until they get it, then can play again.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Why loops](#why-loops)
- [The while loop](#the-while-loop)
- [Counters and running totals](#counters-and-running-totals)
- [A loop that asks again](#a-loop-that-asks-again)
- [The for loop and range](#the-for-loop-and-range)
- [Building a string in a loop](#building-a-string-in-a-loop)
- [break and continue](#break-and-continue)
- [Random numbers](#random-numbers)
- [A play again loop](#a-play-again-loop)
- [Testing a program that uses random numbers](#testing-a-program-that-uses-random-numbers)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Number Guessing Game](#the-challenge-number-guessing-game)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How a `while` loop repeats while a condition is `True`
- How to count with a loop counter and add up a running total
- How to keep asking until the user gives an answer in range
- How a `for` loop counts with `range()`
- How to build a string one piece at a time
- What `break` and `continue` do
- How to make random numbers with the `random` module
- How to put one loop inside another for a "play again" feature
- How to test a program whose answer is random

## Why loops

Without loops, printing the numbers 1 to 100 takes 100 `print` lines. With a loop it takes 2. A **loop** repeats a block of code. Every BPA program uses loops: for asking again after bad input, for going through every player, for running a menu until the user quits.

Python has two loops:

| Loop | Use it when... |
|---|---|
| `while` | you **don't know** how many times it will repeat ("keep asking until they get it right") |
| `for` | you **do know** how many times, or you want to go through every item in a list ("do this 5 times") |

## The while loop

A `while` loop works like an `if` that keeps repeating. It checks the condition; if `True`, it runs the block, then goes back up and checks again. When the condition is `False`, the loop ends and the program continues below it.

```python
# Processing and Output: count down from 3
countdown = 3
while countdown > 0:
    print(countdown)
    countdown = countdown - 1     # without this line the loop never ends
print("Go!")
```

It prints:

```text
3
2
1
Go!
```

Step by step: `countdown` is 3 → `3 > 0` is True → print 3, make it 2 → `2 > 0` True → print 2, make it 1 → print 1, make it 0 → `0 > 0` is False → loop ends → print `Go!`.

Same rules as `if`: colon at the end, block indented.

**The infinite loop.** If nothing inside the loop ever makes the condition `False`, the loop runs forever. In IDLE, press **Ctrl+C** in the Shell window to stop it.

## Counters and running totals

Two patterns you'll use in almost every program:

- A **counter** starts at 0 and goes up by 1 each time something happens: `count = count + 1`
- A **running total** starts at 0 and has a value added each time: `total = total + value`

Python also has a short way to write these: `count += 1` means the same as `count = count + 1`. Both are fine. These lessons mostly use the long way because it is easier to read.

<!-- input: 20|15|0 -->
```python
# Processing: a counter and a running total start at 0
count = 0
total = 0

# Input: keep reading amounts until the user types 0
amount = int(input("Amount (0 to stop): "))
while amount != 0:
    count = count + 1
    total = total + amount
    amount = int(input("Amount (0 to stop): "))

# Output
print(f"You entered {count} amounts. Total: {total}")
```

It prints (user typed `20`, `15`, `0`):

```text
Amount (0 to stop): 20
Amount (0 to stop): 15
Amount (0 to stop): 0
You entered 2 amounts. Total: 35
```

The `0` here is called a **sentinel** — a special value that means "stop." Notice the pattern: ask once **before** the loop, then ask again at the **bottom** of the loop. That way the condition always checks the newest answer.

## A loop that asks again

A `while` loop is how you keep asking until the user types something in range:

<!-- input: 9|0|4 -->
```python
# Input: ask for a team size from 1 to 5
team_size = int(input("Team size (1-5): "))

# Processing: while the answer is out of range, complain and ask again
while team_size < 1 or team_size > 5:
    print("Please enter 1 to 5.")
    team_size = int(input("Team size (1-5): "))

# Output: we only get here with a good answer
print(f"Team of {team_size} saved.")
```

It prints (user typed `9`, `0`, `4`):

```text
Team size (1-5): 9
Please enter 1 to 5.
Team size (1-5): 0
Please enter 1 to 5.
Team size (1-5): 4
Team of 4 saved.
```

This is the same `or` range check from Step 3, inside a `while` instead of an `if`. This exact pattern is in almost every BPA test. (Typing letters still crashes it. Step 10 fixes that.)

## The for loop and range

A `for` loop goes through a sequence of values, one at a time. `range()` makes a sequence of whole numbers.

```python
# Output: print 1 through 5
for number in range(1, 6):
    print(number)
```

It prints:

```text
1
2
3
4
5
```

The variable after `for` (`number` here) gets the next value each time through the loop. You don't have to add 1 to it yourself — the `for` loop does it.

| What you type | Numbers you get | Notes |
|---|---|---|
| `range(5)` | 0, 1, 2, 3, 4 | starts at 0; stops **before** 5; repeats 5 times |
| `range(1, 6)` | 1, 2, 3, 4, 5 | starts at 1; stops **before** 6 |
| `range(0, 10, 2)` | 0, 2, 4, 6, 8 | third number is the step |
| `range(5, 0, -1)` | 5, 4, 3, 2, 1 | counts down |

The "stops before" rule trips everyone up at first. `range(1, 6)` does **not** include 6. To count 1 to N, use `range(1, N + 1)`.

If you just want to repeat something N times and don't need the number, `for count in range(N):` is the usual way.

```python
# Output: a small times table using the loop variable
for row in range(1, 4):
    print(f"{row} x 7 = {row * 7}")
```

It prints:

```text
1 x 7 = 7
2 x 7 = 14
3 x 7 = 21
```

**Try it**
1. Use a `for` loop to print the even numbers from 2 to 20.
2. Ask the user for a number N, then print the total of 1 + 2 + ... + N using a `for` loop and a running total.

## Building a string in a loop

You can start with an empty string `""` and add to it each time through a loop. This is how you make a bar chart out of characters.

```python
# Processing: build a bar of # characters, one per point
points = 6
bar = ""
for count in range(points):
    bar = bar + "#"

# Output
print("Points: " + bar)
```

It prints:

```text
Points: ######
```

(Python can also do `"#" * points`, which you saw in Step 1. The challenge asks you to use a `for` loop on purpose — graders want to see that you can write the loop.)

## break and continue

Two words that change how a loop runs:

| What you type | What it does |
|---|---|
| `break` | Leave the loop right now. The program continues after the loop. |
| `continue` | Skip the rest of this pass through the loop and go back to the top (the condition is checked again). |

```python
# Processing: find the first number from 1 to 50 that divides evenly by 7 and by 4
for number in range(1, 51):
    if number % 7 == 0 and number % 4 == 0:
        print(f"Found it: {number}")
        break                         # stop looking
print("Search done.")

# Processing: print 1 to 6 but skip 4
for number in range(1, 7):
    if number == 4:
        continue                      # jump back to the top of the loop
    print(number, end=" ")            # end=" " prints a space instead of a new line
print()
```

It prints:

```text
Found it: 28
Search done.
1 2 3 5 6 
```

Use `break` and `continue` lightly. A loop with a clear condition is easier to read. But `continue` is handy in the challenge: when a guess is out of range, you print the message and `continue` so that guess isn't counted.

## Random numbers

Python's random number tools live in a **module** called `random`. A module is a file of ready-made code. To use it, put `import random` at the **top** of your program, then call its functions with `random.` in front.

| What you type | What it gives you |
|---|---|
| `random.randint(1, 6)` | a random whole number from 1 to 6, **including** both 1 and 6 |
| `random.choice(["a", "b", "c"])` | one random item from a list (lists are Step 6) |
| `random.random()` | a random decimal from 0.0 up to (not including) 1.0 |

Careful: `randint(1, 6)` **includes** the 6, but `range(1, 6)` does **not**. They work differently.

```python
import random

# Processing: roll two dice
die1 = random.randint(1, 6)
die2 = random.randint(1, 6)

# Output
print(f"You rolled {die1} and {die2} for a total of {die1 + die2}.")
```

Example output (yours will be different every run):

```
You rolled 4 and 2 for a total of 6.
```

## A play again loop

To let the user play more than once, put the whole game inside an **outer** `while` loop. The game's own loop goes **inside** it. That's called a **nested loop**.

<!-- input: y|y|n -->
```python
import random

rounds_played = 0
again = "y"

# Outer loop: one pass = one round
while again == "y" or again == "Y":
    rounds_played = rounds_played + 1

    # Processing: flip a coin 3 times and count heads (inner loop)
    heads = 0
    for flip in range(3):
        if random.randint(0, 1) == 1:
            heads = heads + 1

    # Output
    print(f"Round {rounds_played}: {heads} heads out of 3")

    # Input: ask at the BOTTOM of the outer loop
    again = input("Flip again? (y/n): ")

print(f"Rounds played: {rounds_played}")
```

Example output (the user typed `y`, `y`, `n`; the heads counts are random):

```
Round 1: 2 heads out of 3
Flip again? (y/n): y
Round 2: 1 heads out of 3
Flip again? (y/n): y
Round 3: 3 heads out of 3
Flip again? (y/n): n
Rounds played: 3
```

Notice: `again` is set to `"y"` **before** the loop so the first round always runs. Anything that must start fresh each round (like `heads = 0`) is set **inside** the outer loop. Anything that counts across all rounds (like `rounds_played`) is set **before** it.

## Testing a program that uses random numbers

How do you test a guessing game if you don't know the secret? Two ways:

1. **Print the secret while testing.** Right after picking it, add a line:
   ```python
   print("TEST - secret is", secret)   # REMOVE before turning in
   ```
   Now you know the answer and can test "too low," "too high," and "got it."
2. **Set it to a fixed number while testing.** Temporarily change `secret = random.randint(1, 100)` to `secret = 42`. Then the sample run below should match exactly.

**Remove the test line (or put the `randint` back) before you turn it in.** A guessing game that shows the answer or always picks 42 doesn't meet requirement 2.

## Common mistakes

**1. The loop never ends**
```python
count = 1
while count <= 5:
    print(count)          # MISTAKE - count never changes
```
No error message — it prints `1` forever. Press **Ctrl+C** to stop it. Fix: add `count = count + 1` inside the loop.

**2. Off by one with `range`**
`for number in range(1, 10)` prints 1 to **9**, not 10. Fix: `range(1, 11)`.

**3. Resetting a counter in the wrong place**
If `guesses = 0` is above the outer play-again loop, the second game keeps counting from where the first ended. Fix: reset per-game values **inside** the outer loop, at the start of each game.

**4. Forgetting `import random`**
Error: `NameError: name 'random' is not defined. Did you forget to import 'random'?`
Fix: `import random` on one of the first lines of the program.

**5. Asking for input before the loop but not inside it**
```python
guess = int(input("Your guess (1-100): "))
while guess != secret:
    print("Too low!")       # MISTAKE - never asks again, loops forever
```
Fix: the loop needs a new `input()` inside it, so the value can change.

**6. Counting an out-of-range guess**
If you add 1 to `guesses` before you check the range, `150` counts as a guess. Check the range first, and `continue` (or use `else`) so the counter isn't touched.

## How this shows up at BPA
- "Re-prompt on invalid input" is in every BPA Python test. That is a `while` loop. On the 2024 regional, out-of-range checks were worth 20 points each and the "forces the user to re-enter" part was graded every time.
- The 2026 regional asked for scores for **every** player on **each of 9 holes** — a `for` loop inside a `for` loop.
- The 2024 regional used random prices (`random.randint`) inside a range like $10–$20 inclusive. Know that `randint` includes both ends.
- Loops instead of repeated code are part of the "Program Design & Structure" score. Copy-pasting the same lines 9 times loses points.

## The challenge: Number Guessing Game

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
- Test with a fixed secret of 42 (see [Testing a program that uses random numbers](#testing-a-program-that-uses-random-numbers)), then put `randint` back.
- Test a game where you get it on the first guess. It should say `You got it in 1 guess!`.

## Turn it in
1. In your `bpaPrep` repo make a folder `python_step04`.
2. Put `step04.py` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 4 done*.

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
- [ ] Pushed to `bpaPrep/python_step04`
