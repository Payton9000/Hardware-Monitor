# Hardware Monitor

This software is a modified version of the PC-side program originally released by Bilibili user [垃圾研究社](https://space.bilibili.com/376404862) in their [DIY Air-Cooled Radiator Assembly Guide](https://www.bilibili.com/read/cv36613704), with additional features implemented.

We greatly appreciate the author for open-sourcing such an excellent air-cooled radiator solution. Here is the [video link](https://www.bilibili.com/video/BV1Lr421M7u2) of the DIY radiator; make sure to give the author a like, comment, and subscribe!

## Table of Contents

- [Background](##Background)
- [Installation](##Installation)
- [Instructions (Using Default Method to Get Temperature)](##Instructions-(Using-Default-Method-to-Get-Temperature))
- [Instructions (Using AIDA64 Method to Get Temperature)](##Instructions-(Using-AIDA64-Method-to-Get-Temperature))
- [Serial Port Usage](##Serial-Port-Usage)
- [Minimizing and Uninstalling the Software](##Minimizing-and-Uninstalling-the-Software)

## Background

I personally prefer monitoring the CPU Package temperature when detecting temperatures. The original program had issues with reading CPU temperatures on Intel's 12th-14th generation processors using LibreHardwareMonitor, which led me to modify the code based on the original work by the UP (Uploader) user.

This software is an updated version of the PC-side software by [垃圾研究社](https://space.bilibili.com/376404862), with additional features and improved display optimization for high-resolution screens.

The features provided by the software will be explained in the following sections.

## Installation

You can download the software from the [Release Release v1.0 · Payton9000/Hardware-Monitor (github.com)](https://github.com/Payton9000/Hardware-Monitor/releases/tag/Release) page.

Alternatively, you can download the software directly by clicking this link: [Hardware Monitor.msi](https://github.com/Payton9000/Hardware-Monitor/releases/download/Release/Hardware.Monitor.msi).

Once downloaded, you can install the package on your computer. If the installation is successful, you should see the software icon on your desktop, which you can click to use.

![image](https://github.com/user-attachments/assets/5f5dc9ab-65c3-4c33-a189-d8316e44c4db)

## Instructions (Using Default Method to Get Temperature)

The main interface of the software is shown below. CPU Temp and GPU Temp represent the current temperature readings, which are obtained by default using [LibreHardwareMonitor](https://github.com/LibreHardwareMonitor/LibreHardwareMonitor).

![2b81491e4c0b34696a9a997b99e09cc9](https://github.com/user-attachments/assets/c7f92c0b-c5aa-41a1-96ac-2e5423cf8fd5)

In its default state, the software queries the hardware temperature every 5 seconds. You can adjust this interval using the "Select Refresh Time" option. Since setting the interval to 1 second might cause errors in LibreHardwareMonitor, the refresh time is limited to between 3 to 30 seconds. After selecting the desired interval, click "Conform" to apply the current refresh time setting.

![cd9202e352e28e45b33c0ad4e67367de](https://github.com/user-attachments/assets/28a120bb-92e7-4f11-a810-7de5ee9ec381)

## Instructions (Using AIDA64 Method to Get Temperature)

To use AIDA64 to get the temperature, simply check the checkbox. If AIDA64 is not set up, you will encounter the following error:

![0ebe37a0e0a80153234473d08b150669](https://github.com/user-attachments/assets/fd41cc41-49f9-4e53-8e6d-fa32ac6e8ad6)

This software retrieves temperature data from AIDA64 by reading values stored in the registry. First, you need to download AIDA64. If it is not installed, you can visit the [AIDA64 official website](http://www.aida64.com.cn/index.html) or install it through the [TB Toolbox](https://www.tbtool.cn/).

In the AIDA64 settings, find the **Hardware Detection Tool**, then go to **External Programs** and check **Allow monitoring data to be written to the registry (R)**. After confirming, the following interface should appear. Click **Apply** to complete the setup.

![7e0fef0188c8159a11f000de78d0bbdd](https://github.com/user-attachments/assets/9961806e-0bcf-4564-8d75-94bae137db58)

Then, click "Use AIDA64 to get hardware information" in the software. If everything is set up correctly, the software will automatically use the CPU and GPU temperatures provided by AIDA64 as the temperature sensors.

**If you continue to encounter the following error, you can refer to the solutions below:**

![image](https://github.com/user-attachments/assets/2c69ccf7-535f-4634-86ae-d7ce0dd0d489)

1. Choose a longer refresh time, then select the appropriate CPU and GPU sensors.

2. After confirming, the software will use the CPU & GPU temperature sensors specified by the user.

Selecting a longer refresh time is recommended because using a shorter refresh time might cause the error to recur more quickly.

Users can either use the automatically detected CPU & GPU temperature sensors or manually specify the temperature sensors.

![bf487b269a873b37a2082c182304d392_720](https://github.com/user-attachments/assets/7e4244a0-8293-434a-86b7-c8ea921581c6)

![2ede68ab47158f79a289c5a8cdb5e290](https://github.com/user-attachments/assets/b1de5920-ae7d-406f-a1b6-0c60ea501bda)

## Serial Port Usage

For this part, you can refer to the video by the UPer [垃圾研究社](https://space.bilibili.com/376404862) [here](https://www.bilibili.com/video/BV1Lr421M7u2).

## Minimizing and Uninstalling the Software

When you minimize the software, it will be displayed in the system tray.

![image](https://github.com/user-attachments/assets/fbdc9bf5-e909-48ce-b87c-8f334c3fb62c)

Right-click the icon to exit the program, or left-click to reopen the window.

If you need to uninstall the software, go to the system settings, search for Hardware Monitor, and click "Uninstall."

![4dd3818f2a7b3be2f0c4d40fe7c2a3c3](https://github.com/user-attachments/assets/ab97b8b0-94bb-4b7f-88e9-ab16b1942dde)
