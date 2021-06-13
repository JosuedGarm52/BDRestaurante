using System;
namespace BDproj.Clases
{
    public class Plato: Superclase
    {
        public Plato()
        {
        }
        private string strFoto;
        public string Foto
        {
            get { return strFoto; }
            set { strFoto = value; }
        }
        private string dblPrecio;
        public string Precio
        {
            get { return dblPrecio; }
            set { dblPrecio = value; }
        }
    }
}
