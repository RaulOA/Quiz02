<%@ Page Title="Resultado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resultado.aspx.cs" Inherits="Quiz02_.Resultado" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Resultado de la operación</h2>
        
        <div class="alert alert-info text-center" role="alert">
            <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="d-block"></asp:Label>
        </div>

        <!-- Botón para regresar a la lista de teléfonos -->
        <div class="text-center mt-4">
            <a href="ListaTelefonos.aspx" class="btn btn-primary">Volver a la Lista</a>
        </div>
    </div>
</asp:Content>
