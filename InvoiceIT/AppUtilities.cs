using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public class AppUtilities
    {
        // Class checks to see if passed list is empty or not
        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                return true; // The passed list is empty
            }

            return !list.Any(); // flase the passed list is not empty
        }
        public static void ClearForm(ControlCollection frmCtrls)
        { // class begin
            foreach (Control frmCtrl in frmCtrls)
            {
                string ffield = (frmCtrl.GetType()).Name;

                switch (ffield)
                {
                    case "TextBox":
                        TextBox tbSource = (TextBox)frmCtrl;
                        tbSource.Text = "";
                        break;
                    case "RadioButtonList":
                        RadioButtonList rblSource = (RadioButtonList)frmCtrl;
                        rblSource.SelectedIndex = -1;
                        break;
                    case "DropDownList":
                        DropDownList ddlSource = (DropDownList)frmCtrl;
                        ddlSource.SelectedIndex = -1;
                        break;
                    case "ListBox":
                        ListBox lbsource = (ListBox)frmCtrl;
                        lbsource.SelectedIndex = -1;
                        break;
                }
                ClearForm(frmCtrl.Controls);
            }
        } // class end
    }
}