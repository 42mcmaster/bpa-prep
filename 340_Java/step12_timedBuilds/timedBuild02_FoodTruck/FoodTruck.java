// Contestant ID: ____________
// Date: ____________
// Program: Timed Build 02 - Food Truck Sales
// Description: ____________
//
// This starter is already named FoodTruck.java because the public class is FoodTruck.
// (In Java the file name must match the public class name.) Fill in each TODO.
// Keep the program runnable at all times - run it after every method you finish.

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Scanner;

//SC1
/*
 * FoodItem: one item on the food truck menu with its price and quantity sold.
 * Not public, so it can live in this file next to the public FoodTruck class.
 */
class FoodItem {
    // TODO: three private fields - name (String), price (double), quantity (int)

    /*
     * Constructor: store the item's data.
     * Parameters: name - item name; price - price of one; quantity - how many sold so far
     */
    FoodItem(String name, double price, int quantity) {
        // TODO: store all three parameters in the fields (this.name = name; ...)
    }

    // TODO: getName(), getPrice(), getQuantity() - each returns one field

    /*
     * Purpose: calculate the money taken in for this item.
     * Parameters: none
     * Returns: price times quantity
     */
    double getRevenue() {
        // TODO
        return 0.0;
    }

    /*
     * Purpose: add more sold units to this item.
     * Parameters: amount - how many more were sold
     * Returns: nothing (void)
     */
    void addSale(int amount) {
        // TODO
    }
}

public class FoodTruck {

    static Scanner keyboard = new Scanner(System.in);
    static final String SALES_FILE = "sales.csv";           // relative path - same folder as the program
    static final String REPORT_FILE = "sales_report.txt";

    //SC2
    /*
     * Purpose: ask until the answer is a whole number from low to high.
     * Parameters: prompt - the question; low - smallest allowed; high - largest allowed
     * Returns: the valid number
     */
    static int getInt(String prompt, int low, int high) {
        // Input: keyboard.nextLine()
        // Processing: try Integer.parseInt(); catch NumberFormatException; check the range;
        //             ask again if bad (loop with a boolean, no break)
        // Output: return the good number
        // TODO
        System.out.print(prompt);
        return Integer.parseInt(keyboard.nextLine().trim());
    }

    /*
     * Purpose: ask until the answer is not blank.
     * Parameters: prompt - the question
     * Returns: the trimmed answer
     */
    static String getText(String prompt) {
        // TODO: re-ask with "This cannot be blank." while the answer is empty
        System.out.print(prompt);
        return keyboard.nextLine().trim();
    }

    //SC3
    /*
     * Purpose: read sales.csv into a list of FoodItem objects.
     * Parameters: none
     * Returns: the list of FoodItem objects (TODO: decide how to report a missing file)
     */
    static ArrayList<FoodItem> loadItems() {
        ArrayList<FoodItem> items = new ArrayList<>();
        // TODO: try (Scanner fileReader = new Scanner(new File(SALES_FILE))) { ... }
        //       skip the header, split each line on commas, make a FoodItem, add it to items
        //       catch (FileNotFoundException e) { ... }
        return items;
    }

    /*
     * Purpose: build the sales table as text (header, 33 dashes, one row per item, TOTAL row).
     * Parameters: items - the list of FoodItem objects
     * Returns: the table as one String
     * Tip: returning text lets the same table go to the screen AND to the report file.
     */
    static String buildTable(ArrayList<FoodItem> items) {
        // TODO: String.format("%-12s%-8s%-6s%s\n", ...)
        return "";
    }

    /*
     * Purpose: build the two best-seller lines as text.
     * Parameters: items - the list of FoodItem objects
     * Returns: the two lines as one String
     */
    static String buildBestSellers(ArrayList<FoodItem> items) {
        // TODO: your own loop for highest revenue and highest quantity
        return "";
    }

    /*
     * Purpose: menu option 1 - print the sales table.
     * Parameters: items - the list of FoodItem objects
     * Returns: nothing (void)
     */
    static void showTable(ArrayList<FoodItem> items) {
        // TODO
    }

    //SC4
    /*
     * Purpose: menu option 2 - record more sales of one item.
     * Parameters: items - the list of FoodItem objects
     * Returns: nothing (void)
     */
    static void addSale(ArrayList<FoodItem> items) {
        // TODO
    }

    /*
     * Purpose: menu option 3 - print the best sellers.
     * Parameters: items - the list of FoodItem objects
     * Returns: nothing (void)
     */
    static void showBestSellers(ArrayList<FoodItem> items) {
        // TODO
    }

    /*
     * Purpose: menu option 4 - case-insensitive partial-match search.
     * Parameters: items - the list of FoodItem objects
     * Returns: nothing (void)
     */
    static void searchItems(ArrayList<FoodItem> items) {
        // TODO
    }

    //SC5
    /*
     * Purpose: menu option 5 - write sales_report.txt with the date and time.
     * Parameters: items - the list of FoodItem objects
     * Returns: nothing (void)
     */
    static void saveReport(ArrayList<FoodItem> items) {
        // TODO: LocalDateTime.now().format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm"))
        //       try (PrintWriter writer = new PrintWriter(new FileWriter(REPORT_FILE))) { ... }
        //       catch (IOException e) { ... }
    }

    /*
     * Purpose: print a blank line and the menu.
     * Parameters: none
     * Returns: nothing (void)
     */
    static void showMenu() {
        // TODO
    }

    /*
     * Purpose: load the data, then run the menu until the user quits.
     * Parameters: args - command-line words (not used)
     * Returns: nothing (void)
     */
    public static void main(String[] args) {
        // Input: load the data (TODO: handle a missing file)
        ArrayList<FoodItem> items = loadItems();
        System.out.println("Loaded " + items.size() + " items from " + SALES_FILE);

        // TODO: menu loop - showMenu(), getInt for the choice, a switch that calls the right method
        System.out.println("Goodbye!");
        keyboard.close();
    }
}
