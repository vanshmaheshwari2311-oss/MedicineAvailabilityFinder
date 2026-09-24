<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ManageMedicine.aspx.cs"
    Inherits="MedicineAvailabilityFinder.Admin.ManageMedicine" %>

<!DOCTYPE html>

<html>
<head runat="server">

    <title>Manage Medicines</title>

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

    <h1>💊 Manage Medicines</h1>

    <div class="form-group">

        <asp:Label ID="lblMedicineName"
            runat="server"
            Text="Medicine Name">
        </asp:Label>

        <asp:TextBox ID="txtMedicineName"
            runat="server"
            CssClass="input">
        </asp:TextBox>

    </div>


    <div class="form-group">

        <asp:Label ID="lblGenericName"
            runat="server"
            Text="Generic Name">
        </asp:Label>

        <asp:TextBox ID="txtGenericName"
            runat="server"
            CssClass="input">
        </asp:TextBox>

    </div>


    <div class="form-group">

        <asp:Label ID="lblCategory"
            runat="server"
            Text="Category">
        </asp:Label>

        <asp:TextBox ID="txtCategory"
            runat="server"
            CssClass="input">
        </asp:TextBox>

    </div>


    <div class="form-group">

        <asp:Label ID="lblStrength"
            runat="server"
            Text="Strength">
        </asp:Label>

        <asp:TextBox ID="txtStrength"
            runat="server"
            CssClass="input">
        </asp:TextBox>

    </div>


    <asp:Button ID="btnAddMedicine"
        runat="server"
        Text="Add Medicine"
        CssClass="btn"
        OnClick="btnAddMedicine_Click" />


    <asp:Label ID="lblMessage"
        runat="server"
        CssClass="message">
    </asp:Label>


    <h2>Existing Medicines</h2>


    <asp:GridView ID="gvMedicines"
        runat="server"
        AutoGenerateColumns="true">
    </asp:GridView>

</div>

</form>

</body>
</html>
