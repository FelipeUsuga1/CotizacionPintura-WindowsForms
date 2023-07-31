using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libPunto6;

namespace Punto6
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtValAncho.Text = String.Empty;
            this.txtMedAncho.Text = String.Empty;
            this.txtValLargo.Text = String.Empty;
            this.txtMedLargo.Text = String.Empty;
            this.txtVcu.Text = String.Empty;
            this.txtNumCu.Text = String.Empty;
            this.txtVco.Text = String.Empty;
            this.txtNumCo.Text = String.Empty;
            this.txtVt.Text = String.Empty;
            this.txtNumT.Text = String.Empty;
            this.txtPiva.Text = String.Empty;
            this.txtReteFte.Text = String.Empty;
            this.lbTotalPagar.Text = String.Empty;
            this.grbAPagar.Visible = false;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            float fltValAncho;
            float fltMedAncho;
            float fltValLargo;
            float fltMedLargo;
            float fltVCu;
            int intNumCu;
            float fltVCo;
            int intNumCo;
            float fltVTe;
            int intNumTe;
            float fltPIva;
            float fltPReteFte;

            try {

                fltValAncho = Convert.ToSingle(this.txtValAncho.Text);
                fltMedAncho = Convert.ToSingle(this.txtMedAncho.Text);
                fltValLargo = Convert.ToSingle(this.txtValLargo.Text);
                fltMedLargo = Convert.ToSingle(this.txtMedLargo.Text);
                fltVCu = Convert.ToSingle(this.txtVcu.Text);
                intNumCu = Convert.ToInt32(this.txtNumCu.Text);
                fltVCo = Convert.ToSingle(this.txtVco.Text);
                intNumCo = Convert.ToInt32(this.txtNumCo.Text);
                fltVTe = Convert.ToSingle(this.txtVt.Text);
                intNumTe = Convert.ToInt32(this.txtNumT.Text);
                fltPIva = Convert.ToSingle(this.txtPiva.Text);
                fltPReteFte = Convert.ToSingle(this.txtReteFte.Text);

                //Crear la instancia de clase = crear el objeto

                clsCalcular clCal = new clsCalcular();

                //Envio de la info de la Clase

                clCal.valAncho = fltValAncho;
                clCal.medAncho = fltMedAncho;
                clCal.valLargo = fltValLargo;
                clCal.medLargo = fltMedLargo;
                clCal.vCu = fltVCu;
                clCal.numCu = intNumCu;
                clCal.vCo = fltVCo;
                clCal.numCo = intNumCo;
                clCal.vTe = fltVTe;
                clCal.numTe = intNumTe;
                clCal.pIva = fltPIva;
                clCal.pReteFte = fltPReteFte;

                //Invocacion del Metodo y Tratamiento del error
                if (!clCal.calcular())
                {
                    MessageBox.Show(clCal.Error);
                    clCal = null; // opcional
                    return;
                }  

                //Mostrar info
                this.lbTotalPagar.Text = clCal.valTotal.ToString();
                this.grbAPagar.Visible = true;

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
