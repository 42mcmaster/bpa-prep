# Step 12 — Timed Builds (Java)

**What you'll build:** 90-minute practice builds in the same shape as the real BPA Java event.
**Time:** 90 minutes per build, plus 15-20 minutes to grade yourself with the rubric.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [How the BPA Java event works](#how-the-bpa-java-event-works)
- [How it is scored](#how-it-is-scored)
- [Java-specific rules to know cold](#java-specific-rules-to-know-cold)
- [A time plan for 90 minutes](#a-time-plan-for-90-minutes)
- [What graders look for](#what-graders-look-for)
- [Printed code to bring](#printed-code-to-bring)
- [How to practice](#how-to-practice)
- [The timed builds in this folder](#the-timed-builds-in-this-folder)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Timed Builds](#the-challenge-timed-builds)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How the 340 Java Programming event runs, from setup to submitting
- How the event is scored, and why a program that doesn't run scores zero for execution
- The Java test rules: exact prompts, exact variable names with your Contestant ID digits, `SC` comment flags, no `break` out of loops, close the Scanner
- A 90-minute plan you can follow under pressure
- How to practice and grade yourself

---

## How the BPA Java event works

- **One program, 90 minutes.** You get a printed test booklet that describes a program. You build it on your own computer.
- **Local IDE only.** IntelliJ, Eclipse, NetBeans, BlueJ, or VS Code. No online compilers, no internet, no AI.
- **Printed materials are allowed**, including printed code. Nothing electronic. **No old BPA tests.**
- **Contestant ID, never your name.** Put your Contestant ID in a comment at the top of the program. Your name and school must not appear anywhere.
- **One folder.** Make a folder on the flash drive named with your Contestant ID and put your **entire** solution in it. The test warns that advanced IDEs scatter files into several folders, and graders will **not** fix that. If you use VS Code with a single `.java` file (as in this course), this is easy.
- **Exact file name.** The test names the file (for example, the program "will be saved as `SomethingName.java`"). The class name must match it.
- **Relative paths.** If there is a data file, open it with just its name (`"data.csv"`). The flash drive letter may change when it is graded.
- **The graders will not edit or recompile your code to fix problems.** What you hand in is what gets run.

---

## How it is scored

Past Java regionals had three parts:

| Part | What it covers | Typical share |
|---|---|---|
| **Solution and Project** | File is on the flash drive, in one folder named with your Contestant ID | Small (about 5-10%) |
| **Program Execution** | Graders run it and check each requirement: prompts, calculations, output format, error messages | About half |
| **Source Code Review** | Graders read the code: comments, variable names, required structures (Scanner, Random, switch, while loops, methods, try/catch, class), Scanner closed | About 40% |

**If the program does not run, the rest of the Program Execution section scores zero.** A program that runs and does half the requirements beats a program that "almost" does everything but has one compile error. **Always keep a running version.**

Many source code review items are "no partial credit": the structure has to be there **and** work.

---

## Java-specific rules to know cold

These come straight from how past Java regionals were written.

**1. Exact prompts and exact output.** The tests say "use the exact prompts" and "produce the exact output." Copy every prompt character for character, including capital letters, punctuation, and the space at the end.

**2. Exact variable names with your Contestant ID digits.** The test lists variable names ending in `xx`, like:

```
String userNamexx
int totalPointsxx, roundCountxx
```

You replace `xx` with the **last 2 digits of your Contestant ID**. If your ID is `12345`, you write:

```java
String userName45;
int totalPoints45, roundCount45;
```

On the 2026 regional this was worth 30 points: full points for exact names with your digits, fewer points if you left the `xx`, fewer still if only some names matched. **Write the names exactly as given** - same spelling, same capitals - and add your digits. Only the listed variables need the digits; your own extra variables can be named normally.

**3. Comment flags (`SC1`, `SC2`, ...).** The 2024 Java regional listed numbered "Source Code Review" items and said each must have a comment flag next to it, like:

```java
//SC3 gathers the user's input
int count45 = getCount();
```

"If a comment flag is not present, you will not receive credit." When a test uses flags, read the rubric list and put each flag right above the code it describes. The 2026 regional used Input / Processing / Output comments instead. **Do both habits:** I/P/O comments on every block, and flags whenever the test asks for them.

**4. Loops end by their condition.** The 2026 regional gave points for "Neither while loop exits using a break statement." Use a `boolean` flag or a condition, as you did in Steps 4 and 10.

**5. Close the Scanner.** Worth points every time: `keyboard45.close();` at the end of `main`.

**6. Required structures by name.** If the test says "a switch statement," "2 while loops," "a Random object," "a DecimalFormat object," or "an if/else," graders look for exactly that. Use what the test asks for, even if you know another way.

`DecimalFormat` showed up on the 2024 regional. It is another way to format numbers:

```java
import java.text.DecimalFormat;

DecimalFormat money = new DecimalFormat("0.00");
System.out.println(money.format(3.14159));   // 3.14
System.out.println(money.format(2.5));       // 2.50
```

The pattern `"0.00"` means "at least one digit before the decimal point, exactly two after."

---

## A time plan for 90 minutes

| Time | What to do |
|---|---|
| **0:00-0:10** | **Read the whole booklet.** Highlight every exact prompt, exact output line, variable name, and file name. Read the scoring rubric at the end - it tells you what earns points. Write your Contestant ID digits at the top of the page. |
| **0:10-0:20** | **Set up and make a running skeleton.** Make the Contestant ID folder. Make the `.java` file with the exact name. Type the header comment with your ID, the `public class`, `main`, the imports, the Scanner. Type in your printed input methods (`getText`, `getInt`). **Run it.** Save it. |
| **0:20-0:30** | **Declare the required variables** with your digits, exactly as listed. Write the input prompts. Run it. |
| **0:30-1:10** | **Easiest requirements first.** Do the parts you are sure of, one at a time. After each one: run, compare to the sample, save. If a part is stuck for more than 5 minutes, leave a comment and move on. **Comment as you go** - Input / Processing / Output and any `SC` flags. |
| **1:10-1:20** | **Harder requirements and error handling.** Bad input messages, file errors, edge cases. |
| **1:20-1:30** | **Stop adding features.** Run the program start to finish. Compare every line to the sample run. Check the variable names, the ID comment, the Scanner close, the flags. Make sure the folder on the flash drive has the `.java` file (and any data file). **If something you just changed broke it, undo it.** |

**Save a running version often.** One easy way: when a part works, copy the file into a folder named `backup` *outside* your Contestant ID folder (or keep a copy in your notes). If you break something at 1:25, you can go back.

---

## What graders look for

Use this as a final check on every build.

**Project**
- [ ] Folder named with your Contestant ID, everything inside it
- [ ] File and class named exactly as the test says
- [ ] Contestant ID comment at the top (no name, no school)

**Execution**
- [ ] Runs with no errors from start to finish
- [ ] Every prompt matches exactly
- [ ] Every output line matches the sample (spacing, punctuation, decimals)
- [ ] Bad input gives the right message and asks again - no crash
- [ ] The program ends the way the test says (after the last item, on Quit, etc.)

**Source code review**
- [ ] Input / Processing / Output comments on every major block
- [ ] `SC` flags if the test asks for them, each right next to its code
- [ ] Required variable names, exactly, with your 2 digits
- [ ] Every method has a purpose / parameters / returns comment
- [ ] Required structures are present: Scanner, Random, switch, while loops, methods, try/catch, class - whatever the test lists
- [ ] Loops end by their condition (no `break` out of loops)
- [ ] Scanner closed
- [ ] Relative file paths

---

## Printed code to bring

Printed code is allowed. Bring short, tested pieces you can type in quickly:

- Your **header comment** and program skeleton (`public class`, `main`, imports, class-level Scanner).
- **`getText`, `getInt`, `getDouble`, `getYesNo`** from Step 10.
- **Random in a range:** `random.nextInt(high - low + 1) + low`.
- **File reading** with try-with-resources, skipping the header, `split(",")` (Step 9).
- **File writing** with `PrintWriter` / `FileWriter` and the date: `LocalDateTime.now().format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm"))` (Step 9).
- **A class** with private fields, constructor, getters (Step 11).
- **A menu loop** with `switch` (Step 11).
- **printf patterns:** `%-10s`, `%5d`, `%.2f`, `%%`, `%n` (Steps 2 and 8).
- **Selection sort** on parallel arrays (Step 8) and sorting a list of objects (Step 11).
- The [340 Java Competition Reference](../340_Java_Competition_Reference.md).

Put everything in one binder with tabs. During the event you won't have time to search through loose pages.

---

## How to practice

1. **Print** the reference guide and your code pages. Close the browser. No AI, no internet.
2. **Read** the problem file all the way through before typing.
3. **Set a timer for 90 minutes** and start.
4. When time is up, **stop typing**. Whatever you have is what gets graded.
5. **Grade yourself** with the rubric in the build's folder. Be honest.
6. Write down the one or two things that cost you the most points. Practice those before the next build.

Your teacher will also hand out **printed** past regional tests for extra practice. Those are paper only - they can't go in the repo, and you can't bring them to the event.

---

## The timed builds in this folder

| Build | Folder | What it practices | Turn-in folder |
|---|---|---|---|
| Timed Build 1 — Rock Paper Scissors Match | [timedBuild01_RockPaperScissors](timedBuild01_RockPaperScissors/timedBuild01.md) | The Java regional format: exact prompts, exact variable names with your ID digits, `SC` flags, Scanner, Random, switch, two while loops, no break | `java_timed01` |
| Timed Build 2 — Food Truck Sales | [timedBuild02_FoodTruck](timedBuild02_FoodTruck/timedBuild02.md) | A full menu program: a class, a CSV file, validated input, a formatted table, a dated report. Same build in all four languages. | `java_timed02` |

Do them in order. Timed Build 1 is shorter and focuses on the strict Java rules. Timed Build 2 uses everything from Steps 1-11.

---

## Common mistakes

**1. Building everything before running anything**
- Result: at 1:20 there are 15 compile errors and no time to fix them. Execution scores zero.
- Fix: run after every small piece.

**2. Leaving `xx` in the variable names**
- Result: lost points on the variable names item.
- Fix: replace `xx` with your 2 digits as you declare each variable.

**3. Prompt is close but not exact**
- Looks like: `Enter your name:` instead of `What is your name: `.
- Fix: copy the prompt from the booklet character by character.

**4. Forgetting a flag or a comment**
- Result: "No flag, no credit," even when the code is right.
- Fix: put the flag in when you write the code, not at the end.

**5. Folder problems**
- Looks like: the `.java` file is on the desktop, not in the Contestant ID folder on the flash drive.
- Fix: work **in** the folder from the start, or copy it there and open it to check before time is up.

---

## How this shows up at BPA

- The 2026 Java regional (515 points) gave 30 points for exact variable names with ID digits, 50 points for commenting, and about half the points for execution.
- The 2024 Java regional (390 points) had 11 flagged source code review items (`SC1`-`SC11`) and "no partial credit."
- Both tests used a Scanner with exact prompts, `while` loops, a `Random` object, and required structures named in the booklet.

---

## The challenge: Timed Builds

Do each timed build in the table above under real conditions: 90 minutes, printed materials only, then grade yourself with its rubric.

Each build folder has:
- `timedBuildNN.md` - the instructions (start here)
- a **Problem** file - the full specification
- a **starter** `.java` file - already named correctly, so it compiles and runs
- a **Rubric** - 100 points, how it is graded
- data files if the build needs them

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_timed01` (or `java_timed02`).
2. Put your `.java` file in it, plus any data and report files the build uses.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java timed build 1 done* (or *2*).

---

## Checklist
- [ ] Built in 90 minutes with printed materials only
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name (Contestant ID at BPA), date, program, description
- [ ] Input / Processing / Output comments
- [ ] `SC` flags on the parts the rubric lists
- [ ] Graded myself with the rubric
- [ ] Pushed to `bpaPrep/java_timed01` or `bpaPrep/java_timed02`
