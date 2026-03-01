using NUnit.Framework;
using Annualbonus;   // ? Reference to your main project namespace
using System;

namespace TestProject1
{
    public class EmployeeBonusTests
    {
        [Test]
        public void TestCase1_NormalHighPerformer()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 500000,
                PerformanceRating = 5,
                YearofExperience = 6,
                DepartmentMultiplier = 1.1m,
                AttendancePercentage = 95
            };
            Assert.AreEqual(123200.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void TestCase2_AttendancePenalty()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 400000,
                PerformanceRating = 4,
                YearofExperience = 8,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 80
            };
            Assert.AreEqual(60480.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void TestCase3_CapTriggered()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 1000000,
                PerformanceRating = 5,
                YearofExperience = 15,
                DepartmentMultiplier = 1.5m,
                AttendancePercentage = 95
            };
            Assert.AreEqual(280000.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void TestCase4_ZeroSalary()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 0,
                PerformanceRating = 5,
                YearofExperience = 10,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 100
            };
            Assert.AreEqual(0.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void TestCase5_LowPerformer()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 300000,
                PerformanceRating = 2,
                YearofExperience = 3,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 90
            };
            Assert.AreEqual(13500.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void TestCase6_Exact150kBoundary()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 600000,
                PerformanceRating = 3,
                YearofExperience = 0,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 100
            };
            Assert.AreEqual(64800.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void TestCase7_HighTaxSlab()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 900000,
                PerformanceRating = 5,
                YearofExperience = 11,
                DepartmentMultiplier = 1.2m,
                AttendancePercentage = 100
            };
            Assert.AreEqual(226800.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void TestCase8_RoundingPrecision()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 555555,
                PerformanceRating = 4,
                YearofExperience = 6,
                DepartmentMultiplier = 1.13m,
                AttendancePercentage = 92
            };
            Assert.AreEqual(118649.88m, emp.NetAnnualBonus);
        }

        [Test]
        public void TestCase_InvalidRating()
        {
            var emp = new EmployeeBonus
            {
                BaseSalary = 500000,
                PerformanceRating = 6, // Invalid
                YearofExperience = 5,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 90
            };
            Assert.Throws<InvalidOperationException>(() => { var bonus = emp.NetAnnualBonus; });
        }
    }
}