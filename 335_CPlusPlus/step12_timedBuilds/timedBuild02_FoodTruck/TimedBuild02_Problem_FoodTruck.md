# BPA 335 C++ — Timed Build 2: Food Truck Sales

**Time: 90 minutes. Individual. Contest conditions — your own IDE only, no online compilers, no AI.**

This task is the same size and shape as a real regional: a menu program with a class, a data file, validated input, a formatted table, and a dated report file.

## Setup (do this exactly — it's graded)

1. Create a folder named with your Contestant ID (for practice, a Visual Studio Console App project named `cpp_timed02` inside your `bpaPrep` repo).
2. The source file must be named **`TimedBuild02_FoodTruck.cpp`** — all your code goes in this one file. (Start from `TimedBuild02_FoodTruck_starter.cpp`.)
3. Put **`sales.csv`** in the project folder, and also next to the `.exe` after your first build. Open it with a **relative path** (`"sales.csv"`), never a full path like `C:\Users\...`.
4. Put your Contestant ID as a **comment at the top** of the file.
5. Submit the whole project folder, including the `.exe`.

## The scenario

A food truck sells five items. The owner keeps a running count of how many of each item have been sold in `sales.csv`. Your program loads that file, lets the owner look at the numbers, record new sales, and save a report.

`sales.csv` (given — do not change it):

```
Item,Price,Quantity
Taco,3.50,42
Burrito,7.25,30
Nachos,5.00,18
Quesadilla,6.75,25
Churro,2.25,40
```

## Requirement 1 — Class (graded in Source Code Review)

Write a class named **`FoodItem`** with:
- Fields `name` (string), `price` (double), and `quantity` (int).
- A constructor with the parameters name, price, quantity.
- A method **`getRevenue()`** that returns `price × quantity`.
- A method **`addSale(amount)`** that adds `amount` to the quantity.

## Requirement 2 — Load the data

- When the program starts, read `sales.csv`. Skip the header line. Make one `FoodItem` object per line and store them in a **`vector<FoodItem>`**.
- Print `Loaded 5 items from sales.csv` (use the real count).
- If the file is missing, print `Error: could not find sales.csv` and end the program **without crashing**.

## Requirement 3 — Menu

Print a blank line and then this menu. Repeat it until the user chooses 6.

```
===== FOOD TRUCK SALES =====
1. Show sales table
2. Add a sale
3. Best sellers
4. Search for an item
5. Save report
6. Quit
```

Prompt: `Choose an option (1-6): `
- The choice must be a whole number from 1 to 6. On anything else (letters, decimals like `2.5`, blanks, negatives, 0, 7+) print `Please enter a whole number from 1 to 6.` and ask again. **The program must not crash.**
- Each menu option must be its **own function**.

## Requirement 4 — Option 1: Show sales table

Print the table in exactly this format. Columns: Item (12 wide, left), Price (8 wide, left, as money), Qty (6 wide, left), Revenue (as money). A line of 33 dashes under the header. The last row is **TOTAL** with the total quantity and total revenue.

```
Item        Price   Qty   Revenue
---------------------------------
Taco        $3.50   42    $147.00
Burrito     $7.25   30    $217.50
Nachos      $5.00   18    $90.00
Quesadilla  $6.75   25    $168.75
Churro      $2.25   40    $90.00
TOTAL               155   $713.25
```

## Requirement 5 — Option 2: Add a sale

- List the items numbered, with their price: `1. Taco ($3.50)` …
- Ask `Choose an item (1-5): ` and `Quantity sold (1-100): `. Both must be whole numbers in range. On a bad entry print `Please enter a whole number from <low> to <high>.` and ask again.
- Call the item's `addSale` method, then print `Added <amount> <item>. <item> quantity is now <new quantity>.`

## Requirement 6 — Option 3: Best sellers

Print the item with the highest revenue and the item with the highest quantity. If two items tie, the one that comes first in the list wins. Write the search loops yourself.

```
Highest revenue: Burrito ($217.50)
Highest quantity: Taco (42 sold)
```

## Requirement 7 — Option 4: Search for an item

- Ask `Search for: ` (cannot be blank — print `This cannot be blank.` and ask again).
- Print every item whose name **contains** the search text, **ignoring upper/lower case**, like `Quesadilla - $6.75 each, 25 sold`.
- If nothing matches, print `No items match "<text>".`

## Requirement 8 — Option 5: Save report

