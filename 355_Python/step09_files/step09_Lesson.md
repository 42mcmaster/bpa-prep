# Step 09 — Files (Python)

**What you'll build:** Scoreboard From a File — read player scores from `scores.csv`, print the Step 8 leaderboard and analysis, and save them to `report.txt` with the date and time.
**Time:** about one to two class periods.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Text files and CSV files](#text-files-and-csv-files)
- [Where Python looks for a file](#where-python-looks-for-a-file)
- [Opening a file with with](#opening-a-file-with-with)
- [Reading a file line by line](#reading-a-file-line-by-line)
- [Skipping the header and splitting on commas](#skipping-the-header-and-splitting-on-commas)
- [Returning two values from a function](#returning-two-values-from-a-function)
- [When the file is missing](#when-the-file-is-missing)
- [Writing a file](#writing-a-file)
- [One function for the screen and the file](#one-function-for-the-screen-and-the-file)
- [The current date and time](#the-current-date-and-time)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Scoreboard From a File](#the-challenge-scoreboard-from-a-file)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What a CSV file is
- Where Python looks for a file when you use a **relative path**, in IDLE and in VS Code
- How to open, read, and close a file safely with `with`
- How to read a file one line at a time, skip the header line, and split each line on commas
- How a function can return two values
- How to handle a missing file without crashing (a first look at `try`/`except`)
- How to write lines to a text file
- How to make one print function that can print to the screen **or** to a file
- How to get the current date and time and format it as `yyyy-MM-dd HH:mm`

## Text files and CSV files

A **text file** is plain characters — you can open it in Notepad. A **CSV file** ("comma-separated values") is a text file that holds a table: one row per line, with commas between the columns. The first line is usually a **header** that names the columns.

For the examples in this lesson, make this file. In IDLE click **File > New File**, type the four lines, and **Save As** `inventory.csv` in the same folder as your example program. (Notepad works too.)

```
Item,Count
Pens,40
Markers,12
Folders,25
```

Spreadsheet programs like Excel and Google Sheets can open and save CSV files too.

## Where Python looks for a file

When your code says `open("inventory.csv")`, that's a **relative path** — just a file name, with no drive or folders. Python looks for it in the **working directory** (the "current folder").

| How you run it | The working directory is... | What to do |
|---|---|---|
| **IDLE, F5** | the folder the `.py` file is saved in | Put the data file in the same folder as your `.py` file. That's it. |
| **VS Code, Run button** | the folder you opened in VS Code (File > Open Folder) | Open the **step folder itself** in VS Code, with the `.py` and the data file inside it. |
| **Command line** (`python step09.py`) | the folder the terminal is in | `cd` to the step folder first. |

**Never use a full path** like `C:\Users\jordan\Desktop\scores.csv`. It works only on your computer. BPA says it plainly: "Use relative file paths only — the flash drive letter may change." Graders run your program from their own folder.

You can check whether a file is there before opening it:

```python
import os

# Processing: os.path.exists gives True or False
if os.path.exists("inventory.csv"):
    print("Found it.")
else:
    print("Not here.")
```

It prints (with `inventory.csv` in the folder):

```text
Found it.
```

## Opening a file with with

`open(file_name, mode)` opens a file. The **mode** says what you want to do:

| Mode | Means | If the file doesn't exist... | If it does exist... |
|---|---|---|---|
| `"r"` | read (the default) | crash: `FileNotFoundError` | read from the start |
| `"w"` | write | create it | **erase it** and start over |
| `"a"` | append (add to the end) | create it | keep it, add to the end |

Every opened file must be **closed** when you're done, or what you wrote might not be saved. The safe way is `with`:

```python
# Input: "with" opens the file and closes it automatically at the end of the block
with open("inventory.csv", "r") as data_file:
    first_line = data_file.readline()
print(first_line)
```

It prints:

```text
Item,Count

```

| Part | What it means |
|---|---|
| `with open(...) as data_file:` | Open the file and call it `data_file` inside the block. |
| the indented block | Use the file here. |
| the end of the block | Python **closes the file for you**, even if an error happens inside. |

(Why the blank line in that output? `readline()` keeps the new-line character at the end of the line, and then `print` adds another one. You'll remove it with `strip()` in a moment.)

Without `with`, you have to remember to close it yourself:

```python
data_file = open("inventory.csv", "r")
first_line = data_file.readline()
data_file.close()           # don't forget!
print(first_line.strip())
```

It prints:

```text
Item,Count
```

BPA's 2026 rules say "Close all files properly." `with` does that every time, so use it.

## Reading a file line by line

A `for` loop over an open file gives you one line at a time, as a string:

```python
# Input and Output: print every line, cleaned up
with open("inventory.csv", "r") as data_file:
    for line in data_file:
        line = line.strip()     # remove the new-line character (and spaces) at the ends
        print(line)
```

It prints:

```text
Item,Count
Pens,40
Markers,12
Folders,25
```

Other ways to read:

| What you type | Gives you |
|---|---|
| `data_file.readline()` | the next line (one string, with `\n` at the end) |
| `data_file.readlines()` | a list of all the remaining lines |
| `data_file.read()` | the whole file as one big string |
| `for line in data_file:` | each line in turn — the most common way |

## Skipping the header and splitting on commas

The header line (`Item,Count`) isn't data. Read it once with `readline()` before the loop and don't use it. The `for` loop then starts on the **next** line.

Then each data line is split into parts with `split(",")` (from Step 7). Each part is a **string**, so numbers must be converted with `int()` or `float()`.

```python
items = []
counts = []
# Input: read the file into two parallel lists
with open("inventory.csv", "r") as data_file:
    data_file.readline()                # skip the header line
    for line in data_file:
        line = line.strip()
        if line == "":
            continue                    # ignore a blank line at the end
        # Processing: "Pens,40" -> ["Pens", "40"]
        parts = line.split(",")
        items.append(parts[0])
        counts.append(int(parts[1]))    # text -> number

# Output
print(items)
print(counts)
```

It prints:

```text
['Pens', 'Markers', 'Folders']
[40, 12, 25]
```

When a line has more than one number (like `Avery,88,92,79`), `parts[1:]` is a slice (Step 7) of all the parts after the name: `["88", "92", "79"]`. Loop over it and convert each one to build a row for your list of lists (Step 8).

**Try it**
1. Read `inventory.csv` and print the total count of all items.
2. Add a line `Staplers,8` to the file. Run your program again without changing the code — it should handle the extra line.

## Returning two values from a function

A reading function usually needs to give back **two** lists (names and numbers). Python lets a function return more than one value, separated by commas. The caller catches them in the same order:

```python
def read_inventory(file_name):
    """Purpose: read an inventory CSV into two parallel lists.
    Parameters: file_name (str) - the CSV file to read
    Returns: two lists - item names (list of str) and counts (list of int)
    """
    items = []
    counts = []
    with open(file_name, "r") as data_file:
        data_file.readline()
        for line in data_file:
            parts = line.strip().split(",")
            items.append(parts[0])
            counts.append(int(parts[1]))
    return items, counts        # two values

# The two returned values land in two variables, in order
item_list, count_list = read_inventory("inventory.csv")
print(item_list[1], count_list[1])
```

It prints:

```text
Markers 12
```

## When the file is missing

Opening a missing file for reading crashes:

```
Traceback (most recent call last):
  File "C:\bpaPrep\python_step09\step09.py", line 12, in <module>
    with open("scores.csv", "r") as data_file:
FileNotFoundError: [Errno 2] No such file or directory: 'scores.csv'
```

To handle it, wrap the code that might fail in `try`, and say what to do in `except`:

```python
# Input: try to read the file; handle it if it isn't there
try:
    with open("missing_file.csv", "r") as data_file:
        print(data_file.readline())
except FileNotFoundError:
    print("Error: could not find missing_file.csv")

print("The program keeps going.")
```

It prints:

```text
Error: could not find missing_file.csv
The program keeps going.
```

How it works: Python runs the `try` block. If a `FileNotFoundError` happens anywhere in it, Python jumps straight to the `except` block instead of crashing. If nothing goes wrong, the `except` block is skipped. **Step 10** covers `try`/`except` fully. For now, this one pattern is all you need.

To **end the program** when the file is missing, put the read in `main()` and use `return` in the `except` block — `return` leaves `main`, and the program is over.

## Writing a file

Open with `"w"` and use `.write()`. Unlike `print`, **`write` does not add a new line** — put `\n` at the end of each line yourself.

```python
# Output: write three lines to a new file
with open("restock.txt", "w") as out_file:
    out_file.write("RESTOCK LIST\n")
    out_file.write("Markers: 12\n")
    out_file.write("Order more markers.\n")

# Input: read it back to check
with open("restock.txt", "r") as check_file:
    print(check_file.read(), end="")
```

It prints:

```text
RESTOCK LIST
Markers: 12
Order more markers.
```

The file shows up in the same folder as the program (the working directory). `"w"` erases the file first, so running it twice doesn't double the lines. To **add** to a file instead, use `"a"`.

## One function for the screen and the file

`print` can send its output to a file instead of the screen. Add `file=` and the open file:

```python
with open("note.txt", "w") as out_file:
    print("This line goes into the file.", file=out_file)    # adds the \n for you
```

That gives a neat trick. If you call `print(..., file=None)`, the output goes to the **screen** (`None` means "the normal place"). So you can give a print function an extra parameter that **defaults** to `None`:

```python
def print_inventory(items, counts, out_file=None):
    """Purpose: print the inventory table.
    Parameters: items (list of str), counts (list of int)
                out_file - an open file to write to; None (the default) means the screen
    Returns: nothing
    """
    # Output: every print sends its line to out_file
    print(f"{'Item':<10}Count", file=out_file)
    for i in range(len(items)):
        print(f"{items[i]:<10}{counts[i]}", file=out_file)

items = ["Pens", "Markers"]
counts = [40, 12]

print_inventory(items, counts)                 # no third argument -> the screen

with open("inventory_report.txt", "w") as report:
    print_inventory(items, counts, report)     # same function -> the file

with open("inventory_report.txt", "r") as check:
    print(check.read(), end="")
```

It prints (the table twice: once printed straight to the screen, once read back from the file):

```text
Item      Count
Pens      40
Markers   12
Item      Count
Pens      40
Markers   12
```

`out_file=None` in the `def` line is a **default value**: if the caller leaves that argument out, the parameter gets `None`. This is how you'll reuse your Step 8 `print_table` and `print_analysis` for `report.txt` — add `out_file=None` as the last parameter and `file=out_file` to every `print` inside. No copy-pasting the table code.

## The current date and time

The `datetime` module gives the current date and time. `strftime` ("string format time") turns it into text in the layout you want.

```python
import datetime

# Processing: get "now" and format it like 2026-11-02 08:15
now = datetime.datetime.now()
stamp = now.strftime("%Y-%m-%d %H:%M")

# Output
print("Report created: " + stamp)
```

Example output (yours shows the real date and time):

```
Report created: 2026-11-02 08:15
```

| Code | Means | Example |
|---|---|---|
| `%Y` | 4-digit year | `2026` |
| `%m` | 2-digit month | `11` |
| `%d` | 2-digit day | `02` |
| `%H` | hour, 24-hour clock | `08`, `14` |
| `%M` | minutes (capital M) | `15` |
| `%I` / `%p` | hour on a 12-hour clock / AM or PM | `02` / `PM` |

`datetime.datetime.now()` has "datetime" twice: the first is the **module**, the second is a **type** inside it with the same name. Small `%m` is month; capital `%M` is minutes. Mixing them up is a very common bug.

## Common mistakes

**1. File not found even though it's "right there"**
`FileNotFoundError: [Errno 2] No such file or directory: 'scores.csv'`
Causes: the CSV isn't in the same folder as the `.py`; in VS Code the wrong folder is open; the file is really named `scores.csv.txt` (Windows hides extensions — turn on **View > File name extensions** in File Explorer); or the name is spelled differently.

**2. Forgetting to skip the header**
`ValueError: invalid literal for int() with base 10: 'Round1'` — the program tried to convert the header. Fix: `data_file.readline()` before the loop.

**3. Forgetting `strip()`**
The last number on each line comes with `\n` on it. `int("79\n")` happens to work, but text comparisons and printing don't (extra blank lines). Always `strip()` each line.

**4. `write` with no new lines**
Everything ends up on one long line. Fix: add `\n` to each `write`, or use `print(..., file=...)`.

**5. Forgetting to convert numbers**
`parts[1]` is the string `"88"`. Adding two of them gives `"8892"`. Fix: `int(parts[1])`.

**6. Full paths**
`open("C:\\Users\\jordan\\Desktop\\scores.csv")` works for you and fails for the grader. Use `"scores.csv"`.

**7. `%m` vs `%M`**
`strftime("%Y-%M-%d")` prints minutes where the month should be. Month is small `%m`.

## How this shows up at BPA
- 2026 regional, Requirement 5: save results in a file named exactly `tournament_results.txt`, include the date and time "using the datetime module," and "ensure all file handling (open/write/close) is correct."
- Other BPA tests (C++ 2026) ask you to read a CSV and display it as a table, with error handling for a missing file. Python can get the same kind of task.
- "Close all files properly" is in the development standards. `with` covers it.
- Relative paths: "the flash drive letter may change." Graders run your program from a different folder than you did.
- The output file must be named **exactly** what the test says. A different name means the grader can't find it.

## The challenge: Scoreboard From a File

Read the scores from a file instead of the keyboard, print the leaderboard, and save a report.

**Data file:** `scores.csv` is in this step folder ([scores.csv](scores.csv)). Copy it into your `python_step09` folder, next to `step09.py`. Its contents:
```
Name,Round1,Round2,Round3
Avery,88,92,79
Blake,95,67,84
Casey,72,85,90
Devon,100,94,98
Emery,65,70,58
```

**Requirements**
1. Header comment.
2. Read `scores.csv` from the same folder as the program (relative path). Skip the header line. Store names and scores like Step 8.
3. If the file is missing, print `Error: could not find scores.csv` and end the program without crashing.
4. Print `Read 5 players from scores.csv` (the real count), a blank line, then the same leaderboard table and analysis as Step 8.
5. Write the same table and analysis to `report.txt`, with two lines at the top: `CLASS SCOREBOARD REPORT` and `Report created: <date and time>` (format `yyyy-MM-dd HH:mm`).
6. Print `Report saved to report.txt` at the end.
7. Reuse your Step 8 functions (copy them in). Function comments and Input / Processing / Output comments.

**Sample run (exact)**
```
Read 5 players from scores.csv

Name      R1   R2   R3   Total  Average
---------------------------------------
Devon     100  94   98   292    97.33
Avery     88   92   79   259    86.33
Casey     72   85   90   247    82.33
Blake     95   67   84   246    82.00
Emery     65   70   58   193    64.33

Winner: Devon (292 points)
Best single round: Devon, round 1 (100)
Highest scoring round: Round 1 (average 84.00)
Report saved to report.txt
```

**`report.txt` (exact except the date and time)**
```
CLASS SCOREBOARD REPORT
Report created: 2026-11-02 08:15

Name      R1   R2   R3   Total  Average
---------------------------------------
Devon     100  94   98   292    97.33
Avery     88   92   79   259    86.33
Casey     72   85   90   247    82.33
Blake     95   67   84   246    82.00
Emery     65   70   58   193    64.33

Winner: Devon (292 points)
Best single round: Devon, round 1 (100)
Highest scoring round: Round 1 (average 84.00)
```
Check: R1 average = (88+95+72+100+65)/5 = 84.00; R2 = (92+67+85+94+70)/5 = 81.60; R3 = (79+84+90+98+58)/5 = 81.80.

**Hints**
- Copy in `calculate_total`, `sort_by_total`, `print_table`, and `print_analysis` from Step 8. You won't need the input functions.
- Write `read_scores(file_name)` that returns `names, scores`.
- Add `out_file=None` to `print_table` and `print_analysis` (see [One function for the screen and the file](#one-function-for-the-screen-and-the-file)). Then `save_report` opens `report.txt` and calls them with the open file.
- Test the missing-file case: rename `scores.csv` to `scores_old.csv`, run, check the message, rename it back.

## Turn it in
1. In your `bpaPrep` repo make a folder `python_step09`.
2. Put `step09.py`, `scores.csv`, and the `report.txt` your program made in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 9 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] `report.txt` matches (except the date and time)
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Relative path `"scores.csv"`; files opened with `with`
- [ ] Missing file prints the error and ends without a red traceback
- [ ] Date and time in `yyyy-MM-dd HH:mm` format
- [ ] Every function has a Purpose / Parameters / Returns comment
- [ ] Pushed to `bpaPrep/python_step09`
