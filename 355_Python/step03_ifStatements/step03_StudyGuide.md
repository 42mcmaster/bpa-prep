# Step 03 Study Guide — If Statements (Python)

This guide covers everything for Step 3, with full explanations and commented code. Start with the [Step 3 lesson](step03_Lesson.md), then do the [Step 3 Practice](step03_Practice.md). Come back here when you need more detail. Build 3A and the other [Step 3 builds](../bpaBuilds/build03_ifStatements.md) use these skills too. The builds for Steps 1–3 start after Step 3.

**Print this.** BPA lets you bring printed notes and printed code into the Python event.

## Table of Contents
- [What this guide covers](#what-this-guide-covers)
- [True and False](#true-and-false)
- [Comparison operators](#comparison-operators)
- [The if statement](#the-if-statement)
- [if and else](#if-and-else)
- [elif for more than two choices](#elif-for-more-than-two-choices)
- [Logical operators and or not](#logical-operators-and-or-not)
- [Nested if statements](#nested-if-statements)
- [Comparing text](#comparing-text)
- [The match statement (optional)](#the-match-statement-optional)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [Quick reference](#quick-reference)

## What this guide covers
- What `True` and `False` are and where they come from
- The comparison operators: `==`, `!=`, `<`, `>`, `<=`, `>=`
- How to make decisions with `if`, `elif`, and `else`
- Why indentation matters in Python
- How to combine conditions with `and`, `or`, and `not`
- How to put one `if` inside another (nested if)
- How to compare text, and how upper/lower case changes the answer
- What `match` is (and what `switch` is in C++, Java, and C#)

## True and False

In Step 2 you saw the `bool` type. A `bool` has only two values: `True` and `False` (capital T and F).

Every decision a program makes comes down to a question with a `True` or `False` answer: "Is the score at least 60?" "Did the user type y?"

```python
# Processing: comparisons give back True or False
score = 75
print(score >= 60)
print(score == 100)

passed = score >= 60      # you can store the answer in a variable
print(passed)
```

It prints:

```text
True
False
True
```

## Comparison operators

| What you type | What it means | `7 ? 5` gives |
|---|---|---|
| `==` | is equal to | `7 == 5` → `False` |
| `!=` | is not equal to | `7 != 5` → `True` |
| `<` | is less than | `7 < 5` → `False` |
| `>` | is greater than | `7 > 5` → `True` |
| `<=` | is less than or equal to | `7 <= 5` → `False` |
| `>=` | is greater than or equal to | `7 >= 5` → `True` |

**`=` vs `==`:** one equal sign **stores** a value (`x = 5`). Two equal signs **asks a question** (`x == 5`). Mixing them up is the most common `if` mistake.

## The if statement

An `if` runs a block of code **only when** its condition is `True`.

<!-- input: 12 -->
```python
# The program already knows how many are left
tickets_left = 4

# Input: how many tickets the user wants
wanted = int(input("How many tickets? "))

# Processing and Output: warn only when there aren't enough
if wanted > tickets_left:
    print(f"Sorry, only {tickets_left} tickets are left.")
    print("Please choose a smaller number.")
print("Thanks for checking.")
```

It prints (user typed `12`):

```text
How many tickets? 12
Sorry, only 4 tickets are left.
Please choose a smaller number.
Thanks for checking.
```

If the user typed `2`, only `Thanks for checking.` would print.

The rules:

| Part | Rule |
|---|---|
| `if tickets_left == 0` | The word `if`, then the condition. |
| `:` | A colon at the end of the line. Always. |
| The indented lines | The **block**. They run only when the condition is `True`. Indent with 4 spaces (IDLE does this for you when you press Enter after a `:`). |
| The first line that is **not** indented | The block is over. This line always runs. |

In C++, Java, and C#, curly braces `{ }` mark a block. In Python, **indentation** marks it. The indentation is not just for looks — it changes what the program does.

## if and else

`else` gives a second block that runs when the condition is `False`. Exactly one of the two blocks runs.

<!-- input: 15 -->
```python
# Input
age = int(input("Age: "))

# Processing and Output: one of two messages
if age >= 16:
    print("You can sign up for the driving class.")
else:
    years_left = 16 - age
    print(f"You can sign up in {years_left} year(s).")
```

It prints (user typed `15`):

```text
Age: 15
You can sign up in 1 year(s).
```

`else` has no condition. It means "every other case." It lines up with the `if` and also ends with a colon.

## elif for more than two choices

`elif` means "else if." Use it when there are three or more choices. Python checks the conditions **top to bottom** and runs **only the first block whose condition is True**. Then it skips the rest.

<!-- input: 72 -->
```python
# Input
temperature = int(input("Temperature: "))

# Processing: pick one description, checking from the top down
if temperature >= 90:
    description = "hot"
elif temperature >= 70:
    description = "warm"
elif temperature >= 50:
    description = "cool"
else:
    description = "cold"

# Output
print(f"It is {description} today.")
```

It prints (user typed `72`):

```text
Temperature: 72
It is warm today.
```

Why doesn't `72` also count as "cool" (it is also `>= 50`)? Because the `>= 70` check was `True` first, so Python ran that block and skipped every `elif` and `else` below it.

**Order matters.** If you put `>= 50` first, then `72` would be called "cool," and so would `95`. When you check ranges with `>=`, start with the **highest** range and work down.

**Try it**
1. Ask for a number of hours of sleep. Print `Great` for 8 or more, `OK` for 6 or 7, and `Not enough` for less than 6.
2. Swap the order of your conditions so the lowest check comes first. Test with 9. What breaks?

## Logical operators and or not

You can join two conditions into one.

| What you type | Is True when... | Example |
|---|---|---|
| `a and b` | **both** a and b are True | `age >= 13 and age <= 19` (a teenager) |
| `a or b` | **at least one** is True | `day == "Sat" or day == "Sun"` (weekend) |
| `not a` | a is False | `not finished` |

C++, Java, and C# write these as `&&` (and), `||` (or), and `!` (not). Python uses the words.

A very common use is a **range check** — is a number outside the allowed range?

<!-- input: 7 -->
```python
# Input
rating = int(input("Rating (1-5): "))

# Processing and Output: "or" because it is bad if EITHER side is true
if rating < 1 or rating > 5:
    print("Error: rating must be 1 to 5.")
else:
    print(f"Thanks for rating us {rating} out of 5.")
```

It prints (user typed `7`):

```text
Rating (1-5): 7
Error: rating must be 1 to 5.
```

Think it through: a number can't be both less than 1 **and** greater than 5 at the same time, so the "outside the range" check must use `or`. The "inside the range" check uses `and`:

```python
rating = 3
# Processing: inside the range uses "and"
if rating >= 1 and rating <= 5:
    print("Valid rating")
# Python also lets you write the same thing like a math inequality
# This is shorthand for: rating >= 1 and rating <= 5.
if 1 <= rating <= 5:
    print("Also valid")
```

It prints:

```text
Valid rating
Also valid
```

**Try it**
1. Ask for a day of the week and print `Weekend` if it is `Saturday` or `Sunday`, otherwise `School day`.
2. Ask for a test score and print `Valid` only when it is from 0 to 100, using `and`.

## Nested if statements

You can put an `if` inside another `if`. The inner one is indented one more level. It only gets checked when the outer condition is `True`.

<!-- input: 25|y -->
```python
# Input
age = int(input("Age: "))
member = input("Club member? (y/n): ")

# Processing and Output: the inner check only happens for adults
if age >= 18:
    if member == "y":
        print("Ticket price: $6.00")
    else:
        print("Ticket price: $9.00")
else:
    print("Ticket price: $4.00")
```

It prints (user typed `25`, `y`):

```text
Age: 25
Club member? (y/n): y
Ticket price: $6.00
```

In Build 3A (Grade Checker), the whole grade-checking part sits inside the `else` of the range check. That way, an out-of-range score prints the error and nothing else.

## Comparing text

`==` works on strings too. But Python compares **exactly** — upper and lower case are different.

```python
answer = "Yes"
print(answer == "yes")          # capital Y vs small y
print(answer.lower() == "yes")  # .lower() makes a lowercase copy first
print(answer.upper())           # .upper() makes an uppercase copy
```

It prints:

```text
False
True
YES
```

`.lower()` and `.upper()` are **methods** — actions you call on a string with a dot. They give back a new string; they don't change the original. You will learn many more string methods in Step 7.

Two ways to accept `y` or `Y`:

```python
choice = "Y"
# Way 1: check both with "or"
if choice == "y" or choice == "Y":
    print("Way 1: yes")
# Way 2: lowercase it first, then check once
if choice.lower() == "y":
    print("Way 2: yes")
```

It prints:

```text
Way 1: yes
Way 2: yes
```

**Note for Java:** in Java, `==` on two strings does not compare the text — you must use `.equals()`. Python's `==` compares the text, so you don't have that problem here.

## The match statement (optional)

C++, Java, and C# have a `switch` statement that picks a block based on one value. Python 3.10 and newer has something like it called `match`. You don't need it for these lessons — `if`/`elif` does the same job — but you may see it:

```python
choice = 2
# Processing: match picks the case that equals choice
match choice:
    case 1:
        print("Add member")
    case 2:
        print("Record points")
    case _:
        print("Unknown option")   # _ means "anything else"
```

It prints:

```text
Record points
```

Use `if`/`elif`/`else` in Build 3A (Grade Checker). It works in every Python version, and graders know it well.

## Common mistakes

**1. Forgetting the colon**
```python
if score >= 60          # MISTAKE - no colon
    print("Passed")
```
Error: `SyntaxError: expected ':'`
Fix: `if score >= 60:`

**2. Forgetting to indent**
```python
if score >= 60:
print("Passed")         # MISTAKE - not indented
```
Error: `IndentationError: expected an indented block after 'if' statement on line 1`
Fix: indent the block 4 spaces.

**3. Using `=` instead of `==`**
```python
if score = 100:         # MISTAKE
    print("Perfect")
```
Error: `SyntaxError: invalid syntax. Maybe you meant '==' or ':=' instead of '='?`
Fix: `if score == 100:`

**4. Ranges in the wrong order**
No error — wrong output. If `elif score >= 60` comes before `elif score >= 80`, a score of 87 gets a D. Check from the highest range down.

**5. Writing `or` the lazy way**
```python
if letter == "A" or "F":    # MISTAKE - always True
```
No error, but it is **always** `True`, because `"F"` by itself counts as True. Fix: repeat the variable: `if letter == "A" or letter == "F":`

**6. Using a separate `if` instead of `elif`**
If each grade check is its own `if`, a score of 95 matches `>= 90`, `>= 80`, `>= 70`, and `>= 60`, and the last one wins. Use one `if` followed by `elif`s.

## How this shows up at BPA
- BPA tests are full of decisions: "if the user enters a value out of range, show an error message." Every validation requirement starts with an `if` and a range check using `or`.
- The 2026 regional asked for the winner (lowest total) and the hardest hole (highest average). Both need comparisons inside a loop — you'll do that in Steps 6 and 8.
- Exact output still counts. `got an A.` vs `got a A.` is the kind of small difference that costs points.
- Graders read your logic. A clean `if`/`elif`/`else` chain with a comment saying what it decides is easy to give points for.

## Quick reference

```python
# comparisons:  ==  !=  <  >  <=  >=
if score >= 90:
    grade = "A"
elif score >= 80:
    grade = "B"
else:
    grade = "F"

if age < 0 or age > 120:          # or: either side
    print("Error: age must be 0 to 120.")
else:
    print("Good age.")            # the rest of the program goes here

if age >= 15 and permit == "y":   # and: both sides
    print("Can drive.")

if day.lower() == "tuesday":      # .lower() ignores capitals
    total = total - DISCOUNT
if three_d.lower() == "y":        # separate if: both can happen
    total = total + THREE_D_CHARGE
```

For the mistakes students make most on Steps 1–3, see [Steps 1–3 Common Mistakes](../Steps01-03_CommonMistakes.md).
