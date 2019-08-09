### 隐式转换和显示转换

- #### 隐式转换

```
//implicit：表示隐式转换，如从 B -> A 只需直接赋值（A = B）
//此处将Immortal对象隐式转换为Monster对象
public static implicit operator Monster(Immortal value)
{
    return new Monster(value.name + "，变妖怪！");
}
```
- #### 显式转换
```
//explicti：表示显式转换，如从 A -> B 必须进行强制类型转换（B = (B)A）
//此处将Monster对象显示转换为Immortal对象
public static explicit operator Immortal(Monster value)
{
    return new Immortal(value.name + "，变神仙！");
}
```