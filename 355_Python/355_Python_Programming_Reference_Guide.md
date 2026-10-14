# 355 Python Programming Reference Guide

## Essential Python Concepts for BPA Competition

### Basic Program Structure
```python
# Python programs start executing from the top
# No main() required, but recommended for organization

def main():
    # Your code here
    print("Hello, World!")

if __name__ == "__main__":
    main()
```

### Input and Output
```python
# Basic input (always returns string)
name = input("Enter your name: ")

# Convert input to numbers
age = int(input("Enter age: "))
gpa = float(input("Enter GPA: "))

# Output
print("Hello", name)
print(f"Your age is {age}")  # f-string (formatted)
print("Value: {}".format(value))  # .format()
```

### Input Validation
```python
# Validate integer input
while True:
    try:
        number = int(input("Enter a number: "))
        
        # Check range
        if number < 1 or number > 50:
            print("Number must be between 1 and 50")
            continue
        break
    except ValueError:
        print("Invalid input. Please enter a whole number.")

# Validate with function
def get_valid_int(prompt, min_val, max_val):
    while True:
        try:
            value = int(input(prompt))
            if min_val <= value <= max_val:
                return value
            else:
                print(f"Value must be between {min_val} and {max_val}")
        except ValueError:
            print("Invalid input. Please enter a number.")
```

### Random Numbers
```python
import random

# Random integer in range (inclusive)
num = random.randint(1, 10)  # 1-10
grade = random.randint(9, 12)  # 9-12

# Random float from 0.0 to 1.0
value = random.random()

# Random float in range
gpa = random.uniform(1.0, 4.0)  # 1.0-4.0

# Random choice from list
names = ["Alice", "Bob", "Charlie"]
name = random.choice(names)

# Random sample (no duplicates)
selected = random.sample(names, 2)
```

### Number Formatting
```python
# Format to 2 decimal places
gpa = 3.456789
formatted = f"{gpa:.2f}"  # "3.46"
formatted = "{:.2f}".format(gpa)  # "3.46"
formatted = round(gpa, 2)  # 3.46

# Print with formatting
print(f"GPA: {gpa:.2f}")
```

### Lists (Arrays)
```python
# Create lists
names = ["Alice", "Bob", "Charlie"]
numbers = [1, 2, 3, 4, 5]
empty = []

# Access elements
first = names[0]  # "Alice"
last = names[-1]  # "Charlie"

# Add elements
names.append("David")  # Add to end
names.insert(0, "Eve")  # Insert at position

# Remove elements
names.remove("Bob")  # Remove by value
names.pop()  # Remove and return last
names.pop(0)  # Remove and return at index

# List operations
length = len(names)
if "Alice" in names:
    print("Found!")

# Slicing
sub_list = names[1:3]  # Elements 1 and 2
first_two = names[:2]
last_two = names[-2:]

# Loop through list
for name in names:
    print(name)

for i in range(len(names)):
    print(f"{i}: {names[i]}")

# List comprehension
squares = [x**2 for x in range(10)]
even = [x for x in range(20) if x % 2 == 0]
```

### Strings
```python
name = "John Doe"

# Length
length = len(name)

# Access characters
first_char = name[0]  # 'J'

# Slicing
first_name = name[:4]  # "John"

# String methods
upper = name.upper()  # "JOHN DOE"
lower = name.lower()  # "john doe"
title = name.title()  # "John Doe"

# Check contents
if "Doe" in name:
    print("Found!")

# Split and join
parts = name.split()  # ["John", "Doe"]
full = " ".join(parts)  # "John Doe"

# Replace
new_name = name.replace("Doe", "Smith")

# String formatting
print(f"Name: {name}, Length: {length}")
```

### Dictionaries
```python
# Create dictionary
student = {
    "first_name": "John",
    "last_name": "Doe",
    "grade": 11,
    "gpa": 3.5
}

# Access values
first = student["first_name"]
first = student.get("first_name")  # Safer

# Add or update
student["age"] = 16
student["gpa"] = 3.7

# Check if key exists
if "first_name" in student:
    print(student["first_name"])

# Loop through dictionary
for key in student:
    print(f"{key}: {student[key]}")

for key, value in student.items():
    print(f"{key}: {value}")

# Dictionary of lists
classes = {
    "Math": ["Alice", "Bob"],
    "Science": ["Charlie", "David"]
}
```

### Functions
```python
# Basic function
def greet(name):
    print(f"Hello, {name}!")

# Function with return value
def add(a, b):
    return a + b

# Function with default parameters
def power(base, exponent=2):
    return base ** exponent

# Function with multiple returns
def get_min_max(numbers):
    return min(numbers), max(numbers)

min_val, max_val = get_min_max([1, 2, 3, 4, 5])

# Function with variable arguments
def sum_all(*args):
    return sum(args)

total = sum_all(1, 2, 3, 4, 5)
```

