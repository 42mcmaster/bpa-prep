# Builds for Step 02 — Variables and Input (Python)

These are BPA-style programs that use the Step 2 skills together with everything before it. They are bigger than the practice problems, and closer to what the BPA test asks for.

**Do these after you finish Steps 1–3 (lessons and practice).** Use the [Step 2 Study Guide](../step02_variablesAndInput/step02_StudyGuide.md) for help.

## Table of Contents
- [Build 2A: Snack Bar Order](#build-2a-snack-bar-order)
- [Build 2B: Pizza Party Planner](#build-2b-pizza-party-planner)
- [Build 2C: Road Trip Calculator](#build-2c-road-trip-calculator)
- [Build 2D: Paycheck Calculator](#build-2d-paycheck-calculator)
- [A note about pennies](#a-note-about-pennies)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Build 2A: Snack Bar Order
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

---

## Build 2B: Pizza Party Planner
Write a program that plans the pizza for a party: how many whole pizzas, how many extra slices, and what it costs.

**Requirements**
1. Header comment.
2. Ask for the host's name, the number of people (whole number), and slices per person (whole number), using the exact prompts in the sample runs.
3. Store these in named constants at the top of the file:

   | Constant | Value |
   |---|---|
   | `SLICES_PER_PIZZA` | 8 |
   | `PIZZA_PRICE` | 12.99 |
   | `SLICE_PRICE` | 2.25 |

4. Calculate:
   - total slices = people × slices per person
   - whole pizzas = total slices `//` slices per pizza
   - extra slices = total slices `%` slices per pizza (these are bought by the slice)
   - total cost = whole pizzas × pizza price + extra slices × slice price
   - cost per person = total cost ÷ people
5. Print the plan exactly as shown, with money to 2 decimal places.
6. Input / Processing / Output comments.

**Sample run 1**
```
Host name: Jordan
Number of people: 10
Slices per person: 3

=== Pizza Plan for Jordan's Party ===
Slices needed:    30
Whole pizzas:     3
Extra slices:     6
Total cost:       $52.47
Cost per person:  $5.25
```

**Sample run 2**
```
Host name: Priya
Number of people: 6
Slices per person: 2

=== Pizza Plan for Priya's Party ===
Slices needed:    12
Whole pizzas:     1
Extra slices:     4
Total cost:       $21.99
Cost per person:  $3.67
```

**Hints**
- Check run 1 by hand: 10 × 3 = 30 slices. 30 // 8 = 3 pizzas. 30 % 8 = 6 extra slices. 3 × 12.99 + 6 × 2.25 = 52.47.
- `{host}'s Party` — the apostrophe goes right after the curly brace, inside the f-string.
- All the values line up because each label is followed by the right number of spaces. Count them.

**Test these too:** 4 people × 2 slices (exactly 1 pizza, 0 extra), 1 person × 3 slices (0 pizzas, 3 extra).

---

## Build 2C: Road Trip Calculator
Write a program that figures out gas, cost per person, and driving time for a road trip.

**Requirements**
1. Header comment.
2. Ask for the destination, trip distance in miles (decimal), the car's miles per gallon (decimal), the gas price (decimal), and the number of people splitting the cost (whole number), using the exact prompts.
3. Store the average speed in a named constant: `AVERAGE_SPEED = 55` (miles per hour).
4. Calculate:
   - gallons = miles ÷ miles per gallon
   - gas cost = gallons × gas price
   - cost per person = gas cost ÷ people
   - driving time in minutes = miles ÷ average speed × 60, turned into a whole number with `int()`
   - hours = minutes `//` 60, and leftover minutes = minutes `%` 60
   - round trip gas = gas cost × 2
5. Print the summary exactly as shown. Gallons have **1** decimal place. Money has **2**.
6. The driving time line must use the `AVERAGE_SPEED` constant in the f-string (not a typed `55`).
7. Input / Processing / Output comments.

**Sample run 1**
```
Destination: Columbus
Trip distance (miles): 150
Car's miles per gallon: 30
Gas price per gallon: 3.20
Number of people splitting the cost: 2

--- Trip to Columbus ---
Gallons of gas:   5.0
Gas cost:         $16.00
Cost per person:  $8.00
Driving time:     2 hr 43 min (at 55 mph)
Round trip gas:   $32.00
```

**Sample run 2**
```
Destination: Cedar Point
Trip distance (miles): 62
Car's miles per gallon: 28
Gas price per gallon: 3.19
Number of people splitting the cost: 4

--- Trip to Cedar Point ---
Gallons of gas:   2.2
Gas cost:         $7.06
Cost per person:  $1.77
Driving time:     1 hr 7 min (at 55 mph)
Round trip gas:   $14.13
```

**Hints**
- Check run 1 by hand: 150 ÷ 30 = 5.0 gallons. 5.0 × 3.20 = $16.00. 150 ÷ 55 × 60 = 163.6 minutes, and `int()` chops that to 163. 163 // 60 = 2 hours, 163 % 60 = 43 minutes.
- `int()` chops off the decimal. It does not round. That is what you want here.
- `Car's` has an apostrophe. Inside double quotes, that is fine.
- In run 2, round trip gas is `$14.13`, not `$14.12`. See [A note about pennies](#a-note-about-pennies).

---

## Build 2D: Paycheck Calculator
Write a program that prints a weekly pay stub with taxes taken out, plus yearly totals.

**Requirements**
1. Header comment.
2. Ask for the employee name, hourly pay rate (decimal), and hours worked this week (decimal), using the exact prompts.
3. Store these in named constants:

   | Constant | Value |
   |---|---|
   | `FEDERAL_TAX_RATE` | 0.10 |
   | `STATE_TAX_RATE` | 0.035 |
   | `SOCIAL_SECURITY_RATE` | 0.062 |
   | `MEDICARE_RATE` | 0.0145 |
   | `WEEKS_PER_YEAR` | 52 |

4. Calculate:
   - gross pay = rate × hours
   - each tax = gross pay × its rate (four separate variables)
   - total taken out = the four taxes added together
   - net pay = gross pay − total taken out
   - percent kept = net pay ÷ gross pay × 100
   - yearly gross = gross pay × weeks per year, and yearly net = net pay × weeks per year
5. Print the pay stub exactly as shown. Hours and percent kept have **1** decimal place. Money has **2**.
6. The border lines are 32 characters. Use `"=" * 32` and `"-" * 32`.
7. Input / Processing / Output comments. Use at least two separate `Processing:` comments (one for the paycheck, one for the yearly numbers).

**Sample run 1**
```
Employee name: Avery
Hourly pay rate: 16.00
Hours worked this week: 25

================================
PAY STUB: Avery
================================
Hours worked:      25.0
Hourly rate:       $16.00
Gross pay:         $400.00
--------------------------------
Federal tax (10%): $40.00
State tax (3.5%):  $14.00
Social Security:   $24.80
Medicare:          $5.80
Total taken out:   $84.60
--------------------------------
NET PAY:           $315.40
================================
You keep 78.8% of what you earn.
Yearly gross: $20800.00
Yearly net:   $16400.80
```

**Sample run 2**
```
Employee name: Sam
Hourly pay rate: 14.25
Hours worked this week: 30

================================
PAY STUB: Sam
================================
Hours worked:      30.0
Hourly rate:       $14.25
Gross pay:         $427.50
--------------------------------
Federal tax (10%): $42.75
State tax (3.5%):  $14.96
Social Security:   $26.50
Medicare:          $6.20
Total taken out:   $90.42
--------------------------------
NET PAY:           $337.08
================================
You keep 78.8% of what you earn.
Yearly gross: $22230.00
Yearly net:   $17528.35
```

**Hints**
- Do not round anything in your math. Only format when you print.
- `PAY STUB: {worker}` — the name goes right in the f-string.
- The dollar values line up because every label plus its spaces is the same width (19 characters). Count the spaces after each label.
- In run 2, adding the four printed taxes gives $90.41, but the stub says $90.42. That is correct. See [A note about pennies](#a-note-about-pennies).

---

## A note about pennies
Your program does math with the full numbers (like 26.505), and only rounds when it prints. So if you add up the **printed** numbers yourself, you can be off by a penny. That is normal, and the sample runs were made the same way. Do the math with the full values, and format only in the `print` lines, and your output will match.

---

## Turn it in
1. In your `bpaPrep` repo, make a folder named `python_builds` (one folder for all builds).
2. Save the builds as `build02A.py`, `build02B.py`, `build02C.py`, and `build02D.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `TAX_RATE = 0.07` is a named constant near the top
- [ ] Price uses `float()`, quantity uses `int()`
- [ ] All money shows 2 decimal places with `$`
- [ ] Pushed to `bpaPrep/python_builds`
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] I tested the extra inputs listed under Build 2B
- [ ] Every rate and price is a named constant in ALL_CAPS at the top
- [ ] Input / Processing / Output comments in each file
