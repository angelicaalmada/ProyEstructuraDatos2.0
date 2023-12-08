using ProyEstructuraDatos2._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Proy_EstructuraDatos
{
    public class Pila
    {
        private int _cima;
        private Cancion[] listaPila;
        private int _longitudPila = 5;

        public int GetCima()
        {
            return this._cima;
        }

        public Cancion[] GetListaPila()
        {
            return listaPila;
        }

        public Pila()
        {
            _cima = -1;
            listaPila = new Cancion[_longitudPila];
        }

        //metodo para verificar si la pila esta vacia
        public bool PilaVacia()
        {
            //return _cima == -1? false: true;
            if (_cima == -1)
                return true;
            else
                return false;
        }

        //verificar si la cima esta llena
        public bool Pilallena()
        {
            if (_cima == _longitudPila - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Para saber o conocer el tamano de la pila
        public int LongitudPila()
        {
            return _longitudPila;
        }

        //Conocer la cantidad de elementos de la pila
        public int CantElementos()
        {
            return _cima + 1;
        }

        //Obtener el valor de la cima
        public Cancion ValorCima()
        {
            return listaPila[_cima];
        }

        //Insertar un valor en la pila
        public bool InsertarElemento(Cancion valor)
        {
            if (Pilallena())
            {
                return false;
            }
            else
            {
                _cima++;
                listaPila[_cima] = valor;
                return true;
            }
        }

        //Extraer un elemento de la pila
        public Cancion EliminarElemento()
        {
            if (PilaVacia())
            {
                Console.WriteLine("La pila esta vacia");
                return null;
            }
            else
            {
                Cancion aux = listaPila[_cima];
                _cima--;
                return aux;
            }
        }

        public Cancion BuscarElementoPorValor(string valor)
        {
            for (int i = 0; i <= _cima; i++)
            {
                if (listaPila[i].NombreCancion == valor)
                {
                    return listaPila[i];
                }
            }

            return null;
        }


        public bool Modificar(string nombrecancion, Cancion cancion)
        {
            Pila pilaAuxiliar = new Pila();
            bool encontrado = false;
            // Movemos los datos en auxiliar para no perder los originales
           // int cimaux = _cima;
            while (listaPila[_cima] != null)
            {
                if (listaPila[_cima].NombreCancion == nombrecancion)
                {
                    listaPila[_cima] = cancion;
                    encontrado = true;
                    break;
                }

                pilaAuxiliar.InsertarElemento(listaPila[_cima]);
                EliminarElemento();                
            }
           // cimaux = _cima;
            // RegrpilaAuxiliaresamos los datos
            while (!pilaAuxiliar.PilaVacia())
            {
                InsertarElemento(pilaAuxiliar.listaPila[pilaAuxiliar._cima]);
                pilaAuxiliar.EliminarElemento();
               // cimaux++;
            }

            return encontrado;

        }

        //imprimir todos los elementos de la pila
        public void ImprimirElementos()
        {
            if (PilaVacia())
            {
                Console.WriteLine("La pila esta vacia");
            }
            else
            {
                for (int i = 0; i <= _cima; i++)
                {
                    Console.Write(listaPila[i].NombreCancion + "-->");
                }
            }
        }
    }
}
