# Step 01 — Output and Comments (Python)

This lesson teaches how to print exactly what you want, and how to comment your code the way BPA graders expect. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 1 Practice](step01_Practice.md) problems. For more examples, use the [Step 1 Study Guide](step01_StudyGuide.md). The [Steps 1–3 Common Mistakes](../Steps01-03_CommonMistakes.md) page shows the mistakes students make most.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: Your first program](#part-1-your-first-program)
- [Part 2: Printing text exactly](#part-2-printing-text-exactly)
- [Part 3: Repeating a character](#part-3-repeating-a-character)
- [Part 4: Escape sequences](#part-4-escape-sequences)
- [Part 5: Comments](#part-5-comments)
- [Part 6: The header comment](#part-6-the-header-comment)
- [Part 7: Reading an error](#part-7-reading-an-error)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- How to write and run a Python program in IDLE
- How to print text exactly the way a sample run shows it
- How to repeat a character, like a line of `=`
- How to use `\n`, `\"`, and `\\`
- How to write comments and the header comment
- How to read a syntax error

---

## Part 1: Your first program

1. Open **IDLE**. Click **File > New File**.
2. Type this line:

```python
print("Hello, BPA!")
```

3. Click **File > Save As** and save it as `hello.py` in your `python_step01` folder.
4. Press **F5** to run it. The output shows in the Shell window:

```text
Hello, BPA!
```

`print()` shows whatever is inside the parentheses. Text goes inside quotes. Python runs a program from the top line down, one line at a time.

---

## Part 2: Printing text exactly

BPA grades your output by comparing it to the sample run, **character by character**. Every space, capital letter, and punctuation mark counts.

```python
print("MCCC Game Night")
print("Friday at 6:00 PM")
print()                         # an empty print() makes a blank line
print("Room 112")
```

```text
MCCC Game Night
Friday at 6:00 PM

Room 112
```

Spaces inside the quotes are printed exactly as you type them:

```python
print("Name:     Avery")        # 5 spaces after the colon
print("Grade:    11")           # 4 spaces after the colon
```

```text
Name:     Avery
Grade:    11
```

**Type the spaces.** Don't use tabs to line things up.

**Try it:** Print your class schedule: three lines, each with a period number and a class name.

---

## Part 3: Repeating a character

`"=" * 20` makes 20 equal signs. This is the easy way to print a border line, and it's the way the tasks ask you to do it.

```python
print("=" * 20)
print("  WELCOME")
print("=" * 20)
print("-" * 20)
```

```text
====================
  WELCOME
====================
--------------------
```

**Try it:** Print a box: a line of 15 `*`, the word `BPA` in the middle line, and another line of 15 `*`.

---

## Part 4: Escape sequences

A backslash `\` and one more character make a special character:

| What you type | What it prints |
|---|---|
| `\n` | a new line |
| `\"` | a `"` inside a string |
| `\\` | one backslash `\` |

```python
print("Line one\nLine two")
print("The sign said \"Quiet please\".")
print("C:\\BPA\\scores.txt")
```

```text
Line one
Line two
The sign said "Quiet please".
C:\BPA\scores.txt
```

You can also put an apostrophe inside double quotes with no backslash: `print("It's game night")`.

---

## Part 5: Comments

A **comment** starts with `#`. Python skips it. Comments explain the code to the person reading it, and BPA graders give points for them.

```python
# Output: print the title of the event
print("MCCC Game Night")    # a comment can also go at the end of a line
```

```text
MCCC Game Night
```

From now on, label each part of your programs with one of these:

| Comment | Goes above code that... |
|---|---|
| `# Input:` | gets data from the user or a file |
| `# Processing:` | does math or makes decisions |
| `# Output:` | prints results |

---

## Part 6: The header comment

**Every program starts with a header comment.** It says who wrote it, when, and what it does.

```python
# Name: Avery Collins
# Date: 2026-11-16
# Program: Step 1 Practice 1
# Description: Prints a welcome message for the class.

# Output: the welcome message
print("Welcome to Software Engineering!")
```

```text
Welcome to Software Engineering!
```

At the BPA event, put your **Contestant ID** where your name goes. Never put your name or school on BPA work.

---

## Part 7: Reading an error

If Python can't understand a line, it stops and shows a **syntax error**. It highlights where it got confused, and the mistake is usually on that line or the line just above it.

The most common causes:
- A missing quote: `print("Hello)`
- A missing parenthesis: `print("Hello"`
- `Print` with a capital P. Python is case-sensitive, so it must be `print`.

**Try it:** Take the last quote mark off one of your `print` lines and run it. Read the error, then fix it.

---

## Common mistakes

1. **Spaces that don't match the sample run.** Count them.
2. **Using `\t` (a tab) to line things up.** Type spaces instead.
3. **Typing out `====================`** instead of using `"=" * 20`.
4. **`Print` instead of `print`.**
5. **A missing quote or parenthesis.**
6. **No header comment.**

---

## Next steps
1. Do the [Step 1 Practice](step01_Practice.md) problems.
2. Keep the [Step 1 Study Guide](step01_StudyGuide.md) open while you work. Print it for BPA.
