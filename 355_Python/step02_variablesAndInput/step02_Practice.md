# Step 02 Practice — Variables and Input (Python)

**Do these after the [Step 2 lesson](step02_Lesson.md).** Each problem is short. The goal is lots of practice with variables, input, and math before the bigger BPA-style programs.

**Time:** about one class period for Problems 1–12. The Challenge at the end takes longer.

**Need help?** Use the [Step 2 Study Guide](step02_StudyGuide.md). Every problem lists the study guide section that shows how.

Problems marked **(review)** use skills from earlier steps, so you keep practicing them.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: Store and print](#problem-1-store-and-print)
- [Problem 2: Say hello](#problem-2-say-hello)
- [Problem 3: Ten years from now](#problem-3-ten-years-from-now)
- [Problem 4: Add two numbers](#problem-4-add-two-numbers)
- [Problem 5: Room area](#problem-5-room-area)
- [Problem 6: Hours and minutes](#problem-6-hours-and-minutes)
- [Problem 7: Price with tax](#problem-7-price-with-tax)
- [Problem 8: Split the bill](#problem-8-split-the-bill)
- [Problem 9: Average of three](#problem-9-average-of-three)
- [Problem 10: Fahrenheit to Celsius](#problem-10-fahrenheit-to-celsius)
- [Problem 11: Cookie boxes](#problem-11-cookie-boxes)
- [Problem 12: A receipt](#problem-12-a-receipt)
- [Challenge: Movie Night Snacks](#challenge-movie-night-snacks)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step02_p01.py`, `step02_p02.py`, and so on.
2. Start each file with a header comment (name, date, program name).
3. Use the **exact** prompts and output shown. Same words, same spaces. Use spaces, not tabs.
4. Get the values from `input()`. Don't type the sample answers into your code.
5. Run your program with the sample input and compare your output to the sample run, line by line.

---

## Problem 1: Store and print
Make three variables: `team = "Code Crushers"`, `wins = 7`, and `losses = 2`. Print them with one f-string per line.

**Sample run**
```
Team:   Code Crushers
Wins:   7
Losses: 2
```

**Hint:** Inside an f-string, `{wins}` is replaced with the value of `wins`.

**Study guide:** [Formatting output with f-strings](step02_StudyGuide.md#formatting-output-with-f-strings)

---

## Problem 2: Say hello
Ask for the user's name and favorite class, then print a sentence with both.

**Sample run**
```
Your name: Maya
Favorite class: Software Engineering
Hi Maya! Software Engineering is a great class.
```

**Hint:** Put a space at the end of each prompt.

**Study guide:** [Reading input from the keyboard](step02_StudyGuide.md#reading-input-from-the-keyboard)

---

## Problem 3: Ten years from now
Ask for the user's age and print how old they'll be in 10 years.

**Sample run**
```
Age: 16
In 10 years you will be 26.
```

**Hint:** `input()` gives text. Use `int()` before you add.

**Study guide:** [Converting text to numbers](step02_StudyGuide.md#converting-text-to-numbers)

---

## Problem 4: Add two numbers
Ask for two whole numbers. Print their sum and their product.

**Sample run**
```
First number: 12
Second number: 7
Sum:     19
Product: 84
```

**Hint:** `*` means multiply.

**Study guide:** [Math operators](step02_StudyGuide.md#math-operators)

---

## Problem 5: Room area
Ask for a room's length and width in feet (decimals allowed). Print the area to 1 decimal place.

**Sample run**
```
Length (feet): 12.5
Width (feet): 10
Area: 125.0 square feet
```

**Hints**
- Decimals mean `float()`.
- `:.1f` shows 1 decimal place.

**Study guide:** [Formatting output with f-strings](step02_StudyGuide.md#formatting-output-with-f-strings)

---

## Problem 6: Hours and minutes
Ask for a number of minutes. Print it as hours and minutes.

**Sample run**
```
Total minutes: 135
135 minutes is 2 hr 15 min
```

**Hint:** `//` gives the whole hours. `%` gives the minutes left over.

**Study guide:** [Division in Python](step02_StudyGuide.md#division-in-python)

---

## Problem 7: Price with tax
Ask for a price. Use a named constant `TAX_RATE = 0.0675`. Print the tax and the total as money.

**Sample run**
```
Price: 40
Tax:   $2.70
Total: $42.70
```

**Hints**
- Constants go at the top, in ALL_CAPS.
- Money always uses `:.2f`.

**Study guide:** [Named constants](step02_StudyGuide.md#named-constants)

---

## Problem 8: Split the bill
Ask for the bill total and how many people. Print how much each person pays.

**Sample run**
```
Bill total: 86.40
Number of people: 5
Each person pays $17.28
```

**Hint:** The bill is money (`float`). People is a whole number (`int`).

**Study guide:** [Converting text to numbers](step02_StudyGuide.md#converting-text-to-numbers)

---

## Problem 9: Average of three
Ask for three test scores. Print the average to 1 decimal place.

**Sample run**
```
Score 1: 88
Score 2: 92
Score 3: 79
Average: 86.3
```

**Hint:** Put parentheses around the adding, so the whole sum gets divided by 3.

**Study guide:** [Math operators](step02_StudyGuide.md#math-operators)

---

## Problem 10: Fahrenheit to Celsius
Ask for a temperature in Fahrenheit. Print it in Celsius to 1 decimal place. The formula is `(F - 32) * 5 / 9`.

**Sample run**
```
Temperature (F): 72
72.0 F is 22.2 C
```

**Hint:** The parentheses make Python subtract first.

**Study guide:** [Math operators](step02_StudyGuide.md#math-operators)

---

## Problem 11: Cookie boxes
A box holds 12 cookies. Ask how many cookies were baked. Print how many full boxes there are and how many cookies are left over. Use a constant for the box size.

**Sample run**
```
Cookies baked: 100
Full boxes:  8
Left over:   4
```

**Hint:** Check it by hand: 100 // 12 = 8 boxes, and 100 % 12 = 4 left over.

**Study guide:** [Division in Python](step02_StudyGuide.md#division-in-python)

---

## Problem 12: A receipt
*(review: Step 1 borders and spacing)*

Ask for an item, how many, and the price each. Print a receipt with a border, like the sample.

**Sample run**
```
Item: Hoodie
Quantity: 2
Price each: 24.99

========================
Item:      Hoodie
Quantity:  2
Price:     $24.99
Total:     $49.98
========================
```

**Hints**
- `"=" * 24` makes the border.
- Count the spaces after each label so the values line up.

**Study guide:** [Putting it together](step02_StudyGuide.md#putting-it-together)

---

## Challenge: Movie Night Snacks
This one puts the pieces together: input, `int` and `float`, named constants, math, and a lined-up receipt with money.

**Requirements**
1. Header comment, and Input / Processing / Output comments.
2. Named constants: `POPCORN_PRICE = 4.50`, `DRINK_PRICE = 2.75`, `TAX_RATE = 0.0675`.
3. Ask for the name, the number of popcorns, and the number of drinks, using the exact prompts.
4. Work out each cost, the subtotal, the tax, and the total. Don't round in the math.
5. Print the receipt exactly as shown. Money has 2 decimal places. The borders are 28 characters.

**Sample run**
```
Name: Jordan
Popcorn: 2
Drinks: 3

============================
Snack order for Jordan
============================
Popcorn x 2:    $9.00
Drinks x 3:     $8.25
----------------------------
Subtotal:       $17.25
Tax:            $1.16
Total:          $18.41
```

**Hints**
- Check it by hand: 2 × 4.50 = 9.00, and 3 × 2.75 = 8.25, so the subtotal is 17.25.
- The spaces after each label make the dollar signs line up. Count them in the sample run.

**Study guide:** [Putting it together](step02_StudyGuide.md#putting-it-together)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step02` folder.
2. Save the problems as `step02_p01.py` through `step02_p12.py`, and the challenge as `step02_challenge.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step02`
