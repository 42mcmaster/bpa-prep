# Java Setup Guide (340 Java Programming)

This guide gets Java working on your computer and walks you through your first program. It assumes you have never used Java or VS Code for Java before.

## Table of Contents
- [What you need](#what-you-need)
- [For the teacher and IT](#for-the-teacher-and-it)
- [Installing at home](#installing-at-home)
- [Check that Java is installed](#check-that-java-is-installed)
- [Why we use single-file programs](#why-we-use-single-file-programs)
- [Your first program in VS Code](#your-first-program-in-vs-code)
- [What the parts of the program mean](#what-the-parts-of-the-program-mean)
- [Running from the command line](#running-from-the-command-line)
- [Where your files are saved](#where-your-files-are-saved)
- [Reading a compile error](#reading-a-compile-error)
- [Opening a folder of starter files](#opening-a-folder-of-starter-files)
- [Pushing a step to your bpaPrep repo](#pushing-a-step-to-your-bpaprep-repo)
- [The .gitignore file](#the-gitignore-file)
- [Other Java IDEs](#other-java-ides)
- [What is allowed at BPA](#what-is-allowed-at-bpa)
- [Troubleshooting](#troubleshooting)

---

## What you need

| Tool | What it is | Why you need it |
|---|---|---|
| **JDK 21 (Eclipse Temurin)** | The Java Development Kit. It has `javac` (the compiler) and `java` (the program that runs your code). | Without the JDK, nothing in Java runs. |
| **VS Code** | The code editor you already used for web pages. | You type and run your programs here. |
| **Extension Pack for Java** (by Microsoft) | A VS Code add-on that understands Java. | It gives you the **Run** button, red underlines for mistakes, and auto-complete. |
| **GitHub Desktop** | The app you already use to push to GitHub. | You turn in every step through your `bpaPrep` repo. |

"JDK" means Java Development Kit. You may also see "JRE" (Java Runtime Environment). The JRE can only *run* Java programs. You need the **JDK** because you are *writing* programs.

---

## For the teacher and IT

> **What IT needs to install on the lab Windows computers**
>
> 1. **Eclipse Temurin JDK 21 (LTS), Windows x64 `.msi` installer** from adoptium.net. During install, turn on these two options (they are off by default on some versions):
>    - **Set JAVA_HOME variable**
>    - **Add to PATH**
> 2. **Visual Studio Code** (already installed for web design).
> 3. The VS Code extension **Extension Pack for Java** (publisher: Microsoft, ID `vscjava.vscode-java-pack`). If extensions are installed per user, students can add it themselves from the Extensions panel.
> 4. **GitHub Desktop** (already installed).
>
> **How to check it worked:** open Command Prompt and type `java -version` and then `javac -version`. Both should print a version number that starts with `21`.
>
> Nothing else is needed. No Maven, no Gradle, no IntelliJ.

---

## Installing at home

1. Go to **adoptium.net**. Click the download for **Temurin 21 (LTS)** for your system (Windows, Mac, or Linux). On Windows choose the `.msi` file.
2. Run the installer. On the "Custom Setup" screen, click **Set JAVA_HOME variable** and **Add to PATH** and pick "Will be installed on local hard drive" for both.
3. Install **VS Code** from code.visualstudio.com if you do not have it.
4. Open VS Code. Click the **Extensions** icon on the left side (it looks like four squares). Search for **Extension Pack for Java**. Click **Install** on the one by Microsoft.
5. Close and reopen VS Code.

---

## Check that Java is installed

1. Open a terminal. In VS Code: **Terminal > New Terminal**. (On Windows you can also use Command Prompt.)
2. Type this and press Enter:
   ```
   java -version
   ```
   You should see something like:
   ```
   openjdk version "21.0.5" 2024-10-15 LTS
   OpenJDK Runtime Environment Temurin-21.0.5+11 (build 21.0.5+11-LTS)
   ```
3. Then type:
   ```
   javac -version
   ```
   You should see `javac 21.0.5` (your numbers after 21 may be different).

If you see `'java' is not recognized as an internal or external command`, Java is not on the PATH. See [Troubleshooting](#troubleshooting).

---

## Why we use single-file programs

At the BPA Java event you must put your **whole solution in one folder named with your Contestant ID**. The test warns that "advanced IDEs" (like IntelliJ or Eclipse) put files into several folders, and the graders will **not** fix that for you. If the graders cannot find and run your code, the execution section scores zero.

So in this class every program is **one `.java` file in one folder**. No projects, no packages, no build tools. You open the folder in VS Code, write the file, and click Run. It is simple, and it is exactly what you will turn in at BPA.

---

## Your first program in VS Code

Follow these steps exactly the first time.

1. **Make a folder.** In File Explorer, inside your `bpaPrep` repo folder, make a new folder named `java_practice`.
2. **Open the folder in VS Code.** In VS Code click **File > Open Folder...**, pick `java_practice`, and click **Select Folder**. If VS Code asks "Do you trust the authors of the files in this folder?", click **Yes, I trust the authors**.
3. **Make a new file.** In the Explorer panel on the left, hover over the folder name and click the **New File** icon. Name it exactly:
   ```
   Hello.java
   ```
   Capital `H`. The `.java` ending matters.
4. **Type this program** (type it, do not paste it - typing it is how you learn it):
   ```java
   // Name: Your Name
   // Date: today's date
   // Program: Hello
   // Description: My first Java program. It prints two lines.

   public class Hello {
       public static void main(String[] args) {
           System.out.println("Hello, BPA!");
           System.out.println("Java is working.");
       }
   }
   ```
5. **Save** with **Ctrl+S**.
6. **Run it.** Wait a few seconds the first time (the bottom bar says "Java: Activating..." and then "Java: Ready"). Then you will see the words **Run | Debug** appear just above the `public static void main` line. Click **Run**. You can also click the **triangle (Run) button** in the top right corner of the editor.
7. **Look at the output.** A **Terminal** panel opens at the bottom of the window. You will see a long command that VS Code ran for you, and then:
   ```
   Hello, BPA!
   Java is working.
   ```

That is your first Java program.

---

## What the parts of the program mean

Step 1 explains this again in more detail. Here is the short version.

| What you type | What it means |
|---|---|
| `// ...` | A comment. Java ignores everything after `//` on that line. |
| `public class Hello {` | Every Java program lives inside a **class**. This class is named `Hello`. The `{` starts the class. |
| `public static void main(String[] args) {` | The **main method**. Java starts running your program here. Every program you run needs exactly this line. |
| `System.out.println("...");` | Print the text and then go to a new line. |
| `;` | Every statement ends with a semicolon. |
| `}` | Ends a block. The first `}` ends `main`, the last one ends the class. |

**The file name must match the class name.** A `public class Hello` must be in a file named `Hello.java`, with the same capital letters. If they do not match, you get this error:

```
Hi.java:1: error: class Hello is public, should be declared in a file named Hello.java
public class Hello {
       ^
```

---

## Running from the command line

VS Code's Run button runs two commands for you. You should know how to run them yourself. It helps when something goes wrong, and it works on any computer that has the JDK.

1. Open a terminal in VS Code (**Terminal > New Terminal**). It opens in the folder you have open.
2. **Compile** the program (turn your `.java` file into a `.class` file the computer can run):
   ```
   javac Hello.java
   ```
   If there are no errors, nothing prints. A new file named `Hello.class` appears in the folder.
3. **Run** the program. Use the class name only - **no** `.java` or `.class` on the end:
   ```
   java Hello
   ```
   Output:
   ```
   Hello, BPA!
   Java is working.
   ```

| Command | What it does |
|---|---|
| `javac Hello.java` | Compiles. Checks for errors and makes `Hello.class`. |
| `java Hello` | Runs the compiled class `Hello`. |
| `java Hello.java` | Shortcut (Java 11 and newer): compiles and runs a single file in one step, without making a `.class` file. |

If you change the code, you must run `javac` again before `java`, or you will run the old version.

---

## Where your files are saved

- Your `.java` files are saved in the folder you opened in VS Code.
- When you run from the command line, `javac` puts the `.class` file in the same folder.
- When your program **reads or writes a file** (Step 9 and later), Java looks in the **working directory**. When you click Run in VS Code, the working directory is the **folder you opened** with File > Open Folder. That is why you should always **open the step folder itself** (for example `java_step09`), not the whole `bpaPrep` repo. Then `scores.csv` in that folder is found, and `report.txt` is written there.

---

## Reading a compile error

Java checks your whole program **before** it runs. If something is wrong, it will not run at all. This is called a **compile error**.

Here is a program with a missing semicolon on line 3:

```java
public class Oops {
    public static void main(String[] args) {
        System.out.println("Missing semicolon")
    }
}
```

`javac Oops.java` prints:

```
Oops.java:3: error: ';' expected
        System.out.println("Missing semicolon")
                                               ^
1 error
```

How to read it:

| Part | Meaning |
|---|---|
| `Oops.java` | The file with the problem. |
| `:3:` | The **line number**. Go to line 3. (VS Code shows line numbers on the left. **Ctrl+G** jumps to a line.) |
| `error: ';' expected` | What Java expected to find. |
| The `^` mark | Where on the line Java noticed the problem. |

In VS Code, you will also see a **red squiggly underline** under the problem, and the **Problems** panel (**View > Problems**) lists every error. Hover your mouse over the red line to see the message.

**Tip:** fix the **first** error first. One mistake (like a missing `}`) can cause many errors further down. Fix the first one, save, and check again.

If you click Run while there is an error, VS Code may ask **"Build failed, do you want to continue?"**. Click **Fix...** (or Cancel) and fix the error. Do not click Proceed - it will run an old version or fail.

---

## Opening a folder of starter files

For timed builds you get a starter `.java` file and sometimes a `.csv` data file.

1. Download the files from the GitHub repo (click the file, then the **Download raw file** button).
2. Make your turn-in folder (for example `java_timed02`) in your `bpaPrep` repo and move the files into it.
3. In VS Code: **File > Open Folder...** and pick that folder.
4. Open the `.java` file from the Explorer panel on the left, and click **Run** to check that the starter runs before you change anything.

---

## Pushing a step to your bpaPrep repo

You already have a `bpaPrep` repo. Each step goes in its own folder named `java_stepNN` (for example `java_step01`).

1. In File Explorer, make the folder `java_step01` inside your `bpaPrep` folder.
2. Save `Step01.java` in it (open that folder in VS Code and create the file there).
3. Open **GitHub Desktop**. Make sure **Current repository** (top left) is `bpaPrep`.
4. On the left you will see your new file(s) listed under **Changes**.
5. At the bottom left, type a summary like `Java step 1` and click **Commit to main**.
6. Click **Push origin** at the top.
7. Check the repo on github.com to see the folder is there.
8. In Google Classroom, on the **BPA Friday** assignment, add a private comment: *Java step 1 done*.

---

## The .gitignore file

When you compile from the command line, `.class` files appear next to your `.java` files. The graders and your teacher only need the `.java` files. To stop GitHub Desktop from listing `.class` files, add a file named `.gitignore` (with the dot, and no other ending) in the top of your `bpaPrep` folder with these lines:

```
# Java compiled files
*.class

# VS Code settings folders
.vscode/
```

If GitHub Desktop already shows a `.gitignore` in your repo (from the C# steps, for example), open it and add these lines at the bottom.

---

## Other Java IDEs

BPA lets you use IntelliJ, Eclipse, NetBeans, BlueJ, or VS Code. You do not need any of them except VS Code. If you already know one of the others, that is fine, but:

- They usually want a "project" with `src`, `bin`, or `out` folders and sometimes a package name at the top of the file (`package something;`).
- At BPA, all your files must be in **one** folder named with your Contestant ID. If you use one of these IDEs, copy the **whole project folder** into your Contestant ID folder, and make sure the `.java` file is in it.
- A `package` line at the top changes how the program is run. Leave it out in this class.

---

## What is allowed at BPA

For **340 Java Programming**:

- 90 minutes to build one program.
- You bring your own computer with a local Java IDE (IntelliJ, Eclipse, NetBeans, BlueJ, or VS Code). **No online compilers.**
- **Printed** reference materials and **printed** code are allowed. Nothing electronic. No old BPA tests.
- No internet, no AI.
- Your Contestant ID goes in a comment at the top of the program - **never your name or school**.
- Your solution goes in a folder named with your Contestant ID on the flash drive they give you.
- Use **relative** file paths (just `"data.csv"`, never `"C:\\Users\\..."`) because the flash drive letter may change when it is graded.

Print the lessons in this folder and the [340 Java Competition Reference](340_Java_Competition_Reference.md) and bring them.

---

## Troubleshooting

| Problem | Fix |
|---|---|
| `'java' is not recognized...` or `javac: command not found` | The JDK is not on the PATH. Re-run the Temurin installer and turn on **Add to PATH**. Close and reopen VS Code and the terminal. |
| No **Run** link above `main` | Wait for the bottom bar to say "Java: Ready". Check that the Extension Pack for Java is installed. Check the file ends in `.java`. |
| `class X is public, should be declared in a file named X.java` | Rename the file or the class so they match exactly, including capital letters. |
| `error: could not find or load main class Step01` | You ran `java Step01.java` or `java Step01.class` the wrong way, or you are in the wrong folder. Use `java Step01` in the folder that has `Step01.class`. |
| Program cannot find `scores.csv` | You opened the wrong folder. Open the step folder itself with **File > Open Folder**, and put the `.csv` file in that folder. |
| "Build failed, do you want to continue?" | Some `.java` file in the open folder has an error. Look in the **Problems** panel, fix it, and run again. |
| VS Code shows errors in a file you are not working on | VS Code compiles every `.java` file in the open folder. Keep one program per folder. |
