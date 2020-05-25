using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientAngularCore
{
    public class ClassToTest : IVehicle
    {
        public int number { get; set; }
        public string MaxSpeed(string carname, int bhp)
        {
            switch (carname)
            {
                case "ferrari":
                    return "240";
                default:
                    return "100";
            }
        }

        public bool CheckNumberGreaterThan10()
        {
            return (number > 10);
        }
    }

    public interface IVehicle
    {
        public string MaxSpeed(string carname, int bhp);
        public bool CheckNumberGreaterThan10();
    }

    public interface IEmployee
    {
        public string JoinName(string fName, string lName);
    }

    public class Employee : IEmployee
    {
        public string JoinName(string fName, string lName)
        {
            return (fName + " " + lName);
        }
    }

    public class MainEmployee
    {
        private IEmployee _emp;
        public MainEmployee(IEmployee employee)
        {
            _emp = employee;
        }

        public string FullName(string fname, string lname)
        {
            return _emp.JoinName(fname, lname);
        }
    }
}
