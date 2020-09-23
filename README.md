# Untitled Car Game

### Created by:
Collin Hughes
Brian Bennett
Brandon Louis
Peter Giovi

### Build Instructions
To begin, ensure that version 3.7.1 of the Monogame Framework is installed. It can be found here: http://community.monogame.net/t/monogame-3-7-1-release/11173
Next, clone the repository to your local machine and extract it. Open UntitledCarGame.sln in Visual Studio.

Inside of Visual Studio, build the solution for “Release” and run it. A Monogame Window will open to the main menu, showing a successful build and launch.

Installers can be generated using Inno Setup, an easy installer script generator for Windows.. It can be found here: https://jrsoftware.org/isdl.php#stable.

Run the Inno Setup Compiler program, and Create a New Script using the script wizard. At the welcome screen, hit next. Under “Application Name,” enter “Untitled Car Game.” Under “Application Version,” enter the application version. The rest of the fields can remain blank. Hit next. 

Leave these parameters as default. Hit next. 

For the main executable file, hit browse and go into the project files, and select the executable under: “Untitled-Car-Game\UntitledCarGame\bin\Windows\x86\Release.” Then select “Add Folder” and add the “Release” folder. At the prompt, hit “Yes.” Then hit next.

Leave these parameters as default. Hit next. Leave these parameters blank. Hit next.

Under install mode, select “Non administrative install mode.” Any other mode will cause issues with assets being loaded. Hit next.

Select the languages for the installer and hit next. Enter the output location for the compiled installer and installer name. The rest can be left blank. Hit next.

Keep the default parameters. Hit next. Hit finish. Hit yes to compile the script. Hit yes to save the script and enter the desired name. The script will compile. When it’s complete, run the installer executable. Follow the prompts. Once the installation is complete, the game can be launched.


### Executable Instructions
From the downloads page, download the “Untitled Car Game - Installer.” Once it’s downloaded, run the installer and follow the prompts. Once the installation is complete, run the “UntitledCarGame.exe” executable.

### How to Play
When the game is launched, the main menu will appear. The user can select whether to start a new race, go to the options menu (unavailable) or exit the game.

Selecting the “Start Race” option will take the user to the setup menu. Here, the user can select the parameters for their race. These parameters include:
Map File - Here the user enters the name of the .tmx for the map they want to load. The map must be located in the “Content\maps\(map_name)” directory. The name of the map should be of the form “map_name.tmx,” where the name of the directory and map file are the same. In that same directory should be all of the assets for the map. See the “Map Creation” section for more information.
Number of Cars - Here the user can choose whether to have one car or two cars on the map.
Instruction Files - Here the user can enter the name of the instruction file they want to load for each car. Selecting two cars opens up a second input box for the second instruction file. Files must be located in the “Content\instructions” directory. The name of the instruction file must be of the form “instructions_file.txt.” See the “Programming Interface” section for more information.

Once all parameters are filled in, the user can click the “Start Race” button. This will load the level, and the car will begin to move, following the instructions from the respective instruction file. To return to the main menu, the user can click the “Main Menu” button in the lower right corner.

### Programming Interface
The programming interface allows users to create instruction files that can be loaded onto cars, controlling their movements. Instruction files are text files, where each line contains one instruction. Inside of the car, an instruction is run each frame, forcing the user to balance calculation commands with movement commands.
Available instructions with syntax are:
 
Command
Action


Command
Action
add; x; y;
Adds x + y


madd; x; y;
Adds memory[x] + memory[y]

sub; x; y;
Subtracts x + y


msub; x; y;
Subtracts memory[x] - memory[y]

mul; x; y;
Multiplies x + y


mmul; x; y;
Multiply memory[x] * memory[y]

div; x; y;
Divides x + y


mdiv; x; y;
Divide memory[x] / memory[y]

acc; x;
Accelerates x


macc; x;
Accerates memory[x]

trn; x;
Turns x


mtrn; x;
Turns memory[x]

brk; x;
Brakes x


mbrk; x;
Brakes memory[x]

mvi; x;
Moves tempMath into memory[x]


mvo; x;
Moves memory[x] into tempMath

Arithmetic calculations can be done on either memory locations or static decimal values. After each calculation, the result is stored in the tempMath variable. Values must then be moved out of memory manually. 8 memory locations can be selected, numbered 0-7.

Car movement instructions can be called from either memory locations or static decimal values. Values only remain for the frame in which they are called. Accelerate instructions can be from -1 to 1 for positive and negative acceleration. Any values larger or smaller are automatically capped at those values. Turn instructions can also be from -1 to 1, for left and right turns respectively. Any values larger or smaller are automatically capped at those values. Brake values can only be applied from 0 to 1, for how much braking force to apply. Any values larger or smaller are automatically capped.

Any lines with invalid syntax or values will be automatically skipped when running.

Instruction files MUST be stored in the game directory, under “Content\instructions.” Any files not stored here will not be recognized and will not be loaded in.

### Map Creation

For creating a map you will first need the map editor program Tiled which can be found here https://www.mapeditor.org/. 

Please note before beginning. 

All maps created must be saved within their own folder with the name being the same as the name of the map. These folders must be located in the “Content/maps”. Full directory “Untitled-Car-Game/UntitledCarGame/bin/Windows/x86/Release/Content/maps”. Per example if your tiled map is called “map.tmx” it must be in a folder called “map”(same name)  and located within the maps folder of the game. All images within the tileset of your map should be located in the same folder as the tiled map. An example of this is below except the “Debug” will be “Release” instead.

 
After downloading and opening Tiled, you should see the option of creating a new map. Click on “New Map” and you should see a screen similar to this. 

Here you can configure changes in your map. The options we will be focusing on are layer format, map size and tile size. For layer format, you will have to select CSV otherwise the map will need load in. For Map size, you can make the map any size but we recommend you keep the default of 32x32. For Tile size, we recommend 32x32 as well. Images used for creating your map that are bigger than the tile size may be drawn slightly lower than expected.

After creating your map, you will need to add your images to the tileset. Select the new tileset option, name your tileset and select the option of type “collection of images” and check the embed in map option. Edit your tileset to add images in. Currently the game can only take in a maximum of 9 different images.

For creating collisions, add an “object layer” to your map and insert rectangles which can be found at the top of the Tiled program upon clicking on your object layer. You can have infinite objects in your map of any size. These rectangles act as your collisions and will not be visible in the game. You are able to place an image over a rectangle to make a visible collision.
 
