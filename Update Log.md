# Kyanberu-unity3Dgame-One
The first 3D game ive made in years, hope it goes well...

-----------------------------------------------------------------------------------------------------------------

10/10/2020:
Created:
- Created First Room/Map
- Created Materials For Map
- Created Player
- Created Player Controller Script (movement controls, ability to jump)

-----------------------------------------------------------------------------------------------------------------

11/10/2020:
Created:
- Created The First Gun Object.
- Created Bullet Prefab.
- Created First Gun Script (instantiating bullets, ammo count, reload etc.)
- Created Bullet Prefab Script (moves forwards at constant speed with given rotation, destroys on impact or over time)

-----------------------------------------------------------------------------------------------------------------

12/10/2020:
Fixed:
- Fixed The Bullets Not Colliding With Objects (Mostly).
- Fixed Bullets Being Destroyed On Collision With Objects.

Created:
- Second Gun (duplicate of the first gun with diffrent ammo, fire rate and reload speed)
- Particle System Prefab Obj For The Bullets Collision/Impact.
- DestroyOverTime Script Created (destroys the object its attacked to after given amount of time)

Edited:
- Edited The Bullet Script To Instanciate The Bullet Hit Prefab Object With A Rotation That Is Perpendicular To The Object It Has Collided With.

-----------------------------------------------------------------------------------------------------------------

13/10/2020:
Fixed:
- Removed The Collision System That Handles Bullet Collisions And Replaced It With A New System (see below in "Edited" section)

Created:
- New Gun Object, GunTwo-AutoRifle (dupe of the first gun object)
- New Script For Automatic Guns (player can hold mouse button to auto fire)
- Holster Scroll Function Script (the ScrollWheelScript changes which child gun object of the GunHolster object is active using a list of GameObjects)
- New Bullet Prefab & Bullet Material (dupe of first bullet prefab with diffrent material, this is the prefab used in the new gun object)

Edited:
- Changed The System That Detects Bullet Impact. (switched from detecting collider collisions to using a ray on the bullet)
- GunOneScript (added a rotation and local position change on reaload which will be a visual replacement of the reload Debug.Log)
- Organised Some Scripts And Asset Folders.

-----------------------------------------------------------------------------------------------------------------

14/10/2020:
Created:
- Bullet Models In Blender (saved the blender files in the project for better workflow)
- Created Two Prefabs Of The Bullet Model With Two Seperate Textures (bullet red and bullet purple)

Edited:
- Moved Blender Models From GitHub Repo File To Blender Model File In Projects Asset Folder (for better workflow)
- Removed The Gun Model/Materials/Textures Due To Bugy Materials In Unity (will be remade and used at a later date)

-----------------------------------------------------------------------------------------------------------------

15/10/2020:
Fixed:
- Fixed Issue With Indavidual Guns Not Having There Own Script Values Due To Them Using The Same Script With Public Variables (created prefabs and made some of the code public)

Created:
- The Model For The First Modeled Gun And The Textures For It (the model was created in blender and the texture was used to create an unlit texture material)

-----------------------------------------------------------------------------------------------------------------

16/10/2020:
Created:
- New Bullet Prefab (varient of red bullet with a diffrent particle system)
- New Particle System For The New Bullet Prefab (uses diffrent material for its particles, diffrent particle movement/effect)
- Prefabs For The Guns When Not Picked Up.
- Script For Picking Up Guns Using A Tag System (when the player interacts with it the gun, the gun with the same name in the gunHolster object is found and is set to "picked up")

Edited:
- Changed "OnButtonUp()" To "OnButtonDown()" For The "Fire()" Method.

-----------------------------------------------------------------------------------------------------------------

17/10/2020:
Fixed:
- Model Textures.

Created:
- New Gun Model ("The Shark")
- Reload Animation For The New Gun
- Script To Move The Ammo Mag For The New Gun While Its Being Fired.

Edited:
- PurpleBullet Size (to fit the scale of the new gun model)

-----------------------------------------------------------------------------------------------------------------

18/10/2020:
Fixed:
- Fixed The Rotation And Texture Problems With The 'Shark' Gun.

Created:
- New Model For A Mob (robot)
- Created And Implemented New Particle System For A Muzzle Flash Effect On The Shark Gun.
- New Particle System For The Mobs 'Blood' Splatter For When The Mob Is Killed And One For When The Mob Is Hit.
- A Reload Particle System For The LowPollyGun Object.

Edited:
The Bullets 'MoveAndDestroySelf' Script To Implement The New 'Blood' Particle Systems.

-----------------------------------------------------------------------------------------------------------------

19/10/2020:
Fixed:
- Minor Fixes To Scripts And Object References.

Created:
- Created Player Health System (500 health, when hit by mob's bullet the health goes down)
- Created UI Overlay (crosshair in the middle of screen, health bar that responds to the value of "health" in the player health script)
- Created Pause Menu (pressing "TAB" opens and closes the pause menu, can change mouse/look sensitivity with UI slider, can quit game with "ExitGameButton")
- Created Game Over Screen (displayed when the player dies)
- Created Texture For The Mob.
- Created Attack AI For Mobs (while player is in range they aim their gun and fire at a randomly set interval)
- Created Blood Particle System For Player Hit (variation of the "BloodParticleSystem", played when player is hit by a mobs bullet)
- Created Score System (when player kills a mob the score goes up by 10, there are 10 mobs on the map therefor when the score = 100 the game ends)

Edited:
- Bullet One Prefab Script (gave it new script so that collisions with the player could be detected)
- Changed The Initial Mouse Sensitivity In "PlayerLookAround" Script.

-----------------------------------------------------------------------------------------------------------------

20/10/2020:
Created:
- The GAME OVER screen for when the player dies.

Edited:
- The "GlobalValues" Script (so that the GAME OVER canvas is displayed on players death)

-----------------------------------------------------------------------------------------------------------------
