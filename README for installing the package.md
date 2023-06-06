## README for installing the package

- To install the package, open a new project on Unity. Make sure you have installed the Android Build Support SDK/NDK tools.
- Then go to Windows > Package Manager
- In the Advanced Tab, click on show preview packages
- Install the XR Interaction Toolkit & XR Management Tool
- In the XR Management Tool, install the Oculus Package
- Go to File > Build Settings, and switch to Android device.

- Go to Edit->Project Settings, select the player tab on the left. In Resolution and Presentation make sure 'Start in fullscreen mode' is checked. Now scroll to 'Other Settings', 'Identification'. Set the 'Minimum APT Level' to 'Android 6.0 'Marshmallow' API level 23'.

- Now move to the XR Plugin Management menu on the left, select the Android tab on the right and press the '+' icon to add 'Oculus XR Plugin' to the Plugin Providers List. 'Oculus Loader' should now appear on the list. Then select the subsection 'Oculus' on the left and for the Android tab make sure the Stereo Rendering Mode is 'Multi Pass'.

- To load the game on the oculus, ensure that the Oculus is in Developer mode, and after plugging the Oculus into the computer via the USB cable, accept the message that appears on the headset. Then go to File -> Build Settings in Unity. Select Android as the platform, and Select Oculus Quest 2 as the Run Device. If it does not appear, press refresh.

- Press Build and Run. The first time running may take some time to load the project. When this is completed you can enjoy the game on the Oculus Quest 2.
