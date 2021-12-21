# Unity-3D-Level-Prototype-Tools
A small collection of prefabs to help prototype a 3D level with some small functionality.

The tools are reliant on the New Input System and TextMeshPro (These are imported automatically when adding the package)


## Table of Contents
1. [Getting Started](#getting-started)
2. [Adding the Player / Camera and UI](#adding-the-player-camera-and-ui)
3. [Triggers](#triggers)
4. [Activations](#activations)
5. [Prefabs](#prefabs)
6. [Others](#others)



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


## Triggers
Triggers are used to activate functionality in the game. These are mostly interacted with by the player.

### Zone Trigger
When a player enters into an area, the trigger activates. When a player leaves the area, the trigger deactivates. Any 3D Collider can be used as long as the "Is Trigger" property is set to true. 

### Pressure Plate Trigger
When a GameObject with a 3D Collider collides with the pressure plate, the trigger activates. When the colliding object is removed, the trigger deactivates.

### Pickup Trigger
When the player collides with this GameObject, the trigger activates and this gameobject is destroyed. There is no way to deactivate this trigger.

### Lever Trigger
When the player presses the interact button, this trigger activates. When the player presses the interact button again, the trigger deactivates.

### Key / Lock Trigger
The player can collect a key GameObject. When the player enters the lock area with the key, this trigger is activated. There is no way to deactivate this trigger.





## Activations
Activations are the functionality that your triggers activate.

### Show / Hide Objects
When activated, the list of GameObjects will be enabled in the scene hierarchy - showing them. When deactivated, the list of GameObjects will be disabled - hiding them. Make sure you deactivate all the GameObjects you need hidden first.

### Destroy Objects
When activated, will destroy all GameObjects in the list. There is no deactivation. 

### Text
When activated, will display text for a duration of time before hiding. When deactivated, will immediatly hide the text.

### Lights
When activated, will turn on the light. When deactivated, will turn off the light.

### Moving Objects
When activated, will start moving the GameObject around on a set path. When deactivated, the GameObject will stop moving and stay in its current position. When reactivated, the GameObject will resume the path from its current position. 

## Prefabs
Some prefabs have been created to get you started. You can create 

### Using Story Beats


### Using Interactions




## Others

### Using Teleporters

### Using Springs