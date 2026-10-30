# Step 05 — Functions (C++)

**What you'll build:** Snack Bar with Functions — the Step 2 snack bar rebuilt so an order can have several items, with each job done by its own function.
**Time:** about one class period (2 hours). This is an important step; take longer if you need it.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Why use functions](#why-use-functions)
- [Writing and calling a function](#writing-and-calling-a-function)
- [Parameters](#parameters)
- [Return values](#return-values)
- [void functions](#void-functions)
- [main is a function too](#main-is-a-function-too)
- [Function prototypes](#function-prototypes)
- [Local variables and scope](#local-variables-and-scope)
- [Passing by value and by reference](#passing-by-value-and-by-reference)
- [The function comment block](#the-function-comment-block)
- [Building text with ostringstream](#building-text-with-ostringstream)
- [Fixing getline after cin](#fixing-getline-after-cin)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Snack Bar with Functions](#the-challenge-snack-bar-with-functions)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What a function is and why BPA requires them
- How to write a function, give it parameters, and return a value
- `void` functions that do a job but return nothing
- How `main` fits in, and what a **function prototype** is
- Local variables and scope (where a variable exists)
- The difference between passing **by value** and **by reference** (`&`)
- The function comment block: purpose, parameters, return value
- How to build a string the way `cout` prints, with `ostringstream`
- How to fix the `getline` after `cin >>` problem with `cin.ignore`

---

## Why use functions

A **function** is a named block of code that does one job. You write it once and **call** it (run it) as many times as you need.

- **No repeated code.** If you need the same calculation in three places, write it once.
- **Easier to read.** `printReceipt(name, count, subtotal);` tells you what happens without reading 10 lines.
- **Easier to fix.** A bug in a function is fixed in one place.
- **BPA requires it.** The 2026 regional said "Each menu option should have its own function." Source code review gives points for each required function being "designed and used correctly."

In Python you wrote `def area(width, height):`. In C++ you also write the **types**.

---

## Writing and calling a function

```cpp
#include <iostream>
using namespace std;

// Purpose: print a line of 20 stars.
// Parameters: none
// Returns: nothing
void printStars()
{
    // Output: 20 stars and a new line
    for (int i = 0; i < 20; i++)
    {
        cout << "*";
    }
    cout << endl;
}

int main()
{
    // Output: use the function twice, around a title
    printStars();
    cout << "  SCIENCE FAIR" << endl;
    printStars();
    return 0;
}
```

What it prints:
```
********************
  SCIENCE FAIR
********************
```

| Part | Example | Meaning |
|---|---|---|
| Return type | `void` | What kind of value the function gives back. `void` means nothing. |
| Name | `printStars` | camelCase, a verb that says what it does |
| Parameters | `()` | Values the function needs. Empty here. |
| Body | `{ ... }` | The code that runs when the function is called |
| Call | `printStars();` | Runs the function. The parentheses are required, even when empty. |

When C++ reaches `printStars();` it jumps into the function, runs it top to bottom, then comes back to the line after the call.

---

## Parameters

A **parameter** is a variable in the function's parentheses that receives a value from the call. Each parameter has a type and a name, separated by commas.

```cpp
#include <iostream>
#include <string>
using namespace std;

// Purpose: print a line made of any character, any length.
// Parameters: symbol - the character to repeat; length - how many times
// Returns: nothing
void printLine(char symbol, int length)
{
    // Output: the line
    for (int i = 0; i < length; i++)
    {
        cout << symbol;
    }
    cout << endl;
}

// Purpose: greet a person by name.
// Parameters: name - who to greet
// Returns: nothing
void greet(string name)
{
    // Output: one greeting line
    cout << "Welcome, " << name << "!" << endl;
}

int main()
{
    // Output: the values in the call are copied into the parameters, in order
    printLine('=', 12);
    greet("Ava");
    greet("Ben");
    printLine('-', 12);
    return 0;
}
```

What it prints:
```
============
Welcome, Ava!
Welcome, Ben!
------------
```

The values in the call (`'='` and `12`) are called **arguments**. They are matched to the parameters **by position**: the first argument goes into the first parameter. The types must fit: `printLine("=", 12)` with double quotes is an error, because `symbol` is a `char`.

---

## Return values

A function can **calculate** a value and hand it back with `return`. The return type before the name says what kind of value comes back.

```cpp
#include <iostream>
using namespace std;

// Purpose: work out the area of a rectangle.
// Parameters: width, height - the sides, in feet
// Returns: width times height
double calculateArea(double width, double height)
{
    // Processing: multiply
    return width * height;
}

// Purpose: check if a number is even.
// Parameters: number - the whole number to check
// Returns: true if even, false if odd
bool isEven(int number)
{
    // Processing: even numbers have remainder 0 when divided by 2
    return number % 2 == 0;
}

int main()
{
    // Processing: store a returned value in a variable
    double roomArea = calculateArea(12.0, 10.5);

    // Output: or use the returned value directly
    cout << "Room: " << roomArea << " sq ft" << endl;
    cout << "Closet: " << calculateArea(3.0, 4.0) << " sq ft" << endl;

    if (isEven(14))
    {
        cout << "14 is even" << endl;
    }
    return 0;
}
```

What it prints:
```
Room: 126 sq ft
Closet: 12 sq ft
14 is even
```

Rules:
- `return` ends the function immediately and sends the value back to the call.
- A function with a return type (like `double`) **must** return a value of that type on every path. If you forget, Visual Studio says `C4715 not all control paths return a value`.
- The call **becomes** the value. `calculateArea(3.0, 4.0)` is replaced by `12`.
- A returned value is lost if you do not store it or use it. `calculateArea(3.0, 4.0);` alone on a line does the math and throws the answer away.

---

## void functions

A `void` function does a job (usually printing) and returns nothing. You call it on its own line. You cannot store its result, because there is none.

```cpp
void printReport(int wins, int losses);   // does a job, returns nothing
int countWins(...);                        // calculates and returns a number
```

A good habit: functions that **calculate** return a value and do not print. Functions that **print** are `void` and do not do big calculations. The challenge follows this: `calculateSubtotal`, `calculateTax`, and `formatMoney` return values; `printReceipt` prints.

---

## main is a function too

`main` is the function C++ calls to start your program. `int main()` means it returns an `int`; `return 0;` sends 0 back to Windows to say "finished normally."

In C++ there is no extra line needed to start `main` (Python needs `if __name__ == "__main__": main()`). C++ always starts at `main`.

---

## Function prototypes

C++ reads your file **from top to bottom**. You must tell it a function exists **before** you call it. There are two ways.

**Way 1: define every function above `main`.** This is what the examples above do. It works, but `main` ends up at the bottom of a long file.

**Way 2: put a prototype above `main`, and the full function below.** A **prototype** is the first line of the function, with a semicolon instead of a body. It is a promise: "this function exists; its full code is further down."

```cpp
#include <iostream>
using namespace std;

// Function prototypes - promises that these functions exist below main
int square(int number);
void printResult(int number, int result);

// Purpose: starting point.
// Parameters: none
// Returns: 0 when the program ends normally
int main()
{
    // Processing + Output: square 1 to 3
    for (int i = 1; i <= 3; i++)
    {
        printResult(i, square(i));
    }
    return 0;
}

// Purpose: multiply a number by itself.
// Parameters: number - the number to square
// Returns: number times number
int square(int number)
{
    return number * number;
}

// Purpose: print one line of the squares table.
// Parameters: number - the original number; result - its square
// Returns: nothing
void printResult(int number, int result)
{
    // Output: one line
    cout << number << " squared is " << result << endl;
}
```

What it prints:
```
1 squared is 1
2 squared is 4
3 squared is 9
```

The prototype must match the real function: same return type, same name, same parameter types. If they do not match, you get a **linker** error like `LNK2019 unresolved external symbol "int __cdecl square(double)"`. That means "you promised a function that I can't find." Compare the prototype and the function line by line.

**Use Way 2 at BPA.** `main` stays near the top, and the prototype list works like a table of contents for graders.

---

## Local variables and scope

A variable made **inside** a function (or inside any `{ }`) is a **local variable**. It only exists inside those braces. When the function ends, the variable is gone. This is called **scope**.

```cpp
#include <iostream>
using namespace std;

// Purpose: add a bonus to a score.
// Parameters: score - the starting score
// Returns: the score plus 10
int addBonus(int score)
{
    int bonus = 10;          // local to addBonus
    score = score + bonus;   // changes addBonus's own copy of score
    return score;
}

int main()
{
    int score = 80;                    // local to main - a different variable
    int newScore = addBonus(score);

    // Output: main's score did not change
    cout << "score: " << score << endl;
    cout << "newScore: " << newScore << endl;
    // cout << bonus;   // error C2065: 'bonus': undeclared identifier - it only exists in addBonus
    return 0;
}
```

What it prints:
```
score: 80
newScore: 90
```

Notes:
- Two functions can each have a variable named `score`. They are separate boxes.
- To get a value **into** a function, pass it as a parameter. To get a value **out**, return it.
- A variable declared **above all functions** is a **global variable**. Every function can see and change it. **Avoid global variables.** The 2024 BPA rubric said "no global variables" and gave points for it. Constants (`const double TAX_RATE = 0.07;`) above `main` are fine, because they cannot change.

---

## Passing by value and by reference

Look again at `addBonus` above. Changing `score` inside the function did **not** change `score` in `main`. That is because C++ normally passes a **copy** of the value. This is called **passing by value**.

Sometimes you **want** the function to change the caller's variable. Put `&` after the type. That makes the parameter a **reference**: another name for the caller's actual variable, not a copy.

```cpp
#include <iostream>
using namespace std;

// Purpose: add points to a score, changing the caller's variable.
// Parameters: score - passed by reference (&), so changes stick; points - how many to add
// Returns: nothing
void addPoints(int& score, int points)
{
    // Processing: this changes the original variable in main
    score = score + points;
}

int main()
{
    int teamScore = 50;
    addPoints(teamScore, 15);
    addPoints(teamScore, 5);

    // Output: the original changed
    cout << "Team score: " << teamScore << endl;
    return 0;
}
```

What it prints:
```
Team score: 70
```

| Parameter | Name | What happens |
|---|---|---|
| `int score` | by value | The function gets a copy. Changes do not affect the caller. |
| `int& score` | by reference | The function works on the caller's variable. Changes stick. |
| `const vector<int>& scores` | by const reference | No copy is made (fast), and `const` means the function promises not to change it. You will use this for lists in Step 6. |

For this step, pass everything by value. You will use `&` in Steps 6, 8, and 11.

---

## The function comment block

Every function gets a comment block right above it with three parts. BPA graders look for this.

```cpp
// Purpose: what the function does, in one sentence.
// Parameters: each parameter's name and what it is (or "none")
// Returns: what value it gives back (or "nothing" for void)
```

Inside the function, keep using **Input / Processing / Output** comments on each block.

---

## Building text with ostringstream

`cout << fixed << setprecision(2) << amount` prints money nicely. But what if you want that text in a **string** to return from a function, like `formatMoney(12.04)` returning `"$12.04"`?

An **ostringstream** (output string stream) works exactly like `cout`, but instead of printing, it collects the text. Then `.str()` gives you the text as a `string`. It needs `#include <sstream>`.

```cpp
#include <iostream>
#include <string>
#include <sstream>   // ostringstream
#include <iomanip>   // fixed, setprecision
using namespace std;

// Purpose: make a percent label like 85.5%
// Parameters: value - the number to show
// Returns: the text with 1 decimal place and a % sign
string formatPercent(double value)
{
    // Processing: build the text the same way cout would print it
    ostringstream text;
    text << fixed << setprecision(1) << value << "%";
    return text.str();
}

int main()
{
    // Output: use the returned strings
    string label = formatPercent(85.46);
    cout << "Attendance: " << label << endl;
    cout << "Pass rate: " << formatPercent(92) << endl;
    return 0;
}
```

What it prints:
```
Attendance: 85.5%
Pass rate: 92.0%
```

Use the same pattern for `formatMoney`, with `"$"` in front and `setprecision(2)`.

---

## Fixing getline after cin

In Step 2 you avoided a problem by asking text questions first. Now the order repeats in a loop, so you hit it. Here is what happens:

1. `cin >> quantity;` reads `3`, but leaves the **Enter key** (`\n`) in the input.
2. `cin >> answer;` reads `y`, and again leaves the Enter key.
3. The loop goes back to `getline(cin, item);`. `getline` reads up to the next Enter key. The leftover Enter is **right there**, so `getline` returns an empty string immediately. The program prints `Item: Price:` and never lets you type the item.

The fix: after the last `cin >>` before a `getline`, throw away the rest of the line:

```cpp
cin >> answer;
cin.ignore(1000, '\n');   // skip up to 1000 characters, stopping after the Enter key
```

| What you type | What it means |
|---|---|
| `cin.ignore(1000, '\n');` | Throw away characters from the input until an Enter key has been thrown away (or 1000 characters, whichever comes first). |

Step 7 explains this problem fully. Step 10 removes it completely by reading **every** input with `getline`.

---

## Common mistakes

**1. Calling a function before C++ knows about it**
- Error: `C3861 'calculateTax': identifier not found` (g++: `'calculateTax' was not declared in this scope`)
- Fix: add a prototype above `main`, or move the function above `main`.

**2. Prototype does not match the function**
- Error: `LNK2019 unresolved external symbol` (g++: `undefined reference to 'calculateTax(int)'`)
- Fix: make the return type, name, and parameter types the same in both places.

**3. Forgetting to use the return value**
- Looks like: `calculateTax(subtotal);` on its own line, then printing `tax`, which is still 0.
- Fix: `double tax = calculateTax(subtotal);`

**4. A semicolon after the function's first line**
- Looks like: `double calculateTax(double subtotal); { ... }`
- Error: `C2447 '{': missing function header (old-style formal list?)`
- Fix: a `;` goes after a **prototype** only, never before a body.

**5. Missing return**
- Warning: `C4715 'calculateTax': not all control paths return a value`
- Result: garbage numbers.
- Fix: every non-`void` function must `return` a value.

**6. getline skipped in the loop**
- Looks like: `Item: Price:` on one line.
- Fix: `cin.ignore(1000, '\n');` after the `cin >>` that comes right before the `getline`.

---

## How this shows up at BPA

- The 2026 regional named every required function (`readCSV`, `randomPassword`, `reverseSentence`, `simpleCalculator`, `exitProgram`) and said what each one takes in and returns. You must match the names and the return types exactly.
- The 2024 regional asked for functions that "take in the text as a parameter" and "return the number as an integer." That is parameters and return values, exactly as in this step.
- Source code review awards points for **each** function being designed and used correctly, and for function comments.
- **No global variables.** Pass values in as parameters and get them back with `return`.

---

## The challenge: Snack Bar with Functions

Rebuild the Step 2 snack bar so an order can have several items, using functions.

**Requirements**
1. Header comment.
2. Rebuild the Step 2 snack bar so an order can have **several items**: after each item ask `Add another item? (y/n): `.
3. Write these functions (names in your language's style):
   - `calculateSubtotal(price, quantity)` → returns price × quantity
   - `calculateTax(subtotal)` → returns subtotal × TAX_RATE
   - `formatMoney(amount)` → returns text like `$12.04`
   - `printReceipt(name, itemCount, subtotal)` → prints the receipt (calls `calculateTax` and `formatMoney`), returns nothing
   - `main()` → asks the questions, keeps the running subtotal and item count, calls `printReceipt`
4. Every function has a comment with its purpose, parameters, and return value.
5. Input / Processing / Output comments.

(C++ names use camelCase: `calculate_subtotal` in the shared spec is `calculateSubtotal` here.)

**Sample run (exact)**
```
Customer name: Jordan
Item: Pretzel
Price: 2.75
Quantity: 3
Add another item? (y/n): y
Item: Lemonade
Price: 1.50
Quantity: 2
Add another item? (y/n): n

--- Receipt for Jordan ---
Items ordered: 5
Subtotal:  $11.25
Tax (7%):  $0.79
Total:     $12.04
```
`Items ordered` is the total quantity: 3 + 2.

**Hints**
- Put `const double TAX_RATE = 0.07;` above `main` so `calculateTax` can use it. A constant above `main` is allowed; a changeable variable there is not.
- Use prototypes above `main` and the function bodies below it.
- Keep `runningSubtotal` and `itemCount` in `main`, starting at 0. Add to them inside the loop.
- The loop is like Step 4's play-again loop: a `string` answer that starts as `"y"`.
- Remember `cin.ignore(1000, '\n');` after reading the y/n answer.
- `formatMoney` uses an `ostringstream`. Don't forget `#include <sstream>` and `#include <iomanip>`.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step05`.
2. Put `step05.cpp` in it. (Visual Studio: push the whole project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 5 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] All five functions exist with the right names, parameters, and return types
- [ ] Every function has a purpose / parameters / returns comment
- [ ] Prototypes above `main`
- [ ] No global variables (the `TAX_RATE` constant is fine)
- [ ] Pushed to `bpaPrep/cpp_step05`
