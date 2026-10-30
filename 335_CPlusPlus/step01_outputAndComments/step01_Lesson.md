# Step 01 — Output and Comments (C++)

**What you'll build:** Event Welcome Screen — a program that prints a welcome screen for MCCC Game Night.
**Time:** about one class period (2 hours). Do the [Setup Guide](../Setup_Guide.md) first if Visual Studio is not set up yet.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [The parts of a C++ program](#the-parts-of-a-c-program)
- [Printing with cout](#printing-with-cout)
- [Escape sequences](#escape-sequences)
- [Comments](#comments)
- [The header comment](#the-header-comment)
- [Input, Processing, and Output comments](#input-processing-and-output-comments)
- [Building and running](#building-and-running)
- [Syntax errors](#syntax-errors)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Event Welcome Screen](#the-challenge-event-welcome-screen)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- The parts every C++ program has: `#include`, `using namespace std;`, `int main()`, braces, and `return 0;`
- How to print text with `cout`
- How to start a new line with `endl` or `\n`
- Escape sequences: `\n`, `\t`, `\"`, `\\`
- Single-line comments `//` and block comments `/* */`
- The header comment and Input / Processing / Output comments that BPA graders look for
- How to build and run, and how to read a syntax error

---

## The parts of a C++ program

Here is the smallest useful C++ program. Every program you write this year starts with this shape.

```cpp
#include <iostream>
using namespace std;

int main()
{
    cout << "Hello from C++!" << endl;
    return 0;
}
```

What it prints:
```
Hello from C++!
```

Line by line:

| What you type | What it means |
|---|---|
| `#include <iostream>` | Bring in the **iostream** library. It has `cout` (console output) and `cin` (console input). Without this line, C++ does not know what `cout` is. Lines starting with `#` are instructions to the compiler, not statements, so they do **not** end with `;`. |
| `using namespace std;` | All the standard C++ tools live in a group called `std` (short for "standard"). Without this line you would have to write `std::cout` and `std::endl` every time. With it you can write just `cout` and `endl`. |
| `int main()` | The **main function**. Every C++ program starts running at the first line inside `main`. `int` means `main` gives back a whole number when it finishes. |
| `{` and `}` | Braces mark the start and end of a block of code. Everything for `main` goes between them. |
| `cout << "Hello from C++!" << endl;` | Print the text, then end the line. |
| `return 0;` | End `main` and tell Windows "the program finished normally." 0 means no problems. |
| `;` | A semicolon ends each **statement** (each instruction). Forgetting one is the most common C++ error. |

### `using namespace std;` or `std::`?

You will see both styles in books and online. These two programs do the same thing:

```cpp
// Style 1: using namespace std (what these lessons use)
#include <iostream>
using namespace std;

int main()
{
    cout << "Style one" << endl;
    return 0;
}
```

```cpp
// Style 2: write std:: in front of each standard name
#include <iostream>

int main()
{
    std::cout << "Style two" << std::endl;
    return 0;
}
```

Professional programmers often prefer `std::` in big projects so names from different libraries cannot clash. For a 90-minute BPA program, `using namespace std;` is normal, shorter, and easier to read. The lessons use it. Pick one style and stay consistent.

### Python compared with C++

If you know some Python, this table helps.

| Python | C++ | Notes |
|---|---|---|
| `print("Hi")` | `cout << "Hi" << endl;` | C++ needs the `;` |
| Runs from the top of the file | Runs from the top of `main` | |
| Indentation marks blocks | `{ }` marks blocks | Still indent your code so it is readable |
| `# comment` | `// comment` | |
| No build step | Build (compile) first, then run | Visual Studio does this when you press Ctrl+F5 |

---

## Printing with cout

`cout` (say "see-out") means **console output**. The `<<` arrows point **toward** `cout`: you are sending things to the screen. You can chain as many pieces as you like with more `<<`.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Output: three pieces sent to cout in one statement
    cout << "Room " << 112 << " is open." << endl;

    // Output: two statements that print on the same line
    cout << "Doors open at ";
    cout << "6:00 PM" << endl;

    // Output: an empty line
    cout << endl;
    cout << "Done." << endl;
    return 0;
}
```

What it prints:
```
Room 112 is open.
Doors open at 6:00 PM

Done.
```

Notes:
- Text goes inside **double quotes** `"..."`. A number like `112` does not need quotes.
- `cout` does **not** add a new line by itself. That is why `Doors open at ` and `6:00 PM` ended up on one line. To end a line, use `endl` or `\n`.
- Spaces inside the quotes are printed exactly. `"Room "` has a space at the end so the number does not touch the word.

**Try it:** Print your favorite food and your favorite game on one line using a single `cout` with three `<<` pieces.

---

## Escape sequences

Some characters cannot be typed directly inside quotes. A **backslash** `\` followed by a letter makes a special character. These are called **escape sequences**.

| What you type | What it means |
|---|---|
| `\n` | New line (same effect as `endl` when it is inside the text) |
| `\t` | Tab (jumps to the next tab stop, used to line up columns) |
| `\"` | A double quote character inside the text |
| `\\` | One backslash character |

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Output: \n makes two lines from one string
    cout << "Line one\nLine two" << endl;

    // Output: \t lines up the columns
    cout << "Name\tTeam" << endl;
    cout << "Ava\tBlue" << endl;

    // Output: quotes and a backslash inside the text
    cout << "She said \"Go team!\"" << endl;
    cout << "Save to C:\\BPA" << endl;
    return 0;
}
```

What it prints:
```
Line one
Line two
Name    Team
Ava     Blue
She said "Go team!"
Save to C:\BPA
```

### `endl` or `\n`?

Both end the line. `endl` also **flushes** the output, which means "make sure it is on the screen right now." For our programs either is fine. You can mix them. The challenge asks you to use `\n` at least once so you practice it.

**Try it:** Use `\t` to print a small two-column table of three classes and their room numbers.

---

## Comments

A **comment** is a note for people reading the code. The compiler ignores it completely.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // This is a single-line comment. It runs to the end of the line.
    cout << "Hi" << endl;   // a comment can also go after code

    /* This is a block comment.
       It can cover many lines.
       It ends with a star and a slash. */
    cout << "Bye" << endl;
    return 0;
}
```

What it prints:
```
Hi
Bye
```

| What you type | What it means |
|---|---|
| `// text` | Comment from here to the end of the line |
| `/* text */` | Comment from `/*` to `*/`, can be many lines |

Comments are also handy for turning code off while testing: put `//` in front of a line and it stops running. In Visual Studio, select lines and press **Ctrl+K, Ctrl+C** to comment them out, and **Ctrl+K, Ctrl+U** to uncomment.

---

## The header comment

Every program you write for this class and for BPA starts with a header comment:

```cpp
// Name: Your Name        (at BPA this is your Contestant ID - never your name)
// Date: today's date
// Program: Step 1 - Event Welcome Screen
// Description: one or two sentences about what the program does
```

At the real event you put your **contestant ID** where the name goes. Graders must not see your name or school.

---

## Input, Processing, and Output comments

BPA graders give points for comments that label each major block of code as:

- **Input:** where data comes from (the keyboard, a file) and what it is.
- **Processing:** the math, decisions, or logic.
- **Output:** what is shown or saved, and where.

This step only has output, so you only need `// Output:` comments. From Step 2 on you will use all three.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Output: the title banner for the bake sale
    cout << "*** BAKE SALE ***" << endl;

    // Output: the price list, one item per line
    cout << "Cookies  $1" << endl;
    cout << "Brownies $2" << endl;
    return 0;
}
```

A good comment says **what** the block does, not just the word "Output". `// Output: the price list, one item per line` is better than `// Output`.

---

## Building and running

1. Press **Ctrl+F5** in Visual Studio.
2. Visual Studio **builds** (compiles) your code into an `.exe`. Watch the Output window for `1 succeeded`.
3. The console window opens and shows your output.
4. Press any key to close the console.

If the build fails, nothing runs. Read the Error List (next section). The [Setup Guide](../Setup_Guide.md#run-the-program) has more detail.

---

## Syntax errors

A **syntax error** means the code breaks C++'s grammar rules, so it cannot be built. Here is a program with one mistake (the `;` is missing at the end of line 7):

```cpp
#include <iostream>
using namespace std;

int main()
{
    cout << "First line" << endl;
    cout << "Second line" << endl
    return 0;
}
```

Visual Studio's Error List shows:
```
C2143   syntax error: missing ';' before 'return'     step01.cpp   8
```

The mistake is on line 7, but the error says line 8. The compiler only notices the missing `;` when it reaches `return` on the next line. **Always check the reported line and the line above it.**

Double-click the error in the Error List to jump to the line. Fix the first error, build again, and repeat.

---

## Common mistakes

**1. Missing semicolon**
- Looks like: `cout << "Hi" << endl` with no `;`
- Error: `C2143 syntax error: missing ';' before ...` (g++: `expected ';' before ...`)
- Fix: add `;` at the end of the statement. Check the line above the one reported.

**2. Forgot `#include <iostream>` or `using namespace std;`**
- Error: `C2065 'cout': undeclared identifier` (g++: `'cout' was not declared in this scope`)
- Fix: add both lines at the top.

**3. Wrong arrow direction**
- Looks like: `cout >> "Hi";`
- Error: `C2678 binary '>>': no operator found ...` (a long, confusing message)
- Fix: output uses `<<` (arrows point toward `cout`).

**4. Single quotes around text**
- Looks like: `cout << 'Hello';`
- Result: a warning about a multi-character constant, and a number prints instead of the word.
- Fix: text uses **double quotes** `"Hello"`. Single quotes are for one character only, like `'A'` (Step 3).

**5. Curly "smart" quotes**
- Looks like: `cout << “Hello”;` (copied from Word or Google Docs)
- Error: `C3872 '0x201c': this character is not allowed in an identifier` or `stray '\342' in program`
- Fix: retype the quotes in Visual Studio.

**6. Wrong spacing in the output**
- Looks like: `   MCCC GAME NIGHT` printed with 2 spaces instead of 3.
- Result: the output does not match the sample. At BPA, "matches the sample" is part of the score.
- Fix: count the spaces in the sample run and copy them exactly.

---

## How this shows up at BPA

- Every BPA C++ program must start with your **contestant ID in a comment**. The 2024 test said this outright.
- The 2026 regional's comment rules ask for **Input, Processing, and Output** comments on every major part. Points are awarded for them. Get in the habit now.
- If your program does not build, the whole execution section scores **zero**. Learning to read a syntax error quickly is a real competition skill.
- Exact output matters. Graders compare your screen with their sample.

---

## The challenge: Event Welcome Screen

Write a program that prints the welcome screen for MCCC Game Night.

**Requirements**
1. Header comment at the top (name, date, program name, description).
2. Print exactly the welcome screen below.
3. Use at least one `\n` inside a single print statement to make two lines.
4. An `Output:` comment (in your language's comment style) above the printing block.

**Sample run (exact)**
```
==============================
   MCCC GAME NIGHT
   Friday, 6:00 PM - Room 112
==============================
Events tonight:
  1. Board Games
  2. Video Game Tournament
  3. Trivia
Bring a friend!
```

**Hints**
- The `=` lines are 30 equal signs. Count them, or copy the line from this page.
- `MCCC GAME NIGHT` and the `Friday` line start with **3** spaces. The numbered events start with **2** spaces.
- One `cout` with `\n` in the middle can print the two lines inside the banner.
- In C++ the Output comment looks like `// Output: ...`.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step01`. (If you created the Visual Studio project named `cpp_step01` inside `bpaPrep`, it already exists.)
2. Put `step01.cpp` in it. If you used a Visual Studio project, push the whole project folder.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 1 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run (count the spaces and the `=` signs)
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments (this step: an `Output:` comment)
- [ ] At least one `\n` inside a single print statement
- [ ] Pushed to `bpaPrep/cpp_step01`
