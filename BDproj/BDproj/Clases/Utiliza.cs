using System;
namespace BDproj.Clases
{
    public class Utiliza: Superclase
    {
        public Utiliza()
        {
        }
        private string intCantidad;
        public string Cantidad
        {
            get { return intCantidad; }
            set { intCantidad = value; }
        }
    }
}
