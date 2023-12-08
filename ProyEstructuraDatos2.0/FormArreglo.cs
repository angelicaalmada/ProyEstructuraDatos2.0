using ProyEstructuraDatos2._0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Proy_EstructuraDatos
{
    public partial class FormArreglo : Form
    {


        Arreglos arreglos;
        //se crea el constructor
        public FormArreglo(Arreglos arreglos)
        {
            this.arreglos = arreglos;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Aquí puedes obtener los datos de la canción desde tus cuadros de texto u otros controles
                Cancion cancion = new Cancion();
                cancion.NombreCancion = txtCancion.Text;
                cancion.Interprete = txtInterprete.Text;
                cancion.Duracion = txtDuracion.Text;
                cancion.Genero = txtGenero.Text;
                string msg = cancion.ValidarCampos();
                if (!String.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);
                }
                else
                {

                    bool respuesta = arreglos.GuardarCancion(cancion);
                    if (respuesta == true)
                    {
                        MessageBox.Show("Canción guardada exitosamente.", "Guardar Canción");
                        MostrarGridCanciones();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se guardo la cancion.", "Guardar Canción");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("surgio un error al guardar");
            }
        }



        private void Limpiar()
        {
            txtCancion.Text = "";
            txtDuracion.Text = "";
            txtGenero.Text = "";
            txtInterprete.Text = "";
            txtCancionEditar.Text = "";
            txtDuracionEditar.Text = "";
            txtGeneroEditar.Text = "";
            txtInterpreteEditar.Text = "";
        }

        private void btnGuardarList_Click(object sender, EventArgs e)
        {
            pnlGuardar.Visible = true;
            pnlMostrar.Visible = false;
            pnlEliminar.Visible = false;
            pnlBuscar.Visible = false;
            pnlEditar.Visible = false;

        }

        private void btnMostrarList_Click(object sender, EventArgs e)
        {
            MostrarGridCanciones();


            //for (int i = 0; i <= pilas.GetCima(); i++)
            //{

            //    Cancion cancion = pilas.GetListaPila()[i];
            //    gridCaciones.Rows.Add(cancion.NombreCancion, cancion.Interprete, cancion.Duracion, cancion.Genero);





        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreCancion = txtCancionEliminar.Text;
                // Llama al método EliminarCancion con los valores adecuados
                bool cancionEliminada = arreglos.EliminarCancion(nombreCancion);

                // Proporciona retroalimentación al usuario según el resultado
                if (cancionEliminada)
                {
                    MessageBox.Show("¡Canción eliminada correctamente!");
                    txtCancionEliminar.Text = "";
                }
                else
                {
                    MessageBox.Show("Canción no encontrada o ocurrió un error al eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Canción no encontrada o ocurrió un error al eliminar.");
            }


        }



        private void btnEliminarList_Click(object sender, EventArgs e)
        {
            pnlGuardar.Visible = false;
            pnlMostrar.Visible = false;
            pnlEliminar.Visible = true;
            pnlBuscar.Visible = false;
            pnlEditar.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                // Aquí puedes obtener el nombre de la canción a buscar, por ejemplo, desde un cuadro de texto.
                string nombreABuscar = txtBuscar.Text;

                Cancion cancion = arreglos.BuscarCancion(nombreABuscar);
                if (cancion != null)
                {
                    txtBInterprete.Text = cancion.Interprete;
                    txtBDuracion.Text = cancion.Duracion;
                    txtBGenero.Text = cancion.Genero;
                }
                else
                {
                    MessageBox.Show($"La canción '{nombreABuscar}' no fue encontrada.", "Buscar Canción");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("surgio un error al buscar");
            }

        }



        private void btnBuscarList_Click(object sender, EventArgs e)
        {
            pnlGuardar.Visible = false;
            pnlMostrar.Visible = false;
            pnlEliminar.Visible = false;
            pnlBuscar.Visible = true;
            pnlEditar.Visible = false;
        }

        private void FormArreglo_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarEditar_Click(object sender, EventArgs e)
        {
            string nombreABuscar = txtCancionEditar.Text;

            Cancion cancion = arreglos.BuscarCancion(nombreABuscar);
            if (cancion != null)
            {
                txtInterpreteEditar.Text = cancion.Interprete;
                txtDuracionEditar.Text = cancion.Duracion;
                txtGeneroEditar.Text = cancion.Genero;
            }
            else
            {
                MessageBox.Show($"La canción '{nombreABuscar}' no fue encontrada.", "Buscar Canción");
            }


        }



        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            Cancion cancion = new Cancion();
            cancion.NombreCancion = txtCancionEditar.Text;
            cancion.Interprete = txtInterpreteEditar.Text;
            cancion.Duracion = txtDuracionEditar.Text;
            cancion.Genero = txtGeneroEditar.Text;
            string msg = cancion.ValidarCampos();
            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
            }
            else
            {
                bool result = arreglos.ModificarCancion(cancion);
                if (result == true)
                {
                    MessageBox.Show("se guardaron los cambios");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se guardaron los cambios");
                }

                pnlModificar.Visible = false;
                Limpiar();
                MostrarGridCanciones();
            }


        }

        private void btnEditarList_Click(object sender, EventArgs e)
        {
            pnlGuardar.Visible = false;
            pnlMostrar.Visible = false;
            pnlEliminar.Visible = false;
            pnlBuscar.Visible = false;
            pnlEditar.Visible = true;
        }

        private void btnOrdAscendente_Click(object sender, EventArgs e)
        {
            arreglos.OrdenarAscendente();
            MostrarGridCanciones();
        }

        private void btnOrdDesendente_Click(object sender, EventArgs e)
        {
            arreglos.OrdenarDecendente();
            MostrarGridCanciones();
        }
        private void MostrarGridCanciones()
        {
            gridCaciones.Columns.Clear();
            gridCaciones.Rows.Clear();
            pnlGuardar.Visible = false;
            pnlMostrar.Visible = true;
            pnlEliminar.Visible = false;
            pnlBuscar.Visible = false;
            pnlEditar.Visible = false;

            gridCaciones.Columns.Add("nombreCancion", "Cancion");
            gridCaciones.Columns.Add("Interprete", "Interprete");
            gridCaciones.Columns.Add("Duracion", "Duracion");
            gridCaciones.Columns.Add("Genero", "Genero");

            Cancion[] canciones = arreglos.Listar();

            if (canciones.Length > 0)
            {

                for (int i = 0; i < canciones.Length; i++)
                {
                    gridCaciones.Rows.Add(canciones[i].NombreCancion, canciones[i].Interprete, canciones[i].Duracion, canciones[i].Genero);
                }


            }
            else
            {
                MessageBox.Show("No hay canciones almacenadas.", "Canciones guardadas");
            }
        }

        private void btnGuardarMedio_Click(object sender, EventArgs e)
        {
            try
            {
                // Aquí puedes obtener los datos de la canción desde tus cuadros de texto u otros controles
                Cancion cancion = new Cancion();
                cancion.NombreCancion = txtCancion.Text;
                cancion.Interprete = txtInterprete.Text;
                cancion.Duracion = txtDuracion.Text;
                cancion.Genero = txtGenero.Text;
                string msg = cancion.ValidarCampos();
                if (!String.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);
                }
                else
                {

                    bool respuesta = arreglos.InsertarMedio(cancion);
                    if (respuesta == true)
                    {
                        MessageBox.Show("Canción guardada exitosamente.", "Guardar Canción");
                        MostrarGridCanciones();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se guardo la cancion.", "Guardar Canción");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("surgio un error al guardar");
            }
        }

        private void btnGuardarInicio_Click(object sender, EventArgs e)
        {
            try
            {
                // Aquí puedes obtener los datos de la canción desde tus cuadros de texto u otros controles
                Cancion cancion = new Cancion();
                cancion.NombreCancion = txtCancion.Text;
                cancion.Interprete = txtInterprete.Text;
                cancion.Duracion = txtDuracion.Text;
                cancion.Genero = txtGenero.Text;
                string msg = cancion.ValidarCampos();
                if (!String.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);
                }
                else
                {

                    bool respuesta = arreglos.InsertarInicio(cancion);
                    if (respuesta == true)
                    {
                        MessageBox.Show("Canción guardada exitosamente.", "Guardar Canción");
                        MostrarGridCanciones();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se guardo la cancion.", "Guardar Canción");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("surgio un error al guardar");
            }
        }

        private void gridCaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int colindex = e.ColumnIndex;
            int rowEdit = e.RowIndex;
            if (colindex < 0)
            {
                Cancion cancion = new Cancion();
                txtCancionEditar.Text = gridCaciones.Rows[rowEdit].Cells[0].Value.ToString();
                txtInterpreteEditar.Text = gridCaciones.Rows[rowEdit].Cells[1].Value.ToString();
                txtDuracionEditar.Text = gridCaciones.Rows[rowEdit].Cells[2].Value.ToString();
                txtGeneroEditar.Text = gridCaciones.Rows[rowEdit].Cells[3].Value.ToString();

                pnlModificar.Visible = true;

            }

        }

        private void btnEliminarSel_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreCancion = txtCancionEditar.Text;
                // Llama al método EliminarCancion con los valores adecuados
                bool cancionEliminada = arreglos.EliminarCancion(nombreCancion);

                // Proporciona retroalimentación al usuario según el resultado
                if (cancionEliminada)
                {
                    MessageBox.Show("¡Canción eliminada correctamente!");
                    txtCancionEditar.Text = "";
                }
                else
                {
                    MessageBox.Show("Canción no encontrada o ocurrió un error al eliminar.");
                }
                pnlModificar.Visible = false;
                Limpiar();
                MostrarGridCanciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Canción no encontrada o ocurrió un error al eliminar.");
            }


        }

        private void pnlMostrar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
