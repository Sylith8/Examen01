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
                    Console.WriteLine("Saliendo");
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
            Console.WriteLine("Producto agregado exitosamente.");
        }
        catch
        {
            Console.WriteLine("Error: Precio o cantidad no son válidos.");
        }
    }


    }
}

