using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Datos
{
    public class EmpleadoRepository
    {
        private readonly string fileName = "Empleados.txt";

        public void Guardar(Empleado empleadoGuardado)
        {
            FileStream file = new FileStream(fileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(empleadoGuardado.FormatoParaArchivo());
            writer.Close();
            file.Close();
        }
        public List<Empleado> Consultar()
        {
            List<Empleado>empleadosLista = new List<Empleado>();

            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {
                empleadosLista.Add(Map(linea));
            }
            reader.Close();
            file.Close();
            return empleadosLista;
        }
        private Empleado Map(string linea)
        {
            string[] datoEmpleado = linea.Split(';');
            Empleado empleadoMap = InstanciarCargo(datoEmpleado[4]);

            empleadoMap.Nombre = datoEmpleado[0];
            empleadoMap.Edad = Convert.ToInt32(datoEmpleado[1]);
            empleadoMap.Id = datoEmpleado[2];
            empleadoMap.Salario =Convert.ToInt32(datoEmpleado[3]);
            empleadoMap.Cargo = datoEmpleado[4];

            return empleadoMap;

        }
        private Empleado InstanciarCargo(string cargo)
        {
            Empleado empleadoMap;

            if (cargo.Equals("BODEGA"))
            {
                empleadoMap = new EmpleadoBodega();
            }   
            else if (cargo.Equals("OFICINA"))
            {
                empleadoMap = new EmpleadoOficina();
            }
            else
            {
                empleadoMap = null;
            } 
            return empleadoMap;
        }
      
        public void Eliminar(string IdParaEliminar)
        {
            List<Empleado> listaEmpleados = Consultar();
            FileStream file = new FileStream(fileName, FileMode.Create);
            file.Close();
            foreach (var empleados in listaEmpleados)
            {
                if (empleados.Id != IdParaEliminar)
                {
                    Guardar(empleados);
                }
            }
        }
        public Empleado Buscar(string identificacion)
        {
            List<Empleado> listaEmpleados = Consultar();
            foreach (var empleados in listaEmpleados)
            {
                if (empleados.Id.Equals(identificacion))
                    return empleados;
            }
            return null;
        }
        public List<Empleado> FiltrarDatos(string tipoDato)
        {
            IEnumerable<Empleado>filtroDato = from var in Consultar() where var.Id == tipoDato select var;
            return filtroDato.ToList();
        }
    }
}