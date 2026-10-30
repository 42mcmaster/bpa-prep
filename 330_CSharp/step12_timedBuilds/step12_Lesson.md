# Step 12 — Timed Builds (C#)

**What you'll build:** practice programs in the real BPA format — 90 minutes, a problem, a starter, and a rubric.
**Time:** 90 minutes per build, plus time to grade yourself.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [How the BPA programming event works](#how-the-bpa-programming-event-works)
- [How it is scored](#how-it-is-scored)
- [A time plan for the 90 minutes](#a-time-plan-for-the-90-minutes)
- [What graders look for](#what-graders-look-for)
- [Things to have printed](#things-to-have-printed)
- [How to practice](#how-to-practice)
- [The timed builds in this folder](#the-timed-builds-in-this-folder)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: the timed builds](#the-challenge-the-timed-builds)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What happens at the 330 C# Programming event, start to finish
- How the program is scored, and why "it runs" matters more than anything
- A time plan for the 90 minutes
- The checklist graders use for source code review
- How to practice with a timer and grade yourself with the rubric

## How the BPA programming event works

- **90 minutes**, one program, on your own. You get a printed test booklet.
- At the 2026 regional you were given a **Visual Studio project with a pre-built Windows Form** (`Regional_C_Sharp`). The form had text boxes, list boxes, labels, radio buttons, and 12 buttons with their Click methods already made. You wrote the code inside them. (Older regionals asked you to build the whole form yourself from a table of control names and settings — be ready for both.)
- You need **Visual Studio 2019 or newer**.
- **Printed** reference materials and **printed** code are allowed. Nothing electronic, no internet, no AI, no old BPA tests.
- You make a folder on the flash drive named with your **contestant ID** and copy your **whole project** into it. Your name and school must not appear anywhere.
- Your contestant ID goes in a comment at the top of the main code file (`Form1.cs`).
- Use **relative paths** for any file. The flash drive letter may change when it is graded.

## How it is scored

The 2026 regional was worth 1030 points in three parts:

| Part | What it checks | Notes |
|---|---|---|
| Solution and project | The project is on the flash drive in one folder named with your contestant ID | No partial credit |
| **Button execution** (the big one) | Each button does what its instructions say; invalid input shows a message instead of crashing | **If the program does not run, this whole section scores zero.** Harder buttons are worth more. |
| Source code review | Comments, especially comments marked with the test's flags (`//SC1`, `//SC2`…) on specific code; the contestant ID comment; code for data structures, algorithms, exception handling, class construction | "Code must work to get credit." |

What this means for you:
1. **A program that runs with 7 working buttons beats a program with 12 half-finished buttons that won't build.** You can win without doing every button.
2. Read the commenting instructions. If the test says to flag a block with `//SC3`, the grader is looking for exactly `//SC3`. No flag, no points.
3. Input / Processing / Output comments are expected on every major block.

## A time plan for the 90 minutes

| Time | What to do |
|---|---|
| **0–10 min** | Read the **whole** booklet before typing. Note the control names, the exact messages, the comment flags, and the point values. Circle the buttons that are easy and worth a lot. |
| **10–15 min** | Set up: make the contestant-ID folder, open the project, put your ID comment at the top of `Form1.cs`, **build and run it once** to make sure it works before you change anything. |
| **15–70 min** | Do the buttons **easiest first**. After each button: run it, test good and bad input, then move on. Write the comments and flags **as you go** — not at the end. |
| **70–80 min** | Harder buttons, the "grader" / test-all button (it calls `PerformClick()` on the others, so it comes last), any extras. |
| **80–90 min** | **Stop adding.** Rebuild, run every button once, fix anything that crashes. Comment out anything that won't build. Check the ID comment. Copy the whole project folder to the flash drive. |

Run the program **every few minutes**. A build error you find right away takes 30 seconds to fix. Ten build errors you find at minute 85 can cost you everything.

If a button won't work and time is short, **leave its method empty or comment out its code** so the program still builds. An empty button scores 0 for that button; a program that won't build scores 0 for **all** of them.

## What graders look for

**Execution**
- [ ] The program builds and opens with no errors
- [ ] Every button does exactly what the instructions say, with the exact message text
- [ ] Bad input (letters, decimals, blanks, negatives, out-of-range) shows a `MessageBox`, never a crash
- [ ] Files are found with relative paths

**Source code review**
- [ ] Contestant ID comment at the top of `Form1.cs`
- [ ] The test's comment flags (`//SC1`…) on the exact blocks it lists
- [ ] Input / Processing / Output comments on every major block
- [ ] A comment on each method: purpose, parameters, returns
- [ ] Meaningful names: PascalCase methods and classes, camelCase variables, the control names left exactly as given
- [ ] Data structures used where asked (`List<string>`, arrays, a `List` of objects)
- [ ] `try` / `catch` or `TryParse` for input and files, with a comment saying what it handles
- [ ] A class with properties, a constructor, and methods, when the test asks for one

## Things to have printed

Bring a binder with:
- The [330 C# reference guide](../330_CSharp_Programming_Reference_Guide.md)
- Your Step 10 input code (`TryParse` with a range check), Step 11 Form code (ListBox, MessageBox, RadioButton, `Visible`, `PerformClick`, `Form1_Load`), and your Step 9 file reading and writing code
- These lessons, especially the "Common mistakes" sections
- Your own solutions to the timed builds

Put tabs on the pages so you can find things fast. Practice finding code in the binder — the time you spend flipping pages is time you're not typing.

## How to practice

1. **Print** the problem and the rubric. Don't look at the rubric's grading notes yet.
2. **Set a timer for 90 minutes.** No Google, no AI, no asking a friend. Printed material only — just like the real event.
3. Follow the time plan above.
4. When the timer goes off, **stop**, even if you're not done. Push what you have.
5. **Grade yourself** with the rubric. Be honest. Then read the grading notes and test the way the graders will (junk input in every box, missing data file).
6. Write down the one thing that cost you the most time. Next build, fix that first.

Your teacher will also hand out **printed** past regional tests for more practice. Do those the same way: 90 minutes, printed materials, then grade with the test's rubric.

## The timed builds in this folder

| Build | Folder | Format | What it practices | Turn-in folder |
|---|---|---|---|---|
| 1 | [timedBuild01_ButtonLogic](timedBuild01_ButtonLogic/timedBuild01.md) | Console | The logic behind common BPA buttons: reverse text, remove vowels, simple interest with `TryParse` loops | `csharp_timed01` |
| 2 | [timedBuild02_FoodTruck](timedBuild02_FoodTruck/timedBuild02.md) | **Windows Form** (pre-built, empty Click methods — the 2026 format) | A class, a `List` of objects, CSV loading, validated input, a lined-up table, best-seller loops, search, a dated report file, `PerformClick` bonus | `csharp_timed02` |

Do Timed Build 1 any time after Step 10. Do Timed Build 2 after Step 11.

## Common mistakes

**Starting to code before reading everything.**
You build a button one way, then find out on page 6 that it needed a different message or a `//SC` flag.
Fix: spend the first 10 minutes reading. It saves time.

**Not running the starter first.**
You change a dozen things and then find the project never built in the first place.
Fix: build and run the untouched project in the first few minutes.

**Renaming the given controls or Click methods.**
The graders' instructions and rubric use the original names. Renaming breaks the wiring and costs naming points.
Fix: don't rename anything you were given.

**Saving the big button for last and running out of time.**
Fix: check point values while reading. Do the buttons that give the most points for the least time first. A 100-point button that takes 15 minutes is a better use of time than a 30-point button that takes 15 minutes.

**A build error at the end.**
Fix: run every few minutes. In the last 10 minutes, only fix — don't add.

**Copying only `Form1.cs` to the flash drive.**
The graders need to open the project.
Fix: copy the whole project folder (the one with the `.sln` / `.csproj`).

## How this shows up at BPA

- This step *is* the event. Everything from Steps 1–11 shows up inside the buttons: string loops (Step 7), formulas with decimals (Step 2), `if`/radio buttons (Step 3), loops that add things up (Step 4), methods (Step 5), lists (Step 6), files (Step 9), `TryParse` and `MessageBox` (Steps 10–11).
- The 2026 regional's two most valuable items were the distance converter (100 points) and the grader button (200 points plus 50 in code review). The grader button only works if the others do — another reason to build and test as you go.

## The challenge: the timed builds

Do each timed build under real conditions (90 minutes, printed materials only), then grade yourself with its rubric. The instructions, problem, starter, and rubric for each are in its folder — see the table [above](#the-timed-builds-in-this-folder).

## Turn it in
1. In your `bpaPrep` repo make a folder for the build: `csharp_timed01` or `csharp_timed02`.
2. Put your whole Visual Studio project folder in it (for timed build 2, include `sales.csv`).
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# timed build 1 done* (or 2), plus your self-graded score.

## Checklist
- [ ] Did the build in 90 minutes with only printed materials
- [ ] Program runs with no errors
- [ ] Contestant ID (your name for practice) in a comment at the top
- [ ] Input / Processing / Output comments and the rubric's `//SC` flags
- [ ] Graded yourself with the rubric
- [ ] Pushed to `bpaPrep/csharp_timed01` or `bpaPrep/csharp_timed02`
