<%@ Page Title="Lista de Teléfonos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaTelefonos.aspx.cs" Inherits="Quiz02_.ListaTelefonos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h1>Lista de Teléfonos</h1>
        
        <!-- GridView para mostrar los teléfonos -->
        <asp:GridView ID="gvTelefonos" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False" DataKeyNames="id_Telefono">
            <Columns>
                <asp:BoundField DataField="id_Telefono" HeaderText="ID" ReadOnly="True" SortExpression="id_Telefono" />
                <asp:BoundField DataField="marca" HeaderText="Marca" SortExpression="marca" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" 
                               DataFormatString="{0:C0}" HtmlEncode="false" />
                <asp:BoundField DataField="fechaLanzamiento" HeaderText="Lanzamiento" SortExpression="fechaLanzamiento" 
                               DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="EditarTelefono.aspx?id=<%# Eval("id_Telefono") %>" class="btn btn-warning btn-sm">Modificar</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
