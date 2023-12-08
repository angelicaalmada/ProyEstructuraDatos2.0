using ProyEstructuraDatos2._0;

namespace Proy_EstructuraDatos
{
    public partial class Form1 : Form
    { //aqui envia su respectiva variable a cada form y se crea un constructor en cada clase para recibirla
        Arreglos arreglos = new Arreglos();
        Listas listas = new Listas();
        Pila pilas = new Pila();
        Colas colas = new Colas();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormArreglo formArreglos = new FormArreglo(arreglos);
            formArreglos.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormListas formListas = new FormListas(listas);
            formListas.ShowDialog();
        }
        private void btnPilas_Click(object sender, EventArgs e)
        {
            FormPilas formPilas = new FormPilas(pilas);
            formPilas.ShowDialog();
        }
        private void btnColas_Click(object sender, EventArgs e)
        {
            FormColas formColas = new FormColas(colas);
            formColas.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}