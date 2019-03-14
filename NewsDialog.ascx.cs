using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvantageCMS.Core.Common;
using AdvantageCMS.Core.Common.BaseClasses;
using BusinessEntity;
using Common;
using System.Text;
using AdvantageCMS.Core.Common.Engine;

public partial class Modules_Common_NewsDialog : AdvantageAttributeControl 
{   
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        
        var engine = new AdvantageModuleEngine(CurrentSql, AdminDomain.DomainID, AdminLanguageID);

        ddlMediaCategory.DataSource = engine.GetAllPublishedObjects<NewsCategory>().ToList();
        ddlMediaCategory.DataBind();

        ddlItemsPerPage.DataSource = Counter(1, 20, 1);
        ddlItemsPerPage.DataBind();
 
        chkDetailPage.CheckedChanged += chkDetailPage_CheckedChanged;

        // year
        ddlYear.Items.Add(new ListItem("Current", DateTime.Now.Year.ToString()));

        var years = Counter(DateTime.Now.Year - 20, DateTime.Now.Year - 1, null);
        years.Reverse();

        ddlYear.DataSource = years;
        ddlYear.DataBind();
    }

    private void chkDetailPage_CheckedChanged(object sender, EventArgs e)
    {
        phRedirect.Visible = chkDetailPage.Checked;
    }

    protected override void SaveDataToObject()
    {
        Attributes.Add("Heading", txtHeading.Text.Trim());
       
        if (ddlMediaCategory.SelectedIndex > 0)
        {
            Attributes.Add("filterCategory", ddlMediaCategory.SelectedValue);
        }

        Attributes.Add("ItemsPerPage", ddlItemsPerPage.SelectedValue);
        Attributes.Add("chkPagination", chkPagination.Checked.ToString());
        Attributes.Add("chkInfiniteScroll", chkInfiniteScroll.Checked.ToString());
        
        Attributes.Add("showThumbs", cbThumbs.Checked.ToString());
        if (AnimationSelect1.Animation.SelectedIndex > 0) Attributes.Add("animation", AnimationSelect1.Animation.SelectedValue);

        Attributes.Add("MoreLink", txtMoreLink.GetAdvantageLink());

        Attributes.Add("MoreTitle", txtMoreTitle.Text.Trim());

        Attributes.Add("filterYear", ddlYear.SelectedValue);

        Attributes.Add(ClientConstants.HasDetailLink, chkDetailPage.Checked);
        Attributes.Add(ClientConstants.DetailLink, lnkDetail.GetAdvantageLink());    
    }

    protected override void LoadDataFromObject(AdvantageAttributeArgs e)
    {       
        txtMoreTitle.Text = SafeString(Attributes.GetString("MoreTitle"));
        txtHeading.Text = SafeString(Attributes.GetString("Heading"));
        
        ddlMediaCategory.SelectedValue = SafeString(Attributes.GetString("filterCategory"));

        string temp = SafeString(Attributes.GetString("filterYear"));
        ddlYear.SelectedValue = SafeString(Attributes.GetString("filterYear"));

        chkPagination.Checked = Attributes.GetBool("chkPagination");
        chkInfiniteScroll.Checked = Attributes.GetBool("chkInfiniteScroll");

        ddlItemsPerPage.SelectedValue = SafeString(Attributes.GetString("ItemsPerPage"));
         
        cbThumbs.Checked = Attributes.GetBool("showThumbs");
        AnimationSelect1.Animation.SelectedValue = Attributes.GetString("animation");

        txtMoreLink.SetAdvantageLink(SafeString(Attributes.GetString("MoreLink")));

        chkDetailPage.Checked = Attributes.GetBool(ClientConstants.HasDetailLink);
        lnkDetail.SetAdvantageLink(Attributes.GetString(ClientConstants.DetailLink));

        phRedirect.Visible = chkDetailPage.Checked;                       
    }

    public override bool ValidateSave(out string message)
    {
        message = string.Empty;
        bool retval = true;

        if (chkDetailPage.Checked)
        {
            if (string.IsNullOrEmpty(lnkDetail.GetAdvantageLink()))
            {
                message = "Please add a link for the Detail page.<br/>";
                retval = false;
            }
        }

        return retval;
    }

    private List<int> Counter(int min, int max, int? multiples)
    {
        List<int> count = new List<int>();

        if (multiples != null)
            for (int i = min; i <= max; i = i + (int)multiples) count.Add(i); 
        else
            for (int i = min; i <= max; i++) count.Add(i);

        return count;
    }
}