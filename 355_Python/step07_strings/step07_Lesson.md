# Step 07 — Strings (Python)

A **string** is text. In Python, a string works a lot like a list of characters. This lesson teaches strings one piece at a time. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 7 Practice](step07_Practice.md) problems. For more examples, use the [Step 7 Study Guide](step07_StudyGuide.md).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: Characters and indexes](#part-1-characters-and-indexes)
- [Part 2: Slicing](#part-2-slicing)
- [Part 3: Looping over the characters](#part-3-looping-over-the-characters)
- [Part 4: What kind of character is it?](#part-4-what-kind-of-character-is-it)
- [Part 5: Building a new string](#part-5-building-a-new-string)
- [Part 6: Useful string methods](#part-6-useful-string-methods)
- [Part 7: Splitting a string into a list](#part-7-splitting-a-string-into-a-list)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- How to get one character, or a piece of a string, by its position
- How to loop over every character
- How to check if a character is a letter, a digit, uppercase, or a space
- How to build a new string one character at a time
- The most useful string methods: `upper`, `lower`, `strip`, `replace`, `in`, and `split`

---

## Part 1: Characters and indexes

Each character in a string has an index, just like a list. **The first character is index 0.** Spaces count as characters.

```python
word = "Python"
#index: 012345

print(word[0])          # the first character
print(word[-1])         # the last character
print(len(word))        # how many characters
```

```text
P
n
6
```

**Strings can't be changed in place.** `word[0] = "J"` crashes. To change a string, you build a new one (Part 5).

**Try it:** Ask for the user's name. Print its first letter and how many letters it has.

---

## Part 2: Slicing

A **slice** gives you a piece of a string: `text[start:stop]`. Like `range`, it stops **before** the stop number.

```python
code = "MCCC-2027-SE"

print(code[0:4])        # index 0 up to (not including) 4
print(code[5:9])
print(code[:4])         # leave out start: from the beginning
print(code[10:])        # leave out stop: to the end
```

```text
MCCC
2027
MCCC
SE
```

**Try it:** Ask for a first and last name, like `Jordan` and `Lee`. Print a username made from the first 3 letters of each: `JorLee`.

---

## Part 3: Looping over the characters

A `for` loop can go through a string one character at a time, just like a list.

<!-- input: banana bread -->
```python
text = input("Enter some text: ")

count = 0
for character in text:
    if character == "a":
        count = count + 1

print(f"The letter a appears {count} times.")
```

```text
Enter some text: banana bread
The letter a appears 4 times.
```

---

## Part 4: What kind of character is it?

These checks give back `True` or `False`:

| Check | True when the character is... |
|---|---|
| `ch.isalpha()` | a letter |
| `ch.isdigit()` | a digit, 0 to 9 |
| `ch.isupper()` | an uppercase letter |
| `ch.islower()` | a lowercase letter |
| `ch.isspace()` | a space |

<!-- input: Room 204B -->
```python
text = input("Enter some text: ")

letters = 0
digits = 0
for ch in text:
    if ch.isalpha():
        letters = letters + 1
    elif ch.isdigit():
        digits = digits + 1

print(f"Letters: {letters}")
print(f"Digits:  {digits}")
```

```text
Enter some text: Room 204B
Letters: 5
Digits:  3
```

**Try it:** Also count the spaces.

---

## Part 5: Building a new string

You can't change a string, but you can build a new one. Start with `""` and add characters in a loop, like the star bar in Step 4.

<!-- input: Call 555-0142 -->
```python
text = input("Enter some text: ")

hidden = ""
for ch in text:
    if ch.isdigit():
        hidden = hidden + "#"       # replace each digit
    else:
        hidden = hidden + ch        # keep everything else

print(hidden)
```

```text
Enter some text: Call 555-0142
Call ###-####
```

**Try it:** Change it to replace every space with an underscore `_`.

---

## Part 6: Useful string methods

A **method** is a function that belongs to the string. You call it with a dot. These all give back a **new** string; the original doesn't change.

| What you type | Result when `text = "  Game Night  "` |
|---|---|
| `text.strip()` | `"Game Night"` (removes spaces from both ends) |
| `text.upper()` | `"  GAME NIGHT  "` |
| `text.lower()` | `"  game night  "` |
| `text.replace("Game", "Movie")` | `"  Movie Night  "` |
| `"Night" in text` | `True` (is it inside?) |

`.lower()` is great for checking answers, so `Yes`, `YES`, and `yes` all count:

<!-- input: YES -->
```python
answer = input("Continue? ").strip().lower()

if answer == "yes":
    print("Continuing.")
else:
    print("Stopping.")
```

```text
Continue? YES
Continuing.
```

You can chain methods: `.strip().lower()` removes the spaces, then makes it lowercase.

---

## Part 7: Splitting a string into a list

`split()` breaks a string into a list. With nothing in the `()`, it splits at the spaces. With `","`, it splits at the commas.

```python
sentence = "the quick brown fox"
words = sentence.split()
print(words)
print(f"{len(words)} words")

record = "Avery,88,92"
parts = record.split(",")
print(parts[0])
```

```text
['the', 'quick', 'brown', 'fox']
4 words
Avery
```

You'll use `split(",")` a lot in Step 9 to read files.

**Try it:** Ask for a full name like `Jordan Lee`. Print `Lee, Jordan`.

---

## Common mistakes

1. **Trying to change one character:** `word[0] = "J"` crashes. Build a new string instead.
2. **Forgetting the `()` on a method:** `text.upper` doesn't change anything. Use `text.upper()`.
3. **Expecting a method to change the variable.** `text.upper()` gives back a new string. Save it: `text = text.upper()`.
4. **Slicing off by one.** `text[0:3]` gives 3 characters: indexes 0, 1, and 2.
5. **Comparing without `.lower()`.** `"Yes" == "yes"` is False.

---

## Next steps
1. Do the [Step 7 Practice](step07_Practice.md) problems.
2. Keep the [Step 7 Study Guide](step07_StudyGuide.md) open while you work. Print it for BPA.
