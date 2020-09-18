using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CTTManagement.DataModel.FormV
{
   public class ItemRelation
    {

        private List<string> toItemIdField;

        private string typeField;

        public List<string> toItemId
        {
            get
            {
                return this.toItemIdField;
            }
            set
            {
                this.toItemIdField = value;
            }
        }

        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    public class ItemCardinalityEnum
    {
        string itemCardinalityString;
        string itemCardinalityEnum;
        public string getCardinality()
        {
            switch (itemCardinalityEnum)
            {
                case "single":
                    itemCardinalityString = "single (default)";
                    break;
                case "zero_or_more":
                    itemCardinalityString = "zero_or_more";
                    break;
                case "one_or_more":
                    itemCardinalityString = "one_or_more";
                    break;
                default:
                    itemCardinalityString = "single (default)";
                    //MessageBox.Show("get wrong cardinality type " + itemCardinalityEnum);
                    break;
            }
            return itemCardinalityString;

        }

        public void SetCardinality(string itemCardinalityString)
        {
            switch (itemCardinalityString)
            {
                case "single (default)":
                    itemCardinalityEnum = ItemCardinality.single.ToString();
                    break;
                case "zero_or_more":
                    itemCardinalityEnum = ItemCardinality.zero_or_more.ToString();
                    break;
                case "one_or_more":
                    itemCardinalityEnum = ItemCardinality.one_or_more.ToString();
                    break;
                default:
                    MessageBox.Show("wrong cardinality type " + itemCardinalityString);
                    break;
            }
        }
    }
    }
