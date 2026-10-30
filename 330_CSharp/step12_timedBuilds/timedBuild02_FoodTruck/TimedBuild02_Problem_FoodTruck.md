# BPA 330 C# — Timed Build 2: Food Truck Sales

**Time: 90 minutes. Individual. Contest conditions — Visual Studio, printed references only, no internet, no AI.**

This task is the same shape as the 2026 C# regional: a Windows Form is already built for you, every button's Click method already exists, and you write the code behind them. It also needs a class, a data file, validated input, a formatted table, and a dated report file. The Python, C++, and Java students build the same program as a console menu; your buttons do the same jobs with the same wording.

## Setup (do this exactly — it's graded)

1. Create a **Windows Forms App** (C#, .NET 8) named **`TimedBuild02`** in a folder named with your Contestant ID. For practice, use the folder `csharp_timed02` inside your `bpaPrep` repo.
2. Close the Form1 designer tab. In File Explorer, replace the project's `Form1.cs` and `Form1.Designer.cs` with the two files from the [starter](starter/) folder. Back in Visual Studio, open `Form1.cs [Design]` — you should see the form below. (This is the "pre-built form" the regional gives you.)
3. Add **`sales.csv`** to the project (right-click the project → Add → Existing Item, file type **All Files**) and set **Copy to Output Directory** to **Copy if newer**. Open it in code with a **relative path** (`"sales.csv"`).
4. Put your Contestant ID in a **comment at the top of `Form1.cs`**.

If the starter files won't load, you can build the form yourself from the sketch and the control table. The control names must match exactly.

## The scenario

A food truck sells five items. The owner keeps a running count of how many of each item have been sold in `sales.csv`. Your program loads that file, lets the owner look at the numbers, record new sales, and save a report.

`sales.csv` (given — do not change it):

```text
Item,Price,Quantity
Taco,3.50,42
Burrito,7.25,30
Nachos,5.00,18
Quesadilla,6.75,25
Churro,2.25,40
```

## The form (already built in the starter)

```text
+--------------------------------------------------------------------------+
| Food Truck Sales                                                    [X]  |
+--------------------------------------------------------------------------+
| lbl_Status (status messages)                                             |
|                                                                          |
| "Sales table"                                                            |
| +-----------------------------------------+  [ btn_ShowTable       ]     |
| | lst_Sales  (Font: Consolas)             |  [ btn_BestSellers     ]     |
| |                                         |  [ btn_SaveReport      ]     |
| |                                         |  [ btn_TestAll (bonus) ]     |
| |                                         |  "Items"                     |
| +-----------------------------------------+  +---------------------+     |
| "Choose an item (1-5):"  [txt_ItemNumber]    | lst_Items           |     |
|                                [ btn_AddSale ]| 1. Taco ($3.50)     |     |
| "Quantity sold (1-100):" [txt_Quantity  ]    | 2. Burrito ($7.25)  |     |
|                                              | ...                 |     |
| lbl_BestRevenue    "Highest revenue:"        |                     |     |
| lbl_BestQuantity   "Highest quantity:"       +---------------------+     |
|                                                                          |
| "Search for:" [txt_Search ] [ btn_Search ]                               |
| +-----------------------------------------+                              |
| | lst_Results                             |  [ btn_Quit            ]     |
| +-----------------------------------------+                              |
+--------------------------------------------------------------------------+
```

| Control | (Name) | Text | Used for |
|---|---|---|---|
| Label | `lbl_Status` | (empty) | load message, confirmations |
| ListBox | `lst_Sales` | — | Option 1: the sales table (Font Consolas) |
| ListBox | `lst_Items` | — | the numbered item list, filled when the form loads |
| TextBox | `txt_ItemNumber` | — | Option 2: item number |
| TextBox | `txt_Quantity` | — | Option 2: quantity sold |
| Label | `lbl_BestRevenue`, `lbl_BestQuantity` | `Highest revenue:`, `Highest quantity:` | Option 3 |
| TextBox | `txt_Search` | — | Option 4: search text |
| ListBox | `lst_Results` | — | Option 4: search results |
| Button | `btn_ShowTable` | `Show Sales Table` | Option 1 |
| Button | `btn_AddSale` | `Add Sale` | Option 2 |
| Button | `btn_BestSellers` | `Best Sellers` | Option 3 |
| Button | `btn_Search` | `Search` | Option 4 |
| Button | `btn_SaveReport` | `Save Report` | Option 5 |
| Button | `btn_Quit` | `Quit` | Option 6 |
| Button | `btn_TestAll` | `Test All (bonus)` | Bonus |

The Click methods (`btn_ShowTable_Click` and so on) and `Form1_Load` already exist in the starter and are wired to the buttons. **Do not rename them.**

## Requirement 1 — Class (graded in Source Code Review)

Add a class file **`FoodItem.cs`** (Project → Add Class) with a public class **`FoodItem`**:
- Properties `Name` (string), `Price` (decimal), `Quantity` (int).
- A constructor with the parameters `name`, `price`, `quantity`.
- A method **`GetRevenue()`** that returns `Price × Quantity`.
- A method **`AddSale(int amount)`** that adds `amount` to `Quantity`.

## Requirement 2 — Load the data (`Form1_Load`)

- Read `sales.csv`. Skip the header line. Make one `FoodItem` object per line and store them in a **`List<FoodItem>`** field.
- Show `Loaded 5 items from sales.csv` (use the real count) in `lbl_Status`.
- Fill `lst_Items` with one line per item, numbered, with the price: `1. Taco ($3.50)` …
- If the file is missing, show `Error: could not find sales.csv` in a `MessageBox` **without crashing**. (The console versions end the program here. On a form, leave it open — the other buttons must not crash with an empty list; they can show `No items loaded.`)

## Requirement 3 — The buttons

Each menu option from the console version is one button. Each Click method is its own method; put shared work (the table, the best sellers, the number check) in helper methods.
- Every whole number typed in a text box must be checked. On anything else (letters, decimals like `2.5`, blanks, negatives, out of range) show `Please enter a whole number from <low> to <high>.` in a `MessageBox`. **The program must not crash.**

## Requirement 4 — Option 1: Show Sales Table

Fill `lst_Sales` with the table in exactly this format. Columns: Item (12 wide, left), Price (8 wide, left, as money), Qty (6 wide, left), Revenue (as money). A line of 33 dashes under the header. The last row is **TOTAL** with the total quantity and total revenue.

```text
Item        Price   Qty   Revenue
---------------------------------
Taco        $3.50   42    $147.00
Burrito     $7.25   30    $217.50
Nachos      $5.00   18    $90.00
Quesadilla  $6.75   25    $168.75
Churro      $2.25   40    $90.00
TOTAL               155   $713.25
```

## Requirement 5 — Option 2: Add Sale

- The item number comes from `txt_ItemNumber` (1–5) and the quantity from `txt_Quantity` (1–100). Both must be whole numbers in range; on a bad entry show `Please enter a whole number from <low> to <high>.` in a `MessageBox`.
- Call the item's `AddSale` method, then show `Added <amount> <item>. <item> quantity is now <new quantity>.` in `lbl_Status`. Example: `Added 15 Burrito. Burrito quantity is now 45.`
- Clear the two text boxes and refresh the table (calling `btn_ShowTable.PerformClick()` is an easy way).

## Requirement 6 — Option 3: Best Sellers

Show the item with the highest revenue in `lbl_BestRevenue` and the item with the highest quantity in `lbl_BestQuantity`. If two items tie, the one that comes first in the list wins. Write the search loops yourself.

```text
Highest revenue: Burrito ($217.50)
Highest quantity: Taco (42 sold)
```

## Requirement 7 — Option 4: Search

- The search text comes from `txt_Search` (cannot be blank — show `This cannot be blank.`).
- Fill `lst_Results` with every item whose name **contains** the search text, **ignoring upper/lower case**, like `Quesadilla - $6.75 each, 25 sold`.
- If nothing matches, show `No items match "<text>".` in `lst_Results`.

## Requirement 8 — Option 5: Save Report

- Write **`sales_report.txt`** with these lines: `FOOD TRUCK SALES REPORT`, `Report created: yyyy-MM-dd HH:mm` (the real date and time, from `DateTime.Now`), a blank line, the sales table, a blank line, and the two best-seller lines.
- Use a `using` block for the `StreamWriter` and a `try` / `catch` so a write error shows `Error: could not save sales_report.txt` instead of crashing.
- On success show `Report saved to sales_report.txt` in `lbl_Status`.

## Requirement 9 — Option 6: Quit

Show `Goodbye!` in a `MessageBox`, then close the form (`this.Close();`).

## Bonus (not in the 100 points) — Test All

Like the 2026 regional's "Grader Button": put sample text in the text boxes and call `PerformClick()` on Show Sales Table, Best Sellers, and Search, then show `All tests completed.` in a `MessageBox`.

## Sample session

This session adds 15 Burritos, so the numbers change after that.

| You do | You see |
|---|---|
| Open the form | `lbl_Status`: `Loaded 5 items from sales.csv`. `lst_Items`: `1. Taco ($3.50)` … `5. Churro ($2.25)` |
| Click Show Sales Table | the table above in `lst_Sales` |
| Click Best Sellers | `Highest revenue: Burrito ($217.50)` and `Highest quantity: Taco (42 sold)` |
| Item `abc`, quantity `15`, click Add Sale | a box: `Please enter a whole number from 1 to 5.` |
| Item `2`, quantity `2.5`, click Add Sale | a box: `Please enter a whole number from 1 to 100.` |
| Item `2`, quantity `15`, click Add Sale | `lbl_Status`: `Added 15 Burrito. Burrito quantity is now 45.` The table shows `Burrito     $7.25   45    $326.25` and `TOTAL               170   $822.00` |
| Search `QUES` | `Quesadilla - $6.75 each, 25 sold` |
| Search `zz` | `No items match "zz".` |
| Click Save Report | `lbl_Status`: `Report saved to sales_report.txt` |
| Click Quit | a box: `Goodbye!`, then the form closes |

`sales_report.txt` after that session (in `bin\Debug\net8.0-windows\`; your date and time will differ):

```text
FOOD TRUCK SALES REPORT
Report created: 2026-11-06 09:41

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

- Put the flags `//SC1` … `//SC5` in a comment right next to the code they describe (see the rubric). No flag, no credit.
- **Input / Processing / Output comments** on every major block.
- Every method has a comment with its purpose, parameters, and return value.
- C# naming: PascalCase for methods, classes, and properties; camelCase for local variables.
- `TryParse` for every number from a text box (never a bare `Parse` on user input).

**If it does not build and run at time-up, the Program Execution section scores zero. Keep a working version at all times.**
