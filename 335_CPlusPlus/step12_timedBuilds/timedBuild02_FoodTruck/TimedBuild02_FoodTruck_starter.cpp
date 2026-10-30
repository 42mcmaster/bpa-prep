// Contestant ID: ____________
// Date: ____________
// Program: Timed Build 02 - Food Truck Sales
// Description: ____________
// Fill in each TODO. Keep the program compiling at all times.

#define _CRT_SECURE_NO_WARNINGS   // lets Visual Studio accept localtime (keep as the first line)

#include <iostream>
#include <fstream>     // ifstream, ofstream
#include <sstream>     // stringstream, ostringstream
#include <string>
#include <iomanip>     // setw, left, fixed, setprecision, put_time
#include <vector>
#include <cctype>      // tolower
#include <ctime>       // time, localtime
#include <stdexcept>   // invalid_argument, out_of_range
using namespace std;

// ---------------------------------------------------------------
// #SC1 FoodItem class: one food item with its price and quantity sold
// ---------------------------------------------------------------
class FoodItem
{
public:
    // TODO: fields - name (string), price (double), quantity (int)

    // TODO: constructor that fills in all three fields

    // TODO: method getRevenue() - returns price times quantity

    // TODO: method addSale(amount) - adds amount to quantity
};

// Function prototypes - input helpers (copy them from your Step 10 program)
// Put the #SC2 flag on your getInt function
string trim(string text);
string getText(string prompt);
int getInt(string prompt, int low, int high);

// Function prototypes - other helpers
bool loadItems(string fileName, vector<FoodItem>& items);
string formatMoney(double amount);
void printTable(ostream& out, const vector<FoodItem>& items);
void printBestSellers(ostream& out, const vector<FoodItem>& items);
void showMenu();

// Function prototypes - one function per menu option
void showSalesTable(const vector<FoodItem>& items);
void recordSale(vector<FoodItem>& items);
void showBestSellers(const vector<FoodItem>& items);
void searchItems(const vector<FoodItem>& items);
void saveReport(const vector<FoodItem>& items);

// Purpose: starting point. Loads sales.csv, then runs the menu until Quit.
// Parameters: none
// Returns: 0 when the program ends normally
int main()
{
    // Input: load the items from sales.csv (relative path)
    vector<FoodItem> items;
    // TODO: call loadItems; if it returns false, print the error message and return 0
    // TODO: print "Loaded N items from sales.csv"

    bool running = true;
    while (running)
    {
        // Output: blank line and the menu
        cout << endl;
        showMenu();

        // Input: the choice - TODO: replace the next line with getInt("Choose an option (1-6): ", 1, 6)
        int choice = 6;

        // Processing: call the function for the option
        switch (choice)
        {
        case 1:
            showSalesTable(items);
            break;
        case 2:
            recordSale(items);
            break;
        case 3:
            showBestSellers(items);
            break;
        case 4:
            searchItems(items);
            break;
        case 5:
            saveReport(items);
            break;
        case 6:
            cout << "Goodbye!" << endl;
            running = false;
            break;
        }
    }
    return 0;
}

// #SC3
// Purpose: read Item,Price,Quantity lines from the file into FoodItem objects.
// Parameters: fileName - the file to read; items - the vector to fill (by reference)
// Returns: true if the file was read, false if it could not be opened
bool loadItems(string fileName, vector<FoodItem>& items)
{
    // Input: open the file, skip the header line, read one item per line
    // Processing: split each line on commas, convert price (stod) and quantity (stoi)
    // TODO
    return false;
}

// Purpose: print the menu.
// Parameters: none
// Returns: nothing
void showMenu()
{
    // Output: the menu lines
    cout << "===== FOOD TRUCK SALES =====" << endl;
    cout << "1. Show sales table" << endl;
    cout << "2. Add a sale" << endl;
    cout << "3. Best sellers" << endl;
    cout << "4. Search for an item" << endl;
    cout << "5. Save report" << endl;
    cout << "6. Quit" << endl;
}

// Purpose: menu option 1 - show the sales table with a TOTAL row.
// Parameters: items - the item list
// Returns: nothing
void showSalesTable(const vector<FoodItem>& items)
{
    // Output: the table to the console
    printTable(cout, items);
}

// #SC4
// Purpose: menu option 2 - record a sale for one item.
// Parameters: items - the item list (changed, so by reference)
// Returns: nothing
void recordSale(vector<FoodItem>& items)
{
    // Output: numbered list of items
    // Input: item number (1-5) and quantity sold (1-100) with getInt
    // Processing: addSale on the chosen item (use a reference: FoodItem& chosen = ...)
    // Output: confirmation line
    // TODO
}

// Purpose: menu option 3 - show the highest revenue item and the most sold item.
// Parameters: items - the item list
// Returns: nothing
void showBestSellers(const vector<FoodItem>& items)
{
    // Output: the two best-seller lines to the console
    printBestSellers(cout, items);
}

// Purpose: menu option 4 - find items whose name contains some text, ignoring case.
// Parameters: items - the item list
// Returns: nothing
void searchItems(const vector<FoodItem>& items)
{
    // Input: search text with getText
    // Processing: compare lowercase copies with find
    // Output: each match, or the "No items match" message
    // TODO
}

// #SC5
// Purpose: menu option 5 - save the report to sales_report.txt.
// Parameters: items - the item list
// Returns: nothing
void saveReport(const vector<FoodItem>& items)
{
    // Output: title line, date line, blank line, the table, blank line, best sellers - inside try/catch
    // TODO
}

// Purpose: print the sales table with a TOTAL row, to the screen or a file.
// Parameters: out - where to print (cout or an open file); items - the item list
// Returns: nothing
void printTable(ostream& out, const vector<FoodItem>& items)
{
    // Processing: running totals of quantity and revenue
    // Output: header, 33 dashes, one row per item, TOTAL row
    // TODO
}

// Purpose: print the highest revenue item and the highest quantity item (first one wins a tie).
// Parameters: out - where to print (cout or an open file); items - the item list
// Returns: nothing
void printBestSellers(ostream& out, const vector<FoodItem>& items)
{
    // Processing: one loop finds both best items
    // Output: the two lines
    // TODO
}

// Purpose: turn a number into money text, like $147.00 (from Step 5).
// Parameters: amount - the number to format
// Returns: the money text
string formatMoney(double amount)
{
    // TODO
    return "";
}

// TODO: trim, getText, getInt (copy from Step 10), plus any helpers you add
// (toLower, currentDateTime from Step 9)
