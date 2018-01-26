System.IO 方面的学习及序列化学习

	1、FileHelp.cs 文件操作,流及二进制学习
		对文件的读写，编辑，删除,流处理；
		1.1 C# 常用三大流：文件流 FileStream; 内存流 MemoryStream; 网络流 NetworkStream
		1.2 流转为二进制, byte[] bytes = new byte[stream.Length];  stream.Write(bytes, 0, bytes.Length);
		1.3 二进制 转 string Encoding.Default.GetString
		1.4 文件的基本操作;  StringBuilder 的使用.

	2、DirectoryHelp.cs	目录/磁盘操作学习
		文件夹的创建删除，磁盘信息查看，一些小知识学习；
		2.1 获取所有子目录 Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);	
		2.2	获取目录下所有文件 new DirectoryInfo(path).EnumerateFiles(searchPattern, SearchOption.AllDirectories);

	3、JsonSerializer.cs Json 序列化及反序列化
		封装Newtonsoft.Json 的序列化及反序列化

	4、ImageHelper.cs	网络下载，对图片文件进行处理
		包含一些常用的如：缩略图，水印，翻转、反色等....