using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Reflection
{
    class Program
    {
        [Serializable]
        class Test
        {
            public string Subject { get; set; }
            public int SMark { get; set; }

            public Test()
            {
                SMark = 0;
            }

            public Test(string s, int n)
            {
                Subject = s;
                SMark = n;
            }
            public int TestMethod(int n)
            {
                return n + 10;
            }
        }

        class Student
        {
            public string FullName { set; get; }
            public int[] Marks { set; get; }

            public Student()
            {
                Marks = new int[5];
            }

            public Student(int n)
            {
                Marks = new int[n];
            }

            public void GetAvgMark(out double avgMark)
            {
                avgMark = 0.0;
                for (int i = 0; i < Marks.Length; i++)
                    avgMark += Marks[i];
                avgMark = avgMark / Marks.Length;
            }
        }

        static void Main(string[] args)
        {
            TypeInfo info = new TypeInfo(typeof(Test));
            info.ShowTypeInfo();
            TypeInfo studInfo = new TypeInfo(typeof(Student));
            studInfo.ShowTypeInfo();
            Console.ReadLine();
        }
    }
}
