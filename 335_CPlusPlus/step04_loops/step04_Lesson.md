# Step 04 — Loops (C++)

**What you'll build:** Number Guessing Game — the computer picks a secret number and the player guesses until they get it.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [The while loop](#the-while-loop)
- [Re-asking until the input is in range](#re-asking-until-the-input-is-in-range)
- [The for loop](#the-for-loop)
- [Counters and running totals](#counters-and-running-totals)
- [break and continue](#break-and-continue)
- [The do-while loop](#the-do-while-loop)
- [Random numbers](#random-numbers)
- [The play again loop](#the-play-again-loop)
- [Testing with a fixed secret number](#testing-with-a-fixed-secret-number)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Number Guessing Game](#the-challenge-number-guessing-game)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to repeat code with a `while` loop
- How to re-ask a question until the answer is in range
- How to count with a `for` loop
- Counters (`count++`) and running totals
- What `break` and `continue` do
- The `do-while` loop (good to recognize)
- How to make random numbers with `<random>` (and the older `rand()`)
- How to build a "play again?" loop around a whole program

---

## The while loop

A `while` loop repeats its block **as long as** the condition is true. It checks the condition **before** each pass. When the condition becomes false, the loop ends and the program moves on.

```cpp
while (condition)
{
    // repeats while condition is true
}
```

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Processing + Output: count down from 5
    int count = 5;
    while (count > 0)
    {
        cout << count << "... ";
        count--;   // count = count - 1
    }
    cout << "Liftoff!" << endl;
    return 0;
}
```

What it prints:
```
5... 4... 3... 2... 1... Liftoff!
```

Something inside the loop must change the condition, or the loop runs forever. Here `count--` moves `count` toward 0. If you forget it, the program prints `5...` forever. (To stop a stuck program, close the console window or press **Ctrl+C** in it.)

---

## Re-asking until the input is in range

A very common use of `while`: keep asking until the user gives an acceptable answer. Ask once **before** the loop, and again **inside** the loop.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: a team size, re-asked until it is 2 to 5
    int teamSize = 0;
    cout << "Team size (2-5): ";
    cin >> teamSize;
    while (teamSize < 2 || teamSize > 5)
    {
        cout << "Please enter 2 to 5." << endl;
        cout << "Team size (2-5): ";
        cin >> teamSize;
    }

    // Output: only reached with a good value
    cout << "Making teams of " << teamSize << "." << endl;
    return 0;
}
```

Sample run:
```
Team size (2-5): 9
Please enter 2 to 5.
Team size (2-5): 1
Please enter 2 to 5.
Team size (2-5): 4
Making teams of 4.
```

The condition is the **bad** range (`< 2 || > 5`), the same range check you wrote in Step 3. This works for numbers. If the user types **letters**, `cin` breaks and this loop never ends. **Step 10 fixes that** with a crash-proof input function.

---

## The for loop

A `for` loop is the usual way to **count**. It puts the three parts of a counting loop on one line.

```cpp
for (int i = 1; i <= 5; i++)
{
    // runs 5 times, with i = 1, 2, 3, 4, 5
}
```

| Part | Example | What it does |
|---|---|---|
| Start | `int i = 1` | Runs once, before the loop. Makes the counter. |
| Condition | `i <= 5` | Checked before every pass. The loop runs while it is true. |
| Update | `i++` | Runs after every pass. Moves the counter. |

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: which times table to print
    int number = 0;
    cout << "Times table for: ";
    cin >> number;

    // Processing + Output: one line for 1 through 5
    for (int i = 1; i <= 5; i++)
    {
        cout << number << " x " << i << " = " << number * i << endl;
    }

    // Output: a bar of dashes, one per loop pass
    for (int i = 0; i < 10; i++)
    {
        cout << "-";
    }
    cout << endl;
    return 0;
}
```

Sample run:
```
Times table for: 7
7 x 1 = 7
7 x 2 = 14
7 x 3 = 21
7 x 4 = 28
7 x 5 = 35
----------
```

Two counting styles you will see:
- `for (int i = 1; i <= 5; i++)` counts 1 to 5. Good for numbering things a person reads.
- `for (int i = 0; i < 10; i++)` counts 0 to 9 (10 passes). Programmers use this a lot, and it matches how lists are numbered (Step 6).

The second loop is the pattern for the challenge's **guess chart**: print one `*` per pass, then `endl` after the loop.

Python comparison: `for i in range(1, 6):` is the same as `for (int i = 1; i <= 5; i++)`.

**When to use which loop:** use `for` when you know how many times to repeat. Use `while` when you repeat **until something happens** (a right guess, a good answer).

---

## Counters and running totals

A **counter** counts how many times something happened. A **running total** adds up values as you go. Both start at 0 **before** the loop.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Processing: counter and running total start at 0
    int total = 0;
    int evenCount = 0;

    // Processing: add up 1 through 10 and count the even numbers
    for (int i = 1; i <= 10; i++)
    {
        total = total + i;
        if (i % 2 == 0)   // remainder 0 when divided by 2 means even
        {
            evenCount++;
        }
    }

    // Output
    cout << "Total: " << total << endl;
    cout << "Even numbers: " << evenCount << endl;
    return 0;
}
```

What it prints:
```
Total: 55
Even numbers: 5
```

The challenge counts guesses with a counter like `evenCount` and counts games played with another one.

---

## break and continue

| What you type | What it means |
|---|---|
| `break;` | Leave the loop **right now**. The program continues after the loop. |
| `continue;` | Skip the **rest of this pass** and go back to the top of the loop. |

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Processing + Output: print 1 to 10, skip 4, stop at 8
    for (int i = 1; i <= 10; i++)
    {
        if (i == 4)
        {
            continue;   // skip printing 4
        }
        if (i == 8)
        {
            break;      // leave the loop completely
        }
        cout << i << " ";
    }
    cout << endl;
    return 0;
}
```

What it prints:
```
1 2 3 5 6 7 
```

`continue` is handy in the challenge: when the guess is out of range, print the message and `continue` so that guess is not counted. Use `break` and `continue` sparingly. A loop that is easy to read is better than a clever one.

---

## The do-while loop

A `do-while` loop runs the block **first** and checks the condition **after**. It always runs at least once. Note the **semicolon** after the `while (...)` at the end.

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Input: keep asking until the PIN is 4 digits (1000 to 9999)
    int pin = 0;
    do
    {
        cout << "4-digit PIN: ";
        cin >> pin;
    } while (pin < 1000 || pin > 9999);

    // Output
    cout << "PIN saved." << endl;
    return 0;
}
```

Sample run:
```
4-digit PIN: 12
4-digit PIN: 4821
PIN saved.
```

You do not need `do-while` for the challenge, but you will see it in other people's code and in the reference guide.

---

## Random numbers

C++ has two ways to make random numbers. Use the modern way. Recognize the old way.

### The modern way: `<random>`

```cpp
#include <iostream>
#include <random>   // random_device, mt19937, uniform_int_distribution
using namespace std;

int main()
{
    // Processing: set up the random number generator ONE time
    random_device seed;                        // gets a truly random starting value
    mt19937 generator(seed());                 // the generator, started from that seed
    uniform_int_distribution<int> die(1, 6);   // the range we want: 1 to 6, both included

    // Processing + Output: roll the die 5 times
    for (int i = 1; i <= 5; i++)
    {
        int roll = die(generator);   // a new random number each time
        cout << "Roll " << i << ": " << roll << endl;
    }
    return 0;
}
```

One possible run (yours will differ):
```
Roll 1: 4
Roll 2: 1
Roll 3: 6
Roll 4: 4
Roll 5: 2
```

What each line means, in plain words:

| What you type | What it means |
|---|---|
| `random_device seed;` | A source of randomness from the computer. We use it once, to pick a starting point. |
| `mt19937 generator(seed());` | The random number **generator** (its name, "Mersenne Twister," is just the method it uses). It makes a long stream of random-looking numbers. |
| `uniform_int_distribution<int> die(1, 6);` | Says what range you want. "Uniform" means every number is equally likely. Both ends are included. |
| `die(generator)` | Get the next random number from 1 to 6. |

You do not need to understand how the generator works inside. Copy the three setup lines, change the range, and call `range(generator)` whenever you need a number. **Set it up once, at the top of `main`, not inside the loop.**

For the challenge: `uniform_int_distribution<int> oneToHundred(1, 100);` then `int secret = oneToHundred(generator);`.

### The older way: `rand()`

You will see this in older code and in the reference guide:

```cpp
#include <cstdlib>   // rand, srand
#include <ctime>     // time

srand(time(0));                    // seed once, using the clock
int secret = rand() % 100 + 1;     // 0-99, then + 1 gives 1-100
```

It works, and it is allowed at BPA. The modern way is preferred because `rand()` is lower quality and the `% 100 + 1` math is easy to get wrong. Either is fine for a guessing game.

---

## The play again loop

To let the user play again, put the **whole game** inside an outer `while` loop. Ask "play again?" at the end of each pass.

```cpp
#include <iostream>
#include <string>
#include <random>
using namespace std;

int main()
{
    // Processing: random setup, once
    random_device seed;
    mt19937 generator(seed());
    uniform_int_distribution<int> coin(0, 1);

    int flips = 0;
    string again = "y";

    // Processing: one pass of this loop = one coin flip
    while (again == "y")
    {
        flips++;

        // Output: heads or tails
        if (coin(generator) == 0)
        {
            cout << "Heads" << endl;
        }
        else
        {
            cout << "Tails" << endl;
        }

        // Input: go again?
        cout << "Flip again? (y/n): ";
        cin >> again;
    }

    // Output: summary after the loop ends
    cout << "You flipped " << flips << " times." << endl;
    return 0;
}
```

One possible run:
```
Heads
Flip again? (y/n): y
Tails
Flip again? (y/n): n
You flipped 2 times.
```

Notes:
- `again` starts as `"y"` so the loop runs the first time.
- `again` is a `string`, read with `cin >>`. A `string` is safer than a `char` here: if the user types `yes`, a `char` would only take the `y` and leave `es` in the input to confuse the next `cin`.
- The challenge must accept `y` **or** `Y`: `while (again == "y" || again == "Y")`.
- Anything that is set up **per game** (secret number, guess counter) goes **inside** the outer loop so it resets. Anything for the **whole session** (games played, the random generator) goes **before** it.

**Try it:** Change the coin flip example to count how many heads came up, and print it at the end.

---

## Testing with a fixed secret number

Random programs are hard to test, because you cannot know the answer. Two tricks:

1. **Print the secret while testing.** Right after you pick it, add:
   ```cpp
   cout << "(testing: secret is " << secret << ")" << endl;   // REMOVE before turning in
   ```
2. **Fix the secret while testing.** Temporarily replace the random line with:
   ```cpp
   int secret = 42;   // TESTING ONLY - put the random line back
   ```
   Now you can type the sample run exactly (50, 150, 25, 42) and compare.

**Remove the testing line before you turn it in.** The finished program must pick a random number.

---

## Common mistakes

**1. Infinite loop**
- Looks like: the same line prints forever, or the program freezes.
- Cause: nothing inside the loop changes the condition (forgot `count--`), or `cin` broke because letters were typed.
- Fix: close the console (or Ctrl+C). Make sure the loop changes its own condition.

**2. Off by one**
- Looks like: `for (int i = 0; i <= 5; i++)` prints 6 stars instead of 5.
- Fix: `i = 0` with `i < 5`, or `i = 1` with `i <= 5`. Both run 5 times.

**3. Semicolon after the loop header**
- Looks like: `while (guess != secret);` or `for (int i = 0; i < 5; i++);`
- Result: the `;` becomes the loop body. A `while` hangs forever; a `for` runs the block only once.
- Fix: no `;` after `while (...)` or `for (...)`. (The only loop with a `;` after `while` is `do-while`.)

**4. Resetting in the wrong place**
- Looks like: the second game says `You got it in 7 guesses!` when it took 2.
- Cause: the guess counter was made before the outer loop, so it never reset.
- Fix: create per-game variables inside the outer loop.

**5. Same "random" number every time**
- Cause: the generator was set up inside the loop, or with a fixed seed like `mt19937 generator(5);`.
- Fix: set up with `random_device` once, before the loops.

**6. Using a variable outside its braces**
- Looks like: using `i` after the `for` loop ends.
- Error: `C2065 'i': undeclared identifier`.
- Cause: a variable made inside `for (...)` or inside `{ }` only exists inside them. This is called **scope**. Step 5 covers it.

---

## How this shows up at BPA

- Every BPA menu program is a loop: show the menu, do the choice, repeat until Exit. The 2026 regional menu repeated until the user chose to exit.
- Re-asking for input until it is in range is required on every validated input ("prompt the user to try again without crashing").
- The 2026 regional generated random passwords from a list of allowed characters. That is a random number used as a position, inside a `for` loop that runs once per character. You will have everything needed for that after Step 7.
- Graders look for the right loop for the job: `for` for counting, `while` for repeat-until.

---

## The challenge: Number Guessing Game

Write a guessing game with a guess chart and a "play again" option.

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

**Sample run** (the secret number was 42 here — yours will be random)
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

Typing letters instead of a number will make this program loop forever or misbehave. **Step 10 fixes that.**

**Hints**
- Two loops: an outer `while` for "play again" and an inner `while` for the guesses.
- `#include <random>` and set up the generator once at the top of `main`.
- Inside the guess loop, check the range first. If it is out of range, print the message and `continue`.
- Use the [testing trick](#testing-with-a-fixed-secret-number) to check your output against the sample run, then remove it.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step04`.
2. Put `step04.cpp` in it. (Visual Studio: push the whole project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 4 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run (test with a fixed secret, then put the random line back)
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Out-of-range guesses do not count
- [ ] `1 guess` vs `N guesses`
- [ ] Guess chart printed with a `for` loop
- [ ] `y` or `Y` plays again with a new secret number
- [ ] No testing line left in the code
- [ ] Pushed to `bpaPrep/cpp_step04`
