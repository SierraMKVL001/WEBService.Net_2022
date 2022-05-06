<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentation.Alumnos.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Listado Alumnos</h3>
    <br />
    <asp:Button class="btn btn-primary" ID="btnAgre" runat="server" Text="Agregar" OnClick="btnAgre_Click" />
    <br />
    <div>
        
            <asp:GridView GridLines="Horizontal"  CssClass="table  table-sm table-bordered table-condensed table-responsive-sm table-hover table-striped" ID="gvAlumno" runat="server" Width="361px" AutoGenerateColumns="False" OnRowCommand="gvAlumno_RowCommand" AllowPaging="True" OnPageIndexChanging="gvAlumno_PageIndexChanging" PageSize="5">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Id" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
            <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="IdEstadoOrig" HeaderText="Estado" />
            <asp:BoundField DataField="IdEstatus" HeaderText="Estatus" />
            <asp:ButtonField Text="Detalles" CommandName="Detalles" >
            <ControlStyle CssClass="btn btn-warning" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Editar" Text="Editar">
            <ControlStyle CssClass="btn btn-success" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Eliminar" Text="Eliminar">
            <ControlStyle CssClass="btn btn-danger" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    </div>
       
        
</asp:Content>
