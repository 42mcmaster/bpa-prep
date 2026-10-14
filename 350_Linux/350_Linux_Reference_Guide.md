# BPA 350 — Linux Operating System Fundamentals Reference Guide

*Competition study and exam reference — MCCC IT Academy*

The BPA 350 regional exam is **50 multiple-choice questions, 2 points each, 60 minutes**. Most questions ask one of three things: *"Which command does this job?"*, *"What does this command do?"*, or *"Which file or directory holds this?"*. The later questions are short scenarios ("You need to... which command should you use?").

**You may bring printed reference materials into the test.** The 2026-27 guidelines list "published and/or unpublished non-electronic written reference materials" under what the contestant supplies. Print this guide. You may NOT bring old BPA tests or sample tests.

Every section ends with **On the exam** — how that topic usually gets asked.

---

## Table of Contents

1. [Exam Strategy](#1-exam-strategy)
2. [Linux Big Picture and Vocabulary](#2-linux-big-picture-and-vocabulary)
3. [Shell Basics and Getting Help](#3-shell-basics-and-getting-help)
4. [The Linux Directory Layout](#4-the-linux-directory-layout)
5. [Moving Around and Managing Files](#5-moving-around-and-managing-files)
6. [Viewing and Searching Text](#6-viewing-and-searching-text)
7. [Pipes and Redirection](#7-pipes-and-redirection)
8. [Text Editors: vi and nano](#8-text-editors-vi-and-nano)
9. [Permissions and Ownership](#9-permissions-and-ownership)
10. [Users and Groups](#10-users-and-groups)
11. [Processes and Jobs](#11-processes-and-jobs)
12. [Services and systemd](#12-services-and-systemd)
13. [Scheduling Tasks: cron and at](#13-scheduling-tasks-cron-and-at)
14. [Disks, Partitions, and File Systems](#14-disks-partitions-and-file-systems)
15. [Archives, Compression, and Checksums](#15-archives-compression-and-checksums)
16. [Installing Software: Package Managers](#16-installing-software-package-managers)
17. [Installation, Boot Process, and GRUB](#17-installation-boot-process-and-grub)
18. [Networking Commands and Files](#18-networking-commands-and-files)
19. [Remote Access and File Transfer](#19-remote-access-and-file-transfer)
20. [Firewalls and System Security](#20-firewalls-and-system-security)
21. [Printing](#21-printing)
22. [Environment Variables and Shell Scripting](#22-environment-variables-and-shell-scripting)
23. [Logs, Date and Time, and Troubleshooting](#23-logs-date-and-time-and-troubleshooting)
24. [Acronym Bank](#24-acronym-bank)
25. [Look-Alike Commands: The Trap List](#25-look-alike-commands-the-trap-list)
26. [Quick Reference Card](#26-quick-reference-card)

---

## 1. Exam Strategy

- **Time:** 50 questions in 60 minutes is about 70 seconds each. "What does this acronym stand for" questions should take 10 seconds. Save the time for scenario questions.
- **Most wrong answers are real commands that do a different job.** `df` and `du` are both real. `chmod` and `chown` are both real. The test checks whether you know which is which. [Section 25](#25-look-alike-commands-the-trap-list) lists the pairs that get mixed up most.
- **Some wrong answers are made up.** `checkfs`, `rmuser`, `meminfo`, `ownfile` are not real commands. If you have never seen it in this guide, be suspicious.
- **Read the whole scenario.** "List files" and "list files *including hidden files*" have different answers (`ls` vs `ls -a`).
- **Options matter.** Know what the common letters mean: `-a` all, `-l` long, `-r` or `-R` recursive, `-f` force or follow, `-h` human-readable, `-v` verbose.
- **Use the Quick Reference Card** ([Section 26](#26-quick-reference-card)) during the test. It is organized by job ("I need to...") so you can find a command fast.

---

## 2. Linux Big Picture and Vocabulary

### What Linux is

**Linux** is a free, open-source operating system kernel first released by **Linus Torvalds** in **1991**. It is modeled on **UNIX**. The source code is released under the **GPL** (GNU General Public License), which lets anyone use, change, and share it.

| Term | Meaning |
|---|---|
| **Kernel** | The core of the operating system. It talks to the hardware and manages memory, processes, and devices. |
| **Shell** | The program that reads the commands you type and runs them. The most common shell is **bash** (Bourne Again SHell). Others: sh, zsh, ksh, csh. |
| **Terminal** | The window where you type commands into the shell. |
| **Distribution (distro)** | The kernel plus tools, a package manager, and usually a desktop, bundled together. |
| **GNU** | The project that wrote most of the command-line tools Linux uses. "GNU's Not Unix." |
| **Open source** | The source code is public. Anyone can read it, change it, and share it. |
| **root** | The administrator account. It can do anything. Its user ID (UID) is **0**. |
| **CLI / GUI** | Command Line Interface / Graphical User Interface. |
| **Daemon** | A program that runs in the background as a service. Names often end in `d`: `sshd`, `crond`, `cupsd`. |

### Distribution families

This matters because **each family uses a different package manager** (see [Section 16](#16-installing-software-package-managers)).

| Family | Examples | Package format | Package tools |
|---|---|---|---|
| **Debian** | Debian, Ubuntu, Linux Mint, Kali | `.deb` | `apt`, `apt-get`, `dpkg` |
| **Red Hat** | RHEL, Fedora, CentOS, Rocky, AlmaLinux | `.rpm` | `dnf`, `yum`, `rpm` |
| **SUSE** | openSUSE, SLES | `.rpm` | `zypper`, `rpm` |
| **Arch** | Arch, Manjaro | `.pkg.tar.zst` | `pacman` |

### The prompt

```text
student@lab-pc:~$        <- a normal user.  $ means regular user.
root@lab-pc:/etc#        <- the root user.  # means root.

student   = the user name
lab-pc    = the hostname (the computer's name)
~         = the current directory (~ is a shortcut for your home directory)
```

### Linux is case sensitive

`File.txt`, `file.txt`, and `FILE.TXT` are three different files. Commands are lowercase. `LS` does not work; `ls` does.

**On the exam:** who created Linux, what the kernel does, what a shell is, what UID root has (0), `$` vs `#` in the prompt, and which distro belongs to which family.

---

## 3. Shell Basics and Getting Help

### Command structure

```text
command  -options  arguments

ls       -la       /etc
│         │         └── what to act on (a file, directory, user name...)
│         └──────────── how to do it (options, also called flags or switches)
└────────────────────── what to do
```

Short options use one dash and can be combined: `ls -l -a` is the same as `ls -la`. Long options use two dashes: `ls --all`.

### Getting help

| Command | What it does |
|---|---|
| `man ls` | Opens the **manual page** for `ls`. Press `q` to quit, `/word` to search. |
| `ls --help` | Prints a short help summary. |
| `info ls` | A longer, linked help document. |
| `whatis ls` | One-line description of a command. |
| `apropos copy` | Searches manual pages for a keyword. Same as `man -k copy`. |
| `which ls` | Shows the full path of the program that will run (`/usr/bin/ls`). |
| `type ls` | Tells you if a command is a program, an alias, or built into the shell. |

Manual pages are split into numbered sections. The ones to know: **1** = user commands, **5** = file formats (like `/etc/passwd`), **8** = system administration commands.

### Keyboard shortcuts

| Keys | What happens |
|---|---|
| **Ctrl+C** | **Stops (kills)** the running program. Sends the SIGINT signal. |
| **Ctrl+Z** | **Pauses (suspends)** the running program and puts it in the background, stopped. Sends SIGTSTP. Bring it back with `fg`. |
| **Ctrl+D** | Sends "end of input." At an empty prompt it logs you out. |
| **Ctrl+L** | Clears the screen (same as `clear`). |
| **Ctrl+A / Ctrl+E** | Jump to the start / end of the line. |
| **Ctrl+R** | Search back through your command history. |
| **Tab** | Auto-completes a command or file name. |
| **Up arrow** | Previous command. |

### History

```bash
history          # list the commands you have typed
!!               # run the last command again
!42              # run command number 42 from the history list
!ls              # run the most recent command that started with "ls"
sudo !!          # run the last command again, this time with sudo
```

Your history is saved in the file `~/.bash_history`.

### Running more than one command

```bash
cmd1 ; cmd2      # run cmd1, then cmd2, no matter what
cmd1 && cmd2     # run cmd2 ONLY IF cmd1 worked
cmd1 || cmd2     # run cmd2 ONLY IF cmd1 failed
cmd1 &           # run cmd1 in the background
```

**On the exam:** Ctrl+C vs Ctrl+Z is a favorite. Ctrl+C **ends** the program. Ctrl+Z **suspends** it. Also: which command opens the manual (`man`), and what `&&` does.

---

## 4. The Linux Directory Layout

Linux has **one** directory tree. It starts at **`/`**, called the **root directory**. There are no drive letters. Extra disks and USB drives are attached ("mounted") to a directory inside the tree.

Do not mix up `/` (the root *directory*, top of the tree) with `/root` (the root *user's* home directory).

```text
/
├── bin      essential user commands (ls, cp, cat)
├── sbin     essential system admin commands (fdisk, fsck, reboot)
├── boot     kernel and boot loader files (vmlinuz, initramfs, grub/)
├── dev      device files (/dev/sda, /dev/null, /dev/tty)
├── etc      system-wide CONFIGURATION files and startup scripts
├── home     regular users' home directories (/home/maria)
├── root     the root user's home directory
├── lib      shared libraries needed by /bin and /sbin
├── media    mount point for removable media (USB, DVD)
├── mnt      temporary mount point for the admin to use
├── opt      optional, add-on software
├── proc     virtual files about processes and the kernel (/proc/cpuinfo)
├── sys      virtual files about hardware and devices
├── tmp      temporary files, often cleared at reboot
├── usr      installed programs, libraries, documentation (/usr/bin, /usr/share)
├── var      VARIABLE data that changes: logs, mail, print queues, caches
│   └── log  system LOG files
└── srv      data for services the system provides (web, FTP)
```

### The directories that get asked about most

| Directory | Remember it as |
|---|---|
| `/etc` | **Configuration.** Almost every settings file lives here: `/etc/passwd`, `/etc/fstab`, `/etc/hostname`, `/etc/hosts`. System startup scripts and init files are here too (`/etc/init.d`, `/etc/systemd`). |
| `/var/log` | **Logs.** `/var/log/syslog` or `/var/log/messages`, `/var/log/auth.log`. |
| `/home` | Users' personal files. |
| `/boot` | The kernel and GRUB. |
| `/dev` | Hardware shows up as files. First SATA/SCSI disk = `/dev/sda`, its first partition = `/dev/sda1`. |
| `/proc` | Not real files on disk. Live information from the kernel. `/proc/meminfo`, `/proc/cpuinfo`. |
| `/tmp` | Anyone can write here. Do not store anything you need to keep. |
| `/bin` vs `/sbin` | `/bin` = commands for everyone. `/sbin` = commands for the system administrator. |

### Special devices in /dev

| Device | What it is |
|---|---|
| `/dev/null` | The "black hole." Anything sent to it is thrown away. |
| `/dev/zero` | Gives an endless stream of zeros. |
| `/dev/random`, `/dev/urandom` | Give random data. |
| `/dev/sda`, `/dev/sdb` | First and second disk. `/dev/sda1` = first partition on the first disk. |
| `/dev/nvme0n1` | First NVMe solid-state drive. |
| `/dev/tty` | Terminals. |

### Paths

- **Absolute path:** starts with `/` and works from anywhere. `/home/maria/notes.txt`
- **Relative path:** starts from where you are now. `notes.txt` or `../maria/notes.txt`

| Shortcut | Means |
|---|---|
| `.` | the current directory |
| `..` | the parent directory (one level up) |
| `~` | your home directory |
| `~maria` | maria's home directory |
| `-` | (with `cd`) the directory you were in before |

**On the exam:** "Which directory stores log files?" (`/var/log`). "Which directory holds configuration files?" (`/etc`). "Where is the kernel?" (`/boot`). "Where are device files?" (`/dev`).

---

## 5. Moving Around and Managing Files

### Where am I, and what is here?

```bash
pwd              # Print Working Directory: shows where you are
cd /etc          # Change Directory to /etc
cd               # with nothing after it: go to your home directory
cd ..            # go up one level
cd -             # go back to the previous directory
ls               # list files in the current directory
```

### ls options

| Option | What it adds |
|---|---|
| `ls -l` | **Long** format: permissions, owner, group, size, date. |
| `ls -a` | **All** files, including **hidden** files. A hidden file's name starts with a dot: `.bashrc`. |
| `ls -h` | **Human-readable** sizes (K, M, G). Use with `-l`: `ls -lh`. |
| `ls -R` | **Recursive**: also lists everything inside subdirectories. |
| `ls -t` | Sort by **time** modified, newest first. |
| `ls -r` | **Reverse** the sort order. |
| `ls -S` | Sort by **size**, largest first. |
| `ls -d */` | List directories themselves, not what is inside them. |
| `ls -i` | Show each file's **inode** number. |

Reading one line of `ls -l`:

```text
-rw-r--r--  1  maria  staff  2048  Sep 12 09:30  notes.txt
│└───┬───┘  │    │      │      │         │          └── file name
│    │      │    │      │      │         └── last modified
│    │      │    │      │      └── size in bytes
│    │      │    │      └── group owner
│    │      │    └── user owner
│    │      └── number of hard links
│    └── permissions (see Section 9)
└── file type:  - regular file   d directory   l symbolic link
                c character device   b block device
```

### Creating, copying, moving, deleting

```bash
touch report.txt          # create an empty file (or update a file's timestamp)
mkdir projects            # make a directory
mkdir -p a/b/c            # make a directory AND any missing parent directories

cp file1 file2            # copy file1 to file2
cp -r dir1 dir2           # copy a directory and everything in it (recursive)
cp -p file1 file2         # copy and PRESERVE permissions, owner, timestamps
cp -i file1 file2         # ask before overwriting (interactive)

mv old.txt new.txt        # RENAME a file (Linux has no separate rename step)
mv file.txt /tmp/         # MOVE a file to another directory

rm file.txt               # remove (delete) a file
rm -i file.txt            # ask first
rm -r projects            # remove a directory AND everything in it, recursively
rm -rf projects           # same, and force: never ask, ignore errors. Dangerous.
rmdir emptydir            # remove a directory ONLY IF it is empty
```

There is **no recycle bin** on the command line. `rm` is permanent.

### Links

A **link** is a second name that points to a file.

```bash
ln file.txt hard.txt        # HARD link: a second name for the same data (same inode)
ln -s file.txt soft.txt     # SYMBOLIC (soft) link: a shortcut that points to the file's path
```

| | Hard link | Symbolic link |
|---|---|---|
| Made with | `ln` | `ln -s` |
| Points to | the file's data (inode) | the file's name/path |
| Works across different file systems? | No | Yes |
| Can link to a directory? | No | Yes |
| If the original is deleted | still works | **breaks** ("dangling" link) |
| Shows in `ls -l` as | a normal file, link count goes up | `l` at the start and `soft.txt -> file.txt` |

An **inode** is the record the file system keeps for each file: its size, owner, permissions, timestamps, and where its data is on disk. The inode does **not** hold the file's name.

### Information about a file

```bash
file photo.jpg       # tells you what TYPE of file it is, by looking at the contents
stat notes.txt       # full details: size, inode, permissions, and all three timestamps
                     #   Access (last read), Modify (contents changed), Change (inode changed)
wc notes.txt         # Word Count: lines, words, and bytes
wc -l notes.txt      # just the number of lines
```

### Wildcards (globbing)

The shell fills these in before the command runs.

| Pattern | Matches | Example |
|---|---|---|
| `*` | any number of characters (including none) | `ls *.txt` = every file ending in .txt |
| `?` | exactly one character | `ls file?.txt` = file1.txt, fileA.txt |
| `[abc]` | one character from the list | `ls file[123].txt` |
| `[a-z]` | one character from the range | `ls [a-c]*` |
| `[!abc]` | one character NOT in the list | `ls [!0-9]*` |
| `{a,b}` | each item in turn | `touch file{1,2,3}.txt` makes three files |

**On the exam:** `ls -a` for hidden files. `rm -r` removes a directory and its contents. `mv` is how you rename. `mkdir -p` makes parent directories. `stat` shows a file's modification time in detail. `cp -r` to copy a directory.

---

## 6. Viewing and Searching Text

### Viewing files

| Command | What it does |
|---|---|
| `cat file` | Prints the whole file to the screen at once. Also joins files: `cat a b > c`. |
| `tac file` | Like `cat`, but last line first. |
| `less file` | Opens the file one screen at a time. You can scroll **up and down** and search with `/word`. Press `q` to quit. Safest way to look at a file you do not trust, because it does not dump raw control characters to your terminal. |
| `more file` | Older pager. Moves **forward** one screen at a time. |
| `head file` | The **first 10** lines. `head -n 5 file` = the first 5. |
| `tail file` | The **last 10** lines. `tail -n 20 file` = the last 20. |
| `tail -f file` | **Follow**: keeps the file open and prints new lines as they are added. This is how you watch a log file live. |
| `nl file` | Prints the file with line numbers. |

"less is more": `less` does everything `more` does, plus scrolling backward.

### grep: search INSIDE files

`grep` prints the **lines** that contain a pattern.

```bash
grep "error" app.log          # lines containing "error"
grep -i "error" app.log       # -i  ignore upper/lower case
grep -v "debug" app.log       # -v  inVert: lines that do NOT match
grep -n "error" app.log       # -n  show line numbers
grep -c "error" app.log       # -c  count the matching lines
grep -r "TODO" ~/projects     # -r  recursive: search every file under a directory
grep -l "TODO" *.py           # -l  list only the NAMES of files that match
grep -w "cat" pets.txt        # -w  whole word only (not "category")
grep -E "cat|dog" pets.txt    # -E  extended regular expressions (same as egrep)
```

Regular expression basics used with `grep`:

| Symbol | Meaning | Example |
|---|---|---|
| `^` | start of the line | `grep "^root" /etc/passwd` |
| `$` | end of the line | `grep "bash$" /etc/passwd` |
| `.` | any one character | `grep "h.t"` matches hat, hot, hit |
| `*` | zero or more of the thing before it | `grep "lo*l"` matches ll, lol, lool |
| `[abc]` | any one of these characters | `grep "[Ll]inux"` |

### find: search for FILES by name, type, size, time, or owner

`find` looks through a directory tree live. It is slow on big trees but always up to date.

```bash
find . -name "*.txt"             # files ending in .txt, here and in all subdirectories
find /home -iname "report*"      # -iname ignores case
find /var -type d                # -type d = directories,  -type f = files,  -type l = links
find / -user maria               # files owned by maria
find / -size +100M               # files larger than 100 MB
find /tmp -mtime -1              # modified less than 1 day ago
find /tmp -mtime +30             # modified more than 30 days ago
find . -perm 777                 # files with exactly these permissions
find . -name "*.tmp" -delete     # find them and delete them
find . -name "*.log" -exec rm {} \;   # run a command on each result; {} is the file name
```

Always put the pattern in quotes so the shell does not expand the `*` before `find` sees it.

### locate, which, whereis

| Command | What it searches | Notes |
|---|---|---|
| `find` | the real directory tree, right now | slow, always accurate, many filters |
| `locate name` | a pre-built **database** of file names | very fast; can be out of date. Refresh the database with `updatedb`. |
| `which cmd` | your `PATH` | shows which program runs when you type `cmd` |
| `whereis cmd` | standard system locations | shows the program, its source, and its man page |

### Cutting, sorting, and counting text

```bash
sort names.txt            # sort lines A to Z
sort -r names.txt         # reverse order
sort -n numbers.txt       # sort as numbers (so 10 comes after 9)
sort -u names.txt         # sort and remove duplicates
uniq names.txt            # remove duplicate lines THAT ARE NEXT TO EACH OTHER (sort first)
uniq -c names.txt         # also count how many times each line appeared
cut -d: -f1 /etc/passwd   # cut field 1, using : as the delimiter -> list of user names
tr 'a-z' 'A-Z' < file     # translate characters: lowercase to uppercase
diff file1 file2          # show the lines that differ between two files
sed 's/cat/dog/g' file    # stream editor: replace every "cat" with "dog"
awk '{print $1}' file     # print the first column of every line
```

**On the exam:** `tail -f` to watch a log in real time. `head` = first lines, `tail` = last lines. `grep` searches **inside** files; `find` searches for files **by name**. `find . -name "*.txt"` is the standard pattern. `grep -i` ignores case, `grep -v` inverts, `grep -r` is recursive.

---

## 7. Pipes and Redirection

Every program has three standard streams:

| Stream | Number | Default |
|---|---|---|
| **stdin** (standard input) | 0 | the keyboard |
| **stdout** (standard output) | 1 | the screen |
| **stderr** (standard error) | 2 | the screen |

### Redirection

| Symbol | What it does |
|---|---|
| `>` | Send stdout to a file. **Overwrites** the file. |
| `>>` | Send stdout to a file. **Appends** to the end. |
| `<` | Read stdin from a file. |
| `2>` | Send stderr (error messages) to a file. |
| `2>&1` | Send stderr to the same place as stdout. |
| `&>` | Send both stdout and stderr to a file. |
| `> /dev/null` | Throw the output away. |

```bash
ls -l > list.txt              # save the listing (replaces list.txt)
echo "done" >> log.txt        # add a line to the end of log.txt
find / -name "*.conf" 2> /dev/null    # hide the "Permission denied" errors
sort < names.txt              # feed names.txt to sort
command > out.txt 2>&1        # save normal output AND errors in out.txt
```

### Pipes

A **pipe** `|` sends the **output of one command into the input of the next**.

```bash
ls -l | less                  # page through a long listing
cat /etc/passwd | wc -l       # count how many user accounts exist
ps -ef | grep sshd            # find the sshd process
history | tail -n 5           # last 5 commands
sort names.txt | uniq -c | sort -rn    # count duplicates, most common first
```

`tee` splits the output: it writes to a file **and** still shows it on screen.

```bash
ls -l | tee list.txt          # see the listing AND save it
```

`xargs` takes output and turns it into arguments for another command:

```bash
find . -name "*.tmp" | xargs rm      # delete every file that find printed
```

**On the exam:** `>` overwrites, `>>` appends. `|` connects two commands. `2>` redirects errors. `/dev/null` discards output.

---

## 8. Text Editors: vi and nano

### nano

`nano file.txt` opens a simple editor. The commands are listed at the bottom of the screen. `^` means the Ctrl key.

| Keys | Action |
|---|---|
| Ctrl+O | Write **O**ut (save) |
| Ctrl+X | Exit |
| Ctrl+W | **W**here is (search) |
| Ctrl+K | Cut the current line |
| Ctrl+U | Paste ("uncut") |

### vi / vim

`vi` is on almost every Linux system. `vim` means "vi improved." It has **modes**, and that is what the exam asks about.

| Mode | What it is for | How to get there |
|---|---|---|
| **Command (normal) mode** | moving around, deleting, copying. vi **starts** in this mode. | press **Esc** |
| **Insert mode** | typing text | press `i`, `a`, or `o` |
| **Ex (last-line) mode** | saving, quitting, search and replace | type `:` from command mode |

Getting into insert mode:

| Key | Starts typing... |
|---|---|
| `i` | before the cursor (insert) |
| `a` | after the cursor (append) |
| `o` | on a new line below |
| `O` | on a new line above |
| `A` | at the end of the line |

Saving and quitting (type these in command mode, then press Enter):

| Command | Action |
|---|---|
| `:w` | **w**rite (save) |
| `:q` | **q**uit (fails if you have unsaved changes) |
| `:wq` or `:x` or `ZZ` | save and quit |
| `:q!` | quit and **throw away** changes |
| `:w newname` | save as a different file |

Editing in command mode:

| Key | Action |
|---|---|
| `h` `j` `k` `l` | left, down, up, right |
| `x` | delete one character |
| `dd` | delete (cut) the current line. `3dd` cuts three lines. |
| `dw` | delete a word |
| `yy` | yank (copy) the current line |
| `p` | paste after the cursor |
| `u` | undo |
| `gg` / `G` | go to the first / last line. `10G` goes to line 10. |
| `/word` | search forward. `n` = next match. |
| `?word` | search backward |
| `:%s/old/new/g` | replace every "old" with "new" in the whole file |
| `:set number` | show line numbers |

**On the exam:** "How do you save and quit vi?" (`:wq`). "Quit without saving?" (`:q!`). "Which key enters insert mode?" (`i`). "Which key deletes a line?" (`dd`). "Which key returns to command mode?" (Esc).

---

## 9. Permissions and Ownership

Every file has an **owner (user)**, a **group**, and three sets of permissions.

### Reading a permission string

```text
- rwx r-x r--
│  │   │   └── OTHER  (everyone else):      read only
│  │   └────── GROUP  (the file's group):   read and execute
│  └────────── USER   (the file's owner):   read, write, execute
└───────────── file type ( - file, d directory, l link )
```

| Letter | On a file | On a directory |
|---|---|---|
| `r` read | view the contents | list the file names inside |
| `w` write | change the contents | create, delete, and rename files inside |
| `x` execute | run it as a program | enter it with `cd` |

### Octal (number) permissions

Each permission has a value. Add them up for each set.

```text
r = 4     w = 2     x = 1

rwx = 4+2+1 = 7
rw- = 4+2   = 6
r-x = 4+1   = 5
r-- = 4     = 4
--- =         0
```

| Octal | String | Common use |
|---|---|---|
| `777` | `rwxrwxrwx` | everyone can do everything (unsafe) |
| `755` | `rwxr-xr-x` | programs, scripts, directories |
| `750` | `rwxr-x---` | owner full, group read/enter, others nothing |
| `700` | `rwx------` | private directory or script |
| `644` | `rw-r--r--` | normal files: owner edits, everyone reads |
| `640` | `rw-r-----` | owner edits, group reads |
| `600` | `rw-------` | private file (SSH keys) |
| `400` | `r--------` | owner read only |

### chmod: change permissions (mode)

```bash
# Number method: set all three at once
chmod 755 script.sh           # rwxr-xr-x
chmod 644 notes.txt           # rw-r--r--

# Letter method:  who (u g o a)   + - =   what (r w x)
chmod u+x script.sh           # add execute for the user (owner)
chmod g-w notes.txt           # remove write from the group
chmod o=r notes.txt           # set other to exactly read
chmod a+r notes.txt           # a = all three
chmod ug+rw,o-rwx file        # several changes at once
chmod -R 750 projects         # -R = recursive: the directory and everything in it
```

### chown and chgrp: change ownership

```bash
chown maria file.txt          # change the OWNER to maria
chown maria:staff file.txt    # change owner AND group
chown :staff file.txt         # change only the group
chgrp staff file.txt          # change only the group
chown -R maria /home/maria    # recursive
```

Only **root** (or `sudo`) can give a file to a different owner.

### umask: default permissions for NEW files

The **umask** is *subtracted* from the starting permissions. New files start at `666`. New directories start at `777`.

```text
umask 022   ->   files 644 (rw-r--r--)     directories 755 (rwxr-xr-x)
umask 027   ->   files 640 (rw-r-----)     directories 750 (rwxr-x---)
umask 077   ->   files 600 (rw-------)     directories 700 (rwx------)
```

Type `umask` to see the current value. `022` is the usual default.

### Special permissions

| Name | Octal | Looks like | What it does |
|---|---|---|---|
| **SUID** (Set User ID) | `4000` | `rws` in the **user** set | The program runs with the permissions of the file's **owner**. Example: `/usr/bin/passwd` is owned by root so a normal user can change their own password. |
| **SGID** (Set Group ID) | `2000` | `rws` in the **group** set | On a program: runs with the file's group. On a **directory**: new files inside inherit the directory's group. |
| **Sticky bit** | `1000` | `t` at the end: `rwxrwxrwt` | On a directory: only a file's **owner** (or root) can delete it, even if everyone can write there. `/tmp` uses this. |

```bash
chmod 4755 program       # SUID
chmod 2775 shared_dir    # SGID
chmod 1777 /tmp          # sticky bit
chmod u+s program        # SUID, letter method
chmod +t shared_dir      # sticky bit, letter method
```

### ACLs: Access Control Lists

Normal permissions allow only one owner and one group. An **ACL** lets you give rights to **extra** users or groups.

```bash
getfacl report.txt                  # show the ACL
setfacl -m u:jordan:rw report.txt   # -m = modify: give user jordan read and write
setfacl -m g:interns:r report.txt   # give the group interns read
setfacl -x u:jordan report.txt      # -x = remove jordan's entry
setfacl -b report.txt               # -b = remove ALL ACL entries
```

A `+` at the end of the permission string in `ls -l` (`-rw-r--r--+`) means the file has an ACL.

**On the exam:** convert between `rwxr-xr--` and `754`. `chmod` = permissions, `chown` = owner, `chgrp` = group. What umask `022` produces. What the sticky bit does on `/tmp`. What SUID means.

---

## 10. Users and Groups

### The account files

| File | What is in it | Who can read it |
|---|---|---|
| `/etc/passwd` | one line per **user account** | everyone |
| `/etc/shadow` | the **encrypted (hashed) passwords** and password aging rules | root only |
| `/etc/group` | one line per **group** and its members | everyone |
| `/etc/gshadow` | group passwords | root only |
| `/etc/sudoers` | who may use `sudo`. Edit it only with **`visudo`**. | root only |
| `/etc/skel` | template files copied into every **new** user's home directory | |
| `/etc/login.defs` | defaults for new accounts (UID ranges, password aging) | |

One line of `/etc/passwd` has **seven fields** separated by colons:

```text
maria:x:1001:1001:Maria Lopez:/home/maria:/bin/bash
  │   │   │    │       │          │           └── 7 login shell
  │   │   │    │       │          └── 6 home directory
  │   │   │    │       └── 5 comment (full name), called the GECOS field
  │   │   │    └── 4 primary group ID (GID)
  │   │   └── 3 user ID (UID)
  │   └── 2 password placeholder: x means "look in /etc/shadow"
  └── 1 user name
```

UID ranges: **0** = root. **1-999** = system and service accounts. **1000 and up** = regular users (on most modern distros).

### Managing users

```bash
useradd jordan                 # create a user (low-level tool; may not make a home directory)
useradd -m jordan              # -m = also create the home directory /home/jordan
useradd -m -s /bin/bash -G staff jordan    # set the shell and an extra group
adduser jordan                 # friendlier, interactive version on Debian/Ubuntu

passwd jordan                  # set or change jordan's password
passwd                         # change YOUR OWN password
passwd -l jordan               # lock the account
passwd -u jordan               # unlock it

usermod -aG sudo jordan        # ADD jordan to the sudo group (keeps the groups jordan already has)
usermod -L jordan              # lock the account
usermod -s /bin/zsh jordan     # change the login shell
usermod -l newname jordan      # change the login name

userdel jordan                 # delete the account, KEEP the home directory
userdel -r jordan              # delete the account AND remove the home directory

chage -l jordan                # list password aging information
chage -M 90 jordan             # password must be changed every 90 days
```

**`usermod -aG` is the one to memorize.** `-G` sets the list of extra groups. `-a` means **append**. Without `-a`, the user is **removed from every other extra group**.

Giving a user administrator rights means adding them to the admin group: `sudo` on Debian/Ubuntu, `wheel` on Red Hat/Fedora.

### Managing groups

```bash
groupadd developers            # create a group
groupdel developers            # delete a group
groupmod -n devs developers    # rename a group
gpasswd -a jordan developers   # add a user to a group
gpasswd -d jordan developers   # remove a user from a group
groups jordan                  # list the groups jordan belongs to
```

Every user has one **primary group** (field 4 in `/etc/passwd`) and any number of **secondary (supplementary) groups** (listed in `/etc/group`).

### Who am I? Who is logged in?

| Command | Shows |
|---|---|
| `whoami` | your user name |
| `id` | your UID, GID, and all your groups |
| `who` | who is logged in right now |
| `w` | who is logged in **and what they are doing** |
| `last` | history of logins |
| `lastb` | history of **failed** logins |

### Becoming another user

```bash
sudo command        # run ONE command as root. Asks for YOUR password. Logged.
sudo -i             # start a root shell
su - jordan         # switch user to jordan. Asks for JORDAN'S password.
su -                # switch to root. Asks for ROOT'S password.
                    # the dash means "full login": load that user's environment
```

`sudo` is preferred over logging in as root: each user keeps their own password, access can be limited to certain commands, and every use is logged.

**On the exam:** `useradd` creates, `usermod` modifies (including adding to a group), `userdel` deletes. Hashed passwords are in `/etc/shadow`. `usermod -aG sudo name` gives admin rights. `visudo` edits the sudoers file. Root has UID 0.

---

## 11. Processes and Jobs

A **process** is a running program. Each one has a **PID** (process ID) and a **PPID** (parent process ID: the process that started it). The first process is **PID 1**: `systemd` on modern systems, `init` on older ones.

### Looking at processes

| Command | What it shows |
|---|---|
| `ps` | only the processes in your current terminal |
| `ps -ef` | **every** process, **full** format. Columns include **UID, PID, PPID**, start time, command. This is the one that shows the parent PID. |
| `ps aux` | every process, BSD style. Columns include USER, PID, **%CPU, %MEM**, command. Does not show PPID. |
| `ps -u maria` | processes owned by maria |
| `pstree` | processes drawn as a tree of parents and children |
| `top` | **live**, updating view sorted by CPU use. Also shows load average and memory. `q` quits, `k` kills. |
| `htop` | a nicer, color version of `top` (may need installing) |
| `pgrep firefox` | prints just the **PID(s)** of processes with that name |
| `pidof firefox` | same idea: PID of a named program |
| `lsof` | **L**i**s**t **O**pen **F**iles, and which process has each one open. `lsof -i :80` shows what is using port 80. |
| `uptime` | how long the system has been up, and the load average |
| `free -h` | memory and **swap** in use and free |

### Stopping processes: signals

`kill` sends a **signal** to a process. It does not always "kill."

| Signal | Number | Meaning |
|---|---|---|
| `SIGHUP` | 1 | Hang up. Many daemons reload their configuration. |
| `SIGINT` | 2 | Interrupt. What **Ctrl+C** sends. |
| `SIGKILL` | **9** | **Force** kill. Cannot be caught or ignored. Last resort. |
| `SIGTERM` | **15** | Terminate politely. The **default** signal for `kill`. Lets the program clean up. |
| `SIGCONT` | 18 | Continue a stopped process. |
| `SIGSTOP` / `SIGTSTP` | 19 / 20 | Pause. **Ctrl+Z** sends SIGTSTP. |

```bash
kill 1234            # send SIGTERM (15) to PID 1234
kill -9 1234         # force kill
kill -SIGKILL 1234   # same thing, by name
kill -l              # list every signal
killall firefox      # kill every process NAMED firefox
pkill firefox        # same idea, matches by pattern
```

### Foreground and background jobs

```bash
sleep 300 &          # & at the end starts the command in the BACKGROUND
jobs                 # list this shell's background and stopped jobs
fg %1                # bring job 1 to the FOREGROUND
bg %1                # let stopped job 1 keep running in the BACKGROUND
Ctrl+Z               # suspend the foreground job
nohup script.sh &    # keep running even after you log out
```

### Priority: nice

Each process has a **nice value** from **-20 (highest priority)** to **19 (lowest priority)**. The default is 0. A "nicer" process gives up more CPU time to others. Only root can set a negative value.

```bash
nice -n 10 backup.sh         # START a program with nice value 10
renice -n 5 -p 1234          # CHANGE the nice value of a program that is already running
```

**On the exam:** `pgrep` finds a PID by name. `ps -ef` shows PPID. `top` is the live view. `kill -9` forces. The default kill signal is 15 (SIGTERM). `free` shows memory and swap. `lsof` lists open files. `&` runs in the background. Nice ranges from -20 to 19.

---

## 12. Services and systemd

Modern distributions use **systemd** to start the system and manage services. A service is described by a **unit file** (for example `sshd.service`). The command to control systemd is **`systemctl`**.

```bash
systemctl status sshd        # is it running? shows recent log lines too
systemctl start sshd         # start it NOW
systemctl stop sshd          # stop it now
systemctl restart sshd       # stop, then start
systemctl reload sshd        # re-read the config file without stopping
systemctl enable sshd        # start it automatically AT BOOT
systemctl disable sshd       # do not start it at boot
systemctl enable --now sshd  # enable AND start in one step
systemctl is-active sshd     # prints active or inactive
systemctl is-enabled sshd    # prints enabled or disabled
systemctl list-units --type=service    # list services
systemctl daemon-reload      # re-read unit files after you edit one
```

**`start` and `enable` are different.** `start` = run it now. `enable` = run it at every boot. A service can be one without the other.

Older systems (SysVinit) used `service sshd start` and `chkconfig sshd on`. Those scripts lived in `/etc/init.d`.

### Targets and runlevels

A systemd **target** is a system state. Targets replaced the older numbered **runlevels**.

| Runlevel | systemd target | State |
|---|---|---|
| 0 | `poweroff.target` | shut down |
| 1 | `rescue.target` | single-user mode, for repair |
| 3 | `multi-user.target` | full system, **text** login, networking |
| 5 | `graphical.target` | full system with the **GUI** |
| 6 | `reboot.target` | reboot |

```bash
systemctl get-default                     # which target the system boots into
systemctl set-default multi-user.target   # boot to text mode from now on
systemctl isolate rescue.target           # switch to a target right now
```

### Shutting down

```bash
shutdown -h now          # halt (power off) right now
shutdown -r now          # reboot right now
shutdown -h +10          # power off in 10 minutes
shutdown -c              # cancel a scheduled shutdown
reboot                   # reboot
poweroff                 # power off
halt                     # stop the system
```

**On the exam:** `systemctl enable` = at boot; `systemctl start` = now. Runlevel 3 = multi-user text, 5 = graphical, 0 = halt, 6 = reboot. PID 1 is systemd.

---

## 13. Scheduling Tasks: cron and at

### cron: tasks that REPEAT

The **cron** daemon (`crond`) runs commands on a schedule. Each user has a **crontab** (cron table).

```bash
crontab -e           # edit your crontab
crontab -l           # list your crontab
crontab -r           # REMOVE your whole crontab (careful: -r is next to -e)
crontab -u maria -l  # root can view another user's crontab
```

Each line has **five time fields**, then the command:

```text
┌───────── minute         (0-59)
│ ┌─────── hour           (0-23)
│ │ ┌───── day of month   (1-31)
│ │ │ ┌─── month          (1-12)
│ │ │ │ ┌─ day of week    (0-7, where 0 and 7 are both Sunday)
│ │ │ │ │
* * * * *  command to run
```

Remember the order: **M**inute **H**our **D**ay-of-month **M**onth **D**ay-of-week.

| Entry | Runs |
|---|---|
| `30 2 * * * /home/maria/backup.sh` | every day at 2:30 AM |
| `0 * * * * cmd` | at the top of every hour |
| `*/15 * * * * cmd` | every 15 minutes |
| `0 8 * * 1-5 cmd` | 8:00 AM, Monday through Friday |
| `0 0 1 * * cmd` | midnight on the 1st of every month |
| `0 6,18 * * * cmd` | at 6:00 AM and 6:00 PM |
| `@reboot cmd` | once, each time the system starts |
| `@daily cmd` | once a day (same as `0 0 * * *`) |

Symbols: `*` = every value. `,` = a list. `-` = a range. `/` = a step.

System-wide cron files: `/etc/crontab`, `/etc/cron.d/`, and the folders `/etc/cron.hourly`, `/etc/cron.daily`, `/etc/cron.weekly`, `/etc/cron.monthly`. The files `/etc/cron.allow` and `/etc/cron.deny` control which users may use cron.

**anacron** runs daily, weekly, and monthly jobs that were **missed** because the computer was turned off. Good for laptops.

### at: a task that runs ONCE

```bash
at 3:00 PM             # then type the commands, and press Ctrl+D to finish
at now + 2 hours
atq                    # list your waiting at jobs
atrm 3                 # remove at job number 3
```

**On the exam:** cron = repeating jobs; at = one time. `crontab -e` edits. Know the five fields in order. Be able to read a line like `0 3 * * 0` (3:00 AM every Sunday).

---

## 14. Disks, Partitions, and File Systems

### Device names

```text
/dev/sda      first SATA / SCSI / USB disk
/dev/sda1     first partition on that disk
/dev/sda2     second partition
/dev/sdb      second disk
/dev/nvme0n1p1   first partition on the first NVMe drive
/dev/sr0      optical (CD/DVD) drive
```

### Partition tables

| | **MBR** (Master Boot Record) | **GPT** (GUID Partition Table) |
|---|---|---|
| Age | older | newer |
| Largest disk | 2 TB | far larger (zettabytes) |
| Partitions | 4 primary (or 3 primary + 1 extended holding logical partitions) | 128 by default |
| Goes with | BIOS | UEFI |

### Partitioning and formatting commands

| Command | Job |
|---|---|
| `lsblk` | **L**i**s**t **bl**oc**k** devices as a tree: disks, partitions, sizes, mount points. |
| `blkid` | Show each partition's **UUID** and file system type. |
| `fdisk /dev/sda` | **Create and manage partitions** (classic tool, MBR and GPT). `fdisk -l` just lists them. |
| `gdisk` | Like fdisk, for GPT disks. |
| `parted` | Partition tool that handles large GPT disks and can resize. |
| `mkfs -t ext4 /dev/sdb1` | **M**a**k**e a **f**ile **s**ystem (format a partition). Same as `mkfs.ext4 /dev/sdb1`. |
| `mkswap /dev/sdb2` | Format a partition as swap. |
| `swapon /dev/sdb2` | Start using a swap area. `swapoff` stops. `swapon -s` shows swap in use. |
| `fsck /dev/sdb1` | **F**ile **s**ystem **c**hec**k**: check and repair a file system. Run it on an **unmounted** file system. |
| `tune2fs` | Adjust settings on ext2/3/4 file systems. |
| `e2label`, `xfs_admin -L` | Set a file system label. |

### File system types

| Type | Notes |
|---|---|
| **ext4** | The standard Linux file system. **Journaling.** Default on Debian/Ubuntu. |
| ext3 | Older. Added journaling to ext2. |
| ext2 | Oldest. **No journal.** |
| **XFS** | High-performance journaling file system. Default on RHEL. |
| Btrfs | Newer: snapshots, built-in RAID, copy-on-write. |
| **swap** | Disk space used as overflow when RAM is full. Not mounted to a directory. |
| vfat / FAT32, exFAT | USB sticks; readable by Windows. The EFI system partition is FAT32. |
| NTFS | Windows file system. |
| NFS | **N**etwork **F**ile **S**ystem: share directories between Linux/UNIX machines. |
| CIFS / SMB | Windows-style network shares. **Samba** is the Linux software for SMB. |
| iso9660 | CDs and DVDs. |
| tmpfs, proc, sysfs | Virtual file systems that live in memory. |

A **journal** records changes before they are made, so the file system can recover quickly after a crash or power loss.

### Mounting

To use a file system you **mount** it on a directory (the **mount point**).

```bash
mount                          # list everything that is mounted
mount /dev/sdb1 /mnt/usb       # attach the partition at /mnt/usb
mount -t ext4 /dev/sdb1 /data  # say the type yourself
mount -o ro /dev/sdb1 /mnt     # -o gives options: ro = read only
umount /mnt/usb                # detach. NOTE THE SPELLING: umount, not "unmount"
mount -a                       # mount everything listed in /etc/fstab
findmnt                        # tree view of mounts
```

### /etc/fstab: what gets mounted at boot

**fstab** = **f**ile **s**ystem **tab**le. Six fields per line:

```text
UUID=3e6b...9f   /home   ext4   defaults   0   2
     │             │      │        │       │   └── 6 fsck order (0 = skip, 1 = root, 2 = others)
     │             │      │        │       └── 5 dump (backup) flag, almost always 0
     │             │      │        └── 4 mount options (defaults, ro, noexec, nofail...)
     │             │      └── 3 file system type
     │             └── 2 mount point
     └── 1 the device: by UUID, by LABEL, or by /dev name
```

A **UUID** is preferred because `/dev/sdb` can become `/dev/sdc` if disks are added or moved. The UUID never changes.

### How full is it?

| Command | Answers | Memory trick |
|---|---|---|
| `df -h` | How much space is used and **free on each file system (disk)**? | **d**isk **f**ree |
| `du -sh /var/log` | How much space does **this directory** take up? | **d**isk **u**sage |
| `free -h` | How much **RAM and swap** is used and free? | |

`-h` = human-readable. For `du`, `-s` = summary (one total, not every subfolder). `df -i` shows **inode** usage: a disk can be "full" because it ran out of inodes while space remains.

### LVM: Logical Volume Manager

LVM puts a flexible layer between the disks and the file systems, so you can **resize** volumes and **combine** several disks into one pool.

```text
Physical Volumes (PV)   ->   Volume Group (VG)   ->   Logical Volumes (LV)
  real disks or              a pool made from         the "partitions" you format
  partitions                 one or more PVs          and mount. Easy to grow.
```

| Layer | Create | List |
|---|---|---|
| Physical volume | `pvcreate /dev/sdb1` | `pvs`, `pvdisplay` |
| Volume group | `vgcreate vg_data /dev/sdb1` | `vgs`, `vgdisplay` |
| Logical volume | `lvcreate -L 20G -n lv_home vg_data` | `lvs`, `lvdisplay` |

Grow a logical volume with `lvextend`, then grow the file system inside it (`resize2fs` for ext4, `xfs_growfs` for XFS). LVM also supports **snapshots**.

### RAID

**RAID** = Redundant Array of Independent Disks. Linux software RAID is managed with **`mdadm`**.

| Level | How it works | Minimum disks | Survives a failed disk? |
|---|---|---|---|
| RAID 0 | **striping**: data split across disks for speed | 2 | No |
| RAID 1 | **mirroring**: every disk holds a full copy | 2 | Yes |
| RAID 5 | striping with **parity** | 3 | Yes, one |
| RAID 6 | striping with double parity | 4 | Yes, two |
| RAID 10 | mirrored pairs, then striped | 4 | Yes |

**On the exam:** `df` = free space on disks; `du` = size of a directory. `fdisk` creates and manages partitions. `mkfs` formats. `fsck` checks and repairs. `mount` / `umount`. `/etc/fstab` lists what mounts at boot. LVM = Logical Volume Manager. `free` shows swap.

---

## 15. Archives, Compression, and Checksums

**Archiving** = putting many files into one file. **Compressing** = making a file smaller. `tar` archives; `gzip`, `bzip2`, and `xz` compress. `tar` can call them for you.

### tar (tape archive)

Pick **one action letter**, add option letters, and end with **`f` followed by the archive name**.

| Letter | Meaning |
|---|---|
| `c` | **c**reate an archive |
| `x` | e**x**tract an archive |
| `t` | lis**t** the contents (table of contents) |
| `r` | append files to an existing archive |
| `f` | **f**ile: the next word is the archive's name. Almost always needed. |
| `v` | **v**erbose: print each file name as it is processed |
| `z` | compress with g**z**ip -> `.tar.gz` or `.tgz` |
| `j` | compress with bzip2 -> `.tar.bz2` |
| `J` | compress with xz -> `.tar.xz` |
| `p` | **p**reserve permissions |
| `C dir` | change to `dir` before extracting |

```bash
tar -cvf  backup.tar      projects/     # create, not compressed
tar -czvf backup.tar.gz   projects/     # create + gzip   (a "tarball")
tar -cjvf backup.tar.bz2  projects/     # create + bzip2
tar -czvpf backup.tar.gz  projects/     # create + gzip + preserve permissions
tar -xzvf backup.tar.gz                 # extract a gzip tarball
tar -xvf  backup.tar -C /restore        # extract into /restore
tar -tvf  backup.tar                    # list what is inside, without extracting
```

Say it out loud: **c**reate **z**ipped **v**erbose **f**ile. e**x**tract **z**ipped **v**erbose **f**ile.

### Compression tools

| Tool | Extension | Compress | Decompress | Notes |
|---|---|---|---|---|
| gzip | `.gz` | `gzip file` | `gunzip file.gz` or `gzip -d` | Fast. **Replaces** the original file. One file only, not directories. |
| bzip2 | `.bz2` | `bzip2 file` | `bunzip2 file.bz2` | Smaller output than gzip, slower. |
| xz | `.xz` | `xz file` | `unxz file.xz` | Smallest output, slowest. |
| zip | `.zip` | `zip -r out.zip dir/` | `unzip out.zip` | Archives **and** compresses. Works with Windows. `-r` for directories, `-e` to encrypt with a password. |
| 7z | `.7z` | `7z a out.7z files` | `7z x out.7z` | `-sfx` makes a **self-extracting** archive. |

`zcat file.gz` shows a gzip file's contents without unpacking it. `zgrep` and `zless` also work on `.gz` files directly.

### Other copy and backup tools

| Tool | What it is for |
|---|---|
| `cpio` | Older archive tool; reads file names from stdin. |
| `dd` | Copies raw data block by block. Used to clone disks and write ISO images to USB: `dd if=image.iso of=/dev/sdb bs=4M`. `if` = input file, `of` = output file. |
| `rsync` | Synchronizes directories and copies only what changed. See [Section 19](#19-remote-access-and-file-transfer). |

### Checksums: has this file been changed or damaged?

A **checksum (hash)** is a fingerprint of a file. If even one byte changes, the hash changes.

```bash
md5sum file.iso                  # print the MD5 hash (older, weaker)
sha256sum file.iso               # print the SHA-256 hash (current standard)
sha512sum file.iso               # SHA-512
sha256sum -c file.iso.sha256     # -c = CHECK the file against the saved hash. Prints OK or FAILED.
```

**On the exam:** `tar -czvf name.tar.gz dir` creates a compressed tarball; `tar -xzvf` extracts it. `z` = gzip, `j` = bzip2. `tar -tvf` lists. `-p` preserves permissions. `sha256sum -c` verifies a download.

---

## 16. Installing Software: Package Managers

A **package** is an installable bundle: the program, its files, and a list of other packages it needs (**dependencies**). A **repository (repo)** is a server that stores packages.

Two levels of tool:

- **Low-level** tools install one package file that you already have. They do **not** fetch dependencies. (`dpkg`, `rpm`)
- **High-level** tools download from repositories and **resolve dependencies automatically**. (`apt`, `dnf`, `yum`, `zypper`, `pacman`)

### Debian / Ubuntu: .deb packages

| Job | Command |
|---|---|
| Refresh the list of available packages | `apt update` |
| Upgrade everything installed | `apt upgrade` |
| Install | `apt install nginx` |
| Remove (keep config files) | `apt remove nginx` |
| Remove including config files | `apt purge nginx` |
| Remove dependencies nothing needs now | `apt autoremove` |
| Search | `apt search nginx` |
| Show details | `apt show nginx` |
| Install a `.deb` file you downloaded | `dpkg -i package.deb` |
| Remove with dpkg | `dpkg -r package` |
| List installed packages | `dpkg -l` |
| List files a package installed | `dpkg -L package` |
| Which package owns this file? | `dpkg -S /usr/bin/nano` |

`apt update` **only refreshes the list**. `apt upgrade` **installs** the newer versions. Run `update` first. `apt-get` and `apt-cache` are the older commands that `apt` combines.

Repositories are listed in `/etc/apt/sources.list` and the folder `/etc/apt/sources.list.d/`.

### Red Hat / Fedora / CentOS / Rocky: .rpm packages

| Job | Command |
|---|---|
| Install | `dnf install httpd` (older systems: `yum install httpd`) |
| Remove | `dnf remove httpd` |
| Upgrade everything | `dnf upgrade` (or `yum update`) |
| Search | `dnf search httpd` |
| Show details | `dnf info httpd` |
| Which package provides this file? | `dnf provides /usr/bin/nano` |
| Install an `.rpm` file | `rpm -ivh package.rpm` (**i**nstall, **v**erbose, **h**ash-mark progress) |
| Upgrade with rpm | `rpm -Uvh package.rpm` |
| Remove (erase) with rpm | `rpm -e package` |
| List all installed (query all) | `rpm -qa` |
| Details of an installed package | `rpm -qi package` |
| Files in a package | `rpm -ql package` |
| Which package owns this file? | `rpm -qf /usr/bin/nano` |

**dnf** replaced **yum**. Repository files are in `/etc/yum.repos.d/`.

### Others

| Distro | Tool | Install | Refresh / upgrade |
|---|---|---|---|
| openSUSE | `zypper` | `zypper install pkg` | `zypper refresh`, `zypper update` |
| Arch | `pacman` | `pacman -S pkg` | `pacman -Syu` |

Distro-independent formats: **snap**, **flatpak**, **AppImage**.

### Building from source

```bash
tar -xzvf program.tar.gz
cd program
./configure        # check the system and prepare the build
make               # compile
sudo make install  # copy the finished program into place
```

Shared libraries: `ldd /usr/bin/ls` lists the libraries a program needs. `ldconfig` rebuilds the library cache.

**On the exam:** match the tool to the family (`apt`/`dpkg` = Debian; `dnf`/`yum`/`rpm` = Red Hat; `zypper` = SUSE; `pacman` = Arch). `apt update` vs `apt upgrade`. `rpm -qa` lists everything installed. `dpkg -i` installs a local .deb. High-level tools resolve dependencies; low-level tools do not.

---

## 17. Installation, Boot Process, and GRUB

### Installing Linux: the decisions

- **Boot media:** a USB stick or DVD made from an **ISO** image. A **live** image lets you try Linux without installing it.
- **Partitions:** at minimum a root partition **`/`** and **swap**. A UEFI computer also needs an **EFI System Partition** (FAT32, mounted at `/boot/efi`). Many setups add a separate `/home` so personal files survive a reinstall, and sometimes a separate `/boot` or `/var`.
- **Swap size:** an old rule of thumb is 1 to 2 times the RAM on small systems. Swap can be a partition or a file.
- Then: time zone, a user account, the root password, and which software to install.

### The boot sequence

```text
1. Power on      BIOS or UEFI firmware runs POST (Power-On Self Test) and finds a boot device
2. Boot loader   GRUB2 loads from the MBR (BIOS) or the EFI System Partition (UEFI).
                 It shows the menu and loads the kernel and initramfs into memory.
3. Kernel        Starts up, detects hardware, and mounts the initramfs.
                 initramfs (initial RAM file system) holds the drivers needed to reach the real root file system.
4. Root mounted  The kernel mounts the real / file system.
5. init          The kernel starts PID 1: systemd (or init on older systems).
6. Target        systemd starts services until it reaches the default target
                 (multi-user.target or graphical.target).
7. Login         A login prompt or the graphical login screen appears.
```

| | BIOS | UEFI |
|---|---|---|
| Age | older | newer replacement for BIOS |
| Partition table | MBR | GPT |
| Extra | | **Secure Boot** (only signed boot loaders run), faster startup, disks over 2 TB |

### GRUB2: the GRand Unified Bootloader

| File or command | Purpose |
|---|---|
| `/etc/default/grub` | **The file you edit.** Settings such as `GRUB_TIMEOUT=5` (seconds the menu waits), `GRUB_DEFAULT=0` (which entry boots by default), `GRUB_CMDLINE_LINUX` (options passed to the kernel). |
| `/etc/grub.d/` | Scripts used to build the menu. |
| `/boot/grub/grub.cfg` (Debian) or `/boot/grub2/grub.cfg` (Red Hat) | **The generated menu. Do not edit it by hand.** It gets overwritten. |
| `update-grub` (Debian/Ubuntu) | Rebuilds grub.cfg after you change settings. |
| `grub2-mkconfig -o /boot/grub2/grub.cfg` (Red Hat) | Same job. |
| `grub-install /dev/sda` | Installs GRUB onto a disk. Use it to **repair** a missing or broken boot loader. |

At the GRUB menu, press **`e`** to edit an entry for one boot (for example, to boot into rescue mode and reset a lost root password). Press **`c`** for the GRUB command line.

Older boot loaders: **LILO**, and **GRUB Legacy** (whose config file was `/boot/grub/menu.lst`).

### The kernel and its modules

```bash
uname -r             # kernel version (release)
uname -a             # all system information
uname -m             # machine hardware (x86_64)
cat /etc/os-release  # which distribution and version
hostnamectl          # hostname, OS, and kernel in one place
dmesg                # kernel messages from boot: hardware detection, driver errors
```

Files in `/boot`: `vmlinuz-<version>` is the compressed kernel. `initramfs-<version>.img` or `initrd.img-<version>` is the initial RAM disk.

A **kernel module** is a piece of the kernel, usually a driver, that can be loaded and unloaded while the system runs.

| Command | Job |
|---|---|
| `lsmod` | list loaded modules |
| `modinfo name` | show details about a module |
| `modprobe name` | load a module **and the modules it depends on** |
| `modprobe -r name` | remove a module |
| `insmod file.ko` | load one module file, no dependency handling |
| `rmmod name` | remove one module |

### Looking at hardware

| Command | Shows |
|---|---|
| `lscpu` | CPU details |
| `lsblk` | disks and partitions |
| `lspci` | PCI devices (graphics card, network card) |
| `lsusb` | USB devices |
| `lshw` | a full hardware report |
| `dmidecode` | BIOS and motherboard details |
| `free -h` | memory |

**On the exam:** the boot order (firmware, boot loader, kernel, init). GRUB is the boot loader. Edit `/etc/default/grub`, then run `update-grub` or `grub2-mkconfig`. `uname -r` shows the kernel version. `lsmod` and `modprobe` handle modules. PID 1 is systemd. `dmesg` shows kernel boot messages.

---

## 18. Networking Commands and Files

### Showing and setting addresses

| Modern command (`iproute2`) | Older command (`net-tools`) | Job |
|---|---|---|
| `ip addr` or `ip a` | `ifconfig` | show interfaces and IP addresses |
| `ip link set eth0 up` | `ifconfig eth0 up` | turn an interface on (`down` turns it off) |
| `ip addr add 192.168.1.50/24 dev eth0` | `ifconfig eth0 192.168.1.50 netmask 255.255.255.0` | give an interface an address |
| `ip route` | `route -n` | show the routing table and default gateway |
| `ip route add default via 192.168.1.1` | `route add default gw 192.168.1.1` | add a default route |
| `ip neigh` | `arp -a` | show the ARP table (IP address to MAC address) |
| `ss -tuln` | `netstat -tuln` | show network connections and listening ports |

The **`ip`** command manages network interfaces **and** routing. The older **`route`** command shows the routing table and adds or deletes static routes.

`netstat` / `ss` option letters: `-t` TCP, `-u` UDP, `-l` listening only, `-n` numbers instead of names, `-p` show the process, `-a` all, `-r` routing table.

Interface names: `lo` is the **loopback** (127.0.0.1, the computer talking to itself). `eth0` is the old name for the first wired card. Newer names look like `enp3s0` (wired) or `wlp2s0` (wireless).

Changes made with `ip` are **lost at reboot**. To make them permanent, use the distribution's tool: **NetworkManager** (`nmcli`, `nmtui`), **netplan** on Ubuntu (`/etc/netplan/*.yaml`), `/etc/network/interfaces` on older Debian, or `/etc/sysconfig/network-scripts/ifcfg-eth0` on older Red Hat.

### Testing and troubleshooting

| Command | Job |
|---|---|
| `ping -c 4 8.8.8.8` | Is the host reachable? Uses **ICMP**. `-c 4` = send 4 packets then stop. |
| `traceroute host` | Show each router (hop) along the path. `tracepath` is similar. |
| `mtr host` | ping and traceroute combined, live. |
| `nslookup name` | Look up a name in DNS. |
| `dig name` | Detailed DNS lookup. |
| `host name` | Simple DNS lookup. |
| `curl URL` / `wget URL` | Fetch a web page or download a file. |
| `nmap host` | Scan a host for open ports. |
| `tcpdump` | Capture and display network packets. |
| `nc` (netcat) | Open a raw TCP/UDP connection; test whether a port is open. |
| `ethtool eth0` | Link speed and duplex of a network card. |

Troubleshoot in order: `ping 127.0.0.1` (is networking working at all?), your own IP, the **default gateway**, an outside IP such as `8.8.8.8`, then a **name** such as `google.com`. If the IP works and the name does not, the problem is **DNS**.

### Network configuration files

| File | What it holds |
|---|---|
| **`/etc/hostname`** | The system's **hostname**. Edit this to make a new name last after a reboot. |
| **`/etc/hosts`** | A local table of **IP address to name**. Checked before DNS. `127.0.0.1 localhost` |
| **`/etc/resolv.conf`** | The **DNS servers** to ask (`nameserver 8.8.8.8`) and the **DNS search domains** (`search mccc.local`). |
| `/etc/nsswitch.conf` | The **order** to look things up. `hosts: files dns` means check `/etc/hosts` first, then DNS. |
| `/etc/services` | Service names and their port numbers. |
| `/etc/protocols` | Protocol names and numbers. |

```bash
hostname                              # show the hostname
hostnamectl set-hostname web01        # change it, permanently (writes /etc/hostname)
```

### Ports to know

| Port | Service | | Port | Service |
|---|---|---|---|---|
| 20, 21 | FTP | | 110 | POP3 |
| **22** | **SSH**, SCP, SFTP | | 123 | NTP (time) |
| 23 | Telnet (not encrypted) | | 143 | IMAP |
| 25 | SMTP (sending mail) | | 389 | LDAP |
| 53 | DNS | | **443** | **HTTPS** |
| 67, 68 | DHCP | | 631 | IPP / CUPS (printing) |
| 69 | TFTP | | 3306 | MySQL / MariaDB |
| **80** | **HTTP** | | 3389 | RDP |

Ports **0 to 1023** are "well-known" ports. Only root can open them.

### IP address basics

- **IPv4:** 32 bits, four numbers 0-255: `192.168.1.50`. **IPv6:** 128 bits, written in hexadecimal: `fe80::1`.
- **Subnet mask / CIDR:** `/24` = `255.255.255.0` (254 usable hosts). `/16` = `255.255.0.0`. `/8` = `255.0.0.0`.
- **Private ranges** (not routed on the internet): `10.0.0.0/8`, `172.16.0.0/12`, `192.168.0.0/16`.
- **Loopback:** `127.0.0.1` (IPv6 `::1`). **APIPA:** `169.254.x.x` means the computer asked for a DHCP address and got no answer.
- **Default gateway:** the router that traffic for other networks is sent to.
- **DHCP** hands out IP addresses automatically. **DNS** turns names into IP addresses. **NAT** lets many private addresses share one public address.

**On the exam:** `/etc/hostname` holds the hostname. `/etc/resolv.conf` holds DNS servers and search domains. `/etc/hosts` maps names locally. The `ip` command manages interfaces and routing. `netstat -tuln` (or `ss -tuln`) lists listening ports. `ping` tests reachability. SSH is port 22.

---

## 19. Remote Access and File Transfer

| Tool | Job | Encrypted? |
|---|---|---|
| **`ssh`** | **S**ecure **Sh**ell: log in to a remote computer's command line. Port 22. | Yes |
| **`scp`** | **S**ecure **c**o**p**y: copy files between hosts over SSH. | Yes |
| **`sftp`** | Interactive file transfer over SSH. | Yes |
| **`rsync`** | **Synchronize** files and directories, locally or between systems. Sends **only the differences**, so repeat runs are fast. | Yes, when run over SSH |
| `ftp` | **F**ile **T**ransfer **P**rotocol. Ports 20/21. | **No** |
| `telnet` | Remote login. Port 23. Replaced by SSH. | **No** |
| `wget`, `curl` | Download from web or FTP servers. | Depends on the URL |

```bash
ssh maria@192.168.1.20                        # log in as maria
ssh -p 2222 maria@server                      # use a different port

scp report.txt maria@server:/home/maria/      # local file  -> remote host
scp maria@server:/var/log/app.log .           # remote file -> here ( . = current directory)
scp -r projects/ maria@server:/backup/        # -r for a whole directory

rsync -av  projects/ /backup/projects/        # -a archive (keeps permissions, times, owners), -v verbose
rsync -avz projects/ maria@server:/backup/    # -z compress while sending
rsync -av --delete src/ dest/                 # also delete files in dest that are gone from src
```

### SSH keys: logging in without a password

```bash
ssh-keygen -t ed25519            # make a key pair (or -t rsa -b 4096)
ssh-copy-id maria@server         # install your PUBLIC key on the server
```

| File | What it is |
|---|---|
| `~/.ssh/id_ed25519` (or `id_rsa`) | Your **private** key. Never share it. Permissions must be `600`. |
| `~/.ssh/id_ed25519.pub` | Your **public** key. Safe to hand out. |
| `~/.ssh/authorized_keys` | On the **server**: the public keys allowed to log in to this account. |
| `~/.ssh/known_hosts` | On the **client**: fingerprints of servers you have connected to before. |
| `/etc/ssh/sshd_config` | Settings for the SSH **server** (daemon): `Port`, `PermitRootLogin no`, `PasswordAuthentication no`. |
| `/etc/ssh/ssh_config` | Settings for the SSH **client**. |

After changing `sshd_config`, run `systemctl restart sshd`.

**On the exam:** `scp` securely copies files between hosts. `rsync` synchronizes and sends only changes. `ssh` replaced `telnet` because it is encrypted. SSH uses port 22. The public key goes in `authorized_keys` on the server.

---

## 20. Firewalls and System Security

### Firewalls

A **firewall** allows or blocks network traffic based on rules (port, protocol, source address). Inside the kernel the framework is **netfilter**. The tools below are different ways to write its rules.

| Tool | Where you find it | Examples |
|---|---|---|
| **`ufw`** (Uncomplicated Firewall) | Ubuntu, Debian | `ufw enable` · `ufw status` · `ufw allow 22/tcp` · `ufw allow ssh` · `ufw deny 23` · `ufw delete allow 80` · `ufw default deny incoming` |
| **`firewalld`** (command: `firewall-cmd`) | RHEL, Fedora, CentOS | `firewall-cmd --state` · `firewall-cmd --list-all` · `firewall-cmd --add-service=http --permanent` · `firewall-cmd --add-port=8080/tcp --permanent` · `firewall-cmd --reload` |
| **`iptables`** | older, works everywhere | `iptables -L` (list) · `iptables -A INPUT -p tcp --dport 22 -j ACCEPT` · `iptables -A INPUT -j DROP` |
| **`nftables`** (command: `nft`) | the modern replacement for iptables | `nft list ruleset` |

**firewalld** sorts interfaces into **zones** (public, home, trusted...). A rule added without `--permanent` disappears on reload or reboot. After adding permanent rules, run `firewall-cmd --reload`.

**iptables** words: **tables** (`filter`, `nat`, `mangle`). **Chains**: `INPUT` (traffic coming to this computer), `OUTPUT` (leaving it), `FORWARD` (passing through it). **Targets**: `ACCEPT`, `DROP` (silently discard), `REJECT` (discard and tell the sender), `LOG`. Flags: `-A` append a rule, `-D` delete, `-L` list, `-F` flush (delete all), `-p` protocol, `--dport` destination port, `-s` source, `-j` jump to a target.

### Mandatory access control

Normal permissions are **discretionary** (DAC): the owner decides. **Mandatory** access control (MAC) adds system-wide rules that even root's processes must follow.

| System | Distros | Commands and files |
|---|---|---|
| **SELinux** | Red Hat family | `getenforce` · `setenforce 0` or `1` · `sestatus` · config in `/etc/selinux/config` · `ls -Z` shows a file's security context · `restorecon` fixes contexts · `chcon` changes one |
| **AppArmor** | Ubuntu, SUSE | `aa-status` · profiles in `/etc/apparmor.d/` · `aa-enforce`, `aa-complain` |

SELinux modes: **Enforcing** (blocks and logs), **Permissive** (logs only, blocks nothing), **Disabled**.

### Authentication

- **PAM** (Pluggable Authentication Modules) handles logins for most programs. Config files are in `/etc/pam.d/`.
- Password hashes are in **`/etc/shadow`**. Aging is managed with **`chage`**.
- **`sudo`** rights come from `/etc/sudoers`. Always edit it with **`visudo`**, which checks the syntax before saving.
- `fail2ban` watches logs and blocks addresses that keep failing to log in.
- Failed logins: `lastb`. Successful logins: `last`. Authentication log: `/var/log/auth.log` (Debian) or `/var/log/secure` (Red Hat).

### Hardening checklist

Turn off services you do not need. Keep packages updated. Disable root login over SSH. Use SSH keys. Use `sudo` and avoid logging in as root. Set a restrictive `umask`. Run a firewall with "deny incoming" as the default. Find SUID programs with `find / -perm -4000`. Encrypt files with **`gpg`**. Encrypt whole disks with **LUKS** (`cryptsetup`).

**On the exam:** match the firewall tool to the distro (`ufw` = Ubuntu; `firewalld` = Red Hat). `iptables -L` lists rules. SELinux's three modes; `getenforce` shows the mode. `visudo` edits sudoers. `/etc/shadow` holds password hashes. DROP vs REJECT.

---

## 21. Printing

Linux printing is handled by **CUPS**, the **C**ommon **U**NIX **P**rinting **S**ystem.

- The daemon is **`cupsd`**. Manage it with `systemctl status cups`.
- It has a web admin page at **`http://localhost:631`**. Port **631** is **IPP**, the Internet Printing Protocol.
- Configuration is in `/etc/cups/`. Main file: `/etc/cups/cupsd.conf`. Printers: `/etc/cups/printers.conf`.
- Print jobs wait in the **spool** directory `/var/spool/cups`.

There are two families of commands. Both work with CUPS.

| Job | System V style | BSD style |
|---|---|---|
| **Print** a file | `lp file.txt` | `lpr file.txt` |
| Print to a named printer | `lp -d office file.txt` | `lpr -P office file.txt` |
| Print 3 copies | `lp -n 3 file.txt` | `lpr -#3 file.txt` |
| **Show the queue** | `lpstat -o` | `lpq` |
| **Cancel** a job | `cancel 12` | `lprm 12` |
| Printer status and default printer | `lpstat -p -d` | `lpc status` |
| Everything | `lpstat -t` | |

| Admin command | Job |
|---|---|
| `lpadmin -p office -E -v ipp://192.168.1.60/ipp/print -m everywhere` | add or change a printer |
| `lpadmin -x office` | delete a printer |
| `lpadmin -d office` or `lpoptions -d office` | set the default printer |
| `cupsenable office` / `cupsdisable office` | start / stop **printing** from the queue |
| `cupsaccept office` / `cupsreject office` | allow / refuse **new jobs** into the queue |

**On the exam:** CUPS is the printing system. Port 631. `lp` or `lpr` prints. `lpq` or `lpstat` shows the queue. `lprm` or `cancel` removes a job.

---

## 22. Environment Variables and Shell Scripting

### Variables

```bash
name="Maria"          # set a SHELL variable. NO spaces around the =
echo $name            # use it: put $ in front
echo "${name}_backup" # braces show where the name ends
export name           # make it an ENVIRONMENT variable, so programs you start can see it
export EDITOR=nano    # set and export in one step
unset name            # remove it
```

A **shell variable** exists only in the current shell. An **environment variable** (exported) is handed down to every program the shell starts.

| Command | Shows |
|---|---|
| `env` | the environment variables. Can also run a program with a changed environment. |
| `printenv` | the environment variables. `printenv HOME` prints just one. |
| `set` | **everything**: shell variables, environment variables, and functions |
| `echo $HOME` | the value of one variable |

### Variables to know

| Variable | Holds |
|---|---|
| `$HOME` | your home directory |
| `$USER` | your user name |
| `$PATH` | the list of directories, separated by colons, that the shell searches for commands |
| `$PWD` | the current directory |
| `$SHELL` | your login shell (`/bin/bash`) |
| `$PS1` | what your prompt looks like |
| `$EDITOR` | your default text editor |
| `$LANG` | language and locale |
| `$HISTSIZE` | how many commands the history keeps |
| `$?` | the **exit status** of the last command. **0 = success.** Anything else = an error. |
| `$$` | the PID of the current shell |
| `$0` | the name of the script |
| `$1`, `$2`... | the first, second... **argument** given to the script |
| `$#` | how many arguments were given |
| `$@` | all of the arguments |

### PATH

When you type `ls`, the shell looks through each directory in `$PATH`, in order, and runs the first `ls` it finds. The current directory is **not** in the PATH, which is why you run your own script as **`./script.sh`**.

```bash
echo $PATH
export PATH=$PATH:/opt/tools/bin     # add a directory to the end
```

### Startup files

| File | When it is read |
|---|---|
| `/etc/profile` | system-wide, at **login**, for every user |
| `~/.bash_profile` or `~/.profile` | your own, at **login** |
| `~/.bashrc` | your own, every time an **interactive shell** opens (each new terminal window). Put aliases here. |
| `/etc/bash.bashrc` or `/etc/bashrc` | system-wide version of .bashrc |
| `~/.bash_logout` | when you log out |
| `~/.bash_history` | your saved command history |

After editing `.bashrc`, load it without logging out: **`source ~/.bashrc`** (or `. ~/.bashrc`).

### Aliases

```bash
alias ll='ls -la'     # make a shortcut
alias                 # list your aliases
unalias ll            # remove one
```

An alias typed at the prompt is gone when you close the terminal. Put it in `~/.bashrc` to keep it.

### Quotes

| Quotes | Effect | `echo ... $HOME` prints |
|---|---|---|
| `"double"` | variables **are** expanded | `/home/maria` |
| `'single'` | everything is literal | `$HOME` |
| `` `backticks` `` or `$(command)` | **command substitution**: replaced by the command's output | `today=$(date)` |
| `\` | escape the next character | `\$HOME` prints `$HOME` |

### A shell script, piece by piece

```bash
#!/bin/bash
# The first line is the SHEBANG. It tells Linux which program runs this file.
# Every other line that starts with # is a comment.

# ---- variables and arguments ----
backup_dir="/backup"
target=$1                          # the first argument given to the script

# ---- if / else ----
# Spaces inside [ ] are required.
if [ -z "$target" ]; then          # -z is true when the string is empty
    echo "Usage: $0 directory"
    exit 1                         # leave with a non-zero (error) status
fi

if [ -d "$target" ]; then          # -d is true when it is a directory
    echo "Backing up $target"
else
    echo "$target is not a directory"
    exit 2
fi

# ---- for loop ----
for f in "$target"/*.txt; do
    echo "Found: $f"
done

# ---- while loop ----
count=1
while [ $count -le 3 ]; do         # -le means less than or equal
    echo "Pass $count"
    count=$((count + 1))           # $(( )) does arithmetic
done

# ---- read input ----
read -p "Continue? (y/n) " answer

# ---- case ----
case $answer in
    y|Y) tar -czf "$backup_dir/backup_$(date +%F).tar.gz" "$target" ;;
    n|N) echo "Cancelled" ;;
    *)   echo "Unknown answer" ;;
esac

# ---- check whether the last command worked ----
if [ $? -eq 0 ]; then
    echo "Done"
fi

exit 0                             # 0 means success
```

Make it runnable, then run it:

```bash
chmod +x backup.sh       # add execute permission
./backup.sh /home/maria  # ./ is needed because the current directory is not in PATH
bash backup.sh /home/maria   # this way works even without execute permission
```

### Test operators used inside [ ]

| Files | True when | | Numbers | Means | | Strings | Means |
|---|---|---|---|---|---|---|---|
| `-e f` | f exists | | `-eq` | equal | | `=` | same |
| `-f f` | f is a regular file | | `-ne` | not equal | | `!=` | different |
| `-d f` | f is a directory | | `-gt` | greater than | | `-z s` | s is empty |
| `-r f` | f is readable | | `-ge` | greater or equal | | `-n s` | s is not empty |
| `-w f` | f is writable | | `-lt` | less than | | | |
| `-x f` | f is executable | | `-le` | less or equal | | | |
| `-s f` | f is not empty | | | | | | |

Join tests with `&&` (and), `||` (or), and `!` (not).

### Functions

```bash
greet() {
    echo "Hello, $1"     # inside a function, $1 is the function's first argument
}
greet Maria
```

**On the exam:** what `#!/bin/bash` is called (shebang) and what it does. `chmod +x` then `./script.sh`. `$?` = exit status, 0 = success. `$1` = first argument. `export` makes a variable available to child programs. `echo $HOME` shows your home directory. `env` or `printenv` lists environment variables. `.bashrc` is where aliases go. Single quotes stop variable expansion.

---

## 23. Logs, Date and Time, and Troubleshooting

### Log files: /var/log

| File | Holds |
|---|---|
| `/var/log/syslog` (Debian/Ubuntu) or `/var/log/messages` (Red Hat) | general system messages |
| `/var/log/auth.log` (Debian) or `/var/log/secure` (Red Hat) | logins, `sudo` use, authentication |
| `/var/log/kern.log` | kernel messages |
| `/var/log/dmesg` | boot-time hardware messages |
| `/var/log/boot.log` | service startup messages |
| `/var/log/cron` | cron job activity |
| `/var/log/apt/`, `/var/log/dnf.log` | package installs |
| `/var/log/wtmp`, `/var/log/btmp` | login records. Binary files: read them with `last` and `lastb`. |

```bash
tail -f /var/log/syslog           # watch a log LIVE as lines are added
tail -n 50 /var/log/auth.log      # the last 50 lines
grep -i "failed" /var/log/auth.log
less /var/log/syslog              # scroll and search
tac /var/log/syslog | less        # newest entries first
```

### The systemd journal

systemd keeps its own binary log. Read it with **`journalctl`**.

```bash
journalctl                  # everything, oldest first
journalctl -r               # reverse: NEWEST first
journalctl -f               # follow live (like tail -f)
journalctl -u sshd          # only one unit (service)
journalctl -b               # only since the current boot
journalctl -p err           # priority "err" and worse
journalctl --since "1 hour ago"
journalctl -k               # kernel messages (like dmesg)
```

**rsyslog** is the daemon that writes the text log files (`/etc/rsyslog.conf`). **logrotate** renames, compresses, and deletes old logs on a schedule so they do not fill the disk (`/etc/logrotate.conf`). `logger "text"` writes your own message into the system log.

Syslog **severity levels**, from most to least serious: 0 emerg, 1 alert, 2 crit, 3 err, 4 warning, 5 notice, 6 info, 7 debug.

### Date and time

| Command | Job |
|---|---|
| `date` | Show the current date and time. `date +%F` prints `2026-09-25`. |
| `TZ="America/New_York" date` | Show the time in a different time zone, just this once. |
| **`timedatectl`** | Show the time, **time zone**, and whether NTP sync is on. |
| `timedatectl list-timezones` | List valid time zone names. |
| `timedatectl set-timezone America/New_York` | **Change the system time zone.** |
| `timedatectl set-ntp true` | Turn on automatic time sync. |
| `hwclock` | Read or set the **hardware** (BIOS/RTC) clock. |
| `cal` | Print a calendar. |

`/etc/localtime` is a link to the current zone's file under `/usr/share/zoneinfo/`. `/etc/timezone` holds the zone name on Debian. **NTP** (Network Time Protocol, port 123) keeps clocks in sync. The daemon is `chronyd`, `ntpd`, or `systemd-timesyncd`.

### Troubleshooting: which tool for which symptom

| Symptom | First tools to try |
|---|---|
| "Disk full" | `df -h` to find the full file system, then `du -sh *` to find the big directory. Check inodes with `df -i`. |
| System is slow | `top` or `htop` (CPU, memory), `free -h` (is swap in use?), `uptime` (load average), `iostat`, `vmstat` |
| A service will not start | `systemctl status name`, then `journalctl -u name` |
| Cannot reach the network | `ip addr`, `ip route`, `ping` the gateway, then `ping 8.8.8.8`, then a name. Check `/etc/resolv.conf`. |
| What is using port 80? | `ss -tulnp` or `lsof -i :80` |
| "Permission denied" | `ls -l` for permissions and owner, `id` for your groups, `getfacl` for ACLs, `getenforce` for SELinux |
| "Command not found" | `echo $PATH`, `which cmd`, is the package installed? |
| A program is frozen | `pgrep name` or `ps -ef \| grep name`, then `kill PID`, then `kill -9 PID` if it ignores you |
| Hardware not detected | `dmesg`, `lspci`, `lsusb`, `lsmod` |
| System will not boot | GRUB menu, press `e`, boot to `rescue.target`; run `fsck`; check `/etc/fstab`; `grub-install` |
| File system errors | unmount it, then `fsck /dev/sdXN` |

**Load average** (from `uptime` or `top`) is three numbers: the average number of processes waiting to run over the last **1, 5, and 15 minutes**. On a 4-core computer, a load of 4.0 means fully busy.

**On the exam:** logs are in `/var/log`. `tail -f` watches a log live. `journalctl` reads the systemd journal; `-u` picks a service, `-r` shows newest first. `timedatectl` sets the time zone. `dmesg` shows kernel and hardware messages. `df` for disk space, `free` for memory.

---

## 24. Acronym Bank

The regional test includes a few "What does ___ stand for?" questions. These are the ones most likely to show up.

| Acronym | Stands for | One-line meaning |
|---|---|---|
| **ACL** | Access Control List | extra per-user or per-group permissions on a file |
| **APT** | Advanced Package Tool | Debian/Ubuntu package manager |
| **ARP** | Address Resolution Protocol | finds the MAC address for an IP address |
| **BASH** | Bourne Again SHell | the default Linux shell |
| **BIOS** | Basic Input/Output System | older firmware that starts the computer |
| **CIDR** | Classless Inter-Domain Routing | the `/24` way of writing a subnet mask |
| **CLI** | Command Line Interface | typing commands |
| **CUPS** | Common UNIX Printing System | Linux printing |
| **DHCP** | Dynamic Host Configuration Protocol | hands out IP addresses automatically |
| **DNF** | Dandified YUM | Red Hat family package manager |
| **DNS** | Domain Name System | turns names into IP addresses |
| **FHS** | Filesystem Hierarchy Standard | the rules for what goes in `/etc`, `/var`, and so on |
| **FTP** | File Transfer Protocol | file transfer, not encrypted, ports 20/21 |
| **GNU** | GNU's Not Unix | the project behind most Linux tools |
| **GPL** | General Public License | the open-source license Linux uses |
| **GPT** | GUID Partition Table | modern partition table |
| **GRUB** | GRand Unified Bootloader | the Linux boot loader |
| **GUI** | Graphical User Interface | windows and a mouse |
| **HTTP / HTTPS** | HyperText Transfer Protocol (Secure) | web traffic, ports 80 / 443 |
| **ICMP** | Internet Control Message Protocol | what `ping` uses |
| **IP** | Internet Protocol | addressing and routing |
| **IPP** | Internet Printing Protocol | network printing, port 631 |
| **LDAP** | Lightweight Directory Access Protocol | central user directory |
| **LUKS** | Linux Unified Key Setup | disk encryption |
| **LVM** | Logical Volume Manager | flexible, resizable storage |
| **MAC** | Media Access Control *or* Mandatory Access Control | a network card's hardware address / SELinux-style security |
| **MBR** | Master Boot Record | older partition table; first sector of the disk |
| **NAT** | Network Address Translation | many private addresses share one public address |
| **NFS** | Network File System | share directories between Linux machines |
| **NIC** | Network Interface Card | the network adapter |
| **NTP** | Network Time Protocol | keeps clocks in sync |
| **PAM** | Pluggable Authentication Modules | the login and authentication framework |
| **PID / PPID** | Process ID / Parent Process ID | a process's number / its parent's number |
| **POSIX** | Portable Operating System Interface | the standard UNIX-like systems follow |
| **RAID** | Redundant Array of Independent Disks | several disks combined for speed or safety |
| **RPM** | RPM Package Manager (originally Red Hat Package Manager) | Red Hat family package format and tool |
| **SCP** | Secure Copy | copy files over SSH |
| **SELinux** | Security-Enhanced Linux | mandatory access control on Red Hat |
| **SFTP** | SSH File Transfer Protocol | interactive file transfer over SSH |
| **SGID / SUID** | Set Group ID / Set User ID | special permission bits |
| **SMB / CIFS** | Server Message Block / Common Internet File System | Windows file sharing (Samba) |
| **SMTP** | Simple Mail Transfer Protocol | sending e-mail, port 25 |
| **SSH** | Secure Shell | encrypted remote login, port 22 |
| **TCP / UDP** | Transmission Control Protocol / User Datagram Protocol | reliable, connection-based / fast, connectionless |
| **UEFI** | Unified Extensible Firmware Interface | modern replacement for BIOS |
| **UFW** | Uncomplicated Firewall | Ubuntu's firewall tool |
| **UID / GID** | User ID / Group ID | the numbers behind user and group names |
| **UUID** | Universally Unique Identifier | a permanent ID for a file system |
| **VFS** | Virtual File System | the kernel layer that makes all file systems look alike |
| **YUM** | Yellowdog Updater, Modified | older Red Hat package manager |

---

## 25. Look-Alike Commands: The Trap List

Wrong answers on this test are usually a real command that does a *nearby* job. Know these pairs.

| Do not mix up | The difference |
|---|---|
| `df` / `du` / `free` | `df` = free space on each **disk**. `du` = size of a **directory**. `free` = **memory** and swap. |
| `chmod` / `chown` / `chgrp` | **mod**e (permissions) / **own**er / **gr**ou**p**. |
| `useradd` / `usermod` / `userdel` | create / **change** (this is the one that adds a user to a group) / delete. |
| `groupadd` / `usermod -aG` | `groupadd` **creates a new group**. `usermod -aG` **puts a user into** a group. |
| `find` / `grep` / `locate` | `find` = files by **name or property**. `grep` = text **inside** files. `locate` = fast name search in a **database**. |
| `head` / `tail` / `tail -f` | first lines / last lines / last lines and **keep watching**. |
| `cat` / `less` / `more` | dump it all / page **both ways** / page forward only. |
| `ps` / `top` / `pgrep` | snapshot list / **live** view / just the **PID** for a name. |
| `ps -ef` / `ps aux` | `-ef` shows **PPID**. `aux` shows **%CPU and %MEM**. |
| `kill` / `kill -9` / `killall` | polite (SIGTERM 15) / forced (SIGKILL 9) / by **name**. |
| Ctrl+C / Ctrl+Z / Ctrl+D | **end** the program / **suspend** it / end of input (log out). |
| `>` / `>>` | **overwrite** / **append**. |
| `rm -r` / `rmdir` | remove a directory **and its contents** / remove only an **empty** directory. |
| `cp` / `mv` | copy / move **or rename**. |
| `ln` / `ln -s` | hard link / symbolic link. |
| `tar -c` / `tar -x` / `tar -t` | **c**reate / e**x**tract / lis**t**. |
| `tar z` / `tar j` | g**z**ip / b**z**ip2 (the letter is `j`). |
| `gzip` / `tar` / `zip` | compress **one file** / bundle many files / bundle **and** compress. |
| `scp` / `rsync` / `ftp` | secure copy / **sync only the changes** / not encrypted. |
| `ssh` / `telnet` | encrypted (22) / plain text (23). |
| `/etc/hostname` / `/etc/hosts` / `/etc/resolv.conf` | this computer's **name** / local **name-to-IP table** / **DNS servers** and search domains. |
| `/etc/passwd` / `/etc/shadow` / `/etc/group` | accounts / password **hashes** / groups. |
| `/` / `/root` | top of the directory tree / root user's **home**. |
| `/bin` / `/sbin` | commands for everyone / commands for the **administrator**. |
| `/etc` / `/var` | **configuration** / **changing data** such as logs. |
| `fdisk` / `mkfs` / `fsck` / `mount` | make **partitions** / **format** / **check and repair** / attach. |
| `ip` / `ifconfig` | modern / older. Both show addresses. |
| `ip` / `route` | `ip` does interfaces **and** routes. `route` does only the routing table. |
| `netstat` / `ss` | older / modern. Both list connections and listening ports. |
| `date` / `timedatectl` / `hwclock` | show the time / set the **time zone** and NTP / the **hardware** clock. |
| `apt update` / `apt upgrade` | refresh the **list** / install the newer **packages**. |
| `apt` / `dpkg`, `dnf` / `rpm` | high-level (handles dependencies) / low-level (one package file). |
| `systemctl start` / `systemctl enable` | run it **now** / run it **at boot**. |
| `cron` / `at` | **repeating** schedule / **one time**. |
| `crontab -e` / `crontab -r` | edit / **remove everything**. |
| `su` / `sudo` | become another user (needs **their** password) / run one command as root (needs **your** password). |
| `env` / `set` | environment variables / **all** variables and functions. |
| `whoami` / `who` / `id` | your name / everyone logged in / your UID and groups. |
| `md5sum` / `sha256sum` | older, weaker hash / current standard. Add `-c` to **check** a file. |
| `stat` / `file` | timestamps, size, inode / what **type** of file it is. |
| `which` / `whereis` | which program will run / program, source, and man page locations. |
| `lp`, `lpr` / `lpq`, `lpstat` / `lprm`, `cancel` | **print** / **show the queue** / **remove** a job. |
| `modprobe` / `insmod` | loads dependencies too / loads one module file only. |
| `umount` | It is spelled **umount**. There is no "unmount" command. |

Commands that **do not exist** (they have appeared as wrong answers): `checkfs`, `diskchk`, `scanfs`, `rmuser`, `deleteuser`, `meminfo`, `ownfile`, `tzconfig`, `size` (for directories). Note that `deluser` and `adduser` **are** real on Debian/Ubuntu.

---

## 26. Quick Reference Card

Organized by the job you need done.

### Files and directories

| I need to... | Command |
|---|---|
| see where I am | `pwd` |
| list files, including hidden ones, with details | `ls -la` |
| change directory / go home / go back | `cd dir` / `cd` / `cd -` |
| make a directory (and its parents) | `mkdir -p a/b` |
| create an empty file | `touch file` |
| copy a file / a directory | `cp a b` / `cp -r dir1 dir2` |
| move or rename | `mv old new` |
| delete a file / a directory tree | `rm file` / `rm -r dir` |
| make a symbolic link | `ln -s target linkname` |
| see a file's type / its timestamps | `file f` / `stat f` |
| find files by name | `find . -name "*.txt"` |
| search inside files | `grep -ri "text" dir` |
| see the first / last lines | `head -n 5 f` / `tail -n 5 f` |
| watch a log live | `tail -f /var/log/syslog` |
| page through a file | `less f` |
| count lines | `wc -l f` |
| compare two files | `diff a b` |

### Permissions, users, groups

| I need to... | Command |
|---|---|
| change permissions | `chmod 755 f` or `chmod u+x f` |
| change owner / group | `chown user:group f` / `chgrp group f` |
| see default permission mask | `umask` |
| give one extra user access | `setfacl -m u:name:rw f` |
| create / delete a user | `useradd -m name` / `userdel -r name` |
| set a password | `passwd name` |
| add a user to a group | `usermod -aG group name` |
| make a user an administrator | `usermod -aG sudo name` (Red Hat: `wheel`) |
| create a group | `groupadd name` |
| see my UID and groups | `id` |
| run one command as root | `sudo command` |
| edit sudo rules safely | `visudo` |

### Processes and services

| I need to... | Command |
|---|---|
| list every process with PPID | `ps -ef` |
| watch processes live | `top` |
| get the PID of a program | `pgrep name` |
| stop a process / force it | `kill PID` / `kill -9 PID` |
| stop by name | `killall name` or `pkill name` |
| suspend / resume in background / bring back | Ctrl+Z / `bg` / `fg` |
| see what has a file or port open | `lsof` / `lsof -i :80` |
| start / stop / check a service | `systemctl start name`, `stop`, `status` |
| start a service at boot | `systemctl enable name` |
| schedule a repeating job | `crontab -e` |
| schedule a one-time job | `at 5pm` |
| reboot / power off | `shutdown -r now` / `shutdown -h now` |

### Storage

| I need to... | Command |
|---|---|
| see free space on disks | `df -h` |
| see how big a directory is | `du -sh dir` |
| see memory and swap | `free -h` |
| list disks and partitions | `lsblk` or `fdisk -l` |
| create partitions | `fdisk /dev/sdb` |
| format a partition | `mkfs.ext4 /dev/sdb1` |
| check and repair a file system | `fsck /dev/sdb1` |
| mount / unmount | `mount /dev/sdb1 /mnt` / `umount /mnt` |
| mount at every boot | add a line to `/etc/fstab` |
| see UUIDs | `blkid` |

### Archives

| I need to... | Command |
|---|---|
| make a gzip tarball | `tar -czvf out.tar.gz dir` |
| extract a gzip tarball | `tar -xzvf out.tar.gz` |
| list a tarball's contents | `tar -tvf out.tar` |
| keep permissions in the archive | add `p`: `tar -czvpf` |
| zip / unzip | `zip -r out.zip dir` / `unzip out.zip` |
| verify a download | `sha256sum -c file.sha256` |

### Software

| I need to... | Debian / Ubuntu | Red Hat / Fedora |
|---|---|---|
| refresh the package list | `apt update` | (automatic) |
| install | `apt install pkg` | `dnf install pkg` |
| remove | `apt remove pkg` | `dnf remove pkg` |
| upgrade everything | `apt upgrade` | `dnf upgrade` |
| install a local package file | `dpkg -i f.deb` | `rpm -ivh f.rpm` |
| list installed packages | `dpkg -l` | `rpm -qa` |

### Network

| I need to... | Command |
|---|---|
| see my IP addresses | `ip addr` |
| see the routing table / gateway | `ip route` |
| test whether a host is reachable | `ping -c 4 host` |
| look up a name in DNS | `dig name` or `nslookup name` |
| list listening ports | `ss -tuln` or `netstat -tuln` |
| see or change the hostname | `hostname` / `hostnamectl set-hostname name` |
| log in to another computer | `ssh user@host` |
| copy a file to another computer | `scp file user@host:/path/` |
| sync a directory | `rsync -av src/ dest/` |
| open a firewall port | `ufw allow 22/tcp` or `firewall-cmd --add-port=22/tcp --permanent` |

### System information

| I need to... | Command |
|---|---|
| kernel version | `uname -r` |
| distribution and version | `cat /etc/os-release` |
| how long the system has been up, and load | `uptime` |
| kernel and hardware messages | `dmesg` |
| read the systemd journal | `journalctl -u name` |
| see or set the time zone | `timedatectl` / `timedatectl set-timezone Zone` |
| list environment variables | `env` or `printenv` |
| see my home directory | `echo $HOME` |
| get help on a command | `man command` |

### Files to know

| File | Holds |
|---|---|
| `/etc/passwd` | user accounts |
| `/etc/shadow` | password hashes |
| `/etc/group` | groups |
| `/etc/sudoers` | sudo rules (edit with `visudo`) |
| `/etc/fstab` | file systems to mount at boot |
| `/etc/hostname` | this computer's name |
| `/etc/hosts` | local name-to-IP table |
| `/etc/resolv.conf` | DNS servers and search domains |
| `/etc/crontab` | system cron table |
| `/etc/default/grub` | GRUB settings |
| `/etc/ssh/sshd_config` | SSH server settings |
| `/etc/os-release` | distribution name and version |
| `/var/log/syslog` or `/var/log/messages` | main system log |
| `/var/log/auth.log` or `/var/log/secure` | login and sudo log |
| `~/.bashrc` | your shell settings and aliases |
| `~/.bash_history` | your command history |
| `~/.ssh/authorized_keys` | public keys allowed to log in |

---

*MCCC IT Academy — BPA 350 Linux Operating System Fundamentals. Original study material written for our students. It is not a copy of any BPA test.*
