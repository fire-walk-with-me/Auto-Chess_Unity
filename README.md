# Auto-Chess_Unity
Unity edtior verison 2022.3.10f1 LTS
Malmö Universitet, Spelutvecklings programmet, 2023

Developed by Gustaf Larsson, gustaf.hd.larsson@gmail.com

This is a game created for educational purposes with a focus on artificial intelligence for games. 
The game was developed using unity with a free license and holds no commercial value.


HOW TO DOWNLOAD AND OPEN:
Create a fork of the github branch titled "main" and download the content. 
Add the project to your unity-hub by pressing the ADD-button in the hub and locating the project folder that was downloaded with github.
You should now be able to open the project from the unity-hub. Just make sure you have unity version 2022.3.10f1 installed.


HOW TO PLAY:
The game is as named a "auto-chess", meaning a game where the pieces are autonomous and fight the battle on their own.
Your job is to buy units and place them strategically to give your team the upper hand against your AI-competitor. 
Use the cursor to click units in the shop UI to buy them, as long as you have enough currency the unit you buy will appear on your side-line where they are inactive. 
To activate a unit, drag and drop it to one of the empty placements-nodes on the map. The AI-competitor will spawn its own units and the round will start. After the round is over the board is reset and there is a planing phase before the game-loop starts over. There is no end. 


HOW TO DEVELOP FURTHER:
The AI used by the units currently is the most simple form of a decision tree, consisting of a series of if-statements, for the purpose of displaying existing unit behaviours. Both your units and the AI-competitors units uses the same AI-script, so when you create a new AI-model both teams will use the same.
Your task is to develop one/several more advanced AI-models to play the units. To do this you can follow the instructions in the AI-script.
The AI-script is the only script necessary to manipulate in order to create the AI-model, however depending on what model you choose you might have to create your own scripts or make changes in scripts that already exists. Feel free to do so, but with caution, as changes might cause the game to break.
There are comments in most scripts that can help or explains how things works. The GameInfo-script hold information about the active game state and is a singleton, which means you can always access the information in it. See the script for more information on how to use it.


EXTRA(if you want to experiment for fun):
The units are currently casting a special ability when they have enough mana, however no ability is developed so nothing happens. Create your own special ability for the units, e.g healing, AoE attack, etc. You can do this directly in the existing abilty-script as it is empty. You could also add more effects and/or animations to the units, for instance when they cast their special ability. Animations from mixamo.com is compatible with the model.

Currently the AI-competitor "buys" new units at random from a pool of units and places them randomly at pre-defined points, you could create a second shop for the  AI-competitor and an AI-model that choose which type of units to buy and place on the map, to create a smarter opponent.

Currently there is only two units, a range and a melee unit. You could create a completely new unit and add it to the unit pool component attached to the shop in the unity editor. You can look at how the existing unit-gameObjects is developed to get an understanding of what components are needed. Remember that if you do this, you might have to make changes in already existing scripts, e.g stats-script, stat-randomizer, etc. As they are currently only compatible with the existing units. You can find free 3D-assets together with animations and skeleton or animation on mixamo.com.
