# Step 06 — Lists (Python)

A **list** holds many values in one variable, in order. This lesson teaches lists one piece at a time. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 6 Practice](step06_Practice.md) problems. For more examples, use the [Step 6 Study Guide](step06_StudyGuide.md).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: Making a list](#part-1-making-a-list)
- [Part 2: Indexes start at 0](#part-2-indexes-start-at-0)
- [Part 3: Length and adding items](#part-3-length-and-adding-items)
- [Part 4: Looping through a list](#part-4-looping-through-a-list)
- [Part 5: Filling a list from input](#part-5-filling-a-list-from-input)
- [Part 6: Totals, averages, and counting](#part-6-totals-averages-and-counting)
- [Part 7: Finding the highest and lowest](#part-7-finding-the-highest-and-lowest)
- [Part 8: Sorting](#part-8-sorting)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- How to make a list and get items out of it by their position
- How to add items and count how many there are
- How to loop through a list
- How to fill a list from what the user types
- How to find the total, average, highest, and lowest yourself
- How to sort a list

---

## Part 1: Making a list

A list goes in square brackets, with commas between the items.

```python
snacks = ["chips", "pretzels", "popcorn"]
scores = [88, 92, 75, 100]

print(snacks)
print(scores)
```

```text
['chips', 'pretzels', 'popcorn']
[88, 92, 75, 100]
```

Without a list, four scores need four variables (`score1`, `score2`...). With a list, one variable holds them all, and a loop can go through them.

---

## Part 2: Indexes start at 0

Each item has a position number called an **index**. **The first item is index 0**, not 1.

```python
snacks = ["chips", "pretzels", "popcorn"]
#  index:     0          1          2

print(snacks[0])        # the first item
print(snacks[2])        # the third item
print(snacks[-1])       # -1 means the last item

snacks[1] = "nachos"    # change the item at index 1
print(snacks)
```

```text
chips
popcorn
popcorn
['chips', 'nachos', 'popcorn']
```

Asking for an index that isn't there, like `snacks[3]`, crashes with `IndexError: list index out of range`.

**Try it:** Make a list of 4 colors. Print the second one. Then change the first one to `"black"` and print the list.

---

## Part 3: Length and adding items

- `len(my_list)` gives how many items are in the list.
- `my_list.append(item)` adds an item to the **end**.

```python
names = []                  # an empty list
names.append("Avery")
names.append("Blake")
names.append("Casey")

print(names)
print(f"There are {len(names)} names.")
```

```text
['Avery', 'Blake', 'Casey']
There are 3 names.
```

---

## Part 4: Looping through a list

A `for` loop can go through a list one item at a time:

```python
prices = [2.50, 1.25, 3.00]

for price in prices:            # price is each item in turn
    print(f"${price:.2f}")
```

```text
$2.50
$1.25
$3.00
```

When you also need the **position** (for example, to number the items), loop over the indexes with `range(len(...))`:

```python
snacks = ["chips", "pretzels", "popcorn"]

for i in range(len(snacks)):            # i is 0, 1, 2
    print(f"{i + 1}. {snacks[i]}")      # + 1 so the list starts at 1, not 0
```

```text
1. chips
2. pretzels
3. popcorn
```

**Try it:** Make a list of 5 numbers and print each one doubled.

---

## Part 5: Filling a list from input

Start with an empty list, then `append` each answer inside a loop:

<!-- input: 3|90|85|77 -->
```python
scores = []

how_many = int(input("How many scores? "))
for count in range(how_many):
    score = int(input("Score: "))
    scores.append(score)            # add this score to the list

print(scores)
```

```text
How many scores? 3
Score: 90
Score: 85
Score: 77
[90, 85, 77]
```

The scores are saved now, so the program can use them again later. In Step 4 each score was gone as soon as the next one was typed.

---

## Part 6: Totals, averages, and counting

These are the Step 4 running total and counter, with a `for` loop going through the list.

```python
scores = [90, 85, 77, 62, 100]

total = 0
passing = 0
for score in scores:
    total = total + score
    if score >= 70:
        passing = passing + 1

average = total / len(scores)
print(f"Total: {total}")
print(f"Average: {average:.1f}")
print(f"Passing: {passing}")
```

```text
Total: 414
Average: 82.8
Passing: 4
```

Python has a built-in `sum()`, but BPA graders want to see that you can write the loop yourself. Use the loop.

---

## Part 7: Finding the highest and lowest

Start by guessing the **first item** is the highest. Then check every item. If one is bigger, it becomes the new highest.

```python
scores = [90, 85, 77, 62, 100]

highest = scores[0]             # start with the first item
for score in scores:
    if score > highest:         # found a bigger one
        highest = score

print(f"Highest: {highest}")
```

```text
Highest: 100
```

The lowest works the same way, with `<` instead of `>`.

**Why start with the first item and not 0?** If every number were negative, a highest of 0 would be wrong. The first item is always a real value from the list.

**Try it:** Add a loop that finds the lowest score.

---

## Part 8: Sorting

| What you type | What it does |
|---|---|
| `sorted(my_list)` | gives back a **new** sorted list, low to high. The original list doesn't change. |
| `sorted(my_list, reverse=True)` | a new list, high to low |
| `my_list.sort()` | sorts the list itself, low to high |

```python
scores = [90, 85, 77, 62, 100]

print(sorted(scores))
print(sorted(scores, reverse=True))
print(scores)                   # unchanged
```

```text
[62, 77, 85, 90, 100]
[100, 90, 85, 77, 62]
[90, 85, 77, 62, 100]
```

To print a list without the brackets, loop through it, or use `join` with a list of strings:

```python
names = ["Avery", "Blake", "Casey"]
print(", ".join(names))         # puts ", " between the items
```

```text
Avery, Blake, Casey
```

---

## Common mistakes

1. **Starting at index 1.** The first item is `my_list[0]`.
2. **Going past the end.** A list of 3 items has indexes 0, 1, and 2. `my_list[3]` crashes.
3. **Starting the highest at 0.** Start it at `my_list[0]`.
4. **Forgetting to `append`.** Typing `score = int(input(...))` in a loop doesn't save anything in the list.
5. **Using `range(my_list)`.** It has to be `range(len(my_list))`.
6. **Expecting `my_list.sort()` to give back a list.** It sorts the list itself and returns `None`. Use `sorted(my_list)` if you need a new list.

---

## Next steps
1. Do the [Step 6 Practice](step06_Practice.md) problems.
2. Keep the [Step 6 Study Guide](step06_StudyGuide.md) open while you work. Print it for BPA.
