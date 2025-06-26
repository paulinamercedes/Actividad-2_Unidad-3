using ACTIVIDAD_2.Controllers;
using ACTIVIDAD_2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACTIVIDAD_2
{

    //llamar al controlador
    public partial class Form1 : Form
    {
        private AlumnoController alumnoController = new AlumnoController();

        public Form1()
        {
            InitializeComponent();
        }

        //Mostrar alumnos
        private void MostrarAlumnos(Alumno[] alumnos)
        {
            dGAlumnos.DataSource = null;
            dGAlumnos.DataSource = alumnos;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //validacion de los campos de entrada
            if (textBoxCodigo.Text == "" || textBoxNombre.Text == "" || textBoxPromedio.Text == "")
            {
                MessageBox.Show("Ingresar datos en los campos");
                return;
            
            }

            //Crear alumnos
            Alumno alumno = new Alumno()
            {
                Codigo = textBoxCodigo.Text,
                Nombre = textBoxNombre.Text,
                Promedio = double.Parse(textBoxPromedio.Text)

            };

            //Registro de los alumnos en el arreglo
            alumnoController.Registrar(alumno);


            //Mostrar los alumnos
            MostrarAlumnos(alumnoController.ListarTodo());

            LimpiarCampos();
        }
        public void LimpiarCampos()
        {
            textBoxCodigo.Clear();
            textBoxNombre.Clear();
            textBoxPromedio.Clear();
            tbBuscarporCodigo.Clear();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Validar la seleccion de la fila a eliminar

            if (dGAlumnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a eliminar");
                return;
            }

            //obtener codigo
            String codigo = dGAlumnos.SelectedRows[0].Cells[0].Value.ToString();


            //Eliminar fila seleccionada
            alumnoController.Eliminar(codigo);


            //Mostar el alumno
            MostrarAlumnos(alumnoController.ListarTodo());
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            MostrarAlumnos(alumnoController.Ordenar());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Validar que el campo no este vacio
            if (tbBuscarporCodigo.Text == "")
            {
                MessageBox.Show("Ingrese el codigo a buscar");
                return;
            }

            String codigo = tbBuscarporCodigo.Text;


            //Mostrar alumnos de la busqueda
            MostrarAlumnos(alumnoController.BuscarPorCodigo(codigo));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
