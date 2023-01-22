---
layout: post
title: 机器学习优化anki复习调度参数(15)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

这里要推荐的一个插件是`FSRS4Anki Helper`。插件的地址：[https://ankiweb.net/shared/info/759844606](https://ankiweb.net/shared/info/759844606)，这个插件的安装码是：759844606。插件需要anki 2.1.55版本以上。该插件**仅能支持电脑端Anki**。更多细节，请看插件作者在知乎的教程：[https://zhuanlan.zhihu.com/p/591833332](https://zhuanlan.zhihu.com/p/591833332)，该插件作者，曾经用anki复习高考知识，提升考分100多分。使用这个调度算法的好处是，卡片间隔会拉长，在同样的记忆效果下，它能够帮助你节约13%的复习时间。

![chrome_Drmqkx3KnQ](/images/posts/chrome_Drmqkx3KnQ.png)

### 1.FSRS4Anki Helper

这个插件的作者是国内的某个计算机大学毕业的算法学生搞出来的一个基于人工智能机器学习的插件，目的是为了优化我们的复习参数。因为anki的复习参数太多了(如下图所示)，Anki新手很容易搞错这些参数，也不知道怎么设置这些参数。我比较推荐使用的就是这个插件，你不用去思考如何设置这些参数，它通过机器学习，python在线训练，得到一个比较优化的参数给到你，这样子，参数问题就变得傻瓜化。而且这个参数是量身定制的，针对每个人的卡片数据，做出的不同的最优解。

![123kzmsdjIUs@](/images/posts/123kzmsdjIUs@.gif)

这个插件的目的就是给每个人的卡片复习进度，进行数据优化，生成针对每个人的定制化的复习参数。这样子我们就不用担心anki参数设置问题了。专业的事情交给专业的人，由机器学习和AI帮你全部搞定。

### 2.插件安装和使用

首先是安装这个插件，我这里是在windows10 Pro 系统，英文界面上面演示。安装的anki是2.1.56版本 QT6版本的。注意，我这里用的是QT6而不是QT5版本，建议你电脑上面的anki也用官方最新的QT6对应的版本。官方地址：[https://apps.ankiweb.net/](https://apps.ankiweb.net/)，旧版本用新版本覆盖安装即可，覆盖安装不会破坏原有的anki配置。

![oegy1DEjYC](/images/posts/oegy1DEjYC.png)

#### 2.1 安装插件

然后是安装插件，安装码是：759844606。直接到anki的add-ons菜单，`Get Add-ons...`里面填入这个Code码安装这个插件即可。安装完毕，就能看到这个插件了:

![anki_EveEKoynm3](/images/posts/anki_EveEKoynm3.png)

#### 2.2 准备工作

这个插件的使用方法，在Github有详细解释：[https://github.com/open-spaced-repetition/fsrs4anki](https://github.com/open-spaced-repetition/fsrs4anki)，它有2个js文件，默认情况下，我们可以直接复制粘贴它里面的js脚本粘贴到我们的anki中，类似下面这样子，点击保存就设置好了，js脚本是粘贴到Custom scheduling这个框里面，它的js脚本分为QT5版本和QT6版本。我这里使用的是QT6版本的脚本。只需要粘贴这个脚本到我们的anki这个Custom scheduling里面，就配置完了。这个只是笼统的说是这样子的，但实际上，我们要生成我们自己的参数，还需要导出我们自己的所有anki卡片，去拿这个工具去训练出我们自己的参数，替换掉这个脚本里面默认的参数才行。下面我们直接讲怎么操作。

![anki_rH3PioEUnz](/images/posts/anki_rH3PioEUnz.png)





#### 2.3 下载FSRS4Anki Helper源码

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

![chrome_KVmSaKhtIa](/images/posts/chrome_KVmSaKhtIa.png)

如下所示，我们修改脚本里面的文本信息，filename改为我们的文件名`collection-2023-01-22@01-37-19.colpkg`，如下图所示：

![U6XMbu7HcK](/images/posts/U6XMbu7HcK.png)

修改之后，脚本会被自动保存。下面可以执行这个脚本了，脚本执行完毕，我们就能得到优化之后的参数。怎么执行脚本呢？回到顶部菜单位置，点击`RunTime`，`Run all`，弹出来一个警告提示框，

![y9sQMZrSIM](/images/posts/y9sQMZrSIM.png)

选择Run anyway，忽略警告信息，执行脚本：

![LbAc7AAyAP](/images/posts/LbAc7AAyAP.png)

脚本开始执行，如下图所示：这个执行过程非常慢，大概需要25分钟左右，看你的卡片数量而定...

![1234kjdd34535355dfgdgds7g](/images/posts/1234kjdd34535355dfgdgds7g.gif)

等待脚本慢慢执行，它正在根据我们自己导出来的anki卡片数据进行机器学习运算，最终会计算出一个最优化的参数。我们之后要拿到这个结果参数，去替换掉js脚本中的参数，粘贴到我们自己的anki中去。这个参数，最好是保存到一个word文档或者txt里面，下次如果丢失了，能够找到这个参数，就不需要每次进行这么久的时间去在线运算这些数据了。

线上这个方式，耗时会比较久,等待结果的过程中我们可以看看它整个运行过程。

机器学习训练过程中，我们可以鼠标滚轮往下滑动脚本页面查看程序运行的每一个环节:

![chrome_J7xjDTUqcS](/images/posts/chrome_J7xjDTUqcS.png)

![chrome_85DAn2UtUI](/images/posts/chrome_85DAn2UtUI.png)

脚本从上到下执行，分好几个环节依次执行，每个小环节有数字序号，我们要拿的结果，在第3个小节，Result这里，如下图。等脚本全部执行完，我们需要向下拖动浏览器滚动条，找到第3小节，Result那个位置去拿结果。脚本还没有跑完之前，这里是不会有结果的。耐心等待。

![Typora_clhUMOkCkP](/images/posts/Typora_clhUMOkCkP.png)

#### 2.6 得到结果

最终，我们拖动浏览滚动条，如下位置，这里会显示最终的结果。下面空白处，输出了` var w = ......`字样：

![5wS6V65aI7](/images/posts/5wS6V65aI7.png)

拿到最终的结果如下：

```shell
var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];
```



#### 2.7 替换脚本

回到脚本这里，我们找到文件`fsrs4anki_scheduler.js`，使用编辑器打开，这里推荐使用Notepad++打开。

![UTQ9DGXpdc](/images/posts/UTQ9DGXpdc.png)

在线生成的参数是根据我自己anki的所有卡片数据生成的，如下：

`var w = [2.2387, 2.3408, 5.294, -0.2247, -1.2567, 0.0472, 1.6229, -0.1875, 1.0231, 2.08, -0.1119, 0.6164, 1.8446];`

用这个生成出来的参数，替换脚本中的这3行：

![MSSS14QKVN](/images/posts/MSSS14QKVN.png)

替换之后，整个复制这个脚本内容，粘贴到我们的anki中去：

1.把`V3 Scheduler`勾选上； 2.去Deck的设置中，粘贴这个参数到`Custom Scheduling`中，3.`Reschedul all cards`重置所有卡片的schedule。这样子就完成了新参数的设置和优化了。

![12666776werfgdgds7g](/images/posts/12666776werfgdgds7g.gif)

### 3. 脚本版本的区别

打开anki菜单中的About页面，查看你的anki的版本是QT6还是QT5, 不同的版本，使用不同的脚本：

![anki_AO9WtfogJp](/images/posts/anki_AO9WtfogJp.png)



![Rb5pgVl0mn](/images/posts/Rb5pgVl0mn.png)

如果版本是QT6则使用`fsrs4anki_scheduler.js`， 如果是QT5则使用`fsrs4anki_scheduler_qt5.js`。

目前这个脚本，好像只能支持`QT6版本，电脑端Anki`。

### 4.我的脚本参数

我的脚本参数，如下：

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

