# PhotonNetworkingExample
A brief project I whipped up this week to test the Photon Networking plugin for Unity3D.  We recently tested a few options for hosting our multiplayer game and this was one sample to see how the framework functioned.

## Controls:
A and D or Left and Right arrows to rotate camera.
Q and E will slowly decrease and increase the player's "anxiety level" respectively.

##Concept:
The point of this small demo is to test setting up lobbies and rooms in Unity using Photon and transfer information between clients.  Players will witness a series of color shifts based on how anxious their player is, varying from cold to hot.  Other players can see how anxious another player is by looking at the color of their avatar.  As the player's environment shifts, their avatar changes color as well to match that tone, and is sent to all other clients.

##Setup:
To see the build in action, open the exampleclient.exe two times, making sure to select a window size that allows you to place both windows side by side and checking the "Windowed" box.  From there, the clients will connect to the server and say "Joined".  When both clients have joined the room, the player count should read 2 and will be able to rotate and change colors based on player input.  Rotate the cameras to face each other and change the environment colors using Q and E to see the changes on both clients at the same time.
