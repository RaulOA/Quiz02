<%@ Page Title="Crear Teléfono" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearTelefono.aspx.cs" Inherits="Quiz02_.CrearTelefono" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Formulario de creación</h2>
        
        <asp:Panel ID="pnlFormulario" runat="server" CssClass="border p-4 rounded shadow-sm mx-auto" style="max-width: 600px;">
            
            <!-- Marca -->
            <div class="mb-3">
                <label for="txtMarca" class="form-label">Marca</label>
                <asp:TextBox ID="txtMarca" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="txtMarca" 
                    InitialValue="" ErrorMessage="La marca es requerida" ForeColor="Red" />
                <asp:RegularExpressionValidator ID="revMarca" runat="server" ControlToValidate="txtMarca" 
                    ValidationExpression="^.{1,100}$" ErrorMessage="La marca no puede exceder los 100 caracteres" 
                    ForeColor="Red" />
            </div>
            
            <!-- Nombre -->
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                    InitialValue="" ErrorMessage="El nombre es requerido" ForeColor="Red" />
                <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" 
                    ValidationExpression="^.{1,50}$" ErrorMessage="El nombre no puede exceder los 50 caracteres" 
                    ForeColor="Red" />
            </div>

            <!-- Año de fabricación -->
            <div class="mb-3">
                <label for="txtAnhoFabricacion" class="form-label">Año de fabricación</label>
                <asp:TextBox ID="txtAnhoFabricacion" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAnhoFabricacion" runat="server" ControlToValidate="txtAnhoFabricacion" 
                    InitialValue="" ErrorMessage="El año de fabricación es requerido" ForeColor="Red" />
                <asp:RangeValidator ID="rvAnhoFabricacion" runat="server" ControlToValidate="txtAnhoFabricacion" 
                    MinimumValue="2000" MaximumValue="2025" Type="Integer" 
                    ErrorMessage="El año debe estar entre 2000 y 2025" ForeColor="Red" />
            </div>

            <!-- Fecha de lanzamiento -->
            <div class="mb-3">
                <label for="txtFechaLanzamiento" class="form-label">Fecha de lanzamiento</label>
                <asp:TextBox ID="txtFechaLanzamiento" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFechaLanzamiento" runat="server" ControlToValidate="txtFechaLanzamiento" 
                    InitialValue="" ErrorMessage="La fecha de lanzamiento es requerida" ForeColor="Red" />
                <asp:CustomValidator ID="cvFechaLanzamiento" runat="server" ControlToValidate="txtFechaLanzamiento"
                    OnServerValidate="cvFechaLanzamiento_ServerValidate" ErrorMessage="La fecha de lanzamiento no puede ser mayor a la fecha actual" ForeColor="Red" />
            </div>

            <!-- Precio -->
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio" 
                    InitialValue="" ErrorMessage="El precio es requerido" ForeColor="Red" />
                <asp:RangeValidator ID="rvPrecio" runat="server" ControlToValidate="txtPrecio" MinimumValue="1" MaximumValue="5000"
                    Type="Integer" ErrorMessage="El precio debe estar entre 1 y 5000" ForeColor="Red" />
                <asp:RegularExpressionValidator ID="revPrecio" runat="server" ControlToValidate="txtPrecio" 
                    ValidationExpression="^\d+$" ErrorMessage="El precio debe ser un valor entero" ForeColor="Red" />
            </div>

            <!-- Botones -->
            <div class="d-flex justify-content-between">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                <a href="ListaTelefonos.aspx" class="btn btn-secondary">Cancelar</a>
            </div>

        </asp:Panel>
    </div>
</asp:Content>
