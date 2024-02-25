using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SOLID.Principles
{
    // Following the Dependency Inversion Principle
    public interface ISalaryCalculator
    {
        float CalculateSalary(int hoursWorked, float hourlyRate);
    }
    public class SalaryCalculatorModified : ISalaryCalculator
    {
        public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
    }
    public class EmployeeDetails
    {
        private readonly ISalaryCalculator _salaryCalculator;

        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }
        public EmployeeDetails(ISalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
        }
        public float GetSalary()
        {
            return _salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
        }
    }

    //In the above code, we see that we have created an interface ISalaryCalculator, and then we have a class called SalaryCalculator that implements this interface.
    //Finally, in the higher-level class EmployeeDetailsModified, we only depend upon the ISalaryCalculator interface and not the concrete class.
    //Hence, when we create the EmployeeDetailsModified class, we specify the abstraction implementation to use.
    //In addition to this, the details of the CalculateSalary function are hidden from the EmployeeDetailsModified class,
    //and any changes to this function will not affect the interface being used.Hence, we can see that in this new design,
    //the higher-level class does not depend upon the lower-level class but on an abstraction,
    //and the abstraction does not depend upon the details.

    //To create the EmployeeDetails class, we use the below code.
    public class DIP
    {
        public void DIPMethod()
        {
            var employeeDetailsModified = new EmployeeDetails(new SalaryCalculatorModified());
            employeeDetailsModified.HourlyRate = 50;
            employeeDetailsModified.HoursWorked = 150;
            Console.WriteLine($"The Total Pay is {employeeDetailsModified.GetSalary()}");
        }
    }
}
