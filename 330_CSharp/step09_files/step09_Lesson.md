# Step 09 — Files (C#)

**What you'll build:** Scoreboard From a File — the Step 8 scoreboard, but the scores come from `scores.csv` and the report is saved to `report.txt`.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Where your program looks for files](#where-your-program-looks-for-files)
- [Getting the data file next to your program](#getting-the-data-file-next-to-your-program)
- [Checking that a file exists](#checking-that-a-file-exists)
- [Reading a whole file at once](#reading-a-whole-file-at-once)
- [Reading line by line with StreamReader](#reading-line-by-line-with-streamreader)
- [Splitting a CSV line](#splitting-a-csv-line)
- [Writing a file with StreamWriter](#writing-a-file-with-streamwriter)
- [The using statement](#the-using-statement)
- [Dates and times](#dates-and-times)
- [Sending the same text to the screen and a file](#sending-the-same-text-to-the-screen-and-a-file)
- [A complete example](#a-complete-example)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Scoreboard From a File](#the-challenge-scoreboard-from-a-file)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What a relative path is and which folder your program looks in when you run it from Visual Studio
- How to make Visual Studio copy a data file next to your `.exe`
- How to check that a file exists before reading it
- How to read a file with `File.ReadAllLines` and with `StreamReader`
- How to split a CSV line into parts and skip the header line
- How to write a file with `StreamWriter`, and what `using ( ... )` does
- How to print the current date and time as `yyyy-MM-dd HH:mm`
- How to build text once and send it to both the screen and a file

Add `using System.IO;` at the top of your program. `File`, `StreamReader`, and `StreamWriter` live in `System.IO`. (A .NET 8 project already includes it behind the scenes, but write it anyway.)

## Where your program looks for files

A **path** says where a file is.
- An **absolute path** gives the whole location: `C:\Users\you\Documents\scores.csv`. **Never use these at BPA.** The graders' computer won't have your folders, and the flash drive letter may change.
- A **relative path** is just the file name: `"scores.csv"`. The program looks for it in its **working directory** — the folder it is running in.

When you press Ctrl+F5 in Visual Studio, the working directory is the folder where the `.exe` was built:

```text
Step09/
├── Program.cs
├── scores.csv               <- you add it here (in the project)...
└── bin/
    └── Debug/
        └── net8.0/
            ├── Step09.exe
            ├── scores.csv   <- ...but the program looks HERE
            └── report.txt   <- and files it writes end up HERE
```

So the data file must end up in `bin\Debug\net8.0\`. Copying it there by hand works, but `bin` is rebuilt and isn't pushed to GitHub. The better way is to let Visual Studio copy it for you every time it builds.

## Getting the data file next to your program

Do this once per project:

1. Download `scores.csv` from this step's folder (on GitHub: open the file → **Download raw file**).
2. In Visual Studio, **Solution Explorer** → right-click the project name (`Step09`) → **Add** → **Existing Item…**
3. In the file box, change the type filter at the bottom right to **All Files (\*.\*)**, then pick `scores.csv`. It now shows up in Solution Explorer and is copied into your project folder.
4. Click `scores.csv` in Solution Explorer. In the **Properties** window (bottom right; View → Properties Window if it is hidden), set **Copy to Output Directory** to **Copy if newer**.

Now every build copies `scores.csv` into `bin\Debug\net8.0\`, and `"scores.csv"` works. This is the same setting you'll use for the `.csv` files in Step 11 and the timed builds.

To find files your program **writes** (like `report.txt`): right-click the project → **Open Folder in File Explorer** → `bin` → `Debug` → `net8.0`.

## Checking that a file exists

Reading a file that isn't there crashes the program with `System.IO.FileNotFoundException: Could not find file '...\scores.csv'.` Check first:

```csharp
if (!File.Exists("scores.csv"))
{
    Console.WriteLine("Error: could not find scores.csv");
    return;   // in Main, return ends the program
}
```

`File.Exists(path)` returns `true` or `false`. `return;` inside `Main` ends `Main`, which ends the program — cleanly, without a crash. (Step 10 shows the other way: `try` / `catch`.)

## Reading a whole file at once

The simplest way to read a text file is `File.ReadAllLines`. It gives you a `string[]` with one item per line:

```csharp
string[] lines = File.ReadAllLines("scores.csv");
Console.WriteLine(lines.Length);   // 6 - the header plus 5 players
Console.WriteLine(lines[0]);       // Name,Round1,Round2,Round3
Console.WriteLine(lines[1]);       // Avery,88,92,79
```

Line 0 is the **header** (the column names). To skip it, start your loop at 1:

```csharp
for (int i = 1; i < lines.Length; i++)
{
    // lines[i] is one data line
}
```

`File.ReadAllText(path)` gives the whole file as one big string, if you ever need that.

## Reading line by line with StreamReader

For very large files, or when the reference guide shows it, you may see a `StreamReader` that reads one line at a time:

```csharp
using (StreamReader reader = new StreamReader("scores.csv"))
{
    string header = reader.ReadLine() ?? "";   // read and skip the header
    string? line;
    while ((line = reader.ReadLine()) != null)   // null means end of file
    {
        Console.WriteLine("Read: " + line);
    }
}
```

`reader.ReadLine()` works like `Console.ReadLine()`, but reads from the file. At the end of the file it returns `null`. The `while` line reads a line **and** checks it in one step. `string?` means "a string that might be null." Both ways are fine; `File.ReadAllLines` is shorter, so the challenge solution uses it.

## Splitting a CSV line

**CSV** means "comma-separated values." Each line is one record, and commas separate the fields. `Split(',')` cuts a line into a `string[]`:

```csharp
string line = "Blake,95,67,84";
string[] parts = line.Split(',');
// parts[0] = "Blake"   parts[1] = "95"   parts[2] = "67"   parts[3] = "84"

string name = parts[0];
int round1 = int.Parse(parts[1]);   // the parts are text - convert them
```

The pieces are **strings**. Convert the numbers with `int.Parse` (or `decimal.Parse` for money).

Files sometimes end with an extra blank line. A blank line splits into one empty part and `int.Parse("")` crashes. Skip blank lines:

```csharp
if (lines[i].Trim() == "")
{
    continue;   // Step 4: skip the rest of this pass
}
```

**Storing rows when you don't know how many there are.** Use Lists while reading (Step 6), then turn them into arrays so your Step 8 methods still work:

```csharp
List<string> nameList = new List<string>();
List<int[]> scoreList = new List<int[]>();   // a list of rows

// ... in the loop: nameList.Add(name); scoreList.Add(row); ...

string[] names = nameList.ToArray();
int[][] scores = scoreList.ToArray();        // a List<int[]> becomes an int[][]
```

## Writing a file with StreamWriter

```csharp
using (StreamWriter writer = new StreamWriter("notes.txt"))
{
    writer.WriteLine("First line");
    writer.WriteLine($"Total: {42}");
    writer.WriteLine();               // blank line
    writer.Write("No new line here");
}
```

`writer.WriteLine` and `writer.Write` work exactly like `Console.WriteLine` and `Console.Write` — but the text goes into the file.

- `new StreamWriter("notes.txt")` **replaces** the file if it already exists.
- `new StreamWriter("notes.txt", true)` **adds to the end** (append) instead.

Quick one-line versions:

| What you type | What it does |
|---|---|
| `File.WriteAllText(path, text)` | writes one string to a file (replaces it) |
| `File.WriteAllLines(path, lines)` | writes an array or list of strings, one per line |
| `File.AppendAllText(path, text)` | adds text to the end of the file |

## The using statement

`using (...) { ... }` makes sure the file is **closed** when the block ends — even if something goes wrong inside it. A file that isn't closed may be missing its last lines, or may stay "locked" so nothing else can open it.

This is a different `using` from the `using System;` lines at the top of the file. Same word, two jobs:

| Where | Meaning |
|---|---|
| `using System.IO;` at the top | "I'm using things from this library" |
| `using (StreamWriter w = ...) { }` in code | "close this thing automatically when the block ends" |

You can also close a file yourself with `writer.Close();`, but `using` is safer and graders recognize it.

## Dates and times

`DateTime.Now` is the current date and time. `ToString` with a pattern formats it:

```csharp
DateTime now = DateTime.Now;
Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm"));   // 2026-11-06 09:41
Console.WriteLine(now.ToString("MM/dd/yyyy"));         // 11/06/2026
Console.WriteLine(now.ToString("h:mm tt"));            // 9:41 AM
```

| Code | Means | Example |
|---|---|---|
| `yyyy` | 4-digit year | 2026 |
| `MM` | month, 2 digits (**capital** M) | 11 |
| `dd` | day, 2 digits | 06 |
| `HH` | hour, 24-hour clock, 2 digits | 09, 14 |
| `hh` / `h` | hour, 12-hour clock | 09 / 9 |
| `mm` | minutes (**lower-case** m) | 41 |
| `tt` | AM or PM | AM |

`MM` is months and `mm` is minutes. Mixing them up is the most common date mistake.

## Sending the same text to the screen and a file

The challenge prints the table on the screen **and** writes the same table to `report.txt`. Don't write the formatting code twice. Instead, have a method **build** the text and **return** it, then print it and write it:

```csharp
// Purpose: build a two-line summary.
// Parameters: count - how many items.
// Returns: the summary text (each line ends with a new line).
static string BuildSummary(int count)
{
    StringBuilder sb = new StringBuilder();
    sb.AppendLine($"Items: {count}");
    sb.AppendLine(new string('=', 10));
    return sb.ToString();
}
```

```csharp
string summary = BuildSummary(5);
Console.Write(summary);          // to the screen
writer.Write(summary);           // to the file (inside a using block)
```

`sb.AppendLine(x)` adds `x` and a new line (Step 7 used `Append`). Use `Console.Write` (not `WriteLine`) for text that already ends with a new line, or you'll get an extra blank line.

So for this step, change Step 8's `PrintTable` and `PrintAnalysis` into `BuildTable` and `BuildAnalysis` that return strings. The loops inside stay the same; `Console.WriteLine(...)` becomes `sb.AppendLine(...)`.

## A complete example

This program reads a list of books from `books.csv`, prints a summary, and saves it to `book_report.txt`. (It is not the challenge.)

To try it, make `books.csv` in the project with **Add → New Item → Text File** (name it `books.csv`), paste these lines, and set **Copy to Output Directory** to **Copy if newer**:

```text
Title,Pages
Hatchet,186
Holes,233
Wonder,310
```

```csharp
// Name: Example
// Date: 2026-11-06
// Program: Book Report
// Description: Reads books.csv, prints each book and the total pages,
//              and saves the same summary to book_report.txt.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookReport
{
    internal class Program
    {
        const string DATA_FILE = "books.csv";
        const string REPORT_FILE = "book_report.txt";

        // Purpose: build the summary text.
        // Parameters: titles, pages - parallel lists of book titles and page counts.
        // Returns: the summary, one line per book plus a total line.
        static string BuildSummary(List<string> titles, List<int> pages)
        {
            // Processing: one lined-up row per book, then the total
            StringBuilder sb = new StringBuilder();
            int total = 0;
            for (int i = 0; i < titles.Count; i++)
            {
                sb.AppendLine($"{titles[i],-10}{pages[i]}");
                total += pages[i];
            }
            sb.AppendLine($"{"TOTAL",-10}{total}");
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            // Input: stop if the file is missing
            if (!File.Exists(DATA_FILE))
            {
                Console.WriteLine($"Error: could not find {DATA_FILE}");
                return;
            }

            // Input: read all lines, skip the header, split each line
            string[] lines = File.ReadAllLines(DATA_FILE);
            List<string> titles = new List<string>();
            List<int> pages = new List<int>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Trim() == "")
                {
                    continue;
                }
                string[] parts = lines[i].Split(',');
                titles.Add(parts[0]);
                pages.Add(int.Parse(parts[1]));
            }

            // Processing: build the summary once
            string summary = BuildSummary(titles, pages);

            // Output: to the screen
            Console.WriteLine($"Read {titles.Count} books from {DATA_FILE}");
            Console.Write(summary);

            // Output: to the report file, with a title and the date at the top
            using (StreamWriter writer = new StreamWriter(REPORT_FILE))
            {
                writer.WriteLine("BOOK REPORT");
                writer.WriteLine("Created: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                writer.Write(summary);
            }
            Console.WriteLine($"Saved {REPORT_FILE}");
        }
    }
}
```

It prints:

```text
Read 3 books from books.csv
Hatchet   186
Holes     233
Wonder    310
TOTAL     729
Saved book_report.txt
```

And `book_report.txt` (in `bin\Debug\net8.0\`) contains:

```text
BOOK REPORT
Created: 2026-11-06 09:41
Hatchet   186
Holes     233
Wonder    310
TOTAL     729
```

**Try it:**
- Rename `books.csv` in the `bin\Debug\net8.0` folder and run again. You should get the error message, not a crash.
- Add a line to the report with the longest book.

## Common mistakes

**File not found, but the file is in the project.**
`Error: could not find scores.csv` (or `System.IO.FileNotFoundException` if you didn't check).
Fix: the program looks in `bin\Debug\net8.0\`. Set **Copy to Output Directory** to **Copy if newer** on the `.csv`.

**Using a full path.**
`"C:\\Users\\you\\Desktop\\scores.csv"` works on your computer and fails everywhere else.
Fix: use just `"scores.csv"`.

**Forgetting to skip the header.**
`System.FormatException: The input string 'Round1' was not in a correct format.` — the program tried to turn the word `Round1` into a number.
Fix: start the loop at index 1.

**Crashing on a blank last line.**
`System.FormatException` on the last line, or `System.IndexOutOfRangeException` when reading `parts[1]`.
Fix: skip lines where `line.Trim() == ""`.

**The report file is empty or missing its end.**
You wrote with a `StreamWriter` but didn't close it.
Fix: put the writer in a `using ( ... ) { }` block.

**"Where is report.txt?"**
It is in `bin\Debug\net8.0\`, next to the `.exe` — not next to `Program.cs`.

**Months show up as minutes.**
You wrote `"yyyy-mm-dd"` and got `2026-41-06`.
Fix: capital `MM` for months, lower-case `mm` for minutes.

**Extra blank lines in the output.**
You used `Console.WriteLine(table)` on text that already ends with a new line.
Fix: `Console.Write(table)`.

## How this shows up at BPA

- The 2026 Python regional exported results to a file with the date and time. The C++ regional read and displayed a CSV, with an error message if the file was missing. File handling is a graded item in the Source Code Review.
- Every BPA test warns that **the flash drive letter may change**. Relative paths only.
- The 2026 C# regional's project and files were provided in a folder; your program must find its files from wherever it runs. The "Copy to Output Directory" setting is how you make that work in Visual Studio.

## The challenge: Scoreboard From a File

Read the scores from `scores.csv`, print the Step 8 leaderboard and analysis, and save them to `report.txt`.

The data file [scores.csv](scores.csv) is in this step's folder. Add it to your project and set **Copy to Output Directory** to **Copy if newer** (see [above](#getting-the-data-file-next-to-your-program)). Its contents:

```text
Name,Round1,Round2,Round3
Avery,88,92,79
Blake,95,67,84
Casey,72,85,90
Devon,100,94,98
Emery,65,70,58
```

**Requirements:**
1. Header comment.
2. Read `scores.csv` from the same folder as the program (relative path). Skip the header line. Store names and scores like Step 8.
3. If the file is missing, print `Error: could not find scores.csv` and end the program without crashing.
4. Print `Read 5 players from scores.csv` (the real count), a blank line, then the same leaderboard table and analysis as Step 8.
5. Write the same table and analysis to `report.txt`, with two lines at the top: `CLASS SCOREBOARD REPORT` and `Report created: <date and time>` (format `yyyy-MM-dd HH:mm`).
6. Print `Report saved to report.txt` at the end.
7. Reuse your Step 8 functions (copy them in). Function comments and Input / Processing / Output comments.

**Sample run (exact):**
```text
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

**`report.txt` (exact except the date/time):**
```text
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

**Hints:**
- Copy in your Step 8 `CalculateTotal` and `SortByTotal` unchanged.
- Turn `PrintTable` and `PrintAnalysis` into `BuildTable` and `BuildAnalysis` that return a `string` (see [Sending the same text to the screen and a file](#sending-the-same-text-to-the-screen-and-a-file)). Start `BuildAnalysis` with `sb.AppendLine();` to get the blank line before `Winner:`.
- Read into `List<string>` and `List<int[]>`, then `.ToArray()`.
- Use `names.Length` (the real count) in the `Read 5 players` line, not the number 5.

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step09`.
2. Put your whole Visual Studio project folder (`Step09`) in it, **including `scores.csv`**.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 9 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] `report.txt` matches the sample (except the date and time)
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Relative path `"scores.csv"`; Copy to Output Directory is set
- [ ] Missing file prints the error message instead of crashing
- [ ] The file is written inside a `using` block
- [ ] Pushed to `bpaPrep/csharp_step09`
