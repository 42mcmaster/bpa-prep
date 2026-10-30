# Step 07 — Strings (Python)

**What you'll build:** Secret Message — a Caesar cipher that encodes or decodes a message, then counts its letters and vowels.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [A string is a sequence of characters](#a-string-is-a-sequence-of-characters)
- [Slicing](#slicing)
- [Looping over the characters](#looping-over-the-characters)
- [Checking what kind of character it is](#checking-what-kind-of-character-it-is)
- [Strings cannot be changed in place](#strings-cannot-be-changed-in-place)
- [Building a new string](#building-a-new-string)
- [Character codes with ord and chr](#character-codes-with-ord-and-chr)
- [Wrapping around with the modulo operator](#wrapping-around-with-the-modulo-operator)
- [How a Caesar cipher works](#how-a-caesar-cipher-works)
- [Useful string methods](#useful-string-methods)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Secret Message](#the-challenge-secret-message)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to get one character or a piece of a string by index and slice
- How to loop over every character
- How to test characters with `isalpha()`, `isupper()`, `islower()`, `isdigit()`
- Why strings can't be changed in place, and how to build a new one instead
- How characters are stored as numbers (ASCII), and how `ord()` and `chr()` convert between them
- How `%` makes values wrap around (Z back to A)
- The string methods you'll use most: `upper`, `lower`, `strip`, `find`, `in`, `replace`, `split`, slices, reverse

## A string is a sequence of characters

A string is like a list of single characters. Each character has an index, starting at 0, just like the lists in Step 6.

```python
word = "Python"
#index: 012345

print(word[0])        # first character
print(word[5])        # last character
print(word[-1])       # also the last character
print(len(word))      # how many characters
```

It prints:

```text
P
n
n
6
```

Spaces, digits, and punctuation are characters too. `"Hi 5!"` has 5 characters: `H`, `i`, a space, `5`, `!`.

## Slicing

A **slice** takes a piece of a string: `text[start:stop]`. Like `range`, it **stops before** the stop index.

| What you type | What you get from `"Medina"` | Notes |
|---|---|---|
| `text[0:3]` | `"Med"` | indexes 0, 1, 2 |
| `text[2:]` | `"dina"` | from index 2 to the end |
| `text[:2]` | `"Me"` | from the start up to (not including) 2 |
| `text[-3:]` | `"ina"` | the last 3 characters |
| `text[::-1]` | `"anideM"` | the whole string reversed |

```python
code = "BPA-355-PY"
# Processing: pull out pieces by position
print(code[0:3])
print(code[4:7])
print(code[-2:])
print(code[::-1])
```

It prints:

```text
BPA
355
PY
YP-553-APB
```

Slices also work on lists: `scores[0:3]` is a new list with the first three scores.

## Looping over the characters

A for-each loop over a string gives you one character at a time:

```python
# Processing: count the spaces in a sentence
sentence = "The lab opens at 7:30"
spaces = 0
for character in sentence:
    if character == " ":
        spaces = spaces + 1

# Output
print(f"Spaces: {spaces}")
```

It prints:

```text
Spaces: 4
```

This is the counting pattern from Step 6, on a string instead of a list.

## Checking what kind of character it is

Strings have methods that answer True/False questions:

| What you type | True when... | `"a"` | `"Q"` | `"7"` | `" "` | `"!"` |
|---|---|---|---|---|---|---|
| `ch.isalpha()` | it's a letter | True | True | False | False | False |
| `ch.isupper()` | it's an uppercase letter | False | True | False | False | False |
| `ch.islower()` | it's a lowercase letter | True | False | False | False | False |
| `ch.isdigit()` | it's a digit 0–9 | False | False | True | False | False |
| `ch.isspace()` | it's a space (or tab, or new line) | False | False | False | True | False |

And two that give back a new string:

| What you type | Gives back |
|---|---|
| `ch.upper()` | the uppercase version (`"a"` → `"A"`; non-letters unchanged) |
| `ch.lower()` | the lowercase version |

```python
password = "Lab2026!"
# Processing: count each kind of character
uppers = 0
digits = 0
others = 0
for ch in password:
    if ch.isupper():
        uppers = uppers + 1
    elif ch.isdigit():
        digits = digits + 1
    elif not ch.isalpha():
        others = others + 1

# Output
print(f"Uppercase: {uppers}, digits: {digits}, symbols: {others}")
```

It prints:

```text
Uppercase: 1, digits: 4, symbols: 1
```

**Checking for a vowel:** the `in` operator asks "is this text inside that text?" So `ch.lower() in "aeiou"` is True for `a`, `E`, `i`, and so on. Lowercasing first means you only have to list the vowels once.

**Try it**
1. Ask for a word and print how many lowercase letters it has.
2. Ask for a sentence and print how many characters are **not** letters.

## Strings cannot be changed in place

You can **read** a character with `word[0]`, but you can't **change** one:

```python
word = "cat"
word[0] = "b"          # MISTAKE - strings can't be changed
```

Error: `TypeError: 'str' object does not support item assignment`

Strings in Python are **immutable** — once made, they never change. Methods like `upper()` and `replace()` don't change the string; they give back a **new** one. To "change" a string, you build a new string and store it in the variable:

```python
word = "cat"
word = "b" + word[1:]     # new string: "b" + "at"
print(word)
```

It prints:

```text
bat
```

(Java and C# strings work the same way. C++ strings *can* be changed in place.)

## Building a new string

The pattern for changing every character: start with an empty string, loop over the old one, and add the new version of each character to the end.

```python
# Processing: replace every digit with "#", keep everything else
phone = "Call 330-555-0142"
hidden = ""
for ch in phone:
    if ch.isdigit():
        hidden = hidden + "#"
    else:
        hidden = hidden + ch

# Output
print(hidden)
```

It prints:

```text
Call ###-###-####
```

This is exactly the shape of the `encode` function in the challenge: loop, change each character (or leave it alone), add it to the result.

## Character codes with ord and chr

Computers store every character as a number. The common table is called **ASCII** (and its bigger version, Unicode). The letters are in order:

| Character | Code | | Character | Code |
|---|---|---|---|---|
| `A` | 65 | | `a` | 97 |
| `B` | 66 | | `b` | 98 |
| `C` | 67 | | `c` | 99 |
| ... | ... | | ... | ... |
| `Z` | 90 | | `z` | 122 |

Digits `0`–`9` are 48–57, and a space is 32.

| What you type | What it means | Example |
|---|---|---|
| `ord("A")` | the number code of a character | `65` |
| `chr(66)` | the character for a number code | `"B"` |

```python
# Processing: move a letter forward by doing math on its code
letter = "C"
code = ord(letter)        # 67
next_code = code + 1      # 68
print(chr(next_code))

# The position of a letter in the alphabet (A = 0, B = 1, ...)
print(ord("D") - ord("A"))
print(ord("d") - ord("a"))
```

It prints:

```text
D
3
3
```

Subtracting `ord("A")` (or `ord("a")` for lowercase) turns a letter into its **position** 0–25. That's the key step in the cipher.

## Wrapping around with the modulo operator

What comes 3 letters after `Y`? Not a symbol — it should **wrap around** to `B`. That's where `%` (remainder, from Step 2) comes in.

`position % 26` always gives a number from 0 to 25. When you go past 25, it starts over at 0.

```python
# Processing: positions past 25 wrap back to the start
print(24 % 26)       # Y stays 24
print(27 % 26)       # 27 wraps to 1
print(-2 % 26)       # going backward from 0 also wraps
```

It prints:

```text
24
1
24
```

Here's the same idea on digits instead of letters: shift each digit, wrapping 9 back to 0 with `% 10`.

```python
def shift_digit(digit, shift):
    """Purpose: move one digit character forward, wrapping 9 to 0.
    Parameters: digit (str) - one character "0"-"9"
                shift (int) - how far to move (negative moves backward)
    Returns: the shifted digit (str)
    """
    position = ord(digit) - ord("0")          # "7" -> 7
    new_position = (position + shift) % 10    # wrap with % 10
    return chr(ord("0") + new_position)       # 1 -> "1"

print(shift_digit("7", 4))
print(shift_digit("1", -4))
```

It prints:

```text
1
7
```

**Python's `%` vs other languages.** In Python, `-2 % 26` is `24` — the answer is always 0 or more when the right side is positive. In **C++, Java, and C#**, `-2 % 26` is **-2**, which breaks the wrap-around. Those languages need `((x % 26) + 26) % 26`. In Python you don't, but now you know why the other lessons have it.

## How a Caesar cipher works

A **Caesar cipher** moves every letter forward by the same number of places (the **shift**). With a shift of 3: A→D, B→E, ... X→A, Y→B, Z→C.

For one letter, the steps are:
1. Is it a letter? If not, leave it alone.
2. Is it uppercase or lowercase? Pick the starting code: `ord("A")` or `ord("a")`. Call it the **base**.
3. Position = `ord(letter) - base` (0–25).
4. New position = `(position + shift) % 26`.
5. New letter = `chr(base + new_position)`.

Worked example: `"y"` with shift 3 → lowercase, base 97 → position `121 - 97 = 24` → `(24 + 3) % 26 = 1` → `chr(97 + 1)` = `"b"`.

**Decoding** moves each letter **backward** by the shift. You don't need new code for that: shifting by `-3` moves backward, and because Python's `%` always gives 0–25, the wrap-around still works (`(1 - 3) % 26 = 24`, so `b` goes back to `y`). That is why `decode(message, shift)` can simply return `encode(message, -shift)`.

## Useful string methods

| What you type | Result with `text = "  Game Night  "` | What it does |
|---|---|---|
| `text.strip()` | `"Game Night"` | removes spaces from both ends (BPA input checks use this) |
| `text.upper()` / `text.lower()` | `"  GAME NIGHT  "` / `"  game night  "` | all upper / all lower |
| `"Night" in text` | `True` | is this text inside? |
| `text.find("Night")` | `7` | index where it starts, or `-1` if not found |
| `text.replace("Game", "Movie")` | `"  Movie Night  "` | swap every match |
| `text.strip().split(" ")` | `["Game", "Night"]` | break into a list at each space |
| `text.count("e")` | `1` | how many times it appears |
| `text.strip().startswith("Game")` | `True` | does it start with this? |

`split` is the one you'll use most in Step 9 — `"Avery,88,92".split(",")` gives `["Avery", "88", "92"]`.

```python
entry = "  avery,88,92  "
# Processing: clean up, split, and fix the capital letter
parts = entry.strip().split(",")
name = parts[0][0].upper() + parts[0][1:]    # "a" -> "A", then the rest
print(parts)
print(name)
print(entry.strip()[::-1])
```

It prints:

```text
['avery', '88', '92']
Avery
29,88,yreva
```

**Try it**
1. Ask for a sentence. Print it reversed, all uppercase.
2. Ask for a full name like `Jordan Lee`. Use `split` to print the last name, then the first name.

## Common mistakes

**1. Trying to change a character**
`message[0] = "X"` → `TypeError: 'str' object does not support item assignment`. Build a new string instead.

**2. Forgetting to store the result of a method**
```python
name = "jordan"
name.upper()              # MISTAKE - result thrown away
print(name)               # still "jordan"
```
Fix: `name = name.upper()`

**3. Using one base for both cases**
If you always subtract `ord("A")`, lowercase letters get positions 32–57 and turn into symbols. Pick the base with `isupper()` / `islower()`.

**4. Shifting characters that aren't letters**
If spaces and digits go through the shift math, `3:00!` turns into garbage. Check `isalpha()` (or `isupper()`/`islower()`) first and return the character unchanged if it's not a letter.

**5. Counting the wrong text**
Requirement 5 says count letters and vowels in **the message the user typed**, not the result. In sample run 2 the typed message has 0 vowels.

**6. Forgetting to wrap**
Without `% 26`, `Z` shifted by 3 becomes `]`. Wrap the **position**, not the character code.

## How this shows up at BPA
- The 2024 regional required a **three-character menu code**, checked with `len()`. String length and content checks show up in almost every test.
- "Names cannot be blank" (2026 regional) is a string check — `.strip() == ""`.
- Graders like seeing character work done with your own loop: counting, building a new string, case checks.
- Exact output formatting is all string work: f-strings, `upper()`, joining pieces together.

## The challenge: Secret Message

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
- Re-read [How a Caesar cipher works](#how-a-caesar-cipher-works) if the wrap-around isn't working.

## Turn it in
1. In your `bpaPrep` repo make a folder `python_step07`.
2. Put `step07.py` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 7 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches both sample runs
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] All five functions, each with a Purpose / Parameters / Returns comment
- [ ] `decode` calls `encode` with a negative shift
- [ ] Upper stays upper, lower stays lower, non-letters unchanged, Z wraps to A
- [ ] Counts are from the typed message
- [ ] Pushed to `bpaPrep/python_step07`
