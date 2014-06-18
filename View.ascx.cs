/*
' Copyright (c) 2014  Plugghest.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Framework;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using Plugghest.Helpers;
using Plugghest.Base2;
using System.Collections.Generic;
using Plugghest.DNN;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Script.Services;
using Plugghest.Modules.UserControl.DisplayPlugg;

namespace Plugghest.Modules.DisplayPlugg
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from DisplayPluggModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : DisplayPluggModuleBase, IActionable
    {
        protected override void AddedControl(Control control, int index)
        {
            base.AddedControl(control, index);
        }

        #region Properties
        /// <summary>
        /// Current Culture Code
        /// </summary>
        private string CurrentLanguage
        {
            get
            {
                return (Page as DotNetNuke.Framework.PageBase).PageCulture.Name;
            }
        }

        /// <summary>
        /// Plugg ID.
        /// </summary>
        private int PluggID
        {
            get
            {
                return Convert.ToInt32(((DotNetNuke.Framework.CDefault)this.Page).Title);
            }
        }

        /// <summary>
        /// Plugg Container.
        /// </summary>
        private PluggContainer PluggContainer
        {
            get
            {
                return new PluggContainer(this.CurrentLanguage, this.PluggID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int EditStr
        {
            get { return !string.IsNullOrEmpty(Page.Request.QueryString["edit"]) ? Convert.ToInt16(Page.Request.QueryString["edit"]) : 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool IsAuthorized
        {
            get { return ((this.UserId != -1 && this.PluggContainer.ThePlugg.WhoCanEdit == EWhoCanEdit.Anyone) || this.PluggContainer.ThePlugg.CreatedByUserId == this.UserId || (UserInfo.IsInRole("Administator"))); }
        }

        /// <summary>
        /// 
        /// </summary>
        private ECase _Case
        {
            get
            {
                return ((this.PluggContainer.CultureCode == this.PluggContainer.ThePlugg.CreatedInCultureCode) && !IsAuthorized) ? ECase.ViewInCreationLangNotAuth :
                    ((this.PluggContainer.CultureCode != this.PluggContainer.ThePlugg.CreatedInCultureCode) && EditStr != 2) ? ECase.ViewInAltLang :
                    ((this.PluggContainer.CultureCode == this.PluggContainer.ThePlugg.CreatedInCultureCode) && IsAuthorized && EditStr != 1 && EditStr != 11) ? ECase.ViewInCreationLangAuth :
                    ((this.PluggContainer.CultureCode != this.PluggContainer.ThePlugg.CreatedInCultureCode) && EditStr == 2) ? ECase.Translate :
                    ((this.PluggContainer.CultureCode == this.PluggContainer.ThePlugg.CreatedInCultureCode) && IsAuthorized && EditStr == 1) ? ECase.Edit : ECase.SubEdit;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string NoComponentText
        {
            get
            {
                return Localization.GetString("lblNoComponent", this.LocalResourceFile + ".ascx." + this.CurrentLanguage + ".resx");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string BtnEdit_Text
        {
            get
            {
                return Localization.GetString("Edit", this.LocalResourceFile + ".ascx." + this.CurrentLanguage + ".resx");
            }
        }

        private bool _chkComTxt = false;
        private bool chkComTxt
        {
            get { return _chkComTxt; }
            set { _chkComTxt = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SetLocalizationText();
                shuffleLocalControls();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void SetLocalizationText()
        {
            btnEditPlug.Text = Localization.GetString("btnEditPlugResource1.Text", this.LocalResourceFile);
            btncanceledit.Text = Localization.GetString("btncanceleditResource1.Text", this.LocalResourceFile);
            btncanceltrans.Text = Localization.GetString("btncanceltransResource1.Text", this.LocalResourceFile);
            btntransplug.Text = Localization.GetString("btntransplug.Text", this.LocalResourceFile);
            btnSelSub.Text = Localization.GetString("btnSelSubResource1.Text", this.LocalResourceFile);
            btnTreecancel.Text = Localization.GetString("btnTreecancelResource1.Text", this.LocalResourceFile);
            btnlocal.Text = Localization.GetString("btnlocalResource1.Text", this.LocalResourceFile) + " (" + this.PluggContainer.ThePlugg.CreatedInCultureCode + ")";
        }

        private void shuffleLocalControls()
        {
            switch (this._Case)
            {
                case ECase.ViewInCreationLangNotAuth:
                    btnlocal.Visible = false;
                    btntransplug.Visible = false;
                    btnEditPlug.Visible = false;
                    btncanceledit.Visible = false;
                    break;
                case ECase.ViewInAltLang:
                    btnlocal.Visible = true;
                    btntransplug.Visible = true;
                    btnEditPlug.Visible = false;
                    break;
                case ECase.ViewInCreationLangAuth:
                    btnlocal.Visible = false;
                    btntransplug.Visible = false;
                    btnEditPlug.Visible = true;
                    btncanceledit.Visible = false;
                    break;
                case ECase.Translate:
                    btnlocal.Visible = false;
                    btncanceltrans.Visible = true;
                    btntransplug.Visible = false;
                    btnEditPlug.Visible = false;
                    break;
                case ECase.Edit:
                    btnlocal.Visible = false;
                    btntransplug.Visible = false;
                    btnEditPlug.Visible = false;
                    btncanceledit.Visible = true;
                    break;
                default:
                    btnEditPlug.Visible = false;
                    btnlocal.Visible = false;
                    btntransplug.Visible = false;
                    break;

            }
            DisplayPluggComp();

        }

        private void DisplayPluggComp()
        {
            List<PluggComponent> comps = this.PluggContainer.GetComponentList();
            int i = 0, IntCompOrder = 1;
            bool isLastComp = false;

            if (!string.IsNullOrEmpty(Page.Request.QueryString["s"]) && true == Convert.ToBoolean(Page.Request.QueryString["s"]))
            {
                int Selected_ComponentID = !string.IsNullOrEmpty(Page.Request.QueryString["cid"]) ? Convert.ToInt16(Page.Request.QueryString["cid"]) : 0;
                LoadControl(1, false, comps.FirstOrDefault(x => x.PluggComponentId == Selected_ComponentID));
                return;
            }

            if (!string.IsNullOrEmpty(Page.Request.QueryString["trans"]) && Convert.ToInt16(Page.Request.QueryString["trans"]) > 0)
            {
                int Selected_ComponentID = Convert.ToInt16(Page.Request.QueryString["trans"]);
                LoadControl(1, false, comps.FirstOrDefault(x => x.PluggComponentId == Selected_ComponentID));
                return;
            }


            foreach (PluggComponent comp in comps)
            {
                isLastComp = (IntCompOrder == comps.Count);
                LoadControl(IntCompOrder, isLastComp, comp);
                i++; IntCompOrder++;
            }
        }

        private void LoadControl(int IntCompOrder, bool isLastComp, PluggComponent comp)
        {
            ControlViewModel viewModel = new ControlViewModel();
            viewModel.ComponentType = comp.ComponentType;
            viewModel.ComponentID = comp != null ? comp.PluggComponentId : 0;
            viewModel.UserID = this.UserId;
            viewModel.Order = IntCompOrder;
            viewModel.TabID = TabId;
            viewModel.isLastComp = isLastComp;
            viewModel._this = this;

            Control_Case _control = new Control_Case(this._Case);
            _control.RunComponentType(comp.ComponentType, viewModel);
        }

        private void ShowNoComMsg()
        {
            lblnoCom.Visible = true;
            lblnoCom.Text = this.NoComponentText;
        }

        /// <summary>
        /// event to Edit Plugg 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditPlugg_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

        protected void btncanceledit_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "test=2", "language=" + this.CurrentLanguage }));
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            pnlPluggCom.Visible = true;
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=" + EditStr, "language=" + this.CurrentLanguage }));
        }

        /// <summary>
        /// event to "Help us with the translation of this Plugg"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btntransplug_Click(object sender, EventArgs e)
        {
            btntransplug.Visible = false;
            btncanceltrans.Visible = true;
            if (!chkComTxt)
                ShowNoComMsg();
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=2", "language=" + this.CurrentLanguage }));

        }

        protected void btnlocal_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "test=2", "language=" + this.PluggContainer.ThePlugg.CreatedInCultureCode }));
        }

        protected void btncanceltrans_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "test=2", "language=" + this.CurrentLanguage }));
        }

        protected void btnSelSub_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(hdnNodeSubjectId.Value))
            {
                int id = Convert.ToInt32(hdnNodeSubjectId.Value);

                BaseHandler plugghandler = new BaseHandler();
                this.PluggContainer.ThePlugg.SubjectId = id;
                this.PluggContainer.LoadTitle();
                List<object> blankList = new List<object>();
                BaseHandler bh = new BaseHandler();
                try
                {
                    bh.SavePlugg(this.PluggContainer, blankList);
                }
                catch (Exception)
                {
                }
            }

            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=" + EditStr, "language=" + this.CurrentLanguage }));

        }

        #region old methods

        //old events

        //private void PageLoadFun()
        //{
        //    if (this.PluggContainer.CultureCode == this.PluggContainer.ThePlugg.CreatedInCultureCode)
        //    {
        //        if (IsCase2)
        //            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=0", "language=" + this.PluggContainer.ThePlugg.CreatedInCultureCode }));

        //        btnlocal.Visible = false;
        //        btntransplug.Visible = false;
        //        btnEditPlug.Visible = true;
        //    }
        //    else
        //    {
        //        if (IsCase3)
        //            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=" + EditStr, "language=" + this.PluggContainer.ThePlugg.CreatedInCultureCode }));

        //        btnEditPlug.Visible = false;
        //        btncanceledit.Visible = false;
        //    }
        //    //CheckEditCase();


        //    if (!IsAuthorized)
        //    {
        //        btnEditPlug.Visible = false;
        //    }
        //    if (IsCase3)
        //    {
        //        btnEditPlug.Visible = false;
        //        btncanceledit.Visible = true;
        //    }
        //    if (IsCase2)
        //    {
        //        btncanceltrans.Visible = true;
        //        btntransplug.Visible = false;
        //    }
        //    DisPlayPluggComp();
        //}

        //private void SetStaticBtnText()
        //{
        //    btnlocal.Text = BtnlocalTxt;
        //    btnEditPlug.Text = btnEditPlugTxt;
        //    btncanceledit.Text = BtncanceleditTet;
        //    btncanceltrans.Text = BtncanceltransTxt;
        //    btntransplug.Text = BtntransplugTxt;
        //    btnSelSub.Text = BtnSaveTxt;
        //    btnTreecancel.Text = BtnCancelTxt;
        //}

        //protected void btnLabelSave_Click(object sender, EventArgs e)
        //{
        //    ETextItemType ItemType = ETextItemType.PluggComponentLabel;
        //    string txt = txtlabel.Text;
        //    UpdatePHtext(ItemType, txt);
        //    pnlPluggCom.Visible = true;
        //}
        //protected void btnSaveRRt_Click(object sender, EventArgs e)
        //{
        //    var id = hdnlabel.Value;
        //    var itemid = Convert.ToInt32(id);

        //    List<PluggComponent> comps = p.GetComponentList();
        //    PluggComponent cToAdd = comps.Find(x => x.PluggComponentId == Convert.ToInt32(id));
        //    BaseHandler bh = new BaseHandler();

        //    var comtype = cToAdd.ComponentType;

        //    switch (cToAdd.ComponentType)
        //    {
        //        case EComponentType.RichRichText:
        //            //PHText RichRichText = bh.GetCurrentVersionText(curlan, itemid, ETextItemType.PluggComponentRichRichText);
        //            //RichRichText.Text = richrichtext.Text;

        //            PHText objPHtext = new PHText(System.Net.WebUtility.HtmlDecode(richrichtext.Text), curlan, ETextItemType.PluggComponentRichRichText);
        //            objPHtext.CultureCodeStatus = ECultureCodeStatus.GoogleTranslated;
        //            objPHtext.ItemId = itemid;
        //            objPHtext.CreatedByUserId = this.UserId;

        //            if (EditStr == "2")
        //                objPHtext.CultureCodeStatus = ECultureCodeStatus.HumanTranslated;


        //            bh.SavePhTextInAllCc(objPHtext);
        //            break;

        //        case EComponentType.Latex:

        //            PHLatex latex = bh.GetCurrentVersionLatexText(curlan, Convert.ToInt32(id), ELatexItemType.PluggComponentLatex);
        //            latex.CultureCodeStatus = ECultureCodeStatus.GoogleTranslated;
        //            latex.ItemId = itemid;
        //            latex.CreatedByUserId = this.UserId;
        //            latex.Text = System.Net.WebUtility.HtmlDecode(richrichtext.Text);
        //            //bh.SaveLatexText(latex);
        //            bh.SaveLatexTextInAllCc(latex);
        //            break;
        //    }

        //    Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=" + EditStr, "language=" + curlan }));


        //}





        //private void CreateBtnImproveHumGoogleTrans(PluggComponent comp, PHText lbl, string css, string id, string BtnText)
        //{
        //    Button btnImpHumTras = new Button();
        //    btnImpHumTras.CssClass = css;
        //    btnImpHumTras.ID = id;
        //    btnImpHumTras.Text = BtnText;
        //    btnImpHumTras.Click += (s, e) => { ImpGoogleTrans(comp, lbl); };
        //    divTitle.Controls.Add(btnImpHumTras);
        //}

        //private void CreateBtnAdd(int orderid, string CssClass, string ID)
        //{
        //    Button Addbutton = new Button();
        //    Addbutton.CssClass = CssClass;
        //    Addbutton.ID = ID;
        //    Addbutton.Text = BtnAddtxt;
        //    Addbutton.Click += (s, e) => { callingAddPlugg(orderid); };
        //    divTitle.Controls.Add(Addbutton);
        //}
        //private void CreateBtnYTEdit(PluggComponent comp, YouTube yt, int ytorderid, string CssClass, string ID)
        //{
        //    Button editbtn = new Button();
        //    editbtn.CssClass = CssClass;
        //    editbtn.ID = ID;
        //    editbtn.Text = BtnEditTxt;
        //    editbtn.Click += (s, e) => { YouTubeEdit(ytorderid, comp, yt); };
        //    divTitle.Controls.Add(editbtn);
        //}

        //private string CreateDivLat(PHLatex lat, string ltdivid, int IntCompOrder)
        //{
        //    string LatHTMLstring = "";
        //    if (lat == null)
        //        LatHTMLstring = "<div><div id=" + ltdivid + " class='Main'>" + "Component " + IntCompOrder + ": " + BtnLatexTxt + " ";
        //    else
        //        LatHTMLstring = "<div><div id=" + ltdivid + " class='Main'> " + "Component " + IntCompOrder + ": " + BtnLatexTxt + " " + lat.Text + "";
        //    divTitle.Controls.Add(new LiteralControl(LatHTMLstring));
        //    return LatHTMLstring;
        //}
        //private string CreateDivLat(PHLatex lat, string ltdivid)
        //{
        //    string LatHTMLstring = "";
        //    if (lat == null)
        //        LatHTMLstring = "<div><div id=" + ltdivid + " class='Main'>" + BtnLatexTxt + ":";
        //    else
        //        LatHTMLstring = "<div><div id=" + ltdivid + " class='Main'> " + BtnLatexTxt + ":" + lat.Text + "";
        //    divTitle.Controls.Add(new LiteralControl(LatHTMLstring));
        //    return LatHTMLstring;
        //}

        //private string CreateDiv(PHText Phtxt, string divid, string obj)
        //{
        //    string HTMLstring = "";
        //    if (Phtxt == null)
        //        HTMLstring = "<div><div id=" + divid + " class='Main'" + obj + " ";
        //    else
        //        HTMLstring = "<div><div id=" + divid + " class='Main'=>" + obj + " " + Phtxt.Text + " ";
        //    divTitle.Controls.Add(new LiteralControl(HTMLstring));
        //    return HTMLstring;
        //}

        //private void CreateBtnGoogleT(PHText rrt, string CssClassGT, string IDGT)
        //{
        //    Button btnGT = new Button();
        //    btnGT.CssClass = CssClassGT;
        //    btnGT.ID = IDGT;
        //    btnGT.Text = BtnGoogleTransTxtOkTxt;
        //    btnGT.Click += (s, e) => { GoogleTranText(rrt); };
        //    divTitle.Controls.Add(btnGT);
        //}

        //private void CreateBtnEdit(PluggComponent comp, PHText lbl, string CssClass, string ID)
        //{
        //    Button editbtn = new Button();
        //    editbtn.CssClass = CssClass;
        //    editbtn.ID = ID;
        //    editbtn.Text = BtnEditTxt;
        //    editbtn.Click += (s, e) => { ImpGoogleTrans(comp, lbl); };
        //    divTitle.Controls.Add(editbtn);
        //}

        //private void CreateBtnDel(int orderid, string CssClass, string ID)
        //{
        //    Button delbtn = new Button();
        //    delbtn.CssClass = CssClass;
        //    delbtn.ID = ID;
        //    delbtn.Text = BtnRemoveTxt;
        //    delbtn.Click += (s, e) => { callingDelPlugg(orderid); };

        //    divTitle.Controls.Add(new LiteralControl("<br />"));
        //    divTitle.Controls.Add(delbtn);
        //}

        //private static string CreateDropDown(string ddl)
        //{
        //    foreach (string name in Enum.GetNames(typeof(EComponentType)))
        //    {
        //        if (name != "NotSet")
        //        {
        //            string dl = "<option  value=" + name + " >" + name + "</option>";
        //            ddl = ddl + dl;
        //        }
        //    }
        //    return ddl;
        //}

        //private void CallLatFun(int ltorderid, PluggComponent comp, PHLatex lat, string p)
        //{
        //    hdnlabel.Value = Convert.ToString(comp.PluggComponentId);

        //    if (comp.ComponentType == EComponentType.Latex)
        //    {
        //        pnlRRT.Visible = true;
        //        pnllabel.Visible = false;
        //        pnlletex.Visible = false;
        //        richtextbox.Visible = false;

        //        pnlYoutube.Visible = false;
        //        richrichtext.Text = lat.Text;
        //    }
        //    pnlPluggCom.Visible = false;
        //}
        //point
        //private void YouTubeEdit(int ytorderid, PluggComponent comp, YouTube yt)
        //{
        //    string ytcode = "";
        //    if (yt == null)
        //        ytcode = "";
        //    else
        //        ytcode = yt.YouTubeCode;
        //    hdnlabel.Value = Convert.ToString(comp.PluggComponentId);

        //    if (comp.ComponentType == EComponentType.YouTube)
        //    {

        //        pnlYoutube.Visible = true;
        //        pnlRRT.Visible = false;
        //        pnllabel.Visible = false;
        //        pnlletex.Visible = false;
        //        richtextbox.Visible = false;
        //        txtYouTube.Text = ytcode;
        //    }
        //    pnlPluggCom.Visible = false;

        //}

        //private void GoogleTranText(PHText txt)
        //{
        //    BaseHandler bh = new BaseHandler();
        //    txt.CultureCodeStatus = ECultureCodeStatus.HumanTranslated;
        //    bh.SavePhText(txt);
        //    Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=" + EditStr, "language=" + curlan }));
        //}
        //private void ImpGoogleTrans(PluggComponent comp, PHText CulTxt)
        //{
        //    hdnlabel.Value = Convert.ToString(comp.PluggComponentId);

        //    string text = CulTxt.Text;
        //    switch (comp.ComponentType)
        //    {
        //        case EComponentType.Label:
        //            CompHide();
        //            txtlabel.Text = text;
        //            pnllabel.Visible = true;
        //            break;

        //        case EComponentType.RichText:
        //            CompHide();
        //            richtextbox.Visible = true;
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", " $(document).ready(function () {$('#editor').html('" + text.Replace("\r\n", "<br />") + "')});", true);
        //            break;

        //        case EComponentType.RichRichText:
        //            CompHide();
        //            pnlRRT.Visible = true;
        //            richrichtext.Text = text;
        //            break;
        //    }
        //    pnlPluggCom.Visible = false;
        //}

        //private void CompHide()
        //{
        //    pnlRRT.Visible = false;
        //    pnllabel.Visible = false;
        //    pnlletex.Visible = false;
        //    richtextbox.Visible = false;
        //    pnlYoutube.Visible = false;
        //}

        /// <summary>
        /// Commented by rohit
        /// </summary>
        /// <param name="orderid"></param>
        //private void callingDelPlugg(int orderid)
        //{

        //    //BaseHandler plugghandler = new BaseHandler();
        //    //plugghandler.DeleteComponent(p, orderid);
        //    //Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=1", "language=" + curlan }));

        //}

        //private void callingAddPlugg(int orderid)
        //{
        //    var id = hdnDDLtxt.Value;

        //    BaseHandler plugghandler = new BaseHandler();
        //    PluggComponent pc = new PluggComponent();
        //    pc.ComponentOrder = orderid + 1;
        //    pc.ComponentType = (EComponentType)Enum.Parse(typeof(EComponentType), id);
        //    plugghandler.AddComponent(p, pc);
        //    Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=1", "language=" + curlan }));


        //}


        //private void DisPlayPluggComp()
        //{
        //    List<PluggComponent> comps = p.GetComponentList();
        //    BaseHandler bh = new BaseHandler();
        //    string ddl = ""; string str = "</select></div><hr />"; int i = 0, IntCompOrder = 1;
        //    if (comps.Count == 0)
        //    {
        //        ShowNoComMsg();
        //    }

        //    ddl = CreateDropDown(ddl);

        //    Label dynamicLabel = new Label();

        //    if (IsCase3)
        //    {
        //        chkComTxt = true;
        //    }
        //    int? subid = p.ThePlugg.SubjectId;
        //    CreateSubject(i, subid);
        //    bool isLastComp = false;
        //    foreach (PluggComponent comp in comps)
        //    {
        //        isLastComp = (IntCompOrder == comps.Count);
        //        switch (comp.ComponentType)
        //        {
        //            case EComponentType.Label:

        //                PHText lbl = bh.GetCurrentVersionText(curlan, comp.PluggComponentId, ETextItemType.PluggComponentLabel);
        //                //This condition is used for editing plugg
        //                string LabHTMLstring = "";
        //                if (IsCase3)
        //                {

        //                    var Label_OrderTitle = (Plugghest.Modules.USerControl.DisplayPlugg.Common.OrderTitle)LoadControl(Plugghest.Base2.UserControlRoot.Common.OrderTitle);
        //                    Label_OrderTitle.ComponentType = EComponentType.Label;
        //                    Label_OrderTitle.Order = IntCompOrder;
        //                    Label_OrderTitle.TabID = TabId;
        //                    Label_OrderTitle.btnHandler += new Plugghest.Modules.USerControl.DisplayPlugg.Common.OrderTitle.OnButtonClick(WebUserControl1_btnHandler);
        //                    divTitle.Controls.Add(Label_OrderTitle);

        //                    var Label_Display = (Plugghest.Modules.USerControl.DisplayPlugg.Label.Display)LoadControl(Plugghest.Base2.UserControlRoot.Label.Display);
        //                    Label_Display.ComponentID = comp != null ? comp.PluggComponentId : 0;
        //                    Label_Display.Order = IntCompOrder;
        //                    divTitle.Controls.Add(Label_Display);

        //                    var Label_AddNewComponenet = (Plugghest.Modules.USerControl.DisplayPlugg.Common.AddNewComponent)LoadControl(Plugghest.Base2.UserControlRoot.Common.AddNewComponent);
        //                    Label_AddNewComponenet.Order = IntCompOrder;
        //                    Label_AddNewComponenet.isLastComp = isLastComp;
        //                    divTitle.Controls.Add(Label_AddNewComponenet);





        //                    //if (lbl.Text == "(No text)")
        //                    //    lbl.Text = "(currently no text)";
        //                    //LabHTMLstring = CreateDiv(lbl, "Label" + i, LabComponenttxt+" " + IntCompOrder + ": " + BtnLabelTxt);
        //                    //int orderid = comp.ComponentOrder;
        //                    //CreateBtnDel(orderid, "btncsdel", "btnlbDel" + i + "");
        //                    //CreateBtnEdit(comp, lbl, "btncsdel", "btnlbEdit" + i + "");

        //                    //if (isLastComp)
        //                    //{
        //                    //    LabHTMLstring = "<hr /></div>" + LabAddNewcomTxt + " after "+LabComponenttxt+" " + IntCompOrder + ": <select class='ddlclass' id='ddl" + i + "'>";
        //                    //}
        //                    //else
        //                    //{
        //                    //    LabHTMLstring = "<hr /></div>" + LabAddNewcomTxt + " between " + LabComponenttxt + " " + IntCompOrder + " and " + (IntCompOrder + 1).ToString() + ": <select class='ddlclass' id='ddl" + i + "'>";
        //                    //}
        //                    //LabHTMLstring = LabHTMLstring + ddl;
        //                    //divTitle.Controls.Add(new LiteralControl(LabHTMLstring));
        //                    //CreateBtnAdd(orderid, "btncs", "btnlbAdd" + i + "");
        //                    //divTitle.Controls.Add(new LiteralControl(str));
        //                }
        //                else if (lbl.Text == "(No text)")
        //                {
        //                    IntCompOrder--;
        //                    break;
        //                }
        //                //This condition is used for Translation The Plugg Text(same for all cases)
        //                else if (IsCase2)
        //                {
        //                    LabHTMLstring = CreateDiv(lbl, "Label" + i, LabComponenttxt + " " + IntCompOrder + ": " + BtnLabelTxt);
        //                    if (lbl.CultureCodeStatus == ECultureCodeStatus.GoogleTranslated)
        //                    {
        //                        CreateBtnImproveHumGoogleTrans(comp, lbl, "googletrans", "btnrtIGT" + i + "", BtnImpgoogleTransTxt);
        //                        CreateBtnGoogleT(lbl, "googleTrasok", "btnGTText" + i + "");
        //                    }
        //                    if (lbl.CultureCodeStatus == ECultureCodeStatus.HumanTranslated)
        //                    {
        //                        CreateBtnImproveHumGoogleTrans(comp, lbl, "btnhumantrans", "btnlbl" + i + "", BtnImproveHumTransTxt);
        //                    }
        //                    divTitle.Controls.Add(new LiteralControl(str));
        //                    chkComTxt = true;
        //                }
        //                else
        //                {
        //                    if (lbl.Text == "(No text)")
        //                    {
        //                        break;
        //                    }

        //                    if (lbl != null)
        //                    {
        //                        var Label_Display = (Plugghest.Modules.USerControl.DisplayPlugg.Label.Display)LoadControl(Plugghest.Base2.UserControlRoot.Label.Display);
        //                        Label_Display.ComponentID = comp != null ? comp.PluggComponentId : 0;
        //                        Label_Display.Order = IntCompOrder;
        //                        divTitle.Controls.Add(Label_Display);
        //                    }
        //                    //divTitle.Controls.Add(new LiteralControl("<div>" + lbl.Text + "</div> "));

        //                    //string LabHTMLstring = CreateDiv(lbl, "Label" + i, BtnLabelTxt);                          
        //                    chkComTxt = true;
        //                }

        //                break;

        //            case EComponentType.RichText:
        //                PHText rt = bh.GetCurrentVersionText(curlan, comp.PluggComponentId, ETextItemType.PluggComponentRichText);
        //                if (IsCase3)
        //                {

        //                    var RichText_OrderTitle = (Plugghest.Modules.USerControl.DisplayPlugg.Common.OrderTitle)LoadControl(Plugghest.Base2.UserControlRoot.Common.OrderTitle);
        //                    RichText_OrderTitle.ComponentType = EComponentType.RichText;
        //                    RichText_OrderTitle.Order = IntCompOrder;
        //                    RichText_OrderTitle.TabID = TabId;
        //                    RichText_OrderTitle.btnHandler += new Plugghest.Modules.USerControl.DisplayPlugg.Common.OrderTitle.OnButtonClick(WebUserControl1_btnHandler);
        //                    divTitle.Controls.Add(RichText_OrderTitle);

        //                    var RichText_Display = (Plugghest.Modules.USerControl.DisplayPlugg.RichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichText.Display);
        //                    RichText_Display.ComponentID = comp != null ? comp.PluggComponentId : 0;
        //                    RichText_Display.Order = IntCompOrder;
        //                    divTitle.Controls.Add(RichText_Display);

        //                    var RichText_AddNewComponenet = (Plugghest.Modules.USerControl.DisplayPlugg.Common.AddNewComponent)LoadControl(Plugghest.Base2.UserControlRoot.Common.AddNewComponent);
        //                    RichText_AddNewComponenet.Order = IntCompOrder;
        //                    RichText_AddNewComponenet.isLastComp = isLastComp;
        //                    divTitle.Controls.Add(RichText_AddNewComponenet);





        //                    //if (rt.Text == "(No text)")
        //                    //    rt.Text = "(currently no text)";

        //                    //string RtHTMLstring = CreateDiv(rt, "RichText" + i, LabComponenttxt+" " + IntCompOrder + ": " + BtnRichTextTxt);
        //                    //int RTorderid = comp.ComponentOrder;

        //                    //CreateBtnDel(RTorderid, "btncsdel", "btnrtDel" + i + "");
        //                    //CreateBtnEdit(comp, rt, "btncsdel", "btnrtEdit" + i + "");
        //                    //if (isLastComp)
        //                    //{
        //                    //    RtHTMLstring = "<hr /></div>" + LabAddNewcomTxt + " after " + LabComponenttxt + " " + IntCompOrder + ": <select class='ddlclass' id='Rtddl" + i + "'>";
        //                    //}
        //                    //else
        //                    //{
        //                    //    RtHTMLstring = "<hr /></div>" + LabAddNewcomTxt + " between " + LabComponenttxt + " " + IntCompOrder + " and " + (IntCompOrder + 1).ToString() + ": <select class='ddlclass' id='Rtddl" + i + "'>";
        //                    //}
        //                    //RtHTMLstring = RtHTMLstring + ddl;
        //                    //divTitle.Controls.Add(new LiteralControl(RtHTMLstring));
        //                    //CreateBtnAdd(RTorderid, "btncs", "btnrtAdd" + i + "");
        //                    //divTitle.Controls.Add(new LiteralControl(str));
        //                }
        //                else if (rt.Text == "(No text)")
        //                {
        //                    IntCompOrder--;
        //                    break;
        //                }
        //                else if (IsCase2)
        //                {

        //                    string RtHTMLstring = CreateDiv(rt, "RichText" + i, LabComponenttxt + " " + IntCompOrder + ": " + BtnRichTextTxt);
        //                    if (rt.CultureCodeStatus == ECultureCodeStatus.GoogleTranslated)
        //                    {
        //                        CreateBtnImproveHumGoogleTrans(comp, rt, "googletrans", "btnrtIGT" + i + "", BtnImpgoogleTransTxt);
        //                        CreateBtnGoogleT(rt, "googleTrasok", "btnrtGTText" + i + "");

        //                    }
        //                    if (rt.CultureCodeStatus == ECultureCodeStatus.HumanTranslated)
        //                    {
        //                        CreateBtnImproveHumGoogleTrans(comp, rt, "btnhumantrans", "btnrtIHT" + i + "", BtnImproveHumTransTxt);
        //                    }
        //                    divTitle.Controls.Add(new LiteralControl(str));
        //                    chkComTxt = true;
        //                }
        //                else
        //                {
        //                    if (rt.Text == "(No text)")
        //                    {
        //                        break;
        //                    }
        //                    var RichText_Display = (Plugghest.Modules.USerControl.DisplayPlugg.RichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichText.Display);
        //                    RichText_Display.ComponentID = comp != null ? comp.PluggComponentId : 0;
        //                    RichText_Display.Order = IntCompOrder;
        //                    divTitle.Controls.Add(RichText_Display);
        //                    //divTitle.Controls.Add(new LiteralControl("<div>" + rt.Text + "</div> "));
        //                    //// string RtHTMLstring = CreateDiv(rt, "RichText" + i, BtnRichTextTxt);

        //                    chkComTxt = true;
        //                }
        //                break;

        //            case EComponentType.RichRichText:
        //                PHText rrt = bh.GetCurrentVersionText(curlan, comp.PluggComponentId, ETextItemType.PluggComponentRichRichText);
        //                if (IsCase3)
        //                {
        //                    var RichRich_OrderTitle = (Plugghest.Modules.USerControl.DisplayPlugg.Common.OrderTitle)LoadControl(Plugghest.Base2.UserControlRoot.Common.OrderTitle);
        //                    RichRich_OrderTitle.ComponentType = EComponentType.RichRichText;
        //                    RichRich_OrderTitle.Order = IntCompOrder;
        //                    RichRich_OrderTitle.TabID = TabId;
        //                    RichRich_OrderTitle.btnHandler += new Plugghest.Modules.USerControl.DisplayPlugg.Common.OrderTitle.OnButtonClick(WebUserControl1_btnHandler);
        //                    divTitle.Controls.Add(RichRich_OrderTitle);

        //                    var RichRich_Display = (Plugghest.Modules.USerControl.DisplayPlugg.RichRichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.Display);
        //                    RichRich_Display.ComponentID = comp != null ? comp.PluggComponentId : 0;
        //                    RichRich_Display.Order = IntCompOrder;
        //                    divTitle.Controls.Add(RichRich_Display);

        //                    var RichRich_AddNewComponenet = (Plugghest.Modules.USerControl.DisplayPlugg.Common.AddNewComponent)LoadControl(Plugghest.Base2.UserControlRoot.Common.AddNewComponent);
        //                    RichRich_AddNewComponenet.Order = IntCompOrder;
        //                    RichRich_AddNewComponenet.isLastComp = isLastComp;
        //                    divTitle.Controls.Add(RichRich_AddNewComponenet);






        //                    //if (rrt.Text == "(No text)")
        //                    //    rrt.Text = "(currently no text)";

        //                    //string RRTHTMLstring = CreateDiv(rrt, "RichRichText" + i, LabComponenttxt+" " + IntCompOrder + ": " + BtnRichRichTxttxt);
        //                    //int RRTorderid = comp.ComponentOrder;

        //                    //CreateBtnDel(RRTorderid, "btncsdel", "btnrrtDel" + i + "");
        //                    //CreateBtnEdit(comp, rrt, "btncsdel", "btnrrtEdit" + i + "");
        //                    //if (isLastComp)
        //                    //{
        //                    //    RRTHTMLstring = "<hr /></div>" + LabAddNewcomTxt + " after " + LabComponenttxt + " " + IntCompOrder + ": <select class='ddlclass' id='Rtddl" + i + "'>";
        //                    //}
        //                    //else
        //                    //{
        //                    //    RRTHTMLstring = "<hr /></div>" + LabAddNewcomTxt + " between " + LabComponenttxt + " " + IntCompOrder + " and " + (IntCompOrder + 1).ToString() + ": <select class='ddlclass' id='Rtddl" + i + "'>";
        //                    //}
        //                    //RRTHTMLstring = RRTHTMLstring + ddl;
        //                    //divTitle.Controls.Add(new LiteralControl(RRTHTMLstring));

        //                    //CreateBtnAdd(RRTorderid, "btncs", "btnrrtAdd" + i + "");


        //                    //divTitle.Controls.Add(new LiteralControl(str));
        //                }
        //                else if (rrt.Text == "(No text)")
        //                {
        //                    IntCompOrder--;
        //                    break;
        //                }
        //                else if (IsCase2)
        //                {
        //                    string RRTHTMLstring = CreateDiv(rrt, "RichRichText" + i, LabComponenttxt + " " + IntCompOrder + ": " + BtnRichRichTxttxt);
        //                    if (rrt.CultureCodeStatus == ECultureCodeStatus.GoogleTranslated)
        //                    {
        //                        CreateBtnImproveHumGoogleTrans(comp, rrt, "googletrans", "btnrrtIGT" + i + "", BtnImpgoogleTransTxt);
        //                        CreateBtnGoogleT(rrt, "googleTrasok", "btnrrtGTText" + i + "");
        //                    }
        //                    if (rrt.CultureCodeStatus == ECultureCodeStatus.HumanTranslated)
        //                    {
        //                        CreateBtnImproveHumGoogleTrans(comp, rrt, "btnhumantrans", "btnrrtIHT" + i + "", BtnImproveHumTransTxt);

        //                    }

        //                    divTitle.Controls.Add(new LiteralControl(str));
        //                    chkComTxt = true;
        //                }
        //                else
        //                {
        //                    if (rrt.Text == "(No text)")
        //                    {
        //                        break;
        //                    }

        //                    //divTitle.Controls.Add(new LiteralControl("<div>" + rrt.Text + "</div> "));
        //                    var RichRich_Display = (Plugghest.Modules.USerControl.DisplayPlugg.RichRichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.Display);
        //                    RichRich_Display.ComponentID = comp != null ? comp.PluggComponentId : 0;
        //                    RichRich_Display.Order = IntCompOrder;
        //                    divTitle.Controls.Add(RichRich_Display);
        //                    ////string RRTHTMLstring = CreateDiv(rrt, "RichRichText" + i, BtnRichRichTxttxt);
        //                    chkComTxt = true;
        //                }
        //                break;

        //            case EComponentType.Latex:
        //                PHLatex lat = bh.GetCurrentVersionLatexText(curlan, comp.PluggComponentId, ELatexItemType.PluggComponentLatex);
        //                if (IsCase3)
        //                {
        //                    var Latex_OrderTitle = (Plugghest.Modules.USerControl.DisplayPlugg.Common.OrderTitle)LoadControl(Plugghest.Base2.UserControlRoot.Common.OrderTitle);
        //                    Latex_OrderTitle.ComponentType = EComponentType.Latex;
        //                    Latex_OrderTitle.Order = IntCompOrder;
        //                    Latex_OrderTitle.TabID = TabId;
        //                    Latex_OrderTitle.btnHandler += new Plugghest.Modules.USerControl.DisplayPlugg.Common.OrderTitle.OnButtonClick(WebUserControl1_btnHandler);
        //                    divTitle.Controls.Add(Latex_OrderTitle);

        //                    var Latex_Display = (Plugghest.Modules.USerControl.DisplayPlugg.Latex.Display)LoadControl(Plugghest.Base2.UserControlRoot.Latex.Display);
        //                    Latex_Display.ComponentID = comp != null ? comp.PluggComponentId : 0;
        //                    Latex_Display.Order = IntCompOrder;
        //                    divTitle.Controls.Add(Latex_Display);

        //                    var Latex_AddNewComponenet = (Plugghest.Modules.USerControl.DisplayPlugg.Common.AddNewComponent)LoadControl(Plugghest.Base2.UserControlRoot.Common.AddNewComponent);
        //                    Latex_AddNewComponenet.Order = IntCompOrder;
        //                    Latex_AddNewComponenet.isLastComp = isLastComp;
        //                    divTitle.Controls.Add(Latex_AddNewComponenet);

        //                    // if (lat.Text == "(No text)")
        //                    //     lat.Text = "(currently no text)";
        //                    // string LatHTMLstring = CreateDivLat(lat, "Latex" + i, IntCompOrder);
        //                    //// string RRTHTMLstring = CreateDivLat(lat, "Latex" + i, "Component " + IntCompOrder + ": " + BtnRichRichTxttxt, IntCompOrder);
        //                    // int ltorderid = comp.ComponentOrder;



        //                    // CreateBtnDel(ltorderid, "btncsdel", "btnltDel" + i + "");

        //                    // Button editbtn = new Button();
        //                    // editbtn.CssClass = "btncsdel";
        //                    // editbtn.ID = "btnltEdit" + i;
        //                    // editbtn.Text = BtnEditTxt;
        //                    // editbtn.Click += (s, e) => { CallLatFun(ltorderid, comp, lat, "1"); };
        //                    // divTitle.Controls.Add(editbtn);

        //                    // if (isLastComp)
        //                    // {
        //                    //     LatHTMLstring = "<hr /></div>" + LabAddNewcomTxt + " after " + LabComponenttxt + " " + IntCompOrder + ": <select class='ddlclass' id='ltddl" + i + "'>";
        //                    // }
        //                    // else
        //                    // {
        //                    //     LatHTMLstring = "<hr /></div>" + LabAddNewcomTxt + " between " + LabComponenttxt + " " + IntCompOrder + " and " + (IntCompOrder + 1).ToString() + ": <select class='ddlclass' id='ltddl" + i + "'>";
        //                    // }
        //                    //     LatHTMLstring = LatHTMLstring + ddl;
        //                    // divTitle.Controls.Add(new LiteralControl(LatHTMLstring));
        //                    // CreateBtnAdd(ltorderid, "btncs", "btnlatexAdd" + i + "");
        //                    // divTitle.Controls.Add(new LiteralControl(str));
        //                }

        //                else
        //                {
        //                    if (lat.Text == "(No text)")
        //                    {
        //                        break;
        //                    }
        //                    var Latex_Display = (Plugghest.Modules.USerControl.DisplayPlugg.Latex.Display)LoadControl(Plugghest.Base2.UserControlRoot.Latex.Display);
        //                    Latex_Display.ComponentID = comp != null ? comp.PluggComponentId : 0;
        //                    Latex_Display.Order = IntCompOrder;
        //                    divTitle.Controls.Add(Latex_Display);

        //                    //sdivTitle.Controls.Add(new LiteralControl("<div>" + lat.Text + "</div> "));  
        //                    string LatHTMLstring = CreateDivLat(lat, "Latex" + i, IntCompOrder);
        //                    if (IsCase2)
        //                        divTitle.Controls.Add(new LiteralControl("<hr />"));
        //                    chkComTxt = true;
        //                }

        //                break;


        //            case EComponentType.YouTube:
        //                YouTube yt = bh.GetYouTubeByComponentId(comp.PluggComponentId);
        //                string strYoutubeIframe = "";
        //                string ytYouTubecode = "";
        //                try
        //                {
        //                    strYoutubeIframe = yt.GetIframeString(p.CultureCode);
        //                }
        //                catch
        //                {
        //                    strYoutubeIframe = "(currently no video)";
        //                }
        //                if (yt == null)
        //                {
        //                    ytYouTubecode = "(currently no video)";
        //                }
        //                else
        //                {
        //                    ytYouTubecode = yt.YouTubeCode;
        //                }
        //                var ytdivid = "Youtube" + i;
        //                var ytddlid = "ytddl" + i;
        //                var ytorderid = comp.ComponentOrder;
        //                string ytHTMLstring = "";
        //                if (IsCase3)
        //                {
        //                    // ytHTMLstring = "<div><div id=" + ytdivid + " class='Main'>" + LabComponenttxt+" " + IntCompOrder + ": " + "YouTube";

        //                    var YouTube_OrderTitle = (Plugghest.Modules.USerControl.DisplayPlugg.Common.OrderTitle)LoadControl(Plugghest.Base2.UserControlRoot.Common.OrderTitle);
        //                    YouTube_OrderTitle.ComponentType = EComponentType.YouTube;
        //                    YouTube_OrderTitle.Order = IntCompOrder;
        //                    YouTube_OrderTitle.TabID = TabId;
        //                    YouTube_OrderTitle.btnHandler += new Plugghest.Modules.USerControl.DisplayPlugg.Common.OrderTitle.OnButtonClick(WebUserControl1_btnHandler);
        //                    divTitle.Controls.Add(YouTube_OrderTitle);

        //                    var YouTube_Display = (Plugghest.Modules.USerControl.DisplayPlugg.YouTube.Display)LoadControl(Plugghest.Base2.UserControlRoot.YouTube.Display);
        //                    YouTube_Display.YTComponentId = yt != null ? yt.PluggComponentId : 0;
        //                    divTitle.Controls.Add(YouTube_Display);

        //                    var YouTube_AddNewComponenet = (Plugghest.Modules.USerControl.DisplayPlugg.Common.AddNewComponent)LoadControl(Plugghest.Base2.UserControlRoot.Common.AddNewComponent);
        //                    YouTube_AddNewComponenet.Order = IntCompOrder;
        //                    YouTube_AddNewComponenet.isLastComp = isLastComp;
        //                    divTitle.Controls.Add(YouTube_AddNewComponenet);


        //                    //divTitle.Controls.Add(new LiteralControl(ytHTMLstring));

        //                    //CreateBtnDel(ytorderid, "btncsdel", "btnytDel" + i + "");

        //                    //string IdYt = "btnrrtEdit" + i;

        //                    //CreateBtnYTEdit(comp, yt, ytorderid, "btncsdel", "IdYt" + i + "");
        //                    //if (isLastComp)
        //                    //{
        //                    //    ytHTMLstring = "</div>" + strYoutubeIframe + "</br><hr />" + LabAddNewcomTxt + " after " + LabComponenttxt + " " + IntCompOrder + ": <select class='ddlclass' id=" + ytddlid + ">";
        //                    //}
        //                    //else
        //                    //{
        //                    //    ytHTMLstring = "</div>" + strYoutubeIframe + "</br><hr />" + LabAddNewcomTxt + " between " + LabComponenttxt + " " + IntCompOrder + " and " + (IntCompOrder + 1).ToString() + ": <select class='ddlclass' id=" + ytddlid + ">";
        //                    //}
        //                    //ytHTMLstring = ytHTMLstring + ddl;
        //                    //divTitle.Controls.Add(new LiteralControl(ytHTMLstring));

        //                    //CreateBtnAdd(ytorderid, "btncs", "btnytAdd" + i + "");

        //                    //divTitle.Controls.Add(new LiteralControl(str));
        //                }
        //                else if (strYoutubeIframe == "(currently no video)")
        //                {
        //                    IntCompOrder--;
        //                    break;
        //                }
        //                else
        //                {
        //                    if (strYoutubeIframe == "(currently no video)")
        //                    {
        //                        break;
        //                    }
        //                    var YouTube_Display = (Plugghest.Modules.USerControl.DisplayPlugg.YouTube.Display)LoadControl(Plugghest.Base2.UserControlRoot.YouTube.Display);
        //                    YouTube_Display.YTComponentId = yt != null ? yt.PluggComponentId : 0;
        //                    divTitle.Controls.Add(YouTube_Display);
        //                    //divTitle.Controls.Add(new LiteralControl("<div>" + strYoutubeIframe + "</div> "));
        //                    ytHTMLstring = "<div>" + strYoutubeIframe + "</div>";
        //                    if (IsCase2)

        //                        divTitle.Controls.Add(new LiteralControl("<div><div id=" + ytdivid + " class='Main'>" + LabComponenttxt + " " + IntCompOrder + ": " + "YouTube"));

        //                    divTitle.Controls.Add(new LiteralControl(ytHTMLstring));
        //                    if (IsCase2)
        //                        divTitle.Controls.Add(new LiteralControl("<hr />"));



        //                    chkComTxt = true;
        //                    //DisplayYouTube.YTComponentId = yt.PluggComponentId;

        //                    //YouTubeControl.Order = comp.ComponentOrder;
        //                    //YouTubeControl.Mode = "Edit1";
        //                    //YouTubeControl.YouTubeId = yt.YouTubeId;
        //                    //YouTubeControl.
        //                }

        //                break;
        //        }
        //        i++;
        //        IntCompOrder++;
        //    }
        //    if (!chkComTxt)
        //        ShowNoComMsg();
        //}
        #endregion
    }
}