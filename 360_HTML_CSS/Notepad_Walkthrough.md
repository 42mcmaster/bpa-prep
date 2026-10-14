# BPA 360 HTML and CSS: Notepad Walkthrough (Windows)

## Overview
In the real competition you get a computer with a browser and **plain Windows Notepad**. Nothing else. No VS Code, no Live Preview, no autocomplete, no color coding, and **not Notepad++** (the rules say using it means disqualification). This walkthrough gets you comfortable building a page the way you will have to on contest day.

**Time Estimate:** 20-30 minutes

**What you need:**
- A Windows computer
- The [360 Reference Guide](360_HTML_CSS_Reference_Guide.md), printed

---

## Part 1: Set Up a Project Folder

Every contest build is a folder with an HTML file, a CSS file, and any images.

1. On the Desktop, right-click, **New > Folder**. Name it `bpa_practice`.
2. Open the folder. Leave it open; you will come back to it.

---

## Part 2: Open Notepad and Save the HTML File First

Save before you type anything. If you save first, Notepad knows it is an HTML file and you will not lose work.

1. Press the Windows key, type `notepad`, press Enter.
2. Press **Ctrl+S** right away.
3. In the Save dialog:
   - Go to your `bpa_practice` folder.
   - **Save as type:** change it from "Text Documents (*.txt)" to **All Files (*.*)**. This is the step everyone misses. If you skip it, Notepad saves `index.html.txt` and the browser will not open it as a web page.
   - **File name:** `index.html`
   - **Encoding:** UTF-8 (the default)
   - Click Save.

Check the folder. You should see `index.html` with a browser icon, not a notepad icon. If it has a notepad icon, the name ended in `.txt`. Delete it and do step 3 again.

---

## Part 3: Type the Starter Page

Notepad does not autocomplete. You type every character, including every closing tag. Type this:

```html
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Contestant Number - HTML and CSS Coding</title>
  <link rel="stylesheet" href="styles.css">
</head>
<body>

  <div id="wrapper">
    <h1>Practice Page</h1>
    <p>If you can see this with a white box around it, the CSS file is linked.</p>
  </div>

</body>
</html>
```

Press **Ctrl+S** to save. Get in the habit: save after every few lines.

**Habits that save you on contest day:**
- Type the opening tag, then the closing tag right away, then go back and put the content between them. You will never forget a closing tag.
- Use two spaces to indent nested tags. Notepad does not do it for you, and the graders read your code.
- Turn on **View > Word Wrap** so long lines do not run off the screen.
- Turn on **View > Status Bar** so you can see the line number when the browser shows a problem.

---

## Part 4: Make the CSS File

1. In Notepad, **File > New Window** (Ctrl+Shift+N). A second Notepad opens.
2. **Ctrl+S**. Same folder, **Save as type: All Files**, name it `styles.css`.
3. Type:

```css
/* Formatting for the practice page */

body {
  background-color: #800000;
  font-family: "Times New Roman", Times, serif;
  color: #000000;
}

#wrapper {
  width: 1000px;
  margin: 20px auto;
  padding: 25px;
  background-color: #FFFFFF;
}

h1 {
  color: #000080;
  text-align: center;
}
```

4. **Ctrl+S**.

Keep both Notepad windows open side by side. Alt+Tab switches between them.

---

## Part 5: Open It in the Browser

1. Go to the `bpa_practice` folder and double-click `index.html`. It opens in the browser.
2. You should see a dark red page with a white box, a centered dark blue heading, and the sentence.

**The edit-and-refresh loop.** This is how you work for the whole 90 minutes:

1. Change something in Notepad.
2. **Ctrl+S**.
3. Click the browser and press **F5** to refresh.
4. Look. Repeat.

If the change does not show up, you forgot to save. If the page is unstyled (black text on white, no box), the CSS is not linked: check that the file is named exactly `styles.css`, that it is in the same folder, and that the `<link>` line matches.

---

## Part 6: Add an Image

1. Put any image file in the `bpa_practice` folder. Name it `logo.png` (or `.jpg`, whichever it is).
2. In `index.html`, inside the wrapper under the `<h1>`, add:

```html
    <img src="logo.png" alt="Practice logo" id="logo">
```

3. In `styles.css`, add:

```css
#logo {
  width: 300px;
  display: block;
  margin: 0 auto;
}
```

4. Save both. F5. The image should appear centered.

If you see a broken-image icon, the file name does not match. Check spelling and the extension. Windows hides extensions by default: in the folder, **View > Show > File name extensions** turns them on.

---

## Part 7: What You Turn In at the Contest

At the end, the judges want printed code and a screenshot. Practice this now so it is not a surprise.

1. **Screenshot the browser page:** press **Windows + Shift + S**, drag over the page, then open Paint (Windows key, type `paint`), **Ctrl+V**, save it as `screenshot.png` in your folder. (Or use **Print Screen** and paste into Paint.)
2. **Print the code:** in each Notepad window, **File > Print**. At the contest they tell you which printer. In practice, choose "Microsoft Print to PDF" and save the PDFs into your folder.
3. Put your contestant number on everything they tell you to.

---

## Part 8: Things That Cost Points

- A `<style>` tag or `style=""` attribute anywhere. The rules say **external CSS only**. Every style goes in `styles.css`.
- A `<table>` used for layout.
- A missing closing tag. Count them.
- The wrong `<title>`. It is always "Contestant Number - (event name)" and they check it.
- Wrong hex colors. Copy them from the spec exactly.
- Saving as `.txt`. Check the icon.

---

## Submission Checklist
- [ ] `bpa_practice` folder with `index.html`, `styles.css`, and an image
- [ ] Page opens in the browser with the CSS working
- [ ] Image shows up
- [ ] Screenshot saved
- [ ] Code printed to PDF

You are ready for the practice build in Week 1.
