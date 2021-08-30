---
layout: post
title: VisualStudio操作技巧归类总结
categories: VisualStudio
description: VisualStudio常用技巧
keywords: trpora
---

此文不定期整理VisualStudio使用的一些技巧。包括快捷键，还有插件的使用，一些重构代码的一些快捷方法。新版本的visual sutido特性的更新等。有些常用的快捷方式，熟悉之后对提高生产力很有帮助。

### 1.常用快捷技巧

Ctrl + Home键：回到文档的顶部

Ctrl+End键：回到文档的底部

Home键：移动到行首，按两次Home键，直接移动到边框最左端

Ctrl +R 连按2次：修改变量名。在安装了Resharp插件的时候，这个功能会同时把整个解决方案中的类名文件名，接口文件名一起修改，非常方便，特别是代码重构的时候加快开发效率。



### 2.给VisualStudio2019设置合适的字号

#### 1.设置全局菜单、侧边栏字体大小：

<img src="https://cs-cn.top/images/posts/visualStudioSettings714.gif"/>

#### 2.设置代码编辑区域popup提示弹窗内字体大小：

<img src="https://cs-cn.top/images/posts/editorTootip736.gif"/>

#### 3.设置AI智能补全提示文字大小

AI智能补全是微软新出来的一个vs增强功能，很多时候这个AI提示字体非常小，把它字体设置稍微大一些，提升开发体验。

<img src="https://cs-cn.top/images/posts/statement_completion03.png"/>

<img src="https://cs-cn.top/images/posts/statement_completion14344.png"/>

具体的设置路径：Tools – Options – Environment - Fonts and Colors > Statement Completion

### 3.自动注入私有属性设置

#### 1.自动生成私有变量属性

可以强制设置私有变量为 ‘_' 带有下划线的小驼峰方式：

<img src="https://cs-cn.top/images/posts/UnderScore055.png"/>

设置完毕之后：

<img src="https://cs-cn.top/images/posts/underscore_15.png"/>

我这里选择的是Refactoring Only：

<img src="https://cs-cn.top/images/posts/underscore_reflector845.png"/>

最终使用的效果就是如下：visualstudio 2019会把含有依赖注入的属性，自动给你补上，并且打上私有属性下划线。

<img src="https://cs-cn.top/images/posts/reflector_creator32.gif"/>

如果没有这个设置，那么编辑器给出来的自动提示就是如下这种：

<img src="https://cs-cn.top/images/posts/private_properties526.png"/>

这个设置在依赖注入的时候，使用起来特别方便。

### 4.提升vs效率

#### 1.Shift + Enter 

专门用来快速输入`大花括号`，当你输入一个类或者方法，需要敲入 `{  }   `一对大花括号的时候，直接Shift +Enter即可快捷输入，并且光标会停留在花括号的真正中间开始的位置。

#### 2.Move Class

这个功能可以把cs文件中的class类单独移动出去成为一个独立的class文件,当从其他文件拷贝class类和代码的时候这个技巧非常有用。可以先把class代码拷贝到一个namespace中，然后使用这个Move type to    XXXX.cs ，就会单独把某个class新建为单独的cs类文件。

<img src="https://cs-cn.top/images/posts/move_class750.png"/>

#### 3.自动复制文件顶部的using语句

<img src="https://cs-cn.top/images/posts/auto_paste5327.png"/>

当你进行代码的复制粘贴的时候，如果从一个文件A复制了一段代码，带有using引用的，当你拷贝到B文件的时候，想要连同A文件顶部的相关的using语句也一并拷贝到B文件，那么就可以开启这个功能。

#### 4.继承关系跳转

<img src="https://cs-cn.top/images/posts/inheriant0411.png"/>

开启这个功能之后，可以使得visual studio 2019编辑器的侧边栏显示蓝色的标记，鼠标点击之后，可以在拥有继承关系的类之间引进跳转。

#### 5.移除不用的Nuget包

这个是visual studio 2019 16.10.3 版本之后自带的功能，老版本的vs可能没有这个功能。

<img src="https://cs-cn.top/images/posts/remove_nugetPacket943.png"/>



#### 6.EditorConfig文件统一开发风格

