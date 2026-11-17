# Step 03 — If Statements (Python)

An **if statement** lets a program make a decision: do one thing if something is true, and something else if it isn't. This lesson teaches decisions one piece at a time. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 3 Practice](step03_Practice.md) problems. For more examples, use the [Step 3 Study Guide](step03_StudyGuide.md). The [Steps 1–3 Common Mistakes](../Steps01-03_CommonMistakes.md) page shows the mistakes students make most on this step.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: True and False](#part-1-true-and-false)
- [Part 2: The if statement](#part-2-the-if-statement)
- [Part 3: if and else](#part-3-if-and-else)
- [Part 4: elif for more than two choices](#part-4-elif-for-more-than-two-choices)
- [Part 5: and, or, not](#part-5-and-or-not)
- [Part 6: Comparing text](#part-6-comparing-text)
- [Part 7: Two separate ifs](#part-7-two-separate-ifs)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- How comparisons give `True` or `False`
- How to run code only when something is true
- How to choose between two or more options
- How to check more than one thing with `and`, `or`, and `not`
- How to compare text so capital letters don't matter
- When to use `elif` and when to use separate `if` statements

---

## Part 1: True and False

A **comparison** checks two values and gives back `True` or `False`.

| Symbol | Means |
|---|---|
| `==` | is equal to (two equal signs) |
| `!=` | is not equal to |
| `<` and `>` | less than, greater than |
| `<=` and `>=` | less than or equal to, greater than or equal to |

```python
age = 16
print(age >= 16)
print(age == 18)
print(age != 18)
```

```text
True
False
True
```

One `=` **stores** a value. Two `==` **compare** values.

---

## Part 2: The if statement

The code under an `if` only runs when the condition is True. The `if` line ends with a colon, and the code under it is **indented** (4 spaces, or press Tab in IDLE).

<!-- input: 95 -->
```python
score = int(input("Score: "))

if score >= 90:
    print("Great job!")         # only runs when the score is 90 or more

print("Done.")                  # not indented: always runs
```

```text
Score: 95
Great job!
Done.
```

With a score of 80, it would only print `Done.`

---

## Part 3: if and else

`else` runs when the `if` condition is False. Exactly one of the two blocks runs.

<!-- input: 64 -->
```python
score = int(input("Score: "))

if score >= 70:
    print("You passed.")
else:
    print("You did not pass.")
```

```text
Score: 64
You did not pass.
```

`else` has no condition, and it lines up with its `if`.

**Try it:** Ask for a number and print whether it's even or odd. (`number % 2 == 0` is True when it's even.)

---

## Part 4: elif for more than two choices

`elif` means "else, if." Python checks each condition from the top down and runs the **first** one that's True. Then it skips the rest.

<!-- input: 84 -->
```python
score = int(input("Score: "))

if score >= 90:
    grade = "A"
elif score >= 80:
    grade = "B"
elif score >= 70:
    grade = "C"
else:
    grade = "F"

print(f"Grade: {grade}")
```

```text
Score: 84
Grade: B
```

84 is not 90 or more, so Python checks the next one. 84 is 80 or more, so the grade is B, and Python skips the rest.

**Order matters.** If `score >= 70` came first, an 84 would get a C.

**Try it:** Add a `D` for scores from 60 to 69.

---

## Part 5: and, or, not

| Word | True when... |
|---|---|
| `and` | **both** sides are True |
| `or` | **at least one** side is True |
| `not` | it flips True to False, and False to True |

<!-- input: 130 -->
```python
age = int(input("Age: "))

if age < 0 or age > 120:
    print("Error: age must be 0 to 120.")
elif age >= 13 and age <= 19:
    print("You are a teenager.")
else:
    print("You are not a teenager.")
```

```text
Age: 130
Error: age must be 0 to 120.
```

The error check comes first. Everything else is in the `elif` and `else`, so it only runs when the age is good.

---

## Part 6: Comparing text

Text comparisons care about capital letters: `"Tuesday" == "tuesday"` is False. Use `.lower()` to make the answer lowercase before you compare.

<!-- input: TUESDAY -->
```python
day = input("Day of the week: ")

if day.lower() == "tuesday":
    print("Half-price day!")
else:
    print("Regular price.")
```

```text
Day of the week: TUESDAY
Half-price day!
```

Now `Tuesday`, `tuesday`, and `TUESDAY` all match.

---

## Part 7: Two separate ifs

Use `if`/`elif`/`else` when only **one** choice can happen. Use **separate** `if` statements when **more than one** can happen.

A movie ticket can get the Tuesday discount **and** a 3D charge, so each one gets its own `if`:

<!-- input: tuesday|y -->
```python
total = 11.00

day = input("Day: ")
three_d = input("3D? (y/n): ")

if day.lower() == "tuesday":
    total = total - 3.00            # start from the current total
if three_d.lower() == "y":
    total = total + 2.50            # this if is checked too

print(f"Total: ${total:.2f}")
```

```text
Day: tuesday
3D? (y/n): y
Total: $10.50
```

With `elif` instead of the second `if`, the 3D check would be skipped on Tuesdays, and the total would be wrong.

---

## Common mistakes

1. **One `=` in a comparison.** `if age = 16:` is an error. Use `==`.
2. **A missing colon** at the end of an `if`, `elif`, or `else` line.
3. **Wrong indents.** The code under an `if` must be indented the same amount.
4. **The wrong edge.** "Under 13" is `< 13`, not `<= 13`. Test the numbers right at the edges.
5. **`elif` when both things can happen.** Use separate `if`s.
6. **Comparing text without `.lower()`.**

---

## Next steps
1. Do the [Step 3 Practice](step03_Practice.md) problems.
2. Keep the [Step 3 Study Guide](step03_StudyGuide.md) open while you work. Print it for BPA.
3. After Step 3, you can start the [Step 1–3 builds](../bpaBuilds/build01_outputAndComments.md).
