# Step 08 — Nested Data (Python)

Real programs keep track of tables: several players, each with several scores. This lesson shows the ways to store a table in Python, one piece at a time. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 8 Practice](step08_Practice.md) problems. For more examples, use the [Step 8 Study Guide](step08_StudyGuide.md).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: A list of lists](#part-1-a-list-of-lists)
- [Part 2: Looping through a table](#part-2-looping-through-a-table)
- [Part 3: Row totals](#part-3-row-totals)
- [Part 4: Parallel lists](#part-4-parallel-lists)
- [Part 5: Filling a table from input](#part-5-filling-a-table-from-input)
- [Part 6: Lining up columns](#part-6-lining-up-columns)
- [Part 7: Dictionaries](#part-7-dictionaries)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- How to store a table as a list of lists
- How to read one value with `[row][column]`
- How to loop through a table with a loop inside a loop
- How to keep names and scores together with parallel lists
- How to line up columns in a printed table
- How to look values up by name with a dictionary

---

## Part 1: A list of lists

A list can hold other lists. Each inner list is one **row** of a table.

```python
#         round 1  round 2  round 3
scores = [[88,     92,      79],     # row 0: Avery
          [95,     67,      84]]     # row 1: Blake

print(scores[0])        # the whole first row
print(scores[1][2])     # row 1, column 2
```

```text
[88, 92, 79]
84
```

`scores[1][2]` means "go to row 1, then column 2." Both start at 0. Read it as `[row][column]`.

**Try it:** Print Avery's round 2 score. Then change Blake's round 2 score to 70.

---

## Part 2: Looping through a table

To visit every value, put a loop inside a loop. The **outer** loop goes through the rows. The **inner** loop goes through the values in one row.

```python
scores = [[88, 92, 79],
          [95, 67, 84]]

for row in scores:              # each row is a list
    for score in row:           # each score in that row
        print(score, end=" ")   # end=" " keeps them on one line
    print()                     # new line after each row
```

```text
88 92 79 
95 67 84 
```

**Try it:** Print a 3 x 3 grid of `*` characters with two loops.

---

## Part 3: Row totals

A row is just a list, so the Step 6 running total works on it. Start the total **inside** the outer loop, so each row starts at 0.

```python
scores = [[88, 92, 79],
          [95, 67, 84]]

for row in scores:
    total = 0                   # reset for each row
    for score in row:
        total = total + score
    print(f"Total: {total}")
```

```text
Total: 259
Total: 246
```

---

## Part 4: Parallel lists

The scores don't say whose they are. Keep the names in a **second list**, in the same order. Index `i` in `names` goes with row `i` in `scores`. These are called **parallel lists**.

```python
names = ["Avery", "Blake"]
scores = [[88, 92, 79],
          [95, 67, 84]]

for i in range(len(names)):
    total = 0
    for score in scores[i]:
        total = total + score
    print(f"{names[i]}: {total}")
```

```text
Avery: 259
Blake: 246
```

If you sort or change one list, you have to do the same to the other, or the names and scores get mixed up.

---

## Part 5: Filling a table from input

Build each row as its own list, then `append` the whole row to the table.

<!-- input: Avery|88|92|Blake|95|67 -->
```python
names = []
scores = []

for player in range(2):
    name = input("Name: ")
    row = []                            # a new, empty row for this player
    for round_number in range(1, 3):
        score = int(input(f"  Round {round_number} score: "))
        row.append(score)
    names.append(name)
    scores.append(row)                  # add the whole row

print(names)
print(scores)
```

```text
Name: Avery
  Round 1 score: 88
  Round 2 score: 92
Name: Blake
  Round 1 score: 95
  Round 2 score: 67
['Avery', 'Blake']
[[88, 92], [95, 67]]
```

`row = []` must be **inside** the outer loop, so each player gets a new row.

---

## Part 6: Lining up columns

Put a width after a colon in the f-string. Shorter values are padded with spaces, so the columns line up.

| What you type | Means |
|---|---|
| `{name:<10}` | left-aligned in 10 spaces |
| `{score:>5}` | right-aligned in 5 spaces |
| `{average:>7.1f}` | 1 decimal place, right-aligned in 7 spaces |

```python
names = ["Avery", "Blake"]
totals = [259, 246]

print(f"{'Name':<8}{'Total':>6}")
print("-" * 14)
for i in range(len(names)):
    print(f"{names[i]:<8}{totals[i]:>6}")
```

```text
Name     Total
--------------
Avery      259
Blake      246
```

Use the **same widths** in the header and in every row.

---

## Part 7: Dictionaries

A **dictionary** stores pairs: a **key** and its **value**. You look a value up by its key, like looking up a word in a dictionary.

```python
prices = {"chips": 1.50, "soda": 2.00, "candy": 1.25}

print(prices["soda"])           # look up by key
prices["water"] = 1.00          # add a new pair

for item in prices:             # a loop gives the keys
    print(f"{item}: ${prices[item]:.2f}")
```

```text
2.0
chips: $1.50
soda: $2.00
candy: $1.25
water: $1.00
```

Check `if item in prices:` before you look something up. A key that isn't there crashes with a `KeyError`.

**Try it:** Ask for an item. If it's in the dictionary, print its price. If not, print `Not on the menu.`

---

## Common mistakes

1. **Mixing up row and column.** It's `table[row][column]`.
2. **Not resetting the row total.** Put `total = 0` inside the outer loop.
3. **Making `row = []` outside the loop.** Every player ends up sharing one row.
4. **Sorting one parallel list but not the other.** The names no longer match the scores.
5. **Different widths in the header and the rows.** The columns don't line up.
6. **Looking up a key that isn't in the dictionary.** Check with `in` first.

---

## Next steps
1. Do the [Step 8 Practice](step08_Practice.md) problems.
2. Keep the [Step 8 Study Guide](step08_StudyGuide.md) open while you work. Print it for BPA.
3. After the practice, try the [Step 8 builds](../bpaBuilds/build08_nestedData.md). They put everything together, BPA style.
