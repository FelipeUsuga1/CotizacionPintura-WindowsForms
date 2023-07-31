using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libPunto6
{
    public class clsCalcular
    {
        #region "Atributos"
        private float fltValAncho;
        private float fltMedAncho;
        private float fltValLargo;
        private float fltMedLargo;
        private float fltVCu;
        private int intNumCu;
        private float fltVCo;
        private int intNumCo;
        private float fltVTe;
        private int intNumTe;
        private float fltPIva;
        private float fltPReteFte;
        private float fltValTotal;
        private string strError;

        #endregion

        #region "Constructor"
        public clsCalcular() {
            fltValAncho = 0;
            fltMedAncho = 0;
            fltValLargo = 0;
            fltMedLargo = 0;
            fltVCu = 0;
            intNumCu = 0;
            fltVCo = 0;
            intNumCo = 0;
            fltVTe = 0;
            intNumTe = 0;
            fltPIva = 0;
            fltPReteFte = 0;
            fltValTotal = 0;
            strError = string.Empty;
        }

        #endregion

        #region "Propiedades"

        public float valAncho
        {
            set { fltValAncho = value; }
        }

        public float medAncho
        {
            set { fltMedAncho = value; }
        }


        public float valLargo
        {
            set { fltValLargo = value; }
        }


        public float medLargo
        {
            set { fltMedLargo = value; }
        }


        public float vCu
        {
            set { fltVCu = value; }
        }


        public int numCu
        {
            set { intNumCu = value; }
        }


        public float vCo
        {
            set { fltVCo = value; }
        }


        public int numCo
        {
            set { intNumCo = value; }
        }

        public float vTe
        {
            set { fltVTe = value; }
        }

        public int numTe
        {
            set { intNumTe = value; }
        }

        public float pIva
        {
            set { fltPIva = value; }
        }

        public float pReteFte
        {
            set { fltPReteFte = value; }
        }

        public float valTotal
        {
            get { return fltValTotal; }
        }

        public string Error
        {
            get { return strError; }
        }

        #endregion

        #region "Metodos privados"

        private bool Validar() {

            if (fltValAncho <= 0 || fltValLargo <= 0 || fltMedAncho <= 0 || fltMedLargo <= 0)
            {
                strError = "Error, valores o medidas de ancho y largo nno validos";
                return false;
            }

            if (fltVCu <= 0 || fltVCo <= 0 || fltVTe <= 0 || intNumCu <= 0 || intNumCo <= 0 || intNumTe <= 0)
            {
                strError = "Error, valor o numero de componentes del fondo no valido";
                return false;
            }

            if (fltPIva < 0 || fltPReteFte < 0)
            {
                strError = "Error, porcentaje de Iva o retencion en la fuente no valido";
                return false;
            }

            return true;
        }

        #endregion

        #region "Metodos publicos"
        public bool calcular() {
            float fltValIva;
            float valPRetFte;
            float fltSubTotal;
            float fltValFondo;
            float fltValTancho;
            float fltValTlargo;

            try
            {

                if (!Validar())
                    return false;
                fltValFondo = (fltVCu*intNumCu) + (fltVCo * intNumCo) + (fltVTe * intNumTe);
                fltValTancho = (fltValAncho*fltMedAncho);
                fltValTlargo = (fltValLargo * fltMedAncho);
                fltSubTotal = fltValFondo + fltValTancho + fltValTlargo;
                fltValIva = fltSubTotal * fltPIva / 100;
                valPRetFte = fltSubTotal * fltPReteFte/ 100;
                fltValTotal = fltSubTotal + fltValIva + valPRetFte;
                return true;
            }
            catch (Exception ex) {
                strError = ex.Message;
                return false;
            }
        }

       #endregion
    }
}
