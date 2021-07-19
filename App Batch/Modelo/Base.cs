using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Batch.Modelo
{
    public static class Base
    {
        public static void GenerarReporte()
        {
            string Path = @"C:\Users\jacksong\Documents\ProgramacionLogica\Reporte.txt";
            string[] Lineas;
            if (Path == null)
            {
                Console.WriteLine("Falta Parametro de archivo");
                return;
            }

            if (!File.Exists(Path))
            {
                Console.WriteLine("archivo No existe");
                return;
            }
            Lineas = File.ReadAllLines(Path);

            List<Material> Materiales = new List<Material>();

            foreach (string registro in Lineas)
            {
                string[] campos = registro.Split(';');
                if(campos.Length !=2)
                {
                    throw new Exception("Cantidad de campos invalida");
                }

                Material M = new Material()
                {
                    Nombre = campos[0],
                    Cantidad = int.Parse(campos [1])

                };Materiales.Add(M);
            }
            //ahora creamos un procedimiento que lea la lista creada y defina cual es el mayor y menor
            CalcularStock(Materiales);
        }

        public static void CalcularStock(List<Material> Stock)
        {           
            long valor = 0;
            long valorMin = 0;
            long valorMax = 0;
            List<Stock> Stokeo = new List<Stock>();
            for (int i = 0; i < Stock.Count; i++)
            {
                valor = Stock[i].Cantidad;
                //El primer valor es el minimo y maximo hasta que se diga lo contrario.
                if (i == 0)
                {
                    valorMax = valor;
                    valorMin = valor;
                }

                if (valor >= valorMax)
                {
                    valorMax = Stock[i].Cantidad;
                    Stock M = new Stock()
                    {
                        Nombre = Stock[i].Nombre,
                        Cantidad = Stock[i].Cantidad,
                        Descripcion = "El material de Mayor Stock"

                }; Stokeo.Add(M);
                }

                if (valor < valorMin)
                {
                    valorMin = Stock[i].Cantidad;
                    Stock m = new Stock()
                    {
                        Nombre = Stock[i].Nombre,
                        Cantidad = Stock[i].Cantidad,
                        Descripcion = "El material de menor Stock"

                    }; Stokeo.Add(m);
                }
            }
            Console.WriteLine($"El minimo es {valorMin} y el maximo es {valorMax}");
            Console.ReadLine();
        }
    }
}
