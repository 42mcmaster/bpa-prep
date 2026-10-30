# Week 1 Rubric — Mini Menu (100 points)

| Category | Description | Points |
|---|---|---|
| Project Setup | Folder named with Contestant ID; file `Week01_MiniMenu.cpp`; ID comment at top | 5 |
| **Program Execution** | **Compiles and runs. If not, everything below this line in the Execution section scores ZERO.** | 10 |
| Main menu | Displays correctly, repeats after each option, rejects anything but 1–3 without crashing (letters included) | 15 |
| Option 1 executes | Sentence reversed with spaces/punctuation; empty input re-prompted | 15 |
| Option 2 executes | Count validated (1–5 int); numbers validated; average correct to 2 decimals | 20 |
| Option 3 executes | y/n confirm; returns bool; menu loop actually uses the returned value | 10 |
| **Source Code Review** | | |
| Functions | `reverseSentence`, `averageNumbers`, `exitProgram` exist with the required signatures; each option is its own function | 10 |
| Comments | Input / Processing / Output comments on every major block; function headers with purpose/params/return | 10 |
| Style | Consistent naming; clean structure; no copy-paste blocks a loop could replace | 5 |

**Grading notes (teacher):** feed the menu a letter, option 2 a letter and a 9, and
option 1 an empty line — the validation points require the re-prompt to work. Watch for
`cin >>` left-over-newline bugs breaking `getline` (the classic C++ trap this task is
designed to surface).
