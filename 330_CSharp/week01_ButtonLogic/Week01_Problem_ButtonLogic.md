# BPA 330 C# — Week 1 Practice: Button Logic Trainer

**Time: 40 minutes. Individual. Contest conditions.**

The real 330 regional (2026) hands you a pre-built Windows Forms app and you implement the
logic behind its buttons — string manipulation, financial math, conversions — with
validation and required comments. This week we drill exactly those button behaviors in a
console program, so the logic is automatic before we add the Forms layer in a later week.

## Setup (graded)

1. Create a folder named with your Contestant ID (practice: class period + initials, e.g. `P2_RM`).
2. Create **`Week01_ButtonLogic.cs`** (or a console project with `Program.cs`).
   Contestant ID as a **comment at the top**.

## What the program does

A loop shows three "buttons" and lets the user pick one, until they quit:

```
===== BUTTON TRAINER =====
1. Reverse Text
2. Remove Vowels
3. Simple Interest
Q. Quit
Pick a button:
```

Invalid choices get an error and a re-prompt — no crashes.

**Button 1 — Reverse Text (method `ReverseText`)**
- Signature: `static string ReverseText(string input)` — takes the text, RETURNS the reversed text.
- Prompt for a line of text (re-prompt if empty), print the returned result.

**Button 2 — Remove Vowels (method `RemoveVowels`)**
- Signature: `static string RemoveVowels(string input)` — returns the text with a, e, i, o, u
  removed (both cases). "Programming Rocks" → "Prgrmmng Rcks".

**Button 3 — Simple Interest (method `SimpleInterest`)**
- Signature: `static decimal SimpleInterest(decimal principal, double rate, int years)`
- Formula: interest = principal × (rate ÷ 100) × years. Return the INTEREST amount.
- Prompt for principal (positive number — use `decimal.TryParse`, re-prompt on junk),
  rate percent (positive, `double.TryParse`), and whole years (positive, `int.TryParse`).
- Display the interest AND the total (principal + interest) formatted as US currency
  (`ToString("C")` → `$1,234.50`).

## Development standards (graded in Source Code Review)

- The three methods exist with the exact signatures above — logic in methods, not in `Main`.
- **Input / Processing / Output comments** on every major block — the 2026 grading standard.
- All numeric input through `TryParse` (never a bare `Parse` that can throw).
- Consistent C# naming: PascalCase methods, camelCase locals.

## Assumptions

- Console only this week; the Forms wrapper comes later.
- After a valid entry the user is cooperative.

**If it does not compile and run at time-up, the Program Execution section scores zero.
Keep a compiling version at all times.**
