# Step 06 Practice — Lists (Python)

**Do these after the [Step 6 lesson](step06_Lesson.md).** Each problem is short. The goal is lots of practice with lists before the bigger BPA-style programs.

**Time:** about one class period for Problems 1–12. The Challenge at the end takes longer.

**Need help?** Use the [Step 6 Study Guide](step06_StudyGuide.md). Every problem lists the study guide section that shows how.

Problems marked **(review)** use skills from earlier steps, so you keep practicing them.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: Print a list](#problem-1-print-a-list)
- [Problem 2: First, last, and how many](#problem-2-first-last-and-how-many)
- [Problem 3: Change an item](#problem-3-change-an-item)
- [Problem 4: Numbered menu](#problem-4-numbered-menu)
- [Problem 5: Team list from input](#problem-5-team-list-from-input)
- [Problem 6: Total and average](#problem-6-total-and-average)
- [Problem 7: Count the passing scores](#problem-7-count-the-passing-scores)
- [Problem 8: Highest temperature](#problem-8-highest-temperature)
- [Problem 9: Lowest and which day](#problem-9-lowest-and-which-day)
- [Problem 10: Keep adding until done](#problem-10-keep-adding-until-done)
- [Problem 11: Sort both ways](#problem-11-sort-both-ways)
- [Problem 12: Average with a function](#problem-12-average-with-a-function)
- [Challenge: Daily Steps Tracker](#challenge-daily-steps-tracker)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step06_p01.py`, `step06_p02.py`, and so on.
2. Start each file with a header comment (name, date, program name).
3. Use your own loops for totals, highest, and lowest. **No** `sum()`, `max()`, or `min()`.
4. Use the **exact** prompts and output shown. Same words, same spaces.
5. Run your program with the sample input and compare your output to the sample run, line by line.

---

## Problem 1: Print a list
Make a list of four foods: `pizza`, `tacos`, `ramen`, and `wings`. Use a `for` loop to print each one on its own line.

**Sample run**
```
pizza
tacos
ramen
wings
```

**Hint:** `for food in foods:` gives you each item in turn.

**Study guide:** [Looping through a list](step06_StudyGuide.md#looping-through-a-list)

---

## Problem 2: First, last, and how many
Make a list of five states: `Ohio`, `Texas`, `Maine`, `Utah`, `Iowa`. Print the first one, the last one, and how many there are.

**Sample run**
```
First: Ohio
Last:  Iowa
Count: 5
```

**Hints**
- The first item is index 0.
- `[-1]` is the last item. `len()` counts the items.

**Study guide:** [Indexes start at 0](step06_StudyGuide.md#indexes-start-at-0)

---

## Problem 3: Change an item
Start with the list `["milk", "bread", "eggs"]`. Print it, change `bread` to `bagels`, add `juice` to the end, then print it again.

**Sample run**
```
['milk', 'bread', 'eggs']
['milk', 'bagels', 'eggs', 'juice']
```

**Hints**
- `bread` is at index 1.
- `.append()` adds to the end.

**Study guide:** [Length and adding items](step06_StudyGuide.md#length-and-adding-items)

---

## Problem 4: Numbered menu
Make a list of snacks: `Chips`, `Pretzels`, `Popcorn`, `Trail mix`. Print them as a numbered menu, starting at 1.

**Sample run**
```
--- Snack Menu ---
1. Chips
2. Pretzels
3. Popcorn
4. Trail mix
```

**Hints**
- `range(len(snacks))` gives the indexes 0, 1, 2, 3.
- Print `i + 1` so the menu starts at 1.

**Study guide:** [Looping through a list](step06_StudyGuide.md#looping-through-a-list)

---

## Problem 5: Team list from input
Ask for three player names, put them in a list, then print the team on one line with commas between the names.

**Sample run**
```
Player name: Avery
Player name: Blake
Player name: Casey
Team: Avery, Blake, Casey
```

**Hints**
- Start with `team = []`, then `append` inside the loop.
- `", ".join(team)` puts a comma and a space between the names.

**Study guide:** [Filling a list from input](step06_StudyGuide.md#filling-a-list-from-input)

---

## Problem 6: Total and average
Use this list of prices: `[4.99, 12.50, 3.25, 8.00]`. Use a loop (not `sum()`) to find the total, then print the total and the average.

**Sample run**
```
Total:   $28.74
Average: $7.19
```

**Hints**
- Running total from Step 4: start at 0, add each price.
- Divide by `len(prices)`, not by a typed 4.

**Study guide:** [Totals averages and counting](step06_StudyGuide.md#totals-averages-and-counting)

---

## Problem 7: Count the passing scores
*(review: Step 3 if statements)*

Use this list of scores: `[88, 64, 92, 71, 55, 79, 100]`. Count how many are 70 or higher.

**Sample run**
```
5 of 7 scores are passing.
```

**Hint:** A counter starts at 0 and goes up by 1 inside the `if`.

**Study guide:** [Totals averages and counting](step06_StudyGuide.md#totals-averages-and-counting)

---

## Problem 8: Highest temperature
Use this list of daily high temperatures: `[61, 58, 67, 72, 64, 59, 70]`. Use your own loop (not `max()`) to find the highest.

**Sample run**
```
Highest: 72
```

**Hints**
- Start `highest` at `temps[0]`, not 0.
- If a temperature is bigger than `highest`, it becomes the new highest.

**Study guide:** [Finding the highest and lowest yourself](step06_StudyGuide.md#finding-the-highest-and-lowest-yourself)

---

## Problem 9: Lowest and which day
Use the same temperatures. Find the **lowest** and which day it was (day 1 is the first item).

**Sample run**
```
Lowest: 58 on day 2
```

**Hints**
- Keep track of the **index** of the lowest, not just the value.
- Loop with `range(len(temps))` so you have the index.
- Add 1 to the index when you print the day.

**Study guide:** [Finding the highest and lowest yourself](step06_StudyGuide.md#finding-the-highest-and-lowest-yourself)

---

## Problem 10: Keep adding until done
*(review: Step 4 while loops)*

Keep asking for items for a packing list until the user types `done`. Then print how many items there are, and each item with a dash in front.

**Sample run**
```
Item (done to stop): charger
Item (done to stop): hoodie
Item (done to stop): snacks
Item (done to stop): done
You packed 3 items:
- charger
- hoodie
- snacks
```

**Hints**
- This is the Step 4 sentinel loop: ask before the loop and again at the bottom.
- Don't `append` the word `done`.

**Study guide:** [Filling a list from input](step06_StudyGuide.md#filling-a-list-from-input)

---

## Problem 11: Sort both ways
Use this list of times in seconds: `[48, 52, 45, 50, 47]`. Print it from fastest to slowest, then slowest to fastest, then the original order.

**Sample run**
```
Fastest first: [45, 47, 48, 50, 52]
Slowest first: [52, 50, 48, 47, 45]
Original:      [48, 52, 45, 50, 47]
```

**Hints**
- `sorted()` makes a new list and doesn't change `times`.
- `reverse=True` sorts high to low.

**Study guide:** [Sorting](step06_StudyGuide.md#sorting)

---

## Problem 12: Average with a function
*(review: Step 5 functions)*

Write a function `average(numbers)` that takes a list and returns the average (use a loop, not `sum()`). Call it with two different lists.

**Sample run**
```
Quiz average: 8.5
Test average: 85.0
```

**Hints**
- A list can be passed to a function like any other value.
- Function comment: Purpose, Parameters, Returns.

**Study guide:** [Passing a list to a function](step06_StudyGuide.md#passing-a-list-to-a-function)

---

## Challenge: Daily Steps Tracker
This one puts the pieces together: an ask-again loop, filling a list, a total and average, finding the best day, counting, and sorting.

**Requirements**
1. Header comment, Input / Processing / Output comments, and a `main()` function.
2. Named constant: `GOAL = 10000`.
3. Ask `How many days? (1-7): ` and ask again until the answer is 1 to 7. A bad answer prints `Please enter 1 to 7.`
4. Use a `for` loop to ask for each day's steps (`Steps on day 1: `, and so on) and `append` them to a list.
5. Use your own loop (no `sum`, `max`, or `min`) to find the total, the best day, and how many days reached the goal (10000 or more).
6. Print the report exactly as shown. The average has 1 decimal place.

**Sample run**
```
How many days? (1-7): 9
Please enter 1 to 7.
How many days? (1-7): 4
Steps on day 1: 8200
Steps on day 2: 12050
Steps on day 3: 10000
Steps on day 4: 6475

--- Step Report ---
Total steps:   36725
Average:       9181.2
Best day:      day 2 (12050 steps)
Goal reached:  2 of 4 days
Sorted:        [6475, 8200, 10000, 12050]
```

**Hints**
- `for day in range(1, days + 1):` gives the day number for the prompt.
- Keep the **index** of the best day, so you can print both the day number and the steps.
- If two days tie for best, the first one wins. Use `>`, not `>=`.

**Study guide:** [Finding the highest and lowest yourself](step06_StudyGuide.md#finding-the-highest-and-lowest-yourself)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step06` folder.
2. Save the problems as `step06_p01.py` through `step06_p12.py`, and the challenge as `step06_challenge.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step06`
