# Timed Build 2 Rubric — Food Truck Sales (100 points)

## Program Execution (20 points)

| Item | Points |
|---|---|
| File named `FoodTruck.java` with `public class FoodTruck`, in the turn-in folder with `sales.csv`; Contestant ID (name for practice) in a comment at the top | 5 |
| **Program runs without errors from start to Quit. If it does not run, everything in the Requirements section scores ZERO.** | 15 |
| **Subtotal** | **20** |

## Requirements (55 points)

| Item | Points |
|---|---|
| Loads `sales.csv` with a relative path, skips the header, prints `Loaded 5 items from sales.csv`; prints `Error: could not find sales.csv` and ends without crashing if the file is missing | 6 |
| Menu prints exactly as shown and repeats until 6; choice rejects letters, decimals, blanks, and out-of-range numbers with the exact message | 6 |
| **Option 1:** table columns line up exactly (12 / 8 / 6 wide), money with `$` and 2 decimals, revenue correct for every row, TOTAL row correct (155, $713.25 at start) | 12 |
| **Option 2:** numbered list with prices; item number (1–5) and quantity (1–100) both validated with re-prompt; quantity really changes (shows in option 1 afterward); confirmation line exact | 12 |
| **Option 3:** highest revenue (Burrito $217.50 at start) and highest quantity (Taco, 42 at start) correct, found with the student's own loop | 6 |
| **Option 4:** case-insensitive partial match (`ques`, `QUES`, `a` all work); output line exact; "No items match" message when nothing is found | 6 |
| **Option 5:** `sales_report.txt` has the title, `Report created:` with the real date and time in `yyyy-MM-dd HH:mm`, the table, and the best sellers; success message printed | 6 |
| Option 6 prints `Goodbye!` and ends | 1 |
| **Subtotal** | **55** |

## Source Code Review (25 points)

The `//SC` flag must be in a comment right next to the code. No flag, no credit. The code must work to get credit.

| Flag | Item | Points |
|---|---|---|
| SC1 | `FoodItem` class: private fields, constructor with `name`, `price`, `quantity`; `getRevenue()` returns price × quantity; `addSale(int amount)` adds to quantity | 5 |
| SC2 | Reusable whole-number input method using `try`/`catch (NumberFormatException e)` and a range check (loop ends by its condition) | 4 |
| SC3 | CSV loaded into an **`ArrayList<FoodItem>`** (split on commas, `Double.parseDouble` and `Integer.parseInt`) inside a `try`/`catch` for `FileNotFoundException` | 3 |
| SC4 | Option 2 uses the validation method for both inputs and calls `addSale` | 2 |
| SC5 | Report file written with try-with-resources (or closed properly), `LocalDateTime` / `DateTimeFormatter` used, `try`/`catch (IOException e)` around the write | 3 |
| — | Every method has a comment with purpose, parameters, and return value | 4 |
| — | Input / Processing / Output comments on the major blocks; camelCase names throughout; Scanner closed | 4 |
| | **Subtotal** | **25** |

## Total: ______ / 100

**Grading notes (teacher):** Run it three times. (1) The exact sample run from the Problem file. (2) Junk everywhere: `abc`, `2.5`, `-1`, blank, `0`, `101` at each number prompt — any crash (a red `Exception in thread "main"` message) means the validation rows lose their points. (3) Rename `sales.csv` and run again — it must print the error and stop, not show a red exception. Partial credit within a row is fine.

Convert to the 5-point scale: 90–100 = 5, 80–89 = 4, 65–79 = 3, started but far off = 2, not turned in = 0.
