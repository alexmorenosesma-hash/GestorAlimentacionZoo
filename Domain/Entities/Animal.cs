using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Animal
    {
        int edad { get; set; }
        int peso { get; set; }
        string salud { get; set; }
        Especie especie { get; set; }
        Dieta dieta {get;set; }
        List<Horario> horariosAlimentacion{get;set; }
        public Animal()
        {
        }
        public Animal(int edad, int peso, string salud, Especie especie, Dieta dieta, List<Horario> horariosAlimentacion)
        {
            this.edad = edad;
            this.peso = peso;
            this.salud = salud;
            this.especie = especie;
            this.dieta = dieta;
            this.horariosAlimentacion = horariosAlimentacion;
        }
    }
}
