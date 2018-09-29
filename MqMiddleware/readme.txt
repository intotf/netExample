C# 中间件开发实例

1.定义当前中间件的下一个键，根据中间件的插入序顺进行；

2.中间件可以将需要处理的数据一层层传递一下，如某一个中间件对数据修改过，下一个中间件收到的内容也会变化；

特点：
	1.可以将消息上下文传递给下一个中间件；
	2.每个中间件的业务处理完全独立；
	3.按顺序线性处理；


主要代码：

方法一：使用 List方式
	private readonly List<IMiddleware> ms = new List<IMiddleware>();

	ms.Add(middleware);
	ms.Aggregate((prev, next) =>
	{
		prev.Next = next;
		return next;
	}).Next = default(IMiddleware);



方法二：LinkedList 链式方法实现中间件

private readonly LinkedList<IMiddleware> middlewares = new LinkedList<IMiddleware>();

//在最后一个中间件后面插入一个中间件
this.middlewares.AddBefore(this.middlewares.Last, middleware);
var node = this.middlewares.First;
while (node.Next != null)
{
    node.Value.Next = node.Next.Value;
    node = node.Next;
}