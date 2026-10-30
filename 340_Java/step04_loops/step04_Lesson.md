# Step 04 — Loops (Java)

**What you'll build:** Number Guessing Game — the computer picks a random number and the player guesses until they get it, with a guess chart and "play again".
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [The while loop](#the-while-loop)
- [Loop counters and running totals](#loop-counters-and-running-totals)
- [Asking again until the input is valid](#asking-again-until-the-input-is-valid)
- [The for loop](#the-for-loop)
- [The do-while loop](#the-do-while-loop)
- [break, and why BPA wants loops to end by their condition](#break-and-why-bpa-wants-loops-to-end-by-their-condition)
- [Random numbers](#random-numbers)
- [A play again loop](#a-play-again-loop)
- [Testing a random program](#testing-a-random-program)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Number Guessing Game](#the-challenge-number-guessing-game)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- `while` loops: repeat while a condition is true
- Counters (`count++`) and running totals
- An input loop that asks again until the answer is in range
- `for` loops: repeat a set number of times
- `do-while` loops (briefly)
- What `break` does, and why the BPA Java tests want loops to end by their condition instead
- Random numbers with `java.util.Random`
- A "play again" loop wrapped around a whole program
- How to test a program that uses random numbers

---

## The while loop

A `while` loop repeats its block **as long as** the condition is true. It checks the condition **before** each pass.

```java
while (condition) {
    // repeats while condition is true
}
```

```java
public class Countdown {
    public static void main(String[] args) {
        int seconds = 5;

        // Processing / Output: count down from 5 to 1
        while (seconds > 0) {
            System.out.println(seconds + "...");
            seconds--;            // same as seconds = seconds - 1
        }
        System.out.println("Liftoff!");
    }
}
```

Output:

```
5...
4...
3...
2...
1...
Liftoff!
```

Each pass through the loop is called an **iteration**. Something inside the loop **must** change so the condition eventually becomes false. Here `seconds--` does that. If you forget it, the loop never ends (an **infinite loop**). In VS Code, click in the Terminal and press **Ctrl+C** to stop a program that is stuck.

---

## Loop counters and running totals

Two patterns you will use in almost every program:

- A **counter** starts at 0 and goes up by 1 each time something happens: `count++;`
- A **running total** starts at 0 and adds a value each time: `total = total + value;` (or `total += value;`)

```java
import java.util.Scanner;

public class CanDrive {
    public static void main(String[] args) {
        Scanner keyboard = new Scanner(System.in);
        int totalCans = 0;   // running total
        int days = 0;        // counter

        // Input / Processing: keep reading until the user types 0
        System.out.print("Cans collected today (0 to stop): ");
        int cans = Integer.parseInt(keyboard.nextLine());
        while (cans != 0) {
            totalCans = totalCans + cans;
            days++;
            System.out.print("Cans collected today (0 to stop): ");
            cans = Integer.parseInt(keyboard.nextLine());
        }

        // Output
        System.out.println("Days: " + days + ", total cans: " + totalCans);
        keyboard.close();
    }
}
```

Sample run:

```
Cans collected today (0 to stop): 40
Cans collected today (0 to stop): 25
Cans collected today (0 to stop): 0
Days: 2, total cans: 65
```

The `0` here is a **sentinel value** - a special answer that means "stop". Notice the pattern: ask once **before** the loop, then ask again at the **end** of the loop body. That way the condition always checks the newest answer.

---

## Asking again until the input is valid

The same pattern checks a range. Ask once, then loop **while the answer is bad**, printing a message and asking again.

```java
System.out.print("Pick a seat row (1-20): ");
int row = Integer.parseInt(keyboard.nextLine());
while (row < 1 || row > 20) {
    System.out.println("Rows go from 1 to 20.");
    System.out.print("Pick a seat row (1-20): ");
    row = Integer.parseInt(keyboard.nextLine());
}
// After the loop, row is guaranteed to be 1-20.
```

Sample run:

```
Pick a seat row (1-20): 25
Rows go from 1 to 20.
Pick a seat row (1-20): 0
Rows go from 1 to 20.
Pick a seat row (1-20): 7
```

This only handles numbers that are out of range. Typing letters still crashes the program. Step 10 fixes that.

---

## The for loop

A `for` loop is the best choice when you know **how many times** to repeat. It puts the three parts of a counting loop on one line.

```java
for (int i = 1; i <= 5; i++) {
    System.out.println("Lap " + i);
}
```

Output:

```
Lap 1
Lap 2
Lap 3
Lap 4
Lap 5
```

| Part | Example | When it runs |
|---|---|---|
| Start | `int i = 1` | Once, before the loop starts. Makes the counter. |
| Condition | `i <= 5` | Before every pass. The loop stops when it is false. |
| Update | `i++` | After every pass. |

The same loop written with `while` looks like this - the `for` just packs it into one line:

```java
int i = 1;
while (i <= 5) {
    System.out.println("Lap " + i);
    i++;
}
```

Common `for` loop shapes:

| Loop | Runs for |
|---|---|
| `for (int i = 0; i < 5; i++)` | 0, 1, 2, 3, 4 (5 times - starting at 0 is common) |
| `for (int i = 1; i <= 5; i++)` | 1, 2, 3, 4, 5 |
| `for (int i = 10; i > 0; i--)` | 10 down to 1 |
| `for (int i = 0; i < 20; i += 5)` | 0, 5, 10, 15 |

**Printing on one line with a loop.** Use `print` inside the loop and one `println()` after it to end the line:

```java
public class StarBar {
    public static void main(String[] args) {
        int votes = 7;
        // Output: one # per vote, all on the same line
        System.out.print("Votes: ");
        for (int i = 0; i < votes; i++) {
            System.out.print("#");
        }
        System.out.println();   // end the line
        System.out.println("Done.");
    }
}
```

Output:

```
Votes: #######
Done.
```

You will use exactly this idea for the guess chart in the challenge.

**Try it:**
1. Print the 7 times table (7, 14, 21, ... 70) with a `for` loop.
2. Print a row of `-` that is as long as a number the user types.

---

## The do-while loop

A `do-while` loop checks its condition **after** each pass, so the body always runs at least once.

```java
int choice;
do {
    System.out.print("Enter 1, 2, or 3: ");
    choice = Integer.parseInt(keyboard.nextLine());
} while (choice < 1 || choice > 3);
```

Note the semicolon after the `while (...)` at the end. `do-while` is fine to use. BPA tests usually say "a while/do while loop", so either one earns the points. In these lessons we mostly use `while` because the pattern is the same in every language.

---

## break, and why BPA wants loops to end by their condition

`break;` immediately jumps out of the loop it is in.

```java
// This works, but BPA Java tests have taken points off for it.
while (true) {
    System.out.print("Password: ");
    String password = keyboard.nextLine();
    if (password.equals("bpa2027")) {
        break;
    }
    System.out.println("Try again.");
}
```

The 2026 Java regional said the program must "exit the loop based on the loop condition instead of by using a break statement," and gave 10 points for "Neither while loop exits using a break statement." So in this class, **end loops with their condition**. Use a variable the condition can check:

```java
// Same behavior, no break: the condition ends the loop.
boolean correct = false;
while (!correct) {
    System.out.print("Password: ");
    String password = keyboard.nextLine();
    if (password.equals("bpa2027")) {
        correct = true;
    } else {
        System.out.println("Try again.");
    }
}
```

A `boolean` that controls a loop like this is sometimes called a **flag**. (`break` inside a `switch` is still required and fine - that rule is only about loops.)

---

## Random numbers

Java makes random numbers with a `Random` object.

```java
import java.util.Random;     // at the top of the file

Random random = new Random();       // make one Random object, once
int roll = random.nextInt(6) + 1;   // a random whole number from 1 to 6
```

| What you type | What it gives you |
|---|---|
| `random.nextInt(6)` | 0, 1, 2, 3, 4, or 5 (six possible numbers, **starting at 0**, **not including 6**) |
| `random.nextInt(6) + 1` | 1 to 6 |
| `random.nextInt(100) + 1` | 1 to 100 |
| `random.nextInt(high - low + 1) + low` | `low` to `high`, including both |
| `random.nextInt(11)` | 0 to 10 (the 2026 regional needed "0 to highest number inclusive") |
| `random.nextDouble()` | A decimal from 0.0 up to (not including) 1.0 |

The number in the parentheses is **how many** different values you want. Add the lowest value you want.

```java
import java.util.Random;

public class DiceRoller {
    public static void main(String[] args) {
        Random random = new Random();
        int doubles = 0;

        // Processing / Output: roll two dice 5 times and count doubles
        for (int turn = 1; turn <= 5; turn++) {
            int die1 = random.nextInt(6) + 1;
            int die2 = random.nextInt(6) + 1;
            System.out.println("Turn " + turn + ": " + die1 + " and " + die2);
            if (die1 == die2) {
                doubles++;
            }
        }
        System.out.println("Doubles rolled: " + doubles);
    }
}
```

One possible output (yours will be different every time):

```
Turn 1: 3 and 5
Turn 2: 6 and 6
Turn 3: 1 and 4
Turn 4: 2 and 2
Turn 5: 5 and 1
Doubles rolled: 2
```

Make the `Random` object **once** (at the start of `main`), then call `nextInt` as many times as you need.

You may also see `Math.random()`, which gives a `double` from 0.0 to 1.0. `(int) (Math.random() * 6) + 1` also rolls a die. BPA Java tests have required "a Random object," so use `Random`.

---

## A play again loop

To let the user play again, wrap the whole game in an outer loop controlled by a `boolean`:

```java
boolean playAgain = true;
int rounds = 0;
while (playAgain) {
    // ... the whole game goes here ...
    rounds++;

    System.out.print("Play again? (y/n): ");
    String answer = keyboard.nextLine();
    playAgain = answer.equals("y") || answer.equals("Y");
}
System.out.println("Rounds played: " + rounds);
```

`answer.equals("y") || answer.equals("Y")` is a `boolean` expression, so you can store its answer straight into `playAgain`. You could also write `answer.equalsIgnoreCase("y")`.

A loop inside another loop is called a **nested loop**. In the challenge, the outer loop is "one game per pass" and the inner loop is "one guess per pass".

---

## Testing a random program

A random number makes testing hard, because you don't know the answer. Two ways to test:

1. **Print the secret temporarily.** Right after you pick it, add a line:
   ```java
   System.out.println("(TEST) secret is " + secret);   // REMOVE BEFORE TURNING IN
   ```
   Now you know the answer and can test "too low", "too high", and "got it".
2. **Set the secret temporarily.** Replace the random line with a fixed number, like `int secret = 42;`, so you can type the exact sample run.

**Remove the test line before you turn it in.** The finished program must pick a random number every game.

---

## Common mistakes

**1. Infinite loop**
- Looks like: the program prints the same thing forever, or keeps asking without stopping.
- Cause: nothing inside the loop changes the condition (for example, you forgot to read a new guess).
- Fix: press Ctrl+C in the Terminal to stop it. Make sure the loop body changes the variable the condition checks.

**2. Off-by-one random range**
- Looks like: `random.nextInt(100)` - the secret can be 0 and can never be 100.
- Fix: `random.nextInt(100) + 1` for 1 to 100.

**3. Making a new Random inside the loop**
- Looks like: `Random random = new Random();` inside the game loop.
- It works, but it is wasteful. Make one `Random` at the start of `main`.

**4. Counting an invalid guess**
- Looks like: `You got it in 4 guesses!` when one of the guesses was 150.
- Fix: only add to the guess counter in the `else` part, after the range check passes.

**5. Variable declared inside the loop, used after it**
- Looks like: `int guessCount = 0;` inside the inner loop, then printing it after the loop.
- Error: `error: cannot find symbol ... symbol: variable guessCount`, or the count resets every pass.
- Fix: declare it before the loop.

**6. `print` vs `println` in the chart**
- Looks like: each `*` on its own line.
- Fix: `System.out.print("*")` inside the loop, then one `System.out.println()` after it.

**7. `"guesses"` when there was only 1**
- Fix: an `if` that prints `guess` when the count is 1.

---

## How this shows up at BPA

- The 2026 Java regional required **two while loops**: one to generate problems until the user got enough right, and one to keep picking a random number while it was 0 (to avoid dividing by zero). That second loop is exactly the "ask again until valid" pattern, but with a random number instead of input.
- The same test said loops must end by their condition, not `break`. That was worth points.
- "Random numbers are within the valid range ... inclusive" was a graded item. Know `nextInt(n) + low` cold.
- Counters ("count the number of correct answers") are always graded.

---

## The challenge: Number Guessing Game

Write a guessing game. The computer picks a secret number, and the player guesses until they find it.

**Requirements**
1. Header comment.
2. The computer picks a secret whole number from 1 to 100.
3. Keep asking `Your guess (1-100): ` until the player guesses it. Print `Too low!` or `Too high!` after each wrong guess.
4. If a guess is below 1 or above 100, print `Please guess between 1 and 100.` — this does **not** count as a guess.
5. When they get it, print `You got it in N guesses!` (use `guess` instead of `guesses` when N is 1).
6. Use a `for` loop to print a guess chart: `Guess chart: ` followed by one `*` per guess.
7. Ask `Play again? (y/n): `. `y` or `Y` starts a new game with a new secret number; anything else ends it.
8. When the player stops, print `Thanks for playing! Games played: N`.
9. Input / Processing / Output comments.

**Sample run** (the secret number was 42 here — yours will be random):
```
I'm thinking of a number from 1 to 100.
Your guess (1-100): 50
Too high!
Your guess (1-100): 150
Please guess between 1 and 100.
Your guess (1-100): 25
Too low!
Your guess (1-100): 42
You got it in 3 guesses!
Guess chart: ***
Play again? (y/n): n
Thanks for playing! Games played: 1
```
The first line `I'm thinking of a number from 1 to 100.` prints at the start of every game.

Typing letters will crash the program. **Step 10 fixes that** (and has you come back to make this game crash-proof).

**Hints**
- Class `Step04` in `Step04.java`. You need both `import java.util.Random;` and `import java.util.Scanner;`.
- Outer loop: `while (playAgain)`. Inside it: pick the secret, set the guess counter to 0, print the "I'm thinking" line, then the inner guessing loop.
- Inner loop: `while (guess != secret)`. Start `guess` at 0 so the loop runs the first time.
- Inside the inner loop: read the guess, then `if` out of range / `else` (count it, then too low / too high).
- To test the sample run exactly, temporarily set `secret` to 42. Then put the random line back.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step04`.
2. Put `Step04.java` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 4 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run (when the secret is 42)
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Secret picked with a `Random` object, 1 to 100, new secret each game
- [ ] Out-of-range guesses don't count
- [ ] `guess` vs `guesses` handled
- [ ] Guess chart printed with a `for` loop
- [ ] Loops end by their condition (no `break` out of a loop)
- [ ] Test line that prints or sets the secret is removed
- [ ] Pushed to `bpaPrep/java_step04`
