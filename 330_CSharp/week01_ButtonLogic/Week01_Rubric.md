# Week 1 Rubric — Button Logic Trainer (100 points)

| Category | Description | Points |
|---|---|---|
| Project Setup | Folder named with Contestant ID; file present; ID comment at top | 5 |
| **Program Execution** | **Compiles and runs. If not, everything below this line in the Execution section scores ZERO.** | 10 |
| Menu loop | Shows the three buttons + Quit, repeats until Q, re-prompts on invalid choices without crashing | 15 |
| Button 1 executes | Text reversed correctly; empty input re-prompted | 10 |
| Button 2 executes | All vowels removed, both cases, other characters untouched | 15 |
| Button 3 executes | Interest correct; inputs validated via TryParse re-prompt loops; interest AND total shown as US currency ($1,234.50) | 20 |
| **Source Code Review** | | |
| Method signatures | `ReverseText(string)→string`, `RemoveVowels(string)→string`, `SimpleInterest(decimal,double,int)→decimal` exactly; logic in methods, not Main | 10 |
| Comments | Input / Processing / Output comments on major blocks; method headers with purpose/params/return | 10 |
| Style | PascalCase methods, camelCase locals; TryParse everywhere (no bare Parse) | 5 |

**Grading notes (teacher):** test button 3 with "abc" for principal, a negative rate, and
"2.5" for years — each must re-prompt, not crash. Check the currency formatting shows a
dollar sign and two decimals (`ToString("C")`).
