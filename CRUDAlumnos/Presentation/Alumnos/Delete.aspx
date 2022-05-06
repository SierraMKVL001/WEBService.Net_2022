<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Presentation.Alumnos.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>Eliminar del Alumno</h3>
        <dl class="dl-horizontal">
            <dt>
                ID
            </dt>
            <dd>
                <asp:Label ID="lblId" runat="server" Text="lblId"></asp:Label>
            </dd>
        </dl>
        <dl class="row">
            <dt>
                Nombre
            </dt>
            <dd>
                <asp:Label ID="lblNom" runat="server" Text="lblN"></asp:Label>
            </dd>
        </dl>
        <dl>
            <dt>
                Primer Apellido
            </dt>
            <dd>
                <asp:Label ID="lblPrA" runat="server" Text="lblPA"></asp:Label>
            </dd>
        </dl>
        <dl>
            <dt>
                Segundo Apellido
            </dt>
            <dd>
                <asp:Label ID="lblSdoA" runat="server" Text="lblSdoA"></asp:Label>
            </dd>
        </dl>
        <dl>
            <dt>
                Fecha de Nacimiento
            </dt>
            <dd>
                <asp:Label ID="lblfN" runat="server" Text="lblFN"></asp:Label>
            </dd>
        </dl>
        <dl>
            <dt>
                Curp
            </dt>
            <dd>
                <asp:Label ID="lblCurp" runat="server" Text="lblCp"></asp:Label>
            </dd>
        </dl>
        <dl>
            <dt>
                Correo
            </dt>
            <dd>
                <asp:Label ID="lblCorre" runat="server" Text="lblCorr"></asp:Label>
            </dd>
        </dl>
        <dl>
            <dt>
                Telefono
            </dt>
            <dd>
                <asp:Label ID="lblTel" runat="server" Text="lblTel"></asp:Label>
            </dd>
        </dl>
        <br />
        <dl>
            <dt>
                Sueldo
            </dt>
            <dd>
                <asp:Label ID="lblSueldo" runat="server" Text="Sueldo"></asp:Label>
            </dd>
        </dl>
        <dl>
            <dt>
                Estado
            </dt>
            <dd>
                <asp:Label ID="lblEstado" runat="server" Text="lblesta"></asp:Label>
            </dd>
        </dl>
        <br />
        <dl>
            <dt>
                Estatus
            </dt>
            <dd>
                <asp:Label ID="lblEstts" runat="server" Text="lblEsts"></asp:Label>
            </dd>
        </dl>
        <div>
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Alumnos/Index.aspx">Regresar a la Lista</asp:HyperLink>
    
            </div>
        </div>
        <div>
            <div>
                <asp:Button class="btn btn-danger" ID="btnDelete" runat="server" Text="Eliminar" OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
</asp:Content>
