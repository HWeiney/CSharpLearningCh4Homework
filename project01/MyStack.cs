using System;
using System.Collections.Generic;
using System.Text;

namespace project01
{
    class MyStack<T>
    {
        public T[] Items;
        private int capacity;
        private int top;

        public MyStack(int i) 
        {
            this.capacity = i;
        }

        public void InitStack()
        {
            this.Items = new T[capacity];
            top = 0;
        }

        public void ClearStack()
        {
            this.Items = new T[0];
        }

        public bool push(T item)
        {
            if(Items.Length != top)
            {
                Items[top++] = item;
                return true;
            }
            return false;
        }

        public T pop()
        {
            top = top - 1;
            if(top == -1)
            {
                throw new Exception("栈已为空");
            }
            return Items[top];
        }
    }
}
