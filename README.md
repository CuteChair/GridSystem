# Technical prototye - Factory Grid System

## Overview

this project is a technical prototype exploring core systems required for a grid-based factory or building game.

It focuses on grid generation, snap-to-grid placement, and building positioning, rather than on gameplay, progression, or visuals.
The goal of this prototype is to validate the robustness and flexibility of the underlying grid logic before building full gameplay systems on top of it.

---

## Systems implemented 

**Grid System**

 - Procedural grid generation
 - Configurable cell size
 - World position ↔ grid coordinate conversion
 - Grid cell indexing and lookup

**Placement System**

 - Snap-to-grid logic for placed objects
 - Grid-aligned placement validation
 - Visual-only building placement
 - Grid cell occupancy tracking (if applicable)

**Architecture**

**Clear separation between:**

 - Grid data
 - Placement logic
 - Visual representation



## Project Status

**This project is a technical prototype and is meant to be reusable for future projects**

---

## Built With
- Unity
- C#
