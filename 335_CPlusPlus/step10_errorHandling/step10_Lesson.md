# Step 10 — Error Handling (C++)

**What you'll build:** Ticket Order — a ticket ordering program that cannot be crashed by bad typing, and saves the order to a file.
**Time:** about one and a half class periods (3 hours). This is the most useful step for BPA. Take your time.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [What goes wrong with cin](#what-goes-wrong-with-cin)
- [What an exception is](#what-an-exception-is)
- [try and catch](#try-and-catch)
- [Catching specific exceptions](#catching-specific-exceptions)
- [Rejecting 2.5 and 3abc: checking the whole string was used](#rejecting-25-and-3abc-checking-the-whole-string-was-used)
- [Read every input as a full line](#read-every-input-as-a-full-line)
- [Trimming spaces](#trimming-spaces)
- [Reusable input functions](#reusable-input-functions)
- [File errors](#file-errors)
- [throw and finally](#throw-and-finally)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Ticket Order](#the-challenge-ticket-order)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- Why `cin >>` misbehaves when the user types letters
- What an exception is and what a crash looks like
- `try` and `catch`, and catching specific exceptions: `invalid_argument` and `out_of_range`
- Using the second argument of `stoi` to reject `2.5` and `3abc`
- Reading **every** input with `getline`, then converting
- Trimming spaces from the ends of text
- Writing **reusable input functions**: `getText`, `getInt`, `getYesNo`
- Handling file-writing errors with `try` / `catch`

---

## What goes wrong with cin

Run Step 4's guessing game and type `abc` at the guess prompt. The program prints `Your guess (1-100): Too low!` forever, or freezes. Here is why:

1. `cin >> guess;` expects a number. It sees `a` and **fails**.
2. On failure, `cin` sets `guess` to 0 and goes into a **fail state**.
3. In the fail state, **every** later `cin >>` does nothing and returns at once.
4. The loop asks again, `cin` does nothing, the loop asks again...

It is possible to recover with `cin.clear();` and `cin.ignore(1000, '\n');`, and you will see that in the reference guide and online. But it does not catch everything: `cin >> number;` happily reads `3` from `3abc` and leaves `abc` behind, and it reads `2` from `2.5`. BPA requires rejecting "letters, symbols, decimals, and negative values where integers are expected."

The reliable way: **read the whole line as text with `getline`, then convert it yourself and check it.** Converting can throw an exception, so first you need to know what that is.

---

## What an exception is

An **exception** is C++'s way of saying "something went wrong and I can't continue this line of code." The function that hit the problem **throws** an exception. If nothing **catches** it, the program **crashes**.

`stoi` (string to int, Step 2) throws an exception when the text is not a number:

```cpp
#include <iostream>
#include <string>
using namespace std;

int main()
{
    string text = "seven";
    int number = stoi(text);   // throws an exception - "seven" is not a number
    cout << number << endl;    // never reached
    return 0;
}
```

What the crash looks like:
- **g++:**
  ```
  terminate called after throwing an instance of 'std::invalid_argument'
    what():  stoi
  ```
- **Visual Studio, Ctrl+F5:** a "Debug Error!" box pops up saying `abort() has been called`, and the program ends.
- **Visual Studio, F5 (debugging):** Visual Studio stops on the line and shows `Unhandled exception at ...: Microsoft C++ exception: std::invalid_argument`.

At BPA, a crash during grading costs points on every test the grader tries after it. The fix is to **catch** the exception.

---

## try and catch

```cpp
try
{
    // code that might throw an exception
}
catch (const invalid_argument&)
{
    // runs only if that kind of exception was thrown
}
```

- Put the risky code inside `try { }`.
- If an exception is thrown, C++ **jumps** straight to the matching `catch` block. The rest of the `try` block is skipped.
- If no exception happens, the `catch` block is skipped.
- Either way, the program **keeps running** after the `catch`.

```cpp
#include <iostream>
#include <string>
#include <stdexcept>   // invalid_argument, out_of_range
using namespace std;

int main()
{
    // Input: some text that may or may not be a number
    string texts[] = { "42", "seven", "-8" };

    for (string text : texts)
    {
        // Processing: this try/catch catches invalid_argument - text with no number at the start
        try
        {
            int number = stoi(text);
            cout << text << " -> " << number << endl;
        }
        catch (const invalid_argument&)
        {
            cout << text << " -> not a number" << endl;
        }
    }

    // Output: the program did not crash
    cout << "Still running." << endl;
    return 0;
}
```

What it prints:
```
42 -> 42
seven -> not a number
-8 -> -8
Still running.
```

| What you type | What it means |
|---|---|
| `#include <stdexcept>` | The standard exception types (`invalid_argument`, `out_of_range`, `runtime_error`, ...) |
| `try { ... }` | Watch this block for exceptions |
| `catch (const invalid_argument&) { ... }` | If an `invalid_argument` exception happens, run this. `const ... &` is the normal way to catch (by reference, like Step 6's parameters). |
| `catch (const invalid_argument& e)` | Same, but names the exception `e` so you can print `e.what()` (a short description) |

---

## Catching specific exceptions

`stoi` can throw **two** kinds of exception:

| Exception | When `stoi` throws it | Example |
|---|---|---|
| `invalid_argument` | The text does not start with a number | `""`, `"abc"`, `"two"`, `"$5"` |
| `out_of_range` | It is a number, but too big to fit in an `int` (over about 2.1 billion) | `"99999999999"` |

`stod` (string to double) throws the same two.

You can stack several `catch` blocks. C++ uses the first one that matches:

```cpp
#include <iostream>
#include <string>
#include <stdexcept>
using namespace std;

// Purpose: try to convert text and describe what happened.
// Parameters: text - the text to convert
// Returns: nothing
void describe(string text)
{
    // Processing: this try/catch catches invalid_argument (not a number)
    // and out_of_range (number too large for an int)
    try
    {
        int value = stoi(text);
        cout << "\"" << text << "\" is the number " << value << endl;
    }
    catch (const invalid_argument&)
    {
        cout << "\"" << text << "\" is not a number" << endl;
    }
    catch (const out_of_range&)
    {
        cout << "\"" << text << "\" is too big" << endl;
    }
}

int main()
{
    // Output: three tests
    describe("17");
    describe("");
    describe("12345678901");
    return 0;
}
```

What it prints:
```
"17" is the number 17
"" is not a number
"12345678901" is too big
```

There is also `catch (const exception& e)`, which catches **any** standard exception. It is a handy safety net, but BPA graders give points for catching the **specific** errors you expect, with a comment saying what each one is for. Catch specific types when you know them.

---

## Rejecting 2.5 and 3abc: checking the whole string was used

`stoi` reads as much of a number as it can **from the start** of the text and quietly ignores the rest:

| Text | `stoi` gives | Should we accept it? |
|---|---|---|
| `"3"` | 3 | Yes |
| `"2.5"` | 2 (stops at the `.`) | **No** - it is a decimal |
| `"3abc"` | 3 (stops at the `a`) | **No** - it has letters |
| `"abc"` | throws `invalid_argument` | No |

To catch the middle two, use `stoi`'s optional second argument. It tells you **how many characters were used**:

```cpp
size_t used = 0;
int value = stoi(text, &used);   // after this, used = number of characters stoi read
if (used == text.length())
{
    // every character was part of the number - accept it
}
```

For `"2.5"`, `used` is 1 but the length is 3, so it is rejected. For `"3"`, `used` is 1 and the length is 1, so it is accepted.

| What you type | What it means |
|---|---|
| `size_t used = 0;` | A variable to receive the count (Step 6 explained `size_t`) |
| `stoi(text, &used)` | Convert, and store how many characters were used into `used`. The `&` here means "the address of `used`," so `stoi` can write into it. |

Negative numbers like `"-3"` convert fine (`stoi` gives -3, and every character was used). They are rejected by the **range check** (`value >= low`), since every range you use starts at 1 or higher.

---

## Read every input as a full line

The plan for crash-proof input:

1. `getline(cin, text);` - read the whole line. This **never** fails on bad typing and never leaves a leftover Enter (no more `cin.ignore`, Step 7).
2. Trim the spaces off the ends.
3. Convert with `stoi` inside `try` / `catch`.
4. Check that the whole string was used and the number is in range.
5. If anything is wrong, print a message and **loop back** to step 1.

When **every** input in the program uses `getline`, the leftover newline problem disappears completely.

---

## Trimming spaces

`"   "` (only spaces) should count as blank, and `" 3 "` should count as 3. **Trimming** removes spaces, tabs, and line-ending characters from both ends.

```cpp
#include <iostream>
#include <string>
using namespace std;

// Purpose: remove whitespace from the start and end of some text.
// Parameters: text - the text to clean up
// Returns: the trimmed text ("" if it was all whitespace)
string trim(string text)
{
    // Processing: find the first character that is NOT whitespace
    size_t first = text.find_first_not_of(" \t\r\n");
    if (first == string::npos)   // npos = not found, so it is all whitespace
    {
        return "";
    }
    // Processing: find the last non-whitespace character, keep what is between
    size_t last = text.find_last_not_of(" \t\r\n");
    return text.substr(first, last - first + 1);
}

int main()
{
    // Output: brackets show exactly where the text starts and ends
    cout << "[" << trim("  Jordan  ") << "]" << endl;
    cout << "[" << trim("   ") << "]" << endl;
    cout << "[" << trim("Ava Lee") << "]" << endl;
    return 0;
}
```

What it prints:
```
[Jordan]
[]
[Ava Lee]
```

| What you type | What it means |
|---|---|
| `text.find_first_not_of(" \t\r\n")` | Index of the first character that is **not** a space, tab, carriage return, or newline |
| `text.find_last_not_of(" \t\r\n")` | Index of the last such character |
| `text.substr(start, count)` | The part of the text from `start`, `count` characters long (Step 7) |

The `\r` is included because files saved on Windows end lines with `\r\n`. Trimming removes the stray `\r` when you read such a file.

Copy `trim` into every program from now on. Python has `.strip()` built in; C++ does not, so you bring your own.

---

## Reusable input functions

This is the most valuable code you will write all year. Write these functions once, test them well, print them, and **bring them to BPA**. Every BPA C++ test asks you to validate input.

Here is the pattern with a small example: `getDouble`, which keeps asking until it gets any decimal number. (The challenge asks you to write `getInt`, which follows the same pattern with a range check.)

```cpp
#include <iostream>
#include <string>
#include <stdexcept>
using namespace std;

// Purpose: remove whitespace from both ends of some text.
// Parameters: text - the text to clean up
// Returns: the trimmed text
string trim(string text)
{
    size_t first = text.find_first_not_of(" \t\r\n");
    if (first == string::npos)
    {
        return "";
    }
    size_t last = text.find_last_not_of(" \t\r\n");
    return text.substr(first, last - first + 1);
}

// Purpose: ask until the user types a valid decimal number.
// Parameters: prompt - the question to show
// Returns: the number as a double
double getDouble(string prompt)
{
    while (true)   // loop until a return statement leaves the function
    {
        // Input: read the whole line as text
        string answer;
        cout << prompt;
        getline(cin, answer);
        answer = trim(answer);

        // Processing: convert. This try/catch catches invalid_argument
        // (not a number) and out_of_range (number too large).
        try
        {
            size_t used = 0;
            double value = stod(answer, &used);
            if (used == answer.length())   // the whole text was a number
            {
                return value;              // good answer: leave the function
            }
        }
        catch (const invalid_argument&)
        {
            // not a number: fall through to the message below
        }
        catch (const out_of_range&)
        {
            // too large: fall through to the message below
        }

        // Output: error, then the while loop asks again
        cout << "Please enter a number." << endl;
    }
}

int main()
{
    // Input: two numbers that cannot crash the program
    double width = getDouble("Width (ft): ");
    double length = getDouble("Length (ft): ");

    // Output
    cout << "Area: " << width * length << " sq ft" << endl;
    return 0;
}
```

Sample run:
```
Width (ft): ten
Please enter a number.
Width (ft): 
Please enter a number.
Width (ft): 10
Length (ft): 4.5ft
Please enter a number.
Length (ft): 4.5
Area: 45 sq ft
```

How it works:
- `while (true)` loops forever. The only way out is `return`, which happens only when the answer is good.
- A bad answer either throws (and the empty `catch` blocks just let the code continue) or fails the `if`. Both end up at the error message, and the loop asks again.
- The prompt is a **parameter**, so the same function works for any question.

### The three functions for the challenge

| Function | Keeps asking until... | On a bad answer prints | Returns |
|---|---|---|---|
| `string getText(string prompt)` | the trimmed answer is not blank | `This cannot be blank.` | the trimmed text |
| `int getInt(string prompt, int low, int high)` | the answer is a whole number from `low` to `high` | `Please enter a whole number from <low> to <high>.` | the number |
| `bool getYesNo(string prompt)` | the answer is `y`, `Y`, `n`, or `N` | `Please enter y or n.` | `true` for y/Y, `false` for n/N |

`getInt` is `getDouble` with three changes: `stoi` instead of `stod`, a range check added to the `if`, and the longer error message. `getText` and `getYesNo` don't need `try` at all; they just compare text.

Once you have them, a whole validated question is one line:

```cpp
int quantity = getInt("Quantity (1-10): ", 1, 10);
```

**Try it:** Go back to your Step 4 guessing game and replace `cin >> guess;` with `getInt("Your guess (1-100): ", 1, 100)`. Now typing letters can't break it. (The message changes to `Please enter a whole number from 1 to 100.` That is fine for this practice.)

---

## File errors

Opening a file to write can fail too: the folder is read-only, the disk is full, or the file is open in another program. By default an `ofstream` does **not** throw an exception; it quietly fails, like `cin`. You have two choices.

**Choice 1: check it** (like reading in Step 9):
```cpp
ofstream outFile("orders.txt");
if (!outFile)
{
    cout << "Error: could not save orders.txt" << endl;
}
```

**Choice 2: turn on exceptions and use try / catch.** BPA rubrics list "exception handling" as a graded item, so this is good to know:

```cpp
#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    // Output: write a file. This try/catch catches ios_base::failure, the
    // exception a file stream throws when exceptions are turned on and
    // the file cannot be opened or written.
    try
    {
        ofstream outFile;
        outFile.exceptions(ofstream::failbit | ofstream::badbit);   // throw on any error
        outFile.open("no_such_folder/log.txt");                     // this folder does not exist

        outFile << "This line is never written." << endl;
        outFile.close();
        cout << "Saved." << endl;
    }
    catch (const ios_base::failure&)
    {
        cout << "Error: could not save log.txt" << endl;
    }
    return 0;
}
```

What it prints:
```
Error: could not save log.txt
```

| What you type | What it means |
|---|---|
| `ofstream outFile;` | Make the stream, but don't open a file yet |
| `outFile.exceptions(ofstream::failbit \| ofstream::badbit);` | From now on, throw an exception if anything fails. Must come **before** `open`. |
| `outFile.open("orders.txt");` | Now open the file |
| `catch (const ios_base::failure&)` | Catch the file stream's exception type |

The order matters: if you open the file in the constructor (`ofstream outFile("orders.txt");`) **before** turning exceptions on, a failed open is not reported as an exception.

To test your error message, temporarily change the file name to a folder that does not exist, like `"nofolder/orders.txt"`.

---

## throw and finally

Two things you may see elsewhere:

- **`throw`** creates an exception yourself: `throw runtime_error("Bad data in file");`. A `catch (const runtime_error& e)` higher up catches it, and `e.what()` gives back the message. You do not need it for the challenge.
- **`finally`** is a block in Python, Java, and C# that always runs after `try`/`catch`. **C++ has no `finally`.** C++ does not need it for files, because a file stream closes itself automatically when its variable goes out of scope, even when an exception jumps out of the block.

---

## Common mistakes

**1. Catch block in the wrong place**
- Looks like: the `try` only surrounds the `cout`, and `stoi` is above it.
- Result: still crashes.
- Fix: the line that throws (`stoi`) must be **inside** the `try`.

**2. Forgot to check the whole string was used**
- Result: `2.5` is accepted as 2, and `3abc` as 3.
- Fix: `stoi(answer, &used)` and `used == answer.length()`.

**3. Mixing `cin >>` with the new functions**
- Looks like: the first `getText` after a `cin >>` returns at once with `This cannot be blank.`
- Cause: the leftover Enter (Step 7).
- Fix: use the input functions for **every** input. No `cin >>` anywhere.

**4. Function never returns a value**
- Warning: `C4715 not all control paths return a value`.
- Cause: `while (true)` loop with no `return` inside, or a `return` only in one branch.
- Fix: `return value;` inside the `if` that accepts the answer.

**5. Range check missing**
- Result: `0` or `99` accepted for a ticket type, then `TICKET_PRICES[98]` reads garbage or crashes.
- Fix: `value >= low && value <= high`.

**6. Missing `#include <stdexcept>`**
- Error: `'invalid_argument': undeclared identifier` (some compilers include it for you; Visual Studio may not).

**7. Blank name accepted**
- Cause: checking `answer != ""` before trimming, so `"   "` passes.
- Fix: trim first, then check.

---

## How this shows up at BPA

- The 2026 regional's general notes: "gracefully handle any invalid input by prompting the user to try again without crashing" and "All numeric inputs should reject letters, symbols, decimals, and negative values where integers are expected." Your `getInt` does exactly that.
- That test's main menu alone was worth 20 execution points plus 40 code review points for being "validated and handles all user inputs." Every option also had its own "invalid input" points.
- The source code review on these tests lists **exception handling** as a gradable block. Comment each `try`/`catch` with what it catches.
- Print your `trim`, `getText`, `getInt`, `getYesNo`, and `getDouble` functions and bring them. Printed code is allowed in the C++ event.

---

## The challenge: Ticket Order

Write a ticket ordering program with crash-proof input.

**Requirements**
1. Header comment.
2. Write these reusable functions:
   - `getText(prompt)` → keeps asking until the answer is not blank; on blank prints `This cannot be blank.`
   - `getInt(prompt, low, high)` → keeps asking until the answer is a whole number from low to high; otherwise prints `Please enter a whole number from <low> to <high>.` Must reject letters, decimals like `2.5`, blanks, and out-of-range numbers without crashing.
   - `getYesNo(prompt)` → returns true for `y`/`Y`, false for `n`/`N`; anything else prints `Please enter y or n.` and asks again.
3. Ask for the name with `getText`, then repeat: show the ticket types, ask ticket type (1–3) and quantity (1–10) with `getInt`, add to the order, ask `Another order? (y/n): ` with `getYesNo`.
   - Ticket types and prices: 1-Student $5.00, 2-Adult $8.50, 3-Senior $6.25.
4. At the end print total tickets and total cost.
5. Save the order to `orders.txt` inside a try/catch. One line per order in the form `Jordan,Adult,3,25.50`. On success print `Order saved to orders.txt`; if writing fails print `Error: could not save orders.txt` (no crash).
6. Function comments and Input / Processing / Output comments, including a comment on each try/catch saying what error it catches.

(C++ names use camelCase: `get_text` in the shared spec is `getText` here.)

**Sample run (exact)**
```
Name: 
This cannot be blank.
Name: Jordan
Ticket types: 1-Student $5.00  2-Adult $8.50  3-Senior $6.25
Ticket type (1-3): two
Please enter a whole number from 1 to 3.
Ticket type (1-3): 2
Quantity (1-10): 2.5
Please enter a whole number from 1 to 10.
Quantity (1-10): 3
Another order? (y/n): maybe
Please enter y or n.
Another order? (y/n): y
Ticket types: 1-Student $5.00  2-Adult $8.50  3-Senior $6.25
Ticket type (1-3): 1
Quantity (1-10): 2
Another order? (y/n): n

Total tickets: 5
Total cost: $35.50
Order saved to orders.txt
```

**`orders.txt`**
```
Jordan,Adult,3,25.50
Jordan,Student,2,10.00
```
The first line `Name: ` with nothing typed means the user pressed Enter. Whitespace-only counts as blank — trim it.

**Hints**
- Keep the ticket names and prices in two small constant arrays above `main` (fixed size, never change, so an array fits - Step 6):
  `const string TICKET_NAMES[] = { "Student", "Adult", "Senior" };` and the same for the prices. Type 1 is index 0, so use `[type - 1]`.
- Keep the orders in parallel vectors (Step 8): one for the type, one for the quantity, one for the cost.
- Use your `formatMoney` from Step 5 for the total.
- Write the file with `fixed << setprecision(2)` so `10` is saved as `10.00`.
- Test every bad input in the sample run, plus `-3`, `3abc`, `   `, and a huge number like `99999999999`.
- Test the save error by temporarily changing the file name to `"nofolder/orders.txt"`.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step10`.
2. Put `step10.cpp` in it. (Visual Studio: push the whole project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 10 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] `orders.txt` matches the sample
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `getText`, `getInt`, `getYesNo` exist, each with a comment block
- [ ] Every input uses one of them (no `cin >>` left)
- [ ] Letters, `2.5`, blanks, negatives, and out-of-range numbers are all rejected without crashing
- [ ] Saving is inside `try` / `catch`, with a comment saying what it catches
- [ ] Pushed to `bpaPrep/cpp_step10`
