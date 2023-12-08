using ProyEstructuraDatos2._0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Proy_EstructuraDatos
{
    public partial class FormListas : Form
    {
        Listas listas;
        public FormListas(Listas listas)
        {
            this.listas = listas;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cancion cancion = new Cancion();
                cancion.NombreCancion = txtCancion.Text;
                cancion.Duracion = txtDuracion.Text;
                cancion.Genero = txtGenero.Text;
                cancion.Interprete = txtInterprete.Text;
                string msg = cancion.ValidarCampos();
                if (!String.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);
                }
                else
                {

                    listas.InsertarFinal(cancion);
                    MessageBox.Show("Se guardo con exito");
                    mostrar();
                    Limpiar();
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

            mostrar();

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ////Nodo a = listas.BuscarCancion(txtCancionEliminar.Text);
            //Nodo b = listas.BuscarNodo(txtCancionEliminar.Text);
            bool elimino = listas.eliminarPorCancion(txtCancionEliminar.Text);
            if (elimino == true)
            {
                txtCancionEliminar.Text = "";
                MessageBox.Show("Se elimino la cancion");
            }
            else
            {
                MessageBox.Show("no se elimino la cancion");
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
            Nodo nodo = listas.BuscarCancion(txtBuscar.Text);
            if (nodo != null)
            {
                txtBInterprete.Text = nodo.getCancion().Interprete;
                txtBDuracion.Text = nodo.getCancion().Duracion;
                txtBGenero.Text = nodo.getCancion().Genero;
            }
            else
            {
                MessageBox.Show("no se encontro la cancion");
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

        private void btnBuscarEditar_Click(object sender, EventArgs e)
        {
            Nodo nodo = listas.BuscarCancion(txtCancionEditar.Text);
            if (nodo != null)
            {
                txtInterpreteEditar.Text = nodo.getCancion().Interprete;
                txtDuracionEditar.Text = nodo.getCancion().Duracion;
                txtGeneroEditar.Text = nodo.getCancion().Genero;
            }
            else
            {
                MessageBox.Show("no se encontro la cancion");
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {

                Cancion cancion = new Cancion();
                cancion.NombreCancion = txtCancionEditar.Text;
                cancion.Duracion = txtDuracionEditar.Text;
                cancion.Genero = txtGeneroEditar.Text;
                cancion.Interprete = txtInterpreteEditar.Text;
                bool res = listas.modificarPorCancion(txtCancionEditar.Text, cancion);
                if (res)
                {
                    MessageBox.Show("se guardaron los cambios");
                }
                else
                {
                    MessageBox.Show("no se guardaron los cambios");
                }

                pnlModificar.Visible = false;
                Limpiar();
                mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Canción no encontrada o ocurrió un error al eliminar.");
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
            listas.OrdenarAcendente();
            mostrar();
        }

        private void btnOrdDesendente_Click(object sender, EventArgs e)
        {
            listas.OrdenarDecendente();
            mostrar();
        }

        public void mostrar()
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

            Nodo actual = listas.getPrimero();
            while (actual != null)
            {
                gridCaciones.Rows.Add(actual.getCancion().NombreCancion, actual.getCancion().Interprete, actual.getCancion().Duracion, actual.getCancion().Genero);
                actual = actual.getSiguente();
            }
        }

        private void btnEliminarSel_Click(object sender, EventArgs e)
        {
            try
            {
                bool cancionEliminada = listas.eliminarPorCancion(txtCancionEditar.Text);

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
                mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Canción no encontrada o ocurrió un error al eliminar.");
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cancion cancion = new Cancion();
                cancion.NombreCancion = txtCancion.Text;
                cancion.Duracion = txtDuracion.Text;
                cancion.Genero = txtGenero.Text;
                cancion.Interprete = txtInterprete.Text;
                string msg = cancion.ValidarCampos();
                if (!String.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);
                }
                else
                {

                    listas.InsertarMedio(cancion);
                    MessageBox.Show("Se guardo con exito");
                    mostrar();
                    Limpiar();
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

        private void btnGuardarPrincipio_Click(object sender, EventArgs e)
        {
            try
            {
                Cancion cancion = new Cancion();
                cancion.NombreCancion = txtCancion.Text;
                cancion.Duracion = txtDuracion.Text;
                cancion.Genero = txtGenero.Text;
                cancion.Interprete = txtInterprete.Text;
                string msg = cancion.ValidarCampos();
                if (!String.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);
                }
                else
                {

                    listas.InsertarElemento(cancion);
                    MessageBox.Show("Se guardo con exito");
                    mostrar();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("surgio un error al guardar");
            }
        }
    }
}
