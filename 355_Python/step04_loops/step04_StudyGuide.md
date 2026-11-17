# Step 04 Study Guide — Loops (Python)

This guide covers everything in the [Step 4 lesson](step04_Lesson.md), with more examples and more explanation. Every example has comments that explain each line, and shows exactly what it prints.

**Print this.** BPA lets you bring printed notes and printed code into the Python event.

## Table of Contents
- [What a loop is](#what-a-loop-is)
- [while or for: which one?](#while-or-for-which-one)
- [The while loop](#the-while-loop)
- [Tracing a loop by hand](#tracing-a-loop-by-hand)
- [Counters](#counters)
- [Running totals](#running-totals)
- [Sentinel loops: ask before and inside](#sentinel-loops-ask-before-and-inside)
- [Ask again until the answer is good](#ask-again-until-the-answer-is-good)
- [An if inside a loop](#an-if-inside-a-loop)
- [The for loop and range](#the-for-loop-and-range)
- [The range table](#the-range-table)
- [Using the loop variable](#using-the-loop-variable)
- [Repeat a set number of times](#repeat-a-set-number-of-times)
- [Averages](#averages)
- [Building a string in a loop](#building-a-string-in-a-loop)
- [break and continue](#break-and-continue)
- [while True with break](#while-true-with-break)
- [A loop inside a loop](#a-loop-inside-a-loop)
- [Random numbers](#random-numbers)
- [A play again loop](#a-play-again-loop)
- [Common mistakes](#common-mistakes)
- [Quick reference](#quick-reference)

---

## What a loop is

A **loop** repeats a block of code. Without a loop, printing 1 to 100 takes 100 `print` lines. With a loop, it takes 2:

```python
for number in range(1, 101):    # number will be 1, then 2, then 3 ... up to 100
    print(number)               # this indented line runs once for each number
```

Every loop has the same two parts:

1. **The loop line**, which ends with a colon `:`
2. **The block**: the indented lines underneath. These are the lines that repeat.

The first line that is **not** indented is outside the loop. It runs once, after the loop is finished.

```python
for number in range(1, 4):
    print(number)       # inside the loop: runs 3 times
print("Done")           # outside the loop: runs once, at the end
```

Prints:
```
1
2
3
Done
```

---

## while or for: which one?

| Use this | When | Example |
|---|---|---|
| `for` | you **know** how many times the loop should run | "Print 1 to 10." "Ask for 5 scores." |
| `while` | you **don't know** how many times. It depends on what the user types. | "Keep asking until they type the password." "Stop when they type 0." |

Many problems can be done either way. Problems 1 and 2 in the practice set print the same thing, one with each kind of loop.

---

## The while loop

A `while` loop is like an `if` that keeps repeating. Python checks the condition:
- If it is `True`, Python runs the block, then goes back up and checks again.
- If it is `False`, the loop ends and the program moves on.

```python
number = 1                  # 1. start the variable BEFORE the loop

while number <= 10:         # 2. the condition: keep going while number is 10 or less
    print(number)           #    do the work
    number = number + 1     # 3. change the variable INSIDE the loop

print("Done")               # runs once, after the loop ends
```

Prints `1` through `10`, then `Done`.

A `while` loop that counts always needs these three things:
1. **Start** the variable before the loop.
2. **Check** it in the condition.
3. **Change** it inside the loop.

**The infinite loop.** If nothing inside the loop ever makes the condition `False`, the loop runs forever. There is no error message. It just keeps going. In IDLE, press **Ctrl+C** to stop it, then find the missing "change" line.

---

## Tracing a loop by hand

Tracing means walking through the loop one pass at a time and writing down what each variable holds. It's the best way to find a bug.

```python
countdown = 3
while countdown > 0:
    print(countdown)
    countdown = countdown - 1
print("Go!")
```

| Pass | `countdown` at the top | `countdown > 0`? | Prints | `countdown` after |
|---|---|---|---|---|
| 1 | 3 | True | 3 | 2 |
| 2 | 2 | True | 2 | 1 |
| 3 | 1 | True | 1 | 0 |
| — | 0 | **False**, loop ends | Go! | — |

Prints:
```
3
2
1
Go!
```

---

## Counters

A **counter** counts how many times something happens.

- Start it at `0` **before** the loop.
- Add 1 **inside** the loop: `count = count + 1`

```python
count = 0                           # nothing counted yet

for number in range(1, 21):         # number goes 1 to 20
    if number % 3 == 0:             # % 3 == 0 means it divides evenly by 3
        count = count + 1           # found one, so add 1 to the counter

print(f"Numbers from 1 to 20 that divide by 3: {count}")
```

Prints:
```
Numbers from 1 to 20 that divide by 3: 6
```

(Those are 3, 6, 9, 12, 15, 18.)

**Short way:** `count += 1` means the same as `count = count + 1`. Either is fine.

---

## Running totals

A **running total** (also called an accumulator) adds up values as the loop goes.

- Start it at `0` **before** the loop.
- Add the new value **inside** the loop: `total = total + value`
- Print it **after** the loop.

```python
total = 0                           # nothing added yet

for number in range(1, 101):        # number goes 1, 2, 3 ... 100
    total = total + number          # add this number to the total

print(f"The total is {total}")      # not indented, so it prints only once
```

Prints:
```
The total is 5050
```

**Watch out:** if the `print` line is indented, it is inside the loop and prints 100 times.

**Watch out:** if `total = 0` is inside the loop, the total goes back to 0 every pass, and you only get the last number.

---

## Sentinel loops: ask before and inside

A **sentinel** is a special value that means "stop," like `0` or `q`. Use a `while` loop when the user decides when to stop.

The pattern: ask **once before** the loop, then ask **again at the bottom** of the loop.

```python
total = 0

# Input: the first question, BEFORE the loop
number = int(input("Enter a number (0 to stop): "))

while number != 0:                  # stop when the user types 0
    total = total + number          # use the number
    # Input: ask again, at the BOTTOM of the loop
    number = int(input("Enter a number (0 to stop): "))

print(f"The total is {total}")
```

Prints (user typed 5, 12, 3, 0):
```
Enter a number (0 to stop): 5
Enter a number (0 to stop): 12
Enter a number (0 to stop): 3
Enter a number (0 to stop): 0
The total is 20
```

**Why ask twice?**
- The question **before** the loop gives the `while` line something to check the first time.
- The question **inside** the loop gets the next number, so the condition can change. Without it, the loop runs forever with the same number.

**If the first answer is the sentinel**, the loop never runs at all. That is correct: the total is 0.

A text sentinel works the same way:

```python
password = input("Enter the password: ")       # ask before
while password != "python123":                 # stop when it's right
    print("Try again!")
    password = input("Enter the password: ")   # ask again
print("Access granted!")
```

---

## Ask again until the answer is good

This is the most important loop for BPA. Every BPA Python test says the program must "force the user to re-enter" bad input. It's the sentinel pattern, with a range check from Step 3 as the condition.

```python
# Input: ask once
rating = int(input("Rate the movie (1-10): "))

# Processing: while the answer is OUT of range, complain and ask again
while rating < 1 or rating > 10:
    print("Please enter 1 to 10.")
    rating = int(input("Rate the movie (1-10): "))

# Output: the program only gets here with a good answer
print(f"Your rating: {rating}")
```

Prints (user typed 15, 0, 8):
```
Rate the movie (1-10): 15
Please enter 1 to 10.
Rate the movie (1-10): 0
Please enter 1 to 10.
Rate the movie (1-10): 8
Your rating: 8
```

**Read the condition as "while it's bad."** `rating < 1 or rating > 10` is True when the rating is bad. When the rating is good, the condition is False and the loop ends.

Use `or`, not `and`. A number can't be below 1 **and** above 10 at the same time, so `and` is never True and the loop never catches anything.

(Typing letters still crashes the program. Step 10 fixes that.)

---

## An if inside a loop

You can put any code inside a loop, including `if` statements. The `if` runs once on every pass.

```python
number = int(input("Enter a number (0 to stop): "))

while number != 0:
    if number < 0:                  # the if is indented once (inside the loop)
        print("Negative")           # its block is indented twice
    else:
        print("Positive")           # it isn't 0 (the loop stopped that) and isn't negative
    number = int(input("Enter a number (0 to stop): "))

print("All done.")
```

Prints (user typed 8, -3, 15, 0):
```
Enter a number (0 to stop): 8
Positive
Enter a number (0 to stop): -3
Negative
Enter a number (0 to stop): 15
Positive
Enter a number (0 to stop): 0
All done.
```

**Watch the indents.** The `if` and the `else` line up with each other. The ask-again line lines up with the `if`, so it is inside the loop but not inside the `else`.

---

## The for loop and range

A `for` loop goes through a list of values, one at a time. `range()` makes a list of whole numbers.

```python
for number in range(1, 6):      # number will be 1, 2, 3, 4, 5
    print(number)
```

Prints:
```
1
2
3
4
5
```

The variable after `for` (here, `number`) gets the next value each time. **The `for` loop changes it for you.** Don't add 1 to it yourself.

**The "stops before" rule.** `range(1, 6)` does **not** include 6. It stops right before the second number. To count from 1 to N, use `range(1, N + 1)`:

```python
last = int(input("Count up to: "))

for number in range(1, last + 1):   # + 1 so that last is included
    print(number)
```

Prints (user typed 4):
```
Count up to: 4
1
2
3
4
```

---

## The range table

| What you type | Numbers you get | How it works |
|---|---|---|
| `range(5)` | 0, 1, 2, 3, 4 | one number: starts at 0, stops before 5, runs 5 times |
| `range(1, 6)` | 1, 2, 3, 4, 5 | start, stop: starts at 1, stops before 6 |
| `range(1, 11)` | 1 to 10 | the usual way to count 1 to 10 |
| `range(2, 21, 2)` | 2, 4, 6 ... 20 | start, stop, step: counts by 2s |
| `range(0, 101, 10)` | 0, 10, 20 ... 100 | counts by 10s |
| `range(5, 0, -1)` | 5, 4, 3, 2, 1 | a negative step counts down; stops before 0 |
| `range(10, 0, -2)` | 10, 8, 6, 4, 2 | counts down by 2s |

Countdown example:

```python
start = int(input("Count down from: "))

for number in range(start, 0, -1):  # from start down to 1 (stops before 0)
    print(number)

print("Liftoff!")                   # after the loop
```

Prints (user typed 5):
```
Count down from: 5
5
4
3
2
1
Liftoff!
```

---

## Using the loop variable

The loop variable can be used inside the loop, for math or in an f-string.

```python
number = int(input("Enter a number: "))     # the user's number: don't change it

for i in range(1, 11):                      # i goes 1 to 10
    print(f"{number} x {i} = {number * i}") # number stays the same, i changes
```

Prints (user typed 7):
```
Enter a number: 7
7 x 1 = 7
7 x 2 = 14
...
7 x 10 = 70
```

Two variables, two jobs:
- `number` holds the user's number. It stays the same the whole time.
- `i` controls the loop. It goes up by 1 each pass.

---

## Repeat a set number of times

Sometimes you just want something to happen a certain number of times. Use `range(times)`. The loop variable is required, but you don't have to use it.

```python
times = int(input("How many cheers? "))

for count in range(times):      # runs "times" times
    print("Go team!")           # count is never used, and that's fine
```

Prints (user typed 3):
```
How many cheers? 3
Go team!
Go team!
Go team!
```

This is how you ask for a set number of inputs. **The `input()` goes inside the loop**, so it asks once per pass:

```python
total = 0

for count in range(5):                      # ask 5 times
    score = int(input("Test score: "))      # INSIDE the loop: a new score each time
    total = total + score                   # add it to the running total

print(f"Total: {total}")
```

You may see `for _ in range(5):` in other code. The `_` means "I'm not using this variable." It works the same.

---

## Averages

An average is the total divided by how many there are. **Work it out after the loop**, once every value has been added.

```python
total = 0

for count in range(5):
    score = int(input("Test score: "))
    total = total + score

# Processing: AFTER the loop, so all 5 scores are in the total
average = total / 5

print(f"Average: {average:.1f}")            # 1 decimal place
```

Prints (user typed 90, 85, 77, 100, 69):
```
Test score: 90
Test score: 85
Test score: 77
Test score: 100
Test score: 69
Average: 84.2
```

For a sentinel loop, you don't know how many ahead of time, so keep a counter too and divide by it:

```python
count = 0
total = 0

score = int(input("Score (-1 to stop): "))
while score != -1:
    count = count + 1
    total = total + score
    score = int(input("Score (-1 to stop): "))

if count > 0:                       # don't divide by 0 if no scores were entered
    print(f"Average: {total / count:.1f}")
else:
    print("No scores entered.")
```

---

## Building a string in a loop

Start with an empty string `""` and add to it each pass. This is how you make a bar chart out of characters.

```python
name = input("Player name: ")
points = int(input("Points scored: "))

bar = ""                        # empty string to start
for count in range(points):     # one pass per point
    bar = bar + "*"             # add one star each pass

print(f"{name}: {bar}")
```

Prints (user typed Maya, 7):
```
Player name: Maya
Points scored: 7
Maya: *******
```

Python can also do `"*" * points` (from Step 1). BPA tasks sometimes ask for the loop on purpose, to see that you can write it.

---

## break and continue

> **Not in the lesson or practice.** This part is for the [Step 4 builds](../bpaBuilds/build04_loops.md), like the Number Guessing Game, which come after Step 7.


| Word | What it does |
|---|---|
| `break` | Leave the loop right now. The program continues after the loop. |
| `continue` | Skip the rest of this pass and go back to the top of the loop. |

```python
# break: stop at the first number that divides by both 7 and 4
for number in range(1, 51):
    if number % 7 == 0 and number % 4 == 0:
        print(f"Found it: {number}")
        break                   # done looking, leave the loop
print("Search done.")
```

Prints:
```
Found it: 28
Search done.
```

```python
# continue: print 1 to 6, but skip 4
for number in range(1, 7):
    if number == 4:
        continue                # skip the print below, go to the next number
    print(number)
```

Prints `1`, `2`, `3`, `5`, `6`, each on its own line.

Use these only when they make the code simpler. A loop with a clear condition is easier to read.

---

## while True with break

> **Not in the lesson or practice.** This part is for the [Step 4 builds](../bpaBuilds/build04_loops.md), like the Number Guessing Game, which come after Step 7.


`while True:` makes a loop that would run forever. Inside it, `break` is the only way out. Some people find this easier for "keep asking" loops, because the question is only written once.

```python
PASSWORD = "python123"

while True:                                 # repeat until a break
    entry = input("Enter the password: ")   # asked only once, at the top
    if entry == PASSWORD:
        print("Access granted!")
        break                               # right answer: leave the loop
    print("Try again!")                     # wrong answer: loop back to the top
```

This prints the same thing as the sentinel version. Both are fine. Use whichever one you understand better, but make sure every `while True:` has a `break` that can actually run.

---

## A loop inside a loop

A loop can go inside another loop. This is called a **nested loop**. The inner loop runs all the way through on **every** pass of the outer loop.

The most common BPA use: a `for` loop goes through each student, and a `while` loop inside it checks that student's score.

```python
total = 0

for student in range(1, 4):                         # outer loop: students 1, 2, 3
    score = int(input(f"Score for student {student}: "))
    while score < 0 or score > 100:                 # inner loop: check this score
        print("Scores must be 0 to 100.")
        score = int(input(f"Score for student {student}: "))
    total = total + score                           # only add a good score

print(f"Total: {total}")
```

Prints (user typed 88, 105, 72, 90):
```
Score for student 1: 88
Score for student 2: 105
Scores must be 0 to 100.
Score for student 2: 72
Score for student 3: 90
Total: 250
```

Notice that student 2 is asked again. The `for` loop doesn't move on to student 3 until the `while` loop gets a good score.

**Indent levels:**
- `for` line: no indent
- the `while` line and the `total` line: 1 indent (inside the `for`)
- the lines inside the `while`: 2 indents

---

## Random numbers

> **Not in the lesson or practice.** This part is for the [Step 4 builds](../bpaBuilds/build04_loops.md), like the Number Guessing Game, which come after Step 7.


Python's random number tools are in a **module** called `random`. Put `import random` at the **top** of the program.

| What you type | What it gives you |
|---|---|
| `random.randint(1, 6)` | a random whole number from 1 to 6, **including** 1 and 6 |
| `random.choice(["rock", "paper", "scissors"])` | one random item from the list |

```python
import random                       # at the top of the file

die = random.randint(1, 6)          # 1, 2, 3, 4, 5, or 6
print(f"You rolled a {die}.")
```

**Careful:** `randint(1, 6)` **includes** 6. `range(1, 6)` does **not**. They work differently.

**Testing a random program:** while you test, set the value by hand (for example, `secret = 42`) so you know the answer. Put `randint` back before you turn it in.

---

## A play again loop

> **Not in the lesson or practice.** This part is for the [Step 4 builds](../bpaBuilds/build04_loops.md), like the Number Guessing Game, which come after Step 7.


Put the whole program inside an outer `while` loop that asks "Play again?" at the bottom.

```python
games = 0
again = "y"                                 # start as "y" so the first game runs

while again == "y" or again == "Y":
    games = games + 1                       # counts ALL games, so it starts before the loop

    # ... the game goes here ...
    # anything that starts fresh each game (like guesses = 0) goes HERE, inside the loop

    again = input("Play again? (y/n): ")    # ask at the BOTTOM

print(f"Games played: {games}")
```

- Things that count **across all games** start **before** the outer loop.
- Things that start fresh **each game** are set **inside** the outer loop, at the top.

---

## Common mistakes

**1. The loop never ends**
```python
number = 1
while number <= 10:
    print(number)               # MISTAKE: number never changes
```
Fix: add `number = number + 1` inside the loop.

**2. Changing the for loop variable yourself**
```python
for count in range(1, 101):
    count = count + 1           # MISTAKE: the for loop already does this
    total = total + count
```
Fix: delete the `count = count + 1` line. A `for` loop moves to the next number on its own.

**3. Off by one with range**
`range(1, 10)` gives 1 to **9**. To include 10, use `range(1, 11)`.

**4. Asking before the loop but not inside it**
```python
number = int(input("Enter a number (0 to stop): "))
while number != 0:
    total = total + number      # MISTAKE: never asks again, so it loops forever
```
Fix: ask again at the bottom of the loop.

**5. The input is outside a for loop**
```python
score = int(input("Test score: "))  # MISTAKE: asked once, before the loop
for count in range(5):
    total = total + score           # adds the same score 5 times
```
Fix: move the `input()` inside the loop.

**6. Working out the average inside the loop**
```python
for count in range(5):
    score = int(input("Test score: "))
    total = total + score
    average = total / 5         # MISTAKE: runs 5 times, before all scores are in
```
Fix: un-indent the average line so it runs once, after the loop.

**7. Resetting the total inside the loop**
```python
for number in range(1, 101):
    total = 0                   # MISTAKE: goes back to 0 every pass
    total = total + number
```
Fix: `total = 0` goes before the loop.

**8. Comparing to the wrong thing**
```python
PASSWORD = "python123"
while entry != "PASSWORD":      # MISTAKE: the quotes make it the word "PASSWORD"
```
Fix: no quotes around a variable or constant name: `while entry != PASSWORD:`

**9. Using % 2 to check positive or negative**
`number % 2 == 0` checks **even or odd**. To check positive or negative, use `number > 0` or `number < 0`.

**10. Using and instead of or in a range check**
`while rating < 1 and rating > 10:` is never True. Use `or`.

**11. Something between an if and its else**
```python
if entry != PASSWORD:
    print("Try again!")
entry = input("Enter the password: ")   # MISTAKE: not indented, so the if is finished
else:                                   # SyntaxError: this else has no if
    print("Access granted!")
```
Fix: the `else` must come right after the `if` block, lined up with the `if`. Indent the `input` line so it's inside the `if` block.

---

## Quick reference

```python
# for loop: counts for you
for i in range(1, 11):          # 1 to 10
    print(i)

# while loop: you start, check, and change the variable
count = 1                       # start
while count <= 10:              # check
    print(count)
    count = count + 1           # change

# running total
total = 0
for i in range(1, 101):
    total = total + i

# sentinel loop: ask before, ask at the bottom
number = int(input("Number (0 to stop): "))
while number != 0:
    # use number here
    number = int(input("Number (0 to stop): "))

# ask again until it's in range
value = int(input("Pick 1-5: "))
while value < 1 or value > 5:
    print("Please enter 1 to 5.")
    value = int(input("Pick 1-5: "))

# repeat a set number of times
for count in range(5):
    score = int(input("Score: "))

# build a string
bar = ""
for count in range(7):
    bar = bar + "*"

# random whole number, both ends included
import random
roll = random.randint(1, 6)
```
