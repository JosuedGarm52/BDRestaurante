using System;
namespace BDproj.Clases
{
    public class Superclase
    {
        public Superclase()
        {
        }
        private string intid_categoria;
        public string id_categoria
        {
            get { return intid_categoria; }
            set { intid_categoria = value; }
        }
        private string intid_encargado;
        public string id_encargado
        {
            get { return intid_encargado; }
            set { intid_encargado = value; }
        }
        private string intid_ingrediente;
        public string id_ingrediente
        {
            get { return intid_ingrediente; }
            set { intid_ingrediente = value; }
        }
        private string intid_platillo;
        public string id_platillo
        {
            get { return intid_platillo; }
            set { intid_platillo = value; }
        }
        private string intid_plato;
        public string id_plato
        {
            get { return intid_plato; }
            set { intid_plato = value; }
        }
    }
}
