特性学习
    
    1.必需继承 System.Attribute

    2. 特性可以应用的目标元素约束包括：
        程序集(assemby)、类(Class)、模块(module)、类型(Type)、
        属性(Property)、事件(Event)、字段(Field)、方法(Method)、
        参数(param)、返回值(return).
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,Inherited = true)]

    3. AllowMultiple 是否可以应用多次

    4. Inherited    是否可以被继承


    System 提交的特性集合：https://msdn.microsoft.com/zh-cn/library/system.attribute(v=vs.110).aspx
    