# Step 01 Study Guide — Output and Comments (Python)

This guide covers everything for Step 1, with full explanations and commented code. Start with the [Step 1 lesson](step01_Lesson.md), then do the [Step 1 Practice](step01_Practice.md). Come back here when you need more detail. Build 1A and the other [Step 1 builds](../bpaBuilds/build01_outputAndComments.md) use these skills too. The builds for Steps 1–3 start after Step 3.

**Print this.** BPA lets you bring printed notes and printed code into the Python event.

## Table of Contents
- [What this guide covers](#what-this-guide-covers)
- [What a Python program is](#what-a-python-program-is)
- [Printing text](#printing-text)
- [Escape sequences](#escape-sequences)
- [Comments](#comments)
- [The header comment](#the-header-comment)
- [Input Processing Output comments](#input-processing-output-comments)
- [Running your program in IDLE](#running-your-program-in-idle)
- [Reading a syntax error](#reading-a-syntax-error)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [Quick reference](#quick-reference)

## What this guide covers
- What a Python program is and how Python runs it (top to bottom, one line at a time)
- How to print text with `print()`
- How to use escape sequences: `\n` (new line), `\t` (tab), `\"` (a quote mark inside text)
- How to write single-line and multi-line comments
- The header comment every BPA program needs
- Input / Processing / Output comments, which BPA graders give points for
- How to run a program in IDLE with **F5**
- What a syntax error looks like and how to find the line it is on

## What a Python program is

A Python program is a plain text file whose name ends in `.py`. Python reads the file **from the top line to the bottom line** and does what each line says, in order.

There is no special "start here" line in Python. The first line of code is where it starts. (In Step 5 you will learn about `main()`, which is a way to organize a bigger program. You don't need it yet.)

IDLE has two kinds of windows:

| Window | What it is for |
|---|---|
| **Shell** (the window that opens first, with `>>>`) | Typing one line of Python and seeing the answer right away. Good for testing small ideas. Nothing you type there is saved. |
| **Editor** (File > New File) | Writing a whole program and saving it as a `.py` file. This is where you do every challenge. |

When you run a program from the Editor, the output shows up in the Shell window.

## Printing text

`print()` shows text on the screen. Put the text inside the parentheses, inside quote marks.

```python
# Print three lines of text
print("Welcome to the computer lab.")
print('Single quotes work too.')
print("Lab hours: 7:30 AM to 2:30 PM")
```

It prints:

```text
Welcome to the computer lab.
Single quotes work too.
Lab hours: 7:30 AM to 2:30 PM
```

Things to know about `print()`:

| What you type | What it means |
|---|---|
| `print("Hello")` | Print the text `Hello`, then go to a new line. |
| `"Hello"` or `'Hello'` | A **string** — a piece of text. Double or single quotes both work. Pick one style and stay with it. These lessons use double quotes. |
| `print()` | Print an empty line (a blank line). |
| `print("A", "B")` | Print more than one thing. Python puts one space between them: `A B`. |
| `print("=" * 10)` | Repeat a string. This prints `==========` (10 equal signs). |

Spaces **inside** the quotes are printed exactly. Spaces **outside** the quotes do not matter.

```python
# Spaces inside the quotes are printed
print("Name:     Avery")
print(   "No extra spaces here"   )
print()
print("Score", 95)
print("-" * 20)
```

It prints:

```text
Name:     Avery
No extra spaces here

Score 95
--------------------
```

**Try it**
1. Print your first name, then a blank line, then your last name.
2. Print a line of 30 `*` characters using `*` and a number (one `print`, not 30 stars typed out).

## Escape sequences

Some characters are hard to type inside a string. For those you use an **escape sequence**: a backslash `\` followed by one letter or symbol. Python turns the two characters into one special character.

| What you type | What it means |
|---|---|
| `\n` | New line. Text after it starts on the next line. |
| `\t` | Tab. Moves over to the next tab stop (usually every 8 characters). |
| `\"` | A double quote mark inside a double-quoted string. |
| `\'` | A single quote mark inside a single-quoted string. |
| `\\` | One backslash. |

```python
# \n makes two lines from one print statement
print("Line one\nLine two")

# \t lines up columns using tab stops
print("Item\tPrice")
print("Pizza\t$2.00")

# \" puts a quote mark inside the text
print("The sign said \"Quiet please\".")

# \\ prints one backslash (common in Windows folder names)
print("C:\\BPA\\Python")
```

It prints:

```text
Line one
Line two
Item	Price
Pizza	$2.00
The sign said "Quiet please".
C:\BPA\Python
```

Tabs are quick, but they do not always line up when the text is different lengths. In Step 8 you will learn a better way to line up columns.

**Try it**
1. With one `print` statement, print your three favorite foods on three lines.
2. Print a two-column table of three lab rooms and their numbers using `\t`. Then make one room name very long and see what happens to the line-up.

## Comments

A **comment** is a note for people. Python skips it completely. Comments explain what the code does and why.

A comment starts with `#`. Everything from the `#` to the end of the line is ignored.

```python
# This whole line is a comment.
print("Hello")   # A comment can also go at the end of a line of code.

# A longer note can use several comment lines in a row.
# Each line needs its own # at the start.
# This is called a block comment.
print("Done")
```

It prints:

```text
Hello
Done
```

**Multi-line strings as comments.** You will also see text between three quote marks, `"""like this"""`. This is really a string, not a comment, but when it sits on its own and is not printed or saved, Python does nothing with it. Programmers use it for long notes. When it is the first line inside a function, it is called a **docstring** (you will use these in Step 5).

```python
"""
This is a multi-line note.
Python ignores it because it is not printed or stored.
"""
print("Only this line prints.")
```

It prints:

```text
Only this line prints.
```

**Commenting out code.** Putting `#` in front of a line of code turns it off without deleting it. In IDLE you can select several lines and press **Alt+3** to comment them out, and **Alt+4** to turn them back on.

**Try it**
1. Add a comment above each `print` in your "Try it" program from the last section.
2. Comment out one `print` line, run the program, and check that the line no longer prints.

## The header comment

Every program you write in these lessons starts with a **header comment**. It says who wrote it, when, and what it does.

```python
# Name: Your Name
# Date: 2026-11-06
# Program: Step 1 - Event Welcome Screen
# Description: Prints the welcome screen for MCCC Game Night,
#              with the time, the room, and the list of events.
```

At the BPA event, put your **Contestant ID** where your name goes. **Never put your name or school** on BPA work — the rules say so, and you can lose points for it.

## Input Processing Output comments

BPA graders look for comments that say what each part of the program does. The 2026 rules ask for comments on how data comes **in**, what the program **does** with it, and where results **go**. In every program from now on, label each major block with one of these:

| Comment | Use it above code that... |
|---|---|
| `# Input: ...` | gets data — from the keyboard, or from a file |
| `# Processing: ...` | does math, makes decisions, sorts, or searches |
| `# Output: ...` | prints to the screen, or writes to a file |

Step 1 has no input and no processing, so it only needs an `Output:` comment. Here is a different example:

```python
# Name: Your Name
# Date: 2026-11-06
# Program: Lunch Menu
# Description: Prints today's lunch menu.

# Output: print the menu title and the items
print("TODAY'S LUNCH")
print("-------------")
print("1. Chicken wrap\n2. Garden salad")
```

It prints:

```text
TODAY'S LUNCH
-------------
1. Chicken wrap
2. Garden salad
```

Start this habit now. By Step 11 your programs will have many blocks, and the comments are worth real points.

## Running your program in IDLE

1. Open IDLE. Click **File > New File**. An empty Editor window opens.
2. Type your program.
3. Click **File > Save As**. Pick your step folder and name the file `step01.py`. (Python will not run a file that has never been saved.)
4. Press **F5** (or click **Run > Run Module**).
5. The output appears in the **Shell** window.

Every time you change the program, press **F5** again. IDLE asks you to save first — click **OK**.

If the Shell shows `= RESTART: ...step01.py` and then your output, it worked.

## Reading a syntax error

A **syntax error** means Python could not understand a line, so it did not run **any** of the program. It is like a spelling or grammar mistake.

In IDLE, a syntax error opens a small pop-up box with the message, and IDLE highlights the spot in **red** in your code. Click **OK**, then look at the red spot **and the line above it** — the real mistake is often at the end of the line before.

If you run the program another way (like VS Code), the error shows up as text:

```
  File "C:\bpaPrep\python_step01\step01.py", line 4
    print("Bring a friend!)
          ^
SyntaxError: unterminated string literal (detected at line 4)
```

How to read it:

1. **`line 4`** — the line number where Python noticed the problem. In IDLE, the line number of your cursor is shown at the bottom right of the Editor (`Ln: 4`).
2. The copy of your code with a `^` under it — the spot where Python got confused.
3. **The last line** — what kind of error it is and a short reason. "Unterminated string literal" means a string was started with a quote but never closed.

A different kind of error happens **while** the program is running. Those are called **runtime errors** (or exceptions). The program runs until it reaches the bad line, then stops with a red **Traceback**:

```
Traceback (most recent call last):
  File "C:\bpaPrep\python_step01\step01.py", line 3, in <module>
    Print("Events tonight:")
    ^^^^^
NameError: name 'Print' is not defined. Did you mean: 'print'?
```

Again: find the line number, then read the last line. Python is case sensitive — `Print` and `print` are different names.

## Common mistakes

**1. Missing closing quote**
```python
print("Bring a friend!)   # MISTAKE - no closing quote
```
Error: `SyntaxError: unterminated string literal (detected at line 1)`
Fix: every string needs a quote at the start and the end: `print("Bring a friend!")`

**2. Missing closing parenthesis**
```python
print("Trivia"            # MISTAKE - no closing )
print("Bring a friend!")
```
Error: `SyntaxError: '(' was never closed`. Python sometimes points at the **next** line, because it kept looking for the `)`.
Fix: `print("Trivia")`

**3. Capital letter on `print`**
```python
Print("Trivia")           # MISTAKE - capital P
```
Error: `NameError: name 'Print' is not defined. Did you mean: 'print'?`
Fix: Python names are case sensitive. Use lowercase `print`.

**4. Quote marks inside a string**
```python
print("Bring your "A game"!")   # MISTAKE - the inner quotes end the string early
```
Error: `SyntaxError: invalid syntax. Perhaps you forgot a comma?`
Fix: use `\"` inside the string: `print("Bring your \"A game\"!")`, or use single quotes outside: `print('Bring your "A game"!')`

**5. Spaces that don't match the sample**
No error message — the output just looks a little different. In Build 1A (Event Welcome Screen), `   MCCC GAME NIGHT` starts with **3 spaces** and the event lines start with **2 spaces**. BPA graders check "exact output." Count the spaces.

**6. Using a forward slash for a new line**
`print("Line one/nLine two")` prints `Line one/nLine two` on one line. The escape character is the **backslash** `\`.

## How this shows up at BPA
- Every BPA Python program is graded partly on **source code review**. The header comment (with your Contestant ID, not your name) and Input / Processing / Output comments are part of that score.
- The test rules say the program **must run as-is**. A single syntax error means the whole program does not run, and the execution section scores **zero**. Run your program often so a mistake never sits there unnoticed.
- Many BPA requirements say the output must match "exactly." That means spaces, capital letters, and punctuation.
- Comments are also how graders find your code. In some years the test asks you to put flags like `#SC1` in a comment next to each graded part. You will practice that in Step 12.

## Quick reference

```python
# Name: Your Name
# Date: 2026-11-16
# Program: Program name
# Description: What the program does.

# Output: the title
print("=" * 30)                 # a line of 30 = signs
print("       TITLE")            # spaces inside the quotes are printed
print()                         # a blank line
print("Name:     Avery")        # type spaces to line things up (no tabs)
print("Line one\nLine two")     # \n = new line
print("She said \"hi\".")       # \" = a quote mark
print("C:\\BPA\\files")          # \\ = one backslash
print("It's fine")              # an apostrophe works inside double quotes
```

For the mistakes students make most on Steps 1–3, see [Steps 1–3 Common Mistakes](../Steps01-03_CommonMistakes.md).
