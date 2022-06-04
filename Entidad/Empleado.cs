using System;

namespace Entidad
{
    public abstract class Empleado
    {
        public Empleado() 
        {
            
        }
        public Empleado(string nombre,string id,int edad,double salario,string cargo)
        {
            Nombre = nombre;
            Id = id;
            Edad = edad;
            Salario = salario;
            Cargo = cargo;
        }
        
        public string Nombre { get; set; }
        public string Id { get; set; }
        public int Edad { get; set; }
        public double Salario { get; set; }
        public string Cargo { get; set; }
        public abstract double CalcularSalario();
        public abstract string DesignarEmpleado();
        public override string ToString()
        {
            return "Informacion del empleado" +
                   "\n" + "Nombre del empleado: " + Nombre +
                   "\n" + "Edad del empleado: " + Edad + " años " +
                   "\n" + "Identificaion del empleado: " + Id +
                   "\n" + "Salario del empleado: " + Salario + " pesos colombianos" +
                   "\n" + "Cargo del empleado: " + Cargo +
                   "\n" + "____________________________________________________________________";
        }
        public string FormatoParaArchivo()
        {
            return $"{Nombre};{Edad};{Id};{Salario};{Cargo};";
        }
    }
}

    