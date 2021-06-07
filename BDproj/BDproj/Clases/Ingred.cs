using System;
namespace BDproj.Clases
{
    public class Ingred: Superclase
    {
        public Ingred()
        {
        }
        private string strIngrediente;
        public string Ingrediente
        {
            get { return strIngrediente; }
            set { strIngrediente = value; }
        }
        private string strAlmacen;
        public string Almacen
        {
            get { return strAlmacen; }
            set { strAlmacen = value; }
        }
        private string intUnidad;
        public string Unidad
        {
            get { return intUnidad; }
            set { intUnidad = value; }
        }
    }
}
