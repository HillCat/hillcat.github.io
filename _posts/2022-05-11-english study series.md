---
layout: post
title: 机器学习AI优化anki复习参数(15)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

这里要推荐的一个插件是`FSRS4Anki Helper`。插件的地址：[https://ankiweb.net/shared/info/759844606](https://ankiweb.net/shared/info/759844606)，这个插件的安装码是：759844606。插件需要anki 2.1.55版本以上。该插件仅能支持电脑端Anki。插件作者在知乎的教程：[https://zhuanlan.zhihu.com/p/591833332](https://zhuanlan.zhihu.com/p/591833332)，该插件作者，曾经用anki复习高考知识，提升考分100多分。

![chrome_Drmqkx3KnQ](/images/posts/chrome_Drmqkx3KnQ.png)

### 1.FSRS4Anki Helper

这个插件的作者是国内的某个计算机大学毕业的算法学生搞出来的一个基于人工智能机器学习的插件，目的是为了优化我们的复习参数。因为anki的复习参数太多了(如下图所示)，Anki新手很容易搞错这些参数，也不知道怎么设置这些参数。我比较推荐使用的就是这个插件，你不用去思考如何设置这些参数，它通过机器学习，python在线训练，得到一个比较优化的参数给到你，这样子，参数问题就变得傻瓜化。而且这个参数是量身定制的，针对每个人的卡片数据，做出的不同的最优解。

![123kzmsdjIUs@](/images/posts/123kzmsdjIUs@.gif)

这个插件的目的就是给每个人的卡片复习进度，进行数据优化，生成针对每个人的定制化的复习参数。这样子我们就不用担心anki参数设置问题了。专业的事情交给专业的人，由机器学习和AI帮你全部搞定。

### 2.插件安装和使用

首先是安装这个插件，我这里是在windows10 Pro 系统，英文界面上面演示。安装的anki是2.1.56版本 QT6版本的。注意，我这里用的是QT6而不是QT5版本，建议你电脑上面的anki也用官方最新的QT6对应的版本。官方地址：[https://apps.ankiweb.net/](https://apps.ankiweb.net/)，旧版本用新版本覆盖安装即可，覆盖安装不会破坏原有的anki配置。

![oegy1DEjYC](/images/posts/oegy1DEjYC.png)

#### 2.1 安装插件

然后是安装插件，安装码是：759844606。直接到anki的add-ons菜单，get add on ...里面填入这个Code码安装这个插件即可。安装完毕，就能看到这个插件了:

![anki_EveEKoynm3](/images/posts/anki_EveEKoynm3.png)

#### 2.2 准备工作

这个插件的使用方法，在Github有详细解释：[https://github.com/open-spaced-repetition/fsrs4anki](https://github.com/open-spaced-repetition/fsrs4anki)，它有2个js文件，默认情况下，我们可以直接复制粘贴它里面的js脚本粘贴到我们的anki中，类似下面这样子，点击保存就设置好了，js脚本是粘贴到Custom scheduling这个框里面，它的js脚本分为QT5版本和QT6版本。我这里使用的是QT6版本的脚本。只需要粘贴这个脚本到我们的anki这个Custom scheduling里面，就配置完了。这个只是笼统的说是这样子的，但实际上，我们要生成我们自己的参数，还需要导出我们自己的所有anki卡片，去拿这个工具去训练出我们自己的参数，替换掉这个脚本里面默认的参数才行。下面我们直接讲怎么操作。

![anki_rH3PioEUnz](/images/posts/anki_rH3PioEUnz.png)



#### 2.3 安装Jupyter

为了安装Jupyter，我们只需要去把Anaconda安装到我们电脑就可以了。Anaconda网站下载：
[https://www.anaconda.com/](https://www.anaconda.com/)

进入到Anaconda官网，看到这个首页就是下载地址，直接下载windows版本的安装文件安装即可，跟我们平时安装其他软件一样，直接下一步，下一步，搞定即可。

![chrome_brNQTPmNMa](/images/posts/chrome_brNQTPmNMa.png)

安装完成之后，我们电脑里面就有`Jupter Notebook(anaconda3)`这个软件了

![explorer_xLilsZN3hz](/images/posts/explorer_xLilsZN3hz.png)

![Obsidian_Ga8AUaLkmT](/images/posts/Obsidian_Ga8AUaLkmT.png)

安装完成之后，我们在windows10开始菜单中就可以看到`Jupyter Notebook(anaconda3)`这个软件了，如下：

![0Qth4u9gQL](/images/posts/0Qth4u9gQL.png)

这样子Jupyter就安装完成了。

#### 2.4 下载FSRS4Anki Helper源码

根据这个Github网址[https://github.com/open-spaced-repetition/fsrs4anki](https://github.com/open-spaced-repetition/fsrs4anki)，我们下载这个Github项目的压缩包，如下图，点击Code图标，Download Zip，把它这个插件项目的代码下载到我们自己windows电脑上。

![CaFiX7SxzD](/images/posts/CaFiX7SxzD.png)

下载到压缩包，解压出来，我们可以看到，解压出来的文件里面的文件如下：

![mKwKGGmKdi](/images/posts/mKwKGGmKdi.png)

好了，我们先把这个源码放在这里备用，我们下一步，打开jupyter工具，这个源码要被下一步的jupyter用到。

#### 2.5 打开jupyter工具

开始菜单中我们找到`Jupter Notebook（anaconda3）`，鼠标右键，以管理员身份运行。

![Typora_jizrMJFRJa](/images/posts/Typora_jizrMJFRJa.png)

![chrome_AAa51Nll5h](/images/posts/chrome_AAa51Nll5h.png)

打开的一瞬间，会有个黑窗口出来，并且会自动打开浏览器，进入到jupyter的主页，这个页面是在我们电脑本地打开的，并不是浏览器网站，这个网站是在我们自己电脑上面jupyter的后台服务，如下：

![python_xfL94aNYF4](/images/posts/python_xfL94aNYF4.png)

它的地址是localhost:8888/tree 这个地址。

我们把前面这个黑框 最小化，不要关掉这个黑框了。jupyter后台的运行需要保持这个黑框一直运行着。

#### 2.5.1 新建文件夹

在jupyter这个网站页面中，我们创建一个新文件夹，用来保存我们在上面2.4小节中下载到的那个`FSRS4Anki Helper源码`,

![0a7DXNrFvf](/images/posts/0a7DXNrFvf.png)

如下操作，选择新建文件夹，会默认新建一个文件名为`Untitled Folder`的文件夹，我们把这个文件夹随便重新命名一个我们容易记住的名字，比如叫做`Anki`。

![Vyy7HDPWwe](/images/posts/Vyy7HDPWwe.png)

![YFPMebpJNH](/images/posts/YFPMebpJNH.png)

首先是找到这个刚创建的新文件夹，然后选中它：

![chrome_SCavTs8BLN](/images/posts/chrome_SCavTs8BLN.png)

选中之后，回到顶部位置，找到`Rename`重命名按钮，点击之后，填入新名字`Anki`，点击Rename，那么就会看到列表里面有个Anki文件夹了。

![7H674TYxWM](/images/posts/7H674TYxWM.png)

![chrome_3zNKo08i5N](/images/posts/chrome_3zNKo08i5N.png)

![CuXP2ewrjG](/images/posts/CuXP2ewrjG.png)



#### 2.5.2 上传FSRS4Anki Helper源码

进入到这个Anki文件夹中，我们选择Upload按钮，开始上传FSRS4Anki Helper源码。

![kKkGG8C1Rl](/images/posts/kKkGG8C1Rl.png)

在打开的对话框中，我们找到FSRS4Anki Helper源码所在文件夹，选中所有文件上传。

![P8qshYUvvI](/images/posts/P8qshYUvvI.png)



![RSdQcbqRXj](/images/posts/RSdQcbqRXj.png)

依次点击这些文件，上传即可，有2个文件会上传失败，不用管它，上传失败的，我们直接回到列表中点击cancle按钮取消即可：

![ShareX_UTIO4ognPN](/images/posts/ShareX_UTIO4ognPN.png)

![chrome_0Uu8yDIigI](/images/posts/chrome_0Uu8yDIigI.png)



#### 2.5.3 导出我们所有Anki卡片

回到anki界面，Export导出，这些卡片数据最终会被用来进行机器学习，生成针对我们这些卡片优化后的参数。

![anki_nc5SiiTb2C](/images/posts/anki_nc5SiiTb2C.png)

导出的时候，`Include media`的勾去掉:

![v3wEd4cyUl](/images/posts/v3wEd4cyUl.png)

导出之后，我们会得到类似下面这个文件：`collection-2023-01-22@01-37-19.colpkg`

![explorer_T5GNHCrSQV](/images/posts/explorer_T5GNHCrSQV.png)



把这个文件上传到jupyter我们之前创建的那个Anki文件夹中。

![1j2XU2jiKt](/images/posts/1j2XU2jiKt.png)

![chrome_xjOHAyAIqq](/images/posts/chrome_xjOHAyAIqq.png)

点击Upload上传，如下：

![BSsb69oHo1](/images/posts/BSsb69oHo1.png)

我们把这个文件上传之后，我们开始针对这个文件，生成我们自己的参数。

#### 2.5.4 本地生成参数

最终我们上传到jupyter的文件如下图所示。我们选择其中的`fsrs4anki_optimizer.ipynb`点击，注意，不要选择错了，一定要看清楚，是带有`optimizer`字样的这个，而不是`simulator`字样的那个。

![YCeIwx2U3i](/images/posts/YCeIwx2U3i.png)

进入之后，我们修改这个地方的文件名为我们之前自己Export从anki导出的那个文件名，根据你实际导出的文件名来填写，我这里的文件名是`collection-2023-01-22@01-37-19.colpkg`,我这里就把下面这个参数修改为`collection-2023-01-22@01-37-19.colpkg`. 这里一定是有 colpkg后缀名的，没有后缀名，你要把电脑显示文件后缀名给开启来。

![explorer_7MTwNWjbGn](/images/posts/explorer_7MTwNWjbGn.png)

![5R9FA2PUnb](/images/posts/5R9FA2PUnb.png)

替换掉这个文件名之后，我们点击 Cell ,Run All.

![chrome_FVOUiPI52c](/images/posts/chrome_FVOUiPI52c.png)

![123453ccccccc453g](/images/posts/123453ccccccc453g.gif)

遇到了报错，我们采用线上的方式生成我们的数据。进入到下面小节，2.5.5 线上生成参数。

![chrome_j5hpEJMcdK](/images/posts/chrome_j5hpEJMcdK.png)

本地生成参数出现错误，我们改用线上的方式生成。并且这里也推荐新手采用线上方式生成。

#### 2.5.5 线上生成参数

由于本地生成参数失败，我们走线上渠道，在本地`jupyter`这个页面回到顶部，找到这个`Open in Colab`按钮(如下图)，点击之后跳转到线上地址。

![PgA0ndDQDn](/images/posts/PgA0ndDQDn.png)

线上地址跳转之后，如下：

![chrome_MTpfA40tDv](/images/posts/chrome_MTpfA40tDv.png)

我们需要把之前导出的那个anki数据上传到这里来，如下，点击左侧栏的文件夹图标，展开得到初始化的文件夹线上地址。最终如下图2所示。

![1234kjddsfsf987g](/images/posts/1234kjddsfsf987g.gif)

![chrome_Horp6eRQHL](/images/posts/chrome_Horp6eRQHL.png)

点击这个上传↑图标，上传我们的anki卡片数据。

![nYe6a1brUS](/images/posts/nYe6a1brUS.png)

最终上传成功，效果如下图：`collection-2023-01-22@01-37-19.colpkg`已经在里面了。

![chrome_KVmSaKhtIa](/images/posts/chrome_KVmSaKhtIa.png)

最终是上传成功。我们修改配置文件名，改为我们这个上传的文件名`collection-2023-01-22@01-37-19.colpkg`，如下图所示：

![U6XMbu7HcK](/images/posts/U6XMbu7HcK.png)

修改之后，我们就可以开始执行这个脚本了，回到顶部菜单位置，点击`RunTime`，`Run all`：

![y9sQMZrSIM](/images/posts/y9sQMZrSIM.png)

选择Run anyway，继续执行：

![LbAc7AAyAP](/images/posts/LbAc7AAyAP.png)

脚本开始执行，如下图所示：这个执行过程非常慢，大概需要25分钟左右，看你的卡片数量而定...

![1234kjdd34535355dfgdgds7g](/images/posts/1234kjdd34535355dfgdgds7g.gif)

等待脚本慢慢执行，它正在根据我们自己导出来的anki卡片数据进行AI机器学习运算，最终会计算出一个最优化的参数。我们之后要拿到这个结果参数，去替换掉js脚本中的参数，粘贴到我们自己的anki中去。这个参数，最好是保存到一个word文档或者txt里面，下次如果丢失了，能够找到这个参数。就不需要每次进行这么久的时间去在线运算这些数据了。

本来我们是要在2.5.4小节采用`本地生成参数`的方式来得到这个参数的，因为本地环境python缺少模块，只能最终选择线上的方式来生成，线上这个方式，耗时会比较久,等待结果的过程中我们可以看看它整个运行过程。

机器学习训练过程中，我们可以鼠标往下拖动脚本页面查看程序运行的一些结果:

![chrome_J7xjDTUqcS](/images/posts/chrome_J7xjDTUqcS.png)

![chrome_85DAn2UtUI](/images/posts/chrome_85DAn2UtUI.png)

脚本是从上到下执行的，分小节执行的，每个小节标有数字序号，我们要拿的结果，在第3个小节，Result这里。等脚本全部执行完，我们需要向下拖动浏览器滚动条，找到第3小节，Result那个位置去拿结果。脚本还没有跑完之前，这里是不会有结果的。

![Typora_clhUMOkCkP](/images/posts/Typora_clhUMOkCkP.png)

#### 2.5.6 得到结果

最终，我们拖动浏览滚动条，如下位置，这里会显示最终的结果。下面空白处，输出了` var w = ......`字样：

![5wS6V65aI7](/images/posts/5wS6V65aI7.png)

拿到最终的结果如下：

```shell
var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];
```



#### 2.5.7 替换脚本

回到脚本这里，我们找到文件`fsrs4anki_scheduler.js`，使用编辑器打开，这里推荐使用Notepad++打开。

![UTQ9DGXpdc](/images/posts/UTQ9DGXpdc.png)

在线生成的参数是根据我自己anki的所有卡片数据生成的，如下：

`var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];`

用这个生成出来的参数，替换脚本中的这3行：

![MSSS14QKVN](/images/posts/MSSS14QKVN.png)

替换之后，整个复制这个脚本内容，粘贴到我们的anki中去：

1.把`V3 Scheduler`勾选上； 2.去Deck的设置中，粘贴这个参数到`Custom Scheduling`中，3.`Reschedul all cards`重置所有卡片的schedule。这样子就完成了新参数的设置和优化了。

![12666776werfgdgds7g](/images/posts/12666776werfgdgds7g.gif)

#### 2.5.8 脚本版本的区别

打开anki菜单中的About页面，查看你的anki的版本是QT6还是QT5, 不同的版本，使用不同的脚本：

![anki_AO9WtfogJp](/images/posts/anki_AO9WtfogJp.png)



![Rb5pgVl0mn](/images/posts/Rb5pgVl0mn.png)

如果版本是QT6则使用`fsrs4anki_scheduler.js`， 如果是QT5则使用`fsrs4anki_scheduler_qt5.js`。

目前这个脚本，好像只能支持`QT6版本，电脑端Anki`。
