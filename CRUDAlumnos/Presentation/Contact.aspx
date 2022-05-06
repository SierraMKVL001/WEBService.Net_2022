<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Presentation.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>Contacto.</h2>
    <h3>Direccion</h3>
    <address>
        Lago Ximilpa 173<br />
        Pensil Norte<br />
        <abbr title="Phone">P:</abbr>
        55-87-16-06-18
    </address>

    <address>
        <strong>Contacto:</strong>   <a href="mailto:contacto@ticapitalhumano.com">contacto@ticapitalhumano.com</a><br />
        <strong>Comercial:</strong> <a href="mailto:comercial@ticapitalhumano.com">comercial@ticapitalhumano.com</a>
    </address>
</asp:Content>
