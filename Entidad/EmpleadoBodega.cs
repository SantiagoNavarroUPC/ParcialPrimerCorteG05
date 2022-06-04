using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidad.IBodega;

namespace Entidad
{
    public class EmpleadoBodega : Empleado,IBodega
    {
        public EmpleadoBodega() 
        {
            
        }
        public EmpleadoBodega(string nombre, string id, int edad, double salario, string cargo,double numeroBodega) : base(nombre, id, edad, salario, cargo)
        {
            NumeroBodega = numeroBodega;
        }
        public double NumeroBodega { get; set; }

        const double SM = 1000000;
        public override double CalcularSalario()
        {
            TipoBodega();
            double salario = SM * NumeroBodega;
            Salario = salario;
            return Salario;
        }
        public override string DesignarEmpleado()
        {
            string cargo = "BODEGA";
            Cargo = cargo;
            return Cargo;
        }
        public double TipoBodega() { 

            if (NumeroBodega == 1) NumeroBodega = Convert.ToDouble(Bodega.carga);

            else if (NumeroBodega == 2) NumeroBodega = Convert.ToDouble(Bodega.mantenimiento) - 0.5;
            
            else NumeroBodega = 0;
            
            return NumeroBodega;
        }

    }

}
