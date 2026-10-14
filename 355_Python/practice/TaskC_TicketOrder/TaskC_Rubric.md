# Task C — "Ticket Order" — Grading Rubric (100 pts)

*Modeled on the BPA Event 355 three-section rubric with `#SC` comment flags.*

## Section 1 — Solution & Project (10 pts)
- [ ] Program present and named `TicketOrder` (5)
- [ ] Contestant-number comment at the top (5)

## Section 2 — Program Execution (40 pts)  — *hard gate: if it does not run, this section = 0*
- [ ] Runs from the drive without editing (8)
- [ ] Prompts for 1–10 ticket types and loops that many times (8)
- [ ] Builds a `Ticket` object for each type into a list (8)
- [ ] Prints every order with a blank line between (8)
- [ ] Currency shows as `$X.00`; per-order total = price × quantity (8)

## Section 3 — Source Code Review (50 pts) — check the `#SC` flags
- [ ] `#SC1` constructor stores code, event, quantity (5)
- [ ] `#SC2` random whole-dollar price $15–$60 (5)
- [ ] `#SC3`/`#SC4` `get_value()` returns price × quantity, currency-formatted (7)
- [ ] `#SC5` `__str__()` returns the required format (6)
- [ ] `#SC6`/`#SC9` two `try`/`except` blocks (count and quantity) (7)
- [ ] `#SC7` range check 1–10 (4)
- [ ] `#SC8` event code exactly 4 characters (5)
- [ ] `#SC10`/`#SC11` objects stored in a list (5)
- [ ] `#SC12` print loop with blank line between orders (3)
- [ ] Methods/driver documented; consistent naming (3)

**Teacher check:** `Ticket("SHOW", "Spring Musical", 3, price=42).get_value()` returns `"$126.00"`;
`str(...)` matches the required two-line block. (The solution accepts an optional `price=` only to make
this deterministic check possible; students generate it randomly.)
