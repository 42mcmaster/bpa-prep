# Builds for Step 11 — Menu Programs and Classes (Python)

These are BPA-style programs that use the Step 11 skills together with everything before it. They are bigger than the practice problems, and closer to what the BPA test asks for.

**Do these after you finish the Step 11 lesson and practice.** Use the [Step 11 Study Guide](../step11_menuProgram/step11_StudyGuide.md) for help.

**Rules for every build in this file**
- Copy `get_text` and `get_int` (and `get_yes_no` where needed) from Build 10A (Ticket Order).
- Each menu option is its own function.
- A blank line prints before each menu.
- Every class, method, and function has a purpose / parameters / returns comment.
- Every `try`/`except` names its error and has a comment saying what it catches.
- End the file with `if __name__ == "__main__":` and `main()`.

## Table of Contents
- [Build 11A: Club Manager](#build-11a-club-manager)
- [Build 11B: To-Do List](#build-11b-to-do-list)
- [Build 11C: Library Checkout](#build-11c-library-checkout)
- [Build 11D: Gradebook Manager](#build-11d-gradebook-manager)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Build 11A: Club Manager
Build a menu program that manages a club's members and points.

**Data file:** `members.csv` is in this folder (`bpaBuilds`) ([members.csv](members.csv)). Copy it into your `python_builds` folder.
```
Name,Points
Avery,120
Blake,95
Casey,140
```

**Requirements**
1. Header comment.
2. A `Member` class with a name, points, a constructor, and an `add_points(amount)` method.
3. At start, load `members.csv` into a list of `Member` objects and print `Loaded 3 members from members.csv`. If it's missing print `No members.csv found. Starting with an empty list.`
4. Show this menu and repeat until Quit. Use `get_int` for the choice (1–6):
   ```
   ===== CLUB MANAGER =====
   1. Add member
   2. Record points
   3. Show leaderboard
   4. Search for a member
   5. Save
   6. Quit
   ```
   prompt: `Choose an option (1-6): `
5. **Add member:** `New member name: ` (get_text). If the name already exists (ignore case) print `That member already exists.` Otherwise add with 0 points and print `Added <name>.`
6. **Record points:** if there are no members print `No members yet.` Otherwise list them numbered (`1. Avery (120)`), ask `Choose a member (1-N): ` and `Points to add (1-50): ` (get_int), then print `<name> now has <points> points.`
7. **Show leaderboard:** sorted by points, highest first:
   ```
   Rank  Name      Points
   ----------------------
   1     Casey     140
   2     Avery     120
   3     Blake     95
   ```
   (Rank 6 wide left, Name 10 wide left, then points. 22 dashes.)
8. **Search:** `Search for: ` — print every member whose name contains the text, ignoring case, as `Casey - 140 points`. If none: `No members match "<text>".`
9. **Save:** write `members.csv` (header + one line per member) and `club_report.txt` (`CLUB REPORT`, `Report created: yyyy-MM-dd HH:mm`, a blank line, the leaderboard). Use try/except. Print `Saved members.csv and club_report.txt`.
10. **Quit:** print `Goodbye!`
11. Each menu option is its own function. Function comments and Input / Processing / Output comments.

**Sample run (exact)**
```
Loaded 3 members from members.csv

===== CLUB MANAGER =====
1. Add member
2. Record points
3. Show leaderboard
4. Search for a member
5. Save
6. Quit
Choose an option (1-6): 1
New member name: Jordan
Added Jordan.

===== CLUB MANAGER =====
1. Add member
2. Record points
3. Show leaderboard
4. Search for a member
5. Save
6. Quit
Choose an option (1-6): 2
1. Avery (120)
2. Blake (95)
3. Casey (140)
4. Jordan (0)
Choose a member (1-4): 2
Points to add (1-50): 50
Blake now has 145 points.

===== CLUB MANAGER =====
1. Add member
2. Record points
3. Show leaderboard
4. Search for a member
5. Save
6. Quit
Choose an option (1-6): 3
Rank  Name      Points
----------------------
1     Blake     145
2     Casey     140
3     Avery     120
4     Jordan    0

===== CLUB MANAGER =====
1. Add member
2. Record points
3. Show leaderboard
4. Search for a member
5. Save
6. Quit
Choose an option (1-6): 4
Search for: a
Avery - 120 points
Blake - 145 points
Casey - 140 points
Jordan - 0 points

===== CLUB MANAGER =====
1. Add member
2. Record points
3. Show leaderboard
4. Search for a member
5. Save
6. Quit
Choose an option (1-6): 7
Please enter a whole number from 1 to 6.
Choose an option (1-6): 6
Goodbye!
```
A blank line prints before each menu. Showing the leaderboard must not reorder the members list — sort a copy — so option 2's numbered list stays in the order loaded and added. The search for "a" matches all four because every name contains an "a" or "A".

**Hints**
- Copy `get_text` and `get_int` from Build 10A (Ticket Order).
- Build it in this order, running after each: the `Member` class → `load_members` → the menu loop with empty option functions → Quit → Add → Record points → Leaderboard → Search → Save.
- `print_leaderboard(members, out_file=None)` can serve both option 3 and the report file.
- Test with no `members.csv` (rename it): you should see the "No members.csv found" message, and option 2 should say `No members yet.`
- After option 5, open `members.csv` in Notepad. Jordan should be there.

---

## Build 11B: To-Do List
Build a menu program that keeps a to-do list of `Task` objects. There is no file in this task.

**Requirements**
1. Header comment.
2. A `Task` class:
   - constructor with `title` and `priority` (1 high, 2 medium, 3 low); every new task starts with `done = False`
   - `mark_done()` method that sets `done` to True
   - `__str__` method that returns text like `[ ] Study for quiz (high)` or `[X] Clean room (low)`
3. The menu, repeated until Quit, with `get_int` for the choice:
   ```
   ===== TO-DO LIST =====
   1. Add a task
   2. Show tasks
   3. Mark a task done
   4. Clear done tasks
   5. Quit
   ```
   prompt: `Choose an option (1-5): `
4. **Add a task:** `Task: ` (`get_text`) and `Priority (1=high, 2=medium, 3=low): ` (`get_int`). Print `Added "<title>".`
5. **Show tasks:** print every task (using `print(task)`), sorted by priority, high first. Then `N of M done`. If there are no tasks, print `No tasks yet.`
6. **Mark a task done:** list the tasks numbered in the order they were added, then ask `Which task is done (1-N): `. Print `Marked "<title>" done.`, or `"<title>" was already done.` If there are no tasks, print `No tasks yet.`
7. **Clear done tasks:** remove every task that is done. Print `Done tasks removed: N`.
8. **Quit:** print `Goodbye! N tasks left.`
9. Input / Processing / Output comments.

**Sample run**
```

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 2
No tasks yet.

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 1
Task: Study for quiz
Priority (1=high, 2=medium, 3=low): 1
Added "Study for quiz".

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 1
Task: Clean room
Priority (1=high, 2=medium, 3=low): 3
Added "Clean room".

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 1
Task: Finish Python task
Priority (1=high, 2=medium, 3=low): 0
Please enter a whole number from 1 to 3.
Priority (1=high, 2=medium, 3=low): 2
Added "Finish Python task".

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 2
[ ] Study for quiz (high)
[ ] Finish Python task (medium)
[ ] Clean room (low)
0 of 3 done

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 3
1. [ ] Study for quiz (high)
2. [ ] Clean room (low)
3. [ ] Finish Python task (medium)
Which task is done (1-3): 2
Marked "Clean room" done.

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 3
1. [ ] Study for quiz (high)
2. [X] Clean room (low)
3. [ ] Finish Python task (medium)
Which task is done (1-3): 2
"Clean room" was already done.

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 2
[ ] Study for quiz (high)
[ ] Finish Python task (medium)
[X] Clean room (low)
1 of 3 done

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 4
Done tasks removed: 1

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 2
[ ] Study for quiz (high)
[ ] Finish Python task (medium)
0 of 2 done

===== TO-DO LIST =====
1. Add a task
2. Show tasks
3. Mark a task done
4. Clear done tasks
5. Quit
Choose an option (1-5): 5
Goodbye! 2 tasks left.
```

**Hints**
- Sorting by priority: write `get_priority(task)` that returns `task.priority`, then `sorted(tasks, key=get_priority)`. Use `sorted` (a new list) so option 3's numbered list stays in the order added.
- `print(task)` calls your `__str__` method. So does `f"{i + 1}. {tasks[i]}"`.
- The easiest way to clear done tasks: build a **new** list of the tasks that are not done, and return it. In `main`: `tasks = clear_done(tasks)`.
- `\"` puts quote marks inside an f-string: `print(f"Added \"{title}\".")`

**Test these too:** options 2 and 3 with no tasks, and a blank task name.

---

## Build 11C: Library Checkout
Build a menu program that loads library books from a file, checks copies out and in, searches, and saves.

**Data file:** [books.csv](books.csv) — copy it into your `python_builds` folder.
```
Title,Author,Copies,CheckedOut
Hatchet,Gary Paulsen,3,1
Holes,Louis Sachar,2,2
The Giver,Lois Lowry,4,0
Wonder,R. J. Palacio,2,1
```

**Requirements**
1. Header comment. Constant: `FILE_NAME = "books.csv"`.
2. A `Book` class:
   - constructor with `title`, `author`, `copies`, and `checked_out`
   - `available()` returns copies minus checked out
   - `check_out()` adds 1 to `checked_out` and returns True if a copy is available; otherwise returns False and changes nothing
   - `return_copy()` subtracts 1 and returns True if any are checked out; otherwise returns False
   - `__str__` returns text like `Hatchet by Gary Paulsen - 2 of 3 on the shelf`
3. At the start, load `books.csv` into a list of `Book` objects and print `Loaded 4 books from books.csv`. If it is missing, print `No books.csv found. Starting with no books.`
4. The menu, repeated until Quit:
   ```
   ===== LIBRARY =====
   1. List books
   2. Check out a book
   3. Return a book
   4. Search
   5. Save
   6. Quit
   ```
   prompt: `Choose an option (1-6): `
5. **List books:** print every book, then `Copies checked out: N`.
6. **Check out** and **Return:** write `choose_book(books, prompt)` that lists the books numbered and asks the question with `get_int`, then returns the chosen `Book`. Print the messages exactly as shown.
7. **Search:** `Search title or author: ` — print every book whose title **or** author contains the text, ignoring capitals. If none, print `No books match "<text>".`
8. **Save:** write the header and every book back to `books.csv` inside `try`/`except OSError`. Print `Saved books.csv`.
9. **Quit:** print `Goodbye!`
10. If there are no books, options 1, 2, and 3 print `No books yet.`
11. Input / Processing / Output comments.

**Sample run**
```
Loaded 4 books from books.csv

===== LIBRARY =====
1. List books
2. Check out a book
3. Return a book
4. Search
5. Save
6. Quit
Choose an option (1-6): 1
Hatchet by Gary Paulsen - 2 of 3 on the shelf
Holes by Louis Sachar - 0 of 2 on the shelf
The Giver by Lois Lowry - 4 of 4 on the shelf
Wonder by R. J. Palacio - 1 of 2 on the shelf
Copies checked out: 4

===== LIBRARY =====
1. List books
2. Check out a book
3. Return a book
4. Search
5. Save
6. Quit
Choose an option (1-6): 2
1. Hatchet by Gary Paulsen - 2 of 3 on the shelf
2. Holes by Louis Sachar - 0 of 2 on the shelf
3. The Giver by Lois Lowry - 4 of 4 on the shelf
4. Wonder by R. J. Palacio - 1 of 2 on the shelf
Check out which book (1-4): 2
Sorry, every copy of Holes is checked out.

===== LIBRARY =====
1. List books
2. Check out a book
3. Return a book
4. Search
5. Save
6. Quit
Choose an option (1-6): 2
1. Hatchet by Gary Paulsen - 2 of 3 on the shelf
2. Holes by Louis Sachar - 0 of 2 on the shelf
3. The Giver by Lois Lowry - 4 of 4 on the shelf
4. Wonder by R. J. Palacio - 1 of 2 on the shelf
Check out which book (1-4): 1
Checked out Hatchet. 1 left on the shelf.

===== LIBRARY =====
1. List books
2. Check out a book
3. Return a book
4. Search
5. Save
6. Quit
Choose an option (1-6): 3
1. Hatchet by Gary Paulsen - 1 of 3 on the shelf
2. Holes by Louis Sachar - 0 of 2 on the shelf
3. The Giver by Lois Lowry - 4 of 4 on the shelf
4. Wonder by R. J. Palacio - 1 of 2 on the shelf
Return which book (1-4): 3
No copies of The Giver are checked out.

===== LIBRARY =====
1. List books
2. Check out a book
3. Return a book
4. Search
5. Save
6. Quit
Choose an option (1-6): 3
1. Hatchet by Gary Paulsen - 1 of 3 on the shelf
2. Holes by Louis Sachar - 0 of 2 on the shelf
3. The Giver by Lois Lowry - 4 of 4 on the shelf
4. Wonder by R. J. Palacio - 1 of 2 on the shelf
Return which book (1-4): 1
Returned Hatchet. 2 on the shelf now.

===== LIBRARY =====
1. List books
2. Check out a book
3. Return a book
4. Search
5. Save
6. Quit
Choose an option (1-6): 4
Search title or author: lo
Holes by Louis Sachar - 0 of 2 on the shelf
The Giver by Lois Lowry - 4 of 4 on the shelf

===== LIBRARY =====
1. List books
2. Check out a book
3. Return a book
4. Search
5. Save
6. Quit
Choose an option (1-6): 4
Search title or author: zzz
No books match "zzz".

===== LIBRARY =====
1. List books
2. Check out a book
3. Return a book
4. Search
5. Save
6. Quit
Choose an option (1-6): 5
Saved books.csv

===== LIBRARY =====
1. List books
2. Check out a book
3. Return a book
4. Search
5. Save
6. Quit
Choose an option (1-6): 6
Goodbye!
```

**Hints**
- The methods do the checking. `check_out_book` just calls `book.check_out()` and prints one message if it returns True and another if it returns False.
- `choose_book` is shared by options 2 and 3, with a different prompt for each.
- Searching with `or`: `if text.lower() in book.title.lower() or text.lower() in book.author.lower():`
- `lo` matches both books with an author named `Lo...`, and `Holes` does not contain `lo` (it has `ol`).
- **Make a backup copy of `books.csv` before you test Save.**

**Test these too:** check out the last copy of a book, then try again (should say every copy is checked out). Rename `books.csv` and try options 1–3.

---

## Build 11D: Gradebook Manager
Build a menu program that keeps `Student` objects, each with a **list** of scores. Print a sorted report and save to two files.

**Data file:** [gradebook.csv](gradebook.csv) — the scores for each student are separated by spaces.
```
Name,Scores
Avery,88 92 79
Blake,95 67 84
Casey,72 85 90 96
```

**Requirements**
1. Header comment. Constants: `FILE_NAME = "gradebook.csv"`, `REPORT_NAME = "gradebook_report.txt"`.
2. A `Student` class:
   - constructor with `name` and `scores` (a list of ints)
   - `add_score(score)` appends one score
   - `average()` returns the average, or 0.0 if there are no scores
   - `letter()` returns A (90+), B (80+), C (70+), D (60+), or F, based on the average
3. At the start, load the file. Split each line on the comma, then split the scores part on spaces and turn each one into an `int`. Print `Loaded 3 students from gradebook.csv`, or `No gradebook.csv found. Starting an empty gradebook.`
4. The menu:
   ```
   ===== GRADEBOOK =====
   1. Add a student
   2. Add a score
   3. Show report
   4. Search
   5. Save
   6. Quit
   ```
   prompt: `Choose an option (1-6): `
5. **Add a student:** `New student name: `. If the name already exists (ignore capitals), print `That student already exists.` Otherwise add the student with no scores and print `Added <name>.`
6. **Add a score:** list the students numbered, ask `Choose a student (1-N): ` and `Score (0-100): `, add it, and print `Added <score> for <name>. New average: X.X`
7. **Show report:** sorted by average, highest first: Rank 6 wide, Name 10 wide, Average 9 wide (1 decimal), Grade 7 wide, then the number of scores. A line of 38 dashes.
8. **Search:** `Search for: ` — print every student whose name contains the text (ignore capitals) as `Avery: 88 92 79 (average 86.3, B)`. If none, print `No students match "<text>".`
9. **Save:** write `gradebook.csv` (same format as the original) and `gradebook_report.txt` (`GRADEBOOK REPORT`, `Report created: <date and time>`, a blank line, then the report). Use `try`/`except OSError`. Print `Saved gradebook.csv and gradebook_report.txt`.
10. **Quit:** if anything changed since the last save, ask `You have unsaved changes. Save before quitting? (y/n): ` and save if yes. Then print `Goodbye!`
11. Input / Processing / Output comments.

**Sample run**
```
Loaded 3 students from gradebook.csv

===== GRADEBOOK =====
1. Add a student
2. Add a score
3. Show report
4. Search
5. Save
6. Quit
Choose an option (1-6): 3
Rank  Name      Average  Grade  Scores
--------------------------------------
1     Avery     86.3     B      3
2     Casey     85.8     B      4
3     Blake     82.0     B      3

===== GRADEBOOK =====
1. Add a student
2. Add a score
3. Show report
4. Search
5. Save
6. Quit
Choose an option (1-6): 1
New student name: casey
That student already exists.

===== GRADEBOOK =====
1. Add a student
2. Add a score
3. Show report
4. Search
5. Save
6. Quit
Choose an option (1-6): 1
New student name: Devon
Added Devon.

===== GRADEBOOK =====
1. Add a student
2. Add a score
3. Show report
4. Search
5. Save
6. Quit
Choose an option (1-6): 2
1. Avery
2. Blake
3. Casey
4. Devon
Choose a student (1-4): 4
Score (0-100): 91
Added 91 for Devon. New average: 91.0

===== GRADEBOOK =====
1. Add a student
2. Add a score
3. Show report
4. Search
5. Save
6. Quit
Choose an option (1-6): 2
1. Avery
2. Blake
3. Casey
4. Devon
Choose a student (1-4): 4
Score (0-100): 105
Please enter a whole number from 0 to 100.
Score (0-100): 88
Added 88 for Devon. New average: 89.5

===== GRADEBOOK =====
1. Add a student
2. Add a score
3. Show report
4. Search
5. Save
6. Quit
Choose an option (1-6): 3
Rank  Name      Average  Grade  Scores
--------------------------------------
1     Devon     89.5     B      2
2     Avery     86.3     B      3
3     Casey     85.8     B      4
4     Blake     82.0     B      3

===== GRADEBOOK =====
1. Add a student
2. Add a score
3. Show report
4. Search
5. Save
6. Quit
Choose an option (1-6): 4
Search for: a
Avery: 88 92 79 (average 86.3, B)
Blake: 95 67 84 (average 82.0, B)
Casey: 72 85 90 96 (average 85.8, B)

===== GRADEBOOK =====
1. Add a student
2. Add a score
3. Show report
4. Search
5. Save
6. Quit
Choose an option (1-6): 6
You have unsaved changes. Save before quitting? (y/n): y
Saved gradebook.csv and gradebook_report.txt
Goodbye!
```

**`gradebook_report.txt`** (exact except the date and time)
```
GRADEBOOK REPORT
Report created: 2026-11-09 08:15

Rank  Name      Average  Grade  Scores
--------------------------------------
1     Devon     89.5     B      2
2     Avery     86.3     B      3
3     Casey     85.8     B      4
4     Blake     82.0     B      3
```

**Hints**
- `"88 92 79".split(" ")` gives `["88", "92", "79"]`. Loop over that and append `int(text)` to a list.
- To save the scores back, turn each score into a string and use `" ".join(...)`.
- `print_report(students, out_file=None)` serves both option 3 and the report file, the same way as Step 9.
- Keep an `unsaved` variable in `main`. Set it to True after a student or score is added, and False after a save.
- Have `add_student` and `add_score` return True when they change something, so `main` knows when to set `unsaved`.
- Sorting objects: `get_average(student)` returns `student.average()`, then `sorted(students, key=get_average, reverse=True)`.
- **Make a backup copy of `gradebook.csv` before you test Save.**

**Test these too:** quit right after loading (no unsaved-changes question), and answer `n` to the unsaved-changes question (the file should not change).

---

## Turn it in
1. In your `bpaPrep` repo, make a folder named `python_builds` (one folder for all builds).
2. Save the builds as `build11A.py`, `build11B.py`, `build11C.py`, and `build11D.py`. Put any data files the build uses next to the program.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `Member` class with constructor and `add_points(amount)`
- [ ] Members stored as a list of `Member` objects
- [ ] Each menu option is its own function, each with a Purpose / Parameters / Returns comment
- [ ] Leaderboard sorts a copy; option 2's order doesn't change
- [ ] Duplicate check and search both ignore case
- [ ] Missing file and bad menu choices don't crash
- [ ] Save writes both files with try/except
- [ ] Pushed to `bpaPrep/python_builds`
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] I tried to crash each program with letters, blanks, and out-of-range numbers, and it never crashed
- [ ] Each class has a constructor and the methods listed, with comments
- [ ] Each menu option is its own function
- [ ] Every `try`/`except` names its error and has a comment
- [ ] Pushed to `bpaPrep/python_builds`, with the data and output files