visualStudio中可以为项目添加EditorConfig文件，来统一整个开发团队的开发规范，比如单行代码缩进量的控制。

具体的设置可以参考：[使用 EditorConfig 创建可移植的自定义编辑器设置](https://docs.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options?view=vs-2019)

EditorConfig的更多规范参考[EditorConfig](https://editorconfig.org/)官方网站。

如果开启了EditorConfig文件，那么visualsudio编辑器的ErrorList提示里面会有Messages消息，提示你进行一些代码规范上面的操作：

<img src="https://cs-cn.top/images/posts/EditorConfig25.png"/>

EditorConfig的配置文件修改了之后，可以通过CleanCode一键格式化我们的代码文件：最典型的使用，就是格式化代码的缩进这些，如果对于[EditorConfig](https://editorconfig.org/)研究更深入，可以最大限度的规范我们开发风格。

<img src="https://cs-cn.top/images/posts/clean_code917.png"/>

#### 7.抽取class类中的接口

这个方法跟上面的第2个方法，抽离class到单独的cs文件类似，是把class中的现有方法抽离出去，变为接口。这个在dtonetcore依赖注入的时候，要提取某些接口非常方便。

<img src="https://cs-cn.top/images/posts/ExtraInterface753.png"/>



#### 8.Resharp插件

Resharp官方文档：如果是首次安装Resharp，请查阅官方文档：[使用Resharp第一步](https://www.jetbrains.com/help/resharper/First_Steps.html)。快速打开Resharp的设置页面使用快捷键：(**Alt+R, O**).这里只会使用到Resharp的关键几个功能：

1.代码智能提示修改为使用Resharp代替。设置完成之后，API接口的形参提示会直接弹出提示，提升编码效率。这里影响的是上方这块参数的智能提示。下方的那块智能提示是vs2019微软的AI提示给出来的信息。

<img src="https://cs-cn.top/images/posts/resharp_Plugin49.png"/>

<img src="https://cs-cn.top/images/posts/resharp_plugin22.png"/>


另外使用快捷键，ctrl + shift + space 也是可以弹出来参数智能提示的；

2.代码块的注释、取消注释

**Ctrl + Atl + /**        对于选中的代码块，注释、取消注释，都是这3个组合键。参考官方文档：[注释和取消注释代码](https://www.jetbrains.com/help/resharper/Coding_Assistance__Comment_Uncomment_Code.html)

#### 9.快速打开文件位置

快速打开一个cs文件所在的硬盘位置：

<img src="https://cs-cn.top/images/posts/fast_open_file822.gif"/>

Copy Full Path拷贝全路径：

<img src="https://cs-cn.top/images/posts/copy_full_path50.png"/>



#### 10.智能补全&&实现接口

快速实现接口的时候，visualstudio 2019默认是通过抛异常的方式实现接口的，类似如下这种效果：

<img src="https://cs-cn.top/images/posts/throwing_property311.png"/>

如果要弄成自动实现方式,这是为auto Property:

<img src="https://cs-cn.top/images/posts/auto_property210.png"/>

<img src="https://cs-cn.top/images/posts/auto_property435.gif"/>

#### 11.找到真实的接口实现

一般情况下，如果实现类是一个接口类型的对象，我们定位这个类的方法的实现的时候，是定位到接口的里面去的，但是实际上我们需要找的是这个类对应方法的具体实现，使用F12快捷键明显是找不到具体的实现的，它会直接跳到接口里面：

<img src="https://cs-cn.top/images/posts/jump_to_implemendation01.gif"/>

使用Ctrl F12快捷键可以跳转到接口的实现，这个快捷键跟欧陆词典的快捷键设置会有冲突，如果安装了欧陆词典要注意。

<img src="https://cs-cn.top/images/posts/edit_user_shortcut230.png"/>

<img src="https://cs-cn.top/images/posts/oulu_settings313.png"/>

#### 12.跳转到定义字段

Ctrl + 鼠标左键

<img src="https://cs-cn.top/images/posts/ctrl_clickLeft27.gif"/>

#### 13.Go To All

<img src="https://cs-cn.top/images/posts/goes_to_all816.png"/>

默认情况下，使用Ctrl + T 是可以呼出这个功能的，如下：

<img src="https://cs-cn.top/images/posts/got_to_all5914.png"/>

这个快捷键会被resharp的Search功能替换掉，如果觉得影响性能，可以不安装Resharper。这个快捷键原本是属于visualstudio的.

<img src="https://cs-cn.top/images/posts/resharp_40943.png"/>



<img src="https://cs-cn.top/images/posts/camel303.png"/>

可以对驼峰命名的关键字进行匹配。

而且还能自动跳转到相应的代码行，是实时响应式的：

<img src="https://cs-cn.top/images/posts/jumper_codeline18.png"/>

还可以限定某些文件类型：

<img src="https://cs-cn.top/images/posts/limit_type628.png"/>

这个功能最大的优点是查询速度非常快，实时定位到相应位置。

#### 14.移除掉不必要的命名空间

<img src="https://cs-cn.top/images/posts/removing_name_space357.gif"/>

#### 15.格式化代码

Ctrl + E  D

<img src="https://cs-cn.top/images/posts/ctrl_e_d350.png"/>

<img src="https://cs-cn.top/images/posts/format_code1715.gif"/>

#### 16.控制台中调试Csharp代码

在命令控制台种直接执行调试某些C # 代码：

<img src="https://cs-cn.top/images/posts/csharp_code_interface2424.png"/>

在控制台里面，就像chrome的console种调试js代码一样方便：

<img src="https://cs-cn.top/images/posts/console_csharp2611.png"/>

#### 17. Alt + 上下方向键

这个Alt 结合 键盘上面的方向键，上下箭头，是可以做到快速移动代码位置的，效果如下：

<img src="https://cs-cn.top/images/posts/fast_removing140.gif"/>

选中一大段代码进行移动位置都是可以的。

#### 18.给Vs增加新功能

Tools菜单栏，Get Tool and Fetures...

很多时候都是寻找微软的那个exe更新器给vs更新或者卸载模块，其实这里有个菜单可以直接对vs模块功能增加删除。

<img src="https://cs-cn.top/images/posts/Add_Extension440.gif"/>

#### 19.In line Hints

行内提示功能，一般是Resharper插件中的功能，但是在vs2019中其实默认是没有被启用的，可以通过相关设置启用。

在没有启用In Line Hints功能之前，我是通过安装Resharper来得到这种行内提示效果：

<img src="https://cs-cn.top/images/posts/In_line_hints1451.png"/>

尝试禁用Resharper插件，使用visual studio 2019自带的In Line Hints功能，把下面没有打勾的全部打上勾：

<img src="https://cs-cn.top/images/posts/In_Line_Hints11311.png"/>

不过总体感觉vs自带的行内提示还是没有Resharper的那种体验好。节省vs性能的时候可以使用自带的凑合用。自带的提示，Lambda的提示信息不要勾选上，要不然会显示过多的信息，干扰阅读代码。

### 5.VisualStudio的AI提示

微软的AI代码提示功能靠下面的Visual Studio IntelliCode给出来的。

<img src="https://cs-cn.top/images/posts/vs_AI41.png"/>

<img src="https://cs-cn.top/images/posts/vs_Ai3846.png"/>

微软的这个AI提示会根据经验值，把频率最高的API给排序显示出来，方便日常快速开发。默认的设置是通用的，并不是针对C#的，如果是开发.net的话，需要把所有专门针对C#的智能提示给开启：最新版vs2019这里有9项全部开启。那么AI智能提示就全部是针对C#的。

<img src="https://cs-cn.top/images/posts/vs_Ai_Settings623.png"/>

完成这些设置之后，通过view菜单进入到Visual Studio IntelliCode界面；

<img src="https://cs-cn.top/images/posts/createModel940.png"/>

进入到这个页面之后点击生成Patterns，那么就会根据你当前项目中使用到的有些语法特征，分析出AI模型，对你当前的项目提供特定的AI智能提示：数据模型创建完毕之后处于Ready状态。开启这个功能之后，以后每次打开一个已经存在于电脑硬盘上面的.net项目都会自动开启本地Local的Ai分析，这个插件对应的AI程序会针对本地的代码进行AI建模分析，给出合理的代码提示建议。

<img src="https://cs-cn.top/images/posts/IntelliSense113.png"/>

