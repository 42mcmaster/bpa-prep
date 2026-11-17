# Step 05 Practice — Functions (Python)

**Do these after the [Step 5 lesson](step05_Lesson.md).** Each problem is short. The goal is lots of practice writing and calling functions before the bigger BPA-style programs.

**Time:** about one class period for Problems 1–12. The Challenge at the end takes longer.

**Need help?** Use the [Step 5 Study Guide](step05_StudyGuide.md). Every problem lists the study guide section that shows how.

Problems marked **(review)** use skills from earlier steps, so you keep practicing them.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: A welcome banner](#problem-1-a-welcome-banner)
- [Problem 2: Greet three people](#problem-2-greet-three-people)
- [Problem 3: Square numbers](#problem-3-square-numbers)
- [Problem 4: Average of three](#problem-4-average-of-three)
- [Problem 5: Even or odd](#problem-5-even-or-odd)
- [Problem 6: Letter grade](#problem-6-letter-grade)
- [Problem 7: Tip calculator](#problem-7-tip-calculator)
- [Problem 8: A line of any length](#problem-8-a-line-of-any-length)
- [Problem 9: Rectangle area and perimeter](#problem-9-rectangle-area-and-perimeter)
- [Problem 10: Temperature table](#problem-10-temperature-table)
- [Problem 11: Bigger of two](#problem-11-bigger-of-two)
- [Problem 12: Use main()](#problem-12-use-main)
- [Challenge: Pizza Order](#challenge-pizza-order)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step05_p01.py`, `step05_p02.py`, and so on.
2. Start each file with a header comment (name, date, program name).
3. **Every function gets a comment** with its Purpose, Parameters, and Returns, like the lesson shows.
4. Use the **exact** prompts and output shown. Same words, same spaces.
5. Run your program with the sample input and compare your output to the sample run, line by line.

---

## Problem 1: A welcome banner
Write a function `print_banner()` that prints the banner below. Call it **two** times.

**Sample run**
```
====================
  BPA Python Club
====================
====================
  BPA Python Club
====================
```

**Hints**
- Define the function first, then call it on two separate lines with `print_banner()`.
- `"=" * 20` makes the line of 20 equal signs.

**Study guide:** [Defining and calling a function](step05_StudyGuide.md#defining-and-calling-a-function)

---

## Problem 2: Greet three people
Write a function `greet(name)` that prints a greeting. Call it three times with `"Avery"`, `"Blake"`, and `"Casey"`.

**Sample run**
```
Hello, Avery! Welcome to class.
Hello, Blake! Welcome to class.
Hello, Casey! Welcome to class.
```

**Hint:** `name` is the parameter. `"Avery"` is the argument you send in.

**Study guide:** [Parameters and arguments](step05_StudyGuide.md#parameters-and-arguments)

---

## Problem 3: Square numbers
*(review: Step 4 for loops)*

Write a function `square(number)` that **returns** the number times itself. Use a `for` loop to print the squares of 1 through 5.

**Sample run**
```
1 squared is 1
2 squared is 4
3 squared is 9
4 squared is 16
5 squared is 25
```

**Hints**
- The function only does the math and `return`s it. The `print` goes in the loop.
- `range(1, 6)` gives 1 to 5.

**Study guide:** [Return values](step05_StudyGuide.md#return-values)

---

## Problem 4: Average of three
Write a function `average_of_three(a, b, c)` that returns the average of three numbers. Ask the user for three test scores, then print the average to 1 decimal place.

**Sample run**
```
Score 1: 88
Score 2: 92
Score 3: 73
Average: 84.3
```

**Hint:** Put parentheses around the adding: `(a + b + c) / 3`. Without them, only `c` gets divided.

**Study guide:** [Return values](step05_StudyGuide.md#return-values)

---

## Problem 5: Even or odd
*(review: Step 3 if statements)*

Write a function `is_even(number)` that returns `True` if the number is even and `False` if it is odd. Ask for a number and print the result as a sentence.

**Sample run 1**
```
Enter a number: 14
14 is even.
```

**Sample run 2**
```
Enter a number: 7
7 is odd.
```

**Hints**
- `number % 2 == 0` is already True or False, so you can return it directly.
- `if is_even(number):` calls the function and checks what it returns.

**Study guide:** [Return values](step05_StudyGuide.md#return-values)

---

## Problem 6: Letter grade
*(review: Step 3 if/elif/else)*

Write a function `letter_grade(score)` that returns `A` (90 and up), `B` (80–89), `C` (70–79), `D` (60–69), or `F` (below 60). Ask for a score and print the letter.

**Sample run 1**
```
Score: 84
Letter grade: B
```

**Sample run 2**
```
Score: 59
Letter grade: F
```

**Hints**
- Each `return` ends the function, so check from the top grade down.
- Test the edges: 90, 89, 60, 59.

**Study guide:** [Return values](step05_StudyGuide.md#return-values)

---

## Problem 7: Tip calculator
*(review: Step 2 money formatting)*

Write a function `calculate_tip(bill, percent)` that returns the tip. Ask for the bill and the tip percent, then print the tip and the total.

**Sample run**
```
Bill amount: 48.50
Tip percent: 20
Tip:   $9.70
Total: $58.20
```

**Hints**
- Money is `float`. The percent is a whole number, so `int`.
- Only format with `:.2f` in the `print` lines.

**Study guide:** [The function comment](step05_StudyGuide.md#the-function-comment)

---

## Problem 8: A line of any length
*(review: Step 4 building a string)*

Write a function `print_line(symbol, length)` that prints `symbol` repeated `length` times. Call it with `("*", 10)`, `("-", 15)`, and `("#", 5)`.

**Sample run**
```
**********
---------------
#####
```

**Hints**
- Build the line with a `for` loop, like the star bar in Step 4.
- The arguments go in the same order as the parameters: symbol first, then length.

**Study guide:** [Parameters and arguments](step05_StudyGuide.md#parameters-and-arguments)

---

## Problem 9: Rectangle area and perimeter
Write two functions: `calculate_area(width, height)` and `calculate_perimeter(width, height)`. Each one returns its answer. Ask for the width and height and print both.

**Sample run**
```
Width: 12
Height: 8.5
Area:      102.0
Perimeter: 41.0
```

**Hint:** Two separate `def` blocks. Each one has its own function comment.

**Study guide:** [Return values](step05_StudyGuide.md#return-values)

---

## Problem 10: Temperature table
*(review: Step 4 range with a step)*

Write a function `to_fahrenheit(celsius)` that returns the Fahrenheit temperature (`celsius * 9 / 5 + 32`). Use a `for` loop to print a table from 0 to 100 Celsius, counting by 20.

**Sample run**
```
Celsius  Fahrenheit
0        32.0
20       68.0
40       104.0
60       140.0
80       176.0
100      212.0
```

**Hints**
- `range(0, 101, 20)` gives 0, 20, 40, 60, 80, 100.
- `{celsius:<9}` prints the number in a space 9 characters wide, lined up on the left. That keeps the columns even.

**Study guide:** [Return values](step05_StudyGuide.md#return-values)

---

## Problem 11: Bigger of two
Write a function `bigger(a, b)` that returns the bigger of two numbers. Don't use Python's `max()`; use an `if`. Ask for two numbers and print the bigger one.

**Sample run**
```
First number: 17
Second number: 42
The bigger number is 42
```

**Hint:** If the two numbers are equal, it doesn't matter which one you return.

**Study guide:** [Return values](step05_StudyGuide.md#return-values)

---

## Problem 12: Use main()
Write a function `calculate_total(price, quantity)` that returns the cost of an order. Put the input and output in a `main()` function, and start the program with `if __name__ == "__main__":`.

**Sample run**
```
Item: hoodies
Price: 24.99
Quantity: 2
2 hoodies cost $49.98
```

**Hints**
- The last two lines of the file are `if __name__ == "__main__":` and `main()` (indented).
- Two underscores on each side of `name` and `main`.

**Study guide:** [The main function](step05_StudyGuide.md#the-main-function)

---

## Challenge: Pizza Order
This one puts the pieces together: functions that return values, a function that prints, a loop that asks again, and `main()`.

**Requirements**
1. Header comment, and Input / Processing / Output comments.
2. Named constants: `PIZZA_PRICE = 11.99` and `TAX_RATE = 0.0675`.
3. Write these functions, each with a Purpose / Parameters / Returns comment:

   | Function | What it does |
   |---|---|
   | `get_pizza_count()` | asks `How many pizzas? (1-10): ` until the answer is 1 to 10, then **returns** it. A bad answer prints `Please enter 1 to 10.` |
   | `calculate_subtotal(pizzas)` | **returns** pizzas × price |
   | `calculate_tax(subtotal)` | **returns** subtotal × tax rate |
   | `print_receipt(name, pizzas, subtotal, tax)` | **prints** the receipt |
   | `main()` | asks for the name, then calls the other functions in order |

4. Start the program with `if __name__ == "__main__":` and `main()`.
5. Print the receipt exactly as shown.

**Sample run 1**
```
Name for the order: Jordan
How many pizzas? (1-10): 12
Please enter 1 to 10.
How many pizzas? (1-10): 3

--- Order for Jordan ---
Pizzas:    3
Subtotal:  $35.97
Tax:       $2.43
Total:     $38.40
```

**Sample run 2**
```
Name for the order: Sam
How many pizzas? (1-10): 1

--- Order for Sam ---
Pizzas:    1
Subtotal:  $11.99
Tax:       $0.81
Total:     $12.80
```

**Hints**
- `get_pizza_count` is the Step 4 ask-again loop, moved into a function that ends with `return count`.
- In `main()`, save each returned value in a variable, then pass it to the next function.
- Check Sample run 1 by hand: 3 × 11.99 = 35.97, and 35.97 × 0.0675 = 2.43.

**Study guide:** [Functions that call other functions](step05_StudyGuide.md#functions-that-call-other-functions)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step05` folder.
2. Save the problems as `step05_p01.py` through `step05_p12.py`, and the challenge as `step05_challenge.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step05`
