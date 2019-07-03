

这是我曾经参与做过的一个用Kinect 和 Unity 实现的一个Unity体感游戏， 我负责的是kinect部分

效果图如下
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190704003147470.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxODc0NDU1OTUz,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190704003212979.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxODc0NDU1OTUz,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/201907040033244.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxODc0NDU1OTUz,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190704003525691.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxODc0NDU1OTUz,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190704003603271.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxODc0NDU1OTUz,size_16,color_FFFFFF,t_70)


**下面是项目的实现报告， 如果想看Kinect技术可以直接跳到 4.2 Kinect技术总结**

# 项目地址

<https://github.com/wyj16340227/Kick996>



# 1 项目概况

## 1.1 项目简介 

- 1.1.1 游戏介绍

使用`kinect`与`uinity 3D`引擎实现人机交互的`AR闯关游戏：Kick996`。
通过kinect获取玩家行为信息（包括动作、语音），通过算法转化为输入信息，控制角色动作完成交互。

- 1.1.2游戏规则

玩家具有`跳跃`、`攻击`、`移动`等动作，每一关有不同的敌人，通过攻击动作消灭敌人，完成闯关。

------

## 1.2 项目目的

`kinect`是目前应用最广泛的`VR外设`之一，我们小组计划初步学习`kinect`，结合学过的`Unity 3D`知识，进行人机交互，实现一个具体的小游戏。通过这个学习过程了解目前Kinect应用的范围，瓶颈以及日后的应用空间，体会VR技术对于现实生活的影响。

------

## 1.3 主要技术

- 1.3.1 kinect行为捕捉

通过`kinect for windows`固件完成用户行为信息读取，通过筛选数据获得交互信息，舍弃多余信息。并通过接口传输信息。

- 1.3.2 unity 3D游戏设计

主要使用技术：`刚体碰撞`、`状态机`、`工厂模式`、`MVC模型`、`消息发布模式`。

- 1.3.3 语音识别

通过`Speech Platform API`完成识别，并通过算法进行筛选（正则表达式匹配），筛选出正确语音，完成输入。

------

# 2 设计

## 2.1 基本概念

- 

------

## 2.2 框架

- `MVC模型`

将基本框架分为`Model`、`View`、`Controller`三个部分。分别控制数据、视图、控制器。
`Model`单独存储数据结构，`View`记录视图中存在的对象及参数，`Controller`显示视图。

------

## 2.3 算法

- `工厂模式`

考虑到对象的销毁及产生需要占用大量资源，因此考虑使用对象工厂，通过控制生存状态，减少对象生产及销毁所造成的运算资源开销。
状态为`死亡`的对象存放在视图以外。

- `消息发布模式`

玩家将状态通报所有订阅对象，对象根据自己的状态选择将要执行的动作。

------

## 2.4 模型

- 场景模型

使用`Unity3D-Terrian`组件进行场景构建。

- 角色模型

角色模型选择在`unity asset store`上购买。

## 2.5 调查问卷

经过针对性的问卷调查（对象多为在校学生），约有`73%`的人（大三居多）认为学习压力比较繁重，其中有`77%`曾经过选择并有意向继续选择小游戏纾解压力。
通过对这些同学进行问询，普遍认为`狂扁小朋友`是一款有趣、能够纾解压力的游戏。
由于产品尚未制作完成，因此无法进行体验调查。

------

# 3 实现

## 3.1 技术难点

- 3.1.1 实时性不强

`kinect`行为捕捉较为缓慢，很容易产生`滞后感`，当玩家动作过快，容易识别错误或无法识别动作，造成信息不准确及信息丢失的问题。很严重的影响游戏体验。

- 3.1.2 游戏设计趣味性有待增强

由于游戏操作较为简单，因此需要优美的场景及丰富的剧情来增强可玩性。对于`unity3D`引擎来说，挑战巨大。

- 3.1.3 语音识别

语音识别滞后性非常强，原则上来说，无法单独通过语音控制玩家动作。

------

## 3.2 解决方案

