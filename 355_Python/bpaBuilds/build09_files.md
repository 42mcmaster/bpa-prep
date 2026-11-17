# Builds for Step 09 — Files (Python)

These are BPA-style programs that use the Step 9 skills together with everything before it. They are bigger than the practice problems, and closer to what the BPA test asks for.

**Do these after you finish the Step 9 lesson and practice.** Use the [Step 9 Study Guide](../step09_files/step09_StudyGuide.md) for help.

**Rules for every build in this file**
- Every task reads a data file. The data files are in this folder (`bpaBuilds`). Copy the one you need into your `python_builds` folder, **next to** your program. Use the file name only (a relative path), never a full path like `C:\Users\...`.
- If the data file is missing, print `Error: could not find <file name>` and end the program without crashing.
- Every function has a purpose / parameters / returns comment.
- End the file with `if __name__ == "__main__":` and `main()`.
- The date and time in your output files will be the real date and time when you run the program, so they won't match the samples exactly.

## Table of Contents
- [Build 9A: Scoreboard From a File](#build-9a-scoreboard-from-a-file)
- [Build 9B: Honor Roll Report](#build-9b-honor-roll-report)
- [Build 9C: Monthly Sales Report](#build-9c-monthly-sales-report)
- [Build 9D: Supply Reorder](#build-9d-supply-reorder)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Build 9A: Scoreboard From a File
Read the scores from a file instead of the keyboard, print the leaderboard, and save a report.

**Data file:** `scores.csv` is in this folder (`bpaBuilds`) ([scores.csv](scores.csv)). Copy it into your `python_builds` folder, next to `build09A.py`. Its contents:
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
4. Print `Read 5 players from scores.csv` (the real count), a blank line, then the same leaderboard table and analysis as Build 8A.
5. Write the same table and analysis to `report.txt`, with two lines at the top: `CLASS SCOREBOARD REPORT` and `Report created: <date and time>` (format `yyyy-MM-dd HH:mm`).
6. Print `Report saved to report.txt` at the end.
7. Reuse your Build 8A functions (copy them in). Function comments and Input / Processing / Output comments.

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
- Copy in `calculate_total`, `sort_by_total`, `print_table`, and `print_analysis` from Build 8A (Team Scoreboard). You won't need the input functions.
- Write `read_scores(file_name)` that returns `names, scores`.
- Add `out_file=None` to `print_table` and `print_analysis` (see [One function for the screen and the file](../step09_files/step09_StudyGuide.md#one-function-for-the-screen-and-the-file)). Then `save_report` opens `report.txt` and calls them with the open file.
- Test the missing-file case: rename `scores.csv` to `scores_old.csv`, run, check the message, rename it back.

---

## Build 9B: Honor Roll Report
Read a list of students from a file, print a table and stats, and save the honor roll to a text file.

**Data file:** [students.csv](students.csv)
```
Name,Grade,GPA
Avery,11,3.85
Blake,12,2.90
Casey,10,3.52
Devon,12,3.97
Emery,9,2.45
Finley,11,3.10
Harper,10,3.60
```

**Requirements**
1. Header comment. Constants: `FILE_NAME = "students.csv"`, `REPORT_NAME = "honor_roll.txt"`, `HONOR_GPA = 3.5`.
2. Write `read_students(file_name)` that skips the header line and returns **three** parallel lists: names, grades (int), and GPAs (float).
3. Print `Read 7 students from students.csv` (the real count), then a blank line.
4. Write `print_table(names, grades, gpas)`: Name 10 wide, Grade 7 wide, then GPA with 2 decimals. A line of 21 dashes under the header.
5. Print the average GPA (2 decimals), then how many students are in each grade from 9 to 12. Use `1 student` (not `1 students`) when there is one.
6. Write `get_honor_roll(names, gpas)` that returns a list of names with a GPA of 3.5 or higher, in file order.
7. Print the honor roll on one line, separated by a comma and a space.
8. Write `save_honor_roll(honor)` that writes `honor_roll.txt` exactly as shown below, with the real date and time. Then print `Saved honor_roll.txt`.
9. Input / Processing / Output comments.

**Sample run**
```
Read 7 students from students.csv

Name      Grade  GPA
---------------------
Avery     11     3.85
Blake     12     2.90
Casey     10     3.52
Devon     12     3.97
Emery     9      2.45
Finley    11     3.10
Harper    10     3.60

Average GPA: 3.34
Grade 9: 1 student
Grade 10: 2 students
Grade 11: 2 students
Grade 12: 2 students

Honor roll (3.5 or higher): Avery, Casey, Devon, Harper
Saved honor_roll.txt
```

**`honor_roll.txt`** (exact except the date and time)
```
HONOR ROLL
Created: 2026-11-09 08:15

Avery
Casey
Devon
Harper

Total: 4 students
```

**Hints**
- A function can return three values the same way it returns two: `return names, grades, gpas`. Catch them with `names, grades, gpas = read_students(FILE_NAME)`.
- Put the `read_students` call inside `try` / `except FileNotFoundError` in `main`. In the `except`, print the error and `return`.
- Count each grade with a loop: `for grade_level in range(9, 13):`, and inside it a loop that counts matches.
- `.write()` does not add a new line. End each line with `\n`.

**Test these too:** rename `students.csv` and run (you should see the error message, not a crash). Then add a new student to the file and run again.

---

## Build 9C: Monthly Sales Report
Read a year of sales from a file and print a bar chart and stats. Send the same report to the screen **and** a file using the `out_file=None` trick from the Step 9 study guide.

**Data file:** [sales.csv](sales.csv)
```
Month,Sales
January,8250.00
February,7400.50
March,9100.00
April,10325.75
May,12010.00
June,13450.25
July,14100.00
August,12875.50
September,9800.00
October,8900.00
November,11200.00
December,15600.00
```

**Requirements**
1. Header comment. Constants: `FILE_NAME = "sales.csv"`, `REPORT_NAME = "sales_report.txt"`, `DOLLARS_PER_STAR = 1000`.
2. Write `read_sales(file_name)` that returns two parallel lists: months and sales (float).
3. Write `print_chart(months, sales, out_file=None)`: Month 10 wide, then the stars 17 wide, then the sales with `$` and 2 decimals. One `*` for each full $1,000 (use `//`).
4. Write `print_stats(months, sales, out_file=None)` that prints the total, the average month, the best and worst months, and how many months are above average. Use your own loop (no `max`, `min`, or `sum`).
5. On the screen, print the title line, the chart, and the stats exactly as shown.
6. Write `save_report(months, sales)` that opens `sales_report.txt` and writes `SALES REPORT`, `Report created: <date and time>`, a blank line, the chart, a blank line, and the stats, by calling the same two print functions with the open file.
7. Print `Report saved to sales_report.txt` at the end.
8. Input / Processing / Output comments.

**Sample run**
```
Sales chart (each * = $1000)

January   ********         $8250.00
February  *******          $7400.50
March     *********        $9100.00
April     **********       $10325.75
May       ************     $12010.00
June      *************    $13450.25
July      **************   $14100.00
August    ************     $12875.50
September *********        $9800.00
October   ********         $8900.00
November  ***********      $11200.00
December  ***************  $15600.00

Total sales:   $133012.00
Average month: $11084.33
Best month:    December ($15600.00)
Worst month:   February ($7400.50)
Months above average: 6

Report saved to sales_report.txt
```

**`sales_report.txt`** (exact except the date and time)
```
SALES REPORT
Report created: 2026-11-09 08:15

January   ********         $8250.00
February  *******          $7400.50
March     *********        $9100.00
April     **********       $10325.75
May       ************     $12010.00
June      *************    $13450.25
July      **************   $14100.00
August    ************     $12875.50
September *********        $9800.00
October   ********         $8900.00
November  ***********      $11200.00
December  ***************  $15600.00

Total sales:   $133012.00
Average month: $11084.33
Best month:    December ($15600.00)
Worst month:   February ($7400.50)
Months above average: 6
```

**Hints**
- Build the stars with `"*" * int(sales[i] // DOLLARS_PER_STAR)`. 8250 // 1000 is 8.0, and `int()` turns it into 8.
- `{stars:<17}` pads the stars to 17 characters so the dollar amounts line up.
- Every `print` inside `print_chart` and `print_stats` needs `file=out_file`. A blank line in the file is `print(file=out_file)`.
- Find the best and worst months by **index**, so you can print both the month and the amount.

**Test these too:** change one month's sales to `999.99` (no stars at all) and run again.

---

## Build 9D: Supply Reorder
A school store needs to know which supplies to reorder. Read the inventory, print a status table, write a reorder file, and **add** a line to a log file each time the program runs.

**Data file:** [inventory.csv](inventory.csv)
```
Item,Quantity,ReorderLevel,Price
Pencils,240,100,0.25
Notebooks,35,50,1.99
Markers,18,40,1.25
Glue Sticks,60,30,0.89
Folders,22,25,0.50
Erasers,150,60,0.35
```

**Requirements**
1. Header comment. Constants: `FILE_NAME = "inventory.csv"`, `ORDER_FILE = "reorder.csv"`, `LOG_FILE = "inventory_log.txt"`.
2. Write `read_inventory(file_name)` that returns **four** parallel lists: items, quantities (int), reorder levels (int), and prices (float).
3. Write `order_amount(quantity, level)`: if the quantity is **at or below** the reorder level, return enough to bring the stock up to **twice** the reorder level (`level * 2 - quantity`). Otherwise return 0.
4. Print the status table exactly as shown: Item 13 wide, On Hand 9 wide, Reorder At 12 wide, then the status. A line of 42 dashes. The status is `OK` or `ORDER <amount>`.
5. Add up the inventory value (quantity × price for every item).
6. Write `reorder.csv` with the header `Item,OrderQuantity,Cost` and one line per item to order. Cost is order amount × price, with 2 decimals and no `$`.
7. **Append** one line to `inventory_log.txt` with the date and time, how many items need reordering, and the reorder cost. Use `"a"` mode so the old lines stay.
8. Print the summary exactly as shown.
9. Input / Processing / Output comments.

**Sample run**
```
Item         On Hand  Reorder At  Status
------------------------------------------
Pencils      240      100         OK
Notebooks    35       50          ORDER 65
Markers      18       40          ORDER 62
Glue Sticks  60       30          OK
Folders      22       25          ORDER 28
Erasers      150      60          OK

Inventory value: $269.05
Items to reorder: 3
Reorder cost: $220.85
Saved reorder.csv
Added a line to inventory_log.txt
```

**`reorder.csv`** (exact)
```
Item,OrderQuantity,Cost
Notebooks,65,129.35
Markers,62,77.50
Folders,28,14.00
```

**`inventory_log.txt`** after running the program **twice** (exact except the dates and times)
```
2026-11-09 08:15 - 3 items to reorder, $220.85
2026-11-09 08:16 - 3 items to reorder, $220.85
```

**Hints**
- Notebooks: 35 is at or below 50, so order 50 × 2 − 35 = 65. Cost 65 × 1.99 = 129.35.
- Keep three more lists while you loop (the items to order, the amounts, and the costs). Then write `reorder.csv` from those lists.
- `"w"` erases a file first. `"a"` adds to the end. That is the only difference.
- `Glue Sticks` has a space in it. That's fine; the CSV is split on commas, not spaces.

**Test these too:** run the program three times and open `inventory_log.txt` (three lines). Change Pencils to `100` (exactly the reorder level — it should say `ORDER 100`).

---

## Turn it in
1. In your `bpaPrep` repo, make a folder named `python_builds` (one folder for all builds).
2. Save the builds as `build09A.py`, `build09B.py`, `build09C.py`, and `build09D.py`. Put any data files the build uses next to the program.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

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
- [ ] Pushed to `bpaPrep/python_builds`
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Each program prints the error message (no crash) when its data file is missing
- [ ] Relative file names only
- [ ] Input / Processing / Output comments in each file
- [ ] Pushed to `bpaPrep/python_builds`, with the data and output files
