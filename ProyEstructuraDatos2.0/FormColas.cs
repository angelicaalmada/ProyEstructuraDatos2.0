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
    public partial class FormColas : Form
    {
        Colas colas;
        public FormColas(Colas colas)
        {
            this.colas = colas;
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
                    colas.Encolar(cancion);
                    MessageBox.Show("Se guardo con exito");
                    MostrarCanciones();
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

            MostrarCanciones();

        }

        public void MostrarCanciones()
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
            foreach (DataGridViewColumn column in gridCaciones.Columns)
            {
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            }


            Cancion[] canciones = colas.Listar();
            for (int i = 0; i < canciones.Length; i++)
            {
                gridCaciones.Rows.Add(canciones[i].NombreCancion, canciones[i].Interprete, canciones[i].Duracion, canciones[i].Genero);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                ////Nodo a = listas.BuscarCancion(txtCancionEliminar.Text);
                //Nodo b = listas.BuscarNodo(txtCancionEliminar.Text);
                //bool elimino = true;//colas.Desencolar(txtCancionEliminar.Text);
                Cancion ccancion = colas.Pop();
                if (ccancion != null)
                {
                    MessageBox.Show("Se elimino la cancion");
                }
                else
                {
                    MessageBox.Show("no se elimino la cancion");
                }
            }
            catch
            {
                MessageBox.Show("error al eliminar cancion");
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
            Cancion cancion = colas.Buscar(txtBuscar.Text);
            if (cancion != null)
            {
                txtBInterprete.Text = cancion.Interprete;
                txtBDuracion.Text = cancion.Duracion;
                txtBGenero.Text = cancion.Genero;
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
            Cancion cancion = colas.Buscar(txtCancionEditar.Text);
            if (cancion != null)
            {
                txtInterpreteEditar.Text = cancion.Interprete;
                txtDuracionEditar.Text = cancion.Duracion;
                txtGeneroEditar.Text = cancion.Genero;
            }
            else
            {
                MessageBox.Show("no se encontro la cancion");
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {

            Cancion cancion = new Cancion();
            cancion.NombreCancion = txtCancionEditar.Text;
            cancion.Duracion = txtDuracionEditar.Text;
            cancion.Genero = txtGeneroEditar.Text;
            cancion.Interprete = txtInterpreteEditar.Text;

            string msg = cancion.ValidarCampos();
            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
            }
            else
            {

                bool res = colas.Modificar(txtCancionEditar.Text, cancion);
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
                MostrarCanciones();
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

    }
}
