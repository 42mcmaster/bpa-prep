# Endless Runner Tutorials for Godot

## Overview
Watch one of these before you write any code. The point is to see how a Godot endless runner is put together: a player that jumps, obstacles that scroll toward it, a spawner, collision, a score, and game over. Then build your own version for Afterburn.

**Do not copy a tutorial game and reskin it.** The judges grade an original game. Use the tutorials to learn the pieces, then build the Afterburn pieces yourself. Any code you take from a tutorial goes in your works cited.

All of these are on YouTube. Pick one main series and follow it start to finish. Use the others when you get stuck on one part.

---

## Start Here (complete game, one video)

**Godot 4 T-Rex Endless Runner Game - Complete Game Tutorial**
https://www.youtube.com/watch?v=THauvoHBKLk
A full endless runner (like the Chrome dinosaur game) built from nothing in Godot 4, in one video. Covers the player, ground scrolling, obstacle spawning, collision, score, and game over. The closest match to what Afterburn needs. Watch this first.

**Endless Runner: From Scratch to Leaderboards with Godot 4.4**
https://www.youtube.com/watch?v=Rq6jz0cglMc
Another complete build in Godot 4.4. Goes further into saving scores, which Afterburn needs (persistent high scores are one of the graded competencies).

---

## Step-by-Step Series (one topic per video)

**Making an Endless Runner in Godot**
- Part 1, Scrolling Background: https://www.youtube.com/watch?v=3OpH4j4zpPU
- Part 4, Object Pool: https://www.youtube.com/watch?v=spLLaA1f1ho
Find the rest of the parts on the same channel. The object pool video matters: spawning and deleting hundreds of obstacles slows a game down, and pooling fixes it.

**Godot beginner tutorial, endless runner**
- Part 1, Introduction: https://www.youtube.com/watch?v=K6eJ7zUsIVU
- Part 4: https://www.youtube.com/watch?v=br9GV7xadSo
Beginner pace. Good if you have never opened Godot.

**Godot 4 Infinite Runner Tutorial**
- Part 2: https://www.youtube.com/watch?v=dPLDxya2BiU
Find Part 1 on the same channel.

---

## Other Useful Ones

**Godot Endless-Runner Tutorial**
https://www.youtube.com/watch?v=0amclwspR0w

**Learn to make an endless runner game with Godot**
https://www.youtube.com/watch?v=bFzhy3g0T5A

**Godot 4 GDScript Beginners Tutorial, Part 1**
https://www.youtube.com/watch?v=wy2lK8KMu-U
Not a runner. If GDScript looks strange, this is the language from the start. It is close to Python.

**Sample project on GitHub: learning-godot/endless-runner**
https://github.com/learning-godot/endless-runner
Working 2D endless runner source code you can open in Godot and read. Read it; do not copy it.

---

## Check the Godot Version

Some older videos use Godot 3. The code looks similar but does not run in Godot 4 (for example, `KinematicBody2D` became `CharacterBody2D`, and `yield` became `await`). If a video's title does not say Godot 4, check the first minute. Stick to Godot 4 tutorials.

---

## What Afterburn Needs That Most Tutorials Skip

The tutorials get you a runner that jumps over things. The BPA competencies also require:

- **Three moves:** dash, jump, and slide, not just jump.
- **State management:** a menu, pause, game over, and restart that all work.
- **Persistent data:** high score, unlocked gadgets, and settings saved to a file and loaded next time (look up `FileAccess` and `ConfigFile` in the Godot docs).
- **Procedural generation that is fair:** obstacle patterns that are random but always possible to survive, and get harder over time.
- **Power crystals** that keep the board running (a draining meter) and **gadgets** that unlock.
- **Obstacle behavior:** robots, scaffolding, and drones that act differently from each other.

Plan for these from the start. They are the difference between a tutorial game and a competition entry.
