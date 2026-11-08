# Step 05 Tasks — Functions (Python)

**Do these after the [Step 5 lesson](step05_Lesson.md).** The lesson's Snack Bar with Functions is the walkthrough. These three tasks are extra practice with the same skills.

Each task also uses skills from Steps 1–4: input, math, money to 2 decimals, `if`/`elif`/`else`, and loops.

**Rules for every task in this step**
- Every function has a comment with its **purpose**, **parameters**, and **return value** (docstring style from the lesson).
- All the code that runs goes inside functions. The only code outside a function is the header comment, constants, the `def` lines, and these two lines at the very end:
  ```python
  if __name__ == "__main__":
      main()
  ```
- Use the **exact** function names and parameters listed. BPA tests often name the functions they want.

## Table of Contents
- [Task A: Temperature Converter](#task-a-temperature-converter)
- [Task B: Class Grade Report](#task-b-class-grade-report)
- [Task C: Phone Bill Calculator](#task-c-phone-bill-calculator)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Task A: Temperature Converter

Write a program that converts temperatures between Fahrenheit and Celsius and says how the temperature feels.

**Requirements**
1. Header comment.
2. Write these functions:

   | Function | What it does |
   |---|---|
   | `f_to_c(fahrenheit)` | returns `(fahrenheit - 32) * 5 / 9` |
   | `c_to_f(celsius)` | returns `celsius * 9 / 5 + 32` |
   | `describe(fahrenheit)` | returns `Freezing` (32 or below), `Cold` (below 50), `Mild` (below 70), `Warm` (below 85), or `Hot` |
   | `print_result(start_temp, start_unit, end_temp, end_unit, feel)` | prints the two result lines, returns nothing |
   | `main()` | runs the program |

3. In `main`, ask `Convert from (F/C): `. Accept capital or lowercase.
   - If it is F, ask for the temperature, convert it to C, and describe it.
   - If it is C, ask for the temperature, convert it to F, and describe the **Fahrenheit** answer.
   - Anything else: print `Please type F or C.` (do not ask for a temperature).
4. Temperatures print with **1** decimal place.
5. After each one, ask `Convert another? (y/n): ` and print a blank line.
6. At the end, print `Conversions done: N`. Bad unit answers do not count.
7. Input / Processing / Output comments.

**Sample run**
```
Convert from (F/C): F
Temperature: 72
72.0 F = 22.2 C
That feels: Warm
Convert another? (y/n): y

Convert from (F/C): c
Temperature: -5
-5.0 C = 23.0 F
That feels: Freezing
Convert another? (y/n): y

Convert from (F/C): k
Please type F or C.
Convert another? (y/n): y

Convert from (F/C): f
Temperature: 98.6
98.6 F = 37.0 C
That feels: Hot
Convert another? (y/n): n

Conversions done: 3
```

**Hints**
- `describe` only works with Fahrenheit. For a C input, pass it the converted F value.
- `describe` uses `return` inside each branch of the `if`/`elif`/`else`. As soon as a `return` runs, the function is done.
- `print_result` does the printing. `f_to_c`, `c_to_f`, and `describe` only **return** values. They never call `print`.
- Make the unit uppercase right away: `unit = input("...").upper()`.

**Test these too:** exactly 32 F (Freezing), 0 C (Freezing), 100 C (Hot), and 50 F (Mild, not Cold).

---

## Task B: Class Grade Report

Write a program that averages three test scores for each student in a class, then prints class stats.

**Requirements**
1. Header comment. Store the passing average in a constant: `PASSING_AVERAGE = 60`.
2. Write these functions:

   | Function | What it does |
   |---|---|
   | `get_average(score1, score2, score3)` | returns the average of the three scores |
   | `letter_grade(average)` | returns `A` (90+), `B` (80+), `C` (70+), `D` (60+), or `F` |
   | `is_passing(average)` | returns `True` if the average is at least `PASSING_AVERAGE`, otherwise `False` |
   | `print_report_line(name, average, letter, passing)` | prints one line like `Avery: average 91.7, grade A, PASS`, returns nothing |
   | `main()` | runs the program |

3. In `main`, ask `How many students? `. If it is less than 1, print `Enter at least 1 student.` and ask again until it is good.
4. Use a `for` loop to go through the students. For each one:
   - print a blank line and `Student N`
   - ask for the name and three scores (whole numbers)
   - call the functions and print the report line
5. Keep track of the class total, how many passed, and the top student (highest average and their name).
6. After all students, print the class summary exactly as shown. The class letter grade comes from calling `letter_grade` on the class average.
7. Averages print with **1** decimal place.
8. Input / Processing / Output comments.

**Sample run**
```
How many students? 0
Enter at least 1 student.
How many students? 3

Student 1
Name: Avery
Score 1: 92
Score 2: 88
Score 3: 95
Avery: average 91.7, grade A, PASS

Student 2
Name: Jordan
Score 1: 71
Score 2: 65
Score 3: 80
Jordan: average 72.0, grade C, PASS

Student 3
Name: Sam
Score 1: 55
Score 2: 62
Score 3: 48
Sam: average 55.0, grade F, FAIL

--- Class Summary ---
Class average: 72.9 (C)
Passed: 2 of 3
Top student: Avery (91.7)
```

**Hints**
- `is_passing` can be one line: `return average >= PASSING_AVERAGE`. A comparison already gives `True` or `False`.
- `print_report_line` gets a True/False value. Turn it into the word `PASS` or `FAIL` inside the function with an `if`.
- For the top student, start `best_average` at `-1.0` so the first student always beats it. When a student's average is higher, save **both** the average and the name.
- The variables for class stats are local to `main`. Set them up before the `for` loop.

**Test these too:** 1 student, a student with exactly 60 (PASS, D), and two students tied for top (the first one entered stays on top).

---

## Task C: Phone Bill Calculator

Write a program a phone store clerk could use to print monthly bills for several customers, then a store summary.

**Requirements**
1. Header comment. Store these in constants: `LINE_PRICE = 30.00`, `MULTI_LINE_DISCOUNT = 0.10`, `TAX_RATE = 0.06`.
2. Write these functions:

   | Function | What it does |
   |---|---|
   | `line_cost(lines)` | returns lines × `LINE_PRICE`. If there are 3 or more lines, take 10% off that amount. |
   | `data_cost(gigabytes)` | returns 10.00 for 5 GB or less, 25.00 for 15 GB or less, otherwise 40.00 |
   | `calculate_tax(subtotal)` | returns subtotal × `TAX_RATE` |
   | `format_money(amount)` | returns text like `$12.04` |
   | `print_bill(name, lines, gigabytes)` | calls the functions above, prints the bill, and **returns the bill total** |
   | `main()` | runs the program |

3. In `main`, ask for the customer name, number of lines (whole number), and data used in GB (decimal). Call `print_bill` and save what it returns.
4. Ask `Another customer? (y/n): ` after each bill. Keep going for `y` or `Y`.
5. Keep track of the number of customers, the total billed, and the biggest bill (and whose it was).
6. Print each bill and the store summary exactly as shown. The `(10% multi-line discount applied)` line only prints for 3 or more lines.
7. Every money amount is printed with `format_money`.
8. Input / Processing / Output comments.

**Sample run**
```
Customer name: Garcia Family
Number of lines: 4
Data used (GB): 22

--- Bill for Garcia Family ---
Lines:        4 x $30.00
Line cost:    $108.00
  (10% multi-line discount applied)
Data used:    22.0 GB
Data cost:    $40.00
Tax (6%):     $8.88
Total:        $156.88

Another customer? (y/n): y
Customer name: Lee
Number of lines: 1
Data used (GB): 3.5

--- Bill for Lee ---
Lines:        1 x $30.00
Line cost:    $30.00
Data used:    3.5 GB
Data cost:    $10.00
Tax (6%):     $2.40
Total:        $42.40

Another customer? (y/n): n

=== Store Summary ===
Customers billed: 2
Total billed:     $199.28
Average bill:     $99.64
Biggest bill:     Garcia Family ($156.88)
```

**Hints**
- `print_bill` both prints **and** returns. That is allowed. It prints the bill for the customer and gives the total back to `main` so `main` can add it up.
- Check the Garcia bill by hand: 4 × 30 = 120, minus 10% = 108. Data over 15 GB = 40. Subtotal 148. Tax 148 × 0.06 = 8.88. Total 156.88.
- `Lines:        4 x $30.00` uses `format_money(LINE_PRICE)` for the price.
- The average bill is total billed ÷ customers. You can call `format_money` right inside the f-string.

**Test these too:** exactly 3 lines (discount), exactly 2 lines (no discount), exactly 5 GB and exactly 15 GB.

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step05` folder.
2. Save the tasks as `step05_taskA.py`, `step05_taskB.py`, and `step05_taskC.py`.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 5 tasks done*.

## Checklist
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] I tested the extra inputs listed under each task
- [ ] Every function has a purpose / parameters / returns comment
- [ ] Function names and parameters match the tables exactly
- [ ] All code is inside functions, and the file ends with `if __name__ == "__main__":` and `main()`
- [ ] Pushed to `bpaPrep/python_step05`
