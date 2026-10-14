# C++ Programming Competition Reference Guide
## Comprehensive Study Material for BPA Competitions

---

## Table of Contents
1. [Competition Format & Requirements](#competition-format--requirements)
2. [Program Structure & Setup](#program-structure--setup)
3. [Input & Output](#input--output)
4. [Data Types & Variables](#data-types--variables)
5. [Operators & Expressions](#operators--expressions)
6. [Control Structures](#control-structures)
7. [Functions](#functions)
8. [Arrays](#arrays)
9. [Vectors](#vectors)
10. [Strings](#strings)
11. [File I/O](#file-io)
12. [Mathematical Operations](#mathematical-operations)
13. [Common Algorithms](#common-algorithms)
14. [Error Handling](#error-handling)
15. [Memory & Pointers](#memory--pointers)
16. [Debugging & Testing](#debugging--testing)
17. [Complete Example Programs](#complete-example-programs)

---

## Competition Format & Requirements

### What You Need to Know

BPA C++ competitions typically require you to:
1. Create a console application in 60-90 minutes
2. Name project with contestant number (e.g., CPP_335_01-2345-6789)
3. Include contestant ID as comment at top
4. Use specific functions as required
5. Handle file operations and error checking
6. Format output to match specifications exactly
7. Submit working code on flash drive

### Critical Rules

```cpp
// ❌ WRONG - No contestant ID
#include <iostream>
using namespace std;

// ✅ CORRECT - Contestant ID at top
// Contestant Number: 01-2345-6789

#include <iostream>
using namespace std;

// ❌ WRONG - Project name doesn't follow convention
MyProgram

// ✅ CORRECT - Follows naming convention
CPP_335_01-2345-6789

// ❌ WRONG - Missing required function
// (if problem requires isPrime function)
int main() {
    // checking prime inline
}

// ✅ CORRECT - Required function present
bool isPrime(int n);

int main() {
    if (isPrime(7)) {
        // use result
    }
}
```

### Grading Breakdown (Typical 300-350 points)

**Solution and Project (20 points)**
- Project present on flash drive
- Named according to conventions

**Program Execution (130-150 points)**
- Program runs without errors
- Correct calculations and output
- Proper error handling
- User interaction as specified

**Source Code Review (150-200 points)**
- Comments (contestant ID, functions, as needed)
- Variable naming conventions
- Required functions present and logical
- Proper use of loops, file I/O, etc.
- Main function structure

---

## Program Structure & Setup

### Required Headers

```cpp
// Input/Output
#include <iostream>     // cin, cout
#include <iomanip>      // setw, setprecision, fixed
#include <fstream>      // ifstream, ofstream

// Containers
#include <vector>       // vector<T>
#include <string>       // string class

// Math
#include <cmath>        // sqrt, pow, abs, etc.
#include <cstdlib>      // rand, srand

// Utilities
#include <algorithm>    // sort, find, min, max
#include <ctime>        // time (for random seed)

using namespace std;
```

### Basic Program Template

```cpp
// Contestant Number: 01-2345-6789
/*
 * Program: ProgramName
 * Description: Brief description of what program does
 * Date: Competition date
 */

#include <iostream>
#include <vector>
#include <string>
using namespace std;

// Function prototypes (declare before main)
void displayMenu();
int getUserInput();
double calculateAverage(vector<int> data);

int main() {
    // Main program logic
    
    return 0;  // Successful execution
}

// Function definitions (implement after main)
void displayMenu() {
    cout << "=== Menu ===" << endl;
    // implementation
}

int getUserInput() {
    int value;
    cin >> value;
    return value;
}

double calculateAverage(vector<int> data) {
    double sum = 0;
    for (int i = 0; i < data.size(); i++) {
        sum += data[i];
    }
    return sum / data.size();
}
```

### Function Prototype Pattern

```cpp
// ALWAYS declare prototypes before main
// Define (implement) after main

// Prototypes
bool isPrime(int n);
bool isPerfect(int n);
void displayResults(vector<int> primes);

int main() {
    // Can now call these functions
    if (isPrime(7)) {
        cout << "7 is prime" << endl;
    }
    
    return 0;
}

// Definitions
bool isPrime(int n) {
    if (n <= 1) return false;
    
    for (int i = 2; i <= sqrt(n); i++) {
        if (n % i == 0) {
            return false;
        }
    }
    return true;
}

bool isPerfect(int n) {
    if (n <= 1) return false;
    
    int sum = 0;
    for (int i = 1; i < n; i++) {
        if (n % i == 0) {
            sum += i;
        }
    }
    return sum == n;
}

void displayResults(vector<int> primes) {
    for (int i = 0; i < primes.size(); i++) {
        cout << primes[i];
        if (i < primes.size() - 1) {
            cout << ", ";
        }
    }
    cout << endl;
}
```

---

## Input & Output

### Console Input (cin)

```cpp
#include <iostream>
using namespace std;

// Basic input
int age;
cout << "Enter age: ";
cin >> age;

// Multiple inputs
int x, y;
cout << "Enter two numbers: ";
cin >> x >> y;

// String input (one word)
string name;
cout << "Enter name: ";
cin >> name;  // Stops at whitespace

// String input (entire line)
string fullName;
cout << "Enter full name: ";
cin.ignore();  // Clear buffer first (if needed)
getline(cin, fullName);

// Character input
char choice;
cout << "Enter choice (Y/N): ";
cin >> choice;
```

### Input Validation

```cpp
// Validate integer input
int getValidInteger(int min, int max) {
    int value;
    
    while (true) {
        cout << "Enter value (" << min << "-" << max << "): ";
        cin >> value;
        
        // Check if input failed (non-numeric)
        if (cin.fail()) {
            cin.clear();  // Clear error flag
            cin.ignore(10000, '\n');  // Discard bad input
            cout << "Invalid input. Enter a number." << endl;
            continue;
        }
        
        // Check range
        if (value >= min && value <= max) {
            return value;
        }
        
        cout << "Value must be between " << min << " and " << max << endl;
    }
}

// Usage
int main() {
    int userInput = getValidInteger(1, 100);
    cout << "You entered: " << userInput << endl;
    return 0;
}
```

### Console Output (cout)

```cpp
#include <iostream>
using namespace std;

// Basic output
cout << "Hello, World!" << endl;

// Multiple items
string name = "Alice";
int age = 25;
cout << "Name: " << name << ", Age: " << age << endl;

// Without newline
cout << "Processing";
cout << "...";
cout << "Done!" << endl;  // Output: Processing...Done!

// Formatting numbers
double price = 19.99;
cout << "Price: $" << price << endl;
```

### Output Formatting (iomanip)

```cpp
#include <iostream>
#include <iomanip>
using namespace std;

// Set decimal places
double pi = 3.14159265;
cout << fixed << setprecision(2);  // Always show 2 decimals
cout << pi << endl;  // 3.14

// Width and alignment
cout << setw(10) << "Name" << setw(10) << "Score" << endl;
cout << setw(10) << "Alice" << setw(10) << 95 << endl;
cout << setw(10) << "Bob" << setw(10) << 87 << endl;

// Left alignment
cout << left;
cout << setw(15) << "Product" << setw(10) << "Price" << endl;
cout << setw(15) << "Widget" << setw(10) << "$19.99" << endl;

// Right alignment (default)
cout << right;
cout << setw(10) << 42 << endl;  // "        42"

// Fill character
cout << setfill('0') << setw(5) << 42 << endl;  // "00042"
cout << setfill(' ');  // Reset to spaces
```

### Screen Control

```cpp
#include <iostream>
#include <cstdlib>  // For system()
using namespace std;

// Clear screen (Windows)
void clearScreen() {
    system("cls");
}

// Clear screen (Cross-platform)
void clearScreen() {
    #ifdef _WIN32
        system("cls");
    #else
        system("clear");
    #endif
}

// Pause for user
void pauseScreen() {
    cout << "Press any key to continue..." << endl;
    cin.ignore();
    cin.get();
}

// Usage
int main() {
    cout << "First screen" << endl;
    pauseScreen();
    
    clearScreen();
    
    cout << "Second screen" << endl;
    pauseScreen();
    
    return 0;
}
```

---

## Data Types & Variables

### Primitive Data Types

```cpp
// Integer types
int age = 25;              // -2.1 billion to 2.1 billion
short smallNum = 32000;    // -32,768 to 32,767
long bigNum = 2000000L;    // Larger range
long long huge = 9000000000000LL;  // Very large

// Unsigned (no negative)
unsigned int positive = 100;  // 0 to 4.2 billion

// Floating-point
float price = 19.99f;      // 6-7 decimal digits (note the f)
double pi = 3.14159;       // 15-16 decimal digits (MOST COMMON)

// Character
char letter = 'A';         // Single character (use single quotes)

// Boolean
bool isValid = true;       // true or false
bool isActive = false;

// String (technically a class)
string name = "Alice";     // Text (use double quotes)
```

### Variable Declaration and Initialization

```cpp
// Declaration only
int x;
double y;
string name;

// Declaration with initialization
int score = 95;
double gpa = 3.85;
string city = "Cleveland";

// Multiple declarations
int a, b, c;
int x = 5, y = 10, z = 15;

// Constants (cannot be changed)
const int MAX_SCORE = 100;
const double PI = 3.14159;
const string SCHOOL_NAME = "Tech High";

// Auto type inference (C++11)
auto num = 42;        // int
auto price = 19.99;   // double
auto name = "Alice";  // const char* (use string for safety)
```

### Type Casting

```cpp
// Implicit casting (automatic)
int whole = 5;
double decimal = whole;  // 5.0

// Explicit casting
double price = 19.99;
int dollars = (int)price;  // 19 (C-style cast)
int dollars2 = int(price); // 19 (C++ style cast)
int dollars3 = static_cast<int>(price);  // 19 (preferred C++)

// Integer division vs float division
int a = 7, b = 2;
int result1 = a / b;                    // 3 (integer division)
double result2 = (double)a / b;         // 3.5 (cast one operand)
double result3 = static_cast<double>(a) / b;  // 3.5 (C++ style)

// String to number
#include <string>
string text = "123";
int num = stoi(text);      // String to int
double dec = stod(text);   // String to double

// Number to string
int age = 25;
string ageText = to_string(age);  // "25"
```

---

## Operators & Expressions

### Arithmetic Operators

```cpp
int a = 10;
int b = 3;

// Basic operations
int sum = a + b;        // 13
int diff = a - b;       // 7
int product = a * b;    // 30
int quotient = a / b;   // 3 (integer division)
int remainder = a % b;  // 1 (modulus - VERY IMPORTANT!)

// Floating-point division
double result = (double)a / b;  // 3.333...

// Increment/Decrement
int x = 5;
x++;     // x = 6 (post-increment)
++x;     // x = 7 (pre-increment)
x--;     // x = 6 (post-decrement)
--x;     // x = 5 (pre-decrement)

// Compound assignment
x += 5;  // x = x + 5
x -= 3;  // x = x - 3
x *= 2;  // x = x * 2
x /= 2;  // x = x / 2
x %= 3;  // x = x % 3
```

### Modulus Operator Uses

```cpp
// Check even/odd
if (num % 2 == 0) {
    cout << "Even" << endl;
} else {
    cout << "Odd" << endl;
}

// Check divisibility
if (num % 5 == 0) {
    cout << "Divisible by 5" << endl;
}

// Get last digit
int lastDigit = num % 10;

// Cycle through values
for (int i = 0; i < 20; i++) {
    int cyclic = i % 5;  // 0,1,2,3,4,0,1,2,3,4,...
}

// Division with remainder (perfect numbers, factors)
int dividend = 28;
int divisor = 7;
if (dividend % divisor == 0) {
    cout << divisor << " is a factor of " << dividend << endl;
}
```

### Comparison Operators

```cpp
int x = 10;
int y = 5;

// Equality
bool isEqual = (x == y);     // false
bool notEqual = (x != y);    // true

// Relational
bool greater = (x > y);      // true
bool greaterEq = (x >= y);   // true
bool less = (x < y);         // false
bool lessEq = (x <= y);      // false

// CRITICAL: Don't confuse = with ==
int a = 5;     // Assignment
if (a == 5) {  // Comparison
    // code
}
```

### Logical Operators

```cpp
// AND (&&) - both must be true
if (age >= 18 && hasLicense) {
    cout << "Can drive" << endl;
}

// OR (||) - at least one must be true
if (day == "Saturday" || day == "Sunday") {
    cout << "Weekend!" << endl;
}

// NOT (!) - reverses boolean
bool isRaining = false;
if (!isRaining) {
    cout << "No umbrella needed" << endl;
}

// Complex conditions
if ((age >= 18 && age <= 65) && income > 30000) {
    // Working age adult with income
}

// Short-circuit evaluation
if (x != 0 && 100 / x > 5) {  // Safe from division by zero
    // code
}
```

---

## Control Structures

### If Statements

```cpp
// Simple if
if (score >= 60) {
    cout << "Passing" << endl;
}

// If-else
if (temperature > 90) {
    cout << "Hot" << endl;
} else {
    cout << "Not hot" << endl;
}

// If-else if-else
if (grade >= 90) {
    cout << "A" << endl;
} else if (grade >= 80) {
    cout << "B" << endl;
} else if (grade >= 70) {
    cout << "C" << endl;
} else if (grade >= 60) {
    cout << "D" << endl;
} else {
    cout << "F" << endl;
}

// Nested if
if (age >= 16) {
    if (hasPermit) {
        cout << "Can drive with supervision" << endl;
    } else {
        cout << "Need permit" << endl;
    }
} else {
    cout << "Too young" << endl;
}
```

### Switch Statements

```cpp
int choice;
cout << "Enter choice (1-4): ";
cin >> choice;

switch (choice) {
    case 1:
        cout << "Option 1 selected" << endl;
        break;
    case 2:
        cout << "Option 2 selected" << endl;
        break;
    case 3:
        cout << "Option 3 selected" << endl;
        break;
    case 4:
        cout << "Option 4 selected" << endl;
        break;
    default:
        cout << "Invalid option" << endl;
        break;
}

// Multiple cases with same result
char grade;
cin >> grade;

switch (grade) {
    case 'A':
    case 'a':
        cout << "Excellent!" << endl;
        break;
    case 'B':
    case 'b':
        cout << "Good!" << endl;
        break;
    case 'F':
    case 'f':
        cout << "Failing" << endl;
        break;
    default:
        cout << "Invalid grade" << endl;
        break;
}
```

### For Loops

```cpp
// Standard for loop
for (int i = 0; i < 10; i++) {
    cout << i << " ";
}
cout << endl;  // 0 1 2 3 4 5 6 7 8 9

// Loop with different increment
for (int i = 0; i <= 100; i += 10) {
    cout << i << " ";  // 0 10 20 30 ... 100
}

// Countdown
for (int i = 10; i >= 1; i--) {
    cout << i << " ";  // 10 9 8 7 ... 1
}

// Loop through array
int numbers[5] = {10, 20, 30, 40, 50};
for (int i = 0; i < 5; i++) {
    cout << numbers[i] << " ";
}

// Loop through vector
vector<int> scores = {85, 92, 78, 90};
for (int i = 0; i < scores.size(); i++) {
    cout << scores[i] << " ";
}

// Range-based for loop (C++11)
for (int score : scores) {
    cout << score << " ";
}

// Nested loops
for (int row = 0; row < 5; row++) {
    for (int col = 0; col < 5; col++) {
        cout << "* ";
    }
    cout << endl;
}
```

### While Loops

```cpp
// Basic while loop
int count = 0;
while (count < 5) {
    cout << count << " ";
    count++;
}

// Input validation with while
int value;
cout << "Enter positive number: ";
cin >> value;

while (value <= 0) {
    cout << "Must be positive. Try again: ";
    cin >> value;
}

// Sentinel-controlled loop
int sum = 0;
int num;

cout << "Enter numbers (0 to stop):" << endl;
cin >> num;

while (num != 0) {
    sum += num;
    cin >> num;
}

cout << "Sum: " << sum << endl;
```

### Do-While Loops

```cpp
// COMPETITION REQUIREMENT: Often required
// Executes at least once

int choice;
do {
    cout << "\n=== Menu ===" << endl;
    cout << "1. Option 1" << endl;
    cout << "2. Option 2" << endl;
    cout << "3. Exit" << endl;
    cout << "Enter choice: ";
    cin >> choice;
    
    switch (choice) {
        case 1:
            cout << "Option 1 selected" << endl;
            break;
        case 2:
            cout << "Option 2 selected" << endl;
            break;
        case 3:
            cout << "Exiting..." << endl;
            break;
        default:
            cout << "Invalid choice" << endl;
            break;
    }
    
} while (choice != 3);

// Ask to run again pattern
char runAgain;
do {
    // Main program logic
    cout << "Program completed." << endl;
    
    cout << "Run again? (Y/N): ";
    cin >> runAgain;
    
} while (runAgain == 'Y' || runAgain == 'y');
```

### Loop Control

```cpp
// Break - exit loop immediately
for (int i = 0; i < 100; i++) {
    if (i == 50) {
        break;  // Exit loop when i reaches 50
    }
    cout << i << " ";
}

// Continue - skip rest of iteration
for (int i = 0; i < 10; i++) {
    if (i % 2 == 0) {
        continue;  // Skip even numbers
    }
    cout << i << " ";  // Only prints odd: 1 3 5 7 9
}

// Nested loops with break
bool found = false;
for (int i = 0; i < 10 && !found; i++) {
    for (int j = 0; j < 10; j++) {
        if (i * j == 24) {
            cout << "Found: " << i << " * " << j << endl;
            found = true;
            break;  // Exits inner loop only
        }
    }
}
```

---

## Functions

### Function Basics

```cpp
// Function structure:
// returnType functionName(parameters) {
//     // function body
//     return value;  // if not void
// }

// Void function (no return value)
void printGreeting() {
    cout << "Hello, World!" << endl;
}

// Function with return value
int add(int a, int b) {
    int sum = a + b;
    return sum;
}

// Function with multiple parameters
double calculateAverage(int score1, int score2, int score3) {
    double sum = score1 + score2 + score3;
    return sum / 3.0;
}

// Function with default parameters
void displayMessage(string msg = "Hello", int times = 1) {
    for (int i = 0; i < times; i++) {
        cout << msg << endl;
    }
}

// Calling functions
int main() {
    printGreeting();                    // Void function
    
    int result = add(5, 3);             // Function with return
    cout << result << endl;             // 8
    
    double avg = calculateAverage(85, 92, 78);
    cout << "Average: " << avg << endl;
    
    displayMessage();                   // Uses defaults
    displayMessage("Goodbye", 3);       // Custom values
    
    return 0;
}
```

### Function Prototypes (REQUIRED!)

```cpp
// Prototypes MUST appear before main
// Tell compiler function exists

// Function prototypes
bool isPrime(int n);
bool isPerfect(int n);
double calculateStandardDeviation(vector<int> data);
void displayResults(vector<int> primes, vector<int> perfects);

int main() {
    // Can now use these functions
    if (isPrime(17)) {
        cout << "17 is prime" << endl;
    }
    
    vector<int> data = {1, 2, 3, 4, 5};
    double stdDev = calculateStandardDeviation(data);
    
    return 0;
}

// Function definitions (after main)
bool isPrime(int n) {
    if (n <= 1) return false;
    
    for (int i = 2; i <= sqrt(n); i++) {
        if (n % i == 0) {
            return false;
        }
    }
    return true;
}

bool isPerfect(int n) {
    if (n <= 1) return false;
    
    int sum = 0;
    for (int i = 1; i < n; i++) {
        if (n % i == 0) {
            sum += i;
        }
    }
    return sum == n;
}

double calculateStandardDeviation(vector<int> data) {
    // Calculate average
    double sum = 0;
    for (int i = 0; i < data.size(); i++) {
        sum += data[i];
    }
    double average = sum / data.size();
    
    // Calculate sum of squared differences
    double sumSquaredDiff = 0;
    for (int i = 0; i < data.size(); i++) {
        double diff = data[i] - average;
        sumSquaredDiff += diff * diff;
    }
    
    // Calculate standard deviation
    double variance = sumSquaredDiff / (data.size() - 1);
    return sqrt(variance);
}

void displayResults(vector<int> primes, vector<int> perfects) {
    cout << "Prime Numbers: ";
    for (int i = 0; i < primes.size(); i++) {
        cout << primes[i];
        if (i < primes.size() - 1) {
            cout << ", ";
        }
    }
    cout << endl;
    
    cout << "Perfect Numbers: ";
    for (int i = 0; i < perfects.size(); i++) {
        cout << perfects[i];
        if (i < perfects.size() - 1) {
            cout << ", ";
        }
    }
    cout << endl;
}
```

### Pass by Value vs Pass by Reference

```cpp
// Pass by value (copy is made)
void incrementValue(int x) {
    x = x + 10;  // Changes local copy only
}

// Pass by reference (actual variable modified)
void incrementReference(int& x) {
    x = x + 10;  // Changes actual variable
}

int main() {
    int num = 5;
    
    incrementValue(num);
    cout << num << endl;  // Still 5
    
    incrementReference(num);
    cout << num << endl;  // Now 15
    
    return 0;
}

// Pass large objects by reference for efficiency
void processData(vector<int>& data) {
    // Modifies original vector
    for (int i = 0; i < data.size(); i++) {
        data[i] *= 2;
    }
}

// Pass by const reference (read-only, efficient)
double calculateAverage(const vector<int>& data) {
    // Cannot modify data
    double sum = 0;
    for (int i = 0; i < data.size(); i++) {
        sum += data[i];
    }
    return sum / data.size();
}
```

### Common Function Patterns

```cpp
// Finding maximum in vector
int findMax(vector<int> data) {
    if (data.empty()) {
        return 0;  // Or throw error
    }
    
    int max = data[0];
    for (int i = 1; i < data.size(); i++) {
        if (data[i] > max) {
            max = data[i];
        }
    }
    return max;
}

// Finding minimum in vector
int findMin(vector<int> data) {
    if (data.empty()) {
        return 0;
    }
    
    int min = data[0];
    for (int i = 1; i < data.size(); i++) {
        if (data[i] < min) {
            min = data[i];
        }
    }
    return min;
}

// Calculate average
double calculateAverage(vector<int> data) {
    if (data.empty()) {
        return 0.0;
    }
    
    double sum = 0;
    for (int i = 0; i < data.size(); i++) {
        sum += data[i];
    }
    return sum / data.size();
}

// Count values meeting condition
int countAbove(vector<int> data, int threshold) {
    int count = 0;
    for (int i = 0; i < data.size(); i++) {
        if (data[i] > threshold) {
            count++;
        }
    }
    return count;
}
```

---

## Arrays

### Array Basics

```cpp
// Declare array (fixed size)
int numbers[5];           // Array of 5 integers
double prices[10];        // Array of 10 doubles
string names[20];         // Array of 20 strings

// Initialize with values
int scores[5] = {85, 92, 78, 90, 88};
string cities[3] = {"Cleveland", "Columbus", "Cincinnati"};

// Partial initialization (rest are 0/empty)
int values[10] = {1, 2, 3};  // First 3 are 1,2,3, rest are 0

// Size determined by initializer
int data[] = {10, 20, 30, 40};  // Size is 4

// Access elements (zero-indexed)
cout << scores[0] << endl;  // 85 (first element)
cout << scores[4] << endl;  // 88 (fifth element)

scores[2] = 95;  // Change third element to 95

// Array size
const int SIZE = 5;
int numbers[SIZE];

// Loop through array
for (int i = 0; i < SIZE; i++) {
    numbers[i] = i * 10;
    cout << numbers[i] << " ";
}
```

### Array Operations

```cpp
// Calculate sum
int scores[5] = {85, 92, 78, 90, 88};
int sum = 0;

for (int i = 0; i < 5; i++) {
    sum += scores[i];
}

// Calculate average
double average = (double)sum / 5;

// Find maximum
int max = scores[0];
for (int i = 1; i < 5; i++) {
    if (scores[i] > max) {
        max = scores[i];
    }
}

// Find minimum
int min = scores[0];
for (int i = 1; i < 5; i++) {
    if (scores[i] < min) {
        min = scores[i];
    }
}

// Search for value
int target = 90;
int index = -1;

for (int i = 0; i < 5; i++) {
    if (scores[i] == target) {
        index = i;
        break;
    }
}

if (index != -1) {
    cout << "Found at index " << index << endl;
}
```

### Multi-Dimensional Arrays

```cpp
// 2D array (rows and columns)
int grid[3][4];  // 3 rows, 4 columns

// Initialize 2D array
int matrix[3][3] = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

// Access elements
cout << matrix[0][0] << endl;  // 1 (first row, first column)
cout << matrix[2][2] << endl;  // 9 (third row, third column)

// Loop through 2D array
for (int row = 0; row < 3; row++) {
    for (int col = 0; col < 3; col++) {
        cout << matrix[row][col] << " ";
    }
    cout << endl;
}

// Practical example: grade table
double grades[3][4] = {
    {85, 92, 78, 90},  // Student 1
    {88, 79, 95, 87},  // Student 2
    {92, 91, 89, 93}   // Student 3
};

// Calculate each student's average
for (int student = 0; student < 3; student++) {
    double sum = 0;
    for (int quiz = 0; quiz < 4; quiz++) {
        sum += grades[student][quiz];
    }
    double avg = sum / 4;
    cout << "Student " << (student + 1) << " average: " << avg << endl;
}
```

### Arrays with Functions

```cpp
// Passing array to function
// Array size must also be passed

void displayArray(int arr[], int size) {
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

double calculateArrayAverage(int arr[], int size) {
    double sum = 0;
    for (int i = 0; i < size; i++) {
        sum += arr[i];
    }
    return sum / size;
}

void fillArray(int arr[], int size, int value) {
    for (int i = 0; i < size; i++) {
        arr[i] = value;
    }
}

int main() {
    int numbers[5] = {10, 20, 30, 40, 50};
    
    displayArray(numbers, 5);
    
    double avg = calculateArrayAverage(numbers, 5);
    cout << "Average: " << avg << endl;
    
    fillArray(numbers, 5, 0);  // Set all to 0
    displayArray(numbers, 5);
    
    return 0;
}
```

---

## Vectors

### Vector Basics

```cpp
#include <vector>
using namespace std;

// Create empty vector
vector<int> numbers;
vector<double> prices;
vector<string> names;

// Create vector with size
vector<int> scores(10);  // 10 elements, all initialized to 0

// Create vector with size and initial value
vector<int> values(10, 5);  // 10 elements, all set to 5

// Initialize with values
vector<int> data = {10, 20, 30, 40, 50};
vector<string> cities = {"Cleveland", "Columbus", "Cincinnati"};

// Size of vector
cout << data.size() << endl;  // 5

// Check if empty
if (data.empty()) {
    cout << "Vector is empty" << endl;
}
```

### Vector Methods

```cpp
vector<int> numbers;

// Add elements
numbers.push_back(10);  // Add to end
numbers.push_back(20);
numbers.push_back(30);
// numbers is now {10, 20, 30}

// Access elements
cout << numbers[0] << endl;     // 10 (first element)
cout << numbers[2] << endl;     // 30 (third element)
cout << numbers.at(1) << endl;  // 20 (with bounds checking)

// Access first and last
cout << numbers.front() << endl;  // 10
cout << numbers.back() << endl;   // 30

// Remove last element
numbers.pop_back();  // removes 30
// numbers is now {10, 20}

// Clear all elements
numbers.clear();  // numbers is now empty

// Insert at position
numbers = {10, 20, 40};
numbers.insert(numbers.begin() + 2, 30);  // Insert 30 at index 2
// numbers is now {10, 20, 30, 40}

// Erase element
numbers.erase(numbers.begin() + 1);  // Remove element at index 1
// numbers is now {10, 30, 40}
```

### Looping Through Vectors

```cpp
vector<int> scores = {85, 92, 78, 90, 88};

// Standard for loop
for (int i = 0; i < scores.size(); i++) {
    cout << scores[i] << " ";
}
cout << endl;

// Range-based for loop (C++11) - EASIER
for (int score : scores) {
    cout << score << " ";
}
cout << endl;

// With reference (to modify elements)
for (int& score : scores) {
    score += 5;  // Add 5 to each score
}
```

### Vector Algorithms

```cpp
#include <algorithm>  // For sort, find, etc.

vector<int> numbers = {40, 10, 30, 20, 50};

// Sort vector (ascending)
sort(numbers.begin(), numbers.end());
// numbers is now {10, 20, 30, 40, 50}

// Sort descending
sort(numbers.begin(), numbers.end(), greater<int>());
// numbers is now {50, 40, 30, 20, 10}

// Find element
auto it = find(numbers.begin(), numbers.end(), 30);
if (it != numbers.end()) {
    cout << "Found 30 at index " << (it - numbers.begin()) << endl;
}

// Reverse vector
reverse(numbers.begin(), numbers.end());

// Sum of all elements (C++11)
#include <numeric>
int total = accumulate(numbers.begin(), numbers.end(), 0);
```

### Vectors with Functions

```cpp
// Passing vector by value (copy is made)
void displayVector(vector<int> v) {
    for (int i = 0; i < v.size(); i++) {
        cout << v[i] << " ";
    }
    cout << endl;
}

// Passing by reference (efficient, can modify)
void doubleValues(vector<int>& v) {
    for (int i = 0; i < v.size(); i++) {
        v[i] *= 2;
    }
}

// Passing by const reference (efficient, read-only)
double calculateAverage(const vector<int>& v) {
    if (v.empty()) {
        return 0.0;
    }
    
    double sum = 0;
    for (int i = 0; i < v.size(); i++) {
        sum += v[i];
    }
    return sum / v.size();
}

// Returning vector from function
vector<int> getEvenNumbers(vector<int> numbers) {
    vector<int> evens;
    
    for (int i = 0; i < numbers.size(); i++) {
        if (numbers[i] % 2 == 0) {
            evens.push_back(numbers[i]);
        }
    }
    
    return evens;
}
```

---

## Strings

### String Basics

```cpp
#include <string>
using namespace std;

// Create strings
string name = "Alice";
string empty;              // Empty string
string repeated(5, 'x');   // "xxxxx"

// String length
cout << name.length() << endl;  // 5
cout << name.size() << endl;    // 5 (same as length)

// Check if empty
if (empty.empty()) {
    cout << "String is empty" << endl;
}

// Access characters
char firstChar = name[0];      // 'A'
char lastChar = name[4];       // 'e'
char last = name[name.length() - 1];  // 'e' (safer)

// Modify character
name[0] = 'B';  // "Blice"
```

### String Operations

```cpp
string str1 = "Hello";
string str2 = "World";

// Concatenation
string result = str1 + " " + str2;  // "Hello World"
str1 += " there";  // "Hello there"

// Substring
string text = "Programming";
string sub = text.substr(0, 4);     // "Prog" (start at 0, length 4)
string sub2 = text.substr(3);       // "gramming" (from index 3 to end)

// Find
int pos = text.find("gram");        // 3 (position where "gram" starts)
int notFound = text.find("xyz");    // string::npos (not found)

if (text.find("gram") != string::npos) {
    cout << "Found 'gram'" << endl;
}

// Replace
string message = "Hello Alice";
message.replace(6, 5, "Bob");  // "Hello Bob" (start at 6, replace 5 chars)

// Insert
message.insert(5, " there");   // "Hello there Bob"

// Erase
message.erase(5, 6);           // "Hello Bob" (erase 6 chars from position 5)
```

### String Comparison

```cpp
string str1 = "apple";
string str2 = "banana";
string str3 = "apple";

// Equality
if (str1 == str3) {
    cout << "Equal" << endl;
}

if (str1 != str2) {
    cout << "Not equal" << endl;
}

// Lexicographical comparison (alphabetical)
if (str1 < str2) {
    cout << "apple comes before banana" << endl;
}

// Compare method
int result = str1.compare(str2);
// result < 0: str1 comes before str2
// result == 0: strings are equal
// result > 0: str1 comes after str2
```

### String Conversion

```cpp
#include <string>

// Number to string
int age = 25;
string ageStr = to_string(age);  // "25"

double price = 19.99;
string priceStr = to_string(price);  // "19.990000"

// String to number
string numText = "123";
int num = stoi(numText);        // String to int
double dec = stod(numText);     // String to double
long lng = stol(numText);       // String to long

// With error handling
try {
    string invalid = "abc";
    int value = stoi(invalid);  // Throws exception
} catch (invalid_argument& e) {
    cout << "Invalid number format" << endl;
} catch (out_of_range& e) {
    cout << "Number too large" << endl;
}

// Case conversion
#include <algorithm>
string text = "Hello World";

// To uppercase
transform(text.begin(), text.end(), text.begin(), ::toupper);
// text is now "HELLO WORLD"

// To lowercase
transform(text.begin(), text.end(), text.begin(), ::tolower);
// text is now "hello world"
```

### Character Operations

```cpp
#include <cctype>

char ch = 'A';

// Check character type
bool isLetter = isalpha(ch);      // true
bool isDigit = isdigit(ch);       // false
bool isUpper = isupper(ch);       // true
bool isLower = islower(ch);       // false
bool isSpace = isspace(' ');      // true

// Convert case
char lower = tolower(ch);         // 'a'
char upper = toupper('b');        // 'B'

// Process each character in string
string text = "Hello123";
int letterCount = 0;
int digitCount = 0;

for (int i = 0; i < text.length(); i++) {
    if (isalpha(text[i])) {
        letterCount++;
    } else if (isdigit(text[i])) {
        digitCount++;
    }
}

cout << "Letters: " << letterCount << endl;  // 5
cout << "Digits: " << digitCount << endl;    // 3
```

---

## File I/O

### Reading from Files

```cpp
#include <fstream>
#include <string>
using namespace std;

// Basic file reading
ifstream inputFile("data.txt");

// Check if file opened successfully
if (!inputFile) {
    cout << "Error opening file!" << endl;
    return 1;
}

// Read line by line
string line;
while (getline(inputFile, line)) {
    cout << line << endl;
}

inputFile.close();

// Read word by word
ifstream inputFile2("data.txt");
string word;

while (inputFile2 >> word) {
    cout << word << endl;
}

inputFile2.close();

// Read integers
ifstream inputFile3("numbers.txt");
int num;

while (inputFile3 >> num) {
    cout << num << endl;
}

inputFile3.close();
```

### Writing to Files

```cpp
#include <fstream>
using namespace std;

// Basic file writing
ofstream outputFile("output.txt");

if (!outputFile) {
    cout << "Error creating file!" << endl;
    return 1;
}

outputFile << "Hello, World!" << endl;
outputFile << "This is line 2" << endl;

outputFile.close();

// Append to file
ofstream appendFile("output.txt", ios::app);

appendFile << "This is appended" << endl;

appendFile.close();

// Write numbers
ofstream numFile("numbers.txt");

for (int i = 1; i <= 10; i++) {
    numFile << i << endl;
}

numFile.close();
```

### File I/O Patterns

```cpp
// COMPETITION PATTERN: Load integers into vector
vector<int> loadDataFromFile(string filename) {
    vector<int> data;
    ifstream inputFile(filename);
    
    if (!inputFile) {
        cout << "Error: Could not open file" << endl;
        return data;  // Return empty vector
    }
    
    int value;
    while (inputFile >> value) {
        data.push_back(value);
    }
    
    inputFile.close();
    
    if (data.empty()) {
        cout << "Error: No data elements found" << endl;
    }
    
    return data;
}

// Usage
int main() {
    vector<int> testScores = loadDataFromFile("testscores.txt");
    
    if (testScores.empty()) {
        return 1;  // Exit if no data
    }
    
    // Process data...
    
    return 0;
}

// Save results to file
void saveResults(string filename, vector<int> data) {
    ofstream outputFile(filename);
    
    if (!outputFile) {
        cout << "Error: Could not create file" << endl;
        return;
    }
    
    for (int i = 0; i < data.size(); i++) {
        outputFile << data[i] << endl;
    }
    
    outputFile.close();
}
```

### File Path Handling

```cpp
// Hardcoded path
string filename = "testscores.txt";
string filepath = "C:\\data\\testscores.txt";  // Windows (double backslash)
string filepath2 = "/home/user/data/testscores.txt";  // Linux/Mac

// Ask user for filename
string filename;
cout << "Enter filename: ";
cin >> filename;

ifstream inputFile(filename);

// Check if file exists before opening
#include <fstream>
bool fileExists(string filename) {
    ifstream file(filename);
    return file.good();
}

if (fileExists("data.txt")) {
    cout << "File exists" << endl;
}
```

---

## Mathematical Operations

### Math Functions

```cpp
#include <cmath>
using namespace std;

// Power and roots
double squared = pow(5, 2);      // 25 (5^2)
double cubed = pow(2, 3);        // 8 (2^3)
double squareRoot = sqrt(16);    // 4
double cubeRoot = cbrt(27);      // 3

// Absolute value
int absValue = abs(-5);          // 5
double absDouble = fabs(-3.14);  // 3.14

// Rounding
double rounded = round(3.7);     // 4.0
double ceilingVal = ceil(3.2);   // 4.0 (round up)
double floorVal = floor(3.8);    // 3.0 (round down)

// Trigonometry (radians)
double sine = sin(0.5);
double cosine = cos(0.5);
double tangent = tan(0.5);

// Exponential and logarithm
double e = exp(1);               // e^1 ≈ 2.718
double natural = log(10);        // ln(10)
double base10 = log10(100);      // 2 (log base 10)

// Min and Max
int minimum = min(5, 10);        // 5
int maximum = max(5, 10);        // 10
double minDouble = fmin(3.5, 2.1);  // 2.1
```

### Random Numbers

```cpp
#include <cstdlib>   // For rand() and srand()
#include <ctime>     // For time()

// Seed random number generator (do once at start of program)
srand(time(0));

// Generate random numbers
int random = rand();  // Random number 0 to RAND_MAX

// Random number in range [min, max]
int min = 1;
int max = 100;
int randomInRange = rand() % (max - min + 1) + min;

// Examples
int dice = rand() % 6 + 1;        // 1-6 (dice roll)
int percent = rand() % 101;       // 0-100
int temp = rand() % 41 + 60;      // 60-100

// Random double [0.0, 1.0)
double randomDouble = (double)rand() / RAND_MAX;

// Random double in range
double minD = 10.0;
double maxD = 50.0;
double randomRange = minD + (maxD - minD) * ((double)rand() / RAND_MAX);
```

### Statistical Calculations

```cpp
#include <cmath>
#include <vector>

// Calculate average (mean)
double calculateAverage(vector<int> data) {
    if (data.empty()) return 0.0;
    
    double sum = 0;
    for (int i = 0; i < data.size(); i++) {
        sum += data[i];
    }
    return sum / data.size();
}

// Calculate standard deviation
double calculateStandardDeviation(vector<int> data) {
    if (data.size() <= 1) return 0.0;
    
    // Calculate average
    double avg = calculateAverage(data);
    
    // Calculate sum of squared differences
    double sumSquaredDiff = 0;
    for (int i = 0; i < data.size(); i++) {
        double diff = data[i] - avg;
        sumSquaredDiff += diff * diff;
    }
    
    // Standard deviation formula: sqrt(sum/(n-1))
    double variance = sumSquaredDiff / (data.size() - 1);
    return sqrt(variance);
}

// Calculate median (requires sorted data)
double calculateMedian(vector<int> data) {
    if (data.empty()) return 0.0;
    
    sort(data.begin(), data.end());
    
    int size = data.size();
    if (size % 2 == 0) {
        // Even number of elements - average of middle two
        return (data[size/2 - 1] + data[size/2]) / 2.0;
    } else {
        // Odd number of elements - middle element
        return data[size/2];
    }
}

// Find mode (most frequent value)
int findMode(vector<int> data) {
    if (data.empty()) return 0;
    
    sort(data.begin(), data.end());
    
    int mode = data[0];
    int maxCount = 1;
    int currentCount = 1;
    
    for (int i = 1; i < data.size(); i++) {
        if (data[i] == data[i-1]) {
            currentCount++;
            if (currentCount > maxCount) {
                maxCount = currentCount;
                mode = data[i];
            }
        } else {
            currentCount = 1;
        }
    }
    
    return mode;
}
```

---

## Common Algorithms

### Prime Number Checking

```cpp
// COMPETITION REQUIREMENT: Often required
#include <cmath>

bool isPrime(int n) {
    // Numbers <= 1 are not prime
    if (n <= 1) {
        return false;
    }
    
    // 2 and 3 are prime
    if (n <= 3) {
        return true;
    }
    
    // Even numbers (except 2) are not prime
    if (n % 2 == 0) {
        return false;
    }
    
    // Check odd divisors up to sqrt(n)
    for (int i = 3; i <= sqrt(n); i += 2) {
        if (n % i == 0) {
            return false;
        }
    }
    
    return true;
}

// Find all primes up to n
vector<int> findPrimes(int n) {
    vector<int> primes;
    
    for (int i = 2; i <= n; i++) {
        if (isPrime(i)) {
            primes.push_back(i);
        }
    }
    
    return primes;
}
```

### Perfect Number Checking

```cpp
// COMPETITION REQUIREMENT: Often required

bool isPerfect(int n) {
    // Numbers <= 1 are not perfect
    if (n <= 1) {
        return false;
    }
    
    // Find sum of proper divisors (all divisors except n)
    int sum = 0;
    for (int i = 1; i < n; i++) {
        if (n % i == 0) {
            sum += i;
        }
    }
    
    // Perfect if sum of divisors equals n
    return sum == n;
}

// Optimized version (check up to sqrt(n))
bool isPerfectOptimized(int n) {
    if (n <= 1) {
        return false;
    }
    
    int sum = 1;  // 1 is always a divisor
    
    for (int i = 2; i <= sqrt(n); i++) {
        if (n % i == 0) {
            sum += i;
            
            // Also add the corresponding divisor
            if (i != n / i) {
                sum += n / i;
            }
        }
    }
    
    return sum == n;
}

// Find all perfect numbers up to n
vector<int> findPerfects(int n) {
    vector<int> perfects;
    
    for (int i = 2; i <= n; i++) {
        if (isPerfect(i)) {
            perfects.push_back(i);
        }
    }
    
    return perfects;
}
```

### Quartile Distribution

```cpp
// COMPETITION REQUIREMENT: May be required
// Count how many values fall into each quartile

void calculateQuartiles(vector<int> data) {
    int q1 = 0, q2 = 0, q3 = 0, q4 = 0;
    
    for (int i = 0; i < data.size(); i++) {
        if (data[i] >= 0 && data[i] <= 24) {
            q1++;
        } else if (data[i] >= 25 && data[i] <= 49) {
            q2++;
        } else if (data[i] >= 50 && data[i] <= 74) {
            q3++;
        } else if (data[i] >= 75 && data[i] <= 100) {
            q4++;
        }
    }
    
    cout << "Quartile 1: " << q1 << endl;
    cout << "Quartile 2: " << q2 << endl;
    cout << "Quartile 3: " << q3 << endl;
    cout << "Quartile 4: " << q4 << endl;
}

// More flexible version
void calculateQuartiles(vector<int> data, int min, int max) {
    int range = (max - min + 1) / 4;
    vector<int> quartileCounts(4, 0);
    
    for (int i = 0; i < data.size(); i++) {
        int value = data[i];
        
        if (value < min || value > max) {
            continue;  // Skip out-of-range values
        }
        
        int quartile = (value - min) / range;
        if (quartile > 3) quartile = 3;  // Last quartile includes max
        
        quartileCounts[quartile]++;
    }
    
    for (int i = 0; i < 4; i++) {
        cout << "Quartile " << (i + 1) << ": " << quartileCounts[i] << endl;
    }
}
```

### Sorting

```cpp
#include <algorithm>

// Sort vector
vector<int> numbers = {40, 10, 30, 20, 50};

sort(numbers.begin(), numbers.end());  // Ascending
// numbers is now {10, 20, 30, 40, 50}

// Sort descending
sort(numbers.begin(), numbers.end(), greater<int>());
// numbers is now {50, 40, 30, 20, 10}

// Sort array
int arr[5] = {40, 10, 30, 20, 50};
sort(arr, arr + 5);  // Ascending

// Manual bubble sort (if required)
void bubbleSort(vector<int>& arr) {
    int n = arr.size();
    
    for (int i = 0; i < n - 1; i++) {
        for (int j = 0; j < n - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                // Swap
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}
```

### Searching

```cpp
#include <algorithm>

// Linear search (unsorted data)
int linearSearch(vector<int> data, int target) {
    for (int i = 0; i < data.size(); i++) {
        if (data[i] == target) {
            return i;  // Found at index i
        }
    }
    return -1;  // Not found
}

// Binary search (sorted data only)
int binarySearch(vector<int> data, int target) {
    int left = 0;
    int right = data.size() - 1;
    
    while (left <= right) {
        int mid = left + (right - left) / 2;
        
        if (data[mid] == target) {
            return mid;  // Found at index mid
        } else if (data[mid] < target) {
            left = mid + 1;  // Search right half
        } else {
            right = mid - 1;  // Search left half
        }
    }
    
    return -1;  // Not found
}

// Using STL binary_search (returns bool)
#include <algorithm>
vector<int> sorted = {10, 20, 30, 40, 50};

if (binary_search(sorted.begin(), sorted.end(), 30)) {
    cout << "Found" << endl;
}

// Using STL find
auto it = find(sorted.begin(), sorted.end(), 30);
if (it != sorted.end()) {
    int index = it - sorted.begin();
    cout << "Found at index " << index << endl;
}
```

---

## Error Handling

### Input Validation

```cpp
// Check if cin failed
int value;
cout << "Enter number: ";
cin >> value;

if (cin.fail()) {
    cout << "Invalid input!" << endl;
    cin.clear();  // Clear error flag
    cin.ignore(10000, '\n');  // Discard bad input
}

// Complete validation function
int getValidInteger() {
    int value;
    
    while (true) {
        cout << "Enter integer: ";
        cin >> value;
        
        if (cin.fail()) {
            cin.clear();
            cin.ignore(10000, '\n');
            cout << "Invalid input. Try again." << endl;
        } else {
            cin.ignore(10000, '\n');  // Clear any extra input
            return value;
        }
    }
}

// Validate range
int getValidRange(int min, int max) {
    int value;
    
    while (true) {
        value = getValidInteger();
        
        if (value >= min && value <= max) {
            return value;
        }
        
        cout << "Value must be between " << min << " and " << max << endl;
    }
}
```

### File Error Handling

```cpp
// Check if file opened
ifstream inputFile("data.txt");

if (!inputFile) {
    cout << "Error: Could not open file" << endl;
    return 1;  // Exit program
}

// Check if file is empty
vector<int> data;
int value;

while (inputFile >> value) {
    data.push_back(value);
}

if (data.empty()) {
    cout << "Error: No data elements found" << endl;
    return 1;
}

// Complete file reading with error handling
vector<int> loadFile(string filename) {
    vector<int> data;
    ifstream inputFile(filename);
    
    // Check if file opened
    if (!inputFile) {
        cout << "Error: Could not open file '" << filename << "'" << endl;
        return data;  // Return empty vector
    }
    
    // Read data
    int value;
    while (inputFile >> value) {
        data.push_back(value);
    }
    
    inputFile.close();
    
    // Check if empty
    if (data.empty()) {
        cout << "Error: File contains no data elements" << endl;
    }
    
    return data;
}
```

### Try-Catch (Exceptions)

```cpp
#include <stdexcept>

// Throw exception
void validateScore(int score) {
    if (score < 0 || score > 100) {
        throw invalid_argument("Score must be 0-100");
    }
}

// Catch exception
try {
    int score = 150;
    validateScore(score);
    cout << "Valid score" << endl;
} catch (invalid_argument& e) {
    cout << "Error: " << e.what() << endl;
}

// String to int with error handling
try {
    string text = "abc";
    int num = stoi(text);  // Throws exception
} catch (invalid_argument& e) {
    cout << "Invalid number format" << endl;
} catch (out_of_range& e) {
    cout << "Number too large" << endl;
}
```

---

## Memory & Pointers

### Pointer Basics

```cpp
// Declare pointer
int* ptr;
double* dPtr;
string* sPtr;

// Get address of variable
int x = 42;
int* ptr = &x;  // ptr holds address of x

// Dereference pointer (get value)
cout << *ptr << endl;  // 42

// Change value through pointer
*ptr = 100;
cout << x << endl;  // 100 (x was changed)

// Null pointer
int* nullPtr = nullptr;  // C++11 (use NULL in older C++)

// Check for null
if (ptr != nullptr) {
    cout << *ptr << endl;
}
```

### Dynamic Memory Allocation

```cpp
// Allocate single variable
int* ptr = new int;
*ptr = 42;
cout << *ptr << endl;
delete ptr;  // Free memory

// Allocate array
int size = 10;
int* arr = new int[size];

for (int i = 0; i < size; i++) {
    arr[i] = i * 10;
}

delete[] arr;  // Free array memory (note the [])

// Always pair new with delete!
// Memory leak if you forget delete
```

### References

```cpp
// Reference - alias for existing variable
int x = 42;
int& ref = x;  // ref is another name for x

cout << ref << endl;  // 42
ref = 100;
cout << x << endl;    // 100 (x was changed)

// References in functions (already covered)
void increment(int& value) {
    value++;  // Modifies original
}

int main() {
    int num = 5;
    increment(num);
    cout << num << endl;  // 6
    
    return 0;
}
```

---

## Debugging & Testing

### Common Compilation Errors

```cpp
// ❌ Missing semicolon
int x = 5

// ✅ CORRECT
int x = 5;

// ❌ Undeclared variable
cout << total << endl;  // total was never declared

// ✅ CORRECT
int total = 0;
cout << total << endl;

// ❌ Wrong function prototype
int add(int a, int b);
double add(int a, int b) {  // Return type doesn't match
    return a + b;
}

// ✅ CORRECT
double add(int a, int b);
double add(int a, int b) {
    return a + b;
}

// ❌ Missing return statement
int getMax(int a, int b) {
    if (a > b) {
        return a;
    }
    // Missing return for else case!
}

// ✅ CORRECT
int getMax(int a, int b) {
    if (a > b) {
        return a;
    } else {
        return b;
    }
}
```

### Common Runtime Errors

```cpp
// Array index out of bounds
int arr[5] = {1, 2, 3, 4, 5};
cout << arr[10] << endl;  // CRASH! (index 10 doesn't exist)

// Solution: Check bounds
int index = 10;
if (index >= 0 && index < 5) {
    cout << arr[index] << endl;
}

// Division by zero
int result = 10 / 0;  // CRASH!

// Solution: Check divisor
int divisor = 0;
if (divisor != 0) {
    int result = 10 / divisor;
}

// Null pointer dereference
int* ptr = nullptr;
cout << *ptr << endl;  // CRASH!

// Solution: Check for null
if (ptr != nullptr) {
    cout << *ptr << endl;
}

// Vector index out of bounds
vector<int> v = {1, 2, 3};
cout << v[10] << endl;  // May crash

// Solution: Use at() for bounds checking
try {
    cout << v.at(10) << endl;
} catch (out_of_range& e) {
    cout << "Index out of range" << endl;
}
```

### Debug Output

```cpp
// Print debug information
cout << "DEBUG: x = " << x << endl;
cout << "DEBUG: vector size = " << v.size() << endl;

// Conditional debug output
#define DEBUG 1

if (DEBUG) {
    cout << "DEBUG: Entering function" << endl;
}

// Trace program flow
void myFunction() {
    cout << "Entering myFunction" << endl;
    
    // Function code...
    
    cout << "Exiting myFunction" << endl;
}

// Check loop iterations
for (int i = 0; i < 10; i++) {
    cout << "DEBUG: Iteration " << i << endl;
    // Loop code...
}
```

### Testing Strategies

```cpp
// Test with boundary values
// For range 0-100, test:
// - Below minimum (e.g., -1)
// - Minimum (0)
// - Middle (50)
// - Maximum (100)
// - Above maximum (101)

// Test edge cases
vector<int> empty;
calculateAverage(empty);  // What happens with empty?

vector<int> single = {42};
calculateAverage(single);  // What happens with one element?

// Test typical cases
vector<int> normal = {10, 20, 30, 40, 50};
double avg = calculateAverage(normal);  // Should be 30

// Verify calculations manually
int result = isPrime(17);  // Should be true
int result2 = isPerfect(28);  // Should be true
```

---

## Complete Example Programs

### Example 1: Test Score Statistics Reporter

```cpp
// Contestant Number: 01-2345-6789
/*
 * Test Score Statistics Reporter
 * Loads test scores from file and calculates statistics
 * Date: Competition Date
 */

#include <iostream>
#include <fstream>
#include <vector>
#include <cmath>
#include <iomanip>
using namespace std;

// Function prototypes
vector<int> loadScores(string filename);
double calculateAverage(const vector<int>& scores);
int findMin(const vector<int>& scores);
int findMax(const vector<int>& scores);
double calculateStandardDeviation(const vector<int>& scores);
void displayQuartiles(const vector<int>& scores);
void displayStatistics(const vector<int>& scores);

int main() {
    // Load test scores from file
    vector<int> testScores = loadScores("testscores.txt");
    
    // Check if file loaded successfully
    if (testScores.empty()) {
        return 1;  // Exit program
    }
    
    // Display all statistics
    displayStatistics(testScores);
    
    // Pause before exit
    cout << "Press any key to continue . . ." << endl;
    cin.get();
    
    return 0;
}

// Load scores from file
vector<int> loadScores(string filename) {
    vector<int> scores;
    ifstream inputFile(filename);
    
    // Check if file opened
    if (!inputFile) {
        cout << "Error: Could not open file" << endl;
        return scores;
    }
    
    // Read all integers
    int score;
    while (inputFile >> score) {
        scores.push_back(score);
    }
    
    inputFile.close();
    
    // Check if empty
    if (scores.empty()) {
        cout << "Error: No data elements found" << endl;
    }
    
    return scores;
}

// Calculate average
double calculateAverage(const vector<int>& scores) {
    if (scores.empty()) {
        return 0.0;
    }
    
    double sum = 0;
    for (int i = 0; i < scores.size(); i++) {
        sum += scores[i];
    }
    
    return sum / scores.size();
}

// Find minimum value
int findMin(const vector<int>& scores) {
    if (scores.empty()) {
        return 0;
    }
    
    int minimum = scores[0];
    for (int i = 1; i < scores.size(); i++) {
        if (scores[i] < minimum) {
            minimum = scores[i];
        }
    }
    
    return minimum;
}

// Find maximum value
int findMax(const vector<int>& scores) {
    if (scores.empty()) {
        return 0;
    }
    
    int maximum = scores[0];
    for (int i = 1; i < scores.size(); i++) {
        if (scores[i] > maximum) {
            maximum = scores[i];
        }
    }
    
    return maximum;
}

// Calculate standard deviation
double calculateStandardDeviation(const vector<int>& scores) {
    if (scores.size() <= 1) {
        return 0.0;
    }
    
    // Calculate average
    double avg = calculateAverage(scores);
    
    // Calculate sum of squared differences
    double sumSquaredDiff = 0;
    for (int i = 0; i < scores.size(); i++) {
        double diff = scores[i] - avg;
        sumSquaredDiff += diff * diff;
    }
    
    // Standard deviation formula
    double variance = sumSquaredDiff / (scores.size() - 1);
    return sqrt(variance);
}

// Display quartile distribution
void displayQuartiles(const vector<int>& scores) {
    int q1 = 0, q2 = 0, q3 = 0, q4 = 0;
    
    for (int i = 0; i < scores.size(); i++) {
        if (scores[i] >= 0 && scores[i] <= 24) {
            q1++;
        } else if (scores[i] >= 25 && scores[i] <= 49) {
            q2++;
        } else if (scores[i] >= 50 && scores[i] <= 74) {
            q3++;
        } else if (scores[i] >= 75 && scores[i] <= 100) {
            q4++;
        }
    }
    
    cout << "Quartile 1: " << q1 << endl;
    cout << "Quartile 2: " << q2 << endl;
    cout << "Quartile 3: " << q3 << endl;
    cout << "Quartile 4: " << q4 << endl;
}

// Display all statistics
void displayStatistics(const vector<int>& scores) {
    cout << fixed << setprecision(2);
    
    cout << "Number of Elements: " << scores.size() << endl;
    cout << endl;
    cout << "Average: " << calculateAverage(scores) << endl;
    cout << "Min Value: " << findMin(scores) << endl;
    cout << "Max Value: " << findMax(scores) << endl;
    cout << "Standard Deviation: " << calculateStandardDeviation(scores) << endl;
    cout << endl;
    displayQuartiles(scores);
}
```

### Example 2: Prime and Perfect Numbers

```cpp
// Contestant Number: 01-2345-6789
/*
 * Prime and Perfect Number Finder
 * Displays all prime and perfect numbers up to user-specified limit
 * Date: Competition Date
 */

#include <iostream>
#include <vector>
#include <cmath>
#include <cstdlib>  // For system()
using namespace std;

// Function prototypes
bool isPrime(int n);
bool isPerfect(int n);
void displayPrimes(int limit);
void displayPerfects(int limit);
void clearScreen();
void pauseScreen();

int main() {
    char runAgain;
    
    do {
        int limit;
        
        // Get user input
        cout << "Enter number to count up to: ";
        cin >> limit;
        
        // Validate input
        while (limit < 1) {
            cout << "Please enter a positive number: ";
            cin >> limit;
        }
        
        // Display prime numbers
        displayPrimes(limit);
        pauseScreen();
        clearScreen();
        
        // Display perfect numbers
        displayPerfects(limit);
        pauseScreen();
        clearScreen();
        
        // Ask to run again
        cout << "Run again? (Y/N): ";
        cin >> runAgain;
        
        if (runAgain == 'Y' || runAgain == 'y') {
            clearScreen();
        }
        
    } while (runAgain == 'Y' || runAgain == 'y');
    
    return 0;
}

// Check if number is prime
bool isPrime(int n) {
    if (n <= 1) {
        return false;
    }
    
    if (n <= 3) {
        return true;
    }
    
    if (n % 2 == 0) {
        return false;
    }
    
    for (int i = 3; i <= sqrt(n); i += 2) {
        if (n % i == 0) {
            return false;
        }
    }
    
    return true;
}

// Check if number is perfect
bool isPerfect(int n) {
    if (n <= 1) {
        return false;
    }
    
    int sum = 0;
    for (int i = 1; i < n; i++) {
        if (n % i == 0) {
            sum += i;
        }
    }
    
    return sum == n;
}

// Display all prime numbers up to limit
void displayPrimes(int limit) {
    cout << "Prime Numbers:" << endl;
    
    bool first = true;
    for (int i = 2; i <= limit; i++) {
        if (isPrime(i)) {
            if (!first) {
                cout << ", ";
            }
            cout << i;
            first = false;
        }
    }
    
    cout << endl;
}

// Display all perfect numbers up to limit
void displayPerfects(int limit) {
    cout << "Perfect Numbers:" << endl;
    
    bool first = true;
    for (int i = 2; i <= limit; i++) {
        if (isPerfect(i)) {
            if (!first) {
                cout << ", ";
            }
            cout << i;
            first = false;
        }
    }
    
    cout << endl;
}

// Clear screen
void clearScreen() {
    #ifdef _WIN32
        system("cls");
    #else
        system("clear");
    #endif
}

// Pause for user input
void pauseScreen() {
    cout << "\nPress Enter to continue...";
    cin.ignore();
    cin.get();
}
```

---

## Quick Reference

### Essential Syntax

```cpp
// Comments
// Single line comment
/* Multi-line
   comment */

// Variables
int x = 5;
double y = 3.14;
string name = "Alice";
const int MAX = 100;

// Input/Output
cin >> x;
cout << "Value: " << x << endl;

// Conditionals
if (x > 5) { }
else if (x < 5) { }
else { }

switch (x) {
    case 1: break;
    default: break;
}

// Loops
for (int i = 0; i < 10; i++) { }
while (condition) { }
do { } while (condition);

// Functions
int add(int a, int b) {
    return a + b;
}

// Vectors
vector<int> v;
v.push_back(5);
int size = v.size();

// File I/O
ifstream in("file.txt");
ofstream out("file.txt");

// Math
sqrt(x);
pow(x, 2);
abs(x);
```

---

## Competition Day Checklist

### Before Starting
- [ ] Read entire problem
- [ ] Note required functions
- [ ] Note file I/O requirements
- [ ] Plan program structure

### While Coding
- [ ] Add contestant number comment at top
- [ ] Name project correctly (CPP_335_ContestantNumber)
- [ ] Write function prototypes before main
- [ ] Comment each function
- [ ] Use meaningful variable names
- [ ] Handle file errors
- [ ] Test with sample data

### Before Submitting
- [ ] Program compiles without errors
- [ ] Program runs correctly
- [ ] Output matches format exactly
- [ ] All required functions present
- [ ] Code is commented
- [ ] Project saved on flash drive
- [ ] Files in correct folder

---

**Good luck on your competition!**
