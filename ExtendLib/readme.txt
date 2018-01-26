扩展,是对任意类型扩展新的方法；
	注：在VS编辑器中，看到一个方法前面的图标有向下箭头就是 扩展出来的方法

	1、创建的类必需为 公开的静态类 public static class

	2、类中的方法也必需为公开的静态方法

	3、方法中第一个参数必需包含 this 如：public static string GetDisplayDescription(this Enum e)