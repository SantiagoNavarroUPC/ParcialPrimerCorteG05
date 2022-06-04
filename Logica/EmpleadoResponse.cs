using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Logica
{
    public class EmpleadoResponse
    {
        public List<Empleado> Empleados { get; set; }
        public Empleado EmpleadoEncontrado { get; set; }
        public string MessageError { get; set; }
        public bool ExistError { get; set; }

        public EmpleadoResponse(List<Empleado> empleados)
        {
            Empleados = empleados;
            ExistError = false;
        }
        public EmpleadoResponse(Empleado empleados)
        {
            EmpleadoEncontrado = empleados;
            ExistError = false;
        }
        public EmpleadoResponse(string messageError)
        {
            MessageError = messageError;
            ExistError = true;
        }

    }
}
