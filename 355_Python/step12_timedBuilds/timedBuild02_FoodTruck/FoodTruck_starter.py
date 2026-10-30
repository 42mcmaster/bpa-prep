# Contestant ID: ____________
# Date: ____________
# Program: Timed Build 02 - Food Truck Sales
# Description: ____________
#
# Rename this file to FoodTruck.py. Fill in each TODO.
# Keep the program runnable at all times - run it (F5) after every function you finish.

import datetime

SALES_FILE = "sales.csv"            # relative path - same folder as this program
REPORT_FILE = "sales_report.txt"


#SC1
class FoodItem:
    """One item on the food truck menu with its price and quantity sold."""

    def __init__(self, name, price, quantity):
        """Purpose: constructor - store the item's data.
        Parameters: name (str), price (float), quantity (int)
        Returns: nothing
        """
        # TODO: store all three parameters on self
        pass

    def get_revenue(self):
        """Purpose: calculate the money taken in for this item.
        Parameters: none
        Returns: price times quantity (float)
        """
        # TODO
        return 0.0

    def add_sale(self, amount):
        """Purpose: add more sold units to this item.
        Parameters: amount (int)
        Returns: nothing
        """
        # TODO
        pass


#SC2
def get_int(prompt, low, high):
    """Purpose: ask until the answer is a whole number from low to high.
    Parameters: prompt (str), low (int), high (int)
    Returns: the number (int)
    """
    # Input: input()
    # Processing: try int(); except ValueError; check the range; ask again if bad
    # Output: return the good number
    # TODO
    return low


def get_text(prompt):
    """Purpose: ask until the answer is not blank.
    Parameters: prompt (str)
    Returns: the trimmed answer (str)
    """
    # TODO
    return input(prompt)


#SC3
def load_items(file_name):
    """Purpose: read the CSV file into a list of FoodItem objects.
    Parameters: file_name (str)
    Returns: list of FoodItem
    """
    items = []
    # TODO: open with "with", skip the header, split each line on commas,
    #       make a FoodItem, append it to items
    return items


def print_table(items, out_file=None):
    """Purpose: print the sales table with a TOTAL row.
    Parameters: items (list of FoodItem), out_file (open file or None for the screen)
    Returns: nothing
    """
    # TODO: header, 33 dashes, one row per item, TOTAL row
    #       Tip: print(..., file=out_file) prints to the screen when out_file is None
    pass


def print_best_sellers(items, out_file=None):
    """Purpose: print the highest revenue item and the highest quantity item.
    Parameters: items (list of FoodItem), out_file (open file or None)
    Returns: nothing
    """
    # TODO
    pass


#SC4
def add_sale(items):
    """Purpose: menu option 2 - record more sales of one item.
    Parameters: items (list of FoodItem)
    Returns: nothing
    """
    # TODO
    pass


def search_items(items):
    """Purpose: menu option 4 - case-insensitive partial-match search.
    Parameters: items (list of FoodItem)
    Returns: nothing
    """
    # TODO
    pass


#SC5
def save_report(items):
    """Purpose: menu option 5 - write sales_report.txt with the date and time.
    Parameters: items (list of FoodItem)
    Returns: nothing
    """
    # TODO: datetime.datetime.now().strftime("%Y-%m-%d %H:%M")
    pass


def show_menu():
    """Purpose: print a blank line and the menu.
    Parameters: none
    Returns: nothing
    """
    # TODO
    pass


def main():
    """Purpose: load the data, then run the menu until the user quits.
    Parameters: none
    Returns: nothing
    """
    # Input: load the data (TODO: handle a missing file)
    items = load_items(SALES_FILE)
    print(f"Loaded {len(items)} items from {SALES_FILE}")

    # TODO: menu loop - show_menu(), get the choice, call the right function
    print("Goodbye!")


if __name__ == "__main__":
    main()
