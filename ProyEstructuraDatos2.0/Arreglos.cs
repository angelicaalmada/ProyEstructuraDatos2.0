using Proy_EstructuraDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyEstructuraDatos2._0
{
    public class Arreglos
    {
        private Cancion[] canciones = new Cancion[100];
        private int totalCanciones = 0;

        public bool GuardarCancion(Cancion cancion)
        {
            // Verifica si hay espacio disponible en los arreglos
            if (totalCanciones < canciones.Length)
            {

                canciones[totalCanciones] = cancion;
                totalCanciones++;

              return true;
            }
            else
            {
                return false;
            }
        }

        public bool InsertarMedio(Cancion cancion)
        {
            try
            {
                int primerEspacioVacio = 0;
                while (canciones[primerEspacioVacio] != null)
                {
                    primerEspacioVacio++;
                }

                int medio = 0;
                medio = totalCanciones / 2;

                for (int i = primerEspacioVacio - 1; i >= medio; i--)
                {
                    canciones[i + 1] = canciones[i];
                }


                //for (int i = medio; i < totalCanciones+1; i++)
                //{
                //    if (i == medio)
                //    {
                //        Cancion aux = canciones[i];
                //        canciones[i] = cancion;
                //    }
                //}
                canciones[medio] = cancion;
                totalCanciones++;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertarInicio(Cancion cancion)
        {
            try
            {
                int primerEspacioVacio = 0;
                while (canciones[primerEspacioVacio] != null)
                {
                    primerEspacioVacio++;
                }

                // Desplaza todos los elementos hacia la derecha a partir del último elemento no nulo
                for (int i = primerEspacioVacio - 1; i >= 0; i--)
                {
                    canciones[i + 1] = canciones[i];
                }

                // Ahora puedes colocar el nuevo elemento en el primer espacio vacío
                canciones[0] = cancion;
                totalCanciones++;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Cancion[] Listar()
        {
            Cancion[] listarcanciones = new Cancion[totalCanciones];
            for (int i = 0; i < totalCanciones; i++)
            {
                listarcanciones[i] = canciones[i];
            }
            return listarcanciones;
        }

        public bool EliminarCancion(string nombreCancion)
        {
            int indiceCancion = -1;

            // Busca el índice de la canción a eliminar
            for (int i = 0; i < totalCanciones; i++)
            {
                if (canciones[i].NombreCancion == nombreCancion)
                {
                    indiceCancion = i;
                    break;
                }
            }

            if (indiceCancion != -1)
            {
                // "Elimina" la canción estableciendo sus valores a null (o cualquier valor que indique eliminación)

                for (int a = indiceCancion; a < canciones.Length - 1; a++)
                {
                    // moving elements downwards, to fill the gap at [index]
                    canciones[a]= canciones[a + 1];                 

                }

                totalCanciones--;
                return true;
            }

            // Indica que la canción no se encontró
            return false;

        }

        public Cancion BuscarCancion(string nombreABuscar)
        {
         
            Cancion cancion = null;

            // Verifica si hay canciones almacenadas
            if (totalCanciones > 0)
            {
                // Busca la canción por nombre
                for (int i = 0; i < totalCanciones; i++)
                {
                    if (canciones[i].NombreCancion.Equals(nombreABuscar, StringComparison.CurrentCultureIgnoreCase))
                    {
                       
                        cancion = canciones[i];
                        break; 
                    }
                }             
            }
            return cancion;
        }

        public bool ModificarCancion(Cancion cancionModificar)
        {
            bool modificado = false;
           

            // Verifica si hay canciones almacenadas
            if (totalCanciones > 0)
            {
                // Busca la canción por nombre
                for (int i = 0; i < totalCanciones; i++)
                {
                    if (canciones[i].NombreCancion.Equals(cancionModificar.NombreCancion, StringComparison.CurrentCultureIgnoreCase))
                    {

                        canciones[i] = cancionModificar;
                        modificado=true;
                        break;
                    }
                }
            }
            return modificado;
        }

        public void OrdenarDecendente()
        {

            // Implementación de la ordenación descendente usando el método de burbuja
            int n = totalCanciones;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    // Comparar los años de las películas y swap si es necesario
                    if (canciones[j].NombreCancion.CompareTo(canciones[j + 1].NombreCancion)<0)
                    {
                        Cancion temp = canciones[j];
                        canciones[j] = canciones[j + 1];
                        canciones[j + 1] = temp;
                    }
                }
            }
        }
        public void OrdenarAscendente()
        {
            // Implementación de la ordenación descendente usando el método de burbuja
            int n = totalCanciones;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    // Comparar los años de las películas y swap si es necesario
                    if (canciones[j].NombreCancion.CompareTo(canciones[j + 1].NombreCancion)>0)
                    {
                        Cancion temp = canciones[j];
                        canciones[j] = canciones[j + 1];
                        canciones[j + 1] = temp;
                    }
                }
            }
        }

    }
}
