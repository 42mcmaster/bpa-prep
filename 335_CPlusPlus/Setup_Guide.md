# C++ Setup Guide (BPA 335)

This guide gets you from nothing installed to a running C++ program that is pushed to your `bpaPrep` repo. It assumes you have never used C++ or Visual Studio for C++. Do it once at the start. Come back to it when you forget where something is.

## Table of Contents
- [What you will use](#what-you-will-use)
- [For the teacher and IT](#for-the-teacher-and-it)
- [Install Visual Studio 2022 with C++](#install-visual-studio-2022-with-c)
- [Make your first program in Visual Studio](#make-your-first-program-in-visual-studio)
- [Run the program](#run-the-program)
- [Where your files are saved](#where-your-files-are-saved)
- [Where the program looks for data files](#where-the-program-looks-for-data-files)
- [Reading a compile error](#reading-a-compile-error)
- [Opening a starter file](#opening-a-starter-file)
- [Optional: set the C++ version to C++17](#optional-set-the-c-version-to-c17)
- [Alternative: VS Code and g++](#alternative-vs-code-and-g)
- [Push a step to your bpaPrep repo](#push-a-step-to-your-bpaprep-repo)
- [The .gitignore file](#the-gitignore-file)
- [What is allowed at BPA](#what-is-allowed-at-bpa)
- [Troubleshooting](#troubleshooting)

---

## What you will use

| Tool | What it is | Do you need it? |
|---|---|---|
| **Visual Studio 2022 Community** with the **Desktop development with C++** workload | The IDE (the program you type code in). It also has the C++ compiler (MSVC) built in. | **Yes.** This is the main tool for every lesson. |
| GitHub Desktop | Pushes your work to GitHub. | Yes (you already have it). |
| VS Code + MinGW-w64 `g++` | A lighter editor plus a different C++ compiler, run from the command line. | Optional. Use it only if Visual Studio is not available. |

A **compiler** turns your C++ code (text) into an `.exe` file (a program Windows can run). Python does not need this step, which is why C++ feels slower to start. In C++ the order is always: **write code, build (compile), run**. Visual Studio does the build for you when you press Ctrl+F5.

> **Visual Studio** (purple icon) and **Visual Studio Code** (blue icon) are two different programs. The lessons use Visual Studio (purple).

---

## For the teacher and IT

> **What IT must install on the lab Windows machines**
>
> 1. **Visual Studio 2022 Community** (free, from visualstudio.microsoft.com).
> 2. In the Visual Studio Installer, the workload **"Desktop development with C++"**. If Visual Studio is already installed for C# (".NET desktop development"), click **Modify** on Visual Studio 2022 and add this workload. It includes the MSVC v143 compiler and the Windows SDK. No other options are needed.
> 3. GitHub Desktop (already installed for class).
>
> Optional, only if a student will use the g++ route: VS Code, the Microsoft **C/C++** extension, and **MSYS2** with the MinGW-w64 UCRT g++ package, with `C:\msys64\ucrt64\bin` added to the PATH.
>
> Test: open Visual Studio, File > New > Project, search "Console App". If a **C++** Console App appears, the workload is installed.

---

## Install Visual Studio 2022 with C++

Skip this section if you are on a lab computer and IT has already done it. Do the test in the box above to check.

1. Open the **Visual Studio Installer** (search for it in the Start menu). If Visual Studio is not installed at all, download Visual Studio 2022 Community and run the installer.
2. Next to Visual Studio 2022, click **Modify**.
3. On the **Workloads** tab, check **Desktop development with C++**.
4. Click **Modify** (bottom right). It is a large download. Let it finish.
5. Open Visual Studio 2022.

---

## Make your first program in Visual Studio

Every step gets its own Visual Studio project. A **project** is a folder that holds your `.cpp` file plus some files Visual Studio needs. A **solution** is a container for one or more projects. For our work there is always one project in one solution.

1. Make sure you have your `bpaPrep` repo on this computer (GitHub Desktop: **File > Clone repository** if not). Note where it is, usually `C:\Users\<you>\Documents\GitHub\bpaPrep`.
2. Open Visual Studio 2022. Click **Create a new project**.
3. In the search box type `console`. Pick **Console App** with the tags **C++ / Windows / Console**. (Do not pick the C# one.) Click **Next**.
4. Fill in the form:
   - **Project name:** `cpp_step01` (change the number for each step)
   - **Location:** your `bpaPrep` folder (click the `...` button and browse to it)
   - Check **Place solution and project in the same directory**. This keeps everything in one folder.
5. Click **Create**.
6. Visual Studio opens a file named `cpp_step01.cpp` with a "Hello World!" program in it. This is the file you edit.
7. Rename the file so it matches the lesson: in **Solution Explorer** (the panel on the right; if you can't see it, use **View > Solution Explorer**), open **Source Files**, right-click `cpp_step01.cpp`, choose **Rename**, and type `step01.cpp`.
8. Delete the sample code and type your program.

Your first program, to check everything works:

```cpp
// Name: Your Name
// Date: today's date
// Program: Setup Test
// Description: Prints one line to prove Visual Studio can build and run C++.

#include <iostream>
using namespace std;

int main()
{
    // Output: one test line
    cout << "C++ is working!" << endl;
    return 0;
}
```

Step 1 explains every line of this.

---

## Run the program

| Keys | Menu | What it does |
|---|---|---|
| **Ctrl+F5** | Debug > Start Without Debugging | Builds and runs. **Use this one most of the time.** |
| F5 | Debug > Start Debugging | Builds and runs with the debugger attached (for stepping through code). |
| Ctrl+Shift+B | Build > Build Solution | Builds only (makes the `.exe`) without running. |

When you press **Ctrl+F5**:
1. The **Output** window at the bottom shows the build. Look for `Build: 1 succeeded, 0 failed`.
2. A black **console window** opens. That is where your program's output appears and where you type answers.
3. At the end it says `Press any key to close this window . . .`. Press a key to close it.

If you change the code, press Ctrl+F5 again. It rebuilds automatically.

---

## Where your files are saved

With the settings above, the folder looks like this:

```
bpaPrep/
└── cpp_step01/
    ├── cpp_step01.sln          <- the solution (double-click this to reopen the project)
    ├── cpp_step01.vcxproj      <- the project settings
    ├── step01.cpp              <- YOUR CODE
    └── x64/
        └── Debug/
            └── cpp_step01.exe  <- the program Visual Studio built
```

- To reopen your work later, double-click the `.sln` file, or use **File > Open > Project/Solution**.
- The `.exe` is the **executable**. BPA requires the executable in your submitted folder, so you will need to know where it is. It appears after the first build.
- The hidden `.vs` folder holds Visual Studio's own settings. You never need to touch it.

---

## Where the program looks for data files

Starting in Step 9 your programs read and write files like `scores.csv`. The code uses a **relative path** (just the file name, no `C:\...`). A relative path means "look in the **working directory**," which is the folder the program is running from.

| How you run it | Working directory | Put the data file here |
|---|---|---|
| Ctrl+F5 or F5 in Visual Studio | The **project folder** (where `step09.cpp` and the `.vcxproj` are) | `cpp_step09\scores.csv` |
| Double-clicking the `.exe` | The folder the `.exe` is in | `cpp_step09\x64\Debug\scores.csv` |
| g++ from the command line | The folder your terminal is in | Same folder you run `.\step09.exe` from |

For BPA, put a copy of the data file **in both** the project folder and next to the `.exe`. That way it works whether the grader runs it from Visual Studio or double-clicks the `.exe`.

To add an existing file to the project folder: copy it with File Explorer. To see the project folder quickly: right-click the project in Solution Explorer, **Open Folder in File Explorer**.

**Never** use a full path like `C:\Users\you\Desktop\scores.csv`. The grader's computer and flash drive letter are different, and the program will fail.

---

## Reading a compile error

C++ checks your whole program before it runs. If something is wrong, it does not run at all. You get errors instead.

Try it: delete the `;` at the end of the `cout` line in the test program and press Ctrl+F5. Visual Studio says there were build errors. Click **No** (do not run the last good build). The **Error List** window shows something like:

```
Code    Description                                     File         Line
C2143   syntax error: missing ';' before 'return'       step01.cpp   13
```

How to read it:
- **Code** (`C2143`) is the error number. You can search it later, but the description is usually enough.
- **Description** says what the compiler expected.
- **Line** is where the compiler **noticed** the problem. The real mistake is often on that line **or the line above it**. Here the `;` is missing at the end of line 12 (the `cout` line), but it is reported on line 13, because the compiler only realizes it is missing when it reaches the next statement.
- **Double-click the error** to jump to that line.

Fix the **first** error first. One mistake can cause a long list of follow-on errors that all disappear when you fix the first one.

Red squiggly underlines in the editor are Visual Studio guessing at errors before you build. Hover over them to read the message.

**Warnings** (yellow triangle) do not stop the program from running, but read them. They often point at a real bug.

---

## Opening a starter file

Step 12's timed builds give you a starter `.cpp` file. To use it:

1. Create a new Console App project the normal way (named as the instructions say).
2. Open the starter file on GitHub, click **Raw** (or the copy button), and copy all of it.
3. In Visual Studio, select all the template code in your `.cpp` file (Ctrl+A) and paste over it (Ctrl+V).
4. Rename the `.cpp` file in Solution Explorer if the instructions give it a required name.
5. Copy any data file (like `sales.csv`) into the project folder **and** next to the `.exe` (see above).

---

## Optional: set the C++ version to C++17

Visual Studio 2022 uses the C++14 standard by default. Everything in these lessons works with C++14, so you do not need to change it. If you want the newer standard:

1. Right-click the project in Solution Explorer > **Properties**.
2. At the top, set **Configuration** to **All Configurations**.
3. **Configuration Properties > C/C++ > Language > C++ Language Standard** > **ISO C++17 Standard (/std:c++17)**.
4. Click **OK**.

---

## Alternative: VS Code and g++

Use this only if Visual Studio is not available. Some students used `gcc` for C last year; `g++` is the C++ version of the same compiler.

1. Install **VS Code** and the Microsoft **C/C++** extension.
2. Install **MSYS2** (msys2.org). In the MSYS2 UCRT64 terminal run:
   `pacman -S mingw-w64-ucrt-x86_64-gcc`
3. Add `C:\msys64\ucrt64\bin` to your Windows PATH (Start > "Edit the system environment variables" > Environment Variables > Path > New). Close and reopen VS Code.
4. Check it: open a terminal in VS Code (**Terminal > New Terminal**) and type `g++ --version`.

Making and running a program:

1. In File Explorer make the folder `bpaPrep\cpp_step01`. In VS Code use **File > Open Folder** and open it.
2. Create `step01.cpp` and type your code.
3. In the VS Code terminal, compile:
   ```
   g++ -std=c++17 -Wall step01.cpp -o step01.exe
   ```
   - `-std=c++17` uses the C++17 standard.
   - `-Wall` turns on warnings (helpful hints about likely bugs).
   - `-o step01.exe` names the program file.
4. Run it:
   ```
   .\step01.exe
   ```
5. After every change, compile again, then run again.

A g++ error looks like this:

```
step01.cpp: In function 'int main()':
step01.cpp:12:38: error: expected ';' before 'return'
   12 |     cout << "C++ is working!" << endl
      |                                      ^
      |                                      ;
```

`step01.cpp:12:38` means file `step01.cpp`, **line 12, column 38**. g++ also draws the line and puts a `^` where it expected the `;`. Same advice as above: look at that line and the one before it, and fix the first error first.

---

## Push a step to your bpaPrep repo

Your `bpaPrep` repo has one folder per step: `cpp_step01`, `cpp_step02`, and so on. If you created the project inside the `bpaPrep` folder (as above), the folder is already in the right place.

1. Save everything in Visual Studio (**File > Save All**, Ctrl+Shift+S).
2. Open **GitHub Desktop**. Make sure **Current repository** (top left) is `bpaPrep`.
3. The **Changes** tab lists your new files. Check that `cpp_step01/step01.cpp` is there.
4. In the **Summary** box (bottom left) type `C++ step 1`.
5. Click **Commit to main**.
6. Click **Push origin** (top).
7. Check on github.com that the folder and `.cpp` file are there.
8. Post the private comment on the Google Classroom **BPA Friday** assignment: *C++ step 1 done*.

---

## The .gitignore file

Visual Studio makes large build files (the `x64` folder, the hidden `.vs` folder). They do not belong in GitHub. A file named `.gitignore` in the top of your `bpaPrep` repo tells GitHub Desktop to skip them.

Make it once:
1. In GitHub Desktop: **Repository > Repository settings > Ignored files**.
2. Paste these lines and click **Save**:

```
# Visual Studio build and settings folders
.vs/
x64/
Debug/
Release/

# Built programs and build leftovers
*.exe
*.obj
*.pdb
*.ilk
```

3. Commit the `.gitignore` file and push.

The `.sln`, `.vcxproj`, `.vcxproj.filters`, and your `.cpp` and data files are still pushed. That is what the teacher needs.

> This is only for your practice repo. **At BPA you submit the whole folder including the `.exe`.**

---

## What is allowed at BPA

For **335 C++ Programming**:

- You bring your own computer with one of these IDEs: **Visual Studio 2022**, Visual Studio Code, Dev-C++, or Code::Blocks.
- **Printed** reference materials and **printed code** are allowed. Print the reference guide and your best solutions.
- Nothing electronic beyond your IDE: no internet, no AI, no online compilers, no old BPA tests.
- Your **contestant ID** goes in a comment at the top of your code. Never your name or school.
- Use **relative file paths** only. The flash drive letter may change when it is graded.
- Submit the **whole project folder**, including the `.exe`, in a folder named with your contestant ID.
- **If the program does not run, the execution section scores zero.** Keep a version that runs at all times.

---

## Troubleshooting

| Problem | Fix |
|---|---|
| No C++ "Console App" when creating a project | The C++ workload is not installed. See [For the teacher and IT](#for-the-teacher-and-it). |
| The console window flashes and closes | You used F5 and the setting "Automatically close the console" is on. Use **Ctrl+F5** instead. |
| `error C4996: 'localtime': This function or variable may be unsafe` | Visual Studio's safety checks. Put `#define _CRT_SECURE_NO_WARNINGS` as the **very first line** of code (above the `#include` lines). Step 9 explains this. |
| `cannot open file 'cpp_step01.exe'` or `LNK1168` | The program is still running in another console window. Close that window and build again. |
| The file is not found (`Error: could not find scores.csv`) | The data file is not in the working directory. See [Where the program looks for data files](#where-the-program-looks-for-data-files). |
| GitHub Desktop shows hundreds of changed files | You do not have the `.gitignore` yet. Add it (above), then the build files disappear from the list. |
| "There were build errors. Would you like to continue and run the last successful build?" | Click **No**. Then read the Error List. |
| Two `main` functions error (`LNK2005 main already defined`) | You added a second `.cpp` file with its own `main` to the same project. Each step needs its own project. Remove the extra file from the project (right-click > Remove). |
