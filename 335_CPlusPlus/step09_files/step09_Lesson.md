# Step 09 — Files (C++)

**What you'll build:** Scoreboard From a File — the Step 8 scoreboard, but the players and scores come from `scores.csv`, and the report is also saved to `report.txt`.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Files and streams](#files-and-streams)
- [Writing a text file with ofstream](#writing-a-text-file-with-ofstream)
- [Reading a text file line by line with ifstream](#reading-a-text-file-line-by-line-with-ifstream)
- [Checking that the file opened](#checking-that-the-file-opened)
- [Where the program looks for the file](#where-the-program-looks-for-the-file)
- [Reading a CSV file](#reading-a-csv-file)
- [Printing to the screen or a file with one function](#printing-to-the-screen-or-a-file-with-one-function)
- [The current date and time](#the-current-date-and-time)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Scoreboard From a File](#the-challenge-scoreboard-from-a-file)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What a file stream is: `ifstream` to read, `ofstream` to write (`#include <fstream>`)
- Writing lines to a text file
- Reading a file one line at a time with `getline`
- Checking whether a file opened, and stopping politely if it did not
- Relative paths and the **working directory** (where the program looks for files)
- Splitting a CSV line on commas with `stringstream`, skipping the header line, and converting with `stoi`
- Writing one print function that can print to the screen **or** a file (`ostream&`)
- Getting the current date and time as `yyyy-MM-dd HH:mm`

---

## Files and streams

In C++ a **stream** is anything you send text to or read text from. You already know two: `cout` (to the screen) and `cin` (from the keyboard). File streams work **the same way**, with the same `<<`, `>>`, and `getline`.

| Stream | Direction | Needs |
|---|---|---|
| `cout` | program to screen | `<iostream>` |
| `cin` | keyboard to program | `<iostream>` |
| `ofstream` | program to a file ("output file stream") | `<fstream>` |
| `ifstream` | file to program ("input file stream") | `<fstream>` |

If you can print with `cout`, you can write a file.

---

## Writing a text file with ofstream

```cpp
#include <iostream>
#include <fstream>   // ofstream, ifstream
using namespace std;

int main()
{
    // Output: open (create) pets.txt in the working directory
    ofstream outFile("pets.txt");

    // Output: write lines with << exactly like cout
    outFile << "Name,Kind,Age" << endl;
    outFile << "Biscuit,dog,4" << endl;
    outFile << "Pepper,cat,2" << endl;
    outFile << "Nemo,fish,1" << endl;

    // Output: close the file to finish writing it
    outFile.close();

    cout << "Saved pets.txt" << endl;
    return 0;
}
```

What it prints on the screen:
```
Saved pets.txt
```

And `pets.txt` now contains:
```
Name,Kind,Age
Biscuit,dog,4
Pepper,cat,2
Nemo,fish,1
```

| What you type | What it means |
|---|---|
| `ofstream outFile("pets.txt");` | Make an output file stream named `outFile` and open `pets.txt`. If the file exists, it is **erased** and started fresh. If not, it is created. |
| `ofstream outFile("log.txt", ios::app);` | Open for **appending**: new lines go at the end, old lines are kept. |
| `outFile << ...;` | Write to the file, just like `cout`. |
| `outFile.close();` | Finish and close the file. |

**Closing:** a file stream closes itself automatically when the variable goes out of scope (the end of the `{ }` it was made in). Calling `.close()` yourself is still a good habit: it makes your intent clear to graders, and the file is complete before the next line runs.

---

## Reading a text file line by line with ifstream

```cpp
#include <iostream>
#include <fstream>
#include <string>
using namespace std;

int main()
{
    // Input: open pets.txt for reading
    ifstream inFile("pets.txt");

    // Input + Output: read one line at a time until the end of the file
    string line;
    int lineCount = 0;
    while (getline(inFile, line))
    {
        lineCount++;
        cout << lineCount << ": " << line << endl;
    }

    inFile.close();
    return 0;
}
```

What it prints (with the `pets.txt` from above):
```
1: Name,Kind,Age
2: Biscuit,dog,4
3: Pepper,cat,2
4: Nemo,fish,1
```

`while (getline(inFile, line))` is the standard pattern. `getline` returns the stream; when a line was read, the stream counts as **true** and the loop runs. At the end of the file it counts as **false** and the loop stops. You never need to know how many lines there are.

`getline(inFile, line)` is the same `getline` you use with `cin`. Only the stream is different.

---

## Checking that the file opened

If the file is missing, `ifstream` does **not** crash. It just reads nothing, and your program prints an empty report or uses garbage. Always check:

```cpp
#include <iostream>
#include <fstream>
#include <string>
using namespace std;

int main()
{
    // Input: try to open a file that does not exist
    ifstream inFile("missing.csv");

    // Processing: !inFile is true when the file could not be opened
    if (!inFile)
    {
        cout << "Error: could not find missing.csv" << endl;
        return 0;   // end politely
    }

    // (reading would go here)
    cout << "File opened." << endl;
    return 0;
}
```

What it prints:
```
Error: could not find missing.csv
```

| What you type | What it means |
|---|---|
| `if (!inFile)` | "If the file stream is not OK" (could not open) |
| `if (inFile.is_open())` | "If the file was opened" (the other way to check) |

This is the "error message if the file is missing" that BPA asks for on every file task.

---

## Where the program looks for the file

`ifstream inFile("scores.csv");` uses a **relative path**: just the file name. The program looks for it in the **working directory**, the folder the program is running "from." That folder depends on how you run it:

| How you run it | Working directory | Put `scores.csv` here |
|---|---|---|
| Visual Studio, Ctrl+F5 or F5 | The **project folder** (same folder as `step09.cpp` and the `.vcxproj`) | `bpaPrep\cpp_step09\scores.csv` |
| Double-click the `.exe` | The folder the `.exe` is in | `bpaPrep\cpp_step09\x64\Debug\scores.csv` |
| g++ in a terminal | The folder the terminal is in | Same folder as `step09.exe` when you run `.\step09.exe` |

Files your program **writes** (like `report.txt`) appear in the same working directory.

To get to the project folder fast: in Solution Explorer, right-click the project, **Open Folder in File Explorer**.

**Never use an absolute path** like `C:\Users\jordan\Desktop\scores.csv`. BPA says: "the flash drive letter may not be the same when the program is graded... Use relative file paths, not absolute file paths." At BPA, put the data file in the project folder **and** next to the `.exe`.

---

## Reading a CSV file

A **CSV** (comma-separated values) file has one record per line and commas between the fields. The first line is usually a **header** with the column names.

```
Title,Pages,Rating
Hatchet,195,4
Wonder,310,5
Holes,233,4
```

Three new pieces:
1. **Skip the header:** call `getline` once before the loop and ignore what it reads.
2. **Split a line on commas:** put the line into a `stringstream`, then call `getline(lineStream, field, ',')` to read up to each comma. (`<sstream>`)
3. **Convert text to numbers:** `stoi(field)` (Step 2).

```cpp
#include <iostream>
#include <fstream>
#include <sstream>   // stringstream
#include <string>
#include <vector>
using namespace std;

int main()
{
    // Output: first make a small CSV file to read (normally it already exists)
    ofstream makeFile("books.csv");
    makeFile << "Title,Pages,Rating\nHatchet,195,4\nWonder,310,5\nHoles,233,4\n";
    makeFile.close();

    // Input: open the CSV and stop if it is missing
    ifstream inFile("books.csv");
    if (!inFile)
    {
        cout << "Error: could not find books.csv" << endl;
        return 0;
    }

    // Input: read and ignore the header line
    string line;
    getline(inFile, line);

    // Input + Processing: split each line into title, pages, rating
    vector<string> titles;
    vector<int> pages;
    while (getline(inFile, line))
    {
        stringstream lineStream(line);   // treat this one line like a little input stream
        string title;
        string pagesText;
        string ratingText;

        getline(lineStream, title, ',');        // read up to the 1st comma
        getline(lineStream, pagesText, ',');    // up to the 2nd comma
        getline(lineStream, ratingText, ',');   // the rest of the line

        titles.push_back(title);
        pages.push_back(stoi(pagesText));       // text "195" -> number 195
    }
    inFile.close();

    // Output: what was read
    cout << "Read " << titles.size() << " books" << endl;
    for (size_t i = 0; i < titles.size(); i++)
    {
        cout << titles[i] << " has " << pages[i] << " pages" << endl;
    }
    return 0;
}
```

What it prints:
```
Read 3 books
Hatchet has 195 pages
Wonder has 310 pages
Holes has 233 pages
```

| What you type | What it means |
|---|---|
| `#include <sstream>` | String streams |
| `stringstream lineStream(line);` | A stream that reads from the text in `line` instead of a file or the keyboard |
| `getline(lineStream, field, ',');` | Read from `lineStream` up to the next **comma** (the third argument is the character to stop at). The comma is removed. |
| `stoi(field)` | Convert the text to an `int` |

**Blank lines:** a file may end with an empty line. `stoi("")` crashes the program (Step 10 explains why). A simple guard at the top of the loop avoids it:

```cpp
if (line.empty())
{
    continue;   // skip blank lines
}
```

**Try it:** Add up the pages of all the books and print the total and the average.

---

## Printing to the screen or a file with one function

The challenge prints the same table to the screen **and** to `report.txt`. You do not need two copies of `printTable`. Both `cout` and an `ofstream` are kinds of **output stream** (`ostream`). A function that takes an `ostream&` parameter can print to either one.

```cpp
#include <iostream>
#include <fstream>
#include <string>
using namespace std;

// Purpose: print a short weather summary.
// Parameters: out - where to print (cout or an open file); city - the city; high - today's high
// Returns: nothing
void printSummary(ostream& out, string city, int high)
{
    // Output: everything goes to "out", wherever that is
    out << "City: " << city << endl;
    out << "High: " << high << " F" << endl;
}

int main()
{
    // Output: once to the screen
    printSummary(cout, "Medina", 58);

    // Output: once to a file
    ofstream outFile("weather.txt");
    printSummary(outFile, "Medina", 58);
    outFile.close();

    cout << "Saved weather.txt" << endl;
    return 0;
}
```

What it prints:
```
City: Medina
High: 58 F
Saved weather.txt
```

And `weather.txt` has the same two lines.

The parameter must be `ostream& out`, **with the `&`**. Streams cannot be copied, so passing one by value is an error (`C2280 attempting to reference a deleted function`).

For the challenge, add `ostream& out` as the first parameter of your Step 8 `printTable` and `printAnalysis`, and change every `cout` inside them to `out`.

---

## The current date and time

The report needs a line like `Report created: 2026-11-02 08:15`. C++ gets the time from `<ctime>` and formats it with `put_time` from `<iomanip>`.

```cpp
#define _CRT_SECURE_NO_WARNINGS   // must be the first line: lets Visual Studio accept localtime

#include <iostream>
#include <iomanip>   // put_time
#include <sstream>   // ostringstream
#include <string>
#include <ctime>     // time, localtime
using namespace std;

// Purpose: get the current date and time as text.
// Parameters: none
// Returns: text like 2026-11-02 08:15 (yyyy-MM-dd HH:mm)
string currentDateTime()
{
    // Processing: get "now", break it into year/month/day/hour/minute
    time_t now = time(nullptr);
    tm* local = localtime(&now);

    // Processing: format it into a string
    ostringstream text;
    text << put_time(local, "%Y-%m-%d %H:%M");
    return text.str();
}

int main()
{
    // Output
    cout << "Report created: " << currentDateTime() << endl;
    return 0;
}
```

Example output (yours shows the real date and time):
```
Report created: 2026-11-02 08:15
```

| What you type | What it means |
|---|---|
| `time(nullptr)` | The current time, as a count of seconds since January 1, 1970 |
| `localtime(&now)` | Break that count into parts (year, month, day, hour, minute) for this computer's time zone |
| `put_time(local, "...")` | Format the parts using codes |
| `%Y` / `%m` / `%d` | 4-digit year / 2-digit month / 2-digit day |
| `%H` / `%M` | hour 00-23 / minute 00-59 |

**About `#define _CRT_SECURE_NO_WARNINGS`:** Visual Studio marks `localtime` as "unsafe" and, with its default settings, stops the build with `error C4996: 'localtime': This function or variable may be unsafe`. This `#define` turns that check off. It must be the **very first line of code** in the file, above every `#include`. Other compilers ignore it, so it is safe to leave in.

Copy `currentDateTime` into any program that needs a timestamp. It is a good function to have on your printed reference sheet.

---

## Common mistakes

**1. File not found, but it is right there**
- Looks like: `Error: could not find scores.csv` even though you can see the file.
- Cause: the file is not in the working directory (often it is next to the `.sln` in a different folder, or the name is `scores.csv.txt` because Windows hid the extension).
- Fix: see [Where the program looks for the file](#where-the-program-looks-for-the-file). In File Explorer, **View > Show > File name extensions** to see the real name.

**2. No check for a missing file**
- Result: the program prints an empty table, or crashes when it uses `names[0]`.
- Fix: `if (!inFile)` right after opening.

**3. Header line treated as data**
- Looks like: crash with `invalid_argument` (from `stoi("Round1")`), shown in Visual Studio as an "Unhandled exception" box.
- Fix: `getline(inFile, line);` once before the loop.

**4. Forgot the comma in `getline(lineStream, field, ',')`**
- Result: the whole rest of the line ends up in the first field.

**5. `localtime` error in Visual Studio**
- Error: `C4996 'localtime': This function or variable may be unsafe.`
- Fix: `#define _CRT_SECURE_NO_WARNINGS` as the first line.

**6. Writing the report to the screen only**
- Cause: `cout` left inside a print function that should use `out`.
- Fix: inside `printTable(ostream& out, ...)`, every print uses `out`.

**7. Absolute path**
- Looks like: `ifstream inFile("C:\\Users\\jordan\\scores.csv");`
- Result: works at home, fails for the grader.
- Fix: `ifstream inFile("scores.csv");`

---

## How this shows up at BPA

- The 2026 regional option 1 (worth 40 + 10 + 50 points) was: read a CSV file, display it in an aligned table with headers, and show an error message if the file is missing or unreadable. This step is that skill.
- The 2024 regional read `Story.txt` and `grades.txt`, and required an exact message ("Error Opening File") and ending the program if the file could not be opened.
- Every test says to use relative paths and to make sure the data file is where the program can find it after it is copied to the flash drive.
- A report with a date/time stamp is a common requirement on the Python and Java tests too.

---

## The challenge: Scoreboard From a File

Rebuild the Step 8 scoreboard so the data comes from a file and the report is also saved to a file.

**Data file:** `scores.csv` is in this step's folder ([scores.csv](scores.csv)). Download it and put it in your project folder (the same folder as `step09.cpp`). If you run the `.exe` directly, also copy it next to the `.exe`. Its contents:
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

**`report.txt` (exact except the date/time)**
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
Check: R1 avg = (88+95+72+100+65)/5 = 84.00; R2 = (92+67+85+94+70)/5 = 81.60; R3 = (79+84+90+98+58)/5 = 81.80.

**Hints**
- Replace `getScores` from Step 8 with a function like `bool loadScores(string fileName, vector<string>& names, vector<vector<int>>& scores)` that fills the vectors (passed by reference) and returns `false` if the file could not be opened.
- `calculateTotal` and `sortByTotal` copy over unchanged.
- Give `printTable` and `printAnalysis` an `ostream& out` first parameter, then call each twice: once with `cout`, once with the `ofstream`.
- The averages in the analysis divide by the number of players, which is now 5. Use `names.size()`, not a fixed number.
- To test the missing-file message, rename `scores.csv` for a moment and run again.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step09`.
2. Put `step09.cpp` **and** `scores.csv` in it. (Visual Studio: push the whole project folder, with `scores.csv` in the project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 9 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] `report.txt` matches the sample (except the date and time)
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Relative path only (`"scores.csv"`)
- [ ] Missing file prints the error and ends without crashing
- [ ] The header line is skipped
- [ ] The table and analysis functions print to either `cout` or the file
- [ ] Pushed to `bpaPrep/cpp_step09` with `scores.csv`
