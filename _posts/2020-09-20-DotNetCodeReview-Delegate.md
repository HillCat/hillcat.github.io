---

layout: post
title: Delegate解耦代码逻辑
categories: .net
description: 使用委托来解耦代码
keywords: dotnet
typora-root-url: ../
---

Delegate对于解耦代码有很多地方使用到。最常见的用法，就是把Library类库和上层调用者进行解耦。

<img src="https://cs-cn.top/images/posts/Library_UI_decouple5208.png"/>

### 类库和模块之间解耦

比如我们封装了一段逻辑，是用来计算商品折扣的，这段逻辑被写在了公共类库Libray里面，硬编码的，但是如果哪一天需求发生了变化，需要对这部分的逻辑进行调整。而这个类库有可能被很多模块都引用了，直接修改这个地方的硬编码逻辑，会影响到其他调用这个类库的模块。所以，对于类库的封装，一般只是封装抽象的部分，具体的实现交给上层调用者自己处理，这样子就能实现解耦。可以考虑把上面这段计算商品折扣的硬编码，通过delegate，把这个方法抽离出去。

````c#
 public class ShoppingCartModel
    {
        public delegate void MentionDiscount(decimal subTotal);

        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
        
        public decimal GenerateTotal(MentionDiscount mentionSubtotal,
            Func<List<ProductModel>,decimal,decimal> calculateDiscountedTotal,
            Action<string> tellUserWeAreDiscounting)
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionSubtotal(subTotal);

            tellUserWeAreDiscounting("We are applying your discount.");

            decimal total = calculateDiscountedTotal(Items, subTotal);

            return total;
        }
    }
````



<img src="https://cs-cn.top/images/posts/couple1416.png"/>

通过委托，把具体的逻辑部分解耦到其他地方。这样子，其他模块对该类库的依赖，就变成了对抽象的依赖，而不是对具体硬编码的依赖。

上图中的项目，ConsoleUI层其实是依赖于DemoLibrary层的。而计算折扣的硬编码，通过委托的封装为抽象，而具体的硬编码直接交给ConsoleUI层去实现。这样子避免了WinFormUI层调用DemoLibrary层的时候受到影响。



<img src="https://cs-cn.top/images/posts/detegate430.png"/>

上面的代码，声明了一个委托，并且决定把红框内的代码移动到上层调用方。

<img src="https://cs-cn.top/images/posts/modify_code293.png"/>

