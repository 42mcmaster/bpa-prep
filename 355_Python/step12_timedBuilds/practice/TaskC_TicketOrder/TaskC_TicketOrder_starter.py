# TicketOrder  -  BPA Event 355 Practice Task C
# Contestant Number: ____________
#
# Build Ticket objects (code, event, quantity) with a random $15-$60 whole-dollar price,
# validate all input, store them in a list, and print a formatted report.

import random


class Ticket:
    """A single ticket-order type."""

    def __init__(self, code, event, quantity):
        # TODO: store code, event, quantity; generate a random whole-dollar price $15-$60
        pass

    def get_value(self):
        """Return price * quantity as US currency (e.g. $126.00)."""
        # TODO
        pass

    def __str__(self):
        # TODO: return the required multi-line format for one ticket
        pass


# ---------------- DRIVER ----------------
def main():
    # TODO: validate the type count (1-10), then for each type read a 4-char code,
    #       an event name, and a whole-number quantity; build Ticket objects into a list;
    #       finally print them all with a blank line between orders.
    pass


if __name__ == "__main__":
    main()
