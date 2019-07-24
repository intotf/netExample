
设置监控目录及目标目录，定时自动同步文件到目标目录：

	学习点：主要是通过文件有变化触发同步事件
		1、new FileSystemWatcher();  系统文件监控对象，可监控文件的任何变化，如时间、创建、属性被修改等；
		2、目录文件并行扫描：
			Directory.EnumerateFiles("D:\\test", "*.*", SearchOption.AllDirectories).AsParallel().ForAll(item =>
            {
                CopyToTarget(item);	//Copy 文件到目标目录
            });
		3、一个文件的创建会同时产生多个事件，文件流写入需要一个段时间，故需对文件同的操作需要延迟：
			使用 Timer  进行延迟操作；(具体延迟可跟据实际情况来,通过配置文件设置延迟)


配置文件 config.json 说明：
[
  {
    "SourcePath": "E:\\github\\netExample\\Tool\\FileSync\\test\\a\\",		//来源目录/监控目录
    "TargetPath": "E:\\github\\netExample\\Tool\\FileSync\\test\\b\\",		//目标目录
    "SyncOne": true,														//以 SourcePath 为准，程序启动的时候同步一次
    "FilterType": "*.*",													//需要同步的文件通配符 
    "IncludeSubdir": true,													//是否同步子目录
    "DelaySeconds": 3,														//文件同步延迟单位秒
    "IsAyncDelete": true													//SourcePath 文件删除是否同步
  }
]

通配符学习
 * 零个或多个字符
 ? 正好一个字符

新建*,		文件名前两个字符为 新媒，不限长度
*.???		文件后缀必需为 三位长度的
*.rtf		指定文件后缀
*Microsoft*.*		必需包含 Microsoft 字符的文件且需要带 .