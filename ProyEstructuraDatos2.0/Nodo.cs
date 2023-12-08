using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_EstructuraDatos
{
    public class Nodo
    {
        //private string nombreCancion;
        //private string Interprete;
        //private string Duracion;
        //private string Genero;
        public Cancion _cancion;
        private Nodo _Siguiente;

        public Nodo(Cancion cancion)
        {
            _cancion = cancion;       
        }

        public Nodo(Cancion cancion, Nodo siguiente)
        {
            _cancion = cancion;
            _Siguiente = siguiente;
        }

     

        public Cancion getCancion()
        {
            return _cancion;
        }
        public Cancion setCancion(Cancion cancion)
        {
            return _cancion=cancion;
        }


        public Nodo getSiguente()
        {
            return _Siguiente ;
        }

        public void setSiguiente(Nodo siguiente)
        {
            _Siguiente = siguiente;
        }
    }
}
