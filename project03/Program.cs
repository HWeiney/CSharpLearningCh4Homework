using System;

namespace project03
{
    public delegate String GradePrint(Student s);
    public class Student
    {
        public GradePrint GP { set; get; }
        public String Sname { set; get; }
        public int G_Math { set; get; }
        public int G_Chinese { set; get; }
        public int G_English { set; get; }
        public Student(String Sname,int G_Math,int G_Chinese,int G_English)
        {
            this.Sname = Sname;
            this.G_Math = G_Math;
            this.G_Chinese = G_Chinese;
            this.G_English = G_English;
        } 
        public String toString()
        {
            return "学生姓名: " + Sname + "\n数学成绩: " + G_Math +
                "\n语文成绩: " + G_Chinese + "\n英语成绩: " + G_English;
        }
    }
    public class GradeReport
    {
        public static String GradeReportOrderByTerm(Student s)
        {
            return s.toString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("20软一 202100838\n" +
                "---------------静态方法完成委托---------------");
            Student stu1 = new Student("Weiney", 100, 98, 99);
            GradePrint gradePrint = GradeReport.GradeReportOrderByTerm;
            Console.WriteLine(gradePrint(stu1) + "\n" +
                "---------------实例方法完成委托---------------");
            GradeReport gradeReport = new GradeReport();
            stu1.GP += GradeReport.GradeReportOrderByTerm;
            Console.WriteLine(stu1.GP(stu1));
        }
    }
}
