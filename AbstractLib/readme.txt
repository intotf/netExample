抽象类的学习
	
	抽象类相对接口来说，可以自己去实现业务逻辑，而接口只做定义并约束继承者去实现；

	1、抽象类学习 WorkAbstract.cs
		1.1 抽象类跟普通类一样，但需要在前面加 abstract 修饰
		1.2 virtual 可由基类重写实现
		1.3 abstract 抽像方法只需要有方法名，由基类必需云实现
		1.4 基类有用抽象类中的任意方法
		1.5 override 子类重写基类方法
		1.6 sealed 密封类/方法，子类不可重写
		1.7 base 父类

	2、WorkParallel.cs 并行运行 Task任务
		2.1	Stopwatch	时间统计器
		2.2 Parallel.Invoke(task1, task2);	并行运行多线程,在明确任务内容或数据总数量大的时候，使用并行执行时间要短
		2.3 Interlocked.Add(ref cNum, n);	原子操作,保持在多线程中对原子只能单线程修改

	3、WorksTask.cs	多线程管理
		var t1 = new Task[1] { Task.Factory.StartNew(Run1) };
        Task.WaitAll(t1, 5000);	设置超时时间
		TaskStatus.RanToCompletion	线程完成状态

		