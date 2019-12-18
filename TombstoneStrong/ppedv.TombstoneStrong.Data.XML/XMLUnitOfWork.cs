using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ppedv.TombstoneStrong.Data.XML
{
    public class XMLUnitOfWork : IUnitOfWork
    {
        public XMLUnitOfWork(string path = "Employees.xml")
        {
            this.path = path;
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Employee>));
                try
                {
                    employees = (HashSet<Employee>) serializer.Deserialize(stream);
                }
                catch (InvalidOperationException ex)
                {
                    // Es sind keine Employee-Daten vorhanden
                }
                finally
                {
                    if(employees == null)
                        employees = new HashSet<Employee>();
                }
            }
        }
        private readonly string path;
        private HashSet<Employee> employees;

        public IEmployeeRepository EmployeeRepository => new XMLEmployeeRepository(ref employees);

        public IUniversalRepository<T> GetRepository<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            using(FileStream stream = new FileStream(path,FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Employee>));
                serializer.Serialize(stream, employees);
            }
        }
    }
}
