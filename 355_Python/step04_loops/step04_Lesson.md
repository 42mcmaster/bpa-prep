# Step 04 — Loops (Python)

This lesson teaches the two kinds of loops one piece at a time. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 4 Practice](step04_Practice.md) problems. For more examples, use the [Step 4 Study Guide](step04_StudyGuide.md).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: What a loop is](#part-1-what-a-loop-is)
- [Part 2: The while loop](#part-2-the-while-loop)
- [Part 3: Running totals and counters](#part-3-running-totals-and-counters)
- [Part 4: Keep asking until the user says stop](#part-4-keep-asking-until-the-user-says-stop)
- [Part 5: Ask again until the answer is good](#part-5-ask-again-until-the-answer-is-good)
- [Part 6: The for loop and range](#part-6-the-for-loop-and-range)
- [Part 7: Repeat something a set number of times](#part-7-repeat-something-a-set-number-of-times)
- [Part 8: Building a string with a loop](#part-8-building-a-string-with-a-loop)
- [Which loop should I use?](#which-loop-should-i-use)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- How a `while` loop repeats while something is true
- How to add up numbers and count things in a loop
- How to keep asking the user until they say stop, or until they give a good answer
- How a `for` loop counts with `range()`
- How to build a string one piece at a time

---

## Part 1: What a loop is

A **loop** repeats code. Without a loop, printing 1 to 5 takes 5 lines:

```python
print(1)
print(2)
print(3)
print(4)
print(5)
```

With a loop, it takes 2 lines, and it would still take 2 lines for 1 to 1,000:

```python
for number in range(1, 6):
    print(number)
```

```text
1
2
3
4
5
```

Every loop has a line that ends with a colon `:`, and an **indented block** under it. The indented lines are the ones that repeat.

---

## Part 2: The while loop

A `while` loop keeps going **while** its condition is True. It checks the condition, runs the block, then goes back up and checks again.

```python
count = 1                 # 1. start the variable before the loop

while count <= 5:         # 2. check it: keep going while count is 5 or less
    print(count)
    count = count + 1     # 3. change it inside the loop

print("Done")             # not indented: runs once, after the loop
```

```text
1
2
3
4
5
Done
```

Walk through it: `count` is 1, so `1 <= 5` is True. Print 1, then count becomes 2. Check again... When count becomes 6, `6 <= 5` is False, so the loop stops and `Done` prints.

**Forget the "change" line and the loop never stops.** It just prints `1` forever. Press **Ctrl+C** to stop it.

**Try it:** Change the example to count from 1 to 10. Then make it count from 10 down to 1. (Start at 10, check `count >= 1`, and subtract 1.)

---

## Part 3: Running totals and counters

A **running total** adds numbers up as the loop goes. It starts at 0 **before** the loop.

```python
total = 0                 # start at 0, before the loop
number = 1

while number <= 4:
    total = total + number    # add this number to the total
    number = number + 1

print(f"The total is {total}")
```

```text
The total is 10
```

That's 1 + 2 + 3 + 4. A **counter** is the same idea, but it adds 1 each time something happens: `count = count + 1`.

**Try it:** Change the example to add up 1 through 100. You should get 5050.

---

## Part 4: Keep asking until the user says stop

A `while` loop can keep asking until the user types a special "stop" value, like `0`. That value is called a **sentinel**.

The pattern: ask **once before** the loop, then ask **again at the bottom** of the loop.

<!-- input: 5|12|3|0 -->
```python
total = 0

number = int(input("Enter a number (0 to stop): "))     # ask before the loop

while number != 0:                                     # != means "is not equal to"
    total = total + number
    number = int(input("Enter a number (0 to stop): ")) # ask again, at the bottom

print(f"The total is {total}")
```

```text
Enter a number (0 to stop): 5
Enter a number (0 to stop): 12
Enter a number (0 to stop): 3
Enter a number (0 to stop): 0
The total is 20
```

- The question **before** the loop gives the `while` line something to check.
- The question **inside** the loop gets the next number. Without it, the number never changes and the loop never ends.

**Try it:** Add a counter so the program also prints `You entered 3 numbers.`

---

## Part 5: Ask again until the answer is good

This is the same pattern, but the loop keeps going while the answer is **bad**. It's on every BPA Python test.

<!-- input: 15|0|8 -->
```python
rating = int(input("Rate the movie (1-10): "))

while rating < 1 or rating > 10:                # True when the rating is bad
    print("Please enter 1 to 10.")
    rating = int(input("Rate the movie (1-10): "))

print(f"Your rating: {rating}")                 # only gets here with a good answer
```

```text
Rate the movie (1-10): 15
Please enter 1 to 10.
Rate the movie (1-10): 0
Please enter 1 to 10.
Rate the movie (1-10): 8
Your rating: 8
```

Use `or`. A number can't be below 1 **and** above 10 at the same time.

**Try it:** Change it to ask for an age from 0 to 120.

---

## Part 6: The for loop and range

A `for` loop goes through a set of numbers. `range()` makes the numbers. **The `for` loop moves to the next number on its own.** You don't add 1 yourself.

```python
for number in range(1, 6):
    print(number)
```

```text
1
2
3
4
5
```

`range(1, 6)` starts at 1 and stops **before** 6. To count from 1 to 10, use `range(1, 11)`.

| What you type | Numbers you get |
|---|---|
| `range(5)` | 0, 1, 2, 3, 4 |
| `range(1, 6)` | 1, 2, 3, 4, 5 |
| `range(2, 11, 2)` | 2, 4, 6, 8, 10 (the third number is the step) |
| `range(5, 0, -1)` | 5, 4, 3, 2, 1 (a negative step counts down) |

You can use the loop variable inside the loop:

```python
for i in range(1, 4):
    print(f"{i} x 7 = {i * 7}")
```

```text
1 x 7 = 7
2 x 7 = 14
3 x 7 = 21
```

**Try it:** Print the even numbers from 2 to 20. Then add up 1 to 100 with a `for` loop instead of a `while` loop.

---

## Part 7: Repeat something a set number of times

`range(5)` runs the loop 5 times. This is how you ask for a set number of answers. **The `input()` goes inside the loop**, so it asks once each time.

<!-- input: 90|85|100 -->
```python
total = 0

for count in range(3):                      # ask 3 times
    score = int(input("Test score: "))      # inside the loop
    total = total + score

average = total / 3                         # after the loop, once all scores are in
print(f"Average: {average:.1f}")
```

```text
Test score: 90
Test score: 85
Test score: 100
Average: 91.7
```

Work out the average **after** the loop. Inside the loop, not all the scores are in yet.

**Try it:** Change it to ask for 5 scores.

---

## Part 8: Building a string with a loop

Start with an empty string `""` and add to it each time through the loop.

<!-- input: 6 -->
```python
points = int(input("Points: "))

bar = ""                        # an empty string
for count in range(points):
    bar = bar + "*"             # add one star each time

print(f"Chart: {bar}")
```

```text
Points: 6
Chart: ******
```

**Try it:** Ask for a name too, and print `Maya: ******`.

---

## Which loop should I use?

| Use | When | Examples |
|---|---|---|
| `for` | you know how many times | "Print 1 to 10." "Ask for 5 scores." |
| `while` | it depends on what the user types | "Keep asking until they type 0." "Ask again until it's 1 to 10." |

---

## Common mistakes

1. **The loop never ends.** In a `while` loop, something inside has to change the variable in the condition.
2. **Adding 1 to a `for` loop variable yourself.** The `for` loop already does it. Delete that line.
3. **Off by one.** `range(1, 10)` stops at 9. Use `range(1, 11)` for 1 to 10.
4. **The `input()` is outside the loop**, so the same answer gets used every time.
5. **The total starts inside the loop**, so it goes back to 0 every time. Put `total = 0` before the loop.
6. **The final `print` is indented**, so it prints every time through the loop instead of once at the end.

---

## Next steps
1. Do the [Step 4 Practice](step04_Practice.md) problems.
2. Keep the [Step 4 Study Guide](step04_StudyGuide.md) open while you work. Print it for BPA.
