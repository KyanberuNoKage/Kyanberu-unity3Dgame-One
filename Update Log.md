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
