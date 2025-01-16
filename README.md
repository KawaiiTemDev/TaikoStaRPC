# TaikoStaRPC

 <a href="https://shorturl.at/s1gHM"> <img src="Resources/InstallButton.png" alt="One-click Install using the Taiko Mod Manager" width="256"/> </a>

 
This is a mod for Taiko no Tatsujin: Rhythm Festival that adds Discord RPC.

> [!IMPORTANT]  
> This mod was originally made by Namakemono-san. I simply forked it and removed features, whilst keeping only the RPC aspect of the mod.
> 
> I also modified some aspects of the RPC: Namely, instead of putting the Genre in the second line it'll be the subtitle. The genre is now the big picture thingy.

## Features

- Add Discord Rich Presence : Translated from Japanese => English

## Installation

Releases tab, and download the zip. Place this in Bepinex\Plugins

## Build
 Install [BepInEx 6.0.0-pre.2](https://github.com/BepInEx/BepInEx/releases/tag/v6.0.0-pre.2) into your Rhythm Festival directory and launch the game.\
 This will generate all the dummy dlls in the interop folder that will be used as references.\
 Make sure you install the Unity.IL2CPP-win-x64 version.\

Clone the project (duh)
Go into `RF.TaikoStaRPC.csproj` and change the game path variable if needed.

<sup><sub>_(not needed if in the default steam location on your C drive)_.

Build, and everything should work fine. I made it so it automatically creates the appropriate plugin folder and launches the game so you can instantly test the mod.

## Screenshots
![image](https://github.com/user-attachments/assets/6bafb0cf-f45c-434f-8a7a-a4c5c26f39c8) ![image](https://github.com/user-attachments/assets/288fa341-2ebc-4a52-8e3f-ef3bec94c19b)

![image](https://github.com/user-attachments/assets/10d1c334-eb8e-4996-8767-e3808ffa8cbc) ![image](https://github.com/user-attachments/assets/42e66bcf-6b78-40dd-b698-8553b0d7d567)










## License

This project is licensed under the MIT License, see the [LICENSE](LICENSE) file for details
