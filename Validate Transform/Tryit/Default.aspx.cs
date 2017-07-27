using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Validate_Click(object sender, EventArgs e)
    {
        try
        {
            string xmlUrl = xmlURLBox.Text;
            string xsdUrl = xsdURLBox.Text;
            //checking if .xml file is input to textbox
            string ext = Path.GetExtension(xmlUrl);
            if (ext.Equals(".xml"))
            {
                ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
                string output = s.validateXml(xmlUrl, xsdUrl);
                Label2.Text = output;
            }
            else
            {
                Label2.Text = "Give valid inputs!!!";
            }


        }
        catch (Exception)
        {
            Label2.Text = "Give valid inputs!!!";
        }
    }

    protected void Transform_Click(object sender, EventArgs e)
    {
        try
        {
            string xmlUrl = xmlURLBox1.Text;
            string xslUrl = xslURLBox.Text;
            //checking if .xml file is input to textbox
            string ext = Path.GetExtension(xmlUrl);
            if (ext.Equals(".xml"))
            {
                ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();

                string output = s.transformXml(xmlUrl, xslUrl);
                Label4.Text = output;
            }
            else
            {
                Label4.Text = "Give valid inputs!!!";
            }
        }
        catch (Exception)
        {
            Label4.Text = "Give valid inputs!!!";
        }
    }
}