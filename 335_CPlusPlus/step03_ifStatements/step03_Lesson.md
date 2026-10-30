# Step 03 — If Statements (C++)

**What you'll build:** Grade Checker — a program that turns a score into a letter grade and says whether the student passed.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Comparison operators](#comparison-operators)
- [if, else if, else](#if-else-if-else)
- [Logical operators: and, or, not](#logical-operators-and-or-not)
- [Nested if statements](#nested-if-statements)
- [Comparing text and characters](#comparing-text-and-characters)
- [The switch statement](#the-switch-statement)
- [Ending the program early with return](#ending-the-program-early-with-return)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Grade Checker](#the-challenge-grade-checker)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- The comparison operators `==  !=  <  >  <=  >=`
- How to make decisions with `if`, `else if`, and `else`
- How to combine conditions with `&&` (and), `||` (or), and `!` (not)
- How to put one `if` inside another
- How to compare strings and single characters, and why case matters
- How to use a `switch` statement
- How to end `main` early with `return 0;`

---

## Comparison operators

A **comparison** asks a yes/no question. The answer is a `bool`: `true` or `false`.

| Operator | Meaning | Example (with `age = 16`) | Result |
|---|---|---|---|
| `==` | equal to | `age == 16` | `true` |
| `!=` | not equal to | `age != 16` | `false` |
| `<` | less than | `age < 18` | `true` |
| `>` | greater than | `age > 18` | `false` |
| `<=` | less than or equal to | `age <= 16` | `true` |
| `>=` | greater than or equal to | `age >= 18` | `false` |

**`=` and `==` are different.** One `=` **stores** a value. Two `==` **asks** if two values are equal. Mixing them up is a classic bug (see Common mistakes).

---

## if, else if, else

An `if` statement runs a block of code only when its condition is true.

```cpp
if (condition)
{
    // runs only when condition is true
}
```

The condition always goes in **parentheses**. The block goes in **braces**. There is **no semicolon** after `if (...)`.

Add `else if` and `else` to choose between several paths. C++ checks the conditions **top to bottom** and runs **only the first one that is true**. `else` runs if none of them were true.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: the temperature
    int temperature = 0;
    cout << "Temperature (F): ";
    cin >> temperature;

    // Processing + Output: pick one message
    if (temperature >= 90)
    {
        cout << "Hot. Bring water." << endl;
    }
    else if (temperature >= 70)
    {
        cout << "Nice day." << endl;
    }
    else if (temperature >= 40)
    {
        cout << "Bring a jacket." << endl;
    }
    else
    {
        cout << "Very cold. Bring a coat." << endl;
    }

    // Output: this line always runs - it is after the if chain
    cout << "Have a good day!" << endl;
    return 0;
}
```

Sample run:
```
Temperature (F): 75
Nice day.
Have a good day!
```

Why does 75 print only `Nice day.` and not also `Bring a jacket.`? 75 is also `>= 40`, but once `>= 70` matched, the rest of the chain is skipped. This is why the order matters: **check the biggest range first** when you use `>=`.

Python comparison:

| Python | C++ |
|---|---|
| `if x > 5:` | `if (x > 5) {` |
| `elif x > 2:` | `} else if (x > 2) {` |
| `else:` | `} else {` |

### Separate ifs versus an if / else if chain

Sometimes you want **more than one** check to run. Then use separate `if` statements instead of a chain. Each separate `if` is checked on its own.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: number of tickets sold
    int ticketsSold = 0;
    cout << "Tickets sold: ";
    cin >> ticketsSold;

    // Processing + Output: each if is checked separately, so several can print
    if (ticketsSold > 0)
    {
        cout << "The show is on." << endl;
    }
    if (ticketsSold >= 100)
    {
        cout << "Open the balcony." << endl;
    }
    if (ticketsSold == 150)
    {
        cout << "Sold out!" << endl;
    }
    return 0;
}
```

Sample run:
```
Tickets sold: 150
The show is on.
Open the balcony.
Sold out!
```

**Try it:** Ask for an age. Print `Child` for under 13, `Teen` for 13 to 19, and `Adult` for 20 and up. Then, as a separate `if`, print `Can vote` for 18 and up.

---

## Logical operators: and, or, not

Combine conditions with these operators. Python uses words; C++ uses symbols.

| C++ | Python | Meaning | True when... |
|---|---|---|---|
| `&&` | `and` | and | **both** sides are true |
| `\|\|` | `or` | or | **at least one** side is true |
| `!` | `not` | not | flips true to false and false to true |

(`||` is two "pipe" characters. The key is above Enter, with Shift.)

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: day number and hour
    int day = 0;    // 1 = Monday ... 7 = Sunday
    int hour = 0;   // 0 to 23
    cout << "Day (1-7): ";
    cin >> day;
    cout << "Hour (0-23): ";
    cin >> hour;

    // Processing: check for bad input using OR
    if (day < 1 || day > 7)
    {
        cout << "Error: day must be 1 to 7." << endl;
    }
    // Processing: weekday AND during school hours
    else if (day <= 5 && hour >= 8 && hour < 15)
    {
        cout << "School is in session." << endl;
    }
    else
    {
        cout << "No school right now." << endl;
    }

    // Processing: NOT - true when the day is not Sunday
    if (!(day == 7))
    {
        cout << "The library is open today." << endl;
    }
    return 0;
}
```

Sample run:
```
Day (1-7): 3
Hour (0-23): 10
School is in session.
The library is open today.
```

The **range check pattern** is worth memorizing. "Outside 1 to 7" is `day < 1 || day > 7`. "Inside 1 to 7" is `day >= 1 && day <= 7`. You will use both in almost every BPA program.

You **cannot** write `1 <= day <= 7` in C++. It builds, but it does the wrong thing. Always write two comparisons joined with `&&`.

**Try it:** Ask for a number. Print `In range` if it is from 1 to 10, otherwise `Out of range`. Write it once with `&&` and once with `||`.

---

## Nested if statements

An `if` can go inside another `if`. The inner one is only checked when the outer one is true.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: age and whether the person has a student ID (1 = yes, 0 = no)
    int age = 0;
    int hasStudentId = 0;
    cout << "Age: ";
    cin >> age;
    cout << "Student ID? (1 = yes, 0 = no): ";
    cin >> hasStudentId;

    // Processing + Output: nested decision for the movie ticket price
    if (age < 18)
    {
        if (hasStudentId == 1)
        {
            cout << "Price: $5" << endl;
        }
        else
        {
            cout << "Price: $7" << endl;
        }
    }
    else
    {
        cout << "Price: $10" << endl;
    }
    return 0;
}
```

Sample run:
```
Age: 15
Student ID? (1 = yes, 0 = no): 1
Price: $5
```

Indent each level so you can see which `else` belongs to which `if`. In Visual Studio, **Ctrl+K, Ctrl+D** fixes the indentation of the whole file.

---

## Comparing text and characters

### Strings

C++ `string` variables can be compared with `==` and `!=`, just like numbers. (Java is different; this is one place C++ is easier.)

```cpp
#include <iostream>
#include <string>
using namespace std;

int main()
{
    // Input: a password guess (full line)
    string guess;
    cout << "Password: ";
    getline(cin, guess);

    // Processing + Output: == compares the text exactly
    if (guess == "Tiger42")
    {
        cout << "Access granted." << endl;
    }
    else
    {
        cout << "Access denied." << endl;
    }
    return 0;
}
```

Sample runs:
```
Password: Tiger42
Access granted.
```
```
Password: tiger42
Access denied.
```

String comparison is **case-sensitive**: `"tiger42"` is not equal to `"Tiger42"`. To ignore case you change both to lowercase first. Steps 7 and 11 show how.

### Single characters

A `char` holds one character and uses **single quotes**: `'y'`. A `string` uses double quotes: `"y"`. Compare each with its own kind.

```cpp
char answer = 'y';
if (answer == 'y' || answer == 'Y')   // char compared with chars
{
    cout << "Yes!" << endl;
}
```

| What you type | Type | Meaning |
|---|---|---|
| `'A'` | `char` | one character |
| `"A"` | `string` (text) | text that happens to be one character long |

---

## The switch statement

A `switch` picks one of several blocks based on **one whole number or one character**. It is a tidy replacement for a long `if / else if` chain that checks the same variable against exact values. You will use it for **menus** in Step 11 and at BPA.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: a menu choice
    int choice = 0;
    cout << "1. Pizza  2. Salad  3. Soup" << endl;
    cout << "Choose (1-3): ";
    cin >> choice;

    // Processing + Output: run the matching case
    switch (choice)
    {
    case 1:
        cout << "Pizza is $3.00" << endl;
        break;
    case 2:
        cout << "Salad is $2.50" << endl;
        break;
    case 3:
        cout << "Soup is $2.00" << endl;
        break;
    default:
        cout << "Not on the menu." << endl;
        break;
    }
    return 0;
}
```

Sample run:
```
1. Pizza  2. Salad  3. Soup
Choose (1-3): 2
Salad is $2.50
```

| What you type | What it means |
|---|---|
| `switch (choice)` | Look at the value of `choice` |
| `case 1:` | Start here if `choice` is 1 (note the **colon**) |
| `break;` | Stop and jump past the end of the switch |
| `default:` | Runs if no case matched (like `else`) |

**Do not forget `break`.** Without it, C++ keeps running into the next case ("fall through"). Choosing 1 would print the pizza line **and** the salad line.

Rules:
- `switch` works on `int` and `char` values. It does **not** work on `string` or `double`.
- Each `case` must be a fixed value, not a range. For ranges like 90 to 100, use `if / else if`.

That is why the challenge uses `if / else if` for the letter grades: the grades are ranges.

**Try it:** Ask for a `char` like `'r'`, `'g'`, or `'b'` and use a `switch` to print `Red`, `Green`, or `Blue` (and `Unknown` for anything else).

---

## Ending the program early with return

`return 0;` inside `main` ends the program right there. Use it when there is nothing more to do, like after an error message.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: number of guests
    int guests = 0;
    cout << "Guests: ";
    cin >> guests;

    // Processing: stop right away if the number makes no sense
    if (guests < 1)
    {
        cout << "Error: need at least 1 guest." << endl;
        return 0;   // the program ends here
    }

    // Processing + Output: only reached when guests >= 1
    int pizzas = (guests + 2) / 3;   // one pizza per 3 guests, rounded up
    cout << "Order " << pizzas << " pizzas." << endl;
    return 0;
}
```

Sample run:
```
Guests: 0
Error: need at least 1 guest.
```

The other way is to put everything else inside an `else` block. Both are fine.

---

## Common mistakes

**1. `=` instead of `==`**
- Looks like: `if (score = 100)`
- Result: it **stores** 100 into `score`, and the condition is always true. Visual Studio may warn `C4706 assignment within conditional expression`; g++ warns `suggest parentheses around assignment used as truth value`.
- Fix: `if (score == 100)`.

**2. Semicolon after the if**
- Looks like: `if (score > 90);`
- Result: the `;` is an empty statement. The block below **always** runs.
- Fix: no `;` after `if (...)`.

**3. Checking ranges in the wrong order**
- Looks like: `if (score >= 60) ... else if (score >= 90)`
- Result: 95 gets a D, because `>= 60` matched first.
- Fix: check the highest range first.

**4. Writing a range like math**
- Looks like: `if (0 <= score <= 100)`
- Result: always true. It compares `0 <= score` (gives 0 or 1), then checks that 0 or 1 is `<= 100`.
- Fix: `if (score >= 0 && score <= 100)`.

**5. Missing `break` in a switch**
- Result: more than one case prints.
- Fix: end every case with `break;`.

**6. Comparing a char with double quotes**
- Looks like: `if (answer == "y")` where `answer` is a `char`.
- Error: `C2446 '==': no conversion from 'const char *' to 'int'` (g++: `ISO C++ forbids comparison between pointer and integer`)
- Fix: use single quotes for a `char`: `answer == 'y'`.

---

## How this shows up at BPA

- Every BPA menu program needs a decision for each choice and a range check for bad input. The 2026 regional required the menu to reject anything that is not 1 to 5.
- Range checks with `||` and `&&` are used for every validated number.
- Graders like a clean `switch` for a menu; Step 11 builds one.
- Exact messages matter. If the spec says `Error: score must be 0 to 100.`, print exactly that, period included.

---

## The challenge: Grade Checker

Write a program that asks for a student's name and score, then prints the letter grade and whether they passed.

**Requirements**
1. Header comment.
2. Ask for the student name and a score (whole number) with the exact prompts.
3. If the score is below 0 or above 100, print `Error: score must be 0 to 100.` and nothing else. Use a logical operator (or / `||`) in this check.
4. Otherwise print `<name> got a <letter>.` — 90–100 A, 80–89 B, 70–79 C, 60–69 D, below 60 F. Use "an" instead of "a" before A and F (`got an A.`, `got an F.`).
5. Then print `<name> passed.` for 60 or higher, otherwise `<name> did not pass.`
6. If the score is exactly 100, also print `Perfect score!` as the last line.
7. Input / Processing / Output comments.

**Sample run 1**
```
Student name: Taylor
Score (0-100): 87
Taylor got a B.
Taylor passed.
```
**Sample run 2**
```
Student name: Sam
Score (0-100): 105
Error: score must be 0 to 100.
```
**Sample run 3**
```
Student name: Riley
Score (0-100): 100
Riley got an A.
Riley passed.
Perfect score!
```
**Sample run 4**
```
Student name: Max
Score (0-100): 42
Max got an F.
Max did not pass.
```

**Hints**
- Read the name with `getline` first, then the score with `cin >>` (same order rule as Step 2).
- Store the letter in a `char` variable, and the word `a` or `an` in a `string` variable. Then one `cout` prints the sentence.
- After the error message, `return 0;` ends the program.
- Test all four sample runs, plus a score of exactly 90, 60, and 0.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step03`.
2. Put `step03.cpp` in it. (Visual Studio: push the whole project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 3 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches all four sample runs
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] The error check uses `||`
- [ ] `an` before A and F, `a` before B, C, D
- [ ] `Perfect score!` only for exactly 100
- [ ] Pushed to `bpaPrep/cpp_step03`
