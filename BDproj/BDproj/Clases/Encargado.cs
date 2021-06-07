using System;
namespace BDproj.Clases
{
    public class Encargado: Superclase
    {
        public Encargado()
        {
        }
        private string strNombre;
        public string Nombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }
        private string strApellido;
        public string Apellido
        {
            get { return strApellido; }
            set { strApellido = value; }
        }
    }
}
