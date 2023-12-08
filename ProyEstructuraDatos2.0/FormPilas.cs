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

namespace Proy_EstructuraDatos
{
    public partial class FormPilas : Form
    {
        Pila pilas;
        public FormPilas(Pila pilas)
        {
            this.pilas = pilas;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try { 
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
                    pilas.InsertarElemento(cancion);
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
        }

        private void btnGuardarList_Click(object sender, EventArgs e)
        {
            pnlGuardar.Visible = true;
            pnlMostrar.Visible = false;
            pnlEliminar.Visible = false;
            pnlBuscar.Visible = false;

        }

        public void MostrarCanciones()
        {
            gridCaciones.Columns.Clear();
            gridCaciones.Rows.Clear();
            pnlGuardar.Visible = false;
            pnlMostrar.Visible = true;
            pnlEliminar.Visible = false;
            pnlBuscar.Visible = false;


            gridCaciones.Columns.Add("nombreCancion", "Cancion");
            gridCaciones.Columns.Add("Interprete", "Interprete");
            gridCaciones.Columns.Add("Duracion", "Duracion");
            gridCaciones.Columns.Add("Genero", "Genero");

            for (int i = 0; i <= pilas.GetCima(); i++)
            {

                Cancion cancion = pilas.GetListaPila()[i];
                gridCaciones.Rows.Add(cancion.NombreCancion, cancion.Interprete, cancion.Duracion, cancion.Genero);

            }
        }

        private void btnMostrarList_Click(object sender, EventArgs e)
        {
            MostrarCanciones();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            //Nodo a = listas.BuscarCancion(txtCancionEliminar.Text);
            Cancion b = pilas.EliminarElemento();

            if (b != null)
            {

                MessageBox.Show("Se elimino la cancion de la pila");
            }


        }

        private void btnEliminarList_Click(object sender, EventArgs e)
        {
            pnlGuardar.Visible = false;
            pnlMostrar.Visible = false;
            pnlEliminar.Visible = true;
            pnlBuscar.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Cancion cancion = pilas.BuscarElementoPorValor(txtBuscar.Text);
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
            } catch 
            {
                MessageBox.Show("surgio un error al buscar la cancion");
            }
        }

        private void btnBuscarList_Click(object sender, EventArgs e)
        {
            pnlGuardar.Visible = false;
            pnlMostrar.Visible = false;
            pnlEliminar.Visible = false;
            pnlBuscar.Visible = true;
        }

        private void btnEditarList_Click(object sender, EventArgs e)
        {

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

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
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

                    bool res = pilas.Modificar(txtCancionEditar.Text, cancion);
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
            catch (Exception ex)
            {
                MessageBox.Show("surgio un error al guardar");
            }
        }
    }
}
