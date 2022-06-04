using Datos;
using Entidad;
using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Logica
{
    public class EmpleadoService
    {
        private EmpleadoRepository empleadoRepository;

        public EmpleadoService()
        {
            empleadoRepository = new EmpleadoRepository();
        }
        public string Guardar(Empleado empleado)
        {
            try
            {

                empleadoRepository.Guardar(empleado);
                return "Se ha guardado exitosamente!";


            }
            catch (Exception e)
            {
                return "Se ha presentado la excepcion: " + e.Message;
            }
        }
        public EmpleadoConsultarResponse Consultar()
        {
            try
            {
                List<Empleado> empleadoDelFile = empleadoRepository.Consultar();
                return new EmpleadoConsultarResponse(empleadoDelFile);
            }
            catch (Exception e)
            {
                return new EmpleadoConsultarResponse("Se ha presentado la excepcion: " + e.Message);
            }
        }
        public string Eliminar(string id)
        {
            try
            {
                if (empleadoRepository.Buscar(id) != null)
                {
                    empleadoRepository.Eliminar(id);
                    return $"Se Eliminó el registro de la persona con identificacion{id}";
                }
                return $"No fue posible eliminar el registro, porque no existe la persona con la identificacion {id}";
            }
            catch (Exception e)
            {
                return $"Error inesperado al Eliminar: {e.Message}";
            }
        }
        public EmpleadoResponse Buscar(string idBuscar)
        {
            try
            {
                Empleado empleadoFile = empleadoRepository.Buscar(idBuscar);
                if (empleadoFile != null)
                {
                    return new EmpleadoResponse(empleadoFile);
                }
                else
                    return new EmpleadoResponse("No existe ninguna liquidacion registrada con este codigo.");
            }
            catch (Exception e)
            {
                return new EmpleadoResponse("Se ha presentado la siguiente excepcion: " + e.Message);
            }
        }
        public EmpleadoResponse Filtrar(string tipoLiquidacion)
        {
            try
            {
                List<Empleado> empleadosDelFile = empleadoRepository.FiltrarDatos(tipoLiquidacion);
                return new EmpleadoResponse(empleadosDelFile);
            }
            catch (Exception e)
            {
                return new EmpleadoResponse("Se ha presentado la excepcion: " + e.Message);
            }
        }

    }
        
}