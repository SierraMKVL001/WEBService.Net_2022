<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Presentation.Alumnos.Details" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>Datos del Alumno</h3>
        <dl>
            <dt>
                ID
            </dt>
            <dd>
                <asp:Label ID="lblId" runat="server" Text="lblId" ClientIDMode="Static"></asp:Label>
            </dd>
        </dl>
        <dl>
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
                <input id="iModal" type="button" onclick="CalcularIMSS()" value="CalcularIMSS" class="btn btn-primary" />
            </div>
        </div>
        <div>
            <div>
                <asp:Button CssClass="btn btn-light" ID="btnOpenPopUp" runat="server" text="Clacular ISR" OnClick="btnOpenPopUp_Click" />
            </div>
        </div>
        <div>
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Alumnos/Index.aspx">Regresar a la Lista</asp:HyperLink>
    
            </div>
        </div>
    </div>
    
         <div>
             <div>
                  
     <asp:Label ID="lblHidden" runat="server" Text=""></asp:Label>
   <ajaxToolkit:ModalPopupExtender ID="mpePopUp" runat="server" TargetControlID="lblHidden" PopupControlID="divPopUp" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>

     <div class="pnlBackGround" id="divPopUp" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h3 class="modal-title" id="exampleModalLabel">Calculo del ISR</h3>
      </div>
      <div class="modal-body">
          <dl>
              <dt>
                  Limite Inferior
              </dt>
              <dd>
                  <asp:Label ID="lblLiminf" runat="server" Text="Label"></asp:Label>
              </dd>
          </dl>
          <dl>
              <dt>
                  Limite Superior
              </dt>
              <dd>
                  <asp:Label ID="lblLimSup" runat="server" Text="Label"></asp:Label>
              </dd>
          </dl>
          <dl>
              <dt>
                  Cuota Fija
              </dt>
              <dd>
                  <asp:Label ID="lblCuotFij" runat="server" Text="Label"></asp:Label>
              </dd>
          </dl>
          <dl>
              <dt>
                  Excedente Limite Inferior
              </dt>
              <dd>
                  <asp:Label ID="excedLimInf" runat="server" Text="Label"></asp:Label>
              </dd>
          </dl>
        <dl>
            <dt>
                Subsidio
            </dt>
            <dd>
             <asp:Label ID="lblSubsid" runat="server" Text="Label"></asp:Label>
            </dd>
        </dl>
        <dl>
            <dt>
                Impuesto
            </dt>
            <dd>
            <asp:Label ID="lblImpuest" runat="server" Text="Label"></asp:Label>
            </dd>
        </dl>
      </div>
      <div class="modal-footer">
          <div id="buttons">
              <div id="DivbtnOK" class="buttonOK">
                <asp:Button ID="btnCloseModal" runat="server" CssClass="btn btn-danger" Text="Cerrar" />
              </div>
          </div>
      </div>
    </div>
  </div>
</div>
             </div>
         </div>

<div>
    <div class="modal" id="IMSSModClient"  tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Encabezado Modal -->
                <div class="modal-header">
                    <h4 class="modal-title">Calculo del IMSS</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Curepo de la Modal -->
                <div class="modal-body">    
                    <dl>
                        <dt>Enfermedades y Maternidad
                        </dt>
                        <dd>
                            <asp:Label ID="lblEnfMat" runat="server" Text="Enfermedades y Maternidad"></asp:Label>
                        </dd>
                    </dl>
                    <dl>
                        <dt>
                            Invalidez y Vida
                        </dt>
                        <dd>
                            <asp:Label ID="lblInvyVid" runat="server" Text="Invalidez y Vida"></asp:Label>
                        </dd>
                    </dl>
                    <dl>
                        <dt>
                            Retiro
                        </dt>
                        <dd>
                            <asp:Label ID="lblRetiro" runat="server" Text="Retiro"></asp:Label>
                        </dd>
                    </dl>
                    <dl>
                        <dt>
                            Cesantia
                        </dt>
                        <dd>
                            <asp:Label ID="lblCesantia" runat="server" Text="Cesantia"></asp:Label>
                        </dd>
                    </dl>
                    <dl>
                        <dt>
                            Infonavit
                        </dt>
                        <dd>
                            <asp:Label ID="lblInfona" runat="server" Text="Infonavit"></asp:Label>
                        </dd>
                    </dl>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>

            </div>
        </div>
    </div>
</div>
    <script type="text/javascript">
        function CalcularIMSS(){
            var urlWS = 'https://localhost:44381/WSAlumnos.asmx/CalcularIMSS';
            var id = $("#lblId").text();
            var alumno = { id: id };
            var parametros = JSON.stringify(alumno);
            LlamaAjaxPost(urlWS, parametros, MuestraAportacionesIMSS);
        }
        function LlamaAjaxPost(url, parametros, funcionExito) {
            $.ajax({
                type: 'POST',
                url: url,
                data: parametros,
                contentType: "application/json; charset = utf - 8",
                dataType: "json",
                success: funcionExito,
                error: errorGenerico
            });
        }

        function MuestraAportacionesIMSS(data) {
            try {
                imss = data.d;
                if (imss != null) {
                    $("#<%= lblEnfMat.ClientID%>").text(imss.EnfyMat);
                    $("#<%=lblInvyVid.ClientID%>").text(imss.InvyVid);
                    $("#<%=lblRetiro.ClientID%>").text(imss.Retiro);
                    $("#<%=lblCesantia.ClientID%>").text(imss.Cesantia);
                    $("#<%=lblInfona.ClientID%>").text(imss.CreditoInf);
                    $("#IMSSModClient").modal();
                } else {
                    alert('La pagina Web no puede responder a tu peticion')
                }
            } catch (ex) {
                alumno = [];
                alert('No se pudo guardar los datos');
            }
        }
        function funcExito(resultado, estatus, jqXHR) {
            var oRespuesta;
            try {
                oRespuesta = JSON.parse(resultado.d);
                if (oRespuesta != null) {
                    if (oRespuesta.Mensaje == "Exito") {
                        alert('Transacción efectuada con éxito');
                        /*window.location.href = "Default.aspx";*/
                    }
                    else {
                        alert(oRespuesta.Mensaje);
                    }
                }
                else {
                    alert('La respuesta recibida del Web Service es incorrecta ' + resultado.d);
                }
            }
            catch (ex) {
                alert('Error al recibir los datos');
            }
        }
        function errorGenerico(jqXHR, estatus, error) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No está conectado, favor de verificar su conexión.';
            }
            else if (jqXHR.status === 404) {
                msg = 'Página no encontrada [404]';
            }
            else if (jqXHR.status === 500) {
                msg = 'Error no hay conexión al servidor [500]';
            }
            else if (jqXHR.status === 'parseerror') {
                msg = 'El parseo del JSON es erróneo.';
            }
            else if (jqXHR.status === 'timeout') {
                $('body').addClass('loaded');
            }
            else if (jqXHR.status === 'abort') {
                msg = 'La petición Ajax fue abortada.';
            }
            else {
                msg = 'Error no conocido. ';
                console.log(exception);
            }
            alert(msg);
        }
    </script>
   
</asp:Content>
