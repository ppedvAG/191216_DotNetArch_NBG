using Domain.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MeineKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region  Marke Eigenbau mit Reflection:
            //Assembly a = Assembly.LoadFrom("MEF_Demo.dll");
            //Type TRtype = a.GetType("MEF_Demo.Taschenrechner");

            //object instance = Activator.CreateInstance(TRtype);

            //MethodInfo minfo = TRtype.GetMethod("Add", new Type[] { typeof(int), typeof(int) });

            //var result = minfo.Invoke(instance, new object[] { 12, 3 });
            //Console.WriteLine(result); 
            #endregion

            Core core = new Core();

            // Komponente, die den Core mit den richtigen Daten befüllt:
            
            DirectoryCatalog catalog = new DirectoryCatalog(".");
            CompositionContainer container = new CompositionContainer(catalog);

            container.ComposeParts(core);

            var result =  core.Rechenmodul[1].Add(12,3);
            Console.WriteLine(result);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

    class Core
    {
        [ImportMany(typeof(IRechner))]
        public IRechner[] Rechenmodul { get; set; }
    }
}
