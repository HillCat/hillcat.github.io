---
layout: post
title: 生产力台式机配置推荐
categories: Blog
description: 台式机windows方案推荐
keywords: trpora
---
以下是来自于一些评测网站提供的台式机PC配置单：比较推荐配置1作为家用的主力开发机。如果是短暂出差，另外准备一个比较便宜的轻薄笔记本(4500价位)即可。对比如果花费12000元购买联想拯救者Y9000X ，高配的itx台式机 +轻薄本 的组合，比较适合。而且价格和预算都要低于12000的联想拯救者。

### 配置1

<img src="https://cs-cn.top/images/posts/win_863.png"/>

处理器: i7-10700   8核16线程   价格：2229；

主板:微星B460M 迫击炮       改为  华硕 [B460-I GAMING  + Intel i7 10700散片](https://item.taobao.com/item.htm?spm=a230r.1.14.43.17df18333e7W6Z&id=639489164136&ns=1&abbucket=11#detail) ≈ **2899** ；    如果选择AMD平台的CPU主板组合，可以考虑[R5 5600G](https://item.jd.com/10034953966503.html) 价格：2249； 比英特尔i7便宜600多，性能差不多。不过，程序员生产力机型还是建议英特尔平台。[i5套装](https://item.jd.com/43328560104.html)=1469元(i5 10400F)

内存:[英睿达16GB 2666](https://item.jd.com/100020763062.html)双通道 ，价格：16GB(8G x 2) =449;   单根 8G ≈ 200； 配置24GB内存≈ **600**；最好是直接32GB，因为chrome浏览器开很多窗口，加上再开3个visual studio2019大型项目要分析源码框架，这个非常耗费内存，如果再开几个虚拟机docker，内存也会不够用。下图中16GB的内存，其实开3个visual Studio 2019和10几个chorme窗口，就感觉16GB不够用了，而且还开了SqlServerStudio，虚拟机是没有开的，如果是要开Linux虚拟机，这个16GB完全不够用。

<img src="https://cs-cn.top/images/posts/visualStudio2776.png"/>



固态硬盘:铠侠RC10/500G      价格：399 ， 如果是配置为[1T](https://item.jd.com/100012956294.html)，则 **699**

显卡:UHD

机箱：爱国者M5    价格：179;  [爱国者YOGO S1](https://item.jd.com/100015885304.html) 价格：**499**； 机箱的具体细节[https://www.bilibili.com/video/BV1cA411j7Fs/](https://www.bilibili.com/video/BV1cA411j7Fs/)

电源：~~酷冷至尊 雷霆500W铜牌   价格：379；     [全模组长城电源 600W](https://item.jd.com/100010194562.html)  价格 **499**；~~   itx机箱，电源只能使用SFX电源，台湾品牌 [SFP全汉500W/全模组铜牌/5年质保](https://item.jd.com/100006670405.html) ，价格529元。

散热器：乔思伯 240MM水冷  价格：339； [酷冷至尊 B240水冷 ](https://item.jd.com/4567820.html)，价格：**299**；

价格：3999元

硬盘提升到1T，则价格 +300；机箱改为爱国者YOGO S1 ITX 白色小机箱，则价格 +300；

全套 ：i7 CPU + 华硕主板 + 1T 固态硬盘 NVMe M.2接口 +24G内存 +爱国者机箱 S1 +水冷散热 +500W电源 = **5525 元**   （如果是 i5 10040F,整机价格=4095）

在有显卡的时候，峰值功率是 470W ；

参考连接： [intel Core i7 10700 + 华硕 B460-I GAMING](https://youtu.be/4z3lTLQM20w)

#### 注意事项

机箱这块可以考虑：[爱国者 S1-桌面立式ITX机箱 i7 10700+RTX3070装机体验](https://www.bilibili.com/video/BV14t4y1e76s/)，比中正评测推荐的机箱要好，内置防尘网。水冷这块更换为台湾的 酷冷至尊。

另外注意：微星b450i有一个特别严重的问题，它的无线网卡很垃圾，笔记本信号满格的地方它都搜不到信号，B460M是否有同样问题需要注意。

#### 其他配置

考虑到搬家，机箱太大不太方便，下面这个爱国者ITX机箱配合水冷系统，也是不错的考虑。

CPU：intel i5 -11600K    
主板: 华硕ROG B560-i GAMING WIFI  
散热: 华硕TUF破冰手240一体水冷
内存: 海盗船复仇者8+8G 3600
固态:三星980PRO 1TB M.2 NVME
显卡：七彩虹战斧RTX2060 6G
电源：长城SFX金牌全模组额定750W
机箱: 爱国者YOGO S1小新白色

CPU + 主板 =2618； 散热：799；内存：509；固态：899；电源：699；机箱：499；

#### 特别注意i7 CPU价格走势

从行情来看，Intel i 7 10700这个CPU是涨价了的。

在2021年4月20日的时候，就有人说主板+CPU涨价了300元，当时的价格是2401元，而现在2021年9月26日 主板+CPU价格是2899元。

也就是说2021年整整一年的时间 主板+CPU基本上涨了1000元。看样子2021年不太适合入手这个套装。

老台式机编译abp 3.0.0源码花费时间为：00：01：42.95  

#### 关于win11的问题

上面这套配置是可以支持win11的，CPU自带了TPM安全模块。

参考：[https://www.bilibili.com/read/cv12609304](https://www.bilibili.com/read/cv12609304)

### 配置2

<img src="https://cs-cn.top/images/posts/win2_4742.png"/>

处理器：R7-4750GE 8核16线程

主板：华硕B450M重炮手

内存：海盗船16G3600双通道

固态硬盘：铠侠RC10/500G

显卡:512SP

机箱：先马趣造

电源：酷冷至尊500W铜牌

散热器：玄冰400 4热管

价格：4000 RMB



京东：主板+CPU=2449  ；内存=519 ；固态硬盘：399；电源：259；散热：169；机箱：289；

### 配置3

这个配置据说是程序员专用笔记本：

<img src="https://cs-cn.top/images/posts/programmer_pc369.png"/>



### 配置4

CPU：十代酷睿I7 10700 

风扇：乔思伯CR1000 白色 

主板: 昂达Z490魔剑 

硬盘：凯侠RC10 500G M.2 NVME 

内存：铭瑄终结者16G 3200马甲条（8G*2） 

显卡：HD630核显（适合玩玩LOL坐等3060） 

电源：金河田智能芯GTX480（想上30系列显卡的可以+230升级航嘉700瓦铜牌） 

机箱：航嘉GS400C） 

价格大概是3599

参考地址：[https://www.bilibili.com/video/BV1bo4y1d7TT?share_source=copy_web](https://www.bilibili.com/video/BV1bo4y1d7TT?share_source=copy_web)

以上主板，主要是保证CPU不掉频。

### AMD方案

如果是不考虑i7处理器，则可以考虑AMD方案：

R7 4750G

3200内存

对于BIOS和驱动，会要求进行很多设置，这个相对于intel的i7而言，配置方面会比较麻烦。



### 帮朋友配置办公电脑

处理器:i3-10105   4核8线程

主板：华硕H510M-K

内存：宇瞻 8G 2666

固态硬盘：铠侠RC10/500G

显卡：HD630核显

机箱：爱国者M2

电源：长城300W 额定

散热器:玄刃猎户

价格：2199元， 不含运费



（处理器:i3-10105   4核8线程   +  主板：华硕H510M-K）套装     价格 ：1289元     

固态硬盘:铠侠RC10/500G      价格：399 

内存条宇瞻 8G 2666  价格：199

机箱,爱国者M2 价格：189

长城300W 额定，小金刚， 价格：159

散热器:玄刃猎户  价格：60

京东采购价格共计：2295元





如果是要2100左右的价格搞定全套。那机箱成本控制在1600左右，可以选择中正评测的这套方案：[https://item.taobao.com/item.htm?spm=a1z10.1-c.w4004-1253775079.13.23996a27WTYZPj&id=618648783294](https://item.taobao.com/item.htm?spm=a1z10.1-c.w4004-1253775079.13.23996a27WTYZPj&id=618648783294)

<img src="https://cs-cn.top/images/posts/zhongzheng335.png"/>



可以去京东的二手购买显示器：https://item.jd.com/41077601625.html

键鼠套装，搞个罗技的即可：https://item.jd.com/584300.html  



### 检测电脑系统版本

slmgr.vbs /dli



### 同事的电脑配置

CPU 英特尔 i5 10400F
主板 微星B460M BOMBER爆破弹
内存 镁光Crucial 8G 2666
硬盘 西数SN550 250G M.2 NVME
显卡 铭瑄GTX1650终结者
电源 全汉GT500额定500W铜牌
机箱 先马剑魔电竞版
风扇 先马玲珑12CM
散热器 长城霜龙200

