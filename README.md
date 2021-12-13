# [💾](https://github.com/Pokeyi/VRC-Player-Tracking/blob/main/P_PlayerTracking.cs) VRC-Player-Tracking <!-- [![Downloads](https://img.shields.io/github/downloads/Pokeyi/VRC-Player-Tracking/total?label=Downloads&logo=github)](https://github.com/Pokeyi/VRC-Player-Tracking/releases) -->
Local player body-part tracking for VRChat.

![Player Tracking](P_PlayerTracking.png)

## Overview
🚧 This project is functional but in early stages with additional features planned. 🚧

VRC Player Tracking is a single configurable UdonSharp behaviour that can be used to track specific player avatar body parts and bones as well as smoothly attach game objects to those positions.

It is intended to be efficient and relatively simple to use without the need for any additional editor scripts or dependencies outside of UdonSharp. All configuration can be done within the Unity Inspector window without the need for any programming, Udon, or SDK knowledge. That said, the source code is cleanly-organized and commented in the hopes of also being a good learning tool.

### Requirements
Errors regarding functions not being exposed likely mean you need an updated version of the SDK or UdonSharp.
- [Unity](https://docs.vrchat.com/docs/current-unity-version) (Tested: v2019.4.31f1)
- [VRChat Worlds SDK3](https://vrchat.com/home/download) (Tested: v2021.11.8)
- [UdonSharp](https://github.com/MerlinVR/UdonSharp) (Tested: v0.20.3)

### Recommended
Other useful VRChat world-creation tools that I will always recommend.
- [World Creator Assistant](https://github.com/Varneon/WorldCreatorAssistant) (SDK & Package Management)
- [CyanEmu](https://github.com/CyanLaser/CyanEmu) (Unity-Window Testing)

### Setup
Make sure you have already imported the VRChat Worlds SDK and UdonSharp into your project.
- Download the latest [Unity Package](https://github.com/Pokeyi/VRC-Player-Tracking/releases) and import it into your project.
- A pre-configured example prefab is included that you can drop into your scene if you like.
- Create and select an empty game object and add the P_PlayerTracking behaviour via the Unity Inspector window or 'Component > Pokeyi.VRChat > P.VRC Player Tracking' toolbar menu.
- Click the 'Convert to UdonBehaviour' button if prompted.
- Configure the rest of the behaviour's properties in the Inspector window as you see fit. Each of these is explained in detail further below.

## Features
The main features of Player Tracking.
- Use-Attachments Toggle - Toggle the use of attachments to tracked positions.
- Attachment Positions - Assign which game objects will be attached to which positions.

All of the following properties have hover-tooltips in the Unity Inspector window.

### Attachment Positions
The following avatar body parts and bones have attachment positions included in the behaviour. Any left blank will be safely ignored.
- Origin - API Tracking Data - Center ground-level position.
- Head - API Tracking Data - HUD elements can be attached here.
- Left Hand - API Tracking Data - Hand-tracking data.
- Right Hand - API Tracking Data - Hand-tracking data.
- Left Foot - Bone Position
- Right Foot - Bone Position
- Left Lower Arm - Bone Position
- Right Lower Arm - Bone Position
- Left Upper Arm - Bone Position
- Right Upper Arm - Bone Position
- Left Lower Leg - Bone Position
- Right Lower Leg - Bone Position
- Left Upper Leg - Bone Position
- Right Upper Leg - Bone Position
- Chest - Bone Position

### Use Case Examples
Attachments should follow movements smoothly without jittering or rubber-banding, though performance may vary by use case.
- HUD elements attached to the Head position.
- Colliders or triggers attached to the Hand positions for physical interactivity.
- Hide invisible cubes named after your friends inside every part of your body. No one will ever see them, but you'll know.

## Credit & Support
Please credit me as Pokeyi if you use my work. I would also love to see your creations that make use of it if you're inclined to share. This and [related projects](https://github.com/Pokeyi/pokeyi.github.io#my-projects) at release have involved over three months of solid work and self-education as I strive for an opportunity to change careers and make a better life for myself. If you find value in my work, please consider supporting me, I appreciate it more than you can imagine!

[![Patreon](https://img.shields.io/badge/Patreon-Support-red?logo=patreon)](https://patreon.com/pokeyi)

[![PayPal](https://img.shields.io/badge/PayPal-Donate-blue?logo=paypal)](https://www.paypal.com/donate?hosted_button_id=XFBLJ5GNSLGRC)

## License
This work is licensed under the MIT License.

Copyright © 2021 Pokeyi - https://pokeyi.dev - [pokeyi@pm.me](mailto:pokeyi@pm.me)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
