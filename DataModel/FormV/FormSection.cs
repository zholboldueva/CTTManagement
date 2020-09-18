using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace CTTManagement.DataModel.FormV
{
    public class FormSection: FormNode
    {
        public string name { get; set; }
        public string prefix { get; set; }
        public bool hasStatusColumn { get; set; }
        public bool hasRoleColumn { get; set; }
        public bool hasCertColumn { get; set; }


        public Dictionary<Guid, Relation> relationsSelectFrom = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsSupportFrom = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsControlFrom = new Dictionary<Guid, Relation>();
        public Guid parentItemId { get; set; }
        public Dictionary<Guid, FormNode> sectionChildItems = new Dictionary<Guid, FormNode>();
        public string sectionIndex;
        public FormSection()
            : base()
        {
            hasStatusColumn = true;
            hasCertColumn = true;
            hasRoleColumn = false;
        }
        public override void readXmlNode(XmlDocument r_xmlDoc, XmlNode xmlFormSection, XmlNamespaceManager r_nm, Dictionary<Guid, FormNode> itemList)
        {
            base.readXmlNode(r_xmlDoc, xmlNode, r_nm, itemList);

            name = xmlFormSection.Attributes["name"].Value;
            prefix = xmlFormSection.Attributes["prefix"].Value;
            id = new Guid(xmlFormSection.SelectSingleNode("zcp:sectionId", r_nm).InnerText);

            if (xmlFormSection.SelectSingleNode("zcp:sectionDescription", r_nm) != null)
            {
                description = xmlFormSection.SelectSingleNode("zcp:sectionDescription", r_nm).InnerXml;
                description2 = xmlFormSection.SelectSingleNode("zcp:sectionDescription", r_nm).InnerText;
            }

            if (xmlFormSection.Attributes["hasStatusColumn"] != null)
            {
                if (xmlFormSection.Attributes["hasStatusColumn"].Value == "true")
                {
                    hasStatusColumn = true;
                }
                else
                {
                    hasStatusColumn = false;
                }
            }
            else
            {
                hasStatusColumn = true;
            }
            if (xmlFormSection.Attributes["hasCertColumn"] != null)
            {
                if (xmlFormSection.Attributes["hasCertColumn"].Value == "true")
                {
                    hasCertColumn = true;
                }
                else
                {
                    hasCertColumn = false;
                }
            }
            else
            {
                hasCertColumn = true;
            }

            if (xmlFormSection.Attributes["hasRoleColumn"] != null)
            {
                if (xmlFormSection.Attributes["hasRoleColumn"].Value == "true")
                {
                    hasRoleColumn = true;
                }
                else
                {
                    hasRoleColumn = false;
                }
            }
            else
            {
                hasRoleColumn = false;
            }

            if (xmlFormSection.Attributes["hidden"] != null)
            {
                if (xmlFormSection.Attributes["hidden"].Value == "true")
                {
                    hidden = true;
                }
                else
                {
                    hidden = false;
                }
            }
            else
            {
                hidden = false;
            }

            XmlNodeList xmlFormItems = xmlFormSection.SelectNodes("zcp:formItem", r_nm);

            foreach (XmlNode xmlFormItem in xmlFormItems)
            {
                FormItem formItem = new FormItem();
                formItem.readXmlNode(r_xmlDoc, xmlFormItem, r_nm, itemList);
                formItem.parentItemId = id;
                sectionChildItems.Add(formItem.id, formItem);
                itemList.Add(formItem.id, formItem);
            }

        }
        public override Dictionary<Guid, FormNode> getChildItems()
        {
            base.getChildItems();
            return sectionChildItems;
        }
        public override Dictionary<Guid, FormNode> getItemList()
        {
            return base.getItemList();
        }
        public override void setItemList(Dictionary<Guid, FormNode> itemList)
        {
            base.setItemList(itemList);

            foreach (Guid childId in sectionChildItems.Keys)
            {
                itemList.Add(childId, sectionChildItems[childId]);

                foreach (Guid comboInputItemKey in sectionChildItems[childId].getInputs().inputComboItems.Keys)
                {
                    itemList.Add(comboInputItemKey, sectionChildItems[childId].getInputs().inputComboItems[comboInputItemKey]);
                }

                sectionChildItems[childId].setItemList(itemList);
            }
        }
        public override void setRelations(Dictionary<Guid, Relation> relations, string relationsType)
        {
            base.setRelations(relations, relationsType);
        }
        public override Dictionary<Guid, Relation> getRelations(string relationsType)
        {
            return getRelations(relationsType, true);
        }

        public override Dictionary<Guid, Relation> getRelations(string relationsType, bool relationsTo)
        {
            base.getRelations(relationsType, relationsTo);

            Dictionary<Guid, Relation> relations = new Dictionary<Guid, Relation>();

            switch (relationsType)
            {
                case "select":
                    if (!relationsTo)
                    {
                        relations = relationsSelectFrom;
                    }
                    break;

                case "support":
                    if (!relationsTo)
                    {
                        relations = relationsSupportFrom;
                    }
                    break;

                case "control":
                    if (!relationsTo)
                    {
                        relations = relationsControlFrom;
                    }
                    break;

                default:
                    MessageBox.Show("wrong input type " + relationsType);
                    break;
            }

            return relations;
        }
        public override Dictionary<Guid, Relation> getRelationsFrom(string relationsType)
        {
            base.getRelationsFrom(relationsType);

            Dictionary<Guid, Relation> relationsFrom = new Dictionary<Guid, Relation>();

            switch (relationsType)
            {
                case "select":
                    relationsFrom = relationsSelectFrom;
                    break;

                case "support":
                    relationsFrom = relationsSupportFrom;
                    break;

                case "control":
                    relationsFrom = relationsControlFrom;
                    break;

                default:
                    MessageBox.Show("wrong input type " + relationsType);
                    break;
            }

            return relationsFrom;
        }
        public override string getItemType()
        {
            base.getItemType();

            return "Section";
        }
       
    }
}
