# 360 HTML and CSS Coding Reference Guide

*This event was called 415 Fundamentals of Web Design before 2026-27. Same content, new number.*

## Essential HTML5 and CSS for BPA Competition

### Basic HTML5 Document Structure
```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Your Contestant Number -- Fundamentals of Web Design</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <!-- Your content here -->
</body>
</html>
```

## HTML5 REFERENCE

### Essential HTML5 Semantic Elements
```html
<!-- Semantic structure elements -->
<header>Page or section header</header>
<nav>Navigation links</nav>
<main>Main content</main>
<article>Self-contained content</article>
<section>Thematic grouping</section>
<aside>Side content</aside>
<footer>Page or section footer</footer>

<!-- Non-semantic container -->
<div id="wrapper">Content container</div>
```

### Text Elements
```html
<!-- Headings -->
<h1>Main Heading</h1>
<h2>Subheading</h2>
<h3>Sub-subheading</h3>

<!-- Paragraphs -->
<p>This is a paragraph of text.</p>

<!-- Line break -->
<br>

<!-- Horizontal rule -->
<hr>

<!-- Text formatting -->
<strong>Bold text</strong>
<em>Italic text</em>
<u>Underlined text</u>
```

### Links
```html
<!-- Basic link -->
<a href="https://example.com">Visit Example</a>

<!-- Email link -->
<a href="mailto:info@example.com">Email Us</a>

<!-- Link to another page -->
<a href="about.html">About Page</a>

<!-- Link that opens in new tab -->
<a href="https://example.com" target="_blank">Open in New Tab</a>
```

### Images
```html
<!-- Basic image -->
<img src="image.jpg" alt="Description of image">

<!-- Image with dimensions -->
<img src="logo.png" width="200" height="100" alt="Company Logo">

<!-- Using class for styling -->
<img src="photo.jpg" class="alignLeft" alt="Photo">
```

### Lists
```html
<!-- Unordered (bulleted) list -->
<ul>
    <li>First item</li>
    <li>Second item</li>
    <li>Third item</li>
</ul>

<!-- Ordered (numbered) list -->
<ol>
    <li>Step one</li>
    <li>Step two</li>
    <li>Step three</li>
</ol>
```

### Tables (Not for Layout!)
```html
<table>
    <thead>
        <tr>
            <th>Header 1</th>
            <th>Header 2</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Data 1</td>
            <td>Data 2</td>
        </tr>
        <tr>
            <td>Data 3</td>
            <td>Data 4</td>
        </tr>
    </tbody>
</table>
```

### Forms
```html
<form action="submit.php" method="post">
    <!-- Text input -->
    <label for="name">Name:</label>
    <input type="text" id="name" name="name">
    
    <!-- Email input -->
    <label for="email">Email:</label>
    <input type="email" id="email" name="email">
    
    <!-- Textarea -->
    <label for="message">Message:</label>
    <textarea id="message" name="message" rows="4"></textarea>
    
    <!-- Submit button -->
    <input type="submit" value="Submit">
</form>
```

### HTML5 Media Elements
```html
<!-- Video -->
<video width="320" height="240" controls>
    <source src="video.mp4" type="video/mp4">
    Your browser does not support the video tag.
</video>

<!-- Audio -->
<audio controls>
    <source src="audio.mp3" type="audio/mpeg">
    Your browser does not support the audio element.
</audio>
```

## CSS REFERENCE

### Linking CSS to HTML
```html
<!-- External stylesheet (REQUIRED for BPA) -->
<link rel="stylesheet" href="styles.css">

<!-- NO INLINE STYLES ALLOWED IN BPA! -->
```

### CSS Selectors
```css
/* Element selector */
body {
    color: #000;
}

/* Class selector */
.className {
    font-size: 14pt;
}

/* ID selector */
#wrapper {
    width: 1000px;
}

/* Multiple selectors */
h1, h2, h3 {
    font-family: Arial, sans-serif;
}

/* Descendant selector */
nav a {
    text-decoration: none;
}
```

### Common CSS Properties

#### Text and Font
```css
/* Font family */
font-family: "Times New Roman", serif;
font-family: Arial, sans-serif;
font-family: Verdana, sans-serif;

/* Font size */
font-size: 12pt;
font-size: 14px;
font-size: 1.5em;

/* Font weight */
font-weight: normal;
font-weight: bold;

/* Text alignment */
text-align: left;
text-align: center;
text-align: right;

/* Text decoration */
text-decoration: none;
text-decoration: underline;

/* Text color */
color: #000;          /* Black */
color: #FFF;          /* White */
color: #000080;       /* Navy blue */
color: #F00;          /* Red */
```

#### Colors
```css
/* Common color formats */
color: #000000;       /* Hexadecimal (6 digits) */
color: #000;          /* Hexadecimal (3 digits) */
color: rgb(0, 0, 0);  /* RGB */

/* Common colors in hex */
#000 or #000000       /* Black */
#FFF or #FFFFFF       /* White */
#F00 or #FF0000       /* Red */
#0F0 or #00FF00       /* Green */
#00F or #0000FF       /* Blue */
#000080               /* Navy */
#090 or #009900       /* Green */
```

#### Box Model
```css
/* Width and height */
width: 1000px;
height: 500px;

/* Padding (inside space) */
padding: 5px;                    /* All sides */
padding: 10px 20px;              /* Top/bottom, left/right */
padding: 10px 15px 20px 15px;    /* Top, right, bottom, left */
padding-top: 10px;
padding-right: 15px;
padding-bottom: 20px;
padding-left: 15px;

/* Margin (outside space) */
margin: 0 auto;                  /* Center horizontally */
margin: 10px;                    /* All sides */
margin-top: 20px;
margin-bottom: 20px;

/* Border */
border: 1px solid #000;
border-width: 2px;
border-style: solid;
border-color: #000;
```

