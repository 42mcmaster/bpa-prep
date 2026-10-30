# Step 11 — Windows Forms Program with a Class (C#)

**What you'll build:** Club Manager — a Windows Forms app that loads club members from `members.csv`, lets you add members, record points, show a leaderboard, search, and save.
**Time:** two to three class periods. This is the biggest step, and the one closest to the real C# event.

## Table of Contents
- [What you'll learn](#what-youll-learn)
- [From console programs to Windows Forms](#from-console-programs-to-windows-forms)
- [Make a Windows Forms project](#make-a-windows-forms-project)
- [The files in a Forms project](#the-files-in-a-forms-project)
- [The Designer, Toolbox, and Properties window](#the-designer-toolbox-and-properties-window)
- [Naming controls the BPA way](#naming-controls-the-bpa-way)
- [Click events: code behind a button](#click-events-code-behind-a-button)
- [Reading and changing controls from code](#reading-and-changing-controls-from-code)
- [Numbers from a text box and MessageBox](#numbers-from-a-text-box-and-messagebox)
- [ListBox](#listbox)
- [RadioButtons](#radiobuttons)
- [Form1_Load and fields](#form1_load-and-fields)
- [A complete example: Tip Calculator](#a-complete-example-tip-calculator)
- [Clicking a button from code](#clicking-a-button-from-code)
- [Writing your own class](#writing-your-own-class)
- [A list of objects](#a-list-of-objects)
- [Sorting objects and searching](#sorting-objects-and-searching)
- [Data files in a Forms project](#data-files-in-a-forms-project)
- [Common mistakes](#common-mistakes)
- [How this shows up at BPA](#how-this-shows-up-at-bpa)
- [The challenge: Club Manager](#the-challenge-club-manager)
- [Turn it in](#turn-it-in)
- [Checklist](#checklist)

## What you'll learn
- How a Windows Forms program is different from a console program (events instead of a loop)
- How to make a Windows Forms App in Visual Studio and what each file is for
- How to add controls with the Toolbox and set them up in the Properties window
- How to name controls with BPA's prefixes: `txt_`, `lbl_`, `lst_`, `btn_`, `rdb_`
- How double-clicking a button makes its Click event, and how to write the code behind it
- How to read a `TextBox`, change a `Label`, fill a `ListBox`, and check a `RadioButton`
- How to show errors with `MessageBox.Show`
- How to load data when the form opens (`Form1_Load`)
- How to click a button from code with `PerformClick` (the 2026 "grader button")
- How to write your own class with properties, a constructor, and a method, and keep a `List` of objects

## From console programs to Windows Forms

In Steps 1–10 your program ran top to bottom: ask a question, wait, ask the next one. The **program** was in charge.

A Windows Forms program is **event-driven**. It shows a window and then **waits**. Nothing happens until the user does something — clicks a button, for example. Each click runs a small method called an **event handler**. When that method ends, the program goes back to waiting.

| Console (Steps 1–10) | Windows Forms (this step) |
|---|---|
| `Console.Write` a prompt, then `Console.ReadLine()` | the user types in a **TextBox**; you read `txt_Name.Text` |
| `Console.WriteLine` the result | set a **Label**'s text, or add lines to a **ListBox** |
| print an error message | `MessageBox.Show("...")` pops up a box |
| a menu loop with options 1–6 | one **Button** per option; each has its own Click method |
| `while` loop asking again on bad input | show the error and `return`; the user fixes it and clicks again |

The good news: everything inside the methods — `if`, loops, lists, `TryParse`, files, `StringBuilder` — is the same C# you already know.

## Make a Windows Forms project

1. Visual Studio → **Create a new project** → search `windows forms` → choose **Windows Forms App** with the **C#** tag. **Not** "Windows Forms App (.NET Framework)", and not Visual Basic. → **Next**.
2. **Project name:** `Step11`. **Location:** your `bpaPrep\csharp_step11` folder. Check **Place solution and project in the same directory**. → **Next**.
3. **Framework:** `.NET 8.0 (Long Term Support)` → **Create**.

Visual Studio opens **Form1.cs [Design]**: a picture of an empty window. Press **Ctrl+F5** now — an empty window appears. Close it. That's a working Windows program with zero lines of your code.

## The files in a Forms project

In Solution Explorer you'll see:

| File | What it is | Do you edit it? |
|---|---|---|
| `Program.cs` | starts the program and opens `Form1` | No |
| `Form1.cs` | the **code-behind**: your event handlers and methods. Right-click → **View Code** (or press **F7**) to see it. | **Yes — this is where your code goes** |
| `Form1.cs [Design]` | the **Designer**: drag controls onto the form. Shift+F7 switches back to it. | Yes, by dragging and the Properties window |
| `Form1.Designer.cs` | code Visual Studio **writes for you** from what you do in the Designer (creates each control, sets its position and text) | **No** — let the Designer manage it |

`Form1.cs` starts like this:

```csharp
namespace Step11
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

| What you see | What it means |
|---|---|
| `public partial class Form1 : Form` | `Form1` is a class. `: Form` means it **is a** Windows window and gets all the abilities of one. `partial` means the class is split across two files: this one (yours) and `Form1.Designer.cs` (the Designer's). |
| `public Form1()` | the **constructor** — runs once when the form is created (more on constructors [below](#writing-your-own-class)) |
| `InitializeComponent();` | runs the Designer's code that creates all your controls. Never delete it. |

There is no `static` on the methods you write here. They belong to the **form object**, so they can use its controls directly. (That is the change Step 5 mentioned.)

At the top of `Form1.cs`, add the `using` lines you need, like in the console steps: `using System;`, `using System.Collections.Generic;`, `using System.IO;`, `using System.Windows.Forms;`. (A Forms project includes these behind the scenes; writing them shows what you use.)

The header comment with your name (contestant ID at BPA) goes at the very top of **`Form1.cs`**. The 2026 regional gave 10 points for exactly that.

## The Designer, Toolbox, and Properties window

- **Toolbox** (View → Toolbox, or Ctrl+Alt+X): the list of controls. Click the pushpin to keep it open. Drag a control onto the form, or click it and then click the form.
- **Properties window** (View → Properties Window, or F4): settings for whatever is selected. Click a control first, then change its properties.
- Drag a control to move it; drag its little white squares to resize it.

The controls you need:

| Control | Toolbox name | Used for | Key property |
|---|---|---|---|
| Label | `Label` | text the user reads (captions, results) | `Text` |
| TextBox | `TextBox` | text the user types | `Text` |
| Button | `Button` | something to click | `Text`, Click event |
| ListBox | `ListBox` | a list of lines | `Items`, `SelectedIndex` |
| RadioButton | `RadioButton` | pick one of several choices | `Checked` |
| GroupBox / Panel | `GroupBox`, `Panel` | a box that holds other controls; radio buttons inside one box form a group | `Visible` |

Two properties matter most, and they are easy to mix up:

| Property | What it is | Example |
|---|---|---|
| **(Name)** | the name you use **in code**. Near the top of the Properties list, in parentheses. | `btn_AddMember` |
| **Text** | what the user **sees** on the control | `Add Member` |

Other useful properties: `Font` (size and style), `ForeColor` (text color), `Visible`, `Enabled`, `AutoSize` (for labels — set it to `False` if you want a fixed-size label with a border), `BorderStyle`.

For the form itself (click an empty spot on the form): `Text` is the title bar, `StartPosition` = `CenterScreen` opens it in the middle, `FormBorderStyle` = `FixedDialog` stops resizing, `MaximizeBox` = `False` removes the maximize button. The 2022 regional asked for exactly those settings.

## Naming controls the BPA way

BPA's C# tests name every control with a **prefix** that says what kind of control it is, then an underscore, then a name in PascalCase:

| Prefix | Control | Example |
|---|---|---|
| `txt_` | TextBox | `txt_Name`, `txt_Points` |
| `lbl_` | Label | `lbl_Status`, `lbl_Result` |
| `lst_` | ListBox | `lst_Members`, `lst_Results` |
| `btn_` | Button | `btn_AddMember`, `btn_Save` |
| `rdb_` | RadioButton | `rdb_Miles`, `rdb_KM` |
| `chk_` | CheckBox | `chk_Member` |
| `pnl_` | Panel | `pnl_HideShow` |
| `grp_` | GroupBox | `grp_Units` |

At the regional the form was **pre-built** with these names and you only wrote the code. In practice, name each control **right after you add it**, and always **before** you double-click it (next section explains why).

Labels that never change (captions like "Search for:") don't strictly need a special name, but giving them one (`lbl_SearchFor`) keeps things tidy.

## Click events: code behind a button

1. Add a Button. Set **(Name)** to `btn_SayHello` and **Text** to `Say Hello`.
2. **Double-click** the button in the Designer.

Visual Studio switches to `Form1.cs` and makes an empty method for you:

```csharp
private void btn_SayHello_Click(object sender, EventArgs e)
{

}
```

Write the code that should run when the button is clicked inside it:

```csharp
private void btn_SayHello_Click(object sender, EventArgs e)
{
    // Output: pop up a message
    MessageBox.Show("Hello from BPA prep!");
}
```

Run with Ctrl+F5 and click the button.

| Part | What it means |
|---|---|
| `private` | only this form uses the method |
| `void` | returns nothing |
| `btn_SayHello_Click` | the name: control name + `_` + event name. This is why you name the control **first**. If you double-click `button1` and rename it later, the method stays `button1_Click`, which looks messy and costs naming points. |
| `object sender` | which control raised the event (the button). You rarely need it. |
| `EventArgs e` | extra details about the event. You rarely need it. |

How does the button know to call this method? When you double-clicked, the Designer also added this line to `Form1.Designer.cs`:

```csharp
btn_SayHello.Click += btn_SayHello_Click;
```

`+=` here means "when `btn_SayHello` is clicked, also run `btn_SayHello_Click`." This connection is called **wiring** the event. You don't type it — the Designer does. You can see a control's wired events by selecting it and clicking the **lightning bolt** at the top of the Properties window.

## Reading and changing controls from code

Inside your form's methods, use a control by its **(Name)**, then a dot, then a property:

```csharp
// Input: read what the user typed
string name = txt_Name.Text;

// Output: show something
lbl_Result.Text = "Welcome, " + name;

// Clear a text box and put the cursor in it
txt_Name.Clear();
txt_Name.Focus();

// Show / hide and enable / disable
lbl_Result.Visible = false;
btn_Save.Enabled = false;

// Colors and fonts (Color and Font come from System.Drawing)
lbl_Result.ForeColor = Color.Red;
lbl_Result.Font = new Font("Arial", 14, FontStyle.Bold);

// Change a button's own text
btn_SayHello.Text = "Clicked!";
```

`.Text` is always a **string**, even in a text box where the user typed `42`. Convert it before doing math (next section).

## Numbers from a text box and MessageBox

You can't re-ask in a loop like Step 10 — the user is looking at the form. Instead: check the input; if it's bad, show a message and **`return`** (leave the method). The user fixes it and clicks again.

```csharp
private void btn_Double_Click(object sender, EventArgs e)
{
    // Input: the number from the text box. TryParse gives false (no crash)
    // for letters, decimals, and blanks.
    if (!int.TryParse(txt_Number.Text, out int number) || number < 1 || number > 1000)
    {
        MessageBox.Show("Please enter a whole number from 1 to 1000.");
        return;   // stop - don't do the math with a bad number
    }

    // Processing + Output
    lbl_Result.Text = $"Double: {number * 2}";
}
```

This is the same `TryParse` you used in `GetInt` (Step 10), turned inside-out: `!` means "if it did **not** parse **or** it's out of range, show the error."

`MessageBox.Show` has several forms:

| What you type | What appears |
|---|---|
| `MessageBox.Show("Saved.");` | a box with the message and an OK button |
| `MessageBox.Show("Bad input.", "Input Error");` | same, with a title on the box |
| `MessageBox.Show("Bad input.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);` | adds a red error icon |

The program waits until the user clicks OK.

## ListBox

A ListBox shows lines of text. You control it through its **`Items`** collection, which works like a List:

```csharp
lst_Results.Items.Clear();                  // remove everything
lst_Results.Items.Add("First line");        // add a line at the bottom
lst_Results.Items.Add($"Total: {42}");
int howMany = lst_Results.Items.Count;      // how many lines

int picked = lst_Results.SelectedIndex;     // which line the user clicked (-1 = none)
lst_Results.SelectedIndex = 0;              // select the first line from code
```

- `SelectedIndex` starts at 0, like a list. **-1** means nothing is selected. Always check for -1 before using it.
- If you add lines in the same order as a `List`, then `SelectedIndex` is also the index in that List. The challenge uses this to know which member was clicked.

**Lining up columns in a ListBox.** The normal font is proportional (an `i` is narrower than an `M`), so `{name,-10}` padding won't line up. Set the ListBox's **Font** property to **Consolas** (a monospaced font — every character is the same width), and your Step 8 column formatting lines up again.

## RadioButtons

RadioButtons let the user pick **one** choice. Clicking one automatically un-checks the others in the same group (the same form, or the same GroupBox/Panel). Read them with `.Checked`, which is `true` or `false`:

```csharp
if (rdb_Miles.Checked)
{
    // convert miles to km
}
else if (rdb_KM.Checked)
{
    // convert km to miles
}
else
{
    MessageBox.Show("Please choose a unit.");
}
```

To have one already chosen when the form opens, set its **Checked** property to `True` in the Properties window. To start with none chosen (so you can test the "please choose" message), leave them all `False`.

## Form1_Load and fields

**Form1_Load** runs once, when the form opens, before the user can click anything. It's the place to load a data file. To make it, **double-click an empty spot on the form** in the Designer (not on a control). You get:

```csharp
private void Form1_Load(object sender, EventArgs e)
{

}
```

**Fields.** A variable made inside a click method disappears when the method ends. To keep a value **between** clicks (a counter, a list of members), make it a **field**: a variable inside the class but **outside** any method, usually at the top of `Form1`:

```csharp
public partial class Form1 : Form
{
    // Fields: these live as long as the form is open
    private int clickCount = 0;
    private List<string> names = new List<string>();

    public Form1()
    {
        InitializeComponent();
    }

    private void btn_Count_Click(object sender, EventArgs e)
    {
        clickCount++;   // keeps going up with every click
        lbl_Count.Text = $"Clicks: {clickCount}";
    }
}
```

The 2026 regional's Add and Subtract buttons were exactly this: a counter field, changed by two buttons, both calling one `UpdateCounterDisplay()` method that set the label's text and color.

## A complete example: Tip Calculator

This form works out a tip. It uses a TextBox, RadioButtons, Labels, a ListBox, a field, `TryParse`, `MessageBox`, `Form1_Load`, and a show/hide button. (It is not the challenge.)

**The form:**

```text
+-------------------------------------------------------------+
| Tip Calculator                                         [X]  |
+-------------------------------------------------------------+
|  Bill amount: [txt_Bill      ]   (o) rdb_Tip15  ( ) rdb_Tip20|
|                                                             |
|  [ btn_Calculate ]   lbl_Tip: Tip: $6.00    lbl_Total: ...  |
|  +-------------------------------------------------------+  |
|  | lst_History  (Font: Consolas)                         |  |
|  | 1. $40.00 + 15% = $46.00                              |  |
|  +-------------------------------------------------------+  |
|  [ btn_ClearHistory ]  [ btn_HideHistory ]                  |
+-------------------------------------------------------------+
```

**Build it:**
1. New Windows Forms App named `TipCalculator`.
2. Click the form; set its **Text** to `Tip Calculator`.
3. Add a Label with Text `Bill amount:`. Add a TextBox; (Name) `txt_Bill`.
4. Add two RadioButtons: `rdb_Tip15` (Text `15%`, **Checked** `True`) and `rdb_Tip20` (Text `20%`).
5. Add a Button `btn_Calculate` (Text `Calculate`), and two Labels `lbl_Tip` and `lbl_Total`.
6. Add a ListBox `lst_History`; set its Font to Consolas.
7. Add Buttons `btn_ClearHistory` (Text `Clear History`) and `btn_HideHistory` (Text `Hide History`).
8. Double-click each of the three buttons, then double-click an empty spot on the form (for `Form1_Load`). Now fill in the methods.

**Form1.cs:**

```csharp
// Name: Example
// Date: 2026-11-06
// Program: Tip Calculator
// Description: Works out a tip and total from a bill amount and a tip
//              percent chosen with radio buttons, and keeps a history.

using System;
using System.Windows.Forms;

namespace TipCalculator
{
    public partial class Form1 : Form
    {
        // Field: lives as long as the form, so it keeps counting between clicks
        private int checksCalculated = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // Purpose: runs once when the form opens.
        // Parameters: sender, e - supplied by Windows Forms.  Returns: nothing.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Output: starting text
            lbl_Tip.Text = "Tip: $0.00";
            lbl_Total.Text = "Total: $0.00";
        }

        // Purpose: Calculate button - work out the tip and total.
        // Parameters: sender, e - supplied by Windows Forms.  Returns: nothing.
        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            // Input: the bill from the text box. TryParse returns false for
            // letters or blanks, so a bad entry shows a message instead of crashing.
            if (!decimal.TryParse(txt_Bill.Text, out decimal bill) || bill <= 0)
            {
                MessageBox.Show("Please enter a bill amount greater than 0.", "Input Error");
                txt_Bill.Focus();   // put the cursor back in the text box
                return;             // stop here
            }

            // Processing: pick the rate from the radio buttons
            decimal rate;
            if (rdb_Tip20.Checked)
            {
                rate = 0.20m;
            }
            else
            {
                rate = 0.15m;
            }
            decimal tip = bill * rate;
            decimal total = bill + tip;
            checksCalculated++;

            // Output: labels and one new line in the list box
            lbl_Tip.Text = $"Tip: ${tip:F2}";
            lbl_Total.Text = $"Total: ${total:F2}";
            lst_History.Items.Add($"{checksCalculated}. ${bill:F2} + {rate * 100:F0}% = ${total:F2}");
        }

        // Purpose: Clear History button - empty the list box.
        // Parameters: sender, e - supplied by Windows Forms.  Returns: nothing.
        private void btn_ClearHistory_Click(object sender, EventArgs e)
        {
            // Output: remove every line
            lst_History.Items.Clear();
        }

        // Purpose: Hide History button - show or hide the list box.
        // Parameters: sender, e - supplied by Windows Forms.  Returns: nothing.
        private void btn_HideHistory_Click(object sender, EventArgs e)
        {
            // Processing + Output: flip Visible, and change the button text to match
            if (lst_History.Visible)
            {
                lst_History.Visible = false;
                btn_HideHistory.Text = "Show History";
            }
            else
            {
                lst_History.Visible = true;
                btn_HideHistory.Text = "Hide History";
            }
        }
    }
}
```

**What happens:**

| You do | You see |
|---|---|
| Open the form | `Tip: $0.00` and `Total: $0.00` |
| Type `abc`, click Calculate | a box: "Please enter a bill amount greater than 0." |
| Type `40`, 15% chosen, click Calculate | `Tip: $6.00`, `Total: $46.00`, list line `1. $40.00 + 15% = $46.00` |
| Type `25.50`, choose 20%, click Calculate | `Tip: $5.10`, `Total: $30.60`, list line `2. $25.50 + 20% = $30.60` |
| Click Hide History | the list disappears; the button now says `Show History` |

**Try it:**
- Add a third radio button `rdb_Tip25` for 25%.
- Add a Label `lbl_Count` that shows `Checks: 2` after each calculation.
- Make the total label red when the total is over $100 (`lbl_Total.ForeColor = Color.Red;`), and black otherwise.

## Clicking a button from code

Every Button has a **`PerformClick()`** method. It runs that button's Click event as if the user clicked it:

```csharp
// Purpose: Test All button - run the other buttons with sample input.
private void btn_TestAll_Click(object sender, EventArgs e)
{
    txt_Bill.Text = "40";
    rdb_Tip15.Checked = true;
    btn_Calculate.PerformClick();     // runs btn_Calculate_Click

    txt_Bill.Text = "25.50";
    rdb_Tip20.Checked = true;
    btn_Calculate.PerformClick();

    MessageBox.Show("All tests completed.");
}
```

The 2026 regional's **Grader Button** was worth 200 points plus 50 in code review: put sample values in the text boxes, call `PerformClick()` on each of the other buttons, then show a summary message. It only works if the other buttons already work — so build it last.

## Writing your own class

So far you've used classes other people wrote: `Random`, `List`, `StringBuilder`, `Form`. Now you'll write one.

A **class** is a blueprint for a kind of thing. It says what data each thing holds and what it can do. An **object** is one thing made from the blueprint. `new` makes an object.

Make a new file for the class: **Project → Add Class…** (or right-click the project → Add → Class), name it `Product.cs`, and Visual Studio creates it. Here is an example class (the challenge's `Member` class is similar):

```csharp
namespace Inventory
{
    // Purpose: one product in a store: its name and how many are in stock.
    public class Product
    {
        // Properties: the data each Product object holds
        public string Name { get; set; }
        public int Stock { get; set; }

        // Purpose: constructor - runs when you write new Product(...).
        // Parameters: name - product name; stock - starting stock.
        // Returns: nothing (constructors never return a value).
        public Product(string name, int stock)
        {
            Name = name;
            Stock = stock;
        }

        // Purpose: add new stock.
        // Parameters: amount - how many arrived.
        // Returns: nothing.
        public void Restock(int amount)
        {
            Stock += amount;
        }
    }
}
```

| Part | What it means |
|---|---|
| `public class Product` | the blueprint's name. `public` means other files (like `Form1.cs`) can use it. |
| `public string Name { get; set; }` | a **property**: a piece of data each object has. `get` lets other code read it, `set` lets other code change it. Properties use PascalCase. |
| `public Product(string name, int stock)` | the **constructor**. Same name as the class, **no return type**. It runs once when an object is made, and fills in the properties. |
| `Name = name;` | the property `Name` (capital N) gets the parameter `name` (lower-case n) |
| `public void Restock(int amount)` | a **method** that belongs to each object. No `static` — it works on one particular product's `Stock`. |

Using it:

```csharp
Product pens = new Product("Pens", 40);     // make an object - the constructor runs
Product pads = new Product("Notepads", 12);

pens.Restock(10);                            // call the method on ONE object
Console.WriteLine($"{pens.Name}: {pens.Stock}");   // Pens: 50
Console.WriteLine($"{pads.Name}: {pads.Stock}");   // Notepads: 12 - not changed
```

Each object has its **own** `Name` and `Stock`. Restocking `pens` doesn't touch `pads`.

**Put the class in its own file.** If you put another class **above** `Form1` in `Form1.cs`, the Designer can't open the form any more. Its own file avoids that. Use the same `namespace` as your form (Visual Studio does this for you).

## A list of objects

A `List` can hold objects, just like it holds ints:

```csharp
List<Product> products = new List<Product>();
products.Add(new Product("Pens", 40));
products.Add(new Product("Notepads", 12));

foreach (Product p in products)
{
    lst_Results.Items.Add($"{p.Name} ({p.Stock})");
}

products[1].Restock(5);   // the second product now has 17
```

`products[1]` is a whole `Product`, so you can use its properties and methods directly. This replaces the parallel arrays from Step 8: the name and the number travel together in one object, so they can never get out of sync.

## Sorting objects and searching

**Sorting by a property.** The selection sort from Step 8 works on a List of objects — compare a property, and swap the whole object. Sort a **copy** so the original order stays the same:

```csharp
// Purpose: copy the products, sorted by stock, highest first.
// Parameters: none.  Returns: the sorted copy.
private List<Product> SortedByStock()
{
    List<Product> sorted = new List<Product>(products);   // a copy
    for (int i = 0; i < sorted.Count - 1; i++)
    {
        int biggest = i;
        for (int j = i + 1; j < sorted.Count; j++)
        {
            if (sorted[j].Stock > sorted[biggest].Stock)
            {
                biggest = j;
            }
        }
        Product temp = sorted[i];          // one swap moves the whole object
        sorted[i] = sorted[biggest];
        sorted[biggest] = temp;
    }
    return sorted;
}
```

(You may see a shortcut: `sorted.Sort((a, b) => b.Stock.CompareTo(a.Stock));`. The `(a, b) => ...` part is a **lambda** — a tiny method written in one line that tells `Sort` how to compare two products. It works, but writing the loop shows graders the algorithm, and the loop keeps ties in their original order.)

**Case-insensitive search.** Lower-case both sides, then use `Contains` (Step 7):

```csharp
string search = txt_Search.Text.Trim().ToLower();
foreach (Product p in products)
{
    if (p.Name.ToLower().Contains(search))
    {
        lst_Results.Items.Add($"{p.Name} - {p.Stock} in stock");
    }
}
```

## Data files in a Forms project

Everything from Step 9 works the same. Two differences:
- The program runs from **`bin\Debug\net8.0-windows\`** (note `-windows`). Add the `.csv` to the project and set **Copy to Output Directory** to **Copy if newer**, exactly like Step 9.
- Load the file in **`Form1_Load`**, and save it in a button's Click method, inside `try` / `catch` (Step 10).

Show messages in a status Label or a `MessageBox` instead of `Console.WriteLine`.

## Common mistakes

**You double-clicked a control by accident and got an empty method.**
`label1_Click` or `txt_Name_TextChanged` appears in your code.
Fix: leave it empty (harmless), or remove it the safe way: select the control → Properties → lightning bolt → right-click the event → **Reset**. That removes both the method and the wiring.

**You deleted a method, and now the Designer has an error.**
`CS0103 The name 'button1_Click' does not exist in the current context`, and the error is in `Form1.Designer.cs`. (Older projects show `CS1061 'Form1' does not contain a definition for 'button1_Click'` instead.)
Fix: double-click the error to jump to the line `button1.Click += button1_Click;` and delete **that one line**. Then save and rebuild.

**You renamed a control after making its event.**
The method is still called `button1_Click`.
Fix: rename the method too (right-click the method name → **Rename**, which also fixes the wiring), or delete it the safe way and double-click again.

**Using the Text instead of the (Name) in code.**
`CS0103 The name 'Add Member' does not exist...` or a name that doesn't match.
Fix: code uses **(Name)** (`btn_AddMember`). Text is just what's displayed.

**Doing math with `.Text` directly.**
`CS0019 Operator '*' cannot be applied to operands of type 'string' and 'int'`.
Fix: `int.TryParse(txt_Points.Text, out int points)` first.

**Using `SelectedIndex` when nothing is selected.**
`System.ArgumentOutOfRangeException` when you use `members[-1]`.
Fix: check `if (lst_Members.SelectedIndex == -1)` and show a message.

**The leaderboard columns don't line up.**
Fix: set the ListBox Font to **Consolas**.

**The form won't open in the Designer.**
"The class Form1 can be designed, but is not the first class in the file."
Fix: move your other class (like `Member`) into its own file.

**The CSV isn't found.**
Fix: set **Copy to Output Directory** to **Copy if newer**. The program looks in `bin\Debug\net8.0-windows\`.

**A value resets on every click.**
You made the variable inside the click method.
Fix: make it a **field** at the top of the class.

## How this shows up at BPA

- The 2026 regional was this format: a pre-built `Form1` with `txt_`, `lbl_`, `lst_`, `btn_`, `rdb_` controls and empty Click methods. You wrote the code inside them.
- Its buttons map straight onto this step: fill a ListBox from a `List<string>` (Vocab Generator), read text boxes and show errors in a message box (Monthly Payment), branch on radio buttons (Distance Converter), a counter field plus a shared update method that changes a label's color (Add/Subtract), toggle `Visible` and change the button's `Text` (Hide or Show), random `Font` and `Color` (Random Font), and `PerformClick` on the other buttons (Grader Button).
- The rubric gives points for the contestant ID comment at the top of **`Form1.cs`**, and for comments marked with flags like `//SC1` on specific methods. Read the test's commenting instructions carefully and use their exact flags.
- "Class construction" and "data structures" are graded items. A class with properties, a constructor, and a method, kept in a `List`, covers both.

## The challenge: Club Manager

Build the Club Manager as a Windows Forms app. It has the same features and the same messages as the console version the other languages build. Each menu option is a button.

The data file [members.csv](members.csv) is in this step's folder. Add it to your project with **Copy to Output Directory** = **Copy if newer**:

```text
Name,Points
Avery,120
Blake,95
Casey,140
```

**The form** — use these control names exactly (Text in quotes):

```text
+--------------------------------------------------------------------------+
| Club Manager                                                        [X]  |
+--------------------------------------------------------------------------+
| lbl_Status (AutoSize False, BorderStyle FixedSingle, wide)               |
|  Loaded 3 members from members.csv                                       |
|                                                                          |
|  "Members"                          "Leaderboard"                        |
|  +----------------------------+     +--------------------------------+   |
|  | lst_Members                |     | lst_Leaderboard (Font Consolas)|   |
|  | Avery (120)                |     | Rank  Name      Points         |   |
|  | Blake (95)                 |     | ----------------------         |   |
|  | Casey (140)                |     | 1     Casey     140            |   |
|  +----------------------------+     +--------------------------------+   |
|                                     [ btn_Leaderboard "Show Leaderboard" ]|
|  "New member name:" [txt_Name   ]  [ btn_AddMember "Add Member" ]        |
|  "Points to add:"   [txt_Points ]  [ btn_RecordPoints "Record Points" ]  |
|  "Search for:"      [txt_Search ]  [ btn_Search "Search" ]               |
|  +------------------------------------+                                  |
|  | lst_Results                        |   [ btn_Save "Save" ] [ btn_Quit "Quit" ] |
|  +------------------------------------+                                  |
+--------------------------------------------------------------------------+
```

| Control | (Name) | Text / setting |
|---|---|---|
| Label | `lbl_Status` | empty; AutoSize `False`, BorderStyle `FixedSingle` |
| ListBox | `lst_Members` | |
| ListBox | `lst_Leaderboard` | Font `Consolas` |
| ListBox | `lst_Results` | |
| TextBox | `txt_Name`, `txt_Points`, `txt_Search` | |
| Button | `btn_AddMember` | `Add Member` |
| Button | `btn_RecordPoints` | `Record Points` |
| Button | `btn_Leaderboard` | `Show Leaderboard` |
| Button | `btn_Search` | `Search` |
| Button | `btn_Save` | `Save` |
| Button | `btn_Quit` | `Quit` |
| Labels (captions) | `lbl_Members`, `lbl_Leaderboard`, `lbl_NewName`, `lbl_PointsToAdd`, `lbl_SearchFor` | `Members`, `Leaderboard`, `New member name:`, `Points to add:`, `Search for:` |
| Form | `Form1` | Text `Club Manager`, StartPosition `CenterScreen` |

**How the console menu maps to the form:**

| Console version | Form version |
|---|---|
| print `Loaded 3 members from members.csv` at start | `Form1_Load` puts it in `lbl_Status` |
| menu option 1, `New member name: ` | type in `txt_Name`, click **Add Member** |
| option 2, numbered list + `Choose a member (1-N): ` | `lst_Members` always shows the members as `Avery (120)`; click one to choose it |
| `Points to add (1-50): ` | type in `txt_Points`, click **Record Points** |
| option 3 | **Show Leaderboard** fills `lst_Leaderboard` |
| option 4, `Search for: ` | type in `txt_Search`, click **Search**; results go in `lst_Results` |
| option 5 | **Save** |
| option 6 | **Quit** |
| `Please enter a whole number from 1 to 6.` | not needed — buttons can't be "out of range" |

**Requirements:**
1. Header comment (at the top of `Form1.cs`, and also at the top of `Member.cs`).
2. A `Member` class (in `Member.cs`) with a name, points, a constructor, and an `AddPoints(amount)` method.
3. When the form loads, load `members.csv` into a `List<Member>` and show `Loaded 3 members from members.csv` (the real count) in `lbl_Status`. If it's missing show `No members.csv found. Starting with an empty list.` `lst_Members` always shows every member as `Avery (120)`, in the order loaded/added.
4. One button per menu option: Add Member, Record Points, Show Leaderboard, Search, Save, Quit. Invalid input shows a `MessageBox` and never crashes.
5. **Add member:** read `txt_Name` (trimmed). Blank: `This cannot be blank.` If the name already exists (ignore case): `That member already exists.` Otherwise add with 0 points and show `Added <name>.` in `lbl_Status`.
6. **Record points:** if there are no members: `No members yet.` If no member is selected in `lst_Members`: `Please choose a member.` Points from `txt_Points` must be a whole number from 1 to 50, otherwise `Please enter a whole number from 1 to 50.` Then call `AddPoints` and show `<name> now has <points> points.` in `lbl_Status`.
7. **Show leaderboard:** fill `lst_Leaderboard`, sorted by points, highest first:
   ```text
   Rank  Name      Points
   ----------------------
   1     Casey     140
   2     Avery     120
   3     Blake     95
   ```
   (Rank 6 wide left, Name 10 wide left, then points. 22 dashes.) Showing the leaderboard must **not** reorder the members list — sort a copy.
8. **Search:** show in `lst_Results` every member whose name contains the text in `txt_Search`, ignoring case, as `Casey - 140 points`. If none: `No members match "<text>".` Blank search: `This cannot be blank.`
9. **Save:** write `members.csv` (header + one line per member) and `club_report.txt` (`CLUB REPORT`, `Report created: yyyy-MM-dd HH:mm`, a blank line, the leaderboard). Use try/catch. Show `Saved members.csv and club_report.txt` in `lbl_Status`.
10. **Quit:** show `Goodbye!` in a `MessageBox`, then close the form (`this.Close();`).
11. Each menu option is its own method (the Click methods, plus helper methods such as `LoadMembers`, `FindMember`, `BuildLeaderboard`). Function comments and Input / Processing / Output comments.

**Sample session** (the same steps as the console version's sample run):

| You do | You see |
|---|---|
| Open the form | `lbl_Status`: `Loaded 3 members from members.csv`. `lst_Members`: `Avery (120)`, `Blake (95)`, `Casey (140)` |
| Type `Jordan` in `txt_Name`, click Add Member | `lbl_Status`: `Added Jordan.` `lst_Members` gets `Jordan (0)` |
| Click `Blake (95)` in `lst_Members`, type `50` in `txt_Points`, click Record Points | `lbl_Status`: `Blake now has 145 points.` The list shows `Blake (145)` |
| Click Show Leaderboard | `lst_Leaderboard`: see below |
| Type `a` in `txt_Search`, click Search | `lst_Results`: `Avery - 120 points`, `Blake - 145 points`, `Casey - 140 points`, `Jordan - 0 points` |
| Click Quit | a box: `Goodbye!`, then the form closes |

Leaderboard after those steps:

```text
Rank  Name      Points
----------------------
1     Blake     145
2     Casey     140
3     Avery     120
4     Jordan    0
```

Also test: Add Member with `avery` (already exists), Record Points with `abc`, `2.5`, `0`, and `51`, Record Points with nothing selected, Search for `zz` (`No members match "zz".`), and Save (then open `bin\Debug\net8.0-windows\club_report.txt`).

**Hints:**
- Build the form first and name every control **before** double-clicking any of them. Then double-click each button and the empty form background.
- Fields at the top of `Form1`: `private List<Member> members = new List<Member>();`
- Write a helper `RefreshMemberList()` that clears `lst_Members` and adds every member. Call it after loading, adding, and recording points.
- `FindMember(string name)` returns the index of a member whose name matches (ignore case), or `-1`.
- `BuildLeaderboard()` returns a `List<string>` of lines. Show it in the ListBox **and** write it to the report — the Step 9 "build once, use twice" idea.
- After Record Points, `RefreshMemberList()` clears the selection. Set `lst_Members.SelectedIndex = index;` again if you want it to stay selected.

## Turn it in
1. In your `bpaPrep` repo make a folder `csharp_step11`.
2. Put your whole Visual Studio project folder (`Step11`) in it, including `members.csv`.
3. Commit and push with GitHub Desktop.
4. Private comment on the Classroom **BPA Friday** assignment: *C# step 11 done*.

## Checklist
- [ ] Program runs with no errors
- [ ] The sample session gives the same results
- [ ] Header comment at the top of `Form1.cs` and `Member.cs`
- [ ] Input / Processing / Output comments
- [ ] Every control is named with the right prefix, exactly as in the table
- [ ] `Member` class with properties, a constructor, and `AddPoints`, in its own file
- [ ] Members kept in a `List<Member>`; the leaderboard sorts a copy
- [ ] Every bad input shows a `MessageBox` instead of crashing
- [ ] Save uses `try` / `catch` with a comment saying what it catches
- [ ] Pushed to `bpaPrep/csharp_step11`
