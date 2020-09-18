using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace CTTManagement.DataModel.FormV
{
  public  class CertForm: FormNode
    {
        public string changeLog { get; set; }
        public int version { get; set; }

        public Dictionary<Guid, FormNode> certChildItems = new Dictionary<Guid, FormNode>();
        public string name { get; set; }
        public string prefixId { get; set; }
        public string prefixNumber { get; set; }
        public CertForm()
           : base()
        {}
        public override void readXmlNode(XmlDocument r_xmlDoc, XmlNode xmlNode, XmlNamespaceManager r_nm, Dictionary<Guid, FormNode> itemList)
        {
            base.readXmlNode(r_xmlDoc, xmlNode, r_nm, itemList);

            certChildItems.Clear();

            XmlNode certForm = r_xmlDoc.SelectSingleNode("zcp:CertForm", r_nm);
            name = certForm.Attributes["name"].Value;
            version = Convert.ToInt32(certForm.Attributes["version"].Value);
            prefixId = certForm.Attributes["prefixId"].Value;
            prefixNumber = certForm.Attributes["prefixNumber"].Value;

            XmlNode descriptionNode = certForm.SelectSingleNode("zcp:formDescription", r_nm);
            if (descriptionNode != null)
            {
                description = certForm.SelectSingleNode("zcp:formDescription", r_nm).InnerText;
            }
            else
            {
                description = "";
            }

            XmlNode changeLogNode = certForm.SelectSingleNode("zcp:formChangeLog", r_nm);
            if (changeLogNode != null)
            {
                changeLog = certForm.SelectSingleNode("zcp:formChangeLog", r_nm).InnerXml;
            }
            else
            {
                changeLog = "";
            }

            XmlNodeList xmlFormSections = certForm.SelectNodes("zcp:formSection", r_nm);

            foreach (XmlNode xmlFormSection in xmlFormSections)
            {
                FormSection formSection = new FormSection();
                xmlNode = xmlFormSection;
                formSection.readXmlNode(r_xmlDoc, xmlNode, r_nm, itemList);
                certChildItems.Add(formSection.id, formSection);
                itemList.Add(formSection.id, formSection);
            }

            do
            {
                id = Guid.NewGuid();

                if (itemList.ContainsKey(id) == true)
                {
                    MessageBox.Show("same Guid " + id.ToString());
                }
            } while (itemList.ContainsKey(id));
        }

        public override Dictionary<Guid, FormNode> getChildItems()
        {
            base.getChildItems();
            return certChildItems;
        }
        public override Dictionary<Guid, FormNode> getItemList()
        {
            base.getItemList();

            Dictionary<Guid, FormNode> itemList = new Dictionary<Guid, FormNode>();

            foreach (Guid childId in certChildItems.Keys)
            {
                itemList.Add(childId, certChildItems[childId]);

                certChildItems[childId].setItemList(itemList);
            }

            return itemList;
        }

        public override void setItemList(Dictionary<Guid, FormNode> itemList)
        {
            base.setItemList(itemList);
        }

        public override void setRelations(Dictionary<Guid, Relation> relations, string relationsType)
        {
            base.setRelations(relations, relationsType);
        }
        public override Dictionary<Guid, Relation> getRelations(string relationsType)
        {
            return base.getRelations(relationsType);
        }

        public override Dictionary<Guid, Relation> getRelationsFrom(string relationsType)
        {
            return base.getRelationsFrom(relationsType);
        }
        public override string getItemType()
        {
            base.getItemType();

            return "Cert";
        }

    }
}
