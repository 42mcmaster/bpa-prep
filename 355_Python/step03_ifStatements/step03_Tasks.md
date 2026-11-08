# Step 03 Tasks — If Statements (Python)

**Do these after the [Step 3 lesson](step03_Lesson.md).** The lesson's Grade Checker is the walkthrough. These three tasks are extra practice with the same skills.
**Time:** about two class periods for all three. Task A is the shortest; Task C is the longest.

Each task also uses skills from Steps 1 and 2: header comments, `input`, `int` and `float`, named constants, and money with 2 decimal places.

## Table of Contents
- [Task A: Movie Ticket Price](#task-a-movie-ticket-price)
- [Task B: Shipping Calculator](#task-b-shipping-calculator)
- [Task C: BPA Eligibility Checker](#task-c-bpa-eligibility-checker)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Task A: Movie Ticket Price

Write a program that figures out the price of one movie ticket.

**Requirements**
1. Header comment.
2. Ask for the name, age (whole number), day of the week, and whether the movie is 3D, using the exact prompts in the sample runs.
3. Store every price in a named constant at the top of the file:

   | Constant | Value |
   |---|---|
   | `CHILD_PRICE` | 7.00 |
   | `ADULT_PRICE` | 11.00 |
   | `SENIOR_PRICE` | 8.00 |
   | `TUESDAY_DISCOUNT` | 3.00 |
   | `THREE_D_CHARGE` | 2.50 |

4. If the age is below 0 or above 120, print `Error: age must be 0 to 120.` and nothing else. Use `or` in this check.
5. Otherwise, pick the ticket type with an `if`/`elif`/`else` chain:
   - under 13 → `Child`
   - 65 or older → `Senior`
   - everyone else → `Adult`
6. If the day is Tuesday, take off the Tuesday discount. This must work for `Tuesday`, `tuesday`, or `TUESDAY` (use `.lower()`).
7. If the answer to the 3D question is `y` or `Y`, add the 3D charge.
8. Print the ticket exactly as shown. The `Tuesday deal` line and the `3D charge` line only print when they apply.
9. Input / Processing / Output comments.

**Sample run 1**
```
Name: Avery
Age: 34
Day of the week: Friday
3D movie? (y/n): n

--- Ticket for Avery ---
Ticket type:   Adult
Base price:    $11.00
Total:         $11.00
```

**Sample run 2**
```
Name: Mia
Age: 9
Day of the week: Tuesday
3D movie? (y/n): y

--- Ticket for Mia ---
Ticket type:   Child
Base price:    $7.00
Tuesday deal: -$3.00
3D charge:     $2.50
Total:         $6.50
```

**Sample run 3**
```
Name: Grandpa Joe
Age: 70
Day of the week: TUESDAY
3D movie? (y/n): n

--- Ticket for Grandpa Joe ---
Ticket type:   Senior
Base price:    $8.00
Tuesday deal: -$3.00
Total:         $5.00
```

**Sample run 4**
```
Name: Kai
Age: 130
Day of the week: Monday
3D movie? (y/n): y
Error: age must be 0 to 120.
```

**Hints**
- Ask all four questions first, then do the age check.
- Use two separate `if` statements for Tuesday and 3D, not `elif`. A ticket can get both.
- Keep a `total` variable. Start it at the base price, then subtract or add.
- The `Tuesday deal` line has a minus sign right before the `$`, so it has one less space after the colon. Count the spaces.

**Test these too:** age 12 and 13 (child/adult edge), age 64 and 65 (adult/senior edge), age 0, and `tuesday` in lowercase.

---

## Task B: Shipping Calculator

Write a program that figures out the shipping cost and delivery time for an online order.

**Requirements**
1. Header comment.
2. Ask for the order total, package weight in pounds (both decimals), shipping zone (whole number), and rush delivery (y/n), using the exact prompts.
3. Store these in named constants:

   | Constant | Value |
   |---|---|
   | `ZONE1_RATE` | 0.50 (per pound) |
   | `ZONE2_RATE` | 0.75 (per pound) |
   | `ZONE3_RATE` | 1.25 (per pound) |
   | `MINIMUM_SHIPPING` | 4.00 |
   | `FREE_SHIPPING_AMOUNT` | 50.00 |
   | `RUSH_FEE` | 10.00 |

4. Check the input in this order:
   - If the order total or the weight is 0 or less, print `Error: order total and weight must be more than 0.` and stop.
   - Otherwise, if the zone is not 1, 2, or 3, print `Error: zone must be 1, 2, or 3.` and stop.
5. Figure out the shipping with these rules, **in this order**:

   | Rule | What happens |
   |---|---|
   | Zone rate | Shipping = weight × the zone's rate. Zone 1 takes 2 days, zone 2 takes 4 days, zone 3 takes 6 days. |
   | Minimum | If shipping is less than $4.00, make it $4.00. |
   | Free shipping | If the order total is $50.00 or more **and** it is **not** rush, shipping is $0. |
   | Rush | If rush, add the $10.00 rush fee. Rush delivery takes 1 day for zones 1 and 2, and 2 days for zone 3. |
   | Heavy package | If the weight is more than 50 pounds, add 2 days. |

6. Print the summary exactly as shown:
   - Print `FREE` instead of `$0.00` when shipping is free.
   - Print `1 day` (not `1 days`) when it arrives in one day.
   - Print the heavy package note only for packages over 50 pounds.
7. Input / Processing / Output comments.

**Sample run 1**
```
Order total: 32.00
Package weight (lbs): 6
Shipping zone (1-3): 2
Rush delivery? (y/n): n

--- Shipping Summary ---
Order total:  $32.00
Shipping:     $4.50
Grand total:  $36.50
Arrives in:   4 days
```

**Sample run 2**
```
Order total: 64.50
Package weight (lbs): 3
Shipping zone (1-3): 1
Rush delivery? (y/n): n

--- Shipping Summary ---
Order total:  $64.50
Shipping:     FREE
Grand total:  $64.50
Arrives in:   2 days
```

**Sample run 3**
```
Order total: 75.00
Package weight (lbs): 12
Shipping zone (1-3): 3
Rush delivery? (y/n): y

--- Shipping Summary ---
Order total:  $75.00
Shipping:     $25.00
Grand total:  $100.00
Arrives in:   2 days
```

**Sample run 4**
```
Order total: 20.00
Package weight (lbs): 60
Shipping zone (1-3): 1
Rush delivery? (y/n): y

--- Shipping Summary ---
Order total:  $20.00
Shipping:     $40.00
Grand total:  $60.00
Arrives in:   3 days
Note: heavy package, 2 extra days added.
```

**Sample run 5**
```
Order total: 15
Package weight (lbs): 2
Shipping zone (1-3): 5
Rush delivery? (y/n): n
Error: zone must be 1, 2, or 3.
```

**Hints**
- Save the rush answer as a True/False variable once: `is_rush = rush.lower() == "y"`. Then you can write `if is_rush:` and `not is_rush`.
- Set both `rate` and `days` inside the same `if`/`elif`/`else` chain for the zone.
- Follow the rules table top to bottom. Each rule is its own `if`. The order matters: in Sample run 3 the order is over $50, but it is rush, so it does not get free shipping.
- Check Sample run 1 by hand: 6 × 0.75 = 4.50, which is more than the $4.00 minimum.

**Test these too:** a 2-pound zone 1 package (should hit the $4.00 minimum), an order of exactly $50.00, and a weight of exactly 50 (not heavy).

---

## Task C: BPA Eligibility Checker

Write a program a chapter advisor could use to check whether a member can compete at BPA.

**Requirements**
1. Header comment.
2. Ask for the member's name, grade (whole number), GPA (decimal), whether dues are paid (y/n), and how many events they signed up for (whole number), using the exact prompts.
3. Store these in named constants: `MIN_GPA = 2.0`, `OFFICER_GPA = 3.0`, `HONOR_GPA = 3.5`, `MAX_EVENTS = 2`.
4. Check the input:
   - If the grade is not 9 to 12, print `Error: grade must be 9 to 12.` and stop.
   - Otherwise, if the GPA is below 0.0 or above 4.0, print `Error: GPA must be 0.0 to 4.0.` and stop.
5. A member is **eligible** if dues are paid **and** the GPA is at least 2.0.
6. If eligible, print `Status: ELIGIBLE`, then **one** of these, based on the number of events:

   | Events | Print |
   |---|---|
   | 0 | `Sign up for at least one event.` |
   | 1 | `You are entered in 1 event.` |
   | 2 | `You are entered in 2 events.` |
   | more than 2 | `You can only enter 2 events. Drop N.` (N is how many extra) |

7. If not eligible, print `Status: NOT ELIGIBLE`, then **every** reason that applies:
   - `Reason: dues not paid.`
   - `Reason: GPA is below 2.0.`
8. After that, for **every** member who passed the input checks (eligible or not):
   - If grade 11 or 12 **and** GPA 3.0 or higher, print `You can run for chapter office.`
   - If grade 12 **and** GPA 3.5 or higher, print `Senior honor cord: yes`
9. Input / Processing / Output comments.

**Sample run 1**
```
Member name: Jordan
Grade (9-12): 11
GPA (0.0-4.0): 3.2
Dues paid? (y/n): y
Events signed up for: 2

--- BPA Check for Jordan ---
Status: ELIGIBLE
You are entered in 2 events.
You can run for chapter office.
```

**Sample run 2**
```
Member name: Sam
Grade (9-12): 10
GPA (0.0-4.0): 1.8
Dues paid? (y/n): n
Events signed up for: 1

--- BPA Check for Sam ---
Status: NOT ELIGIBLE
Reason: dues not paid.
Reason: GPA is below 2.0.
```

**Sample run 3**
```
Member name: Riley
Grade (9-12): 12
GPA (0.0-4.0): 3.9
Dues paid? (y/n): y
Events signed up for: 4

--- BPA Check for Riley ---
Status: ELIGIBLE
You can only enter 2 events. Drop 2.
You can run for chapter office.
Senior honor cord: yes
```

**Sample run 4**
```
Member name: Max
Grade (9-12): 12
GPA (0.0-4.0): 2.5
Dues paid? (y/n): y
Events signed up for: 0

--- BPA Check for Max ---
Status: ELIGIBLE
Sign up for at least one event.
```

**Sample run 5**
```
Member name: Lee
Grade (9-12): 8
GPA (0.0-4.0): 3.0
Dues paid? (y/n): y
Events signed up for: 1
Error: grade must be 9 to 12.
```

**Hints**
- This task uses a **nested if**: the events check goes **inside** the eligible branch.
- The two reasons in requirement 7 are separate `if` statements, so a member can get both. Use `not` for the dues reason.
- The office and honor checks in requirement 8 are **not** inside the eligible branch. Line them up with the eligible `if`, not inside it. A member who has not paid dues can still have the grades to run for office.
- Draw the decisions on paper first: input check → eligible or not → events or reasons → office → honor cord.

**Test these too:** GPA exactly 2.0, exactly 3.0, and exactly 3.5; a grade 10 student with a 4.0 (no office message); dues `Y` in capital letters; 3 events (should say `Drop 1.`).

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step03` folder.
2. Save the tasks as `step03_taskA.py`, `step03_taskB.py`, and `step03_taskC.py`.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 3 tasks done*.

## Checklist
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] I tested the extra inputs listed under each task
- [ ] Header comment and named constants at the top of each file
- [ ] Input / Processing / Output comments in each file
- [ ] Pushed to `bpaPrep/python_step03`
