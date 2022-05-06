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
    public partial class Index : System.Web.UI.Page
    {
        NAlumno alumno=new NAlumno();
        NEstado _nestado=new NEstado();
        NEstatus _nestatus=new NEstatus();
        List<Alumno> _Alumnos=new List<Alumno>();
        List<Estado> _Estado=new List<Estado>();
        List<EstatusAlumnos> _Estatus=new List<EstatusAlumnos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                CargarDta();
            }

        }
        protected void btnAgre_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx");
        }
        public void CargarDta()
        {
            _Alumnos = alumno.Consultar();
            _Estado = _nestado.Consultar();
            _Estatus = _nestatus.Consultar();
            var Alm5 = from alumno in _Alumnos
                       join estados in _Estado on alumno.IdEstadoOrig equals estados.ID
                       join estatus in _Estatus on alumno.IdEstatus equals estatus.ID
                       select new
                       {
                           ID = alumno.ID,
                           Nombre = alumno.Nombre,
                           PrimerApellido= alumno.PrimerApellido,
                           SegundoApellido=alumno.SegundoApellido,
                           Correo=alumno.Correo,
                           Telefono=alumno.Telefono,
                           IdEstadoOrig = estados.Nombre,
                           IdEstatus = estatus.Nombre
                       };
            gvAlumno.DataSource = Alm5.ToList();
            gvAlumno.DataBind();

        }

        protected void gvAlumno_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }
            int numRenglon=Convert.ToInt32(e.CommandArgument);
            GridViewRow renglon=gvAlumno.Rows[numRenglon];
            TableCell celda = renglon.Cells[0];
            int id =Convert.ToInt32(celda.Text);
            
            switch (e.CommandName)
            {
                case "Detalles":
                    Response.Redirect($"Details.aspx?valor={id}");
                    break;
                case "Editar":
                    Response.Redirect($"Edit.aspx?valor={id}");
                    break;
                case "Eliminar":
                    Response.Redirect($"Delete.aspx?valor={id}");
                    break;
            }
        }

        protected void gvAlumno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAlumno.PageIndex=e.NewPageIndex;
            CargarDta();
        }
    }
}