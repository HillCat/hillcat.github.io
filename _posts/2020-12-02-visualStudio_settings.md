---
layout: post
title: VisualStudio操作技巧汇总
categories: DotNetCore
description: VisualStudio常用技巧
keywords: trpora
typora-root-url: ../
---

此文不定期整理VisualStudio使用的一些技巧。包括快捷键，还有插件的使用，一些重构代码的一些快捷方法。新版本的visual sutido特性的更新等。有些常用的快捷方式，熟悉之后对提高生产力很有帮助。

### 让当前所处代码function,class，namespace位置置顶显示

这个功能主要是方便在浏览代码的时候，清楚的知道当前行所处的代码块位置，比如当前的代码块所处于哪个function内部，或者处于哪个class内部，当代码行特别多的时候，开启这个功能非常有必要。


### visual sutido2022弹出提示Just My Code Warning

![image-20220706094655928](/images/posts/image-20220706094655928.png)

https://techstrology.com/you-are-debugging-a-release-build-of-dll-using-just-my-code-with-release-builds-using-compiler-optimizations-results-in-a-degraded-debugging-experience/

解决办法：visual studio 2022 --->debug ---->options  

![image-20220706095117871](/images/posts/image-20220706095117871.png)



### 关掉部分特性，节省vs2022内存消耗

这些设置可以降低visual studio 2022的内存消耗。

![image-20220703151014999](/images/posts/image-20220703151014999.png)

![image-20220703151220633](/images/posts/image-20220703151220633.png)

