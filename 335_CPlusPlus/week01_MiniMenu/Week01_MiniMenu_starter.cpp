// Contestant ID: ____________
// BPA 335 Week 1 Practice — Mini Menu
// Fill in each function. Keep the program compiling at all times.

#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

// Purpose: prompt for a sentence and print it reversed (spaces/punctuation too).
// Parameters: none.  Returns: nothing.
void reverseSentence() {
    // Input: a full line from the user (use getline; re-prompt if empty)
    // Processing: build or print the string in reverse order
    // Output: the reversed sentence on the console
    // TODO
}

// Purpose: average 1-5 user-entered numbers.
// Parameters: none.  Returns: nothing.
void averageNumbers() {
    // Input: a count (int 1-5, validated), then that many decimal numbers (validated)
    // Processing: accumulate a sum, divide by the count
    // Output: the average, 2 decimal places
    // TODO
}

// Purpose: confirm the user wants to quit.
// Parameters: none.  Returns: true to exit the program, false to show the menu again.
bool exitProgram() {
    // Input: y/n from the user
    // Processing: interpret the answer
    // Output: boolean back to the menu loop
    // TODO
    return true;
}

int main() {
    bool done = false;
    while (!done) {
        // Output: the menu
        cout << "\n===== MINI MENU =====\n";
        cout << "1. Reverse a Sentence\n";
        cout << "2. Average Calculator\n";
        cout << "3. Exit\n";
        cout << "Choose an option (1-3): ";

        // Input: menu choice — validate that it is 1, 2, or 3 (no crash on letters!)
        // TODO: read safely, call the right function; option 3 sets done = exitProgram();
    }
    return 0;
}
