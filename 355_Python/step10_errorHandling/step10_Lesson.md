# Step 10 — Error Handling (Python)

Up to now, typing letters where a number belongs crashed every program. This lesson shows how to catch errors so the program keeps going. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 10 Practice](step10_Practice.md) problems. For more examples, use the [Step 10 Study Guide](step10_StudyGuide.md).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: What an exception is](#part-1-what-an-exception-is)
- [Part 2: try and except](#part-2-try-and-except)
- [Part 3: Ask again until it's a number](#part-3-ask-again-until-its-a-number)
- [Part 4: A number in a range](#part-4-a-number-in-a-range)
- [Part 5: A reusable input function](#part-5-a-reusable-input-function)
- [Part 6: Blank answers](#part-6-blank-answers)
- [Part 7: Other errors you can catch](#part-7-other-errors-you-can-catch)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- What an exception is and how to read the error message
- How `try` and `except` stop a crash
- How to keep asking until the user types a real number
- How to write a `get_int` function you can use in every program
- How to stop blank answers

---

## Part 1: What an exception is

An **exception** is an error that happens while the program is running. If nothing catches it, the program stops and prints a red message called a **traceback**. The **last line** tells you what went wrong:

```
Traceback (most recent call last):
  File "test.py", line 1, in <module>
    age = int(input("Age: "))
ValueError: invalid literal for int() with base 10: 'seventeen'
```

| Error | What causes it |
|---|---|
| `ValueError` | `int("seventeen")` or `int("2.5")`: text that isn't a whole number |
| `ZeroDivisionError` | dividing by 0 |
| `IndexError` | a list index that isn't there |
| `FileNotFoundError` | opening a file that isn't there |

---

## Part 2: try and except

Put the code that might fail under `try:`. Put what to do instead under `except`:

<!-- input: seventeen -->
```python
try:
    age = int(input("Age: "))
    print(f"Next year you'll be {age + 1}.")
except ValueError:                          # catches the error from int()
    print("That wasn't a whole number.")

print("The program kept going.")
```

```text
Age: seventeen
That wasn't a whole number.
The program kept going.
```

If the code under `try` works, Python skips the `except` part. If a `ValueError` happens, Python jumps straight to `except`. **Name the error** after `except`, so you only catch the one you expect.

**Try it:** Run it again and type `17`.

---

## Part 3: Ask again until it's a number

Put the `try` inside a `while True:` loop. If the number is good, `break` out of the loop. If not, print a message and the loop asks again.

<!-- input: ten|2.5|10 -->
```python
while True:
    try:
        tickets = int(input("How many tickets? "))
        break                                   # good number: leave the loop
    except ValueError:
        print("Please enter a whole number.")

print(f"You ordered {tickets} tickets.")
```

```text
How many tickets? ten
Please enter a whole number.
How many tickets? 2.5
Please enter a whole number.
How many tickets? 10
You ordered 10 tickets.
```

`break` only runs if `int()` worked, because a `ValueError` jumps past it to the `except`.

---

## Part 4: A number in a range

Now check the range too, after the number is good. Both kinds of bad answer get the same message:

<!-- input: abc|9|4 -->
```python
while True:
    try:
        rating = int(input("Rating (1-5): "))
        if rating >= 1 and rating <= 5:
            break                               # a number AND in range
    except ValueError:
        pass                                    # pass means "do nothing here"
    print("Please enter a whole number from 1 to 5.")

print(f"Rating: {rating}")
```

```text
Rating (1-5): abc
Please enter a whole number from 1 to 5.
Rating (1-5): 9
Please enter a whole number from 1 to 5.
Rating (1-5): 4
Rating: 4
```

The message is printed in one place, after the `try`/`except`. Python only gets there if the loop didn't `break`.

---

## Part 5: A reusable input function

Move that loop into a function. The question and the range are parameters, so the same function works for every number in every program. **Print it and bring it to BPA.**

<!-- input: two|2|40 -->
```python
def get_int(prompt, low, high):
    """Purpose: ask until the user types a whole number from low to high.
    Parameters: prompt (str) - the question
                low (int), high (int) - the smallest and largest allowed
    Returns: the number (int)
    """
    while True:
        try:
            number = int(input(prompt))
            if number >= low and number <= high:
                return number                   # return also leaves the loop
        except ValueError:                      # catches letters and decimals
            pass
        print(f"Please enter a whole number from {low} to {high}.")

seats = get_int("Seats (1-4): ", 1, 4)
age = get_int("Age (0-120): ", 0, 120)
print(f"{seats} seats, age {age}")
```

```text
Seats (1-4): two
Please enter a whole number from 1 to 4.
Seats (1-4): 2
Age (0-120): 40
2 seats, age 40
```

**Try it:** Write `get_float(prompt, low, high)` the same way, using `float()`.

---

## Part 6: Blank answers

If the user just presses Enter, `input()` gives back `""`, an empty string. `.strip()` also turns an answer of only spaces into `""`.

<!-- input: |Avery -->
```python
name = input("Name: ").strip()
while name == "":
    print("This cannot be blank.")
    name = input("Name: ").strip()

print(f"Hello, {name}!")
```

```text
Name: 
This cannot be blank.
Name: Avery
Hello, Avery!
```

---

## Part 7: Other errors you can catch

You can list more than one `except`, one for each kind of error:

<!-- input: 10|0 -->
```python
try:
    total = int(input("Total points: "))
    games = int(input("Games played: "))
    print(f"Average: {total / games:.1f}")
except ValueError:                  # letters instead of a number
    print("Please type whole numbers.")
except ZeroDivisionError:           # games was 0
    print("Games played can't be 0.")
```

```text
Total points: 10
Games played: 0
Games played can't be 0.
```

The `FileNotFoundError` from Step 9 works the same way.

---

## Common mistakes

1. **A bare `except:` with no error name.** It hides every error, even typos in your code. Name the error: `except ValueError:`.
2. **Too much code under `try`.** Only put the lines that can fail there.
3. **Forgetting `break` or `return`.** The `while True:` loop never ends.
4. **Checking the range outside the loop.** A bad number gets through.
5. **Forgetting `.strip()` on text.** An answer of only spaces isn't caught as blank.

---

## Next steps
1. Do the [Step 10 Practice](step10_Practice.md) problems.
2. Keep the [Step 10 Study Guide](step10_StudyGuide.md) open while you work. Print it for BPA.
3. After the practice, try the [Step 10 builds](../bpaBuilds/build10_errorHandling.md).
