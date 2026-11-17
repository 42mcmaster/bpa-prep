# Step 03 Practice — If Statements (Python)

**Do these after the [Step 3 lesson](step03_Lesson.md).** Each problem is short. The goal is lots of practice making decisions before the bigger BPA-style programs.

**Time:** about one class period for Problems 1–11. The Challenge at the end takes longer.

**Need help?** Use the [Step 3 Study Guide](step03_StudyGuide.md). Every problem lists the study guide section that shows how.

Problems marked **(review)** use skills from earlier steps, so you keep practicing them.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: Pass or not](#problem-1-pass-or-not)
- [Problem 2: Even or odd](#problem-2-even-or-odd)
- [Problem 3: Positive, negative, or zero](#problem-3-positive-negative-or-zero)
- [Problem 4: Letter grade](#problem-4-letter-grade)
- [Problem 5: Can they drive?](#problem-5-can-they-drive)
- [Problem 6: Check the range first](#problem-6-check-the-range-first)
- [Problem 7: Secret word](#problem-7-secret-word)
- [Problem 8: Bigger number](#problem-8-bigger-number)
- [Problem 9: Free shipping and gift wrap](#problem-9-free-shipping-and-gift-wrap)
- [Problem 10: Member price](#problem-10-member-price)
- [Problem 11: Late fee](#problem-11-late-fee)
- [Challenge: Gym Day Pass](#challenge-gym-day-pass)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step03_p01.py`, `step03_p02.py`, and so on.
2. Start each file with a header comment (name, date, program name).
3. Use the **exact** prompts and output shown. Same words, same spaces.
4. Test every sample run, and test the numbers right at the edges (like 69 and 70).
5. Run your program with the sample input and compare your output to the sample run, line by line.

---

## Problem 1: Pass or not
Ask for a test score. Print `You passed.` if it is 70 or more. Otherwise print `You did not pass.`

**Sample run 1**
```
Score: 82
You passed.
```

**Sample run 2**
```
Score: 69
You did not pass.
```

**Hint:** Test the edge: 70 should pass, and 69 should not.

**Study guide:** [if and else](step03_StudyGuide.md#if-and-else)

---

## Problem 2: Even or odd
Ask for a whole number. Say whether it is even or odd.

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

**Hint:** `number % 2` is the remainder after dividing by 2. It is 0 for even numbers.

**Study guide:** [if and else](step03_StudyGuide.md#if-and-else)

---

## Problem 3: Positive, negative, or zero
Ask for a number. Say whether it is positive, negative, or zero.

**Sample run 1**
```
Enter a number: -4
Negative
```

**Sample run 2**
```
Enter a number: 0
Zero
```

**Hint:** Three choices means `if`, `elif`, `else`.

**Study guide:** [elif for more than two choices](step03_StudyGuide.md#elif-for-more-than-two-choices)

---

## Problem 4: Letter grade
Ask for a score and print the letter grade: A (90+), B (80–89), C (70–79), D (60–69), F (below 60).

**Sample run 1**
```
Score: 84
Grade: B
```

**Sample run 2**
```
Score: 59
Grade: F
```

**Hint:** Check from the top grade down. Python stops at the first one that's True.

**Study guide:** [elif for more than two choices](step03_StudyGuide.md#elif-for-more-than-two-choices)

---

## Problem 5: Can they drive?
Ask for the user's age and whether they have a permit (y/n). They can drive with an adult if they are 15 or older **and** have a permit.

**Sample run 1**
```
Age: 16
Have a permit? (y/n): y
You can drive with an adult.
```

**Sample run 2**
```
Age: 16
Have a permit? (y/n): n
Not yet.
```

**Hints**
- `and` is True only when both sides are True.
- `.lower()` makes `Y` count too.

**Study guide:** [Logical operators and or not](step03_StudyGuide.md#logical-operators-and-or-not)

---

## Problem 6: Check the range first
Ask for a rating from 1 to 5. If it is out of range, print `Error: rating must be 1 to 5.` Otherwise, print `Thanks for the rating of N!`

**Sample run 1**
```
Rating (1-5): 4
Thanks for the rating of 4!
```

**Sample run 2**
```
Rating (1-5): 9
Error: rating must be 1 to 5.
```

**Hint:** `or` is True when either side is True: too low **or** too high.

**Study guide:** [Logical operators and or not](step03_StudyGuide.md#logical-operators-and-or-not)

---

## Problem 7: Secret word
Store the secret word in a constant: `SECRET = "python"`. Ask for a guess. It counts if it matches with any capitals.

**Sample run 1**
```
Guess the word: PYTHON
Correct!
```

**Sample run 2**
```
Guess the word: java
Wrong guess.
```

**Hint:** Compare `guess.lower()` to the constant, not to the word in quotes.

**Study guide:** [Comparing text](step03_StudyGuide.md#comparing-text)

---

## Problem 8: Bigger number
Ask for two numbers. Print which one is bigger, or that they are equal.

**Sample run 1**
```
First number: 12
Second number: 30
30 is bigger.
```

**Sample run 2**
```
First number: 8
Second number: 8
They are equal.
```

**Hint:** Don't forget the case where they're equal.

**Study guide:** [elif for more than two choices](step03_StudyGuide.md#elif-for-more-than-two-choices)

---

## Problem 9: Free shipping and gift wrap
*(review: Step 2 money and constants)*

Ask for the order total and whether to gift wrap it. Shipping is free on orders of $50 or more, and $5.99 otherwise. Gift wrap adds $3.00. Print the final total.

**Sample run 1**
```
Order total: 62.00
Gift wrap? (y/n): y
Final total: $65.00
```

**Sample run 2**
```
Order total: 30.00
Gift wrap? (y/n): n
Final total: $35.99
```

**Hints**
- Both things can happen, so use **two separate** `if` statements, not `elif`.
- Start `total` at the order, then add to it.

**Study guide:** [if and else](step03_StudyGuide.md#if-and-else)

---

## Problem 10: Member price
Ask whether the user is a club member (y/n). Members also get asked their grade. Seniors (grade 12) who are members pay $3. Other members pay $5. Non-members pay $8.

**Sample run 1**
```
Club member? (y/n): y
Grade: 12
Your price: $3
```

**Sample run 2**
```
Club member? (y/n): y
Grade: 10
Your price: $5
```

**Sample run 3**
```
Club member? (y/n): n
Your price: $8
```

**Hints**
- This is a **nested if**: the grade question and the second `if` go **inside** the member's `if`.
- Non-members are never asked their grade.

**Study guide:** [Nested if statements](step03_StudyGuide.md#nested-if-statements)

---

## Problem 11: Late fee
*(review: Step 2 math)*

A library book costs $0.25 per day late, but the fee is never more than $5.00. Ask how many days late it is and print the fee.

**Sample run 1**
```
Days late: 6
Late fee: $1.50
```

**Sample run 2**
```
Days late: 30
Late fee: $5.00
```

**Hint:** Work out the fee first. Then, if it's over the max, set it to the max.

**Study guide:** [The if statement](step03_StudyGuide.md#the-if-statement)

---

## Challenge: Gym Day Pass
This one puts the pieces together: a range check, an `if`/`elif`/`else` chain, two separate `if` statements, constants, and a receipt with money.

**Requirements**
1. Header comment, and Input / Processing / Output comments.
2. Named constants for every price: `CHILD_PRICE = 4.00`, `STUDENT_PRICE = 6.00`, `ADULT_PRICE = 9.00`, `WEEKEND_CHARGE = 2.00`, `TOWEL_PRICE = 1.50`.
3. Ask all four questions first. Then, if the age is below 5 or above 100, print `Error: age must be 5 to 100.` and nothing else.
4. Pass type: under 13 is `Child`, 13 to 18 is `Student`, and 19 and up is `Adult`.
5. Saturday or Sunday (any capitals) adds the weekend charge. A towel adds the towel price. Both can happen.
6. The `Weekend` and `Towel` lines only print when they apply.
7. Print the receipt exactly as shown.

**Sample run 1**
```
Name: Avery
Age: 16
Day of the week: Saturday
Rent a towel? (y/n): y

--- Day Pass for Avery ---
Pass type:  Student
Base price: $6.00
Weekend:    $2.00
Towel:      $1.50
Total:      $9.50
```

**Sample run 2**
```
Name: Blake
Age: 40
Day of the week: tuesday
Rent a towel? (y/n): n

--- Day Pass for Blake ---
Pass type:  Adult
Base price: $9.00
Total:      $9.00
```

**Sample run 3**
```
Name: Casey
Age: 3
Day of the week: Monday
Rent a towel? (y/n): n
Error: age must be 5 to 100.
```

**Hints**
- Put everything after the error check inside the `else`, so a bad age prints only the error.
- Use two separate `if` statements for the weekend and the towel.
- Test the edges: ages 12, 13, 18, and 19.

**Study guide:** [Nested if statements](step03_StudyGuide.md#nested-if-statements)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step03` folder.
2. Save the problems as `step03_p01.py` through `step03_p11.py`, and the challenge as `step03_challenge.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step03`
