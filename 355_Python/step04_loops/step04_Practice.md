# Step 04 Practice — Simple Loop Problems (Python)

**Do these after the [Step 4 lesson](step04_Lesson.md).** Each problem is short. The goal is lots of practice with `for` and `while` loops before the bigger BPA-style programs.

**Time:** about one class period for Problems 1–13. The Challenge at the end takes longer.

**Need help?** Use the [Step 4 Study Guide](step04_StudyGuide.md). Every problem below lists the study guide section that shows how.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: Count to 10 with a for loop](#problem-1-count-to-10-with-a-for-loop)
- [Problem 2: Count to 10 with a while loop](#problem-2-count-to-10-with-a-while-loop)
- [Problem 3: Even numbers](#problem-3-even-numbers)
- [Problem 4: Add up 1 to 100](#problem-4-add-up-1-to-100)
- [Problem 5: Password checker](#problem-5-password-checker)
- [Problem 6: Times table](#problem-6-times-table)
- [Problem 7: Add numbers until zero](#problem-7-add-numbers-until-zero)
- [Problem 8: Countdown](#problem-8-countdown)
- [Problem 9: Positive or negative](#problem-9-positive-or-negative)
- [Problem 10: Average of five test scores](#problem-10-average-of-five-test-scores)
- [Problem 11: Ask again until it is in range](#problem-11-ask-again-until-it-is-in-range)
- [Problem 12: Star bar](#problem-12-star-bar)
- [Problem 13: Count and add until zero](#problem-13-count-and-add-until-zero)
- [Challenge: Class Score Summary](#challenge-class-score-summary)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step04_p01.py`, `step04_p02.py`, and so on.
2. Start each file with a header comment (name, date, program name).
3. Use the **exact** prompts and output shown. Same words, same spaces.
4. Run your program with the sample input and compare your output to the sample run, line by line.

---

## Problem 1: Count to 10 with a for loop

Use a `for` loop to print the numbers 1 through 10, one per line.

**Sample run**
```
1
2
3
4
5
6
7
8
9
10
```

**Hint:** `range(1, 11)` gives 1 through 10. It stops **before** 11.
**Study guide:** [The for loop and range](step04_StudyGuide.md#the-for-loop-and-range)

---

## Problem 2: Count to 10 with a while loop

Print the same numbers as Problem 1, but use a `while` loop this time.

**Sample run**
```
1
2
3
4
5
6
7
8
9
10
```

**Hints**
- Start a variable at 1 **before** the loop.
- Add 1 to it **inside** the loop. If you forget, the loop never ends (press **Ctrl+C** to stop it).

**Study guide:** [The while loop](step04_StudyGuide.md#the-while-loop)

---

## Problem 3: Even numbers

Use a `for` loop to print the even numbers from 2 to 20.

**Sample run**
```
2
4
6
8
10
12
14
16
18
20
```

**Hint:** `range()` can take a third number, the **step**. `range(2, 21, 2)` counts by 2s.
**Study guide:** [The range table](step04_StudyGuide.md#the-range-table)

---

## Problem 4: Add up 1 to 100

Use a `for` loop and a running total to add up every number from 1 to 100.

**Sample run**
```
The total is 5050
```

**Hints**
- Start `total = 0` **before** the loop.
- Inside the loop: `total = total + number`
- Print the total **after** the loop (not indented), so it prints only once.
- Do **not** add 1 to the loop variable yourself. The `for` loop already does that.

**Study guide:** [Running totals](step04_StudyGuide.md#running-totals)

---

## Problem 5: Password checker

Keep asking for the password until the user types `python123`.

**Requirements**
1. Store the password in a named constant: `PASSWORD = "python123"`
2. Print `Try again!` after every wrong answer.
3. Print `Access granted!` when it is right.

**Sample run**
```
Enter the password: hello
Try again!
Enter the password: Python123
Try again!
Enter the password: python123
Access granted!
```

**Hints**
- Ask once **before** the loop, and again at the **bottom** of the loop.
- Compare to the constant `PASSWORD`, not to the word `"password"`.
- `Python123` with a capital P is wrong. Text comparisons care about capital letters.

**Study guide:** [Sentinel loops: ask before and inside](step04_StudyGuide.md#sentinel-loops-ask-before-and-inside)

---

## Problem 6: Times table

Ask the user for a number, then print its times table from 1 to 10.

**Sample run**
```
Enter a number: 7
7 x 1 = 7
7 x 2 = 14
7 x 3 = 21
7 x 4 = 28
7 x 5 = 35
7 x 6 = 42
7 x 7 = 49
7 x 8 = 56
7 x 9 = 63
7 x 10 = 70
```

**Hints**
- `number` holds the user's number. Do not change it.
- The loop variable (`i`) goes from 1 to 10. Use both in the f-string: `{number} x {i} = {number * i}`

**Study guide:** [Using the loop variable](step04_StudyGuide.md#using-the-loop-variable)

---

## Problem 7: Add numbers until zero

Keep asking for numbers and add them up. Stop when the user types `0`, then print the total.

**Sample run 1**
```
Enter a number (0 to stop): 5
Enter a number (0 to stop): 12
Enter a number (0 to stop): 3
Enter a number (0 to stop): 0
The total is 20
```

**Sample run 2**
```
Enter a number (0 to stop): 0
The total is 0
```

**Hints**
- `0` is the **sentinel**: the special value that means "stop."
- Loop condition: `while number != 0:`
- Sample run 2 must work too. If the first number is 0, the loop never runs.

**Study guide:** [Sentinel loops: ask before and inside](step04_StudyGuide.md#sentinel-loops-ask-before-and-inside)

---

## Problem 8: Countdown

Ask the user what number to count down from. Count down to 1 with a `for` loop, then print `Liftoff!`.

**Sample run**
```
Count down from: 5
5
4
3
2
1
Liftoff!
```

**Hints**
- To count down, the step is `-1`: `range(start, 0, -1)`
- The stop number is 0 because `range` stops **before** it, so 1 is the last number.
- `Liftoff!` is not indented, so it prints once, after the loop.

**Study guide:** [The range table](step04_StudyGuide.md#the-range-table)

---

## Problem 9: Positive or negative

Keep asking for numbers. For each one, print `Positive` or `Negative`. Stop when the user types `0`, then print `All done.`

**Sample run**
```
Enter a number (0 to stop): 8
Positive
Enter a number (0 to stop): -3
Negative
Enter a number (0 to stop): 15
Positive
Enter a number (0 to stop): 0
All done.
```

**Hints**
- This is Problem 7's loop with an `if`/`else` inside it.
- Inside the loop the number can't be 0, so if it is not negative, it must be positive.
- `% 2` checks **even or odd**, not positive or negative. Use `< 0`.

**Study guide:** [An if inside a loop](step04_StudyGuide.md#an-if-inside-a-loop)

---

## Problem 10: Average of five test scores

Use a `for` loop to ask for five test scores. Add them up, then print the average to 1 decimal place.

**Sample run**
```
Test score: 90
Test score: 85
Test score: 77
Test score: 100
Test score: 69
Average: 84.2
```

**Hints**
- `range(5)` runs the loop 5 times.
- Put the `input()` **inside** the loop, so it asks once each time.
- Work out the average **after** the loop, once all five scores are in.

**Study guide:** [Repeat a set number of times](step04_StudyGuide.md#repeat-a-set-number-of-times)

---

## Problem 11: Ask again until it is in range

Ask the user to rate a movie from 1 to 10. If the answer is out of range, print `Please enter 1 to 10.` and ask again.

**Sample run**
```
Rate the movie (1-10): 15
Please enter 1 to 10.
Rate the movie (1-10): 0
Please enter 1 to 10.
Rate the movie (1-10): 8
Your rating: 8
```

**Hints**
- Loop condition: `while rating < 1 or rating > 10:`
- This pattern is on **every** BPA Python test. Learn it well.

**Study guide:** [Ask again until the answer is good](step04_StudyGuide.md#ask-again-until-the-answer-is-good)

---

## Problem 12: Star bar

Ask for a player's name and points. Use a `for` loop to build a bar with one `*` per point.

**Sample run**
```
Player name: Maya
Points scored: 7
Maya: *******
```

**Hints**
- Start with an empty string: `bar = ""`
- Inside the loop: `bar = bar + "*"`
- Use a `for` loop, not `"*" * points`. The point is to practice the loop.

**Study guide:** [Building a string in a loop](step04_StudyGuide.md#building-a-string-in-a-loop)

---

## Problem 13: Count and add until zero

Like Problem 7, but also count how many numbers were entered (not counting the 0).

**Sample run**
```
Enter a number (0 to stop): 4
Enter a number (0 to stop): 10
Enter a number (0 to stop): 6
Enter a number (0 to stop): 0
You entered 3 numbers.
The total is 20
```

**Hints**
- You need **two** variables that start at 0: a counter and a total.
- Counter: `count = count + 1`. Total: `total = total + number`.

**Study guide:** [Counters](step04_StudyGuide.md#counters)

---

## Challenge: Class Score Summary

This one puts the pieces together: an in-range check, a `for` loop, a loop inside a loop, a counter, a running total, and a bar built with a loop.

**Requirements**
1. Header comment and Input / Processing / Output comments.
2. Store the passing score in a named constant: `PASSING_SCORE = 70`
3. Ask `How many students? (1-30): `. If the answer is out of range, print `Please enter 1 to 30.` and ask again.
4. Use a `for` loop to ask for each student's score: `Score for student 1: `, `Score for student 2: `, and so on.
5. If a score is below 0 or above 100, print `Scores must be 0 to 100.` and ask for **that same student** again.
6. Count how many students passed (score of 70 or higher).
7. Print the summary exactly as shown. The average has 1 decimal place.
8. Use a `for` loop to build the chart: one `#` per passing student. If nobody passed, print `none` instead.

**Sample run 1**
```
How many students? (1-30): 40
Please enter 1 to 30.
How many students? (1-30): 4
Score for student 1: 88
Score for student 2: 105
Scores must be 0 to 100.
Score for student 2: 72
Score for student 3: 65
Score for student 4: 93

--- Class Summary ---
Students:  4
Average:   79.5
Passing:   3
Chart:     ###
```

**Sample run 2**
```
How many students? (1-30): 2
Score for student 1: 50
Score for student 2: 61

--- Class Summary ---
Students:  2
Average:   55.5
Passing:   0
Chart:     none
```

**Hints**
- `for student in range(1, students + 1):` gives you the student number for the prompt.
- The score check is a `while` loop **inside** the `for` loop. It is the same pattern as Problem 11.
- Add to the total and the counter only **after** the score is good.
- Build the chart after the `for` loop, then use an `if` to decide between the chart and `none`.

**Study guide:** [A loop inside a loop](step04_StudyGuide.md#a-loop-inside-a-loop)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step04` folder.
2. Save the problems as `step04_p01.py` through `step04_p13.py`, and the challenge as `step04_challenge.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] No program loops forever
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step04`
