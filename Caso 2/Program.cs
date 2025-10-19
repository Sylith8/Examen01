using System;
using System.Collections.Generic;

class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }

    public Persona(int id, string nombre, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
    }
}

class Cita
{
    public int PersonaId { get; set; }
    public string Fecha { get; set; }
    public string Descripcion { get; set; }
}

class Program
{
    static List<Persona> personas = new List<Persona>();
    static List<Cita> citas = new List<Cita>();

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n Menú AgendaPro ");
            Console.WriteLine("1. Registrar persona");
            Console.WriteLine("2. Listar personas");
            Console.WriteLine("3. Crear cita para persona");
            Console.WriteLine("4. Listar citas por PersonaId");
            Console.WriteLine("5. Mostrar todas las citas");
            Console.WriteLine("6. Salir");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarPersona();
                    break;
                case 2:
                    ListarPersonas();
                    break;
                case 3:
                    CrearCita();
                    break;
                case 4:
                    ListarCitasPorPersona();
                    break;
                case 5:
                    MostrarTodasLasCitas();
                    break;
                case 6:
                    Console.WriteLine("Saliendo");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 6);
    }

    static void RegistrarPersona()
    {
        try
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            if (personas.Exists(p => p.Id == id))
            {
                Console.WriteLine("Id ya existe.");
                return;
            }

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            personas.Add(new Persona(id, nombre, telefono));
            Console.WriteLine("Persona registrada.");
        }
        catch
        {
            Console.WriteLine("Error al ingresar datos.");
        }
    }

    static void ListarPersonas()
    {
        Console.WriteLine("Personas Registradas");
        foreach (var p in personas)
            Console.WriteLine($"{p.Id}|{p.Nombre}|{p.Telefono}");
    }

    static void CrearCita()
    {
        try
        {
            Console.Write("PersonaId: ");
            int pid = int.Parse(Console.ReadLine());

            if (!personas.Exists(p => p.Id == pid))
            {
                Console.WriteLine("Persona no encontrada.");
                return;
            }

            Console.Write("Fecha: ");
            string fecha = Console.ReadLine();

            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            citas.Add(new Cita { PersonaId = pid, Fecha = fecha, Descripcion = descripcion });
            Console.WriteLine("Cita registrada.");
        }
        catch
        {
            Console.WriteLine("Datos inválidos.");
        }
    }

    static void ListarCitasPorPersona()
    {
        Console.Write("PersonaId: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            foreach (var c in citas)
                if (c.PersonaId == id)
                    Console.WriteLine($"{c.PersonaId}|{c.Fecha}|{c.Descripcion}");
        }
        else
        {
            Console.WriteLine("Id inválido.");
        }
    }

    static void MostrarTodasLasCitas()
    {
        Console.WriteLine("-- Todas las Citas --");
        foreach (var c in citas)
            Console.WriteLine($"{c.PersonaId}|{c.Fecha}|{c.Descripcion}");
    }
}
