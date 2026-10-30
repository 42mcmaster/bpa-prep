# Step 12 — Timed Builds (C++)

**What you'll build:** practice BPA tests under real time limits, starting with a 3-option mini menu and then a full 90-minute food truck menu program.
**Time:** 90 minutes per timed build, plus time to grade yourself. Do them on separate Fridays.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [How the BPA C++ event works](#how-the-bpa-c-event-works)
- [How it is scored](#how-it-is-scored)
- [A plan for the 90 minutes](#a-plan-for-the-90-minutes)
- [Build a working skeleton first](#build-a-working-skeleton-first)
- [What graders look for](#what-graders-look-for)
- [What to bring: your printed code](#what-to-bring-your-printed-code)
- [How to practice](#how-to-practice)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The timed builds](#the-timed-builds)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How the BPA 335 C++ event runs and how it is scored
- How to spend 90 minutes so you finish with a program that runs
- How to build a skeleton menu first and fill it in one option at a time
- What graders check in the source code review
- How to practice and grade yourself

---

## How the BPA C++ event works

- **One program, 90 minutes.** You read a printed test and build a console program on your own computer.
- **Your computer, your IDE.** Allowed IDEs: Visual Studio 2022, Visual Studio Code, Dev-C++, Code::Blocks. Use what you practiced with (Visual Studio 2022 in these lessons).
- **Printed materials allowed.** Printed reference guides and printed code. Nothing electronic: no internet, no AI, no online compilers, no old BPA tests.
- **Contestant ID, never your name.** Your contestant ID goes in a comment at the top of the code and in the folder name. Your name and school must not appear anywhere.
- **Exact names.** The test tells you the file name (2026: `Regional_MenuProject.cpp`) and the function names (2026: `readCSV`, `randomPassword`, `reverseSentence`, `simpleCalculator`, `exitProgram`). Use them **exactly**, including capital letters.
- **Relative paths.** "The flash drive letter may not be the same when the program is graded... Use relative file paths, not absolute file paths."
- **Submit the whole project.** Copy the entire project folder, **including the `.exe`** and any data files, into a folder named with your contestant ID on the flash drive. "Submissions that do not contain source code will not be graded."

---

## How it is scored

There are three parts. The exact points change each year, but the shape does not.

| Part | What it means | 2026 example |
|---|---|---|
| Solution and project | Files named correctly, in the right folder, with your ID | 10 points |
| **Program execution** | The grader runs your program and tries every option, including bad input | 260 points |
| **Source code review** | The grader reads your code: comments, functions, validation, data structures, exception handling, classes | 280 points |

**The most important rule: if the program does not run, the execution section scores zero.** In 2026 that would be 260 of 540 points gone at once. A program that runs with 3 of 5 options working beats a program with 5 options that does not build.

Look at how the 2026 points were split: comments alone were worth 50, and "main menu is validated" was 40. Comments and validation are cheap points. Don't skip them.

---

## A plan for the 90 minutes

| Time | What to do |
|---|---|
| **0-10 min** | **Read everything.** Read the whole test before you type. Underline every exact name, prompt, message, and file name. Note the point values: they tell you what matters. |
| **10-25 min** | **Build the skeleton** (next section). Header comment, includes, your printed input functions, the menu loop, and an empty function for every option. Build and run it. It should show the menu and quit. |
| **25-75 min** | **Fill in options, easiest first.** Do the one you are surest of first. **Build and run after each option.** Comment as you go, not at the end. |
| **75-80 min** | **Bad-input pass.** Try letters, blanks, decimals, negatives, and out-of-range numbers on every prompt. Rename the data file and check the missing-file message. |
| **80-90 min** | **Finish and submit.** Check the header comment and I/P/O comments. Build one last time. Copy the whole project folder (with the `.exe` and data files) into the contestant-ID folder. Open the copy and make sure the `.exe` is there. |

If an option is not working with 15 minutes left, **comment it out** so the program builds, add a comment explaining what you were trying, and move on. A comment like `// Processing: sort by price (not finished)` can still earn some review points; a build error earns none.

---

## Build a working skeleton first

A **skeleton** is the whole program's structure with empty functions. It runs from the first 15 minutes, so you always have something to submit.

```cpp
// Contestant ID: 01-2345-6789
// Date: 2027-01-15
// Program: Practice Skeleton
// Description: Menu program skeleton - every option is an empty function for now.

#include <iostream>
#include <string>
#include <stdexcept>
using namespace std;

// Function prototypes
int getInt(string prompt, int low, int high);
void optionOne();
void optionTwo();
bool exitProgram();

// Purpose: starting point. Runs the menu until the user exits.
// Parameters: none
// Returns: 0 when the program ends normally
int main()
{
    bool done = false;
    while (!done)
    {
        // Output: the menu
        cout << endl;
        cout << "1. Option one" << endl;
        cout << "2. Option two" << endl;
        cout << "3. Exit" << endl;

        // Input: validated choice
        int choice = getInt("Choose an option (1-3): ", 1, 3);

        // Processing: run the option
        switch (choice)
        {
        case 1:
            optionOne();
            break;
        case 2:
            optionTwo();
            break;
        case 3:
            done = exitProgram();
            break;
        }
    }
    return 0;
}

// Purpose: option one (not written yet).  Parameters: none.  Returns: nothing.
void optionOne()
{
    cout << "Option one is not finished yet." << endl;
}

// Purpose: option two (not written yet).  Parameters: none.  Returns: nothing.
void optionTwo()
{
    cout << "Option two is not finished yet." << endl;
}

// Purpose: confirm exit.  Parameters: none.  Returns: true to end the program.
bool exitProgram()
{
    cout << "Goodbye!" << endl;
    return true;
}

// Purpose: read a whole number from low to high (from Step 10).
// Parameters: prompt - the question; low, high - the range.  Returns: the number.
int getInt(string prompt, int low, int high)
{
    while (true)
    {
        // Input: full line
        string answer;
        cout << prompt;
        getline(cin, answer);

        // Processing: this try/catch catches invalid_argument and out_of_range from stoi
        try
        {
            size_t used = 0;
            int value = stoi(answer, &used);
            if (used == answer.length() && value >= low && value <= high)
            {
                return value;
            }
        }
        catch (const invalid_argument&) {}
        catch (const out_of_range&) {}

        // Output: error, ask again
        cout << "Please enter a whole number from " << low << " to " << high << "." << endl;
    }
}
```

Sample run:
```

1. Option one
2. Option two
3. Exit
Choose an option (1-3): 1
Option one is not finished yet.

1. Option one
2. Option two
3. Exit
Choose an option (1-3): x
Please enter a whole number from 1 to 3.
Choose an option (1-3): 3
Goodbye!
```

This skeleton already earns menu points: it displays, repeats, and rejects bad input. Every option you finish after this adds points to a program that already runs.

The 2026 regional's `exitProgram` returned a `bool`, and the menu loop used it (`done = exitProgram();`). That is the pattern above, and it is also the pattern in Timed Build 01.

---

## What graders look for

Use this as a checklist while you build.

**Execution**
- [ ] It builds and runs from the submitted folder
- [ ] Menu looks like the test's figure and repeats until exit
- [ ] Every prompt and message matches the test's wording
- [ ] Every number prompt rejects letters, symbols, decimals, negatives, blanks, and out-of-range values without crashing
- [ ] Text prompts reject blank input when the test says so
- [ ] File options show an error message if the file is missing
- [ ] Tables are lined up in columns (`setw`, `left`)
- [ ] Money and averages show 2 decimal places

**Source code review**
- [ ] Contestant ID in a comment at the top
- [ ] **Input / Processing / Output comments** on every major block
- [ ] A comment block on every function: purpose, parameters, return value
- [ ] Every required function exists with the exact name, parameters, and return type
- [ ] No global variables (constants are fine)
- [ ] Data structures fit the job (`vector`, a class), with clear names
- [ ] Each `try`/`catch` has a comment saying what it catches
- [ ] Consistent camelCase naming, no copy-pasted blocks a loop or function could replace
- [ ] If the rubric uses source code flags (like `// #SC1` in Timed Build 02), each flag is in a comment right next to its code

---

## What to bring: your printed code

Printed code is allowed in the C++ event. That is a big advantage if you prepare. Print and bring:

1. **Your input functions** from Step 10: `trim`, `getText`, `getInt`, `getYesNo`, plus a `getDouble` (shown in the Step 10 lesson). They answer the "validate every input" requirement on every test.
2. **CSV reading and table printing** from Step 9: open, check for missing file, skip header, split with `stringstream`, print with `setw`.
3. **`currentDateTime()`** and the `#define _CRT_SECURE_NO_WARNINGS` line from Step 9.
4. **A class with a vector of objects, sorting a copy, and case-insensitive search** from Step 11.
5. **The random number setup** from Step 4 (`random_device`, `mt19937`, `uniform_int_distribution`).
6. **The skeleton menu** above.
7. **The 335 C++ reference guide.**

Organize them with tabs or headings so you can find each one in seconds. Practice using your printouts during timed builds, so you know where things are.

---

## How to practice

1. **Print** the problem, the rubric, and your reference code. Close the browser.
2. **Set a timer** for 90 minutes (40 for Timed Build 01). No Google, no AI, no asking classmates. Only your printouts.
3. **Build.** Follow the time plan.
4. **Stop when the timer ends**, even if you are not done. Push what you have.
5. **Grade yourself** with the rubric. Be honest. Write your score in your Classroom comment.
6. **Fix it afterward** (not timed) and keep the finished version as printed code for next time.

The teacher will hand out **printed past regional tests** for more practice. Do them the same way: timer, printouts only, grade yourself with the rubric printed in the test.

---

## Common mistakes

**1. Building everything before running anything**
- Result: 40 errors at minute 70 and no time to fix them.
- Fix: build and run after every option.

**2. Leaving comments until the end**
- Result: no time, and comments are worth a lot of points.
- Fix: write the I/P/O comment before you write the block.

**3. Wrong file or function names**
- Result: lost project points, and graders may not find your functions.
- Fix: copy names exactly from the test. Check capital letters.

**4. Data file in the wrong place**
- Result: "file not found" on the grader's computer, and the whole CSV option scores zero.
- Fix: data file in the project folder **and** next to the `.exe`. Relative path in the code.

**5. Submitting only the `.cpp` file**
- Result: BPA says "the project must include an executable program file."
- Fix: copy the whole project folder, including `x64\Debug\*.exe`.

**6. Your name in the code**
- Fix: contestant ID only. Check the header comment before you submit.

**7. Leftover testing code**
- Looks like: `cout << "(testing: secret is 42)"` still in the program.
- Fix: search your code for "test" before submitting.

---

## How this shows up at BPA

- The 2026 regional was a 5-option console menu in 90 minutes, worth 540 points, with each option its own named function and every input validated. The timed builds here have the same shape.
- The 2024 regional was two separate programs (Jobs) in the same 90 minutes, each reading a text file. Timed builds with file reading prepare you for that too.
- Every year: contestant ID comment, relative paths, I/P/O comments, required function names, and "if it doesn't run, execution scores zero."

---

## The timed builds

| Build | Time | What it practices | Files |
|---|---|---|---|
| [Timed Build 01: Mini Menu](timedBuild01_MiniMenu/timedBuild01.md) | 40 minutes | A 3-option menu like the 2026 regional: reverse a sentence, average 1-5 numbers, exit that returns a `bool`. Input validation and the `getline` trap. | Problem, starter, rubric |
| [Timed Build 02: Food Truck Sales](timedBuild02_FoodTruck/timedBuild02.md) | 90 minutes | A full 6-option menu: CSV file into a class and a `vector`, aligned table with a TOTAL row, validated sales entry, best sellers, case-insensitive search, saved report with a date. | Problem, starter, rubric, `sales.csv` |

Do Timed Build 01 after Step 10. Do Timed Build 02 after Step 11. Then move on to the printed past regional tests.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_timed01` (or `cpp_timed02`).
2. Put your `.cpp` file in it, plus any data file it reads. (Visual Studio: push the whole project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ timed build 1 done* (or 2), with your rubric score.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the problem's sample run and messages
- [ ] Header comment with name (contestant ID at BPA), date, program, description
- [ ] Input / Processing / Output comments
- [ ] Every input validated; nothing crashes on bad input
- [ ] Graded yourself with the rubric
- [ ] Pushed to `bpaPrep/cpp_timed01` or `bpaPrep/cpp_timed02`