- Write **`sales_report.txt`** with these lines: `FOOD TRUCK SALES REPORT`, `Report created: yyyy-MM-dd HH:mm` (the real date and time, using `<ctime>` and `put_time`), a blank line, the sales table, a blank line, and the two best-seller lines.
- Use a `try`/`catch` (with the stream's `exceptions()` turned on) so a write error prints `Error: could not save sales_report.txt` instead of crashing.
- On success print `Report saved to sales_report.txt`.

## Requirement 9 — Option 6: Quit

Print `Goodbye!` and end the program.

## Sample run (exact)

The user's typed answers are shown after each prompt. This run adds 15 Burritos, so the numbers change after that.

```
Loaded 5 items from sales.csv

===== FOOD TRUCK SALES =====
1. Show sales table
2. Add a sale
3. Best sellers
4. Search for an item
5. Save report
6. Quit
Choose an option (1-6): 1
Item        Price   Qty   Revenue
---------------------------------
Taco        $3.50   42    $147.00
Burrito     $7.25   30    $217.50
Nachos      $5.00   18    $90.00
Quesadilla  $6.75   25    $168.75
Churro      $2.25   40    $90.00
TOTAL               155   $713.25

===== FOOD TRUCK SALES =====
1. Show sales table
2. Add a sale
3. Best sellers
4. Search for an item
5. Save report
6. Quit
Choose an option (1-6): 3
Highest revenue: Burrito ($217.50)
Highest quantity: Taco (42 sold)

===== FOOD TRUCK SALES =====
1. Show sales table
2. Add a sale
3. Best sellers
4. Search for an item
5. Save report
6. Quit
Choose an option (1-6): 2
1. Taco ($3.50)
2. Burrito ($7.25)
3. Nachos ($5.00)
4. Quesadilla ($6.75)
5. Churro ($2.25)
Choose an item (1-5): 6
Please enter a whole number from 1 to 5.
Choose an item (1-5): 2.5
Please enter a whole number from 1 to 5.
Choose an item (1-5): -3
Please enter a whole number from 1 to 5.
Choose an item (1-5): 2
Quantity sold (1-100): abc
Please enter a whole number from 1 to 100.
Quantity sold (1-100): 0
Please enter a whole number from 1 to 100.
Quantity sold (1-100): 15
Added 15 Burrito. Burrito quantity is now 45.

===== FOOD TRUCK SALES =====
1. Show sales table
2. Add a sale
3. Best sellers
4. Search for an item
5. Save report
6. Quit
Choose an option (1-6): 1
Item        Price   Qty   Revenue
---------------------------------
Taco        $3.50   42    $147.00
Burrito     $7.25   45    $326.25
Nachos      $5.00   18    $90.00
Quesadilla  $6.75   25    $168.75
Churro      $2.25   40    $90.00
TOTAL               170   $822.00

===== FOOD TRUCK SALES =====
1. Show sales table
2. Add a sale
3. Best sellers
4. Search for an item
5. Save report
6. Quit
Choose an option (1-6): 3
Highest revenue: Burrito ($326.25)
Highest quantity: Burrito (45 sold)

===== FOOD TRUCK SALES =====
1. Show sales table
2. Add a sale
3. Best sellers
4. Search for an item
5. Save report
6. Quit
Choose an option (1-6): 4
Search for: QUES
Quesadilla - $6.75 each, 25 sold

===== FOOD TRUCK SALES =====
1. Show sales table
2. Add a sale
3. Best sellers
4. Search for an item
5. Save report
6. Quit
Choose an option (1-6): 4
Search for: zz
No items match "zz".

===== FOOD TRUCK SALES =====
1. Show sales table
2. Add a sale
3. Best sellers
4. Search for an item
5. Save report
6. Quit
Choose an option (1-6): 5
Report saved to sales_report.txt

===== FOOD TRUCK SALES =====
1. Show sales table
2. Add a sale
3. Best sellers
4. Search for an item
5. Save report
6. Quit
Choose an option (1-6): 9
Please enter a whole number from 1 to 6.
Choose an option (1-6): 6
Goodbye!
```

**`sales_report.txt` from that run (your date and time will be different):**

```
FOOD TRUCK SALES REPORT
Report created: 2026-11-13 09:42

Item        Price   Qty   Revenue
---------------------------------
Taco        $3.50   42    $147.00
Burrito     $7.25   45    $326.25
Nachos      $5.00   18    $90.00
Quesadilla  $6.75   25    $168.75
Churro      $2.25   40    $90.00
TOTAL               170   $822.00

Highest revenue: Burrito ($326.25)
Highest quantity: Burrito (45 sold)
```

## Development standards (graded in Source Code Review)

- camelCase naming for variables and functions, PascalCase for the class, consistent throughout. No global variables (constants are fine).
- Each menu option in its own function; each function has a comment block with its **purpose, parameters, and return value**.
- **Input / Processing / Output comments** on each major block.
- **`#SC` comment flags** on the five parts listed in the rubric (for example `// #SC1 FoodItem class`). Graders use the flags to find the code. No flag, no credit.
- Relative file paths only.

## Assumptions you may make

- `sales.csv` is always in the format shown when it exists.
- Console application only.
- The program does not need to save changes back to `sales.csv` (only the report).
- Money is shown with a `$` and 2 decimal places everywhere.

**A starter file is provided (`TimedBuild02_FoodTruck_starter.cpp`). If it does not run when time is up, the Program Execution section scores zero — always keep a runnable version.**
