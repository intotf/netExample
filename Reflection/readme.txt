反射学习

	1、见用实体对象反射
		1.1 获取对象的所有属性：GetProperties
		1.2 获取对象中的所有方法：GetMethods
		1.3 获取对象任意属性的值：Func<T, TKey> field

	2、高级类反射
		2.1 反射筛选出  指定抽象类的所有继承者包括子类；( IsSubclassOf )
		2.2 反射筛选出  指定接口的所有继承者；	(Type.GetInterfaces().Contains(typeof(IWork)))
		2.3 反射筛选出  应用了指定特性的非抽象类；（IsDefined）
		2.4 反射筛选出	应用指定特性的特性信息；( GetCustomAttributes )
		2.5 创建对象 Activator.CreateInstance(typeof(T),parameters) as T;如果构建对象需加参数，可在后面加相应的 parameters