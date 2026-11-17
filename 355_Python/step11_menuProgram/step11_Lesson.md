# Step 11 — Menu Programs and Classes (Python)

BPA programs are usually **menu programs**: they show a list of choices, do the one the user picks, and show the menu again until the user quits. This lesson teaches the menu loop and **classes** one piece at a time. Each part has a short example and a quick "Try it."

**Time:** about one class period.
**After this lesson:** do the [Step 11 Practice](step11_Practice.md) problems. For more examples, use the [Step 11 Study Guide](step11_StudyGuide.md).

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [Part 1: The menu loop](#part-1-the-menu-loop)
- [Part 2: One function per menu option](#part-2-one-function-per-menu-option)
- [Part 3: What a class is](#part-3-what-a-class-is)
- [Part 4: Writing a class](#part-4-writing-a-class)
- [Part 5: Methods](#part-5-methods)
- [Part 6: A list of objects](#part-6-a-list-of-objects)
- [Part 7: A menu with a list of objects](#part-7-a-menu-with-a-list-of-objects)
- [Common mistakes](#common-mistakes)
- [Next steps](#next-steps)

## What you'll learn
- How to write a menu loop that runs until the user quits
- How to give each menu option its own function
- What a class and an object are
- How to write a class with `__init__` and methods
- How to keep a list of objects and loop through it

---

## Part 1: The menu loop

A menu is a `while` loop (Step 4) with an `if`/`elif` chain (Step 3) inside.

<!-- input: 1|2|3 -->
```python
choice = 0
while choice != 3:                      # 3 is Quit
    print()
    print("--- LIGHTS ---")
    print("1. Turn on")
    print("2. Turn off")
    print("3. Quit")
    choice = int(input("Choose (1-3): "))
    if choice == 1:
        print("Lights on.")
    elif choice == 2:
        print("Lights off.")
print("Bye!")
```

```text

--- LIGHTS ---
1. Turn on
2. Turn off
3. Quit
Choose (1-3): 1
Lights on.

--- LIGHTS ---
1. Turn on
2. Turn off
3. Quit
Choose (1-3): 2
Lights off.

--- LIGHTS ---
1. Turn on
2. Turn off
3. Quit
Choose (1-3): 3
Bye!
```

- `choice = 0` before the loop makes sure the loop runs the first time.
- When `choice` is 3, nothing in the `if` chain matches, the loop condition is False, and the loop ends.
- In a real program, use `get_int` from Step 10 for the choice, so letters can't crash it.

**Try it:** Add a choice `3. Dim` and make Quit choice 4.

---

## Part 2: One function per menu option

As the program grows, the menu gets long. Give each option its own function, so the loop stays short and easy to read. BPA graders look for this.

<!-- input: 1|2|3 -->
```python
def show_hours():
    """Purpose: print the hours. Parameters: none. Returns: nothing"""
    print("Open 8 to 3, Monday to Friday.")

def show_location():
    """Purpose: print the location. Parameters: none. Returns: nothing"""
    print("Room 112, IT Academy.")

def main():
    """Purpose: run the menu. Parameters: none. Returns: nothing"""
    choice = 0
    while choice != 3:
        print("1. Hours  2. Location  3. Quit")
        choice = int(input("Choose: "))
        if choice == 1:
            show_hours()
        elif choice == 2:
            show_location()
    print("Bye!")

if __name__ == "__main__":
    main()
```

```text
1. Hours  2. Location  3. Quit
Choose: 1
Open 8 to 3, Monday to Friday.
1. Hours  2. Location  3. Quit
Choose: 2
Room 112, IT Academy.
1. Hours  2. Location  3. Quit
Choose: 3
Bye!
```

---

## Part 3: What a class is

A **class** is a blueprint for a kind of thing. An **object** is one thing made from that blueprint.

For example, a `Player` class says every player has a **name** and **points**. Then `Player("Avery", 40)` makes one player object, and `Player("Blake", 25)` makes another. Each object keeps its own name and points.

The values an object keeps are called its **attributes**. The functions that belong to a class are called its **methods**.

Classes keep data that belongs together in one place. That's easier than keeping parallel lists in step.

---

## Part 4: Writing a class

```python
class Player:
    """A player with a name and a point total."""

    def __init__(self, name, points):
        """Purpose: set up a new Player.
        Parameters: name (str), points (int)
        Returns: nothing
        """
        self.name = name            # self.name is this object's name
        self.points = points

# Make two Player objects
first = Player("Avery", 40)
second = Player("Blake", 25)

# Read their attributes with a dot
print(first.name, first.points)
print(second.name, second.points)
```

```text
Avery 40
Blake 25
```

- Class names start with a **capital letter**: `Player`.
- `__init__` (two underscores on each side) runs automatically when you make a new object. It's called the **constructor**.
- `self` means "this object." `self.name = name` saves the name in this object.
- When you make an object, you don't pass `self`. Python does that for you.

**Try it:** Make a third player and print their name.

---

## Part 5: Methods

A **method** is a function inside a class. It always has `self` first, so it can use the object's attributes.

```python
class Player:
    def __init__(self, name, points):
        self.name = name
        self.points = points

    def add_points(self, amount):
        """Purpose: add to this player's points.
        Parameters: amount (int) - points to add
        Returns: nothing
        """
        self.points = self.points + amount

player = Player("Avery", 40)
player.add_points(15)           # call a method with a dot
player.add_points(5)
print(f"{player.name} has {player.points} points")
```

```text
Avery has 60 points
```

**Try it:** Add a method `reset(self)` that sets the points back to 0.

---

## Part 6: A list of objects

A list can hold objects. A loop goes through them, and each item has its own attributes.

```python
class Player:
    def __init__(self, name, points):
        self.name = name
        self.points = points

team = []
team.append(Player("Avery", 40))
team.append(Player("Blake", 25))
team.append(Player("Casey", 33))

total = 0
for player in team:
    print(f"{player.name:<8}{player.points:>4}")
    total = total + player.points
print(f"Team total: {total}")
```

```text
Avery     40
Blake     25
Casey     33
Team total: 98
```

To find one object, loop and compare. Use `.lower()` so the search ignores capitals:

<!-- input: casey -->
```python
class Player:
    def __init__(self, name, points):
        self.name = name
        self.points = points

team = [Player("Avery", 40), Player("Blake", 25), Player("Casey", 33)]

search = input("Find player: ").strip().lower()
found = False
for player in team:
    if player.name.lower() == search:
        print(f"{player.name} has {player.points} points")
        found = True
if not found:
    print("No player by that name.")
```

```text
Find player: casey
Casey has 33 points
```

---

## Part 7: A menu with a list of objects

Here is a short program that puts it together: a class, a list of objects, and a menu with one function per option.

<!-- input: 1|Avery|1|Blake|2|3 -->
```python
class Player:
    def __init__(self, name, points):
        self.name = name
        self.points = points

def add_player(team):
    """Purpose: ask for a name and add a new player.
    Parameters: team (list of Player)
    Returns: nothing
    """
    name = input("Name: ").strip()
    team.append(Player(name, 0))
    print(f"Added {name}.")

def show_team(team):
    """Purpose: print every player. Parameters: team (list of Player). Returns: nothing"""
    for player in team:
        print(f"{player.name}: {player.points}")

def main():
    """Purpose: run the menu. Parameters: none. Returns: nothing"""
    team = []
    choice = 0
    while choice != 3:
        print("1. Add player  2. Show team  3. Quit")
        choice = int(input("Choose: "))
        if choice == 1:
            add_player(team)
        elif choice == 2:
            show_team(team)
    print("Bye!")

if __name__ == "__main__":
    main()
```

```text
1. Add player  2. Show team  3. Quit
Choose: 1
Name: Avery
Added Avery.
1. Add player  2. Show team  3. Quit
Choose: 1
Name: Blake
Added Blake.
1. Add player  2. Show team  3. Quit
Choose: 2
Avery: 0
Blake: 0
1. Add player  2. Show team  3. Quit
Choose: 3
Bye!
```

The list `team` is made in `main()` and passed to each function. When `add_player` appends to it, `main()` sees the new player too.

---

## Common mistakes

1. **Forgetting `self`.** Every method needs `self` first, and attributes are `self.name`, not just `name`.
2. **One underscore instead of two.** It's `__init__`.
3. **Passing `self` when making an object.** Write `Player("Avery", 40)`, not `Player(self, "Avery", 40)`.
4. **Printing the object itself.** `print(player)` shows something like `<__main__.Player object at 0x...>`. Print its attributes instead. (The study guide shows how `__str__` fixes this.)
5. **A menu loop that never ends.** Make sure the Quit choice makes the loop condition False.

---

## Next steps
1. Do the [Step 11 Practice](step11_Practice.md) problems.
2. Keep the [Step 11 Study Guide](step11_StudyGuide.md) open while you work. Print it for BPA.
3. After the practice, try the [Step 11 builds](../bpaBuilds/build11_menuProgram.md). Then move on to the Step 12 timed builds.
