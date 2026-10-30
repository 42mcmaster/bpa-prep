# BPA 340 Java — Timed Build 1: Rock Paper Scissors Match

**Time: 90 minutes. Individual. Contest conditions — local IDE only, no online compilers, no AI.**

This task is written in the same style as the Java regional tests: exact prompts, exact output, exact variable names with your Contestant ID digits, and numbered comment flags for source code review.

## Setup (do this exactly — it's graded)

1. Create a folder named with your Contestant ID (for practice, use `java_timed01` inside your `bpaPrep` repo).
2. The program must be saved as **`RockPaperScissors.java`** with **`public class RockPaperScissors`**. All code goes in this one file. (The starter file is already set up this way.)
3. Your Contestant ID (your name, for practice) must be in a **comment at the top** of the file.

## The program

The player plays rock paper scissors against the computer. The player chooses how many round wins it takes to win the match. Rounds continue until either the player or the computer reaches that number of wins.

- Rock beats Scissors. Scissors beats Paper. Paper beats Rock.
- If both choose the same thing, the round is a tie. A tie counts as a round played but nobody gets a win.

## Assumptions you can make

- The user will type a non-blank name, and a whole number from 1 to 5 for the number of wins. You do not need to check these two inputs.
- When choosing Rock, Paper, or Scissors, the user will always type a whole number, but it might **not** be 1, 2, or 3. You must handle that (see below).
- The program ends only when the player or the computer reaches the number of wins needed.

## Input

You must use the exact variable names listed below, with the **last 2 digits of your Contestant ID** added to the end of each where you see `xx`.

```
String playerNamexx, playerWordxx, computerWordxx
int winsNeededxx, playerChoicexx, computerChoicexx
int playerWinsxx, computerWinsxx, roundNumberxx
```

The program must use a **Scanner** and these exact prompts to get the starting input:

```
What is your name: Jordan
How many wins does it take to win the match (1-5): 2
```

After the starting input, print a blank line and then this message (based on `playerNamexx` and `winsNeededxx`):

```
Jordan, the match is first to 2. Good luck!
```

## Playing the rounds

Use a **while loop** that keeps playing rounds while **both** `playerWinsxx` and `computerWinsxx` are less than `winsNeededxx`. The loop must end because of its condition — **not** by using a `break` statement.

During each round:

1. Add 1 to `roundNumberxx`. Print a blank line, then `Round ` and the round number (for example `Round 1`).
2. Prompt with exactly `Choose 1-Rock, 2-Paper, or 3-Scissors: ` and read the choice into `playerChoicexx`.
3. Use a **second while loop**: while `playerChoicexx` is less than 1 or greater than 3, print `Please choose 1, 2, or 3.` and prompt again. An invalid choice does **not** start a new round.
4. Use a **Random** object to set `computerChoicexx` to a random whole number from 1 to 3 (1, 2, and 3 must all be possible).
5. Write a method named **`choiceToWord`** that takes a choice number (1, 2, or 3) and **returns** `"Rock"`, `"Paper"`, or `"Scissors"`. It must use a **switch statement**. Use it to set `playerWordxx` and `computerWordxx`.
6. Print both choices, like `You chose Rock. The computer chose Scissors.`
7. Use an **if / else if / else** to decide the round:
   - Same choice: print `This round is a tie.`
   - Player wins: print `You win this round!` and add 1 to `playerWinsxx`.
   - Computer wins: print `The computer wins this round!` and add 1 to `computerWinsxx`.
8. Print the score, like `Score: Jordan 1, Computer 0`

## Final output

After the loop ends, print a blank line and then **one** of these messages:

- If the player won: `Congratulations, Jordan, you won the match 2 to 0!` (player's wins first)
- If the computer won: `Sorry, Sam, the computer won the match 2 to 1.` (computer's wins first)

Then print `Rounds played: ` and the value of `roundNumberxx`.

The **Scanner must be closed** before the program ends.

## Sample runs

The dialog must match these exactly, except that the computer's choices are random, so your rounds will go differently.

**Sample run 1** (the player wins):

```
What is your name: Jordan
How many wins does it take to win the match (1-5): 2

Jordan, the match is first to 2. Good luck!

Round 1
Choose 1-Rock, 2-Paper, or 3-Scissors: 1
You chose Rock. The computer chose Scissors.
You win this round!
Score: Jordan 1, Computer 0

Round 2
Choose 1-Rock, 2-Paper, or 3-Scissors: 2
You chose Paper. The computer chose Paper.
This round is a tie.
Score: Jordan 1, Computer 0

Round 3
Choose 1-Rock, 2-Paper, or 3-Scissors: 3
You chose Scissors. The computer chose Paper.
You win this round!
Score: Jordan 2, Computer 0

Congratulations, Jordan, you won the match 2 to 0!
Rounds played: 3
```

**Sample run 2** (an invalid choice, then the computer wins):

```
What is your name: Sam
How many wins does it take to win the match (1-5): 2

Sam, the match is first to 2. Good luck!

Round 1
Choose 1-Rock, 2-Paper, or 3-Scissors: 4
Please choose 1, 2, or 3.
Choose 1-Rock, 2-Paper, or 3-Scissors: 1
You chose Rock. The computer chose Paper.
The computer wins this round!
Score: Sam 0, Computer 1

Round 2
Choose 1-Rock, 2-Paper, or 3-Scissors: 1
You chose Rock. The computer chose Rock.
This round is a tie.
Score: Sam 0, Computer 1

Round 3
Choose 1-Rock, 2-Paper, or 3-Scissors: 2
You chose Paper. The computer chose Rock.
You win this round!
Score: Sam 1, Computer 1

Round 4
Choose 1-Rock, 2-Paper, or 3-Scissors: 3
You chose Scissors. The computer chose Rock.
The computer wins this round!
Score: Sam 1, Computer 2

Sorry, Sam, the computer won the match 2 to 1.
Rounds played: 4
```

## Main requirements

1. The program is named `RockPaperScissors.java` and is in a folder named with your Contestant ID (`java_timed01` for practice).
2. Your Contestant ID is in a comment at the top of the program.
3. Your code uses the exact variable names given above, with the last 2 digits of your Contestant ID in place of `xx`.
4. Your code uses a Scanner to collect all input, with the exact prompts given.
5. Your code produces the exact output given.
6. Your code contains **2 while loops**: one for the match and one to re-ask an invalid choice. Neither loop exits with `break`.
7. Your code uses a Random object for the computer's choice, 1 to 3 inclusive.
8. Your code has a method `choiceToWord` that uses a switch statement, with a comment that gives its purpose, parameter, and return value.
9. Your code uses an if / else if / else to decide each round, and an if / else for the final message.
10. Your code closes the Scanner.
11. Your code has Input / Processing / Output comments, and the comment flags below.

## Comment flags for source code review

Put each flag in a comment right next to the code it describes, for example `//SC3 computer picks 1-3`. **No flag, no credit.**

| Flag | Put it next to... |
|---|---|
| SC1 | the code that creates the Scanner |
| SC2 | the code that creates the Random object |
| SC3 | the code that picks the computer's choice |
| SC4 | the switch statement in `choiceToWord` |
| SC5 | the while loop that plays the rounds |
| SC6 | the while loop that re-asks an invalid choice |
| SC7 | the if / else if / else that decides the round |
| SC8 | the if / else that prints the final message |
| SC9 | the code that closes the Scanner |

**A starter file is provided (`RockPaperScissors.java`). It compiles and runs. If your program does not run when time is up, the Program Execution section scores zero — always keep a runnable version.**
