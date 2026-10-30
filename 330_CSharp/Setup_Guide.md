# C# Setup Guide (Visual Studio 2022)

Read this before Step 1. It shows you how to make a C# project in Visual Studio, run it, read an error, and push your work to GitHub. You used Visual Studio for the Pac-Man game, so some of this will look familiar.

## Table of Contents
- [What you need](#what-you-need)
- [For the teacher and IT](#for-the-teacher-and-it)
- [The two kinds of projects we use](#the-two-kinds-of-projects-we-use)
- [Make your first console project](#make-your-first-console-project)
- [What Visual Studio made for you](#what-visual-studio-made-for-you)
- [Run the program](#run-the-program)
- [Where your files are saved](#where-your-files-are-saved)
- [Reading an error](#reading-an-error)
- [Open a project or starter files](#open-a-project-or-starter-files)
- [Make a Windows Forms project (Step 11 and later)](#make-a-windows-forms-project-step-11-and-later)
- [Push a step to your bpaPrep repo](#push-a-step-to-your-bpaprep-repo)
- [The .gitignore file](#the-gitignore-file)
- [What is allowed at BPA](#what-is-allowed-at-bpa)

## What you need

| Tool | What it is for |
|---|---|
| **Visual Studio 2022 Community** (purple icon, not "Visual Studio Code") | Writing, running, and debugging C# programs. It also has the Windows Forms designer. |
| **.NET desktop development** workload | The part of Visual Studio that does C#, console apps, and Windows Forms. It includes .NET 8. |
| **GitHub Desktop** | Pushing your work to your `bpaPrep` repo. |

Visual Studio and Visual Studio Code are two different programs. **Visual Studio** (purple) is the big one we use for C#. **VS Code** (blue) is the one you use for web pages.

## For the teacher and IT

> **What IT needs to install on the lab Windows machines**
> - Visual Studio 2022 Community (17.8 or newer) with the **".NET desktop development"** workload checked. This workload includes the .NET 8 SDK and Windows Forms.
> - GitHub Desktop.
> - To check a machine: open Visual Studio → **Create a new project** → type `console` in the search box. You should see **Console App** with a **C#** tag and **Windows Forms App** with a **C#** tag. If you only see "(.NET Framework)" versions, .NET 8 is missing.
> - If students also take C++, add the "Desktop development with C++" workload too (Visual Studio Installer → Modify).

## The two kinds of projects we use

| Steps | Project type | What it looks like |
|---|---|---|
| Steps 1–10 | **Console App** | Text in a black window. You type answers, the program prints results. |
| Step 11 and timed build 2 | **Windows Forms App** | A real window with text boxes, labels, list boxes, and buttons. This is what the BPA event uses. |

In the "Create a new project" list there are look-alike templates that end in **(.NET Framework)**. Do **not** pick those. Pick the plain **Console App** and **Windows Forms App** that have the **C#** tag.

## Make your first console project

Do this once now to practice. You will make a new project the same way for every step.

1. Open **Visual Studio 2022**. On the start screen click **Create a new project**.
2. In the search box type `console`. Click **Console App** (the one with the **C#** tag — not Visual Basic, not .NET Framework). Click **Next**.
3. On **Configure your new project**:
   - **Project name:** `Step01`
   - **Location:** click the `...` button and pick a folder named `csharp_step01` inside your `bpaPrep` repo folder (make the folder if it is not there).
   - Check **Place solution and project in the same directory**. This keeps all the files in one folder.
   - Click **Next**.
4. On **Additional information**:
   - **Framework:** `.NET 8.0 (Long Term Support)`
   - Check **Do not use top-level statements**. This is important. It gives you the full program structure (`class Program` and `static void Main`) that every lesson uses.
   - Leave "Enable native AOT publish" unchecked.
   - Click **Create**.

## What Visual Studio made for you

Visual Studio opens `Program.cs` with this code in it:

```csharp
namespace Step01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

Step 1 explains every line. For now:
- `Program.cs` is the file you edit. Your code goes inside `Main`, between its `{` and `}`.
- The window on the right is **Solution Explorer**. It lists the files in your project. Double-click `Program.cs` there if you ever close it.
- If you forgot to check "Do not use top-level statements", the file will only have one line: `Console.WriteLine("Hello, World!");`. Delete the project and make it again with the box checked, so your code matches the lessons.

## Run the program

| What you press | What it does |
|---|---|
| **Ctrl+F5** (Debug → Start Without Debugging) | Builds and runs the program. The console window stays open at the end so you can read the output. Use this most of the time. |
| **F5** or the green **▶ Step01** button | Builds and runs with the debugger. Also fine. |
| **Shift+F5** | Stops a running program. |

A black console window opens. It shows what your program prints. At the end it says something like:

```text
Hello, World!

C:\Users\you\bpaPrep\csharp_step01\Step01\bin\Debug\net8.0\Step01.exe (process 5120) exited with code 0.
Press any key to close this window . . .
```

The last two lines come from Visual Studio, not your program. Press a key to close the window, then go back to your code.

**Important:** close the console window before you run again. If an old one is still open, Visual Studio may not be able to rebuild the `.exe`.

## Where your files are saved

With the settings above, your project folder looks like this:

```text
bpaPrep/
└── csharp_step01/
    └── Step01/
        ├── Step01.sln          (the "solution" - double-click it to open the project)
        ├── Step01.csproj       (the project settings)
        ├── Program.cs          (YOUR CODE)
        ├── bin/
        │   └── Debug/
        │       └── net8.0/
        │           └── Step01.exe   (the program Visual Studio built)
        └── obj/                (temporary build files)
```

- `Program.cs` is your code. This is what graders read.
- `bin\Debug\net8.0\` is where the `.exe` is built. When your program reads or writes a file with a relative path (Step 9 and later), it looks **in this folder**. Step 9 explains how to get your data file there.
- `bin` and `obj` are rebuilt every time you run. You do not push them (see [The .gitignore file](#the-gitignore-file)).

## Reading an error

If your code has a mistake that stops it from building, Visual Studio:
1. Puts a **red squiggly line** under the problem.
2. Shows a box: "There were build errors. Would you like to continue and run the last successful build?" — click **No**. Fix the error first.
3. Lists the error in the **Error List** window (View → Error List if you can't see it).

Here is what the Error List shows if you forget a semicolon at the end of line 7:

| Code | Description | Project | File | Line |
|---|---|---|---|---|
| CS1002 | ; expected | Step01 | Program.cs | 7 |

How to read it:
- **Description** says what C# expected. `; expected` means a semicolon is missing.
- **Line** is where C# noticed the problem. The real mistake is on that line or **the line just above it**.
- **Double-click the row** and Visual Studio jumps to that spot.
- Fix the **first** error first. One mistake can cause a pile of extra errors below it. Fixing the first one often makes the rest disappear.

Yellow squiggles and **warnings** (yellow triangle) do not stop the program from running. Red ones (errors) do.

Turn on line numbers if you don't see them: **Tools → Options → Text Editor → C# → General → Line numbers**.

## Open a project or starter files

- **Open your own project again:** File → Open → Project/Solution, then pick the `.sln` file. Or double-click the `.sln` file in File Explorer.
- **Use a starter `.cs` file from a lesson:** make a new project the normal way, then open the starter file in Notepad (or on GitHub), copy all of it, and paste it over the code in `Program.cs`. Change the `namespace` line to match your project name if they are different.
- **Add an existing file (like a `.csv` data file) to a project:** in Solution Explorer right-click the project name (`Step09`) → **Add** → **Existing Item…** → change the file type box to **All Files (\*.\*)** → pick the file.

## Make a Windows Forms project (Step 11 and later)

1. **Create a new project** → search `windows forms` → pick **Windows Forms App** with the **C#** tag (not ".NET Framework", not Visual Basic) → **Next**.
2. Name it (for example `Step11`), set the location to your `csharp_step11` folder, check **Place solution and project in the same directory** → **Next**.
3. Framework: **.NET 8.0** → **Create**.
4. Visual Studio opens **Form1.cs [Design]** — a picture of your empty window. Step 11 teaches the rest.

The built program for a Forms project lands in `bin\Debug\net8.0-windows\` (note the `-windows`).

## Push a step to your bpaPrep repo

You already have a `bpaPrep` repo. If it is not on this computer yet, open GitHub Desktop → **File → Clone repository** → pick `bpaPrep` → choose where to put it (for example `Documents\GitHub\bpaPrep`).

After you finish a step:

1. **Close Visual Studio** (or at least stop the program). This makes sure everything is saved.
2. Open **GitHub Desktop**. Make sure **Current repository** (top left) says `bpaPrep`.
3. The left side lists the changed files. You should see files like `csharp_step01/Step01/Program.cs`. You should **not** see hundreds of files in `bin/` or `obj/` — if you do, add the `.gitignore` first (next section).
4. At the bottom left, type a summary like `C# step 1` and click **Commit to main**.
5. Click **Push origin** at the top.
6. Check on github.com that the folder is there.
7. Post the private comment on the Classroom **BPA Friday** assignment: *C# step 1 done*.

## The .gitignore file

`bin`, `obj`, and `.vs` are folders Visual Studio rebuilds every time. They are big and you never push them. A `.gitignore` file tells GitHub Desktop to skip them. You only do this once for the whole repo.

1. In GitHub Desktop: **Repository → Repository settings… → Ignored files**.
2. Paste this in, then click **Save**:

```text
# Visual Studio build output and settings - do not push these
bin/
obj/
.vs/
*.user
```

3. Commit the new `.gitignore` file and push it like any other change.

## What is allowed at BPA

- **Software:** Visual Studio 2019 or newer. Your own laptop or the provided computer, depending on the site.
- **Printed** reference materials and **printed** code are allowed. Nothing electronic. No old BPA tests. No internet, no AI.
- Put your **contestant ID** in a comment at the top of your main code file (`Form1.cs` at the 2026 regional). Never your name or school.
- Make a folder named with your contestant ID on the flash drive and copy your **whole project folder** into it.
- Use **relative file paths** only (`"sales.csv"`, not `"C:\Users\you\sales.csv"`). The flash drive letter may be different when it is graded.
- If the program does not run when time is up, the execution section scores zero. Keep a version that runs at all times.
