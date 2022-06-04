using Logica;
using Entidad;
using System;

namespace Presentacion
{
    class Program
    {
        static EmpleadoService empleadoService = new EmpleadoService();
        static void Main(string[] args)
        {
            ConsoleKeyInfo continuar;
            do
            {
                Console.Clear();
                int op;
                Console.WriteLine("----------Software de Registro de Empleados----------");
                Console.WriteLine("1 --> Guardar Empleados");
                Console.WriteLine("2 --> Consultar Empleados");
                Console.WriteLine("3 --> Eliminar Empleados");
                Console.WriteLine("4 --> Buscar Empleados");
                Console.WriteLine("5 --> Modificar Empleados");
                do
                {
                    Console.Write("Escoja una Opción: ");
                    op = int.Parse(Console.ReadLine());
                } while (op < 1 || op > 6);


                switch (op)
                {
                    case 1:
                        RegistrarDatos();
                        break;
                    case 2:
                        ConsultarDatos();
                        break;
                    case 3:
                        EliminarDatos();
                        break;
                    case 4:
                        BuscarDatos();
                        break;
                    case 5:
                        ModificarDatos();
                        break;
                }
                Console.Write("Desea Continuar en la aplicación (S/N): ");
                continuar = Console.ReadKey();
            } while (continuar.Key == ConsoleKey.S || continuar.Key == ConsoleKey.S);

        }
        static EmpleadoOficina RegistrarOficina()
        {
            string nombre, id, cargo;
            int edad, tipoBono;
            double prestacion, salario;
            EmpleadoOficina empleadoOficina = null;
            Console.WriteLine("Digite su nombre completo ");
            nombre = Console.ReadLine();
            Console.WriteLine("Digite su edad");
            edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite su numero de identificacion");
            id = Console.ReadLine();
            Console.WriteLine("Digite el valor de su prestacion");
            prestacion = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite su tipo de bono");
            Console.WriteLine("BAJO -- > 1 - ALTO -- > 2 - SUPERIOR -- > 3 ");
            tipoBono = Convert.ToInt32(Console.ReadLine());
            salario = 0;
            cargo = "";
            empleadoOficina = new EmpleadoOficina(nombre, id, edad, salario, cargo, prestacion, tipoBono);
            empleadoOficina.CrearBono();
            empleadoOficina.CalcularSalario();
            empleadoOficina.DesignarEmpleado();
            return empleadoOficina;
        }
        static EmpleadoBodega RegistrarBodega()
        {
            string nombre, id, cargo;
            int edad, numeroBodega;
            double prestacion, salario;
            EmpleadoBodega empleadoBodega = null;
            Console.WriteLine("Digite su nombre completo ");
            nombre = Console.ReadLine();
            Console.WriteLine("Digite su edad");
            edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite su numero de identificacion");
            id = Console.ReadLine();
            Console.WriteLine("Digite el numero de su bodega");
            Console.WriteLine("CARGA -- > 1 - MANTENIMIENTO -- > 2");
            numeroBodega = Convert.ToInt32(Console.ReadLine());
            salario = 0;
            cargo = "";
            empleadoBodega = new EmpleadoBodega(nombre, id, edad, salario, cargo, numeroBodega);
            empleadoBodega.CalcularSalario();
            empleadoBodega.DesignarEmpleado();
            return empleadoBodega;
        }
        static void RegistrarDatos()
        {
            Console.Clear();
            Empleado empleado = null;
            Console.WriteLine("Ingreso de empleados");
            Console.WriteLine("Ingresar los datos del empleado");
            Console.WriteLine("Tipo de empleado: BODEGA --> B - OFICINA --> O ");
            int opcion = Convert.ToChar(Console.ReadLine());
            if (opcion == 'b' || opcion == 'B')
            {
                empleado = RegistrarBodega();
            }
            if (opcion == 'o' || opcion == 'O')
            {
                empleado = RegistrarOficina();
            }
            Console.WriteLine(empleadoService.Guardar(empleado) + '\n');

        }
        static void ConsultarDatos()
        {
            Console.Clear();
            Console.WriteLine("Listado de empleados.\n");
            var response = empleadoService.Consultar();
            if (response.Error)
            {
                Console.WriteLine(response.MensajeDeError);
            }
            else
            {
                foreach (var liquidacion in response.Empleados)
                {
                    Console.WriteLine(liquidacion.ToString());
                    Divisor();
                }
            }
        }
        static void EliminarDatos()
        {
            Console.Clear();
            ConsultarDatos();
            Console.Clear();
            Console.Write("Ingrese el codigo de la liquidacion que desea borrar: ");
            string id = Console.ReadLine();
            Console.WriteLine(empleadoService.Eliminar(id));
            Console.Clear();
            ConsultarDatos();

        }
        static void ModificarDatos()
        {
            Console.Clear();
            ConsultarDatos();
            Console.Clear();
            Console.Write("Ingrese el codigo de la liquidacion que desea modificar: ");
            string id = Console.ReadLine();
            Console.WriteLine(empleadoService.Eliminar(id));
            Console.Clear();
            RegistrarDatos();
            ConsultarDatos();

        }
        static void BuscarDatos()
        {
            Console.Clear();
            ConsultarDatos();
            Console.Clear();
            Console.WriteLine("---------Busqueda por Identificación---------");
            ValidaYMuestraEmpleadoBuscada();

        }
        private static (string Identificacion, bool IsFind) ValidaYMuestraEmpleadoBuscada()
        {
            Console.Write("Identificiacion: ");
            string identificacion = Console.ReadLine();
            var mensajeBusqueda = empleadoService.Buscar(identificacion);
            if (mensajeBusqueda.ExistError)
            {
                Console.WriteLine(mensajeBusqueda.MessageError);
            }
            else
            {
                Console.WriteLine(mensajeBusqueda.EmpleadoEncontrado.ToString());
            }
            return (identificacion, !mensajeBusqueda.ExistError);
        }
        static void Divisor()
        {
            Console.WriteLine("********************************************");
        }
    }
}