参考资料：[https://stackoverflow.com/questions/70683618/visual-studio-2022-highly-used-memory](https://stackoverflow.com/questions/70683618/visual-studio-2022-highly-used-memory)


### 1.常用快捷技巧

Ctrl + Home键：回到文档的顶部

Ctrl+End键：回到文档的底部

Home键：移动到行首，按两次Home键，直接移动到边框最左端

**Ctrl +R 连按2次：修改变量名**。在安装了Resharp插件的时候，这个功能会同时把整个解决方案中的类名文件名，接口文件名一起修改，非常方便，特别是代码重构的时候加快开发效率。



### 代码生成器

利用T4模板，生成Efore相应的代码，参考：[https://marketplace.visualstudio.com/items?itemName=DevartSoftware.DevartT4EditorforVisualStudio](https://marketplace.visualstudio.com/items?itemName=DevartSoftware.DevartT4EditorforVisualStudio)



关于T4模板官方介绍：[https://docs.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates?view=vs-2022](https://docs.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates?view=vs-2022)

![aO11fgVAgZ](/images/posts/aO11fgVAgZ.png)

### Immediate Windows打印变量为Json字符串

在debug模式下，Newtonsoft.Json.JsonConvert.SerializeObject(someVariable) 既可以变量变为Json 

其他方法参考：[https://stackoverflow.com/questions/67410924/how-visual-studio-immediate-windows-to-print-format-indented-json](https://stackoverflow.com/questions/67410924/how-visual-studio-immediate-windows-to-print-format-indented-json)

![image-20220309175229224](/images/posts/image-20220309175229224.png)

### vs2022针对不同的project显示tab不同颜色

这个tab针对不同的project区分不同的颜色，对于提升开发效率有着一定的提升。特别是关掉一些不要用的tab对于提升代码专注度很有好处。根据颜色就非常容易区分，把那些跟当前Project颜色不一样的文件全部关闭，防止其他项目干扰。

![image-20220305171859118](/images/posts/image-20220305171859118.png)

### Debug的时候去掉Diagnostic弹窗的显示

![image-20220305153656274](/images/posts/image-20220305153656274.png)

#### Git版本管理技巧

为了最大限度防止漏提交了文件，最好是使用Vs自带的工具进行commit，之后再使用git乌龟工具拉取分支之后再push，当然，这些东西都可以在visualStudio中进行。

![9b7epT7ZF3](/images/posts/9b7epT7ZF3.png)

![6u93IiQG7g](/images/posts/6u93IiQG7g.png)



### 使用TaskList标记TODO

参考：[https://docs.microsoft.com/en-us/visualstudio/ide/using-the-task-list?view=vs-2022](https://docs.microsoft.com/en-us/visualstudio/ide/using-the-task-list?view=vs-2022)

在visual studio 2019中 view菜单中打开task list，可以查看到我们平时标记的TODO列表，而这个地方还可以自定义BUG等自己的标记，打开Task List的时候就可以看到一些代码的位置，提升我们开发效率。当团队中其他人也在使用这个标签的时候，就会变得比较混乱，查找起来也不方便，很多Project来回切换，做好标记非常重要。

![image-20220312074723153](/images/posts/image-20220312074723153.png)![image-20220312074744340](/images/posts/image-20220312074744340.png)

![image-20211125183343042](/images/posts/image-20211125183343042.png)

![image-20211125183432426](/images/posts/image-20211125183432426.png)

### 2.给vs任意位置设置合适的字体大小

#### 1.设置全局菜单、侧边栏字体大小：

<img src="/images/posts/visualStudioSettings714.gif"/>

代码编辑区推荐的字体设置如下：

![image-20220126144328715](/images/posts/image-20220126144328715.png)

#### 2.设置代码编辑区域popup提示弹窗内字体大小：

<img src="/images/posts/editorTootip736.gif"/>

#### 3.设置AI智能补全提示文字大小

AI智能补全是微软新出来的一个vs增强功能，很多时候这个AI提示字体非常小，把它字体设置稍微大一些，提升开发体验。另外关于AI智能补全功能的，可以参考：[https://dotnetcoretutorials.com/2021/11/27/turning-off-visual-studio-2022-intellicode-complete-line-intellisense/](https://dotnetcoretutorials.com/2021/11/27/turning-off-visual-studio-2022-intellicode-complete-line-intellisense/)

<img src="/images/posts/statement_completion03.png"/>

<img src="/images/posts/statement_completion14344.png"/>

具体的设置路径：Tools – Options – Environment - Fonts and Colors > Statement Completion

### 3.自动注入私有属性设置

#### 1.自动生成私有变量属性

可以强制设置私有变量为 ‘_' 带有下划线的小驼峰方式：

<img src="/images/posts/UnderScore055.png"/>

设置完毕之后：

<img src="/images/posts/underscore_15.png"/>

我这里选择的是Refactoring Only：

<img src="/images/posts/underscore_reflector845.png"/>

最终使用的效果就是如下：visualstudio 2019会把含有依赖注入的属性，自动给补上，并且打上私有属性下划线。

<img src="/images/posts/reflector_creator32.gif"/>

如果没有这个设置，那么编辑器给出来的自动提示就是如下这种：

<img src="/images/posts/private_properties526.png"/>

这个设置在依赖注入的时候，使用起来特别方便。

### 4.提升vs效率

#### 1.Shift + Enter 

专门用来快速输入`大花括号`，当程序员输入一个类或者方法，需要敲入 `{  }   `一对大花括号的时候，直接Shift +Enter即可快捷输入，并且光标会停留在花括号的正中间开始的位置。

#### 2.Move Class

这个功能可以把cs文件中的class类单独移动出去成为一个独立的class文件,当从其他文件拷贝class类和代码的时候这个技巧非常有用。可以先把class代码拷贝到一个namespace中，然后使用这个Move type to    XXXX.cs ，就会单独把某个class新建为单独的cs类文件。

<img src="/images/posts/move_class750.png"/>

#### 3.自动复制文件顶部的using语句

<img src="/images/posts/auto_paste5327.png"/>

当进行代码的复制粘贴的时候，如果从一个文件A复制了一段代码，带有using引用的，当拷贝到B文件的时候，想要连同A文件顶部的相关的using语句也一并拷贝到B文件，那么就可以开启这个功能。

#### 4.继承关系跳转

<img src="/images/posts/inheriant0411.png"/>

开启这个功能之后，可以使得visual studio 2019编辑器的侧边栏显示蓝色的标记，鼠标点击之后，可以在拥有继承关系的类之间引进跳转。

#### 5.移除不用的Nuget包

这个是visual studio 2019 16.10.3 版本之后自带的功能，老版本的vs可能没有这个功能。

<img src="/images/posts/remove_nugetPacket943.png"/>



#### 6.EditorConfig文件统一开发风格

visualStudio中可以为项目添加EditorConfig文件，来统一整个开发团队的开发规范，比如单行代码缩进量的控制。

具体的设置可以参考：[使用 EditorConfig 创建可移植的自定义编辑器设置](https://docs.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options?view=vs-2019)

EditorConfig的更多规范参考[EditorConfig](https://editorconfig.org/)官方网站。

如果开启了EditorConfig文件，那么visualsudio编辑器的ErrorList提示里面会有Messages消息，提示用户进行一些代码规范上面的操作：

<img src="/images/posts/EditorConfig25.png"/>

EditorConfig的配置文件修改了之后，可以通过CleanCode一键格式化我们的代码文件：最典型的使用，就是格式化代码的缩进这些，如果对于[EditorConfig](https://editorconfig.org/)研究更深入，可以最大限度的规范我们开发风格。

<img src="/images/posts/clean_code917.png"/>

#### 7.抽取class类中的接口

这个方法跟上面的第2个方法，抽离class到单独的cs文件类似，是把class中的现有方法抽离出去，变为接口。这个在dtonetcore依赖注入的时候，要提取某些接口非常方便。

<img src="/images/posts/ExtraInterface753.png"/>



#### 8.Resharp插件

Resharp官方文档：如果是首次安装Resharp，请查阅官方文档：[使用Resharp第一步](https://www.jetbrains.com/help/resharper/First_Steps.html)。快速打开Resharp的设置页面使用快捷键：(**Alt+R, O**).这里只会使用到Resharp的关键几个功能：

1.代码智能提示修改为使用Resharp代替。设置完成之后，API接口的形参提示会直接弹出提示，提升编码效率。这里影响的是上方这块参数的智能提示。下方的那块智能提示是vs2019微软的AI提示给出来的信息。

<img src="/images/posts/resharp_Plugin49.png"/>

<img src="/images/posts/resharp_plugin22.png"/>


另外使用快捷键，ctrl + shift + space 也是可以弹出来参数智能提示的；

2.代码块的注释、取消注释

**Ctrl + Atl + /**        对于选中的代码块，注释、取消注释，都是这3个组合键。参考官方文档：[注释和取消注释代码](https://www.jetbrains.com/help/resharper/Coding_Assistance__Comment_Uncomment_Code.html)



#### 使用Resharp的好处

1.避免Swagger的坑

比如 Ctrl + R 修改API接口的形参名字的时候，经常是修改了cs文件里面的形参而忘记了去修改SwaggerXml文件夹中的配置，会导致某些接口的备注不会被显示出来，是因为有些地方形参名字改了，有些地方没有改，而导致Swagger出现莫名的问题。如果使用Resharp的批量修改，它会自动检测到所有地方的引用，通过引导程序帮助你把Swagger相关配置里面的也一并修改。

![LrbLRsTWw3](/images/posts/LrbLRsTWw3.png)

2.在if esle条件判断很多的时候，会提示你代码存在冗余，比如某些条件判断节点永远为false或者永远为true，这种小的细节，Resharp会智能提示你。

3.某些情况下lambda操作或者foreach操作可以精简为一句Linq操作，Resharp也会提示你。

#### 9.快速打开文件位置

快速打开一个cs文件所在的硬盘位置：

<img src="/images/posts/fast_open_file822.gif"/>

Copy Full Path拷贝全路径：

<img src="/images/posts/copy_full_path50.png"/>



#### 10.智能补全&&实现接口

快速实现接口的时候，visualstudio 2019默认是通过抛异常的方式实现接口的，类似如下这种效果：

<img src="/images/posts/throwing_property311.png"/>

如果要弄成自动实现方式,这是为auto Property:

<img src="/images/posts/auto_property210.png"/>

<img src="/images/posts/auto_property435.gif"/>

#### 11.找到真实的接口实现

一般情况下，如果实现类是一个接口类型的对象，我们定位这个类的方法的实现的时候，是定位到接口的里面去的，但是实际上我们需要找的是这个类对应方法的具体实现，使用F12快捷键明显是找不到具体的实现的，它会直接跳到接口里面：

<img src="/images/posts/jump_to_implemendation01.gif"/>

使用Ctrl F12快捷键可以跳转到接口的实现，这个快捷键跟欧陆词典的快捷键设置会有冲突，如果安装了欧陆词典要注意。

<img src="/images/posts/edit_user_shortcut230.png"/>

<img src="/images/posts/oulu_settings313.png"/>

#### 12.跳转到定义字段

Ctrl + 鼠标左键

<img src="/images/posts/ctrl_clickLeft27.gif"/>

#### 13.Go To All

<img src="/images/posts/goes_to_all816.png"/>

默认情况下，使用Ctrl + T 是可以呼出这个功能的，如下：

<img src="/images/posts/got_to_all5914.png"/>

这个快捷键会被resharp的Search功能替换掉，如果觉得影响性能，可以不安装Resharper。这个快捷键原本是属于visualstudio的.

<img src="/images/posts/resharp_40943.png"/>



<img src="/images/posts/camel303.png"/>

可以对驼峰命名的关键字进行匹配。

而且还能自动跳转到相应的代码行，是实时响应式的：

<img src="/images/posts/jumper_codeline18.png"/>

还可以限定某些文件类型：

<img src="/images/posts/limit_type628.png"/>

这个功能最大的优点是查询速度非常快，实时定位到相应位置。

#### 14.移除掉不必要的命名空间

<img src="/images/posts/removing_name_space357.gif"/>

#### 15.格式化代码

Ctrl + E  D

<img src="/images/posts/ctrl_e_d350.png"/>

<img src="/images/posts/format_code1715.gif"/>

#### 16.控制台中调试Csharp代码

在命令控制台种直接执行调试某些C # 代码：

<img src="/images/posts/csharp_code_interface2424.png"/>

在控制台里面，就像chrome的console种调试js代码一样方便：

<img src="/images/posts/console_csharp2611.png"/>

#### 17. Alt + 上下方向键

这个Alt 结合 键盘上面的方向键，上下箭头，是可以做到快速移动代码位置的，效果如下：

<img src="/images/posts/fast_removing140.gif"/>

选中一大段代码进行移动位置都是可以的。

#### 18.给Vs增加新功能

Tools菜单栏，Get Tool and Fetures...

很多时候都是寻找微软的那个exe更新器给vs更新或者卸载模块，其实这里有个菜单可以直接对vs模块功能增加删除。

<img src="/images/posts/Add_Extension440.gif"/>

#### 19.In line Hints

行内提示功能，一般是Resharper插件中的功能，但是在vs2019中其实默认是没有被启用的，可以通过相关设置启用。

在没有启用In Line Hints功能之前，我是通过安装Resharper来得到这种行内提示效果：

<img src="/images/posts/In_line_hints1451.png"/>

尝试禁用Resharper插件，使用visual studio 2019自带的In Line Hints功能，把下面没有打勾的全部打上勾：

<img src="/images/posts/In_Line_Hints11311.png"/>

不过总体感觉vs自带的行内提示还是没有Resharper的那种体验好。节省vs性能的时候可以使用自带的凑合用。自带的提示，Lambda的提示信息不要勾选上，要不然会显示过多的信息，干扰阅读代码。某些情况下resharp插件会提示你，visual studio2019自带的In line Hint已经被关闭。如果要启用的话，为了防止冲突，开启visual studio的行内提示的情况下在禁用掉resharp的行内提示。

### 5.VisualStudio的AI提示

微软的AI代码提示功能靠下面的Visual Studio IntelliCode给出来的。

<img src="/images/posts/vs_AI41.png"/>

<img src="/images/posts/vs_Ai3846.png"/>

微软的这个AI提示会根据经验值，把频率最高的API给排序显示出来，方便日常快速开发。默认的设置是通用的，并不是针对C#的，如果是开发.net的话，需要把所有专门针对C#的智能提示给开启：最新版vs2019这里有9项全部开启。那么AI智能提示就全部是针对C#的。

<img src="/images/posts/vs_Ai_Settings623.png"/>

完成这些设置之后，通过view菜单进入到Visual Studio IntelliCode界面；

<img src="/images/posts/createModel940.png"/>

进入到这个页面之后点击生成Patterns，那么就会根据用户当前项目中使用到的有些语法特征，分析出AI模型，对用户当前的项目提供特定的AI智能提示：数据模型创建完毕之后处于Ready状态。开启这个功能之后，以后每次打开一个已经存在于电脑硬盘上面的.net项目都会自动开启本地Local的Ai分析，这个插件对应的AI程序会针对本地的代码进行AI建模分析，给出合理的代码提示建议。

<img src="/images/posts/IntelliSense113.png"/>

### 6.visualStudio扩展插件

#### 1.Add New File

插件下载地址：[https://marketplace.visualstudio.com/items?itemName=MadsKristensen.AddNewFile](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.AddNewFile)

![add_file](/images/posts/add_file.png)

安装上这个插件之后，就可以非常方便的创建各种文件，包括文件夹的嵌套都是非常方便的，特别是创建cs文件的时候。而且这个插件会默认开启快捷键shift + f2, 给开发带来比较大的便利性。

#### 2.CodeMaid

插件地址：[https://www.codemaid.net/](https://www.codemaid.net/)![codemaid](/images/posts/codemaid.png)

#### 3.Indent Guides

![identguide](/images/posts/identguide.png)

插件地址：[https://marketplace.visualstudio.com/items?itemName=SteveDowerMSFT.IndentGuides](https://marketplace.visualstudio.com/items?itemName=SteveDowerMSFT.IndentGuides)



### 7.影响visualSdutio性能的硬件因素

参考：[codenong.com/867741/]()

影响visualStudio加载大型项目速度的是SSD固态硬盘，如果电脑中存在机械硬盘，则对于visualSdutio加载速度的影响是巨大的。而影响编译速度的主要是CPU主频。日常使用中，各种智能提示、智能感知的速度更大程度上取决于更快的CPU。

### 8.快捷键

#### Ctrl + M + O: 折叠所有方法

Ctrl + M + M: 折叠或者展开当前方法

#### Ctrl + M + L: 展开所有方法



#### ctrl + shift +F

如果是安装的原版简体中文windows10操作系统，这个visual studio 2019快捷键会会被系统的输入法切换键给占用，占用之后发现visual studio2019的这个功能键失效了。

可以参考这篇帖子：“[简体/繁体中文输入法切换](https://jingyan.baidu.com/article/6b97984d87cee15da2b0bfc0.html)” ，关掉这个简体繁体中文输入法切换功能即可，或者设置为其他的组合键，不要和visual studio 2019发生冲突即可。

#### Alt +F7 

这个快捷键也是比较有用的，如图：

![XKfP3AaZGK](/images/posts/XKfP3AaZGK.png)

在visual studio 2019打开的文件特别多的时候，在tab栏去切换已经打开的文件或者窗口非常蛋疼，用这个快捷键直接显示出所有Active状态的文件和窗口，非常方便。参考这篇:[How to: Move around in the Visual Studio IDE](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-move-around-in-the-visual-studio-ide?view=vs-2019)

#### shift + F12

查找所有的引用。

#### ctrl + F12

跳转到具体的实现。

#### ctrl +shift +f9 

删除所有的debug调试标记点，特别是在项目告一段落的时候，会有之前记录过的很多debug痕迹，可以使用快捷键一键删除。

### 9.如何导出vs2019配置

参考这篇：[What's the best way to export all of my visual studio 2019 configuration](https://docs.microsoft.com/en-us/answers/questions/382848/what39s-the-best-way-to-export-all-of-my-visual-st.html) 



### VisualStudio异常设置

visualStudio抛异常的时候，把抛异常的报错位置，精确到代码行：

OpenExceptionSettings

![image-20211229210638213](/images/posts/image-20211229210638213.png)
