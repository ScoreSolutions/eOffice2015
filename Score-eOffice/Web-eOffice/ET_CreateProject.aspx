<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="MasterPage_Basic.master" CodeFile="ET_CreateProject.aspx.vb" Inherits="_ET_CreateProject" %>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="cphMain">
<br />
<table border="1"  align="center" cellpadding="0"  class="dataTable">
  <tr>
    <td align ="center" class="dataTableHeader" style="width: 360px">Add New Project
    </td>
  </tr>
  <tr>
    <td class="dataTableCell" style="width: 400px;" align="center">
      <table align ="center" width="400">
          <tr>
              <td style="width: 113px" align="left" valign="middle">
                  </td>
              <td align="left" style="width: 71px">
                  <asp:Label ID="lblProject_Id" runat="server" Width="136px" Visible="False"></asp:Label></td>
              <td align="left" style="width: 75px">
                  <asp:Label ID="lblTempSQL" runat="server" Visible="False" Width="1px"></asp:Label></td>
          </tr>
        <tr><td style="width: 113px" align="left" valign="middle">
            Project Code:</td><td align="left" style="width: 71px">
            <asp:TextBox cssclass="textboxRequired" Width="150px" ID="txtProjectCode"  MaxLength="20" runat ="server" />
            <td align="left" style="width: 75px">
                <asp:RequiredFieldValidator ID="vldProjectCode" runat="server" ControlToValidate="txtProjectCode"
                    ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr ><td style="width: 113px" align="left" valign="middle">
            Project Name:</td><td align="left" style="width: 71px"><asp:TextBox cssclass="textboxRequired" Width="150" ID="txtProjectName"  MaxLength="20" runat ="server" /></td>
            <td align="left" style="width: 75px">
                <asp:RequiredFieldValidator ID="vldProjectName" runat="server" ControlToValidate="txtProjectName"
                    ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr ><td style="width: 113px" align="left" valign="middle">
            Project Billing No:</td><td align="left" style="width: 71px"><asp:TextBox cssclass="textboxRequired" Width="150" ID="txtBilling"  MaxLength="20" runat ="server" /></td>
            <td align="left" style="width: 75px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBilling"
                    ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
          <tr>
              <td style="width: 113px; height: 23px" align="left" valign="middle">
                  Kick Off Date</td>
              <td align="left" style="width: 71px; height: 23px"><asp:TextBox cssclass="textboxRequired" Width="150" ID="txtDate"  MaxLength="20" runat ="server" />&nbsp;
              </td>
              <td align="left" style="width: 75px; height: 23px">
                  <asp:RequiredFieldValidator ID="vldStartDate" runat="server" ControlToValidate="txtDate"
                      ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                  <asp:PlaceHolder ID="PlHSelectDate" runat="server"></asp:PlaceHolder>
              </td>
          </tr>
          <tr>
              <td style="width: 113px; height: 23px" align="left" valign="middle">
                  Elapsed Time (Days)
              </td>
              <td align="left" style="width: 71px; height: 23px"><asp:TextBox cssclass="textboxRequired" Width="150" ID="txtDulation"  MaxLength="20" runat ="server" />Day</td>
              <td align="left" style="width: 75px; height: 23px">
                  <asp:RequiredFieldValidator ID="vldDulation" runat="server" ControlToValidate="txtDulation"
                      ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
          </tr>
        <tr ><td style="width: 113px; height: 23px;" align="left" valign="middle">
            Location:</td><td align="left" style="width: 71px; height: 23px;"><asp:DropDownList ID="drpClientOwner" runat="server" Width="150px" DataTextField="Client_Name" DataValueField="Client_id" AutoPostBack="True" /></td>
            <td align="left" style="width: 75px; height: 23px;">
                <asp:RangeValidator ID="vldClient" runat="server" ControlToValidate="drpClientOwner"
                    ErrorMessage="*" MaximumValue="999" MinimumValue="1" SetFocusOnError="True" ValidationGroup="client_branch"></asp:RangeValidator><asp:RangeValidator ID="vldProjectOwner" runat="server" ControlToValidate="drpClientOwner"
                    ErrorMessage="*" MaximumValue="999" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator></td>
        </tr>
        <tr ><td style="width: 113px" align="left" valign="middle">
            Site Branch:</td>
            <td align="left" colspan="2">
                <asp:Button ID="butExpBranch" runat="server" CssClass="butNormal"
                    Text="Expand" ValidationGroup="client_branch" Visible="False" /><asp:CheckBoxList ID="chbOperateBranch" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Dotted" BorderWidth="1px" DataTextField="Client_name" DataValueField="Client_Id" Width="100%" Visible="False">
            </asp:CheckBoxList></td>
        </tr>
        <tr ><td style="width: 113px" align="left" valign="middle">
            Billing To</td><td align="left" style="width: 71px"><asp:DropDownList ID="drpBillTo" runat="server" Width="150px" DataTextField="Client_Name" DataValueField="Client_id" /></td>
            <td align="left" style="width: 75px">
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="drpBillTo"
                    ErrorMessage="*" MaximumValue="999" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator></td>
        </tr>
          <tr>
              <td style="width: 113px; height: 17px;" align="left" valign="middle">
                  Billing Address</td>
              <td align="left" style="width: 71px; height: 17px;"><asp:TextBox Width="100%" ID="TxtBillAddress"  MaxLength="200" runat ="server" TextMode="MultiLine" Height="100px" BackColor="White" EnableTheming="False" EnableViewState="False" /></td>
              <td align="left" style="width: 75px; height: 17px;">
              </td>
          </tr>
      </table>
        <asp:Panel ID="Panel3" runat="server">
      <table align ="center" style="width: 350px">
          <tr>
              <td style="height: 23px; width: 108px;" valign="top">
                  &nbsp;Methodology</td>
              <td align="left" style="width: 66px; height: 23px;">
                  <asp:DropDownList ID="drpMethodology" runat="server" DataTextField="title" DataValueField="id" Width="97px">
                  </asp:DropDownList></td>
              <td align="left" style="width: 124px; height: 23px;">
                  <asp:RangeValidator ID="vldMethodology" runat="server" ControlToValidate="drpMethodology"
                      ErrorMessage="*" MaximumValue="999" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator></td>
          </tr>
      </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <table>
                <tr>
                    <td align="center" style="width: 100px; height: 47px;">
                        <strong>Client<br />
                            Project<br />
                            Manager</strong></td>
                    <td align="center" style="width: 100px; height: 47px;">
                        <strong>Client<br />
                            Project<br />
                            Leader</strong></td>
                    <td align="center" style="width: 100px; height: 47px;">
                        <strong>Client<br />
                            ContactPerson</strong></td>
                    <td align="center" style="width: 100px; height: 47px;">
                        <strong>Project Champion(Approver)</strong></td>
                    <td align="center" style="width: 100px; height: 47px;">
                        <strong>Project 
                            <br />
                            Leader</strong></td>
                    <td align="center" style="width: 100px; height: 47px;">
                        <strong>
                  ProjectTeam</strong></td>
                </tr>
                <tr>
                    <td style="width: 100px" valign="top">
                  <asp:Button ID="butExpanCusManager" runat="server" CssClass="butNormal"
                      Text="Expand" ValidationGroup="client_branch" Visible="False" /><asp:CheckBoxList ID="chbCusManager" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Dotted" BorderWidth="1px" DataTextField="CustomerFullName" DataValueField="Customer_Id" Width="100%">
                      </asp:CheckBoxList></td>
                    <td style="width: 100px" valign="top">
                  <asp:Button ID="butExpanCusLeader" runat="server" CssClass="butNormal"
                      Text="Expand" ValidationGroup="client_branch" Visible="False" /><asp:CheckBoxList ID="chbCusLeader" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Dotted" BorderWidth="1px" DataTextField="CustomerFullName" DataValueField="Customer_Id" Width="100%">
                      </asp:CheckBoxList></td>
                    <td style="width: 100px" valign="top">
                  <asp:Button ID="butExpenContractPerson" runat="server" CssClass="butNormal"
                      Text="Expand" ValidationGroup="client_branch" Visible="False" />
                  <asp:CheckBoxList ID="chbContractPerson" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Dotted" BorderWidth="1px" DataTextField="CustomerFullName" DataValueField="Customer_Id" Width="100%">
                  </asp:CheckBoxList></td>
                    <td style="width: 100px" valign="top">
                  <asp:Button ID="butProjectManager" runat="server" CausesValidation="False" CssClass="butNormal"
                      Text="Expand" Visible="False" />
                  <asp:CheckBoxList ID="chbProjectManager" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Dotted" BorderWidth="1px" DataTextField="MemberFullName" DataValueField="member_Id" Width="100%">
                  </asp:CheckBoxList></td>
                    <td style="width: 100px" valign="top">
                  <asp:Button ID="butExpandProLeader" runat="server" CausesValidation="False" CssClass="butNormal"
                      Text="Expand" Visible="False" />
                  <asp:CheckBoxList ID="chbProjectLeader" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Dotted" BorderWidth="1px" DataTextField="MemberFullName" DataValueField="member_Id" Width="100%">
                  </asp:CheckBoxList></td>
                    <td style="width: 100px" valign="top">
                  <asp:Button ID="ButExpandProjectTeam" runat="server" CausesValidation="False" CssClass="butNormal"
                      Text="Expand" Visible="False" />
                  <asp:CheckBoxList ID="chbProjectTeam" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Dotted" BorderWidth="1px" DataTextField="MemberFullName" DataValueField="member_Id" Width="100%">
                  </asp:CheckBoxList></td>
                </tr>
            </table>
        </asp:Panel>
    </td>
  </tr>
