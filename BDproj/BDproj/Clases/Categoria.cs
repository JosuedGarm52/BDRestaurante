using System;
namespace BDproj.Clases
{
    public class Categoria: Superclase
    {
        public Categoria()
        {
        }
        private string strDescripcion;
        public string Descripcion
        {
            get { return strDescripcion; }
            set { strDescripcion = value; }
        }
    }
}
