---
layout: post
title: FSRS4Anki Helper插件(14)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

`FSRS4Anki Helper`插件的地址：[https://ankiweb.net/shared/info/759844606](https://ankiweb.net/shared/info/759844606)，安装码是：759844606。插件需要anki 2.1.55版本以上。该插件**仅能支持电脑端Anki**。这个插件的好处主要是3个：1.把留存率超过90%的卡片suspend处理；2，把留存率还没有达到90%，但是已经被你拖延的卡片的复习进度提前。3.把手机端复习过的卡片，复习间隔统一刷新为FSRS算法来更新，这样子虽然FSRS自定义算法没有支持手机，但是可以在PC上追加一层FSRS印记，再同步。等于说是让这套算法间接在手机原生anki算法的基础上叠加一层。效果跟你直接在PC上面复习卡片的效果是一样的。

### 1.FSRS4Anki Helper

安装插件之后，插件源码中会有2个js脚本，我们需要通过google的col lab在线训练数据，之后填写到js脚本里面，把脚本粘贴到我们的Anki电脑端。插件的地址：[https://ankiweb.net/shared/info/759844606](https://ankiweb.net/shared/info/759844606)，这个插件的安装码是：759844606。插件需要anki 2.1.55版本以上。仅支持电脑端Anki。使用方法请看插件源码的Github页面说明。

### 2.插件安装和使用

插件支持Anki2.1.55版本 及以上版本。去官方下载最新版本的Anki即可。

#### 2.1 安装插件

然后是安装插件，安装码是：759844606。直接到anki的add-ons菜单，`Get Add-ons...`里面填入这个Code码安装这个插件即可。安装完毕，就能看到这个插件了:

![anki_EveEKoynm3](/images/posts/anki_EveEKoynm3.png)

#### 2.2 准备工作

插件要正常使用，需要粘贴插件配套的js脚本到如下位置才能生效，同时下面的参数也请参考我的设置参数。

![anki_rH3PioEUnz](/images/posts/anki_rH3PioEUnz.png)





#### 2.3 配置插件js参数

根据这个Github网址[https://github.com/open-spaced-repetition/fsrs4anki](https://github.com/open-spaced-repetition/fsrs4anki)，我们下载这个Github项目的压缩包，如下图，点击Code图标，Download Zip，把它这个插件项目的代码下载到我们自己windows电脑上。

![CaFiX7SxzD](/images/posts/CaFiX7SxzD.png)

下载到压缩包，解压出来，我们可以看到，解压出来的文件里面的文件如下：

![mKwKGGmKdi](/images/posts/mKwKGGmKdi.png)

好了，我们先把这个源码放在这里备用，等我们在线生成参数之后，要回来编辑这个里面js文件，然后粘贴到Anki中。



#### 2.4 导出我们所有Anki卡片

回到anki界面，Export导出，这些卡片数据最终会被用来进行机器学习，生成针对我们这些卡片优化后的参数。

![anki_nc5SiiTb2C](/images/posts/anki_nc5SiiTb2C.png)

导出的时候，`Include media`的勾去掉:

![v3wEd4cyUl](/images/posts/v3wEd4cyUl.png)

导出之后，我们会得到类似下面这个文件：`collection-2023-01-22@01-37-19.colpkg`

![explorer_T5GNHCrSQV](/images/posts/explorer_T5GNHCrSQV.png)







我们用线上的方式生成参数，下一步操作，会要把这个导出的卡片数据上传到网上。

#### 2.5 在线生成参数

回到这个插件项目的Github地址，Github网址[https://github.com/open-spaced-repetition/fsrs4anki](https://github.com/open-spaced-repetition/fsrs4anki)

![Gf4vSpJwxe](/images/posts/Gf4vSpJwxe.png)

找到这个optimizer字样的文件，点击，在chrome新窗口打开。

![2cTnd4Vzza](/images/posts/2cTnd4Vzza.png)

打开之后，会进入这个页面：[https://github.com/open-spaced-repetition/fsrs4anki/blob/main/fsrs4anki_optimizer.ipynb](https://github.com/open-spaced-repetition/fsrs4anki/blob/main/fsrs4anki_optimizer.ipynb)

然后，点击如下图的`Open in Colab`:

![F9zG6DuENf](/images/posts/F9zG6DuENf.png)

点击之会跳转到google的colab网址，会自动打开这个脚本的运行页面，这是脚本的模拟运行环境，如下：

![chrome_MTpfA40tDv](/images/posts/chrome_MTpfA40tDv.png)

我们需要把之前导出的那个anki文件上传到这里来，如下，先展开左侧栏的File文件夹地址，展开方式是，直接点击左边这个第一个图标![Typora_uVHUOeo8md](/images/posts/Typora_uVHUOeo8md.png)展开Table of Content，然后点击![Typora_YwWefGDbSK](/images/posts/Typora_YwWefGDbSK.png)文件夹图标，它会显示`Connecting to a runtime to enable file browsing`，提示它正在加载运行时环境以便打开文件浏览器，等待几秒钟，它会在左侧栏加载出来文件列表。

![1234kjddsfsf987g](/images/posts/1234kjddsfsf987g.gif)

文件夹最终展开之后的效果如下，文件夹里面默认有个sample_data文件夹，如下：

![chrome_Horp6eRQHL](/images/posts/chrome_Horp6eRQHL.png)

我们点击如下的‘上传图标’，上传我们的anki卡片数据，从弹出对话框中，选择我们电脑中已经导出的anki文件，点击Open，开始上传。

![nYe6a1brUS](/images/posts/nYe6a1brUS.png)

最终上传成功，效果如下图：文件`collection-2023-01-22@01-37-19.colpkg`已经在里面了，我们需要复制这个文件的全名，包括colpkg这个后缀，一起复制。

![Typora_PoXOxv55ei](/images/posts/Typora_PoXOxv55ei.png)

如下所示，我们修改脚本里面的文本信息，filename改为我们的文件名`collection-2023-01-22@01-37-19.colpkg`，如下图所示：

![U6XMbu7HcK](/images/posts/U6XMbu7HcK.png)

修改之后，脚本会被自动保存。怎么执行脚本呢？回到顶部菜单位置，点击`RunTime`，`Run all`，弹出来一个警告提示框，选择Run anyway，忽略警告信息，执行脚本。

![y9sQMZrSIM](/images/posts/y9sQMZrSIM.png)



脚本开始执行，如下图所示：这个执行过程非常慢，大概需要25分钟左右，脚本会使用机器学习算法，帮你优化复习参数，

![1234kjdd34535355dfgdgds7g](/images/posts/1234kjdd34535355dfgdgds7g.gif)

等待脚本慢慢执行，它正在根据我们自己导出来的anki卡片数据进行机器学习，最终会计算出一个最优参数。如下这种：

![5wS6V65aI7](/images/posts/5wS6V65aI7.png)



我们之后要拿到这个结果参数，去替换掉js脚本中的参数，粘贴到我们自己的anki中去。在它出结果之前，我们耐心等待10~20分钟吧：

![chrome_J7xjDTUqcS](/images/posts/chrome_J7xjDTUqcS.png)

![chrome_85DAn2UtUI](/images/posts/chrome_85DAn2UtUI.png)

脚本分好几个环节依次执行，等脚本全部执行完，找到第3小节，Result这里拿结果。

![Typora_clhUMOkCkP](/images/posts/Typora_clhUMOkCkP.png)

#### 2.6 得到结果

最终，我们拖动浏览滚动条，拿到结果。

![5wS6V65aI7](/images/posts/5wS6V65aI7.png)

拿到最终的结果如下：

```shell
var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];
```



#### 2.7 替换变量w参数

js脚本中，定义的这个w参数我们要去替换成我们自己的。找到文件`fsrs4anki_scheduler.js`，使用编辑器打开，

![UTQ9DGXpdc](/images/posts/UTQ9DGXpdc.png)

替换如下3行，如果你看得懂里面的代码注释，同时也懂Anki的参数配置，可以详细对这个里面的其他部分进行修改。

![MSSS14QKVN](/images/posts/MSSS14QKVN.png)

改好之后保存，最好是把这个改好之后的脚本备份，以防止以后丢失了还要使用这个参数配置。拷贝整个脚本内容，粘贴到我们的anki中去。步骤如下：

1.把`V3 Scheduler`勾选上； 2.去option设置中，Scheduling页面找到`Custom Scheduling`那一项input框，把js粘贴进去，3.回到anki主界面，Tools菜单中，找到`Reschedul all cards`重置所有卡片的schedule。这样子就完成了新参数的设置和优化了。

![12666776werfgdgds7g](/images/posts/12666776werfgdgds7g.gif)



#### 2.8 本地生成参数

首先是安装Anaconda,网站下载：
https://www.anaconda.com/products/distribution/start-coding-immediately

安装pytorch:

https://pytorch.org/get-started/locally/
进入到上面的页面，页面中会有个安装脚本，复制粘贴到Anacoda Prompt运行：

不使用NVida显卡，只使用CPU，如下：
```shell
conda install pytorch torchvision torchaudio cpuonly -c pytorch
```
使用上面的方法，安装速度是非常快的，只需要使用芒果委培恩帆樯的话。

![Obsidian_6gTmSBg3yH](/images/posts/Obsidian_6gTmSBg3yH.png)

本地电脑安装成功jupyter Notes之后生成参数的速度就会比较快。可以每隔一段时间导出所有anki单词卡数据生成和优化一下参数。调整下我们的anki数据。

###3.解决手机端FSRS4Anki问题

根据anki论坛的帖子讨论，目前FSRS4Anki是不支持移动端手机anki的。但是我们大部分时间都是在手机上面复习卡片。在手机上还是依然使用的的anki原生的复习算法。那么怎么让手机上复习过的卡片也启用FSRS4Anki功能呢？思路就是把手机上复习过的卡片，在PC电脑上面用FSRS4Anki Helper插件刷新更新一下。

我们在PC端创建Filter Deck，通过`rated:2 -is:learn`筛选出最近2天的学习过的卡片，然后在这个deck的齿轮位置，点击Reschedule cards in deck即可，即便我们这2天在手机上复习过的卡片，也会被FSRS算法重置，这个重置并不是“归零”，而是把手机上使用的效果弄成和PC上使用FSRS效果一样，虽然你是在手机上复习了，导致了手机上的算法没用采用自定义复习算法，但是只要在PC端这么去刷新下，这2天在手机上复习过的卡片，就会等价于是在PC上采用了FSRS算法一样的效果了。

![Typora_6dvgyVXfIz](/images/posts/Typora_6dvgyVXfIz.png)

**官方文档search这块的语法说明**，rated:1 就是今天回答过的卡片；rated:1:2 就是今天回答过的Hard的卡片；rated:7:1 就是这个星期回答过的Again的卡片，rated:31:4 就是这个月回答过的Easy的卡片。

![chrome_M2MJr7SjtA](/images/posts/chrome_M2MJr7SjtA.png)



参考：

[https://docs.ankiweb.net/searching.html](https://docs.ankiweb.net/searching.html) anki 搜索语法

[https://www.reddit.com/r/Anki/comments/yhmddm/fsrs4anki_helper_question/](https://www.reddit.com/r/Anki/comments/yhmddm/fsrs4anki_helper_question/) 论坛帖子

原帖如下：

Helper can reschedule all cards, but you can select one deck to be rescheduled - click on the "gears" icon next to the deck name and choose "Reschedule cards in this deck".

FSRS4Anki scheduling works only on desktop, because it's using the custom scheduling feature, that is not available on the mobile. So cards scheduled on desktop by FSRS4Anki will appear in "proper" time on mobile. But after answering on mobile they will be scheduled by standard Anki algorithm.

What I implemented, as I am sometimes doing more reviews on the mobile than on desktop: I created filtered deck with the following search criteria: `rated:2 -is:learn`. It selects all cards rated today and yesterday, that are in review state. Then I rebuild this filtered deck, click "Reschedule cards in this deck" and empty it. By doing that I have all cards scheduled according to the FSRS4Anki, but I am not rescheduling all cards, only the ones answered recently.



### 4. 脚本版本的区别

如果Anki版本是QT6则使用`fsrs4anki_scheduler.js`， 如果是QT5则使用`fsrs4anki_scheduler_qt5.js`。



![Rb5pgVl0mn](/images/posts/Rb5pgVl0mn.png)



### 5.我的脚本参数

我的脚本参数，QT6版本的参数如下：

#### 5.1 QT6参数

```javascript
// FSRS4Anki v3.9.6 Scheduler Qt6
set_version();
// The latest version will be released on https://github.com/open-spaced-repetition/fsrs4anki

// Default parameters of FSRS4Anki for global
var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];
// The above parameters can be optimized via FSRS4Anki optimizer.

// User's custom parameters for global
let requestRetention = 0.9; // recommended setting: 0.8 ~ 0.9
let maximumInterval = 36500;
let easyBonus = 1.3;
let hardInterval = 1.2;
// FSRS only modifies the long-term scheduling. So (re)learning steps in deck options work as usual.
// I recommend not to set steps longer than one day.

// "Fuzz" is a small random delay applied to new intervals to prevent cards from
// sticking together and always coming up for review on the same day
const enable_fuzz = true;

debugger;

// get the name of the card's deck
// need to add <div id=deck deck_name="{{Deck}}"></div> to your card's front template's first line
if (document.getElementById("deck") !== null) {
    const deck_name = document.getElementById("deck").getAttribute("deck_name");
    // parameters for a specific deck
    if (deck_name == "ALL::Learning::English::Reading") {
        var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];
        // User's custom parameters for the specific deck
        requestRetention = 0.9;
        maximumInterval = 36500;
        easyBonus = 1.3;
        hardInterval = 1.2;
    // parameters for a deck's all sub-decks
    } else if (deck_name.startsWith("ALL::Archive")) {
        var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];
        // User's custom parameters for sub-decks
        requestRetention = 0.9;
        maximumInterval = 36500;
        easyBonus = 1.3;
        hardInterval = 1.2;
    }
}

// auto-calculate intervalModifier
const intervalModifier = Math.log(requestRetention) / Math.log(0.9);
// global fuzz factor for all ratings.
const fuzz_factor = set_fuzz_factor();

const ratings = {
  "again": 1,
  "hard": 2,
  "good": 3,
  "easy": 4
};

// For new cards
if (is_new()) {
    init_states();
    const good_interval = next_interval(customData.good.s);
    const easy_interval = Math.max(next_interval(customData.easy.s * easyBonus), good_interval + 1);
    if (states.good.normal?.review) {
        states.good.normal.review.scheduledDays = good_interval;
    }
    if (states.easy.normal?.review) {
        states.easy.normal.review.scheduledDays = easy_interval;
    }
// For learning/relearning cards
} else if (is_learning()) {
    // Init states if the card didn't contain customData
    if (is_empty()) {
        init_states();
    }
    const good_interval = next_interval(customData.good.s);
    const easy_interval = Math.max(next_interval(customData.easy.s * easyBonus), good_interval + 1);
    if (states.good.normal?.review) {
        states.good.normal.review.scheduledDays = good_interval;
    }
    if (states.easy.normal?.review) {
        states.easy.normal.review.scheduledDays = easy_interval;
    }
// For review cards
} else if (is_review()) {
    // Convert the interval and factor to stability and difficulty if the card didn't contain customData
    if (is_empty()) {
        convert_states();
    }
    const interval = states.current.normal?.review.elapsedDays ? states.current.normal.review.elapsedDays : states.current.filtered.rescheduling.originalState.review.elapsedDays;
    const last_d = customData.again.d;
    const last_s = customData.again.s;
    const retrievability = Math.exp(Math.log(0.9) * interval / last_s);
    const lapses = states.again.normal?.relearning.review.lapses ? states.again.normal.relearning.review.lapses : states.again.filtered.rescheduling.originalState.relearning.review.lapses;
    customData.again.d = next_difficulty(last_d, "again");
    customData.again.s = next_forget_stability(customData.again.d, last_s, retrievability);
    customData.hard.d = next_difficulty(last_d, "hard");
    customData.hard.s = next_recall_stability(customData.hard.d, last_s, retrievability);
    customData.good.d = next_difficulty(last_d, "good");
    customData.good.s = next_recall_stability(customData.good.d, last_s, retrievability);
    customData.easy.d = next_difficulty(last_d, "easy");
    customData.easy.s = next_recall_stability(customData.easy.d, last_s, retrievability);
    let hard_interval = next_interval(last_s * hardInterval);
    let good_interval = next_interval(customData.good.s);
    let easy_interval = next_interval(customData.easy.s * easyBonus)
    hard_interval = Math.min(hard_interval, good_interval)
    good_interval = Math.max(good_interval, hard_interval + 1);
    easy_interval = Math.max(easy_interval, good_interval + 1);
    if (states.hard.normal?.review) {
        states.hard.normal.review.scheduledDays = hard_interval;
    }
    if (states.good.normal?.review) {
        states.good.normal.review.scheduledDays = good_interval;
    }
    if (states.easy.normal?.review) {
        states.easy.normal.review.scheduledDays = easy_interval;
    }
}

function constrain_difficulty(difficulty) {
    return Math.min(Math.max(difficulty.toFixed(2), 1), 10);
}

function apply_fuzz(ivl) {
    if (!enable_fuzz || ivl < 2.5) return ivl;
    ivl = Math.round(ivl);
    const min_ivl = Math.max(2, Math.round(ivl * 0.95 - 1));
    const max_ivl = Math.round(ivl * 1.05 + 1);
    return Math.floor(fuzz_factor * (max_ivl - min_ivl + 1) + min_ivl);
}

function next_interval(stability) {
    const new_interval = apply_fuzz(stability * intervalModifier);
    return Math.min(Math.max(Math.round(new_interval), 1), maximumInterval);
}

function next_difficulty(d, rating) {
    let next_d = d + w[4] * (ratings[rating] - 3);
    return constrain_difficulty(mean_reversion(w[2], next_d));
}

function mean_reversion(init, current) {
    return w[5] * init + (1 - w[5]) * current;
}

function next_recall_stability(d, s, r) {
    return +(s * (1 + Math.exp(w[6]) *
    (11 - d) *
    Math.pow(s, w[7]) *
    (Math.exp((1 - r) * w[8]) - 1))).toFixed(2);
}

function next_forget_stability(d, s, r) {
    return +(w[9] * Math.pow(d, w[10]) * Math.pow(
        s, w[11]) * Math.exp((1 - r) * w[12])).toFixed(2);
}

function init_states() {
    customData.again.d = init_difficulty("again");
    customData.again.s = init_stability("again");
    customData.hard.d = init_difficulty("hard");
    customData.hard.s = init_stability("hard");
    customData.good.d = init_difficulty("good");
    customData.good.s = init_stability("good");
    customData.easy.d = init_difficulty("easy");
    customData.easy.s = init_stability("easy");
}

function init_difficulty(rating) {
    return +constrain_difficulty(w[2] + w[3] * (ratings[rating] - 3)).toFixed(2);
}

function init_stability(rating) {
    return +Math.max(w[0] + w[1] * (ratings[rating] - 1), 0.1).toFixed(2);
}

function convert_states() {
    const scheduledDays = states.current.normal ? states.current.normal.review.scheduledDays : states.current.filtered.rescheduling.originalState.review.scheduledDays;
    const easeFactor = states.current.normal ? states.current.normal.review.easeFactor : states.current.filtered.rescheduling.originalState.review.easeFactor;
    const old_s = +Math.max(scheduledDays, 0.1).toFixed(2);
    const old_d = constrain_difficulty(11 - (easeFactor - 1) / (Math.exp(w[6]) * Math.pow(old_s, w[7]) * (Math.exp(0.1 * w[8]) - 1)));
    customData.again.d = old_d;
    customData.again.s = old_s;
    customData.hard.d = old_d;
    customData.hard.s = old_s;
    customData.good.d = old_d;
    customData.good.s = old_s;
    customData.easy.d = old_d;
    customData.easy.s = old_s;
}

function is_new() {
    if (states.current.normal?.new !== undefined) {
        if (states.current.normal?.new !== null) {
            return true;
        }
    }
    if (states.current.filtered?.rescheduling?.originalState !== undefined) {
        if (Object.hasOwn(states.current.filtered?.rescheduling?.originalState, 'new')) {
            return true;
        }
    } 
    return false;
}

function is_learning() {
    if (states.current.normal?.learning !== undefined) {
        if (states.current.normal?.learning !== null) {
            return true;
        }
    }
    if (states.current.filtered?.rescheduling?.originalState !== undefined) {
        if (Object.hasOwn(states.current.filtered?.rescheduling?.originalState, 'learning')) {
            return true;
        }
    }
    if (states.current.normal?.relearning !== undefined) {
        if (states.current.normal?.relearning !== null) {
            return true;
        }
    }
    if (states.current.filtered?.rescheduling?.originalState !== undefined) {
        if (Object.hasOwn(states.current.filtered?.rescheduling?.originalState, 'relearning')) {
            return true;
        }
    }
    return false;
}

function is_review() {
    if (states.current.normal?.review !== undefined) {
        if (states.current.normal?.review !== null) {
            return true;
        }
    }
    if (states.current.filtered?.rescheduling?.originalState !== undefined) {
        if (Object.hasOwn(states.current.filtered?.rescheduling?.originalState, 'review')) {
            return true;
        }
    }
    return false;
}

function is_empty() {
    return !customData.again.d | !customData.again.s | !customData.hard.d | !customData.hard.s | !customData.good.d | !customData.good.s | !customData.easy.d | !customData.easy.s;
}

function set_version() {
    const version = "3.9.6";
    customData.again.v = version;
    customData.hard.v = version;
    customData.good.v = version;
    customData.easy.v = version;
}

function set_fuzz_factor() {
    // Note: Originally copied from seedrandom.js package (https://github.com/davidbau/seedrandom)
    !function(f,a,c){var s,l=256,p="random",d=c.pow(l,6),g=c.pow(2,52),y=2*g,h=l-1;function n(n,t,r){function e(){for(var n=u.g(6),t=d,r=0;n<g;)n=(n+r)*l,t*=l,r=u.g(1);for(;y<=n;)n/=2,t/=2,r>>>=1;return(n+r)/t}var o=[],i=j(function n(t,r){var e,o=[],i=typeof t;if(r&&"object"==i)for(e in t)try{o.push(n(t[e],r-1))}catch(n){}return o.length?o:"string"==i?t:t+"\0"}((t=1==t?{entropy:!0}:t||{}).entropy?[n,S(a)]:null==n?function(){try{var n;return s&&(n=s.randomBytes)?n=n(l):(n=new Uint8Array(l),(f.crypto||f.msCrypto).getRandomValues(n)),S(n)}catch(n){var t=f.navigator,r=t&&t.plugins;return[+new Date,f,r,f.screen,S(a)]}}():n,3),o),u=new m(o);return e.int32=function(){return 0|u.g(4)},e.quick=function(){return u.g(4)/4294967296},e.double=e,j(S(u.S),a),(t.pass||r||function(n,t,r,e){return e&&(e.S&&v(e,u),n.state=function(){return v(u,{})}),r?(c[p]=n,t):n})(e,i,"global"in t?t.global:this==c,t.state)}function m(n){var t,r=n.length,u=this,e=0,o=u.i=u.j=0,i=u.S=[];for(r||(n=[r++]);e<l;)i[e]=e++;for(e=0;e<l;e++)i[e]=i[o=h&o+n[e%r]+(t=i[e])],i[o]=t;(u.g=function(n){for(var t,r=0,e=u.i,o=u.j,i=u.S;n--;)t=i[e=h&e+1],r=r*l+i[h&(i[e]=i[o=h&o+t])+(i[o]=t)];return u.i=e,u.j=o,r})(l)}function v(n,t){return t.i=n.i,t.j=n.j,t.S=n.S.slice(),t}function j(n,t){for(var r,e=n+"",o=0;o<e.length;)t[h&o]=h&(r^=19*t[h&o])+e.charCodeAt(o++);return S(t)}function S(n){return String.fromCharCode.apply(0,n)}if(j(c.random(),a),"object"==typeof module&&module.exports){module.exports=n;try{s=require("crypto")}catch(n){}}else"function"==typeof define&&define.amd?define(function(){return n}):c["seed"+p]=n}("undefined"!=typeof self?self:this,[],Math);
    // MIT License
    // Copyright 2019 David Bau.
    // Permission is hereby granted, free of charge, to any person obtaining a copy
    // of this software and associated documentation files (the "Software"), to deal
    // in the Software without restriction, including without limitation the rights
    // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    // copies of the Software, and to permit persons to whom the Software is
    // furnished to do so, subject to the following conditions:
    // The above copyright notice and this permission notice shall be included in all
    // copies or substantial portions of the Software.
    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    // SOFTWARE.
    let seed = !customData.again.seed | !customData.hard.seed | !customData.good.seed | !customData.easy.seed ? document.getElementById("qa").innerText : customData.good.seed;
    const generator = new Math.seedrandom(seed);
    const fuzz_factor = generator();
    seed = Math.round(fuzz_factor * 10000);
    customData.again.seed = (seed + 1) % 10000;
    customData.hard.seed = (seed + 2) % 10000;
    customData.good.seed = (seed + 3) % 10000;
    customData.easy.seed = (seed + 4) % 10000;
    return fuzz_factor;
}
```

#### 5.2 QT5参数

```java
// FSRS4Anki v3.9.6 Scheduler Qt5
set_version();
// The latest version will be released on https://github.com/open-spaced-repetition/fsrs4anki

// Default parameters of FSRS4Anki for global
var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];
// The above parameters can be optimized via FSRS4Anki optimizer.

// User's custom parameters for global
let requestRetention = 0.9; // recommended setting: 0.8 ~ 0.9
let maximumInterval = 36500;
let easyBonus = 1.3;
let hardInterval = 1.2;
// FSRS only modifies the long-term scheduling. So (re)learning steps in deck options work as usual.
// I recommend not to set steps longer than one day.

// "Fuzz" is a small random delay applied to new intervals to prevent cards from
// sticking together and always coming up for review on the same day
const enable_fuzz = true;

debugger;

// get the name of the card's deck
// need to add <div id=deck deck_name="{{Deck}}"></div> to your card's front template's first line
if (document.getElementById("deck") !== null) {
  const deck_name = document.getElementById("deck").getAttribute("deck_name");
  // parameters for a specific deck
  if (deck_name == "ALL::Learning::English::Reading") {
    var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];
    // User's custom parameters for the specific deck
    requestRetention = 0.9;
    maximumInterval = 36500;
    easyBonus = 1.3;
    hardInterval = 1.2;
    // parameters for a deck's all sub-decks
  } else if (deck_name.startsWith("ALL::Archive")) {
    var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];
    // User's custom parameters for sub-decks
    requestRetention = 0.9;
    maximumInterval = 36500;
    easyBonus = 1.3;
    hardInterval = 1.2;
  }
}

// auto-calculate intervalModifier
const intervalModifier = Math.log(requestRetention) / Math.log(0.9);
// global fuzz factor for all ratings.
const fuzz_factor = set_fuzz_factor();
const ratings = {
  "again": 1,
  "hard": 2,
  "good": 3,
  "easy": 4
};

// For new cards
if (is_new()) {
  var _states$good$normal, _states$easy$normal;
  init_states();
  const good_interval = next_interval(customData.good.s);
  const easy_interval = Math.max(next_interval(customData.easy.s * easyBonus), good_interval + 1);
  if ((_states$good$normal = states.good.normal) !== null && _states$good$normal !== void 0 && _states$good$normal.review) {
    states.good.normal.review.scheduledDays = good_interval;
  }
  if ((_states$easy$normal = states.easy.normal) !== null && _states$easy$normal !== void 0 && _states$easy$normal.review) {
    states.easy.normal.review.scheduledDays = easy_interval;
  }
  // For learning/relearning cards
} else if (is_learning()) {
  var _states$good$normal2, _states$easy$normal2;
  // Init states if the card didn't contain customData
  if (is_empty()) {
    init_states();
  }
  const good_interval = next_interval(customData.good.s);
  const easy_interval = Math.max(next_interval(customData.easy.s * easyBonus), good_interval + 1);
  if ((_states$good$normal2 = states.good.normal) !== null && _states$good$normal2 !== void 0 && _states$good$normal2.review) {
    states.good.normal.review.scheduledDays = good_interval;
  }
  if ((_states$easy$normal2 = states.easy.normal) !== null && _states$easy$normal2 !== void 0 && _states$easy$normal2.review) {
    states.easy.normal.review.scheduledDays = easy_interval;
  }
  // For review cards
} else if (is_review()) {
  var _states$current$norma, _states$again$normal, _states$hard$normal, _states$good$normal3, _states$easy$normal3;
  // Convert the interval and factor to stability and difficulty if the card didn't contain customData
  if (is_empty()) {
    convert_states();
  }
  const interval = (_states$current$norma = states.current.normal) !== null && _states$current$norma !== void 0 && _states$current$norma.review.elapsedDays ? states.current.normal.review.elapsedDays : states.current.filtered.rescheduling.originalState.review.elapsedDays;
  const last_d = customData.again.d;
  const last_s = customData.again.s;
  const retrievability = Math.exp(Math.log(0.9) * interval / last_s);
  const lapses = (_states$again$normal = states.again.normal) !== null && _states$again$normal !== void 0 && _states$again$normal.relearning.review.lapses ? states.again.normal.relearning.review.lapses : states.again.filtered.rescheduling.originalState.relearning.review.lapses;
  customData.again.d = next_difficulty(last_d, "again");
  customData.again.s = next_forget_stability(customData.again.d, last_s, retrievability);
  customData.hard.d = next_difficulty(last_d, "hard");
  customData.hard.s = next_recall_stability(customData.hard.d, last_s, retrievability);
  customData.good.d = next_difficulty(last_d, "good");
  customData.good.s = next_recall_stability(customData.good.d, last_s, retrievability);
  customData.easy.d = next_difficulty(last_d, "easy");
  customData.easy.s = next_recall_stability(customData.easy.d, last_s, retrievability);
  let hard_interval = next_interval(last_s * hardInterval);
  let good_interval = next_interval(customData.good.s);
  let easy_interval = next_interval(customData.easy.s * easyBonus);
  hard_interval = Math.min(hard_interval, good_interval);
  good_interval = Math.max(good_interval, hard_interval + 1);
  easy_interval = Math.max(easy_interval, good_interval + 1);
  if ((_states$hard$normal = states.hard.normal) !== null && _states$hard$normal !== void 0 && _states$hard$normal.review) {
    states.hard.normal.review.scheduledDays = hard_interval;
  }
  if ((_states$good$normal3 = states.good.normal) !== null && _states$good$normal3 !== void 0 && _states$good$normal3.review) {
    states.good.normal.review.scheduledDays = good_interval;
  }
  if ((_states$easy$normal3 = states.easy.normal) !== null && _states$easy$normal3 !== void 0 && _states$easy$normal3.review) {
    states.easy.normal.review.scheduledDays = easy_interval;
  }
}
function constrain_difficulty(difficulty) {
  return Math.min(Math.max(difficulty.toFixed(2), 1), 10);
}
function apply_fuzz(ivl) {
  if (!enable_fuzz || ivl < 2.5) return ivl;
  ivl = Math.round(ivl);
  const min_ivl = Math.max(2, Math.round(ivl * 0.95 - 1));
  const max_ivl = Math.round(ivl * 1.05 + 1);
  return Math.floor(fuzz_factor * (max_ivl - min_ivl + 1) + min_ivl);
}
function next_interval(stability) {
  const new_interval = apply_fuzz(stability * intervalModifier);
  return Math.min(Math.max(Math.round(new_interval), 1), maximumInterval);
}
function next_difficulty(d, rating) {
  let next_d = d + w[4] * (ratings[rating] - 3);
  return constrain_difficulty(mean_reversion(w[2], next_d));
}
function mean_reversion(init, current) {
  return w[5] * init + (1 - w[5]) * current;
}
function next_recall_stability(d, s, r) {
  return +(s * (1 + Math.exp(w[6]) * (11 - d) * Math.pow(s, w[7]) * (Math.exp((1 - r) * w[8]) - 1))).toFixed(2);
}
function next_forget_stability(d, s, r) {
  return +(w[9] * Math.pow(d, w[10]) * Math.pow(s, w[11]) * Math.exp((1 - r) * w[12])).toFixed(2);
}
function init_states() {
  customData.again.d = init_difficulty("again");
  customData.again.s = init_stability("again");
  customData.hard.d = init_difficulty("hard");
  customData.hard.s = init_stability("hard");
  customData.good.d = init_difficulty("good");
  customData.good.s = init_stability("good");
  customData.easy.d = init_difficulty("easy");
  customData.easy.s = init_stability("easy");
}
function init_difficulty(rating) {
  return +constrain_difficulty(w[2] + w[3] * (ratings[rating] - 3)).toFixed(2);
}
function init_stability(rating) {
  return +Math.max(w[0] + w[1] * (ratings[rating] - 1), 0.1).toFixed(2);
}
function convert_states() {
  const scheduledDays = states.current.normal ? states.current.normal.review.scheduledDays : states.current.filtered.rescheduling.originalState.review.scheduledDays;
  const easeFactor = states.current.normal ? states.current.normal.review.easeFactor : states.current.filtered.rescheduling.originalState.review.easeFactor;
  const old_s = +Math.max(scheduledDays, 0.1).toFixed(2);
  const old_d = constrain_difficulty(11 - (easeFactor - 1) / (Math.exp(w[6]) * Math.pow(old_s, w[7]) * (Math.exp(0.1 * w[8]) - 1)));
  customData.again.d = old_d;
  customData.again.s = old_s;
  customData.hard.d = old_d;
  customData.hard.s = old_s;
  customData.good.d = old_d;
  customData.good.s = old_s;
  customData.easy.d = old_d;
  customData.easy.s = old_s;
}
function is_new() {
  var _states$current$norma2, _states$current$filte, _states$current$filte2;
  if (((_states$current$norma2 = states.current.normal) === null || _states$current$norma2 === void 0 ? void 0 : _states$current$norma2.new) !== undefined) {
    var _states$current$norma3;
    if (((_states$current$norma3 = states.current.normal) === null || _states$current$norma3 === void 0 ? void 0 : _states$current$norma3.new) !== null) {
      return true;
    }
  }
  if (((_states$current$filte = states.current.filtered) === null || _states$current$filte === void 0 ? void 0 : (_states$current$filte2 = _states$current$filte.rescheduling) === null || _states$current$filte2 === void 0 ? void 0 : _states$current$filte2.originalState) !== undefined) {
    var _states$current$filte3, _states$current$filte4;
    if ((_states$current$filte3 = states.current.filtered) !== null && _states$current$filte3 !== void 0 && (_states$current$filte4 = _states$current$filte3.rescheduling) !== null && _states$current$filte4 !== void 0 && _states$current$filte4.originalState.hasOwnProperty('new')) {
      return true;
    }
  }
  return false;
}
function is_learning() {
  var _states$current$norma4, _states$current$filte5, _states$current$filte6, _states$current$norma6, _states$current$filte9, _states$current$filte10;
  if (((_states$current$norma4 = states.current.normal) === null || _states$current$norma4 === void 0 ? void 0 : _states$current$norma4.learning) !== undefined) {
    var _states$current$norma5;
    if (((_states$current$norma5 = states.current.normal) === null || _states$current$norma5 === void 0 ? void 0 : _states$current$norma5.learning) !== null) {
      return true;
    }
  }
  if (((_states$current$filte5 = states.current.filtered) === null || _states$current$filte5 === void 0 ? void 0 : (_states$current$filte6 = _states$current$filte5.rescheduling) === null || _states$current$filte6 === void 0 ? void 0 : _states$current$filte6.originalState) !== undefined) {
    var _states$current$filte7, _states$current$filte8;
    if ((_states$current$filte7 = states.current.filtered) !== null && _states$current$filte7 !== void 0 && (_states$current$filte8 = _states$current$filte7.rescheduling) !== null && _states$current$filte8 !== void 0 && _states$current$filte8.originalState.hasOwnProperty('learning')) {
      return true;
    }
  }
  if (((_states$current$norma6 = states.current.normal) === null || _states$current$norma6 === void 0 ? void 0 : _states$current$norma6.relearning) !== undefined) {
    var _states$current$norma7;
    if (((_states$current$norma7 = states.current.normal) === null || _states$current$norma7 === void 0 ? void 0 : _states$current$norma7.relearning) !== null) {
      return true;
    }
  }
  if (((_states$current$filte9 = states.current.filtered) === null || _states$current$filte9 === void 0 ? void 0 : (_states$current$filte10 = _states$current$filte9.rescheduling) === null || _states$current$filte10 === void 0 ? void 0 : _states$current$filte10.originalState) !== undefined) {
    var _states$current$filte11, _states$current$filte12;
    if ((_states$current$filte11 = states.current.filtered) !== null && _states$current$filte11 !== void 0 && (_states$current$filte12 = _states$current$filte11.rescheduling) !== null && _states$current$filte12 !== void 0 && _states$current$filte12.originalState.hasOwnProperty('relearning')) {
      return true;
    }
  }
  return false;
}
function is_review() {
  var _states$current$norma8, _states$current$filte13, _states$current$filte14;
  if (((_states$current$norma8 = states.current.normal) === null || _states$current$norma8 === void 0 ? void 0 : _states$current$norma8.review) !== undefined) {
    var _states$current$norma9;
    if (((_states$current$norma9 = states.current.normal) === null || _states$current$norma9 === void 0 ? void 0 : _states$current$norma9.review) !== null) {
      return true;
    }
  }
  if (((_states$current$filte13 = states.current.filtered) === null || _states$current$filte13 === void 0 ? void 0 : (_states$current$filte14 = _states$current$filte13.rescheduling) === null || _states$current$filte14 === void 0 ? void 0 : _states$current$filte14.originalState) !== undefined) {
    var _states$current$filte15, _states$current$filte16;
    if ((_states$current$filte15 = states.current.filtered) !== null && _states$current$filte15 !== void 0 && (_states$current$filte16 = _states$current$filte15.rescheduling) !== null && _states$current$filte16 !== void 0 && _states$current$filte16.originalState.hasOwnProperty('review')) {
      return true;
    }
  }
  return false;
}
function is_empty() {
  return !customData.again.d | !customData.again.s | !customData.hard.d | !customData.hard.s | !customData.good.d | !customData.good.s | !customData.easy.d | !customData.easy.s;
}
function set_version() {
  const version = "3.9.6";
  customData.again.v = version;
  customData.hard.v = version;
  customData.good.v = version;
  customData.easy.v = version;
}
function set_fuzz_factor() {
    // Note: Originally copied from seedrandom.js package (https://github.com/davidbau/seedrandom)
    !function(f,a,c){var s,l=256,p="random",d=c.pow(l,6),g=c.pow(2,52),y=2*g,h=l-1;function n(n,t,r){function e(){for(var n=u.g(6),t=d,r=0;n<g;)n=(n+r)*l,t*=l,r=u.g(1);for(;y<=n;)n/=2,t/=2,r>>>=1;return(n+r)/t}var o=[],i=j(function n(t,r){var e,o=[],i=typeof t;if(r&&"object"==i)for(e in t)try{o.push(n(t[e],r-1))}catch(n){}return o.length?o:"string"==i?t:t+"\0"}((t=1==t?{entropy:!0}:t||{}).entropy?[n,S(a)]:null==n?function(){try{var n;return s&&(n=s.randomBytes)?n=n(l):(n=new Uint8Array(l),(f.crypto||f.msCrypto).getRandomValues(n)),S(n)}catch(n){var t=f.navigator,r=t&&t.plugins;return[+new Date,f,r,f.screen,S(a)]}}():n,3),o),u=new m(o);return e.int32=function(){return 0|u.g(4)},e.quick=function(){return u.g(4)/4294967296},e.double=e,j(S(u.S),a),(t.pass||r||function(n,t,r,e){return e&&(e.S&&v(e,u),n.state=function(){return v(u,{})}),r?(c[p]=n,t):n})(e,i,"global"in t?t.global:this==c,t.state)}function m(n){var t,r=n.length,u=this,e=0,o=u.i=u.j=0,i=u.S=[];for(r||(n=[r++]);e<l;)i[e]=e++;for(e=0;e<l;e++)i[e]=i[o=h&o+n[e%r]+(t=i[e])],i[o]=t;(u.g=function(n){for(var t,r=0,e=u.i,o=u.j,i=u.S;n--;)t=i[e=h&e+1],r=r*l+i[h&(i[e]=i[o=h&o+t])+(i[o]=t)];return u.i=e,u.j=o,r})(l)}function v(n,t){return t.i=n.i,t.j=n.j,t.S=n.S.slice(),t}function j(n,t){for(var r,e=n+"",o=0;o<e.length;)t[h&o]=h&(r^=19*t[h&o])+e.charCodeAt(o++);return S(t)}function S(n){return String.fromCharCode.apply(0,n)}if(j(c.random(),a),"object"==typeof module&&module.exports){module.exports=n;try{s=require("crypto")}catch(n){}}else"function"==typeof define&&define.amd?define(function(){return n}):c["seed"+p]=n}("undefined"!=typeof self?self:this,[],Math);
    // MIT License
    // Copyright 2019 David Bau.
    // Permission is hereby granted, free of charge, to any person obtaining a copy
    // of this software and associated documentation files (the "Software"), to deal
    // in the Software without restriction, including without limitation the rights
    // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    // copies of the Software, and to permit persons to whom the Software is
    // furnished to do so, subject to the following conditions:
    // The above copyright notice and this permission notice shall be included in all
    // copies or substantial portions of the Software.
    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    // SOFTWARE.
    let seed = !customData.again.seed | !customData.hard.seed | !customData.good.seed | !customData.easy.seed ? document.getElementById("qa").innerText : customData.good.seed;
    const generator = new Math.seedrandom(seed);
    const fuzz_factor = generator();
    seed = Math.round(fuzz_factor * 10000);
    customData.again.seed = (seed + 1) % 10000;
    customData.hard.seed = (seed + 2) % 10000;
    customData.good.seed = (seed + 3) % 10000;
    customData.easy.seed = (seed + 4) % 10000;
    return fuzz_factor;
}
```

