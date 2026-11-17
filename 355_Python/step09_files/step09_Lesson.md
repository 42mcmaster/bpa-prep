# Step 09 — Files (Python)

So far, everything a program knows is gone when it ends. **Files** let a program read data that's already saved, and save results for later. This lesson teaches files one piece at a time. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 9 Practice](step09_Practice.md) problems. For more examples, use the [Step 9 Study Guide](step09_StudyGuide.md).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: Text files and CSV files](#part-1-text-files-and-csv-files)
- [Part 2: Where Python looks for the file](#part-2-where-python-looks-for-the-file)
- [Part 3: Reading a file line by line](#part-3-reading-a-file-line-by-line)
- [Part 4: Skipping the header and splitting on commas](#part-4-skipping-the-header-and-splitting-on-commas)
- [Part 5: Writing a file](#part-5-writing-a-file)
- [Part 6: When the file is missing](#part-6-when-the-file-is-missing)
- [Part 7: The date and time](#part-7-the-date-and-time)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- What text files and CSV files are
- Why the file has to be in the same folder as your program
- How to read a file one line at a time
- How to split each line of a CSV file into its parts
- How to write a new file
- What to do when the file isn't there
- How to print the date and time

---

## Part 1: Text files and CSV files

A **text file** is plain characters. You can open it in Notepad. A **CSV file** ("comma-separated values") is a text file that holds a table: one row per line, with commas between the columns. The first line is usually a **header** that names the columns.

The examples use `inventory.csv`, which is in this step folder. It looks like this:

```
Item,Count
Pens,40
Markers,12
Folders,25
```

Copy it into your `python_step09` folder, next to your program.

---

## Part 2: Where Python looks for the file

When your code says `open("inventory.csv")`, Python looks for the file in the **same folder as your program**. Just the file name, with no drive or folders, is called a **relative path**.

**Never use a full path** like `C:\Users\jordan\Desktop\inventory.csv`. It only works on your computer. BPA says to use relative paths only, because the grader runs your program from their own folder.

---

## Part 3: Reading a file line by line

```python
with open("inventory.csv", "r") as data_file:   # "r" means read
    for line in data_file:                      # one line at a time
        print(line.strip())                     # strip() removes the line break at the end
```

```text
Item,Count
Pens,40
Markers,12
Folders,25
```

- `with open(...) as data_file:` opens the file. When the indented block ends, Python closes the file for you.
- Each `line` still has an invisible line break at the end. `.strip()` removes it. Without it, you get blank lines between the lines.

**Try it:** Count how many lines are in the file. (You should get 4.)

---

## Part 4: Skipping the header and splitting on commas

The header line isn't data, so skip it. Then `split(",")` (from Step 7) breaks each line into its parts. Put the parts into parallel lists (from Step 8).

```python
items = []
counts = []

with open("inventory.csv", "r") as data_file:
    data_file.readline()                    # read the header line and throw it away
    for line in data_file:
        parts = line.strip().split(",")     # "Pens,40" becomes ["Pens", "40"]
        items.append(parts[0])
        counts.append(int(parts[1]))        # text from a file is a string, so use int()

print(items)
print(counts)
```

```text
['Pens', 'Markers', 'Folders']
[40, 12, 25]
```

Everything read from a file is **text**. Use `int()` or `float()` on numbers, just like with `input()`.

**Try it:** After the loop, print the total of all the counts. (You should get 77.)

---

## Part 5: Writing a file

`"w"` means **write**. It makes a new file, or **replaces** the file if it's already there. Use `print(..., file=out_file)` to write a line.

```python
with open("restock.txt", "w") as out_file:      # "w" means write
    print("Restock list", file=out_file)
    print("Markers: order 20", file=out_file)

# Read it back to check
with open("restock.txt", "r") as check_file:
    for line in check_file:
        print(line.strip())
```

```text
Restock list
Markers: order 20
```

`file=out_file` sends the line to the file instead of the screen. Everything else about `print` works the same, including f-strings.

`"a"` means **append**: add to the end of the file instead of replacing it.

---

## Part 6: When the file is missing

Opening a file that isn't there crashes the program with `FileNotFoundError`. Use `try` and `except` to print a message instead. (Step 10 covers this in more detail.)

```python
try:
    with open("missing_file.csv", "r") as data_file:
        print(data_file.readline())
except FileNotFoundError:
    print("Error: could not find missing_file.csv")
```

```text
Error: could not find missing_file.csv
```

Python **tries** the code under `try`. If that error happens, it jumps to `except` and runs that code instead of crashing.

---

## Part 7: The date and time

BPA programs often put the date and time in a report file. Use the `datetime` module:

<!-- norun -->
```python
import datetime

now = datetime.datetime.now()
stamp = now.strftime("%Y-%m-%d %H:%M")
print("Report created: " + stamp)
```

It prints the real date and time, like:

```
Report created: 2026-11-18 09:30
```

`%Y` is the year, `%m` the month, `%d` the day, `%H` the hour (24-hour clock), and `%M` the minutes.

---

## Common mistakes

1. **The file isn't in the same folder as the program.** You get `FileNotFoundError`. Check the folder, and check the spelling.
2. **Using a full path** like `C:\Users\...`. Use just the file name.
3. **Forgetting `.strip()`.** You get blank lines, and the last item on each line has a line break stuck to it.
4. **Forgetting to skip the header.** `int("Count")` crashes.
5. **Forgetting `int()` or `float()`.** Numbers from a file are strings.
6. **Using `"w"` when you meant `"r"`.** `"w"` erases the file.

---

## Next steps
1. Do the [Step 9 Practice](step09_Practice.md) problems.
2. Keep the [Step 9 Study Guide](step09_StudyGuide.md) open while you work. Print it for BPA.
3. After the practice, try the [Step 9 builds](../bpaBuilds/build09_files.md).
