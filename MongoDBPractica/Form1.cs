using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using Domain;
using Infraestructure;

namespace MongoDBPractica
{
    public partial class Form1 : Form
    {
        private IEmpleadoService empleadoService;
        private IJuegoService juegoService;
        public Form1(IEmpleadoService empleadoService, IJuegoService juegoService)
        {
            this.juegoService = juegoService;
            this.empleadoService = empleadoService;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado()
            {
                IdObjeto = empleadoService.GetLastId()+1,
                Nombre = "Pepe",
                Direccion = new Direccion()
                {
                    Ciudad = "Managua",
                    Pais = "Nicaragua"
                },
                Salario = 10000
            };
            empleadoService.Add(emp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado()
            {
                //Id=empOriginal.Id,
                IdObjeto = 1,
                Nombre = "Luis",
                Direccion = new Direccion()
                {
                    Ciudad = "Leon",
                    Pais = "España"
                },
                Salario = 999999
            };
            empleadoService.Update(emp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Empleado emp = empleadoService.FindAny(1);
            if (empleadoService.Delete(emp))
            {
                MessageBox.Show("Borrado con exito");
            }
            else
            {
                MessageBox.Show("No fuer borrado");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Empleado> empleados = empleadoService.FindAll();
            if (empleados.Count==0)
            {
                MessageBox.Show("NO hay");
            }
            foreach(Empleado emp in empleados)
            {
                MessageBox.Show(emp.Nombre);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Empleado empleado = empleadoService.FindAny(1);
            if(empleado == null)
            {
                MessageBox.Show("No encontrado");
            }
            else
            {
                MessageBox.Show("Encontrado");
                MessageBox.Show(empleado.Id.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmJuego frmJuego = new FrmJuego();
            frmJuego.juegoService = juegoService;
            frmJuego.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Empleado> empleados = empleadoService.GetDespedidos();
            if (empleados.Count == 0)
            {
                MessageBox.Show("NO hay");
            }
            foreach (Empleado emp in empleados)
            {
                MessageBox.Show(emp.Nombre);
            }
        }
    }
}
