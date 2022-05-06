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
    public partial class Create : System.Web.UI.Page
    {
        Alumno _alumno = new Alumno();
        public NEstado _nestado=new NEstado();
        public NAlumno _nalumno=new NAlumno();
        public NEstatus _nestatus=new NEstatus();
        public List<Estado> _estadoList = new List<Estado>();
        public List<EstatusAlumnos> _estatusList = new List<EstatusAlumnos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                txbFN.Text = "2022-01-30";
                CargarEstados();
                CargarEstatus();
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
            ddlEstatus.DataSource=_estatusList;
            ddlEstatus.DataTextField = "Nombre";
            ddlEstatus.DataValueField= "ID";
            ddlEstatus.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string nombre=txtNombre.Text;
            string primerA = txbPA.Text;
            string segundoA = txbSA.Text;
            DateTime fechaNac = Convert.ToDateTime( txbFN.Text);
            string curp=txbCurp.Text;
            string correo=txbCorr.Text;
            string telefono=txbTel.Text;
            decimal sueld = DBNull.Value.Equals(txbSueldo.Text) ? 0 : Convert.ToDecimal(txbSueldo.Text);
            int idEdo=int.Parse(ddlEstados.SelectedValue);
            int idEsta=int.Parse(ddlEstatus.SelectedValue);
            _alumno=new Alumno(1,nombre,primerA,segundoA,correo,telefono,fechaNac,curp,sueld,
                idEdo,idEsta);
            _nalumno.Agregar(_alumno);
            Response.Redirect("Index.aspx");

        }
    }
}