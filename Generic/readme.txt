泛型委托学习

	1. delegate 委托两种方式
		1.1 带返回值的如： Fun<string,int> 
			自写委托 public delegate int funDelegate(string str, out int newstr);
		1.2 不带返回值的 Action<int>
			自写委托 public delegate void actDelegate(int t);

	2. WorkGeneric.cs	泛型委托，协变、逆变
			泛型就是在不定义参数类型如 T，由使用者去自定义，泛型可作与类，接口，方法

			为了解决泛型父子类 关系的实例进行转换
			协变，逆变;只能放在接口或者委托的泛型参数前面
			协变：out 
				只以做为返回值
				左边是父，右边是子
			逆变：in 
				只可以做为参数值
				左边是子，右边是父