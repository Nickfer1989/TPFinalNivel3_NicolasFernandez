<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="articulos_web.Favoritos" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3>Mis Favoritos</h3>
    <br />
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="Img del articulo" style="max-width: 500px; max-height: 600px;"
                            onerror="this.src='https://st4.depositphotos.com/14953852/22772/v/450/depositphotos_227725020-stock-illustration-image-available-icon-flat-vector.jpg'">
                     
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <h3 class="card-title"><%#Eval("Precio", "{0:F2}") %></h3>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver detalle</a>
                          
                            <asp:Button ID="btnEliminarFav" CssClass="btn btn-danger" runat="server" Text="Eliminar"
                                CommandName="ArticuloId" CommandArgument='<%#Eval("Id")%>' OnClick="btnEliminarFav_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
