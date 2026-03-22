using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Especie
    {
        string nombre { get; set; }
        string nombreCientifico { get; set; }
        string tipoAlimentacion { get; set; }
        
        public Especie()
        {
        }

        public Especie(string nombre,string tipoAlimentacion)
        {
            this.nombre = nombre;
            this.tipoAlimentacion = tipoAlimentacion;
        }
        public Especie(string nombre, string nombreCientifico, string tipoAlimentacion)
        {
            this.nombre = nombre;
            this.nombreCientifico = nombreCientifico;
            this.tipoAlimentacion = tipoAlimentacion;
        }

    }
}
