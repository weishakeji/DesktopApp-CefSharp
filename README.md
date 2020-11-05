# DesktopApp-CefSharp
# 网页“加壳”成桌面应用的小工具
> 这是一款基于Chromium内核的DotNET应用程序，方便将网页打包成桌面应用。其中CefSharp是DotNet编写的浏览器包，采用Chromium内核，可以在Winform和WPF中调用。

> 当前软件中的Chromium内核版本为63，并不是最新版，如果想采用最新内核，可以到Chrome官网下载。但<b>官网下载的Chromium内核不支持MP4播放</b>，需要手工加载H264相关代码，自行编译。

## 开发环境：
* 采用C#；基于.Net 4.5.2 Framework<a href="https://www.microsoft.com/en-us/download/details.aspx?id=42642" target="_blank" size=12>[下载]</a>
* 开发工具 Microsoft Visual Studio Community 2019

## 使用说明：
* 编译后可以执行的程序在\bin\Debug文件夹。
* 主程序是DesktopApp.exe
* 配置所用的程序是 Setup.exe，用于设置DesktopApp打开时的页面，或相关设置；当程序提供给客户时，可以把它删掉。
* Confing.xml文件记录Setup.exe的设置项。

## 开发说明：
* 解决方案中，共四个项目，一个文件夹Lib，lib中是需要引用的dll文件（不要用Nuget中的官方版本，如前所述，他们的不支持mp4播放）。
* 四个项目中，updater原来是写自动升级的，不过我没有写，可以忽略掉它。
* DesktopApp是主程序
* Setup是用来设置的相关参数的
* Confing是用来记录和还原参数的，如果是三层架构的话，它就是负责数据持久化的，加密解密都有了。

## 开源地址：
* GitHub ：<a href="https://github.com/weishakeji/DesktopApp-CefSharp" target="_blank">https://github.com/weishakeji/DesktopApp-CefSharp</a> 
* Gitee（同步镜像）： <a href="https://gitee.com/weishakeji/desktop-app-cef-sharp" target="_blank">https://gitee.com/weishakeji/desktop-app-cef-sharp</a> 


## 开发交流：
>QQ交流群：10237400

## 其它开源项目：
<b> 微厦在线学习云服务平台</b>
>“在线视频学习、在线试题练习、在线同步考试”紧密相联，打造“学、练、考”于一体的在线教育系统，能够利用电脑、手机、微信等多种设备进行学习，方便学员利用碎片化时间进行随时随地的学习。并带有“分享、分润、分销”的辅助功能，对于平台推广、课程销售起到非常有效的帮助。
### 学习系统的开源地址：
* GitHub ：<a href="https://github.com/weishakeji/LearningSystem" target="_blank">https://github.com/weishakeji/LearningSystem</a> 
* Gitee（同步镜像）： <a href="https://gitee.com/weishakeji/LearningSystem" target="_blank">https://gitee.com/weishakeji/LearningSystem</a> 