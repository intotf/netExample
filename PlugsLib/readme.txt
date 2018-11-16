插件式开发：

	1、定义好插件功能接口  IPlug.cs
	2、对应的插件(PlugOne.cs\PlugTwo.cs)做好实现（或创建插件抽象类 PlugBase.cs，实现共用性）
	3、通过反射方式创建 实现了插件接口的 对象；( AcsPlug.cs )
	4、然后各自执行插件内容； (Program.cs)