</table>
<center>
    &nbsp;</center>

    <center>
         
    <asp:Button ID ="butQuery" Text="Search" runat="server" CssClass="buttonQuery" CausesValidation="False" Visible="False" />
    <asp:Button ID ="butSave" Text="Save" runat="server" CssClass="buttonCreate" Width="57px" />
    <asp:Button ID ="butUpdate" Text="Update" runat="server" CssClass="butUpdate" Visible="False" />
    <asp:Button ID ="butDelete" Text="Delete" runat="server" CssClass="butDelete" Visible="False" CausesValidation="False" />
    <asp:Button ID ="butCancel" Text="Cancel" runat="server" CssClass="buttonCancel" Visible="False" CausesValidation="False" />
    <br />
    <br />
    <asp:label ID ="lblError" runat = "server" Visible = "false" Width ="400" CssClass = "errorBox"  /> <br />
    <br />
    <asp:Button ID ="butShowAll" Text="View All Project" runat="server" CssClass="buttonNormal" CausesValidation="False" /></center>
    <center>
    <asp:Repeater  ID = "rptShowProject" runat = "server">

<HeaderTemplate>
    <table align="center" class ="dataTable" width="600" border="1">
    <tr>
    <td colspan="5"  align ="center" class ="dataTableHeader">Project Management</td>
    </tr>
    <tr  align ="center"  class ="dataTableSubHeader">
        <td width="7%">No.</td>
        <td width="10%">Project Code</td>
        <td width="30%">Project Name</td>
        <td width="30%">Client Name</td>
        <td width="7%">Select</td>
              
    </tr>
