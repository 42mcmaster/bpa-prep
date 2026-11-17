# Step 09 Practice — Files (Python)

**Do these after the [Step 9 lesson](step09_Lesson.md).** Each problem is short and uses one idea from the lesson.

**Time:** about one class period for Problems 1–11. The Challenge at the end takes longer.

**Need help?** Use the [Step 9 Study Guide](step09_StudyGuide.md). Every problem lists the study guide section that shows how.

Problems marked **(review)** use skills from earlier steps, so you keep practicing them.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: Print a file](#problem-1-print-a-file)
- [Problem 2: Count the lines](#problem-2-count-the-lines)
- [Problem 3: Numbered roster](#problem-3-numbered-roster)
- [Problem 4: Read a CSV file](#problem-4-read-a-csv-file)
- [Problem 5: Total from a file](#problem-5-total-from-a-file)
- [Problem 6: Hottest day](#problem-6-hottest-day)
- [Problem 7: Write a file](#problem-7-write-a-file)
- [Problem 8: Save names from input](#problem-8-save-names-from-input)
- [Problem 9: Add to a file](#problem-9-add-to-a-file)
- [Problem 10: Missing file](#problem-10-missing-file)
- [Problem 11: Read lines with a function](#problem-11-read-lines-with-a-function)
- [Challenge: Quiz Report From a File](#challenge-quiz-report-from-a-file)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step09_p01.py`, `step09_p02.py`, and so on.
2. Copy the data files from this step folder (`team.txt`, `prices.csv`, `temps.csv`, `quiz_scores.csv`) into your `python_step09` folder, **next to** your programs.
3. Start each file with a header comment (name, date, program name).
4. Use just the file name (a relative path), never a full path like `C:\Users\...`.
5. Use the **exact** output shown. Same words, same spaces.

---

## Problem 1: Print a file
The file `team.txt` (in this step folder) has one name per line. Print every line.

**Sample run**
```
Avery
Blake
Casey
Devon
Emery
```

**Hints**
- Copy `team.txt` into your `python_step09` folder first.
- Use `.strip()`, or you'll get blank lines in between.

**Study guide:** [Reading a file line by line](step09_StudyGuide.md#reading-a-file-line-by-line)

---

## Problem 2: Count the lines
Read `team.txt` and count how many names are in it.

**Sample run**
```
team.txt has 5 names.
```

**Hint:** A counter from Step 4: add 1 for each line.

**Study guide:** [Reading a file line by line](step09_StudyGuide.md#reading-a-file-line-by-line)

---

## Problem 3: Numbered roster
Read `team.txt` and print each name with a number in front, starting at 1.

**Sample run**
```
1. Avery
2. Blake
3. Casey
4. Devon
5. Emery
```

**Hint:** Keep your own counter, starting at 1.

**Study guide:** [Reading a file line by line](step09_StudyGuide.md#reading-a-file-line-by-line)

---

## Problem 4: Read a CSV file
The file `prices.csv` has a header line, then one item and price per line. Skip the header and print each item and price.

**Sample run**
```
Notebook: $1.99
Pencils: $0.25
Binder: $3.49
Highlighter: $1.15
```

**Hints**
- `data_file.readline()` reads the header so the loop starts at the data.
- `split(",")` gives a list: the item is `[0]` and the price is `[1]`.
- The price is a string. Use `float()`.

**Study guide:** [Skipping the header and splitting on commas](step09_StudyGuide.md#skipping-the-header-and-splitting-on-commas)

---

## Problem 5: Total from a file
*(review: Step 4 running totals)*

Read `prices.csv` and print the total of all the prices and how many items there are.

**Sample run**
```
4 items cost $6.88
```

**Hint:** Running total and counter, inside the reading loop.

**Study guide:** [Skipping the header and splitting on commas](step09_StudyGuide.md#skipping-the-header-and-splitting-on-commas)

---

## Problem 6: Hottest day
*(review: Step 8 parallel lists)*

The file `temps.csv` has a day and its high temperature on each line. Read it into two parallel lists, then print the hottest day.

**Sample run**
```
Hottest day: Thursday (72 degrees)
```

**Hint:** First read the file into the lists. Then, after the `with` block, find the highest like Step 6.

**Study guide:** [Skipping the header and splitting on commas](step09_StudyGuide.md#skipping-the-header-and-splitting-on-commas)

---

## Problem 7: Write a file
Write three goals to a file named `goals.txt`, one per line. Then read the file back and print it.

**Sample run**
```
Finish the Step 9 practice
Pass the IC3 exam
Place at BPA regionals
```

**`goals.txt` after the run**
```
Finish the Step 9 practice
Pass the IC3 exam
Place at BPA regionals
```

**Hint:** `"w"` makes the file. `print(..., file=out_file)` writes one line.

**Study guide:** [Writing a file](step09_StudyGuide.md#writing-a-file)

---

## Problem 8: Save names from input
Ask for three names and save them to `roster.txt`, one per line. Then print how many names were saved.

**Sample run**
```
Name: Avery
Name: Blake
Name: Casey
Saved 3 names to roster.txt
```

**`roster.txt` after the run**
```
Avery
Blake
Casey
```

**Hint:** The `for` loop can go inside the `with` block, so the file stays open while you write.

**Study guide:** [Writing a file](step09_StudyGuide.md#writing-a-file)

---

## Problem 9: Add to a file
Write `Day 1: 20 minutes` to `practice_log.txt`. Then open it again with `"a"` (append) and add `Day 2: 35 minutes`. Read the file back and print it.

**Sample run**
```
Day 1: 20 minutes
Day 2: 35 minutes
```

**`practice_log.txt` after the run**
```
Day 1: 20 minutes
Day 2: 35 minutes
```

**Hint:** `"a"` adds to the end. `"w"` would erase Day 1.

**Study guide:** [Writing a file](step09_StudyGuide.md#writing-a-file)

---

## Problem 10: Missing file
Try to read `scores_2025.csv`, which doesn't exist. Print a message instead of crashing.

**Sample run**
```
Error: scores_2025.csv was not found.
```

**Hint:** Put the `with` block inside `try:`. The message goes in `except FileNotFoundError:`.

**Study guide:** [When the file is missing](step09_StudyGuide.md#when-the-file-is-missing)

---

## Problem 11: Read lines with a function
*(review: Step 5 functions and Step 6 lists)*

Write a function `read_names(file_name)` that reads a file and returns a list of the lines, stripped. Call it with `team.txt` and print the list and its length.

**Sample run**
```
['Avery', 'Blake', 'Casey', 'Devon', 'Emery']
5 names
```

**Hint:** The file name is a parameter, so the same function could read any file.

**Study guide:** [Returning two values from a function](step09_StudyGuide.md#returning-two-values-from-a-function)

---

## Challenge: Quiz Report From a File
This one puts the pieces together: reading a CSV file into parallel lists, a total and highest, a missing-file check, and writing a report file.

**Requirements**
1. Header comment, Input / Processing / Output comments, and a `main()` function.
2. Named constants: `FILE_NAME = "quiz_scores.csv"`, `REPORT_NAME = "quiz_report.txt"`, `PASSING = 70`.
3. Write `read_scores(file_name)`: skip the header, and return a list of names and a list of scores.
4. Write `print_report(names, scores, out_file=None)`: print each name, score, and `PASS` or `FAIL`, then the average and the highest. Widths: name 8 left; score 4 right; then 2 spaces and the result.
5. In `main()`, if the file is missing, print `Error: quiz_scores.csv was not found.` and stop.
6. Print the report on the screen, then call `print_report` again to write the same report to `quiz_report.txt`.

**Sample run**
```
Read 5 scores from quiz_scores.csv

Avery     88  PASS
Blake     64  FAIL
Casey     92  PASS
Devon     71  PASS
Emery     58  FAIL
Average: 74.6
Highest: Casey (92)

Report saved to quiz_report.txt
```

**`quiz_report.txt` after the run**
```
Avery     88  PASS
Blake     64  FAIL
Casey     92  PASS
Devon     71  PASS
Emery     58  FAIL
Average: 74.6
Highest: Casey (92)
```

**Test this too:** rename `quiz_scores.csv` and run it. You should see the error message, not a crash.

**Hints**
- A function can return two values: `return names, scores`, then `names, scores = read_scores(FILE_NAME)`.
- With `out_file=None`, `print(..., file=None)` prints to the screen. Pass the open file to write to the file instead.
- `return` inside `main()` ends the program early when the file is missing.

**Study guide:** [One function for the screen and the file](step09_StudyGuide.md#one-function-for-the-screen-and-the-file)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step09` folder.
2. Save the problems as `step09_p01.py` through `step09_p11.py`, and the challenge as `step09_challenge.py`. Include the data files and any files your programs make.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step09`
