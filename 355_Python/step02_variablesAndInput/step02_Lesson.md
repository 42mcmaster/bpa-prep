# Step 02 — Variables and Input (Python)

This lesson teaches how a program stores values, asks the user questions, and does math. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 2 Practice](step02_Practice.md) problems. For more examples, use the [Step 2 Study Guide](step02_StudyGuide.md). The [Steps 1–3 Common Mistakes](../Steps01-03_CommonMistakes.md) page shows the mistakes students make most on this step.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: Variables](#part-1-variables)
- [Part 2: Printing variables with f-strings](#part-2-printing-variables-with-f-strings)
- [Part 3: Asking the user with input](#part-3-asking-the-user-with-input)
- [Part 4: Turning text into numbers](#part-4-turning-text-into-numbers)
- [Part 5: Math](#part-5-math)
- [Part 6: Money with 2 decimal places](#part-6-money-with-2-decimal-places)
- [Part 7: Named constants](#part-7-named-constants)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- How to store a value in a variable
- How to put variables in your output with f-strings
- How to ask the user a question with `input()`
- How to turn the answer into a number with `int()` or `float()`
- How to do math, including `//` and `%`
- How to print money with 2 decimal places
- How to use named constants

---

## Part 1: Variables

A **variable** is a name that holds a value. The `=` sign stores the value on the right in the name on the left.

```python
player = "Avery"        # text (a string) goes in quotes
points = 42             # a whole number (an int)
price = 3.50            # a decimal number (a float)

print(player)
print(points)
```

```text
Avery
42
```

Variable names are lowercase, with underscores between words: `total_cost`, not `TotalCost` or `total cost`. Pick names that say what the value is.

**Try it:** Make variables for your name and your grade, and print them.

---

## Part 2: Printing variables with f-strings

An **f-string** has an `f` right before the first quote. Anything inside `{curly braces}` is replaced with its value.

```python
player = "Avery"
points = 42

print(f"{player} scored {points} points.")
print(f"Player:  {player}")
```

```text
Avery scored 42 points.
Player:  Avery
```

Use one f-string for the whole line. That way, you control every space.

---

## Part 3: Asking the user with input

`input()` shows a question (called a **prompt**) and waits for the user to type an answer. The answer is saved in a variable.

<!-- input: Jordan -->
```python
name = input("What is your name? ")     # note the space after the ?
print(f"Hi, {name}!")
```

```text
What is your name? Jordan
Hi, Jordan!
```

Put a space at the end of the prompt, so the answer doesn't touch the question.

---

## Part 4: Turning text into numbers

`input()` **always** gives back text, even when the user types a number. To do math, turn it into a number first:

| Use | For | Examples |
|---|---|---|
| `int()` | whole numbers | people, age, quantity |
| `float()` | decimals | money, miles, hours |

<!-- input: 3|2.50 -->
```python
quantity = int(input("How many? "))
price = float(input("Price each: "))
print(f"Total: {quantity * price}")
```

```text
How many? 3
Price each: 2.50
Total: 7.5
```

`int("2.50")` crashes, because 2.50 isn't a whole number. Use `float()` for money.

**Try it:** Ask for the user's age and print how old they'll be in 10 years.

---

## Part 5: Math

| Symbol | Means | Example | Result |
|---|---|---|---|
| `+` | add | `7 + 2` | `9` |
| `-` | subtract | `7 - 2` | `5` |
| `*` | multiply | `7 * 2` | `14` |
| `/` | divide | `7 / 2` | `3.5` |
| `//` | divide, whole part only | `7 // 2` | `3` |
| `%` | the remainder | `7 % 2` | `1` |

`//` and `%` are great for "how many fit, and how many are left over":

```python
slices = 30
whole_pizzas = slices // 8      # 3 pizzas
extra_slices = slices % 8       # 6 slices left over
print(f"{whole_pizzas} pizzas and {extra_slices} extra slices")
```

```text
3 pizzas and 6 extra slices
```

Python does math in the normal order: multiply and divide before add and subtract. Use parentheses to change the order: `(a + b) / 2`.

**Try it:** Turn 135 minutes into hours and minutes. (You should get 2 hours and 15 minutes.)

---

## Part 6: Money with 2 decimal places

Python doesn't add zeros on its own. Put `:.2f` after the variable inside the curly braces to show exactly 2 decimal places.

```python
total = 7.5
print(f"Total: ${total}")
print(f"Total: ${total:.2f}")
```

```text
Total: $7.5
Total: $7.50
```

- `:.2f` means 2 places after the decimal. `:.1f` means 1 place.
- The `$` is just text in front of the curly brace.
- Do all the math with the full numbers. Only format in the `print` line.

---

## Part 7: Named constants

A **constant** is a value that never changes while the program runs, like a price or a tax rate. Put it at the top of the program, with a name in ALL_CAPS. Then use the name in the math.

<!-- input: 3 -->
```python
TICKET_PRICE = 8.50
TAX_RATE = 0.0675

tickets = int(input("Tickets: "))
subtotal = tickets * TICKET_PRICE
tax = subtotal * TAX_RATE
print(f"Subtotal: ${subtotal:.2f}")
print(f"Tax:      ${tax:.2f}")
print(f"Total:    ${subtotal + tax:.2f}")
```

```text
Tickets: 3
Subtotal: $25.50
Tax:      $1.72
Total:    $27.22
```

If the price changes, you only change one line.

---

## Common mistakes

1. **Forgetting `int()` or `float()`.** `"3" * 2` gives `"33"`, not `6`.
2. **Using `int()` for money.** `int("2.50")` crashes. Use `float()`.
3. **No `:.2f` on money.** `$7.5` doesn't match `$7.50`.
4. **Rounding in the middle of the math.** Only round in the `print` line.
5. **Typing the sample answers into the code** instead of using `input()`. Test every sample run.
6. **Changing the prompt.** It has to match the sample run exactly, including the space at the end.

---

## Next steps
1. Do the [Step 2 Practice](step02_Practice.md) problems.
2. Keep the [Step 2 Study Guide](step02_StudyGuide.md) open while you work. Print it for BPA.
