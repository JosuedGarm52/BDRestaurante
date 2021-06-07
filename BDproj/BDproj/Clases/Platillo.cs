using System;
namespace BDproj.Clases
{
    public class Platillo: Superclase
    {
        public Platillo()
        {
        }
        private string strDescripcion;
        public string Descripcion
        {
            get { return strDescripcion; }
            set { strDescripcion = value; }
        }
        private string intnivel;
        public string Nivel
        {
            get { return intnivel; }
            set { intnivel = value; }

        }
    }
}