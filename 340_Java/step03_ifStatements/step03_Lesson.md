# Step 03 — If Statements (Java)

**What you'll build:** Grade Checker — a program that turns a score into a letter grade and says whether the student passed.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Comparison operators](#comparison-operators)
- [The if statement](#the-if-statement)
- [if and else](#if-and-else)
- [else if chains](#else-if-chains)
- [Logical operators: and, or, not](#logical-operators-and-or-not)
- [Nested if statements](#nested-if-statements)
- [Comparing Strings: equals, not ==](#comparing-strings-equals-not-)
- [The switch statement](#the-switch-statement)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Grade Checker](#the-challenge-grade-checker)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- The six comparison operators (`==`, `!=`, `<`, `>`, `<=`, `>=`)
- `if`, `else if`, and `else`
- Logical operators `&&` (and), `||` (or), and `!` (not)
- Putting one `if` inside another (nested if)
- Why Strings are compared with `.equals()` and never with `==`
- The `switch` statement, and why each `case` needs `break`

---

## Comparison operators

A **comparison** asks a yes/no question. The answer is a `boolean`: `true` or `false`.

| Operator | Meaning | Example | Result when `age` is 16 |
|---|---|---|---|
| `==` | is equal to | `age == 16` | `true` |
| `!=` | is not equal to | `age != 16` | `false` |
| `<` | less than | `age < 18` | `true` |
| `>` | greater than | `age > 18` | `false` |
| `<=` | less than or equal to | `age <= 16` | `true` |
| `>=` | greater than or equal to | `age >= 18` | `false` |

**`=` vs `==`:** one equal sign **stores** a value (`age = 16;`). Two equal signs **compare** (`age == 16`). Mixing them up is one of the most common mistakes.

You can store the answer in a `boolean` variable:

```java
boolean canDrive = age >= 16;   // true
```

---

## The if statement

An `if` runs a block of code **only when** the condition is true.

```java
if (condition) {
    // runs only when condition is true
}
```

- The condition goes in **parentheses** `( )`.
- The code to run goes in **curly braces** `{ }`.
- There is **no semicolon** after `if (...)`.

```java
int battery = 15;
if (battery < 20) {
    System.out.println("Low battery. Plug in your laptop.");
}
System.out.println("This line always runs.");
```

Output:

```
Low battery. Plug in your laptop.
This line always runs.
```

If `battery` were 80, only the second line would print.

---

## if and else

`else` runs when the condition is **false**. Exactly one of the two blocks runs.

```java
int temperature = 45;
if (temperature >= 60) {
    System.out.println("No jacket needed.");
} else {
    System.out.println("Bring a jacket.");
}
```

Output:

```
Bring a jacket.
```

---

## else if chains

When there are more than two choices, chain them with `else if`. Java checks each condition **from the top down** and runs the **first** block whose condition is true. Then it skips the rest.

```java
import java.util.Scanner;

public class TicketPrice {
    public static void main(String[] args) {
        Scanner keyboard = new Scanner(System.in);

        // Input: the customer's age
        System.out.print("Age: ");
        int age = Integer.parseInt(keyboard.nextLine());

        // Processing: pick the price. Order matters - the first true condition wins.
        double price;
        if (age < 4) {
            price = 0.00;
        } else if (age < 13) {
            price = 6.50;
        } else if (age < 65) {
            price = 11.00;
        } else {
            price = 7.25;
        }

        // Output
        System.out.printf("Ticket price: $%.2f%n", price);
        keyboard.close();
    }
}
```

Sample runs:

```
Age: 10
Ticket price: $6.50
```
```
Age: 70
Ticket price: $7.25
```

When the age is 10, `age < 4` is false, then `age < 13` is true, so the price is 6.50 and Java skips the rest. It never checks `age < 65`, even though 10 is also less than 65. That is why **order matters**: put the most specific check first.

Notice `double price;` is declared **before** the `if`. A variable declared inside `{ }` only exists inside those braces. If you declared `price` inside the `if` block, you could not print it afterward. (This is called **scope**. Step 5 talks about it more.)

**Try it:**
1. Write an `else if` chain for a phone battery: 80+ "Full", 40-79 "OK", 15-39 "Low", below 15 "Charge now".
2. Swap the order of two conditions in `TicketPrice` and see what breaks.

---

## Logical operators: and, or, not

Combine conditions with logical operators.

| Operator | Name | True when... | Example |
|---|---|---|---|
| `&&` | and | **both** sides are true | `age >= 13 && age <= 19` (a teenager) |
| `\|\|` | or | **at least one** side is true | `day == 6 \|\| day == 7` (weekend) |
| `!` | not | the condition is false | `!isMember` |

(In a code file you type `||` - two vertical bars. On most keyboards the bar is Shift + backslash.)

Python uses the words `and`, `or`, `not`. Java uses the symbols.

```java
int hour = 22;
boolean hasPermission = false;

// "or" - checking for a value OUTSIDE a range
if (hour < 6 || hour > 21) {
    System.out.println("The gym is closed.");
}

// "and" - checking for a value INSIDE a range
if (hour >= 6 && hour <= 21) {
    System.out.println("The gym is open.");
}

// "not"
if (!hasPermission) {
    System.out.println("Ask a teacher first.");
}
```

Output:

```
The gym is closed.
Ask a teacher first.
```

A good habit: **outside a range = `||`**, **inside a range = `&&`**. The challenge checks for a score outside 0-100, so it uses `||`.

---

## Nested if statements

You can put an `if` inside another `if`. The inner one is only checked when the outer one is true.

```java
int score = 85;
boolean turnedInLate = true;

if (score >= 70) {
    System.out.println("You passed the quiz.");
    if (turnedInLate) {
        System.out.println("But it was late, so 5 points come off.");
    }
} else {
    System.out.println("Please retake the quiz.");
}
```

Output:

```
You passed the quiz.
But it was late, so 5 points come off.
```

Nesting is useful when one check only makes sense after another one passes. In the challenge, you only figure out the letter grade **after** you know the score is valid (0-100). That is a nested if inside the `else`.

---

## Comparing Strings: equals, not ==

This is one of the most important Java rules:

> **Compare Strings with `.equals()`. Never with `==`.**

```java
String answer = keyboard.nextLine();

if (answer.equals("yes")) {            // correct
    System.out.println("Great!");
}

if (answer == "yes") {                 // WRONG - compiles, but often false even when they typed yes
    System.out.println("You may never see this.");
}
```

Why? A `String` is an **object**. The variable doesn't hold the letters directly - it holds the *location* of the object in memory. `==` asks "are these the same object in the same location?" Text typed by the user is always a new object, so `==` is usually `false` even when the letters match. `.equals()` asks "do they have the same letters?" - which is what you want.

| What you type | What it checks |
|---|---|
| `a.equals(b)` | Same letters, same capitals |
| `a.equalsIgnoreCase(b)` | Same letters, capitals don't matter (`"YES"` equals `"yes"`) |
| `!a.equals(b)` | Not the same letters |
| `a == b` | Same object in memory - **don't use for Strings** |

`==` is still correct for `int`, `double`, `char`, and `boolean`, because those are primitive types that hold the value directly.

```java
public class StringCompare {
    public static void main(String[] args) {
        String typed = new String("Pizza");   // makes a new String object, like user input does
        String lunch = "Pizza";

        System.out.println(typed == lunch);                    // false - different objects
        System.out.println(typed.equals(lunch));               // true  - same letters
        System.out.println(typed.equals("pizza"));             // false - capital P matters
        System.out.println(typed.equalsIgnoreCase("pizza"));   // true
    }
}
```

Output:

```
false
true
false
true
```

---

## The switch statement

A `switch` picks one of several blocks based on the value of **one** variable. It is a cleaner way to write a long `else if` chain that checks one variable for exact values. Java BPA tests often **require** a `switch` (the 2026 regional did).

```java
import java.util.Scanner;

public class DayName {
    public static void main(String[] args) {
        Scanner keyboard = new Scanner(System.in);

        // Input
        System.out.print("Day number (1-5): ");
        int day = Integer.parseInt(keyboard.nextLine());

        // Processing: switch on the day number
        String dayName;
        switch (day) {
            case 1:
                dayName = "Monday";
                break;
            case 2:
                dayName = "Tuesday";
                break;
            case 3:
                dayName = "Wednesday";
                break;
            case 4:
                dayName = "Thursday";
                break;
            case 5:
                dayName = "Friday - BPA day";
                break;
            default:
                dayName = "not a school day";
                break;
        }

        // Output
        System.out.println("Day " + day + " is " + dayName + ".");
        keyboard.close();
    }
}
```

Sample run:

```
Day number (1-5): 5
Day 5 is Friday - BPA day.
```

| What you type | What it means |
|---|---|
| `switch (day) {` | Look at the value of `day`. |
| `case 1:` | If `day` is 1, start running here. Note the **colon**. |
| `break;` | Stop and jump past the end of the switch. |
| `default:` | Runs if no `case` matched (like a final `else`). |

**Every `case` needs a `break;`.** Without it, Java keeps running into the **next** case too. This is called **fall-through**:

```java
switch (day) {
    case 1:
        System.out.println("Monday");     // no break!
    case 2:
        System.out.println("Tuesday");
        break;
}
// When day is 1, this prints BOTH Monday and Tuesday.
```

`break` inside a `switch` is normal and expected. (Some BPA tests say a **loop** must not end with `break` - that rule is about loops in Step 4, not `switch`.)

You can switch on an `int`, a `char`, or a `String` (case labels like `case "y":`). You can't switch on a `double`, and a `case` can't be a range like "90 to 100". For ranges, use `else if` - that is why the grade challenge uses `else if` for the letter grade.

Newer Java (14+) also has a shorter "arrow" form (`case 1 -> dayName = "Monday";`) that doesn't need `break`. You may see it online. In this class, use the classic form above - every Java IDE and grader understands it.

**Try it:**
1. Write a switch on a `String` menu choice: `"a"` prints "Add", `"d"` prints "Delete", anything else prints "Unknown".
2. Remove one `break` from `DayName` and see what prints.

---

## Common mistakes

**1. `=` instead of `==` in a condition**
- Looks like: `if (score = 100)`
- Error: `error: incompatible types: int cannot be converted to boolean`
- Fix: `if (score == 100)`

**2. Comparing Strings with `==`**
- Looks like: `if (answer == "y")`
- No error. The condition is `false` even when the user typed `y`, so the wrong branch runs.
- Fix: `if (answer.equals("y"))`

**3. A semicolon after the `if`**
- Looks like: `if (score >= 60); { System.out.println("passed"); }`
- No error. The `;` ends the `if` with an empty statement, so the block **always** runs.
- Fix: no semicolon between `)` and `{`.

**4. Conditions in the wrong order**
- Looks like: checking `score >= 60` before `score >= 90`.
- No error, but a 95 gets a D, because the first true condition wins.
- Fix: check from the highest to the lowest.

**5. Missing `break` in a `switch`**
- Looks like: choosing case 1 also runs case 2.
- Fix: end each case with `break;`.

**6. Variable declared inside the `if` block**
- Looks like: `if (...) { String letter = "A"; } System.out.println(letter);`
- Error: `error: cannot find symbol ... symbol: variable letter`
- Fix: declare it before the `if`: `String letter;` and assign it inside.

**7. "might not have been initialized"**
- Looks like: `String letter;` then an `if / else if` chain with no final `else`, then printing `letter`.
- Error: `error: variable letter might not have been initialized`
- Fix: give it a starting value (`String letter = "";`) or make sure the chain ends with `else`.

---

## How this shows up at BPA

- The 2026 Java regional required "a switch statement to assign the operator and the answer," plus "2 if/else statements" and "2 if statements" to check answers. Graders look for these structures by name, so know which is which.
- Range checks (`if (value < 1 || value > 50)`) are on every test - checking the number of items, a menu choice, a score.
- Exact output means choosing between messages correctly, like "Correct!" vs "Incorrect. Try again!".
- Comparing Strings with `.equals()` is something graders notice. `==` on Strings is a classic Java bug.

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

**Sample run 1:**
```
Student name: Taylor
Score (0-100): 87
Taylor got a B.
Taylor passed.
```
**Sample run 2:**
```
Student name: Sam
Score (0-100): 105
Error: score must be 0 to 100.
```
**Sample run 3:**
```
Student name: Riley
Score (0-100): 100
Riley got an A.
Riley passed.
Perfect score!
```
**Sample run 4:**
```
Student name: Max
Score (0-100): 42
Max got an F.
Max did not pass.
```

**Hints**
- Class `Step03` in `Step03.java`. Read the score with `Integer.parseInt(keyboard.nextLine())`.
- Structure: `if (score < 0 || score > 100) { error } else { everything else }`.
- Store the letter in a `String letter` with an `else if` chain. Then decide the article (`"a"` or `"an"`) with an `if` that uses `letter.equals("A") || letter.equals("F")`.
- Test all four sample runs. Also test 90, 89, 60, 59, 0, and -1 - the edges are where mistakes hide.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step03`.
2. Put `Step03.java` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 3 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches all four sample runs
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Range check uses `||`
- [ ] Strings compared with `.equals()`, not `==`
- [ ] "an" before A and F, "a" before B, C, D
- [ ] Pushed to `bpaPrep/java_step03`
