# Timed Build 2 Rubric — Food Truck Sales (C#) (100 points)

## Program Execution (20 points)

| Item | Points |
|---|---|
| Windows Forms project named `TimedBuild02`, whole project in the turn-in folder with `sales.csv`; Contestant ID (name for practice) in a comment at the top of `Form1.cs` | 5 |
| **Program builds and runs without errors from opening the form to Quit. If it does not run, everything in the Requirements section scores ZERO.** | 15 |
| **Subtotal** | **20** |

## Requirements (55 points)

| Item | Points |
|---|---|
| `Form1_Load` loads `sales.csv` with a relative path, skips the header, shows `Loaded 5 items from sales.csv` and the numbered list `1. Taco ($3.50)` …; shows `Error: could not find sales.csv` without crashing if the file is missing (and the other buttons don't crash with no items) | 6 |
| Every number box rejects letters, decimals, blanks, and out-of-range numbers with a `MessageBox` showing the exact message | 6 |
| **Option 1:** table columns line up exactly in `lst_Sales` (12 / 8 / 6 wide, Consolas font), money with `$` and 2 decimals, revenue correct for every row, TOTAL row correct (155, $713.25 at start) | 12 |
| **Option 2:** item number (1–5) and quantity (1–100) both validated; quantity really changes (shows in the table afterward); confirmation text exact | 12 |
| **Option 3:** highest revenue (Burrito $217.50 at start) and highest quantity (Taco, 42 at start) correct, found with the student's own loop | 6 |
| **Option 4:** case-insensitive partial match (`ques`, `QUES`, `a` all work); result line exact; "No items match" message when nothing is found | 6 |
| **Option 5:** `sales_report.txt` has the title, `Report created:` with the real date and time in `yyyy-MM-dd HH:mm`, the table, and the best sellers; success message shown | 6 |
| Option 6 shows `Goodbye!` and closes the form | 1 |
| **Subtotal** | **55** |

## Source Code Review (25 points)

The `//SC` flag must be in a comment right next to the code. No flag, no credit. The code must work to get credit.

| Flag | Item | Points |
|---|---|---|
| SC1 | `FoodItem` class: properties, constructor with `name`, `price`, `quantity`; `GetRevenue()` returns Price × Quantity; `AddSale(amount)` adds to Quantity | 5 |
| SC2 | Reusable whole-number check (a helper method) using `int.TryParse` and a range check | 4 |
| SC3 | CSV loaded into a **`List<FoodItem>`** (split on commas, convert to `decimal` and `int`) | 3 |
| SC4 | Option 2 uses the number check for both inputs and calls `AddSale` | 2 |
| SC5 | Report written with a `StreamWriter` in a `using` block, `DateTime.Now` used, `try` / `catch` around the write | 3 |
| — | Every method has a comment with purpose, parameters, and return value | 4 |
| — | Input / Processing / Output comments on the major blocks; PascalCase methods, camelCase locals, BPA control names unchanged | 4 |
| | **Subtotal** | **25** |

## Total: ______ / 100

**Bonus (not counted in the 100):** `btn_TestAll` calls `PerformClick()` on Show Sales Table, Best Sellers, and Search, then shows `All tests completed.`

**Grading notes (teacher):** Run it three times. (1) The sample session from the Problem file. (2) Junk in every text box: `abc`, `2.5`, `-1`, blank, `0`, `101` — any crash means the validation rows lose their points. (3) Rename `sales.csv` in `bin\Debug\net8.0-windows\` and run again — it must show the error message, not an "Unhandled exception" box, and clicking buttons afterward must not crash. Partial credit within a row is fine.

Convert to the 5-point scale: 90–100 = 5, 80–89 = 4, 65–79 = 3, started but far off = 2, not turned in = 0.
