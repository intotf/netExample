该项目主要对一些临散内容进行学习并做好相应 Demo

1、ConcurrentDictionaryHelp.cs	线程安全字典学习
	用于多线程开发缓存，只要进程不重启字典内容会一起存在；
	对字典内容进行常规 添加、删除、编辑 三种操作；


2、TimeSpanHelp.cs	定时器学习
	System.Timers.Timer、System.Threading.Timer这两个平时用的时候没有发现太大的区别，定时的精度都差不多。

	2.1 System.Timers.Timer是基于服务的一个简单的轻量计时器；(推荐使用)
		new Timer((state) =>
        {
            执行内容
        }, null, TimeSpan(延迟的时间量), TimeSpan(时间间隔))
	2.2 CancellationTokenSource.Token.Register 基与 Timer 的定时器更简单；
	
	2.3 System.Timers.Timer是基于服务的定时器
		 imer.Interval = 3000;		 //定时间隔
         timer.Enabled = true;       //是否启用
         timer.AutoReset = true;     //是否启用事件
         timer.Elapsed += timer_Elapsed;	//触发事件

3、StructLib.cs 结构体概念学习
	 结构体(一种值类型)
     3.1 结构体就是一个可以包含不同数据类型的一个结构.它是一种可以自己定义的数据类型.
     3.2 结构体可以在一个结构中声明不同的数据类型.
     3.3 相同结构的结构体变量是可以相互赋值的.
     3.4 节省内存空间
     3.5 结构式值类型，其值存储在堆栈上，空间上浪费些(如果有多个实例). 效率比较好。
     3.6 结构可以指定内存的layout.
     注：结构体一般使用在简单对象如：Int32，而不是偏向于"面向对象"，通常使用 class 就好了