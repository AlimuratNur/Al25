

using System;
using System.Collections.Generic;

namespace Al25.Models.Decanat
{
    internal class Student
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public double Rating { get; set; }

    }

    internal class Group
    {
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }


    }
}
