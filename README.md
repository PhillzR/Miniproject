# Miniproject
![Garfield_(video_game)](https://github.com/user-attachments/assets/72f081ea-30ec-483d-a4ad-b6a42287c13e)

**Project Name:** Garfield ...but worse
<br> **Name:** Phillip Rumpelthiin

## Overview of the Game
I have chosen to try to somewhat replicate the Garfield game. The premise of the original game is that you play as Garfield and need to clean up the house before Jon gets home, otherwise you will not get lasagna. You have a vacuum to vacuum up objects and blow them out onto their right places again, that's the core loop of the game - and what I have chosen to focus on. 

**Game features:** 
*	Player - Able to move around using WASD and controller as I used the “new” input system in Unity. 
*	Camera - The player is able to look around with the use of a cinemachine virtual camera with the Player gameobject as Follow and Look At target. The Body is set as Transposer and Aim as POV.
*	Objects to vacuum and place - Some primitives with a material, collider and a tag making the player able to pick it up and place it with the use of raycasting.
*	Some obstacles to push around - just some primitives with a collider and a rigidbody component and the mass lower than the players. They all have the same material. 
- Domino bricks
- A big box
- A small box
- A big sphere
*	Visual Effect (Shadergraph shader) to show where the objects should be placed. Just a simple shader using a Time node with Sine Time and a Smoothstep node to make the objects size/scaling “pulse”, a variable for transparency set to 0.8 and a base color. 


### Project Parts:
**Scripts:** 
* PlayerController - All the functionality is in here, Move, Vacuum, Look, Sprint - I wanted a jump mechanic as well but it took too long to bugfix. 

**Models & Prefabs:**
In terms of models i have only used primitives. 
For prefabs I have:
*	Player
*	Objects to vacuum
*	Object for placement
*	Player camera
*	Domino bricks
*	Variants of objects to vacuum + objects for placement


**Materials:**
* PlayerMaterial
* ObjectMaterial
* SilhouetteShaderMaterial - Made from the shadergraph shader. 
* Ground - A probuilder plane where I have edited the vertices a little bit. 
* Skybox
* Variant materials

**Scenes:** 
* Sandbox

**Testing:**
<br> The game is only tested on a windows pc. 

### Features I ran out of time to implement: 
* Enemy: Odie, who follows the player around and is occasionally annoying by walking into you - I would have used NavMesh and a NavMeshAgent component on the enemy to make this possible and probably make a range around it to make it “attack” the player if the player was in range and otherwise choose some random points on to walk towards. 
* I need to bugfix the player controller as the rotation of the player changes with collisions, so the WASD controls changes. 
* Jumping mechanic, I had trouble with physics because I set the linear velocity on the y axis to 0 in update. I did not find a fix in time.
* GUI to see vacuumed objects - I would have used a render texture to place the objects as an image in the top-left corner of the screen and a switch statement to toggle between them, to make it possible to carry more objects around and placing them.  


## Time Management
Task  | Time it took (in hours)
------------- | -------------
Setting up Unity, making a project in GitHub  | 0.5
Conceptualization of game idea | 0.5
Making camera movement, player control and initial testing | 2
Bugfixing jumping mechanic and research into physics in Unity | 3
Making vacuum mechanic | 3
Making readme | 0.75
Obstacles to push | 0.25
Scene set up | 0.25
**All** | **10.25**

## Used Resources
https://docs.unity.com/
https://discussions.unity.com/ 








