主要对第三方库的学习积累

	1、WorkParallel.cs 并行运行 Task任务
		2.1	Stopwatch	时间统计器
		2.2 Parallel.Invoke(task1, task2);	并行运行多线程,在明确任务内容或数据总数量大的时候，使用并行执行时间要短
		2.3 Interlocked.Add(ref cNum, n);	原子操作,保持在多线程中对原子只能单线程修改

	2、WorksTask.cs	多线程管理
		var t1 = new Task[1] { Task.Factory.StartNew(Run1) };
        Task.WaitAll(t1, 5000);	设置超时时间
		TaskStatus.RanToCompletion	线程完成状态
