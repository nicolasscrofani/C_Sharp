using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perro : Mascota
    {
        private int edad;
        private bool esAlfa;

        public Perro(string nombre, string raza) :base(nombre,raza)
        {
            
        }

        public Perro (string nombre, string raza, int edad, bool esAlfa) :this(nombre, raza)
        {
            this.edad = edad;
            this.esAlfa = esAlfa;
        }


        public static explicit operator int(Perro p)
        {
            return p.edad;
        }

        public static bool operator ==(Perro p1, Perro p2)
        {
            return (Mascota)p1 == (Mascota)p2 && p1.edad == p2.edad;
        }

        public static bool operator !=(Perro p1, Perro p2)
        {
            return !(p1 == p2); 
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Perro)
            {
                if(this == (Perro)obj)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        protected override string Ficha()
        {
            StringBuilder mensaje = new StringBuilder();

            if (this.esAlfa)
            {
                mensaje.Append($"Perro - {base.DatosCompletos()}, alfa de la manada, edad {this.edad}");
            }
            else
            {
                mensaje.Append($"Perro - {base.DatosCompletos()}, edad {this.edad}");
            }

            return mensaje.ToString();
        }

        public override string ToString()
        {
            return this.Ficha();
        }

    }
}
