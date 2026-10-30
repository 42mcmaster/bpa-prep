# Programming Steps — Overview

The four BPA programming events — **355 Python, 335 C++, 340 Java, and 330 C#** — all test the same thing: build one working program in 90 minutes that takes input, checks it, stores data in lists, does calculations, reads and writes files, handles errors, and is organized into commented functions.

So every language follows **the same 12 steps**, and **each step has the same challenge in every language**. The prompts, the requirements, and the sample run are identical. Only the code is different. If you switch languages, you land on the same step.

## Table of Contents

- [The 12 steps](#the-12-steps)
- [Where to start](#where-to-start)
- [How a step works](#how-a-step-works)
- [How to turn in a step](#how-to-turn-in-a-step)
- [Tools for each language](#tools-for-each-language)
- [Which language should I pick?](#which-language-should-i-pick)

---

## The 12 steps

| Step | What you learn | What you build |
|---|---|---|
| 1 | Output and comments | **Event Welcome Screen** — print a formatted screen |
| 2 | Variables, input, math, formatting | **Snack Bar Order** — a receipt with tax |
| 3 | If statements | **Grade Checker** — letter grade and pass/fail |
| 4 | Loops and random numbers | **Number Guessing Game** — with play again |
| 5 | Functions | **Snack Bar with Functions** — several items, one receipt |
| 6 | Lists and arrays | **Score Stats** — highest, lowest, average, sorted |
| 7 | Strings | **Secret Message** — encode and decode a cipher |
| 8 | Nested data (lists of lists, 2D arrays) | **Team Scoreboard** — a sorted leaderboard table |
| 9 | Files | **Scoreboard From a File** — read a CSV, write a report |
| 10 | Error handling | **Ticket Order** — input that can't crash the program |
| 11 | Menu programs and classes | **Club Manager** — a full menu program (C#: a Windows Form) |
| 12 | Timed builds | 90-minute practice builds, like the real event |

Each step adds one or two new ideas, and every challenge reuses the earlier ones. By Step 11 you are writing the same kind of program the regional test asks for.

---

## Where to start

| Event | Folder | Setup guide |
|---|---|---|
| 355 Python | [355_Python](355_Python/) | [Setup_Guide.md](355_Python/Setup_Guide.md) |
| 335 C++ | [335_CPlusPlus](335_CPlusPlus/) | [Setup_Guide.md](335_CPlusPlus/Setup_Guide.md) |
| 340 Java | [340_Java](340_Java/) | [Setup_Guide.md](340_Java/Setup_Guide.md) |
| 330 C# | [330_CSharp](330_CSharp/) | [Setup_Guide.md](330_CSharp/Setup_Guide.md) |

1. Open your event's folder and read its **README**.
2. Do the **Setup Guide** first. It walks you through the tools and your first program.
3. Start **Step 1**. Do the steps in order. You keep track of which step you're on — steps are not tied to dates.

If you already know the language well, you can move quickly through the early steps, but still turn each one in. They're short when you know the material.

---

## How a step works

Every step folder has a **lesson file** (`stepNN_Lesson.md`). Each lesson has:

1. **Explanations** of the new ideas, with small commented examples.
2. **Try it** exercises — quick practice, not turned in.
3. **Common mistakes** — the errors you'll probably hit and how to fix them.
4. **How this shows up at BPA** — what the graders look for.
5. **The challenge** — numbered requirements and an exact sample run. Your program's output should match the sample run.
6. **Turn it in** and a **checklist**.

Print the lessons if it helps. Printed notes and printed code are allowed in all four programming events. Your own code from these steps is good printed reference to bring.

---

## How to turn in a step

1. In your **`bpaPrep`** GitHub repo, make a folder for the step:

   | Language | Folder name | File |
   |---|---|---|
   | Python | `python_step01` | `step01.py` |
   | C++ | `cpp_step01` | `step01.cpp` (or the whole Visual Studio project folder) |
   | Java | `java_step01` | `Step01.java` |
   | C# | `csharp_step01` | the whole Visual Studio project folder |

2. Put your program in it, commit, and push with GitHub Desktop.
3. On the Google Classroom **BPA Friday** assignment, add a private comment like *Java step 4 done*.

---

## Tools for each language

| Language | Tool | What IT needs to install on lab computers |
|---|---|---|
| Python | **IDLE** (comes with Python) | Python 3 from python.org |
| C++ | **Visual Studio 2022 Community** | The **"Desktop development with C++"** workload |
| Java | **VS Code** with the **Extension Pack for Java** | **JDK 21** (Eclipse Temurin) and the VS Code extension |
| C# | **Visual Studio 2022 Community** | The **".NET desktop development"** workload |

Each language's Setup Guide has the full details and a box for the teacher/IT.

---

## Which language should I pick?

- **Python** — the easiest to read and write. Also the language of the Programming course and the Certiport Python exam.
- **C#** — you've used it in Visual Studio already (Pac-Man). The BPA event uses **Windows Forms** (buttons and text boxes). Fewer students enter it.
- **C++** — closest to the Arduino code you write. The event is a console menu program.
- **Java** — similar to C#. The event uses exact prompts and exact variable names, so it rewards careful reading.