#### Background
```css
/* Background color */
background-color: #FFF;
background-color: #000080;

/* Background image */
background-image: url('image.jpg');
background-repeat: no-repeat;
background-position: center;
background-size: cover;
```

#### Layout
```css
/* Display */
display: block;
display: inline;
display: inline-block;
display: none;

/* Float (for image alignment) */
float: left;
float: right;
float: none;

/* Clear floats */
clear: both;

/* Position */
position: relative;
position: absolute;
position: fixed;
```

### Common BPA Pattern: Wrapper/Container
```css
/* In CSS file */
#wrapper {
    width: 1000px;
    background-color: #FFF;
    padding: 5px;
    margin: 0 auto;  /* Center horizontally */
}

body {
    background-color: #000080;
    margin: 0;
    padding: 0;
}
```

```html
<!-- In HTML file -->
<body>
    <div id="wrapper">
        <!-- All page content goes here -->
    </div>
</body>
```

### Common BPA Pattern: Image Alignment Classes
```css
.alignLeft {
    float: left;
    padding: 15px;
}

.alignRight {
    float: right;
    padding: 15px;
}

.textCenter {
    text-align: center;
}
```

```html
<img src="image.jpg" class="alignLeft" alt="Description">
<h1 class="textCenter">Centered Heading</h1>
```

### Complete Example for BPA Contest

**HTML (index.html):**
```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>12345 -- Fundamentals of Web Design</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <div id="wrapper">
        <h1 class="textCenter">Holly's Home Pet Sitting Service</h1>
        <h2 class="textCenter">Where the Safety of your Home and Pets Come Together</h2>
        <hr>
        
        <p>Holly's Home Pet Sitting Services offer a variety of different services...</p>
        
        <img src="home.jpg" width="210" height="136" class="alignLeft" alt="Home with Pet">
        <img src="playtime.jpg" width="181" height="136" class="alignRight" alt="Playtime">
        
        <h2>Full Service In-Home Pet Sitting:</h2>
        <ul>
            <li>Pet sitter stays in your home with your pets overnight</li>
            <li>Care for house and yard plants</li>
            <li>Feed, walk and water your pets</li>
            <li>Ample playtime with your pets</li>
            <li>For peace of mind you would know that your pets would not be spending long periods of time home alone or in a cage</li>
            <li>Can also care for goldfish, gerbils, lizards, etc. <span class="green">(upon request)</span></li>
        </ul>
        
        <h2>Minimum Service In-Home Pet Sitting:</h2>
        <ol>
            <li>Minimum of two times a day feeding and water check</li>
            <li>Minimum of 30-minute walk</li>
            <li>One to two hours of pet playtime</li>
        </ol>
        
        <p><a href="mailto:information@hollyshomepetsitting.com">Please contact us for more information</a></p>
    </div>
</body>
</html>
```

**CSS (styles.css):**
```css
body {
    width: 1000px;
    font-family: "Times New Roman", serif;
    font-size: 12pt;
    margin: 0 auto;
    background-color: #000080;
    color: #000;
}

#wrapper {
    width: 1000px;
    background-color: #FFF;
    padding: 5px;
}

h1 {
    font-family: Verdana, sans-serif;
    font-size: 24pt;
    color: #000080;
    font-weight: normal;
}

h2 {
    font-family: Arial, sans-serif;
    font-size: 14pt;
    color: #F00;
    font-weight: normal;
}

hr {
    height: 12px;
    background-color: #000080;
    border: none;
}

.alignLeft {
    float: left;
    padding: 15px;
}

.alignRight {
    float: right;
    padding: 15px;
}

.textCenter {
    text-align: center;
}

.green {
    color: #090;
}
```

## Key BPA Contest Rules

1. **DOCTYPE must be HTML5:** `<!DOCTYPE html>`
2. **NO TABLES FOR LAYOUT** - Only for tabular data
3. **ALL STYLING IN EXTERNAL CSS** - No inline styles or `<style>` tags
4. **NO ATTRIBUTES IN `<body>` TAG** - All styling in CSS
5. **Use semantic HTML5 elements** when appropriate
6. **Images need alt text** for accessibility
7. **Wrapper/container** to hold page content
8. **Proper indentation** for readability

## Generic Font Families
There are **5** generic font families browsers recognize:
1. serif (Times New Roman, Georgia)
2. sans-serif (Arial, Helvetica)
3. monospace (Courier, Consolas)
4. cursive (Comic Sans MS)
5. fantasy (Impact)

## Web Color Values
- Colors are expressed in **hexadecimal numbers** (#RGB or #RRGGBB)
- Can also use RGB: `rgb(255, 0, 0)`

## Protocols
- **HTTP** (HyperText Transfer Protocol) - Web page transfer
- **TCP/IP** - Primary communication on Internet
- **FTP** - File Transfer Protocol

## HTML5 Features
- Streamlined DOCTYPE: `<!DOCTYPE html>`
- New semantic elements: `<nav>`, `<article>`, `<section>`, etc.
- Native audio and video support
- Backwards compatible with existing web

## Common Mistakes to Avoid
1. Using tables for layout (PROHIBITED)
2. Inline styles or style attributes (PROHIBITED)
3. Forgetting alt text on images
4. Not closing tags properly
5. Forgetting to link external stylesheet
6. Not using wrapper/container div
7. Wrong DOCTYPE declaration

---
**Remember**: Use Notepad only (no Dreamweaver or other tools)! Print your code AND browser screenshot!
