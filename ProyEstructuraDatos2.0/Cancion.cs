using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proy_EstructuraDatos
{
    public class Cancion
    {
        public string NombreCancion { get; set; }
        public string Interprete { get; set; }
        public string Duracion { get; set; }
        public string Genero { get; set; }

        public string ValidarCampos()
        {
            string error = "";
            if (String.IsNullOrEmpty(NombreCancion))
            {
                error += "Ingrese nombre \n";
            }
            if (String.IsNullOrEmpty(Interprete))
            {
                error += "Ingrese Interprete \n";
            }
            if (String.IsNullOrEmpty(Duracion))
            {
                error += "Ingrese Duracion \n";
            }
            if (String.IsNullOrEmpty(Genero))
            {
                error += "Ingrese Genero \n";
            }
            if (!Regex.IsMatch(NombreCancion, "^[a-zA-Z0-9]*$") || !Regex.IsMatch(Interprete, "^[a-zA-Z0-9]*$") || !Regex.IsMatch(Duracion, "^[a-zA-Z0-9]*$") || !Regex.IsMatch(Genero, "^[a-zA-Z0-9]*$"))
            {
                error += "Ingrese caracteres alfanumericos \n";
            }
            return error;
        }
    }
}
