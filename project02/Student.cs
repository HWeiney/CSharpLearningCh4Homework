using System;
using System.Collections.Generic;
using System.Text;

namespace project02
{
    class Student
    {
        private String sno;
        private String sname;

        public Student(String sno,String sname)
        {
            this.sno = sno;
            this.sname = sname;
        }

        public String printStudentInfo()
        {
            String info = "学号为“" + sno + "”的学生姓名是“" + sname + ".";
            return info;
        }

        public void setSno(String sno)
        {
            this.sno = sno;
        }

        public String getSno()
        {
            return this.sno;
        }

        public void setSname(String sname)
        {
            this.sname = sname;
        }

        public String getSname()
        {
            return this.sname;
        }
    }
}
