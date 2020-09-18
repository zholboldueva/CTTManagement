using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CTTManagement.DataModel.FormV
{
   public class ZatsTest
    {
        private string relationTriggeredByEnum;
        private string relationTriggeredByString;
        public string typeSymbol = "";
        public string value;

        public ZatsTest(string ZATSValue, string RelationTriggerType)
        {
            value = ZATSValue;
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
    }
}
