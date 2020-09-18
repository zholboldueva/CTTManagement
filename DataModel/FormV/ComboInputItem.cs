using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace CTTManagement.DataModel.FormV
{
    public class ComboInputItem : FormNode
    {

        #region properties
        public string value { get; set; }
        public string name { get; set; }
        public string ZATSValue { get; set; }

        public Dictionary<Guid, Relation> relationsSelectTo = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsSupportTo = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsControlTo = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsSelectFrom = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsSupportFrom = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsControlFrom = new Dictionary<Guid, Relation>();
        public Guid parentItemId;
        public string itemIndex { get; set; }
        #endregion

        public ComboInputItem()
            : base()
        {
        }

       
        public override void readXmlNode(XmlDocument r_xmlDoc, XmlNode xmlComboInputItem, XmlNamespaceManager r_nm, Dictionary<Guid, FormNode> itemList)
        {
            base.readXmlNode(r_xmlDoc, xmlNode, r_nm, itemList);

            //value = xmlComboItem.Attributes["value"].Value;
            //id = new Guid(xmlComboItem.SelectSingleNode("zcp:itemId", r_nm).InnerText);

            id = new Guid(xmlComboInputItem.SelectSingleNode("zcp:itemId", r_nm).InnerText);

            if (xmlComboInputItem.Attributes["value"] == null)
            {
                value = "";
            }
            else
            {
                value = xmlComboInputItem.Attributes["value"].Value;
            }

            if (xmlComboInputItem.Attributes["zatsValue"] == null)
            {
                ZATSValue = "";
            }
            else
            {
                ZATSValue = xmlComboInputItem.Attributes["zatsValue"].Value;
            }

            XmlNode comboItemRelationSelect = xmlComboInputItem.SelectSingleNode("zcp:comboItemRelation[@type='select']", r_nm);
            if (comboItemRelationSelect != null)
            {
                XmlNodeList toItemIDs = comboItemRelationSelect.SelectNodes("zcp:toItemId", r_nm);
                foreach (XmlNode itemId in toItemIDs)
                {
                    try
                    {
                        string triggeredBy;

                        if (itemId.Attributes["triggeredBy"] != null)
                        {
                            triggeredBy = itemId.Attributes["triggeredBy"].Value;
                        }
                        else
                        {
                            triggeredBy = "select";
                        }

                        Relation relation = new Relation(id, new Guid(itemId.InnerText), "select", triggeredBy);
                        relationsSelectTo.Add(relation.toItemId, relation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Test RelationLoad Error: " + ex.Message);
                    }
                }
            }

            XmlNode comboItemRelationSupport = xmlComboInputItem.SelectSingleNode("zcp:comboItemRelation[@type='support']", r_nm);
            if (comboItemRelationSupport != null)
            {
                XmlNodeList toItemIDs = comboItemRelationSupport.SelectNodes("zcp:toItemId", r_nm);
                foreach (XmlNode itemId in toItemIDs)
                {
                    string triggeredBy;

                    if (itemId.Attributes["triggeredBy"] != null)
                    {
                        triggeredBy = itemId.Attributes["triggeredBy"].Value;
                    }
                    else
                    {
                        triggeredBy = "select";
                    }

                    Relation relation = new Relation(id, new Guid(itemId.InnerText), "support", triggeredBy);
                    relationsSupportTo.Add(relation.toItemId, relation);
                }
            }

            XmlNode comboItemRelationControl = xmlComboInputItem.SelectSingleNode("zcp:comboItemRelation[@type='control']", r_nm);
            if (comboItemRelationControl != null)
            {
                XmlNodeList toItemIDs = comboItemRelationControl.SelectNodes("zcp:toItemId", r_nm);
                foreach (XmlNode itemId in toItemIDs)
                {
                    string triggeredBy;

                    if (itemId.Attributes["triggeredBy"] != null)
                    {
                        triggeredBy = itemId.Attributes["triggeredBy"].Value;
                    }
                    else
                    {
                        triggeredBy = "select";
                    }

                    Relation relation = new Relation(id, new Guid(itemId.InnerText), "control", triggeredBy);
                    relationsControlTo.Add(relation.toItemId, relation);
                }
            }
        }
      

        public override Dictionary<Guid, FormNode> getItemList()
        {
            return base.getItemList();
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
                    if (relationsTo)
                    {
                        relations = relationsSelectTo;
                    }
                    else
                    {
                        relations = relationsSelectFrom;
                    }
                    break;

                case "support":
                    if (relationsTo)
                    {
                        relations = relationsSupportTo;
                    }
                    else
                    {
                        relations = relationsSupportFrom;
                    }
                    break;

                case "control":
                    if (relationsTo)
                    {
                        relations = relationsControlTo;
                    }
                    else
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

            return "ComboInputItem";
        }
    }
}
