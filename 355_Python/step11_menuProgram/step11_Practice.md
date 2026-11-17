# Step 11 Practice — Menu Programs and Classes (Python)

**Do these after the [Step 11 lesson](step11_Lesson.md).** Each problem is short and uses one idea from the lesson.

**Time:** about one class period for Problems 1–11. The Challenge at the end takes longer.

**Need help?** Use the [Step 11 Study Guide](step11_StudyGuide.md). Every problem lists the study guide section that shows how.

Problems marked **(review)** use skills from earlier steps, so you keep practicing them.

## Table of Contents
- [Rules for every problem](#rules-for-every-problem)
- [Problem 1: A simple menu](#problem-1-a-simple-menu)
- [Problem 2: A counter menu](#problem-2-a-counter-menu)
- [Problem 3: A crash-proof menu](#problem-3-a-crash-proof-menu)
- [Problem 4: One function per option](#problem-4-one-function-per-option)
- [Problem 5: A Pet class](#problem-5-a-pet-class)
- [Problem 6: A method that changes the object](#problem-6-a-method-that-changes-the-object)
- [Problem 7: A method that returns a value](#problem-7-a-method-that-returns-a-value)
- [Problem 8: Print an object nicely](#problem-8-print-an-object-nicely)
- [Problem 9: A list of objects](#problem-9-a-list-of-objects)
- [Problem 10: Find an object](#problem-10-find-an-object)
- [Problem 11: Best in the list](#problem-11-best-in-the-list)
- [Challenge: Snack Stand Manager](#challenge-snack-stand-manager)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

---

## Rules for every problem

1. Put each problem in its own file: `step11_p01.py`, `step11_p02.py`, and so on.
2. Start each file with a header comment (name, date, program name).
3. Every function, method, and class gets a comment.
4. Use the **exact** prompts and output shown. Same words, same spaces.
5. Run your program with the sample input and compare your output to the sample run, line by line.

---

## Problem 1: A simple menu
Write a menu with three choices: `1. Say hello`, `2. Say goodbye`, `3. Quit`. It repeats until the user picks 3.

**Sample run**
```
1. Say hello  2. Say goodbye  3. Quit
Choose: 1
Hello!
1. Say hello  2. Say goodbye  3. Quit
Choose: 2
Goodbye!
1. Say hello  2. Say goodbye  3. Quit
Choose: 3
Program ended.
```

**Hint:** Start with `choice = 0` so the loop runs the first time.

**Study guide:** [The menu loop](step11_StudyGuide.md#the-menu-loop)

---

## Problem 2: A counter menu
*(review: Step 4 counters)*

Write a menu that keeps a count: `1. Add one`, `2. Show count`, `3. Quit`.

**Sample run**
```
1. Add one  2. Show count  3. Quit
Choose: 1
1. Add one  2. Show count  3. Quit
Choose: 1
1. Add one  2. Show count  3. Quit
Choose: 2
Count: 2
1. Add one  2. Show count  3. Quit
Choose: 1
1. Add one  2. Show count  3. Quit
Choose: 3
Final count: 3
```

**Hint:** `count = 0` goes before the loop, so it isn't reset every time.

**Study guide:** [The menu loop](step11_StudyGuide.md#the-menu-loop)

---

## Problem 3: A crash-proof menu
*(review: Step 10 get_int)*

Rewrite Problem 1 using `get_int` from Step 10 for the choice, so letters and numbers out of range can't crash it.

**Sample run**
```
1. Say hello  2. Say goodbye  3. Quit
Choose: one
Please enter a whole number from 1 to 3.
Choose: 7
Please enter a whole number from 1 to 3.
Choose: 1
Hello!
1. Say hello  2. Say goodbye  3. Quit
Choose: 3
Program ended.
```

**Hints**
- Copy your `get_int` from Step 10.
- Since `get_int` only returns 1 to 3, you don't need an `else` for bad choices.

**Study guide:** [The menu loop](step11_StudyGuide.md#the-menu-loop)

---

## Problem 4: One function per option
Write a menu for a club: `1. Meeting time`, `2. Club advisor`, `3. Quit`. Each of the first two options calls its own function. Put the menu in `main()`.

**Sample run**
```
1. Meeting time  2. Club advisor  3. Quit
Choose: 2
The advisor is Mr. McMaster.
1. Meeting time  2. Club advisor  3. Quit
Choose: 1
Meetings are Tuesdays at 2:45.
1. Meeting time  2. Club advisor  3. Quit
Choose: 3
Bye!
```

**Hint:** The `if`/`elif` chain only calls the functions. The printing happens inside them.

**Study guide:** [One function per menu option](step11_StudyGuide.md#one-function-per-menu-option)

---

## Problem 5: A Pet class
Write a class `Pet` with a constructor that saves a `name` and a `species`. Make two pets and print each one.

**Sample run**
```
Biscuit is a dog.
Smokey is a cat.
```

**Hints**
- `__init__` has two underscores on each side, and `self` comes first.
- Make an object with `Pet("Biscuit", "dog")`. Don't pass `self`.

**Study guide:** [Writing a class](step11_StudyGuide.md#writing-a-class)

---

## Problem 6: A method that changes the object
Write a class `PiggyBank` with a `balance` that starts at 0, and a method `deposit(amount)` that adds to it. Make a piggy bank, deposit 3 times, and print the balance.

**Sample run**
```
Balance: $17.75
```

**Hints**
- The constructor can set an attribute without a parameter: `self.balance = 0.0`.
- Call the method with a dot: `bank.deposit(5.00)`.

**Study guide:** [Methods](step11_StudyGuide.md#methods)

---

## Problem 7: A method that returns a value
Write a class `Rectangle` with a `width` and `height`, and a method `area()` that returns the area. Ask for the size, make the object, and print the area.

**Sample run**
```
Width: 12
Height: 10.5
Area: 126.0
```

**Hints**
- A method can `return` a value, just like a function.
- Inside the method, use `self.width` and `self.height`.

**Study guide:** [Methods](step11_StudyGuide.md#methods)

---

## Problem 8: Print an object nicely
Write a class `Book` with a `title` and `author`, and a `__str__` method that returns `Title by Author`. Then `print()` two books.

**Sample run**
```
Hatchet by Gary Paulsen
Holes by Louis Sachar
```

**Hints**
- `__str__` must **return** a string, not print it.
- Then `print(book)` uses that string automatically.

**Study guide:** [Printing an object with str](step11_StudyGuide.md#printing-an-object-with-str)

---

## Problem 9: A list of objects
*(review: Step 6 totals)*

Use a `Student` class with a `name` and a `grade`. Put three students in a list, print each one, and print the average grade.

**Sample run**
```
Avery     92
Blake     78
Casey     85
Average: 85.0
```

**Hints**
- `for student in roster:` gives you one object at a time.
- Use `student.grade` in the running total.

**Study guide:** [A list of objects](step11_StudyGuide.md#a-list-of-objects)

---

## Problem 10: Find an object
*(review: Step 7 .lower())*

Use the same three students. Ask for a name and print that student's grade. The search should ignore capitals. If there's no match, print `No student by that name.`

**Sample run 1**
```
Find student: BLAKE
Blake's grade: 78
```

**Sample run 2**
```
Find student: Devon
No student by that name.
```

**Hints**
- Compare `student.name.lower()` to the lowercase search.
- Use a True/False variable to remember if you found one.

**Study guide:** [Searching ignoring upper and lower case](step11_StudyGuide.md#searching-ignoring-upper-and-lower-case)

---

## Problem 11: Best in the list
*(review: Step 6 finding the highest)*

Use the same three students. Find the student with the highest grade (your own loop, not `max()`).

**Sample run**
```
Top student: Avery (92)
```

**Hint:** Start `best` at the first **object**, `roster[0]`, then compare `.grade`.

**Study guide:** [A list of objects](step11_StudyGuide.md#a-list-of-objects)

---

## Challenge: Snack Stand Manager
This one puts the pieces together: a class with a method, a list of objects, a crash-proof menu, and one function per option.

**Requirements**
1. Header comment, Input / Processing / Output comments, and a `main()` function.
2. Copy `get_int` from Step 10, and use it for every number the user types.
3. Write a class `Snack` with `name`, `price`, and `stock`, and a method `sell(amount)`. If there are enough, it takes them out of stock and returns `True`. If not, it changes nothing and returns `False`.
4. In `main()`, start with these snacks: Chips $1.50 (10 left), Pretzels $1.25 (4 left), Cookies $2.00 (8 left).
5. Write `show_snacks(snacks)` and `sell_snack(snacks)`, one function per menu option.
6. Print everything exactly as shown. In the snack list, the name is 10 wide, left-aligned.

**Sample run**
```

--- SNACK STAND ---
1. Show snacks
2. Sell a snack
3. Quit
Choose (1-3): 2
1. Chips     $1.50  (10 left)
2. Pretzels  $1.25  (4 left)
3. Cookies   $2.00  (8 left)
Which snack? (1-3): 2
How many? (1-20): 6
Only 4 Pretzels left.

--- SNACK STAND ---
1. Show snacks
2. Sell a snack
3. Quit
Choose (1-3): 2
1. Chips     $1.50  (10 left)
2. Pretzels  $1.25  (4 left)
3. Cookies   $2.00  (8 left)
Which snack? (1-3): 2
How many? (1-20): 3
Sold 3 Pretzels for $3.75

--- SNACK STAND ---
1. Show snacks
2. Sell a snack
3. Quit
Choose (1-3): 1
1. Chips     $1.50  (10 left)
2. Pretzels  $1.25  (1 left)
3. Cookies   $2.00  (8 left)

--- SNACK STAND ---
1. Show snacks
2. Sell a snack
3. Quit
Choose (1-3): x
Please enter a whole number from 1 to 3.
Choose (1-3): 3
Stand closed.
```

**Hints**
- The menu loop is Part 1 of the lesson, with `get_int` for the choice.
- `sell_snack` calls `show_snacks` first, so the user can see the numbers.
- The user picks 1 to 3, but the list index is 0 to 2. Use `snacks[pick - 1]`.

**Study guide:** [Putting it together: a small menu program](step11_StudyGuide.md#putting-it-together-a-small-menu-program)

---

## Turn it in
1. In your `bpaPrep` repo, use your `python_step11` folder.
2. Save the problems as `step11_p01.py` through `step11_p11.py`, and the challenge as `step11_challenge.py`.
3. Commit and push with GitHub Desktop.
4. Turn in the link on the Classroom assignment.

## Checklist
- [ ] Every program runs with no errors
- [ ] Every sample run matches exactly (count the spaces)
- [ ] Header comment in every file
- [ ] One problem per file, named the way the list says
- [ ] Pushed to `bpaPrep/python_step11`
