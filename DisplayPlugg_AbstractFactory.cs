using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugghest.Modules.DisplayPlugg
{
    public class ControlViewModel
    {
        public EComponentType ComponentType { get; set; }
        public int ComponentID { get; set; }
        public int UserID { get; set; }
        public int Order { get; set; }
        public int TabID { get; set; }
        public bool isLastComp { get; set; }
        public System.Web.UI.UserControl _this { get; set; }
    }

    //Abstract patterns
    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    public abstract class DisplayPlugg_AbstractFactory
    {
        public abstract AbstractView CreateLabel();
        public abstract AbstractView CreateLatex();
        public abstract AbstractView CreateRich();
        public abstract AbstractView CreateRichRich();
        public abstract AbstractView CreateYouTube();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    public class ConcreteCase_ViewInCreationLangNotAuth : DisplayPlugg_AbstractFactory
    {
        private static ConcreteCase_ViewInCreationLangNotAuth myVar;
        public static ConcreteCase_ViewInCreationLangNotAuth Instance
        {
            get
            {
                // Uses lazy initialization.
                // Note: this is not thread safe.
                if (null == myVar)
                    myVar = new ConcreteCase_ViewInCreationLangNotAuth();
                return myVar;
            }
        }

        private ConcreteCase_ViewInCreationLangNotAuth()
        { }

        public override AbstractView CreateLabel()
        {
            return new Label_ViewInCreationLangNotAuth();
        }
        public override AbstractView CreateLatex()
        {
            return new Latex_ViewInCreationLangNotAuth();
        }
        public override AbstractView CreateRich()
        {
            return new RichText_ViewInCreationLangNotAuth();
        }
        public override AbstractView CreateRichRich()
        {
            return new RichRichText_ViewInCreationLangNotAuth();
        }
        public override AbstractView CreateYouTube()
        {
            return new YouTube_ViewInCreationLangNotAuth();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    public class ConcreteCase_ViewInAltLang : DisplayPlugg_AbstractFactory
    {
        private static ConcreteCase_ViewInAltLang myVar;
        public static ConcreteCase_ViewInAltLang Instance
        {
            get
            {
                // Uses lazy initialization.
                // Note: this is not thread safe.
                if (null == myVar)
                    myVar = new ConcreteCase_ViewInAltLang();
                return myVar;
            }
        }

        private ConcreteCase_ViewInAltLang()
        { }

        public override AbstractView CreateLabel()
        {
            return new Label_ViewInAltLang();
        }
        public override AbstractView CreateLatex()
        {
            return new Latex_ViewInAltLang();
        }
        public override AbstractView CreateRich()
        {
            return new RichText_ViewInAltLang();
        }
        public override AbstractView CreateRichRich()
        {
            return new RichRichText_ViewInAltLang();
        }
        public override AbstractView CreateYouTube()
        {
            return new YouTube_ViewInAltLang();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory3' class
    /// </summary>
    public class ConcreteCase_ViewInCreationLangAuth : DisplayPlugg_AbstractFactory
    {
        private static ConcreteCase_ViewInCreationLangAuth myVar;
        public static ConcreteCase_ViewInCreationLangAuth Instance
        {
            get
            {
                // Uses lazy initialization.
                // Note: this is not thread safe.
                if (null == myVar)
                    myVar = new ConcreteCase_ViewInCreationLangAuth();
                return myVar;
            }
        }

        private ConcreteCase_ViewInCreationLangAuth()
        { }

        public override AbstractView CreateLabel()
        {
            return new Label_ViewInCreationLangAuth();
        }
        public override AbstractView CreateLatex()
        {
            return new Latex_ViewInCreationLangAuth();
        }
        public override AbstractView CreateRich()
        {
            return new RichText_ViewInCreationLangAuth();
        }
        public override AbstractView CreateRichRich()
        {
            return new RichRichText_ViewInCreationLangAuth();
        }
        public override AbstractView CreateYouTube()
        {
            return new YouTube_ViewInCreationLangAuth();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory3' class
    /// </summary>
    public class ConcreteCase_Edit : DisplayPlugg_AbstractFactory
    {
        private static ConcreteCase_Edit myVar;
        public static ConcreteCase_Edit Instance
        {
            get
            {
                // Uses lazy initialization.
                // Note: this is not thread safe.
                if (null == myVar)
                    myVar = new ConcreteCase_Edit();
                return myVar;
            }
        }

        private ConcreteCase_Edit()
        { }

        public override AbstractView CreateLabel()
        {
            return new Label_Edit();
        }
        public override AbstractView CreateLatex()
        {
            return new Latex_Edit();
        }
        public override AbstractView CreateRich()
        {
            return new RichText_Edit();
        }
        public override AbstractView CreateRichRich()
        {
            return new RichRichText_Edit();
        }
        public override AbstractView CreateYouTube()
        {
            return new YouTube_Edit();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory3' class
    /// </summary>
    public class ConcreteCase_Translate : DisplayPlugg_AbstractFactory
    {
        private static ConcreteCase_Translate myVar;
        public static ConcreteCase_Translate Instance
        {
            get
            {
                // Uses lazy initialization.
                // Note: this is not thread safe.
                if (null == myVar)
                    myVar = new ConcreteCase_Translate();
                return myVar;
            }
        }

        private ConcreteCase_Translate()
        { }

        public override AbstractView CreateLabel()
        {
            return new Label_Translate();
        }
        public override AbstractView CreateLatex()
        {
            return new Latex_Translate();
        }
        public override AbstractView CreateRich()
        {
            return new RichText_Translate();
        }
        public override AbstractView CreateRichRich()
        {
            return new RichRichText_Translate();
        }
        public override AbstractView CreateYouTube()
        {
            return new YouTube_Translate();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory6' class
    /// </summary>
    public class ConcreteCase_SubEdit : DisplayPlugg_AbstractFactory
    {
        private static ConcreteCase_SubEdit myVar;
        public static ConcreteCase_SubEdit Instance
        {
            get
            {
                // Uses lazy initialization.
                // Note: this is not thread safe.
                if (null == myVar)
                    myVar = new ConcreteCase_SubEdit();
                return myVar;
            }
        }

        private ConcreteCase_SubEdit()
        { }


        public override AbstractView CreateLabel()
        {
            return new Label_SubEdit();
        }
        public override AbstractView CreateLatex()
        {
            return new Latex_SubEdit();
        }
        public override AbstractView CreateRich()
        {
            return new RichText_SubEdit();
        }
        public override AbstractView CreateRichRich()
        {
            return new RichRichText_SubEdit();
        }
        public override AbstractView CreateYouTube()
        {
            return new YouTube_SubEdit();
        }
    }

    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    public abstract class AbstractView : System.Web.UI.UserControl
    {
        public abstract void Display(ControlViewModel obj);
        public abstract void Edit1(ControlViewModel obj);
        public abstract void Edit2(ControlViewModel obj);
    }

    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    public abstract class AbstractLatex
    {
        public abstract void Display(ControlViewModel obj);
        public abstract void Edit1(ControlViewModel obj);
        public abstract void Edit2(ControlViewModel obj);
    }

    #region Label
    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    public class Label_ViewInCreationLangNotAuth : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var Label_Display = (Plugghest.Modules.UserControl.DisplayPlugg.Label.Display)LoadControl(Plugghest.Base2.UserControlRoot.Label.Display);
            Label_Display.Parent_Page = obj._this.Page;
            Label_Display.ComponentID = obj.ComponentID;
            Label_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(Label_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    public class Label_ViewInAltLang : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {

        }

        public override void Edit1(ControlViewModel obj)
        {
        }

        public override void Edit2(ControlViewModel obj)
        {
            var Label_Edit2 = (Plugghest.Modules.UserControl.DisplayPlugg.Label.Edit2)LoadControl(Plugghest.Base2.UserControlRoot.Label.Edit2);
            Label_Edit2.Parent_Page = obj._this.Page;
            Label_Edit2.Order = obj.Order;
            Label_Edit2.ComponentID = obj.ComponentID;
            obj._this.FindControl("divTitle").Controls.Add(Label_Edit2);
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    public class Label_ViewInCreationLangAuth : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var Label_Display = (Plugghest.Modules.UserControl.DisplayPlugg.Label.Display)LoadControl(Plugghest.Base2.UserControlRoot.Label.Display);
            Label_Display.Parent_Page = obj._this.Page;
            Label_Display.ComponentID = obj.ComponentID; //comp != null ? comp.PluggComponentId : 0;
            Label_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(Label_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {
        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    public class Label_Translate : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var Label_TranslationTitle = (Plugghest.Modules.UserControl.DisplayPlugg.Label.TranslationTitle)LoadControl(Plugghest.Base2.UserControlRoot.Label.TranslationTitle);
            Label_TranslationTitle.Parent_Page = obj._this.Page;
            Label_TranslationTitle.ComponentType = obj.ComponentType;
            Label_TranslationTitle.ComponentID = obj.ComponentID;
            Label_TranslationTitle.UserID = obj.UserID;
            Label_TranslationTitle.Order = obj.Order;
            Label_TranslationTitle.TabID = obj.TabID;
            obj._this.FindControl("divTitle").Controls.Add(Label_TranslationTitle);

            var Label_Display = (Plugghest.Modules.UserControl.DisplayPlugg.Label.Display)LoadControl(Plugghest.Base2.UserControlRoot.Label.Display);
            Label_Display.Parent_Page = obj._this.Page;
            Label_Display.ComponentID = obj.ComponentID;
            Label_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(Label_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {
        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    public class Label_Edit : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {

            var Label_OrderTitle = (Plugghest.Modules.UserControl.DisplayPlugg.Common.OrderTitle)LoadControl(Plugghest.Base2.UserControlRoot.Common.OrderTitle);
            Label_OrderTitle.Parent_Page = obj._this.Page;
            Label_OrderTitle.ComponentType = obj.ComponentType;
            Label_OrderTitle.ComponentID = obj.ComponentID; //comp != null ? comp.PluggComponentId : 0;
            Label_OrderTitle.UserID = obj.UserID;
            Label_OrderTitle.Order = obj.Order;
            Label_OrderTitle.TabID = obj.TabID;
            //Label_OrderTitle.btnHandler += new Plugghest.Modules.UserControl.DisplayPlugg.Common.OrderTitle.OnButtonClick(WebUserControl1_btnHandler);
            obj._this.FindControl("divTitle").Controls.Add(Label_OrderTitle);

            var Label_Display = (Plugghest.Modules.UserControl.DisplayPlugg.Label.Display)LoadControl(Plugghest.Base2.UserControlRoot.Label.Display);
            Label_Display.Parent_Page = obj._this.Page;
            Label_Display.ComponentID = obj.ComponentID; //comp != null ? comp.PluggComponentId : 0;
            Label_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(Label_Display);

            var Label_AddNewComponenet = (Plugghest.Modules.UserControl.DisplayPlugg.Common.AddNewComponent)LoadControl(Plugghest.Base2.UserControlRoot.Common.AddNewComponent);
            Label_AddNewComponenet.Parent_Page = obj._this.Page;
            Label_AddNewComponenet.Order = obj.Order; //IntCompOrder;
            Label_AddNewComponenet.isLastComp = obj.isLastComp;
            obj._this.FindControl("divTitle").Controls.Add(Label_AddNewComponenet);
        }

        public override void Edit1(ControlViewModel obj)
        {
        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    public class Label_SubEdit : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {

        }

        public override void Edit1(ControlViewModel obj)
        {
            var Label_Edit1 = (Plugghest.Modules.UserControl.DisplayPlugg.Label.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.Label.Edit1);
            Label_Edit1.Parent_Page = obj._this.Page;
            Label_Edit1.UserID = obj.UserID;
            Label_Edit1.Order = obj.Order;
            Label_Edit1.ComponentID = obj.ComponentID;
            Label_Edit1.ComponentType = obj.ComponentType;
            Label_Edit1.TabID = obj.TabID;
            obj._this.FindControl("divTitle").Controls.Add(Label_Edit1);
        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }
    #endregion

    #region Latex
    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    public class Latex_ViewInCreationLangNotAuth : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var Latex_Display = (Plugghest.Modules.UserControl.DisplayPlugg.Latex.Display)LoadControl(Plugghest.Base2.UserControlRoot.Latex.Display);
            Latex_Display.Parent_Page = obj._this.Page;
            Latex_Display.ComponentID = obj.ComponentID;
            Latex_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(Latex_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {
            Console.WriteLine("Latex - I - Edit1");
        }

        public override void Edit2(ControlViewModel obj)
        {
            Console.WriteLine("Latex - I - Edit2");
        }
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    public class Latex_ViewInAltLang : AbstractView
    {

        public override void Display(ControlViewModel obj)
        {

        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class Latex_ViewInCreationLangAuth : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var Latex_Display = (Plugghest.Modules.UserControl.DisplayPlugg.Latex.Display)LoadControl(Plugghest.Base2.UserControlRoot.Latex.Display);
            Latex_Display.Parent_Page = obj._this.Page;
            Latex_Display.ComponentID = obj.ComponentID;
            Latex_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(Latex_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class Latex_Translate : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var Latex_TranslationTitle = (Plugghest.Modules.UserControl.DisplayPlugg.Latex.TranslationTitle)LoadControl(Plugghest.Base2.UserControlRoot.Latex.TranslationTitle);
            Latex_TranslationTitle.Parent_Page = obj._this.Page;
            Latex_TranslationTitle.ComponentType = obj.ComponentType;
            Latex_TranslationTitle.ComponentID = obj.ComponentID;
            Latex_TranslationTitle.UserID = obj.UserID;
            Latex_TranslationTitle.Order = obj.Order;
            Latex_TranslationTitle.TabID = obj.TabID;
            obj._this.FindControl("divTitle").Controls.Add(Latex_TranslationTitle);

            var Latex_Display = (Plugghest.Modules.UserControl.DisplayPlugg.Latex.Display)LoadControl(Plugghest.Base2.UserControlRoot.Latex.Display);
            Latex_Display.Parent_Page = obj._this.Page;
            Latex_Display.ComponentID = obj.ComponentID;
            Latex_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(Latex_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class Latex_Edit : AbstractView
    {

        public override void Display(ControlViewModel obj)
        {
            var Latex_OrderTitle = (Plugghest.Modules.UserControl.DisplayPlugg.Common.OrderTitle)LoadControl(Plugghest.Base2.UserControlRoot.Common.OrderTitle);
            Latex_OrderTitle.Parent_Page = obj._this.Page;
            Latex_OrderTitle.ComponentType = EComponentType.Latex;
            Latex_OrderTitle.ComponentID = obj.ComponentID;
            Latex_OrderTitle.UserID = obj.UserID;
            Latex_OrderTitle.Order = obj.Order;
            Latex_OrderTitle.TabID = obj.TabID;
            //Latex_OrderTitle.btnHandler += new Plugghest.Modules.UserControl.DisplayPlugg.Common.OrderTitle.OnButtonClick(WebUserControl1_btnHandler);
            obj._this.FindControl("divTitle").Controls.Add(Latex_OrderTitle);

            var Latex_Display = (Plugghest.Modules.UserControl.DisplayPlugg.Latex.Display)LoadControl(Plugghest.Base2.UserControlRoot.Latex.Display);
            Latex_Display.Parent_Page = obj._this.Page;
            Latex_Display.ComponentID = obj.ComponentID;
            Latex_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(Latex_Display);

            var Latex_AddNewComponenet = (Plugghest.Modules.UserControl.DisplayPlugg.Common.AddNewComponent)LoadControl(Plugghest.Base2.UserControlRoot.Common.AddNewComponent);
            Latex_AddNewComponenet.Parent_Page = obj._this.Page;
            Latex_AddNewComponenet.Order = obj.Order;
            Latex_AddNewComponenet.isLastComp = obj.isLastComp;
            obj._this.FindControl("divTitle").Controls.Add(Latex_AddNewComponenet);
        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class Latex_SubEdit : AbstractView
    {

        public override void Display(ControlViewModel obj)
        {

        }

        public override void Edit1(ControlViewModel obj)
        {
            var Latex_Edit1 = (Plugghest.Modules.UserControl.DisplayPlugg.Latex.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.Latex.Edit1);
            Latex_Edit1.Parent_Page = obj._this.Page;
            Latex_Edit1.UserID = obj.UserID;
            Latex_Edit1.Order = obj.Order;
            Latex_Edit1.ComponentID = obj.ComponentID;
            Latex_Edit1.ComponentType = obj.ComponentType;
            Latex_Edit1.TabID = obj.TabID;
            obj._this.FindControl("divTitle").Controls.Add(Latex_Edit1);
        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }
    #endregion

    #region RichText
    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class RichText_ViewInCreationLangNotAuth : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var RichText_Display = (Plugghest.Modules.UserControl.DisplayPlugg.RichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichText.Display);
            RichText_Display.Parent_Page = obj._this.Page;
            RichText_Display.ComponentID = obj.ComponentID;
            RichText_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(RichText_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {
            Console.WriteLine("Latex - I - Edit1");
        }

        public override void Edit2(ControlViewModel obj)
        {
            Console.WriteLine("Latex - I - Edit2");
        }
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    public class RichText_ViewInAltLang : AbstractView
    {

        public override void Display(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Display");
        }

        public override void Edit1(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Edit1");
        }

        public override void Edit2(ControlViewModel obj)
        {
            var Rich_Edit2 = (Plugghest.Modules.UserControl.DisplayPlugg.RichText.Edit2)LoadControl(Plugghest.Base2.UserControlRoot.RichText.Edit2);
            Rich_Edit2.Parent_Page = obj._this.Page;
            Rich_Edit2.Order = obj.Order;
            Rich_Edit2.ComponentID = obj.ComponentID;
            obj._this.FindControl("divTitle").Controls.Add(Rich_Edit2);
        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class RichText_ViewInCreationLangAuth : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var RichText_Display = (Plugghest.Modules.UserControl.DisplayPlugg.RichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichText.Display);
            RichText_Display.Parent_Page = obj._this.Page;
            RichText_Display.ComponentID = obj.ComponentID;
            RichText_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(RichText_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Edit1");
        }

        public override void Edit2(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Edit2");
        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class RichText_Translate : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var Latex_TranslationTitle = (Plugghest.Modules.UserControl.DisplayPlugg.RichText.TranslationTitle)LoadControl(Plugghest.Base2.UserControlRoot.RichText.TranslationTitle);
            Latex_TranslationTitle.Parent_Page = obj._this.Page;
            Latex_TranslationTitle.ComponentType = obj.ComponentType;
            Latex_TranslationTitle.ComponentID = obj.ComponentID;
            Latex_TranslationTitle.UserID = obj.UserID;
            Latex_TranslationTitle.Order = obj.Order;
            Latex_TranslationTitle.TabID = obj.TabID;
            obj._this.FindControl("divTitle").Controls.Add(Latex_TranslationTitle);

            var RichText_Display = (Plugghest.Modules.UserControl.DisplayPlugg.RichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichText.Display);
            RichText_Display.Parent_Page = obj._this.Page;
            RichText_Display.ComponentID = obj.ComponentID;
            RichText_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(RichText_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Edit1");
        }

        public override void Edit2(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Edit2");
        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class RichText_Edit : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var RichText_OrderTitle = (Plugghest.Modules.UserControl.DisplayPlugg.Common.OrderTitle)LoadControl(Plugghest.Base2.UserControlRoot.Common.OrderTitle);
            RichText_OrderTitle.Parent_Page = obj._this.Page;
            RichText_OrderTitle.ComponentType = EComponentType.RichText;
            RichText_OrderTitle.ComponentID = obj.ComponentID;
            RichText_OrderTitle.UserID = obj.UserID;
            RichText_OrderTitle.Order = obj.Order;
            RichText_OrderTitle.TabID = obj.TabID;
            //RichText_OrderTitle.btnHandler += new Plugghest.Modules.UserControl.DisplayPlugg.Common.OrderTitle.OnButtonClick(WebUserControl1_btnHandler);
            obj._this.FindControl("divTitle").Controls.Add(RichText_OrderTitle);

            var RichText_Display = (Plugghest.Modules.UserControl.DisplayPlugg.RichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichText.Display);
            RichText_Display.Parent_Page = obj._this.Page;
            RichText_Display.ComponentID = obj.ComponentID;
            RichText_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(RichText_Display);

            var RichText_AddNewComponenet = (Plugghest.Modules.UserControl.DisplayPlugg.Common.AddNewComponent)LoadControl(Plugghest.Base2.UserControlRoot.Common.AddNewComponent);
            RichText_AddNewComponenet.Parent_Page = obj._this.Page;
            RichText_AddNewComponenet.Order = obj.Order;
            RichText_AddNewComponenet.isLastComp = obj.isLastComp;
            obj._this.FindControl("divTitle").Controls.Add(RichText_AddNewComponenet);
        }

        public override void Edit1(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Edit1");
        }

        public override void Edit2(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Edit2");
        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class RichText_SubEdit : AbstractView
    {

        public override void Display(ControlViewModel obj)
        {

        }

        public override void Edit1(ControlViewModel obj)
        {
            var RichText_Edit1 = (Plugghest.Modules.UserControl.DisplayPlugg.RichText.Edit)LoadControl(Plugghest.Base2.UserControlRoot.RichText.Edit1);
            RichText_Edit1.Parent_Page = obj._this.Page;
            RichText_Edit1.UserID = obj.UserID;
            RichText_Edit1.Order = obj.Order;
            RichText_Edit1.ComponentID = obj.ComponentID;
            RichText_Edit1.ComponentType = obj.ComponentType;
            RichText_Edit1.TabID = obj.TabID;
            obj._this.FindControl("divTitle").Controls.Add(RichText_Edit1);
        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }
    #endregion

    #region RichRichText
    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class RichRichText_ViewInCreationLangNotAuth : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var RichRichText_Display = (Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.Display);
            RichRichText_Display.Parent_Page = obj._this.Page;
            RichRichText_Display.ComponentID = obj.ComponentID;
            RichRichText_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(RichRichText_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {
            Console.WriteLine("Latex - I - Edit1");
        }

        public override void Edit2(ControlViewModel obj)
        {
            Console.WriteLine("Latex - I - Edit2");
        }
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    public class RichRichText_ViewInAltLang : AbstractView
    {

        public override void Display(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Display");
        }

        public override void Edit1(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Edit1");
        }

        public override void Edit2(ControlViewModel obj)
        {
            var RichRich_Edit2 = (Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.Edit2)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.Edit2);
            RichRich_Edit2.Parent_Page = obj._this.Page;
            RichRich_Edit2.Order = obj.Order;
            RichRich_Edit2.ComponentID = obj.ComponentID;
            obj._this.FindControl("divTitle").Controls.Add(RichRich_Edit2);
        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class RichRichText_ViewInCreationLangAuth : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var RichRich_Display = (Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.Display);
            RichRich_Display.Parent_Page = obj._this.Page;
            RichRich_Display.ComponentID = obj.ComponentID;
            RichRich_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(RichRich_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class RichRichText_Translate : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var Latex_TranslationTitle = (Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.TranslationTitle)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.TranslationTitle);
            Latex_TranslationTitle.Parent_Page = obj._this.Page;
            Latex_TranslationTitle.ComponentType = obj.ComponentType;
            Latex_TranslationTitle.ComponentID = obj.ComponentID;
            Latex_TranslationTitle.UserID = obj.UserID;
            Latex_TranslationTitle.Order = obj.Order;
            Latex_TranslationTitle.TabID = obj.TabID;
            obj._this.FindControl("divTitle").Controls.Add(Latex_TranslationTitle);

            var RichRich_Display = (Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.Display);
            RichRich_Display.Parent_Page = obj._this.Page;
            RichRich_Display.ComponentID = obj.ComponentID;
            RichRich_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(RichRich_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    public class RichRichText_Edit : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var RichRich_OrderTitle = (Plugghest.Modules.UserControl.DisplayPlugg.Common.OrderTitle)LoadControl(Plugghest.Base2.UserControlRoot.Common.OrderTitle);
            RichRich_OrderTitle.Parent_Page = obj._this.Page;
            RichRich_OrderTitle.ComponentType = obj.ComponentType;
            RichRich_OrderTitle.ComponentID = obj.ComponentID;
            RichRich_OrderTitle.UserID = obj.UserID;
            RichRich_OrderTitle.Order = obj.Order;
            RichRich_OrderTitle.TabID = obj.TabID;
            //RichRich_OrderTitle.btnHandler += new Plugghest.Modules.UserControl.DisplayPlugg.Common.OrderTitle.OnButtonClick(WebUserControl1_btnHandler);
            obj._this.FindControl("divTitle").Controls.Add(RichRich_OrderTitle);

            var RichRich_Display = (Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.Display)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.Display);
            RichRich_Display.Parent_Page = obj._this.Page;
            RichRich_Display.ComponentID = obj.ComponentID;
            RichRich_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(RichRich_Display);

            var RichRich_AddNewComponenet = (Plugghest.Modules.UserControl.DisplayPlugg.Common.AddNewComponent)LoadControl(Plugghest.Base2.UserControlRoot.Common.AddNewComponent);
            RichRich_AddNewComponenet.Parent_Page = obj._this.Page;
            RichRich_AddNewComponenet.Order = obj.Order;
            RichRich_AddNewComponenet.isLastComp = obj.isLastComp;
            obj._this.FindControl("divTitle").Controls.Add(RichRich_AddNewComponenet);
        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class RichRichText_SubEdit : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {

        }

        public override void Edit1(ControlViewModel obj)
        {
            var RichRichText_Edit1 = (Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.Edit1);
            RichRichText_Edit1.Parent_Page = obj._this.Page;
            RichRichText_Edit1.UserID = obj.UserID;
            RichRichText_Edit1.Order = obj.Order;
            RichRichText_Edit1.ComponentID = obj.ComponentID;
            RichRichText_Edit1.ComponentType = obj.ComponentType;
            RichRichText_Edit1.TabID = obj.TabID;
            obj._this.FindControl("divTitle").Controls.Add(RichRichText_Edit1);
        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }
    #endregion

    #region YouTube
    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class YouTube_ViewInCreationLangNotAuth : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var YouTube_Display = (Plugghest.Modules.UserControl.DisplayPlugg.YouTube.Display)LoadControl(Plugghest.Base2.UserControlRoot.YouTube.Display);
            YouTube_Display.Parent_Page = obj._this.Page;
            //YouTube_Display.ComponentID = obj.ComponentID;
            //YouTube_Display.Order = obj.Order;
            obj._this.FindControl("divTitle").Controls.Add(YouTube_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {
            Console.WriteLine("Latex - I - Edit1");
        }

        public override void Edit2(ControlViewModel obj)
        {
            Console.WriteLine("Latex - I - Edit2");
        }
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    public class YouTube_ViewInAltLang : AbstractView
    {

        public override void Display(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Display");
        }

        public override void Edit1(ControlViewModel obj)
        {
            Console.WriteLine("Latex - II - Edit1");
        }

        public override void Edit2(ControlViewModel obj)
        {
            var YouTube_Display = (Plugghest.Modules.UserControl.DisplayPlugg.YouTube.Display)LoadControl(Plugghest.Base2.UserControlRoot.YouTube.Display);
            YouTube_Display.Parent_Page = obj._this.Page;
            YouTube_Display.Parent_Page = obj._this.Page;
            YouTube_Display.YTComponentId = obj.ComponentID;
            obj._this.FindControl("divTitle").Controls.Add(YouTube_Display);
        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class YouTube_ViewInCreationLangAuth : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var YouTube_Display = (Plugghest.Modules.UserControl.DisplayPlugg.YouTube.Display)LoadControl(Plugghest.Base2.UserControlRoot.YouTube.Display);
            YouTube_Display.Parent_Page = obj._this.Page;
            YouTube_Display.Parent_Page = obj._this.Page;
            YouTube_Display.YTComponentId = obj.ComponentID;
            obj._this.FindControl("divTitle").Controls.Add(YouTube_Display);
        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class YouTube_Translate : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {

        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class YouTube_Edit : AbstractView
    {
        public override void Display(ControlViewModel obj)
        {
            var YouTube_OrderTitle = (Plugghest.Modules.UserControl.DisplayPlugg.Common.OrderTitle)LoadControl(Plugghest.Base2.UserControlRoot.Common.OrderTitle);
            YouTube_OrderTitle.Parent_Page = obj._this.Page;
            YouTube_OrderTitle.ComponentType = obj.ComponentType;
            YouTube_OrderTitle.ComponentID = obj.ComponentID;
            YouTube_OrderTitle.UserID = obj.UserID;
            YouTube_OrderTitle.Order = obj.Order;
            YouTube_OrderTitle.TabID = obj.TabID;
            //YouTube_OrderTitle.btnHandler += new Plugghest.Modules.UserControl.DisplayPlugg.Common.OrderTitle.OnButtonClick(WebUserControl1_btnHandler);
            obj._this.FindControl("divTitle").Controls.Add(YouTube_OrderTitle);

            var YouTube_Display = (Plugghest.Modules.UserControl.DisplayPlugg.YouTube.Display)LoadControl(Plugghest.Base2.UserControlRoot.YouTube.Display);
            YouTube_Display.Parent_Page = obj._this.Page;
            YouTube_Display.Parent_Page = obj._this.Page;
            YouTube_Display.YTComponentId = obj.ComponentID;
            obj._this.FindControl("divTitle").Controls.Add(YouTube_Display);

            var YouTube_AddNewComponenet = (Plugghest.Modules.UserControl.DisplayPlugg.Common.AddNewComponent)LoadControl(Plugghest.Base2.UserControlRoot.Common.AddNewComponent);
            YouTube_AddNewComponenet.Parent_Page = obj._this.Page;
            YouTube_AddNewComponenet.Order = obj.Order;
            YouTube_AddNewComponenet.isLastComp = obj.isLastComp;
            obj._this.FindControl("divTitle").Controls.Add(YouTube_AddNewComponenet);
        }

        public override void Edit1(ControlViewModel obj)
        {

        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }

    /// <summary>
    /// The 'ProductB3' class
    /// </summary>
    public class YouTube_SubEdit : AbstractView
    {

        public override void Display(ControlViewModel obj)
        {

        }

        public override void Edit1(ControlViewModel obj)
        {
            var YouTube_Edit1 = (Plugghest.Modules.UserControl.DisplayPlugg.YouTube.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.YouTube.Edit);
            YouTube_Edit1.Parent_Page = obj._this.Page;
            YouTube_Edit1.UserID = obj.UserID;
            YouTube_Edit1.Order = obj.Order;
            YouTube_Edit1.ComponentID = obj.ComponentID;
            YouTube_Edit1.ComponentType = obj.ComponentType;
            YouTube_Edit1.TabID = obj.TabID;
            obj._this.FindControl("divTitle").Controls.Add(YouTube_Edit1);
        }

        public override void Edit2(ControlViewModel obj)
        {

        }
    }
    #endregion

    /// <summary>
    /// The 'Client' class. Interaction environment for the products.
    /// </summary>
    public class Control_Case
    {
        private Dictionary<EComponentType, AbstractView> temp = new Dictionary<EComponentType, AbstractView>();
        private Dictionary<ECase, DisplayPlugg_AbstractFactory> t = new Dictionary<ECase, DisplayPlugg_AbstractFactory>();

        // Strategy pattern
        /// <summary>
        /// Case Constructor 
        /// </summary>
        /// <param name="factoryCase"> use ECase enum to select case </param>
        public Control_Case(ECase factoryCase)
        {
            t.Add(ECase.ViewInCreationLangNotAuth, ConcreteCase_ViewInCreationLangNotAuth.Instance);
            t.Add(ECase.ViewInAltLang, ConcreteCase_ViewInAltLang.Instance);
            t.Add(ECase.ViewInCreationLangAuth, ConcreteCase_ViewInCreationLangAuth.Instance);
            t.Add(ECase.Translate, ConcreteCase_Translate.Instance);
            t.Add(ECase.Edit, ConcreteCase_Edit.Instance);
            t.Add(ECase.SubEdit, ConcreteCase_SubEdit.Instance);

            temp.Add(EComponentType.Label, t[factoryCase].CreateLabel());
            temp.Add(EComponentType.Latex, t[factoryCase].CreateLatex());
            temp.Add(EComponentType.RichText, t[factoryCase].CreateRich());
            temp.Add(EComponentType.RichRichText, t[factoryCase].CreateRichRich());
            temp.Add(EComponentType.YouTube, t[factoryCase].CreateYouTube());
        }

        public void RunComponentType(EComponentType _Type, ControlViewModel obj)
        {
            temp[_Type].Display(obj);
            temp[_Type].Edit1(obj);
            temp[_Type].Edit2(obj);
        }
    }
}