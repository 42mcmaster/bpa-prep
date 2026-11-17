# Step 10 Practice — Error Handling (Python)

**Do these after the [Step 10 lesson](step10_Lesson.md).** Each problem is short and uses one idea from the lesson.

**Time:** about one class period for Problems 1–11. The Challenge at the end takes longer.

**Need help?** Use the [Step 10 Study Guide](step10_StudyGuide.md). Every problem lists the study guide section that shows how.

Problems marked **(review)** use skills from earlier steps, so you keep practicing them.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: Catch one bad answer](#problem-1-catch-one-bad-answer)
- [Problem 2: Ask until it's a whole number](#problem-2-ask-until-its-a-whole-number)
- [Problem 3: Ask until it's a price](#problem-3-ask-until-its-a-price)
- [Problem 4: A number in a range](#problem-4-a-number-in-a-range)
- [Problem 5: Write get_int](#problem-5-write-get_int)
- [Problem 6: No blank names](#problem-6-no-blank-names)
- [Problem 7: Yes or no function](#problem-7-yes-or-no-function)
- [Problem 8: Divide safely](#problem-8-divide-safely)
- [Problem 9: Pick from a list](#problem-9-pick-from-a-list)
- [Problem 10: Skip bad lines in a file](#problem-10-skip-bad-lines-in-a-file)
- [Problem 11: Open the file the user names](#problem-11-open-the-file-the-user-names)
- [Challenge: Field Trip Signup](#challenge-field-trip-signup)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step10_p01.py`, `step10_p02.py`, and so on.
2. Start each file with a header comment (name, date, program name).
3. Every function gets a Purpose / Parameters / Returns comment.
4. Name the error in every `except` (like `except ValueError:`). No bare `except:`.
5. Use the **exact** prompts and output shown. Same words, same spaces.
6. Try to crash each program with letters, blanks, and decimals. It should never crash.

---

## Problem 1: Catch one bad answer
Ask for the user's age. If they type something that isn't a whole number, print a message instead of crashing.

**Sample run 1**
```
Age: 16
In 5 years you'll be 21.
```

**Sample run 2**
```
Age: sixteen
That wasn't a whole number.
```

**Hint:** Put both the `input` line and the `print` that uses `age` under `try:`.

**Study guide:** [try and except](step10_StudyGuide.md#try-and-except)

---

## Problem 2: Ask until it's a whole number
Keep asking `How many laps? ` until the user types a whole number.

**Sample run**
```
How many laps? four
Please enter a whole number.
How many laps? 4.5
Please enter a whole number.
How many laps? 4
Running 4 laps.
```

**Hints**
- `while True:` with `break` after the `int()` line.
- `int("4.5")` is a `ValueError` too.

**Study guide:** [The ask-until-valid loop](step10_StudyGuide.md#the-ask-until-valid-loop)

---

## Problem 3: Ask until it's a price
Keep asking `Price: ` until the user types a number (decimals are OK). Then print it as money.

**Sample run**
```
Price: $5
Please enter a number, like 4.99
Price: five
Please enter a number, like 4.99
Price: 5
Price: $5.00
```

**Hints**
- Same loop as Problem 2, with `float()` instead of `int()`.
- `float("$5")` fails because of the `$`.

**Study guide:** [The ask-until-valid loop](step10_StudyGuide.md#the-ask-until-valid-loop)

---

## Problem 4: A number in a range
*(review: Step 4 range checks)*

Keep asking `Team size (2-6): ` until the answer is a whole number from 2 to 6. Every bad answer gets the same message.

**Sample run**
```
Team size (2-6): big
Please enter a whole number from 2 to 6.
Team size (2-6): 9
Please enter a whole number from 2 to 6.
Team size (2-6): 3
Team size: 3
```

**Hints**
- Check the range inside the `try`, right after `int()`.
- Put the message after the `try`/`except`, so both kinds of bad answer print it.

**Study guide:** [The ask-until-valid loop](step10_StudyGuide.md#the-ask-until-valid-loop)

---

## Problem 5: Write get_int
*(review: Step 5 functions)*

Write the `get_int(prompt, low, high)` function from the lesson. Use it to ask for a grade (9–12) and a number of classes (1–8).

**Sample run**
```
Grade (9-12): 8
Please enter a whole number from 9 to 12.
Grade (9-12): eleven
Please enter a whole number from 9 to 12.
Grade (9-12): 11
Classes (1-8): 7
Grade 11, 7 classes
```

**Hints**
- `return number` hands back the answer and also ends the loop.
- The message uses the parameters: `f"... from {low} to {high}."`

**Study guide:** [Reusable input functions](step10_StudyGuide.md#reusable-input-functions)

---

## Problem 6: No blank names
Keep asking `Team name: ` until the answer isn't blank. An answer of only spaces counts as blank.

**Sample run**
```
Team name: 
This cannot be blank.
Team name:    
This cannot be blank.
Team name: Code Crushers
Welcome, Code Crushers!
```

**Hint:** `.strip()` turns `"   "` into `""`.

**Study guide:** [Blank answers and strip](step10_StudyGuide.md#blank-answers-and-strip)

---

## Problem 7: Yes or no function
*(review: Step 7 string methods)*

Write `get_yes_no(prompt)` that keeps asking until the answer is `y` or `n` (any capitals), then returns `True` for y and `False` for n.

**Sample run**
```
Do you want a receipt? (y/n): sure
Please enter y or n.
Do you want a receipt? (y/n): Y
Printing your receipt.
```

**Hints**
- No `try` is needed here. Nothing can crash; you just check the text.
- `.strip().lower()` makes `Y` and ` y ` count.

**Study guide:** [Yes or no questions](step10_StudyGuide.md#yes-or-no-questions)

---

## Problem 8: Divide safely
Ask for total points and games played, then print the average. Catch both kinds of errors: letters, and 0 games.

**Sample run 1**
```
Total points: 84
Games played: 6
Points per game: 14.0
```

**Sample run 2**
```
Total points: 84
Games played: 0
Games played can't be 0.
```

**Sample run 3**
```
Total points: lots
Please type whole numbers.
```

**Hint:** Two `except` blocks, one for each error.

**Study guide:** [Catching specific errors](step10_StudyGuide.md#catching-specific-errors)

---

## Problem 9: Pick from a list
*(review: Step 6 lists)*

Make a list of four prizes. Ask which one the user wants (1–4) and print it. Use `get_int` so a bad answer can't crash it.

**Sample run**
```
1. Sticker
2. Water bottle
3. T-shirt
4. Hoodie
Pick a prize (1-4): 5
Please enter a whole number from 1 to 4.
Pick a prize (1-4): 3
You picked: T-shirt
```

**Hints**
- Subtract 1 from the choice to get the index.
- Since `get_int` only allows 1 to 4, the index can never be out of range.

**Study guide:** [Reusable input functions](step10_StudyGuide.md#reusable-input-functions)

---

## Problem 10: Skip bad lines in a file
*(review: Step 9 files)*

The file `readings.txt` has one number per line, but some lines are bad (a word, a blank line, a decimal). Add up the good whole numbers and count the bad lines.

**Sample run**
```
Total of good lines: 50
Bad lines skipped: 3
```

**Hints**
- Put the `try` inside the reading loop, so one bad line doesn't stop the rest.
- Copy `readings.txt` from this step folder.

**Study guide:** [Handling file errors](step10_StudyGuide.md#handling-file-errors)

---

## Problem 11: Open the file the user names
*(review: Step 9 files)*

Ask for a file name. If the file is there, print its lines. If not, print a message.

**Sample run 1**
```
File name: notes.txt
Bring a laptop charger.
Practice starts at 3:00.
```

**Sample run 2**
```
File name: note.txt
Could not find note.txt.
```

**Hint:** Copy `notes.txt` from this step folder to test it.

**Study guide:** [Handling file errors](step10_StudyGuide.md#handling-file-errors)

---

## Challenge: Field Trip Signup
This one puts the pieces together: three reusable input functions, so nothing the user types can crash it, and a save that can't crash either.

**Requirements**
1. Header comment, Input / Processing / Output comments, and a `main()` function.
2. Named constants: `BUS_COST = 350.00`, `TICKET_PRICE = 12.50`, `FILE_NAME = "signup.txt"`.
3. Write `get_text(prompt)`, `get_int(prompt, low, high)`, and `get_yes_no(prompt)`, with the messages shown. Use them for **every** input.
4. Total cost = students × ticket price, plus the bus cost if they need a bus.
5. Print the summary exactly as shown.
6. Save one line to `signup.txt`: the teacher, the students, and the total, with commas between. Put the save in `try`/`except OSError` and print `Saved to signup.txt`.
7. Every `try`/`except` has a comment saying what error it catches.

**Sample run**
```
Teacher name: 
This cannot be blank.
Teacher name: Ms. Rivera
Number of students (1-40): forty
Please enter a whole number from 1 to 40.
Number of students (1-40): 45
Please enter a whole number from 1 to 40.
Number of students (1-40): 28
Need a bus? (y/n): maybe
Please enter y or n.
Need a bus? (y/n): y

Teacher:      Ms. Rivera
Students:     28
Bus:          yes
Total cost:   $700.00
Per student:  $25.00
Saved to signup.txt
```

**`signup.txt` after the run**
```
Ms. Rivera,28,700.00
```

**Hints**
- Once the three input functions work, `main()` has no loops at all.
- `{'yes' if bus else 'no'}` prints yes or no from a True/False value. An `if`/`else` that sets a variable works too.
- Try to crash it: letters, decimals, blanks, and numbers out of range.

**Study guide:** [Reusable input functions](step10_StudyGuide.md#reusable-input-functions)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step10` folder.
2. Save the problems as `step10_p01.py` through `step10_p11.py`, and the challenge as `step10_challenge.py`. Include `readings.txt` and `notes.txt`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step10`
