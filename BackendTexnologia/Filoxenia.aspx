<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Filoxenia.aspx.cs" Inherits="TexnologiaProject.Filoxenia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container" style="width: 100%; height: 100%;">
        <div class="row"  style="background-image: url(Images/back10.jpg); background-repeat: no-repeat; ; background-size: cover; height: 100%;">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align: center;">
                <br/> 
                    <h1 style="font-family:Times New Roman; color:white;" >Upload your Room to FILOXENIA</h1> <br/>
                    <asp:Label ID="Label4" style="color: White;" runat="server" Text="In which country is your home?"></asp:Label><br /><br />
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox><br /><br />
                   <asp:Label ID="Label5" style="color: White;" runat="server" Text="In which city is your home?"></asp:Label><br /><br />
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br /><br />
                    <asp:Label ID="Label612451245" style="color: White;" runat="server" Text="How many people can you accommodate to your room?"></asp:Label><br /><br />
                    <asp:TextBox ID="txtPersons" runat="server"></asp:TextBox><br /><br />
                    <!-- trexei ston server, tis html den trexoun ston server-->
                    <asp:Label ID="Label512451245" style="color: White;" runat="server" Text="How many square meters is your room?"></asp:Label><br /><br />
                    <asp:TextBox ID="txtSquare"  runat="server"></asp:TextBox><br /><br />
              
                    <h3 style="color: White;">When you can offer your room?</h3>
                    <h5 style="color: White;">From</h5>
                    <asp:TextBox ID="txtStartingDate" TextMode="Date" runat="server"></asp:TextBox><br />
                    <h5 style="color: White;">To</h5>
                    <asp:TextBox ID="txtEndingDate" TextMode="Date" runat="server"></asp:TextBox><br /><br />

                  <h5 style="color: White;">More info about your room</h5>  <br/>
                   <%--<textarea id="txtInfo" name="myTextBox" cols="50" rows="5">Enter some text...</textarea>--%>
                <asp:TextBox ID="txtInfo"  runat="server">Enter some info</asp:TextBox><br/>
                   <br />
                <%--<h5 style="color: White;">Upload a picture of your room</h5>--%>
                 <%--<asp:Button ID="BtnSignup112451245" runat="server"  Text="Upload" class="btn btn-success"  /><br /><br />--%>
                   <asp:Button ID="Button113441" runat="server" Text="Upload my Room to Filoxenia" class="btn btn-info" OnClick="Button113441_Click"  /><br /><br/>
                <asp:Label ID="Label1" style="color: White;" runat="server" Text=""></asp:Label><br /><br />
                         <asp:Label ID="Label2" style="color: White;" runat="server" Text=""></asp:Label><br /><br />
                 <asp:Label ID="Label3" style="color: White;" runat="server" Text=""></asp:Label><br /><br />

                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="This expression does not validate." ControlToValidate="txtPasswordSU" ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"></asp:RegularExpressionValidator><!--gia ta regural expression-->--%>
                          <br/>  <br/>  <br/> <br/>  <br/>  <br/> <br/>  <br/>  <br/> <br/>  <br/>  <br/> <br/>  <br/>  <br/> <br/>  <br/>  <br/>
            </div>
     </div>
 </div>
</asp:Content>
