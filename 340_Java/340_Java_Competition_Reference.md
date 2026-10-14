# Java Programming Competition Reference Guide
## Comprehensive Study Material for BPA Competitions

---

## Table of Contents
1. [Competition Format & Requirements](#competition-format--requirements)
2. [Program Structure & Setup](#program-structure--setup)
3. [Input & Validation](#input--validation)
4. [Data Types & Variables](#data-types--variables)
5. [Operators & Expressions](#operators--expressions)
6. [Control Structures](#control-structures)
7. [Methods & Functions](#methods--functions)
8. [String Operations](#string-operations)
9. [Arrays](#arrays)
10. [ArrayLists](#arraylists)
11. [Random Number Generation](#random-number-generation)
12. [Output Formatting](#output-formatting)
13. [Exception Handling](#exception-handling)
14. [Object-Oriented Programming](#object-oriented-programming)
15. [Common Algorithms & Patterns](#common-algorithms--patterns)
16. [Debugging & Testing](#debugging--testing)
17. [Complete Example Programs](#complete-example-programs)

---

## Competition Format & Requirements

### What You Need to Know

BPA Java competitions typically require you to:
1. Write a complete program in 90 minutes
2. Use specific variable names with your contestant ID
3. Match exact prompts and output formats
4. Include flag comments for code review
5. Handle input validation with exception handling
6. Work with objects and ArrayLists
7. Format output using printf or DecimalFormat
8. Submit working code on a flash drive

### Critical Rules (These Can Disqualify You!)

```java
// ❌ WRONG - No contestant ID comment
public class MyProgram {

// ✅ CORRECT - Contestant ID at top
// Contestant Number: 12345
public class MyProgram {

// ❌ WRONG - Missing xx suffix on variables
int total;
String userName;

// ✅ CORRECT - Last 2 digits of contestant ID (45 from 12345)
int total45;
String userName45;

// ❌ WRONG - Using break to exit loop
while (count < target) {
    if (count == target) {
        break;  // NOT ALLOWED
    }
}

// ✅ CORRECT - Exit through loop condition
while (count < target) {
    // Loop naturally exits when condition becomes false
}

// ❌ WRONG - Prompt doesn't match exactly
System.out.print("Enter name:");

// ✅ CORRECT - Exact spacing and punctuation
System.out.print("Enter name: ");
```

### Grading Breakdown

**Program Execution (260-280 points)**
- Program runs without errors
- Correct input handling
- Correct calculations
- Exact output format
- Proper validation

**Source Code Review (320-340 points)**
- Flag comments present (5 points each)
- Code segments work correctly (10-25 points each)
- Proper use of required structures (Scanner, Random, switch, loops)
- Variable naming conventions
- Comments explaining logic

---

## Program Structure & Setup

### Required Imports

```java
// Scanner for user input
import java.util.Scanner;

// Random number generation
import java.util.Random;

// ArrayList for dynamic collections
import java.util.ArrayList;

// Number formatting
import java.text.DecimalFormat;

// Exception handling (usually automatic)
import java.util.InputMismatchException;
```

### Complete Program Template

```java
// Contestant Number: 12345
/*
 * Program: ProgramName
 * Description: Brief description of what this program does
 * Author: Contestant 12345
 */

import java.util.Scanner;
import java.util.Random;
import java.util.ArrayList;
import java.text.DecimalFormat;

public class ProgramName {
    
    // Class-level static variables (if needed)
    static Scanner input;
    static Random rand;
    
    public static void main(String[] args) {
        // INPUT: Describe how data is collected
        
        // PROCESSING: Explain the logic and algorithms used
        
        // OUTPUT: Describe the format and content of results
        
    }
    
    // Helper methods go here
    
}
```

### File Naming and Organization

```java
// Main program file must match class name
// If class is: public class ShoppingCart
// File must be: ShoppingCart.java

// For object classes (separate files)
// Class: public class Product
// File: Product.java

// Folder structure for submission
ContestantID_Folder/
    ├── ShoppingCart.java
    ├── Product.java
    └── (any other required files)
```

---

## Input & Validation

### Scanner Basics

```java
import java.util.Scanner;

//SC1: Create Scanner object for user input
Scanner input = new Scanner(System.in);

// Read different types of input
String fullLine = input.nextLine();    // Reads entire line including spaces
String word = input.next();            // Reads one word (stops at space)
int number = input.nextInt();          // Reads an integer
double decimal = input.nextDouble();   // Reads a decimal number
boolean flag = input.nextBoolean();    // Reads true/false

// CRITICAL: Always close Scanner when done
input.close();
```

### Scanner Input Buffer Issues

```java
// PROBLEM: Mixing nextInt() with nextLine()
System.out.print("Enter age: ");
int age = input.nextInt();              // Leaves \n in buffer
System.out.print("Enter name: ");
String name = input.nextLine();         // Reads the leftover \n!

// SOLUTION 1: Add extra nextLine() to clear buffer
System.out.print("Enter age: ");
int age = input.nextInt();
input.nextLine();  // Clear the buffer
System.out.print("Enter name: ");
String name = input.nextLine();  // Now works correctly

// SOLUTION 2: Use nextLine() and parse
System.out.print("Enter age: ");
int age = Integer.parseInt(input.nextLine());
System.out.print("Enter name: ");
String name = input.nextLine();
```

### Input Validation - Complete Pattern

```java
//SC3: Collect user input with validation
private static int getValidInteger(Scanner input, String prompt, int min, int max) {
    int value = 0;
    boolean valid = false;
    
    System.out.print(prompt);
    
    while (!valid) {
        //SC4: Exception handling for invalid data types
        try {
            value = input.nextInt();
            
            //SC5: Range validation strategy
            if (value >= min && value <= max) {
                valid = true;  // Exit loop condition
            } else {
                System.out.printf("Value must be between %d and %d: ", min, max);
            }
            
        } catch (InputMismatchException e) {
            System.out.print("Invalid input. Please enter a number: ");
            input.next();  // Clear the invalid input from buffer
        }
    }
    
    return value;
}

// Usage
int quantity45 = getValidInteger(input, "Enter quantity (1-100): ", 1, 100);
```

### Validating String Input

```java
// Validate non-empty string
private static String getValidString(Scanner input, String prompt) {
    String value = "";
    
    while (value.trim().isEmpty()) {
        System.out.print(prompt);
        value = input.nextLine();
        
        if (value.trim().isEmpty()) {
            System.out.print("Input cannot be empty. ");
        }
    }
    
    return value;
}

// Usage
String name45 = getValidString(input, "Enter your name: ");
```

### Multiple Input Validation Example

```java
// Collecting and validating multiple inputs
public static void main(String[] args) {
    Scanner input = new Scanner(System.in);
    
    // INPUT: Collect all required information
    System.out.print("Enter your name: ");
    String userName45 = input.nextLine();
    
    int age45 = getValidInteger(input, "Enter age (1-120): ", 1, 120);
    
    // Clear buffer after nextInt
    input.nextLine();
    
    System.out.print("Enter city: ");
    String city45 = input.nextLine();
    
    int items45 = getValidInteger(input, "How many items (1-50): ", 1, 50);
    
    // Process inputs...
    
    input.close();
}
```

---

## Data Types & Variables

### Primitive Data Types

```java
// Integer types (whole numbers)
byte smallNum = 127;           // -128 to 127
short mediumNum = 32000;       // -32,768 to 32,767
int regularNum = 2000000;      // -2.1 billion to 2.1 billion (MOST COMMON)
long bigNum = 9000000000L;     // Very large numbers (note the L)

// Floating-point types (decimals)
float smallDecimal = 3.14f;    // 6-7 decimal digits (note the f)
double largeDecimal = 3.14159; // 15-16 decimal digits (MOST COMMON)

// Other types
boolean isValid = true;        // true or false only
char letter = 'A';             // Single character (use single quotes)

// String (technically not primitive, but acts like one)
String text = "Hello";         // Text (use double quotes)
```

### Variable Naming with Contestant ID

```java
// If contestant number is 12345, last 2 digits are 45
// Add 45 to end of each required variable name

// ✅ CORRECT naming
String customerName45;
int orderQuantity45;
double totalPrice45;
boolean isActive45;

// ❌ WRONG - Missing suffix
String customerName;
int orderQuantity;

// Variable naming rules
// - Must start with letter, $, or _
// - Can contain letters, digits, $, _
// - Cannot use Java keywords (int, class, public, etc.)
// - Case sensitive (total45 ≠ Total45)

// Good naming conventions
int studentCount45;      // camelCase for variables
final int MAX_SIZE45;    // UPPER_CASE for constants
String firstName45;      // descriptive names
```

### Type Casting and Conversion

```java
// Automatic casting (widening)
int whole = 5;
double decimal = whole;  // 5.0 - automatic conversion

// Manual casting (narrowing)
double price = 9.99;
int dollars = (int) price;  // 9 - decimal part lost

// Integer division vs double division
int a = 7;
int b = 2;
int result1 = a / b;           // 3 (integer division)
double result2 = (double)a / b; // 3.5 (double division)

// String to number conversion
String text = "123";
int number = Integer.parseInt(text);      // Convert String to int
double decimal = Double.parseDouble(text); // Convert String to double

// Number to String conversion
int age = 25;
String ageText = String.valueOf(age);  // "25"
String ageText2 = "" + age;            // "25" (concatenation trick)
```

### Constants

```java
// Use final keyword for values that don't change
final int MAX_STUDENTS = 30;
final double TAX_RATE = 0.07;
final String SCHOOL_NAME = "Tech High";

// Convention: Use ALL_CAPS with underscores
// Benefits: Prevents accidental changes, makes code clearer
```

---

## Operators & Expressions

### Arithmetic Operators

```java
int a = 10;
int b = 3;

// Basic arithmetic
int sum = a + b;        // 13 (addition)
int diff = a - b;       // 7 (subtraction)
int product = a * b;    // 30 (multiplication)
int quotient = a / b;   // 3 (integer division)
int remainder = a % b;  // 1 (modulus - IMPORTANT!)

// Double division
double result = 10.0 / 3.0;  // 3.333...
double result2 = (double)a / b;  // 3.333... (cast one operand)

// Modulus operator uses
System.out.println(10 % 2);  // 0 (even number)
System.out.println(11 % 2);  // 1 (odd number)
System.out.println(17 % 5);  // 2 (remainder)

// Negative modulus
System.out.println(-10 % 3);  // -1 (keeps sign of dividend)
```

### Increment and Decrement

```java
int count = 5;

// Post-increment/decrement (use then modify)
int a = count++;  // a = 5, count = 6
int b = count--;  // b = 6, count = 5

// Pre-increment/decrement (modify then use)
int c = ++count;  // count = 6, c = 6
int d = --count;  // count = 5, d = 5

// Common usage in loops
for (int i = 0; i < 10; i++) {  // i++ is typical
    System.out.println(i);
}

// Compound assignment operators
count += 5;  // Same as: count = count + 5
count -= 3;  // Same as: count = count - 3
count *= 2;  // Same as: count = count * 2
count /= 2;  // Same as: count = count / 2
count %= 3;  // Same as: count = count % 3
```

### Comparison Operators

```java
int x = 10;
int y = 5;

// Equality and inequality
boolean isEqual = (x == y);      // false
boolean notEqual = (x != y);     // true

// Relational operators
boolean greater = (x > y);       // true
boolean greaterEq = (x >= y);    // true
boolean less = (x < y);          // false
boolean lessEq = (x <= y);       // false

// CRITICAL: Don't confuse = with ==
int a = 5;  // Assignment
if (a == 5) { }  // Comparison
```

### Logical Operators

```java
// AND operator (&&) - both must be true
boolean result1 = (age >= 18) && (hasLicense);  // Both conditions required

// OR operator (||) - at least one must be true
boolean result2 = (isWeekend) || (isHoliday);   // Either condition works

// NOT operator (!) - reverses boolean value
boolean result3 = !(isRaining);  // true if NOT raining

// Complex conditions
if ((age >= 18 && age <= 65) && (income > 30000)) {
    // Working age adult with sufficient income
}

// Short-circuit evaluation
// With &&: If first is false, second isn't checked
// With ||: If first is true, second isn't checked
if ((x != 0) && (100 / x > 5)) {  // Safe from division by zero
    // Code here
}
```

### Operator Precedence

```java
// Order of operations (highest to lowest)
// 1. Parentheses: ()
// 2. Multiplication, Division, Modulus: * / %
// 3. Addition, Subtraction: + -
// 4. Comparison: < <= > >=
// 5. Equality: == !=
// 6. Logical AND: &&
// 7. Logical OR: ||

// Examples
int result = 2 + 3 * 4;        // 14 (not 20)
int result2 = (2 + 3) * 4;     // 20 (parentheses first)

boolean check = 5 > 3 && 10 < 20;  // true && true = true

// Use parentheses to make complex expressions clear
boolean valid = ((age >= 18) && (age <= 65)) || (hasPermit);
```

---

## Control Structures

### If Statements

```java
// Simple if
if (temperature > 90) {
    System.out.println("It's hot!");
}

// If-else
if (score >= 60) {
    System.out.println("Pass");
} else {
    System.out.println("Fail");
}

// If-else if-else chain
if (grade >= 90) {
    letterGrade = 'A';
} else if (grade >= 80) {
    letterGrade = 'B';
} else if (grade >= 70) {
    letterGrade = 'C';
} else if (grade >= 60) {
    letterGrade = 'D';
} else {
    letterGrade = 'F';
}

// Nested if statements
if (age >= 16) {
    if (hasPermit) {
        System.out.println("Can drive with supervision");
    } else {
        System.out.println("Need to get permit");
    }
} else {
    System.out.println("Too young to drive");
}

// Multiple conditions
if (temperature > 80 && humidity > 70) {
    System.out.println("Hot and humid");
}

if (day.equals("Saturday") || day.equals("Sunday")) {
    System.out.println("Weekend!");
}
```

### Switch Statements

```java
// Basic switch with int
int choice = 2;

switch (choice) {
    case 1:
        System.out.println("Option 1 selected");
        break;
    case 2:
        System.out.println("Option 2 selected");
        break;
    case 3:
        System.out.println("Option 3 selected");
        break;
    default:
        System.out.println("Invalid option");
        break;
}

// Switch with String (Java 7+)
String day = "Monday";

switch (day) {
    case "Monday":
    case "Tuesday":
    case "Wednesday":
    case "Thursday":
    case "Friday":
        System.out.println("Weekday");
        break;
    case "Saturday":
    case "Sunday":
        System.out.println("Weekend");
        break;
    default:
        System.out.println("Invalid day");
        break;
}

// Competition pattern: Set operation and calculate result
int operationType45 = 3;
String symbol45;
int num1_45 = 10;
int num2_45 = 5;
int answer45;

switch (operationType45) {
    case 1:
        symbol45 = "+";
        answer45 = num1_45 + num2_45;
        break;
    case 2:
        symbol45 = "-";
        answer45 = num1_45 - num2_45;
        break;
    case 3:
        symbol45 = "*";
        answer45 = num1_45 * num2_45;
        break;
    case 4:
        symbol45 = "/";
        answer45 = num1_45 / num2_45;
        break;
    default:
        symbol45 = "?";
        answer45 = 0;
        break;
}

System.out.printf("%d %s %d = %d%n", num1_45, symbol45, num2_45, answer45);
```

### While Loops

```java
// Basic while loop
int count = 0;
while (count < 5) {
    System.out.println("Count: " + count);
    count++;
}

// Loop with user input
Scanner input = new Scanner(System.in);
String response = "";

while (!response.equals("quit")) {
    System.out.print("Enter command (or 'quit'): ");
    response = input.nextLine();
    System.out.println("You entered: " + response);
}

// COMPETITION PATTERN: Loop until target reached
int correctAnswers45 = 0;
int requiredCorrect45 = 10;

while (correctAnswers45 < requiredCorrect45) {
    // Generate problem
    int problem = generateProblem();
    
    // Get user answer
    System.out.print("Answer: ");
    int userAnswer = input.nextInt();
    
    // Check if correct
    if (userAnswer == problem) {
        correctAnswers45++;
        System.out.println("Correct!");
    } else {
        System.out.println("Incorrect. Try again!");
    }
}
// Loop exits through condition, NOT break statement

System.out.printf("You answered %d correctly!%n", correctAnswers45);
```

### Do-While Loops

```java
// Do-while executes at least once
int number;
Scanner input = new Scanner(System.in);

do {
    System.out.print("Enter a positive number: ");
    number = input.nextInt();
} while (number <= 0);

// Use when you always want to execute at least once
String password;
do {
    System.out.print("Create password (min 8 characters): ");
    password = input.nextLine();
    
    if (password.length() < 8) {
        System.out.println("Password too short!");
    }
} while (password.length() < 8);
```

### For Loops

```java
// Standard for loop
for (int i = 0; i < 10; i++) {
    System.out.println(i);  // 0 through 9
}

// Loop with different increment
for (int i = 0; i <= 100; i += 10) {
    System.out.println(i);  // 0, 10, 20, ..., 100
}

// Countdown loop
for (int i = 10; i >= 1; i--) {
    System.out.println(i);  // 10 down to 1
}

// Loop through array
int[] numbers = {10, 20, 30, 40, 50};
for (int i = 0; i < numbers.length; i++) {
    System.out.println(numbers[i]);
}

// Enhanced for loop (for-each)
for (int num : numbers) {
    System.out.println(num);
}

// Loop through ArrayList
ArrayList<String> names = new ArrayList<>();
for (int i = 0; i < names.size(); i++) {
    System.out.println(names.get(i));
}

// Enhanced for loop with ArrayList
for (String name : names) {
    System.out.println(name);
}
```

### Nested Loops

```java
// Nested loops for 2D patterns
for (int row = 0; row < 5; row++) {
    for (int col = 0; col < 5; col++) {
        System.out.print("* ");
    }
    System.out.println();  // New line after each row
}

// Multiplication table
for (int i = 1; i <= 10; i++) {
    for (int j = 1; j <= 10; j++) {
        System.out.printf("%4d", i * j);
    }
    System.out.println();
}

// Processing 2D data
for (int student = 0; student < students.size(); student++) {
    for (int quiz = 0; quiz < 5; quiz++) {
        // Process each quiz for each student
    }
}
```

### Loop Control: When NOT to Use Break

```java
// ❌ WRONG - Using break in competition
int count = 0;
while (true) {
    count++;
    if (count == 10) {
        break;  // NOT ALLOWED in competitions
    }
}

// ✅ CORRECT - Exit through loop condition
int count = 0;
while (count < 10) {
    count++;
    // Loop naturally exits when condition is false
}

// ✅ CORRECT - Boolean flag for complex conditions
boolean continueLoop = true;
int attempts = 0;

while (continueLoop && attempts < 10) {
    // Do something
    if (successCondition) {
        continueLoop = false;  // Set flag to exit
    }
    attempts++;
}
```

---

## Methods & Functions

### Method Basics

```java
// Method structure:
// accessModifier returnType methodName(parameters) {
//     // method body
//     return value;  // if not void
// }

// Void method (no return value)
public static void printGreeting() {
    System.out.println("Hello, World!");
}

// Method with return value
public static int add(int a, int b) {
    int sum = a + b;
    return sum;
}

// Method with multiple parameters
public static double calculateAverage(int score1, int score2, int score3) {
    double sum = score1 + score2 + score3;
    double average = sum / 3.0;
    return average;
}

// Calling methods
public static void main(String[] args) {
    printGreeting();                    // Void method
    
    int result = add(5, 3);             // Method with return
    System.out.println(result);         // 8
    
    double avg = calculateAverage(85, 92, 78);
    System.out.println("Average: " + avg);
}
```

### Input Validation Methods

```java
// Reusable method for integer validation
private static int getValidInteger(Scanner input, String prompt, 
                                   int min, int max) {
    int value = 0;
    boolean valid = false;
    
    System.out.print(prompt);
    
    while (!valid) {
        try {
            value = input.nextInt();
            
            if (value >= min && value <= max) {
                valid = true;
            } else {
                System.out.printf("Must be between %d and %d: ", min, max);
            }
        } catch (InputMismatchException e) {
            System.out.print("Invalid. Enter a number: ");
            input.next();
        }
    }
    
    return value;
}

// String validation method
private static String getNonEmptyString(Scanner input, String prompt) {
    String value = "";
    
    while (value.trim().isEmpty()) {
        System.out.print(prompt);
        value = input.nextLine();
        
        if (value.trim().isEmpty()) {
            System.out.print("Cannot be empty. ");
        }
    }
    
    return value;
}

// Usage in main
int age = getValidInteger(input, "Enter age (1-120): ", 1, 120);
String name = getNonEmptyString(input, "Enter name: ");
```

### Methods for Processing Data

```java
// Calculate total from ArrayList
private static int calculateTotal(ArrayList<Integer> scores) {
    int total = 0;
    for (int score : scores) {
        total += score;
    }
    return total;
}

// Calculate average
private static double calculateAverage(ArrayList<Integer> scores) {
    if (scores.size() == 0) {
        return 0.0;
    }
    int total = calculateTotal(scores);
    return (double) total / scores.size();
}

// Find maximum value
private static int findMax(ArrayList<Integer> scores) {
    if (scores.size() == 0) {
        return 0;
    }
    
    int max = scores.get(0);
    for (int i = 1; i < scores.size(); i++) {
        if (scores.get(i) > max) {
            max = scores.get(i);
        }
    }
    return max;
}

// Find minimum value
private static int findMin(ArrayList<Integer> scores) {
    if (scores.size() == 0) {
        return 0;
    }
    
    int min = scores.get(0);
    for (int i = 1; i < scores.size(); i++) {
        if (scores.get(i) < min) {
            min = scores.get(i);
        }
    }
    return min;
}
```

### Methods Returning Objects

```java
// Method that creates and returns an object
private static Book createBook(Scanner input) {
    System.out.print("Enter title: ");
    String title = input.nextLine();
    
    System.out.print("Enter author: ");
    String author = input.nextLine();
    
    System.out.print("Enter pages: ");
    int pages = input.nextInt();
    input.nextLine();  // Clear buffer
    
    return new Book(title, author, pages);
}

// Method that returns ArrayList of objects
private static ArrayList<Book> generateRandomBooks(int count, Random rand) {
    ArrayList<Book> books = new ArrayList<>();
    String[] titles = {"Programming", "Databases", "Networks", "Security"};
    String[] authors = {"Smith", "Johnson", "Williams", "Brown"};
    
    for (int i = 0; i < count; i++) {
        String title = titles[rand.nextInt(titles.length)];
        String author = authors[rand.nextInt(authors.length)];
        int pages = rand.nextInt(400) + 100;
        
        books.add(new Book(title, author, pages));
    }
    
    return books;
}
```

### Method Overloading

```java
// Same method name, different parameters
public static int multiply(int a, int b) {
    return a * b;
}

public static double multiply(double a, double b) {
    return a * b;
}

public static int multiply(int a, int b, int c) {
    return a * b * c;
}

// Java chooses correct method based on arguments
int result1 = multiply(5, 3);           // Uses first method
double result2 = multiply(5.5, 3.2);    // Uses second method
int result3 = multiply(2, 3, 4);        // Uses third method
```

---

## String Operations

### String Basics

```java
// Creating strings
String str1 = "Hello";
String str2 = new String("World");
String str3 = str1 + " " + str2;  // Concatenation

// String is immutable (cannot be changed)
String name = "John";
name.toUpperCase();  // Creates new String, doesn't change name
System.out.println(name);  // Still "John"

String upper = name.toUpperCase();  // Store the result
System.out.println(upper);  // "JOHN"
```

### String Comparison (CRITICAL!)

```java
String str1 = "apple";
String str2 = "apple";
String str3 = "banana";
String str4 = new String("apple");

// ❌ WRONG - Don't use == for strings
if (str1 == str2) { }  // Compares memory addresses!

// ✅ CORRECT - Use .equals()
if (str1.equals(str2)) {
    System.out.println("Strings are equal");  // TRUE
}

if (str1.equals(str3)) {
    System.out.println("Equal");
} else {
    System.out.println("Not equal");  // This prints
}

// Case-insensitive comparison
if (str1.equalsIgnoreCase("APPLE")) {
    System.out.println("Equal ignoring case");  // TRUE
}

// Alphabetical comparison with .compareTo()
int result = str1.compareTo(str3);
if (result < 0) {
    System.out.println("str1 comes before str3");  // TRUE
} else if (result > 0) {
    System.out.println("str1 comes after str3");
} else {
    System.out.println("Strings are equal");
}

//SC15: COMPETITION PATTERN - Comparing object attributes
// Inside a class method
public boolean languagesMatch() {
    return this.primaryLang.equals(this.secondaryLang);
}
```

### Common String Methods

```java
String text = "Java Programming";

// Length
int len = text.length();  // 16

// Character at index
char firstChar = text.charAt(0);    // 'J'
char lastChar = text.charAt(text.length() - 1);  // 'g'

// Substring
String sub1 = text.substring(5);        // "Programming"
String sub2 = text.substring(0, 4);     // "Java" (start to end-1)
String sub3 = text.substring(5, 9);     // "Prog"

// Index operations
int index = text.indexOf('P');          // 5 (first occurrence)
int lastIndex = text.lastIndexOf('a');  // 11 (last occurrence)
int notFound = text.indexOf('z');       // -1 (not found)

// Check if contains
boolean hasProg = text.contains("Prog");  // true
boolean hasX = text.contains("xyz");      // false

// Case conversion
String upper = text.toUpperCase();      // "JAVA PROGRAMMING"
String lower = text.toLowerCase();      // "java programming"

// Trim whitespace
String messy = "  hello world  ";
String clean = messy.trim();  // "hello world"

// Replace characters/strings
String replaced = text.replace('a', 'o');       // "Jovo Progromming"
String replaced2 = text.replace("Java", "C++"); // "C++ Programming"

// Split string
String sentence = "one,two,three";
String[] parts = sentence.split(",");  // ["one", "two", "three"]

// Check start/end
boolean starts = text.startsWith("Java");  // true
boolean ends = text.endsWith("ing");       // true

// Empty check
String empty = "";
boolean isEmpty = empty.isEmpty();         // true
boolean isEmpty2 = empty.length() == 0;    // true (same thing)
```

### String Building

```java
// String concatenation (simple but inefficient for loops)
String result = "";
for (int i = 0; i < 5; i++) {
    result += i + " ";  // Creates new String each time
}

// StringBuilder (efficient for many concatenations)
StringBuilder sb = new StringBuilder();
for (int i = 0; i < 5; i++) {
    sb.append(i);
    sb.append(" ");
}
String result2 = sb.toString();  // "0 1 2 3 4 "

// Format strings
String name = "Alice";
int age = 25;
String formatted = String.format("%s is %d years old", name, age);
System.out.println(formatted);  // "Alice is 25 years old"
```

### Character Operations

```java
char ch = 'A';

// Check character type
boolean isLetter = Character.isLetter(ch);     // true
boolean isDigit = Character.isDigit(ch);       // false
boolean isWhitespace = Character.isWhitespace(' ');  // true
boolean isUpper = Character.isUpperCase(ch);   // true
boolean isLower = Character.isLowerCase(ch);   // false

// Convert case
char lower = Character.toLowerCase(ch);  // 'a'
char upper = Character.toUpperCase('b'); // 'B'

// Convert between char and int (ASCII values)
char letter = 'A';
int ascii = (int) letter;  // 65
char converted = (char) 66;  // 'B'

// Loop through characters in string
String word = "Hello";
for (int i = 0; i < word.length(); i++) {
    char c = word.charAt(i);
    System.out.println(c);
}

// Process each character
String input = "Hello123";
int letterCount = 0;
int digitCount = 0;

for (int i = 0; i < input.length(); i++) {
    char c = input.charAt(i);
    if (Character.isLetter(c)) {
        letterCount++;
    } else if (Character.isDigit(c)) {
        digitCount++;
    }
}
```

---

## Arrays

### Array Basics

```java
// Declare and create array
int[] numbers = new int[5];      // Array of 5 integers (all 0)
String[] names = new String[10]; // Array of 10 strings (all null)
double[] prices = new double[3]; // Array of 3 doubles (all 0.0)

// Initialize with values
int[] scores = {85, 92, 78, 90, 88};
String[] cities = {"Cleveland", "Columbus", "Cincinnati"};

// Access elements (zero-indexed)
numbers[0] = 10;  // Set first element
numbers[1] = 20;  // Set second element
int first = numbers[0];  // Get first element
int last = numbers[numbers.length - 1];  // Get last element

// Array length
int size = numbers.length;  // 5 (property, not method!)
```

### Looping Through Arrays

```java
int[] scores = {85, 92, 78, 90, 88};

// Standard for loop
for (int i = 0; i < scores.length; i++) {
    System.out.println("Score " + i + ": " + scores[i]);
}

// Enhanced for loop (for-each)
for (int score : scores) {
    System.out.println(score);
}

// Process array elements
int total = 0;
for (int score : scores) {
    total += score;
}
double average = (double) total / scores.length;

// Find maximum
int max = scores[0];
for (int i = 1; i < scores.length; i++) {
    if (scores[i] > max) {
        max = scores[i];
    }
}

// Find minimum
int min = scores[0];
for (int i = 1; i < scores.length; i++) {
    if (scores[i] < min) {
        min = scores[i];
    }
}
```

### Array Algorithms

```java
// Count occurrences
int[] numbers = {5, 3, 5, 8, 5, 3, 9};
int target = 5;
int count = 0;

for (int num : numbers) {
    if (num == target) {
        count++;
    }
}

// Linear search (find index of value)
int searchValue = 8;
int foundIndex = -1;

for (int i = 0; i < numbers.length; i++) {
    if (numbers[i] == searchValue) {
        foundIndex = i;
        break;  // OK to use break in searches
    }
}

// Check if array contains value
boolean contains = false;
for (int num : numbers) {
    if (num == searchValue) {
        contains = true;
        break;
    }
}

// Reverse array
int[] original = {1, 2, 3, 4, 5};
int[] reversed = new int[original.length];

for (int i = 0; i < original.length; i++) {
    reversed[i] = original[original.length - 1 - i];
}

// Copy array
int[] source = {1, 2, 3, 4, 5};
int[] copy = new int[source.length];

for (int i = 0; i < source.length; i++) {
    copy[i] = source[i];
}
```

### Arrays of Objects

```java
// Create array of Book objects
Book[] library = new Book[5];

// Initialize each element
library[0] = new Book("Java Basics", "Smith", 300);
library[1] = new Book("Advanced Java", "Jones", 450);
library[2] = new Book("Web Design", "Brown", 275);

// Loop through object array
for (int i = 0; i < library.length; i++) {
    if (library[i] != null) {  // Check for null!
        System.out.println(library[i].getTitle());
    }
}

// Enhanced for loop with objects
for (Book book : library) {
    if (book != null) {
        System.out.printf("%s by %s%n", book.getTitle(), book.getAuthor());
    }
}
```

### Multi-Dimensional Arrays

```java
// 2D array (rows and columns)
int[][] grid = new int[3][4];  // 3 rows, 4 columns

// Initialize 2D array
int[][] numbers = {
    {1, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12}
};

// Access elements
int value = numbers[0][0];  // 1 (first row, first column)
int value2 = numbers[2][3]; // 12 (third row, fourth column)

// Loop through 2D array
for (int row = 0; row < numbers.length; row++) {
    for (int col = 0; col < numbers[row].length; col++) {
        System.out.printf("%3d ", numbers[row][col]);
    }
    System.out.println();
}

// Enhanced for loop with 2D array
for (int[] row : numbers) {
    for (int value : row) {
        System.out.print(value + " ");
    }
    System.out.println();
}
```

---

## ArrayLists

### ArrayList Basics

```java
import java.util.ArrayList;

// Create ArrayList (must use wrapper classes for primitives)
ArrayList<Integer> numbers = new ArrayList<>();      // Integer, not int
ArrayList<Double> prices = new ArrayList<>();        // Double, not double
ArrayList<String> names = new ArrayList<>();
ArrayList<Book> library = new ArrayList<>();         // Custom objects

//SC2: Create ArrayList to store objects
ArrayList<Product> inventory = new ArrayList<>();
```

### ArrayList Methods

```java
ArrayList<String> cities = new ArrayList<>();

// Add elements
cities.add("Cleveland");           // Add to end
cities.add("Columbus");
cities.add("Cincinnati");
cities.add(1, "Toledo");          // Insert at index 1

// Get elements
String first = cities.get(0);     // "Cleveland"
String second = cities.get(1);    // "Toledo"

// Size
int count = cities.size();        // 4

// Modify element
cities.set(0, "Akron");          // Replace element at index 0

// Remove elements
cities.remove(2);                 // Remove by index
cities.remove("Toledo");          // Remove by value

// Check if contains
boolean hasCLE = cities.contains("Cleveland");  // false (was replaced)

// Clear all elements
cities.clear();                   // Empty the list

// Check if empty
boolean empty = cities.isEmpty(); // true
```

### Looping Through ArrayLists

```java
ArrayList<Integer> scores = new ArrayList<>();
scores.add(85);
scores.add(92);
scores.add(78);
scores.add(90);

// Standard for loop
for (int i = 0; i < scores.size(); i++) {
    int score = scores.get(i);
    System.out.println("Score " + i + ": " + score);
}

// Enhanced for loop
for (int score : scores) {
    System.out.println(score);
}

// Process ArrayList elements
int total = 0;
for (int score : scores) {
    total += score;
}
double average = (double) total / scores.size();
```

### ArrayList with Objects

```java
//SC2: ArrayList to store Book objects
ArrayList<Book> library = new ArrayList<>();

// Add objects
library.add(new Book("Java Basics", "Smith", 300));
library.add(new Book("Web Design", "Jones", 250));

//SC8: Create multiple objects and add to ArrayList
for (int i = 0; i < 5; i++) {
    String title = titles[rand.nextInt(titles.length)];
    String author = authors[rand.nextInt(authors.length)];
    int pages = rand.nextInt(400) + 100;
    
    library.add(new Book(title, author, pages));
}

//SC11: Access object data using getter methods
for (int i = 0; i < library.size(); i++) {
    Book book = library.get(i);
    System.out.printf("%-30s %-20s %5d%n",
                      book.getTitle(),
                      book.getAuthor(),
                      book.getPages());
}

// Enhanced for loop with objects
for (Book book : library) {
    System.out.println(book.getTitle() + " - " + book.getPages() + " pages");
}
```

### ArrayList Algorithms

```java
ArrayList<Integer> numbers = new ArrayList<>();
// Add some numbers...

// Find maximum
int max = numbers.get(0);
for (int i = 1; i < numbers.size(); i++) {
    if (numbers.get(i) > max) {
        max = numbers.get(i);
    }
}

// Find minimum
int min = numbers.get(0);
for (int i = 1; i < numbers.size(); i++) {
    if (numbers.get(i) < min) {
        min = numbers.get(i);
    }
}

// Count values meeting condition
int count = 0;
for (int num : numbers) {
    if (num > 50) {
        count++;
    }
}

// Remove values meeting condition
for (int i = numbers.size() - 1; i >= 0; i--) {  // Backwards!
    if (numbers.get(i) < 10) {
        numbers.remove(i);
    }
}

// Find index of value
int target = 42;
int index = -1;
for (int i = 0; i < numbers.size(); i++) {
    if (numbers.get(i) == target) {
        index = i;
        break;
    }
}
```

### Arrays vs ArrayLists

```java
// ARRAYS - Fixed size
int[] array = new int[5];
array[0] = 10;
int value = array[0];
int size = array.length;  // Property

// ARRAYLISTS - Dynamic size
ArrayList<Integer> list = new ArrayList<>();
list.add(10);
int value2 = list.get(0);
int size2 = list.size();  // Method

// Converting between them
Integer[] arrayFromList = list.toArray(new Integer[0]);
ArrayList<Integer> listFromArray = new ArrayList<>(Arrays.asList(1, 2, 3));
```

---

## Random Number Generation

### Random Class Basics

```java
import java.util.Random;

//SC6: Create Random object for generating random values
Random rand = new Random();

// Generate random integers
int dice = rand.nextInt(6) + 1;          // 1-6 (inclusive)
int percent = rand.nextInt(101);         // 0-100 (inclusive)
int temperature = rand.nextInt(41) + 60; // 60-100 (inclusive)

// Formula: rand.nextInt(max - min + 1) + min
int min = 10;
int max = 50;
int value = rand.nextInt(max - min + 1) + min;  // 10-50 inclusive
```

### Random Integer Ranges

```java
Random rand = new Random();

// Common patterns
int d6 = rand.nextInt(6) + 1;        // 1-6 (dice)
int d20 = rand.nextInt(20) + 1;      // 1-20 (D&D die)
int age = rand.nextInt(100) + 1;     // 1-100
int year = rand.nextInt(25) + 2000;  // 2000-2024

//SC9: Random selection within specific range
int complexity = rand.nextInt(16) + 1;  // 1-16

// Specific ranges
int temp = rand.nextInt(41) + 60;    // 60-100 (temperature)
int score = rand.nextInt(51) + 50;   // 50-100 (test score)
int pages = rand.nextInt(400) + 100; // 100-499 (book pages)

// Generate 4-digit numbers
int id = rand.nextInt(9000) + 1000;  // 1000-9999
```

### Random Doubles

```java
Random rand = new Random();

// Random double from 0.0 to 1.0 (exclusive)
double random = rand.nextDouble();  // 0.0 <= value < 1.0

//SC10: Generate random decimal values
double price = rand.nextDouble() * 100;  // 0.0 to 100.0

// Specific range
double min = 10.5;
double max = 99.9;
double value = rand.nextDouble() * (max - min) + min;

//SC12: Format random doubles
DecimalFormat df = new DecimalFormat("0.00");
double rawPrice = rand.nextDouble() * 50 + 10;  // 10.00 to 60.00
String formatted = df.format(rawPrice);
double finalPrice = Double.parseDouble(formatted);
```

### Random Selection from Arrays

```java
Random rand = new Random();

//SC9: Randomly select from array
String[] titles = {"Java", "Python", "C++", "JavaScript", "Ruby"};
String[] authors = {"Smith", "Jones", "Brown", "Davis"};

String randomTitle = titles[rand.nextInt(titles.length)];
String randomAuthor = authors[rand.nextInt(authors.length)];

// Pattern: Select different items
String primary = titles[rand.nextInt(titles.length)];
String secondary = titles[rand.nextInt(titles.length)];

// Ensure they're different
while (primary.equals(secondary)) {
    secondary = titles[rand.nextInt(titles.length)];
}
```

### Avoiding Invalid Random Values

```java
Random rand = new Random();

// Pattern 1: Avoid zero for division
int divisor = 0;
while (divisor == 0) {
    divisor = rand.nextInt(20);  // Keep generating until non-zero
}

// Pattern 2: Avoid specific value
int number = 13;  // Don't want 13
while (number == 13) {
    number = rand.nextInt(20) + 1;  // 1-20
}

// Pattern 3: Generate until condition met
int value = 0;
while (value < 50) {
    value = rand.nextInt(100);  // Keep generating until >= 50
}
```

### Random Booleans

```java
Random rand = new Random();

// Random true/false
boolean coinFlip = rand.nextBoolean();

// Random choice based on probability
int chance = rand.nextInt(100);  // 0-99
if (chance < 30) {  // 30% chance
    System.out.println("Rare event!");
}

// Weighted random selection
int outcome = rand.nextInt(10);  // 0-9
if (outcome < 5) {              // 50% chance
    System.out.println("Common");
} else if (outcome < 8) {       // 30% chance
    System.out.println("Uncommon");
} else {                        // 20% chance
    System.out.println("Rare");
}
```

---

## Output Formatting

### Printf Basics

```java
// Basic syntax
System.out.printf(format_string, arguments);

// Common format specifiers
%s    // String
%d    // Integer (decimal)
%f    // Floating-point
%c    // Character
%b    // Boolean
%n    // Newline (platform-independent - USE THIS instead of \n)

// Examples
String name = "Alice";
int age = 25;
double gpa = 3.87;

System.out.printf("Name: %s%n", name);        // Name: Alice
System.out.printf("Age: %d%n", age);          // Age: 25
System.out.printf("GPA: %f%n", gpa);          // GPA: 3.870000
System.out.printf("GPA: %.2f%n", gpa);        // GPA: 3.87
```

### Decimal Places

```java
double pi = 3.14159265;

System.out.printf("%.0f%n", pi);  // 3
System.out.printf("%.1f%n", pi);  // 3.1
System.out.printf("%.2f%n", pi);  // 3.14
System.out.printf("%.3f%n", pi);  // 3.142
System.out.printf("%.4f%n", pi);  // 3.1416 (rounds!)

// Always show 2 decimal places
double price = 5.5;
System.out.printf("%.2f%n", price);  // 5.50

// Money formatting
double amount = 1234.567;
System.out.printf("$%.2f%n", amount);  // $1234.57
```

### Width and Alignment

```java
// Width - minimum space allocated
System.out.printf("%10s%n", "Hello");     // "     Hello" (right-aligned)
System.out.printf("%10d%n", 42);          // "        42" (right-aligned)
System.out.printf("%10.2f%n", 3.14);      // "      3.14" (right-aligned)

// Left-alignment (use negative width)
System.out.printf("%-10s%n", "Hello");    // "Hello     " (left-aligned)
System.out.printf("%-10d%n", 42);         // "42        " (left-aligned)
System.out.printf("%-10.2f%n", 3.14);     // "3.14      " (left-aligned)

// Width with decimals
System.out.printf("%10.2f%n", 123.4);     // "    123.40"
System.out.printf("%-10.2f%n", 123.4);    // "123.40    "
```

### Formatting Tables

```java
//SC13: Format table headers with printf
System.out.printf("%-20s %10s %10s %12s%n", 
                  "Product", "Quantity", "Price", "Total");
System.out.println("-------------------------------------------------------");

//SC14: Format data rows with printf
String product = "Widget";
int quantity = 5;
double price = 19.99;
double total = quantity * price;

System.out.printf("%-20s %10d %10.2f %12.2f%n",
                  product, quantity, price, total);

/* Output:
Product                Quantity      Price        Total
-------------------------------------------------------
Widget                        5      19.99        99.95
*/

// Complete table example
System.out.printf("%-15s %8s %10s%n", "Name", "Age", "GPA");
System.out.println("------------------------------------");
System.out.printf("%-15s %8d %10.2f%n", "Alice Smith", 20, 3.85);
System.out.printf("%-15s %8d %10.2f%n", "Bob Jones", 22, 3.62);
System.out.printf("%-15s %8d %10.2f%n", "Carol White", 19, 3.91);
```

### DecimalFormat Class

```java
import java.text.DecimalFormat;

//SC7: Create DecimalFormat object for formatting
DecimalFormat currency = new DecimalFormat("$#,##0.00");
DecimalFormat twoPlaces = new DecimalFormat("0.00");
DecimalFormat percent = new DecimalFormat("0.0%");
DecimalFormat noDecimals = new DecimalFormat("#,###");

// Using DecimalFormat
double price = 1234.567;
String formatted = currency.format(price);      // "$1,234.57"

double rate = 0.0575;
String percentStr = percent.format(rate);       // "5.8%"

//SC12: Format random doubles
Random rand = new Random();
DecimalFormat df = new DecimalFormat("0.00");
double randomPrice = rand.nextDouble() * 100;
String priceStr = df.format(randomPrice);
double finalPrice = Double.parseDouble(priceStr);

// Common patterns
DecimalFormat df1 = new DecimalFormat("0.00");       // Always 2 decimals
DecimalFormat df2 = new DecimalFormat("#.00");       // 2 decimals, no leading zero
DecimalFormat df3 = new DecimalFormat("0.000");      // Always 3 decimals
DecimalFormat df4 = new DecimalFormat("#,###.00");   // Commas and 2 decimals
```

### Combining Multiple Formats

```java
// Complex output with multiple data types
String name = "Alice";
int id = 12345;
double salary = 75000.50;
boolean active = true;

System.out.printf("Employee: %-15s ID: %6d Salary: $%,.2f Active: %b%n",
                  name, id, salary, active);
// Employee: Alice           ID:  12345 Salary: $75,000.50 Active: true

// Table with calculated values
for (int i = 0; i < products.size(); i++) {
    Product p = products.get(i);
    double total = p.getQuantity() * p.getPrice();
    double tax = total * 0.07;
    double grandTotal = total + tax;
    
    System.out.printf("%-20s %5d %10.2f %12.2f %10.2f %12.2f%n",
                      p.getName(),
                      p.getQuantity(),
                      p.getPrice(),
                      total,
                      tax,
                      grandTotal);
}
```

---

## Exception Handling

### Try-Catch Basics

```java
//SC4: Exception handling for input validation
try {
    // Code that might throw an exception
    int number = Integer.parseInt(input.nextLine());
    int result = 100 / number;
    System.out.println("Result: " + result);
    
} catch (NumberFormatException e) {
    // Handle non-numeric input
    System.out.println("Please enter a valid number.");
    
} catch (ArithmeticException e) {
    // Handle division by zero
    System.out.println("Cannot divide by zero.");
    
} catch (Exception e) {
    // Catch any other exception
    System.out.println("An error occurred: " + e.getMessage());
}
```

### InputMismatchException Pattern

```java
import java.util.InputMismatchException;

Scanner input = new Scanner(System.in);
int number = 0;
boolean valid = false;

while (!valid) {
    //SC4: Try-catch for invalid input types
    try {
        System.out.print("Enter a number: ");
        number = input.nextInt();
        valid = true;  // Only reached if no exception
        
    } catch (InputMismatchException e) {
        System.out.println("Invalid input. Please enter a number.");
        input.next();  // CRITICAL: Clear the invalid input
    }
}

System.out.println("You entered: " + number);
```

### Complete Validation Method

```java
//SC3: User input collection
//SC4: Exception handling for data type errors
//SC5: Range validation strategy
private static int getValidInteger(Scanner input, String prompt, 
                                   int min, int max) {
    int value = 0;
    boolean valid = false;
    
    System.out.print(prompt);
    
    while (!valid) {
        try {
            value = input.nextInt();
            
            // Check if in valid range
            if (value >= min && value <= max) {
                valid = true;
            } else {
                System.out.printf("Must be between %d and %d: ", min, max);
            }
            
        } catch (InputMismatchException e) {
            System.out.print("Invalid. Enter a number: ");
            input.next();  // Clear buffer
        }
    }
    
    return value;
}

// Usage
int age = getValidInteger(input, "Enter age (1-120): ", 1, 120);
```

### Multiple Exceptions

```java
try {
    // Code that might throw various exceptions
    String input = scanner.nextLine();
    int number = Integer.parseInt(input);
    int[] array = new int[5];
    array[10] = number;  // ArrayIndexOutOfBoundsException
    int result = 100 / number;  // ArithmeticException
    
} catch (NumberFormatException e) {
    System.out.println("Invalid number format");
    
} catch (ArrayIndexOutOfBoundsException e) {
    System.out.println("Array index out of bounds");
    
} catch (ArithmeticException e) {
    System.out.println("Arithmetic error (division by zero?)");
    
} catch (Exception e) {
    // Catch-all for any other exception
    System.out.println("Unexpected error: " + e.getMessage());
}
```

### Try-Catch-Finally

```java
Scanner input = null;

try {
    input = new Scanner(System.in);
    System.out.print("Enter number: ");
    int num = input.nextInt();
    System.out.println("You entered: " + num);
    
} catch (InputMismatchException e) {
    System.out.println("Invalid input");
    
} finally {
    // Always executes, even if exception occurs
    if (input != null) {
        input.close();
    }
}
```

---

## Object-Oriented Programming

### Creating a Class

```java
// Product.java
public class Product {
    // Instance variables (private for encapsulation)
    private String name;
    private int quantity;
    private double price;
    private String category;
    
    // Constructor 1: Default constructor
    public Product() {
        name = "Unknown";
        quantity = 0;
        price = 0.0;
        category = "General";
    }
    
    // Constructor 2: Constructor with parameters
    public Product(String name, int quantity, double price, String category) {
        this.name = name;           // this. refers to instance variable
        this.quantity = quantity;
        this.price = price;
        this.category = category;
    }
    
    // Getter methods (accessors)
    public String getName() {
        return name;
    }
    
    public int getQuantity() {
        return quantity;
    }
    
    public double getPrice() {
        return price;
    }
    
    public String getCategory() {
        return category;
    }
    
    // Setter methods (mutators)
    public void setName(String name) {
        this.name = name;
    }
    
    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }
    
    public void setPrice(double price) {
        this.price = price;
    }
    
    public void setCategory(String category) {
        this.category = category;
    }
    
    // Calculated methods (derive values from other attributes)
    public double calculateTotal() {
        return quantity * price;
    }
    
    public double calculateTax() {
        return calculateTotal() * 0.07;
    }
    
    public double calculateGrandTotal() {
        return calculateTotal() + calculateTax();
    }
    
    public boolean isLowStock() {
        return quantity < 10;
    }
    
    //SC15: String comparison for matching values
    public boolean nameMatchesCategory() {
        return this.name.equals(this.category);
    }
    
    // toString method for easy printing
    @Override
    public String toString() {
        return String.format("%s (Qty: %d @ $%.2f ea) = $%.2f",
                             name, quantity, price, calculateTotal());
    }
}
```

### Using Objects in Main Program

```java
public class InventoryManager {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        
        //SC2: Create ArrayList to store Product objects
        ArrayList<Product> inventory = new ArrayList<>();
        
        // Create objects using constructors
        Product item1 = new Product("Widget", 50, 12.99, "Hardware");
        Product item2 = new Product();  // Uses default constructor
        
        // Use setter methods
        item2.setName("Gadget");
        item2.setQuantity(25);
        item2.setPrice(24.99);
        item2.setCategory("Electronics");
        
        // Add objects to ArrayList
        inventory.add(item1);
        inventory.add(item2);
        
        //SC11: Access object data using getter methods and format output
        System.out.printf("%-20s %10s %10s %12s%n",
                          "Product", "Quantity", "Price", "Total");
        System.out.println("-------------------------------------------------------");
        
        for (int i = 0; i < inventory.size(); i++) {
            Product p = inventory.get(i);
            System.out.printf("%-20s %10d $%9.2f $%11.2f%n",
                              p.getName(),
                              p.getQuantity(),
                              p.getPrice(),
                              p.calculateTotal());
        }
        
        input.close();
    }
}
```

### Creating Objects with Random Data

```java
//SC8: Generate Product objects with randomized data
private static ArrayList<Product> generateProducts(int count, Random rand) {
    ArrayList<Product> products = new ArrayList<>();
    
    String[] names = {"Widget", "Gadget", "Gizmo", "Tool", "Device"};
    String[] categories = {"Hardware", "Electronics", "Tools", "Parts"};
    
    for (int i = 0; i < count; i++) {
        //SC9: Random selection from arrays
        String name = names[rand.nextInt(names.length)];
        String category = categories[rand.nextInt(categories.length)];
        
        // Ensure name and category are different
        while (name.equals(category)) {
            category = categories[rand.nextInt(categories.length)];
        }
        
        //SC10: Generate random quantities and prices
        int quantity = rand.nextInt(100) + 1;  // 1-100
        double price = rand.nextDouble() * 50 + 10;  // 10-60
        
        //SC12: Format price
        DecimalFormat df = new DecimalFormat("0.00");
        String priceStr = df.format(price);
        double finalPrice = Double.parseDouble(priceStr);
        
        products.add(new Product(name, quantity, finalPrice, category));
    }
    
    return products;
}
```

### Object Arrays vs ArrayLists

```java
// Array of objects
Product[] inventory = new Product[10];
inventory[0] = new Product("Widget", 5, 9.99, "Hardware");
inventory[1] = new Product("Gadget", 3, 14.99, "Electronics");

// ArrayList of objects (PREFERRED for competitions)
ArrayList<Product> inventory2 = new ArrayList<>();
inventory2.add(new Product("Widget", 5, 9.99, "Hardware"));
inventory2.add(new Product("Gadget", 3, 14.99, "Electronics"));
```

### Class Methods That Return Values

```java
// Inside Product class

// Method returns boolean based on comparison
public boolean isPremium() {
    return price > 100.0;
}

// Method returns String based on calculations
public String getStockLevel() {
    if (quantity == 0) {
        return "Out of Stock";
    } else if (quantity < 10) {
        return "Low Stock";
    } else if (quantity < 50) {
        return "Moderate Stock";
    } else {
        return "Well Stocked";
    }
}

// Method that modifies object state
public void restock(int amount) {
    this.quantity += amount;
}

public void sell(int amount) {
    if (amount <= this.quantity) {
        this.quantity -= amount;
    } else {
        System.out.println("Insufficient stock!");
    }
}
```

---

## Common Algorithms & Patterns

### Finding Maximum/Minimum

```java
// Find maximum in ArrayList
ArrayList<Integer> scores = new ArrayList<>();
// ... add values ...

int max = scores.get(0);  // Start with first element
for (int i = 1; i < scores.size(); i++) {
    if (scores.get(i) > max) {
        max = scores.get(i);
    }
}

// Find minimum
int min = scores.get(0);
for (int i = 1; i < scores.size(); i++) {
    if (scores.get(i) < min) {
        min = scores.get(i);
    }
}

// Find object with maximum attribute
ArrayList<Product> products = new ArrayList<>();
// ... add products ...

Product mostExpensive = products.get(0);
for (int i = 1; i < products.size(); i++) {
    if (products.get(i).getPrice() > mostExpensive.getPrice()) {
        mostExpensive = products.get(i);
    }
}
```

### Counting

```java
// Count values meeting condition
int count = 0;
for (int num : numbers) {
    if (num > 50) {
        count++;
    }
}

// Count objects meeting condition
int lowStockCount = 0;
for (Product p : products) {
    if (p.getQuantity() < 10) {
        lowStockCount++;
    }
}

// Count characters in string
String text = "Hello World";
int letterCount = 0;
for (int i = 0; i < text.length(); i++) {
    if (Character.isLetter(text.charAt(i))) {
        letterCount++;
    }
}
```

### Accumulation (Totaling)

```java
// Sum values
int total = 0;
for (int score : scores) {
    total += score;
}

// Calculate average
double average = (double) total / scores.size();

// Sum object attributes
double totalRevenue = 0;
for (Product p : products) {
    totalRevenue += p.calculateTotal();
}
```

### Searching

```java
// Linear search for value
int target = 42;
int index = -1;

for (int i = 0; i < numbers.size(); i++) {
    if (numbers.get(i) == target) {
        index = i;
        break;  // OK to use break in searches
    }
}

if (index != -1) {
    System.out.println("Found at index " + index);
} else {
    System.out.println("Not found");
}

// Search for object by attribute
String searchName = "Widget";
Product found = null;

for (Product p : products) {
    if (p.getName().equals(searchName)) {
        found = p;
        break;
    }
}

if (found != null) {
    System.out.println("Found: " + found);
}
```

### Validating Uniqueness

```java
// Check if ArrayList contains duplicate values
boolean hasDuplicates = false;

for (int i = 0; i < numbers.size() - 1; i++) {
    for (int j = i + 1; j < numbers.size(); j++) {
        if (numbers.get(i).equals(numbers.get(j))) {
            hasDuplicates = true;
            break;
        }
    }
}

// Ensure two values are different before adding
String value1 = getRandomValue();
String value2 = getRandomValue();

while (value1.equals(value2)) {
    value2 = getRandomValue();  // Keep regenerating
}
```

### Filtering

```java
// Create new ArrayList with only matching items
ArrayList<Product> lowStockItems = new ArrayList<>();

for (Product p : products) {
    if (p.getQuantity() < 10) {
        lowStockItems.add(p);
    }
}

// Remove items that don't match criteria (backwards iteration!)
for (int i = products.size() - 1; i >= 0; i--) {
    if (products.get(i).getQuantity() == 0) {
        products.remove(i);
    }
}
```

---

## Debugging & Testing

### Common Compilation Errors

```java
// ❌ Missing semicolon
int x = 5

// ✅ CORRECT
int x = 5;

// ❌ Mismatched parentheses/braces
if (x > 5 {
    System.out.println("Yes");
}

// ✅ CORRECT
if (x > 5) {
    System.out.println("Yes");
}

// ❌ Wrong variable type
String number = 42;

// ✅ CORRECT
int number = 42;

// ❌ Method call without parentheses
int size = list.size;

// ✅ CORRECT
int size = list.size();

// ❌ Array property with parentheses
int len = array.length();

// ✅ CORRECT
int len = array.length;
```

### Common Runtime Errors

```java
// NullPointerException
ArrayList<String> list = null;
list.add("item");  // CRASH!

// Solution: Initialize before use
ArrayList<String> list = new ArrayList<>();
list.add("item");

// ArrayIndexOutOfBoundsException
int[] array = {1, 2, 3};
int value = array[5];  // CRASH! (index 5 doesn't exist)

// Solution: Check bounds
if (index >= 0 && index < array.length) {
    int value = array[index];
}

// InputMismatchException
Scanner input = new Scanner(System.in);
int num = input.nextInt();  // User types "abc" - CRASH!

// Solution: Use try-catch
try {
    int num = input.nextInt();
} catch (InputMismatchException e) {
    System.out.println("Invalid input");
    input.next();  // Clear buffer
}

// ArithmeticException (division by zero)
int result = 10 / 0;  // CRASH!

// Solution: Check before dividing
if (denominator != 0) {
    int result = numerator / denominator;
}
```

### Common Logic Errors

```java
// ❌ Infinite loop
int count = 0;
while (count < 10) {
    System.out.println(count);
    // Forgot to increment!
}

// ✅ CORRECT
int count = 0;
while (count < 10) {
    System.out.println(count);
    count++;  // Don't forget!
}

// ❌ Off-by-one error
for (int i = 0; i <= array.length; i++) {  // <= is wrong!
    System.out.println(array[i]);
}

// ✅ CORRECT
for (int i = 0; i < array.length; i++) {  // < not <=
    System.out.println(array[i]);
}

// ❌ Integer division when you want decimal
double average = total / count;  // Both ints!

// ✅ CORRECT
double average = (double) total / count;  // Cast one to double

// ❌ Comparing strings with ==
if (str1 == str2) { }  // Compares addresses!

// ✅ CORRECT
if (str1.equals(str2)) { }  // Compares content
```

### Testing Strategies

```java
// Test with boundary values
// If valid range is 1-100, test with:
// - 0 (below minimum)
// - 1 (minimum)
// - 50 (middle)
// - 100 (maximum)
// - 101 (above maximum)

// Test with empty data
ArrayList<Integer> emptyList = new ArrayList<>();
if (emptyList.size() > 0) {  // Always check size first!
    int max = emptyList.get(0);
}

// Test output format carefully
// Check:
// - Exact spacing
// - Capitalization
// - Punctuation
// - Decimal places
// - Column alignment

// Print debug information
System.out.println("DEBUG: value = " + value);
System.out.println("DEBUG: list size = " + list.size());
```

---

## Complete Example Programs

### Example 1: Temperature Tracker

```java
// Contestant Number: 12345
/*
 * Temperature Tracker
 * Records daily temperatures and calculates statistics
 */

import java.util.Scanner;
import java.util.ArrayList;

public class TemperatureTracker {
    
    public static void main(String[] args) {
        //SC1: Create Scanner for user input
        Scanner input = new Scanner(System.in);
        
        //SC2: Create ArrayList to store temperatures
        ArrayList<Integer> temperatures45 = new ArrayList<>();
        
        // INPUT: Get number of days to track
        System.out.print("How many days to track (1-30): ");
        int numDays45 = getValidInteger(input, 1, 30);
        
        // INPUT: Collect temperatures
        for (int i = 1; i <= numDays45; i++) {
            System.out.printf("Day %d temperature (°F): ", i);
            int temp = getValidInteger(input, -50, 130);
            temperatures45.add(temp);
        }
        
        // PROCESSING: Calculate statistics
        int total = calculateTotal(temperatures45);
        double average = (double) total / temperatures45.size();
        int highest = findMax(temperatures45);
        int lowest = findMin(temperatures45);
        int range = highest - lowest;
        
        // OUTPUT: Display results
        System.out.println("\n=== Temperature Statistics ===");
        System.out.printf("Days tracked: %d%n", numDays45);
        System.out.printf("Average: %.1f°F%n", average);
        System.out.printf("Highest: %d°F%n", highest);
        System.out.printf("Lowest: %d°F%n", lowest);
        System.out.printf("Range: %d°F%n", range);
        
        input.close();
    }
    
    //SC3: Input validation method
    //SC4: Exception handling
    //SC5: Range validation
    private static int getValidInteger(Scanner input, int min, int max) {
        int value = 0;
        boolean valid = false;
        
        while (!valid) {
            try {
                value = input.nextInt();
                if (value >= min && value <= max) {
                    valid = true;
                } else {
                    System.out.printf("Must be %d-%d: ", min, max);
                }
            } catch (Exception e) {
                System.out.print("Invalid. Enter number: ");
                input.next();
            }
        }
        
        return value;
    }
    
    private static int calculateTotal(ArrayList<Integer> temps) {
        int total = 0;
        for (int temp : temps) {
            total += temp;
        }
        return total;
    }
    
    private static int findMax(ArrayList<Integer> temps) {
        int max = temps.get(0);
        for (int i = 1; i < temps.size(); i++) {
            if (temps.get(i) > max) {
                max = temps.get(i);
            }
        }
        return max;
    }
    
    private static int findMin(ArrayList<Integer> temps) {
        int min = temps.get(0);
        for (int i = 1; i < temps.size(); i++) {
            if (temps.get(i) < min) {
                min = temps.get(i);
            }
        }
        return min;
    }
}
```

### Example 2: Library System with Objects

```java
// Contestant Number: 12345
/*
 * Library Management System
 * Manages book inventory with random generation
 */

import java.util.Scanner;
import java.util.ArrayList;
import java.util.Random;
import java.text.DecimalFormat;

public class LibrarySystem {
    
    public static void main(String[] args) {
        //SC1: Scanner for input
        Scanner input = new Scanner(System.in);
        
        //SC6: Random object for generation
        Random rand = new Random();
        
        //SC7: DecimalFormat for prices
        DecimalFormat currency = new DecimalFormat("$0.00");
        
        //SC2: ArrayList to store Book objects
        ArrayList<Book> library45 = new ArrayList<>();
        
        // INPUT: Get number of books
        System.out.print("How many books to generate (1-20): ");
        int numBooks45 = getValidInteger(input, 1, 20);
        
        //SC8: Generate books with random data
        String[] titles = {"Java Basics", "Web Design", "Databases", 
                           "Networks", "Security"};
        String[] authors = {"Smith", "Johnson", "Williams", "Brown", "Jones"};
        
        for (int i = 0; i < numBooks45; i++) {
            //SC9: Random selection from arrays
            String title = titles[rand.nextInt(titles.length)];
            String author = authors[rand.nextInt(authors.length)];
            
            // Ensure title and author are different
            while (title.equals(author)) {
                author = authors[rand.nextInt(authors.length)];
            }
            
            //SC10: Random values
            int pages = rand.nextInt(400) + 100;  // 100-499
            
            //SC12: Format random price
            double rawPrice = rand.nextDouble() * 50 + 20;  // 20-70
            String priceStr = currency.format(rawPrice);
            double price = Double.parseDouble(priceStr.substring(1));
            
            library45.add(new Book(title, author, pages, price));
        }
        
        // OUTPUT: Display library
        //SC13: Format table headers
        System.out.printf("%n%-30s %-20s %8s %10s%n",
                          "Title", "Author", "Pages", "Price");
        System.out.println("---------------------------------------------------------------");
        
        //SC11: Access object data using getters
        //SC14: Format data rows
        for (int i = 0; i < library45.size(); i++) {
            Book b = library45.get(i);
            System.out.printf("%-30s %-20s %8d %10s%n",
                              b.getTitle(),
                              b.getAuthor(),
                              b.getPages(),
                              currency.format(b.getPrice()));
        }
        
        // Statistics
        double totalValue = 0;
        int totalPages = 0;
        
        for (Book b : library45) {
            totalValue += b.getPrice();
            totalPages += b.getPages();
        }
        
        System.out.println("---------------------------------------------------------------");
        System.out.printf("Total Books: %d%n", numBooks45);
        System.out.printf("Total Value: %s%n", currency.format(totalValue));
        System.out.printf("Total Pages: %,d%n", totalPages);
        
        input.close();
    }
    
    //SC3: Input validation
    //SC4: Exception handling
    //SC5: Range validation
    private static int getValidInteger(Scanner input, int min, int max) {
        int value = 0;
        boolean valid = false;
        
        while (!valid) {
            try {
                value = input.nextInt();
                if (value >= min && value <= max) {
                    valid = true;
                } else {
                    System.out.printf("Must be %d-%d: ", min, max);
                }
            } catch (Exception e) {
                System.out.print("Invalid input: ");
                input.next();
            }
        }
        
        return value;
    }
}

// Book.java (separate file)
class Book {
    private String title;
    private String author;
    private int pages;
    private double price;
    
    public Book() {
        title = "Unknown";
        author = "Unknown";
        pages = 0;
        price = 0.0;
    }
    
    public Book(String title, String author, int pages, double price) {
        this.title = title;
        this.author = author;
        this.pages = pages;
        this.price = price;
    }
    
    public String getTitle() {
        return title;
    }
    
    public String getAuthor() {
        return author;
    }
    
    public int getPages() {
        return pages;
    }
    
    public double getPrice() {
        return price;
    }
    
    public void setTitle(String title) {
        this.title = title;
    }
    
    public void setAuthor(String author) {
        this.author = author;
    }
    
    public void setPages(int pages) {
        this.pages = pages;
    }
    
    public void setPrice(double price) {
        this.price = price;
    }
    
    public double calculateShipping() {
        if (pages < 200) {
            return 3.99;
        } else if (pages < 400) {
            return 5.99;
        } else {
            return 7.99;
        }
    }
    
    //SC15: String comparison method
    public boolean titleMatchesAuthor() {
        return this.title.equals(this.author);
    }
}
```

---

## Quick Reference: Competition Day Checklist

### Before Starting
- [ ] Read entire problem carefully
- [ ] Note exact variable names (with xx suffix)
- [ ] Note exact prompts and output format
- [ ] Identify required structures (ArrayList, loops, switch, etc.)
- [ ] Plan your approach

### While Coding
- [ ] Add contestant number comment at top
- [ ] Use exact variable names with ID suffix
- [ ] Add flag comments (//SC1, //SC2, etc.)
- [ ] Use exact prompts character-for-character
- [ ] Use proper string comparison (.equals())
- [ ] Exit loops through conditions, not break
- [ ] Close Scanner when done

### Before Submitting
- [ ] Test with sample input
- [ ] Verify output matches exactly
- [ ] Check all variable names
- [ ] Verify all flag comments present
- [ ] Confirm program runs from USB drive
- [ ] Save in folder named with Contestant ID

