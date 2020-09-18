using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CTTManagement.DataModel.FormV
{
    public class Read_Xml
    {

        XmlDocument r_xmlDoc = new XmlDocument();
        XmlNamespaceManager r_nm;
        XmlNode xmlNode = null;
        Validate_Xml validateFile = new Validate_Xml();
        //string openPathSchema = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\cert_form_schema.xsd";

        public CertForm treeRoot = new CertForm();
        public Dictionary<Guid, FormNode> itemList = new Dictionary<Guid, FormNode>();

        public void readXmlFile(XmlDocument xmlDoc, XmlNamespaceManager nm, string openPathSchema)
        {
            r_xmlDoc = xmlDoc;
            r_nm = nm;

            if (validateFile.validateXml(r_xmlDoc, openPathSchema))
            {
                itemList.Clear();

                treeRoot.readXmlNode(r_xmlDoc, xmlNode, r_nm, itemList);
            }
        }
    }
}
