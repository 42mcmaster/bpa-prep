# BPA 345 — SQL Database Fundamentals Reference Guide

*Competition study & exam reference — MCCC IT Academy*

The BPA 345 exam is **50 multiple-choice questions, 2 points each, 60 minutes**. Roughly the first half is vocabulary and syntax recall; the second half asks you to **read a query against printed sample tables and predict the result**. Every section of this guide ends with the exam angle: how that topic actually gets asked.

---

## Table of Contents

1. [Exam Strategy](#1-exam-strategy)
2. [Database Big Picture & Vocabulary](#2-database-big-picture--vocabulary)
3. [The Sample Database Used in This Guide](#3-the-sample-database-used-in-this-guide)
4. [SELECT — Retrieving Data](#4-select--retrieving-data)
5. [WHERE — Filtering Rows](#5-where--filtering-rows)
6. [ORDER BY, DISTINCT & Limiting Results](#6-order-by-distinct--limiting-results)
7. [Aggregate Functions, GROUP BY & HAVING](#7-aggregate-functions-group-by--having)
8. [DML — INSERT, UPDATE, DELETE](#8-dml--insert-update-delete)
9. [DDL — CREATE, ALTER, DROP & Data Types](#9-ddl--create-alter-drop--data-types)
10. [Keys, Constraints & Integrity](#10-keys-constraints--integrity)
11. [Joins — Combining Tables](#11-joins--combining-tables)
12. [UNION & Combining Result Sets](#12-union--combining-result-sets)
13. [Views, Indexes & Triggers](#13-views-indexes--triggers)
14. [Normalization & Table Relationships](#14-normalization--table-relationships)
15. [Transactions & ACID](#15-transactions--acid)
16. [Acronym Bank & Big Ideas](#16-acronym-bank--big-ideas)
17. [Trap Questions — The Gotcha List](#17-trap-questions--the-gotcha-list)
18. [Quick Reference Card](#18-quick-reference-card)

---

## 1. Exam Strategy

- **Budget your time:** 50 questions in 60 minutes ≈ 70 seconds each. Vocabulary questions should take 15 seconds — bank that time for the query-reading questions at the end.
- **The back half is where ranks are decided.** Questions like "how many rows does this query return?" require you to actually trace the query against the printed table. Slow down, put your finger on the rows that match, and count.
- **Read for the word NOT.** "Which of the following is NOT an aggregate function?" — miss the NOT and you'll confidently pick a correct-looking wrong answer.
- **True/False questions are sprinkled in** (marked "Mark A if true, B if false"). They test precise definitions: *"Every table must have a primary key"* — False (it's best practice, not a requirement).
- **When two answers look right,** the difference is usually one of the traps in [Section 17](#17-trap-questions--the-gotcha-list). Check that list until you know it cold.

---

## 2. Database Big Picture & Vocabulary

### What is a database?

A **database** is an organized collection of data. The software that creates, manages, and queries databases is a **DBMS** (Database Management System). When the data is organized into related tables, the software is an **RDBMS** — **Relational** Database Management System.

```text
Examples of RDBMSs:  MySQL, SQL Server, PostgreSQL, Oracle, SQLite
NOT an RDBMS:        MongoDB (document store), Redis (key-value store)
```

### Anatomy of a table

```text
            column / FIELD / ATTRIBUTE
                     │
Students             ▼
┌────┬───────────┬──────────┬───────┬─────┐
│ id │ firstName │ lastName │ grade │ age │  ◄── column headers (the schema)
├────┼───────────┼──────────┼───────┼─────┤
│ 1  │ Mia       │ Torres   │ 11    │ 16  │  ◄── one row / RECORD / TUPLE
│ 2  │ Deshawn   │ Reed     │ 12    │ 17  │
└────┴───────────┴──────────┴───────┴─────┘
```

Learn these synonym sets — the exam uses them interchangeably:

| Everyday word | Formal synonyms | Meaning |
|---|---|---|
| Table | Relation | Data organized in rows and columns |
| Row | **Record**, **tuple** | All the data about ONE person/place/thing |
| Column | **Field**, **attribute** | ONE piece of information (e.g., lastName) |
| Structure | **Schema** | The blueprint of the database — tables, columns, types, relationships |

### More core vocabulary

- **Query** — a request for data from a database.
- **Result set** — the data a query returns. A query that matches nothing returns an **empty result set** — *not* an error.
- **SQL** — **Structured Query Language**, the standard language for relational databases. It follows the **ANSI** (American National Standards Institute) standard so code ports between database systems. **SQL keywords are NOT case sensitive** (`select` = `SELECT`), but by convention keywords are written in UPPERCASE.
- **T-SQL** (Transact-SQL) — a set of programming extensions to SQL from **Sybase and Microsoft**, used in SQL Server.
- **DBA** — Database Administrator: manages security, backups, performance, and user access. (Traditionally NOT responsible for writing the application's front-end code.)

### Types of databases

| Type | How it stores data | Example |
|---|---|---|
| **Relational** | Related tables of rows/columns; queried with SQL | MySQL, SQL Server, PostgreSQL |
| **Document (NoSQL)** | Documents (like JSON) with **no fixed schema** | MongoDB |
| **Graph** | **Nodes** connected by **edges** (relationships) | Neo4j |
| **Object-oriented** | Objects, like in OOP languages | ObjectDB |
| **Distributed** | Spread across multiple machines/locations | (a property, can apply to many) |

> **Exam angle:** "Which of the following is NOT a database type?" has appeared with made-up answers like *Miniature Database*. Also: SQL is mainly for **relational** databases — not graph databases.

---

## 3. The Sample Database Used in This Guide

Every example below runs against this small **School** database. Get comfortable with it — tracing queries against known tables is exactly what the exam's hardest questions ask.

```text
Students                                Courses
┌────┬───────────┬──────────┬───────┐   ┌──────┬────────────────┬─────────┐
│ id │ firstName │ lastName │ grade │   │ code │ title          │ credits │
├────┼───────────┼──────────┼───────┤   ├──────┼────────────────┼─────────┤
│ 1  │ Mia       │ Torres   │ 11    │   │ SQL1 │ Databases      │ 3       │
│ 2  │ Deshawn   │ Reed     │ 12    │   │ PY1  │ Python         │ 3       │
│ 3  │ Ava       │ Kowalski │ 11    │   │ WEB1 │ Web Design     │ 2       │
│ 4  │ Liam      │ Nagy     │ 12    │   └──────┴────────────────┴─────────┘
│ 5  │ Priya     │ Shah     │ 11    │
└────┴───────────┴──────────┴───────┘

Enrollments  (the JUNCTION table — connects Students to Courses)
┌────┬───────────┬────────────┬───────┐
│ id │ studentId │ courseCode │ score │
├────┼───────────┼────────────┼───────┤
│ 1  │ 1         │ SQL1       │ 95    │
│ 2  │ 1         │ PY1        │ 88    │
│ 3  │ 2         │ SQL1       │ 72    │
│ 4  │ 3         │ WEB1       │ 91    │
│ 5  │ 5         │ SQL1       │ NULL  │   ◄── score not entered yet (NULL)
└────┴───────────┴────────────┴───────┘
```

Note the relationships: `Enrollments.studentId` points at `Students.id`, and `Enrollments.courseCode` points at `Courses.code`. Liam (id 4) has **no enrollments** — that detail matters for join questions later.

---

## 4. SELECT — Retrieving Data

`SELECT` is the statement that retrieves data. It's the most-tested keyword on the exam.

### Basic patterns

```sql
-- Get EVERY column and EVERY row  (* means "all columns")
SELECT * FROM Students;

-- Get specific columns only (separate with commas — NEVER the word AND)
SELECT firstName, lastName FROM Students;

-- Clause order is FIXED and required:
--   SELECT (which columns) → FROM (which table) → WHERE (which rows)
SELECT firstName FROM Students WHERE grade = 12;
```

### Column aliases with AS

An **alias** renames a column (or table) *in the output only* — the real name in the database never changes.

```sql
-- Both of these display the firstName column under the header "Name":
SELECT firstName AS Name FROM Students;
SELECT firstName Name FROM Students;    -- AS is optional; a space alone works
```

> **Exam angle:** know both alias spellings (with and without `AS`). Wrong-answer bait uses `ALIAS` or a colon — neither is real SQL. Also: an alias does NOT permanently rename the column.

### Selecting calculations

```sql
-- SELECT can compute expressions, not just fetch columns:
SELECT (5 + 5) * 6 + 1;      -- returns 61 (one row, one column)
SELECT credits * 2 FROM Courses;   -- doubles each credits value in the output
```

> **Exam angle (2024 style):** "What is the outcome of SELECT (5+5)*6+1?" — just do the math with normal order of operations. The database happily returns calculated values with no table at all.

---

## 5. WHERE — Filtering Rows

`WHERE` filters **which rows** come back. It works with SELECT, UPDATE, and DELETE.

### Comparison operators

```sql
=    equal                 <>   not equal  (some systems also allow !=)
>    greater than          >=   greater than or equal
<    less than             <=   less than or equal
```

```sql
-- Text values need SINGLE QUOTES; numbers don't:
SELECT * FROM Students WHERE lastName = 'Shah';   -- text → quotes
SELECT * FROM Students WHERE grade = 11;          -- number → no quotes
-- Without quotes, SQL thinks Shah is a COLUMN name and errors out.
```

### Combining conditions: AND, OR, NOT

```sql
-- AND: both conditions must be true
SELECT * FROM Students WHERE grade = 11 AND lastName = 'Shah';   -- just Priya

-- OR: either condition can be true
SELECT * FROM Students WHERE grade = 12 OR lastName = 'Torres';  -- Mia, Deshawn, Liam

-- NOT: reverses a condition
SELECT * FROM Students WHERE NOT grade = 12;                     -- the three juniors
```

**Precedence: `NOT` first, then `AND`, then `OR`.** Parentheses override.

```sql
-- These are DIFFERENT queries:
WHERE grade = 11 AND lastName = 'Shah' OR lastName = 'Reed'
--  means: (grade=11 AND lastName='Shah') OR lastName='Reed'   → Priya AND Deshawn
WHERE grade = 11 AND (lastName = 'Shah' OR lastName = 'Reed')
--  means: grade must be 11, name either Shah or Reed          → Priya only
```

> **Exam angle (2024 favorite):** `SELECT TRUE OR FALSE AND FALSE OR TRUE AND FALSE` — evaluate every AND before any OR:
> `TRUE OR (FALSE AND FALSE) OR (TRUE AND FALSE)` → `TRUE OR FALSE OR FALSE` → **TRUE**.

### BETWEEN — range matching (INCLUSIVE!)

```sql
-- BETWEEN includes BOTH endpoints:
SELECT * FROM Students WHERE grade BETWEEN 11 AND 12;   -- grades 11 AND 12 both match
-- Equivalent to:  WHERE grade >= 11 AND grade <= 12
-- Also equivalent to:  WHERE grade > 10 AND grade < 13   (widen by one on each side)
```

> **Exam angle:** "Which query matches `WHERE a BETWEEN 10 AND 20`?" The right rewrite is `a >= 10 AND a <= 20` — or the sneaky-but-equal `a > 9 AND a < 21` for whole numbers. `a > 10 AND a < 20` is WRONG (loses the endpoints).

### IN — matching a list of values

```sql
-- IN checks a column against multiple values (cleaner than chained ORs):
SELECT * FROM Students WHERE lastName IN ('Shah', 'Reed', 'Nagy');
-- Same as: WHERE lastName='Shah' OR lastName='Reed' OR lastName='Nagy'
```

### LIKE — pattern matching with wildcards

Two wildcards:
- `%` — any number of characters (including zero)
- `_` — exactly one character

```sql
SELECT * FROM Students WHERE firstName LIKE 'P%';    -- starts with P        → Priya
SELECT * FROM Students WHERE firstName LIKE '%a';    -- ends with a          → Mia, Ava, Priya
SELECT * FROM Students WHERE firstName LIKE '%ia%';  -- contains "ia"        → Mia, Priya
SELECT * FROM Students WHERE firstName LIKE 'M_a';   -- M, any ONE char, a   → Mia
```

> **Exam angle:** "Get all names containing an 'a'" → `LIKE '%a%'` (percent on BOTH sides). "Starting with B" → `LIKE 'B%'` (percent only at the end).

### NULL — the "no value" value

`NULL` means **no value was entered**. It is not zero, not an empty string — it's the absence of a value, and it needs special syntax:

```sql
-- CORRECT — use IS NULL / IS NOT NULL:
SELECT * FROM Enrollments WHERE score IS NULL;       -- Priya's SQL1 enrollment
SELECT * FROM Enrollments WHERE score IS NOT NULL;   -- the other four rows

-- WRONG — these never match anything, because NULL isn't equal to anything:
SELECT * FROM Enrollments WHERE score = NULL;    -- returns 0 rows, always
```

---

## 6. ORDER BY, DISTINCT & Limiting Results

### ORDER BY — sorting the result set

```sql
-- Ascending (A→Z, small→large) is the DEFAULT:
SELECT * FROM Students ORDER BY lastName;          -- Kowalski, Nagy, Reed, Shah, Torres
SELECT * FROM Students ORDER BY lastName ASC;      -- same thing, explicit

-- DESC sorts largest→smallest / Z→A:
SELECT * FROM Students ORDER BY grade DESC;        -- seniors first

-- Sort by MULTIPLE columns — first column breaks into groups,
-- second column sorts inside each group. Each can have its own direction:
SELECT * FROM Students ORDER BY grade DESC, lastName ASC;
--  → grade 12s alphabetically, then grade 11s alphabetically
```

> **Exam angle:** ORDER BY facts asked as True/False — default is **ascending** (True), can sort by multiple columns (True), can mix ASC and DESC in one query (True). And the keyword is `ORDER BY`, never `SORT BY` — `SORT BY` is a classic wrong answer.

### DISTINCT — removing duplicate rows

```sql
-- Without DISTINCT: one 11 for each junior, one 12 for each senior (5 rows)
SELECT grade FROM Students;            -- 11, 12, 11, 12, 11

-- With DISTINCT: each unique value once (2 rows)
SELECT DISTINCT grade FROM Students;   -- 11, 12
```

> **Exam angle:** `SELECT a FROM t GROUP BY a` **always** produces the same result as `SELECT DISTINCT a FROM t`. That equivalence has been asked directly.

### Limiting the number of rows returned

Different systems use different keywords — the exam has asked for SQL Server's:

```sql
SELECT TOP 3 * FROM Students;              -- SQL Server:  TOP
SELECT * FROM Students LIMIT 3;            -- MySQL / PostgreSQL / SQLite:  LIMIT
```

---

## 7. Aggregate Functions, GROUP BY & HAVING

### The five aggregate functions

An **aggregate function** collapses many rows into ONE calculated value:

| Function | Returns | Example result on Enrollments.score (95, 88, 72, 91, NULL) |
|---|---|---|
| `COUNT()` | how many | `COUNT(score)` → **4** (NULLs not counted!) · `COUNT(*)` → **5** (counts rows) |
| `SUM()` | total | 95+88+72+91 = **346** |
| `AVG()` | average | 346 ÷ **4** = **86.5** (NULL excluded from both sum AND count) |
| `MIN()` | smallest | **72** |
| `MAX()` | largest | **95** |

```sql
-- One row comes back, no matter how many rows go in:
SELECT MIN(score), MAX(score), AVG(score) FROM Enrollments;
--  → exactly ONE row: 72 | 95 | 86.5
```

> **Exam angle #1:** "How many rows does `SELECT MIN(a), MAX(a), AVG(a) FROM t` return?" → **1**. Aggregates without GROUP BY always return exactly one row.
>
> **Exam angle #2:** "Which is NOT an aggregate function?" — bait answers: `TOTAL`, `ADD`. The real five: COUNT, SUM, AVG, MIN, MAX.
>
> **Exam angle #3:** Mixing a plain column with an aggregate — `SELECT name, MIN(a) FROM t` — is a trick: the `name` that comes back is **not reliably from the minimum row** (behavior is undefined/database-dependent). Answer: "it cannot be determined."

### GROUP BY — aggregates per category

`GROUP BY` splits rows into buckets, then applies the aggregate to each bucket:

```sql
-- How many students per grade?
SELECT grade, COUNT(*) FROM Students GROUP BY grade;
--  → 11 | 3
--    12 | 2       (one output row PER GROUP)
```

Rules worth memorizing:
- Every non-aggregate column in the SELECT must appear in the GROUP BY.
- `GROUP BY` on a **primary key** puts every row in its own group — the "grouping" changes nothing.
- **NULLs group together** into their own single group.

### HAVING — filtering the groups

`WHERE` filters **rows before grouping**. `HAVING` filters **groups after aggregation**. You need HAVING when the filter involves an aggregate:

```sql
-- Grades that have more than 2 students:
SELECT grade, COUNT(*) FROM Students
GROUP BY grade
HAVING COUNT(*) > 2;        -- only grade 11 (3 students) survives
-- "WHERE COUNT(*) > 2" would be an ERROR — WHERE can't see aggregates.
```

> **Exam angle:** "In a query without GROUP BY, do HAVING and WHERE produce the same result?" Standard-SQL answer: they're **not** interchangeable — HAVING is for aggregate conditions with grouping. The full clause order is:
> `SELECT → FROM → WHERE → GROUP BY → HAVING → ORDER BY`

---

## 8. DML — INSERT, UPDATE, DELETE

**DML = Data Manipulation Language** — the statements that work with the **data inside** tables. (SELECT is usually grouped here too.)

### INSERT — adding rows

```sql
-- Full-row insert (values in column order):
INSERT INTO Students VALUES (6, 'Jordan', 'Okafor', 12, 18);

-- Safer: name the columns you're filling (others get NULL/default):
INSERT INTO Students (id, firstName, lastName, grade)
VALUES (6, 'Jordan', 'Okafor', 12);
```

### UPDATE — changing existing rows

```sql
-- Change data in rows that match the WHERE:
UPDATE Students
SET grade = 12
WHERE id = 3;          -- only Ava is promoted

-- ⚠️ WITHOUT a WHERE clause, UPDATE changes EVERY row in the table:
UPDATE Students SET grade = 12;    -- everyone is suddenly a senior. Oops.
```

### DELETE — removing rows

```sql
-- Remove the rows that match the WHERE:
DELETE FROM Students WHERE id = 6;

-- ⚠️ WITHOUT a WHERE clause, DELETE empties the whole table:
DELETE FROM Students;    -- table still exists, but has zero rows
```

> **Exam angle:** matching the four verbs to their jobs is guaranteed points:
> **SELECT** = retrieve · **INSERT** = add · **UPDATE** = change · **DELETE** = remove.
> Wrong-answer bait: `ADD`, `MODIFY`, `CHANGE`, `REMOVE`, `GET`. Also: a WHERE clause is **allowed but not required** with DELETE (that's a True/False question — "DELETE may be used with WHERE" = True; "WHERE is required with DELETE" = False).

---

## 9. DDL — CREATE, ALTER, DROP & Data Types

**DDL = Data Definition Language** — the statements that build and change the **structure** (not the data).

| Statement | What it does |
|---|---|
| `CREATE DATABASE School;` | Makes a new database |
| `CREATE TABLE ...` | Makes a new table (also: CREATE VIEW, CREATE INDEX) |
| `ALTER TABLE ...` | Changes a table's structure — add/remove/modify columns, add constraints |
| `DROP TABLE Students;` | Deletes the table **and all its data**, permanently |
| `TRUNCATE TABLE Students;` | Empties all rows but keeps the table structure |

```sql
-- Creating a table = naming each column and giving it a DATA TYPE:
CREATE TABLE Students (
    id        INT          PRIMARY KEY,   -- whole numbers
    firstName VARCHAR(30),                -- variable-length text, up to 30 chars
    lastName  VARCHAR(30)  NOT NULL,      -- must have a value
    grade     INT,
    birthDate DATE                        -- dates
);

-- ALTER examples — changing structure after creation:
ALTER TABLE Students ADD email VARCHAR(50);            -- add a column
ALTER TABLE Students DROP COLUMN email;                -- remove a column
ALTER TABLE Students ALTER COLUMN grade VARCHAR(2);    -- change a column's type
--   (some systems say MODIFY COLUMN instead of ALTER COLUMN)
```

### Data types to know

| Type | Holds | Notes |
|---|---|---|
| `INT` / `INTEGER` | whole numbers | ~−2.1 billion to +2.1 billion |
| `FLOAT` / `DECIMAL` | numbers with decimals | |
| `VARCHAR(n)` | **variable-length** text up to n chars | THE answer for "variable length string data" |
| `CHAR(n)` | fixed-length text, always n chars | |
| `DATE` | dates | Postgres, SQL Server, and MySQL all have DATE |
| `BOOLEAN` / `BIT` | true/false | |

> **Exam angle:** "`String` is NOT a SQL data type" — the SQL type for text is `VARCHAR`/`CHAR`. That exact distractor has appeared. Also: **DDL vs DML classification** is a repeat question — CREATE/ALTER/DROP = DDL; SELECT/INSERT/UPDATE/DELETE = DML.

---

## 10. Keys, Constraints & Integrity

### Primary keys

A **primary key (PK)** uniquely identifies each record in a table.

Facts the exam tests (several as True/False):
- A PK's values must be **unique** — two records can NEVER share a primary key.
- A PK **cannot be NULL**.
- A table can have **only one** primary key…
- …but that one PK **may span multiple columns** (a **composite key**). So "a primary key may contain only one column" = **False**.
- A table is **not required** to have a PK ("every table must have a primary key" = **False** — it's just strongly recommended).
- A PK **can be added after** the table is created, via ALTER TABLE.

```sql
-- Defining a PK at creation:
CREATE TABLE Courses (
    code  VARCHAR(5) PRIMARY KEY,
    title VARCHAR(40)
);

-- Adding a PK to an existing table:
ALTER TABLE Students ADD PRIMARY KEY (id);
-- or with a named constraint:
ALTER TABLE Students ADD CONSTRAINT pk_student PRIMARY KEY (id);
```

### Foreign keys

A **foreign key (FK)** is a column (or columns) in one table that **matches the primary key of another table** — it's how tables link together.

- The FK's job: **enforce referential integrity** (see below) and connect related tables.
- Unlike PKs, foreign key values **CAN repeat** — many Enrollments rows can share `studentId = 1` (Mia has two enrollments). "Two records can have the same foreign key" = **True**.

```sql
-- Enrollments.studentId must match an existing Students.id:
ALTER TABLE Enrollments
ADD CONSTRAINT fk_student
FOREIGN KEY (studentId) REFERENCES Students(id);
```

### The key family

| Key | Definition |
|---|---|
| **Primary key** | The chosen unique identifier for each record |
| **Composite key** | A primary key made of two or more columns |
| **Candidate key** | Any column that COULD serve as the PK (unique, non-null) |
| **Foreign key** | Column matching another table's PK — the link between tables |
| **Surrogate key** | An artificial unique ID (like an auto-numbered id) **not derived from real application data** — it has no business meaning |

> **Exam angle:** "Which is NOT a type of database key?" — bait answers like *master key* or *sort key*. The real family is above.

### Constraints

A **constraint** is a rule the database enforces on data:

| Constraint | Enforces |
|---|---|
| `PRIMARY KEY` | unique + not null — **entity integrity** |
| `FOREIGN KEY` | values must exist in the referenced table — **referential integrity** |
| `UNIQUE` | no duplicate values in the column |
| `NOT NULL` | a value is required |
| `CHECK` | values must satisfy a condition (e.g., `CHECK (grade BETWEEN 9 AND 12)`) |
| `DEFAULT` | value used when none is supplied |

### The two integrities

- **Entity integrity** — every record is uniquely identified: the PK is unique and never NULL. *Enforced by the primary key.*
- **Referential integrity** — every FK value points at a record that actually exists. If `Enrollments.studentId = 9` but there's no student 9, referential integrity is **broken** (an **orphan record**). Deleting a parent record that other rows still reference also breaks it — that's why the delete gets blocked (or cascades).

> **Exam angle:** past exams print two tables and ask "does this table break referential integrity?" Method: take each FK value in the child table and check it exists in the parent table. Any orphan = broken.

---

## 11. Joins — Combining Tables

A **join** combines rows from two (or more) tables using a related column — almost always FK-to-PK. This is the most heavily tested "hard" topic.

### The join family

```text
   INNER JOIN                LEFT JOIN                 RIGHT JOIN               FULL OUTER JOIN
  ┌───┐ ┌───┐              ┌───┐ ┌───┐               ┌───┐ ┌───┐              ┌───┐ ┌───┐
  │ A ▓▓▓ B │              │▓▓▓▓▓▓▓ B │               │ A ▓▓▓▓▓▓▓│              │▓▓▓▓▓▓▓▓▓▓│
  └───┘ └───┘              └───┘ └───┘               └───┘ └───┘              └───┘ └───┘
  matches only             ALL of A +                ALL of B +               everything,
  (intersection)           matches from B            matches from A           matched where possible
```

| Join | Returns |
|---|---|
| **INNER JOIN** | Only rows where the key exists in **BOTH** tables — the **intersection** |
| **LEFT (OUTER) JOIN** | **ALL** rows from the left table + matching rows from the right; where there's no match, right-side columns come back **NULL** |
| **RIGHT (OUTER) JOIN** | ALL rows from the right table + matches from the left |
| **FULL OUTER JOIN** | All rows from both tables, matched where possible, NULLs where not |
| **Self-join** | A table joined **to itself** (e.g., an Employees table where each row's managerId points at another employee row) |
| **CROSS JOIN** | Every row of A paired with every row of B (rarely wanted) |

### Worked example on the School database

```sql
-- INNER JOIN: students WITH their enrollment scores.
SELECT Students.lastName, Enrollments.courseCode, Enrollments.score
FROM Students
INNER JOIN Enrollments ON Students.id = Enrollments.studentId;
```

```text
Result — 5 rows (one per enrollment; Liam is absent — he has no enrollment):
lastName  | courseCode | score
Torres    | SQL1       | 95
Torres    | PY1        | 88      ◄── Mia appears TWICE (two enrollments)
Reed      | SQL1       | 72
Kowalski  | WEB1       | 91
Shah      | SQL1       | NULL
```

```sql
-- LEFT JOIN: ALL students, with scores where they exist.
SELECT Students.lastName, Enrollments.score
FROM Students
LEFT JOIN Enrollments ON Students.id = Enrollments.studentId;
```

```text
Result — 6 rows. Liam NOW appears, with NULLs filling the missing side:
lastName  | score
Torres    | 95
Torres    | 88
Reed      | 72
Kowalski  | 91
Nagy      | NULL     ◄── kept by the LEFT join; no match → NULLs
Shah      | NULL     ◄── (this NULL is a real score that was never entered)
```

### The "find who has NO match" pattern

```sql
-- Students who are enrolled in NOTHING:
-- LEFT JOIN keeps everyone; the WHERE keeps only the no-match rows.
SELECT Students.lastName
FROM Students
LEFT JOIN Enrollments ON Students.id = Enrollments.studentId
WHERE Enrollments.studentId IS NULL;        -- → Nagy
```

> **Exam angle:** a 2022-style question shows a result of names with NULLs and asks which query produced it — the answer is this exact LEFT JOIN + `IS NULL` pattern.

### Row-counting rules for join questions

1. **INNER JOIN row count** = number of matching pairs (a parent row appears once **per matching child row** — Mia × 2).
2. **LEFT JOIN row count** = every left row at least once + extra appearances for multiple matches.
3. **Aggregating a join:** "total items per person" = `SUM(...)` with `GROUP BY` — and to count only people WITH matches, use INNER JOIN.

```sql
-- Average score per student (only students with enrollments):
SELECT Students.lastName, AVG(Enrollments.score)
FROM Students
INNER JOIN Enrollments ON Students.id = Enrollments.studentId
GROUP BY Students.lastName;
```

### How many tables can you join?

The practical limit is **database dependent** — that exact phrasing has been a correct answer. Multi-hop questions ("how many joins to get from Students to Courses?") count the links: Students → Enrollments → Courses = **2 joins**, because the junction table sits in the middle.

---

## 12. UNION & Combining Result Sets

A **join combines columns** (side by side); a **UNION stacks rows** (top to bottom) from two queries.

```sql
-- Both queries must return the SAME NUMBER of columns with compatible types:
SELECT firstName FROM Students WHERE grade = 11
UNION
SELECT firstName FROM Students WHERE grade = 12;

-- UNION removes duplicate rows from the combined result.
-- UNION ALL keeps the duplicates.
```

> **Exam angle:** "Two queries combined with UNION…" → must have matching column counts/types, and duplicates are removed (unless UNION ALL).

---

## 13. Views, Indexes & Triggers

### Views — saved virtual tables

A **view** is a **virtual table whose contents are defined by a query**. It stores no data itself — it re-runs its query when used.

```sql
CREATE VIEW Juniors AS
SELECT firstName, lastName FROM Students WHERE grade = 11;

-- Now query it like a table:
SELECT * FROM Juniors;
```

### Indexes — speed

An **index** is a lookup structure that makes searches on a column **faster** (like a book's index). Cost: slightly slower INSERT/UPDATE and extra storage.

```sql
CREATE INDEX idx_lastname ON Students (lastName);
```

> **Exam angle:** "One way to make queries quicker is to add ____" → **indexes**.

### Triggers — automatic reactions

A **trigger** is stored code that **runs automatically when a data event happens** on a table (INSERT, UPDATE, or DELETE). You don't call a trigger — the event fires it.

---

## 14. Normalization & Table Relationships

### Why normalize?

**Normalization** organizes tables to **reduce redundancy** (the same fact stored twice) and prevent update anomalies. "NF" stands for **Normal Form**.

### The normal forms ladder

| Form | Rule (each builds on the previous) |
|---|---|
| **UNF** | Un-normalized — repeating groups, multiple values crammed in one cell |
| **1NF** | Each cell holds exactly **ONE value** (atomic); no repeating groups |
| **2NF** | 1NF **+** every non-key column depends on the **WHOLE primary key** (matters for composite keys — no partial dependencies) |
| **3NF** | 2NF **+** no **transitive dependencies** (non-key columns must not depend on OTHER non-key columns) |

Facts the exam asks directly: UNF data is **not** normalized; 1NF cells contain **one** value; 2NF non-key columns depend on **the whole key**; 3NF has no **transitive** dependencies; and **data in 3NF is automatically also in 2NF and 1NF** (True).

### Worked mini-example

```text
UNF (one cell, many values):          1NF (atomic — but redundant):
student   | courses                   student | course | teacher | teacherRoom
Mia       | SQL1, PY1                 Mia     | SQL1   | Boyd    | 114
                                      Mia     | PY1    | Chen    | 202
                                      Ava     | SQL1   | Boyd    | 114   ◄ Boyd/114 repeated

3NF fix: teacherRoom depends on teacher (a NON-key) — a TRANSITIVE dependency.
Split it out:   Enrollments(student, course)   Courses(course, teacher)   Teachers(teacher, room)
```

### Relationship types

| Relationship | Meaning | Example |
|---|---|---|
| **One-to-one (1:1)** | One record ↔ exactly one record | Student ↔ locker assignment |
| **One-to-many (1:M)** | One record ← referenced by many | One student → many enrollments |
| **Many-to-many (M:N)** | Many ↔ many — **requires a junction table** | Students ↔ Courses, connected THROUGH Enrollments |

A **junction table** (a.k.a. linking/bridge/associative table) holds two foreign keys — one to each side. `Enrollments` is exactly that: "What type of table is the MovieActor table?" (2024) → a junction table implementing many-to-many.

**Denormalization** = deliberately re-introducing redundancy to make **reads faster** (fewer joins) — a real technique, traded against update risk.

---

## 15. Transactions & ACID

A **transaction** is a group of SQL statements treated as **all-or-nothing** (classic example: transfer money out of one account AND into another — both must happen, or neither).

```sql
BEGIN TRANSACTION;
UPDATE Accounts SET balance = balance - 100 WHERE id = 1;
UPDATE Accounts SET balance = balance + 100 WHERE id = 2;
COMMIT;      -- makes every change permanent, ends the transaction
-- or, if something went wrong before committing:
ROLLBACK;    -- erases ALL changes made since the transaction started
```

**ACID** — the four guarantees of a reliable transaction system:

| Letter | Property | Meaning |
|---|---|---|
| **A** | Atomicity | All-or-nothing — no half-finished transactions |
| **C** | Consistency | Data always moves from one valid state to another |
| **I** | **Isolation** | Concurrent transactions leave the DB **as if they ran one at a time** |
| **D** | Durability | Once committed, changes survive crashes/power loss |

> **Exam angle:** COMMIT = make permanent & end; ROLLBACK = undo everything since the start. "___ requires concurrent transactions to act as if sequential" → **Isolation**. And: major RDBMS providers **DO** implement ACID (the "do not implement" phrasing is False).

---

## 16. Acronym Bank & Big Ideas

The exam loves acronym questions — free points if you've memorized these:

| Acronym | Stands for | One-liner |
|---|---|---|
| **SQL** | Structured Query Language | The language of relational databases |
| **ANSI** | American National Standards Institute | Publishes the SQL standard — write ANSI SQL for portability |
| **DBMS** | Database Management System | Software that manages databases |
| **RDBMS** | Relational DBMS | DBMS for table-based (relational) data |
| **DDL** | Data Definition Language | Structure: CREATE, ALTER, DROP |
| **DML** | Data Manipulation Language | Data: SELECT, INSERT, UPDATE, DELETE |
| **CRUD** | Create, Read, Update, Delete | The four basic data operations |
| **ACID** | Atomicity, Consistency, Isolation, Durability | Transaction guarantees |
| **CAP** | Consistency, Availability, Partition tolerance | Distributed systems: pick two of three |
| **ETL** | Extract, Transform, Load | Moving data between systems (warehousing) |
| **NF / 3NF** | (Third) Normal Form | Normalization levels |
| **T-SQL** | Transact-SQL | Microsoft/Sybase SQL extensions (SQL Server) |
| **DBA** | Database Administrator | Runs security, backups, performance |
| **INT** | Integer | Whole-number type, ~±2.1 billion |
| **VARCHAR** | Variable Character | Variable-length text type |

Other one-off facts that have appeared:
- **RANK** is a **ranking/window function** (not an aggregate).
- **Not RDBMSs:** MongoDB (document), Redis (key-value) — anything NoSQL.
- A **schema/ERD** is a representation of the database's structure.
- A database **tuple** = a row/record.

---

## 17. Trap Questions — The Gotcha List

Read this list the night before and again the morning of. Each one has cost points on a real exam.

1. **BETWEEN is inclusive.** `BETWEEN 10 AND 20` = `>= 10 AND <= 20`. The rewrite `> 9 AND < 21` is also equal (for integers); `> 10 AND < 20` is NOT.
2. **`ORDER BY`, not `SORT BY`.** SORT BY does not exist. Aggregating uses `GROUP BY`; group-filtering uses `HAVING`.
3. **NULL ≠ anything.** `= NULL` matches nothing; use `IS NULL`. A no-match query returns an **empty result set**, not an error.
4. **Aggregates skip NULLs.** `COUNT(column)` ignores NULLs; `COUNT(*)` counts all rows. `AVG` divides by the count of NON-null values.
5. **Aggregates without GROUP BY return exactly ONE row** — `SELECT MIN(a), MAX(a), AVG(a)` → 1 row, 3 columns.
6. **`SELECT name, MIN(a) FROM t`** (bare column + aggregate, no GROUP BY): where `name` comes from **cannot be determined** — it is NOT guaranteed to be from the min row.
7. **`GROUP BY a` on a lone column ≡ `SELECT DISTINCT a`.** Always.
8. **GROUP BY on a primary key changes nothing** — every row is already unique, so each "group" is one row.
9. **AND before OR.** `TRUE OR FALSE AND FALSE` = `TRUE OR (FALSE AND FALSE)` = TRUE. Evaluate every AND first, then ORs, left to right.
10. **Two records can share a FOREIGN key (True) but never a PRIMARY key (False).**
11. **Primary keys:** only one per table, but it may span multiple columns (composite). Not required on every table. Can be added later with ALTER TABLE.
12. **UPDATE/DELETE without WHERE hits EVERY row.** DELETE + WHERE is allowed, not required.
13. **DROP vs DELETE vs TRUNCATE:** DROP removes the whole table (structure + data); DELETE removes rows (filterable with WHERE); TRUNCATE removes all rows, keeps structure.
14. **`String` is not a SQL data type** — text is `VARCHAR`/`CHAR`. Variable-length text = **VARCHAR**.
15. **Alias syntax:** `AS` or just a space. `ALIAS` and `:` are fake. Aliases only rename output, never the real column.
16. **INNER JOIN = intersection.** LEFT JOIN = all left rows + NULLs for non-matches. Finding no-match rows = LEFT JOIN + `WHERE rightKey IS NULL`.
17. **Join limits are database dependent** — that IS the answer when asked "how many tables can be joined?"
18. **Junction table** = the middle table implementing many-to-many, holding two FKs. Crossing it takes **two** joins.
19. **Referential integrity check:** every FK value must exist in the parent table; orphans break it. Deleting a still-referenced parent breaks it.
20. **3NF ⇒ 2NF ⇒ 1NF.** Higher forms include the lower ones. Transitive dependency = non-key depending on non-key (the thing 3NF forbids).
21. **SQL keywords are not case sensitive**, and **SQL is for relational databases** (not graph).
22. **Fake keywords used as bait:** GET, OPEN, QUERY (as a statement), ADD, MODIFY, CHANGE, ALIGN, SORT BY, BUILD, TOTAL, BIGGEST. If it looks made up, it is.

---

## 18. Quick Reference Card

### Clause order (fixed, always)

```sql
SELECT columns          -- 1. what to show
FROM table              -- 2. where it lives
WHERE row_condition     -- 3. filter ROWS (no aggregates here)
GROUP BY column         -- 4. bucket rows
HAVING group_condition  -- 5. filter GROUPS (aggregates OK here)
ORDER BY column ASC     -- 6. sort the result (ASC default / DESC)
```

### Statement cheat table

| Task | Statement |
|---|---|
| Get data | `SELECT cols FROM t WHERE ...` |
| Everything in a table | `SELECT * FROM t;` |
| Unique values | `SELECT DISTINCT col FROM t;` |
| Rename output column | `SELECT col AS Alias FROM t;` |
| Pattern match | `WHERE col LIKE '%text%'` (`%` many, `_` one) |
| Range (inclusive) | `WHERE col BETWEEN a AND b` |
| List match | `WHERE col IN (v1, v2, v3)` |
| Missing value | `WHERE col IS NULL` |
| Sort | `ORDER BY col DESC` |
| First n rows | `SELECT TOP n ...` / `... LIMIT n` |
| Count per group | `SELECT col, COUNT(*) FROM t GROUP BY col` |
| Add row | `INSERT INTO t VALUES (...)` |
| Change rows | `UPDATE t SET col = x WHERE ...` |
| Remove rows | `DELETE FROM t WHERE ...` |
| New table | `CREATE TABLE t (col TYPE, ...)` |
| Change structure | `ALTER TABLE t ADD/DROP/ALTER COLUMN ...` |
| Remove table | `DROP TABLE t;` |
| Both-tables matches | `... A INNER JOIN B ON A.key = B.key` |
| All of A + matches | `... A LEFT JOIN B ON A.key = B.key` |
| Stack two queries | `query1 UNION query2` |
| Save a query as a table | `CREATE VIEW v AS SELECT ...` |
| Speed up searches | `CREATE INDEX idx ON t (col);` |
| Make changes permanent | `COMMIT;` (undo instead: `ROLLBACK;`) |

---

*Prepared for MCCC IT Academy BPA competitors. Original material aligned to the published BPA 345 topic areas; not affiliated with Business Professionals of America.*
