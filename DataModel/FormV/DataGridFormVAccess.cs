using CTTManagement.Model;
using CTTManagement.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml;

namespace CTTManagement.DataModel.FormV
{
    public class DataGridFormVAccess
    {

        public string openPathXml =@"..\arrayTest\FormV2-rev05p.xml";
        string openPathSchema =  @"..\cert_form_schema.xsd";
        //string openPathSchema = "C:\\Users\\MK-Logic\\source\\repos\\DemoProject\\DemoProject\\cert_form_schema.xsd";
        public XmlDocument xmlDoc = new XmlDocument();
        XmlDocument m_certDoc = new XmlDocument();
        XmlNamespaceManager m_nm;
        Read_Xml readFile = new Read_Xml();
        CertForm viewTreeRoot = new CertForm();
        Dictionary<Guid, FormNode> viewItemList = new Dictionary<Guid, FormNode>();
        
       
        public DataGridFormVAccess()
        {
            LoadXml();
        }

        public void LoadXml()
        {
            
            string fileName = "";

            xmlDoc.Load(openPathXml);
            xmlDoc.Schemas.Add(null, openPathSchema);
            var nm = new XmlNamespaceManager(xmlDoc.NameTable);
            nm.AddNamespace("zcp", "http://www.sigmadesigns.com/z-wave_cert_portal/xml-schemata");

            m_certDoc = xmlDoc;
            m_nm = nm;
            readFile.readXmlFile(m_certDoc, m_nm, openPathSchema);

            viewTreeRoot = readFile.treeRoot;
            viewItemList = viewTreeRoot.getItemList();
            viewItemList.Add(viewTreeRoot.id, viewTreeRoot);
            fileName = Path.GetFileName(openPathXml);

        }

       

            public IList<FormVModel> CreateDataGridView()
        {
            List<FormVModel> output = new List<FormVModel>();

            FormVModel data;
            int index = 0;
            string sectionName = "";

            //viewItemList.ForEach(x => x.Value.id != viewTreeRoot.id && x.Value is FormSection);
            //List<FormNode> kList=viewItemList.Where(k => k.Value.id != viewTreeRoot.id && k.Value is FormSection).ToList();
            foreach (KeyValuePair<Guid, FormNode> node in viewItemList)
            {
                var iteratorNode = node.Value;
                if (iteratorNode.id != viewTreeRoot.id)
                {
                    if (iteratorNode.GetType() == typeof(FormSection))
                    {
                        ++index;
                        FormSection section = (FormSection)iteratorNode;
                        sectionName = "Section " + index + " (" + section.prefix + "): " + section.name;
                        data = new FormVModel();
                        data.TitleDescrNote = sectionName;
                        output.Add(data);
                        string itemPrefix = section.prefix;
                        SetDataGridViewOfItems(itemPrefix, section.sectionChildItems, section, output);
                        data = new FormVModel();
                        data.TitleDescrNote = "End of Section " + index + " (" + section.prefix + ")";
                        output.Add(data);
                        data = new FormVModel();
                        output.Add(data);
                    }
                }
            }
            return output;
        }

        public void SetDataGridViewOfItems(string itemPrefix, Dictionary<Guid, FormNode> childItems, FormSection section, List<FormVModel> output)
        {
            int itemIndex = 0;

            foreach (KeyValuePair<Guid, FormNode> itemNode in childItems)
            {
                var iteratorItemNode = itemNode.Value;
                if (iteratorItemNode.GetType() == typeof(FormItem))
                {
                    ++itemIndex;
                    FormItem item = (FormItem)iteratorItemNode;
                    string sectionName = MapTitleDescrNote(item.title, item.note, item.description);
                    var data = new FormVModel();
                    data.FormItemNo = itemPrefix + "." + itemIndex;
                    data.TitleDescrNote = sectionName;
                    data.WikiPageName = item.wikiLink;
                    data.SelfCert = item.selfCertValue;
                    data.Verification = item.verificationValue;
                    data.AdHoc = item.adhocValue;
                    data.ZatsKey = item.zatsKey;
                    data.ZatsValue = item.zatsValue;
                    data.ZatsTests = GetZatsTests(item.ZATSTests);
                    data.TriggeredBy = item.triggeredByType;
                    data.TagName = item.tagName;
                    data.TagValue = item.tagValue;
                    data.InputCustomType = item.inputCustomType;
                    data.InputComboType = item.inputComboType;
                    output.Add(data);
                    if (item.getChildItems().Count > 0)
                    {
                        SetDataGridViewOfItems(itemPrefix + "." + itemIndex, item.getChildItems(), section, output);

                    }
                }
            }
        }

        public string GetZatsTests(List<ZatsTest> ZATSTests)
        {
            string outputArray = "";
            foreach (ZatsTest zatsTest in ZATSTests)
            {
                outputArray += zatsTest.value + "\n";
            }
            return outputArray;
        }

        public string MapCharacters(string ch)
        {
            string k = "";
            if (!string.IsNullOrEmpty(ch))
            {
                k = ch.Replace("<b>", "").Replace("<ul>", "").Replace("</ul>", "").Replace("</b>", "").Replace("<br>", "").Replace("</li>", "").Replace("<li>", "* ").Replace("<![CDATA[", "").Replace("]]>", "");
            }

            return k;
        }


            public string MapTitleDescrNote(string title, string note, string descr)
        {
            string output = "";
            if (!string.IsNullOrEmpty(title))
            {
                output += "Title: " + HTMLToText(title) + "\n";
            }
            if (!string.IsNullOrEmpty(descr))
            {
                output += "Descr: " + HTMLToText(descr) + "\n";
            }
            if (!string.IsNullOrEmpty(note))
            {
                output += "Notes: " + HTMLToText(note) + "\n";
            }
            return output;
        }

        public string HTMLToText(string HTMLCode)
        {
            // Remove new lines since they are not visible in HTML
            HTMLCode = HTMLCode.Replace("\n", " ");

            // Remove tab spaces
            HTMLCode = HTMLCode.Replace("\t", " ");

            // Remove multiple white spaces from HTML
            HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

            // Remove HEAD tag
            HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                , RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Remove any JavaScript
            HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
              , RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Replace special characters like &, <, >, " etc.
            StringBuilder sbHTML = new StringBuilder(HTMLCode);
            // Note: There are many more special characters, these are just
            // most common. You can add new characters in this arrays if needed
            string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;",
   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
            string[] NewWords = { " ", "&", "\"", "<", ">", "Â®", "Â©", "â€¢", "â„¢" };
            for (int i = 0; i < OldWords.Length; i++)
            {
                sbHTML.Replace(OldWords[i], NewWords[i]);
            }

            // Check if there are line breaks (<br>) or paragraph (<p>)
            sbHTML.Replace("<br>", " ");
            sbHTML.Replace("<br ", "\n<br ");
            sbHTML.Replace("<p ", "\n<p ");
            sbHTML.Replace("<li>", "\n*");
            sbHTML.Replace("<![CDATA[", "");
            sbHTML.Replace("]]>", "");

            // Finally, remove all HTML tags and return plain text
            return System.Text.RegularExpressions.Regex.Replace(
              sbHTML.ToString(), "<[^>]*>", "");
        }
    }
}
