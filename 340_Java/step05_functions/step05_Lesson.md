# Step 05 — Methods (Functions) (Java)

**What you'll build:** Snack Bar with Functions — the Step 2 snack bar rebuilt with methods, so one order can have several items.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Why use methods](#why-use-methods)
- [Writing and calling a method](#writing-and-calling-a-method)
- [Parameters](#parameters)
- [Return values](#return-values)
- [void methods](#void-methods)
- [What static means](#what-static-means)
- [main is the starting method](#main-is-the-starting-method)
- [Local variables and scope](#local-variables-and-scope)
- [Class-level constants and one shared Scanner](#class-level-constants-and-one-shared-scanner)
- [The method comment block](#the-method-comment-block)
- [Methods calling other methods](#methods-calling-other-methods)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Snack Bar with Functions](#the-challenge-snack-bar-with-functions)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- What a method is and why BPA wants "each major part in its own method"
- How to write a method with parameters and a return value
- `void` methods that do something but don't return a value
- What `static` means, in plain words
- Why `main` is where the program starts
- Local variables and scope (where a variable exists)
- Putting constants and the `Scanner` at the class level so every method can use them
- The comment block every method needs: purpose, parameters, return value

In Java, a function is called a **method**. Python and C++ say "function". The idea is the same. BPA's Java tests use both words.

---

## Why use methods

A **method** is a named block of code that does one job. You write it once and **call** it (run it) by name whenever you need it.

- **No repeated code.** If you need to format money in five places, write `formatMoney` once and call it five times. If the format changes, you fix one place.
- **Easier to read.** `main` becomes a short list of steps: get input, calculate, print. Each step's details live in its own method.
- **Easier to test.** You can test one method at a time.
- **BPA requires it.** The Python regional said "each major part a documented function," and the Java tests name the methods you must write (for example `setStudents`, `printStudents`, and `integerInputManager` on the 2024 Java regional). Graders give points for methods **and** for their comments.

---

## Writing and calling a method

```java
public class Greeting {

    /*
     * Purpose: print a welcome banner.
     * Parameters: none
     * Returns: nothing (void)
     */
    static void printBanner() {
        System.out.println("*************************");
        System.out.println("  Welcome to BPA Friday");
        System.out.println("*************************");
    }

    public static void main(String[] args) {
        printBanner();                       // call the method
        System.out.println("Let's start.");
        printBanner();                       // call it again
    }
}
```

Output:

```
*************************
  Welcome to BPA Friday
*************************
Let's start.
*************************
  Welcome to BPA Friday
*************************
```

| Part of `static void printBanner()` | Meaning |
|---|---|
| `static` | The method belongs to the class. (See [What static means](#what-static-means).) |
| `void` | The **return type**. `void` means it gives nothing back. |
| `printBanner` | The method's name. Methods use camelCase, like variables, and usually start with a verb: `print...`, `calculate...`, `get...`. |
| `()` | The **parameter list** - empty here. |
| `{ ... }` | The method's body. |

Methods go **inside the class** but **outside of `main`** (and outside each other). The order of methods in the class doesn't matter - `main` can call a method written above it or below it.

To **call** a method, write its name and parentheses: `printBanner();`

---

## Parameters

A **parameter** is a variable that gets its value from the caller. It lets the same method work on different data.

```java
/*
 * Purpose: print a line of a given character, a given length.
 * Parameters: symbol - the character to repeat; length - how many to print
 * Returns: nothing (void)
 */
static void printLine(char symbol, int length) {
    for (int i = 0; i < length; i++) {
        System.out.print(symbol);
    }
    System.out.println();
}
```

Calls:

```java
printLine('=', 10);   // ==========
printLine('-', 4);    // ----
```

- Each parameter has a **type and a name**, separated by commas: `(char symbol, int length)`.
- The values in the call (`'='` and `10`) are called **arguments**. They are matched to the parameters **in order** - the first argument goes into the first parameter.
- The arguments must be the right types. `printLine(10, '=')` is an error because the order is wrong.

---

## Return values

A method can calculate something and **return** (give back) the answer. The return type replaces `void`.

```java
/*
 * Purpose: convert a temperature from Fahrenheit to Celsius.
 * Parameters: fahrenheit - the temperature in degrees F
 * Returns: the temperature in degrees C
 */
static double toCelsius(double fahrenheit) {
    double celsius = (fahrenheit - 32) * 5 / 9;
    return celsius;
}
```

Use the returned value by storing it, printing it, or using it in math:

```java
double today = toCelsius(68);                        // store it
System.out.printf("%.1f C%n", toCelsius(212));       // print it: 100.0 C
double change = toCelsius(80) - toCelsius(60);       // use it in math
```

- `return` sends the value back and **ends the method right away**.
- The value returned must match the return type (`double` here).
- A method can return only **one** value.
- A method with a non-`void` return type **must** return a value on every path, or you get `error: missing return statement`.

**Return vs print.** A method that *returns* a value lets the caller decide what to do with it (print it, save it to a file, use it in math). A method that *prints* can only print. Most calculation methods should **return**.

Here is a whole program that puts parameters and returns together:

```java
import java.util.Scanner;

public class RoomPaint {

    static final double COVERAGE_PER_GALLON = 350.0;   // square feet one gallon covers

    /*
     * Purpose: calculate the area of a wall.
     * Parameters: width - wall width in feet; height - wall height in feet
     * Returns: the area in square feet
     */
    static double wallArea(double width, double height) {
        // Processing: area = width x height
        return width * height;
    }

    /*
     * Purpose: figure out how many gallons of paint are needed.
     * Parameters: area - square feet to paint
     * Returns: gallons needed (a decimal)
     */
    static double gallonsNeeded(double area) {
        return area / COVERAGE_PER_GALLON;
    }

    public static void main(String[] args) {
        Scanner keyboard = new Scanner(System.in);

        // Input
        System.out.print("Wall width (ft): ");
        double width = Double.parseDouble(keyboard.nextLine());
        System.out.print("Wall height (ft): ");
        double height = Double.parseDouble(keyboard.nextLine());

        // Processing: call the methods
        double area = wallArea(width, height);
        double gallons = gallonsNeeded(area);

        // Output
        System.out.printf("Area: %.1f sq ft%n", area);
        System.out.printf("Paint: %.2f gallons%n", gallons);
        keyboard.close();
    }
}
```

Sample run:

```
Wall width (ft): 14
Wall height (ft): 9
Area: 126.0 sq ft
Paint: 0.36 gallons
```

---

## void methods

A `void` method does a job (usually printing) and returns nothing. You call it as a statement on its own line:

```java
printLine('*', 20);
```

You can't store the result of a `void` method - there isn't one:

```java
int x = printLine('*', 20);   // ERROR: incompatible types: void cannot be converted to int
```

A `void` method can still use `return;` (with no value) to stop early. You will see that in Step 11.

---

## What static means

You have typed `static` since Step 1. Here is what it means, in plain words:

- A **class** is like a blueprint. An **object** is one thing built from the blueprint (Step 11 makes your own).
- A **`static`** method belongs to the **class itself**, not to any one object. You can call it without making an object first.
- `main` is `static` so Java can start your program without making an object.
- Because `main` is `static`, any method that `main` calls **directly by name** must also be `static`.

If you forget `static` on a method and call it from `main`, you get:

```
error: non-static method printBanner() cannot be referenced from a static context
```

The fix is to add `static`. Until Step 11, **every method you write is `static`**.

(You can also write `public static` or `private static`. `public` and `private` control who outside the class may use the method. In a one-file program it doesn't matter, so these lessons leave it off, except on `main`, which must be `public`.)

---

## main is the starting method

When you type `java Step05`, Java finds `public static void main(String[] args)` in the class `Step05` and runs it from the top. Every other method only runs if `main` (or a method that `main` called) calls it.

A good `main` reads like an outline:

```java
public static void main(String[] args) {
    // Input
    String name = getName();
    // Processing
    double total = calculateTotal(...);
    // Output
    printReport(name, total);
}
```

---

## Local variables and scope

A variable declared **inside** a method is a **local variable**. It only exists inside that method, from the line where it is declared until the closing `}` of its block. This is called the variable's **scope**.

```java
static double addTip(double bill) {
    double tip = bill * 0.18;      // tip is local to addTip
    return bill + tip;
}

public static void main(String[] args) {
    double total = addTip(40.00);
    System.out.println(tip);       // ERROR: cannot find symbol - tip doesn't exist here
}
```

- Two methods can each have a variable named `total` - they are completely separate boxes.
- Parameters are local variables too. Changing a parameter inside the method does **not** change the caller's variable.
- To get a value out of a method, **return** it.

---

## Class-level constants and one shared Scanner

In Step 2, `TAX_RATE` was declared inside `main`. That means only `main` could use it. If a method like `calculateTax` needs it, move it up to the **class level** - inside the class, but outside every method:

```java
import java.util.Scanner;

public class Example {

    // Class level: every method in this class can use these.
    static final double TAX_RATE = 0.07;
    static Scanner keyboard = new Scanner(System.in);

    static double calculateTax(double amount) {
        return amount * TAX_RATE;           // works - TAX_RATE is class level
    }

    public static void main(String[] args) {
        System.out.print("Amount: ");
        double amount = Double.parseDouble(keyboard.nextLine());   // works - keyboard is class level
        System.out.printf("Tax: $%.2f%n", calculateTax(amount));
        keyboard.close();
    }
}
```

| What you type | What it means |
|---|---|
| `static final double TAX_RATE = 0.07;` | A class-level constant. `static` = belongs to the class. `final` = can't change. |
| `static Scanner keyboard = new Scanner(System.in);` | One Scanner shared by every method. |

**Make only one Scanner for the keyboard.** If several methods each make their own `new Scanner(System.in)`, the program can lose input, especially when you pipe input in for testing. One class-level Scanner avoids that. Close it once, at the end of `main`.

---

## The method comment block

Every method gets a comment right above it with three things. BPA development standards say methods "must be documented with comments explaining the purpose of the method, the input parameters (if any), and the output (if any)."

```java
/*
 * Purpose: what the method does, in one sentence.
 * Parameters: each parameter and what it is (or "none")
 * Returns: what it gives back (or "nothing (void)")
 */
```

You may also see the **Javadoc** style, which starts with `/**` and uses tags:

```java
/**
 * Converts a temperature from Fahrenheit to Celsius.
 * @param fahrenheit the temperature in degrees F
 * @return the temperature in degrees C
 */
```

Either style is fine. Be consistent. The important part is that all three things are there.

---

## Methods calling other methods

Methods can call other methods. A "print the report" method can call a "format money" method:

```java
/*
 * Purpose: format a number as a score out of 100, like "87/100".
 * Parameters: points - the score
 * Returns: the formatted text
 */
static String formatScore(int points) {
    return points + "/100";
}

/*
 * Purpose: print one line of a report card.
 * Parameters: subject - class name; points - the score
 * Returns: nothing (void)
 */
static void printReportLine(String subject, int points) {
    System.out.println(subject + ": " + formatScore(points));
}
```

`printReportLine("Math", 87);` prints `Math: 87/100`.

`String.format` (from Step 2) is perfect for methods that build text. It works like `printf` but **returns** the text instead of printing it:

```java
String text = String.format("%.2f", 3.14159);   // "3.14"
```

**Try it:**
1. Write `static int square(int n)` that returns `n * n`, and print `square(1)` through `square(10)` with a `for` loop.
2. Write `static String letterGrade(int score)` that returns `"A"`, `"B"`, ... using your Step 3 `else if` chain. Call it from `main`.

---

## Common mistakes

**1. Calling a non-static method from `main`**
- Error: `error: non-static method calculateTax(double) cannot be referenced from a static context`
- Fix: add `static` to the method.

**2. Missing return**
- Looks like: `static double calculateTax(double subtotal) { double tax = subtotal * TAX_RATE; }`
- Error: `error: missing return statement`
- Fix: `return tax;` at the end.

**3. Ignoring the returned value**
- Looks like: `calculateTax(subtotal);` on a line by itself.
- No error, but the answer is thrown away.
- Fix: store it: `double tax = calculateTax(subtotal);`

**4. Wrong number or order of arguments**
- Looks like: `printReceipt(subtotal, name, count);` when the method is `printReceipt(String name, int itemCount, double subtotal)`.
- Error: usually `error: incompatible types: double cannot be converted to String` (pointing at the first argument in the wrong place), or `error: method printReceipt in class Step05 cannot be applied to given types;` with `required:` and `found:` lines when the number of arguments is wrong.
- Fix: pass arguments in the same order as the parameters.

**5. A method written inside `main`**
- Error: `error: illegal start of expression`
- Fix: move the method outside `main`, but still inside the class.

**6. Making a new Scanner in every method**
- Looks like: input gets "lost", especially when testing with copied input.
- Fix: one `static Scanner keyboard` at the class level.

**7. Using a local variable from another method**
- Error: `error: cannot find symbol ... symbol: variable tax`
- Fix: return the value, or pass it in as a parameter.

---

## How this shows up at BPA

- Graders check that each major part is its own method **and** that each method has a comment with purpose, parameters, and return.
- The Java tests sometimes give you the exact method names to write. Spell them exactly as given.
- A method like `formatMoney` or `getInt` (Step 10) that you write once and reuse is the kind of "printed code" you can bring to BPA.
- Methods make it easier to keep a running version. Write the method, test it, save, then move to the next one.

---

## The challenge: Snack Bar with Functions

Rebuild the Step 2 snack bar using methods, so one order can have several items.

**Requirements**
1. Header comment.
2. Rebuild the Step 2 snack bar so an order can have **several items**: after each item ask `Add another item? (y/n): `.
3. Write these methods (names in Java style):
   - `calculateSubtotal(price, quantity)` → returns price × quantity
   - `calculateTax(subtotal)` → returns subtotal × TAX_RATE
   - `formatMoney(amount)` → returns text like `$12.04`
   - `printReceipt(name, itemCount, subtotal)` → prints the receipt (calls `calculateTax` and `formatMoney`), returns nothing
   - `main()` → asks the questions, keeps the running subtotal and item count, calls `printReceipt`
4. Every method has a comment with its purpose, parameters, and return value.
5. Input / Processing / Output comments.

**Sample run (exact):**
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
(`Items ordered` is the total quantity: 3 + 2.)

**Hints**
- Class `Step05` in `Step05.java`.
- Put `static final double TAX_RATE = 0.07;` and `static Scanner keyboard = new Scanner(System.in);` at the class level.
- Method headers: `static double calculateSubtotal(double price, int quantity)`, `static double calculateTax(double subtotal)`, `static String formatMoney(double amount)`, `static void printReceipt(String name, int itemCount, double subtotal)`.
- `formatMoney` can be one line: `return String.format("$%.2f", amount);`
- In `main`, use a `while` loop controlled by a `boolean` (Step 4's play again pattern). Keep two running totals: the subtotal (`double`) and the item count (`int`).
- Since `formatMoney` returns text, the receipt lines can use `println` with `+`: `"Subtotal:  " + formatMoney(subtotal)`. Then you don't need `%%` for the tax line.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step05`.
2. Put `Step05.java` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 5 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] All five methods written with the right parameters and return types
- [ ] Every method has a purpose / parameters / returns comment
- [ ] `TAX_RATE` and the Scanner are at the class level
- [ ] `printReceipt` calls `calculateTax` and `formatMoney`
- [ ] Pushed to `bpaPrep/java_step05`
