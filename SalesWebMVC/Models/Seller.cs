using System;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } // Associação da classe Department com Seller
        public int DepartmentId { get; set; } // Com isso o campo na tabela Seller se torna uma FOREIGN KEY NOT NULL no BD
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); // Associação da classe SalesRecord com Seller

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr) => Sales.Add(sr);

        public void RemoveSales(SalesRecord sr) => Sales.Remove(sr);

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
