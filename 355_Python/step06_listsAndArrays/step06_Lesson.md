# Step 06 — Lists (Python)

**What you'll build:** Score Stats — a program that reads a list of scores and prints the highest, lowest, average, how many are above average, and the scores sorted.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [What a list is](#what-a-list-is)
- [Indexes start at 0](#indexes-start-at-0)
- [Length and adding items](#length-and-adding-items)
- [Fixed-size arrays and growable lists](#fixed-size-arrays-and-growable-lists)
- [Looping through a list](#looping-through-a-list)
- [Filling a list from input](#filling-a-list-from-input)
- [Finding the highest and lowest yourself](#finding-the-highest-and-lowest-yourself)
- [Totals averages and counting](#totals-averages-and-counting)
- [Sorting](#sorting)
- [Copies and the same list under two names](#copies-and-the-same-list-under-two-names)
- [Passing a list to a function](#passing-a-list-to-a-function)
- [Printing a list neatly](#printing-a-list-neatly)
- [Other useful list tools](#other-useful-list-tools)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Score Stats](#the-challenge-score-stats)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How to store many values in one variable with a **list**
- How indexes work (the first item is number 0)
- How to get the length and add items with `append`
- How Python lists compare to the arrays in C++, Java, and C#
- Two ways to loop through a list
- How to find the highest, lowest, and average **by writing the loop yourself**
- How to count items that match a condition
- How to sort high to low without changing the original list
- How to pass a list to a function

## What a list is

So far each variable has held one value. A **list** holds many values, in order, under one name.

```python
# Processing: a list of strings and a list of numbers
rooms = ["Lab A", "Lab B", "Library"]
scores = [88, 92, 75]

print(rooms)
print(scores)
```

It prints:

```text
['Lab A', 'Lab B', 'Library']
[88, 92, 75]
```

| What you type | What it means |
|---|---|
| `[88, 92, 75]` | A list with three items. Square brackets, commas between items. |
| `[]` | An empty list. |
| `scores[0]` | The first item in the list. |
| `len(scores)` | How many items are in the list. |
| `scores.append(60)` | Add `60` to the end of the list. |

Each value in a list is called an **item** or **element**.

## Indexes start at 0

Every item has a position number called its **index**. The first item is index **0**, not 1.

```python
scores = [88, 92, 75, 60]
#  index:  0   1   2   3

print(scores[0])    # first item
print(scores[3])    # fourth (last) item
print(scores[-1])   # -1 is a shortcut for the last item

# Processing: change an item by assigning to its index
scores[2] = 80
print(scores)
```

It prints:

```text
88
60
60
[88, 92, 80, 60]
```

A list with 4 items has indexes 0, 1, 2, 3. There is **no** index 4. Asking for it crashes with `IndexError: list index out of range`.

Why start at 0? The index is "how many steps from the start." The first item is 0 steps from the start. Every language in BPA (Python, C++, Java, C#) does it this way.

## Length and adding items

`len()` gives the number of items. `append()` adds one item to the end.

```python
# Processing: start empty and add three names
names = []
names.append("Avery")
names.append("Blake")
names.append("Casey")

# Output
print(names)
print(len(names))
print(names[len(names) - 1])   # last index is always len - 1
```

It prints:

```text
['Avery', 'Blake', 'Casey']
3
Casey
```

## Fixed-size arrays and growable lists

If you move to another language you'll meet two kinds of list:

| Kind | In C++ / Java / C# | Can it grow? | Use it when... |
|---|---|---|---|
| **Array** | `int scores[5]` / `int[] scores = new int[5]` / `int[] scores = new int[5]` | No — the size is set when it's made | you know exactly how many items there will be |
| **Growable list** | `vector<int>` / `ArrayList<Integer>` / `List<int>` | Yes — `push_back` / `add` / `Add` | you don't know how many items yet |

A Python **list** is always the growable kind. You can still make a list of a set size filled with a starting value, which works like an array:

```python
# Make a list of 5 zeros, then fill in one slot
round_scores = [0] * 5
round_scores[2] = 47
print(round_scores)
```

It prints:

```text
[0, 0, 47, 0, 0]
```

In the challenge you'll start with an empty list and `append` to it.

## Looping through a list

There are two common ways. Both are useful.

**1. The for-each loop** — gets each item, one at a time. Use it when you only need the values.

```python
prices = [3.50, 7.25, 5.00]
# Output: each price as money
for price in prices:
    print(f"${price:.2f}")
```

It prints:

```text
$3.50
$7.25
$5.00
```

**2. The index loop** — counts through the indexes with `range(len(...))`. Use it when you need the position number too, or when you need to look at two lists at the same position.

```python
items = ["Taco", "Burrito", "Nachos"]
prices = [3.50, 7.25, 5.00]
# Output: numbered menu, using the index for both lists
for i in range(len(items)):
    print(f"{i + 1}. {items[i]} - ${prices[i]:.2f}")
```

It prints:

```text
1. Taco - $3.50
2. Burrito - $7.25
3. Nachos - $5.00
```

`range(len(items))` is `range(3)`, which gives 0, 1, 2 — exactly the indexes. The `i + 1` is only for the display, so the menu starts at 1 for the user.

## Filling a list from input

This is the same `for` loop with `range` from Step 4, with `append` added:

<!-- input: 3|4.5|5|3.5 -->
```python
# Input: how many, then each value goes into the list
how_many = int(input("How many days? "))
miles = []
for day in range(1, how_many + 1):
    distance = float(input(f"Day {day} miles: "))
    miles.append(distance)

# Output
print(miles)
```

It prints (user typed `3`, `4.5`, `5`, `3.5`):

```text
How many days? 3
Day 1 miles: 4.5
Day 2 miles: 5
Day 3 miles: 3.5
[4.5, 5.0, 3.5]
```

The user typed `5`, but the list shows `5.0`. That's because `float()` turned it into a decimal before it was stored.

The prompt uses an f-string so it can show the day number: `f"Day {day} miles: "`.

## Finding the highest and lowest yourself

Python has built-in `max()`, `min()`, and `sum()`. **The challenge does not let you use them** — BPA graders give points for the **algorithm**, and C++, Java, and C# don't all have them. Here's how to do it with a loop:

**Find the highest:**
1. Pretend the first item is the highest so far.
2. Look at every item. If one is bigger than the highest so far, it becomes the new highest so far.
3. When the loop ends, the highest so far is the highest.

```python
temperatures = [61, 75, 68, 79, 72]

# Processing: highest so far starts as the first item
warmest = temperatures[0]
for temp in temperatures:
    if temp > warmest:
        warmest = temp

# Output
print(f"Warmest: {warmest}")
```

It prints:

```text
Warmest: 79
```

Trace it: start `warmest = 61` → 61 not bigger → 75 bigger, `warmest = 75` → 68 no → 79 bigger, `warmest = 79` → 72 no → done: 79.

**Why start with the first item instead of 0?** If every number were negative, a start of 0 would be "bigger" than all of them and give a wrong answer. Starting with a real item from the list always works.

**Find the lowest:** same idea, with `<` instead of `>`.

**Finding where the highest is:** sometimes you need the **position** (to look up a name in another list). Keep the index instead of the value:

```python
names = ["Avery", "Blake", "Casey"]
points = [40, 95, 70]

# Processing: remember the INDEX of the best so far
best_index = 0
for i in range(len(points)):
    if points[i] > points[best_index]:
        best_index = i

# Output
print(f"Top: {names[best_index]} with {points[best_index]}")
```

It prints:

```text
Top: Blake with 95
```

This is how you'll find the winner in Step 8.

## Totals averages and counting

**Total:** the running total from Step 4, with a for-each loop. **Average:** total divided by `len()`.

```python
times = [12, 15, 9, 14]

# Processing: add up every item
total = 0
for time in times:
    total = total + time
average = total / len(times)

# Processing: count how many are above the average
above = 0
for time in times:
    if time > average:
        above = above + 1

# Output
print(f"Total: {total}")
print(f"Average: {average:.2f}")
print(f"Above average: {above}")
```

It prints:

```text
Total: 50
Average: 12.50
Above average: 2
```

Counting is a counter (Step 4) plus an `if` (Step 3) inside a loop. You can count anything this way: passing scores, items over $5, names that start with "A".

**Try it**
1. Make a list of 6 numbers. With your own loops, print the lowest and the total.
2. Count how many numbers in your list are even (`number % 2 == 0`).

## Sorting

Sorting is fine to do with Python's built-in tools in this step. (In Step 8 you'll write a sort yourself.)

| What you type | What it does |
|---|---|
| `my_list.sort()` | Sorts the list **in place** — the list itself is changed. Low to high. Returns `None`. |
| `my_list.sort(reverse=True)` | Sorts in place, high to low. |
| `sorted(my_list)` | Gives back a **new** sorted list. The original is not changed. |
| `sorted(my_list, reverse=True)` | New list, high to low. |
| `my_list.reverse()` | Flips the order in place (no sorting). |

```python
ages = [17, 15, 18, 16]

# Processing: sorted() makes a new list; ages is unchanged
oldest_first = sorted(ages, reverse=True)
print(oldest_first)
print(ages)

# Processing: sort() changes ages itself
ages.sort()
print(ages)
```

It prints:

```text
[18, 17, 16, 15]
[17, 15, 18, 16]
[15, 16, 17, 18]
```

## Copies and the same list under two names

This surprises everyone once. `=` does **not** copy a list. It gives the **same** list a second name.

```python
original = [3, 1, 2]
same_list = original          # NOT a copy - two names for one list
same_list.sort()
print(original)               # it changed too!

original = [3, 1, 2]
real_copy = original.copy()   # a separate list with the same items
real_copy.sort()
print(original)               # unchanged
print(real_copy)
```

It prints:

```text
[1, 2, 3]
[3, 1, 2]
[1, 2, 3]
```

In the challenge, the `Scores:` line must show the scores **in the order entered**, and the last line shows them sorted. Either print the `Scores:` line before you sort, or sort a **copy** (`.copy()` or `sorted()`).

## Passing a list to a function

You pass a list to a function the same way as any other value. The parameter is just another name for the same list.

```python
def calculate_total(numbers):
    """Purpose: add up a list of numbers with a loop.
    Parameters: numbers (list of int or float)
    Returns: the total (int or float)
    """
    total = 0
    for number in numbers:
        total = total + number
    return total

def add_bonus(numbers, bonus):
    """Purpose: add a bonus to every item in the list (changes the list).
    Parameters: numbers (list of int), bonus (int)
    Returns: nothing
    """
    for i in range(len(numbers)):
        numbers[i] = numbers[i] + bonus

quiz_scores = [7, 9, 8]
print(calculate_total(quiz_scores))
add_bonus(quiz_scores, 1)
print(quiz_scores)               # changed by the function
```

It prints:

```text
24
[8, 10, 9]
```

Because the function gets the **same** list (not a copy), changes the function makes to the items are seen by the caller. That can be useful (`add_bonus`) or a surprise. A function that only **reads** the list, like `calculate_total`, changes nothing.

## Printing a list neatly

`print(scores)` shows brackets and commas: `[88, 92, 75]`. The challenge wants `88 92 75`. Two ways:

```python
scores = [88, 92, 75]

# Way 1: print each item with end=" " so they stay on one line
print("Scores:", end=" ")
for score in scores:
    print(score, end=" ")
print()

# Way 2: turn each number into text, then join them with spaces
text_scores = []
for score in scores:
    text_scores.append(str(score))
print("Scores: " + " ".join(text_scores))
```

It prints:

```text
Scores: 88 92 75 
Scores: 88 92 75
```

Look closely: Way 1 leaves an extra space at the end of the line. You can't see it, but an "exact output" check can. Way 2 doesn't. `" ".join(list_of_strings)` puts the text `" "` **between** the items. It only works on strings, which is why each number is turned into a string with `str()` first.

## Other useful list tools

You don't need these for the challenge, but you'll use them later:

| What you type | What it does |
|---|---|
| `"Blake" in names` | `True` if the item is in the list |
| `names.index("Blake")` | the index of the first `"Blake"` (crashes if it isn't there — check with `in` first) |
| `names.insert(0, "Zoe")` | put an item at index 0 and push the rest down |
| `names.remove("Blake")` | remove the first `"Blake"` |
| `names.pop()` | remove and return the last item |
| `scores.count(92)` | how many times 92 appears |
| `max(scores)`, `min(scores)`, `sum(scores)` | built-ins — **not allowed in the challenge** |

## Common mistakes

**1. Index out of range**
```python
scores = [88, 92, 75]
print(scores[3])          # MISTAKE - last index is 2
```
Error: `IndexError: list index out of range`
Fix: the last index is `len(scores) - 1`. In loops, use `range(len(scores))`, which stops in the right place.

**2. Starting the highest at 0**
`highest = 0` works for test scores but is wrong in general (all-negative numbers). Start with `scores[0]`.

**3. Sorting the original before printing it**
If you `scores.sort(reverse=True)` first, the `Scores:` line comes out sorted. Fix: sort a copy, or print the original line before sorting.

**4. `x = my_list.sort()`**
`sort()` changes the list and returns `None`. So `x` is `None`. Fix: `my_list.sort()` on its own line, or `x = sorted(my_list)`.

**5. Joining numbers**
```python
print(" ".join(scores))   # MISTAKE - scores holds ints
```
Error: `TypeError: sequence item 0: expected str instance, int found`
Fix: build a list of `str(score)` first (see [Printing a list neatly](#printing-a-list-neatly)).

**6. Average done with integer math in other languages**
In Python, `total / len(scores)` is a decimal. If you switch to C++/Java/C#, cast one side to a decimal type first or you'll get `81` instead of `81.40`.

## How this shows up at BPA
- The 2026 regional: "Prompt the user to enter each player's name and **store them in a list**." The 2024 regional: "construct pizza objects ... stored in a simple **data structure**." Lists are how you meet both.
- Data structures are a named category in source code review. A list filled in a loop is what graders look for.
- Highest, lowest, average, and "how many above" are standard analysis requirements. Writing the loop yourself shows the grader the algorithm, and works the same in every language.
- Averages are almost always "rounded to 2 decimal places" — `:.2f`.

## The challenge: Score Stats

Read a list of scores and print some statistics about them.

**Requirements**
1. Header comment.
2. Ask `How many scores? ` (assume a whole number from 1 to 20; if it is outside that range print `Please enter 1 to 20.` and ask again).
3. Ask for each score with `Score 1: `, `Score 2: `, … and store them in a list.
4. Write these functions, each taking the list as a parameter: `find_highest`, `find_lowest`, `calculate_average`. **Use your own loop** in each — no built-in `max`/`min`/`sum`.
5. Print the results exactly as shown: all scores in the order entered, highest, lowest, average (2 decimals), how many scores are above the average, and the scores sorted high to low.
6. Function comments and Input / Processing / Output comments.

**Sample run (exact)**
```
How many scores? 5
Score 1: 88
Score 2: 92
Score 3: 75
Score 4: 92
Score 5: 60

Scores: 88 92 75 92 60
Highest: 92
Lowest: 60
Average: 81.40
Above average: 3
Sorted high to low: 92 92 88 75 60
```
Sorting must not change the `Scores:` line — print that line before sorting, or sort a copy.

**Hints**
- Use the `main()` pattern from Step 5. Put the three required functions above `main`.
- The range check on "How many" is the `while` loop from Step 4.
- Extra functions are fine and make `main` shorter — for example `count_above(scores, value)` or `join_scores(scores)` that returns `"88 92 75"`.
- Check: (88 + 92 + 75 + 92 + 60) / 5 = 81.4. Above 81.4: 88, 92, 92 → 3.

## Turn it in
1. In your `bpaPrep` repo make a folder `python_step06`.
2. Put `step06.py` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Python step 6 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Scores are stored in a list
- [ ] `find_highest`, `find_lowest`, `calculate_average` each take the list and use their own loop (no `max`, `min`, `sum`)
- [ ] Every function has a Purpose / Parameters / Returns comment
- [ ] `Scores:` line is in the order entered; sorted line is high to low
- [ ] Pushed to `bpaPrep/python_step06`
