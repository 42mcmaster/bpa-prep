# Step 11 — Menu Program with a Class (C++)

**What you'll build:** Club Manager — a menu program that loads club members from a file, lets you add members, record points, show a leaderboard, search, and save. It uses everything from Steps 1-10 plus a simple class.
**Time:** about two class periods (4 hours). This is the closest practice yet to a real BPA test.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [The menu loop](#the-menu-loop)
- [One function per menu option](#one-function-per-menu-option)
- [What a class is](#what-a-class-is)
- [Writing a class: fields, constructor, method](#writing-a-class-fields-constructor-method)
- [A vector of objects](#a-vector-of-objects)
- [Changing an object inside a vector](#changing-an-object-inside-a-vector)
- [Sorting objects by a field](#sorting-objects-by-a-field)
- [Case-insensitive search](#case-insensitive-search)
- [Loading and saving the list](#loading-and-saving-the-list)
- [Putting it together: program layout](#putting-it-together-program-layout)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Club Manager](#the-challenge-club-manager)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- The menu loop: show a menu, read a validated choice, run that option, repeat until Quit
- Using `switch` (Step 3) to call one function per option
- What a **class** is, and how to write one with fields, a **constructor**, and a **method**
- Making objects and keeping them in a `vector`
- Changing an object that is inside a vector (with a reference `&`)
- Sorting objects by one field with `stable_sort` and a compare function
- Searching text without caring about upper or lower case
- Loading a CSV into objects at the start, and saving at the end

---

## The menu loop

Almost every BPA C++ test is a **menu program**. The shape is always the same:

```cpp
#include <iostream>
using namespace std;

int main()
{
    bool running = true;
    while (running)
    {
        // Output: the menu
        cout << endl;
        cout << "=== LIGHT SWITCH ===" << endl;
        cout << "1. Turn on" << endl;
        cout << "2. Turn off" << endl;
        cout << "3. Quit" << endl;
        cout << "Choose (1-3): ";

        // Input: the choice (Step 10's getInt would go here in a real program)
        int choice = 0;
        cin >> choice;

        // Processing: run the matching option
        switch (choice)
        {
        case 1:
            cout << "The light is on." << endl;
            break;
        case 2:
            cout << "The light is off." << endl;
            break;
        case 3:
            cout << "Goodbye!" << endl;
            running = false;   // ends the while loop
            break;
        default:
            cout << "Please choose 1 to 3." << endl;
            break;
        }
    }
    return 0;
}
```

Sample run:
```

=== LIGHT SWITCH ===
1. Turn on
2. Turn off
3. Quit
Choose (1-3): 1
The light is on.

=== LIGHT SWITCH ===
1. Turn on
2. Turn off
3. Quit
Choose (1-3): 3
Goodbye!
```

The pieces:
- A `bool` (`running`) controls the loop. Quit sets it to `false`.
- The menu is printed **inside** the loop so it shows again after each option.
- A `switch` (Step 3) picks the option. Every `case` ends with `break`.
- In the challenge, the choice is read with your Step 10 `getInt("Choose an option (1-6): ", 1, 6)`. Because `getInt` already rejects everything except 1 to 6, the `switch` does not need a `default`.

Why not use `break` to leave the `while`? Inside a `switch`, `break` only leaves the **switch**, not the loop. That is why a `bool` variable is used to stop the loop.

---

## One function per menu option

BPA requires each menu option to be its own function. `main` should stay short: load data, run the menu loop, and call one function per option.

```cpp
switch (choice)
{
case 1:
    addMember(members);
    break;
case 2:
    recordPoints(members);
    break;
// ...
}
```

Each option function gets the data it needs as a **parameter** (no global variables). Use the parameter rules from Steps 6 and 8:

| The option... | Parameter |
|---|---|
| changes the list (add, record points) | `vector<Member>& members` |
| only reads the list (show, search, save) | `const vector<Member>& members` |

Showing the menu can be a function too (`void showMenu()`), which keeps the loop easy to read.

---

## What a class is

So far, data about one thing has been spread over parallel lists (Step 8): a name in one vector, scores in another, and you had to keep them in sync. A **class** lets you bundle the data about one thing into a single unit.

- A **class** is a blueprint: "a member has a name and points, and you can add points to a member."
- An **object** is one thing built from that blueprint: "Avery, 120 points."
- **Fields** (also called data members) are the variables each object has: `name`, `points`.
- A **constructor** is a special function that runs when an object is created. It fills in the fields.
- A **method** (also called a member function) is a function that belongs to the class and works on that object's fields: `addPoints(25)`.

You have used objects already: `string` and `vector` are classes. `word.length()` and `scores.push_back(88)` are method calls.

---

## Writing a class: fields, constructor, method

```cpp
#include <iostream>
#include <string>
using namespace std;

// ---------------------------------------------------------------
// Song class: one song with a title and a play count
// ---------------------------------------------------------------
class Song
{
public:
    string title;   // field: the song title
    int plays;      // field: how many times it has been played

    // Purpose: constructor - runs when a Song is created and fills in the fields.
    // Parameters: songTitle - the title; startPlays - the starting play count
    // Returns: nothing (constructors never have a return type)
    Song(string songTitle, int startPlays)
    {
        title = songTitle;
        plays = startPlays;
    }

    // Purpose: record that the song was played more times.
    // Parameters: amount - how many more plays
    // Returns: nothing
    void addPlays(int amount)
    {
        plays = plays + amount;
    }
};   // <-- a class ends with a semicolon

int main()
{
    // Processing: create two objects with the constructor
    Song first("Thunder", 10);
    Song second("Believer", 3);

    // Processing: call a method on one object - only that object changes
    second.addPlays(5);

    // Output: read the fields with a dot
    cout << first.title << ": " << first.plays << " plays" << endl;
    cout << second.title << ": " << second.plays << " plays" << endl;
    return 0;
}
```

What it prints:
```
Thunder: 10 plays
Believer: 8 plays
```

| What you type | What it means |
|---|---|
| `class Song { ... };` | Define a class named `Song`. Class names use **PascalCase** (capital first letter). **The `;` after the closing brace is required.** |
| `public:` | Everything below this line can be used from outside the class (like from `main`). Without it, C++ makes everything **private** and `main` can't use it. |
| `string title;` | A field. Every `Song` object gets its own `title`. |
| `Song(string songTitle, int startPlays)` | The constructor: **same name as the class**, and **no return type** (not even `void`). |
| `void addPlays(int amount)` | A method. Inside it, `plays` means **this object's** `plays`. |
| `Song first("Thunder", 10);` | Create an object named `first`, calling the constructor with those values. |
| `Song("Thunder", 10)` | Create an object without naming it (useful with `push_back`). |
| `first.title` | The `title` field of `first` (the **dot** reaches into the object) |
| `second.addPlays(5);` | Call the method on `second` |

### Why the parameter names are different from the field names

The constructor's parameters are `songTitle` and `startPlays`, not `title` and `plays`. If a parameter had the same name as a field, `title = title;` would just copy the parameter onto itself and the field would never be set. Different names avoid that trap.

### class or struct?

C++ also has `struct`, which is the same as a `class` except everything is `public` by default. You will see both. This course uses `class` with `public:` because that is what Java and C# use, and the BPA rubrics say "class construction."

### Fields public or private?

In large programs, fields are usually `private` and reached through methods (called **getters** and **setters**). That is good design, but more code. For a 90-minute build, **public fields plus a constructor and at least one method** is a clean, accepted class. If you want to try private fields, the reference guide shows how.

**Try it:** Write a `Pet` class with `name` and `age`, a constructor, and a `haveBirthday()` method that adds 1 to `age`. Make a pet, call `haveBirthday()` twice, and print its age.

---

## A vector of objects

A vector can hold objects, just like it holds ints or strings.

```cpp
#include <iostream>
#include <string>
#include <vector>
using namespace std;

class Song
{
public:
    string title;
    int plays;

    // Purpose: constructor. Parameters: songTitle, startPlays. Returns: nothing.
    Song(string songTitle, int startPlays)
    {
        title = songTitle;
        plays = startPlays;
    }
};

int main()
{
    // Processing: a vector of Song objects, filled with push_back
    vector<Song> playlist;
    playlist.push_back(Song("Thunder", 10));
    playlist.push_back(Song("Believer", 8));
    playlist.push_back(Song("Radioactive", 15));

    // Output: numbered list with a counting loop
    for (size_t i = 0; i < playlist.size(); i++)
    {
        cout << (i + 1) << ". " << playlist[i].title << " (" << playlist[i].plays << ")" << endl;
    }

    // Output: total with a for-each loop
    int totalPlays = 0;
    for (const Song& song : playlist)
    {
        totalPlays = totalPlays + song.plays;
    }
    cout << "Total plays: " << totalPlays << endl;
    return 0;
}
```

What it prints:
```
1. Thunder (10)
2. Believer (8)
3. Radioactive (15)
Total plays: 33
```

Notes:
- `playlist[i].title` - first pick the object with `[i]`, then the field with `.title`.
- `for (const Song& song : playlist)` - a for-each loop that **does not copy** each object (`&`) and promises not to change it (`const`). This is the normal way to loop over objects just to read them.
- One vector of objects replaces Step 8's parallel lists. The name and the points can never get out of sync, because they are in the same object.

---

## Changing an object inside a vector

To change an object in the vector, either reach it directly with the index, or make a **reference** to it.

```cpp
#include <iostream>
#include <string>
#include <vector>
using namespace std;

class Song
{
public:
    string title;
    int plays;

    // Purpose: constructor. Parameters: songTitle, startPlays. Returns: nothing.
    Song(string songTitle, int startPlays)
    {
        title = songTitle;
        plays = startPlays;
    }

    // Purpose: add plays. Parameters: amount. Returns: nothing.
    void addPlays(int amount)
    {
        plays = plays + amount;
    }
};

int main()
{
    vector<Song> playlist;
    playlist.push_back(Song("Thunder", 10));
    playlist.push_back(Song("Believer", 8));

    // Processing: way 1 - call the method through the index
    playlist[0].addPlays(1);

    // Processing: way 2 - a reference (&) is another name for the real object
    Song& chosen = playlist[1];
    chosen.addPlays(4);

    // Processing: the WRONG way - this makes a copy, and the copy is changed
    Song copy = playlist[1];
    copy.addPlays(100);

    // Output
    cout << playlist[0].title << ": " << playlist[0].plays << endl;
    cout << playlist[1].title << ": " << playlist[1].plays << endl;
    return 0;
}
```

What it prints:
```
Thunder: 11
Believer: 12
```

The `+100` never reached the vector, because `copy` is a separate object. `Song& chosen` (with `&`) refers to the real object inside the vector. This is the same reference idea as Step 5's `int& score` parameter.

The challenge's "Record points" option: the user picks a number 1 to N, so the member is `members[number - 1]`.

---

## Sorting objects by a field

`sort` (Step 6) knows how to compare numbers and strings, but not `Song` objects. Which field should it compare? You tell it with a **compare function**: a function that takes two objects and returns `true` if the first one should come **before** the second.

```cpp
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>   // sort, stable_sort
using namespace std;

class Song
{
public:
    string title;
    int plays;

    // Purpose: constructor. Parameters: songTitle, startPlays. Returns: nothing.
    Song(string songTitle, int startPlays)
    {
        title = songTitle;
        plays = startPlays;
    }
};

// Purpose: tell stable_sort to put songs with more plays first.
// Parameters: a, b - two songs to compare
// Returns: true if a should come before b
bool morePlays(const Song& a, const Song& b)
{
    return a.plays > b.plays;
}

int main()
{
    vector<Song> playlist;
    playlist.push_back(Song("Thunder", 10));
    playlist.push_back(Song("Believer", 8));
    playlist.push_back(Song("Radioactive", 15));

    // Processing: sort a COPY, so the playlist keeps its own order
    vector<Song> topSongs = playlist;
    stable_sort(topSongs.begin(), topSongs.end(), morePlays);

    // Output: sorted copy, then the original
    for (const Song& song : topSongs)
    {
        cout << song.title << " " << song.plays << endl;
    }
    cout << "Playlist still starts with: " << playlist[0].title << endl;
    return 0;
}
```

What it prints:
```
Radioactive 15
Thunder 10
Believer 8
Playlist still starts with: Thunder
```

| What you type | What it means |
|---|---|
| `bool morePlays(const Song& a, const Song& b)` | A compare function: return `true` when `a` goes first |
| `return a.plays > b.plays;` | More plays first (highest to lowest). Use `<` for lowest first. |
| `stable_sort(v.begin(), v.end(), morePlays);` | Sort using your compare function. Pass the function's **name**, without `()`. |

`stable_sort` is like `sort`, but objects that tie keep their original order. That makes ties predictable.

**Sort a copy** when the original order matters. In the challenge, option 2 lists members in the order loaded/added, so the leaderboard must sort a copy and leave `members` alone.

(You could also write your own selection sort like Step 8 and swap whole objects with `swap(list[i], list[best])`. Either is fine.)

---

## Case-insensitive search

To search without caring about case, make **lowercase copies** of both strings, then use `find` (Step 7).

```cpp
#include <iostream>
#include <string>
#include <cctype>   // tolower
using namespace std;

// Purpose: make a lowercase copy of some text.
// Parameters: text - the original (a copy, so changing it is safe)
// Returns: the text in lowercase
string toLower(string text)
{
    // Processing: change each character in place (Step 7)
    for (size_t i = 0; i < text.length(); i++)
    {
        text[i] = tolower(text[i]);
    }
    return text;
}

int main()
{
    string title = "Radioactive";
    string search = "ACT";

    // Processing: contains, ignoring case?
    bool found = toLower(title).find(toLower(search)) != string::npos;

    // Processing: equal, ignoring case?
    bool same = toLower("Thunder") == toLower("THUNDER");

    // Output
    cout << "Contains: " << found << endl;
    cout << "Same: " << same << endl;
    return 0;
}
```

What it prints:
```
Contains: 1
Same: 1
```

You need both for the challenge:
- **Add member:** "already exists (ignore case)" means `toLower(member.name) == toLower(newName)` for any member.
- **Search:** "name contains the text, ignoring case" means `toLower(member.name).find(toLower(text)) != string::npos`.

To print a double quote in a message like `No members match "zz".`, use `\"` (Step 1).

---

## Loading and saving the list

**Loading** is Step 9's CSV reading, building an object from each line:

```cpp
// Processing: split the line, then build a Member and add it
getline(lineStream, name, ',');
getline(lineStream, pointsText, ',');
members.push_back(Member(name, stoi(pointsText)));
```

Wrap the `stoi` in `try` / `catch` (Step 10) so a bad line in the file is skipped instead of crashing.

If the file is missing, it's not an error here: print the message and start with an empty vector.

**Saving** is Step 9's writing, inside Step 10's `try` / `catch` with `exceptions()` turned on. Write the header line, then one line per object:

```cpp
csvFile << "Name,Points" << endl;
for (const Member& member : members)
{
    csvFile << member.name << "," << member.points << endl;
}
```

The report file reuses one leaderboard function with an `ostream& out` parameter (Step 9), so the same function prints the leaderboard to the screen for option 3 and to `club_report.txt` for option 5. It also reuses `currentDateTime()` from Step 9 (remember `#define _CRT_SECURE_NO_WARNINGS` as the first line).

To build a prompt that includes a number, like `Choose a member (1-4): `, use `to_string` (Step 2):

```cpp
string prompt = "Choose a member (1-" + to_string(count) + "): ";
int number = getInt(prompt, 1, count);
```

---

## Putting it together: program layout

A long program is easier to read (and to grade) when it is laid out in a fixed order. Use this for the challenge and at BPA:

```
1. Header comment
2. #define _CRT_SECURE_NO_WARNINGS
3. #include lines and using namespace std;
4. Constants
5. The class
6. Function prototypes, grouped with a comment:
     - input helpers (trim, getText, getInt)
     - other helpers (toLower, currentDateTime, printLeaderboard, loadMembers, showMenu)
     - one function per menu option
7. main: load, then the menu loop
8. The functions, in the same order as the prototypes, each with its comment block
```

Copy `trim`, `getText`, and `getInt` straight from your Step 10 program. `getYesNo` is not needed this time.

---

## Common mistakes

**1. Missing `;` after the class**
- Looks like: `class Member { ... }` with no `;`
- Error: often a confusing one on the **next** line, like `C2628 'Member' followed by 'int' is illegal (did you forget a ';'?)`. (g++: `expected ';' after class definition`)
- Fix: `};`

**2. Forgot `public:`**
- Error: `C2248 'Member::name': cannot access private member declared in class 'Member'`
- Fix: put `public:` at the top of the class.

**3. Constructor with a return type**
- Looks like: `void Member(string memberName, int startPoints)`
- Error: `C2380 type(s) preceding 'Member' (constructor with return type, or illegal redefinition of current class-name?)`
- Fix: no return type on a constructor.

**4. Changing a copy**
- Looks like: `Member chosen = members[number - 1]; chosen.addPoints(50);` and the points never change.
- Fix: `Member& chosen = members[number - 1];`

**5. Leaderboard reorders the list**
- Looks like: after option 3, option 2 lists members in points order.
- Fix: sort a copy.

**6. `break` inside the switch doesn't end the loop**
- Looks like: choosing Quit prints `Goodbye!` and then the menu again.
- Fix: set `running = false;` in the Quit case.

**7. Option function doesn't change the list**
- Looks like: `Added Jordan.` but Jordan never shows up later.
- Cause: `void addMember(vector<Member> members)` without `&`.
- Fix: `vector<Member>& members`.

**8. `toLower` name clash**
- Error with a name like `tolower`: C++ already has `tolower` (lowercase L) for single characters. Name yours `toLower` (capital L), which is a different name.

---

## How this shows up at BPA

- The 2026 C++ regional was exactly this shape: a menu with 5 options, every option its own function with a required name, a validated menu, and an `exitProgram` function that returned a `bool` to the menu loop.
- That test was 540 points. The main menu (appearance, performance, validation) alone was worth 60.
- Source code review lists "class construction" as a gradable block, and "data structures." A class with a constructor and a method, kept in a `vector`, covers both.
- Graders run every option, including bad input. Test every option with letters, blanks, and out-of-range numbers before time is up.

---

## The challenge: Club Manager

Write a menu program that manages club members and their points.

**Data file:** `members.csv` is in this step's folder ([members.csv](members.csv)). Put it in your project folder (and next to the `.exe` if you run it directly). Its contents:
```
Name,Points
Avery,120
Blake,95
Casey,140
```

**Requirements**
1. Header comment.
2. A `Member` class with a name, points, a constructor, and an `addPoints(amount)` method.
3. At start, load `members.csv` into a list of `Member` objects and print `Loaded 3 members from members.csv`. If it's missing print `No members.csv found. Starting with an empty list.`
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
11. Each menu option is its own function. Function comments and Input / Processing / Output comments.

(In C++ the list is a `vector<Member>`. `add_points` in the shared spec is `addPoints` here.)

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
A blank line prints before each menu. Showing the leaderboard must not reorder the members list — sort a copy — so option 2's numbered list stays in the order loaded/added. The search for "a" matches all four because every name contains an "a" or "A".

**Hints**
- Suggested option functions: `addMember(vector<Member>& members)`, `recordPoints(vector<Member>& members)`, `showLeaderboard(const vector<Member>& members)`, `searchMembers(const vector<Member>& members)`, `saveMembers(const vector<Member>& members)`. Quit can stay in the `switch`.
- One `printLeaderboard(ostream& out, const vector<Member>& members)` serves both option 3 and the report.
- `cout << endl;` at the top of the loop gives the blank line before each menu.
- After testing Save, your `members.csv` has changed. Put the original back (download it again) before comparing with the sample run.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step11`.
2. Put `step11.cpp` and `members.csv` in it. (Visual Studio: push the whole project folder, with `members.csv` in the project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 11 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `Member` class with fields, a constructor, and `addPoints`
- [ ] Members kept in a `vector<Member>`
- [ ] Each menu option is its own function, each with a comment block
- [ ] Menu choice and all numbers use `getInt`; names and search text use `getText`
- [ ] Duplicate check and search ignore case
- [ ] Leaderboard sorts a copy
- [ ] Missing `members.csv` handled; Save uses `try` / `catch`
- [ ] Pushed to `bpaPrep/cpp_step11` with `members.csv`
