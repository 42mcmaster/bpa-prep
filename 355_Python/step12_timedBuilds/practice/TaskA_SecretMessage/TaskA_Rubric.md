# Task A — "Secret Message" — Grading Rubric (100 pts)

*Modeled on the BPA Event 355 three-section rubric.*

## Section 1 — Solution & Project (10 pts)
- [ ] Program file present and named `SecretMessage` (5)
- [ ] Contestant-number comment at the top (5)

## Section 2 — Program Execution (45 pts)  — *hard gate: if it does not run, this section = 0*
- [ ] Program runs from the drive without editing (10)
- [ ] Reads `messages.txt` and prints an `Encrypted:` block (8)
- [ ] Writes all encrypted words to `encrypted.txt`, one per line (8)
- [ ] Reads `encrypted.txt` back and prints a `Decrypted:` block (8)
- [ ] **Decrypted output exactly matches the original words** (11)

## Section 3 — Source Code Review (45 pts)
- [ ] Separate `encrypt(word)` and `decrypt(word)`, each returns a string (10)
- [ ] Letter shift wraps correctly and preserves case (10)
- [ ] Digits / non-letters left unchanged (6)
- [ ] Files opened and closed properly (`with open`) (6)
- [ ] Every function documented (purpose, parameters, return) (7)
- [ ] Consistent naming convention (6)

**Teacher check:** for any word `s`, `decrypt(encrypt(s)) == s` must hold. The provided solution
satisfies this for all letter/digit inputs.
