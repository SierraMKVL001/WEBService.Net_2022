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
    public partial class Edit : System.Web.UI.Page
    {
        Alumno _alumno = new Alumno();
        public NEstado _nestado = new NEstado();
        public NAlumno _nalumno = new NAlumno();
        public NEstatus _nestatus = new NEstatus();
        public List<Estado> _estadoList = new List<Estado>();
        public List<EstatusAlumnos> _estatusList = new List<EstatusAlumnos>();
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                CargarEstados();
                CargarEstatus();
                string Valor = Request.QueryString["valor"];
                id = Convert.ToInt32(Valor);
                LlenarDatos(id);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = Convert.ToInt32(txbId.Text);
                string nombre = txbNombre.Text;
                string primerA = txbPA.Text;
                string segundoA = txbSA.Text;
                DateTime fNac = Convert.ToDateTime(txbFN.Text);
                string curp = txbCurp.Text;
                string correo = txbCorr.Text;
                string telefono = txbTel.Text;
                decimal sueldo = Convert.ToDecimal(txbSueldo.Text);
                int idEdo = int.Parse(ddlEstados.SelectedValue);
                int idEsta = int.Parse(ddlEstatus.SelectedValue);
                _alumno = new Alumno(id, nombre, primerA, segundoA, correo, telefono, fNac, curp, sueldo,
                    idEdo, idEsta);
                _nalumno.Actualizar(_alumno);
                Response.Redirect("Index.aspx");
            }
        }
        public void CargarEstados()
        {
            _estadoList = _nestado.Consultar();
            ddlEstados.DataSource = _estadoList;
            ddlEstados.DataTextField = "Nombre";
            ddlEstados.DataValueField = "ID";
            ddlEstados.DataBind();
        }
        public void CargarEstatus()
        {
            _estatusList = _nestatus.Consultar();
            ddlEstatus.DataSource = _estatusList;
            ddlEstatus.DataTextField = "Nombre";
            ddlEstatus.DataValueField = "ID";
            ddlEstatus.DataBind();
        }
        public void LlenarDatos(int id)
        {
                _alumno = _nalumno.Consultar(id);
                txbId.Text = Convert.ToString(_alumno.ID);
                txbNombre.Text = _alumno.Nombre;
                txbPA.Text = _alumno.PrimerApellido;
                txbSA.Text = _alumno.SegundoApellido;
                txbFN.Text = _alumno.FechaNacimiento.Date.ToString("yyyy-MM-dd");
                txbCurp.Text = _alumno.CURP;
                txbCorr.Text = _alumno.Correo;
                txbTel.Text = _alumno.Telefono;
                txbSueldo.Text = _alumno.SueldoMensual.ToString();
                ddlEstados.SelectedValue = _alumno.IdEstadoOrig.ToString();
                ddlEstatus.SelectedValue = _alumno.IdEstatus.ToString();
        }

        protected void cvFechaCurp_ServerValidate(object source, ServerValidateEventArgs mklv)
        {
            var fechaNac=txbFN.Text;
            var extraCurp = txbCurp.Text.Substring(4, 6);
            var fechaNacCurp = fechaNac.Substring(2, 2) + fechaNac.Substring(5, 2) + fechaNac.Substring(8, 2);
            mklv.IsValid=extraCurp==fechaNacCurp;
        }
    }
}