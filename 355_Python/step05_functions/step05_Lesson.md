# Step 05 — Functions (Python)

**What you'll build:** Snack Bar with Functions — the Step 2 snack bar rebuilt so an order can have several items, with each job in its own function.
**Time:** about one to two class periods. Functions are the most important step for BPA. Take your time.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Why functions](#why-functions)
- [Defining and calling a function](#defining-and-calling-a-function)
- [Parameters and arguments](#parameters-and-arguments)
- [Return values](#return-values)
- [return vs print](#return-vs-print)
- [Functions that return nothing](#functions-that-return-nothing)
- [The function comment](#the-function-comment)
- [Local variables and scope](#local-variables-and-scope)
- [Functions that call other functions](#functions-that-call-other-functions)
- [The main function](#the-main-function)
- [Tracing a program with functions](#tracing-a-program-with-functions)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Snack Bar with Functions](#the-challenge-snack-bar-with-functions)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What a function is and why BPA requires them
- How to write (`def`) a function and how to call it
- How to send values into a function with **parameters**
- How to send a value back out with `return`
- The difference between `return` and `print`
- How to write the function comment graders look for (purpose, parameters, return value)
- What "local variable" and "scope" mean
- How to start a program with `main()` and what `if __name__ == "__main__":` means

## Why functions

A **function** is a named block of code that does one job. You write it once, then **call** it (run it) by name whenever you need that job done.

You've already been calling functions written by other people: `print()`, `input()`, `int()`, `random.randint()`. Now you'll write your own.

Why it matters:
- **No repeated code.** If the receipt is printed in three places, write a `print_receipt` function once and call it three times. Fix a bug in one place.
- **Easier to read.** `tax = calculate_tax(subtotal)` tells you what's happening without reading the math.
- **Easier to test.** You can check one small function at a time.
- **BPA requires it.** The 2026 Python regional says: "Use functions to organize major parts of your program. Each function must include comments explaining its purpose, parameters, and return values."

## Defining and calling a function

```python
# Define the function (this does NOT run it yet)
def print_banner():
    print("*****************")
    print("*  MCCC IT LAB  *")
    print("*****************")

# Call the function (this runs it)
print_banner()
print("Welcome!")
print_banner()
```

It prints:

```text
*****************
*  MCCC IT LAB  *
*****************
Welcome!
*****************
*  MCCC IT LAB  *
*****************
```

| Part | What it means |
|---|---|
| `def` | "Define" — I'm making a function. |
| `print_banner` | The function's name. Use snake_case and a verb that says what it does. |
| `()` | The parameter list (empty here — this function needs no information). |
| `:` | Colon, like `if` and `while`. |
| Indented lines | The **body** — the code that runs each time the function is called. |
| `print_banner()` | A **call**. The parentheses are required. Without them, nothing runs. |

**Defining is not running.** When Python reads the `def` block, it only remembers the function. The code inside runs when (and every time) the function is called.

**Define before you call.** Python reads top to bottom. A function must be defined before the line that calls it runs. (The `main()` pattern later in this lesson makes this easy.)

## Parameters and arguments

A **parameter** is a variable in the function's parentheses. It receives a value when the function is called. The value you pass in the call is called an **argument**.

```python
# Define: "name" and "grade" are parameters
def print_badge(name, grade):
    print(f"[ {name} - Grade {grade} ]")

# Call: "Avery" and 12 are arguments
print_badge("Avery", 12)
print_badge("Blake", 11)
```

It prints:

```text
[ Avery - Grade 12 ]
[ Blake - Grade 11 ]
```

When `print_badge("Avery", 12)` runs, Python does `name = "Avery"` and `grade = 12`, then runs the body. The arguments are matched to the parameters **by position**: first to first, second to second.

The argument can be a variable. Its name does **not** have to match the parameter name:

```python
def print_badge(name, grade):
    print(f"[ {name} - Grade {grade} ]")

student = "Casey"
year = 10
print_badge(student, year)    # name gets "Casey", grade gets 10
```

It prints:

```text
[ Casey - Grade 10 ]
```

## Return values

A function can send a value back to the line that called it with `return`. The call is then replaced by that value, the same way `int("5")` is replaced by `5`.

```python
# Define: takes two numbers, gives back their average
def average_of_two(first, second):
    result = (first + second) / 2
    return result

# Call: the returned value is stored in a variable
quiz_average = average_of_two(80, 95)
print(quiz_average)

# You can also use the call directly inside other code
print(f"Average: {average_of_two(70, 75):.2f}")
```

It prints:

```text
87.5
Average: 72.50
```

What `return` does:
1. Works out the value after it.
2. **Ends the function right away** — any lines below it in the function are skipped.
3. Sends the value back to the caller.

You can return the result of an expression directly: `return (first + second) / 2` does the same thing in one line.

**Try it**
1. Write `area_of_rectangle(width, height)` that returns the area. Call it with `4, 7` and print the result.
2. Write `to_fahrenheit(celsius)` that returns `celsius * 9 / 5 + 32`. Print the result for `100` and `-40`.

## return vs print

This is the biggest point of confusion with functions, so read it twice.

- `print` shows a value **on the screen**. The program can't use it afterward.
- `return` hands a value **back to the code** that called the function. The program can store it, do math with it, or print it.

```python
# This one PRINTS the doubled value
def show_double(number):
    print(number * 2)

# This one RETURNS the doubled value
def get_double(number):
    return number * 2

show_double(5)           # prints 10
answer = get_double(5)   # prints nothing, answer is now 10
print(answer + 1)        # we can use it: 11

result = show_double(5)  # prints 10, but gives back nothing
print(result)            # nothing was returned, so this is None
```

It prints:

```text
10
11
10
None
```

`None` is Python's word for "no value." A function that reaches its end without a `return` gives back `None`.

**Rule of thumb:** functions that **calculate** something should `return` it. Functions whose job is to **show** something should `print` it. In the challenge, `calculate_subtotal`, `calculate_tax`, and `format_money` return; `print_receipt` prints.

## Functions that return nothing

Some functions do a job and don't need to give anything back — like `print_banner` above. In C++, Java, and C#, these are called **void** functions. In Python you simply leave out the `return` (or write a bare `return` to leave early).

```python
def print_line(length):
    # Output: a dashed line of any length; returns nothing
    print("-" * length)

print_line(10)
print_line(4)
```

It prints:

```text
----------
----
```

## The function comment

BPA graders check that **every** function has a comment that says three things:
1. **Purpose** — what the function does
2. **Parameters** — what each one is
3. **Return value** — what it gives back (or "nothing")

In Python, the standard place for this is a **docstring**: a triple-quoted string on the first line inside the function.

```python
def calculate_discount(price, percent_off):
    """Purpose: work out how much money a discount saves.
    Parameters: price (float) - the original price
                percent_off (int) - the discount, like 20 for 20%
    Returns: the amount saved (float)
    """
    # Processing: percent to decimal, then multiply
    return price * percent_off / 100

saved = calculate_discount(50.00, 20)
print(f"You save ${saved:.2f}")
```

It prints:

```text
You save $10.00
```

Writing `(float)` and `(int)` after each parameter tells the reader what type to pass in. You can use `#` comments instead of a docstring if you prefer — what matters is that all three parts are there. Use the same style in every function.

## Local variables and scope

A variable created **inside** a function is a **local variable**. It exists only while that function runs, and only that function can see it. Parameters are local too. This area where a variable can be seen is called its **scope**.

```python
def calculate_area(width, height):
    area = width * height        # "area" is local to calculate_area
    return area

room_area = calculate_area(10, 12)
print(room_area)
print(area)                      # this line fails - "area" doesn't exist out here
```

It prints (only the last line of the red error is shown here):

```text
120
NameError: name 'area' is not defined
```

This is a **good thing**. Two different functions can each have a variable called `total` and they won't mess each other up. To get a value **out** of a function, `return` it. To get a value **in**, pass it as an argument.

**What about constants?** A variable made at the top of the file, outside any function (like `TAX_RATE = 0.07`), is a **global**. Every function can **read** it. That's fine for constants. Don't change globals from inside functions — pass values in and return values out instead.

## Functions that call other functions

A function can call other functions. This lets you build bigger jobs out of small ones.

```python
SHIPPING = 4.99

def format_money(amount):
    """Purpose: show a number as money. Parameters: amount (float). Returns: str like $4.99"""
    return f"${amount:.2f}"

def print_total(item_cost):
    """Purpose: print the cost, shipping, and total. Parameters: item_cost (float). Returns: nothing"""
    total = item_cost + SHIPPING
    print("Items:    " + format_money(item_cost))
    print("Shipping: " + format_money(SHIPPING))
    print("Total:    " + format_money(total))

print_total(20)
```

It prints:

```text
Items:    $20.00
Shipping: $4.99
Total:    $24.99
```

`print_total` calls `format_money` three times. If you ever want money to look different (like adding commas), you change only `format_money`.

## The main function

Bigger programs put the "top level" steps into a function named `main()`. Then the **last two lines** of the file start the program:

```python
def greet(name):
    """Purpose: print a greeting. Parameters: name (str). Returns: nothing"""
    print(f"Hello, {name}!")

def main():
    """Purpose: run the program. Parameters: none. Returns: nothing"""
    greet("Devon")
    greet("Emery")

# Start the program
if __name__ == "__main__":
    main()
```

It prints:

```text
Hello, Devon!
Hello, Emery!
```

**What does `if __name__ == "__main__":` mean?** In plain words: **"If this file is the one being run, call `main()`."**

- When you press F5, Python sets a hidden variable called `__name__` to the text `"__main__"` for that file. So the `if` is True and `main()` runs.
- If a different program ever `import`s this file to borrow its functions, `__name__` is set to the file's name instead. The `if` is False, so the program doesn't start by itself.

You don't need to understand the second case to use it. Just know: it's the standard way to start a Python program, and graders expect to see it. It's spelled with **two underscores** on each side of `name` and `main`.

Why this pattern helps:
- All the `def`s are read first. By the time `main()` runs on the last line, every function is defined, so the order you write them in doesn't matter.
- The steps of the program are listed in one place, in `main()`, where they are easy to read.

In C++, Java, and C#, `main` (or `Main`) is required and is always where the program starts. In Python it's a habit, not a rule — but it's a good one.

## Tracing a program with functions

Follow this small program line by line. Tracing like this is the best way to understand how calls work.

<!-- input: 3 -->
```python
PRICE_PER_TICKET = 6.50

def calculate_cost(tickets):
    """Purpose: cost of some tickets. Parameters: tickets (int). Returns: float"""
    return tickets * PRICE_PER_TICKET

def print_summary(tickets, cost):
    """Purpose: print the order. Parameters: tickets (int), cost (float). Returns: nothing"""
    print(f"{tickets} tickets cost ${cost:.2f}")

def main():
    """Purpose: run the ticket program. Parameters: none. Returns: nothing"""
    # Input
    how_many = int(input("Tickets: "))
    # Processing
    total = calculate_cost(how_many)
    # Output
    print_summary(how_many, total)

if __name__ == "__main__":
    main()
```

It prints (user typed `3`):

```text
Tickets: 3
3 tickets cost $19.50
```

The order things happen:
1. Python stores the constant and remembers the three functions. Nothing prints yet.
2. The `if __name__` line is True, so `main()` is called.
3. In `main`: the user types `3`, so `how_many` is `3`.
4. `calculate_cost(3)` is called. Inside it, `tickets` is `3`. It returns `19.5`. Back in `main`, `total` is `19.5`.
5. `print_summary(3, 19.5)` is called. Inside it, `tickets` is `3` and `cost` is `19.5`. It prints the line and returns nothing.
6. `main` reaches its end. The program is over.

**Try it**
1. Add a function `calculate_fee(cost)` that returns 10% of the cost. Call it from `main` and print the fee.
2. Trace your new program on paper before you run it. Did the output match your trace?

## Common mistakes

**1. Calling a function without parentheses**
```python
main          # MISTAKE - names the function but doesn't call it
```
No error — nothing happens. Fix: `main()`

**2. Calling a function before it is defined**
```python
print_banner()        # MISTAKE - not defined yet when this line runs
def print_banner():
    print("Hi")
```
Error: `NameError: name 'print_banner' is not defined`
Fix: define first, or use the `main()` pattern so all calls happen after all `def`s.

**3. Wrong number of arguments**
```python
def calculate_subtotal(price, quantity):
    return price * quantity
calculate_subtotal(2.75)    # MISTAKE - only one argument
```
Error: `TypeError: calculate_subtotal() missing 1 required positional argument: 'quantity'`
Fix: pass one argument for each parameter, in order.

**4. Printing instead of returning**
If `calculate_tax` does `print(subtotal * TAX_RATE)` instead of `return`, then `tax = calculate_tax(8.25)` stores `None`, and `subtotal + tax` fails with:
`TypeError: unsupported operand type(s) for +: 'float' and 'NoneType'`
Fix: calculation functions `return` their answer.

**5. Forgetting to use the returned value**
```python
calculate_tax(subtotal)      # MISTAKE - the answer is thrown away
print(tax)
```
Error: `NameError: name 'tax' is not defined`
Fix: store it: `tax = calculate_tax(subtotal)`

**6. Using a local variable outside its function**
A variable made inside `main` can't be seen in `print_receipt`. Error: `NameError`. Fix: pass it in as an argument.

**7. Misspelling `__name__` or `"__main__"`**
With one underscore, or `"main"` without underscores, the `if` is False and **nothing runs** (no error). Fix: two underscores on each side: `if __name__ == "__main__":`

## How this shows up at BPA
- The 2026 regional's development standards: "Use functions to organize major parts of your program" and "Each function must include comments explaining its purpose, parameters, and return values." Requirement 6 was "Modularize your program using multiple functions" and named examples like `calculate_totals()` and `save_results()`.
- Requirement 4 of the same test said "Use functions for each major analysis component." Expect to be told **which** functions to write.
- Graders read your function comments. A docstring with Purpose / Parameters / Returns in every function is easy points.
- Functions are also how you avoid repeated code, which is scored under program design.
- In Step 10 you'll write **input functions** (`get_int`, `get_text`) that you can print out and bring to BPA. That only works once functions make sense — which is why this step matters.

## The challenge: Snack Bar with Functions

Rebuild the Step 2 snack bar so an order can have several items, using functions.

**Requirements**
1. Header comment.
2. Rebuild the Step 2 snack bar so an order can have **several items**: after each item ask `Add another item? (y/n): `.
3. Write these functions:
   - `calculate_subtotal(price, quantity)` → returns price × quantity
   - `calculate_tax(subtotal)` → returns subtotal × TAX_RATE
   - `format_money(amount)` → returns text like `$12.04`
   - `print_receipt(name, item_count, subtotal)` → prints the receipt (calls `calculate_tax` and `format_money`), returns nothing
   - `main()` → asks the questions, keeps the running subtotal and item count, calls `print_receipt`
4. Every function has a comment with its purpose, parameters, and return value.
5. Input / Processing / Output comments.

**Sample run (exact)**
```
Customer name: Jordan
Item: Pretzel
Price: 2.75
Quantity: 3
Add another item? (y/n): y
Item: Lemonade
Price: 1.50
Quantity: 2
Add another item? (y/n): n

--- Receipt for Jordan ---
Items ordered: 5
Subtotal:  $11.25
Tax (7%):  $0.79
Total:     $12.04
```
`Items ordered` is the total quantity: 3 + 2.

**Hints**
- Keep `TAX_RATE = 0.07` as a constant at the top of the file, above the functions.
- In `main`, set `order_subtotal = 0.0` and `item_count = 0` **before** the loop. Inside the loop, add to them.
- The loop is like the "play again" loop from Step 4: set the answer to `"y"` before the loop, ask at the bottom.
- The item name is asked for but isn't printed on the receipt. You still need the `input("Item: ")` line so the prompts match.
- `format_money(amount)` is one line: `return f"${amount:.2f}"`.
- End the file with `if __name__ == "__main__":` and `main()`.

## Turn it in
1. In your `bpaPrep` repo make a folder `python_step05`.
2. Put `step05.py` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 5 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] All five functions, with the names given
- [ ] Every function has a Purpose / Parameters / Returns comment
- [ ] Calculation functions `return`; `print_receipt` prints
- [ ] Program starts with `if __name__ == "__main__": main()`
- [ ] Pushed to `bpaPrep/python_step05`
