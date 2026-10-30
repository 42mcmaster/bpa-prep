# Step 10 — Error Handling (Java)

**What you'll build:** Ticket Order — a ticket ordering program with input methods that can't be crashed, and a saved order file.
**Time:** about one and a half class periods (2-3 hours). This is the most useful step for BPA.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [What an exception is](#what-an-exception-is)
- [Reading a crash message](#reading-a-crash-message)
- [try and catch](#try-and-catch)
- [Catching specific exceptions](#catching-specific-exceptions)
- [Exceptions you will see most](#exceptions-you-will-see-most)
- [finally](#finally)
- [Read a full line, then convert](#read-a-full-line-then-convert)
- [Reusable input methods](#reusable-input-methods)
- [getInt step by step](#getint-step-by-step)
- [Commenting your try/catch blocks](#commenting-your-trycatch-blocks)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Ticket Order](#the-challenge-ticket-order)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What an exception is and how to read a crash message (a "stack trace")
- `try` / `catch` to handle an error instead of crashing
- Catching specific exceptions: `NumberFormatException`, `IOException`, `FileNotFoundException`
- `finally` (briefly)
- Why reading every answer with `nextLine()` and then converting is the safest input pattern
- Writing **reusable input methods** - `getText`, `getInt`, `getYesNo` - that you can print and bring to BPA
- How to comment `try`/`catch` blocks for graders

---

## What an exception is

An **exception** is an error that happens **while the program is running**. Your code compiled fine, but something went wrong with the data: the user typed `two` where a number was expected, a file was missing, an index was too big.

When an exception happens and nothing handles it, Java **stops the program** and prints a crash message. At BPA, a crash during grading can cost you most of the execution points. Graders always try bad input: letters, decimals, negative numbers, blanks.

---

## Reading a crash message

Here is a tiny program that crashes when the user types letters:

```java
import java.util.Scanner;

public class CrashDemo {
    public static void main(String[] args) {
        Scanner keyboard = new Scanner(System.in);
        System.out.print("How many tickets? ");
        int tickets = Integer.parseInt(keyboard.nextLine());
        System.out.println("You want " + tickets + " tickets.");
        keyboard.close();
    }
}
```

If the user types `two`:

```
How many tickets? two
Exception in thread "main" java.lang.NumberFormatException: For input string: "two"
	at java.base/java.lang.NumberFormatException.forInputString(NumberFormatException.java:67)
	at java.base/java.lang.Integer.parseInt(Integer.java:662)
	at java.base/java.lang.Integer.parseInt(Integer.java:778)
	at CrashDemo.main(CrashDemo.java:7)
```

How to read it:
1. **The first line** tells you **what** went wrong: a `NumberFormatException`, because `"two"` is not a number.
2. **The `at` lines** are the **stack trace** - the chain of methods that were running. Most of them are inside Java's own code (`java.base/...`). Look for the line with **your** file name: `CrashDemo.java:7`. That is the line of your code that caused it.

(The exact line numbers inside `java.base` can be different on your computer.)

---

## try and catch

`try` / `catch` lets you handle an exception instead of crashing:

```java
try {
    // code that might throw an exception
} catch (ExceptionType e) {
    // runs only if that exception happened in the try block
}
// the program keeps going here either way
```

```java
import java.util.Scanner;

public class SafeTickets {
    public static void main(String[] args) {
        Scanner keyboard = new Scanner(System.in);
        System.out.print("How many tickets? ");
        String text = keyboard.nextLine();

        // try/catch: catches NumberFormatException if the text is not a whole number
        try {
            int tickets = Integer.parseInt(text);
            System.out.println("You want " + tickets + " tickets.");
        } catch (NumberFormatException e) {
            System.out.println("That was not a whole number.");
        }

        System.out.println("Program still running.");
        keyboard.close();
    }
}
```

Run with `two`:

```
How many tickets? two
That was not a whole number.
Program still running.
```

Run with `4`:

```
How many tickets? 4
You want 4 tickets.
Program still running.
```

When the exception happens on the `parseInt` line, Java **skips the rest of the `try` block** (the "You want..." line never runs) and jumps to the `catch`. After the `catch`, the program continues normally.

A variable declared inside `try { }` only exists inside it (scope, from Step 5). If you need the value after the `try`, declare the variable **before** the `try`.

---

## Catching specific exceptions

Always catch the **specific** exception you expect. Each kind of problem has its own exception class. You can have more than one `catch`:

```java
try {
    int seats = Integer.parseInt(text);
    int perRow = 100 / seats;
    System.out.println(perRow + " per row");
} catch (NumberFormatException e) {
    System.out.println("Not a whole number.");
} catch (ArithmeticException e) {
    System.out.println("Can't divide by zero.");
}
```

Java checks the `catch` blocks in order and runs the first one that matches.

You might see `catch (Exception e)`, which catches **every** kind of exception. Avoid it in your BPA programs. It hides real bugs (like a typo that causes an `IndexOutOfBoundsException`), and graders want to see that you know **which** error you are handling.

---

## Exceptions you will see most

| Exception | When it happens | Checked? |
|---|---|---|
| `NumberFormatException` | `Integer.parseInt("two")`, `Integer.parseInt("2.5")`, `Integer.parseInt("")`, `Double.parseDouble("abc")` | No |
| `InputMismatchException` | `keyboard.nextInt()` when the user types letters (from `java.util`) | No |
| `ArrayIndexOutOfBoundsException` / `IndexOutOfBoundsException` | Bad index on an array or ArrayList | No |
| `ArithmeticException` | Whole-number division by zero (`5 / 0`) | No |
| `NullPointerException` | Using a variable that holds `null` (no object) | No |
| `FileNotFoundException` | Opening a file to read that isn't there | **Yes** |
| `IOException` | Any read/write problem with a file (`FileNotFoundException` is one kind) | **Yes** |

**Checked** exceptions (from [Step 9](../step09_files/step09_Lesson.md#checked-exceptions-java-makes-you-plan-for-a-missing-file)) must be caught or declared, or the program won't compile. **Unchecked** ones compile fine but crash at run time if you don't handle them. Input errors are unchecked - Java won't remind you - so you must remember to handle them.

`Integer.parseInt` is strict, which is good for BPA: it rejects `"2.5"`, `"3abc"`, `""`, and `"two"`. It accepts `"-3"` and `"+3"` (those are whole numbers), so you still need a range check.

---

## finally

A `finally` block runs **whether or not** an exception happened. It is used for cleanup:

```java
try {
    System.out.println("Trying...");
    int n = Integer.parseInt("abc");
} catch (NumberFormatException e) {
    System.out.println("Bad number.");
} finally {
    System.out.println("This always runs.");
}
```

Output:

```
Trying...
Bad number.
This always runs.
```

You won't need `finally` much, because try-with-resources (Step 9) already closes files for you. Know what it means if you see it.

---

## Read a full line, then convert

There are two common ways to read numbers in Java:

**Way 1 (what we use):** `nextLine()` + `Integer.parseInt()`, catch `NumberFormatException`.

**Way 2 (you will see it in other code):** `keyboard.nextInt()`, catch `InputMismatchException`. But when it fails, the bad text **stays in the input**, so you must remember to clear it with `keyboard.nextLine()` in the `catch`, or the loop repeats the error forever. And it still has the leftover-Enter problem from [Step 2](../step02_variablesAndInput/step02_Lesson.md#the-nextint-and-nextline-problem). It also accepts `5 6` as `5` and leaves `6` waiting, and it skips blank lines instead of rejecting them.

Way 1 has none of those problems: every call reads exactly one full line, whatever the user typed. That is why every step in this course reads with `nextLine()`.

---

## Reusable input methods

This is the most valuable code in the course for BPA. Write these methods once, test them hard, **print them**, and bring them to the event. Every BPA programming test asks for validated input.

All three use one class-level Scanner (Step 5) and a loop that ends by its condition, not `break` (Step 4).

**`getText` - not blank:**

```java
/*
 * Purpose: ask for text until the user types something that is not blank.
 * Parameters: prompt - the question to show
 * Returns: the text, with spaces trimmed off both ends
 */
static String getText(String prompt) {
    System.out.print(prompt);
    String answer = keyboard.nextLine().trim();
    while (answer.isEmpty()) {
        System.out.println("This cannot be blank.");
        System.out.print(prompt);
        answer = keyboard.nextLine().trim();
    }
    return answer;
}
```

`.trim()` removes spaces from both ends, so an answer of only spaces becomes `""` and counts as blank.

**`getDouble` - a decimal in a range** (not needed in the challenge, but good to have printed):

```java
/*
 * Purpose: ask for a decimal number until it is from low to high.
 * Parameters: prompt - the question; low - smallest allowed; high - largest allowed
 * Returns: the valid number
 */
static double getDouble(String prompt, double low, double high) {
    double number = 0;
    boolean valid = false;
    while (!valid) {
        System.out.print(prompt);
        String text = keyboard.nextLine().trim();
        // try/catch: NumberFormatException means the text was not a number
        try {
            number = Double.parseDouble(text);
            valid = number >= low && number <= high;
        } catch (NumberFormatException e) {
            valid = false;
        }
        if (!valid) {
            System.out.println("Please enter a number from " + low + " to " + high + ".");
        }
    }
    return number;
}
```

The challenge also needs `getInt` and `getYesNo` - you will write those. `getInt` is explained step by step below.

---

## getInt step by step

`getInt(prompt, low, high)` must keep asking until the answer is a whole number from `low` to `high`. It must reject letters, decimals like `2.5`, blanks, and out-of-range numbers **without crashing**.

Plan it in plain words first:

1. Make a variable to hold the number, and a `boolean valid = false`.
2. While not valid:
   1. Print the prompt and read a full line. Trim it.
   2. **Try** to convert it with `Integer.parseInt`.
      - If that works, check the range. If it is in range, set `valid = true`.
      - If it throws `NumberFormatException`, it stays not valid.
   3. If it is still not valid, print the error message.
3. Return the number.

Every kind of bad answer ends up at step 2.3 with the same message, which is exactly what the challenge wants: `Please enter a whole number from 1 to 3.` for `two`, for `2.5`, for a blank, and for `7`.

Here is how a call looks:

```java
int quantity = getInt("Quantity (1-10): ", 1, 10);
```

Write the method yourself from the plan. The [`getDouble`](#reusable-input-methods) method above has the same shape - the differences are the type, `Integer.parseInt`, and the message.

**`getYesNo`** returns a `boolean`: `true` for `y`/`Y`, `false` for `n`/`N`, and asks again for anything else. Hint: `equalsIgnoreCase("y")` handles both cases, and the loop condition can be "while the answer is not y and not n."

**Test your methods hard.** For each number prompt, try: `abc`, `2.5`, an empty Enter, spaces only, `-1`, `0`, the lowest allowed, the highest allowed, one more than the highest. The program must never crash.

---

## Commenting your try/catch blocks

Graders look for exception handling and award points for it - but only if they can find it and see that you understand it. Put a comment on **every** `try`/`catch` that says **what it catches and why**:

```java
// try/catch: catches NumberFormatException, which Integer.parseInt throws
// when the text is not a whole number (letters, "2.5", or blank).
try {
    ...
} catch (NumberFormatException e) {
    ...
}
```

```java
// try/catch: catches IOException, which happens if orders.txt can't be written
// (for example, the file is open in another program or the folder is read-only).
try (PrintWriter writer = new PrintWriter(new FileWriter("orders.txt"))) {
    ...
} catch (IOException e) {
    ...
}
```

The 2024 Java regional had a whole graded item for "properly uses the try/catch code for data type input error" (30 points) and another for "strategy for detecting range violations" (20 points). That is `getInt`.

---

## Common mistakes

**1. Variable declared inside `try`, used after it**
- Looks like: `try { int n = Integer.parseInt(text); } ... return n;`
- Error: `error: cannot find symbol ... symbol: variable n`
- Fix: declare `int number = 0;` before the `try`, assign inside it.

**2. Catching the wrong exception**
- Looks like: `catch (InputMismatchException e)` around `Integer.parseInt`.
- No compile error, but the program still crashes on `two`, because `parseInt` throws `NumberFormatException`.
- Fix: catch `NumberFormatException` for `parseInt` / `parseDouble`.

**3. Infinite loop of error messages**
- Looks like: `Please enter a whole number...` printed forever after one bad answer.
- Cause: using `nextInt()` and not clearing the bad input, or reading the input **outside** the loop.
- Fix: read a new line with `nextLine()` **inside** the loop every time.

**4. Not trimming**
- Looks like: `   ` (spaces) is accepted as a name, or ` 3` fails to convert.
- Fix: `keyboard.nextLine().trim()`.

**5. Range check missing**
- Looks like: `getInt` accepts `-5` or `99`.
- Fix: after converting, check `number >= low && number <= high`.

**6. Empty `catch` block with no comment**
- Looks like: `catch (NumberFormatException e) { }`
- It works, but graders can't tell whether you meant it. Write a comment, or set `valid = false;` so it is clear.

**7. Exiting the loop with `break` or `return` inside `while (true)`**
- Works, but BPA Java tests have taken points for `break` out of loops. Use a `boolean valid` flag in the loop condition.

---

## How this shows up at BPA

- Every BPA programming test checks bad input. The 2024 Java regional gave points for "When entering wrong data values, program gives warning message" **and** "program keeps running and prompts user" - for both wrong types and out-of-range numbers.
- The 2026 C++ regional said to reject "letters, symbols, decimals, and negatives" where whole numbers are expected.
- Graders look for `try`/`catch` by name in source code review. Comment each one.
- Your printed `getText` / `getInt` / `getYesNo` methods are allowed as printed code at the event. Type them in at the start of every timed build.

---

## The challenge: Ticket Order

Write a ticket ordering program that can't be crashed by bad input.

**Requirements**
1. Header comment.
2. Write these reusable methods:
   - `getText(prompt)` → keeps asking until the answer is not blank; on blank prints `This cannot be blank.`
   - `getInt(prompt, low, high)` → keeps asking until the answer is a whole number from low to high; otherwise prints `Please enter a whole number from <low> to <high>.` Must reject letters, decimals like `2.5`, blanks, and out-of-range numbers without crashing.
   - `getYesNo(prompt)` → returns true for `y`/`Y`, false for `n`/`N`; anything else prints `Please enter y or n.` and asks again.
3. Ask for the name with `getText`, then repeat: show the ticket types, ask ticket type (1–3) and quantity (1–10) with `getInt`, add to the order, ask `Another order? (y/n): ` with `getYesNo`.
   - Ticket types and prices: 1-Student $5.00, 2-Adult $8.50, 3-Senior $6.25.
4. At the end print total tickets and total cost.
5. Save the order to `orders.txt` inside a try/catch. One line per order in the form `Jordan,Adult,3,25.50`. On success print `Order saved to orders.txt`; if writing fails print `Error: could not save orders.txt` (no crash).
6. Method comments and Input / Processing / Output comments, including a comment on each try/catch saying what error it catches.

**Sample run (exact):**
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
`orders.txt`:
```
Jordan,Adult,3,25.50
Jordan,Student,2,10.00
```
(The first line `Name: ` with nothing typed means the user pressed Enter. Whitespace-only counts as blank — trim it.)

**Hints**
- Class `Step10` in `Step10.java`. Class-level `static Scanner keyboard`.
- Store the ticket info in two parallel arrays at the class level: `static final String[] TICKET_NAMES = {"Student", "Adult", "Senior"};` and `static final double[] TICKET_PRICES = {5.00, 8.50, 6.25};`. Ticket type 2 is index 1, so use `type - 1`.
- Keep each order line in an `ArrayList<String>`. Build each line with `String.format("%s,%s,%d,%.2f", name, typeName, quantity, cost)`.
- Write the file after the loop, in its own method like `saveOrders(ArrayList<String> orderLines)`, with try-with-resources (Step 9).
- To test the "could not save" message, make `orders.txt` read-only (right-click > Properties > Read-only in Windows) and run again.

**Try it (not turned in):** go back to your Step 4 guessing game and replace the guess input with `getInt("Your guess (1-100): ", 1, 100)`. Now typing letters can't crash it. (The "Please guess between 1 and 100." message will change to the `getInt` message - that's fine for this exercise.)

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step10`.
2. Put `Step10.java` and the `orders.txt` your program made in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 10 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run, and `orders.txt` matches
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `getText`, `getInt`, `getYesNo` written and used, each with a purpose / parameters / returns comment
- [ ] Tested with letters, decimals, blanks, spaces, negatives, and out-of-range numbers - no crashes
- [ ] Every try/catch has a comment saying what it catches
- [ ] Loops end by their condition (no `break`)
- [ ] Pushed to `bpaPrep/java_step10`
