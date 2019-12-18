using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.TombstoneStrong.Logic
{
    public class Core
    {
        public Core(params IUnitOfWork[] UoW)
        {
            this.UoW = UoW;
        }
        private readonly IUnitOfWork[] UoW;

        // Factory-Method
        private IUnitOfWork GetUnitOfWorkFor<T>() where T : Entity
        {
            // ToDo: Was wenn es 2 UoWs für "Employee" gibt ?
            // Entweder beides (MergedUoW)
            // Oder Attributen "Priority"
            var result = UoW.FirstOrDefault(x => x.SupportedEntities.Contains(typeof(T)));

            if (result == null)
                throw new InvalidOperationException($"Es gibt kein UoW für den Datentyp {typeof(T)}");
            else
                return result;
        }

        public ICoreModul<T> Modul<T>() where T : Entity
        {
            // Primitiv:
            if (typeof(T) == typeof(Employee))
                return (ICoreModul<T>)new EmployeeModul(GetUnitOfWorkFor<Employee>());
            else if (typeof(T) == typeof(TimeSheet))
                return (ICoreModul<T>)new TimeSheetModul(GetUnitOfWorkFor<TimeSheet>());
            else
                throw new NotImplementedException("Es ist kein Modul für den Datentypen {typeof(T)} vorhanden");
        }

        // Modul
        //  -> Methoden wie Add/Update/Delete/ usw...
        //  -> Kann gekapselt werden (AuthModul -> nicht alles erlaubt ist)
        //  -> Beispielaufruf: core.Modul<Employee>().Add(item);

        // Definition vom Modul: alles in der Logik
        // Vorteil von Domain: andere DLL mit einem neuen Modul 



        #region Beides
        public void GenerateTestData()
        {
            // XML
            Employee em1 = new Employee { ID = 1, Name = "Tom Ate", Department = "Gemüseabteilung", Guid = Guid.NewGuid().ToString() };
            Employee em2 = new Employee { ID = 2, Name = "Anna Nass", Department = "Obstabteilung", Guid = Guid.NewGuid().ToString() };
            Employee em3 = new Employee { ID = 3, Name = "Peter Silie", Department = "Gemüseabteilung", Guid = Guid.NewGuid().ToString() };

            // EF
            TimeSheet ts1 = new TimeSheet
            {
                // Employee = em1,
                EmployeeGuid = em1.Guid,
                Start = new DateTime(2019, 12, 17, 9, 30, 00),
                End = new DateTime(2019, 12, 17, 17, 25, 00),
            };
            TimeSheet ts2 = new TimeSheet
            {
                //Employee = em1,
                EmployeeGuid = em1.Guid,
                Start = new DateTime(2019, 12, 16, 7, 30, 00),
                End = new DateTime(2019, 12, 16, 12, 00, 00),
            };
            TimeSheet ts3 = new TimeSheet
            {
                //Employee = em1,
                EmployeeGuid = em1.Guid,
                Start = new DateTime(2019, 12, 15, 8, 11, 00),
                End = new DateTime(2019, 12, 15, 15, 12, 00),
            };

            TimeSheet ts4 = new TimeSheet
            {
                // Employee = em2,
                EmployeeGuid = em2.Guid,

                Start = new DateTime(2019, 12, 17, 20, 00, 00),
                End = new DateTime(2019, 12, 18, 6, 00, 00),
            };
            TimeSheet ts5 = new TimeSheet
            {
                EmployeeGuid = em2.Guid,
                //Employee = em2,
                Start = new DateTime(2019, 12, 18, 19, 30, 00),
                End = new DateTime(2019, 12, 19, 4, 59, 00),
            };
            TimeSheet ts6 = new TimeSheet
            {
                EmployeeGuid = em2.Guid,
                // Employee = em2,
                Start = new DateTime(2019, 12, 19, 23, 00, 00),
                End = new DateTime(2019, 12, 20, 9, 35, 00),
            };

            TimeSheet ts7 = new TimeSheet
            {
                EmployeeGuid = em3.Guid,
                // Employee = em3,
                Start = new DateTime(2019, 12, 17, 12, 00, 00),
                End = new DateTime(2019, 12, 17, 14, 00, 00),
            };
            TimeSheet ts8 = new TimeSheet
            {
                EmployeeGuid = em3.Guid,
                // Employee = em3,
                Start = new DateTime(2019, 12, 18, 15, 30, 00),
                End = new DateTime(2019, 12, 18, 17, 40, 00),
            };
            TimeSheet ts9 = new TimeSheet
            {
                EmployeeGuid = em3.Guid,
                // Employee = em3,
                Start = new DateTime(2019, 12, 19, 8, 00, 00),
                End = new DateTime(2019, 12, 19, 9, 36, 00),
            };


            Modul<TimeSheet>().Add(ts1);
            Modul<TimeSheet>().Add(ts2);
            Modul<TimeSheet>().Add(ts3);
            Modul<TimeSheet>().Add(ts4);
            Modul<TimeSheet>().Add(ts5);
            Modul<TimeSheet>().Add(ts6);
            Modul<TimeSheet>().Add(ts7);
            Modul<TimeSheet>().Add(ts8);
            Modul<TimeSheet>().Add(ts9);

            Modul<Employee>().Add(em1);
            Modul<Employee>().Add(em2);
            Modul<Employee>().Add(em3);

            SaveAllUoW();
        }
        public bool IsEmpty<T>() where T : Entity
        {
            return GetUnitOfWorkFor<T>().GetRepository<T>().Query().Count() == 0;
        }
        public void SaveAllUoW()
        {
            foreach (var item in UoW)
                item.SaveAll();
        }
        #endregion

        public ModuleBuilder<T> CreateModul<T>() where T : Entity
        {
            return ModuleBuilder<T>.Create(this);
        }

        public class ModuleBuilder<T> where T : Entity
        {
            internal static ModuleBuilder<T> Create(Core core)
            {
                return new ModuleBuilder<T>(core);
            }
            private ModuleBuilder(Core core)
            {
                module = core.Modul<T>();
                this.core = core;
            }

            private readonly Core core;
            private ICoreModul<T> module;

            private bool hasAuth = false;

            public ModuleBuilder<T> WithAuthentification(User currentUser)
            {
                if(hasAuth == false)
                {
                    module = new AuthentificationModule<T>(currentUser, module, core.GetUnitOfWorkFor<T>());
                    hasAuth = true;
                }
                return this;
            }

            public ICoreModul<T> Build() => module;

            public ModuleBuilder<T> LogsExceptionsInto(Action<string> callback)
            {
                module = new ExceptionModule<T>(module, core.GetUnitOfWorkFor<T>(), callback);
                return this;
            }
        }

    }
}
