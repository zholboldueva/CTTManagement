using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CTTManagement.DataModel.FormV
{
   public class Relation
    {
        public Guid toItemId { get; set; }
        public Guid fromItemId { get; set; }
        private string relationTypeEnum;
        private string relationTypeString;
        private string relationTriggeredByEnum;
        private string relationTriggeredByString;
        private string directionSymbol;
        public string typeSymbol = "";

        public Relation(Guid FromItemId, Guid ToItemId, string RelationType, string RelationTriggerType)
        {
            fromItemId = FromItemId;
            toItemId = ToItemId;
            SetRelationType(RelationType);
            SetRelationTriggeredBy(RelationTriggerType);
        }

        public string getRelationTriggertBy()
        {
            switch (relationTriggeredByEnum)
            {
                case "select":
                    relationTriggeredByString = "select";
                    break;
                case "support":
                    relationTriggeredByString = "support";
                    break;
                case "control":
                    relationTriggeredByString = "control";
                    break;
            }
            return relationTriggeredByString;
        }

        public void SetRelationTriggeredBy(string relationTriggeredByString)
        {
            switch (relationTriggeredByString)
            {
                case "select":
                    relationTriggeredByEnum = RelationType.select.ToString();
                    typeSymbol = "(Sel)";
                    break;
                case "support":
                    relationTriggeredByEnum = RelationType.support.ToString();
                    typeSymbol = "(Sup)";
                    break;
                case "control":
                    relationTriggeredByEnum = RelationType.control.ToString();
                    typeSymbol = "(Con)";
                    break;
                default:
                    MessageBox.Show("wrong relation trigger type " + relationTriggeredByString);
                    break;
            }
        }

        public string getRelationType()
        {
            switch (relationTypeEnum)
            {
                case "select":
                    relationTypeString = "select";
                    break;
                case "support":
                    relationTypeString = "support";
                    break;
                case "control":
                    relationTypeString = "control";
                    break;
            }
            return relationTypeString;
        }

        public void SetRelationType(string relationTypeString)
        {
            switch (relationTypeString)
            {
                case "select":
                    relationTypeEnum = RelationType.select.ToString();
                    break;
                case "support":
                    relationTypeEnum = RelationType.support.ToString();
                    break;
                case "control":
                    relationTypeEnum = RelationType.control.ToString();
                    break;
                default:
                    MessageBox.Show("wrong relation type " + relationTypeString);
                    break;
            }
        }

        private string getDirectionSymbol(Guid itemId)
        {
            if (itemId == fromItemId)
            {
                directionSymbol = "--> ";
            }
            else if (itemId == toItemId)
            {
                directionSymbol = "<-- ";
            }
            else
            {
                directionSymbol = "wrong relation! ";
            }
            return directionSymbol;
        }

        private string getRelationListItemText(string itemName)
        {
            int maxLenght = 60;

            if (itemName.Length > maxLenght)
            {
                if (itemName.LastIndexOf("Version") != -1)
                {
                    return itemName.Substring(0, maxLenght - (itemName.Length - itemName.LastIndexOf("Version")) - 5) + " ... " + itemName.Substring(itemName.LastIndexOf("Version"));
                }
                else
                {
                    return itemName.Substring(0, maxLenght - 5) + " ... ";
                }
            }

            return itemName.PadRight(maxLenght, ' ');
        }

        private string getRelationListItemName(string itemName)
        {
            string relationListItemName = "";



            return relationListItemName;
        }

        public Relation getCopy(Guid newFromItemId)
        {
            Relation copy = new Relation(newFromItemId, toItemId, getRelationType(), getRelationTriggertBy());

            return copy;
        }

        public string getRelationText(Dictionary<Guid, FormNode> itemList)
        {
            string relationText = itemList[fromItemId].getNodeName() + " " + getDirectionSymbol(fromItemId) + typeSymbol + " " + itemList[toItemId].getNodeName();
            return relationText;
        }


    }

    enum RelationType
    {
        select, support, control
    }
}
