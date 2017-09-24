# hero-stone 英雄方块
![image](https://github.com/cxdppp/hero-stone/blob/master/images/logo.png)
## 下载地址：

安卓版：

[csgame1.0.apk](https://github.com/cxdppp/hero-stone/raw/master/APK/csgame1.0.apk)

PC版：

[执行程序](https://github.com/cxdppp/hero-stone/raw/master/APK/csgame1.0.exe)

[数据文件](https://github.com/cxdppp/hero-stone/raw/master/APK/csgame1.0_Data.zip)

两者解压到同一目录，打开“csgame1.0.exe”即可。

## 截图
![image](https://github.com/cxdppp/hero-stone/blob/master/images/0.jpg)
![image](https://github.com/cxdppp/hero-stone/blob/master/images/1.jpg)
![image](https://github.com/cxdppp/hero-stone/blob/master/images/2.jpg)
![image](https://github.com/cxdppp/hero-stone/blob/master/images/3.jpg)
![image](https://github.com/cxdppp/hero-stone/blob/master/images/4.jpg)
![image](https://github.com/cxdppp/hero-stone/blob/master/images/5.jpg)

## 描述

从创意和从功能需求上来说，本游戏与传统的冒险撞击类游戏不同。

除了实现基本的菜单选择、场景转换、本地存储等功能外，还独具特色地加入了“环境因素”、场景转换动画、短时间无敌等多种情况。

此外，本作品应用了Premiere、Flash、Photoshop等多种多媒体制作软件，制作处理素材，力求在画面效果上吸引玩家，具有较好的沉浸式体验。

由于手机APP具有比较好的生态环境，得到越来越多的开发者青睐。

本作品作为一款由小团队开发的休闲类游戏，巧妙实现了基于游戏引擎Unity3D的跨平台开发。

游戏基本上满足了团队对于休闲游戏开发过程的理解，也积累了安卓平台游戏开发的经验，是大学生使用Unity3D进行游戏开发的一次成功的实例尝试。

团队主要解决片头视频文件I/O流的解码、读取和导入。

我们本来在adobe AE做好了片头部分的特效并导出了最高的avi视频格式，后来发现20秒的视频内存在导入格式的问题，经过多重转码压缩控制在6M左右。

另外关于片头动画的初次播放问题，我们尝试了好久，最终创造性的采用了本地存储的数据持久化功能，具有较高的智能性。

在游戏运行过程中传送带和敌人一直生成销毁，本来设想的是刚开始主角以一定速度匀速前进，点击屏幕后加速，后来发现这样总有一天会走到传送带尽头。

经过查阅多种资料，我们尝试把传送带变成可以循环生成销毁的动态对象，主角保持不动，两者逆向运动，主观上看起来像主角在向前运动一样，最终解决了这个难题。

此外，在玩家视觉上摄像机的平滑翻转、状态和时间调试等方面也做了很多尝试。

## 玩法介绍

单击：切换场景，躲避障碍物

双击：加速冲刺碰撞或得分

## 功能概况

数据持久化功能——根据玩家是否第一次玩此游戏，选择性播放介绍游戏背景和游戏规则的片头。

选择游戏模式——根据玩家对自我的认知，选择不同难易程度

游戏过程中(玩家控制一个蓝色方块（以下称为玩家），在游戏过程中会遇到前方高速来临的“敌人”):

单击撞击——切换到另一个场景，来躲避红色敌人（不得分）。

双击加速撞击——加速冲撞蓝色、黄色火焰敌人，得分。

存储更新得分纪录——本地保存游戏数据，识别玩家每次得分并存储更新最高得分。

游戏环境自定义变化——在游戏的过程中，游戏环境会随着游戏进度的推进，产生变化。例如“下雨”和“闪电”，提升游戏体验。

游戏目标：获得尽量高的分数。

系统性能：内存占用较小，性能优越。

                    （系统功能框架图）
![image](https://github.com/cxdppp/hero-stone/blob/master/images/function.png)

