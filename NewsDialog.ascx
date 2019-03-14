<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsDialog.ascx.cs" Inherits="Modules_Common_NewsDialog" %>

<%@ Register Assembly="AdvantageCMS.Web.UI" TagPrefix="Advantage" Namespace="AdvantageCMS.Web.UI" %>
<%@ Register Src="~/AdvantageControls/Helpers/AnimationSelect.ascx" TagPrefix="advantage" TagName="AnimationSelect" %>


<fieldset>
    <legend>Listing Information</legend>
    
    <div class="form-row">
        <label>Section Heading</label>
        <asp:TextBox ID="txtHeading" runat="server" MaxLength="255" />
    </div>

    <div class="form-row">
        <label>Category</label>
        <asp:DropDownList runat="server" ID="ddlMediaCategory" DataTextField="Name" DataValueField="MasterID" AppendDataBoundItems="true">
            <asp:ListItem Value="0" Text="All"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class="form-row">
        <label>Year</label>
        <asp:DropDownList runat="server" ID="ddlYear" AppendDataBoundItems="true">
            <asp:ListItem Value="0" Text="All"></asp:ListItem> 
        </asp:DropDownList>
    </div>
	
    <div class="form-row">
        <label>Display Thumbnails</label>
        <asp:CheckBox runat="server" ID="cbThumbs" />
    </div>
	
    <advantage:AnimationSelect runat="server" id="AnimationSelect1" />
</fieldset>

<fieldset>
    
    <legend>Pagination</legend>

    <div class="form-row">
        <label>Display Pagination</label>
        <asp:CheckBox runat="server" ID="chkPagination" />
    </div>

    <div class="form-row">
        <label>Infinite Scroll</label>
        <asp:CheckBox runat="server" ID="chkInfiniteScroll" />
    </div>

    <div class="form-row">
        <label>Items Per Page</label>
        <asp:DropDownList runat="server" ID="ddlItemsPerPage" AppendDataBoundItems="true">
            <asp:ListItem Value="0" Text="All"></asp:ListItem>
        </asp:DropDownList>        
    </div>


 </fieldset>

<fieldset>
    <legend>Detail Page</legend>

    <div class="form-row">
        <label>Detail page is another path</label>
        <asp:CheckBox runat="server" ID="chkDetailPage" AutoPostBack="true" />
    </div>
    
    <asp:PlaceHolder runat="server" ID="phRedirect" Visible="false">
        <div class="form-row">
            <label>Detail Page</label>
            <advantage:LinkSelector runat="server" ID="lnkDetail" />
            
        </div>
    </asp:PlaceHolder>
</fieldset>


<fieldset>
    <legend>More News</legend>
        <div class="form-row">
        <label>
            Read More Title
        </label>
        <asp:TextBox ID="txtMoreTitle" runat="server" />
    </div>
        <div class="form-row">
        <label>Read More Link</label>
            <advantage:LinkSelector runat="server" ID="txtMoreLink" />
    </div>
    </fieldset>



 

