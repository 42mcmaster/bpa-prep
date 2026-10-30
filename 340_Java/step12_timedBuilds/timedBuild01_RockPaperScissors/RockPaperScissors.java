// Contestant ID: ____________
// Date: ____________
// Program: Timed Build 01 - Rock Paper Scissors Match
// Description: ____________
//
// This starter is already named RockPaperScissors.java because the public class is
// RockPaperScissors. (In Java the file name must match the public class name.)
//
// IMPORTANT: replace every "xx" at the end of a variable name with the last 2 digits of
// your Contestant ID (for practice, use 00). Example: playerNamexx becomes playerName00.
// VS Code: Edit > Replace (Ctrl+H) can do this, but check each change - do not replace
// the "xx" inside words that are not variable names.

import java.util.Random;
import java.util.Scanner;

public class RockPaperScissors {

    /*
     * Purpose: turn a choice number into its word.
     * Parameters: choice - 1, 2, or 3
     * Returns: "Rock" for 1, "Paper" for 2, "Scissors" for 3
     */
    static String choiceToWord(int choice) {
        // TODO: use a switch statement on choice to set the word
        return "";
    }

    /*
     * Purpose: run the match.
     * Parameters: args - command-line words (not used)
     * Returns: nothing (void)
     */
    public static void main(String[] args) {
        // TODO: SC1 create the Scanner
        Scanner keyboardxx = new Scanner(System.in);
        // TODO: SC2 create the Random object

        // The required variables (rename xx!)
        String playerNamexx, playerWordxx, computerWordxx;
        int winsNeededxx, playerChoicexx, computerChoicexx;
        int playerWinsxx = 0;
        int computerWinsxx = 0;
        int roundNumberxx = 0;

        // Input: TODO - ask for the name and the number of wins needed (exact prompts)

        // Output: TODO - the starting message

        // Processing: TODO - SC5 the match loop (while), ends by its condition, no break
        //   - print the round number
        //   - ask for the player's choice; SC6 re-ask with a second while loop if not 1-3
        //   - SC3 the computer picks 1-3 with the Random object
        //   - call choiceToWord for both choices and print them
        //   - SC7 if / else if / else: tie, player wins, or computer wins; add to the win count
        //   - print the score

        // Output: TODO - SC8 the final message and the number of rounds played

        // TODO: SC9 close the Scanner
    }
}
