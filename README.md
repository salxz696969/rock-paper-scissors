# Rock Paper Scissors

Simple Unity project for a rock–paper–scissors mini game that includes a welcome screen, play scene, and win/lose flows.

## Requirements

-   Unity `2022.3.47f1` (LTS)
-   TextMesh Pro is already part of the project; no extra packages are needed

## Getting Started

1. Open the folder `rock_paper_scissors` in Unity Hub.
2. When prompted, confirm the recommended editor version (2022.3.47f1).
3. Once the project loads, open `Assets/Scenes/homeScene.unity` and press `Play`.

## Gameplay Flow

-   Choose rock, paper, or scissors from the UI buttons.
-   The `GameManager` script resolves the round and sends you to either `gameWin` or `gameOver` scenes.
-   Use the provided buttons to replay or quit back to the welcome scene.

## Folder Highlights

-   `Assets/scripts` – C# scripts (`GameManager`, `GameSceneManager`, `KeepMusic`).
-   `Assets/Scenes` – All Unity scenes for the menu and gameplay loop.
-   `Assets/prefabs` – Reusable UI elements for the choices and common buttons.

Feel free to tweak the UI, add sound effects, or extend the logic for score tracking.
