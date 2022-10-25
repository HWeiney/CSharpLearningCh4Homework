using System;
using System.Collections.Generic;
using System.Text;

namespace project02
{
    class StuClass
    {
        Student[] students;
        public StuClass(int capacity)
        {
            students = new Student[capacity];
        }
        public Student this[int index]
        {
            get
            {
                // 验证索引范围
                if (index < 0 || index > students.Length)
                {
                    Console.WriteLine("索引无效");
                    // 使用 null 指示失败
                    return null;
                }
                // 对于有效索引，返回请求的学生
                return students[index];
            }
            set
            {
                if (index < 0 || index >= students.Length)
                {
                    Console.WriteLine("索引无效");
                    return;
                }
                students[index] = value;
            }
        }
        //字符串索引器
        public Student this[string sno]
        {
            get
            {
                // 遍历数组中的所有照片
                foreach (Student stu in students)
                {
                    // 将照片中的标题与索引器参数进行比较
                    if (sno.Equals(stu.getSno()))
                        return stu;
                }
                Console.WriteLine("未找到");
                // 使用 null 指示失败
                return null;
            }
        }
    }
}
