# Step 01 Practice — Output and Comments (Python)

**Do these after the [Step 1 lesson](step01_Lesson.md).** Each problem is short. The goal is lots of practice printing exactly what the sample run shows.

**Time:** about one class period for Problems 1–11. The Challenge at the end takes longer.

**Need help?** Use the [Step 1 Study Guide](step01_StudyGuide.md). Every problem lists the study guide section that shows how.

Problems marked **(review)** use skills from earlier steps, so you keep practicing them.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: Three lines](#problem-1-three-lines)
- [Problem 2: Blank lines](#problem-2-blank-lines)
- [Problem 3: A border](#problem-3-a-border)
- [Problem 4: Centered title](#problem-4-centered-title)
- [Problem 5: A lined-up card](#problem-5-a-lined-up-card)
- [Problem 6: Quotes inside text](#problem-6-quotes-inside-text)
- [Problem 7: A file path](#problem-7-a-file-path)
- [Problem 8: One print, three lines](#problem-8-one-print-three-lines)
- [Problem 9: A box](#problem-9-a-box)
- [Problem 10: Header and comments](#problem-10-header-and-comments)
- [Problem 11: Fix the errors](#problem-11-fix-the-errors)
- [Challenge: Club Flyer](#challenge-club-flyer)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step01_p01.py`, `step01_p02.py`, and so on.
2. Start each file with a header comment (name, date, program name).
3. Match the output **exactly**. Same words, same capitals, same spaces. Use spaces, not tabs.
4. Run your program and compare your output to the sample run, line by line.

---

## Problem 1: Three lines
Print these three lines exactly, using three `print` statements.

**Sample run**
```
Welcome to Software Engineering!
Room 112, IT Academy
Medina County Career Center
```

**Hint:** Copy the text from the sample run carefully: capitals, commas, and the `!`.

**Study guide:** [Printing text](step01_StudyGuide.md#printing-text)

---

## Problem 2: Blank lines
Print a title, a blank line, two lines of text, a blank line, and a closing line, exactly as shown.

**Sample run**
```
BPA Meeting

Tuesday after school
Bring your laptop

See you there!
```

**Hint:** `print()` with nothing inside prints a blank line.

**Study guide:** [Printing text](step01_StudyGuide.md#printing-text)

---

## Problem 3: A border
Print the title `BPA PYTHON CLUB` between two lines of 30 equal signs. Use `"=" * 30`, not 30 typed equal signs.

**Sample run**
```
==============================
BPA PYTHON CLUB
==============================
```

**Hint:** `"=" * 30` repeats the character 30 times.

**Study guide:** [Printing text](step01_StudyGuide.md#printing-text)

---

## Problem 4: Centered title
Print the same border, but center the title by putting 7 spaces in front of it.

**Sample run**
```
==============================
       BPA PYTHON CLUB
==============================
```

**Hint:** The 7 spaces go inside the quotes, before the title.

**Study guide:** [Printing text](step01_StudyGuide.md#printing-text)

---

## Problem 5: A lined-up card
Print this student card. The values all start in the same column, so count the spaces after each label.

**Sample run**
```
------------------------
Name:      Jordan Lee
Grade:     11
Program:   Software Eng
------------------------
```

**Hint:** `Name:` has 6 spaces after it, `Grade:` has 5, and `Program:` has 3. Type spaces, not tabs.

**Study guide:** [Printing text](step01_StudyGuide.md#printing-text)

---

## Problem 6: Quotes inside text
Print these two lines. The first one has double quotes inside it.

**Sample run**
```
The coach said "Push your code every day."
It's the best way to save your work.
```

**Hints**
- Use `\"` for a double quote inside double quotes.
- An apostrophe is fine inside double quotes.

**Study guide:** [Escape sequences](step01_StudyGuide.md#escape-sequences)

---

## Problem 7: A file path
Print this Windows file path. Each `\` in the output needs `\\` in your code.

**Sample run**
```
Save your work in:
C:\BPA\Python\step01
```

**Hint:** `\\` prints one backslash.

**Study guide:** [Escape sequences](step01_StudyGuide.md#escape-sequences)

---

## Problem 8: One print, three lines
Print these three lines using **one** `print` statement.

**Sample run**
```
Line 1: Python
Line 2: GitHub
Line 3: BPA
```

**Hint:** `\n` starts a new line inside the same string.

**Study guide:** [Escape sequences](step01_StudyGuide.md#escape-sequences)

---

## Problem 9: A box
Print a box that is 12 characters wide and 4 lines tall. Use `*` and `" " * 10` for the sides.

**Sample run**
```
************
*          *
*          *
************
```

**Hints**
- The middle lines are one `*`, 10 spaces, and one `*`.
- `+` joins strings together.

**Study guide:** [Printing text](step01_StudyGuide.md#printing-text)

---

## Problem 10: Header and comments
Write a program that prints today's lunch menu. It must have a header comment and an `# Output:` comment.

**Sample run**
```
TODAY'S LUNCH
-------------
1. Chicken wrap
2. Garden salad
3. Pizza
```

**Hints**
- The header comment has four lines: Name, Date, Program, Description.
- Comments don't change the output.

**Study guide:** [The header comment](step01_StudyGuide.md#the-header-comment)

---

## Problem 11: Fix the errors
This program has 3 errors. Fix it so it prints the sample run.

```python
Print("Game Night")
print("Friday at 6:00 PM)
print("Room 112"
```

**Sample run**
```
Game Night
Friday at 6:00 PM
Room 112
```

**Hints**
- Look for a capital letter, a missing quote mark, and a missing parenthesis.
- Run it after each fix, and read the error message.

**Study guide:** [Reading a syntax error](step01_StudyGuide.md#reading-a-syntax-error)

---

## Challenge: Club Flyer
This one puts the pieces together: borders made with `*`, centered and lined-up text, escape sequences, and comments.

**Requirements**
1. Header comment and an `# Output:` comment.
2. Both `=` lines are 32 characters, made with `"=" * 32`. The last line is `"-" * 32`.
3. The title has 8 spaces in front. The second line has 4.
4. The values in the Where / Bring / Who lines all start in the same column.
5. Use `\"` for the quotes and `\\` for each backslash.
6. Print it exactly as shown.

**Sample run**
```
================================
        PYTHON CLUB
    Every Tuesday at 2:45
================================

Where:    Room 112
Bring:    Your laptop
Who:      Juniors and seniors

Motto: "Code it, test it, push it."
Files: C:\BPA\club
--------------------------------
```

**Hints**
- Count the spaces after `Where:`, `Bring:`, and `Who:` in the sample run.
- Two `print()` lines make the two blank lines.

**Study guide:** [Escape sequences](step01_StudyGuide.md#escape-sequences)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step01` folder.
2. Save the problems as `step01_p01.py` through `step01_p11.py`, and the challenge as `step01_challenge.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step01`
