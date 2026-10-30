# Step 06 — Arrays and Vectors (C++)

**What you'll build:** Score Stats — a program that stores a list of scores and prints the highest, lowest, average, and the scores sorted.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Why store a list](#why-store-a-list)
- [Fixed-size arrays](#fixed-size-arrays)
- [Vectors: lists that can grow](#vectors-lists-that-can-grow)
- [Arrays or vectors: which to use](#arrays-or-vectors-which-to-use)
- [Looping through a vector](#looping-through-a-vector)
- [Finding the highest, lowest, and average yourself](#finding-the-highest-lowest-and-average-yourself)
- [Counting items that match](#counting-items-that-match)
- [Sorting](#sorting)
- [Passing a vector to a function](#passing-a-vector-to-a-function)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Score Stats](#the-challenge-score-stats)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- Fixed-size arrays: `int temps[5];`
- Vectors, C++'s growable list: `vector<int> temps;`
- Index numbers start at 0
- `push_back` to add, `size()` to count, and the `size_t` type
- Looping with a counting `for` loop and with a for-each loop
- Writing your own highest, lowest, and average loops (graders look for these)
- Counting items that match a condition
- Sorting with `sort`, and high-to-low with `reverse`
- Passing a vector to a function with `const vector<int>&`

---

## Why store a list

So far each variable held one value. To keep 5 scores, you could make `score1` through `score5`, but then you can't loop over them, and you'd need new code for 6 scores. A **list** holds many values under one name. You reach each value by its **position number**, called its **index**.

C++ has two kinds of list:
- an **array**: a fixed number of boxes, decided when you write the code
- a **vector**: a list that can grow while the program runs (like a Python list)

Python comparison:

| Python | C++ vector |
|---|---|
| `temps = []` | `vector<int> temps;` |
| `temps.append(72)` | `temps.push_back(72);` |
| `len(temps)` | `temps.size()` |
| `temps[0]` | `temps[0]` |
| `for t in temps:` | `for (int t : temps)` |
| `temps.sort()` | `sort(temps.begin(), temps.end());` |

---

## Fixed-size arrays

```cpp
#include <iostream>
using namespace std;

int main()
{
    // Processing: an array of 5 ints, filled in when it is created
    const int DAYS = 5;
    int temps[DAYS] = { 68, 72, 75, 71, 64 };

    // Output: one value by index (index starts at 0)
    cout << "First day: " << temps[0] << endl;
    cout << "Last day: " << temps[DAYS - 1] << endl;

    // Processing: change one value
    temps[2] = 77;

    // Output: every value, with a counting loop
    for (int i = 0; i < DAYS; i++)
    {
        cout << "Day " << (i + 1) << ": " << temps[i] << endl;
    }
    return 0;
}
```

What it prints:
```
First day: 68
Last day: 64
Day 1: 68
Day 2: 72
Day 3: 77
Day 4: 71
Day 5: 64
```

| What you type | What it means |
|---|---|
| `int temps[5];` | Make an array of 5 `int` boxes (values not set yet) |
| `int temps[5] = { 68, 72, 75, 71, 64 };` | Make it and fill it |
| `temps[0]` | The **first** box. Index 0. |
| `temps[4]` | The **last** box of 5. The last index is always size minus 1. |

Important facts about arrays:
- The size is **fixed**. It must be a number or a `const`, not a value the user types.
- The array does **not** know its own size. Keep the size in a constant like `DAYS`.
- C++ does **not** check the index. `temps[5]` on a 5-box array reads memory that is not yours. You get a random number or a crash, and **no clear error**. Be careful with `<` versus `<=` in loops.

You used arrays like this already if you have done Arduino work (`int pins[3] = {2, 3, 4};`). That is the same C++ array.

---

## Vectors: lists that can grow

A **vector** is a list that grows as you add to it. It knows its own size. It needs `#include <vector>`.

```cpp
#include <iostream>
#include <vector>   // needed for vector
using namespace std;

int main()
{
    // Processing: an empty vector of ints
    vector<int> laps;

    // Processing: push_back adds to the END of the vector
    laps.push_back(95);
    laps.push_back(88);
    laps.push_back(91);

    // Output: size and single values
    cout << "Laps recorded: " << laps.size() << endl;
    cout << "First lap: " << laps[0] << " seconds" << endl;
    cout << "Last lap: " << laps[laps.size() - 1] << " seconds" << endl;

    // Processing: change a value, then remove the last one
    laps[1] = 86;
    laps.pop_back();

    // Output: what is left
    cout << "Now " << laps.size() << " laps: " << laps[0] << " " << laps[1] << endl;
    return 0;
}
```

What it prints:
```
Laps recorded: 3
First lap: 95 seconds
Last lap: 91 seconds
Now 2 laps: 95 86
```

| What you type | What it means |
|---|---|
| `vector<int> laps;` | Make an empty vector that holds `int` values. The type goes in `< >`. |
| `vector<string> names;` | A vector of strings (needs `#include <string>` too) |
| `laps.push_back(95);` | Add 95 to the end |
| `laps.size()` | How many items are in it now |
| `laps[0]` | The first item (index 0), same as an array |
| `laps.at(0)` | Same as `laps[0]`, but **checks** the index and stops the program with an error if it is out of range. Useful while testing. |
| `laps.pop_back();` | Remove the last item |
| `laps.empty()` | `true` if it has no items |
| `vector<int> copy = laps;` | Make a full, separate copy |

### Filling a vector from user input

```cpp
#include <iostream>
#include <vector>
using namespace std;

int main()
{
    // Input: how many, then each value, added with push_back
    int count = 0;
    cout << "How many temperatures? ";
    cin >> count;

    vector<int> temps;
    for (int i = 1; i <= count; i++)
    {
        int temp = 0;
        cout << "Temp " << i << ": ";
        cin >> temp;
        temps.push_back(temp);
    }

    // Output: confirm
    cout << "Stored " << temps.size() << " temperatures." << endl;
    return 0;
}
```

Sample run:
```
How many temperatures? 3
Temp 1: 70
Temp 2: 65
Temp 3: 81
Stored 3 temperatures.
```

This is the input pattern the challenge uses.

### What is `size_t`?

`size()` returns a number of type **`size_t`**. `size_t` is a whole-number type that can never be negative, used for sizes and index numbers. When a `for` loop compares its counter with `size()`, make the counter a `size_t` too:

```cpp
for (size_t i = 0; i < temps.size(); i++)
```

If you write `int i` instead, it still works, but the compiler warns: `comparison of integer expressions of different signedness` (g++) or `C4018 '<': signed/unsigned mismatch` (Visual Studio). Using `size_t` keeps the warnings away.

---

## Arrays or vectors: which to use

| | Array `int a[5]` | Vector `vector<int> v` |
|---|---|---|
| Size | Fixed when you write the code | Grows and shrinks while running |
| Knows its size | No (keep a constant) | Yes: `v.size()` |
| Add an item | Not possible | `v.push_back(x)` |
| Pass to a function | Also pass the size | Just pass the vector |
| Best for | Lists that never change size: the 7 days of a week, 3 ticket prices | Lists whose size depends on the user or a file |

**Use a vector** when you don't know the size ahead of time. That is most BPA programs (the number of rows in a CSV file, the number of scores the user enters). Use an array for small fixed lists of constants. The challenge uses a `vector<int>`.

---

## Looping through a vector

There are two ways. Know both.

```cpp
#include <iostream>
#include <vector>
#include <string>
using namespace std;

int main()
{
    vector<string> colors = { "red", "green", "blue" };   // a vector can be filled when made

    // Output: counting loop - use when you need the index number
    for (size_t i = 0; i < colors.size(); i++)
    {
        cout << i << ": " << colors[i] << endl;
    }

    // Output: for-each loop - use when you only need each value
    for (string color : colors)
    {
        cout << color << " ";
    }
    cout << endl;
    return 0;
}
```

What it prints:
```
0: red
1: green
2: blue
red green blue 
```

| Loop | Read it as | Use when |
|---|---|---|
| `for (size_t i = 0; i < v.size(); i++)` | "for each index i" | You need the position, need to compare neighbors, or need to change items |
| `for (int value : v)` | "for each value in v" | You only read each value once, in order |

The for-each loop gives you a **copy** of each item. Changing `value` inside the loop does not change the vector.

### Printing with spaces between, but not at the end

The example above leaves an extra space after `blue`. When output must match exactly, print the space **before** every item except the first:

```cpp
for (size_t i = 0; i < colors.size(); i++)
{
    if (i > 0)
    {
        cout << " ";
    }
    cout << colors[i];
}
cout << endl;
```

---

## Finding the highest, lowest, and average yourself

C++ has built-in tools for these (`max_element`, `accumulate`), but **BPA graders want to see the algorithm**, and the challenge requires your own loops. Learn these three patterns.

```cpp
#include <iostream>
#include <vector>
#include <iomanip>
using namespace std;

int main()
{
    vector<int> temps = { 68, 72, 75, 71, 64 };

    // Processing: HIGHEST - start with the first item, replace it when a bigger one appears
    int warmest = temps[0];
    for (size_t i = 1; i < temps.size(); i++)
    {
        if (temps[i] > warmest)
        {
            warmest = temps[i];
        }
    }

    // Processing: AVERAGE - running total, then divide by the count
    int total = 0;
    for (int temp : temps)
    {
        total = total + temp;
    }
    double average = static_cast<double>(total) / temps.size();

    // Output
    cout << "Warmest: " << warmest << endl;
    cout << fixed << setprecision(2) << "Average: " << average << endl;
    return 0;
}
```

What it prints:
```
Warmest: 75
Average: 70.00
```

Why start with `temps[0]` instead of 0? If every value were negative (like winter temperatures), starting at 0 would wrongly report 0 as the highest. Starting with a real item is always safe. The **lowest** is the same pattern with `<` instead of `>`.

Remember the integer division trap from Step 2: `total / temps.size()` with whole numbers drops the decimals. `static_cast<double>(total)` fixes it.

---

## Counting items that match

Combine a counter (Step 4) with an `if` inside the loop:

```cpp
#include <iostream>
#include <vector>
using namespace std;

int main()
{
    vector<int> temps = { 68, 72, 75, 71, 64 };

    // Processing: count the days above 70
    int warmDays = 0;
    for (int temp : temps)
    {
        if (temp > 70)
        {
            warmDays++;
        }
    }

    // Output
    cout << "Days above 70: " << warmDays << endl;
    return 0;
}
```

What it prints:
```
Days above 70: 3
```

In the challenge, compare each score with the **average** (a `double`) instead of 70.

---

## Sorting

`sort` puts a vector in order from low to high. It needs `#include <algorithm>`. `reverse` flips the order, so `sort` then `reverse` gives high to low.

```cpp
#include <iostream>
#include <vector>
#include <algorithm>   // sort, reverse
using namespace std;

int main()
{
    vector<int> temps = { 68, 72, 75, 71, 64 };

    // Processing: sort a COPY so the original order is kept
    vector<int> sortedTemps = temps;
    sort(sortedTemps.begin(), sortedTemps.end());       // low to high
    reverse(sortedTemps.begin(), sortedTemps.end());    // flip: high to low

    // Output: original, then sorted
    for (int t : temps)
    {
        cout << t << " ";
    }
    cout << endl;
    for (int t : sortedTemps)
    {
        cout << t << " ";
    }
    cout << endl;
    return 0;
}
```

What it prints:
```
68 72 75 71 64 
75 72 71 68 64 
```

| What you type | What it means |
|---|---|
| `sort(v.begin(), v.end());` | Sort the whole vector, low to high. `begin()` and `end()` mark the start and end of the range to sort. |
| `reverse(v.begin(), v.end());` | Flip the order |
| `sort(v.begin(), v.end(), greater<int>());` | Sort high to low in one step (needs `#include <functional>`) |

`sort` **changes the vector it is given**. If you still need the original order (the challenge prints the scores in the order entered), sort a **copy**, or print the original first.

Step 8 shows how to write a sort yourself, which graders like to see.

---

## Passing a vector to a function

Write the parameter as **`const vector<int>& name`**:

```cpp
#include <iostream>
#include <vector>
using namespace std;

// Purpose: find the coldest temperature with a loop.
// Parameters: temps - the temperatures (const reference: not copied, not changed)
// Returns: the lowest value
int findColdest(const vector<int>& temps)
{
    // Processing: same pattern as the highest, with <
    int coldest = temps[0];
    for (size_t i = 1; i < temps.size(); i++)
    {
        if (temps[i] < coldest)
        {
            coldest = temps[i];
        }
    }
    return coldest;
}

int main()
{
    vector<int> week = { 68, 72, 75, 71, 64 };

    // Output: pass the vector by name, no brackets
    cout << "Coldest: " << findColdest(week) << endl;
    return 0;
}
```

What it prints:
```
Coldest: 64
```

What each piece of `const vector<int>& temps` means:
- `vector<int>` - the parameter is a vector of ints.
- `&` - pass **by reference** (Step 5). The function uses the caller's vector directly instead of copying every item. For big lists that is much faster.
- `const` - a promise that the function will **not change** the vector. If it tries, the compiler stops it.

Use `const vector<int>&` for any function that only **reads** a vector. Use `vector<int>&` (no `const`) when the function must **change** the caller's vector (Step 8's sort). In the call, just write the vector's name: `findColdest(week)`.

**Try it:** Write `int countBelow(const vector<int>& temps, int limit)` that returns how many temperatures are below `limit`.

---

## Common mistakes

**1. Index out of range**
- Looks like: `for (int i = 0; i <= temps.size(); i++)` (note `<=`), or `temps[5]` on 5 items.
- Result: a random number, a crash, or in Visual Studio Debug a box that says `vector subscript out of range`.
- Fix: the last index is `size() - 1`. Use `i < temps.size()`. Use `.at(i)` while testing to get a clear error.

**2. Using `[ ]` on an empty vector instead of `push_back`**
- Looks like: `vector<int> scores; scores[0] = 88;`
- Result: crash or `vector subscript out of range`. An empty vector has no box 0 yet.
- Fix: `scores.push_back(88);`

**3. Starting the highest at 0**
- Result: wrong answer when all values are negative.
- Fix: start with the first item, `v[0]`.

**4. Sorting the original when the order is still needed**
- Result: the `Scores:` line comes out sorted.
- Fix: sort a copy: `vector<int> sorted = scores;`

**5. Forgot `#include <vector>` or `#include <algorithm>`**
- Error: `'vector': undeclared identifier` or `'sort': identifier not found`.

**6. Signed/unsigned warning**
- Warning: `C4018 '<': signed/unsigned mismatch`.
- Fix: use `size_t i` when comparing with `size()`.

---

## How this shows up at BPA

- The 2024 regional said: read numbers from a file "and store them in a data structure of your choice." A `vector<int>` is the right choice.
- The same test required `getMean` to "take in the list of numbers" and return a `double`. That is `double getMean(const vector<int>& numbers)`, and it is the same loop as your `calculateAverage`.
- Graders give points for **algorithms** written out (finding a max, averaging, counting). Built-in shortcuts may lose those points.
- Source code review includes "creating data structures." Choosing a vector and naming it clearly counts.

---

## The challenge: Score Stats

Write a program that stores a list of scores and prints statistics about them.

**Requirements**
1. Header comment.
2. Ask `How many scores? ` (assume a whole number from 1 to 20; if it is outside that range print `Please enter 1 to 20.` and ask again).
3. Ask for each score with `Score 1: `, `Score 2: `, … and store them in a list/array.
4. Write these functions, each taking the list/array as a parameter: `findHighest`, `findLowest`, `calculateAverage`. **Use your own loop** in each — no built-in max/min/sum/average.
5. Print the results exactly as shown: all scores in the order entered, highest, lowest, average (2 decimals), how many scores are above the average, and the scores sorted high to low.
6. Function comments and Input / Processing / Output comments.

(In C++ the list is a `vector<int>`. Function names use camelCase.)

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
Sorting must not change the "Scores:" line — print that line before sorting, or sort a copy.

**Hints**
- The "ask again" for `How many scores?` is the re-ask `while` loop from Step 4.
- Each function takes `const vector<int>& scores`.
- `calculateAverage` returns a `double`. Watch out for integer division.
- A helper function like `void printScores(const vector<int>& scores)` that prints the scores with single spaces between them saves you from writing that loop twice.
- `sort` then `reverse` on a copy for the last line.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `cpp_step06`.
2. Put `step06.cpp` in it. (Visual Studio: push the whole project folder.)
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C++ step 6 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run (no extra space at the end of the score lines)
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Scores stored in a `vector<int>`
- [ ] `findHighest`, `findLowest`, `calculateAverage` each take the vector and use their own loop
- [ ] Average shows 2 decimals
- [ ] The `Scores:` line is in the order entered
- [ ] Pushed to `bpaPrep/cpp_step06`
