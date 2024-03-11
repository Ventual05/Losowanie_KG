using System;

namespace DrawSystem.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
        public bool IsPresent { get; set; } = true;
    }
}
