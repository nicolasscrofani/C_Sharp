using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gato : Mascota
    {
        public Gato(string nombre, string raza) : base(nombre, raza)
        {
        }

        public static bool operator ==(Gato a, Gato b)
        {
            return ((Mascota)a == (Mascota)b);
        }

        public static bool operator !=(Gato a, Gato b)
        {
            return !(a == b);
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Gato)
            {
                if (this == (Gato)obj)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        protected override string Ficha()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append($"Gato - {base.DatosCompletos()}");
            return mensaje.ToString();
        }

        public override string ToString()
        {
            return this.Ficha();
        }
    }
}
