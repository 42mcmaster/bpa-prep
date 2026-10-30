# Step 07 — Strings (C#)

**What you'll build:** Secret Message — a program that encodes and decodes messages with a Caesar cipher and counts letters and vowels.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [A string is a row of characters](#a-string-is-a-row-of-characters)
- [Looping over the characters](#looping-over-the-characters)
- [Checking what kind of character it is](#checking-what-kind-of-character-it-is)
- [Characters are numbers underneath](#characters-are-numbers-underneath)
- [Wrapping around with %](#wrapping-around-with-)
- [Strings can't be changed in place](#strings-cant-be-changed-in-place)
- [StringBuilder](#stringbuilder)
- [Useful string methods](#useful-string-methods)
- [The ? : shortcut](#the---shortcut)
- [Reading a whole line](#reading-a-whole-line)
- [A complete example](#a-complete-example)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Secret Message](#the-challenge-secret-message)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to get one character out of a string by its index, and how long a string is
- How to loop through every character
- How to check whether a character is a letter, a digit, upper case, or lower case
- That every character has a number code, and how to do math with characters
- How `%` makes values wrap around (and the C# negative-number catch)
- Why C# strings can't be changed in place, and how `StringBuilder` builds new ones
- The string methods you will use most: `ToUpper`, `Trim`, `Contains`, `IndexOf`, `Replace`, `Split`, `Substring`
- The `? :` shortcut for a small if/else

## A string is a row of characters

A `string` is a row of `char` values. You can get one character with its **index**, starting at 0, just like a list:

```csharp
string word = "BPA rocks";
char first = word[0];                    // 'B'
char last = word[word.Length - 1];       // 's'
Console.WriteLine(word.Length);          // 9 - the space counts
Console.WriteLine(first);                // B
```

- `word.Length` is how many characters (spaces and punctuation count).
- A `char` is **one** character and uses **single quotes**: `'B'`. A `string` uses double quotes: `"B"`. They are different types: `'B' == "B"` is an error.

## Looping over the characters

Both kinds of loop from Step 6 work on strings:

```csharp
string team = "Hawks";

// foreach: each character in turn
foreach (char c in team)
{
    Console.Write(c + "-");
}
Console.WriteLine();

// for: when you need the position - here, going backward
for (int i = team.Length - 1; i >= 0; i--)
{
    Console.Write(team[i]);
}
Console.WriteLine();
```

It prints:

```text
H-a-w-k-s-
skwaH
```

The backward `for` loop is one way to reverse a string.

## Checking what kind of character it is

The `char` type has built-in checks. Each returns `true` or `false`:

| What you type | True when the character is… |
|---|---|
| `char.IsLetter(c)` | a letter A–Z or a–z |
| `char.IsDigit(c)` | a digit 0–9 |
| `char.IsUpper(c)` | an upper-case letter |
| `char.IsLower(c)` | a lower-case letter |
| `char.IsWhiteSpace(c)` | a space, tab, or new line |
| `char.ToUpper(c)` / `char.ToLower(c)` | (not a check — these return the upper/lower-case version) |

```csharp
string code = "Room 112B";
int digits = 0;
int letters = 0;
foreach (char c in code)
{
    if (char.IsDigit(c))
    {
        digits++;
    }
    else if (char.IsLetter(c))
    {
        letters++;
    }
}
Console.WriteLine($"Letters: {letters}, digits: {digits}");
```

This prints `Letters: 5, digits: 3`. The space is neither, so it isn't counted.

To check whether a character is a vowel, look for it in a string of vowels: `"aeiou".Contains(char.ToLower(c))`. Lower-casing it first means `'E'` and `'e'` both count.

## Characters are numbers underneath

Every character is stored as a number called its **character code** (ASCII / Unicode). The upper-case letters are in order, and so are the lower-case letters:

| Character | Code | | Character | Code |
|---|---|---|---|---|
| `'A'` | 65 | | `'a'` | 97 |
| `'B'` | 66 | | `'b'` | 98 |
| `'Z'` | 90 | | `'z'` | 122 |
| `'0'` | 48 | | `' '` (space) | 32 |

Because they are numbers, you can do math with them:

```csharp
char letter = 'D';
int code = letter;                 // 68 - a char fits in an int automatically
int position = letter - 'A';       // 3  - D is 3 places after A
char next = (char)(letter + 1);    // 'E' - add 1, then cast back to char

Console.WriteLine(code);
Console.WriteLine(position);
Console.WriteLine(next);
```

It prints:

```text
68
3
E
```

- `letter - 'A'` gives the letter's position in the alphabet, from 0 (A) to 25 (Z). For lower case, subtract `'a'` instead.
- `letter + 1` gives an `int` (69). `(char)` is a **cast** that turns it back into a character. Without the cast you get `CS0266 Cannot implicitly convert type 'int' to 'char'`.

## Wrapping around with %

`%` gives the remainder after dividing (Step 2). It is perfect for wrapping around, like a clock: `(position + shift) % 26` always lands between 0 and 25.

```csharp
int position = 24;               // 'Y'
int moved = (position + 3) % 26; // 27 % 26 = 1, which is 'B'
```

Y moved forward 3 is Z, A, B. The `% 26` did the wrap.

**The C# catch with negative numbers.** Going backward means a negative shift. In C#, `%` of a negative number is **negative**:

```csharp
Console.WriteLine(-3 % 26);              // -3   (Python would say 23)
Console.WriteLine((-3 % 26 + 26) % 26);  // 23
```

So for a value that might be negative, use `((x % 26) + 26) % 26`. Adding 26 makes it positive, and the second `% 26` puts it back in the 0–25 range. (Python's `%` is always positive, so Python programs don't need this. C, C++, Java, and C# all do.)

## Strings can't be changed in place

C# strings are **immutable** — once made, they can't be changed. This is an error:

```csharp
string name = "jordan";
name[0] = 'J';   // ERROR
```

You see `CS0200 Property or indexer 'string.this[int]' cannot be assigned to -- it is read only`.

What you **can** do is build a **new** string and store it in the variable:

```csharp
string name = "jordan";
name = char.ToUpper(name[0]) + name.Substring(1);   // "Jordan" - a brand new string
```

Methods like `ToUpper()` and `Replace()` also return a **new** string. They don't change the original:

```csharp
string s = "hello";
s.ToUpper();            // does nothing useful - the new string is thrown away
s = s.ToUpper();        // correct - keep the new string
```

## StringBuilder

When you build a string one character at a time in a loop, `+=` makes a brand new string every time. For short text that's fine. `StringBuilder` is the better tool: it is a string you **can** change, and you turn it into a normal string at the end.

Add `using System.Text;` at the top.

```csharp
StringBuilder sb = new StringBuilder();   // starts empty
sb.Append("Go");                           // add text to the end
sb.Append(' ');                            // add a char
sb.Append("Hawks");
sb.Append('!');
sb[0] = 'g';                               // a StringBuilder CAN be changed in place
string result = sb.ToString();             // turn it into a normal string
Console.WriteLine(result);                 // go Hawks!
```

| What you type | What it means |
|---|---|
| `new StringBuilder()` | make an empty, changeable string |
| `.Append(x)` | add `x` (a string, char, or number) to the end |
| `sb[i] = 'x'` | change the character at index `i` |
| `.Length` | how many characters so far |
| `.ToString()` | get the finished text as a normal `string` |

The Secret Message challenge builds its result one character at a time, so use a `StringBuilder` (or `+=` — both work, but graders like seeing `StringBuilder`).

## Useful string methods

| What you type | Result for `s = "  Go Hawks  "` or the note | What it does |
|---|---|---|
| `s.Trim()` | `"Go Hawks"` | removes spaces from both ends |
| `s.ToUpper()` / `s.ToLower()` | `"  GO HAWKS  "` | changes the case |
| `t.Contains("Haw")` (t = `"Go Hawks"`) | `true` | is this text inside? (case-sensitive) |
| `t.IndexOf("Hawks")` | `3` | where it starts, or `-1` if not found |
| `t.Replace("Go", "Win")` | `"Win Hawks"` | swaps every match |
| `t.Substring(3)` | `"Hawks"` | from index 3 to the end |
| `t.Substring(0, 2)` | `"Go"` | from index 0, 2 characters long |
| `t.StartsWith("Go")` | `true` | does it start with this? |
| `t.Split(' ')` | `{ "Go", "Hawks" }` | cut into an array at each space (Step 9 uses this for CSV) |
| `string.Join("-", parts)` | `"Go-Hawks"` | glue an array or list back together |
| `t.ToCharArray()` | `{ 'G', 'o', ' ', ... }` | a `char[]` you can change or reverse |

Reversing a string with a data structure (an array):

```csharp
char[] chars = "Hawks".ToCharArray();
Array.Reverse(chars);
string backwards = new string(chars);   // "skwaH"
```

## The ? : shortcut

C# has a one-line if/else for picking between two values. It is called the **conditional operator** (or "ternary"):

```csharp
int count = 1;
string word = (count == 1) ? "item" : "items";
```

Read it as: "Is `count == 1`? If yes, use `"item"`. If not, use `"items"`." It is the same as:

```csharp
string word;
if (count == 1) { word = "item"; } else { word = "items"; }
```

It is handy for choosing a base letter: `char baseLetter = char.IsUpper(c) ? 'A' : 'a';`. Use it only for simple choices. A normal if/else is fine too.

## Reading a whole line

`Console.ReadLine()` reads **everything** the user typed up to Enter — spaces, punctuation, all of it — and removes the Enter. So `Meet me at 3:00!` comes in as one string. That is exactly what you want for a message.

(If you also do C++ or Java: there, reading a number with `cin >>` or `nextInt()` leaves the Enter key behind, and the next full-line read gets an empty line. That is a very common bug in those languages. C# doesn't have this problem as long as you **always** read with `ReadLine()` and then convert with `int.Parse`. Don't use `Console.Read()` — it reads only one character and leaves the rest of the line behind, which causes the same bug.)

## A complete example

This program checks a password and shows a masked version. It loops over characters, uses the `char` checks, `StringBuilder`, and `? :`. (It is not the challenge.)

<!-- input: Hawks2026! -->
```csharp
// Name: Example
// Date: 2026-11-06
// Program: Password Checker
// Description: Counts the kinds of characters in a password and shows a masked version.

using System;
using System.Text;

namespace PasswordChecker
{
    internal class Program
    {
        // Purpose: count characters that are digits.
        // Parameters: text - the text to check.
        // Returns: how many digits.
        static int CountDigits(string text)
        {
            // Processing: loop over every character
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    count++;
                }
            }
            return count;
        }

        // Purpose: hide all but the first character with *.
        // Parameters: text - the text to mask.
        // Returns: the masked text, like "H*********".
        static string Mask(string text)
        {
            // Processing: keep character 0, then add one * per remaining character
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                sb.Append(i == 0 ? text[i] : '*');
            }
            return sb.ToString();
        }

        // Purpose: run the program.
        // Parameters: args - not used.
        // Returns: nothing.
        static void Main(string[] args)
        {
            // Input: the password (a whole line)
            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            // Processing: count upper case, lower case, and symbols
            int upper = 0;
            int lower = 0;
            int symbols = 0;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    upper++;
                }
                else if (char.IsLower(c))
                {
                    lower++;
                }
                else if (!char.IsDigit(c))
                {
                    symbols++;
                }
            }
            int digits = CountDigits(password);
            bool strong = password.Length >= 8 && upper > 0 && digits > 0 && symbols > 0;

            // Output: the report
            Console.WriteLine($"Masked: {Mask(password)}");
            Console.WriteLine($"Length: {password.Length}");
            Console.WriteLine($"Upper: {upper}  Lower: {lower}  Digits: {digits}  Symbols: {symbols}");
            Console.WriteLine(strong ? "Strong password." : "Weak password.");
        }
    }
}
```

It prints:

```text
Password: Hawks2026!
Masked: H*********
Length: 10
Upper: 1  Lower: 4  Digits: 4  Symbols: 1
Strong password.
```

**Try it:**
- Add a method that returns the password reversed.
- Print the position in the alphabet (1–26) of the first letter, using `char.ToUpper(c) - 'A' + 1`.

## Common mistakes

**Single vs double quotes.**
`if (c == "a")` gives `CS0019 Operator '==' cannot be applied to operands of type 'char' and 'string'`.
Fix: a `char` compares with single quotes: `c == 'a'`.

**Forgetting the `(char)` cast.**
`char next = letter + 3;` gives `CS0266 Cannot implicitly convert type 'int' to 'char'. An explicit conversion exists (are you missing a cast?)`.
Fix: `char next = (char)(letter + 3);`.

**Negative remainder when decoding.**
Decoding `'a'` with shift 3 gives a strange symbol like `^` instead of `x`.
Fix: use `((position + shift) % 26 + 26) % 26`.

**Calling a string method and throwing the result away.**
`message.ToUpper();` on its own line changes nothing.
Fix: `message = message.ToUpper();`.

**Trying to change a string by index.**
`CS0200 Property or indexer 'string.this[int]' cannot be assigned to -- it is read only`.
Fix: build a new string, or use a `StringBuilder` or `char[]`.

**Index out of range on a string.**
`System.IndexOutOfRangeException: Index was outside the bounds of the array.`
Fix: the last character is at `Length - 1`.

**Upper-case letters become lower-case (or the reverse).**
You always subtracted `'a'`.
Fix: pick the base for **each** character: `'A'` if it is upper case, `'a'` if lower case.

## How this shows up at BPA

- String buttons were a big part of the 2026 C# regional: **reverse the text** ("Backwards"), **remove the vowels** ("No Vowels"), and **count digit types** (total, even, odd, zero digits). All three are loops over characters with `char` checks.
- "Backwards" was graded on using a data structure to reverse — `ToCharArray` + `Array.Reverse`, or a backward loop into a `StringBuilder`.
- Graders read your method comments, so say what each string method does in plain words.

## The challenge: Secret Message

Write a program that encodes or decodes a message with a Caesar cipher.

**Requirements:**
1. Header comment.
2. Ask `Encode or decode? (e/d): `, then `Message: `, then `Shift (1-25): `.
3. Caesar cipher: move each letter forward by the shift to encode (backward to decode), wrapping Z→A. Keep uppercase as uppercase and lowercase as lowercase. Anything that isn't a letter (spaces, digits, punctuation) stays the same.
4. Write these functions: `shift_letter(letter, shift)` (shifts one character, returns it), `encode(message, shift)`, `decode(message, shift)` (decode should call encode with a negative shift — explain why that works with `%`), `count_letters(text)`, `count_vowels(text)` (a, e, i, o, u, either case).
5. Print the result, then the number of letters and vowels **in the message the user typed**.
6. Function comments and Input / Processing / Output comments.

In C# the methods are `ShiftLetter(char letter, int shift)`, `Encode`, `Decode`, `CountLetters`, and `CountVowels`.

**Sample run 1 (exact):**
```text
Encode or decode? (e/d): e
Message: Meet me at 3:00!
Shift (1-25): 3
Result: Phhw ph dw 3:00!
Letters: 8
Vowels: 4
```
**Sample run 2 (exact):**
```text
Encode or decode? (e/d): d
Message: Phhw ph dw 3:00!
Shift (1-25): 3
Result: Meet me at 3:00!
Letters: 8
Vowels: 0
```
(Vowels in "Phhw ph dw" = 0. The counts are for the message the user typed, not the result.)

**Hints:**
- `ShiftLetter`: if the character isn't a letter, return it unchanged. Otherwise pick the base (`'A'` or `'a'`), get the position (`letter - baseLetter`), add the shift, wrap with `((… % 26) + 26) % 26`, and return `(char)(baseLetter + newPosition)`.
- `Encode` loops over the message, calls `ShiftLetter` on each character, and appends to a `StringBuilder`.
- `Decode` is one line: `return Encode(message, -shift);`. Shifting back by 3 is the same as shifting forward by −3, and the `+ 26` fix makes the negative remainders come out right. Put that explanation in your comment.
- Read the message with `Console.ReadLine()` so the spaces and punctuation come in too.

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step07`.
2. Put your whole Visual Studio project folder (`Step07`) in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 7 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches both sample runs
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `ShiftLetter`, `Encode`, `Decode`, `CountLetters`, `CountVowels` all exist with comments
- [ ] `Decode` calls `Encode` with a negative shift, with a comment explaining why it works
- [ ] Upper and lower case are kept; non-letters are unchanged
- [ ] Pushed to `bpaPrep/csharp_step07`