- 3.2.1 语音识别
  - 通过语音与动作相结合，减少滞后性带来的不便。
  - 通过组合技来延长动作时间，为语音识别提供更多的识别时间，减少滞后性。
- 3.2.2 游戏性增强
  - 丰富剧情。向其中加入丰富的幽默的字幕解说，来吸引玩家的注意力，其本质是通过`解压游戏`+`看趣味故事`来放松。
  - 压缩场景。过长的故事线只会让玩家愈发觉得游戏无聊，因此采取快速游戏的策略，在玩家的游戏热情尚未结束的时候结束游戏。避免越玩越无聊的情况的出现。

------

# 4 技术支持

## 4.1 游戏设计技术

------

### 4.1.1 MVC

- 1.概念描述

> 即`Model`-`View`-`Controller`三个部分。分别控制场景，显示以及数据。

- 2.模式应用

![在这里插入图片描述](https://img-blog.csdnimg.cn/20190610110752434.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1lhbnp1X1d1,size_16,color_FFFFFF,t_70)

对应关系为：

| Object       | Character  |
| ------------ | ---------- |
| Model        | Model      |
| UIController | View       |
| Controller   | Controller |

- 3.优势

> 能够做到场景与对象完全分离，角色分工明确清晰。不会造成一个对象既要控制场景又要控制角色的情况，避免了很多设计上的冗余。

------

### 4.1.2 工厂模式

- 1.概念描述

> 对于`unity`，重复的对象进行大量的`Destrory`及`Create`是一笔巨大的开销。因此，类似线程池，将对象存储在仓库中，在不使用时，将其`SetActive(false)`；并放在摄像头的背面。使用时激活并放入场景中。

- 2.实现逻辑
  - 得到对象

![在这里插入图片描述](https://img-blog.csdnimg.cn/20190611220128915.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1lhbnp1X1d1,size_16,color_FFFFFF,t_70)

- 销毁对象

![在这里插入图片描述](https://img-blog.csdnimg.cn/20190611220234932.png)

------

### 4.1.3 单例模式

- 1.概念描述

> 是unity中应用最为广泛的一种模式。顾名思义，即对某个对象，对于某个对象全局中只存在一个实例，其他队想要获得该对象的时候，都要通过它提供的方法`GetInsitance`来取得。<br>

- 2.模式应用

> 全局中有一个单例`SceneController`。<br>
> 事实上，`Model` `SceneController` `UIController`都应当作为单例。但是在设计中，`Model`及`UIController`放在了`SceneController`，中，因此可以通过在`SceneController`中添加`Get`方法来取得它们的实例。

------

### 4.1.4 多场景切换

- 1.概念描述

> 由于游戏中需要多个场景，不同的场景需要不同的场景元素，因此在游戏设计中需要考虑多场景切换的问题。<br>
> 有两种较为常用的场景切换方法。<br>
> 第一种方法就是通过不停的切换摄像机的位置。通过将不同的布景放在各个不会互相干扰（摄像机不能同时拍摄到）的地方，由场景控制器来控制场景的变换。<br>
> 第二种方法是创建多个场景，并通过方法`Application.LoadLevel()`来切换场景。这种方法设计起来更加的方便且实用，但是存在数据传递的问题。<br>

- 2.技术难点

> 采取第二种场景切换的方法，但是存在技术难点，即：当前场景的数据在切换到下一个场景的时候会销毁。<br>
> 有两种解决方案。<br>
> 第一种方案：在场景切换的时候将数据存放在本地文件中，在新场景加载出来后再从本地文件中读取数据。<br>
> 第二种解决方案为：将数据挂载在一个对象身上，并使用`DontDestroyOnLoad()`方法使其在场景切换时不被销毁。只需将其放在摄像机看不到的地方即可。<br>

------

### 4.1.5 发布者-订阅者模式

- 1.概念描述

> 角色消息的交互是必要的。例如，在本游戏中，玩家的位置、状态信息就时刻影响着敌人的动作。如果在`update`里不断地获取玩家的状态，将是一件开销十分巨大的事情。因此，使用消息的发布-订阅模式。一方作为消息的发布方，一方作为消息的订阅方；只有在发布方状态更改了之后，才会向订阅者发布消息。

- 2.模式应用

> 在本游戏中，有两组消息发布-接收者。分别是：

|    发布者    |          订阅者          |            消息内容             |
| :----------: | :----------------------: | :-----------------------------: |
|    player    | enemy<br>SceneController | 状态信息（位置、生命、魔法etc） |
| enemyFactory |     SceneController      |            敌人信息             |

![在这里插入图片描述](https://img-blog.csdnimg.cn/20190613163529709.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1lhbnp1X1d1,size_16,color_FFFFFF,t_70)

> 由于场景控制器要时刻控制游戏进度，当消灭的敌人数目达到下一关要求的时候，才会跳转到下一关。因此，需要`EnemyFactory` 向 `SceneController`发布信息。

- 3.实现难点

> 由于C#语法中不能够继承多个类，因此无法让`SceneController`同时作为`Player`及`EnemyFactory`的`Observer`，因此，在`Suject`中加入两个函数，实现分类订阅。

```
    //Player use it notify its observer
    public abstract void NotifyPlayer(PlayerState playerState);

    //EnemyFactory use it notify its observer
    public abstract void NotifyEnemy(int enemyNum, int bossNum);
```



## 4.2 Kinect体感技术

### 4.2.1 与Unity结合

使用 Kinect-package中间件，版本为2.13， 支持Kinect2.



这个包中间有很多Demo， 可以帮助快速上手项目， 其中重点Demo为：**KinectGesturesDemo1** 其中包括关于手势的检测。



其中脚本 



- **Kinect Manager**   Kinect控制器， 当加载此脚本时， 将会连接kinect，处理数据流
- **Kinect Gesture Listener** Kinect 姿势识别器， 当加载此脚本， 会进行姿势的监控
- **CubeGestureListener.cs ** 这个是自己写的脚本， 用于处理Listener的消息



### 4.2.2  识别姿势 



#### 监听器介绍

Kinect 自带的识别器， 也就是 **Kinect Gesture Listener** 

能被流畅的识别以下手势：

◎RaiseRightHand / RaiseLeftHand – 左手或右手举起过肩并保持至少一秒

◎Psi –双手举起过肩并保持至少一秒

◎Stop – 双手下垂.

◎Wave –左手或右手举起来回摆动

◎SwipeLeft – 右手向左挥.

◎SwipeRight – 左手向右挥.

◎SwipeUp / SwipeDown – 左手或者右手向上/下挥

◎ Click – 左手或右手在适当的位置停留至少2.5秒.

◎RightHandCursor / LeftHandCursor – 假手势，用来使光标随着手移动

◎ZoomOut – 手肘向下，左右手掌合在一起（求佛的手势），然后慢慢分开.

◎ZoomIn – 手肘向下，两手掌相聚至少0.7米，然后慢慢合在一起

◎Wheel –想象一下你双手握着方向盘，然后左右转动。

◎Jump –在1.5秒内髋关节中心至少上升10厘米

◎Squat -在1.5秒内髋关节中心至少下降10厘米

◎Push – 在1.5秒内将左手或右手向外推

◎Pull -在1.5秒内将左手或右手向里拉

#### 接口介绍

**在CubeGestureListener里需要这一些函数 进行姿势处理：**

UserDetected()用于启动手势检测；

UserLost()用于清理变量或者占用的资源。你并不需要移除UserDetected()中添加的手势。这些将会在调用UserLost()前自动清除。

GestureInProgress()在一个手势开始但是还没有被结束或者取消时调用。

GestureCompleted()在一个手势结束时调用。你可以在这里添加自己的代码来处理手势

GestureCancelled()手势被取消时调用

#### 实现监听

在此脚本中我们首先需要开启检测的手势：  我们需要用到的手势分别是：

**离散动作： 右手向左挥、右手向左挥、左手或者右手向上挥，，T字型**

**连续动作：  前倾，后倾，左倾，右倾等动作**

```c
    public void UserDetected(long userId, int userIndex)
	{
		// the gestures are allowed for the primary user only
		KinectManager manager = KinectManager.Instance;
		if(!manager || (userIndex != playerIndex))
			return;
		
		// detect these user specific gestures
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
        manager.DetectGesture(userId, KinectGestures.Gestures.Tpose);
        manager.DetectGesture(userId, KinectGestures.Gestures.LeanLeft);
        manager.DetectGesture(userId, KinectGestures.Gestures.LeanRight);
        manager.DetectGesture(userId, KinectGestures.Gestures.LeanForward);
        manager.DetectGesture(userId, KinectGestures.Gestures.LeanBack);
        
		
	}

```

这样我们监听器就只会监听这些动作， 而其他动作检测到也不会触发。



#### Kinect检测源码分析

官方的监听器是这样检测左倾的,   因为Kinect会把人判断为**26个骨头节点**， 左倾就是**左肩膀的节点距离地面的高度要小于右肩膀节点的高度**。



```c
// check for ShoulderRightFront
case Gestures.ShoulderRightFront:
switch(gestureData.state)
{
    case 0:  // 左肩膀的节点距离地面的高度要小于右肩膀节点的高度。
        if(jointsTracked[leftShoulderIndex] && jointsTracked[rightShoulderIndex] && jointsTracked[rightHipIndex] &&
           (jointsPos[leftShoulderIndex].z - jointsPos[rightHipIndex].z) < 0f &&
           (jointsPos[leftShoulderIndex].z - jointsPos[rightShoulderIndex].z) > -0.15f)
        {
            SetGestureJoint(ref gestureData, timestamp, leftShoulderIndex, jointsPos[leftShoulderIndex]);
            gestureData.progress = 0.5f;
        }
        break;

    case 1:  // gesture phase 2 = complete
        if((timestamp - gestureData.timestamp) < 1.5f)
        {
            bool isInPose = jointsTracked[leftShoulderIndex] && jointsTracked[rightShoulderIndex] && jointsTracked[rightHipIndex] &&
                (jointsPos[leftShoulderIndex].z - jointsPos[rightShoulderIndex].z) < -0.2f;

            if(isInPose)
            {
                Vector3 jointPos = jointsPos[gestureData.joint];
                CheckPoseComplete(ref gestureData, timestamp, jointPos, isInPose, 0f);
            }
        }
        else
        {
            // cancel the gesture
            SetGestureCancelled(ref gestureData);
        }
        break;
}
break;

			// check for LeanLeft
```



### 4.2.3 连续姿势和离散姿势

**其中离散动作 例如攻击，在这个函数里进行处理  GestureCompleted**， 因为这些动作需要在完成时调用。而连续动作，例如前倾后倾， 则在**GestureInProgress** 进行处理， 因为在动作完成过程中，动作会发生变化，

#### 离散动作识别

```c
	public bool GestureCompleted (long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectInterop.JointType joint, Vector3 screenPos)
	{
		// the gestures are allowed for the primary user only
		if(userIndex != playerIndex)
			return false;

        sGestureText = gesture + " detected";
        Debug.Log( sGestureText);
        

        if (gesture == KinectGestures.Gestures.SwipeLeft)
			swipeLeft = true;
		if(gesture == KinectGestures.Gestures.SwipeRight)
			swipeRight = true;
	    if(gesture == KinectGestures.Gestures.SwipeUp)
			swipeUp = true;
        if (gesture == KinectGestures.Gestures.Tpose)
        {
            Tpose = true;
        }
        return true;
	}
```

首先我们设置4个bool变量swipeLeft、swipeRight、swipeUp、Tpose， 判断检测的姿势， 如果是对应姿势则会令这些变量为true， 但是因为是离散动作， **这样会导致当判断成功一次后， bool变量会一直变为true，** 所以写一个接口， 当bool变量为为true时， 令它为false， 但是返回为true。  类似于 检测到一个动作后，变量还原

例如判断是否是 SwipeUp（向上滑）接口如下， 只要其他部分调用此接口，就能知道是否进行SwipeUp操作

#### 连续动作识别

连续动作识别则不需要重新写一个接口， 因为状态会一直变化。 不过会有倾斜程度的参（**screenPos.z** ），为了游戏体验，当没有倾斜太大的时候，将倾斜小的认为是直立， 这样更加便于操控， **不然结果就是只要稍微左移就会一直操纵任务左移， 而直到右移才会一直往右边， 我们需要一个中立的状态才好**。  然后其他部分只要读取这四个变量就知道用户是否左倾，右倾了。



```c
	public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectInterop.JointType joint, Vector3 screenPos)
	{
        // the gestures are allowed for the primary user only
       


        if (userIndex != playerIndex)
			return;

	
		 if((gesture == KinectGestures.Gestures.Wheel || gesture == KinectGestures.Gestures.LeanLeft || 
		         gesture == KinectGestures.Gestures.LeanRight || gesture == KinectGestures.Gestures.LeanForward ||
                 gesture == KinectGestures.Gestures.LeanBack) && progress > 0.01f)
		{
			if(gestureInfo != null)
			{
                
                if (gesture == KinectGestures.Gestures.LeanLeft && screenPos.z > detectSense)
                {
                    sGestureText = "左转";

                    LeanLeft = true;
                } else
                {
                    LeanLeft = false;
                }
                    
                if (gesture == KinectGestures.Gestures.LeanRight && screenPos.z > detectSense)
                {
                    sGestureText = "右转";
                    LeanRight = true;
                }else
                {
                    LeanRight = false;
                }

                if (gesture == KinectGestures.Gestures.LeanForward && screenPos.z > detectSense)
                {
                    sGestureText = "前进";
                    LeanForward = true;
                }
                else
                {
                    LeanForward = false;
                }


                if (gesture == KinectGestures.Gestures.LeanBack && screenPos.z > detectSense + 10)
                {
                    sGestureText = "停止/后退";
                    LeanBack = true;
                }
                else
                {
                    LeanBack = false;
                }

                progressDisplayed = true;
				progressGestureTime = Time.realtimeSinceStartup;
			}
		}
	
	}
```



和游戏操控结合， 实现同步

人物移动

```c
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        if (slideChangeWithGestures && gestureListener)
        {

            if (gestureListener.LeanLeft)
            {
                h = -1;   //水平移动大小  负数为左边
            }
            if (gestureListener.LeanRight)
            {
                h = 1;
            }
            if (gestureListener.LeanForward)
            {
                v = 1; //水平移动大小  负数为下边
            }
            if (gestureListener.LeanBack)
            {
                v = -1;
            }
     
        }
    }
```

按键操控

```c
if (slideChangeWithGestures && gestureListener)
{
	//检测动作  映射陈实体按键
    if (gestureListener.IsSwipeUp())
    {
        return KeyCode.J;   //攻击1
    }

    if (gestureListener.IsSwipeLeft())
    {
        return KeyCode.K;  //攻击2
    }
    if (gestureListener.IsTpose())
    {
        return KeyCode.R;  // 人物旋转180度
    }
    if (gestureListener.IsSwipeRight())
    {
        return KeyCode.Q; //向前瞬移
    }

    else
    {
        return KeyCode.None;
    }
}

```







------





# 5. 参考文献

- Lamiaa A. Elrefaei,  Bshaer Azan1, Sameera Hakami JCAVE: A 3D INTERACTIVE GAME TO ASSIST HOME PHYSIOTHERAPY REHABILITATION
- V. Pterneas, "IMPLEMENTING KINECT GESTURES," 27 January 2014. [Online]. Available:https://pterneas.com/2014/01/27/implementing-kinect-gestures/. [Accessed 2017].
- M. Pedraza-Hueso, S. Martín-Calzón, F. J. Díaz-Pernas and M. Martínez-Zarzuela, "Rehabilitation
  Using Kinect-based Games and Virtual Reality," Procedia Computer Science, vol. 75, pp. 161-168,2015https://doi.org/10.1016/j.procs.2015.12.233.
- "Tracking Users with Kinect Skeletal Tracking," [Online]. Available: https://msdn.microsoft.com/enus/library/jj131025.aspx. [Accessed 2017].





