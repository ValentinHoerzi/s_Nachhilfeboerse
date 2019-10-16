using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nachhilfeboerse
{
    class Service
    {

        public int Level { get; set; }
        public static int[] Levels { get; }

        public string Subject { get; set; }

        public static List<string> Subjects { get; }


        static Service(){
            Levels = new int[] { 1, 2, 3, 4, 5 };
            var subjects = File.ReadLines("subjects.csv").ToArray()[0].Split(';');
            Subjects = new List<string>();
            foreach(var s in subjects)
            {
                Subjects.Add(s);
            }
        }

        public override string ToString()
        {
            return $"{Subject} in {Level}. Klasse";
        }
    }
}
