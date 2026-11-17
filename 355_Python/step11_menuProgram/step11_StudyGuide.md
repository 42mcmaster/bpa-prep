# Step 11 Study Guide — Menu Programs and Classes (Python)

This guide covers everything for Step 11, with full explanations and commented code. Start with the [Step 11 lesson](step11_Lesson.md), then do the [Step 11 Practice](step11_Practice.md). Come back here when you need more detail. Build 11A and the other [Step 11 builds](../bpaBuilds/build11_menuProgram.md) use these skills too.

**Print this.** BPA lets you bring printed notes and printed code into the Python event.

## Table of Contents
- [What this guide covers](#what-this-guide-covers)
- [The menu loop](#the-menu-loop)
- [One function per menu option](#one-function-per-menu-option)
- [What a class is](#what-a-class-is)
- [Writing a class](#writing-a-class)
- [Methods](#methods)
- [Printing an object with str](#printing-an-object-with-str)
- [A list of objects](#a-list-of-objects)
- [Sorting objects by a field](#sorting-objects-by-a-field)
- [Searching ignoring upper and lower case](#searching-ignoring-upper-and-lower-case)
- [Loading and saving objects in a CSV file](#loading-and-saving-objects-in-a-csv-file)
- [Putting it together: a small menu program](#putting-it-together-a-small-menu-program)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [Quick reference](#quick-reference)

## What this guide covers
- How to run a menu until the user picks Quit
- How to put each menu option in its own function and pass the data to it
- What a class and an object are
- How to write a class with a constructor (`__init__`), attributes, and methods
- What `self` means
- How to keep many objects in a list and loop over them
- How to sort a list of objects by one of their fields without changing the original list
- How to search names without caring about upper/lower case
- How to load objects from a CSV file at the start and save them at the end

## The menu loop

A menu program shows a list of choices, does the one the user picks, then shows the menu again — until they pick Quit. It's a `while` loop (Step 4) with an `if`/`elif` chain (Step 3) inside, and `get_int` (Step 10) for the choice.

<!-- input: 1|5|2|3 -->
```python
def get_int(prompt, low, high):
    """Purpose: ask until the answer is a whole number from low to high.
    Parameters: prompt (str), low (int), high (int)
    Returns: the number (int)
    """
    while True:
        answer = input(prompt)
        # try/except catches ValueError: int() fails on letters, decimals, blanks
        try:
            number = int(answer)
            if number >= low and number <= high:
                return number
        except ValueError:
            pass
        print(f"Please enter a whole number from {low} to {high}.")

def main():
    """Purpose: run a simple 3-option menu. Parameters: none. Returns: nothing"""
    choice = 0
    while choice != 3:                       # 3 is Quit
        print()
        print("--- LIGHTS ---")
        print("1. Turn on")
        print("2. Turn off")
        print("3. Quit")
        choice = get_int("Choose (1-3): ", 1, 3)
        if choice == 1:
            print("Lights on.")
        elif choice == 2:
            print("Lights off.")
    print("Bye!")

if __name__ == "__main__":
    main()
```

It prints (user typed `1`, `5`, `2`, `3`):

```text

--- LIGHTS ---
1. Turn on
2. Turn off
3. Quit
Choose (1-3): 1
Lights on.

--- LIGHTS ---
1. Turn on
2. Turn off
3. Quit
Choose (1-3): 5
Please enter a whole number from 1 to 3.
Choose (1-3): 2
Lights off.

--- LIGHTS ---
1. Turn on
2. Turn off
3. Quit
Choose (1-3): 3
Bye!
```

Notes:
- `choice = 0` before the loop makes sure the loop runs the first time.
- The Quit option doesn't need its own `elif` — when `choice` is 3, nothing in the chain matches, the loop condition is False, and the loop ends.
- Because `get_int` only returns 1–3, you never need an "invalid choice" `else`.
- The `print()` at the top of the loop makes the blank line before each menu.

## One function per menu option

When each option has real work to do, give each one its own function. The menu loop then only **decides** which function to call. This keeps `main` short and is what BPA asks for ("each menu option its own function").

The options all need the same data (the list of members), so **pass it in** as a parameter:

```python
if choice == 1:
    add_member(members)
elif choice == 2:
    record_points(members)
```

Remember from Step 6: a function gets the **same list**, not a copy. So when `add_member` appends to `members`, the change is still there when the menu comes back around.

A short `show_menu()` function that only prints the menu is a nice touch too.

## What a class is

So far, data about one thing has been spread across parallel lists: `names[2]` and `scores[2]`. A **class** lets you bundle all the data about one thing into a single **object**.

- A **class** is a blueprint. It says what data each object has and what it can do. Example: `Book`.
- An **object** is one thing made from that blueprint. Example: the book *Hatchet* with 3 copies. You can make as many objects from one class as you want.
- An **attribute** is a piece of data stored in the object: `title`, `copies`.
- A **method** is a function that belongs to the class: `check_out()`.

| Parallel lists (Step 8) | Class |
|---|---|
| `titles[2]`, `copies[2]` | `books[2].title`, `books[2].copies` |
| sort → must swap in every list | sort → the object moves as one piece |
| add a field → add a whole new list | add a field → add one line to the class |

## Writing a class

```python
class Book:
    """One library book with a title and a number of copies on the shelf."""

    def __init__(self, title, copies):
        """Purpose: constructor - runs when a new Book is made.
        Parameters: title (str), copies (int)
        Returns: nothing (Python gives back the new object automatically)
        """
        self.title = title          # attribute: store the title in this object
        self.copies = copies        # attribute: store the copies in this object

# Make two Book objects
first_book = Book("Hatchet", 3)
second_book = Book("Holes", 1)

# Read their attributes with a dot
print(first_book.title, first_book.copies)
print(second_book.title, second_book.copies)
```

It prints:

```text
Hatchet 3
Holes 1
```

Line by line:

| Code | What it means |
|---|---|
| `class Book:` | Start a class named `Book`. Class names use **PascalCase** (each word capitalized) — the one exception to snake_case in Python. |
| `def __init__(self, title, copies):` | The **constructor**. It runs automatically each time you make a new `Book`. `__init__` has **two underscores** on each side. |
| `self` | The object being built (or used). It's always the first parameter of a method. You **don't** pass it yourself — Python does. |
| `self.title = title` | Make an attribute named `title` on this object and store the parameter in it. |
| `Book("Hatchet", 3)` | Make a new object. Python calls `__init__` with `self` = the new object, `title` = `"Hatchet"`, `copies` = 3. |
| `first_book.title` | Read an attribute with **object.attribute**. |

**What is `self`, really?** When you write `first_book.title`, Python looks inside the `first_book` object. Inside the class, the code doesn't know which object it's working on, so it uses `self` to mean "whichever object this is." When `Book("Hatchet", 3)` runs, `self` is the new Hatchet object. When `Book("Holes", 1)` runs, `self` is the Holes object.

In Java and C#, the same word is `this`, and they don't make you write it in the parameter list. Python does.

## Methods

A **method** is a function inside the class. It uses `self` to read and change that object's attributes.

```python
class Book:
    """One library book with a title and a number of copies on the shelf."""

    def __init__(self, title, copies):
        """Purpose: constructor. Parameters: title (str), copies (int). Returns: nothing"""
        self.title = title
        self.copies = copies

    def check_out(self):
        """Purpose: take one copy off the shelf if there is one.
        Parameters: none (self is the book)
        Returns: True if a copy was checked out, False if none were left
        """
        if self.copies > 0:
            self.copies = self.copies - 1
            return True
        return False

    def return_copies(self, amount):
        """Purpose: put copies back on the shelf.
        Parameters: amount (int) - how many came back
        Returns: nothing
        """
        self.copies = self.copies + amount

book = Book("Holes", 1)
print(book.check_out())       # 1 copy -> 0
print(book.check_out())       # none left
book.return_copies(2)
print(book.copies)
```

It prints:

```text
True
False
2
```

You call a method with **object.method(arguments)**. Python passes the object in as `self` automatically, so `book.return_copies(2)` matches `def return_copies(self, amount)` with `amount` = 2.

Build 11A's `Member` class has an `add_points(amount)` method — the same shape as `return_copies`.

## Printing an object with str

If you `print()` an object, you get something unhelpful like `<__main__.Book object at 0x000001F2...>`. You can teach Python how to show your object by adding a `__str__` method that **returns** a string:

```python
class Book:
    def __init__(self, title, copies):
        self.title = title
        self.copies = copies

    def __str__(self):
        """Purpose: the text shown when the object is printed.
        Parameters: none
        Returns: a description of the book (str)
        """
        return f"{self.title} ({self.copies} on the shelf)"

print(Book("Hatchet", 3))
```

It prints:

```text
Hatchet (3 on the shelf)
```

Build 11A (Club Manager) doesn't require `__str__`, but BPA tests have (the 2024 regional asked for a "toString method" — Python's `__str__` is the same idea). The timed build practice Task C uses it too.

## A list of objects

Objects go in a list like anything else. A for-each loop gives you one object at a time:

```python
class Book:
    def __init__(self, title, copies):
        self.title = title
        self.copies = copies

# Processing: a list of Book objects
shelf = []
shelf.append(Book("Hatchet", 3))
shelf.append(Book("Holes", 1))
shelf.append(Book("Wonder", 4))

# Output: numbered list, then a total
total = 0
for i in range(len(shelf)):
    print(f"{i + 1}. {shelf[i].title} ({shelf[i].copies})")
    total = total + shelf[i].copies
print(f"Total copies: {total}")
```

It prints:

```text
1. Hatchet (3)
2. Holes (1)
3. Wonder (4)
Total copies: 8
```

When the user picks number 2 from that list, the object is `shelf[2 - 1]` — subtract 1 to get the index (Step 6).

## Sorting objects by a field

`sorted()` (Step 6) can sort objects, but it needs to know **which field** to sort by. You tell it with `key=`: give it the **name of a function** that takes one object and returns the value to sort on.

```python
class Book:
    def __init__(self, title, copies):
        self.title = title
        self.copies = copies

def get_copies(book):
    """Purpose: tell sorted() what to sort by.
    Parameters: book (Book)
    Returns: the number of copies (int)
    """
    return book.copies

shelf = [Book("Hatchet", 3), Book("Holes", 1), Book("Wonder", 4)]

# Processing: sorted() makes a NEW list; shelf keeps its order
most_first = sorted(shelf, key=get_copies, reverse=True)

# Output
for book in most_first:
    print(book.title, book.copies)
print("Original first book:", shelf[0].title)
```

It prints:

```text
Wonder 4
Hatchet 3
Holes 1
Original first book: Hatchet
```

Notice `key=get_copies` has **no parentheses**. You're handing `sorted` the function itself, so it can call it on each book. With parentheses, you'd be calling it once yourself, which is an error.

You'll also see this written with a **lambda** — a tiny function with no name, written right in place: `sorted(shelf, key=lambda book: book.copies, reverse=True)`. It does the same thing. Use whichever you understand; the named function is easier to read and comment.

**Why `sorted()` and not `.sort()`?** Build 11A's "Record points" option lists members in the order they were loaded and added. If "Show leaderboard" used `members.sort(...)`, the original list would be reordered and option 2's numbers would change. `sorted()` leaves the original alone (Step 6, [Copies and the same list under two names](../step06_listsAndArrays/step06_StudyGuide.md#copies-and-the-same-list-under-two-names)).

If two objects have the same value, `sorted()` keeps them in their original order.

## Searching ignoring upper and lower case

To match `ha`, `HA`, or `Ha` in "Hatchet": lowercase **both** sides, then use `in` (Step 7).

<!-- input: o -->
```python
class Book:
    def __init__(self, title, copies):
        self.title = title
        self.copies = copies

shelf = [Book("Hatchet", 3), Book("Holes", 1), Book("Wonder", 4)]

# Input
text = input("Search for: ")

# Processing and Output: count matches so we know if there were none
found = 0
for book in shelf:
    if text.lower() in book.title.lower():
        print(f"{book.title} - {book.copies} copies")
        found = found + 1
if found == 0:
    print(f'No books match "{text}".')
```

It prints (user typed `o`):

```text
Search for: o
Holes - 1 copies
Wonder - 4 copies
```

The single quotes around the f-string in the last `print` let you put double quotes inside it without `\"` (Step 1).

**Checking for a duplicate** is the same idea with `==` instead of `in`: loop through the list and compare `name.lower() == member.name.lower()`. If you find a match, print the message and `return` right away so nothing gets added.

## Loading and saving objects in a CSV file

This is Step 9 with objects. **Loading:** split each line and pass the parts to the constructor. **Saving:** write one line per object, using its attributes.

```python
class Book:
    def __init__(self, title, copies):
        self.title = title
        self.copies = copies

def save_books(file_name, books):
    """Purpose: write books to a CSV file with a header line.
    Parameters: file_name (str), books (list of Book)
    Returns: nothing
    """
    # Output: header, then one line per object
    with open(file_name, "w") as out_file:
        out_file.write("Title,Copies\n")
        for book in books:
            out_file.write(f"{book.title},{book.copies}\n")

def load_books(file_name):
    """Purpose: read books from a CSV file (skips the header).
    Parameters: file_name (str)
    Returns: a list of Book objects (empty if the file is missing)
    """
    books = []
    # try/except catches FileNotFoundError: no file yet means an empty list
    try:
        with open(file_name, "r") as in_file:
            in_file.readline()
            for line in in_file:
                parts = line.strip().split(",")
                books.append(Book(parts[0], int(parts[1])))   # text -> object
    except FileNotFoundError:
        print(f"No {file_name} found.")
    return books

save_books("books.csv", [Book("Hatchet", 3), Book("Holes", 1)])
loaded = load_books("books.csv")
print(f"Loaded {len(loaded)} books. First: {loaded[0].title}")
missing = load_books("nothing_here.csv")
print(len(missing))
```

It prints:

```text
Loaded 2 books. First: Hatchet
No nothing_here.csv found.
0
```

For the report file in Build 11A (Club Manager), reuse the Step 9 trick: give your leaderboard function an `out_file=None` parameter and `file=out_file` on every `print`, so the same function prints to the screen and writes `club_report.txt`.

## Putting it together: a small menu program

Here is a complete program in the same shape as Build 11A (Club Manager), but smaller and about a different topic. Use it as a model for structure: constants, class, input functions, option functions, menu, `main`.

<!-- input: 1|4|2|2|2|2|3 -->
```python
# Name: Your Name
# Date: 2026-11-06
# Program: Shelf Tracker Example
# Description: A small menu program that tracks library books.

class Book:
    """One library book with a title and a number of copies on the shelf."""

    def __init__(self, title, copies):
        """Purpose: constructor. Parameters: title (str), copies (int). Returns: nothing"""
        self.title = title
        self.copies = copies

    def check_out(self):
        """Purpose: remove one copy if any are left.
        Parameters: none
        Returns: True if checked out, False if none left
        """
        if self.copies > 0:
            self.copies = self.copies - 1
            return True
        return False


def get_int(prompt, low, high):
    """Purpose: ask until the answer is a whole number from low to high.
    Parameters: prompt (str), low (int), high (int)
    Returns: the number (int)
    """
    while True:
        answer = input(prompt)
        # try/except catches ValueError: int() fails on letters, decimals, blanks
        try:
            number = int(answer)
            if number >= low and number <= high:
                return number
        except ValueError:
            pass
        print(f"Please enter a whole number from {low} to {high}.")


def list_books(shelf):
    """Purpose: menu option 1 - show every book, numbered.
    Parameters: shelf (list of Book)
    Returns: nothing
    """
    # Output
    for i in range(len(shelf)):
        print(f"{i + 1}. {shelf[i].title} ({shelf[i].copies})")


def check_out_book(shelf):
    """Purpose: menu option 2 - check out one copy of a chosen book.
    Parameters: shelf (list of Book)
    Returns: nothing
    """
    # Output and Input: show the list, then pick one
    list_books(shelf)
    choice = get_int(f"Which book (1-{len(shelf)}): ", 1, len(shelf))
    # Processing and Output
    book = shelf[choice - 1]
    if book.check_out():
        print(f"Checked out {book.title}. {book.copies} left.")
    else:
        print(f"Sorry, no copies of {book.title} left.")


def main():
    """Purpose: run the menu until Quit. Parameters: none. Returns: nothing"""
    shelf = [Book("Hatchet", 3), Book("Holes", 1)]
    choice = 0
    while choice != 3:
        print()
        print("1. List books  2. Check out  3. Quit")
        choice = get_int("Choose (1-3): ", 1, 3)
        if choice == 1:
            list_books(shelf)
        elif choice == 2:
            check_out_book(shelf)
    print("Goodbye!")


if __name__ == "__main__":
    main()
```

It prints (user typed `1`, `4`, `2`, `2`, `2`, `2`, `3`):

```text

1. List books  2. Check out  3. Quit
Choose (1-3): 1
1. Hatchet (3)
2. Holes (1)

1. List books  2. Check out  3. Quit
Choose (1-3): 4
Please enter a whole number from 1 to 3.
Choose (1-3): 2
1. Hatchet (3)
2. Holes (1)
Which book (1-2): 2
Checked out Holes. 0 left.

1. List books  2. Check out  3. Quit
Choose (1-3): 2
1. Hatchet (3)
2. Holes (0)
Which book (1-2): 2
Sorry, no copies of Holes left.

1. List books  2. Check out  3. Quit
Choose (1-3): 3
Goodbye!
```

## Common mistakes

**1. Forgetting `self` in a method**
```python
def add_points(amount):        # MISTAKE - no self
    self.points = self.points + amount
```
Calling `member.add_points(10)` gives: `TypeError: Member.add_points() takes 1 positional argument but 2 were given` (Python passed the object **and** 10). Fix: `def add_points(self, amount):`

**2. Forgetting `self.` on an attribute**
```python
def __init__(self, name, points):
    name = name                 # MISTAKE - just a local variable
```
Later, `member.name` gives `AttributeError: 'Member' object has no attribute 'name'`. Fix: `self.name = name`

**3. One underscore in `__init__`**
`def _init_(self, ...)` is just a normal method that never runs. Making an object gives `TypeError: Member() takes no arguments`. Fix: two underscores on each side.

**4. Sorting the real list for the leaderboard**
`members.sort(...)` changes the order option 2 shows. Fix: `ranked = sorted(members, key=..., reverse=True)`.

**5. `key=get_points()` with parentheses**
Error: `TypeError: get_points() missing 1 required positional argument: 'member'`. Fix: `key=get_points` (no parentheses).

**6. Duplicate check that's case sensitive**
`if name == member.name` lets `jordan` in when `Jordan` exists. Fix: compare `.lower()` on both sides.

**7. Option functions that don't get the list**
If `add_member()` makes its own `members = []`, the new member is lost when the function ends. Fix: pass the list from `main` as a parameter.

## How this shows up at BPA
- The 2026 regional: "Completing a **menu** of various tasks." The 2026 C++ test: a 5-option menu, "each its own function." Expect a menu.
- The 2024 Python regional was built around a **class**: constructor with three required parameters, a `getValue` method, a `toString` method, objects stored in a data structure, and a loop to print them all. Source code review gave points for each part.
- Loading at the start and saving at the end, with a dated report, combines Steps 9 and 10. File handling and exception handling are named categories in source code review.
- Keep your program **runnable** while you build. Write the menu loop with empty option functions first (each just `print("TODO")`), run it, then fill in one option at a time. Step 12 explains why.

## Quick reference

```python
class Player:
    """A player with a name and points."""
    def __init__(self, name, points):          # constructor
        self.name = name
        self.points = points

    def add_points(self, amount):              # method
        self.points = self.points + amount

    def __str__(self):                         # used by print()
        return f"{self.name}: {self.points}"

team = [Player("Avery", 40), Player("Blake", 25)]
team[0].add_points(10)
for player in team:
    print(player)

# menu loop, one function per option
def main():
    team = []
    choice = 0
    while choice != 3:
        print("1. Add  2. Show  3. Quit")
        choice = get_int("Choose (1-3): ", 1, 3)   # from Step 10
        if choice == 1:
            add_player(team)
        elif choice == 2:
            show_team(team)
    print("Bye!")
```
