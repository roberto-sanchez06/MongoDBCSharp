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

namespace MongoDBPractica
{
    public partial class FrmJuego : Form
    {
        public IJuegoService juegoService { get; set; }
        public FrmJuego()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Juego juego = new Juego()
            {
                IdObjeto = juegoService.GetLastId() + 1,
                Nombre= "Halo",
                Precio= 20,
                Plataforma = "Xbox"
            };
            juegoService.Add(juego);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lista = juegoService.FindAll();
            foreach(var j in lista)
            {
                MessageBox.Show(j.Nombre);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var lista = juegoService.BuscarPorPlataforma("Xbox");
            foreach(var j in lista)
            {
                MessageBox.Show(j.Nombre);
            }
        }
    }
}
