# Step 07 Practice — Strings (Python)

**Do these after the [Step 7 lesson](step07_Lesson.md).** Each problem is short. The goal is lots of practice with strings before the bigger BPA-style programs.

**Time:** about one class period for Problems 1–11. The Challenge at the end takes longer.

**Need help?** Use the [Step 7 Study Guide](step07_StudyGuide.md). Every problem lists the study guide section that shows how.

Problems marked **(review)** use skills from earlier steps, so you keep practicing them.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: First and last letter](#problem-1-first-and-last-letter)
- [Problem 2: Shout and whisper](#problem-2-shout-and-whisper)
- [Problem 3: Initials](#problem-3-initials)
- [Problem 4: Username](#problem-4-username)
- [Problem 5: Count the vowels](#problem-5-count-the-vowels)
- [Problem 6: Letters, digits, and spaces](#problem-6-letters-digits-and-spaces)
- [Problem 7: Hide the numbers](#problem-7-hide-the-numbers)
- [Problem 8: Backwards](#problem-8-backwards)
- [Problem 9: Count the words](#problem-9-count-the-words)
- [Problem 10: Yes or no](#problem-10-yes-or-no)
- [Problem 11: Count a letter with a function](#problem-11-count-a-letter-with-a-function)
- [Challenge: Password Check](#challenge-password-check)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step07_p01.py`, `step07_p02.py`, and so on.
2. Start each file with a header comment (name, date, program name).
3. Use the **exact** prompts and output shown. Same words, same spaces.
4. Run your program with the sample input and compare your output to the sample run, line by line.

---

## Problem 1: First and last letter
Ask for a word. Print its first letter, its last letter, and how many letters it has.

**Sample run**
```
Enter a word: elephant
First letter: e
Last letter:  t
Length:       8
```

**Hints**
- `word[0]` is the first character and `word[-1]` is the last.
- `len(word)` counts the characters.

**Study guide:** [A string is a sequence of characters](step07_StudyGuide.md#a-string-is-a-sequence-of-characters)

---

## Problem 2: Shout and whisper
Ask for a sentence. Print it in all uppercase, then in all lowercase.

**Sample run**
```
Say something: Python Is Fun
PYTHON IS FUN
python is fun
```

**Hint:** `.upper()` and `.lower()` give back new strings.

**Study guide:** [Useful string methods](step07_StudyGuide.md#useful-string-methods)

---

## Problem 3: Initials
Ask for a first name and a last name. Print the initials with periods, in uppercase.

**Sample run**
```
First name: jordan
Last name: lee
Initials: J.L.
```

**Hint:** `first[0]` is the first letter. Add `.upper()` to make it a capital.

**Study guide:** [A string is a sequence of characters](step07_StudyGuide.md#a-string-is-a-sequence-of-characters)

---

## Problem 4: Username
Ask for a first name, a last name, and a graduation year. Make a username from the first 4 letters of the last name, the first letter of the first name, and the last 2 digits of the year, all lowercase.

**Sample run**
```
First name: Jordan
Last name: Martinez
Graduation year: 2027
Username: martj27
```

**Hints**
- `last[:4]` is the first 4 letters.
- `year[-2:]` is the last 2 characters. Keep the year as a string; don't use `int()`.

**Study guide:** [Slicing](step07_StudyGuide.md#slicing)

---

## Problem 5: Count the vowels
Ask for a sentence. Count how many vowels (a, e, i, o, u) it has. Count both uppercase and lowercase.

**Sample run**
```
Enter a sentence: Programming Is Awesome
Vowels: 8
```

**Hints**
- Loop over `sentence.lower()` so you only have to check lowercase vowels.
- `ch in "aeiou"` is True when `ch` is one of those letters.

**Study guide:** [Looping over the characters](step07_StudyGuide.md#looping-over-the-characters)

---

## Problem 6: Letters, digits, and spaces
Ask for a line of text. Count the letters, digits, and spaces.

**Sample run**
```
Enter some text: Room 204 opens at 8
Letters: 11
Digits:  4
Spaces:  4
```

**Hints**
- Use `.isalpha()`, `.isdigit()`, and `.isspace()`.
- Three counters, all starting at 0.

**Study guide:** [Checking what kind of character it is](step07_StudyGuide.md#checking-what-kind-of-character-it-is)

---

## Problem 7: Hide the numbers
Ask for a message. Print it with every digit replaced by `*`.

**Sample run**
```
Message: My PIN is 4821
My PIN is ****
```

**Hint:** Start with `hidden = ""` and add one character each time through the loop.

**Study guide:** [Building a new string](step07_StudyGuide.md#building-a-new-string)

---

## Problem 8: Backwards
*(review: Step 3 if statements)*

Ask for a word. Use a loop to build the word backwards, then say whether it is a palindrome (the same forwards and backwards).

**Sample run 1**
```
Enter a word: Racecar
Backwards: racecar
It's a palindrome!
```

**Sample run 2**
```
Enter a word: python
Backwards: nohtyp
Not a palindrome.
```

**Hints**
- Add each new character to the **front**: `backwards = ch + backwards`.
- Use `.lower()` so `Racecar` still matches.

**Study guide:** [Building a new string](step07_StudyGuide.md#building-a-new-string)

---

## Problem 9: Count the words
*(review: Step 6 lists)*

Ask for a sentence. Use `split()` to count the words and print the first and last word.

**Sample run**
```
Enter a sentence: BPA regionals are in January
Words: 5
First word: BPA
Last word:  January
```

**Hint:** `split()` gives a list of words. Then use list tools from Step 6.

**Study guide:** [Useful string methods](step07_StudyGuide.md#useful-string-methods)

---

## Problem 10: Yes or no
*(review: Step 4 ask-again loops)*

Keep asking `Ready to start? (yes/no): ` until the user types yes or no. Accept any capitals and extra spaces. Then print which one they chose.

**Sample run**
```
Ready to start? (yes/no): maybe
Please type yes or no.
Ready to start? (yes/no): YES
You said yes.
```

**Hints**
- `.strip().lower()` cleans up the answer before you check it.
- This loop uses `and`: keep asking while it is not yes **and** not no.

**Study guide:** [Useful string methods](step07_StudyGuide.md#useful-string-methods)

---

## Problem 11: Count a letter with a function
*(review: Step 5 functions)*

Write a function `count_letter(text, letter)` that returns how many times the letter appears, ignoring capitals. Ask for a sentence and a letter, then print the count.

**Sample run**
```
Sentence: She sells Sea Shells
Letter: s
's' appears 6 times.
```

**Hints**
- Lowercase both the text and the letter before you compare.
- The function returns the count; the `print` is outside the function.

**Study guide:** [Looping over the characters](step07_StudyGuide.md#looping-over-the-characters)

---

## Challenge: Password Check
This one puts the pieces together: a loop over characters, character checks, functions, and an ask-again loop.

**Requirements**
1. Header comment, Input / Processing / Output comments, and a `main()` function.
2. Named constant: `MIN_LENGTH = 8`.
3. Write `count_digits(text)` and `count_uppercase(text)`. Each loops over the characters and **returns** a count.
4. Write `is_strong(password)`. It checks the three rules below, prints a line for **every** rule that fails, and returns `True` only if all three pass.
   - at least 8 characters
   - at least 1 digit
   - at least 1 uppercase letter
5. In `main()`, keep asking `New password: ` until the password is strong.
6. Print the output exactly as shown.

**Sample run**
```
New password: cat
- Needs at least 8 characters
- Needs at least 1 digit
- Needs at least 1 uppercase letter
New password: catsanddogs
- Needs at least 1 digit
- Needs at least 1 uppercase letter
New password: Catsanddogs7
Password accepted. It has 12 characters.
```

**Hints**
- In `is_strong`, start with `strong = True`. Each rule is its own `if` (not `elif`), so every problem gets listed.
- `while not is_strong(password):` calls the function each time and keeps going while it returns False.

**Study guide:** [Checking what kind of character it is](step07_StudyGuide.md#checking-what-kind-of-character-it-is)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step07` folder.
2. Save the problems as `step07_p01.py` through `step07_p11.py`, and the challenge as `step07_challenge.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step07`
