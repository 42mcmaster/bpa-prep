# BPA Practice — Event 355 Python Programming
# Practice Task A: "Secret Message" (Cipher)

**Format:** Individual production problem · ~90 minutes · one working program.
**Archetype:** reversible string transform (char/ASCII math, case + digit preservation).
*Original practice problem modeled on the BPA Event 355 format. Not reproduced from BPA materials.*

---

## Scenario

The school's Cyber Club wants a tiny tool that scrambles short code words so they can be posted
publicly, then unscrambled later. You will write **encryption** and **decryption** functions plus a
driver that proves the process is reversible.

## The Algorithm (must be reversible)

Encrypt a word in **two phases, in this order**:

1. **Reverse** the characters of the word.
2. **Shift** each *letter* forward by **7** positions in the alphabet, wrapping around
   (`x` → `e`), and **preserving case** (uppercase stays uppercase, lowercase stays lowercase).
   **Digits and any other characters are left unchanged.**

Decryption undoes both phases in the opposite order: shift each letter **back** by 7, then reverse.

> ASCII hint: `A`–`Z` are 65–90, `a`–`z` are 97–122. Use `ord()` and `chr()` with `% 26` to wrap.

## Required Program Behavior

1. Name the program **`SecretMessage`** (this file).
2. Read words from an input file **`messages.txt`** — one word per line, no spaces.
3. For each word: encrypt it, then **print** it under an `Encrypted:` heading **and** write it to an
   output file **`encrypted.txt`** (one per line).
4. Then **read `encrypted.txt` back**, decrypt each line, and **print** the results under a
   `Decrypted:` heading. The decrypted list must exactly match the original words.
5. Provide **two separate functions**, `encrypt(word)` and `decrypt(word)`, each taking a string and
   **returning** a string. Document each with its purpose, parameters, and return value.
6. Open and close every file properly (use `with open(...)`).
7. Include a comment with your **contestant number** at the top.

## Sample Run (with the provided `messages.txt`)

```
Encrypted:
lkvJ
alyjlZ
3uvoafW
fyhupI
zwvvS

Decrypted:
Code
Secret
Python3
Binary
Loops
```
*(The point is that `Decrypted:` reproduces the original words exactly — proof the transform is reversible.)*

## Assumptions
- The input file exists and contains one clean word per line (letters/digits only, no spaces).

## Development Standards
- Consistent naming convention throughout.
- Every function documented (purpose, parameters, return).
- Optional: tag each gradable block with a comment flag (`#SC1`, `#SC2`, …) so it can be located quickly.

See `TaskA_Rubric.md` for scoring.
