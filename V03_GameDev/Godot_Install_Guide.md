# Godot Install Guide (Windows)

## Overview
Godot is the game engine for the V03 Afterburn project. It is free, there is no installer, and there is no account. You download one file, unzip it, and run it.

**Time Estimate:** 10 minutes

---

## Part 1: Download

1. Go to **https://godotengine.org/download/windows/**
2. Under **Godot Engine 4.7.2** (or whatever the current stable version is), find the **Standard** section. Click **Windows x86_64**. This is the normal 64-bit version.
   - **Do not** download the **.NET** version. That one is for C# and needs extra software installed. We are using GDScript, which is built in.
3. A zip file downloads, about 60 MB.

**Everyone on the team must use the same version.** A project opened in a newer Godot gets converted and may not open in the older one.

---

## Part 2: Unzip and Run

1. In Downloads, right-click the zip file and choose **Extract All**. Extract it to a folder you will keep, for example `Documents\Godot`.
2. Inside the extracted folder there is one file: `Godot_v4.7.2-stable_win64.exe` (the name shows the version). There is also a `console` version; ignore it.
3. Double-click the `.exe`. If Windows shows a "protected your PC" warning, click **More info**, then **Run anyway**. This happens with any program that is not from the Microsoft Store.
4. The Project Manager opens. That is Godot. There is no install step.

If the `.exe` will not run at all (nothing happens or a policy message appears), tell Mr. McMaster. The school may need to allow it.

**Tip:** right-click the `.exe` and choose **Pin to taskbar** so you can find it again.

---

## Part 3: Check That It Works

1. In the Project Manager, click **Create** (or **+ Create** / **New Project**).
2. Project name: `godot_test`. Click **Create Folder** so it gets its own folder. Renderer: leave **Forward+** selected. If the lab PC's graphics are old and the editor looks broken later, come back and choose **Compatibility** instead.
3. Click **Create & Edit**. The editor opens.
4. In the left panel under Scene, click **2D Scene**. A Node2D appears.
5. Press **F5** (Run Project). Godot asks you to pick a main scene; click **Select Current**, save as `main.tscn`. A gray window opens. That is your empty game running. Close it.

If you got the gray window, you are done. Godot works on this machine.

---

## Part 4: System Requirements (we should be fine in MCCC SE lab but just in case you are using this somewhere else)

From the Godot download page:
- Recommended: Vulkan 1.0 compatible graphics
- Minimum: OpenGL 3.3 or OpenGL ES 3.0 compatible graphics

Any lab PC from the last ten years meets the minimum. If the editor shows black or garbled panels, switch the project to the **Compatibility** renderer (Project > Project Settings > Rendering > Renderer).

---

## Part 5: Exporting a Windows .exe (for later)

The BPA submission needs a working executable. Godot needs one extra download for that, the **export templates**. You do not need this on day one.

1. In the editor: **Editor > Manage Export Templates**.
2. Click **Download and Install**. It gets the templates that match your Godot version (about 500 MB).
3. Then **Project > Export > Add > Windows Desktop > Export Project** produces an `.exe`.

Do this once, on whichever machine builds the final version.

---

## Submission Checklist
- [ ] Godot downloaded from godotengine.org (Standard, not .NET)
- [ ] Unzipped to a folder you will keep
- [ ] `.exe` runs and shows the Project Manager
- [ ] Test project created and runs with F5
- [ ] Version number written in the team design doc
