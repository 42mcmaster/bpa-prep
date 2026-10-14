# BPA Practice — Event 355 Python Programming
# Practice Task C: "Ticket Order" (Class + Validation + Formatted Report)

**Format:** Individual production problem · ~90 minutes · one working program.
**Archetype:** build a class (constructor + calculation method + toString), store many in a list,
validate all input, print an exactly-formatted report.
*Original practice problem modeled on the BPA Event 355 format. Not reproduced from BPA materials.*

---

## Scenario

A school theater is taking event-ticket orders. An employee enters 1–10 ticket **types**; for each,
they enter a **4-character event code**, an **event name**, and a **quantity**. The program builds an
object for each type, then prints a formatted list of all orders with a per-order total.

## Class to Implement — `Ticket`

- **Constructor** parameters: `code`, `event`, `quantity`.
- **Price** is **randomly generated $15–$60, whole-dollar only**, stored on the object and shown as
  US currency (e.g. `$42.00`).
- **`get_value()`** — returns the order total = `price × quantity`, US-currency formatted.
- **`__str__()`** — returns the object's info string in the required output format (below).

## Driver Section (clearly marked)

- Controls **all** input and validation.
- Builds each `Ticket` into a **list**.
- After all input, prints every ticket **vertically, with a blank line between orders**.

## Validation Required

- **Type count:** whole number only (reject letters/symbols with `try`/`except`), range **1–10** inclusive; re-prompt on bad input.
- **Event code:** must be **exactly 4 characters** (any letters/numbers/symbols); re-prompt otherwise.
- **Event name:** no validation.
- **Quantity:** whole number only (`try`/`except`), at least 1; re-prompt on bad input.

## Required Output Format (match closely)

```
How many ticket types? (1-10): 2

Ticket type 1
  Event code (4 chars): SHOW
  Event name: Spring Musical
  Quantity: 3

Ticket type 2
  Event code (4 chars): JAZZ
  Event name: Jazz Night
  Quantity: 5

===== TICKET ORDERS =====

Code: SHOW | Spring Musical
  Price: $42.00  x 3  =  $126.00

Code: JAZZ | Jazz Night
  Price: $28.00  x 5  =  $140.00
```
*(Prices are random, so dollar amounts will vary; the layout must match.)*

## Assumptions
- The employee follows prompts; the only invalid entries you must handle are those listed under Validation.

## Development Standards
- Consistent naming; the class methods and driver documented (purpose, parameters, return).
- Optional `#SC1`, `#SC2`, … comment flags on gradable blocks (constructor, random price, `get_value`,
  `__str__`, currency formatting, the two `try`/`except` blocks, range/length checks, list build, print loop).

See `TaskC_Rubric.md` for scoring. A starter file `TaskC_TicketOrder_starter.py` is provided
(mirroring how BPA supplies a starter).
