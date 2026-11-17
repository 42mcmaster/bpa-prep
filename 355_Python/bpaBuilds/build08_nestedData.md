# Builds for Step 08 — Nested Data (Python)

These are BPA-style programs that use the Step 8 skills together with everything before it. They are bigger than the practice problems, and closer to what the BPA test asks for.

**Do these after you finish the Step 8 lesson and practice.** Use the [Step 8 Study Guide](../step08_nestedData/step08_StudyGuide.md) for help.

**Rules for every build in this file**
- Every function has a purpose / parameters / returns comment.
- End the file with `if __name__ == "__main__":` and `main()`.

## Table of Contents
- [Build 8A: Team Scoreboard](#build-8a-team-scoreboard)
- [Build 8B: Step Challenge](#build-8b-step-challenge)
- [Build 8C: Theater Seats](#build-8c-theater-seats)
- [Build 8D: Vote Counter](#build-8d-vote-counter)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Build 8A: Team Scoreboard
Collect scores for up to 6 players over 3 rounds, then print a sorted leaderboard and an analysis.

**Requirements**
1. Header comment.
2. Ask `How many players? ` (1 to 6; if outside print `Please enter 1 to 6.` and ask again).
3. Ask each player's name: `Player 1 name: `, …
4. For each player, ask 3 round scores: `<name>, round 1 score: ` … Scores must be 0 to 100; if not, print `Score must be 0 to 100.` and ask that same round again.
5. Store names in a list and scores in a 2D structure (one row per player, one column per round).
6. Print a leaderboard sorted by total, highest first, in the exact column format below: Name (10 wide, left), R1, R2, R3 (5 wide each, left), Total (7 wide, left), Average (2 decimals). A line of 39 dashes under the header.
7. Print the winner (highest total), the best single round (player, round number, score), and the highest scoring round (round with the highest average across all players, 2 decimals). If there's a tie, the first one found wins.
8. Use functions for: getting scores, calculating a player's total, sorting, printing the table, and the analysis. Function comments and Input / Processing / Output comments.

**Sample run (exact)**
```
How many players? 3
Player 1 name: Jordan
Player 2 name: Taylor
Player 3 name: Sam
Jordan, round 1 score: 80
Jordan, round 2 score: 90
Jordan, round 3 score: 70
Taylor, round 1 score: 95
Taylor, round 2 score: 85
Taylor, round 3 score: 88
Sam, round 1 score: 60
Sam, round 2 score: 75
Sam, round 3 score: 105
Score must be 0 to 100.
Sam, round 3 score: 100

Name      R1   R2   R3   Total  Average
---------------------------------------
Taylor    95   85   88   268    89.33
Jordan    80   90   70   240    80.00
Sam       60   75   100  235    78.33

Winner: Taylor (268 points)
Best single round: Sam, round 3 (100)
Highest scoring round: Round 3 (average 86.00)
```
Check: round averages R1 = (80+95+60)/3 = 78.33, R2 = (90+85+75)/3 = 83.33, R3 = (70+88+100)/3 = 86.00. The highest single score is 100 (Sam, round 3).

Tie rule: "first one found" means scanning rows top to bottom in the **sorted** table, rounds left to right.

**Hints**
- All the names are asked **first**, then all the scores (look at the sample run).
- A constant `NUM_ROUNDS = 3` at the top keeps the 3 from being typed all over.
- A small helper like `get_whole_number(prompt, low, high, error_message)` can do both the player count and each score with one `while` loop.
- Sort **before** you print the table and **before** the analysis. Then the winner is simply row 0.
- Suggested functions: `get_scores(names)`, `calculate_total(row)`, `sort_by_total(names, scores)`, `print_table(names, scores)`, `print_analysis(names, scores)`, and `main()`.

---

## Build 8B: Step Challenge
A group is tracking their steps for a week. Store the steps in a list of lists (one row per person, one column per day) and print a table.

**Requirements**
1. Header comment. Constants at the top:
   ```python
   DAYS = ["Mon", "Tue", "Wed", "Thu", "Fri"]
   DAILY_GOAL = 8000
   ```
2. Write `get_whole_number(prompt, low, high, error_message)` that keeps asking until the answer is from low to high.
3. Ask `How many people? ` (1 to 5, message `Please enter 1 to 5.`).
4. For each person, ask the name, then each day's steps with the prompt `  Mon steps: ` (2 spaces at the start). Steps must be 0 to 50000; otherwise print `  Steps must be 0 to 50000.` and ask that day again.
5. Store the names in a list and the steps in a 2D list.
6. Write these functions:

   | Function | Returns |
   |---|---|
   | `row_total(row)` | the total steps for one person |
   | `column_average(steps, day)` | the average for one day (column) across everyone |
   | `goal_days(row)` | how many days one person was at or above `DAILY_GOAL` |
   | `print_table(names, steps)` | prints the table, returns nothing |

7. The table: Name is 9 wide, each day is 7 wide, then the total. A line of 49 dashes above and below the people. The last row is `Average`, with each day's average as a whole number (`.0f`) and no total.
8. After the table, print the most active person (highest total), the most active day (highest average), and one goal line per person. Ties go to the first one found.
9. Input / Processing / Output comments.

**Sample run**
```
How many people? 3
Person 1 name: Avery
  Mon steps: 9200
  Tue steps: 7600
  Wed steps: 10450
  Thu steps: 8100
  Fri steps: 6900
Person 2 name: Blake
  Mon steps: 5400
  Tue steps: 6100
  Wed steps: 60000
  Steps must be 0 to 50000.
  Wed steps: 7200
  Thu steps: 8800
  Fri steps: 9100
Person 3 name: Casey
  Mon steps: 11000
  Tue steps: 12500
  Wed steps: 9800
  Thu steps: 10200
  Fri steps: 7700

Name     Mon    Tue    Wed    Thu    Fri    Total
-------------------------------------------------
Avery    9200   7600   10450  8100   6900   42250
Blake    5400   6100   7200   8800   9100   36600
Casey    11000  12500  9800   10200  7700   51200
-------------------------------------------------
Average  8533   8733   9150   9033   7900

Most active: Casey (51200 steps)
Most active day: Wed
Avery hit 8000 steps on 3 of 5 days.
Blake hit 8000 steps on 2 of 5 days.
Casey hit 8000 steps on 4 of 5 days.
```

**Hints**
- Build each person's row with an inner loop over `DAYS`, then append the row to `steps`.
- `column_average` loops over the **rows** and adds `row[day]`.
- To print a row with a loop, build one string: start with `f"{names[i]:<9}"`, add `f"{value:<7}"` for each day, then add the total.
- The `Average` row ends with spaces because of the `<7` width. Use `.rstrip()` on the line before you print it, so there are no extra spaces at the end.
- Check Wednesday's average: (10450 + 7200 + 9800) ÷ 3 = 9150.

---

## Build 8C: Theater Seats
Write a program that shows a seating chart and lets the user book seats.

**Requirements**
1. Header comment. Constants at the top: `ROW_LETTERS = "ABCDE"`, `SEATS_PER_ROW = 8`, `SEAT_PRICE = 9.50`.
2. Write `make_chart()` that returns a 2D list with 5 rows of 8 seats, all `"O"` (open). Use nested loops.
3. In `main`, mark these seats as already taken with `"X"`: A4, A5, and C1. (Row A is index 0. Seat 4 is index 3.)
4. Write `print_chart(chart)` that prints the seat numbers across the top and each row's letter and seats, exactly as shown.
5. Print the chart, then ask `Seat to book (like B4), or done: ` until the user types `done` (any capitals). `.strip()` and `.upper()` the answer.
6. For each answer:
   - If it is not 2 characters, or the first character is not A–E, or the second is not a digit 1–8, print `Please type a row letter A-E and a seat number 1-8.`
   - If the seat is already `"X"`, print `<seat> is already taken.`
   - Otherwise mark it `"X"`, save it in a `booked` list, and print `Booked <seat>.`
7. When done, print the chart again, the open seats in each row, the seats booked, and the cost.
8. Write `count_open(row)` that returns how many seats in one row are `"O"`.
9. Input / Processing / Output comments.

**Sample run**
```
   1 2 3 4 5 6 7 8
A  O O O X X O O O
B  O O O O O O O O
C  X O O O O O O O
D  O O O O O O O O
E  O O O O O O O O

Seat to book (like B4), or done: A4
A4 is already taken.
Seat to book (like B4), or done: b4
Booked B4.
Seat to book (like B4), or done: B5
Booked B5.
Seat to book (like B4), or done: Z9
Please type a row letter A-E and a seat number 1-8.
Seat to book (like B4), or done: B12
Please type a row letter A-E and a seat number 1-8.
Seat to book (like B4), or done: c1
C1 is already taken.
Seat to book (like B4), or done: C2
Booked C2.
Seat to book (like B4), or done: done

   1 2 3 4 5 6 7 8
A  O O O X X O O O
B  O O O X X O O O
C  X X O O O O O O
D  O O O O O O O O
E  O O O O O O O O

Row A: 6 open
Row B: 6 open
Row C: 6 open
Row D: 8 open
Row E: 8 open
You booked: B4 B5 C2
Cost: $28.50
```

**Hints**
- `ROW_LETTERS.find("C")` gives `2`, the row index. `int(choice[1]) - 1` gives the seat index.
- `choice[0] not in ROW_LETTERS` checks the row letter.
- `B12` is 3 characters, so the length check catches it.
- Build each chart line as a string: the row letter, a space, then `" " + seat` for each seat.
- `' '.join(booked)` prints the booked seats with spaces between them.

**Test these too:** book every seat in row D, type `0` as the seat number (`A0`), and type `done` right away (`You booked:` with nothing after it and `$0.00`).

---

## Build 8D: Vote Counter
Write a program that counts votes with a **dictionary**, then sorts and prints the results.

**Requirements**
1. Header comment.
2. Print `Type one vote per line. Press Enter on a blank line to finish.`
3. Write `fix_capitals(text)` that returns the text with the first letter uppercase and the rest lowercase (or `""` if the text is blank). Do not use `.title()`.
4. Write `count_votes()` that asks `Vote: ` over and over until a blank answer. It uses `fix_capitals` on each vote, so `pizza`, `Pizza`, and `PIZZA` all count as `Pizza`. It returns a dictionary of choice → number of votes.
5. If there are no votes, print `No votes were cast.` and end.
6. Copy the dictionary into two parallel lists (names and counts). Add up the total.
7. Write `sort_results(names, counts)`: a **bubble sort**, highest count first, that swaps the names the same way.
8. Write `print_results(names, counts, total)` that prints the table exactly as shown: Choice 12 wide, Votes 7 wide, Percent 9 wide (1 decimal), then a bar with one `#` per vote. A line of 36 dashes under the header.
9. Print the total. If the top two counts are the same, print `It's a tie between X and Y!`. Otherwise print `Winner: X`.
10. Input / Processing / Output comments.

**Sample run 1**
```
Type one vote per line. Press Enter on a blank line to finish.
Vote: pizza
Vote: Tacos
Vote: pizza
Vote: burgers
Vote: tacos
Vote: PIZZA
Vote: Sushi
Vote: tacos
Vote: 

Choice      Votes  Percent  Bar
------------------------------------
Pizza       3      37.5     ###
Tacos       3      37.5     ###
Burgers     1      12.5     #
Sushi       1      12.5     #

Total votes: 8
It's a tie between Pizza and Tacos!
```

**Sample run 2**
```
Type one vote per line. Press Enter on a blank line to finish.
Vote: red
Vote: blue
Vote: Red
Vote: green
Vote: blue
Vote: BLUE
Vote: 

Choice      Votes  Percent  Bar
------------------------------------
Blue        3      50.0     ###
Red         2      33.3     ##
Green       1      16.7     #

Total votes: 6
Winner: Blue
```

**Hints**
- Counting with a dictionary: if the vote is already a key, add 1 to it. Otherwise set it to 1.
- `for name in votes:` loops over the keys. Inside, `votes[name]` is the count.
- The bubble sort is the same as the Step 8 study guide's `sort_high_to_low`, comparing counts.
- In a tie, the choice that was voted for first stays first. Bubble sort only swaps when one count is **smaller**, so equal counts don't move.
- Check sample run 1: Pizza 3 of 8 votes = 37.5%.

**Test these too:** only one vote (no tie check crash), and a blank answer right away.

---

## Turn it in
1. In your `bpaPrep` repo, make a folder named `python_builds` (one folder for all builds).
2. Save the builds as `build08A.py`, `build08B.py`, `build08C.py`, and `build08D.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run, including spacing in the table
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Names in a list; scores in a list of lists (one row per player)
- [ ] Bad counts and bad scores are re-asked with the right message
- [ ] Your own sort, swapping names and score rows together
- [ ] Functions for getting scores, total, sorting, table, analysis — each with a Purpose / Parameters / Returns comment
- [ ] Pushed to `bpaPrep/python_builds`
- [ ] All three programs run with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] I tested the extra inputs listed under Builds 8C and 8D
- [ ] Every function has a purpose / parameters / returns comment
- [ ] Input / Processing / Output comments in each file
