# Step 02 — Variables, Input, Math, and Formatting (C++)

**What you'll build:** Snack Bar Order — a program that asks for an order and prints a receipt with tax.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Variables and data types](#variables-and-data-types)
- [Reading input with cin](#reading-input-with-cin)
- [Reading a full line with getline](#reading-a-full-line-with-getline)
- [Converting text to numbers](#converting-text-to-numbers)
- [Math operators](#math-operators)
- [The integer division trap](#the-integer-division-trap)
- [Named constants](#named-constants)
- [Formatting money with iomanip](#formatting-money-with-iomanip)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Snack Bar Order](#the-challenge-snack-bar-order)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to make variables and pick a data type: `string`, `int`, `double`, `bool`, `char`
- How to read a number or a word with `cin >>`
- How to read a whole line of text (with spaces) with `getline`
- How C++ turns typed text into numbers
- Math operators `+ - * / %` and the integer division trap
- How to make a named constant with `const`
- How to print money with exactly 2 decimal places using `<iomanip>`

---

## Variables and data types

A **variable** is a named box that holds a value. In Python you just write `score = 90`. In C++ you must also say **what type of value** the box holds. This is called **declaring** the variable. Once a variable has a type, it keeps that type.

| Type | Holds | Example |
|---|---|---|
| `int` | Whole numbers (no decimal point) | `int quantity = 3;` |
| `double` | Decimal numbers | `double price = 2.75;` |
| `string` | Text (needs `#include <string>`) | `string item = "Pretzel";` |
| `bool` | `true` or `false` | `bool isMember = true;` |
| `char` | One single character, in single quotes | `char grade = 'A';` |

```cpp
#include <iostream>
#include <string>   // needed for the string type
using namespace std;

int main()
{
    // Processing: declare and set some variables
    string teamName = "Blue Jays";
    int wins = 7;
    int losses = 2;
    double winRate = 0.78;
    bool inPlayoffs = true;
    char division = 'B';

    // Processing: change a variable - the old value is replaced
    wins = wins + 1;

    // Output: show the values
    cout << teamName << " (" << division << ")" << endl;
    cout << "Record: " << wins << "-" << losses << endl;
    cout << "Win rate: " << winRate << endl;
    cout << "Playoffs: " << inPlayoffs << endl;
    return 0;
}
```

What it prints:
```
Blue Jays (B)
Record: 8-2
Win rate: 0.78
Playoffs: 1
```

Notes:
- The `=` sign means **store** the value on the right into the variable on the left. `wins = wins + 1;` takes 7, adds 1, and stores 8.
- `cout` prints a `bool` as `1` (true) or `0` (false).
- **Name style:** C++ variables use **camelCase**: start lowercase, capitalize each new word (`teamName`, `winRate`). Use names that say what the value is. BPA graders check naming.
- **Always give a variable a starting value** (`int wins = 0;`). An `int` declared without a value holds random leftover memory, and Visual Studio may refuse to run (`C4700 uninitialized local variable used`).

**Try it:** Make variables for your name, age, GPA, and whether you have a driver's license. Print them on one line.

---

## Reading input with cin

`cin` (say "see-in") means **console input**. It reads what the user types. The arrows `>>` point **away from** `cin` and **into** the variable: the data flows from the keyboard into the box.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: two whole numbers from the keyboard
    int laps = 0;
    int minutes = 0;
    cout << "Laps run: ";
    cin >> laps;
    cout << "Minutes: ";
    cin >> minutes;

    // Processing: total distance (a lap is 400 meters)
    int meters = laps * 400;

    // Output: the result
    cout << "You ran " << meters << " meters in " << minutes << " minutes." << endl;
    return 0;
}
```

Sample run (user typed 8 and 12):
```
Laps run: 8
Minutes: 12
You ran 3200 meters in 12 minutes.
```

How `cin >>` works:
- It **skips spaces and Enter keys** at the start, then reads until the next space or Enter.
- So `cin >> word;` reads **one word**. If the user types `Soft Pretzel`, it only gets `Soft`. Use `getline` (next section) for text that can have spaces.
- It leaves the Enter key (the `\n`) sitting in the input, waiting. That matters soon.

| What you type | What it means |
|---|---|
| `cout << "Prompt: ";` | Show a prompt. No `endl`, so the user types on the same line. |
| `cin >> variable;` | Read one value (word or number) into the variable |

---

## Reading a full line with getline

`getline(cin, variable);` reads **everything the user typed** on the line, spaces included, up to the Enter key. It only works with `string` variables.

```cpp
#include <iostream>
#include <string>
using namespace std;

int main()
{
    // Input: two text answers that can contain spaces
    string fullName;
    string favoriteGame;
    cout << "Full name: ";
    getline(cin, fullName);
    cout << "Favorite game: ";
    getline(cin, favoriteGame);

    // Output: echo them back
    cout << fullName << " likes " << favoriteGame << "." << endl;
    return 0;
}
```

Sample run:
```
Full name: Ava Martinez
Favorite game: Mario Kart
Ava Martinez likes Mario Kart.
```

### A warning about mixing `cin >>` and `getline`

`cin >>` leaves the Enter key behind. If the very next thing is a `getline`, the `getline` sees that leftover Enter and returns an **empty string** right away. The user never gets to type.

For now, follow this simple rule: **ask the text questions first (with `getline`), then the number questions (with `cin >>`).** The challenge is set up so that works. Step 5 shows a one-line fix, and Step 7 explains the problem in full.

---

## Converting text to numbers

Everything a user types is text. In Python you had to write `int(input())` or `float(input())`. In C++, `cin >>` does the conversion **for you**, based on the variable's type:

- `cin >> quantity;` where `quantity` is an `int` turns the text `3` into the number 3.
- `cin >> price;` where `price` is a `double` turns the text `2.75` into the number 2.75.

There are also functions that convert a `string` you already have:

| What you type | What it means |
|---|---|
| `stoi(text)` | string to int: `stoi("42")` gives 42 |
| `stod(text)` | string to double: `stod("2.75")` gives 2.75 |
| `to_string(number)` | number to string: `to_string(42)` gives `"42"` |

You will use `stoi` and `stod` a lot in Steps 9 and 10.

**What if the user types letters where a number goes?** `cin` fails quietly, the variable gets 0, and every `cin` after that is skipped. The program does not crash, but it gives nonsense. That is fine for now. **Step 10 makes input crash-proof.**

---

## Math operators

| Operator | Meaning | Example | Result |
|---|---|---|---|
| `+` | add | `7 + 2` | `9` |
| `-` | subtract | `7 - 2` | `5` |
| `*` | multiply | `7 * 2` | `14` |
| `/` | divide | `7.0 / 2` | `3.5` |
| `%` | remainder (modulo), whole numbers only | `7 % 2` | `1` |

C++ follows normal math order: `*`, `/`, `%` before `+` and `-`. Use parentheses to be clear: `(a + b) / 2`.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: total minutes
    int totalMinutes = 0;
    cout << "Total minutes: ";
    cin >> totalMinutes;

    // Processing: split into hours and leftover minutes
    int hours = totalMinutes / 60;     // whole hours (int division drops the remainder)
    int minutes = totalMinutes % 60;   // what is left over

    // Output
    cout << totalMinutes << " minutes is " << hours << " hr " << minutes << " min" << endl;
    return 0;
}
```

Sample run:
```
Total minutes: 135
135 minutes is 2 hr 15 min
```

Shortcuts you will see:

| Shortcut | Same as |
|---|---|
| `count++;` | `count = count + 1;` |
| `count--;` | `count = count - 1;` |
| `total += price;` | `total = total + price;` |

---

## The integer division trap

When **both** sides of `/` are `int`, C++ does **whole-number division** and throws the decimal part away. It does not round.

```cpp
#include <iostream>
using namespace std;

int main()
{
    int points = 7;
    int games = 2;

    // Processing: three ways to divide
    double wrong = points / games;                        // int / int = 3, then stored as 3.0
    double right1 = static_cast<double>(points) / games;  // 7.0 / 2 = 3.5
    double right2 = points / 2.0;                         // 7 / 2.0 = 3.5

    // Output
    cout << wrong << " " << right1 << " " << right2 << endl;
    return 0;
}
```

What it prints:
```
3 3.5 3.5
```

Storing the answer in a `double` does **not** fix it. The division already happened with whole numbers. To get decimals, make at least one side a `double`:
- `static_cast<double>(points)` means "treat `points` as a double for this calculation." It is the clean C++ way to convert a type. You will see the older style `(double)points` too; it does the same thing.
- Or write the number with a decimal point: `2.0` instead of `2`.

In the challenge, `price` is a `double`, so `price * quantity` is already a `double`. The trap shows up again in Step 6 when you average whole-number scores.

---

## Named constants

A **constant** is a variable whose value can never change. Write `const` in front, and use ALL_CAPS with underscores for the name.

```cpp
const double SHIPPING_RATE = 0.05;
```

Why bother?
- The number has a **name**, so the code explains itself: `subtotal * SHIPPING_RATE` is clearer than `subtotal * 0.05`.
- If the rate changes, you change it in **one place**.
- If you accidentally try to change it later, the compiler stops you (`C3892 you cannot assign to a variable that is const`).

BPA graders like named constants instead of "magic numbers" scattered through the code.

---

## Formatting money with iomanip

By default `cout` prints decimals in the shortest way it can: `8.25` prints as `8.25`, but `3.0` prints as `3` and `0.5775` prints as `0.5775`. For money you want **exactly 2 decimal places**.

```cpp
#include <iostream>
#include <iomanip>   // needed for fixed and setprecision
using namespace std;

int main()
{
    // Processing: some prices
    double ticket = 3.0;
    double fee = 0.5775;

    // Output: before formatting
    cout << ticket << " " << fee << endl;

    // Output: after formatting - every double from now on shows 2 decimals
    cout << fixed << setprecision(2);
    cout << "$" << ticket << " $" << fee << endl;
    return 0;
}
```

What it prints:
```
3 0.5775
$3.00 $0.58
```

| What you type | What it means |
|---|---|
| `#include <iomanip>` | Bring in the I/O manipulators library ("iomanip") |
| `fixed` | Show decimals as a normal number, not scientific notation like `1.2e+05` |
| `setprecision(2)` | With `fixed`: always show exactly 2 digits after the decimal point, rounding the last one |
| `cout << fixed << setprecision(2);` | Turn both on. They **stay on** for every later `cout` |

Notes:
- The rounding only changes what is **printed**. The variable still holds the full value.
- Because the setting stays on, a plain `int` still prints normally (`3`), but every `double` prints with 2 decimals.
- The `$` is just text you print in front.

**Try it:** Ask for a distance in miles (double) and print it in kilometers (miles × 1.609) with 2 decimal places. Use a named constant for 1.609.

---

## Common mistakes

**1. Using a variable that was never declared**
- Looks like: `price = 2.75;` with no `double price` line.
- Error: `C2065 'price': undeclared identifier` (g++: `'price' was not declared in this scope`)
- Fix: declare it with its type first: `double price = 0.0;`

**2. `cin >>` with text that has spaces**
- Looks like: `cin >> item;` and the user types `Soft Pretzel`.
- Result: `item` is only `Soft`. The word `Pretzel` stays in the input and gets read by the next `cin`, causing strange results.
- Fix: use `getline(cin, item);` for text.

**3. `getline` after `cin >>` gets skipped**
- Looks like: the program prints `Item: Price:` on one line and never lets you type the item.
- Fix: ask the text questions before the number questions (the rule above). Step 5 shows `cin.ignore`.

**4. Integer division**
- Looks like: `double average = total / count;` with two `int`s.
- Wrong output: `3` instead of `3.5`.
- Fix: `static_cast<double>(total) / count`.

**5. Money printing as `8.2500001` or `3`**
- Fix: `cout << fixed << setprecision(2);` and `#include <iomanip>`.

**6. Forgot `#include <string>` or `#include <iomanip>`**
- Error: `'setprecision': identifier not found` or `'string': undeclared identifier`.
- Fix: add the include. (Visual Studio sometimes lets `string` work without the include because `<iostream>` pulls it in, but other compilers do not. Always include it.)

**7. Wrong arrows on cin**
- Looks like: `cin << price;`
- Error: a long message with `binary '<<': no operator found`.
- Fix: input is `cin >>` (into the variable). Output is `cout <<`.

---

## How this shows up at BPA

- Every BPA program reads input. Knowing when to use `cin >>` and when to use `getline` avoids the most common C++ input bug.
- Money and averages must be shown with **2 decimal places**. The 2024 regional said "shown with only 2 decimal places." `fixed` and `setprecision(2)` do this.
- Graders review "data types handled in a logical and consistent manner." Use `int` for counts, `double` for money, `string` for text.
- Named constants and clear camelCase names count in source code review.
- **No global variables.** The 2024 test said this. Declare variables inside `main` (or inside functions, Step 5). A `const` above `main` is fine; a changeable variable above `main` is not.

---

## The challenge: Snack Bar Order

Write a program that takes one snack bar order and prints a receipt.

**Requirements**
1. Header comment.
2. Ask for the customer's name, the item, the price (decimal), and the quantity (whole number) using the exact prompts below.
3. Store the tax rate in a named constant (`TAX_RATE = 0.07`).
4. Calculate subtotal (price × quantity), tax (subtotal × TAX_RATE), and total (subtotal + tax).
5. Print the receipt exactly as shown, money with 2 decimal places.
6. Input / Processing / Output comments on each block.

**Sample run (exact)**
```
Customer name: Jordan
Item: Pretzel
Price: 2.75
Quantity: 3

--- Receipt for Jordan ---
Item:      Pretzel
Quantity:  3
Subtotal:  $8.25
Tax (7%):  $0.58
Total:     $8.83
```

There is no input checking yet. If you type letters for the price, the program gives wrong answers. **Step 10 makes it crash-proof.**

**Hints**
- Read the name and item with `getline`, then the price and quantity with `cin >>`.
- In C++ the constant is `const double TAX_RATE = 0.07;`
- There is a blank line before `--- Receipt for Jordan ---`. `cout << endl;` prints one.
- Look closely at the spaces after each label. `Item:` is followed by 6 spaces so the values line up.
- Put `cout << fixed << setprecision(2);` before you print the money lines.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step02`.
2. Put `step02.cpp` in it. (Visual Studio: push the whole project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 2 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `const double TAX_RATE = 0.07;` is used for the tax
- [ ] `getline` for the name and item, `cin >>` for the numbers
- [ ] Money shows exactly 2 decimal places
- [ ] Pushed to `bpaPrep/cpp_step02`
