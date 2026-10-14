# Contestant ID: ____________
# BPA 355 Week 1 Practice — Club Quiz Tracker
# Fill in each function. Keep the program runnable at all times.

import datetime

NUM_QUIZZES = 3


def get_valid_int(prompt, low, high):
    """Ask until the user enters a whole number between low and high (inclusive).

    Parameters: prompt (str), low (int), high (int)
    Returns: the validated int
    """
    # Input: read from the keyboard with input()
    # Processing: try to convert to int; re-prompt if it fails or is out of range
    # Output: returns the valid integer
    # TODO: implement with a while loop and try/except
    pass


def get_members():
    """Ask how many members (1-6), then collect non-blank names.

    Returns: list of name strings
    """
    # TODO
    pass


def get_scores(members):
    """Collect NUM_QUIZZES scores (0-100) for each member.

    Parameters: members (list of str)
    Returns: dict of name -> list of int scores
    """
    # TODO
    pass


def print_leaderboard(scores):
    """Print names, totals, and averages in aligned columns."""
    # TODO: header row, then one row per member; average to 2 decimals
    pass


def top_scorer(scores):
    """Return the (name, total) with the highest total."""
    # TODO
    pass


def hardest_quiz(scores):
    """Return the quiz number (1-based) with the lowest average across members."""
    # TODO
    pass


def save_results(scores):
    """Write the report to quiz_results.txt, dated with datetime."""
    # TODO: open, write, close properly
    pass


def main():
    members = get_members()
    scores = get_scores(members)
    print_leaderboard(scores)
    # TODO: print top scorer and hardest quiz, then save_results


if __name__ == "__main__":
    main()
