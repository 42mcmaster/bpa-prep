# BPA V03 Game Development Team — Week 1: Kickoff

## Overview
Get the team set up and moving. By the end of today: Godot runs on your machines, you have read the official topic, the team has a repo, everyone has a job, and there is a one-page design doc. No game code yet.

**Time Estimate:** the full Friday block

**What you need:**
- The V03 guidelines PDF (BPA Google Classroom, Virtual Events folder, `V03_Virtual_Game_Development_Team.pdf`)
- [Godot_Install_Guide.md](Godot_Install_Guide.md)
- [Endless_Runner_Tutorials.md](Endless_Runner_Tutorials.md)

---

## Part 1: Read the Topic Together (20 minutes)

Read pages 1-2 of the V03 PDF as a team. Write down, in your own words:
- The game title and what the player does
- The three moves (dash, jump, slide)
- What the obstacles are
- What power crystals and gadgets do
- The deadlines: register by Dec 1, submit by Jan 15
- The five competencies you are graded on

If you cannot explain all of these, read it again. Teams that go off topic are disqualified.

---

## Part 2: Install Godot (15 minutes each)

Do [Godot_Install_Guide.md](Godot_Install_Guide.md) on every team member's machine. Write the version number down.

---

## Part 3: Team Repo and Roles (20 minutes)

1. One person makes a GitHub repo named **`afterburn`** and adds the other team members as collaborators. Everyone clones it.
2. Add these files to the repo now, even if they are mostly empty:
   - `README.md` — team names, Godot version, one-paragraph game description
   - `design_doc.md` — see Part 4
   - `ai_log.md` — every time anyone uses AI for anything, one line: date, who, which tool, what for, what you kept. This becomes the required AI Usage form at the end. Start it today.
   - `works_cited.md` — every tutorial, asset, sound, or code snippet you use
3. Pick lanes. One person each (a team of 3 doubles up):

| Lane | Owns |
|---|---|
| Core code | player, physics, collision, the game loop |
| Levels and generation | obstacle spawner, patterns, difficulty ramp, fairness |
| Art and audio | skateboard, inventor, robots, drones, scaffolding, city, crystals, sounds, music |
| Docs and build | game manual, works cited, AI log, release forms, the final .exe and submission PDF |

The docs lane is a real job. Skipping it is how teams get disqualified.

---

## Part 4: One-Page Design Doc (30 minutes)

Write `design_doc.md`. Keep it to one page. Answer:
1. **Look:** what does the city look like? Pixel art, flat shapes, hand-drawn? Pick one the art person can actually make.
2. **Controls:** which keys for dash, jump, slide.
3. **Obstacles:** how a robot, a scaffold, and a drone each behave differently.
4. **Crystals:** how fast the board's power drains, how much a crystal adds.
5. **Gadgets:** three gadgets you could unlock and what each does. Pick the easiest one to build first.
6. **States:** menu, playing, paused, game over, restart. Draw them as boxes with arrows.
7. **Minimum game:** the smallest version that still counts as Afterburn. This is what you build first.

---

## Part 5: Watch One Tutorial (rest of the block)

Everyone watches the first video in [Endless_Runner_Tutorials.md](Endless_Runner_Tutorials.md). The core code person follows along and builds it in a throwaway project to learn the pieces. Nobody copies it into the team repo.

---

## Milestones

| Week | Goal |
|---|---|
| 1 | Godot installed, topic read, repo, roles, design doc (today) |
| 2 | A rectangle runs, jumps, dies on collision, score counts |
| 3 | Obstacles spawn in random patterns; speed ramps up; dash and slide work |
| 4 | Menu, pause, game over, restart all work |
| 5 | High score, settings, and unlocks saved to a file and loaded next run |
| 6 | Real art and sound; crystals drain and refill the board; one gadget unlocks |
| 7 | Game manual written; works cited and AI log complete |
| 8 | Windows .exe exported, tested on a clean machine, submission PDF assembled |
| 9 | Buffer. Submit before Jan 15. |

Every Friday ends with a two-minute demo to Mr. McMaster of whatever runs.

---

## Turn It In

In the Google Classroom **BPA Friday** assignment, write a private comment: *V03 week 1 done* with the link to the team repo. The repo must have the README, design doc, ai_log, and works_cited files.

## Grading
5 = all four files in the repo, design doc answers all seven questions, Godot runs for everyone. 4 = one thing missing. 3 = design doc thin. 2 = repo only. 0 = nothing.
