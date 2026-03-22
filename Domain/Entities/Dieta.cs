using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Dieta
    {
        string nombre { get; set; }
        List<Alimento> alimentos { get; set; }
        public Dieta()
        {
        }
        public Dieta(string nombre, List<Alimento> alimentos)
        {
            this.nombre = nombre;
            this.alimentos = alimentos;
        }
    }
}
