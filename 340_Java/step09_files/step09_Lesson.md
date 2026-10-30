# Step 09 — Files (Java)

**What you'll build:** Scoreboard From a File — read player scores from `scores.csv`, print the Step 8 leaderboard, and save it to `report.txt` with the date and time.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Text files and CSV files](#text-files-and-csv-files)
- [Where Java looks for a file](#where-java-looks-for-a-file)
- [Checked exceptions: Java makes you plan for a missing file](#checked-exceptions-java-makes-you-plan-for-a-missing-file)
- [Reading a file line by line](#reading-a-file-line-by-line)
- [try-with-resources closes the file for you](#try-with-resources-closes-the-file-for-you)
- [Splitting CSV lines and skipping the header](#splitting-csv-lines-and-skipping-the-header)
- [Checking if a file exists](#checking-if-a-file-exists)
- [Writing a text file](#writing-a-text-file)
- [The current date and time](#the-current-date-and-time)
- [Sending the same text to the screen and a file](#sending-the-same-text-to-the-screen-and-a-file)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Scoreboard From a File](#the-challenge-scoreboard-from-a-file)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What a CSV file is
- Relative paths and the "working directory" (where Java looks for files)
- Checked exceptions, and the minimum `try`/`catch` Java requires for files
- Reading a file line by line with `Scanner` and `new File(...)`
- `try`-with-resources, which closes files automatically
- Splitting lines with `split(",")`, skipping a header, and converting text to numbers
- Checking whether a file exists with `File.exists()`
- Writing a file with `PrintWriter` and `FileWriter`
- Getting the date and time formatted as `yyyy-MM-dd HH:mm`
- Building report text once so it can go to the screen **and** a file

---

## Text files and CSV files

A **text file** is just lines of characters. A **CSV** file ("comma-separated values") is a text file that stores a table: one row per line, with commas between the columns. The first line is often a **header** that names the columns.

`pets.csv`:

```
Name,Type,Age
Biscuit,Dog,4
Pickles,Cat,2
Nemo,Fish,1
```

You can open a CSV in Notepad, VS Code, or Excel. To your program it is just text, so you read each line and split it on the commas.

---

## Where Java looks for a file

When you write `new File("pets.csv")`, that is a **relative path** - just the file name, no drive or folders. Java looks for it in the **working directory**: the folder the program is running *from*.

| How you run | Working directory | Where to put `scores.csv` |
|---|---|---|
| VS Code **Run** button | The folder you opened with **File > Open Folder** | In that folder, next to `Step09.java` |
| Command line (`java Step09`) | The folder the terminal is in | In that folder (`cd` there first) |
| IntelliJ IDEA | The project's top folder | The project's top folder (not `src`) |
| Eclipse / NetBeans / BlueJ | The project folder | The project folder (not `src` or `bin`) |

**For this class:** open the step folder itself in VS Code (`java_step09`), and put `scores.csv` in it, next to your `.java` file.

**Always use relative paths.** BPA says "the flash drive letter may not be the same when the program is graded." A path like `"E:\\12345\\scores.csv"` will break on the grader's computer. Just `"scores.csv"` works anywhere, as long as the file is in the same folder.

If you get confused about where Java is looking, this prints the working directory:

```java
System.out.println(new File("").getAbsolutePath());
```

---

## Checked exceptions: Java makes you plan for a missing file

An **exception** is an error that happens while the program runs (Step 10 covers them fully). Most exceptions, like `NumberFormatException`, you can choose to deal with or not.

File exceptions are different. `FileNotFoundException` and `IOException` are **checked exceptions**: Java will **not compile** your program unless you show a plan for them. If you just write:

```java
Scanner fileReader = new Scanner(new File("pets.csv"));
```

you get this compile error:

```
error: unreported exception FileNotFoundException; must be caught or declared to be thrown
```

You have two choices:

**Choice 1 - catch it** (what we do): wrap the file code in `try` / `catch`.

```java
try {
    Scanner fileReader = new Scanner(new File("pets.csv"));
    // ... read the file ...
    fileReader.close();
} catch (FileNotFoundException e) {
    System.out.println("Error: could not find pets.csv");
}
```

`try` means "try to run this." If a `FileNotFoundException` happens anywhere inside it, Java jumps straight to the `catch` block instead of crashing.

**Choice 2 - declare it** with `throws` on the method:

```java
public static void main(String[] args) throws FileNotFoundException {
```

This compiles, but if the file is missing, the program **crashes** with a red error. The challenge says "end the program without crashing," so use Choice 1.

| What you type | What it means |
|---|---|
| `try { ... }` | Run this code, but watch for errors. |
| `catch (FileNotFoundException e) { ... }` | If that kind of error happened, run this instead of crashing. `e` holds details about the error. |
| `throws FileNotFoundException` | "This method might fail this way - whoever calls it must deal with it." |

You need `import java.io.File;` and `import java.io.FileNotFoundException;` at the top.

---

## Reading a file line by line

You already know `Scanner` for the keyboard. Give it a `File` instead of `System.in`, and it reads the file:

| Method | What it does |
|---|---|
| `fileReader.hasNextLine()` | `true` if there is another line to read |
| `fileReader.nextLine()` | Reads the next line (without the new-line character) |

Loop **while there is another line**:

```java
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class ReadPets {
    public static void main(String[] args) {
        // Input: open pets.csv from the working directory
        try (Scanner fileReader = new Scanner(new File("pets.csv"))) {
            int count = 0;
            while (fileReader.hasNextLine()) {
                String line = fileReader.nextLine();
                // Output: show each line as-is
                System.out.println(line);
                count++;
            }
            System.out.println("Lines read: " + count);
        } catch (FileNotFoundException e) {
            System.out.println("Error: could not find pets.csv");
        }
    }
}
```

Output (with the `pets.csv` above in the folder):

```
Name,Type,Age
Biscuit,Dog,4
Pickles,Cat,2
Nemo,Fish,1
Lines read: 4
```

Output if `pets.csv` is missing:

```
Error: could not find pets.csv
```

The file Scanner is a **second** Scanner, separate from your keyboard Scanner. Give it a different name (`fileReader`).

---

## try-with-resources closes the file for you

Files must be **closed** when you are done, so the operating system lets go of them (and, when writing, so everything actually gets saved to disk). Notice the `try` above has parentheses:

```java
try (Scanner fileReader = new Scanner(new File("pets.csv"))) {
    // use fileReader
}
// fileReader is closed automatically here, even if an error happened
```

This is called **try-with-resources**. Anything you create in the parentheses after `try` is closed automatically when the block ends. You don't need to call `.close()` yourself, and you can't forget to. Use it for every file you read or write.

(Do **not** use try-with-resources for the keyboard Scanner. Closing `System.in` early means you can't read the keyboard again.)

---

## Splitting CSV lines and skipping the header

To use the data, **skip the header** by reading the first line before the loop and ignoring it. Then **split** each line on commas (from Step 7) and **convert** the number columns:

```java
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class PetAges {
    public static void main(String[] args) {
        ArrayList<String> names = new ArrayList<>();
        ArrayList<Integer> ages = new ArrayList<>();

        // Input: read pets.csv, skipping the header line
        try (Scanner fileReader = new Scanner(new File("pets.csv"))) {
            fileReader.nextLine();                         // read the header and ignore it
            while (fileReader.hasNextLine()) {
                String line = fileReader.nextLine();
                // Processing: "Biscuit,Dog,4" -> ["Biscuit", "Dog", "4"]
                String[] parts = line.split(",");
                names.add(parts[0]);
                ages.add(Integer.parseInt(parts[2].trim()));
            }
        } catch (FileNotFoundException e) {
            System.out.println("Error: could not find pets.csv");
            return;                                        // stop main here
        }

        // Output
        int totalAge = 0;
        for (int i = 0; i < names.size(); i++) {
            System.out.println(names.get(i) + " is " + ages.get(i));
            totalAge += ages.get(i);
        }
        System.out.printf("Average age: %.2f%n", (double) totalAge / names.size());
    }
}
```

Output:

```
Biscuit is 4
Pickles is 2
Nemo is 1
Average age: 2.33
```

Notes:
- `parts[0]` is the first column, `parts[2]` is the third.
- `.trim()` before converting protects against stray spaces like `Nemo, Fish, 1`.
- `return;` inside `main` ends the program right there. That is how you "end the program without crashing" after an error.
- You don't know how many lines a file has until you read it, so reading into an `ArrayList` first is a good plan. If you need an array (like Step 8's `String[]` and `int[][]`), make it **after** reading, using the list's `size()`.
- A blank line at the end of the file would split into `[""]` and crash `parseInt`. To be safe, skip blank lines: `if (!line.isBlank()) { ... }`.

---

## Checking if a file exists

A `File` object can tell you whether the file is there **before** you try to open it:

```java
File dataFile = new File("pets.csv");
if (!dataFile.exists()) {
    System.out.println("Error: could not find pets.csv");
    return;
}
```

This makes the "missing file" case clear to anyone reading your code. You still need the `try`/`catch` (Java requires it), but now the `catch` is just a safety net.

---

## Writing a text file

To write a file, use a **`PrintWriter`** wrapped around a **`FileWriter`**. A `PrintWriter` has the same `print`, `println`, and `printf` methods you already know from `System.out`.

```java
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;

public class ShoppingList {
    public static void main(String[] args) {
        String[] items = {"Milk", "Eggs", "Bread"};

        // Output: write the list to shopping.txt (replaces the file if it exists)
        // catch: IOException means the file could not be written
        try (PrintWriter writer = new PrintWriter(new FileWriter("shopping.txt"))) {
            writer.println("SHOPPING LIST");
            for (int i = 0; i < items.length; i++) {
                writer.printf("%d. %s%n", i + 1, items[i]);
            }
        } catch (IOException e) {
            System.out.println("Error: could not write shopping.txt");
            return;
        }
        System.out.println("Saved shopping.txt");
    }
}
```

Console output:

```
Saved shopping.txt
```

`shopping.txt`:

```
SHOPPING LIST
1. Milk
2. Eggs
3. Bread
```

| What you type | What it means |
|---|---|
| `new FileWriter("shopping.txt")` | Open the file for writing. **Creates** it if it doesn't exist; **replaces** it if it does. |
| `new FileWriter("log.txt", true)` | `true` means **append** - add to the end instead of replacing. |
| `new PrintWriter(...)` | Wraps the FileWriter so you can use `println`, `print`, `printf`. |
| `writer.println(...)` | Writes a line to the file (nothing shows on screen). |
| `catch (IOException e)` | Writing can fail (disk full, file open in another program, no permission). `IOException` is checked, so Java requires the catch. |

You need `import java.io.FileWriter;`, `import java.io.IOException;`, and `import java.io.PrintWriter;`.

The file is only fully saved when the writer is **closed**. try-with-resources does that for you. If you forget to close a writer, the file may come out empty.

---

## The current date and time

Java's date and time classes are in `java.time`:

```java
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class TimeStamp {
    public static void main(String[] args) {
        // Processing: get the date and time right now, then format it as text
        LocalDateTime now = LocalDateTime.now();
        DateTimeFormatter format = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm");
        String stamp = now.format(format);

        // Output
        System.out.println("Report created: " + stamp);
    }
}
```

Output (yours will show the real date and time):

```
Report created: 2026-11-02 08:15
```

| Pattern letter | Meaning | Example |
|---|---|---|
| `yyyy` | 4-digit year | `2026` |
| `MM` | 2-digit month (**capital** M) | `11` |
| `dd` | 2-digit day | `02` |
| `HH` | hour, 00-23 (24-hour clock) | `08`, `14` |
| `mm` | minutes (**lowercase** m) | `15` |

Capital `MM` is month and lowercase `mm` is minutes. Mixing them up is a classic mistake. `hh` (lowercase) is the 12-hour clock - use `HH` here.

---

## Sending the same text to the screen and a file

The challenge prints the leaderboard on the screen **and** writes the same leaderboard to `report.txt`. You don't want to write the table code twice.

The trick: change Step 8's `printTable` into a method that **builds the table as a String and returns it**. Then you can `System.out.print(table)` and `writer.print(table)`.

```java
/*
 * Purpose: build a small two-column table as text.
 * Parameters: names - the names; points - the points (same order)
 * Returns: the table, each line ending in \n
 */
static String buildPointsTable(String[] names, int[] points) {
    StringBuilder text = new StringBuilder();
    text.append(String.format("%-10s%s\n", "Name", "Points"));
    for (int i = 0; i < names.length; i++) {
        text.append(String.format("%-10s%d\n", names[i], points[i]));
    }
    return text.toString();
}
```

Then:

```java
String table = buildPointsTable(names, points);
System.out.print(table);            // to the screen
writer.print(table);                // to the file
```

`String.format` works like `printf` but returns the text (Step 5), and `StringBuilder` collects the lines (Step 7). Use `\n` for the line endings inside the text, and `print` (not `println`) when you output it, since the text already ends with a new line.

---

## Common mistakes

**1. No `try`/`catch` around file code**
- Error: `error: unreported exception FileNotFoundException; must be caught or declared to be thrown` (or `IOException` for writing)
- Fix: wrap it in `try (...) { } catch (FileNotFoundException e) { }`.

**2. The file is in the wrong folder**
- Looks like: your program prints `Error: could not find scores.csv` even though the file exists.
- Fix: put the CSV in the folder you opened in VS Code (next to the `.java` file), and open the step folder itself.

**3. Using a full path**
- Looks like: `new File("C:\\Users\\jordan\\Desktop\\scores.csv")`
- Works on your computer, fails at BPA.
- Fix: `new File("scores.csv")`.

**4. Forgetting to skip the header**
- Error: `java.lang.NumberFormatException: For input string: "Round1"`
- Fix: call `fileReader.nextLine();` once before the loop.

**5. Writer never closed**
- Looks like: `report.txt` is empty or missing the last lines.
- Fix: use try-with-resources so it is always closed.

**6. `mm` vs `MM`**
- Looks like: `Report created: 2026-15-02 08:11` (minutes where the month should be).
- Fix: `yyyy-MM-dd HH:mm`.

**7. Missing imports**
- Error: `error: cannot find symbol ... symbol: class File` (or `PrintWriter`, `LocalDateTime`...)
- Fix: add the `java.io` and `java.time` imports at the top.

---

## How this shows up at BPA

- The 2026 Python regional required "results exported to a file with date/time." The C++ regional read a CSV and required "error handling for a missing file." Java tests use the same skills.
- **Relative paths** are stated in every BPA programming test.
- Graders run your program from the flash drive. If your data file isn't in your Contestant ID folder, it won't be found. Put the data file and the `.java` file together.
- File code needs try/catch in Java anyway, so you get the "exception handling" points almost for free - **comment** each `catch` to say what it handles.

---

## The challenge: Scoreboard From a File

Instead of typing scores, read them from a file and save a report.

**Data file:** [`scores.csv`](scores.csv) is in this step folder. Download it and put it in your `java_step09` folder, next to `Step09.java`. Do not change it.

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
7. Reuse your Step 8 methods (copy them in). Method comments and Input / Processing / Output comments.

**Sample run (exact):**
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
**`report.txt` (exact except the date/time):**
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
- Class `Step09` in `Step09.java`. This program has **no keyboard input**, so it doesn't need a keyboard Scanner.
- Copy in `calculateTotal` and `sortByTotal` from Step 8 unchanged.
- Change `printTable` into `buildTable` and `printAnalysis` into `buildAnalysis` - same code, but `append` to a `StringBuilder` with `String.format` and return the text. Use `\n` at the end of each line.
- Read the data lines into an `ArrayList<String>` first. Then make `String[] names = new String[lines.size()]` and `int[][] scores = new int[lines.size()][3]` and fill them by splitting each line.
- To test the missing-file message, rename `scores.csv` for a moment and run it.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step09`.
2. Put `Step09.java`, `scores.csv`, and the `report.txt` your program made in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 9 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `scores.csv` opened with a relative path; header skipped
- [ ] Missing file prints the error message and ends without crashing
- [ ] `report.txt` has the title, the date and time (`yyyy-MM-dd HH:mm`), the table, and the analysis
- [ ] Files opened with try-with-resources; each `catch` has a comment saying what it catches
- [ ] Step 8 methods reused, each with a purpose / parameters / returns comment
- [ ] Pushed to `bpaPrep/java_step09` with `scores.csv` and `report.txt`
