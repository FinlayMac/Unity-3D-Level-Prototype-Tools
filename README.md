# Unity-3D-Level-Prototype-Tools
A small collection of prefabs to help prototype a 3D level with some small functionality.

The tools are reliant on the New Input System and TextMeshPro (These are imported automatically when adding the package)


## Table of Contents
1. [Getting Started](#getting-started)
2. [Adding the Player / Camera and UI](#adding-the-player-camera-and-ui)
3. [Using Story Beats](#using-story-beats)
4. [Using Interactions](#using-interactions)
5. [Using Moving Objects](#using-moving-objects)
6. [Using Teleporters](#using-teleporters)




## Getting Started
To use the tools, add the project using Unity's package manager.

Window > Package Manager > Add Package From Git URL

![Package Manager](https://user-images.githubusercontent.com/34044928/144337933-f6b1ef4a-d179-42ce-b717-7ea30f53a5ee.png)

If you are prompted with a warning about the new input system, select Yes

![New-input-system](https://user-images.githubusercontent.com/34044928/144338031-2c8a2d36-c317-41aa-9270-b310f3d21bfc.png)

The assets are imported into the packages section.


## Adding the Player Camera and UI
Inside the Prefabs > Player folder, drag the player, camera and UI prefabs into your scene.

![Player-Location](https://user-images.githubusercontent.com/34044928/144341267-fc2f38ab-ddc3-45f2-9428-1b62273a74ea.png)

When adding the UI, you will be prompted to import TMP Essentials (You don't need the examples and extras)

![TextMeshPro](https://user-images.githubusercontent.com/34044928/144338444-cf268af6-85e2-4edf-a942-8bc81b0cc6e7.png)

For the camera to follow the player correctly, position the camera relative to the player.
Select the camera and locate the Follow Game Object Component. Drag the CameraTarget child from the Player instance into the Game Object to Follow section.

![Link-Camera](https://user-images.githubusercontent.com/34044928/144341970-a2247214-7b4c-4cd5-b9e0-6e0d7230fc50.png)



## Using Story Beats


## Using Interactions


## Using Moving Objects


## Using Teleporters
