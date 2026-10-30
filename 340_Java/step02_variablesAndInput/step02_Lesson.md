# Step 02 — Variables, Input, Math, and Formatting (Java)

**What you'll build:** Snack Bar Order — a program that asks for an order and prints a receipt with 7% tax.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Variables and data types](#variables-and-data-types)
- [Naming variables](#naming-variables)
- [Reading input with Scanner](#reading-input-with-scanner)
- [Converting text to numbers](#converting-text-to-numbers)
- [The nextInt and nextLine problem](#the-nextint-and-nextline-problem)
- [Math operators](#math-operators)
- [The whole-number division trap](#the-whole-number-division-trap)
- [Named constants](#named-constants)
- [Formatting numbers with printf](#formatting-numbers-with-printf)
- [Closing the Scanner](#closing-the-scanner)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Snack Bar Order](#the-challenge-snack-bar-order)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- Java's main data types: `String`, `int`, `double`, `boolean`, `char`
- How to declare a variable and give it a value
- How to read what the user types with a `Scanner`
- How to turn text into numbers with `Integer.parseInt` and `Double.parseDouble`
- Why we read every answer with `nextLine()` (the `nextInt` problem)
- Math operators, including `%` (remainder)
- Why `7 / 2` is `3` in Java, and how to fix it
- Named constants with `final`
- Printing money with 2 decimal places using `printf`

---

## Variables and data types

A **variable** is a named box that holds a value. In Java, every variable has a **type**, and you must say the type when you make (declare) the variable. The type can never change after that.

```java
String teamName = "Robotics";   // text
int members = 14;               // whole number
double dues = 12.50;            // decimal number
boolean isOpen = true;          // true or false
char section = 'B';             // one single character
```

| Type | Holds | Example values | Notes |
|---|---|---|---|
| `String` | Text | `"Jordan"`, `"Room 112"`, `""` | Capital **S**. Double quotes. |
| `int` | Whole numbers | `0`, `42`, `-7` | No decimal point. Range about -2 billion to 2 billion. |
| `double` | Decimal numbers | `2.75`, `0.07`, `-1.5` | Use for prices, averages, GPAs. |
| `boolean` | True or false | `true`, `false` | Lowercase. Used for yes/no decisions (Step 3). |
| `char` | One character | `'A'`, `'7'`, `'!'` | **Single** quotes. Used in Step 7. |

The pattern is always:

```
type name = value;
```

You can declare first and give the value later:

```java
int score;        // declared, no value yet
score = 95;       // now it has a value
score = 88;       // a variable can change - the old value is replaced
```

You **cannot** put the wrong type in a box:

```java
int count = 2.5;        // ERROR: incompatible types: possible lossy conversion from double to int
int age = "16";         // ERROR: incompatible types: String cannot be converted to int
```

`int`, `double`, `boolean`, and `char` are **primitive types** (lowercase names, they hold a simple value). `String` is a **class** (capital name). That difference will matter later when you compare Strings (Step 3).

**Try it:**
1. Make variables for your favorite food (`String`), your grade level (`int`), and your GPA (`double`), and print them in one sentence using `+`.
2. Try putting `3.5` into an `int` and read the error.

---

## Naming variables

- Java uses **camelCase** for variables: start lowercase, each new word starts with a capital. `customerName`, `totalCost`, `numberOfPlayers`.
- Use meaningful names. `price` is good. `p` or `x` is not. Graders check naming.
- No spaces, can't start with a digit, can't be a Java keyword (`class`, `int`, `public`...).
- At BPA Java events, the test gives you **exact variable names** and you add the last 2 digits of your Contestant ID. For example, `userNamexx` becomes `userName45` if your ID ends in 45. You will practice this in Step 12.

---

## Reading input with Scanner

To read what the user types, Java uses a **Scanner**. Using it takes three parts:

```java
import java.util.Scanner;        // 1. at the very top of the file, above the class

public class FavoriteColor {
    public static void main(String[] args) {
        Scanner keyboard = new Scanner(System.in);   // 2. make a Scanner that reads the keyboard

        System.out.print("Favorite color: ");        // the prompt - print, not println
        String color = keyboard.nextLine();          // 3. read the whole line the user types

        System.out.println("You picked " + color + ".");
        keyboard.close();
    }
}
```

Sample run (the user typed `green`):

```
Favorite color: green
You picked green.
```

| What you type | What it means |
|---|---|
| `import java.util.Scanner;` | Tells Java you want to use the `Scanner` class from the `java.util` library. Goes above `public class`. |
| `Scanner keyboard = new Scanner(System.in);` | Make a new Scanner object named `keyboard`. `System.in` means "the keyboard". `new` creates an object. |
| `keyboard.nextLine()` | Wait for the user to type a line and press Enter. Gives back everything they typed as a `String` (without the Enter). |
| `keyboard.close();` | Done with the Scanner. |

**Use `print` for prompts, not `println`.** With `print`, the user types on the same line as the question, like `Favorite color: green`. The challenge sample runs show the answers on the same line as the prompts. Notice the prompt ends with a colon and **a space**: `"Favorite color: "`.

You only make **one** Scanner for the keyboard and use it for every question.

---

## Converting text to numbers

`nextLine()` always gives you a `String`. Even if the user types `16`, you get the text `"16"`, not the number 16. You can't do math with text, so you convert it:

| What you type | What it does | Example |
|---|---|---|
| `Integer.parseInt(text)` | Turns text into an `int` | `Integer.parseInt("16")` gives `16` |
| `Double.parseDouble(text)` | Turns text into a `double` | `Double.parseDouble("2.75")` gives `2.75` |

```java
import java.util.Scanner;

public class AgeNextYear {
    public static void main(String[] args) {
        Scanner keyboard = new Scanner(System.in);

        // Input: read the age as text, then convert it to a whole number
        System.out.print("How old are you? ");
        int age = Integer.parseInt(keyboard.nextLine());

        // Input: read a height in feet as a decimal
        System.out.print("Height in feet: ");
        double heightFeet = Double.parseDouble(keyboard.nextLine());

        // Processing and Output
        System.out.println("Next year you will be " + (age + 1) + ".");
        System.out.println("That is " + (heightFeet * 12) + " inches.");
        keyboard.close();
    }
}
```

Sample run:

```
How old are you? 16
Height in feet: 5.5
Next year you will be 17.
That is 66.0 inches.
```

Notice the parentheses in `(age + 1)`. Without them, `"... be " + age + 1` would join `"16"` and then `"1"` and print `161`. When a String is on the left of `+`, Java joins text instead of adding numbers.

**If the user types letters** where a number is expected, `Integer.parseInt` crashes the program with a `NumberFormatException`. That is fine for now. **Step 10 makes input crash-proof.**

---

## The nextInt and nextLine problem

You will see other Java code that reads numbers with `keyboard.nextInt()` or `keyboard.nextDouble()`. Those work, but they cause a very common bug when you mix them with `nextLine()`:

```java
System.out.print("Age: ");
int age = keyboard.nextInt();          // reads 16, but leaves the Enter key in the input
System.out.print("Name: ");
String name = keyboard.nextLine();     // reads the leftover Enter - name is "" (empty)!
```

When the user types `16` and presses Enter, the input holds `16` followed by an invisible new-line character. `nextInt()` takes the `16` and **leaves the new-line behind**. The next `nextLine()` sees that new-line right away and returns an empty String without waiting. The program seems to "skip" the name question.

**The fix we use in every step:** always read a full line with `nextLine()`, then convert it.

```java
int age = Integer.parseInt(keyboard.nextLine());   // reads the whole line, Enter and all
```

This never leaves anything behind, and in Step 10 it lets you catch bad input easily. It is also what the BPA graders' sample runs expect: one answer per line.

---

## Math operators

| Operator | Meaning | Example | Result |
|---|---|---|---|
| `+` | Add | `7 + 2` | `9` |
| `-` | Subtract | `7 - 2` | `5` |
| `*` | Multiply | `7 * 2` | `14` |
| `/` | Divide | `7.0 / 2` | `3.5` |
| `%` | Remainder (modulus) | `7 % 2` | `1` |

Java follows normal math order: `*`, `/`, `%` happen before `+` and `-`. Use parentheses to be clear: `(a + b) * c`.

`%` gives the remainder after dividing. `17 % 5` is `2` because 17 = 3 × 5 + 2. It is useful for checking even/odd (`n % 2 == 0`) and for "wrap-around" math (Step 7).

Shortcut operators you will see a lot:

| Shortcut | Same as |
|---|---|
| `total += 5;` | `total = total + 5;` |
| `count++;` | `count = count + 1;` |
| `count--;` | `count = count - 1;` |

---

## The whole-number division trap

When **both** numbers are `int`, Java does **whole-number division** and throws away the remainder:

```java
public class DivisionTrap {
    public static void main(String[] args) {
        int pizzaSlices = 7;
        int people = 2;

        System.out.println(pizzaSlices / people);            // 3   (not 3.5!)
        System.out.println(pizzaSlices % people);            // 1   (the leftover slice)
        System.out.println((double) pizzaSlices / people);   // 3.5
        System.out.println(pizzaSlices / 2.0);               // 3.5
    }
}
```

Output:

```
3
1
3.5
3.5
```

If **either** number is a `double`, the answer is a `double`. You can turn an `int` into a `double` for one calculation by putting `(double)` in front of it. This is called a **cast**.

This trap matters for averages: `int total = 407; int count = 5; total / count` gives `81`, not `81.4`. You will use `(double)` in Step 6.

In the snack bar challenge, `price` is a `double`, so `price * quantity` is already a `double`. No trap there.

---

## Named constants

A **constant** is a variable whose value can never change. Use one for fixed values like a tax rate, so the number is written in one place with a clear name.

```java
final double SHIPPING_RATE = 0.05;
```

| What you type | What it means |
|---|---|
| `final` | This variable can't be changed after it gets its value. Trying to change it is a compile error. |
| `SHIPPING_RATE` | Constants are named in ALL CAPS with underscores between words. |

```java
SHIPPING_RATE = 0.10;   // ERROR: cannot assign a value to final variable SHIPPING_RATE
```

Why bother? If the rate changes, you change one line. And `subtotal * SHIPPING_RATE` explains itself better than `subtotal * 0.05`.

In Step 5 you will move constants outside of `main` so every method can use them.

---

## Formatting numbers with printf

Printing a `double` with `println` can give ugly results:

```java
System.out.println(19.99 * 3);   // prints 59.97 (fine)
System.out.println(0.1 + 0.2);   // prints 0.30000000000000004 (not fine)
```

Computers store decimals in binary, so tiny rounding errors show up. For money, always show exactly 2 decimal places with **`printf`** ("print formatted"):

```java
public class GasCost {
    public static void main(String[] args) {
        double gallons = 11.4;
        double pricePerGallon = 3.199;
        double cost = gallons * pricePerGallon;

        // Output: %.2f = a decimal with 2 places, %n = new line
        System.out.printf("Gas cost: $%.2f%n", cost);
        System.out.printf("%d gallons is not right, %.1f gallons is.%n", 11, gallons);
        System.out.printf("Driver: %s%n", "Avery");
        System.out.printf("Sales tax is 7%% in this example.%n");
    }
}
```

Output:

```
Gas cost: $36.47
11 gallons is not right, 11.4 gallons is.
Driver: Avery
Sales tax is 7% in this example.
```

`printf` takes a **format string** with placeholders, then the values to put in them, in order.

| Placeholder | Used for | Example |
|---|---|---|
| `%d` | An `int` | `printf("%d", 42)` prints `42` |
| `%.2f` | A `double`, 2 decimal places (rounded) | `printf("%.2f", 3.14159)` prints `3.14` |
| `%s` | A `String` | `printf("%s", "hi")` prints `hi` |
| `%n` | A new line | `printf` does **not** add a new line by itself |
| `%%` | A real `%` sign | Needed because `%` starts a placeholder |

Two things that trip people up:
- **`printf` does not end the line.** Put `%n` at the end (or `\n`).
- **A plain `%` in the text causes a crash.** `printf("Tax (7%): ...")` throws an `UnknownFormatConversionException` or similar error when it runs. Write `%%` to print one `%`.

If you want the formatted text as a `String` instead of printing it, use `String.format` - it works the same way:

```java
String money = String.format("$%.2f", 36.4686);   // money is "$36.47"
```

You will use `String.format` a lot in Step 5.

**Try it:**
1. Calculate the cost of 3 movie tickets at $11.25 and print it with `printf` and 2 decimal places.
2. Print `100% done` using `printf`.

---

## Closing the Scanner

When your program is finished with the keyboard, close the Scanner:

```java
keyboard.close();
```

It goes at the end of `main`. The 2026 Java regional gave 5 points for "The Scanner was closed." Only close it once, at the very end - after a Scanner on `System.in` is closed, you can't read from the keyboard again in that program.

---

## Common mistakes

**1. Forgetting the import**
- Looks like: using `Scanner` without `import java.util.Scanner;`
- Error: `error: cannot find symbol ... symbol: class Scanner`
- Fix: add `import java.util.Scanner;` at the top of the file.

**2. Using `String` input in math**
- Looks like: `String quantity = keyboard.nextLine(); double cost = price * quantity;`
- Error: `error: bad operand types for binary operator '*'`
- Fix: convert first: `int quantity = Integer.parseInt(keyboard.nextLine());`

**3. Mixing `nextInt()` and `nextLine()`**
- Looks like: the program "skips" a question and stores an empty name.
- No error message - just wrong behavior.
- Fix: read everything with `nextLine()` and convert with `parseInt` / `parseDouble`.

**4. A `%` sign inside `printf` text**
- Looks like: `System.out.printf("Tax (7%):  $%.2f%n", tax);`
- Error when it runs: `Exception in thread "main" java.util.UnknownFormatConversionException: Conversion = ')'`
- Fix: `Tax (7%%):` - two percent signs print one.

**5. Forgetting `%n` in `printf`**
- Looks like: two `printf` lines come out stuck together on one line.
- Fix: end the format string with `%n`.

**6. Whole-number division**
- Looks like: an average of `81.0` when it should be `81.4`.
- Fix: `(double) total / count`.

**7. Typing letters for a number**
- Looks like: user types `three` for the quantity.
- Error: `Exception in thread "main" java.lang.NumberFormatException: For input string: "three"`
- Fix: for now, type numbers. Step 10 handles this properly.

---

## How this shows up at BPA

- Every BPA Java test uses a **Scanner** to collect input, with **exact prompts**. "What is your name: " is not the same as "What is your name? ". Copy the prompts character for character, including the space at the end.
- The Java tests give exact variable names (with your ID digits added). Practice good camelCase names now.
- Money and averages are almost always shown with 2 decimal places. `printf("%.2f")` or `String.format` is how you do it.
- Graders award points for closing the Scanner.
- Input / Processing / Output comments on each block earn points.

---

## The challenge: Snack Bar Order

The snack bar needs a program that takes one order and prints a receipt.

**Requirements**
1. Header comment.
2. Ask for the customer's name, the item, the price (decimal), and the quantity (whole number) using the exact prompts below.
3. Store the tax rate in a named constant (`TAX_RATE = 0.07`).
4. Calculate subtotal (price × quantity), tax (subtotal × TAX_RATE), and total (subtotal + tax).
5. Print the receipt exactly as shown, money with 2 decimal places.
6. Input / Processing / Output comments on each block.

**Sample run (exact):**
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

There is no input checking yet. If you type letters for the price, the program crashes. **Step 10 makes it crash-proof.**

**Hints**
- Class `Step02` in `Step02.java`. You need `import java.util.Scanner;`.
- Constant: `final double TAX_RATE = 0.07;`
- Read every answer with `keyboard.nextLine()`. Convert price with `Double.parseDouble` and quantity with `Integer.parseInt`.
- There is a blank line before the receipt: `System.out.println();`
- Count the spaces after each label: `Item:` is followed by 6 spaces, `Quantity:` by 2, `Subtotal:` by 2, `Tax (7%):` by 2, `Total:` by 5. They line up the values in one column.
- Remember `%%` for the percent sign in the tax line if you use `printf`.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step02`.
2. Put `Step02.java` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 2 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] `TAX_RATE` is a `final` constant
- [ ] Every answer read with `nextLine()`; price converted with `Double.parseDouble`, quantity with `Integer.parseInt`
- [ ] Money printed with 2 decimal places
- [ ] Scanner closed at the end
- [ ] Pushed to `bpaPrep/java_step02`
