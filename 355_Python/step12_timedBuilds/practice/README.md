# BPA Event 355 — Python Programming: Practice Task Pack

Three **original** practice problems built to mirror the format, scope, and rubric style of BPA
Business Professionals of America **Event 355 (Python Programming)** — a single, hands-on,
~90-minute production program graded on three sections (Project · Execution · Source Code Review).

> **Attribution / integrity:** These are *fresh* scenarios written for classroom practice, modeled on
> the recurring problem *archetypes* of the event. They do **not** reproduce BPA's copyrighted contest
> problems. Give BPA credit for the event format; use these for practice only.

## The three tasks (one per archetype)

| Task | Archetype | Core Python skills | Difficulty |
|------|-----------|--------------------|------------|
| **A — Secret Message** | Reversible string/cipher transform | string reversal, `ord`/`chr`, modular wrap, case & digit preservation, functions, file read/write | medium |
| **B — Score Report** | Write → read → summarize a data file | counted input loop, file write/read, `len`/`max`/`min`, average, percentage, 2-dp formatting | easy–medium |
| **C — Ticket Order** | Class + validation + formatted report | `class`/`__init__`/methods/`__str__`, `random.randint`, currency formatting, `try`/`except`, range & length validation, list of objects | medium–hard |

## Each task folder contains

- `*_Problem.md` — the student-facing problem (scenario, requirements, sample output, assumptions, standards).
- `*_starter.py` — a starter file with documented function/method stubs (mirrors BPA-supplied starters).
- `*_Rubric.md` — a 100-point rubric in the BPA three-section style (Execution is a hard gate).
- (Tasks A & B include a sample input file: `messages.txt`, `scores.txt`.)

## How to use

- **Timed practice:** hand out the `*_Problem.md` and `*_starter.py`, give ~90 minutes, grade with the rubric.
- **The `#SC` habit:** tag gradable blocks with `#SC1`, `#SC2`, … — BPA's 2024 comment-flag
  convention. Have students add their own flags so graders (and they) can locate each rubric item.
- **Two skills worth extra drilling** (heavily weighted, easy to under-practice):
  1. **Character/ASCII math + case-preserving transforms** (Task A).
  2. **Exact output formatting** — currency `$X.00`, alignment, blank-line separators (Task C).

## Related course material
Pairs naturally with `prog05` (functions/modules, the main guard), `prog07` (file I/O),
`prog10` (error handling / `try`/`except`), and `prog11` (`random`, modules & tools).
