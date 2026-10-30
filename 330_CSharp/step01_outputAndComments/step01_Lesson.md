# Step 01 — Output and Comments (C#)

**What you'll build:** Event Welcome Screen — a program that prints a welcome screen for MCCC Game Night.
**Time:** about one class period (2 hours). If you have never made a console project in Visual Studio, do the [Setup Guide](../Setup_Guide.md) first.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [The parts of a C# program](#the-parts-of-a-c-program)
- [Printing text](#printing-text)
- [Escape sequences](#escape-sequences)
- [Comments](#comments)
- [The header comment](#the-header-comment)
- [Input Processing Output comments](#input-processing-output-comments)
- [Running your program](#running-your-program)
- [Reading a syntax error](#reading-a-syntax-error)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Event Welcome Screen](#the-challenge-event-welcome-screen)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What each line of a C# console program does (`using`, `namespace`, `class Program`, `static void Main`)
- How to print text with `Console.WriteLine` and `Console.Write`
- How to use escape sequences: `\n` (new line), `\t` (tab), `\"` (a quote mark inside text)
- How to write single-line and multi-line comments
- The header comment every BPA program needs
- Input / Processing / Output comments, which BPA graders give points for
- How to run a program with **Ctrl+F5**
- What a syntax error looks like and how to find the line it is on

## The parts of a C# program

Make a new Console App named `Step01` (see the [Setup Guide](../Setup_Guide.md#make-your-first-console-project) — remember to check **Do not use top-level statements**). Visual Studio gives you this:

```csharp
namespace Step01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

That is a lot of lines just to print one sentence. Here is what each part means. In every lesson we also add one line at the very top: `using System;`.

| What you type | What it means |
|---|---|
| `using System;` | "I am going to use things from the **System** library." `Console` lives in `System`. Your project already includes it behind the scenes, but writing it makes your code work in any kind of C# project, so we always write it. |
| `namespace Step01` | A **namespace** is a name tag for a group of code. Visual Studio uses your project name. You can ignore it — just don't delete it. |
| `internal class Program` | In C#, all code lives inside a **class**. This class is named `Program`. `internal` means "only this project can use it." You will make your own classes in Step 11. |
| `static void Main(string[] args)` | **`Main` is where the program starts.** When you run the program, C# finds `Main` and runs the lines inside it from top to bottom. `void` means Main does not hand back an answer. `static` and `string[] args` are explained in Step 5 — for now, leave them as they are. |
| `{` and `}` | **Curly braces** mark where something starts and ends. The namespace, the class, and `Main` each have their own pair. Every `{` needs a matching `}`. |
| `Console.WriteLine("Hello, World!");` | A **statement** — one instruction. It prints `Hello, World!` and moves to the next line. |
| `;` | Every statement ends with a **semicolon**. It is like a period at the end of a sentence. |

C# is **case-sensitive**. `Console` and `console` are different words to C#. `Main` must have a capital M.

Indentation (the spaces at the start of each line) does not change what the program does, but it shows which code is inside which braces. Visual Studio indents for you. Keep it neat — graders read your code.

## Printing text

`Console.WriteLine` prints text and then moves to a new line. `Console.Write` prints text and stays on the same line.

```csharp
using System;

namespace PrintDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // WriteLine prints the text, then moves to the next line
            Console.WriteLine("Welcome to the computer lab.");
            Console.WriteLine("Lab hours: 7:30 AM to 2:30 PM");

            // Write stays on the same line, so these two join together
            Console.Write("Room ");
            Console.Write("112");

            // WriteLine with nothing inside prints an empty line
            Console.WriteLine();
            Console.WriteLine("Have a good day!");
        }
    }
}
```

It prints:

```text
Welcome to the computer lab.
Lab hours: 7:30 AM to 2:30 PM
Room 112
Have a good day!
```

The `Console.WriteLine()` with nothing inside the parentheses ended the `Room 112` line. If you call it again it prints a blank line.

Text inside double quotes is called a **string**. Spaces inside the quotes are printed exactly as you type them. `"  1. Pizza"` prints two spaces before the `1`.

**Try it:**
- Print your three favorite foods, one per line, each starting with two spaces and a number like `  1. Tacos`.
- Use `Console.Write` three times to print `A`, `B`, and `C` all on one line.

## Escape sequences

Some characters are hard to type inside a string. You can't press Enter in the middle of a string, and a `"` would end the string early. C# uses a **backslash** `\` followed by a letter for these. They are called **escape sequences**.

| What you type | What it prints |
|---|---|
| `\n` | a new line (like pressing Enter) |
| `\t` | a tab (jumps over to the next tab stop, used to line things up) |
| `\"` | a double quote mark `"` |
| `\\` | one backslash `\` |

```csharp
using System;

namespace EscapeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // \n inside one string makes two lines
            Console.WriteLine("Line one\nLine two");

            // \" puts quote marks inside the text
            Console.WriteLine("The club motto is \"Code every day.\"");

            // \t lines up columns
            Console.WriteLine("Name\tRoom");
            Console.WriteLine("Lab\t112");

            // \\ prints one backslash (useful for Windows folder names)
            Console.WriteLine("Save it in C:\\BPA");
        }
    }
}
```

It prints:

```text
Line one
Line two
The club motto is "Code every day."
Name	Room
Lab	112
Save it in C:\BPA
```

**Try it:**
- Print a small table with `\t`: three rows of `Item\tPrice` (for example `Pretzel\t2.75`). Notice how the tab lines up the second column.
- Print this sentence exactly, quote marks included: `She said "BPA is on Friday."`

## Comments

A **comment** is a note for people. C# ignores it completely. Graders read your comments, so they matter at BPA.

| What you type | What it means |
|---|---|
| `// note` | A **single-line comment**. Everything from `//` to the end of the line is ignored. |
| `/* note */` | A **block comment**. Everything between `/*` and `*/` is ignored, even across many lines. |
| `/// <summary>` | An XML documentation comment. Visual Studio uses these in some files it makes for you. You don't need to write them. |

```csharp
// This whole line is a comment
Console.WriteLine("Hi");   // a comment can also go after code

/* This is a block comment.
   It can go on for
   several lines. */
Console.WriteLine("Bye");
```

Only `Hi` and `Bye` are printed. The comments are skipped.

You can also use `//` to **turn off a line of code** without deleting it. This is called "commenting out" a line. In Visual Studio, select some lines and press **Ctrl+K, Ctrl+C** to comment them out, and **Ctrl+K, Ctrl+U** to un-comment them.

## The header comment

Every program you write for these steps starts with a header comment. At BPA you put your **contestant ID** where your name goes — never your real name or your school.

```csharp
// Name: Your Name        (at BPA this is your Contestant ID - never your name)
// Date: today's date
// Program: Step 1 - Event Welcome Screen
// Description: Prints the welcome screen for MCCC Game Night
//              with the list of events.
```

It goes at the very top of `Program.cs`, above `using System;`.

## Input Processing Output comments

BPA graders give points for comments that label each major block of code:

| Label | Use it above code that… |
|---|---|
| `// Input:` | gets data — reads what the user types, reads a file, reads a text box |
| `// Processing:` | works on the data — math, decisions, loops, sorting |
| `// Output:` | shows or saves results — prints, writes a file, fills a label |

Add a few words saying what the block does: `// Output: print the list of events`. In Step 1 the program only prints, so you only need `Output:` comments. Starting in Step 2 you will use all three.

## Running your program

Press **Ctrl+F5**. Visual Studio saves your file, **builds** it (turns your C# into a program the computer can run, `Step01.exe`), and runs it. A console window opens and shows what your program prints.

If you change your code, close the console window and press Ctrl+F5 again. The window always shows the **last version that built**.

## Reading a syntax error

A **syntax error** is a typing mistake that breaks the rules of C# — a missing semicolon, a missing quote mark, a misspelled word. C# refuses to build the program until you fix it.

Here is a program with a missing semicolon on line 13:

```csharp
// Name: Practice
// Date: 2026-11-06
// Program: Error demo
// Description: Shows a syntax error.
using System;
namespace ErrorDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First line");
            Console.WriteLine("Second line")
            Console.WriteLine("Third line");
        }
    }
}
```

When you press Ctrl+F5, Visual Studio asks "There were build errors. Would you like to continue and run the last successful build?" Click **No**. The **Error List** (View → Error List) shows:

| Code | Description | File | Line |
|---|---|---|---|
| CS1002 | ; expected | Program.cs | 13 |

Double-click the row to jump to line 13. Add the `;` and run again.

Three errors you will see a lot:

| Error | What it usually means |
|---|---|
| `CS1002 ; expected` | A statement is missing its semicolon. Look at the end of that line. |
| `CS1010 Newline in constant` | A string is missing its closing `"`. |
| `CS0103 The name 'console' does not exist in the current context` | A word is misspelled or has the wrong capital letters (`console` instead of `Console`). |
| `CS1513 } expected` | A `{` has no matching `}`. Count your braces. |

Fix the **first** error in the list first. One missing brace can create ten errors below it.

## Common mistakes

**Lower-case `console` or `writeline`.**
You see: `CS0103 The name 'console' does not exist in the current context`, or `CS0117 'Console' does not contain a definition for 'writeline'`.
Fix: C# is case-sensitive. It is `Console.WriteLine` — capital C, capital W, capital L.

**Forgetting the semicolon.**
You see: `CS1002 ; expected`.
Fix: every `Console.WriteLine(...)` line ends with `;`.

**Using single quotes for text.**
You type `Console.WriteLine('Hello');` and see `CS1012 Too many characters in character literal`.
Fix: in C#, text (a string) uses **double** quotes `"Hello"`. Single quotes are only for one character, like `'A'` (Step 7).

**A quote mark inside the text.**
You type `Console.WriteLine("He said "hi"");` and get several errors.
Fix: use `\"` for a quote inside a string: `"He said \"hi\""`.

**Spaces don't match the sample.**
The program runs, but `Events tonight:` lines up wrong or there is a missing space.
Fix: count the spaces in the sample run. `   MCCC GAME NIGHT` starts with **three** spaces. `  1. Board Games` starts with **two**.

**Code typed outside `Main`.**
You see errors like `CS0116 A namespace cannot directly contain members such as fields, methods or statements` or `CS1519 Invalid token`.
Fix: your statements must be inside Main's braces — between the `{` under `static void Main` and its matching `}`.

## How this shows up at BPA

- Graders award points for comments. The 2026 regional asked for **Input / Processing / Output** comments on all major parts of the program, plus a comment with your contestant ID at the top of the main file.
- If your program does not build and run, the execution section scores **zero**. Learn to read the Error List quickly so a small typo doesn't cost you.
- Output that matches the requested text exactly (spelling, spaces, punctuation) is what the graders check against.

## The challenge: Event Welcome Screen

Write a program that prints the welcome screen for MCCC Game Night.

**Requirements:**
1. Header comment at the top (name, date, program name, description).
2. Print exactly the welcome screen below.
3. Use at least one `\n` inside a single print statement to make two lines.
4. An `Output:` comment (in your language's comment style) above the printing block.

**Sample run (exact):**
```text
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

**Hints:**
- Each `=` line has exactly 30 equal signs. Copy and paste one line so both match.
- Count the spaces at the start of each line: three before `MCCC` and `Friday`, two before each numbered event.
- For requirement 3, pick two lines that are next to each other and print them with one `Console.WriteLine` that has `\n` between them.
- In C# comment style, requirement 4 looks like `// Output: print the welcome banner`.

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step01`.
2. Put your whole Visual Studio project folder (`Step01`) in it. If you made the project with the Setup Guide settings, it is already there.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 1 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run (every space and every `=`)
- [ ] Header comment with name, date, program, description
- [ ] `Output:` comment above the printing code
- [ ] At least one `Console.WriteLine` uses `\n` to print two lines
- [ ] Pushed to `bpaPrep/csharp_step01`
