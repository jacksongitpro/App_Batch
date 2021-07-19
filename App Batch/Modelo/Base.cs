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


        }
    }
}
