using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace CTTManagement.DataModel.FormV
{
    public class FormNode
    {
        public Guid id { get; set; }
        public string nodeName { get; set; }
        public string description { get; set; }
        public string description2 { get; set; }
        public bool hidden { get; set; }
        public XmlNode xmlNode { get; set; }
        Dictionary<Guid, Relation> relations = null;
        public bool nodeExpand = false;
        public int sectionNumber = 0;
        public string[] relationTypes = { "select", "support", "control" };
        public string index = "";
        public FormNode()
        {
            hidden = false;
        }
       
        public virtual void readXmlNode(XmlDocument r_xmlDoc, XmlNode xmlNode, XmlNamespaceManager r_nm, Dictionary<Guid, FormNode> itemList)
        {

        }
        public virtual Dictionary<Guid, FormNode> getChildItems()
        {
            Dictionary<Guid, FormNode> childItems = new Dictionary<Guid, FormNode>();

            return childItems;
        }
        public virtual string getNodeName()
        {
            return nodeName;
        }
     
        public virtual Dictionary<Guid, FormNode> getItemList()
        {
            Dictionary<Guid, FormNode> itemList = new Dictionary<Guid, FormNode>();

            return itemList;
        }
        public virtual void setItemList(Dictionary<Guid, FormNode> itemList)
        {

        }
       
        public virtual Dictionary<Guid, Relation> getRelations(string relationsType)
        {
            return relations;
        }
        public virtual Dictionary<Guid, Relation> getRelations(string relationsType, bool relationsTo)
        {
            return relations;
        }
        public virtual void setRelations(Dictionary<Guid, Relation> relations, string relationsType)
        {

        }
        public virtual FormInput getInputs()
        {
            return null;
        }
      
        public virtual Dictionary<Guid, Relation> getRelationsFrom(string relationsType)
        {
            return relations;
        }
       
        public virtual Guid getNextSelection(Guid selectedItem)
        {
            return Guid.Empty;
        }
        public virtual string getItemType()
        {
            return "";
        }
        public virtual void addZATSTest(ZatsTest newZATSTest, ZatsTest selectedZATSTest, bool before)
        {

        }
        public virtual List<ZatsTest> GetZATSTests()
        {
            return null;
        }
       
    }

    public class ItemStatusEnum
    {
        string itemStatusString;
        string itemStatusEnum;

        public string getStatusTyp()
        {
            switch (itemStatusEnum)
            {
                case "M":
                    itemStatusString = "M (default)";
                    break;
                case "O":
                    itemStatusString = "O";
                    break;
                case "R":
                    itemStatusString = "R";
                    break;
                case "OM":
                    itemStatusString = "O/M";
                    break;
                case "MR":
                    itemStatusString = "M/R";
                    break;
                case "MS":
                    itemStatusString = "MS";
                    break;
                case "MM":
                    itemStatusString = "MM";
                    break;
                case "empty":
                    itemStatusString = "";
                    break;
            }
            return itemStatusString;
        }

        public string getComboBoxItem(string enumItem)
        {
            switch (enumItem)
            {
                case "M":
                    itemStatusString = "M (default)";
                    break;
                case "O":
                    itemStatusString = "O";
                    break;
                case "R":
                    itemStatusString = "R";
                    break;
                case "OM":
                    itemStatusString = "O/M";
                    break;
                case "MR":
                    itemStatusString = "M/R";
                    break;
                case "MS":
                    itemStatusString = "MS";
                    break;
                case "MM":
                    itemStatusString = "MM";
                    break;
                case "empty":
                    itemStatusString = "";
                    break;
            }
            return itemStatusString;
        }

        public void SetStatusTyp(string itemStatusString)
        {
            switch (itemStatusString)
            {
                case "M (default)":
                    itemStatusEnum = StatusType.M.ToString();
                    break;
                case "O":
                    itemStatusEnum = StatusType.O.ToString();
                    break;
                case "R":
                    itemStatusEnum = StatusType.R.ToString();
                    break;
                case "O/M":
                    itemStatusEnum = StatusType.OM.ToString();
                    break;
                case "M/R":
                    itemStatusEnum = StatusType.MR.ToString();
                    break;
                case "MS":
                    itemStatusEnum = StatusType.MS.ToString();
                    break;
                case "MM":
                    itemStatusEnum = StatusType.MM.ToString();
                    break;
                case "":
                    itemStatusEnum = StatusType.empty.ToString();
                    break;
                default:
                    MessageBox.Show("wrong status type " + itemStatusString);
                    break;
            }
        }
    }

}
