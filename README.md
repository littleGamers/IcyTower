# IcyTower
Escape from prision, but be carefull not to fall!

Jump using the steps leading to the jail bars to your escape from prison.

<br/>

## Instructions:

Move with the LEFT and RIGHT arrow keys.

Jump with SPACE key.

To go to the next level use LEFT CTRL when instructed on the screen.

<br/>

## Components

**[GameOver](Assets/Scripts/GameOver.cs) -** Used with an edge colider to end the game when player fall down from the screen. 
<br />

**[KeyboardForce](Assets/Scripts/KeyboardForce.cs) -** Controls the player's dynamic movement using forces.
<br />

**[stepLevelSpawner](Assets/Scripts/stepLevelSpawner.cs) -** Moves with the camera and spawns new steps as the player moves up.
<br />

**[StopSpawner](Assets/Scripts/StopSpawner.cs) -** Placed near the finish line and used to stop the stepSpawner from working when player reached the final step.
<br />

**[TouchDetector](Assets/Scripts/TouchDetector.cs) -** Detects if the player is touching the ground (used to restrict jumping).
<br />

**[WinLevel](Assets/Scripts/WinLevel.cs) -** Used with an edge colider to win the game when player reach the final step.
<br />

## External Links

Play the game on Itch.io:

https://littlegamers2021.itch.io/icytowerprisonbreak

## Credits

<a href='https://pngtree.com/so/window'>window png from pngtree.com/</a>

## **Have Fun!**

