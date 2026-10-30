# Step 01 — Output and Comments (Java)

**What you'll build:** Event Welcome Screen — a program that prints the welcome screen for the MCCC Game Night.
**Time:** about one class period (2 hours). If Java is not set up yet, do the [Setup Guide](../Setup_Guide.md) first.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [The shape of every Java program](#the-shape-of-every-java-program)
- [The file name must match the class name](#the-file-name-must-match-the-class-name)
- [Printing text](#printing-text)
- [Escape sequences](#escape-sequences)
- [Comments](#comments)
- [The header comment](#the-header-comment)
- [Input, Processing, and Output comments](#input-processing-and-output-comments)
- [Running your program](#running-your-program)
- [Syntax errors and how to read them](#syntax-errors-and-how-to-read-them)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Event Welcome Screen](#the-challenge-event-welcome-screen)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- The parts every Java program has: `public class`, `main`, curly braces, and semicolons
- Why the file name must match the class name
- How to print with `System.out.println` and `System.out.print`
- Escape sequences: `\n` (new line), `\t` (tab), `\"` (a quote mark inside text)
- Single-line comments (`//`) and block comments (`/* ... */`)
- The header comment BPA requires at the top of every program
- Input / Processing / Output comments, which BPA graders give points for
- How to run a program and how to read a syntax error

---

## The shape of every Java program

Every Java program you write in this class has the same shape. Here is the smallest useful one:

```java
public class LibraryHours {
    public static void main(String[] args) {
        System.out.println("The library is open until 3:30 today.");
    }
}
```

It prints:

```
The library is open until 3:30 today.
```

Here is what each line means. You will type these lines in every program, so it is worth learning them once.

| What you type | What it means |
|---|---|
| `public class LibraryHours {` | Java code must live inside a **class**. A class is a named container for code. This one is named `LibraryHours`. `public` means other code is allowed to use it. The `{` opens the class. |
| `public static void main(String[] args) {` | The **main method**. When you run the program, Java looks for this exact line and starts here. A **method** is a named block of code (Python calls these functions). |
| `public` | Java (the program that runs your code) is allowed to call `main`. |
| `static` | `main` belongs to the class itself, so Java can run it without making an object first. Step 5 explains this more. For now: always type it. |
| `void` | `main` does not give back (return) a value. |
| `String[] args` | Words typed after the program name on the command line. We never use them, but Java requires the line to look like this. |
| `System.out.println(...)` | Print the text inside the parentheses, then move to a new line. |
| `;` | Ends a statement. Almost every line that *does* something ends with a semicolon. |
| `}` | Closes a block. The first `}` closes `main`. The last one closes the class. |

**Curly braces come in pairs.** Every `{` needs a matching `}`. VS Code highlights the matching brace when your cursor is next to one. Indenting the code inside each pair (4 spaces) makes it easy to see which braces go together. Java does not care about indenting, but graders and teachers do.

**Java is case-sensitive.** `System` is not the same as `system`. `String` is not the same as `string`. `Main` is not `main`. Copy the capitals exactly.

**Try it:**
1. Make a file `LibraryHours.java`, type the program, and run it.
2. Change the message and run it again.

---

## The file name must match the class name

In Java, a `public class` must be saved in a file with **exactly** the same name, plus `.java`.

| Class line | File name it must be in |
|---|---|
| `public class LibraryHours {` | `LibraryHours.java` |
| `public class Step01 {` | `Step01.java` |
| `public class step01 {` | `step01.java` (but don't do this - class names start with a capital letter) |

If they don't match, the program will not compile:

```
LibraryHour.java:1: error: class LibraryHours is public, should be declared in a file named LibraryHours.java
public class LibraryHours {
       ^
```

Class names use **PascalCase**: every word starts with a capital letter and there are no spaces (`LibraryHours`, `ScoreTracker`, `Step01`). That is why your challenge files are named `Step01.java`, `Step02.java`, and so on.

---

## Printing text

Java has two main printing commands.

| What you type | What it does |
|---|---|
| `System.out.println("text");` | Prints the text, then moves to the next line. (`println` = "print line".) |
| `System.out.print("text");` | Prints the text and stays on the same line. |
| `System.out.println();` | Prints an empty line. |

```java
public class PrintDemo {
    public static void main(String[] args) {
        System.out.print("Bus 14 ");          // stays on the same line
        System.out.print("leaves at ");      // still the same line
        System.out.println("3:05 PM.");      // finishes the line
        System.out.println();                // a blank line
        System.out.println("Do not be late!");
    }
}
```

Output:

```
Bus 14 leaves at 3:05 PM.

Do not be late!
```

Text inside double quotes is called a **String**. Spaces inside the quotes are printed exactly. Spaces outside the quotes don't matter.

You can join (concatenate) Strings with `+`:

```java
System.out.println("Room " + "112");   // prints Room 112
```

**Try it:**
1. Use three `print` statements and one `println` to print one sentence.
2. Print a box made of `*` characters, five lines tall.

---

## Escape sequences

Some characters can't be typed directly inside a String. You write them with a backslash `\` followed by a letter. These are called **escape sequences**.

| What you type | What it prints |
|---|---|
| `\n` | A new line |
| `\t` | A tab (jumps to the next tab stop, usually every 8 characters) |
| `\"` | A double quote mark `"` |
| `\\` | One backslash `\` |

```java
public class EscapeDemo {
    public static void main(String[] args) {
        // \n makes two lines from one println
        System.out.println("Lunch menu\nPizza or salad");

        // \" puts quote marks inside the text
        System.out.println("The sign said \"No running in the halls.\"");

        // \t lines things up in columns
        System.out.println("Day\tTime");
        System.out.println("Mon\t8:00");
        System.out.println("Tue\t9:15");
    }
}
```

Output:

```
Lunch menu
Pizza or salad
The sign said "No running in the halls."
Day	Time
Mon	8:00
Tue	9:15
```

Without the backslash, `"The sign said "No running..."` would end the String at the second `"` and Java would give an error.

**Try it (tabs):**
1. Print a small table of three classes and their room numbers using `\t` between the columns.
2. Print a Windows file path like `C:\BPA\Java` (you need `\\` for each backslash).

---

## Comments

A **comment** is a note for people. Java ignores it completely. Comments explain *why* the code does what it does and make it easy to grade.

```java
// This is a single-line comment. Everything after // on this line is ignored.

/*
 * This is a block comment.
 * It can cover many lines.
 * The * at the start of each middle line is just for looks.
 */

System.out.println("Hello");   // A comment can go at the end of a line too.
```

| What you type | What it means |
|---|---|
| `// note` | Comment from `//` to the end of the line |
| `/* note */` | Comment from `/*` to `*/`, can be many lines |

You can also "comment out" a line of code to turn it off without deleting it. That is handy for testing:

```java
// System.out.println("This line will not run.");
```

In VS Code, **Ctrl+/** comments or uncomments the line your cursor is on (or all selected lines).

---

## The header comment

Every program you write in this class - and at BPA - starts with a header comment:

```java
// Name: Your Name        (at BPA this is your Contestant ID - never your name)
// Date: today's date
// Program: Step 1 - Event Welcome Screen
// Description: one or two sentences about what the program does
```

At BPA, your **Contestant ID** goes here instead of your name. Your name and school must never appear in work you turn in at BPA. Graders give points for the ID comment, and the Java tests also use the last two digits of your ID in variable names (you will see that in Step 12).

The header goes at the very top of the file, above `public class`.

---

## Input, Processing, and Output comments

BPA graders look for comments that label the **major blocks** of your program:

- **Input:** how data gets into the program (the keyboard, a file).
- **Processing:** the math, decisions, and logic.
- **Output:** what gets printed or saved, and where.

The 2026 Java regional gave **50 points** just for proper commenting. In Step 1 there is only output, so you have one `Output:` comment. Later programs will have all three.

```java
public class ClubMeeting {
    public static void main(String[] args) {
        // Output: print the meeting notice to the console.
        System.out.println("Coding Club meets Tuesday in Room 204.");
        System.out.println("Bring your laptop.");
    }
}
```

---

## Running your program

There are two ways. (Both are in the [Setup Guide](../Setup_Guide.md).)

**In VS Code:** open the folder, open the `.java` file, wait for "Java: Ready" at the bottom, and click **Run** above `main` (or the triangle button at the top right). Output appears in the **Terminal** panel at the bottom.

**On the command line:**

```
javac Step01.java
java Step01
```

`javac` compiles (checks and translates) your code into `Step01.class`. `java Step01` runs it. You type the class name with no ending.

---

## Syntax errors and how to read them

A **syntax error** means the code breaks Java's grammar rules. Java will not run the program at all until you fix it.

Example with a missing closing quote on line 3:

```java
public class Broken {
    public static void main(String[] args) {
        System.out.println("Welcome to the game);
    }
}
```

`javac Broken.java` prints:

```
Broken.java:3: error: unclosed string literal
        System.out.println("Welcome to the game);
                           ^
1 error
```

Read it in this order:
1. **File and line number:** `Broken.java:3` means line 3.
2. **Message:** `unclosed string literal` means a String was started with `"` and never ended.
3. **The `^` mark:** points to where Java noticed the problem (the start of the String).

Fix the first error, save, and compile again. In VS Code you will see a red squiggly line under the problem before you even run it - hover over it to read the message.

---

## Common mistakes

**1. File name and class name don't match**
- Looks like: file `step01.java` with `public class Step01`.
- Error: `class Step01 is public, should be declared in a file named Step01.java`
- Fix: rename the file to `Step01.java` (right-click > Rename in VS Code).

**2. Missing semicolon**
- Looks like: `System.out.println("Hi")`
- Error: `error: ';' expected`
- Fix: put `;` at the end of the statement.

**3. Lowercase `system` or `String`**
- Looks like: `system.out.println("Hi");`
- Error: `error: package system does not exist`
- Fix: `System` with a capital S. Java is case-sensitive.

**4. Missing `}`**
- Looks like: you forgot to close `main` or the class.
- Error: `error: reached end of file while parsing`
- Fix: count your braces. Every `{` needs a `}`. Indent so you can see the pairs.

**5. Forgetting the backslash before a quote**
- Looks like: `System.out.println("Say "hi"");`
- Error: `error: ')' or ',' expected` (often with more errors on the same line)
- Fix: `System.out.println("Say \"hi\"");`

**6. Output that is "almost" right**
- Looks like: two spaces where the sample has three, or a missing `!`.
- No error message - the program runs, but the output does not match.
- Fix: compare your output to the sample run character by character. BPA Java tests say the output must match **exactly**.

---

## How this shows up at BPA

- The Java test says "Your code must produce the exact output given in the directions." Graders compare your output to the sample. Spacing and punctuation count.
- Your Contestant ID must be in a comment at the top of the program. That is points you get just for remembering.
- Input / Processing / Output comments are worth a lot of points (50 points on the 2026 regional).
- The program file name is given to you (for example, a class named in the directions). The class name must match it, or the program won't compile and **execution scores zero**.

---

## The challenge: Event Welcome Screen

Write a program that prints the welcome screen for the MCCC Game Night.

**Requirements**
1. Header comment at the top (name, date, program name, description).
2. Print exactly the welcome screen below.
3. Use at least one `\n` inside a single print statement to make two lines.
4. An `Output:` comment (in your language's comment style) above the printing block.

**Sample run (exact):**
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
- The class must be `public class Step01` in a file named `Step01.java`.
- Count the spaces: the second and third lines start with **3** spaces. The numbered events start with **2** spaces. Each `=` line has **30** equal signs.
- For requirement 3, pick two lines that are next to each other and print them with one `println` that has `\n` between them.
- In Java, the comment style is `//` for a line, so your output comment is `// Output: ...`.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step01`.
2. Put `Step01.java` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 1 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments (for this step: an `// Output:` comment)
- [ ] File is named `Step01.java` and the class is `public class Step01`
- [ ] At least one `\n` inside a single print statement
- [ ] Pushed to `bpaPrep/java_step01`