### Classes and Objects
```python
class Student:
    # Constructor
    def __init__(self, first_name, last_name, grade_level, gpa):
        self.first_name = first_name
        self.last_name = last_name
        self.grade_level = grade_level
        self.gpa = gpa
    
    # Method
    def get_full_name(self):
        return f"{self.first_name} {self.last_name}"
    
    # String representation
    def __str__(self):
        return f"{self.last_name}, {self.first_name} | {self.grade_level} | {self.gpa:.2f}"

# Create and use objects
student = Student("John", "Doe", 11, 3.5)
print(student.first_name)
print(student.get_full_name())
print(student)  # Calls __str__()
```

### Loops
```python
# For loop with range
for i in range(10):  # 0-9
    print(i)

for i in range(1, 11):  # 1-10
    print(i)

for i in range(0, 10, 2):  # 0, 2, 4, 6, 8
    print(i)

# For loop with list
names = ["Alice", "Bob", "Charlie"]
for name in names:
    print(name)

# For loop with enumerate
for i, name in enumerate(names):
    print(f"{i}: {name}")

# While loop
i = 0
while i < 10:
    print(i)
    i += 1

# Break and continue
for i in range(10):
    if i == 5:
        break  # Exit loop
    if i % 2 == 0:
        continue  # Skip to next iteration
    print(i)
```

### Conditionals
```python
# If-elif-else
grade = 85
if grade >= 90:
    print("A")
elif grade >= 80:
    print("B")
elif grade >= 70:
    print("C")
else:
    print("D or F")

# Ternary operator
result = "Pass" if score >= 50 else "Fail"

# Multiple conditions
if age >= 16 and has_license:
    print("Can drive")

if is_weekend or is_holiday:
    print("Day off")
```

### File Operations
```python
# Writing to file
with open("output.txt", "w") as file:
    file.write("Hello, World!\n")
    file.write("Another line\n")

# Reading from file
with open("input.txt", "r") as file:
    content = file.read()  # Read entire file
    
with open("input.txt", "r") as file:
    lines = file.readlines()  # Read as list of lines

with open("input.txt", "r") as file:
    for line in file:  # Read line by line
        print(line.strip())

# Append to file
with open("output.txt", "a") as file:
    file.write("Appended text\n")
```

### Common Operations
```python
# Math operations
import math

# Rounding
rounded = round(3.7)  # 4
rounded = round(3.14159, 2)  # 3.14

# Floor and ceiling
floored = math.floor(3.7)  # 3
ceiled = math.ceil(3.2)  # 4

# Power and square root
power = math.pow(2, 3)  # 8.0
power = 2 ** 3  # 8
sqrt = math.sqrt(16)  # 4.0

# Absolute value
abs_val = abs(-5)  # 5

# Min and max
minimum = min(1, 2, 3)  # 1
maximum = max(1, 2, 3)  # 3
```

### Common Mistakes to Avoid
1. **Indentation errors** - Python uses indentation for blocks
2. **Using = instead of ==** - = is assignment, == is comparison
3. **Forgetting to convert input()** - input() always returns string
4. **Index errors** - Remember lists start at 0
5. **Not using .append()** - Can't do `list[10] = value` if list has 5 items

### Common BPA Contest Patterns

#### Pattern 1: Generate Random Student Records
```python
import random

first_names = ["Alice", "Bob", "Charlie", "Diana"]
last_names = ["Smith", "Johnson", "Williams", "Brown"]

students = []
for i in range(num_students):
    # Ensure first and last name are different
    first = random.choice(first_names)
    last = random.choice(last_names)
    while first == last:
        last = random.choice(last_names)
    
    grade = random.randint(9, 12)
    gpa = round(random.uniform(1.0, 4.0), 2)
    
    student = Student(first, last, grade, gpa)
    students.append(student)
```

#### Pattern 2: Print Formatted List
```python
for i, student in enumerate(students, 1):
    print(f"{i}. {student}")
```

#### Pattern 3: Input Validation Loop
```python
def get_student_count():
    while True:
        try:
            count = int(input("Enter number of students (1-50): "))
            if 1 <= count <= 50:
                return count
            print("Number must be between 1 and 50")
        except ValueError:
            print("Invalid input. Enter a whole number.")
```

### Quick Reference: Import Statements
```python
import random      # Random numbers
import math        # Math functions
import sys         # System functions
from random import randint, choice  # Import specific functions
```

### Python-Specific Tips
1. Use meaningful variable names (snake_case for Python)
2. Add docstrings to functions: `"""This is what the function does"""`
3. Use list comprehensions for cleaner code
4. Remember: Python is 0-indexed
5. Use `if __name__ == "__main__":` for main code

---
**Remember**: Python uses indentation to define code blocks. Be consistent with 4 spaces!
