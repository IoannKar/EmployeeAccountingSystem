using System;
using System.Collections.Generic;

namespace EmployeeManagement
{
    class EmployeAccountingSystem
    {
        static void Main(string[] args)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            string command;

            do
            {
                Console.WriteLine("Доступные команды:");
                Console.WriteLine("1 - Добавить сотрудника");
                Console.WriteLine("2 - Обновить сотрудника");
                Console.WriteLine("3 - Получить информацию о сотруднике");
                Console.WriteLine("4 - Расчет зарплаты сотрудника");
                Console.WriteLine("exit - Выход");
                Console.Write("Введите команду: ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        employeeManager.AddEmployee();
                        break;
                    case "2":
                        employeeManager.UpdateEmployee();
                        break;
                    case "3":
                        employeeManager.GetEmployeeInfo();
                        break;
                    case "4":
                        employeeManager.CalculateSalary();
                        break;
                }

            } while (command != "exit");
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }
    }

    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();
        private int nextId = 1;

        public void AddEmployee()
        {
            Employee employee = new Employee();

            Console.Write("Введите имя сотрудника: ");
            employee.Name = Console.ReadLine();
            Console.Write("Введите почасовую ставку: ");
            employee.HourlyRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите количество отработанных часов: ");
            employee.HoursWorked = Convert.ToDouble(Console.ReadLine());

            employee.Id = nextId++;
            employees.Add(employee);

            Console.WriteLine("Сотрудник добавлен с ID: " + employee.Id);
        }

        public void UpdateEmployee()
        {
            Console.Write("Введите ID сотрудника для обновления: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = employees.Find(emp => emp.Id == id);

            if (employee != null)
            {
                Console.Write("Введите новое имя (оставьте пустым, чтобы не менять): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    employee.Name = name;
                }
                Console.Write("Введите новую почасовую ставку (оставьте пустым, чтобы не менять): ");
                string hourlyRateInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(hourlyRateInput))
                {
                    employee.HourlyRate = Convert.ToDouble(hourlyRateInput);
                }
                Console.Write("Введите новое количество отработанных часов (оставьте пустым, чтобы не менять): ");
                string hoursWorkedInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(hoursWorkedInput))
                {
                    employee.HoursWorked = Convert.ToDouble(hoursWorkedInput);
                }

                Console.WriteLine("Сотрудник с ID " + id + " обновлен.");
            }
            else
            {
                Console.WriteLine("Сотрудник не найден.");
            }
        }
        public void GetEmployeeInfo()
        {
            Console.Write("Введите ID сотрудника для просмотра информации: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = employees.Find(emp => emp.Id == id);

            if (employee != null)
            {
                Console.WriteLine($"ID: {employee.Id}, Имя: {employee.Name}, Почасовая ставка: {employee.HourlyRate}, Часы: {employee.HoursWorked}");
            }
            else
            {
                Console.WriteLine("Сотрудник не найден.");
            }
        }

        public void CalculateSalary()
        {
            Console.Write("Введите ID сотрудника для расчета зарплаты: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = employees.Find(emp => emp.Id == id);

            if (employee != null)
            {
                double salary = employee.HourlyRate * employee.HoursWorked;
                Console.WriteLine($"Зарплата сотрудника {employee.Name} (ID: {id}): {salary}");
            }
            else
            {
                Console.WriteLine("Сотрудник не найден.");
            }
        }
    }
}