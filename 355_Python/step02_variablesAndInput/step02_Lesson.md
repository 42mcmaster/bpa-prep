# Step 02 — Variables, Input, Math, and Formatting (Python)

**What you'll build:** Snack Bar Order — a program that asks for one snack bar order and prints a receipt with tax.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Variables](#variables)
- [Data types](#data-types)
- [Naming variables](#naming-variables)
- [Reading input from the keyboard](#reading-input-from-the-keyboard)
- [Converting text to numbers](#converting-text-to-numbers)
- [Math operators](#math-operators)
- [Division in Python](#division-in-python)
- [Named constants](#named-constants)
- [Formatting output with f-strings](#formatting-output-with-f-strings)
- [Putting it together](#putting-it-together)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Snack Bar Order](#the-challenge-snack-bar-order)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to store values in variables
- The four basic data types: text (`str`), whole numbers (`int`), decimals (`float`), true/false (`bool`)
- How to read what the user types with `input()`
- How to turn typed text into a number with `int()` and `float()`
- Math operators, including `//` and `%`
- How division works in Python, and how it is different in C++, Java, and C#
- How to use a named constant for a value that never changes
- How to print money with exactly 2 decimal places using an f-string

## Variables

A **variable** is a name that holds a value. You make one with `=`.

```python
# Processing: store values in variables
room = "Room 112"
seats = 24
print(room)
print(seats)

# A variable can be changed later. The old value is replaced.
seats = 30
print(seats)
```

It prints:

```text
Room 112
24
30
```

Read `=` as **"gets"**, not "equals." `seats = 30` means "seats gets the value 30." The right side is worked out first, then stored in the name on the left. That is why this line makes sense:

```python
count = 5
count = count + 1    # take the old count (5), add 1, store 6 back in count
print(count)
```

It prints:

```text
6
```

## Data types

Every value has a **type**. The type decides what you can do with it.

| Type | Name in Python | Examples | Used for |
|---|---|---|---|
| Text | `str` (string) | `"Jordan"`, `"3"`, `""` | names, words, anything typed |
| Whole number | `int` (integer) | `3`, `0`, `-12` | counts, quantities, scores |
| Decimal | `float` | `2.75`, `0.07`, `100.0` | prices, averages, rates |
| True/false | `bool` (Boolean) | `True`, `False` | yes/no answers (used a lot in Step 3) |

`"3"` with quotes is a **string** (text). `3` without quotes is an **int**. They look alike but act differently. You can ask Python the type of anything with `type()`:

```python
# Processing: check the type of some values
print(type("Jordan"))
print(type(3))
print(type(2.75))
print(type(True))
print(type("3"))
```

It prints:

```text
<class 'str'>
<class 'int'>
<class 'float'>
<class 'bool'>
<class 'str'>
```

**Try it**
1. Make a variable for your name, your grade level, and your GPA. Print each one, then print the `type()` of each.
2. Make `points = 10`, then change it to `points + 5` and print it.

## Naming variables

Python programmers write variable names in **snake_case**: all lowercase, with underscores between words.

| Good | Not good | Why |
|---|---|---|
| `customer_name` | `cn` | Say what it holds. Graders check for meaningful names. |
| `total_cost` | `TotalCost` | `PascalCase` is for classes in Python (Step 11). |
| `quantity` | `2nd_quantity` | Names cannot start with a digit. |
| `item_price` | `item price` | Names cannot have spaces. |

Names are case sensitive: `total` and `Total` are two different variables. BPA's development standards say to use **one naming style consistently** — in Python that means snake_case everywhere.

## Reading input from the keyboard

`input()` shows a prompt, waits for the user to type something and press Enter, and gives back what they typed **as a string**.

<!-- input: Avery -->
```python
# Input: ask for the user's first name
first_name = input("First name: ")

# Output: greet them
print("Hello, " + first_name + "!")
```

It prints (the user typed `Avery`):

```text
First name: Avery
Hello, Avery!
```

Notes:
- Put a space at the end of the prompt (`"First name: "`). Otherwise the user's typing runs right up against the colon.
- The `+` sign joins strings together. This is called **concatenation**.
- `input()` **always** gives back a string, even if the user types a number. That leads to the next section.

## Converting text to numbers

To do math with what the user types, convert it:

| What you type | What it means |
|---|---|
| `int("3")` | Turn the text `"3"` into the whole number `3`. |
| `float("2.75")` | Turn the text `"2.75"` into the decimal `2.75`. |
| `str(3)` | Turn the number `3` into the text `"3"`. |
| `int(input("Quantity: "))` | Ask, then convert the answer to a whole number in one line. |

<!-- input: 15 -->
```python
# Input: read the age as text, then convert it to a whole number
age_text = input("Age: ")
age = int(age_text)

# Processing: math only works on numbers
age_next_year = age + 1

# Output
print("Next year you will be", age_next_year)
```

It prints:

```text
Age: 15
Next year you will be 16
```

Most programmers do the convert in the same line as the input: `age = int(input("Age: "))`.

**What if they type something that is not a number?** If the user types `fifteen` or `2.5` where `int()` is expecting a whole number, the program crashes with a `ValueError`. That is OK for now. **Step 10** teaches you how to catch that and ask again, so the program never crashes.

**Try it**
1. Ask for two whole numbers and print their sum.
2. Remove the `int()` from your "Try it" and run it with `4` and `5`. What prints? (Answer: `45`, because adding two strings joins them.)

## Math operators

| Operator | Meaning | Example | Result |
|---|---|---|---|
| `+` | add | `7 + 2` | `9` |
| `-` | subtract | `7 - 2` | `5` |
| `*` | multiply | `7 * 2` | `14` |
| `/` | divide (always gives a decimal) | `7 / 2` | `3.5` |
| `//` | whole-number divide (drops the decimal part) | `7 // 2` | `3` |
| `%` | remainder (called "modulo" or "mod") | `7 % 2` | `1` |
| `**` | power | `7 ** 2` | `49` |

Python follows normal math order: parentheses first, then `**`, then `*` `/` `//` `%`, then `+` `-`. When in doubt, add parentheses.

```python
# Processing: some math examples
minutes = 135
hours = minutes // 60          # whole hours
leftover = minutes % 60        # minutes left over
print(hours, "hours and", leftover, "minutes")

average = (80 + 90 + 85) / 3   # parentheses: add first, then divide
print(average)

wrong_average = 80 + 90 + 85 / 3   # divides only the 85!
print(wrong_average)
```

It prints:

```text
2 hours and 15 minutes
85.0
198.33333333333334
```

`%` is more useful than it looks. `number % 2` is `0` for even numbers and `1` for odd ones. You will use `%` in Step 7 to make letters wrap from Z back to A.

## Division in Python

This section matters more if you ever switch to C++, Java, or C#.

- In **Python**, `/` always gives a decimal: `7 / 2` is `3.5`, and even `6 / 2` is `3.0`.
- In **C++, Java, and C#**, dividing one whole number by another whole number throws away the decimal: `7 / 2` is `3`. This is called **integer division**, and it causes wrong averages all the time in those languages.
- Python's `//` does integer division on purpose when you want it.

Another trap: `int()` on a decimal **chops off** the decimal part. It does not round.

```python
# Processing: int() chops, round() rounds
price = 8.99
print(int(price))
print(round(price))
print(round(8.8275, 2))
```

It prints:

```text
8
9
8.83
```

For money, do not use `int()` and do not depend on `round()` to make output look right. Format the output instead (see [Formatting output with f-strings](#formatting-output-with-f-strings)).

**Decimals are not always exact.** Computers store decimals in binary, so some values are very slightly off: `0.1 + 0.2` prints `0.30000000000000004`. This is normal in every language. Formatting to 2 decimal places when you print hides it.

## Named constants

A **constant** is a value that never changes while the program runs, like a tax rate. Give it a name in **ALL_CAPS** at the top of the program:

```python
# Named constants (ALL_CAPS means "do not change this")
SALES_TAX_RATE = 0.0675
SHIPPING_COST = 4.99

# Processing: use the names instead of typing the numbers again
order_amount = 40.00
tax = order_amount * SALES_TAX_RATE
total = order_amount + tax + SHIPPING_COST
print(f"Total: ${total:.2f}")    # :.2f is explained in the next section
```

It prints:

```text
Total: $47.69
```

Why bother?
- `order_amount * SALES_TAX_RATE` explains itself. `order_amount * 0.0675` makes the reader guess what `0.0675` is.
- If the rate changes, you change one line at the top instead of hunting through the program.
- Python does not stop you from changing an ALL_CAPS variable. The capital letters are a promise to other programmers (and graders) that you won't.

## Formatting output with f-strings

An **f-string** is a string with an `f` right before the opening quote. Inside it, anything in `{curly braces}` is replaced with its value.

```python
# Processing: some values to show
player = "Casey"
points = 42
cost = 3.5

# Output: f-strings put values right into the text
print(f"{player} scored {points} points.")
print(f"Cost: ${cost}")
print(f"Cost: ${cost:.2f}")
```

It prints:

```text
Casey scored 42 points.
Cost: $3.5
Cost: $3.50
```

The `:.2f` after the variable name is a **format code**. It means "show this number as a decimal (`f`) with exactly 2 digits after the point (`.2`)." It rounds for you. This is how you show money.

| What you type | What it means | Example result |
|---|---|---|
| `{price}` | the value, as-is | `3.5` |
| `{price:.2f}` | 2 decimal places | `3.50` |
| `{price:.1f}` | 1 decimal place | `3.5` |
| `${price:.2f}` | a `$` in front (the `$` is just text) | `$3.50` |
| `{count}` | an int, as-is | `42` |

Without f-strings you would write `print("Cost: $" + str(cost))`, which is longer and can't control decimal places. Use f-strings.

**Try it**
1. Store `price = 19.5` and print it as `Price: $19.50`.
2. Print `10 / 3` with 2 decimal places, then with 4.

## Putting it together

Here is a full program that uses everything above. It is **not** the challenge, but it has the same shape: Input, then Processing, then Output.

<!-- input: Blake|12.5|4 -->
```python
# Name: Your Name
# Date: 2026-11-06
# Program: Carpet Cost Example
# Description: Works out the cost to carpet a room, plus a fee.

# Named constant for the install fee
INSTALL_FEE = 25.00

# Input: room owner, cost per square foot, and room size
owner = input("Owner: ")
cost_per_foot = float(input("Cost per square foot: "))
square_feet = int(input("Square feet: "))

# Processing: material cost and total
material_cost = cost_per_foot * square_feet
total_cost = material_cost + INSTALL_FEE

# Output: a small report, money to 2 decimal places
print()
print(f"--- Estimate for {owner} ---")
print(f"Material:  ${material_cost:.2f}")
print(f"Install:   ${INSTALL_FEE:.2f}")
print(f"Total:     ${total_cost:.2f}")
```

It prints (the user typed `Blake`, `12.5`, `4`):

```text
Owner: Blake
Cost per square foot: 12.5
Square feet: 4

--- Estimate for Blake ---
Material:  $50.00
Install:   $25.00
Total:     $75.00
```

Notice the empty `print()` before the report. That makes the blank line.

## Common mistakes

**1. Doing math on a string**
```python
age = input("Age: ")
print(age + 1)          # MISTAKE - age is text
```
Error: `TypeError: can only concatenate str (not "int") to str`
Fix: convert first: `age = int(input("Age: "))`

**2. Joining a number to a string with `+`**
```python
total = 5
print("Total: " + total)   # MISTAKE
```
Error: `TypeError: can only concatenate str (not "int") to str`
Fix: use an f-string, `print(f"Total: {total}")`, or `str(total)`.

**3. Using `int()` when the user types a decimal**
Typing `2.75` into `int(input("Price: "))` crashes:
`ValueError: invalid literal for int() with base 10: '2.75'`
Fix: prices use `float()`. Quantities use `int()`.

**4. Money printed with the wrong number of decimals**
`print(f"Total: ${total}")` might print `$8.8275` or `$3.5`. No error — it's just wrong.
Fix: always `{total:.2f}` for money.

**5. Variable name spelled two ways**
```python
sub_total = 8.25
print(subtotal)          # MISTAKE - different name
```
Error: `NameError: name 'subtotal' is not defined. Did you mean: 'sub_total'?`
Fix: pick one spelling and use it every time.

**6. Spacing in the receipt doesn't match**
`Subtotal:  $8.25` has **two** spaces after the colon. `Item:      Pretzel` has six. Count them in the sample run.

## How this shows up at BPA
- Every BPA program starts with input. The 2026 test asked for player names and scores; the 2024 test asked for counts and codes. Converting with `int()` and `float()` is in every one.
- Money must be formatted as US currency, like `$24.00`. On the 2024 regional, currency formatting was worth 20 points with **no partial credit**. `:.2f` with a `$` in front is all you need.
- Graders review variable names. snake_case with meaningful names, used the same way throughout, is what the development standards ask for.
- Named constants for fixed values (like a tax rate or the number of rounds) make your code easier for a grader to read.

## The challenge: Snack Bar Order

Write a program that takes one order at the MCCC snack bar and prints a receipt.

**Requirements**
1. Header comment.
2. Ask for the customer's name, the item, the price (decimal), and the quantity (whole number) using the exact prompts below.
3. Store the tax rate in a named constant (`TAX_RATE = 0.07`).
4. Calculate subtotal (price × quantity), tax (subtotal × TAX_RATE), and total (subtotal + tax).
5. Print the receipt exactly as shown, money with 2 decimal places.
6. Input / Processing / Output comments on each block.

**Sample run (exact)**
```
Customer name: Jordan
Item: Pretzel
Price: 2.75
Quantity: 3

--- Receipt for Jordan ---
Item:      Pretzel
Quantity:  3
Subtotal:  $8.25
Tax (7%):  $0.58
Total:     $8.83
```

There is no input checking yet. If the user types letters for the price, the program will crash. That's fine for now — Step 10 makes it crash-proof.

**Hints**
- Four `input()` lines. The price uses `float()`, the quantity uses `int()`.
- The blank line after `Quantity: 3` is a `print()` with nothing in it.
- Check your math with a calculator: 2.75 × 3 = 8.25; 8.25 × 0.07 = 0.5775, which shows as `0.58`.

## Turn it in
1. In your `bpaPrep` repo make a folder `python_step02`.
2. Put `step02.py` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 2 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `TAX_RATE = 0.07` is a named constant near the top
- [ ] Price uses `float()`, quantity uses `int()`
- [ ] All money shows 2 decimal places with `$`
- [ ] Pushed to `bpaPrep/python_step02`
