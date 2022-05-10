using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Domain.Entidades_Negocio;

namespace Presentation.Alumnos
{
    public partial class Details : System.Web.UI.Page
    {
        public Alumno _alumno = new Alumno();
        public NAlumno _nAlumno=new NAlumno();
        public NEstatus _nestatus = new NEstatus();
        public NEstado _nestado = new NEstado();
        public NItemISR _nitemISR = new NItemISR();
        public NISRResult _nISRResult = new NISRResult();
        public NIMSS _nimss= new NIMSS();
        public IMSS _Imss=new IMSS();
        public List<Estado> _estadoList = new List<Estado>();
        public List<EstatusAlumnos> _estatusList = new List<EstatusAlumnos>();
        public ItemISR _itemISR = new ItemISR();
        public List<ItemISR> _itemISRList = new List<ItemISR>();
        public ISRResult _ISRResult = new ISRResult();
        public List<ISRResult> _ISRResultList = new List<ISRResult>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                string Valor = Request.QueryString["valor"];
                int id = Convert.ToInt32(Valor);
                LlenarDatos(id);
            }
        }
        public void LlenarDatos(int id)
        {
            _alumno=_nAlumno.Consultar(id);
            lblId.Text = Convert.ToString(_alumno.ID);
            lblNom.Text = _alumno.Nombre;
            lblPrA.Text = _alumno.PrimerApellido;
            lblSdoA.Text = _alumno.SegundoApellido;
            lblfN.Text=_alumno.FechaNacimiento.ToString();
            lblCurp.Text = _alumno.CURP;
            lblCorre.Text = _alumno.Correo;
            lblTel.Text = _alumno.Telefono;
            lblSueldo.Text=_alumno.SueldoMensual.ToString();
            _estadoList = _nestado.Consultar();
            var resultado = from estado in _estadoList
                            where estado.ID == _alumno.IdEstadoOrig
                            select new
                            {
                                Nombre = estado.Nombre
                                            };
            foreach (var estado in resultado)
            {
                lblEstado.Text = estado.Nombre.ToString();
            }
            _estatusList = _nestatus.Consultar();
            var rEstatus = from estatus in _estatusList
                           where estatus.ID == _alumno.IdEstatus
                           select new
                           {
                               Nombre = estatus.Nombre
                           };

            foreach(var estatus in rEstatus)
            {
                lblEstts.Text = estatus.Nombre.ToString();
            }
        }
        public void LlenarDISR()
        {
            lblLiminf.Text=_itemISR.LimInf.ToString();
            lblLimSup.Text=_itemISR.LimSup.ToString();
            lblCuotFij.Text=_itemISR.CuotaFija.ToString();
            excedLimInf.Text=_itemISR.PorExced.ToString();
            lblSubsid.Text=_itemISR.Subcidio.ToString();
            lblImpuest.Text=_ISRResult.Impuesto.ToString();
        }

        //protected void btnCalIMSS_Click(object sender, EventArgs e)
        //{
        //    decimal sueldo = Convert.ToDecimal(lblSueldo.Text);
        //    _Imss = _nimss.Calcular(sueldo);
        //    LlenarDIMSS();
        //}
        //public void LlenarDIMSS()
        //{
        //    lblEnfMat.Text=_Imss.EnfyMat.ToString();
        //    lblInvyVid.Text=_Imss.InvyVid.ToString();
        //    lblRetiro.Text=_Imss.Retiro.ToString();
        //    lblCesantia.Text=_Imss.Cesantia.ToString();
        //    lblInfona.Text=_Imss.CreditoInf.ToString();
        //}

        protected void btnOpenPopUp_Click(object sender, EventArgs e)
        {
            decimal sueldo = Convert.ToDecimal(lblSueldo.Text);
            int id = Convert.ToInt32(lblId.Text);

            try
            {
                _itemISR = _nitemISR.WebCalcularISR(id);

            }
            catch (Exception ex)
            {
                _itemISR = _nitemISR.CalcularISR(id);
            }
            decimal sueldQ = sueldo / 2;
            _ISRResult = _nISRResult.Calcular(_itemISR, sueldQ);
            LlenarDISR();
            mpePopUp.Show();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            mpePopUp.Hide();
        }
    }
}