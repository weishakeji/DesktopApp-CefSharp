(function () {
    var deskapp = {
        //是否处在deskapp中
        isexist: function () {
            var ua = navigator.userAgent;
            return ua.match(/DeskApp\(.[^\)]*\)/i) ? true : false;
        },
        window: {
            max: function () { deskapp_eventtrigger("window_max"); },			//窗体最大化，但不是全屏
            min: function () { deskapp_eventtrigger("window_min"); },			//窗体最小化到任务栏
            normal: function () { deskapp_eventtrigger("window_normal"); },		//当窗体是全屏或最大化时，还原到默认窗体
            full: function () { deskapp_eventtrigger("window_full"); },			//设置全屏，没有窗体栏，隐藏任务条
            toggle: function () { deskapp_eventtrigger("window_toggle"); },		//全屏与默认窗体的切换
            center: function () { deskapp_eventtrigger("window_center"); },		//设置窗体处于屏幕中央
			focus: function () { deskapp_eventtrigger("window_focus"); },	//窗体获取焦点，并处于最顶层
			blur: function () { deskapp_eventtrigger("window_blur"); },		//失去焦点
            close: function () { deskapp_eventtrigger("window_close"); },	//关闭当前窗体
			exit: function () { deskapp_eventtrigger("window_exit"); },		//关闭窗体，并退出应用
            size: function (width, height) {
                deskapp_eventtrigger("window_size", width, height);
            },
            event: function (eventName) { deskapp_eventtrigger(eventName); }
        },
        //弹出消息
        alert: function (msg) {
            deskapp_eventtrigger("message", msg);
        },
		//退出桌面应用
		exit:function(){deskapp.window.exit();},
        //当前电脑机器
        mechcode: function () {
            if (!deskapp.isexist()) return "";
            var ua = navigator.userAgent;
            var x = String(ua.match(/DeskApp\(.[^\)]*\)/i));
            var m = x.match(/\((.[^\)]*)\)/i);
            return m[1];
        }
    };
    //事件触发方法
    var deskapp_eventtrigger = function (eventName, parameter) {
        if (!deskapp.isexist()) {
            window.alert("当前窗体没有处于桌面应用中，无法响应该事件");
            return;
        }
        if (arguments.length <= 0) return;
        var title = new Date().getTime() + "@" + eventName;
        if (arguments.length > 1) {
            title += ":";
            for (var i = 1; i < arguments.length; i++) {
                title += arguments[i];
                if (i < arguments.length - 1) title += ",";
            }
        }
        document.title = title;
    }
    //禁止右键与文本选取
    if (deskapp.isexist()) {
        //document.oncontextmenu = new Function('event.returnValue=false;');
        //document.onselectstart = new Function('event.returnValue=false;');
    }
    //赋为全局变量
    window.deskapp = deskapp;
})();

