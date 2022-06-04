using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Logica
{
    public class EmpleadoConsultarResponse
    {
        public List<Empleado> Empleados { get; set; }
        public bool Error { get; set; }
        public string MensajeDeError { get; set; }

        public EmpleadoConsultarResponse(List<Empleado>empleados)
        {
            Empleados = empleados;
            Error = false;
        }
        public EmpleadoConsultarResponse(string mensajeDeError)
        {
            MensajeDeError = mensajeDeError;
            Error = true;
        }


    }
}
