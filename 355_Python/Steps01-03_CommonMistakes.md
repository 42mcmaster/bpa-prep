# Steps 01–03 Review: Common Mistakes

These are real mistakes from the Step 01–03 tasks. Each one shows the wrong code, the right code, and why it matters.

In BPA, your program is graded by comparing its output to the sample run. **One wrong space or one missing decimal makes it wrong.** Most of the points lost so far came from small output problems, not hard logic.

## Table of Contents
- [Mistake 1: Using tabs instead of spaces](#mistake-1-using-tabs-instead-of-spaces)
- [Mistake 2: Money not printed with 2 decimal places](#mistake-2-money-not-printed-with-2-decimal-places)
- [Mistake 3: Using commas in print()](#mistake-3-using-commas-in-print)
- [Mistake 4: Rounding too early](#mistake-4-rounding-too-early)
- [Mistake 5: Typing the answers instead of using input()](#mistake-5-typing-the-answers-instead-of-using-input)
- [Mistake 6: Changing the prompts or printing extra lines](#mistake-6-changing-the-prompts-or-printing-extra-lines)
- [Mistake 7: Using the wrong variable](#mistake-7-using-the-wrong-variable)
- [Mistake 8: int() vs. float()](#mistake-8-int-vs-float)
- [Mistake 9: If statement mistakes](#mistake-9-if-statement-mistakes)
- [Mistake 10: Constants and typos](#mistake-10-constants-and-typos)
- [How to check your own work](#how-to-check-your-own-work)
- [Practice: Find the mistakes](#practice-find-the-mistakes)

---

## Mistake 1: Using tabs instead of spaces

This was the most common mistake. `\t` is a tab. A tab is **not** the same as spaces, and it does not line up the same way on every computer.

**Wrong**
```python
print(f"Slices needed:\t{total_slices}")
print(f"Whole pizzas:\t{whole_pizzas}")
```

**Right** — type the spaces. Count them from the sample run.
```python
print(f"Slices needed:    {total_slices}")   # 4 spaces after the colon
print(f"Whole pizzas:     {whole_pizzas}")   # 5 spaces after the colon
```

**Tip:** In the sample run, every value starts in the same column. Copy the label **and its spaces** straight from the sample run into your code.

---

## Mistake 2: Money not printed with 2 decimal places

Python does not add zeros on its own. `16.0` is not `$16.00`.

**Wrong**
```python
print("Gas cost: $" + str(gas_cost))     # prints $16.0  or  $7.063571428571429
print(f"Total cost: ${total_cost:.2}")   # :.2 is NOT the same as :.2f
```

**Right**
```python
print(f"Gas cost:         ${gas_cost:.2f}")      # prints $16.00
print(f"Gallons of gas:   {gallons:.1f}")        # 1 decimal place: 5.0
```

| Code | What it means | 52.4733 prints as |
|---|---|---|
| `{x}` | no formatting | `52.4733` |
| `{x:.2}` | 2 **digits total** | `5.2e+01` ❌ |
| `{x:.2f}` | 2 places **after the decimal** | `52.47` ✅ |
| `{x:.1f}` | 1 place after the decimal | `52.5` |

**Don't forget the `f`.** Without it, you get the wrong number.

---

## Mistake 3: Using commas in print()

When you put commas between items in `print()`, Python adds a space between each one. That breaks exact output.

**Wrong**
```python
print("--- Trip to", destination, "---")   # works by luck
print("Round trip gas:  $", round_trip)    # prints  $ 32.0  (extra space, no .00)
```

**Right** — use one f-string for the whole line. You control every space.
```python
print(f"--- Trip to {destination} ---")
print(f"Round trip gas:   ${round_trip:.2f}")
```

**Rule for this class:** one `print()`, one f-string, one line of output.

---

## Mistake 4: Rounding too early

Do all the math with the full numbers. Only round when you print.

**Wrong** — the gallons get rounded first, so every number after it is a little off.
```python
gallons = round(miles / mpg, 1)        # 2.214... becomes 2.2
gas_cost = round(gallons * price, 2)   # 2.2 x 3.19 = 7.02   (sample says $7.06)
```

**Right**
```python
gallons = miles / mpg                  # keep 2.2142857...
gas_cost = gallons * price             # 7.0635...
print(f"Gallons of gas:   {gallons:.1f}")    # 2.2
print(f"Gas cost:         ${gas_cost:.2f}")  # $7.06
```

**Rule:** no `round()` in your math. Let `:.2f` do the rounding in the `print()` line.

---

## Mistake 5: Typing the answers instead of using input()

The program has to work for **any** input, not just Sample run 1.

**Wrong** — this matches Sample run 1, but Sample run 2 prints Jordan's party again.
```python
people = 10
spp = 3
print("Host name: Jordan")
```

**Right**
```python
host = input("Host name: ")
people = int(input("Number of people: "))
slices_per_person = int(input("Slices per person: "))
```

**Test every sample run**, not just the first one. If run 2 shows run 1's answers, something is typed in.

---

## Mistake 6: Changing the prompts or printing extra lines

The prompts must match the sample run **exactly**, including the space after the colon. Do not print things the sample run does not show.

**Wrong**
```python
name = input("What is your name?")                # sample says  Name:
print("Destination:", destination)                # repeats the input back
print("Tuesday deal: -$0.00")                     # sample does not show this line
```

**Right**
```python
name = input("Name: ")                            # exact prompt, space at the end
```

If a line only shows up "when it applies," put the `print()` **inside** an `if`:
```python
if day.lower() == "tuesday":
    print(f"Tuesday deal: -${TUESDAY_DISCOUNT:.2f}")
```

---

## Mistake 7: Using the wrong variable

The code ran with no errors, but the answer was wrong.

**Wrong** — `slices` is slices **per person** (3), not total slices (30).
```python
total_slices = people * slices
whole_pizzas = slices // SLICES_PER_PIZZA     # 3 // 8 = 0 pizzas
```

**Right**
```python
total_slices = people * slices_per_person
whole_pizzas = total_slices // SLICES_PER_PIZZA   # 30 // 8 = 3 pizzas
```

**Tips**
- Use clear names: `slices_per_person` and `total_slices`, not `slices` and `spp`.
- Check one sample run by hand. The task hints show the math.

---

## Mistake 8: int() vs. float()

- `int()` is for whole numbers: people, age, zone, grade.
- `float()` is for decimals: money, miles, hours, GPA.

**Wrong**
```python
rate = int(input("Hourly pay rate: "))   # typing 16.00 crashes: ValueError
people = float(input("Number of people: "))   # prints 10.0 people
```

**Right**
```python
rate = float(input("Hourly pay rate: "))
people = int(input("Number of people: "))
```

Also remember `//` and `%`:
- `30 / 8` = `3.75` (regular division)
- `30 // 8` = `3` (whole pizzas)
- `30 % 8` = `6` (leftover slices)

---

## Mistake 9: If statement mistakes

**a) Wrong edge.** "Under 13" means 12 and below. A 13-year-old is an adult ticket.
```python
if age <= 13:     # wrong: 13 gets a child ticket
if age < 13:      # right
```

**b) Writing over the total.** Each change has to start from the **current** total.
```python
# Wrong: the 3D line throws away the Tuesday discount
total = price - TUESDAY_DISCOUNT
total = price + THREE_D_CHARGE

# Right: start at the base price, then change total step by step
total = price
if day.lower() == "tuesday":
    total = total - TUESDAY_DISCOUNT
if three_d.lower() == "y":
    total = total + THREE_D_CHARGE
```

**c) The error check doesn't stop the program.** If the age is bad, print the error and **nothing else**. Put everything else in the `else`:
```python
if age < 0 or age > 120:
    print("Error: age must be 0 to 120.")
else:
    # all the ticket code goes here, indented
```

**d) `elif` vs. two `if`s.** Use `elif` when only **one** choice can happen (child, adult, or senior). Use separate `if`s when **both** can happen (Tuesday **and** 3D).

---

## Mistake 10: Constants and typos

**Constants** are values that never change, like prices and rates. Name them in ALL_CAPS at the top of the file and use the name, not the number.

```python
# Wrong
cost = pizzas * 12.99 + extra * 2.25
pizza_price = 12.99          # lowercase

# Right
PIZZA_PRICE = 12.99
SLICE_PRICE = 2.25
cost = pizzas * PIZZA_PRICE + extra * SLICE_PRICE
```

**Typos in labels** count as wrong output: `Gas gost` and `NOTE ELIGIBLE` both lost points. Read your output next to the sample run, word by word.

**File names:** one task per file, named the way the step says (like `step02_p01.py`). Don't put all three tasks in one file.

---

## How to check your own work

Before you push, do this for **every** sample run:

1. Run the program and type the sample run's inputs.
2. Put your output next to the sample run.
3. Check: same words, same spaces, same decimal places, no extra lines.
4. Run the "Test these too" inputs from the task.

---

## Practice: Find the mistakes

This program is supposed to match the sample run below. It has **6 mistakes**. Find them, then fix them.

**Sample run**
```
Item: Hoodie
Price: 24.5
Quantity: 3

--- Order for Hoodie ---
Subtotal:  $73.50
Tax:       $4.78
Total:     $78.28
```

**Program with mistakes**
```python
tax_rate = 0.065

item = input("What item?")
price = int(input("Price: "))
quantity = int(input("Quantity: "))

subtotal = price * quantity
tax = round(subtotal * 0.065, 1)
total = subtotal + tax

print()
print("--- Order for", item, "---")
print(f"Subtotal:\t${subtotal:.2f}")
print(f"Tax:       ${tax:.2f}")
print(f"Total:     ${total}")
```

<details>
<summary>Answers (click to open)</summary>

1. `tax_rate` should be a constant in ALL_CAPS (`TAX_RATE`), and the math should use it instead of typing `0.065`.
2. The prompt should be `"Item: "`, not `"What item?"`.
3. Price is money, so it needs `float()`. `int()` crashes on `24.5`.
4. `round(..., 1)` rounds too early. Take out `round()`.
5. `\t` should be two spaces: `Subtotal:  $`.
6. Total needs `:.2f`.

(The `--- Order for` line with commas happens to work, but the f-string version is safer.)

**Fixed program**
```python
TAX_RATE = 0.065

item = input("Item: ")
price = float(input("Price: "))
quantity = int(input("Quantity: "))

subtotal = price * quantity
tax = subtotal * TAX_RATE
total = subtotal + tax

print()
print(f"--- Order for {item} ---")
print(f"Subtotal:  ${subtotal:.2f}")
print(f"Tax:       ${tax:.2f}")
print(f"Total:     ${total:.2f}")
```
</details>
