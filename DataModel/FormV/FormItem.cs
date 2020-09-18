using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace CTTManagement.DataModel.FormV
{
    public class FormItem : FormNode
    {
        public string header { get; set; }
        public string title { get; set; }
        public string note { get; set; }
        public string wikiLink { get; set; }
        public ItemStatusEnum status = new ItemStatusEnum();
        public FormInput formInput { get; set; }
        public List<ZatsTest> zatsTests { get; set; }
        public ChildItem childItems { get; set; }
        public ItemRelation itemRelation{ get; set; }
        public string selfCertValue { get; set; }
        public string zatsKey{ get; set; }
        public string zatsValue{ get; set; }
        public string tagName{ get; set; }
        public string tagValue{ get; set; }
        public bool hasStatusColumn { get; set; }
        public string adhocValue { get; set; }
        public string verificationValue { get; set; }
        public string inputComboType { get; set; }
        public string inputCustomType { get; set; }
        public string triggeredByType { get; set; }


        public ChildTypeEnum childrenType = new ChildTypeEnum();
        public ItemCardinalityEnum cardinality = new ItemCardinalityEnum();
        public FormInput inputs = new FormInput();
        public Dictionary<Guid, Relation> relationsSelectTo = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsSupportTo = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsControlTo = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsSelectFrom = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsSupportFrom = new Dictionary<Guid, Relation>();
        public Dictionary<Guid, Relation> relationsControlFrom = new Dictionary<Guid, Relation>();
        public List<ZatsTest> ZATSTests = new List<ZatsTest>();
        public Guid parentItemId;
        public Dictionary<Guid, FormNode> formChildItems = new Dictionary<Guid, FormNode>();
        public string itemIndex { get; set; }
        public FormItem()
           : base()
        {}
       
      
        public override void readXmlNode(XmlDocument r_xmlDoc, XmlNode xmlFormItem, XmlNamespaceManager r_nm, Dictionary<Guid, FormNode> itemList)
        {
            base.readXmlNode(r_xmlDoc, xmlNode, r_nm, itemList);

            id = new Guid(xmlFormItem.SelectSingleNode("zcp:itemId", r_nm).InnerText);

            XmlNode itemHeader = xmlFormItem.SelectSingleNode("zcp:itemHeader", r_nm);
            if (itemHeader != null)
            {
                header = xmlFormItem.SelectSingleNode("zcp:itemHeader", r_nm).InnerText;
            }

            XmlNode itemTitle = xmlFormItem.SelectSingleNode("zcp:itemTitle", r_nm);
            if (itemTitle != null)
            {
                title = xmlFormItem.SelectSingleNode("zcp:itemTitle", r_nm).InnerText;
            }

            XmlNode itemDescription = xmlFormItem.SelectSingleNode("zcp:itemDescription", r_nm);
            if (itemDescription != null)
            {
                description = xmlFormItem.SelectSingleNode("zcp:itemDescription", r_nm).InnerXml;
                description2 = xmlFormItem.SelectSingleNode("zcp:itemDescription", r_nm).InnerText;
            }

            XmlNode itemNote = xmlFormItem.SelectSingleNode("zcp:itemNote", r_nm);
            if (itemNote != null)
            {
                note = xmlFormItem.SelectSingleNode("zcp:itemNote", r_nm).InnerXml;
                note = xmlFormItem.SelectSingleNode("zcp:itemNote", r_nm).InnerText;
            }

            XmlNode itemWikiLink = xmlFormItem.SelectSingleNode("zcp:itemWikiLink", r_nm);
            if (itemWikiLink != null)
            {
                wikiLink = xmlFormItem.SelectSingleNode("zcp:itemWikiLink", r_nm).InnerText;
            }

            XmlNode itemTagName = xmlFormItem.SelectSingleNode("zcp:tagName", r_nm);
            if (itemTagName != null)
            {
                tagName = xmlFormItem.SelectSingleNode("zcp:tagName", r_nm).InnerText;
            }

            XmlNode itemTagValue = xmlFormItem.SelectSingleNode("zcp:tagValue", r_nm);
            if (itemTagValue != null)
            {
                tagValue = xmlFormItem.SelectSingleNode("zcp:tagValue", r_nm).InnerText;
            }

            XmlNode itemZatsKey = xmlFormItem.SelectSingleNode("zcp:zatsKey", r_nm);
            if (itemZatsKey != null)
            {
                zatsKey = xmlFormItem.SelectSingleNode("zcp:zatsKey", r_nm).InnerText;
            }

            XmlNode itemZATSValue = xmlFormItem.SelectSingleNode("zcp:zatsValue", r_nm);
            if (itemZATSValue != null)
            {
                zatsValue = xmlFormItem.SelectSingleNode("zcp:zatsValue", r_nm).InnerText;
            }


            XmlNode itemFormInput = xmlFormItem.SelectSingleNode("zcp:formInput", r_nm);
            if (itemFormInput != null)
            {
                XmlNode formInputRole = itemFormInput.SelectSingleNode("zcp:inputRole", r_nm);
                if (formInputRole != null)
                {
                    if (formInputRole.Attributes["type"] == null || (formInputRole.Attributes["type"].Value == "select"))
                    {
                        inputs.inputRole.inputRole.SetInputType("select (default)");
                    }
                    else
                    {
                        inputs.inputRole.inputRole.SetInputType(formInputRole.Attributes["type"].Value);
                    }
                }
                else
                {
                    inputs.inputRole.inputRole.SetInputType("");
                }

                XmlNode formInputCustom = itemFormInput.SelectSingleNode("zcp:inputCustom", r_nm);
                if (formInputCustom != null)
                {
                    if (formInputCustom.Attributes["type"] != null)
                    {
                        if (formInputCustom.Attributes["type"].Value == "text")
                        {
                            inputCustomType = "text";
                        }
                        else
                        {
                            inputCustomType=formInputCustom.Attributes["type"].Value;
                        }
                    }
                    else
                    {
                        inputCustomType="text";
                    }

                }
                else
                {
                    inputCustomType = "";
                }

                XmlNode formInputSelfCert = itemFormInput.SelectSingleNode("zcp:inputSelfCert", r_nm);
                if (formInputSelfCert != null)
                {
                           selfCertValue = formInputSelfCert.Attributes["type"].Value;
                }
                else
                {
                    inputs.inputSelfCert.inputTest.SetInputType("");
                    selfCertValue = "";
                }

                XmlNode formInputVerification = itemFormInput.SelectSingleNode("zcp:inputVerification", r_nm);
                if (formInputVerification != null)
                {
                    if (formInputVerification.Attributes["type"] == null || formInputVerification.Attributes["type"].Value == "select")
                    {
                        verificationValue = "select";
                    }
                    else
                    {
                        verificationValue = formInputVerification.Attributes["type"].Value;
                    }
                }
                else
                {
                    verificationValue = "";
                }

                XmlNode formInputAdhoc = itemFormInput.SelectSingleNode("zcp:inputAdhoc", r_nm);
                if (formInputAdhoc != null)
                {
                    if (formInputAdhoc.Attributes["type"] == null || formInputAdhoc.Attributes["type"].Value == "select")
                    {
                        adhocValue = "select";
                    }
                    else
                    {
                            adhocValue = formInputAdhoc.Attributes["type"].Value;
                    }
                }
                else
                {
                    adhocValue = "";
                }

                XmlNode formInputCombo = itemFormInput.SelectSingleNode("zcp:inputCombo", r_nm);
                if (formInputCombo != null)
                {
                    if (formInputCombo.Attributes["type"] == null || formInputCombo.Attributes["type"].Value == "single")
                    {
                        inputComboType = "single";
                    }
                    else
                    {
                        inputComboType=formInputCombo.Attributes["type"].Value;
                    }
                }
                else
                {
                    inputComboType = "";
                }
            }

            XmlNode itemZATSTests = xmlFormItem.SelectSingleNode("zcp:zatsTests", r_nm);
            if (itemZATSTests != null)
            {
                XmlNodeList zatsTests = itemZATSTests.SelectNodes("zcp:zatsTest", r_nm);
                foreach (XmlNode zatsTest in zatsTests)
                {
                    if (zatsTest.Attributes["triggeredBy"] != null)
                    {
                        triggeredByType = zatsTest.Attributes["triggeredBy"].Value;
                    }
                    else
                    {
                        triggeredByType = "";
                    }
                     ZatsTest newZATSTest = new ZatsTest(zatsTest.InnerText, triggeredByType);
                     ZATSTests.Add(newZATSTest);
                    if (triggeredByType == "select") triggeredByType = "";
                }
            }

            XmlNode xmlChildItems = xmlFormItem.SelectSingleNode("zcp:childItems", r_nm);

            if (xmlChildItems != null)
            {
                
                if (xmlFormItem.SelectSingleNode("zcp:childItems", r_nm).Attributes["type"].Value == "subgroup")
                {
                    childrenType.SetChildTyp(xmlFormItem.SelectSingleNode("zcp:childItems", r_nm).Attributes["type"].Value + " (default)");
                }
                else
                {
                    childrenType.SetChildTyp(xmlFormItem.SelectSingleNode("zcp:childItems", r_nm).Attributes["type"].Value);
                }
               
                XmlNodeList childItems = xmlFormItem.SelectNodes("zcp:childItems/zcp:formItem", r_nm); //zcp:childItems/
                foreach (XmlNode xmlChildItem in childItems)
                {
                    FormItem childItem = new FormItem();
                    childItem.readXmlNode(r_xmlDoc, xmlChildItem, r_nm, itemList);
                    //childItem = readItem(xmlChildItem);
                    childItem.parentItemId = id;
                    formChildItems.Add(childItem.id, childItem);
                    itemList.Add(childItem.id, childItem);

                }
            }
            else
            {
                childrenType.SetChildTyp("");
            }
        }
        public override Dictionary<Guid, FormNode> getChildItems()
        {
            base.getChildItems();
            return formChildItems;
        }
     
        public override Dictionary<Guid, FormNode> getItemList()
        {
            return base.getItemList();
        }
        public override void setItemList(Dictionary<Guid, FormNode> itemList)
        {
            base.setItemList(itemList);
            foreach (Guid childId in formChildItems.Keys)
            {
                try
                {
                    itemList.Add(childId, formChildItems[childId]);

                    foreach (Guid comboInputItemKey in formChildItems[childId].getInputs().inputComboItems.Keys)
                    {
                        itemList.Add(comboInputItemKey, formChildItems[childId].getInputs().inputComboItems[comboInputItemKey]);
                    }
                }
                catch
                { }
                formChildItems[childId].setItemList(itemList);
            }
        }
       
        public override void setRelations(Dictionary<Guid, Relation> relations, string relationsType)
        {
            base.setRelations(relations, relationsType);

            switch (relationsType)
            {
                case "select":
                    checkNewRelations(relations, relationsSelectTo);
                    relationsSelectTo = relations;
                    break;

                case "support":
                    checkNewRelations(relations, relationsSupportTo);
                    relationsSupportTo = relations;
                    break;

                case "control":
                    checkNewRelations(relations, relationsControlTo);
                    relationsControlTo = relations;
                    break;
            }
        }
        private void checkNewRelations(Dictionary<Guid, Relation> newRelations, Dictionary<Guid, Relation> previousRelations)
        {
            foreach (Guid guid in newRelations.Keys)
            {
                if (previousRelations.ContainsKey(guid))
                {
                    newRelations[guid].SetRelationTriggeredBy(previousRelations[guid].getRelationTriggertBy());
                }
            }
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
        public override FormInput getInputs()
        {
            base.getInputs();

            return inputs;
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

            return "Item";
        }
        public override List<ZatsTest> GetZATSTests()
        {
            return ZATSTests;
        }
        public override void addZATSTest(ZatsTest newZATSTest, ZatsTest selectedZATSTest, bool before)
        {
            var test = ZATSTests.Find(x => x.value == newZATSTest.value);

            if (test != null)
            {
                string newZATSTestValue = checkZATSTestValue(newZATSTest.value, 1);
                newZATSTest.value = newZATSTestValue;
            }
            if (selectedZATSTest != null)
            {
                int index = ZATSTests.FindIndex(x => x.value == selectedZATSTest.value);

                if (before)
                {
                    ZATSTests.Insert(index, newZATSTest);
                }
                else
                {
                    if (index < ZATSTests.Count - 2)
                    {
                        ZATSTests.Insert(index + 1, newZATSTest);
                    }
                    else
                    {
                        ZATSTests.Add(newZATSTest);
                    }
                }
            }
            else
            {
                ZATSTests.Add(newZATSTest);
            }
        }
        private string checkZATSTestValue(string toAddZATSTestName, int number)
        {
            string numberString;

            if (number < 10)
            {
                numberString = "0" + number.ToString();
            }
            else
            {
                numberString = number.ToString();
            }

            string modName = string.Format("{0}{1}", toAddZATSTestName, number == 1 ? "" : numberString);

            foreach (ZatsTest test in ZATSTests)
            {
                if (test.value == modName)
                {
                    number = number + 1;
                    return checkZATSTestValue(toAddZATSTestName, number);
                }
            }

            return modName;
        }
    }

    enum ItemCardinality
    {
        single, zero_or_more, one_or_more
    }
}
