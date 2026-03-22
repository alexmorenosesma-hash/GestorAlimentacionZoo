using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Alimento
    {
        string nombre { get; set; }
        double cantidad { get; set; }
        string unidad { get; set; }
        public Alimento()
        {
        }
        public Alimento(string nombre, double cantidad,string unidad)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.unidad = unidad;
        }
    }
}
