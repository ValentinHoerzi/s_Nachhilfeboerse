using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nachhilfeboerse
{
    class Student
    {
        public string Clazz { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Name => $"{Lastname} {Firstname}";
        public string ImagePath => $"Images/{Lastname}_{Firstname}.jpg";

        public List<Service> Services { get; set; }

        public static Student Parse(string line)
        {
            var splitLine = line.Split(';');
            var student = new Student();
            student.Clazz = splitLine[0];
            var splitName = splitLine[1].Split(' ');
            student.Lastname = splitName[0];
            student.Firstname = splitName[1];
            return student;
        }
    }
}
