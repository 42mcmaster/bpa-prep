# 330 C# Programming

**Format:** One program, 90 minutes. At the 2026 regional you were handed a Visual Studio project with a pre-built Windows Form, and you wrote the code behind its buttons. Put your contestant ID in a comment at the top. Use relative file paths only.

**Reference materials in the real test:** **Yes, including printed code.** You may bring printed reference materials and printed pre-written code. Nothing electronic, no internet, no AI, no old BPA tests.

**Software:** Visual Studio 2019 or newer. We use Visual Studio 2022 Community.

The 2026 regional was a pre-built Windows Forms app with 12 buttons to program: string reversal, removing vowels, a loan payment, a distance converter, a counter, show/hide, and a "grader" button that clicks the other buttons from code. Every major block needed an Input / Processing / Output comment.

## Start here

1. [Setup_Guide.md](Setup_Guide.md) — install check, your first program, how to push to GitHub. Do this before Step 1.
2. Print the study guide: [330_CSharp_Programming_Reference_Guide.md](330_CSharp_Programming_Reference_Guide.md). Print each lesson too. You can bring all of it to the event.

## The 12 steps

| Step | Folder | What you learn | What you build |
|---|---|---|---|
| 1 | [step01_outputAndComments](step01_outputAndComments/step01_Lesson.md) | Program structure, `Console.WriteLine`, escape sequences, comments, reading errors | Event Welcome Screen |
| 2 | [step02_variablesAndInput](step02_variablesAndInput/step02_Lesson.md) | Variables, data types, `Console.ReadLine`, converting text to numbers, math, money formatting | Snack Bar Order |
| 3 | [step03_ifStatements](step03_ifStatements/step03_Lesson.md) | `if` / `else if` / `else`, `&&` `\|\|` `!`, comparing text, `switch` | Grade Checker |
| 4 | [step04_loops](step04_loops/step04_Lesson.md) | `while` and `for` loops, counters, `Random`, play-again loops | Number Guessing Game |
| 5 | [step05_functions](step05_functions/step05_Lesson.md) | `static` methods, parameters, return values, `void`, scope | Snack Bar with Functions |
| 6 | [step06_listsAndArrays](step06_listsAndArrays/step06_Lesson.md) | Arrays, `List<int>`, loops over lists, highest/lowest/average, sorting | Score Stats |
| 7 | [step07_strings](step07_strings/step07_Lesson.md) | Characters, string methods, `StringBuilder`, `%` for wrap-around | Secret Message |
| 8 | [step08_nestedData](step08_nestedData/step08_Lesson.md) | 2D arrays, nested loops, sorting rows, table formatting | Team Scoreboard |
| 9 | [step09_files](step09_files/step09_Lesson.md) | Reading and writing files, CSV, `using`, dates | Scoreboard From a File |
| 10 | [step10_errorHandling](step10_errorHandling/step10_Lesson.md) | `try` / `catch`, `int.TryParse`, reusable input methods | Ticket Order |
| 11 | [step11_menuProgram](step11_menuProgram/step11_Lesson.md) | **Windows Forms**, controls, Click events, `MessageBox`, a class, a list of objects | Club Manager (form) |
| 12 | [step12_timedBuilds](step12_timedBuilds/step12_Lesson.md) | How the 90-minute event works, a time plan | Timed builds in the BPA format |

Steps 1–10 are console programs (text in a black window). That is the fastest way to learn the C# logic. Step 11 moves that logic onto a Windows Form, which is what the real event uses. Step 12 practices the full 90-minute format.

## How to turn in

1. Use your **`bpaPrep`** GitHub repository (the one you already have).
2. Each step gets its own folder: `csharp_step01`, `csharp_step02`, … `csharp_step11`. Timed builds use `csharp_timed01`, `csharp_timed02`.
3. Put your whole Visual Studio project folder in it, then commit and push with GitHub Desktop.
4. In the Google Classroom **BPA Friday** assignment, write a private comment: *C# step 4 done*.

## How Fridays work for this event

- Do the next step. You keep track of which step you are on.
- Steps are not tied to dates. Some take one Friday, some take two.
- If you finish a step early, start the next one.
- Every step ends with a challenge program. Make it match the sample run exactly, then push it.
