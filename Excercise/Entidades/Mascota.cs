using System.Text;

namespace Entidades
{
    public abstract class Mascota
    {
        private string nombre;
        private string raza;

        public Mascota(string nombre, string raza)
        {
            this.nombre = nombre;
            this.raza = raza;
        }

        public string Nombre
        {
            get { return this.nombre; }
        }

        public string Raza
        {
            get { return this.raza; }
        }

        protected abstract string Ficha();

        protected virtual string DatosCompletos()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append($"{this.nombre} - {this.raza}");
            return mensaje.ToString();
        }

        public static bool operator ==(Mascota mascota1, Mascota mascota2)
        {
            return mascota1.raza == mascota2.raza && mascota1.nombre == mascota2.nombre;
        }

        public static bool operator !=(Mascota mascota1, Mascota mascota2)
        {
            return !(mascota1 == mascota2);
        }

      
    }
}