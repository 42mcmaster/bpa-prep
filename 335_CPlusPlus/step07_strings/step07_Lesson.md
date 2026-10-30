# Step 07 — Strings (C++)

**What you'll build:** Secret Message — a Caesar cipher that encodes and decodes messages and counts the letters and vowels.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [A string is a list of characters](#a-string-is-a-list-of-characters)
- [Looping over characters](#looping-over-characters)
- [Checking characters with cctype](#checking-characters-with-cctype)
- [Character codes and char math](#character-codes-and-char-math)
- [Wrapping around with the modulo operator](#wrapping-around-with-the-modulo-operator)
- [Building and changing strings](#building-and-changing-strings)
- [Useful string functions](#useful-string-functions)
- [The leftover newline problem](#the-leftover-newline-problem)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Secret Message](#the-challenge-secret-message)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- A `string` is a sequence of `char` values, with index numbers like a vector
- How to loop over every character
- `<cctype>` functions: `isalpha`, `isdigit`, `isupper`, `islower`, `isspace`, `toupper`, `tolower`
- Character codes (ASCII) and doing math with `char` values
- Using `%` to wrap around, and why C++'s `%` is different from Python's with negative numbers
- Building a new string, and changing a string in place
- Useful string functions: `length`, `substr`, `find`, `replace`, `insert`, `erase`, and reversing
- Why `getline` gets skipped after `cin >>`, and the fixes

---

## A string is a list of characters

A `string` holds characters in order. Each character is a `char`, and each has an index starting at 0, just like a vector (Step 6).

```cpp
#include <iostream>
#include <string>
using namespace std;

int main()
{
    string word = "Robot";

    // Output: length and single characters
    cout << "Length: " << word.length() << endl;
    cout << "First: " << word[0] << endl;
    cout << "Last: " << word[word.length() - 1] << endl;

    // Processing: C++ strings can be changed in place
    word[0] = 'r';
    cout << "Changed: " << word << endl;
    return 0;
}
```

What it prints:
```
Length: 5
First: R
Last: t
Changed: robot
```

| What you type | What it means |
|---|---|
| `word.length()` or `word.size()` | Number of characters (both do the same thing) |
| `word[0]` | The first character (a `char`) |
| `word[word.length() - 1]` | The last character |
| `word[0] = 'r';` | Change one character. Note single quotes: it is a `char`. |

**C++ strings can be changed in place.** In Java and C# you can't change a character inside a string; you have to build a new one. In C++ `word[0] = 'r';` just works. That makes the cipher simpler.

---

## Looping over characters

The same two loops from Step 6 work on strings.

```cpp
#include <iostream>
#include <string>
using namespace std;

int main()
{
    string phone = "330-555-0142";

    // Processing: for-each loop - count the dashes
    int dashes = 0;
    for (char c : phone)
    {
        if (c == '-')
        {
            dashes++;
        }
    }

    // Output: counting loop - print each character with its index
    for (size_t i = 0; i < 4; i++)
    {
        cout << i << "=" << phone[i] << " ";
    }
    cout << endl;
    cout << "Dashes: " << dashes << endl;
    return 0;
}
```

What it prints:
```
0=3 1=3 2=0 3=- 
Dashes: 2
```

---

## Checking characters with cctype

The `<cctype>` library has functions that test or change **one character**.

| What you type | Returns true (non-zero) when the character is... |
|---|---|
| `isalpha(c)` | a letter A-Z or a-z |
| `isdigit(c)` | a digit 0-9 |
| `isalnum(c)` | a letter or a digit |
| `isupper(c)` | an uppercase letter |
| `islower(c)` | a lowercase letter |
| `isspace(c)` | a space, tab, or newline |
| `ispunct(c)` | punctuation like `! , . ?` |

| What you type | Gives back |
|---|---|
| `toupper(c)` | the uppercase version (other characters unchanged) |
| `tolower(c)` | the lowercase version (other characters unchanged) |

```cpp
#include <iostream>
#include <string>
#include <cctype>   // isalpha, isdigit, isupper, toupper, ...
using namespace std;

int main()
{
    string code = "Room 2B, Wing C!";

    // Processing: count each kind of character
    int letters = 0;
    int digits = 0;
    int capitals = 0;
    for (char c : code)
    {
        if (isalpha(c))
        {
            letters++;
        }
        if (isdigit(c))
        {
            digits++;
        }
        if (isupper(c))
        {
            capitals++;
        }
    }

    // Processing: make an all-caps copy, changing each character in place
    string shout = code;
    for (size_t i = 0; i < shout.length(); i++)
    {
        shout[i] = toupper(shout[i]);
    }

    // Output
    cout << "Letters: " << letters << ", digits: " << digits << ", capitals: " << capitals << endl;
    cout << shout << endl;
    return 0;
}
```

What it prints:
```
Letters: 10, digits: 1, capitals: 4
ROOM 2B, WING C!
```

**Checking for vowels:** there is no `isvowel`. Make the character lowercase first, then compare with each vowel:

```cpp
char lower = tolower(c);
if (lower == 'a' || lower == 'e' || lower == 'i' || lower == 'o' || lower == 'u')
```

---

## Character codes and char math

Inside the computer each character is stored as a number, its **character code** (ASCII). You don't need to memorize the codes. You only need to know that the letters are **in order**:

| Character | Code |
|---|---|
| `'A'` | 65 |
| `'B'` | 66 |
| `'Z'` | 90 |
| `'a'` | 97 |
| `'z'` | 122 |
| `'0'` | 48 |

Because a `char` is a number underneath, you can do math with it. Python needs `ord()` and `chr()` for this; C++ does it directly.

```cpp
#include <iostream>
using namespace std;

int main()
{
    char letter = 'D';

    // Processing: position in the alphabet - subtract the first letter
    int position = letter - 'A';          // 'D' - 'A' = 68 - 65 = 3

    // Processing: go forward 2 letters, and turn a position back into a letter
    char later = letter + 2;              // 'F'
    char fromPosition = 'A' + 7;          // 'H'

    // Output: a char prints as a letter; (int) shows its code
    cout << letter << " is at position " << position << endl;
    cout << later << " " << fromPosition << endl;
    cout << "Code for " << letter << ": " << static_cast<int>(letter) << endl;
    return 0;
}
```

What it prints:
```
D is at position 3
F H
Code for D: 68
```

The pattern for the cipher:
1. `letter - base` turns a letter into a position 0-25 (`base` is `'A'` for capitals, `'a'` for lowercase).
2. Do math on the position.
3. `base + position` turns it back into a letter.

---

## Wrapping around with the modulo operator

`%` gives the remainder (Step 2). Remainders are perfect for **wrapping around**: after the last item, go back to the first.

Example: hours on a 12-hour clock are positions 0-11. Five hours after 9 o'clock:

```
(9 + 5) % 12 = 14 % 12 = 2
```

The alphabet works the same way with 26: position 24 (`Y`) plus 3 is 27, and `27 % 26 = 1` (`B`).

### The negative number problem

Going **backward** gives negative numbers. Position 1 (`B`) minus 3 is -2. What is `-2 % 26`?

| Language | `-2 % 26` |
|---|---|
| Python | `24` (always positive) |
| **C++**, Java, C# | **`-2`** (keeps the sign) |

In C++ you get -2, which is not a letter position. The fix is to add 26 and take `%` again:

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Processing: go back 3 days from day 1 (Tuesday) in a 7-day week
    int today = 1;    // 0 = Monday, 1 = Tuesday, ... 6 = Sunday
    int back = -3;

    int wrong = (today + back) % 7;               // -2: not a real day
    int right = ((today + back) % 7 + 7) % 7;     // 5: Saturday

    // Output
    cout << "Wrong: " << wrong << endl;
    cout << "Right: " << right << endl;
    return 0;
}
```

What it prints:
```
Wrong: -2
Right: 5
```

How `((x % n) + n) % n` works: the first `%` gives something from `-(n-1)` to `n-1`. Adding `n` makes it positive. The second `%` brings it back into `0` to `n-1`. It is correct for positive numbers too.

For the cipher: `((position + shift) % 26 + 26) % 26`.

### Why decode can call encode

Decoding with shift 3 means moving each letter **back** 3. Encoding with shift **-3** moves each letter back 3. So `decode(message, 3)` can simply `return encode(message, -3);`. That only works because the `% 26 + 26) % 26` formula handles negative shifts. One function does both jobs, with no repeated code.

---

## Building and changing strings

Two ways to make a changed version of a string:

```cpp
#include <iostream>
#include <string>
using namespace std;

int main()
{
    string original = "a-b-c";

    // Processing: Way 1 - build a new string with +=
    string noDashes = "";
    for (char c : original)
    {
        if (c != '-')
        {
            noDashes += c;   // add one character to the end
        }
    }

    // Processing: Way 2 - change a copy in place
    string withSpaces = original;
    for (size_t i = 0; i < withSpaces.length(); i++)
    {
        if (withSpaces[i] == '-')
        {
            withSpaces[i] = ' ';
        }
    }

    // Output
    cout << noDashes << endl;
    cout << withSpaces << endl;
    return 0;
}
```

What it prints:
```
abc
a b c
```

- Build a new string when the result is a **different length** (removing or adding characters).
- Change in place when each character is replaced by **one** character (the cipher is like this).

A function that takes a `string` parameter **by value** (Step 5) gets its own copy. It can change that copy in place and return it, and the caller's string is untouched. The challenge's `encode` can work this way.

`+` also joins whole strings: `string full = first + " " + last;`

---

## Useful string functions

| What you type | What it does | Example with `s = "Game Night"` |
|---|---|---|
| `s.length()` | number of characters | `10` |
| `s.substr(start, count)` | part of the string | `s.substr(5, 5)` is `"Night"` |
| `s.substr(start)` | from `start` to the end | `s.substr(5)` is `"Night"` |
| `s.find(text)` | index where `text` first appears, or `string::npos` if not found | `s.find("Night")` is `5` |
| `s.replace(start, count, text)` | replace part of it | `s.replace(0, 4, "Movie")` makes `"Movie Night"` |
| `s.insert(pos, text)` | insert text | `s.insert(0, "Big ")` makes `"Big Game Night"` |
| `s.erase(start, count)` | remove characters | `s.erase(4, 6)` makes `"Game"` |
| `s.empty()` | `true` if the string is `""` | `false` |
| `reverse(s.begin(), s.end());` | reverse in place (`#include <algorithm>`) | `"thgiN emaG"` |

```cpp
#include <iostream>
#include <string>
#include <algorithm>   // reverse
using namespace std;

int main()
{
    string email = "jordan.lee@mccc.org";

    // Processing: find the @ and split the email into two parts
    size_t at = email.find("@");
    string user = email.substr(0, at);
    string domain = email.substr(at + 1);

    // Processing: does it contain "mccc"?
    bool isSchool = email.find("mccc") != string::npos;

    // Processing: reversed copy
    string backward = user;
    reverse(backward.begin(), backward.end());

    // Output
    cout << "User: " << user << endl;
    cout << "Domain: " << domain << endl;
    cout << "School email: " << isSchool << endl;
    cout << "Backward: " << backward << endl;
    return 0;
}
```

What it prints:
```
User: jordan.lee
Domain: mccc.org
School email: 1
Backward: eel.nadroj
```

`string::npos` is a special value meaning "not found." The pattern `text.find(part) != string::npos` means "text **contains** part." You will use it for searching in Step 11.

Splitting a line on commas uses a `stringstream`; that is in Step 9. Trimming spaces off the ends is in Step 10.

**Try it:** The 2026 regional had a "reverse a sentence" option. Write a program that reads a full line with `getline` and prints it backward, spaces and punctuation included.

---

## The leftover newline problem

This is the most common C++ input bug. You met it in Steps 2 and 5. Here is the full explanation.

When you type `e` and press Enter, the input holds two characters: `e` and `\n` (the Enter key).

```
input waiting:   e \n
```

1. `cin >> mode;` reads `e`. It stops at the `\n` and **leaves it there**.
   ```
   input waiting:   \n
   ```
2. `getline(cin, message);` reads everything **up to the next `\n`**. The `\n` is the very first thing waiting. So `getline` reads **nothing**, removes the `\n`, and returns `""`. The user never gets to type a message.

`cin >>` doesn't have this problem with itself, because `cin >>` **skips** any spaces and Enters before a value. Only `getline` after `cin >>` is affected.

```cpp
#include <iostream>
#include <string>
using namespace std;

int main()
{
    // Input: a number with cin >>, then a line with getline
    int tableNumber = 0;
    string guestName;

    cout << "Table number: ";
    cin >> tableNumber;
    cin.ignore(1000, '\n');   // FIX: throw away the leftover Enter
                              // (delete this line to see the bug)
    cout << "Guest name: ";
    getline(cin, guestName);

    // Output
    cout << guestName << " sits at table " << tableNumber << "." << endl;
    return 0;
}
```

Sample run:
```
Table number: 4
Guest name: Ava Martinez
Ava Martinez sits at table 4.
```

Without the `cin.ignore` line, the run looks like this. The program does not wait for the name:
```
Table number: 4
Guest name:  sits at table 4.
```

Three fixes, from simplest to best:

| Fix | Code | Notes |
|---|---|---|
| Order the questions | `getline` questions first, `cin >>` after | Only works when the order allows it (Step 2) |
| Ignore the rest of the line | `cin.ignore(1000, '\n');` after the `cin >>` | Put it right after the last `cin >>` that comes before a `getline` |
| Read **everything** with `getline` | `getline(cin, text);` then convert with `stoi` | No leftovers ever. **Step 10 does this**, and it also stops bad input from breaking `cin`. |

For this challenge: `cin >> mode;` then `cin.ignore(1000, '\n');` then `getline(cin, message);`.

---

## Common mistakes

**1. `getline` skipped**
- Looks like: `Message: Shift (1-25):` on one line.
- Fix: `cin.ignore(1000, '\n');` after the `cin >>` before it.

**2. Reading the message with `cin >>`**
- Looks like: the result is only `Phhw` (the first word).
- Fix: `getline(cin, message);`

**3. Negative `%`**
- Looks like: decoding gives strange symbols like `J` turning into `G` but `A` turning into `>`.
- Cause: `(position - 3) % 26` is negative for A, B, C.
- Fix: `((position + shift) % 26 + 26) % 26`.

**4. Shifting non-letters**
- Looks like: `3:00!` turns into `6=33$`.
- Fix: check `isalpha(c)` first, and return non-letters unchanged.

**5. Lowercase letters turning into capitals (or symbols)**
- Cause: using `'A'` as the base for every letter.
- Fix: base is `'A'` when `isupper(c)`, otherwise `'a'`.

**6. Double quotes for a char**
- Looks like: `if (c == "a")`
- Error: `C2446 '==': no conversion from 'const char *' to 'int'`.
- Fix: single quotes: `c == 'a'`.

**7. Counting in the wrong message**
- The challenge counts letters and vowels in the message the user **typed**, not in the result.

---

## How this shows up at BPA

- The 2026 regional's option 3 reversed a sentence "including spaces and punctuation" and checked for empty input. That is `getline` plus a string loop.
- The 2026 regional's option 2 built random passwords from a string of allowed characters: pick a random index from 0 to `length() - 1`, take that character, and add it to the password with `+=`. Everything from Step 4 and this step.
- The 2024 regional counted spaces, vowels, consonants, and double letters side by side in a story. Those are character loops with `isalpha`, `tolower`, and comparing `text[i]` with `text[i + 1]`.
- The leftover newline bug is the classic C++ trap on these tests. Graders notice when an option skips its input.

---

## The challenge: Secret Message

Write a Caesar cipher program.

**Requirements**
1. Header comment.
2. Ask `Encode or decode? (e/d): `, then `Message: `, then `Shift (1-25): `.
3. Caesar cipher: move each letter forward by the shift to encode (backward to decode), wrapping Z→A. Keep uppercase as uppercase and lowercase as lowercase. Anything that isn't a letter (spaces, digits, punctuation) stays the same.
4. Write these functions: `shiftLetter(letter, shift)` (shifts one character, returns it), `encode(message, shift)`, `decode(message, shift)` (decode should call encode with a negative shift — explain why that works with `%`), `countLetters(text)`, `countVowels(text)` (a, e, i, o, u, either case).
5. Print the result, then the number of letters and vowels **in the message the user typed**.
6. Function comments and Input / Processing / Output comments.

(C++ names use camelCase. "Explain why that works" means: put a comment in `decode` saying why.)

**Sample run 1 (exact)**
```
Encode or decode? (e/d): e
Message: Meet me at 3:00!
Shift (1-25): 3
Result: Phhw ph dw 3:00!
Letters: 8
Vowels: 4
```
**Sample run 2 (exact)**
```
Encode or decode? (e/d): d
Message: Phhw ph dw 3:00!
Shift (1-25): 3
Result: Meet me at 3:00!
Letters: 8
Vowels: 0
```
Vowels in "Phhw ph dw" = 0.

**Hints**
- Function types: `char shiftLetter(char letter, int shift)`, `string encode(string message, int shift)`, `string decode(string message, int shift)`, `int countLetters(string text)`, `int countVowels(string text)`.
- `shiftLetter`: if not `isalpha`, return it unchanged. Pick the base (`'A'` or `'a'`). Position = `letter - base`. New position with the wrap formula. Return `base + newPosition`.
- `encode`: loop over the message and replace each character with `shiftLetter(message[i], shift)`.
- `#include <cctype>` for `isalpha`, `isupper`, `tolower`.
- Remember `cin.ignore(1000, '\n');` before reading the message.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step07`.
2. Put `step07.cpp` in it. (Visual Studio: push the whole project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 7 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches both sample runs
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] All five functions, each with a purpose / parameters / returns comment
- [ ] `decode` calls `encode` with a negative shift, with a comment explaining why it works
- [ ] Wrap formula handles negative numbers
- [ ] Message read with `getline` (spaces kept)
- [ ] Test: `Xyz ABC` with shift 25 encodes to `Wxy ZAB`
- [ ] Pushed to `bpaPrep/cpp_step07`
