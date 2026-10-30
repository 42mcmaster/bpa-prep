# Python Setup Guide (BPA 355)

How to install Python, write and run your first program in IDLE, read an error, and push your work to your `bpaPrep` repo. Written for someone who has never used Python or IDLE.

## Table of Contents
- [What you need](#what-you-need)
- [For the teacher and IT](#for-the-teacher-and-it)
- [Installing Python at home](#installing-python-at-home)
- [Opening IDLE](#opening-idle)
- [Your first program](#your-first-program)
- [Where your files are saved](#where-your-files-are-saved)
- [Reading an error](#reading-an-error)
- [Opening starter files and data files](#opening-starter-files-and-data-files)
- [Useful IDLE settings and keys](#useful-idle-settings-and-keys)
- [VS Code (the other option)](#vs-code-the-other-option)
- [Pushing a step to your bpaPrep repo](#pushing-a-step-to-your-bpaprep-repo)
- [The gitignore file](#the-gitignore-file)
- [What is allowed at BPA](#what-is-allowed-at-bpa)

## What you need

- **Python 3** from [python.org](https://www.python.org/downloads/) (3.10 or newer; the newest version is fine). It comes with **IDLE**, a simple editor for writing and running Python programs.
- **GitHub Desktop**, already on the lab computers, and your `bpaPrep` repository.

All the lessons use **IDLE** and **F5** to run. IDLE is allowed at the BPA event and has nothing to set up. VS Code works too (see [VS Code (the other option)](#vs-code-the-other-option)).

## For the teacher and IT

> **What IT needs to install on the lab Windows machines**
> 1. **Python 3.12 or newer** (64-bit) from python.org, installed for all users. In the installer: check **"Add python.exe to PATH"**, choose **Customize installation**, and make sure **"tcl/tk and IDLE"** and **"py launcher"** are checked. On the next page check **"Install Python for all users"**.
> 2. Optional: **VS Code** with the **Python** extension (by Microsoft). Students already use VS Code for web work.
> 3. No other packages are needed. Every lesson uses only what comes with Python (`random`, `datetime`, `os`).
>
> **Check it worked:** open the Start menu, type `IDLE`, and open **IDLE (Python 3.x 64-bit)**. Type `print("hello")` at the `>>>` prompt and press Enter. It should print `hello`.

## Installing Python at home

1. Go to [python.org/downloads](https://www.python.org/downloads/) and click the big yellow **Download Python 3.x** button.
2. Run the installer. **On the first screen, check "Add python.exe to PATH"** at the bottom. Then click **Install Now**.
3. When it says "Setup was successful," click **Close**.
4. On a Mac, the installer is a `.pkg` file — open it and click through. IDLE ends up in **Applications > Python 3.x**.

## Opening IDLE

- **Windows:** click Start, type `IDLE`, and open **IDLE (Python 3.x)**.
- **Mac:** Applications > Python 3.x > IDLE.

The first window is the **Shell**. It has a `>>>` prompt. You can type one line of Python there and press Enter to see what it does — good for quick tests. Nothing typed in the Shell is saved.

```
>>> 7 * 6
42
>>> print("Hello")
Hello
```

Programs you turn in are written in an **Editor** window and saved as `.py` files.

## Your first program

1. In IDLE click **File > New File**. A blank Editor window opens.
2. Type this:
   ```python
   # Name: Your Name
   # Date: today's date
   # Program: Hello Test
   # Description: Checks that Python is working.

   # Output: two lines
   print("Hello from Python!")
   print("7 times 6 is", 7 * 6)
   ```
3. Click **File > Save As**. Go to the folder for this step (for example `Documents\GitHub\bpaPrep\python_step01`). Name it `hello.py` and click **Save**. Python can't run a file that has never been saved.
4. Press **F5** (or click **Run > Run Module**).
5. The output shows up in the **Shell** window:
   ```
   = RESTART: C:\Users\you\Documents\GitHub\bpaPrep\python_step01\hello.py
   Hello from Python!
   7 times 6 is 42
   ```

Every time you change the program, press **F5** again. IDLE asks "Source must be saved. OK to save?" — click **OK**. (To skip that question, see [Useful IDLE settings and keys](#useful-idle-settings-and-keys).)

When a program asks for input, you type the answer **in the Shell window**, next to the prompt, and press Enter.

## Where your files are saved

Wherever you choose in **Save As**. Save each step's file in that step's folder in your `bpaPrep` repo, so it's ready to push.

When you run a program with **F5**, IDLE runs it **in the folder the `.py` file is saved in**. That matters starting in Step 9: a program that opens `scores.csv` looks for it in the same folder as the `.py` file. Files your program writes (like `report.txt`) appear in that folder too.

## Reading an error

**Syntax errors** (Python can't understand the code — nothing runs): IDLE shows a pop-up box with the message, and highlights the problem spot in red in the Editor. The real mistake is often at the end of the line **before** the red spot (a missing `)` or `"`).

**Runtime errors** (the program crashes partway through): the Shell shows a red **Traceback**:

```
Traceback (most recent call last):
  File "C:\Users\you\Documents\GitHub\bpaPrep\python_step02\step02.py", line 9, in <module>
    price = float(input("Price: "))
ValueError: could not convert string to float: 'two'
```

1. Read the **last line** first: the kind of error and why.
2. Find the **line number** just above it (`line 9`).
3. In the Editor, the bottom-right corner shows the line your cursor is on (`Ln: 9`). Or right-click the `File ... line 9` line in the Shell and pick **Go to file/line**.

Turn on line numbers: **Options > Show Line Numbers** in the Editor window.

## Opening starter files and data files

- **Open a `.py` file in IDLE:** in IDLE click **File > Open** and pick the file. Or in File Explorer, right-click the file and choose **Edit with IDLE**. (Double-clicking a `.py` file runs it in a black window that closes right away — that's not what you want.)
- **Downloading a file from GitHub:** open the file on GitHub and click the **Download raw file** button (the down-arrow icon at the top right of the file). Save it into your step folder.
- **Data files** (`scores.csv`, `members.csv`, `sales.csv`): put them in the **same folder** as your `.py` file. Check that Windows didn't add `.txt` to the end — in File Explorer, turn on **View > Show > File name extensions** so you can see the real name.

## Useful IDLE settings and keys

| Key or menu | What it does |
|---|---|
| **F5** | Save and run the program |
| **Ctrl+C** (in the Shell) | Stop a program that's stuck in a loop |
| **Alt+3** / **Alt+4** | Comment out / un-comment the selected lines |
| **Ctrl+]** / **Ctrl+[** | Indent / un-indent the selected lines |
| **Alt+P** (in the Shell) | Bring back the last line you typed |
| **Options > Show Line Numbers** | Line numbers on the left of the Editor |
| **Options > Configure IDLE > Fonts** | Bigger text |
| **Options > Configure IDLE > General > "No Prompt"** under "At Start of Run (F5)" | Saves automatically when you press F5 |

IDLE indents 4 spaces for you after a line ending in `:`. Use spaces, not tabs, and keep indents lined up.

## VS Code (the other option)

VS Code works well and is also allowed at BPA. The lessons assume IDLE, but everything works the same way except how you run the program.

1. Install the **Python** extension (by Microsoft): click the Extensions icon on the left bar, search **Python**, click **Install**.
2. **File > Open Folder** and open the **step folder itself** (for example `bpaPrep\python_step09`). This matters: VS Code runs your program from the open folder, so data files must be in it.
3. Create the file: **File > New File**, save it as `step01.py`.
4. Click the **Run** button (the triangle at the top right). The output and any `input()` prompts appear in the **Terminal** panel at the bottom — type answers there.
5. Errors show in the Terminal as a traceback (read it the same way as above). VS Code also underlines problems in red before you run.

If VS Code asks you to "Select a Python interpreter," pick the Python 3 you installed.

## Pushing a step to your bpaPrep repo

You made the `bpaPrep` repo for BPA Fridays. Each step gets its own folder inside it: `python_step01`, `python_step02`, and so on.

1. Open **GitHub Desktop**. At the top left, make sure **Current repository** is `bpaPrep`. (If it isn't on this computer yet: **File > Clone repository**, pick `bpaPrep`, and click **Clone**.)
2. Click **Repository > Show in Explorer**. This opens the repo's folder.
3. Make a new folder named exactly `python_stepNN` (for example `python_step03`). Save your `.py` file (and any data or output files the step lists) in it.
4. Go back to GitHub Desktop. Your new files show in the **Changes** list on the left.
5. At the bottom left, type a summary like `Python step 3` and click **Commit to main**.
6. Click **Push origin** at the top.
7. On the Classroom **BPA Friday** assignment, add a private comment: *Python step 3 done*.

Check on github.com that your folder and file are there.

## The gitignore file

When Python runs some programs, it can make a folder named `__pycache__` with temporary files. You don't need to turn those in. To keep them out of your repo, create a file named `.gitignore` in the **top** of your `bpaPrep` folder (not inside a step folder) with this line:

```
__pycache__/
```

(In GitHub Desktop you can also right-click a `__pycache__` file in the Changes list and choose **Ignore folder**, which makes the file for you.)

## What is allowed at BPA

For **355 Python Programming**:
- **IDE:** your own computer with a local IDE — IDLE, VS Code, PyCharm, or Visual Studio. **No online interpreters** (no replit, no online Python sites).
- **Reference materials:** **printed** reference materials and **printed** code are allowed. Nothing electronic. **No old BPA tests**, even printed ones.
- **No internet, no AI.**
- **Your name and school must not be on your work.** Use your Contestant ID in the top comment.
- You submit a folder named with your Contestant ID, containing the program file named exactly as the test says, on a flash drive or as a zip upload.

Make sure Python and IDLE are installed and working on the laptop you'll bring **before** the day of the event.
