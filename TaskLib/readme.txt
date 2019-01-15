Task 进一步学习  20190110

	1、Task.Wait(TimeSpan);
		表示等待指定时间后退出阻塞过程

	2、高级类反射
		2.1 反射筛选出  指定抽象类的所有继承者包括子类；( IsSubclassOf )
		2.2 反射筛选出  指定接口的所有继承者；	(Type.GetInterfaces().Contains(typeof(IWork)))
		2.3 反射筛选出  应用了指定特性的非抽象类；（IsDefined）
		2.4 反射筛选出	应用指定特性的特性信息；( GetCustomAttributes )
		2.5 创建对象 Activator.CreateInstance(typeof(T),parameters) as T;如果构建对象需加参数，可在后面加相应的 parameters