</HeaderTemplate>

<ItemTemplate>
    <tr   class ="dataTableCell">
        <td align ="center"><%#Container.ItemIndex + 1%></td>
        <td align ="left"><%#Container.DataItem("Project_Code")%></td>
        <td align ="left"><%#Container.DataItem("Project_Name")%></td>
        <td align ="left"><%#Container.DataItem("Client_Name")%></td>
        <td align="center"><asp:Button CssClass ="buttonSelect" ID="butSelect" CausesValidation=false  text="Select" runat ="server" CommandArgument='<%#container.dataitem("Project_Id") %>' CommandName="Select"/></td>
        
    </tr>
</ItemTemplate>
<AlternatingItemTemplate>
    <tr  class ="altdataTableCell">
        <td align ="center"><%#Container.ItemIndex + 1%></td>
        <td align ="left"><%#Container.DataItem("Project_Code")%></td>
        <td align ="left"><%#Container.DataItem("Project_Name")%></td>
        <td align ="left"><%#Container.DataItem("Client_Name")%></td>
        <td align="center"><asp:Button CssClass ="buttonSelect" ID="butSelect" CausesValidation=false  text="Select" runat ="server" CommandArgument='<%#container.dataitem("Project_Id") %>' CommandName="Select"/></td>
        
    </tr>
</AlternatingItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
        &nbsp;</center>
    <center>
        &nbsp;&nbsp;</center>
    <center>
        &nbsp;<br />
        &nbsp;</center>
</asp:Content>

