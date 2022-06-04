using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidad.IBono;

namespace Entidad
{
    public class EmpleadoOficina:Empleado,IBono
    {
        public EmpleadoOficina()
        {

        }
        public EmpleadoOficina(string nombre, string id, int edad, double salario, string cargo, double prestacion,int tipobono) : base(nombre, id, edad, salario, cargo)
        {
            Prestacion = prestacion;
            TipoBonus = tipobono;
        }
        public double Prestacion { get; set; }
        public string Seccion { get; set; }
        public double Bono { get; set; }
        public int TipoBonus { get; set; } 

        private double bono;

        public override double CalcularSalario()
        {
            double salario = 30 * Prestacion;
            CrearBono();
            Salario = salario + Bono;
            return Salario;
        }

        public double CrearBono()
        {
            TipoBono();
            Bono = bono;
            return Bono;
        }

        public override string DesignarEmpleado()
        {
            string cargo = "OFICINA";
            Cargo = cargo;
            return Cargo;
        }

        public double TipoBono()
        {
            if (TipoBonus == 1)
            {
                bono = Convert.ToDouble(Bonus.bajo);
            }
            else if (TipoBonus == 2)
            {
                bono = Convert.ToDouble(Bonus.alto);
            }
            else if (TipoBonus == 3)
            {
                bono = Convert.ToDouble(Bonus.superior);
            }
            else
            {
                bono = 0;
            }
            return bono;
        }
       
    }
}
