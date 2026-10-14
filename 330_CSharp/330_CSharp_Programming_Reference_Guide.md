# C# Programming Competition Reference Guide
## Comprehensive Study Material for BPA Competitions

---

## Table of Contents
1. [Competition Format & Requirements](#competition-format--requirements)
2. [Windows Forms Basics](#windows-forms-basics)
3. [Controls Overview](#controls-overview)
4. [Data Types & Variables](#data-types--variables)
5. [Operators & Expressions](#operators--expressions)
6. [Control Structures](#control-structures)
7. [Methods](#methods)
8. [Event Handlers](#event-handlers)
9. [String Manipulation](#string-manipulation)
10. [Collections (List<T>)](#collections-listt)
11. [Input Validation](#input-validation)
12. [Output Formatting](#output-formatting)
13. [Math Operations](#math-operations)
14. [Control Properties & Methods](#control-properties--methods)
15. [MessageBox & Dialogs](#messagebox--dialogs)
16. [Random Generation](#random-generation)
17. [Common Patterns](#common-patterns)
18. [Debugging & Testing](#debugging--testing)
19. [Complete Example Program](#complete-example-program)

---

## Competition Format & Requirements

### What You Need to Know

BPA C# competitions typically require you to:
1. Create a Windows Forms Application in Visual Studio (2019 or greater)
2. Implement logic for multiple button click events
3. Handle user input with proper validation
4. Manipulate UI controls dynamically
5. Format output correctly
6. Comment code appropriately with flag comments (//SC1, //SC2, etc.)
7. Submit working code on flash drive in 90 minutes

### Critical Rules

```csharp
// ❌ WRONG - No contestant ID
using System;
using System.Windows.Forms;

namespace MyApp

// ✅ CORRECT - Contestant ID at top
// Contestant ID: 01-2345-6789
using System;
using System.Windows.Forms;

namespace MyApp

// ❌ WRONG - Project name doesn't follow convention
MyApplication

// ✅ CORRECT - Follows naming convention
CS_330_01-2345-6789

// ❌ WRONG - No flag comment for graded code
List<string> items = new List<string>();
lst_Display.Items.Clear();

// ✅ CORRECT - Flag comment present
//SC1: Creating data structure and populating list
List<string> items = new List<string>();
foreach (string item in items)
{
    lst_Display.Items.Add(item);
}
```

### Grading Breakdown (Typical 400-1000+ points)

**Solution and Project (20 points)**
- Project present on flash drive
- Named according to conventions

**Program Execution (400-800 points)**
- Program runs without errors
- Button implementations work correctly
- Input validation with error messages
- Correct calculations and output
- UI updates properly

**Source Code Review (150-250 points)**
- Contestant ID comment at top
- Flag comments for graded sections (//SC1, //SC2, etc.)
- Proper naming conventions (btn_, txt_, lbl_, etc.)
- Code structure and logic
- Method implementation

---

## Windows Forms Basics

### Creating a Windows Forms Application

```csharp
// Project Type: Windows Forms App (.NET Framework)
// Name: CS_330_01-2345-6789

using System;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
```

### Form Properties

```csharp
// Set in Properties window or code:

// Form title
this.Text = "Recipe Manager";

// Start position
this.StartPosition = FormStartPosition.CenterScreen;

// Prevent resizing
this.FormBorderStyle = FormBorderStyle.FixedDialog;

// Remove minimize/maximize buttons
this.MaximizeBox = false;
this.MinimizeBox = false;

// Set form size
this.Size = new System.Drawing.Size(800, 600);
```

### Common Namespaces

```csharp
using System;                    // Basic types
using System.Collections.Generic; // List<T>, Dictionary
using System.Drawing;            // Color, Font
using System.Windows.Forms;      // All controls
using System.Linq;               // LINQ operations
```

---

## Controls Overview

### Naming Conventions (CRITICAL!)

All controls must use standard prefixes:

```csharp
// Buttons
Button btn_Add;
Button btn_Remove;
Button btn_Calculate;

// TextBoxes
TextBox txt_Title;
TextBox txt_Author;
TextBox txt_Input;

// Labels
Label lbl_Title;
Label lbl_Result;
Label lbl_Status;

// ListBoxes
ListBox lst_Books;
ListBox lst_Results;

// RadioButtons
RadioButton rdb_Option1;
RadioButton rdb_Option2;

// CheckBoxes
CheckBox chk_Available;
CheckBox chk_Active;

// ComboBoxes
ComboBox cmb_Category;
ComboBox cmb_Options;

// GroupBoxes
GroupBox grp_Options;
GroupBox grp_Settings;

// Panels
Panel pnl_Display;
Panel pnl_Controls;

// TabControl
TabControl tab_Main;
TabPage tabPage_Books;
TabPage tabPage_Authors;
```

### Control Basics

```csharp
// Access control properties
btn_Add.Text = "Add Item";
txt_Title.Text = "Enter title here";
lbl_Result.Text = "Result: 0";

// Enable/Disable controls
btn_Calculate.Enabled = false;
txt_Input.Enabled = true;

// Show/Hide controls
pnl_Display.Visible = true;
lbl_Error.Visible = false;

// Set colors
lbl_Status.ForeColor = Color.Blue;
lbl_Status.BackColor = Color.LightGray;

// Set fonts
lbl_Title.Font = new Font("Arial", 14, FontStyle.Bold);
```

---

## Data Types & Variables

### Primitive Types

```csharp
// Integer types
int count = 10;
long bigNumber = 1000000L;

// Floating-point types
double price = 19.99;
decimal money = 99.95m;  // Use decimal for currency

// Boolean
bool isActive = true;
bool hasItems = false;

// Character
char grade = 'A';

// String
string name = "Book Title";
string empty = "";
string nullString = null;

// Var (type inference)
var number = 42;        // int
var text = "Hello";     // string
var amount = 19.99;     // double
```

### Variable Declaration

```csharp
// Declaration only
int x;
string name;

// Declaration with initialization
int score = 95;
string title = "My Book";

// Multiple declarations
int a, b, c;
int x = 5, y = 10, z = 15;

// Constants
const int MAX_ITEMS = 100;
const double TAX_RATE = 0.07;
const string APP_TITLE = "Recipe Manager";

// Class-level variables (fields)
public partial class Form1 : Form
{
    private int counter = 0;
    private List<string> items = new List<string>();
    private bool isRunning = false;
    
    // Constructor
    public Form1()
    {
        InitializeComponent();
    }
}
```

### Type Conversion

```csharp
// Implicit conversion (safe)
int wholeNumber = 5;
double decimalNumber = wholeNumber;  // 5.0

// Explicit conversion (cast)
double price = 19.99;
int dollars = (int)price;  // 19

// Parse methods (can throw exception)
string text = "123";
int number = int.Parse(text);
double amount = double.Parse("45.67");

// TryParse (RECOMMENDED - safe parsing)
string input = txt_Age.Text;
int age;

if (int.TryParse(input, out age))
{
    // Parsing successful, age contains value
    lbl_Result.Text = "Age: " + age;
}
else
{
    // Parsing failed
    MessageBox.Show("Please enter a valid number");
}

// Convert class methods
int num = Convert.ToInt32("123");
double dec = Convert.ToDouble("45.67");
string str = Convert.ToString(42);

// ToString method
int value = 42;
string text = value.ToString();
double price = 19.99;
string formatted = price.ToString("C2");  // "$19.99"
```

---

## Operators & Expressions

### Arithmetic Operators

```csharp
int a = 10;
int b = 3;

// Basic operations
int sum = a + b;        // 13
int difference = a - b; // 7
int product = a * b;    // 30
int quotient = a / b;   // 3 (integer division)
int remainder = a % b;  // 1 (modulus)

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

// Math class methods
double power = Math.Pow(2, 3);      // 8
double squareRoot = Math.Sqrt(16);  // 4
double absValue = Math.Abs(-5);     // 5
```

### Comparison Operators

```csharp
int x = 10;
int y = 5;

bool isEqual = (x == y);     // false
bool notEqual = (x != y);    // true
bool greater = (x > y);      // true
bool greaterEq = (x >= y);   // true
bool less = (x < y);         // false
bool lessEq = (x <= y);      // false

// CRITICAL: Don't confuse = with ==
int a = 5;     // Assignment
if (a == 5)    // Comparison
{
    // code
}
```

### Logical Operators

```csharp
// AND (&&) - both must be true
if (age >= 18 && hasLicense)
{
    MessageBox.Show("Can drive");
}

// OR (||) - at least one must be true
if (day == "Saturday" || day == "Sunday")
{
    MessageBox.Show("Weekend!");
}

// NOT (!) - reverses boolean
bool isVisible = false;
if (!isVisible)
{
    pnl_Display.Visible = true;
}

// Complex conditions
if ((score >= 60 && score <= 100) && !isExcused)
{
    lbl_Status.Text = "Passing";
}
```

### String Concatenation

```csharp
// Using + operator
string firstName = "John";
string lastName = "Smith";
string fullName = firstName + " " + lastName;  // "John Smith"

// Using += operator
string message = "Hello";
message += " ";
message += "World";  // "Hello World"

// String interpolation (C# 6.0+) - RECOMMENDED
string name = "Alice";
int age = 25;
string output = $"{name} is {age} years old";
// "Alice is 25 years old"

// String.Format
string formatted = string.Format("{0} costs ${1:F2}", item, price);

// Concatenating with controls
lbl_Result.Text = "Total: " + total.ToString();
lbl_Result.Text = $"Total: {total}";  // Using interpolation
```

---

## Control Structures

### If Statements

```csharp
// Simple if
if (score >= 60)
{
    lbl_Status.Text = "Passing";
}

// If-else
if (temperature > 75)
{
    lbl_Weather.Text = "Hot";
}
else
{
    lbl_Weather.Text = "Not hot";
}

// If-else if-else
if (grade >= 90)
{
    lbl_Letter.Text = "A";
}
else if (grade >= 80)
{
    lbl_Letter.Text = "B";
}
else if (grade >= 70)
{
    lbl_Letter.Text = "C";
}
else if (grade >= 60)
{
    lbl_Letter.Text = "D";
}
else
{
    lbl_Letter.Text = "F";
}

// Nested if
if (age >= 16)
{
    if (hasPermit)
    {
        MessageBox.Show("Can drive with supervision");
    }
    else
    {
        MessageBox.Show("Need permit");
    }
}
else
{
    MessageBox.Show("Too young");
}
```

### Switch Statements

```csharp
int choice = 1;

switch (choice)
{
    case 1:
        lbl_Result.Text = "Option 1";
        break;
    case 2:
        lbl_Result.Text = "Option 2";
        break;
    case 3:
        lbl_Result.Text = "Option 3";
        break;
    default:
        lbl_Result.Text = "Invalid option";
        break;
}

// Multiple cases with same result
char grade = 'A';

switch (grade)
{
    case 'A':
    case 'a':
        lbl_Status.Text = "Excellent!";
        break;
    case 'B':
    case 'b':
        lbl_Status.Text = "Good!";
        break;
    case 'F':
    case 'f':
        lbl_Status.Text = "Failing";
        break;
    default:
        lbl_Status.Text = "Invalid grade";
        break;
}

// Switching on strings
string operation = txt_Operation.Text;

switch (operation)
{
    case "add":
        result = a + b;
        break;
    case "subtract":
        result = a - b;
        break;
    case "multiply":
        result = a * b;
        break;
    case "divide":
        if (b != 0)
            result = a / b;
        break;
    default:
        MessageBox.Show("Unknown operation");
        break;
}
```

### For Loops

```csharp
// Standard for loop
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

// Loop with different increment
for (int i = 0; i <= 100; i += 10)
{
    lst_Numbers.Items.Add(i);
}

// Countdown
for (int i = 10; i >= 1; i--)
{
    lbl_Countdown.Text = i.ToString();
}

// Loop through collection
List<string> books = new List<string> { "Book1", "Book2", "Book3" };
for (int i = 0; i < books.Count; i++)
{
    lst_Display.Items.Add(books[i]);
}

// Nested loops
for (int row = 0; row < 5; row++)
{
    for (int col = 0; col < 5; col++)
    {
        Console.Write("* ");
    }
    Console.WriteLine();
}
```

### Foreach Loops (COMMON IN C#)

```csharp
// Loop through List
List<string> recipes = new List<string> { "Pasta", "Pizza", "Salad" };

foreach (string recipe in recipes)
{
    lst_Display.Items.Add(recipe);
}

// Loop through array
int[] scores = { 85, 92, 78, 90 };

foreach (int score in scores)
{
    Console.WriteLine(score);
}

// Loop through ListBox items
foreach (object item in lst_Books.Items)
{
    string bookTitle = item.ToString();
    // Process each book
}

// Calculate sum using foreach
int sum = 0;
foreach (int number in scores)
{
    sum += number;
}
```

### While Loops

```csharp
// Basic while loop
int count = 0;
while (count < 5)
{
    lbl_Count.Text = count.ToString();
    count++;
}

// Input validation with while
double value;
while (!double.TryParse(txt_Input.Text, out value))
{
    MessageBox.Show("Please enter a valid number");
    return;
}

// Condition-based loop
bool isDone = false;
int index = 0;

while (!isDone && index < items.Count)
{
    // Process items
    index++;
    isDone = CheckCondition();
}
```

### Do-While Loops

```csharp
// Executes at least once
int counter = 0;

do
{
    lbl_Display.Text = counter.ToString();
    counter++;
} while (counter < 10);

// Menu pattern (rare in Windows Forms)
// Usually handled by buttons instead
```

---

## Methods

### Method Basics

```csharp
// Method structure:
// accessModifier returnType MethodName(parameters)
// {
//     // method body
//     return value;  // if not void
// }

// Void method (no return value)
private void DisplayMessage()
{
    MessageBox.Show("Hello, World!");
}

// Method with return value
private int Add(int a, int b)
{
    int sum = a + b;
    return sum;
}

// Method with multiple parameters
private double CalculateAverage(int score1, int score2, int score3)
{
    double sum = score1 + score2 + score3;
    return sum / 3.0;
}

// Method with default parameters
private void ShowMessage(string text = "Hello", string title = "Message")
{
    MessageBox.Show(text, title);
}

// Calling methods
private void btn_Test_Click(object sender, EventArgs e)
{
    DisplayMessage();                    // Void method
    
    int result = Add(5, 3);              // Method with return
    lbl_Result.Text = result.ToString();
    
    double avg = CalculateAverage(85, 92, 78);
    lbl_Average.Text = avg.ToString("F2");
    
    ShowMessage();                       // Uses defaults
    ShowMessage("Goodbye", "Farewell");  // Custom values
}
```

### Common Method Patterns

```csharp
// Clear all inputs
private void ClearInputs()
{
    txt_Title.Clear();
    txt_Author.Clear();
    txt_Year.Text = "";
}

// Validate inputs
private bool ValidateInputs()
{
    if (string.IsNullOrWhiteSpace(txt_Title.Text))
    {
        MessageBox.Show("Please enter a title");
        return false;
    }
    
    int year;
    if (!int.TryParse(txt_Year.Text, out year))
    {
        MessageBox.Show("Please enter a valid year");
        return false;
    }
    
    return true;
}

// Update display
private void UpdateDisplay()
{
    lbl_Count.Text = $"Total: {items.Count}";
    lbl_Status.Text = items.Count > 0 ? "Items available" : "No items";
}

// Calculate total
private double CalculateTotal(List<double> prices)
{
    double total = 0;
    foreach (double price in prices)
    {
        total += price;
    }
    return total;
}
```

### Out Parameters

```csharp
// TryParse is a common example of out parameters
string input = txt_Number.Text;
int result;

if (int.TryParse(input, out result))
{
    // result contains the parsed value
    lbl_Display.Text = result.ToString();
}
else
{
    // Parsing failed
    MessageBox.Show("Invalid number");
}

// Custom method with out parameter
private bool TryDivide(double a, double b, out double result)
{
    if (b == 0)
    {
        result = 0;
        return false;
    }
    
    result = a / b;
    return true;
}

// Usage
double quotient;
if (TryDivide(10, 2, out quotient))
{
    lbl_Result.Text = quotient.ToString();
}
else
{
    MessageBox.Show("Cannot divide by zero");
}
```

---

## Event Handlers

### Button Click Events

```csharp
// Single button event
private void btn_Add_Click(object sender, EventArgs e)
{
    string item = txt_Item.Text;
    
    if (!string.IsNullOrWhiteSpace(item))
    {
        lst_Items.Items.Add(item);
        txt_Item.Clear();
    }
}

// Multiple buttons sharing one event handler
private void btn_Number_Click(object sender, EventArgs e)
{
    Button clickedButton = (Button)sender;
    txt_Display.Text += clickedButton.Text;
}

// In the designer, assign this event to all number buttons:
// btn_0.Click += btn_Number_Click;
// btn_1.Click += btn_Number_Click;
// btn_2.Click += btn_Number_Click;
// etc.
```

### Common Event Handler Patterns

```csharp
// Toggle visibility
private void btn_Toggle_Click(object sender, EventArgs e)
{
    if (pnl_Details.Visible)
    {
        pnl_Details.Visible = false;
        btn_Toggle.Text = "Show Details";
    }
    else
    {
        pnl_Details.Visible = true;
        btn_Toggle.Text = "Hide Details";
    }
}

// Counter increment/decrement
private int counter = 0;

private void btn_Increment_Click(object sender, EventArgs e)
{
    counter++;
    UpdateCounterDisplay();
}

private void btn_Decrement_Click(object sender, EventArgs e)
{
    counter--;
    UpdateCounterDisplay();
}

private void UpdateCounterDisplay()
{
    lbl_Counter.Text = counter.ToString();
    
    // Change color based on value
    if (counter < 0)
    {
        lbl_Counter.ForeColor = Color.Red;
    }
    else if (counter > 0)
    {
        lbl_Counter.ForeColor = Color.Green;
    }
    else
    {
        lbl_Counter.ForeColor = Color.Blue;
    }
}

// Clear all
private void btn_Clear_Click(object sender, EventArgs e)
{
    txt_Title.Clear();
    txt_Author.Clear();
    lst_Books.Items.Clear();
    lbl_Status.Text = "All cleared";
}

// Remove selected item
private void btn_Remove_Click(object sender, EventArgs e)
{
    if (lst_Books.SelectedIndex >= 0)
    {
        lst_Books.Items.RemoveAt(lst_Books.SelectedIndex);
    }
    else
    {
        MessageBox.Show("Please select an item to remove");
    }
}
```

### Radio Button Events

```csharp
// Check which radio button is selected
private void btn_Calculate_Click(object sender, EventArgs e)
{
    double value = double.Parse(txt_Value.Text);
    double result;
    
    if (rdb_Celsius.Checked)
    {
        result = (value * 9/5) + 32;  // Convert to Fahrenheit
        lbl_Result.Text = $"{result:F2} °F";
    }
    else if (rdb_Fahrenheit.Checked)
    {
        result = (value - 32) * 5/9;  // Convert to Celsius
        lbl_Result.Text = $"{result:F2} °C";
    }
}

// Radio button changed event
private void rdb_Option_CheckedChanged(object sender, EventArgs e)
{
    RadioButton rb = (RadioButton)sender;
    
    if (rb.Checked)
    {
        lbl_Selected.Text = $"Selected: {rb.Text}";
    }
}
```

### TextBox Events

```csharp
// Text changed event
private void txt_Search_TextChanged(object sender, EventArgs e)
{
    string searchTerm = txt_Search.Text.ToLower();
    lst_Results.Items.Clear();
    
    foreach (string item in allItems)
    {
        if (item.ToLower().Contains(searchTerm))
        {
            lst_Results.Items.Add(item);
        }
    }
}

// Key press event (restrict input)
private void txt_Number_KeyPress(object sender, KeyPressEventArgs e)
{
    // Only allow digits and backspace
    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
    {
        e.Handled = true;  // Cancel the key press
    }
}
```

---

## String Manipulation

### String Methods

```csharp
string text = "Hello World";

// Length
int length = text.Length;  // 11

// Convert case
string upper = text.ToUpper();      // "HELLO WORLD"
string lower = text.ToLower();      // "hello world"

// Substring
string sub = text.Substring(0, 5);  // "Hello"
string sub2 = text.Substring(6);    // "World"

// Replace
string replaced = text.Replace("World", "C#");  // "Hello C#"
string noSpaces = text.Replace(" ", "");        // "HelloWorld"

// Trim (remove whitespace)
string padded = "  Hello  ";
string trimmed = padded.Trim();        // "Hello"
string trimStart = padded.TrimStart(); // "Hello  "
string trimEnd = padded.TrimEnd();     // "  Hello"

// Contains
bool hasWorld = text.Contains("World");  // true

// StartsWith / EndsWith
bool startsWithHello = text.StartsWith("Hello");  // true
bool endsWithWorld = text.EndsWith("World");      // true

// IndexOf (find position)
int index = text.IndexOf("World");     // 6
int notFound = text.IndexOf("xyz");    // -1

// Split
string csv = "apple,banana,cherry";
string[] fruits = csv.Split(',');  // ["apple", "banana", "cherry"]

// Join
string[] words = { "Hello", "World" };
string joined = string.Join(" ", words);  // "Hello World"
```

### String Manipulation Patterns

```csharp
// Reverse a string
private string ReverseString(string input)
{
    char[] chars = input.ToCharArray();
    Array.Reverse(chars);
    return new string(chars);
}

// Usage
string original = "Hello";
string reversed = ReverseString(original);  // "olleH"

// Remove vowels
private string RemoveVowels(string input)
{
    string vowels = "aeiouAEIOU";
    string result = "";
    
    foreach (char c in input)
    {
        if (!vowels.Contains(c))
        {
            result += c;
        }
    }
    
    return result;
}

// Usage
string text = "Hello World";
string noVowels = RemoveVowels(text);  // "Hll Wrld"

// Count specific characters
private int CountCharacter(string input, char target)
{
    int count = 0;
    
    foreach (char c in input)
    {
        if (c == target)
        {
            count++;
        }
    }
    
    return count;
}

// Alternative using LINQ
private int CountCharacterLinq(string input, char target)
{
    return input.Count(c => c == target);
}

// Remove all spaces
private string RemoveSpaces(string input)
{
    return input.Replace(" ", "");
}

// Count words
private int CountWords(string input)
{
    if (string.IsNullOrWhiteSpace(input))
        return 0;
    
    string[] words = input.Split(new char[] { ' ', '\t', '\n' }, 
                                  StringSplitOptions.RemoveEmptyEntries);
    return words.Length;
}

// Check if palindrome
private bool IsPalindrome(string input)
{
    string cleaned = input.ToLower().Replace(" ", "");
    string reversed = ReverseString(cleaned);
    return cleaned == reversed;
}
```

### Character Operations

```csharp
char c = 'A';

// Check character type
bool isLetter = char.IsLetter(c);      // true
bool isDigit = char.IsDigit(c);        // false
bool isUpper = char.IsUpper(c);        // true
bool isLower = char.IsLower(c);        // false
bool isWhiteSpace = char.IsWhiteSpace(' ');  // true

// Convert case
char lower = char.ToLower(c);          // 'a'
char upper = char.ToUpper('b');        // 'B'

// Loop through string characters
string text = "Hello123";
int letterCount = 0;
int digitCount = 0;

foreach (char ch in text)
{
    if (char.IsLetter(ch))
    {
        letterCount++;
    }
    else if (char.IsDigit(ch))
    {
        digitCount++;
    }
}
```

---

## Collections (List<T>)

### List Basics

```csharp
// Create empty list
List<string> books = new List<string>();
List<int> numbers = new List<int>();

// Create with initial values
List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };
List<int> scores = new List<int> { 85, 92, 78, 90 };

// Create with capacity
List<string> items = new List<string>(100);  // Pre-allocate space
```

### List Methods

```csharp
List<string> recipes = new List<string>();

// Add single item
recipes.Add("Pasta");
recipes.Add("Pizza");
recipes.Add("Salad");

// Add multiple items
recipes.AddRange(new string[] { "Soup", "Steak" });

// Insert at position
recipes.Insert(0, "Appetizer");  // Insert at beginning

// Remove item
recipes.Remove("Pizza");  // Remove by value
recipes.RemoveAt(0);      // Remove by index

// Clear all items
recipes.Clear();

// Check if contains
bool hasPasta = recipes.Contains("Pasta");

// Find index
int index = recipes.IndexOf("Pizza");  // -1 if not found

// Count
int count = recipes.Count;

// Check if empty
bool isEmpty = recipes.Count == 0;

// Sort
recipes.Sort();  // Alphabetical for strings

// Reverse
recipes.Reverse();
```

### Looping Through Lists

```csharp
List<string> books = new List<string> { "Book1", "Book2", "Book3" };

// For loop
for (int i = 0; i < books.Count; i++)
{
    Console.WriteLine(books[i]);
}

// Foreach loop (preferred)
foreach (string book in books)
{
    Console.WriteLine(book);
}

// LINQ (advanced)
var filteredBooks = books.Where(b => b.StartsWith("B")).ToList();
```

### List with ListBox

```csharp
// Populate ListBox from List
List<string> tasks = new List<string> { "Task 1", "Task 2", "Task 3" };

lst_Display.Items.Clear();
foreach (string task in tasks)
{
    lst_Display.Items.Add(task);
}

// Alternative: AddRange
lst_Display.Items.Clear();
lst_Display.Items.AddRange(tasks.ToArray());

// Toggle pattern (common in competitions)
List<string> vocabulary = new List<string> 
{ 
    "Algorithm", 
    "Binary", 
    "Compiler", 
    "Database" 
};

private void btn_Toggle_Click(object sender, EventArgs e)
{
    if (lst_Vocab.Items.Count == 0)
    {
        // Populate
        foreach (string word in vocabulary)
        {
            lst_Vocab.Items.Add(word);
        }
    }
    else
    {
        // Clear
        lst_Vocab.Items.Clear();
    }
}
```

---

## Input Validation

### TryParse Pattern (CRITICAL!)

```csharp
// Validate integer input
private void btn_Calculate_Click(object sender, EventArgs e)
{
    int age;
    
    if (int.TryParse(txt_Age.Text, out age))
    {
        // Valid input
        lbl_Result.Text = $"Age: {age}";
    }
    else
    {
        // Invalid input
        MessageBox.Show("Please enter a valid age", "Invalid Input");
    }
}

// Validate double input
double price;

if (double.TryParse(txt_Price.Text, out price))
{
    // Valid
    lbl_Total.Text = $"Price: ${price:F2}";
}
else
{
    MessageBox.Show("Please enter a valid price");
}

// Validate with range check
int quantity;

if (int.TryParse(txt_Quantity.Text, out quantity))
{
    if (quantity >= 1 && quantity <= 100)
    {
        // Valid range
        ProcessOrder(quantity);
    }
    else
    {
        MessageBox.Show("Quantity must be between 1 and 100");
    }
}
else
{
    MessageBox.Show("Please enter a valid quantity");
}
```

### Complete Validation Pattern

```csharp
private void btn_Submit_Click(object sender, EventArgs e)
{
    // Validate all inputs before proceeding
    
    // Check for empty string
    if (string.IsNullOrWhiteSpace(txt_Title.Text))
    {
        MessageBox.Show("Please enter a title", "Validation Error");
        txt_Title.Focus();
        return;
    }
    
    // Validate numeric input
    int year;
    if (!int.TryParse(txt_Year.Text, out year))
    {
        MessageBox.Show("Please enter a valid year", "Validation Error");
        txt_Year.Focus();
        return;
    }
    
    // Range validation
    if (year < 1900 || year > 2100)
    {
        MessageBox.Show("Year must be between 1900 and 2100", "Validation Error");
        txt_Year.Focus();
        return;
    }
    
    // Validate decimal input
    double price;
    if (!double.TryParse(txt_Price.Text, out price))
    {
        MessageBox.Show("Please enter a valid price", "Validation Error");
        txt_Price.Focus();
        return;
    }
    
    // Positive number validation
    if (price < 0)
    {
        MessageBox.Show("Price cannot be negative", "Validation Error");
        txt_Price.Focus();
        return;
    }
    
    // All validations passed
    ProcessData(txt_Title.Text, year, price);
}
```

### Validation Helper Methods

```csharp
// Check if textbox has value
private bool IsTextBoxEmpty(TextBox textBox)
{
    return string.IsNullOrWhiteSpace(textBox.Text);
}

// Validate positive integer
private bool TryGetPositiveInt(string input, out int result)
{
    if (int.TryParse(input, out result))
    {
        return result > 0;
    }
    return false;
}

// Validate range
private bool IsInRange(int value, int min, int max)
{
    return value >= min && value <= max;
}

// Usage
int age;
if (TryGetPositiveInt(txt_Age.Text, out age))
{
    if (IsInRange(age, 1, 120))
    {
        lbl_Result.Text = $"Age: {age}";
    }
    else
    {
        MessageBox.Show("Age must be between 1 and 120");
    }
}
else
{
    MessageBox.Show("Please enter a valid positive number");
}
```

---

## Output Formatting

### String Formatting

```csharp
double price = 19.99;
int quantity = 5;

// String concatenation
string output = "Price: $" + price.ToString();

// String.Format
string formatted = string.Format("Price: ${0:F2}, Quantity: {1}", price, quantity);
// "Price: $19.99, Quantity: 5"

// String interpolation (C# 6.0+) - RECOMMENDED
string interpolated = $"Price: ${price:F2}, Quantity: {quantity}";
// "Price: $19.99, Quantity: 5"
```

### Number Formatting

```csharp
double value = 1234.56789;

// Currency
string currency = value.ToString("C");     // "$1,234.57" (depends on culture)
string currency2 = value.ToString("C2");   // "$1,234.57" (2 decimal places)

// Fixed-point
string fixed0 = value.ToString("F0");      // "1235" (no decimals)
string fixed2 = value.ToString("F2");      // "1234.57" (2 decimals)
string fixed4 = value.ToString("F4");      // "1234.5679" (4 decimals)

// Number with thousands separator
string number = value.ToString("N2");      // "1,234.57"

// Percentage
double percent = 0.857;
string percentage = percent.ToString("P0");  // "86%" (no decimals)
string percentage2 = percent.ToString("P2"); // "85.70%" (2 decimals)

// Custom format
string custom = value.ToString("0,0.00");  // "1,234.57"

// Using string interpolation
lbl_Price.Text = $"${value:C2}";          // "$1,234.57"
lbl_Decimal.Text = $"{value:F2}";         // "1234.57"
lbl_Percent.Text = $"{percent:P1}";       // "85.7%"
```

### Formatting in Controls

```csharp
// Display formatted currency
double total = 1234.56;
lbl_Total.Text = $"Total: {total:C2}";  // "Total: $1,234.56"

// Display percentage
double rate = 0.075;
lbl_Rate.Text = $"Rate: {rate:P2}";  // "Rate: 7.50%"

// Display with specific decimals
double average = 87.666666;
lbl_Average.Text = $"Average: {average:F2}";  // "Average: 87.67"

// Format in MessageBox
MessageBox.Show($"Your total is {total:C2}", "Total");
```

### Date Formatting

```csharp
DateTime now = DateTime.Now;

// Common formats
string shortDate = now.ToString("d");      // "1/15/2026"
string longDate = now.ToString("D");       // "Wednesday, January 15, 2026"
string shortTime = now.ToString("t");      // "2:30 PM"
string longTime = now.ToString("T");       // "2:30:45 PM"
string fullDate = now.ToString("F");       // "Wednesday, January 15, 2026 2:30:45 PM"

// Custom formats
string custom = now.ToString("MM/dd/yyyy");           // "01/15/2026"
string custom2 = now.ToString("MMMM dd, yyyy");       // "January 15, 2026"
string custom3 = now.ToString("yyyy-MM-dd HH:mm:ss"); // "2026-01-15 14:30:45"
```

---

## Math Operations

### Math Class Methods

```csharp
// Power and roots
double squared = Math.Pow(5, 2);      // 25
double cubed = Math.Pow(2, 3);        // 8
double squareRoot = Math.Sqrt(16);    // 4

// Absolute value
int absInt = Math.Abs(-5);            // 5
double absDouble = Math.Abs(-3.14);   // 3.14

// Rounding
double rounded = Math.Round(3.7);     // 4
double roundedTo2 = Math.Round(3.14159, 2);  // 3.14

// Ceiling and Floor
double ceilingVal = Math.Ceiling(3.2); // 4
double floorVal = Math.Floor(3.8);     // 3

// Min and Max
int minimum = Math.Min(5, 10);        // 5
int maximum = Math.Max(5, 10);        // 10

// Trigonometry (radians)
double sine = Math.Sin(Math.PI / 2);  // 1
double cosine = Math.Cos(0);          // 1

// Constants
double pi = Math.PI;                  // 3.14159...
double e = Math.E;                    // 2.71828...
```

### Common Calculations

```csharp
// Calculate average
private double CalculateAverage(List<int> numbers)
{
    if (numbers.Count == 0)
        return 0;
    
    double sum = 0;
    foreach (int num in numbers)
    {
        sum += num;
    }
    
    return sum / numbers.Count;
}

// Calculate sum
private int CalculateSum(List<int> numbers)
{
    int sum = 0;
    foreach (int num in numbers)
    {
        sum += num;
    }
    return sum;
}

// Alternative using LINQ
private double CalculateAverageLinq(List<int> numbers)
{
    return numbers.Average();
}

private int CalculateSumLinq(List<int> numbers)
{
    return numbers.Sum();
}

// Find maximum
private int FindMax(List<int> numbers)
{
    if (numbers.Count == 0)
        return 0;
    
    int max = numbers[0];
    foreach (int num in numbers)
    {
        if (num > max)
        {
            max = num;
        }
    }
    return max;
}

// Find minimum
private int FindMin(List<int> numbers)
{
    if (numbers.Count == 0)
        return 0;
    
    int min = numbers[0];
    foreach (int num in numbers)
    {
        if (num < min)
        {
            min = num;
        }
    }
    return min;
}

// Using Math methods
private int FindMaxMath(List<int> numbers)
{
    return numbers.Max();  // LINQ
}

// Count even numbers
private int CountEven(int limit)
{
    int count = 0;
    for (int i = 2; i <= limit; i += 2)
    {
        count++;
    }
    return count;
}

// Sum of even numbers
private int SumEven(int limit)
{
    int sum = 0;
    for (int i = 2; i <= limit; i += 2)
    {
        sum += i;
    }
    return sum;
}
```

### Financial Formulas

```csharp
// Simple interest
private double CalculateSimpleInterest(double principal, double rate, int years)
{
    return principal * rate * years;
}

// Compound interest
// A = P(1 + r/n)^(nt)
private double CalculateCompoundInterest(double principal, double annualRate, 
                                          int timesCompounded, int years)
{
    double rate = annualRate / 100.0;  // Convert percentage to decimal
    double amount = principal * Math.Pow(1 + (rate / timesCompounded), 
                                          timesCompounded * years);
    return amount;
}

// Monthly payment
// M = P * [r(1+r)^n] / [(1+r)^n - 1]
private double CalculateMonthlyPayment(double principal, double annualRate, int years)
{
    double monthlyRate = annualRate / 100.0 / 12.0;
    int totalPayments = years * 12;
    
    if (monthlyRate == 0)
        return principal / totalPayments;
    
    double payment = principal * 
                     (monthlyRate * Math.Pow(1 + monthlyRate, totalPayments)) / 
                     (Math.Pow(1 + monthlyRate, totalPayments) - 1);
    
    return payment;
}

// Usage
private void btn_Calculate_Click(object sender, EventArgs e)
{
    double principal = double.Parse(txt_Principal.Text);
    double rate = double.Parse(txt_Rate.Text);
    int years = int.Parse(txt_Years.Text);
    
    double payment = CalculateMonthlyPayment(principal, rate, years);
    
    lst_Result.Items.Clear();
    lst_Result.Items.Add($"Monthly Payment: {payment:C2}");
}
```

---

## Control Properties & Methods

### Button Control

```csharp
// Text
btn_Submit.Text = "Click Me";

// Enabled/Disabled
btn_Submit.Enabled = false;
btn_Submit.Enabled = true;

// Visible/Hidden
btn_Submit.Visible = false;
btn_Submit.Visible = true;

// Size
btn_Submit.Width = 100;
btn_Submit.Height = 30;
btn_Submit.Size = new Size(100, 30);

// Location
btn_Submit.Location = new Point(10, 20);

// Colors
btn_Submit.BackColor = Color.Blue;
btn_Submit.ForeColor = Color.White;

// Font
btn_Submit.Font = new Font("Arial", 12, FontStyle.Bold);
```

### TextBox Control

```csharp
// Get/Set text
string text = txt_Input.Text;
txt_Input.Text = "New value";

// Clear
txt_Input.Clear();

// Read only
txt_Input.ReadOnly = true;

// Multiline
txt_Input.Multiline = true;
txt_Input.ScrollBars = ScrollBars.Vertical;

// Password
txt_Password.PasswordChar = '*';

// Max length
txt_Username.MaxLength = 20;

// Text alignment
txt_Title.TextAlign = HorizontalAlignment.Center;

// Focus
txt_Input.Focus();

// Select all text
txt_Input.SelectAll();

// Append text
txt_Log.AppendText("New line" + Environment.NewLine);
```

### Label Control

```csharp
// Text
lbl_Status.Text = "Ready";

// Colors
lbl_Status.ForeColor = Color.Red;
lbl_Status.BackColor = Color.LightGray;

// Font
lbl_Title.Font = new Font("Arial", 16, FontStyle.Bold);

// AutoSize
lbl_Status.AutoSize = true;

// Text alignment
lbl_Title.TextAlign = ContentAlignment.MiddleCenter;

// Border
lbl_Status.BorderStyle = BorderStyle.FixedSingle;
```

### ListBox Control

```csharp
// Add single item
lst_Books.Items.Add("Book Title");

// Add multiple items
lst_Books.Items.AddRange(new string[] { "Item1", "Item2" });

// Remove item
lst_Books.Items.Remove("Book Title");     // By value
lst_Books.Items.RemoveAt(0);              // By index

// Clear all
lst_Books.Items.Clear();

// Get selected item
if (lst_Books.SelectedIndex >= 0)
{
    string selected = lst_Books.SelectedItem.ToString();
}

// Get selected index
int index = lst_Books.SelectedIndex;  // -1 if nothing selected

// Count items
int count = lst_Books.Items.Count;

// Loop through items
foreach (object item in lst_Books.Items)
{
    string text = item.ToString();
    // Process item
}

// Check if item exists
bool exists = lst_Books.Items.Contains("Book Title");

// Sort items
lst_Books.Sorted = true;

// Selection mode
lst_Books.SelectionMode = SelectionMode.One;
lst_Books.SelectionMode = SelectionMode.MultiSimple;
```

### Panel Control

```csharp
// Visibility
pnl_Details.Visible = true;
pnl_Details.Visible = false;

// Background color
pnl_Details.BackColor = Color.LightBlue;

// Border
pnl_Details.BorderStyle = BorderStyle.FixedSingle;

// AutoScroll
pnl_Container.AutoScroll = true;
```

### RadioButton Control

```csharp
// Check which is selected
if (rdb_Option1.Checked)
{
    // Option 1 is selected
}
else if (rdb_Option2.Checked)
{
    // Option 2 is selected
}

// Set selection
rdb_Option1.Checked = true;

// Get value from selected radio button
string selectedOption = "";
if (rdb_Small.Checked)
    selectedOption = "Small";
else if (rdb_Medium.Checked)
    selectedOption = "Medium";
else if (rdb_Large.Checked)
    selectedOption = "Large";
```

### TabControl

```csharp
// Switch to specific tab
tabControl1.SelectedIndex = 0;  // First tab
tabControl1.SelectedTab = tabPage2;

// Get current tab
TabPage currentTab = tabControl1.SelectedTab;

// Tab properties
tabPage1.Text = "Home";
tabPage1.BackColor = Color.White;

// Enable/disable tab
tabPage2.Enabled = false;
```

---

## MessageBox & Dialogs

### MessageBox Basics

```csharp
// Simple message
MessageBox.Show("Hello, World!");

// Message with title
MessageBox.Show("Operation completed successfully", "Success");

// Message with title and icon
MessageBox.Show("File saved successfully", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

// Common icons:
// MessageBoxIcon.Information
// MessageBoxIcon.Warning
// MessageBoxIcon.Error
// MessageBoxIcon.Question
```

### MessageBox with Buttons

```csharp
// Yes/No dialog
DialogResult result = MessageBox.Show("Do you want to save changes?", 
                                      "Confirm", 
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

if (result == DialogResult.Yes)
{
    // User clicked Yes
    SaveData();
}
else
{
    // User clicked No
    DiscardChanges();
}

// Yes/No/Cancel
DialogResult result = MessageBox.Show("Save changes before closing?",
                                      "Confirm",
                                      MessageBoxButtons.YesNoCancel,
                                      MessageBoxIcon.Warning);

if (result == DialogResult.Yes)
{
    SaveData();
    Close();
}
else if (result == DialogResult.No)
{
    Close();
}
// If Cancel, do nothing

// OK/Cancel
DialogResult result = MessageBox.Show("Are you sure?",
                                      "Confirm",
                                      MessageBoxButtons.OKCancel,
                                      MessageBoxIcon.Warning);

if (result == DialogResult.OK)
{
    DeleteItem();
}
```

### Error Messages

```csharp
// Show error
MessageBox.Show("Invalid input. Please enter a number.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

// Show warning
MessageBox.Show("This action cannot be undone.",
                "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

// Show information
MessageBox.Show("Data saved successfully.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
```

---

## Random Generation

### Random Class Basics

```csharp
// Create Random object (do once, typically as class-level variable)
private Random random = new Random();

// Generate random integer
int randomInt = random.Next();  // Any int

// Random integer in range [min, max)
int dice = random.Next(1, 7);   // 1-6 (7 is exclusive)
int percent = random.Next(0, 101);  // 0-100

// Random double [0.0, 1.0)
double randomDouble = random.NextDouble();

// Random double in range
double min = 10.0;
double max = 50.0;
double randomRange = min + (max - min) * random.NextDouble();
```

### Random Font Generation

```csharp
private void btn_RandomFont_Click(object sender, EventArgs e)
{
    //SC1: Generate random font properties
    
    // Random font size between 8 and 20
    int fontSize = random.Next(8, 21);
    
    // Random font style
    FontStyle[] styles = { FontStyle.Regular, FontStyle.Bold, 
                           FontStyle.Italic, FontStyle.Underline, 
                           FontStyle.Strikeout };
    FontStyle randomStyle = styles[random.Next(styles.Length)];
    
    // Random color (RGB values 0-255)
    int r = random.Next(0, 256);
    int g = random.Next(0, 256);
    int b = random.Next(0, 256);
    Color randomColor = Color.FromArgb(r, g, b);
    
    // Apply to label
    lbl_Display.Font = new Font("Arial", fontSize, randomStyle);
    lbl_Display.ForeColor = randomColor;
}
```

### Random Selection

```csharp
// Select random item from list
List<string> colors = new List<string> { "Red", "Blue", "Green", "Yellow" };
string randomColor = colors[random.Next(colors.Count)];

// Select random item from array
string[] fruits = { "Apple", "Banana", "Cherry", "Date" };
string randomFruit = fruits[random.Next(fruits.Length)];

// Generate random list items
private void GenerateRandomRecipes()
{
    string[] recipes = { "Pasta", "Pizza", "Salad", "Soup", "Steak" };
    lst_Display.Items.Clear();
    
    int count = random.Next(3, 6);  // Generate 3-5 items
    
    for (int i = 0; i < count; i++)
    {
        string randomRecipe = recipes[random.Next(recipes.Length)];
        lst_Display.Items.Add(randomRecipe);
    }
}
```

### Random Colors

```csharp
// Generate random color
private Color GenerateRandomColor()
{
    int r = random.Next(0, 256);
    int g = random.Next(0, 256);
    int b = random.Next(0, 256);
    return Color.FromArgb(r, g, b);
}

// Apply random colors to controls
private void btn_Randomize_Click(object sender, EventArgs e)
{
    lbl_Display.BackColor = GenerateRandomColor();
    lbl_Display.ForeColor = GenerateRandomColor();
}

// Predefined colors
private Color GetRandomPredefinedColor()
{
    Color[] colors = { Color.Red, Color.Blue, Color.Green, 
                      Color.Yellow, Color.Purple, Color.Orange };
    return colors[random.Next(colors.Length)];
}
```

---

## Common Patterns

### Toggle Visibility Pattern

```csharp
private void btn_Toggle_Click(object sender, EventArgs e)
{
    if (pnl_Details.Visible)
    {
        pnl_Details.Visible = false;
        btn_Toggle.Text = "Show Details";
    }
    else
    {
        pnl_Details.Visible = true;
        btn_Toggle.Text = "Hide Details";
    }
}
```

### Counter Pattern

```csharp
private int counter = 0;

private void btn_Add_Click(object sender, EventArgs e)
{
    counter++;
    UpdateCounterDisplay();
}

private void btn_Subtract_Click(object sender, EventArgs e)
{
    counter--;
    UpdateCounterDisplay();
}

private void UpdateCounterDisplay()
{
    lbl_Counter.Text = counter.ToString();
    
    // Change color based on value
    if (counter < 0)
    {
        lbl_Counter.ForeColor = Color.Red;
    }
    else if (counter > 0)
    {
        lbl_Counter.ForeColor = Color.Blue;
    }
    else
    {
        lbl_Counter.ForeColor = Color.Black;
    }
}
```

### List Toggle Pattern (VERY COMMON)

```csharp
private List<string> vocabulary = new List<string>
{
    "Algorithm", "Binary", "Compiler", "Database", "Encryption"
};

private void btn_ToggleVocab_Click(object sender, EventArgs e)
{
    //SC1: Toggle list display
    if (lst_Display.Items.Count == 0)
    {
        // Populate list
        foreach (string word in vocabulary)
        {
            lst_Display.Items.Add(word);
        }
    }
    else
    {
        // Clear list
        lst_Display.Items.Clear();
    }
}
```

### Programmatic Button Testing

```csharp
// GRADER BUTTON PATTERN
private void btn_Grader_Click(object sender, EventArgs e)
{
    //SC12: Programmatically test multiple buttons
    
    // Set sample inputs
    txt_Title.Text = "Test Book";
    txt_Pages.Text = "300";
    
    // Simulate button clicks
    btn_Add_Click(sender, e);
    btn_Calculate_Click(sender, e);
    btn_Display_Click(sender, e);
    
    // Show completion message
    MessageBox.Show("All tests completed", "Grader Test");
}
```

### Calculation with Validation

```csharp
private void btn_Calculate_Click(object sender, EventArgs e)
{
    //SC2: Input validation and calculation
    
    // Validate inputs
    double value1, value2;
    
    if (!double.TryParse(txt_Value1.Text, out value1))
    {
        MessageBox.Show("Please enter valid first value", 
                       "Invalid Input");
        return;
    }
    
    if (!double.TryParse(txt_Value2.Text, out value2))
    {
        MessageBox.Show("Please enter valid second value", 
                       "Invalid Input");
        return;
    }
    
    // Perform calculation
    double result = value1 + value2;
    
    // Display result
    lbl_Result.Text = $"Result: {result:F2}";
}
```

### Loop Accumulation Pattern

```csharp
private void btn_SumOdds_Click(object sender, EventArgs e)
{
    //SC5: Loop to accumulate sum
    
    int limit;
    
    if (!int.TryParse(txt_Limit.Text, out limit) || limit < 1)
    {
        MessageBox.Show("Please enter a positive integer", 
                       "Invalid Input");
        return;
    }
    
    int sum = 0;
    
    for (int i = 1; i <= limit; i += 2)
    {
        sum += i;
    }
    
    MessageBox.Show($"Sum of odd numbers: {sum}", "Result");
}
```

---

## Debugging & Testing

### Common Compilation Errors

```csharp
// ❌ Missing semicolon
int x = 5

// ✅ CORRECT
int x = 5;

// ❌ Undeclared variable
lbl_Status.Text = total.ToString();  // total was never declared

// ✅ CORRECT
int total = 0;
lbl_Status.Text = total.ToString();

// ❌ Type mismatch
int age = "25";  // Can't assign string to int

// ✅ CORRECT
int age = 25;
string ageText = "25";

// ❌ Method not returning value
private int GetSum()
{
    int sum = 5 + 10;
    // Missing return!
}

// ✅ CORRECT
private int GetSum()
{
    int sum = 5 + 10;
    return sum;
}
```

### Common Runtime Errors

```csharp
// Null reference exception
TextBox txt = null;
txt.Text = "Hello";  // CRASH!

// Solution: Check for null
if (txt != null)
{
    txt.Text = "Hello";
}

// Format exception (parsing)
string text = "abc";
int number = int.Parse(text);  // CRASH!

// Solution: Use TryParse
int number;
if (int.TryParse(text, out number))
{
    // Use number
}

// Index out of range
List<string> items = new List<string> { "A", "B" };
string item = items[5];  // CRASH!

// Solution: Check bounds
if (index >= 0 && index < items.Count)
{
    string item = items[index];
}

// Division by zero
int result = 10 / 0;  // CRASH!

// Solution: Check divisor
int divisor = 0;
if (divisor != 0)
{
    int result = 10 / divisor;
}
```

### Debug Output

```csharp
// Output to Debug window (only in Debug mode)
System.Diagnostics.Debug.WriteLine("Debug message");
System.Diagnostics.Debug.WriteLine($"Value: {x}");

// Output to console (if console available)
Console.WriteLine("Console message");
Console.WriteLine($"Counter: {counter}");

// MessageBox for debugging (not recommended in final code)
MessageBox.Show($"Debug: x = {x}");

// Using breakpoints
// Set breakpoint in Visual Studio (F9)
// Run in Debug mode (F5)
// Step through code (F10, F11)
```

### Testing Strategies

```csharp
// Test boundary values
// For input 1-100:
// Test: 0, 1, 50, 100, 101

// Test empty input
if (string.IsNullOrWhiteSpace(txt_Input.Text))
{
    MessageBox.Show("Input cannot be empty");
    return;
}

// Test invalid format
int value;
if (!int.TryParse(txt_Input.Text, out value))
{
    MessageBox.Show("Invalid format");
    return;
}

// Test range
if (value < 1 || value > 100)
{
    MessageBox.Show("Value must be 1-100");
    return;
}

// Test with typical values
// Input: 50 → Expected output: 1275 (sum of evens 2-50)
```

---

## Complete Example Program

### Book Manager Application

```csharp
// Contestant ID: 01-2345-6789
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BookManager
{
    public partial class Form1 : Form
    {
        // Class-level variables
        private List<string> books = new List<string>();
        private int favoriteCount = 0;
        private Random random = new Random();
        
        public Form1()
        {
            InitializeComponent();
            InitializeData();
        }
        
        // Initialize sample data
        private void InitializeData()
        {
            books.Add("The Great Novel");
            books.Add("Programming Guide");
            books.Add("Mystery Story");
            books.Add("Science Fiction");
        }
        
        // Button: Display Books
        private void btn_Display_Click(object sender, EventArgs e)
        {
            //SC1: Populate ListBox from List
            lst_Books.Items.Clear();
            
            foreach (string book in books)
            {
                lst_Books.Items.Add(book);
            }
            
            UpdateStatus();
        }
        
        // Button: Add Book
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //SC2: Input validation and adding to list
            
            // Validate input
            if (string.IsNullOrWhiteSpace(txt_Title.Text))
            {
                MessageBox.Show("Please enter a book title", 
                              "Validation Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txt_Title.Focus();
                return;
            }
            
            // Add to list
            string title = txt_Title.Text.Trim();
            books.Add(title);
            
            // Update display
            lst_Books.Items.Add(title);
            
            // Clear input
            txt_Title.Clear();
            txt_Title.Focus();
            
            UpdateStatus();
        }
        
        // Button: Remove Selected
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            //SC3: Remove item from list and ListBox
            
            if (lst_Books.SelectedIndex >= 0)
            {
                int index = lst_Books.SelectedIndex;
                
                // Remove from list
                books.RemoveAt(index);
                
                // Remove from ListBox
                lst_Books.Items.RemoveAt(index);
                
                UpdateStatus();
            }
            else
            {
                MessageBox.Show("Please select a book to remove",
                              "No Selection",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
        }
        
        // Button: Clear All
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            //SC4: Clear collections with confirmation
            
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all books?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                books.Clear();
                lst_Books.Items.Clear();
                UpdateStatus();
            }
        }
        
        // Button: Count Pages
        private void btn_CountPages_Click(object sender, EventArgs e)
        {
            //SC5: Numeric validation and calculation
            
            int pages;
            
            if (!int.TryParse(txt_Pages.Text, out pages))
            {
                MessageBox.Show("Please enter a valid number of pages",
                              "Invalid Input",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                txt_Pages.Focus();
                return;
            }
            
            if (pages < 1)
            {
                MessageBox.Show("Pages must be at least 1",
                              "Invalid Range",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txt_Pages.Focus();
                return;
            }
            
            // Calculate reading time (assuming 1 page per minute)
            int hours = pages / 60;
            int minutes = pages % 60;
            
            string message = $"Reading time: {hours}h {minutes}m";
            MessageBox.Show(message, "Calculation Result",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
        
        // Button: Toggle Favorites
        private void btn_ToggleFavorites_Click(object sender, EventArgs e)
        {
            //SC6: Toggle UI element visibility
            
            if (pnl_Favorites.Visible)
            {
                pnl_Favorites.Visible = false;
                btn_ToggleFavorites.Text = "Show Favorites";
            }
            else
            {
                pnl_Favorites.Visible = true;
                btn_ToggleFavorites.Text = "Hide Favorites";
            }
        }
        
        // Button: Favorite Counter +
        private void btn_FavoriteAdd_Click(object sender, EventArgs e)
        {
            //SC7: Increment counter and update display
            favoriteCount++;
            UpdateFavoriteDisplay();
        }
        
        // Button: Favorite Counter -
        private void btn_FavoriteSubtract_Click(object sender, EventArgs e)
        {
            //SC8: Decrement counter and update display
            favoriteCount--;
            UpdateFavoriteDisplay();
        }
        
        // Update favorite counter display
        private void UpdateFavoriteDisplay()
        {
            lbl_FavoriteCount.Text = favoriteCount.ToString();
            
            // Change color based on value
            if (favoriteCount < 0)
            {
                lbl_FavoriteCount.ForeColor = Color.Red;
            }
            else if (favoriteCount > 0)
            {
                lbl_FavoriteCount.ForeColor = Color.Green;
            }
            else
            {
                lbl_FavoriteCount.ForeColor = Color.Blue;
            }
        }
        
        // Button: Random Highlight
        private void btn_RandomHighlight_Click(object sender, EventArgs e)
        {
            //SC9: Generate random font properties
            
            // Random font size
            int fontSize = random.Next(10, 20);
            
            // Random font style
            FontStyle[] styles = { 
                FontStyle.Regular, 
                FontStyle.Bold,
                FontStyle.Italic 
            };
            FontStyle randomStyle = styles[random.Next(styles.Length)];
            
            // Random color
            Color[] colors = { 
                Color.Red, 
                Color.Blue, 
                Color.Green,
                Color.Purple,
                Color.Orange 
            };
            Color randomColor = colors[random.Next(colors.Length)];
            
            // Apply to label
            lbl_Highlight.Font = new Font("Arial", fontSize, randomStyle);
            lbl_Highlight.ForeColor = randomColor;
        }
        
        // Button: Search Books
        private void btn_Search_Click(object sender, EventArgs e)
        {
            //SC10: String search and filtering
            
            string searchTerm = txt_Search.Text.ToLower();
            
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please enter a search term",
                              "Search Error");
                return;
            }
            
            lst_SearchResults.Items.Clear();
            int count = 0;
            
            foreach (string book in books)
            {
                if (book.ToLower().Contains(searchTerm))
                {
                    lst_SearchResults.Items.Add(book);
                    count++;
                }
            }
            
            lbl_SearchStatus.Text = $"Found {count} result(s)";
        }
        
        // Update status label
        private void UpdateStatus()
        {
            lbl_Status.Text = $"Total Books: {books.Count}";
        }
        
        // Button: Grader Test
        private void btn_Grader_Click(object sender, EventArgs e)
        {
            //SC11: Programmatic button testing
            
            // Clear existing data
            books.Clear();
            lst_Books.Items.Clear();
            
            // Test Add functionality
            txt_Title.Text = "Test Book 1";
            btn_Add_Click(sender, e);
            
            txt_Title.Text = "Test Book 2";
            btn_Add_Click(sender, e);
            
            // Test Display
            btn_Display_Click(sender, e);
            
            // Test Counter
            btn_FavoriteAdd_Click(sender, e);
            btn_FavoriteAdd_Click(sender, e);
            btn_FavoriteSubtract_Click(sender, e);
            
            // Test Random
            btn_RandomHighlight_Click(sender, e);
            
            // Show completion
            MessageBox.Show("All grader tests completed",
                          "Test Complete",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
    }
}
```

---

## Quick Reference

### Essential Code Patterns

```csharp
// Input validation
int value;
if (int.TryParse(txt_Input.Text, out value))
{
    // Valid input
}
else
{
    MessageBox.Show("Invalid input");
}

// Add to ListBox
lst_Display.Items.Add("Item");

// Clear ListBox
lst_Display.Items.Clear();

// Loop through List
foreach (string item in items)
{
    lst_Display.Items.Add(item);
}

// Toggle visibility
control.Visible = !control.Visible;

// Format currency
lbl_Price.Text = $"{price:C2}";

// Random integer
int random = random.Next(1, 11);  // 1-10
```

---

## Competition Day Checklist

### Before Starting
- [ ] Read entire problem
- [ ] Note required buttons and their functions
- [ ] Note validation requirements
- [ ] Note output format requirements

### While Coding
- [ ] Add contestant ID comment at top
- [ ] Name project correctly (CS_330_01-2345-6789)
- [ ] Use proper naming conventions (btn_, txt_, lbl_)
- [ ] Add flag comments (//SC1, //SC2, etc.)
- [ ] Validate all inputs
- [ ] Test each button as you complete it

### Before Submitting
- [ ] Program compiles without errors
- [ ] Program runs correctly
- [ ] All buttons work
- [ ] Input validation displays correct messages
- [ ] Output formats match requirements
- [ ] Flag comments in correct locations
- [ ] Project saved to correct folder on flash drive
