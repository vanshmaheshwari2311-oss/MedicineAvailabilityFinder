<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ManagePharmacy.aspx.cs"
    Inherits="MedicineAvailabilityFinder.Admin.ManagePharmacy" %>

<!DOCTYPE html>

<html>
<head runat="server">

    <title>Manage Pharmacies</title>

    <style>

        body {
            font-family: Arial;
            background-color: #f5f7fa;
            margin: 40px;
        }

        .container {
            width: 700px;
            margin: auto;
            background: white;
            padding: 30px;
            border-radius: 10px;
        }

        h1 {
            color: #198754;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .input {
            width: 100%;
            padding: 10px;
            box-sizing: border-box;
        }

        .btn {
            background-color: #198754;
            color: white;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            border-radius: 5px;
        }

        .message {
            display: block;
            margin: 15px 0;
            font-weight: bold;
        }

        table {
            width: 100%;
            margin-top: 25px;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 10px;
        }

        th {
            background-color: #198754;
            color: white;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

<div class="container">

    <h1>🏪 Manage Pharmacies</h1>


    <div class="form-group">

        <asp:Label ID="lblPharmacyName"
            runat="server"
            Text="Pharmacy Name">
        </asp:Label>

        <asp:TextBox ID="txtPharmacyName"
            runat="server"
            CssClass="input">
        </asp:TextBox>

    </div>


    <div class="form-group">

        <asp:Label ID="lblArea"
            runat="server"
            Text="Area">
        </asp:Label>

        <asp:TextBox ID="txtArea"
            runat="server"
            CssClass="input">
        </asp:TextBox>

    </div>


    <div class="form-group">

        <asp:Label ID="lblAddress"
            runat="server"
            Text="Address">
        </asp:Label>

        <asp:TextBox ID="txtAddress"
            runat="server"
            CssClass="input">
        </asp:TextBox>

    </div>


    <div class="form-group">

        <asp:Label ID="lblPhone"
            runat="server"
            Text="Phone">
        </asp:Label>

        <asp:TextBox ID="txtPhone"
            runat="server"
            CssClass="input">
        </asp:TextBox>

    </div>


    <asp:Button ID="btnAddPharmacy"
        runat="server"
        Text="Add Pharmacy"
        CssClass="btn"
        OnClick="btnAddPharmacy_Click" />


    <asp:Label ID="lblMessage"
        runat="server"
        CssClass="message">
    </asp:Label>


    <h2>Existing Pharmacies</h2>


    <asp:GridView ID="gvPharmacies"
        runat="server"
        AutoGenerateColumns="true">
    </asp:GridView>

</div>

</form>

</body>
</html>
