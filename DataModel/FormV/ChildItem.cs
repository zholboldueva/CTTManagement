using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CTTManagement.DataModel.FormV
{
    public class ChildItem
    {
        private List<FormItem> itemField { get; set; }

        private string typeField { get; set; }

       
    }

    enum ChildType
    {
        empty, subgroup, one_or_more, choice
    }
    public class ChildTypeEnum
    {
        string itemTypeString;
        string itemTypeEnum;
        public string getChildType()
        {
            switch (itemTypeEnum)
            {
                case "subgroup":
                    itemTypeString = "subgroup (default)";
                    break;
                case "one_or_more":
                    itemTypeString = "one_or_more";
                    break;
                case "choice":
                    itemTypeString = "choice";
                    break;
                case "empty":
                    itemTypeString = "";
                    break;
                default:
                    MessageBox.Show("get wrong child status type " + itemTypeEnum);
                    break;
            }
            return itemTypeString;

        }

        public string getComboboxItem(string itemTypeEnum)
        {
            switch (itemTypeEnum)
            {
                case "subgroup":
                    itemTypeString = "subgroup (default)";
                    break;
                case "one_or_more":
                    itemTypeString = "one_or_more";
                    break;
                case "choice":
                    itemTypeString = "choice";
                    break;
                case "empty":
                    itemTypeString = "";
                    break;
                default:
                    MessageBox.Show("wrong child status type " + itemTypeEnum);
                    break;
            }
            return itemTypeString;

        }

        public void SetChildTyp(string itemStatusString)
        {
            switch (itemStatusString)
            {
                case "subgroup (default)":
                    itemTypeEnum = ChildType.subgroup.ToString();
                    break;
                case "one_or_more":
                    itemTypeEnum = ChildType.one_or_more.ToString();
                    break;
                case "choice":
                    itemTypeEnum = ChildType.choice.ToString();
                    break;
                case "":
                    itemTypeEnum = ChildType.empty.ToString();
                    break;
                default:
                    MessageBox.Show("wrong child status type " + itemStatusString);
                    break;
            }
        }
    }


}
