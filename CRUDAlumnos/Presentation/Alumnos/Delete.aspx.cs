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
    public partial class Delete : System.Web.UI.Page
    {
        public Alumno _alumno = new Alumno();
        public NAlumno _nAlumno = new NAlumno();
        public NEstatus _nestatus = new NEstatus();
        public NEstado _nestado = new NEstado();
        public List<Estado> _estadoList = new List<Estado>();
        public List<EstatusAlumnos> _estatusList = new List<EstatusAlumnos>();
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
            _alumno = _nAlumno.Consultar(id);
            lblId.Text = Convert.ToString(_alumno.ID);
            lblNom.Text = _alumno.Nombre;
            lblPrA.Text = _alumno.PrimerApellido;
            lblSdoA.Text = _alumno.SegundoApellido;
            lblfN.Text = _alumno.FechaNacimiento.ToString();
            lblCurp.Text = _alumno.CURP;
            lblCorre.Text = _alumno.Correo;
            lblTel.Text = _alumno.Telefono;
            lblSueldo.Text = _alumno.SueldoMensual.ToString();
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

            foreach (var estatus in rEstatus)
            {
                lblEstts.Text = estatus.Nombre.ToString();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(lblId.Text);
            _nAlumno.Eliminar(id);
            Response.Redirect("Index.aspx");
        }
    }
}