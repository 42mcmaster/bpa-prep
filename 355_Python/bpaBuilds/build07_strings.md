# Builds for Step 07 — Strings (Python)

These are BPA-style programs that use the Step 7 skills together with everything before it. They are bigger than the practice problems, and closer to what the BPA test asks for.

**Do these after you finish Steps 1–7 (lessons and practice).** Use the [Step 7 Study Guide](../step07_strings/step07_StudyGuide.md) for help.

**Rules for every build in this file**
- Every function has a purpose / parameters / returns comment.
- End the file with `if __name__ == "__main__":` and `main()`.

## Table of Contents
- [Build 7A: Secret Message](#build-7a-secret-message)
- [Build 7B: Username Generator](#build-7b-username-generator)
- [Build 7C: Password Checker](#build-7c-password-checker)
- [Build 7D: Sentence Analyzer](#build-7d-sentence-analyzer)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Build 7A: Secret Message
Write a Caesar cipher program that can encode or decode a message.

**Requirements**
1. Header comment.
2. Ask `Encode or decode? (e/d): `, then `Message: `, then `Shift (1-25): `.
3. Caesar cipher: move each letter forward by the shift to encode (backward to decode), wrapping Z→A. Keep uppercase as uppercase and lowercase as lowercase. Anything that isn't a letter (spaces, digits, punctuation) stays the same.
4. Write these functions: `shift_letter(letter, shift)` (shifts one character, returns it), `encode(message, shift)`, `decode(message, shift)` (decode should call encode with a negative shift), `count_letters(text)`, `count_vowels(text)` (a, e, i, o, u, either case).
5. Print the result, then the number of letters and vowels **in the message the user typed**.
6. Function comments and Input / Processing / Output comments.

**Sample run 1 (exact)**
```
Encode or decode? (e/d): e
Message: Meet me at 3:00!
Shift (1-25): 3
Result: Phhw ph dw 3:00!
Letters: 8
Vowels: 4
```
**Sample run 2 (exact)**
```
Encode or decode? (e/d): d
Message: Phhw ph dw 3:00!
Shift (1-25): 3
Result: Meet me at 3:00!
Letters: 8
Vowels: 0
```

**Hints**
- Write and test `shift_letter` first. `print(shift_letter("y", 3))` should print `b`; `print(shift_letter("!", 3))` should print `!`.
- `encode` is the "build a new string" loop, calling `shift_letter` on each character.
- `decode` is one line.
- Re-read [How a Caesar cipher works](../step07_strings/step07_StudyGuide.md#how-a-caesar-cipher-works) if the wrap-around isn't working.

---

## Build 7B: Username Generator
Write a program that builds a school account from a student's name and graduation year.

**Requirements**
1. Header comment. Store the email ending in a constant: `EMAIL_DOMAIN = "@mccc.edu"`.
2. Ask for the first name, last name, and graduation year. Remove extra spaces from the ends of each answer with `.strip()`.
3. If the year is not exactly 4 characters, or is not all digits, print `Error: year must be 4 digits.` and end. Use `len` and `.isdigit()`.
4. Write these functions:

   | Function | Returns |
   |---|---|
   | `make_username(first, last, year)` | first letter of the first name + the first 5 letters of the last name + the last 2 digits of the year, all lowercase. A last name shorter than 5 letters uses the whole name. |
   | `make_initials(first, last)` | text like `J.L.` (uppercase, with periods) |
   | `fix_capitals(name)` | the name with the first letter uppercase and the rest lowercase |

5. Print the account card exactly as shown:
   - `Name:` uses `fix_capitals` on both names, no matter how they were typed
   - `Backwards:` is the fixed full name reversed with a slice
   - `Name length:` is the number of letters in the first and last name together
6. Input / Processing / Output comments.

**Sample run 1** (the user typed spaces before and after `jordan`)
```
First name:   jordan 
Last name: LEE
Graduation year: 2027

--- New Account ---
Name:      Jordan Lee
Initials:  J.L.
Username:  jlee27
Email:     jlee27@mccc.edu
Backwards: eeL nadroJ
Name length: 9 letters
```

**Sample run 2**
```
First name: Alexandra
Last name: Montgomery
Graduation year: 2028

--- New Account ---
Name:      Alexandra Montgomery
Initials:  A.M.
Username:  amontg28
Email:     amontg28@mccc.edu
Backwards: yremogtnoM ardnaxelA
Name length: 19 letters
```

**Sample run 3**
```
First name: Sam
Last name: Ng
Graduation year: 27
Error: year must be 4 digits.
```

**Hints**
- Slices are safe even when the text is short: `"Lee"[0:5]` is just `"Lee"`. No `if` needed.
- The last 2 digits of the year: `year[-2:]`.
- `fix_capitals`: `name[0].upper() + name[1:].lower()`.
- Reverse a string with `[::-1]`.

**Test these too:** a one-letter first name, a year like `20a7`, and a last name typed in all capitals.

---

## Build 7C: Password Checker
Write a program that checks a new password against five rules, prints a checklist, and keeps asking until the password passes all five.

**Requirements**
1. Header comment. Store the minimum length in a constant: `MIN_LENGTH = 8`.
2. The five rules:
   - at least 8 characters
   - at least one uppercase letter
   - at least one lowercase letter
   - at least one digit
   - at least one symbol (anything that is not a letter, a digit, or a space)
3. Write these functions, each with its own `for` loop over the characters:

   | Function | Returns |
   |---|---|
   | `count_upper(text)` | how many uppercase letters |
   | `count_lower(text)` | how many lowercase letters |
   | `count_digits(text)` | how many digits |
   | `count_symbols(text)` | how many symbols |
   | `check_mark(passed)` | `[X]` for True, `[ ]` for False |
   | `check_password(password)` | prints the checklist and **returns** how many rules passed (0–5) |

4. In `main`, ask `New password: ` and keep asking until a password passes all 5 rules. Count the tries.
5. If the password has a space in it, print `  Passwords cannot have spaces.` instead of the checklist, and count it as 0 rules passed.
6. After each try, print `Strength: STRONG (5 of 5)`, `MEDIUM` for 3 or 4, or `WEAK` for 0 to 2, then a blank line.
7. When it is accepted, print `Password accepted:` followed by one `*` for each character, then the number of tries.
8. Input / Processing / Output comments.

**Sample run**
```
New password: dragon
  [ ] At least 8 characters
  [ ] An uppercase letter
  [X] A lowercase letter
  [ ] A digit
  [ ] A symbol
Strength: WEAK (1 of 5)

New password: Dragon2027
  [X] At least 8 characters
  [X] An uppercase letter
  [X] A lowercase letter
  [X] A digit
  [ ] A symbol
Strength: MEDIUM (4 of 5)

New password: my Pass1!
  Passwords cannot have spaces.
Strength: WEAK (0 of 5)

New password: Dragon#2027
  [X] At least 8 characters
  [X] An uppercase letter
  [X] A lowercase letter
  [X] A digit
  [X] A symbol
Strength: STRONG (5 of 5)

Password accepted: ***********
Tries: 4
```

**Hints**
- Use the character checks from the Step 7 study guide: `.isupper()`, `.islower()`, `.isdigit()`, `.isalpha()`, `.isspace()`.
- A symbol is `not ch.isalpha() and not ch.isdigit() and not ch.isspace()`.
- In `check_password`, put the five True/False results in one list and the five labels in a parallel list. Then one `for` loop can print every line and count the passes.
- The checklist lines start with 2 spaces.
- `"*" * len(password)` hides the password.

**Test these too:** a password of exactly 8 characters, and one that is all symbols like `#$%^&*!@`.

---

## Build 7D: Sentence Analyzer
Write a program that prints facts about sentences until the user types `quit`.

**Requirements**
1. Header comment. Store the vowels in a constant: `VOWELS = "aeiou"`.
2. Ask `Sentence (or quit): ` and `.strip()` the answer. Keep going until the answer is `quit` (any capitals). If the answer is blank, print `Please type a sentence.`
3. Split the sentence into words with `.split(" ")`.
4. Write these functions:

   | Function | Returns |
   |---|---|
   | `count_vowels(text)` | how many vowels (either case) |
   | `letters_only(text)` | only the letters, all lowercase (no spaces, digits, or punctuation) |
   | `longest_word(words)` | the longest word (the first one if there is a tie) |
   | `make_acronym(words)` | the first letter of each word, uppercase |
   | `title_case(words)` | each word with the first letter uppercase and the rest lowercase, joined with spaces |
   | `is_palindrome(text)` | True if the **letters** read the same forward and backward |

5. For each sentence, print the report exactly as shown, then a blank line. `Letters:` is the length of `letters_only`.
6. Print `Done.` when the user quits.
7. Input / Processing / Output comments.

**Sample run**
```
Sentence (or quit): Never odd or even
Words: 4
Letters: 14
Vowels: 6
Longest word: Never
Acronym: NOOE
Title case: Never Odd Or Even
Palindrome: yes

Sentence (or quit): portable network graphics
Words: 3
Letters: 23
Vowels: 7
Longest word: portable
Acronym: PNG
Title case: Portable Network Graphics
Palindrome: no

Sentence (or quit): 
Please type a sentence.

Sentence (or quit): quit
Done.
```

**Hints**
- `letters_only` is the "build a new string" loop: start with `""`, and add `ch.lower()` only when `ch.isalpha()`.
- `is_palindrome` can call `letters_only`, then compare it to itself reversed: `letters == letters[::-1]`. That ignores spaces and capitals, so `Never odd or even` counts.
- `title_case` builds a list of fixed words, then uses `" ".join(...)`.
- Do **not** use Python's built-in `.title()`. Write it yourself.

**Test these too:** `Racecar` (one word, palindrome), `A man, a plan, a canal: Panama` (palindrome with punctuation), and `QUIT` in capitals.

---

## Turn it in
1. In your `bpaPrep` repo, make a folder named `python_builds` (one folder for all builds).
2. Save the builds as `build07A.py`, `build07B.py`, `build07C.py`, and `build07D.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches both sample runs
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] All five functions, each with a Purpose / Parameters / Returns comment
- [ ] `decode` calls `encode` with a negative shift
- [ ] Upper stays upper, lower stays lower, non-letters unchanged, Z wraps to A
- [ ] Counts are from the typed message
- [ ] Pushed to `bpaPrep/python_builds`
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] I tested the extra inputs listed under each task
- [ ] Every function has a purpose / parameters / returns comment
- [ ] Input / Processing / Output comments in each file
