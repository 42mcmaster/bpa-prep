# Step 11 — Menu Program with a Class (Java)

**What you'll build:** Club Manager — a menu program that loads club members from a file, lets you add members, record points, show a leaderboard, search, and save.
**Time:** about two class periods (3-4 hours). This step puts everything together.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Classes and objects](#classes-and-objects)
- [Writing a class: fields](#writing-a-class-fields)
- [The constructor](#the-constructor)
- [Instance methods and getters](#instance-methods-and-getters)
- [Where to put the class in your file](#where-to-put-the-class-in-your-file)
- [A complete example with one class](#a-complete-example-with-one-class)
- [A list of objects](#a-list-of-objects)
- [Sorting objects by a field](#sorting-objects-by-a-field)
- [Searching a list, ignoring case](#searching-a-list-ignoring-case)
- [The menu loop](#the-menu-loop)
- [Each menu option is its own method](#each-menu-option-is-its-own-method)
- [Loading at the start and saving at the end](#loading-at-the-start-and-saving-at-the-end)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Club Manager](#the-challenge-club-manager)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What a class and an object are
- Fields, `private`, a constructor, and `this`
- Instance methods (no `static`) and getter methods
- The simplest legal way to put a second class in the same `.java` file
- An `ArrayList` of objects
- Sorting objects by a field, and sorting a copy so the original order is kept
- Case-insensitive search
- A menu loop with `switch`, where each option is its own method
- Loading a CSV into objects at the start and saving them back out
- Reusing your Step 10 input methods

---

## Classes and objects

Up to now, you kept related data in **separate** variables or parallel arrays: `names[i]` and `scores[i]`. That works, but it is easy for them to get out of sync (Step 8's sort had to swap both).

A **class** lets you make your own data type that keeps related data **together**.

- A **class** is a blueprint: "every book has a title and a page count, and you can read pages of it."
- An **object** is one thing built from the blueprint: *this* book, titled "Hatchet", with 192 pages.
- You can make as many objects from one class as you want. Each one has its own copy of the data.

You have already used classes made by other people: `String`, `Scanner`, `Random`, `ArrayList`. When you wrote `new Scanner(System.in)`, you made a `Scanner` **object**. Now you will write your own class.

---

## Writing a class: fields

**Fields** are the variables that every object of the class has. They go inside the class, outside any method:

```java
class Book {
    private String title;
    private int pages;
    private int pagesRead;
}
```

| What you type | What it means |
|---|---|
| `class Book {` | A new class named `Book` (PascalCase, like all class names). |
| `private String title;` | Every `Book` object has its own `title`. |
| `private` | Only code **inside** the `Book` class can touch this field directly. Other code must use the class's methods. This protects the data (this idea is called **encapsulation**). |

Notice the fields are **not** `static`. A `static` variable belongs to the class and is shared (like `TAX_RATE`). A normal field belongs to **each object** - every book has its own title.

---

## The constructor

A **constructor** is a special method that runs when you create an object with `new`. Its job is to give the fields their starting values.

```java
class Book {
    private String title;
    private int pages;
    private int pagesRead;

    // Constructor: same name as the class, no return type (not even void)
    Book(String title, int pages) {
        this.title = title;
        this.pages = pages;
        this.pagesRead = 0;
    }
}
```

Creating objects:

```java
Book first = new Book("Hatchet", 192);
Book second = new Book("Holes", 233);
```

| Part | Meaning |
|---|---|
| `Book(String title, int pages)` | The constructor. **Same name as the class**, and **no return type**. |
| `new Book("Hatchet", 192)` | Make a new `Book` object and run the constructor with these arguments. |
| `this.title` | **This object's** `title` field. |
| `title` (alone) | The **parameter** named `title`. |
| `this.title = title;` | Copy the parameter into this object's field. |

The parameters have the same names as the fields, which is common. `this.` tells Java you mean the field. If you wrote `title = title;`, you would just copy the parameter onto itself, and the field would stay empty (`null`).

---

## Instance methods and getters

Methods that belong to each object are **instance methods**. They do **not** use `static`, because they work on one particular object's data.

```java
class Book {
    private String title;
    private int pages;
    private int pagesRead;

    Book(String title, int pages) {
        this.title = title;
        this.pages = pages;
        this.pagesRead = 0;
    }

    /*
     * Purpose: get the title.
     * Parameters: none
     * Returns: the book's title
     */
    String getTitle() {
        return title;
    }

    /*
     * Purpose: get the total number of pages.
     * Parameters: none
     * Returns: the page count
     */
    int getPages() {
        return pages;
    }

    /*
     * Purpose: get how many pages have been read.
     * Parameters: none
     * Returns: pages read so far
     */
    int getPagesRead() {
        return pagesRead;
    }

    /*
     * Purpose: record that more pages were read.
     * Parameters: amount - how many pages were read
     * Returns: nothing (void)
     */
    void readPages(int amount) {
        pagesRead = pagesRead + amount;
    }

    /*
     * Purpose: calculate how much of the book is finished.
     * Parameters: none
     * Returns: the percent read, 0 to 100
     */
    double percentDone() {
        return 100.0 * pagesRead / pages;
    }
}
```

Calling an instance method uses a **dot** after the object:

```java
Book first = new Book("Hatchet", 192);
first.readPages(48);
System.out.println(first.getTitle() + ": " + first.getPagesRead() + " pages read");
System.out.printf("%.1f%% done%n", first.percentDone());
```

Output:

```
Hatchet: 48 pages read
25.0% done
```

A **getter** is a method that just returns a field (`getTitle()`). Because the fields are `private`, other code reads them through getters. The 2024 Java regional graded "gets all of student object information using get methods."

Inside an instance method you can use the fields directly (`pagesRead`), because the method already knows which object it is working on - the one before the dot.

---

## Where to put the class in your file

Java's rule: **a `.java` file can have only one `public` class, and it must match the file name.** You have three simple, legal options for adding a second class:

**Option 1 (we use this): a second, non-public class in the same file.** Leave off the word `public`:

```java
// File: Step11.java

class Member {          // not public - allowed in Step11.java
    ...
}

public class Step11 {   // the one public class, matches the file name
    public static void main(String[] args) { ... }
}
```

This keeps everything in **one file**, which is the safest thing at BPA (all your code is in the one `.java` file the graders open). The 2024 Java regional gave students a file with the second class "located immediately below" the main class in the same file - exactly this pattern.

**Option 2: a static nested class** inside the main class: `static class Member { ... }` written inside `public class Step11 { ... }`. Also legal. It works the same for our purposes.

**Option 3: a separate file** `Member.java` with `public class Member`, in the same folder. Common in bigger programs. At BPA, this means two files must both be in your Contestant ID folder.

If you write `public class Member` inside `Step11.java`, you get:

```
error: class Member is public, should be declared in a file named Member.java
```

---

## A complete example with one class

```java
public class BookDemo {

    /*
     * Purpose: run a short demo of the Book class.
     * Parameters: args - not used
     * Returns: nothing (void)
     */
    public static void main(String[] args) {
        // Processing: make two objects from the same class
        Book first = new Book("Hatchet", 192);
        Book second = new Book("Holes", 233);

        // Processing: each object keeps its own data
        first.readPages(96);
        second.readPages(20);
        second.readPages(30);

        // Output
        System.out.printf("%s: %.1f%% done%n", first.getTitle(), first.percentDone());
        System.out.printf("%s: %.1f%% done%n", second.getTitle(), second.percentDone());
    }
}

/*
 * Book: one book, its length, and how much has been read.
 * Not public, so it can be in BookDemo.java.
 */
class Book {
    private String title;
    private int pages;
    private int pagesRead;

    /*
     * Constructor: make a book with nothing read yet.
     * Parameters: title - the book's title; pages - total pages
     */
    Book(String title, int pages) {
        this.title = title;
        this.pages = pages;
        this.pagesRead = 0;
    }

    /* Purpose: get the title. Parameters: none. Returns: the title */
    String getTitle() {
        return title;
    }

    /* Purpose: record pages read. Parameters: amount - pages read. Returns: nothing */
    void readPages(int amount) {
        pagesRead = pagesRead + amount;
    }

    /* Purpose: percent finished. Parameters: none. Returns: 0 to 100 */
    double percentDone() {
        return 100.0 * pagesRead / pages;
    }
}
```

Output:

```
Hatchet: 50.0% done
Holes: 21.5% done
```

The second class can go above or below the public class. Both work.

---

## A list of objects

An `ArrayList` can hold objects of your class, just like it holds `String` or `Integer`:

```java
ArrayList<Book> shelf = new ArrayList<>();
shelf.add(new Book("Hatchet", 192));
shelf.add(new Book("Holes", 233));
shelf.add(new Book("Wonder", 310));

// Output: loop through the objects and call their methods
for (int i = 0; i < shelf.size(); i++) {
    Book b = shelf.get(i);
    System.out.println((i + 1) + ". " + b.getTitle());
}
```

Output:

```
1. Hatchet
2. Holes
3. Wonder
```

`shelf.get(1)` gives you the `Book` object at index 1, so `shelf.get(1).readPages(10);` changes that book. The object in the list **is** the object you changed - there is no copy.

Now each item keeps its name and its numbers **together**. No parallel arrays to keep in sync.

---

## Sorting objects by a field

`Collections.sort` doesn't know how to sort `Book` objects - by title? by pages? You have to tell it **how to compare two objects**. The shortest way is with `list.sort(...)` and a **lambda**:

```java
shelf.sort((a, b) -> b.getPagesRead() - a.getPagesRead());
```

Read it like this:
- `(a, b) ->` means "given two books, `a` and `b`..."
- `b.getPagesRead() - a.getPagesRead()` is the rule. Java uses the sign of the answer:
  - **negative**: `a` goes first
  - **positive**: `b` goes first
  - **zero**: keep them in their current order

`b - a` puts the **bigger** value first (highest to lowest). `a - b` would put the smaller first (lowest to highest).

| Sort rule | Order |
|---|---|
| `(a, b) -> a.getPages() - b.getPages()` | Fewest pages first |
| `(a, b) -> b.getPages() - a.getPages()` | Most pages first |
| `(a, b) -> a.getTitle().compareToIgnoreCase(b.getTitle())` | Alphabetical by title |

`list.sort` is **stable**: when two items tie, they stay in the order they were in. That gives a clear tie rule.

**Sort a copy** when you need to keep the original order (the challenge needs this - option 2 lists members in the order they were added):

```java
ArrayList<Book> sorted = new ArrayList<>(shelf);   // copy the list (same objects, new list)
sorted.sort((a, b) -> b.getPagesRead() - a.getPagesRead());
// shelf is still in its original order
```

If you would rather not use a lambda, you can write the Step 8 selection sort on the copy, comparing `getPoints()` and swapping list items with `get` and `set`. Either is fine - comment which one you used.

---

## Searching a list, ignoring case

To find every item whose name **contains** some text, ignoring upper and lower case, lowercase **both** sides and use `contains` (Step 7):

```java
String search = "HO";
int found = 0;
for (Book b : shelf) {
    if (b.getTitle().toLowerCase().contains(search.toLowerCase())) {
        System.out.println(b.getTitle());
        found++;
    }
}
if (found == 0) {
    System.out.println("No books match \"" + search + "\".");
}
```

Output with the shelf above:

```
Holes
```

The counter `found` tells you afterward whether anything matched. `\"` puts a quote mark in the message (Step 1).

To check whether a name **already exists** (ignoring case), use `equalsIgnoreCase` instead of `contains`.

---

## The menu loop

A menu program shows a list of options, gets a choice, does that option, and repeats until the user picks Quit.

```java
int choice = 0;
while (choice != 4) {
    showMenu();
    choice = getInt("Choose an option (1-4): ", 1, 4);
    switch (choice) {
        case 1:
            addBook(shelf);
            break;
        case 2:
            readPages(shelf);
            break;
        case 3:
            showProgress(shelf);
            break;
        case 4:
            System.out.println("Goodbye!");
            break;
    }
}
```

- The loop **ends by its condition** (`choice != 4`) - no `break` out of the loop. The `break`s here belong to the `switch` (Step 3).
- `getInt` (Step 10) guarantees `choice` is 1-4, so you don't need a `default` case. You can add one anyway.
- `showMenu()` is a small method that prints the menu lines.

---

## Each menu option is its own method

Each option gets its own `static` method that takes the list as a parameter. `main` stays short and easy to read, and graders can find each feature.

```java
/*
 * Purpose: menu option 2 - record pages read for one book.
 * Parameters: shelf - the list of books
 * Returns: nothing (void)
 */
static void readPages(ArrayList<Book> shelf) {
    // Processing: nothing to do if the list is empty
    if (shelf.isEmpty()) {
        System.out.println("No books yet.");
        return;                              // leave the method early
    }

    // Output: numbered list
    for (int i = 0; i < shelf.size(); i++) {
        System.out.println((i + 1) + ". " + shelf.get(i).getTitle());
    }

    // Input: which book and how many pages (Step 10 methods)
    int choice = getInt("Choose a book (1-" + shelf.size() + "): ", 1, shelf.size());
    int amount = getInt("Pages read (1-500): ", 1, 500);

    // Processing: the user's 1 is index 0
    Book chosen = shelf.get(choice - 1);
    chosen.readPages(amount);

    // Output
    System.out.println(chosen.getTitle() + " now has " + chosen.getPagesRead() + " pages read.");
}
```

Things to notice:
- `return;` in a `void` method ends the method early. Here it handles the empty-list case.
- The prompt is built with the real size: `"Choose a book (1-" + shelf.size() + "): "`.
- The user types numbers starting at 1, but list indexes start at 0, so use `choice - 1`.

---

## Loading at the start and saving at the end

Combine Step 9 (files) with your class. Loading turns each CSV line into an **object**:

```java
// Input: one line like "Hatchet,192" becomes one Book object
String[] parts = line.split(",");
shelf.add(new Book(parts[0].trim(), Integer.parseInt(parts[1].trim())));
```

Saving writes each object back out as one line (try-with-resources and `IOException` from Step 9):

```java
writer.print("Title,Pages\n");                      // header line first
for (Book b : shelf) {
    writer.print(b.getTitle() + "," + b.getPages() + "\n");
}
```

Writing a method that **returns** the list (`static ArrayList<Member> loadMembers()`) keeps `main` clean: `ArrayList<Member> members = loadMembers();`.

You can open **two** writers in one try-with-resources by separating them with a semicolon:

```java
try (PrintWriter csv = new PrintWriter(new FileWriter("a.csv"));
     PrintWriter report = new PrintWriter(new FileWriter("b.txt"))) {
    ...
}
```

Both are closed automatically.

---

## Common mistakes

**1. Two public classes in one file**
- Error: `error: class Member is public, should be declared in a file named Member.java`
- Fix: remove `public` from the second class.

**2. `static` on fields or instance methods**
- Looks like: `static String name;` in `Member`. Every member ends up with the **same** name (the last one loaded).
- Fix: fields and instance methods in your class are **not** `static`.

**3. Forgetting `this.` in the constructor**
- Looks like: `name = name;` - every member's name prints as `null`.
- Fix: `this.name = name;`

**4. Giving the constructor a return type**
- Looks like: `void Member(String name, int points)` - Java treats it as a normal method, and `new Member("Avery", 120)` fails.
- Error: `error: constructor Member in class Member cannot be applied to given types;`
- Fix: no return type on a constructor.

**5. Reading a private field from outside the class**
- Looks like: `members.get(0).points` in `Step11`.
- Error: `error: points has private access in Member`
- Fix: use the getter: `members.get(0).getPoints()`.

**6. Sorting the real list**
- Looks like: after showing the leaderboard, option 2's numbered list is in a different order.
- Fix: sort a copy: `new ArrayList<>(members)`.

**7. Off-by-one when picking from the list**
- Looks like: choosing 2 changes the third member, or choosing the last number crashes with `IndexOutOfBoundsException`.
- Fix: `members.get(choice - 1)`.

**8. Printing an object directly**
- Looks like: `System.out.println(member);` prints `Member@1b6d3586`.
- Fix: print the fields with getters. (Or write a `toString()` method in the class - optional.)

---

## How this shows up at BPA

- The 2024 Java regional had a provided class and asked students to create objects, store them "in a data structure," and print them "using get methods." Source code review points included "class construction."
- BPA C++ and C# events in 2026 were menu programs where **each option is its own function**. This is the shape most regional tests take.
- Loading data at the start and writing a report at the end, with try/catch, covers the file and exception handling points.
- Reusing your printed `getText` and `getInt` methods saves a lot of time.

---

## The challenge: Club Manager

Build a menu program that manages club members and their points.

**Data file:** [`members.csv`](members.csv) is in this step folder. Put it in your `java_step11` folder, next to `Step11.java`.

```
Name,Points
Avery,120
Blake,95
Casey,140
```

**Requirements**
1. Header comment.
2. A `Member` class with a name, points, a constructor, and an `addPoints(amount)` method.
3. At start, load `members.csv` into a list of `Member` objects (in Java: an `ArrayList<Member>`) and print `Loaded 3 members from members.csv`. If it's missing print `No members.csv found. Starting with an empty list.`
4. Show this menu and repeat until Quit. Use `getInt` for the choice (1–6):
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
5. **Add member:** `New member name: ` (getText). If the name already exists (ignore case) print `That member already exists.` Otherwise add with 0 points and print `Added <name>.`
6. **Record points:** if there are no members print `No members yet.` Otherwise list them numbered (`1. Avery (120)`), ask `Choose a member (1-N): ` and `Points to add (1-50): ` (getInt), then print `<name> now has <points> points.`
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
9. **Save:** write `members.csv` (header + one line per member) and `club_report.txt` (`CLUB REPORT`, `Report created: yyyy-MM-dd HH:mm`, a blank line, the leaderboard). Use try/catch. Print `Saved members.csv and club_report.txt`.
10. **Quit:** print `Goodbye!`
11. Each menu option is its own method. Method comments and Input / Processing / Output comments.

**Sample run (exact):**
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
(A blank line prints before each menu. Showing the leaderboard must not reorder the members list — sort a copy — so option 2's numbered list stays in the order loaded/added. The search for "a" matches all four because every name contains an "a" or "A".)

**Hints**
- One file, `Step11.java`: a non-public `class Member` and the `public class Step11`.
- `Member` needs: two `private` fields, a constructor `Member(String name, int points)`, `getName()`, `getPoints()`, and `addPoints(int amount)`.
- Copy `getText` and `getInt` from Step 10.
- Suggested methods in `Step11`: `loadMembers()`, `showMenu()`, `addMember(members)`, `recordPoints(members)`, `showLeaderboard(members)`, `searchMembers(members)`, `saveAll(members)`, and a `buildLeaderboard(members)` that returns the leaderboard text so both option 3 and the report can use it (the Step 9 idea).
- Leaderboard row format: `String.format("%-6d%-10s%d\n", rank, name, points)`.
- Test **Save** in a copy of your folder, or keep a spare copy of `members.csv` - saving replaces the file.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step11`.
2. Put `Step11.java`, `members.csv`, and the `club_report.txt` your program made in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 11 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `Member` class with private fields, a constructor, getters, and `addPoints`
- [ ] Members stored in an `ArrayList<Member>`
- [ ] Missing `members.csv` handled with the exact message
- [ ] Each menu option is its own method, each with a purpose / parameters / returns comment
- [ ] Leaderboard sorts a copy; option 2's list keeps the original order
- [ ] Search ignores case; duplicate check ignores case
- [ ] Save writes both files inside a try/catch (with a comment saying what it catches)
- [ ] Pushed to `bpaPrep/java_step11`
