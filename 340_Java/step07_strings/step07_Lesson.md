# Step 07 — Strings (Java)

**What you'll build:** Secret Message — a program that encodes and decodes messages with a Caesar cipher and counts the letters and vowels.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [A String is a row of characters](#a-string-is-a-row-of-characters)
- [Looping over the characters](#looping-over-the-characters)
- [Checking characters with the Character class](#checking-characters-with-the-character-class)
- [Characters are numbers](#characters-are-numbers)
- [Strings can't be changed: use StringBuilder](#strings-cant-be-changed-use-stringbuilder)
- [Useful String methods](#useful-string-methods)
- [Wrap-around with the remainder operator](#wrap-around-with-the-remainder-operator)
- [Java's % with negative numbers](#javas--with-negative-numbers)
- [Reading a full line of text](#reading-a-full-line-of-text)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Secret Message](#the-challenge-secret-message)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- Getting one character with `charAt(i)` and the length with `length()`
- The `char` type and single quotes
- Checking characters: `Character.isLetter`, `isUpperCase`, `isDigit`
- Character codes (ASCII/Unicode) and character math like `'A' + 2`
- Why Strings can't be changed in place, and how `StringBuilder` builds new text
- Useful methods: `toUpperCase`, `trim`, `indexOf`, `contains`, `replace`, `split`, `substring`, reversing
- Wrap-around with `%`, and the Java `%` negative number trap
- Reading a message with spaces using `nextLine()`

---

## A String is a row of characters

A `String` is a row of characters. Each character has an index, starting at 0.

```
String word = "Java!";

index:      0    1    2    3    4
character: 'J'  'a'  'v'  'a'  '!'
```

| What you type | What you get |
|---|---|
| `word.length()` | `5` (with parentheses - it is a method) |
| `word.charAt(0)` | `'J'` (a `char`) |
| `word.charAt(4)` | `'!'` |
| `word.charAt(word.length() - 1)` | The last character, `'!'` |
| `word.charAt(5)` | Crash: `StringIndexOutOfBoundsException` |

A **`char`** holds one character and uses **single quotes**: `'J'`. A `String` uses **double quotes**: `"J"`. They are different types. `'J'` is a `char`; `"J"` is a `String` that happens to have one character.

---

## Looping over the characters

Use a counting `for` loop from `0` to `length() - 1`:

```java
public class CountDigits {
    public static void main(String[] args) {
        String code = "Room 112, Bus 7";
        int digits = 0;

        // Processing: look at each character one at a time
        for (int i = 0; i < code.length(); i++) {
            char c = code.charAt(i);
            if (Character.isDigit(c)) {
                digits++;
            }
        }

        // Output
        System.out.println("Digits found: " + digits);
    }
}
```

Output:

```
Digits found: 4
```

You can also loop over a String with a for-each loop by turning it into a `char` array first: `for (char c : code.toCharArray())`.

---

## Checking characters with the Character class

The `Character` class has methods that answer yes/no questions about one `char`:

| What you type | `true` when the character is... |
|---|---|
| `Character.isLetter(c)` | a letter (A-Z, a-z) |
| `Character.isDigit(c)` | a digit (0-9) |
| `Character.isLetterOrDigit(c)` | a letter or a digit |
| `Character.isUpperCase(c)` | an uppercase letter |
| `Character.isLowerCase(c)` | a lowercase letter |
| `Character.isWhitespace(c)` | a space, tab, or new line |

And two that change a `char`:

| What you type | Gives back |
|---|---|
| `Character.toUpperCase(c)` | the uppercase version (`'a'` becomes `'A'`; non-letters stay the same) |
| `Character.toLowerCase(c)` | the lowercase version |

---

## Characters are numbers

Every character is stored as a number called its **character code** (Unicode; for English letters it is the same as ASCII). The letters are in order:

| Character | Code | | Character | Code |
|---|---|---|---|---|
| `'A'` | 65 | | `'a'` | 97 |
| `'B'` | 66 | | `'b'` | 98 |
| `'Z'` | 90 | | `'z'` | 122 |
| `'0'` | 48 | | `' '` (space) | 32 |

Because a `char` is a number, you can do math with it:

```java
public class CharMath {
    public static void main(String[] args) {
        char letter = 'C';

        int code = letter;                    // 67 - a char fits into an int
        int position = letter - 'A';          // 2  - C is 2 letters after A
        char next = (char) (letter + 1);      // 'D' - add 1, then cast back to char
        char fifth = (char) ('A' + 4);        // 'E'

        System.out.println(code);
        System.out.println(position);
        System.out.println(next);
        System.out.println(fifth);
    }
}
```

Output:

```
67
2
D
E
```

`letter + 1` is an `int` (68). To turn it back into a character you **cast** it with `(char)`. Without the cast, `println(letter + 1)` prints `68`.

`letter - 'A'` gives the letter's **position** in the alphabet, from 0 (A) to 25 (Z). For lowercase, subtract `'a'` instead. This is the key idea for the cipher.

Python does the same thing with `ord()` and `chr()`. Java just lets you do math on the `char` directly.

---

## Strings can't be changed: use StringBuilder

In Java, a `String` is **immutable** - once it is made, its characters can never change. There is no `word.charAt(0) = 'X';`. Methods like `toUpperCase()` don't change the String; they **return a new one**:

```java
String team = "eagles";
team.toUpperCase();                 // makes "EAGLES" and throws it away - team is still "eagles"
team = team.toUpperCase();          // now team is "EAGLES"
```

To build a new String one piece at a time, you could use `+` in a loop, but each `+` makes a whole new String. The better tool is **`StringBuilder`**, which is a changeable string:

```java
public class Initials {
    public static void main(String[] args) {
        String fullName = "medina county career center";
        StringBuilder initials = new StringBuilder();   // starts empty

        // Processing: take the first letter, then every letter after a space
        for (int i = 0; i < fullName.length(); i++) {
            if (i == 0 || fullName.charAt(i - 1) == ' ') {
                initials.append(Character.toUpperCase(fullName.charAt(i)));
            }
        }

        // Output: toString() turns the StringBuilder into a normal String
        String result = initials.toString();
        System.out.println(result);
        System.out.println(new StringBuilder("stressed").reverse().toString());
    }
}
```

Output:

```
MCCC
desserts
```

| What you type | What it does |
|---|---|
| `StringBuilder sb = new StringBuilder();` | Make an empty, changeable string |
| `sb.append(x)` | Add `x` (a char, String, or number) to the end |
| `sb.reverse()` | Reverse the characters |
| `sb.length()` | How many characters so far |
| `sb.toString()` | Get a normal `String` back |

---

## Useful String methods

All of these **return** a new value. None of them change the original String.

| Method | Example | Result |
|---|---|---|
| `toUpperCase()` / `toLowerCase()` | `"Hi There".toLowerCase()` | `"hi there"` |
| `trim()` | `"  pizza  ".trim()` | `"pizza"` (removes spaces from both ends) |
| `isEmpty()` | `"".isEmpty()` | `true` |
| `isBlank()` | `"   ".isBlank()` | `true` (empty or only spaces) |
| `indexOf(text)` | `"banana".indexOf("an")` | `1` (first position; `-1` if not found) |
| `contains(text)` | `"banana".contains("nan")` | `true` |
| `startsWith(text)` / `endsWith(text)` | `"Step07.java".endsWith(".java")` | `true` |
| `replace(old, new)` | `"a-b-c".replace("-", "/")` | `"a/b/c"` |
| `substring(start, end)` | `"Medina".substring(0, 3)` | `"Med"` (from `start` up to, not including, `end`) |
| `substring(start)` | `"Medina".substring(3)` | `"ina"` (from `start` to the end) |
| `split(",")` | `"red,green,blue".split(",")` | a `String[]` array: `{"red", "green", "blue"}` |
| `equals(text)` / `equalsIgnoreCase(text)` | `"YES".equalsIgnoreCase("yes")` | `true` (Step 3) |

`split` will be very important in Step 9 for reading CSV files:

```java
String line = "Avery,88,92";
String[] parts = line.split(",");
System.out.println(parts[0]);                       // Avery
System.out.println(Integer.parseInt(parts[1]) + 1); // 89
```

Case-insensitive "contains" (used in Step 11): lowercase both sides first.

```java
String name = "Casey";
String search = "CAS";
boolean found = name.toLowerCase().contains(search.toLowerCase());   // true
```

**Try it:**
1. Ask for a word and print it backward using `StringBuilder.reverse()`. Then print whether it is a palindrome (the same backward, ignoring case).
2. Ask for an email address and print the part before the `@` using `indexOf` and `substring`.

---

## Wrap-around with the remainder operator

A **Caesar cipher** shifts each letter forward in the alphabet by a fixed number. With a shift of 3, A becomes D, B becomes E... and at the end it **wraps around**: X becomes A, Y becomes B, Z becomes C.

To wrap around, work with the letter's **position** (0-25) and use `%` (remainder) with 26:

```
position of 'Y' = 'Y' - 'A' = 24
24 + 3 = 27
27 % 26 = 1           (27 divided by 26 is 1, remainder 1)
'A' + 1 = 'B'         so Y shifted by 3 is B
```

`% 26` always brings the number back into 0-25. The steps are:
1. Find the base: `'A'` for uppercase, `'a'` for lowercase.
2. Position = `c - base`.
3. New position = `(position + shift) % 26`.
4. New letter = `(char) (base + newPosition)`.

**Decoding** is shifting **backward** - the same as shifting by a negative number. So `decode(message, 3)` can just call `encode(message, -3)`. But negative numbers bring up a Java problem...

---

## Java's % with negative numbers

In Python, `-1 % 26` is `25`. In Java (and C++ and C#), **`-1 % 26` is `-1`**. Java's `%` keeps the sign of the left number.

```java
public class NegativeMod {
    public static void main(String[] args) {
        System.out.println(27 % 26);               // 1
        System.out.println(-1 % 26);               // -1  (Python would say 25)
        System.out.println((-1 % 26 + 26) % 26);   // 25  - the safe way
        System.out.println((5 % 26 + 26) % 26);    // 5   - still right for positive numbers
    }
}
```

Output:

```
1
-1
25
5
```

Decoding the letter `'B'` (position 1) with shift 3: `1 + (-3) = -2`, and `-2 % 26` is `-2` in Java. `'A' + (-2)` is not a letter at all. That is a bug.

**The fix:** add 26 and take `%` again. This always gives 0-25, for positive or negative numbers:

```java
int newPosition = ((position + shift) % 26 + 26) % 26;
```

For `-2`: `(-2 % 26 + 26) % 26` = `(-2 + 26) % 26` = `24 % 26` = `24` → `'Y'`. Correct: B shifted back 3 is Y.

That is why decoding by calling `encode` with a negative shift works - **as long as** your shift method uses this safe formula.

---

## Reading a full line of text

The message has spaces in it (`Meet me at 3:00!`), so read it with `nextLine()`, which reads everything up to the Enter key.

If you used `keyboard.next()`, you would only get the first word (`Meet`). And if you read the shift with `keyboard.nextInt()` **before** reading the message with `nextLine()`, the message would come back empty - the leftover-Enter problem from [Step 2](../step02_variablesAndInput/step02_Lesson.md#the-nextint-and-nextline-problem). Reading every answer with `nextLine()` and converting numbers with `Integer.parseInt` avoids both problems.

---

## Common mistakes

**1. Single vs double quotes**
- Looks like: `char c = "A";` or `if (c == "a")`
- Error: `error: incompatible types: String cannot be converted to char` or `error: bad operand types for binary operator '=='`
- Fix: `char` uses single quotes: `'A'`.

**2. Forgetting the `(char)` cast**
- Looks like: `char next = letter + 1;`
- Error: `error: incompatible types: possible lossy conversion from int to char`
- Fix: `char next = (char) (letter + 1);`

**3. Printing a number instead of a letter**
- Looks like: `System.out.println(letter + 1);` prints `68`.
- Fix: cast first: `System.out.println((char) (letter + 1));`

**4. Negative `%` when decoding**
- Looks like: decoding prints strange symbols like `>` or `@` instead of letters.
- Fix: `((position + shift) % 26 + 26) % 26`.

**5. Expecting a String method to change the String**
- Looks like: `message.toUpperCase();` on its own line, then printing `message` - still lowercase.
- Fix: `message = message.toUpperCase();`

**6. `charAt` past the end**
- Error: `java.lang.StringIndexOutOfBoundsException: Index 16 out of bounds for length 16` (Java 21 wording; older versions say `String index out of range: 16`)
- Fix: loop with `i < text.length()`.

**7. Shifting punctuation and digits**
- Looks like: `3:00!` turns into `6=33$`.
- Fix: in `shiftLetter`, return the character unchanged if `!Character.isLetter(c)`.

---

## How this shows up at BPA

- String handling (case, trimming, searching, splitting) is graded on all four BPA programming events. The C# test has whole buttons that are just string manipulation.
- `split(",")` is how you read CSV data (Step 9 and every file-based test).
- `equals` / `equalsIgnoreCase` for comparing text input, and `toLowerCase().contains(...)` for searches, come up in menu programs.
- Small methods like `shiftLetter`, `countVowels` are exactly the kind of "each part its own method" design graders want.

---

## The challenge: Secret Message

Write a program that encodes or decodes a message with a Caesar cipher.

**Requirements**
1. Header comment.
2. Ask `Encode or decode? (e/d): `, then `Message: `, then `Shift (1-25): `.
3. Caesar cipher: move each letter forward by the shift to encode (backward to decode), wrapping Z→A. Keep uppercase as uppercase and lowercase as lowercase. Anything that isn't a letter (spaces, digits, punctuation) stays the same.
4. Write these methods: `shiftLetter(letter, shift)` (shifts one character, returns it), `encode(message, shift)`, `decode(message, shift)` (decode should call encode with a negative shift — explain why that works with `%`), `countLetters(text)`, `countVowels(text)` (a, e, i, o, u, either case).
5. Print the result, then the number of letters and vowels **in the message the user typed**.
6. Method comments and Input / Processing / Output comments.

**Sample run 1 (exact):**
```
Encode or decode? (e/d): e
Message: Meet me at 3:00!
Shift (1-25): 3
Result: Phhw ph dw 3:00!
Letters: 8
Vowels: 4
```
**Sample run 2 (exact):**
```
Encode or decode? (e/d): d
Message: Phhw ph dw 3:00!
Shift (1-25): 3
Result: Meet me at 3:00!
Letters: 8
Vowels: 0
```
(Vowels in "Phhw ph dw" = 0. The counts are for the message the user typed, not the result.)

**Hints**
- Class `Step07` in `Step07.java`.
- Method headers: `static char shiftLetter(char letter, int shift)`, `static String encode(String message, int shift)`, `static String decode(String message, int shift)`, `static int countLetters(String text)`, `static int countVowels(String text)`.
- `encode` loops over the message, calls `shiftLetter` on each `char`, and `append`s the result to a `StringBuilder`.
- `decode` is one line: `return encode(message, -shift);`. In the comment above it, explain that the safe `%` formula in `shiftLetter` turns negative positions into 0-25.
- For vowels, one way: `"aeiou".indexOf(Character.toLowerCase(c)) >= 0` is `true` when `c` is a vowel.
- Read the message with `nextLine()` so the spaces are kept.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step07`.
2. Put `Step07.java` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 7 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches both sample runs
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] All five methods written, with purpose / parameters / returns comments
- [ ] `decode` calls `encode` with a negative shift, with a comment explaining why it works
- [ ] Uppercase stays uppercase, lowercase stays lowercase, other characters unchanged
- [ ] `StringBuilder` used to build the result
- [ ] Pushed to `bpaPrep/java_step07`
