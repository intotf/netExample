一、多线程异步操作

	用于已经明确了需要处理的数据集合，使用指定线程数进行异步单条处理；

	1、使用到  Interlocked.Increment(ref current); 原子操作记数；

	2、System.Threading.SemaphoreSlim 类的新实例，同时指定可同时授予的请求的初始数量和最大数量。
