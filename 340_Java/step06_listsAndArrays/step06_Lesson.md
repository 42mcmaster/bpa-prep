# Step 06 — Arrays and ArrayLists (Java)

**What you'll build:** Score Stats — read a list of scores and print the highest, lowest, average, how many are above average, and the scores sorted.
**Time:** about one class period (2 hours).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Why you need lists](#why-you-need-lists)
- [Arrays](#arrays)
- [Looping through an array](#looping-through-an-array)
- [ArrayList: a list that grows](#arraylist-a-list-that-grows)
- [Wrapper types: Integer instead of int](#wrapper-types-integer-instead-of-int)
- [Looping through an ArrayList](#looping-through-an-arraylist)
- [Arrays vs ArrayLists: which to use](#arrays-vs-arraylists-which-to-use)
- [Finding the highest, lowest, and average yourself](#finding-the-highest-lowest-and-average-yourself)
- [Counting items that match](#counting-items-that-match)
- [Sorting](#sorting)
- [Passing a list to a method](#passing-a-list-to-a-method)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Score Stats](#the-challenge-score-stats)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- Arrays (`int[]`): fixed size, fast, simple
- `ArrayList<Integer>`: a list that can grow
- Why an `ArrayList` holds `Integer` and not `int` (wrapper types)
- Indexes start at 0; `.length` for arrays, `.size()` for ArrayLists
- Looping with a counting `for` loop and with a for-each loop
- Writing your own loops to find the highest, lowest, and average (graders look for this)
- Counting items that match a condition
- Sorting with `Arrays.sort` and `Collections.sort`, and reversing for high-to-low
- Passing an array or ArrayList to a method

---

## Why you need lists

So far each variable holds one value. If you need 20 scores, you don't want `score1`, `score2`, ... `score20`. A **list** holds many values under one name, and a loop can go through all of them.

Java has two kinds of lists you will use:
- An **array** has a fixed size that you choose when you create it.
- An **`ArrayList`** starts empty and grows as you add items.

---

## Arrays

```java
int[] laps = new int[4];         // an array of 4 ints, all start at 0
laps[0] = 62;                    // first item is at index 0
laps[1] = 58;
laps[2] = 60;
laps[3] = 57;                    // last item is at index 3 (length - 1)

String[] days = {"Mon", "Tue", "Wed"};   // create and fill in one line
```

| What you type | What it means |
|---|---|
| `int[] laps` | `laps` is an array of `int`. The `[]` means "array of". |
| `new int[4]` | Make room for 4 ints. Number items start at 0, Strings at `null`. |
| `{"Mon", "Tue", "Wed"}` | Make an array with these values. Size is 3. |
| `laps[0]` | The item at **index** 0 (the first one). |
| `laps.length` | How many items (4). **No parentheses** for arrays. |

**Indexes start at 0.** An array of 4 items has indexes 0, 1, 2, 3. Using index 4 crashes the program:

```
Exception in thread "main" java.lang.ArrayIndexOutOfBoundsException: Index 4 out of bounds for length 4
```

**An array's size can never change.** If you made room for 4, you can't add a fifth.

---

## Looping through an array

**Counting `for` loop** - use when you need the index (position):

```java
for (int i = 0; i < laps.length; i++) {
    System.out.println("Lap " + (i + 1) + ": " + laps[i] + " seconds");
}
```

Note `i < laps.length`, not `<=`. The last index is `length - 1`.

**For-each loop** - use when you only need the values:

```java
for (int time : laps) {
    System.out.println(time);
}
```

Read `for (int time : laps)` as "for each `int` named `time` in `laps`." Each pass, `time` holds the next value. You can't see the index, and you can't change the array this way.

```java
public class LapTimes {
    public static void main(String[] args) {
        int[] laps = {62, 58, 60, 57};

        // Output: counting loop, because we want the lap number
        for (int i = 0; i < laps.length; i++) {
            System.out.println("Lap " + (i + 1) + ": " + laps[i]);
        }

        // Processing: for-each loop, because we only need the values
        int total = 0;
        for (int time : laps) {
            total += time;
        }
        System.out.println("Total: " + total + " seconds");
    }
}
```

Output:

```
Lap 1: 62
Lap 2: 58
Lap 3: 60
Lap 4: 57
Total: 237 seconds
```

---

## ArrayList: a list that grows

```java
import java.util.ArrayList;     // at the top of the file

ArrayList<String> names = new ArrayList<>();   // an empty list of Strings
names.add("Avery");                             // add to the end
names.add("Blake");
names.add("Casey");
System.out.println(names.size());               // 3
System.out.println(names.get(0));               // Avery
names.set(1, "Bailey");                         // replace index 1
names.remove(2);                                // remove index 2 (Casey)
System.out.println(names);                      // [Avery, Bailey]
```

| What you type | What it does |
|---|---|
| `ArrayList<String> names = new ArrayList<>();` | Make an empty list that holds Strings. The type goes in `< >`. The empty `<>` on the right means "same type as the left". |
| `names.add(x)` | Add `x` to the end. The list grows by 1. |
| `names.get(i)` | The item at index `i`. (Arrays use `names[i]`; ArrayLists use `.get(i)`.) |
| `names.set(i, x)` | Replace the item at index `i` with `x`. |
| `names.remove(i)` | Remove the item at index `i`. Everything after it moves down one. |
| `names.size()` | How many items. **With parentheses** for ArrayLists. |
| `names.isEmpty()` | `true` if there are no items. |
| `names.contains(x)` | `true` if `x` is in the list (uses `.equals`). |
| `System.out.println(names)` | Prints the whole list like `[Avery, Bailey]` - handy for testing, but not the format BPA output usually wants. |

Indexes still start at 0. A bad index crashes with `IndexOutOfBoundsException`.

---

## Wrapper types: Integer instead of int

An `ArrayList` can only hold **objects**, not primitive types. So you can't write `ArrayList<int>`. Each primitive type has a matching **wrapper class** that is an object:

| Primitive | Wrapper class to use in `< >` |
|---|---|
| `int` | `Integer` |
| `double` | `Double` |
| `boolean` | `Boolean` |
| `char` | `Character` |

```java
ArrayList<Integer> temps = new ArrayList<>();   // correct
ArrayList<int> temps = new ArrayList<>();       // ERROR: unexpected type ... required: reference, found: int
```

Java converts between `int` and `Integer` for you automatically (this is called **autoboxing**), so you can mostly forget about it:

```java
temps.add(72);              // the int 72 is wrapped into an Integer
int first = temps.get(0);   // the Integer is unwrapped back into an int
```

One warning: compare `Integer` values from a list by storing them in `int` variables first, or use `.equals()`. `temps.get(0) == temps.get(1)` can be `false` for big numbers even when they are equal, because `==` compares objects (the same reason as Strings in Step 3).

---

## Looping through an ArrayList

Both loop styles work:

```java
// Counting loop: .size() and .get(i)
for (int i = 0; i < temps.size(); i++) {
    System.out.println("Day " + (i + 1) + ": " + temps.get(i));
}

// For-each loop
for (int t : temps) {
    System.out.println(t);
}
```

Reading values into an ArrayList with a loop:

```java
import java.util.ArrayList;
import java.util.Scanner;

public class TempLog {
    public static void main(String[] args) {
        Scanner keyboard = new Scanner(System.in);
        ArrayList<Integer> temps = new ArrayList<>();

        // Input: 3 temperatures into the list
        for (int day = 1; day <= 3; day++) {
            System.out.print("Day " + day + " high: ");
            temps.add(Integer.parseInt(keyboard.nextLine()));
        }

        // Output: print them all on one line, separated by spaces
        System.out.print("Highs:");
        for (int t : temps) {
            System.out.print(" " + t);
        }
        System.out.println();
        keyboard.close();
    }
}
```

Sample run:

```
Day 1 high: 71
Day 2 high: 65
Day 3 high: 78
Highs: 71 65 78
```

Printing a space **before** each value (after a label that has no trailing space) is one easy way to avoid an extra space at the end of the line.

---

## Arrays vs ArrayLists: which to use

| | Array `int[]` | ArrayList `ArrayList<Integer>` |
|---|---|---|
| Size | Fixed when created | Grows and shrinks |
| Get an item | `a[i]` | `list.get(i)` |
| Change an item | `a[i] = x;` | `list.set(i, x);` |
| Add an item | Can't | `list.add(x);` |
| How many | `a.length` | `list.size()` |
| Holds | Primitives or objects | Objects only (`Integer`, not `int`) |
| Sort | `Arrays.sort(a);` | `Collections.sort(list);` |
| Use when | You know the size ahead of time (3 rounds, 12 months) | You don't know how many items there will be, or items get added later |

In this challenge you could use either, because you know the count after the first question. The challenge uses an **`ArrayList<Integer>`** so you practice it - it is what BPA programs usually use for a list of records.

---

## Finding the highest, lowest, and average yourself

Java has shortcuts like `Collections.max(list)`, but **graders look for the algorithm** - the loop you write yourself. The challenge requires your own loops.

**Highest (maximum):** start with the first item, then compare every item to the best so far.

```java
int highest = temps.get(0);       // assume the first one is the highest
for (int t : temps) {
    if (t > highest) {
        highest = t;              // found a bigger one
    }
}
```

Why start with the first item and not 0? If every value were negative, starting at 0 would give the wrong answer. Starting with a real item from the list is always safe.

**Lowest (minimum):** the same, with `<`.

**Average:** add them up with a running total, then divide by the count. Remember the [whole-number division trap](../step02_variablesAndInput/step02_Lesson.md#the-whole-number-division-trap) from Step 2:

```java
int total = 0;
for (int t : temps) {
    total += t;
}
double average = (double) total / temps.size();   // (double) so 214 / 3 = 71.33..., not 71
```

---

## Counting items that match

Use a counter (Step 4) and an `if`:

```java
int hotDays = 0;
for (int t : temps) {
    if (t >= 75) {
        hotDays++;
    }
}
```

---

## Sorting

Java can sort for you. (Sorting by hand comes in Step 8.)

```java
import java.util.Arrays;
import java.util.Collections;

int[] laps = {62, 58, 60, 57};
Arrays.sort(laps);                    // laps is now 57 58 60 62 (low to high)

ArrayList<Integer> temps = ...;       // 71 65 78
Collections.sort(temps);              // 65 71 78 (low to high)
Collections.reverse(temps);           // 78 71 65 (now high to low)
```

| What you type | What it does |
|---|---|
| `Arrays.sort(array)` | Sorts an array low to high. Needs `import java.util.Arrays;` |
| `Collections.sort(list)` | Sorts an ArrayList low to high. Needs `import java.util.Collections;` |
| `Collections.reverse(list)` | Reverses the order. After sorting, this gives high to low. |

**Sorting changes the list itself.** If you still need the original order, sort a **copy**:

```java
ArrayList<Integer> sorted = new ArrayList<>(temps);   // a new list with the same items
Collections.sort(sorted);
// temps is still in the original order
```

`new ArrayList<>(temps)` makes a new, separate list. Writing `ArrayList<Integer> sorted = temps;` does **not** copy - both names point at the same list, and sorting one sorts "both".

**Try it:**
1. Put 5 test scores in an `ArrayList<Integer>`, sort a copy high to low, and print both lists.
2. Print only the top 3 from the sorted copy using a `for` loop.

---

## Passing a list to a method

Arrays and ArrayLists can be parameters, just like numbers:

```java
import java.util.ArrayList;

public class ListMethods {

    /*
     * Purpose: add up all the values in a list.
     * Parameters: values - the list of numbers
     * Returns: the total
     */
    static int sumList(ArrayList<Integer> values) {
        int total = 0;
        for (int v : values) {
            total += v;
        }
        return total;
    }

    /*
     * Purpose: add up all the values in an array.
     * Parameters: values - the array of numbers
     * Returns: the total
     */
    static int sumArray(int[] values) {
        int total = 0;
        for (int i = 0; i < values.length; i++) {
            total += values[i];
        }
        return total;
    }

    public static void main(String[] args) {
        ArrayList<Integer> steps = new ArrayList<>();
        steps.add(8000);
        steps.add(6500);
        steps.add(10200);
        int[] pages = {12, 30, 8};

        System.out.println("Steps: " + sumList(steps));
        System.out.println("Pages: " + sumArray(pages));
    }
}
```

Output:

```
Steps: 24700
Pages: 50
```

The parameter type is written the same way as the variable type: `ArrayList<Integer> values` or `int[] values`.

**Methods can change the list.** Unlike a number, when you pass a list to a method, the method gets the **same** list, not a copy. If the method sorts it or adds to it, the caller sees the change. That is why you sort a copy in the challenge.

---

## Common mistakes

**1. Index out of bounds**
- Looks like: `for (int i = 0; i <= list.size(); i++)`
- Error: `java.lang.IndexOutOfBoundsException: Index 5 out of bounds for length 5`
- Fix: use `<`, not `<=`. The last index is `size() - 1`.

**2. `ArrayList<int>`**
- Error: `error: unexpected type ... required: reference ... found: int`
- Fix: `ArrayList<Integer>`.

**3. `.length` vs `.size()` vs `.length()`**
- Arrays: `a.length` (no parentheses). ArrayLists: `list.size()`. Strings: `s.length()` (with parentheses).
- Error: `error: cannot find symbol ... symbol: method length()` or `symbol: variable size`.
- Fix: use the right one for the type.

**4. `list[i]` on an ArrayList**
- Error: `error: array required, but ArrayList<Integer> found`
- Fix: `list.get(i)`.

**5. Forgetting the imports**
- Error: `error: cannot find symbol ... symbol: class ArrayList`
- Fix: `import java.util.ArrayList;` (and `java.util.Collections` for sorting).

**6. Sorting the original list**
- Looks like: the "Scores:" line comes out sorted.
- Fix: print first, or sort a copy made with `new ArrayList<>(scores)`.

**7. Average is a whole number**
- Looks like: `Average: 81.00` instead of `81.40`.
- Fix: `(double) total / scores.size()`.

**8. Extra space at the end of a line**
- Looks like: `"Scores: 88 92 75 92 60 "` (with a trailing space). It is hard to see but does not match exactly.
- Fix: print the space before each item, or only print a space when `i > 0`.

---

## How this shows up at BPA

- The 2024 Java regional asked for student records to be "stored in a data structure" (an ArrayList of objects) and gave points for it. You will build lists of objects in Step 11.
- Finding the highest/lowest/total with your own loop is a standard graded algorithm.
- Averages formatted to 2 decimal places come up on every test.
- Passing the list to a method shows graders you understand both data structures and methods.

---

## The challenge: Score Stats

Write a program that reads several scores and prints statistics about them.

**Requirements**
1. Header comment.
2. Ask `How many scores? ` (assume a whole number from 1 to 20; if it is outside that range print `Please enter 1 to 20.` and ask again).
3. Ask for each score with `Score 1: `, `Score 2: `, … and store them in a list/array. (In Java: an `ArrayList<Integer>`.)
4. Write these methods, each taking the list as a parameter: `findHighest`, `findLowest`, `calculateAverage`. **Use your own loop** in each — no built-in max/min/sum/average.
5. Print the results exactly as shown: all scores in the order entered, highest, lowest, average (2 decimals), how many scores are above the average, and the scores sorted high to low.
6. Method comments and Input / Processing / Output comments.

**Sample run (exact):**
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
(Sorting must not change the "Scores:" line — print that line before sorting, or sort a copy.)

**Hints**
- Class `Step06` in `Step06.java`. Imports: `ArrayList`, `Collections`, `Scanner`.
- Method headers: `static int findHighest(ArrayList<Integer> scores)`, `static int findLowest(ArrayList<Integer> scores)`, `static double calculateAverage(ArrayList<Integer> scores)`.
- The range check on "How many scores?" is the Step 4 "ask again" loop.
- A small helper method `printScores(String label, ArrayList<Integer> scores)` saves you from writing the "print on one line" loop twice.
- "Above average" means **greater than** the average (81.40): 88, 92, and 92.

---

## Turn it in
1. In your `bpaPrep` repo make a folder `java_step06`.
2. Put `Step06.java` in it.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *Java step 6 done*.

---

## Checklist
- [ ] Program runs with no errors
- [ ] Output matches the sample run
- [ ] Header comment with name, date, program, description
- [ ] Input / Processing / Output comments
- [ ] Scores stored in an `ArrayList<Integer>`
- [ ] `findHighest`, `findLowest`, `calculateAverage` each use your own loop and take the list as a parameter
- [ ] Average printed with 2 decimals
- [ ] "Scores:" line is in the original order; sorted line is high to low
- [ ] Every method has a purpose / parameters / returns comment
- [ ] Pushed to `bpaPrep/java_step06`
