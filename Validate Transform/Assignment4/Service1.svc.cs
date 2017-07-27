using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Assignment4
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static string errorMessage = "";

        //Implement Validation web operation service Ref lc17
        public string validateXml(string xmlURL, string xsdURL)
        {
            errorMessage = "";
            //Creating XmlSchemaSet class obj
            XmlSchemaSet sc = new XmlSchemaSet();
            XmlReader reader = null;
            try
            {
                // Adding the schema to the collection before performing validation
                sc.Add(null, xsdURL);

                //Defining the validation settings.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;

                //Associating the schemas with XmlReaderSettings object
                settings.Schemas = sc;
                //Initailizing Handler
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

                //Create the XmlReader object.
                reader = XmlReader.Create(xmlURL, settings);

                //Initializing response string
                string response = "";
                //Parsing the file. 
                while (reader.Read()) ; // will call event handler if invalid
                response = "No Error: The XML file validation has been completed successfully.";
                if (errorMessage.Equals(""))
                    return response;
                else
                    return errorMessage; //If error then message from ValidationCallBack handler               
            }
            catch (Exception)
            {
                string s = "Enter correct Inputs.";
                return s;
            }
            finally
            {
                reader.Close();
            }
        }

        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            //Console.WriteLine("Validation Error: {0}", e.Message);
            errorMessage += e.Message + "<br>";
        }

        //Implement Transformation web operation service Ref lc17
        public string transformXml(string xmlURL, string xslURL)
        {
            string yolo = "";
            try
            {
                //Creating XPathDocument class obj to parse the xmlURL and store tree in memeory
                XPathDocument parseXml = new XPathDocument(xmlURL);

                //Creating XslCompiledTransform class obj
                XslCompiledTransform xt = new XslCompiledTransform();
                //Loads the URL string of style sheet. 
                xt.Load(xslURL);

                //Using StringWriter to implement a TextWriter to write information to a string that is stored in an underlying StringBuilder.
                StringWriter writer = new StringWriter();

                //Executes the transform using the input document specified by the XPathDocument object and outputs the results to an TextWriter.
                xt.Transform(parseXml, null, writer);
                yolo = writer.ToString();
            }
            catch (Exception ex)
            {
                yolo = ex.Message;
            }
            //return html string when valid 
            return yolo;
        }
    }
}
