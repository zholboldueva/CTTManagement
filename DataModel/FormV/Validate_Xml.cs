using System;
using System.Windows;
using System.Xml;
using System.Xml.Schema;

namespace CTTManagement.DataModel.FormV
{
    public class Validate_Xml
    {
        public bool validateXml(XmlDocument xmlDoc, string openPathSchema)
        {
            string logEntry = "Xml OK";
            try
            {
                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

                xmlDoc.Validate(eventHandler);

            }
            catch (XmlException ex)
            {
                MessageBox.Show("XmlDocumentValidationExample.XmlException: {0}", ex.Message);
                logEntry = "XmlDocumentValidationExample.XmlException: " + ex.Message;
                return false;
            }
            catch (XmlSchemaValidationException ex)
            {
                MessageBox.Show("XmlDocumentValidationExample.XmlSchemaValidationException: {0}", ex.Message);
                logEntry = "XmlDocumentValidationExample.XmlSchemaValidationException: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("XmlDocumentValidationExample.Exception: {0}", ex.Message);
                logEntry = "XmlDocumentValidationExample.Exception: " + ex.Message;
                return false;
            }
           
            return true;
        }
        static void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            switch (args.Severity)
            {
                case XmlSeverityType.Error:
                    MessageBox.Show(args.Message, "XmlSeverityType.Error:");
                    break;
                case XmlSeverityType.Warning:
                   
                    MessageBox.Show(args.Message, "XmlSeverityType.Warning:");
                    break;
            }
        }

    }
}
