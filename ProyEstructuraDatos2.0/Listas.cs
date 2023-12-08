using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_EstructuraDatos
{
    public class Listas
    {
        Nodo primero;
        Nodo ultimo;
        public Listas()
        {
            primero = ultimo = null;
        }
        public bool ListaVacia()
        {
            if (primero == null)
            {
                return true;
            }
            return false;
        }

        public void InsertarElemento(Cancion cancion)
        {
            if (ListaVacia())
            {
                primero = new Nodo(cancion);
            }
            else
            {
                primero = new Nodo(cancion, primero);
            }

        }

        public void InsertarFinal(Cancion cancion)
        {
            if (primero == null)
            {
                primero = new Nodo(cancion);

                //primero.setCancion(cancion);
                primero.setSiguiente(null);
            }
            else
            {
                Nodo nuevo = new Nodo(cancion);
                //nuevo.setCancion();

                Nodo actual = primero;
                while (actual.getSiguente() != null)
                {
                    actual = actual.getSiguente();
                }

                actual.setSiguiente(nuevo);
            }
        }
    


    public bool eliminarPorCancion(string cancion)
        {
            if (primero == null)
            {
                return false; // La lista está vacía
            }

            Nodo actual = primero;
            Nodo anterior = null;

            while (actual != null)
            {
                if (actual.getCancion().NombreCancion == cancion)
                {
                    if (anterior != null)
                    {
                        anterior.setSiguiente(actual.getSiguente());
                    }
                    else
                    {
                        primero = actual.getSiguente();
                    }

                    return true; // Elemento encontrado y eliminado
                }

                anterior = actual;
                actual = actual.getSiguente();
            }

            return false; // Elemento no encontrado
        }

        public bool modificarPorCancion(string cancion, Cancion cancionoModificada)
        {
            Nodo actual = primero;

            while (actual != null)
            {
                if (actual.getCancion().NombreCancion == cancion)
                {
                   
                    actual._cancion = cancionoModificada;
                    return true; // Se ha modificado exitosamente
                }

                actual = actual.getSiguente();
            }

            return false; // El ID no se encontró en la lista
        }

        public void InsertarMedio(Cancion cancion)
        {
            if (ListaVacia())
            {
                primero = new Nodo(cancion, primero);
            }
            else
            {
                Nodo anterior = null;
                int iterador = 1;
                int longitud = LongitudLista();
                Nodo actual = primero;
                Console.WriteLine(longitud);
                while (actual.getSiguente() != null && iterador < longitud / 2)
                {
                    actual = actual.getSiguente();
                    iterador++;
                }
                
                anterior = actual;
                Nodo nuevo = new Nodo(cancion, actual.getSiguente());
                anterior.setSiguiente(nuevo);
            }
        }

        public int LongitudLista()
        {
            int contador = 0;
            if (ListaVacia())
            {
                return contador;
            }
            else
            {
                Nodo actual = primero;
                if (actual.getSiguente() == null)
                {
                    return (contador + 1);
                }
                else
                {

                    while (actual.getSiguente() != null)
                    {
                        contador++;
                        actual = actual.getSiguente();
                    }
                    return contador + 1;
                }
            }
        }

        public void ImprimirLista()
        {
            if (ListaVacia())
            {
                Console.WriteLine("Lista Vacia");
            }
            else
            {
                Nodo actual = primero;
                while (actual != null)
                {
                   
                    actual = actual.getSiguente();
                }
                Console.WriteLine("--> null");

            }
        }

        public int BuscarPosicion(string cancion)
        {
            int cont = 0;
            //checar primero si la lista esta vacia o si hay elementos 
            if (ListaVacia())
            {
                Console.WriteLine("La lista esta vacia");
            }
            else
            {
                Nodo actual = primero;
                while (actual != null)
                {
                    cont++;

                    if (actual.getCancion().NombreCancion == cancion)
                    {
                        cont++;
                    }
                    else
                    {
                        actual = actual.getSiguente();
                    }
                }   
            }
            return cont;
        }
        public Nodo getPrimero() { return primero; }


    
        public Nodo BuscarCancion(string cancion)
        {
            Nodo i, encontrado;
            i = primero;
            encontrado = null;
            while (i != null)
            {
                if (i.getCancion().NombreCancion == cancion)
                {
                    encontrado = i;
                    break;
                }
                else
                {
                    //p = i;
                    i = i.getSiguente();
                }
            }
            return (encontrado);
        }

        public void OrdenarDecendente()
        {
            if (ListaVacia())
            {
                MessageBox.Show("la lista esta vacia");
            }
            else
            {
                bool terminado;
                Nodo temporal;
                do
                {
                    terminado = false;
                    Nodo actual = primero;
                    Nodo siguiente = primero.getSiguente();

                    while (siguiente != null)
                    {
                        if (actual.getCancion().NombreCancion.CompareTo(siguiente.getCancion().NombreCancion)<0)
                        {
                            // Intercambiar los datos de las canciones
                            temporal = new Nodo(actual.getCancion());
                            actual.setCancion(siguiente.getCancion());
                            siguiente.setCancion(temporal.getCancion());

                            terminado = true;
                        }

                        actual = siguiente;
                        siguiente = siguiente.getSiguente();
                    }
                } while (terminado);
            }
        }

        public void OrdenarAcendente()
        {
            if (ListaVacia())
            {
                MessageBox.Show("la lista esta vacia");
            }
            else
            {
                bool terminado;
                Nodo temporal;
                do
                {
                    terminado = false;
                    Nodo actual = primero;
                    Nodo siguiente = primero.getSiguente();

                    while (siguiente != null)
                    {
                        if (actual.getCancion().NombreCancion.CompareTo(siguiente.getCancion().NombreCancion)>0)
                        {
                            // Intercambiar los datos de las canciones
                            temporal = new Nodo(actual.getCancion());
                            actual.setCancion(siguiente.getCancion());
                            siguiente.setCancion(temporal.getCancion());

                            terminado = true;
                        }

                        actual = siguiente;
                        siguiente = siguiente.getSiguente();
                    }
                } while (terminado);
            }
        }

    }
}
