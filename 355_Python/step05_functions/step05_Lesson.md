# Step 05 — Functions (Python)

A **function** is a named block of code you can run any time by calling its name. This lesson teaches functions one piece at a time. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 5 Practice](step05_Practice.md) problems. For more examples, use the [Step 5 Study Guide](step05_StudyGuide.md).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: Defining and calling a function](#part-1-defining-and-calling-a-function)
- [Part 2: Parameters](#part-2-parameters)
- [Part 3: Return values](#part-3-return-values)
- [Part 4: return vs. print](#part-4-return-vs-print)
- [Part 5: The function comment](#part-5-the-function-comment)
- [Part 6: Functions that use if and loops](#part-6-functions-that-use-if-and-loops)
- [Part 7: The main function](#part-7-the-main-function)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- How to write a function with `def` and run it by calling it
- How to send values into a function with parameters
- How to get a value back out with `return`
- When to `return` and when to `print`
- How to write the function comment BPA graders look for
- How to start a program with `main()`

---

## Part 1: Defining and calling a function

There are two steps:
1. **Define** the function with `def`. This only teaches Python what the function does. Nothing runs yet.
2. **Call** the function by writing its name with `()`. This runs it.

```python
# Define the function (nothing prints yet)
def print_welcome():
    print("Welcome to the BPA Snack Bar!")
    print("-" * 29)

# Call it twice
print_welcome()
print_welcome()
```

```text
Welcome to the BPA Snack Bar!
-----------------------------
Welcome to the BPA Snack Bar!
-----------------------------
```

The `def` line ends with a colon, and the function's code is indented, just like `if` and loops. Function names follow the same rules as variable names: lowercase with underscores.

**Try it:** Write a function `print_goodbye()` that prints `Thanks for visiting!`. Call it once.

---

## Part 2: Parameters

A **parameter** is a variable in the `()` of the `def` line. It lets you send a value into the function. The value you send is called an **argument**.

```python
def greet(name):                # name is the parameter
    print(f"Hello, {name}!")

greet("Avery")                  # "Avery" is the argument
greet("Blake")
```

```text
Hello, Avery!
Hello, Blake!
```

A function can have more than one parameter. Separate them with commas. The arguments go in the **same order**:

```python
def print_score(name, score):
    print(f"{name} scored {score}")

print_score("Casey", 92)        # name = "Casey", score = 92
```

```text
Casey scored 92
```

**Try it:** Write `print_birthday(name, age)` that prints `Happy 17th birthday, Jordan!` when called with `("Jordan", 17)`. (Don't worry about "st", "nd", and "rd". Just use "th".)

---

## Part 3: Return values

`return` sends a value **back** to the line that called the function. You usually save it in a variable.

```python
def add_tax(price):
    total = price * 1.0675      # 6.75% tax
    return total                # send the answer back

cost = add_tax(20.00)           # cost gets the returned value
print(f"Total: ${cost:.2f}")
```

```text
Total: $21.35
```

Think of it like a calculator: you put numbers in (the arguments), and an answer comes out (the return value).

You can also use the call right inside other code:

```python
def double(number):
    return number * 2

print(double(4) + double(10))   # 8 + 20
```

```text
28
```

**`return` ends the function right away.** Any lines after it in the function don't run.

**Try it:** Write `triple(number)` that returns the number times 3. Print `triple(5)`.

---

## Part 4: return vs. print

These two look alike but do different things:

| | `print` | `return` |
|---|---|---|
| What it does | shows text on the screen | sends a value back to the code that called it |
| Can the program use the value later? | No | Yes |

```python
def area_print(width, height):
    print(width * height)       # shows the answer, but gives nothing back

def area_return(width, height):
    return width * height       # gives the answer back

room = area_return(10, 12)      # room is 120
print(f"Two rooms: {room * 2} square feet")
```

```text
Two rooms: 240 square feet
```

If you tried `room = area_print(10, 12)`, `room` would be `None` (Python's word for "nothing"), and `room * 2` would crash.

**Rule of thumb:** functions that **calculate** something should `return` it. Functions whose job is to **show** something should `print` it.

---

## Part 5: The function comment

BPA graders check that **every** function has a comment that says three things:
1. **Purpose:** what it does
2. **Parameters:** what each one is
3. **Returns:** what it gives back (or "nothing")

Put it on the first line inside the function, in triple quotes. This is called a **docstring**.

```python
def calculate_tip(bill, percent):
    """Purpose: work out the tip on a restaurant bill.
    Parameters: bill (float) - the bill amount
                percent (int) - the tip percent, like 20
    Returns: the tip amount (float)
    """
    return bill * percent / 100

print(f"Tip: ${calculate_tip(40.00, 20):.2f}")
```

```text
Tip: $8.00
```

Use the same style in every function you write from now on.

---

## Part 6: Functions that use if and loops

Anything you can write in a program can go inside a function, including `if` statements and loops.

```python
def letter_grade(score):
    """Purpose: turn a number score into a letter grade.
    Parameters: score (int) - the score from 0 to 100
    Returns: the letter grade (str)
    """
    if score >= 90:
        return "A"
    elif score >= 80:
        return "B"
    elif score >= 70:
        return "C"
    else:
        return "F"

for score in [95, 83, 61]:
    print(f"{score}: {letter_grade(score)}")
```

```text
95: A
83: B
61: F
```

Each `return` ends the function, so only one letter comes back.

**Try it:** Add a `"D"` for scores from 60 to 69.

---

## Part 7: The main function

Bigger programs put the main steps into a function named `main()`. The **last two lines** of the file start the program:

<!-- input: 12.50|3 -->
```python
def calculate_total(price, quantity):
    """Purpose: work out the cost of an order.
    Parameters: price (float) - price of one item
                quantity (int) - how many items
    Returns: the total cost (float)
    """
    return price * quantity

def main():
    """Purpose: run the program. Parameters: none. Returns: nothing"""
    # Input
    price = float(input("Price: "))
    quantity = int(input("Quantity: "))
    # Processing
    total = calculate_total(price, quantity)
    # Output
    print(f"Total: ${total:.2f}")

# Start the program
if __name__ == "__main__":
    main()
```

```text
Price: 12.50
Quantity: 3
Total: $37.50
```

`if __name__ == "__main__":` means "if this is the file being run, start `main()`." Type it exactly: **two underscores** on each side of `name` and `main`. Graders expect to see it.

---

## Common mistakes

1. **Defining a function but never calling it.** Nothing happens. Add the call, like `main()`.
2. **Forgetting the `()` when calling.** `main` does nothing. `main()` runs it.
3. **Printing instead of returning.** If the program needs the answer later, `return` it.
4. **Arguments in the wrong order.** `print_score(92, "Casey")` puts 92 in `name`.
5. **Using a function's variable outside the function.** A variable made inside a function only exists inside it. Return it instead.
6. **Code after `return`.** It never runs.

---

## Next steps
1. Do the [Step 5 Practice](step05_Practice.md) problems.
2. Keep the [Step 5 Study Guide](step05_StudyGuide.md) open while you work. Print it for BPA.
