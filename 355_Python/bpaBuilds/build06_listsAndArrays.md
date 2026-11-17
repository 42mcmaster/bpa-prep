# Builds for Step 06 — Lists (Python)

These are BPA-style programs that use the Step 6 skills together with everything before it. They are bigger than the practice problems, and closer to what the BPA test asks for.

**Do these after you finish Steps 1–7 (lessons and practice).** Use the [Step 6 Study Guide](../step06_listsAndArrays/step06_StudyGuide.md) for help.

**Rules for every build in this file**
- **Use your own loop** to find highest, lowest, and totals. No built-in `max`, `min`, or `sum`.
- Every function has a purpose / parameters / returns comment.
- End the file with `if __name__ == "__main__":` and `main()`.

## Table of Contents
- [Build 6A: Score Stats](#build-6a-score-stats)
- [Build 6B: Weekly Temperature Log](#build-6b-weekly-temperature-log)
- [Build 6C: Shopping List](#build-6c-shopping-list)
- [Build 6D: Test Curve](#build-6d-test-curve)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Build 6A: Score Stats
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

---

## Build 6B: Weekly Temperature Log
Write a program that stores a week of daily high temperatures in a list and prints a report about the week.

**Requirements**
1. Header comment.
2. Store the day names in a constant list at the top of the file:
   ```python
   DAY_NAMES = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"]
   ```
3. Use a `for` loop over `DAY_NAMES` to ask for each day's high (whole number) with the prompt `Monday high: `, `Tuesday high: `, and so on. Store the temperatures in a list.
4. Write these functions, each taking the list as a parameter:

   | Function | Returns |
   |---|---|
   | `find_highest(temps)` | the highest temperature |
   | `find_lowest(temps)` | the lowest temperature |
   | `calculate_average(temps)` | the average |
   | `find_day(temps, value)` | the day name for the first time `value` shows up in the list |

5. Print each day and its temperature. Add ` (above average)` after any day that is above the average.
6. Print the warmest day, the coldest day, the average (**1** decimal place), and the biggest swing (highest minus lowest).
7. Use **slices** to average the weekdays (`temps[0:5]`) and the weekend (`temps[5:7]`), using your `calculate_average` function. Print `The weekend was warmer than the weekdays.` or `The weekend was not warmer than the weekdays.`
8. Input / Processing / Output comments.

**Sample run**
```
Monday high: 58
Tuesday high: 62
Wednesday high: 71
Thursday high: 65
Friday high: 60
Saturday high: 74
Sunday high: 69

--- This Week ---
Monday: 58
Tuesday: 62
Wednesday: 71 (above average)
Thursday: 65
Friday: 60
Saturday: 74 (above average)
Sunday: 69 (above average)

Warmest: Saturday (74)
Coldest: Monday (58)
Average: 65.6
Biggest swing: 16 degrees
The weekend was warmer than the weekdays.
```

**Hints**
- The day names list and the temperature list are **parallel lists**: `DAY_NAMES[2]` and `temps[2]` are both Wednesday.
- `find_day` loops with `range(len(temps))` so it has the index. When `temps[i] == value`, return `DAY_NAMES[i]`.
- Check the average by hand: (58 + 62 + 71 + 65 + 60 + 74 + 69) ÷ 7 = 65.57, which shows as 65.6.
- The weekday average is 63.2 and the weekend average is 71.5.

**Test these too:** the same temperature every day (no day is above average), and the highest temperature on two different days (`find_day` gives the first one).

---

## Build 6C: Shopping List
Write a program that builds a shopping list with prices, then prints the list and some stats.

**Requirements**
1. Header comment. Store the budget in a constant: `BUDGET = 25.00`.
2. Print `Enter items. Type done when finished.` Then ask `Item: ` over and over until the user types `done` (any capitals, like `DONE`).
3. Store each item in **lowercase** in an `items` list, and its price in a parallel `prices` list. Ask `Price: ` right after each new item.
4. If the item is already on the list (ignore capitals), print `<item> is already on the list.` and do **not** ask for a price. Use `in`.
5. If the list is empty when the user types `done`, print `Your list is empty.` and end.
6. Write these functions:

   | Function | Returns |
   |---|---|
   | `calculate_total(prices)` | the total of all prices |
   | `find_most_expensive(prices)` | the **index** of the highest price |
   | `count_under(prices, limit)` | how many prices are below `limit` |

7. Print the numbered list and the stats exactly as shown. `A to Z` is the item names sorted alphabetically, separated by a comma and a space.
8. Print `Over budget by $X.XX` or `Under budget by $X.XX`.
9. Input / Processing / Output comments.

**Sample run 1**
```
Enter items. Type done when finished.
Item: Milk
Price: 3.49
Item: Bread
Price: 2.99
Item: milk
milk is already on the list.
Item: Chicken
Price: 9.75
Item: Apples
Price: 4.50
Item: done

--- Shopping List ---
1. milk - $3.49
2. bread - $2.99
3. chicken - $9.75
4. apples - $4.50

Items: 4
Total: $20.73
Most expensive: chicken ($9.75)
Items under $5.00: 3
A to Z: apples, bread, chicken, milk
Under budget by $4.27
```

**Sample run 2**
```
Enter items. Type done when finished.
Item: Steak
Price: 18.99
Item: Charcoal
Price: 12.50
Item: DONE

--- Shopping List ---
1. steak - $18.99
2. charcoal - $12.50

Items: 2
Total: $31.49
Most expensive: steak ($18.99)
Items under $5.00: 0
A to Z: charcoal, steak
Over budget by $6.49
```

**Hints**
- Check for a duplicate with `if item.lower() in items:`. That works because everything in `items` is already lowercase.
- `find_most_expensive` returns an **index**, not a price, so `main` can print both `items[top]` and `prices[top]`.
- `sorted(items)` gives a new sorted list and leaves `items` in the order entered. `", ".join(...)` puts `, ` between the names.
- To end `main` early when the list is empty, use `return`.

**Test these too:** type `done` right away (empty list), and add the same item three times.

---

## Build 6D: Test Curve
A teacher curves a test so the top score becomes 100, and everyone gets the same number of extra points. Write the program.

**Requirements**
1. Header comment.
2. Write `get_count()` that asks `How many scores? ` and keeps asking until the answer is 1 to 30, printing `Please enter 1 to 30.` each time it is not.
3. Ask for each score with `Score 1: `, `Score 2: `, and so on. Store them in a list.
4. Write these functions:

   | Function | Returns |
   |---|---|
   | `find_highest(scores)` | the highest score |
   | `calculate_average(scores)` | the average |
   | `curve_scores(scores, points)` | a **new** list with `points` added to every score. The original list must not change. |
   | `find_median(scores)` | the middle score of a **sorted copy**. If there is an even number of scores, the average of the two middle ones. |
   | `join_scores(scores)` | text like `72 85 64` with one space between scores and no extra space at the end |

5. The curve is `100 - highest`. If the highest score is already 100, the curve is +0.
6. Count the letter grades of the **curved** scores: A (90+), B (80+), C (70+), D (60+), F (below 60).
7. Print the report exactly as shown. Averages have **2** decimal places and the median has **1**.
8. Input / Processing / Output comments.

**Sample run 1**
```
How many scores? 40
Please enter 1 to 30.
How many scores? 6
Score 1: 72
Score 2: 85
Score 3: 64
Score 4: 91
Score 5: 58
Score 6: 77

Original: 72 85 64 91 58 77
Curve: +9 points
Curved:   81 94 73 100 67 86

Original average: 74.50
Curved average:   83.50
Curved median:    83.5

A: 2  B: 2  C: 1  D: 1  F: 0
```

**Sample run 2**
```
How many scores? 5
Score 1: 100
Score 2: 80
Score 3: 70
Score 4: 90
Score 5: 60

Original: 100 80 70 90 60
Curve: +0 points
Curved:   100 80 70 90 60

Original average: 80.00
Curved average:   80.00
Curved median:    80.0

A: 2  B: 1  C: 1  D: 1  F: 0
```

**Hints**
- `curve_scores` starts with an empty list and appends `score + points` for each score. That way the original list is untouched.
- Median: sort a copy with `sorted(scores)`. The middle index is `len // 2`. If the count is odd (`% 2 == 1`), that's the median. If it's even, average the two middle items.
- Check sample run 1: sorted curved scores are 67 73 81 86 94 100. The two middle ones are 81 and 86, so the median is 83.5.
- `join_scores` is Way 2 from the Step 6 study guide's "Printing a list neatly," or a loop that builds a string and then uses `.strip()`.
- Five counter variables (`a_count`, `b_count`, …) are fine for the letter grades.

**Test these too:** 1 score, an odd number of scores (median is one value), and a highest score of 100.

---

## Turn it in
1. In your `bpaPrep` repo, make a folder named `python_builds` (one folder for all builds).
2. Save the builds as `build06A.py`, `build06B.py`, `build06C.py`, and `build06D.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Scores are stored in a list
- [ ] `find_highest`, `find_lowest`, `calculate_average` each take the list and use their own loop (no `max`, `min`, `sum`)
- [ ] Every function has a Purpose / Parameters / Returns comment
- [ ] `Scores:` line is in the order entered; sorted line is high to low
- [ ] Pushed to `bpaPrep/python_builds`
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] I tested the extra inputs listed under each task
- [ ] No `max`, `min`, or `sum` — my own loops only
- [ ] Input / Processing / Output comments in each file
