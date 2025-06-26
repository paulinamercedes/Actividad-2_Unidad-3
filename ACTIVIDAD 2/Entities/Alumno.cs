using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACTIVIDAD_2.Entities
{
    internal class Alumno
    {
        //Contructor
        public Alumno() { }

        //propiedad automatica de los atributos

        public String Codigo { get; set; }

        public String Nombre { get; set; }

        public double Promedio { get; set; }
    }
}
