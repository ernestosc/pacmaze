PAC-MAZE by Augmented Sauce

[ Development platforms: Windows 10 / OS X El Capitan]

[ Mobile platform: Android 5.1.1 Samsung Galaxy Note 4]

[ Video URL: https://drive.google.com/a/columbia.edu/file/d/0B9pt1m_nlNVtNlVPN3RhWm5QajA/view ]

[ Project Directory Overview ]

  - PacMaze [Unity Project Folder]
  - AugmentedSauce-WrittenDescription.pdf
  - AugmentedSauce-RepresentativeScreenshot.png
  - AugmentedSauce-Screenshot-Paragraph-Permission.pdf
  - README.txt

[ USAGE INSTRUCTIONS ]

    REQUIRED IMAGE TARGETS (Assignment3 database):
        - tarmac: Maze position
        - stones: Remote control, button interface
        - acid  : Rotation/Scale Workspace
        - vortex: Wand pointer

    SETUP:

        - Please position the image targets as specified on the Project
          description, or to the user's preferred convenience.
        - Hold the vortex image target with the user's dominant hand,
          while the other hand is used to hold the phone and look at
          the other image targets through the camera.

    TRANSFORMING THE MAZE:

        - If the user wishes to scale/rotate the maze itself, then 
        press the 'Maze' button on the Remote control. Select the 
        desired transformation using the buttons on the remote control
        once again. (Note: buttons can be pressed by either occluding
        them with the user's hand or the vortex image target itself). 

        - If the user selects rotation, he/she will have to select 
          which axis to rotate around through the remote control. 
          Using the wand, move the wand Up and down to rotate the 
          maze around the chosen axis, or inwards and outwards to 
          scale it (depending on the mode the user selected on the
          previous steps). To finish, press the 'done' button on 
          the remote control.

    TRANSFORMING THE OBJECT:
        - If the user wishes to begin transforming/moving the object,
         then he/she should select it by touching the object with the 
         virtual wand.
        - Once the object is selected (highlighted) the user can choose
         to either move it or transform it in the workspace by pressing
          the correct virtual button on the remote control.
        - If translating the object, the user can either select a 
        neighboring cube by pointing at it with the wand and confirming
         with a tap on the screen of the phone. The object will move 
         automatically unless blocked by an obstacle.
        - If rotating the object the user must once again select an 
        axis to rotate around. Then, he/she can move the wand up and 
        down to rotate the object by 90 degree steps. If scaling the
         object, the user will once again have to move the wand inwards
         or outwards. To finish, please press the done button on the 
         remote control.
        - BONUS: The user could also use the teleport function, instead 
        of dragging the object around the maze. However this should 
        only be used as a cheat. It is an additional help to users who 
        may find dragging the object a little too slow. Additionally, 
        the user is not allowed to teleport to an actual gingerbread
        house, which means that he/she will still be faced with at 
        least one obstacles to reach each house.

    THE GOAL:
        - To win the game, drag the gingerbread man to the correct
         gingerbread house! (Only one of the 5 is correct)

[ Code Bugs ]

  - Passage through obstacles allows for mirrored orientations
    for passage from different directions.

  - Virtual button sensitivity is too high and layout puts them
    a bit too close to each other.

[ Asset Sources ]

  - Skybox Unity Assets Store
  - Gingerbread house model from:
  	www.planit3d.com/source/meshes_files/gingerbread.html
  - Wood material is from Luis' demo earlier in the class.
  - All other Materials are from the Unity Assets Store.
  - Everything else is original content.
  - Vuforia
