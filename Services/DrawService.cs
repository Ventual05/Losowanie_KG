﻿using System;
using System.Collections.Generic;
using System.Linq;
using DrawSystem.Models;

namespace DrawSystem.Services
{
    public class DrawService
    {
        private readonly Random _random;
        private int _luckyNumber;
        private HashSet<int> _absentStudents;

        public DrawService()
        {
            _random = new Random();
            _absentStudents = new HashSet<int>();
            GenerateLuckyNumber();
        }

        public Student DrawStudent(List<Student> students)
        {
            if (students == null || students.Count == 0)
            {
                return null;
            }

            var eligibleStudents = students.Where(s => !_absentStudents.Contains(s.Id)).ToList();

            if (eligibleStudents.Count == 0)
            {
                return null;
            }

            int index = _random.Next(0, eligibleStudents.Count);

            return eligibleStudents[index];
        }

        public int GetLuckyNumber()
        {
            return _luckyNumber;
        }

        private void GenerateLuckyNumber()
        {
            int maxId = CalculateMaxId();
            _luckyNumber = _random.Next(1, maxId + 1);
        }

        private int CalculateMaxId()
        {
            var fileServices = new FileServices();
            return fileServices.GetMaxStudentId();
        }
    }
}
