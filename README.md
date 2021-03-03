# Can-I-Eat-You
"Can I Eat You" Open Source Release

The game was made for the **Brackeys Jam 2021.1** using **Unity**.
So the source code might be a bit messy sometimes.

# Movement
Animation method used for the player is inspired by the movement in the Hotline Miami.

*TopDownMovement.cs* script is slightly changed version of a Brackeys tutorial.


#### What is special about it?
Torso of the player and Legs are animated seperately.

**Torso**'s angle is set to rotate towards the **mouse cursor** by  code.   *RotateTowardsMouse.cs*
**Legs** are rotated according to **keyboard input** (wasd). 
 *RotateAccordingToMovement.cs*
 
Animation controller just takes the **Speed** parameter into account, because the rotation is done by code.
