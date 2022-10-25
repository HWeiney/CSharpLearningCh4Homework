using System;
/**
 自定义一个泛型类MyStack<T>，包括一个类指定泛型的数组属性，用于存储数据，并完成栈的基本操作操作。
（1）初始化一个栈：InitStack
（2）清空一个栈：ClearStack
（3）入栈，把一个元素加入到栈中：Push 
（4）出栈，并把栈顶元素给删除：Pop 
 */
namespace project01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("20软一 202100838\n请输入栈的大小：");
            int size = int.Parse(Console.ReadLine());
            MyStack<int> myStack = new MyStack<int>(size);
            myStack.InitStack();
            Console.WriteLine("请依次输入将要入栈数据");
            for(int i = 0; i < size; i++) // 测试入栈
            {
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("\t"+ x +"入栈状态为：" + myStack.push(x));
            }
            // 测试清空栈：
            // myStack.ClearStack();
            for(int i = 0; i < size; i++) // 测试出栈
            {
                Console.WriteLine("出栈数据：" + myStack.pop());
            }
        }
    }
}
