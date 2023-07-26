using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Grupo
    {
        private List<Mascota> manada;
        private string nombre;
        private static EtipoManada tipo;

        static Grupo()
        {
            Grupo.tipo = EtipoManada.Unica;
        }

        private Grupo()
        {
            this.manada = new List<Mascota>();
        }

        public Grupo(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public Grupo(string nombre, EtipoManada tipo) : this(nombre)
        {
            Grupo.tipo = tipo;
        }

        public static EtipoManada Tipo
        {
            set { Grupo.tipo = value; }
        }

        public static bool operator ==(Grupo g, Mascota m)
        {
            bool retorno = false;
            if (g.manada.Count > 0)
            {
                foreach (Mascota mascota in g.manada)
                {
                    if (mascota == m)
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        public static bool operator != (Grupo g, Mascota m)
        {
            return !(g == m);
        }

        public static Grupo operator +(Grupo g, Mascota m)
        {
            if (g != m)
            {
                g.manada.Add(m);
            }
            else
            {
                Console.WriteLine($"El {m} ya se encuentra en el grupo");
            }
            return g;
        }

        public static Grupo operator -(Grupo g, Mascota m)
        {
            if (g == m)
            {
                g.manada.Remove(m);
            }
            else
            {
                Console.WriteLine($"El {m} no se encuentra en el grupo");
            }
            return g;
        }

        public static implicit operator string(Grupo grupo)
        {
            StringBuilder mensaje = new StringBuilder();

            mensaje.AppendLine($"Grupo: {grupo.nombre} - tipo: {Grupo.tipo}");
            mensaje.AppendLine($"Integrantes {grupo.manada.Count.ToString()}");

            foreach (Mascota mascota in  grupo.manada)
            {
                mensaje.AppendLine(mascota.ToString());
            }
            return mensaje.ToString();
        }
    }
}
