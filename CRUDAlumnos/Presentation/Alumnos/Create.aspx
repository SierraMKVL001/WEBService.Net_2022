<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Presentation.Alumnos.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h3>Agregar Alumno</h3>
        <br />
        <div>
            <asp:Label  class="form-label" ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <div>
                <asp:RequiredFieldValidator ID="rfVNombre" runat="server" ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                <asp:TextBox  class="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revNom" runat="server" ErrorMessage="El nombre no puede contener numeros" ControlToValidate="txtNombre" ValidationExpression="^[A-Za-z\s]+$" CssClass="alert alert-warning"></asp:RegularExpressionValidator>

            </div>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Primer Apellido"></asp:Label>
            <div>
                <div>
                    <asp:RequiredFieldValidator ID="rfVPApellido" runat="server" ErrorMessage="Primer apellido requerido" ControlToValidate="txbPA" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                </div>
                <asp:TextBox class="form-control" ID="txbPA" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revPrimerA" runat="server" ErrorMessage="El primer apellido no puede contener numeros" ControlToValidate="txbPA" ValidationExpression="^[A-Za-z\s]+$" CssClass="alert alert-warning"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Segundo Apelldo"></asp:Label>
            <div>
                <asp:TextBox class="form-control" ID="txbSA" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revSegApe" runat="server" ErrorMessage="Tu segundo apellido no puede contener numeros" ValidationExpression="^[A-Za-z\s]+$" ControlToValidate="txbSA" CssClass="alert alert-warning"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Fecha de Nacimiento"></asp:Label>
            <div>
                <asp:RequiredFieldValidator ID="rvFNac" runat="server" ErrorMessage="Fecha de Nacimiento Requerida" ControlToValidate="txbFN" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                <asp:TextBox class="form-control" type="date" CssClass="form-control" ID="txbFN" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="rvFecha" runat="server" ErrorMessage="Edad fuera de rango" ControlToValidate="txbFN" MinimumValue="01-01-1990" MaximumValue="31-12-2020" Type="Date" CssClass="alert alert-warning"></asp:RangeValidator>
                <asp:CustomValidator ID="cvEdadCurp" runat="server" ErrorMessage="La CURP no coincide con la fecha" ControlToValidate="txbFN" ClientValidationFunction="MatchCurpEdad" CssClass="alert alert-warning"></asp:CustomValidator>
            </div>
        </div>
        <div>
            <asp:Label ID="Label9" runat="server" Text="CURP"></asp:Label>
            <div>
                <asp:RequiredFieldValidator ID="rvCurp" runat="server" ErrorMessage="CURP Requerida" ControlToValidate="txbCurp" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                <asp:TextBox class="form-control" ID="txbCurp" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revCurp" runat="server" ErrorMessage="Formato de CURP erroneo" ValidationExpression="^([A-Z&]|[a-z&]{1})([AEIOU]|[aeiou]{1})([A-Z&]|[a-z&]{1})([A-Z&]|[a-z&]{1})([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])([HM]|[hm]{1})([AS|as|BC|bc|BS|bs|CC|cc|CS|cs|CH|ch|CL|cl|CM|cm|DF|df|DG|dg|GT|gt|GR|gr|HG|hg|JC|jc|MC|mc|MN|mn|MS|ms|NT|nt|NL|nl|OC|oc|PL|pl|QT|qt|QR|qr|SP|sp|SL|sl|SR|sr|TC|tc|TS|ts|TL|tl|VZ|vz|YN|yn|ZS|zs|NE|ne]{2})([^A|a|E|e|I|i|O|o|U|u]{1})([^A|a|E|e|I|i|O|o|U|u]{1})([^A|a|E|e|I|i|O|o|U|u]{1})([0-9]{2})$" ControlToValidate="txbCurp" CssClass="alert alert-warning"></asp:RegularExpressionValidator>        
            </div>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Correo"></asp:Label>
            <div>
                <asp:RequiredFieldValidator ID="rfvCorr" runat="server" ErrorMessage="Correo Requerido" ControlToValidate="txbCorr" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                <asp:TextBox class="form-control" ID="txbCorr" runat="server"></asp:TextBox>
            </div>
        </div>
        <div>
            <asp:Label for="idControl" ID="Label6" runat="server" Text="Telefono"></asp:Label>
            <div>
                <asp:RegularExpressionValidator ID="revTel" runat="server" ErrorMessage="Telefono incorrecto" ValidationExpression="[0-9]{10}" ControlToValidate="txbTel" CssClass="alert alert-warning"></asp:RegularExpressionValidator>
                <asp:TextBox class="form-control" ID="txbTel" runat="server"></asp:TextBox>
            </div>
        </div>
        <div>
            <asp:Label ID="Label10" runat="server" Text="Sueldo"></asp:Label>
            <div>
                <asp:RangeValidator ID="rvSueldo" runat="server" ErrorMessage="El sueldo debe ser mayor a $10,000 y menor a $40,000" MaximumValue="40000" MinimumValue="10000" ControlToValidate="txbSueldo" Type="String" CssClass="alert alert-danger"></asp:RangeValidator>
                <asp:TextBox class="form-control" ID="txbSueldo" runat="server"></asp:TextBox>
            </div>
        </div>
        <div>
            <asp:Label ID="Label7" runat="server" Text="Estado"></asp:Label>
            <div>
                <asp:DropDownList class="form-control" ID="ddlEstados" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        
        <div>
            <asp:Label ID="Label8" runat="server" Text="Estatus"></asp:Label>
            <div>
                <asp:DropDownList class="form-control" ID="ddlEstatus" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div>
            <div>
                <asp:Button class="btn btn-primary" ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" />
            </div>
        </div>
        <br />
        <div>
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Alumnos/Index.aspx">Regresar a la Lista</asp:HyperLink>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function MatchCurpEdad(source, mklv) {
            var fechaNac = $("#<%=txbFN.ClientID%>").val();
            var extracCurp = $("#<%=txbCurp.ClientID%>").val().substr(4, 6);
            var fechaNacCurp = fechaNac.substr(2, 2) + fechaNac.substr(5, 2) + fechaNac.substr(8,2)
            mklv.IsValid = extracCurp == fechaNacCurp;
        }
    </script>
</asp:Content>
