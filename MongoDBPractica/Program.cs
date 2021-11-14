using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using Autofac;
using Domain;
using Infraestructure;

namespace MongoDBPractica
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EmpleadoMongo>().As<IEmpleadoMongo>();
            builder.RegisterType<JuegosMongo>().As<IJuegoMongo>();
            builder.RegisterType<EmpleadoService>().As<IEmpleadoService>();
            builder.RegisterType<JuegoService>().As<IJuegoService>();

            var container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(container.Resolve<IEmpleadoService>(), container.Resolve<IJuegoService>()));
        }
    }
}
