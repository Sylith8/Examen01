using System;
using System.Collections.Generic;

class Producto
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    public override string ToString()
    {
        return $"{Codigo}|{Nombre}|{Precio}|{Cantidad}";
    }
}

class Program
{
    static List<Producto> productos = new List<Producto>();

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n Menú Inventario ElectroPlus ");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Listar productos");
            Console.WriteLine("3. Buscar producto por Código");
            Console.WriteLine("4. Mostrar productos con Cantidad = 0");
            Console.WriteLine("5. Salir");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Ingrese un número.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AgregarProducto();
                    break;
                case 2:
                    ListarProductos();
                    break;
                case 3:
                    BuscarProducto();
                    break;
                case 4:
                    MostrarSinStock();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 5);
    }

    static void AgregarProducto()
    {
        Producto p = new Producto();

        Console.Write("Código: ");
        p.Codigo = Console.ReadLine();

        Console.Write("Nombre: ");
        p.Nombre = Console.ReadLine();

        try
        {
            Console.Write("Precio: ");
            p.Precio = decimal.Parse(Console.ReadLine());

            Console.Write("Cantidad: ");
            p.Cantidad = int.Parse(Console.ReadLine());

            productos.Add(p);
            Console.WriteLine("Producto agregado correctamente.");
        }
        catch
        {
            Console.WriteLine("Error: Precio o cantidad no son válidos.");
        }
    }

    static void ListarProductos()
    {
        Console.WriteLine("\n Lista de Productos ");
        foreach (var p in productos)
            Console.WriteLine(p);
    }

    static void BuscarProducto()
    {
        Console.Write("Ingrese código a buscar: ");
        string codigo = Console.ReadLine();

        var encontrado = productos.Find(p => p.Codigo == codigo);
        if (encontrado != null)
            Console.WriteLine("Encontrado: " + encontrado);
        else
            Console.WriteLine("Producto no encontrado.");
    }

    static void MostrarSinStock()
    {
        Console.WriteLine("\n Productos sin stock ");
        foreach (var p in productos)
            if (p.Cantidad == 0)
                Console.WriteLine(p);
    }
}

