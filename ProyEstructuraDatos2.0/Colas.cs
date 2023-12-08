using Proy_EstructuraDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ProyEstructuraDatos2._0
{
    public class Colas
    {
        public Nodo Principio;
        public Nodo Final;

        public Colas()
        {
            Principio = null;
            Final = null;
        }

        public bool ColaVacia()
        {
            return Principio == null;
        }


        public void Encolar(Cancion cancion)
        {
            Nodo nuevoNodo = new Nodo(cancion);

            if (Final == null)
            {
                Principio = nuevoNodo;
                Final = nuevoNodo;
            }
            else
            {
                Final.setSiguiente(nuevoNodo);
                Final = nuevoNodo;
            }
        }

        public Cancion Pop()
        {
            if (Principio == null)
            {
                return null;
            }

            Cancion dato = Principio.getCancion();
            Principio = Principio.getSiguente();

            if (Principio == null)
            {
                Final = null;
            }

            return dato;
        }

        public bool Desencolar(string cancion)
        {
            Colas colaAuxiliar = new Colas();
            bool encontrado = false;

            while (Principio != null)
            {
                Cancion actual = Pop();

                if (actual.NombreCancion == cancion)
                {
                    encontrado = true;
                }
                else
                {
                    colaAuxiliar.Encolar(actual);
                }
            }

            while (!colaAuxiliar.ColaVacia())
            {
                Encolar(colaAuxiliar.DesencolarBuscar());
            }

            return encontrado;
        }


        public Cancion DesencolarBuscar()
        {
            if (ColaVacia())
            {
                return null;
            }

            Cancion datoDesencolado = Principio.getCancion();
            Principio = Principio.getSiguente();

            if (Principio == null)
            {
                Final = null;
            }
            // Movemos los datos en auxiliar para no perder los originales
            Colas colaAuxiliar = new Colas();
            while (Principio != null)
            {
                colaAuxiliar.Encolar(DesencolarBuscar());
            }
            // Regresamos los datos

            while (!colaAuxiliar.ColaVacia())
            {
                Encolar(colaAuxiliar.DesencolarBuscar());
            }

            return datoDesencolado;
        }

        public int ElementosEnCola()
        {
            if (ColaVacia())
                return -1;
            else
            {
                Nodo Auxiliar = Principio;
                int contador = 1;
                while (Auxiliar.getSiguente() != null)
                {
                    contador++;
                    Auxiliar = Auxiliar.getSiguente();
                }
                return contador;
            }
        }

        public Cancion[] Listar()
        {
            if (ColaVacia())
                return null;
            else
            {
                int cantidadDeElementos = ElementosEnCola();
                Cancion[] lista = new Cancion[cantidadDeElementos];
                Nodo Auxiliar = Principio;
                for (int i = 0; i < cantidadDeElementos; i++)
                {
                    lista[i] = Auxiliar.getCancion();
                    Auxiliar = Auxiliar.getSiguente();
                }
                return lista;
            }
        }

        public Cancion Buscar(string buscado)
        {
            Colas colaAuxiliar = new Colas();
            Cancion instrumentoEncontrado = null;
            // Movemos los datos en auxiliar para no perder los originales
            while (!ColaVacia())
            {
                Cancion instrumentoActual = DesencolarBuscar();
                colaAuxiliar.Encolar(instrumentoActual);

                if (instrumentoActual.NombreCancion == buscado)
                {
                    instrumentoEncontrado = instrumentoActual;
                    break;
                }
            }

            // Regresamos los datos
            while (!colaAuxiliar.ColaVacia())
            {
                Encolar(colaAuxiliar.DesencolarBuscar());
            }

            return instrumentoEncontrado;
        }

        public bool Modificar(string nombreCancion, Cancion cancion)
        {
            bool encontrado = false;

            // Guardar datos en auxiliar para no perder los datos
            Colas colaAuxiliar = new Colas();

            while (!ColaVacia())
            {
                Cancion cancionActual = DesencolarBuscar();

                if (cancionActual.NombreCancion == nombreCancion)
                {
                    encontrado = true;
                    cancionActual = cancion;
                }

                colaAuxiliar.Encolar(cancionActual);
            }

            // Regresamos los datos
            while (!colaAuxiliar.ColaVacia())
            {
                Encolar(colaAuxiliar.DesencolarBuscar());
            }

            return encontrado;
        }

        public void Limpiar()
        {
            Principio = null;
            Final = null;
        }

        public void Ascendente()
        {
            if (ColaVacia() || Principio == Final)
            {
                return;
            }

            Colas colaAuxiliar = new Colas();

            while (!ColaVacia())
            {
                Cancion actual = DesencolarBuscar();

                while (!colaAuxiliar.ColaVacia() && actual.NombreCancion.CompareTo(colaAuxiliar.Principio.getCancion().NombreCancion)<0)
                {
                    Encolar(colaAuxiliar.DesencolarBuscar());
                }

                colaAuxiliar.Encolar(actual);
            }

            while (!colaAuxiliar.ColaVacia())
            {
                Encolar(colaAuxiliar.DesencolarBuscar());
            }
        }

        public void Descendente()
        {
            if (ColaVacia() || Principio == Final)
            {
                return;
            }

            Colas colaAuxiliar = new Colas();

            while (!ColaVacia())
            {
                Cancion actual = DesencolarBuscar();

                while (!colaAuxiliar.ColaVacia() && actual.NombreCancion.CompareTo(colaAuxiliar.Principio.getCancion().NombreCancion)>0)
                {
                    Encolar(colaAuxiliar.DesencolarBuscar());
                }

                colaAuxiliar.Encolar(actual);
            }

            while (!colaAuxiliar.ColaVacia())
            {
                Encolar(colaAuxiliar.DesencolarBuscar());
            }
        }

    }
}
