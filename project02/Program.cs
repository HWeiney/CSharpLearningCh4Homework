using System;
using project02;
// 定义一个学生类，定义一个班级类，实现班级类按索引方式访问改班级所有学生
namespace project01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("20软一 202100838\n");
            StuClass class01 = new StuClass(3);

            // 创建学生
            Student student01 = new Student("202100838", "Weiney");
            Student student02 = new Student("202100800", "Weizhi");
            Student student03 = new Student("202100899", "Weitian");

            // 在班级添加学生
            class01[0] = student01;
            class01[1] = student02;
            class01[2] = student03;

            // 按索引检索
            Console.Write("请输入要查找的索引值：");
            int index = int.Parse(Console.ReadLine());
            Student objStu01 = class01[index];
            Console.WriteLine(objStu01.printStudentInfo()+"\n");

            // 按学号检索
            Console.Write("请输入要查找的学号：");
            String sno = Console.ReadLine();
            Student objStu02 = class01[sno];
            Console.WriteLine("该学生的姓名：" + objStu02.getSname());

            Console.ReadLine();
        }
    }
}