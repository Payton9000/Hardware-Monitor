# 硬件检测器

本软件在B站用户[垃圾研究社](https://space.bilibili.com/376404862)所开源的[DIY压风式散热器组装说明](https://www.bilibili.com/read/cv36613704)中所开源的电脑端程序修改而来，实现了更多的功能

在此非常感谢大佬能开源这么好的压风式散热器方案，这个是此DIY散热器的[视频链接](https://www.bilibili.com/video/BV1Lr421M7u2)，给大佬三连！！！

## 内容列表

- [背景](##背景)
- [安装](##安装)
- [使用说明(使用默认方法获取温度)](##使用说明(使用默认方法获取温度))
- [使用说明(使用AIDA64方法获取温度)](##使用说明(使用AIDA64方法获取温度))
- [串口使用方法](##串口使用方法)
- [最小化与卸载软件](##最小化与卸载软件)


## 背景

由于个人在检测温度时更偏重于检测CPU Package的温度，并且原先的程序在检测12~14代Intel处理器温度时LibreHardwareMonitor容易出现问题，导致无法读出CPU的温度，因此我基于UP主的代码进行了修改

此软件基于[垃圾研究社](https://space.bilibili.com/376404862)电脑端软件更新而来，实现了更多的功能、优化了软件在高分辨率屏幕上的显示效果……

在后续的使用说明中会提到软件所提供的功能

## 安装

您可以在[Release Release v1.0 · Payton9000/Hardware-Monitor (github.com)](https://github.com/Payton9000/Hardware-Monitor/releases/tag/Release)中下载此软件

或者点击链接[Hardware Monitor.msi](https://github.com/Payton9000/Hardware-Monitor/releases/download/Release/Hardware.Monitor.msi)下载软件

即可获取安装包，可以在电脑上安装，如果安装成功，应该可以在桌面看到这个软件的图标，点击即可使用

![image](https://github.com/user-attachments/assets/5f5dc9ab-65c3-4c33-a189-d8316e44c4db)


## 使用说明(使用默认方法获取温度)

软件主界面如下，CPU Temp和GPU Temp代表目前获取的温度，默认使用[LibreHardwareMonitor](https://github.com/LibreHardwareMonitor/LibreHardwareMonitor)获取CPU和GPU的温度信息

![2b81491e4c0b34696a9a997b99e09cc9](https://github.com/user-attachments/assets/c7f92c0b-c5aa-41a1-96ac-2e5423cf8fd5)

当软件在默认状态下，会每隔5秒询问一次硬件温度，可以通过Select Refresh Time修改询问硬件温度的时间间隔，由于将时间设置为1s的话，LibreHardwareMonitor将会报错，因此将刷新时间限制在3至30秒，在选择完时间后点击Conform即可使用当前刷新时间设置

![cd9202e352e28e45b33c0ad4e67367de](https://github.com/user-attachments/assets/28a120bb-92e7-4f11-a810-7de5ee9ec381)

## 使用说明(使用AIDA64方法获取温度)

如果要使用AIDA64获取温度，点击checkbox即可，若没有设置AIDA64，则会有如下报错

![0ebe37a0e0a80153234473d08b150669](https://github.com/user-attachments/assets/fd41cc41-49f9-4e53-8e6d-fa32ac6e8ad6)

本软件获取AIDA64温度的方式是读取其存储在注册表内部的值，首先用户需要下载AIDA64，若未安装，则可前往[AIDA64中文官方官网](http://www.aida64.com.cn/index.html)或者是通过[图吧工具箱](https://www.tbtool.cn/)进行安装

在AIDA64的设置界面，找到**硬件检测工具**，点开后点击**外部程序**,点击**允许将监测数据写入注册表(R)**，确认后，应该为如下界面，点击**应用**后即完成设置

![7e0fef0188c8159a11f000de78d0bbdd](https://github.com/user-attachments/assets/9961806e-0bcf-4564-8d75-94bae137db58)

之后再点击软件中的Use AIDA64 to get hardware information,如果没有出现问题，软件会自动使用AIDA64提供的CPU和GPU温度作为温度传感器

**若此处持续弹出如下报错，可以参考以下解决方案**

![image](https://github.com/user-attachments/assets/2c69ccf7-535f-4634-86ae-d7ce0dd0d489)


1.选择较长的刷新时间，然后同时选择合适的CPU和GPU监视器。

2.点击确认后，软件会选择用户所指定的CPU&GPU温度传感器

选择较长的刷新时间是因为如果如果您使用较短的刷新时间，错误可能会以较快的速度反复出现。

用户可以使用软件自动检测的CPU&GPU温度传感器，也可以自行指定温度传感器

![bf487b269a873b37a2082c182304d392_720](https://github.com/user-attachments/assets/7e4244a0-8293-434a-86b7-c8ea921581c6)


![2ede68ab47158f79a289c5a8cdb5e290](https://github.com/user-attachments/assets/b1de5920-ae7d-406f-a1b6-0c60ea501bda)

## 串口使用方法

这部分可以看UP主[垃圾研究社](https://space.bilibili.com/376404862)的[视频](https://www.bilibili.com/video/BV1Lr421M7u2)

## 最小化与卸载软件

当将本软件最小化时，会显示在状态栏

![image](https://github.com/user-attachments/assets/fbdc9bf5-e909-48ce-b87c-8f334c3fb62c)

点击右键后可以选择退出程序，左键单击程序可以打开窗口

如果需要卸载软件，可以打开系统设置，搜索Hardware Monitor，点击卸载即可

![4dd3818f2a7b3be2f0c4d40fe7c2a3c3](https://github.com/user-attachments/assets/ab97b8b0-94bb-4b7f-88e9-ab16b1942dde)
