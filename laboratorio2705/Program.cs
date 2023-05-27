// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using laboratorio2705.Clases;

class Program
{
    static void Main()
    {
        // Ruta de la base de datos SQLite
        string databaseFileName = "archivo.sqlite";
        string currentDirectory = Environment.CurrentDirectory;
        string databasePath = System.IO.Path.Combine(currentDirectory, databaseFileName);

        // Crear instancia del gestor de empleados
        GestorEmpleados gestorEmpleados = new GestorEmpleados(databasePath);

        // Crear la tabla de empleados si no existe
        gestorEmpleados.CrearTabla();

        // Agregar 5 empleados predefinidos
        List<Empleado> empleados = new List<Empleado>
            {
                new Empleado(1, "Juan", "Pérez", 30, "Gerente", 5000),
                new Empleado(2, "María", "González", 25, "Supervisor", 4000),
                new Empleado(3, "Carlos", "López", 28, "Analista", 3500),
                new Empleado(4, "Laura", "Hernández", 32, "Consultora", 4500),
                new Empleado(5, "Pedro", "Ramírez", 27, "Programador", 3000)
            };
        foreach (Empleado empleado in empleados)
        {
            gestorEmpleados.AgregarEmpleado(empleado);
        }

        // Obtener y mostrar todos los empleados en la consola
        List<Empleado> empleadosRegistrados = gestorEmpleados.ObtenerEmpleados();
        foreach (Empleado empleado in empleadosRegistrados)
        {
            Console.WriteLine(empleado.ToString());
        }

        // Esperar a que el usuario presione una tecla para salir
        Console.ReadKey();
    }
}

