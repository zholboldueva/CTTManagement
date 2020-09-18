using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CTTManagement.DataModel.FormV
{
    public class FormInput
    {
        public InputTypeRole inputRole = new InputTypeRole();
        public InputTypeSelect inputSelect = new InputTypeSelect();
        public InputTypeCustom inputCustom = new InputTypeCustom();
        public InputTypeTest inputSelfCert = new InputTypeTest();
        public InputTypeTest inputVerification = new InputTypeTest();
        public InputTypeTest inputAdhoc = new InputTypeTest();
        public InputTypeCombo inputCombo = new InputTypeCombo();
        public Dictionary<Guid, ComboInputItem> inputComboItems = new Dictionary<Guid, ComboInputItem>();

        public FormInput()
        {}

    }
    public class ItemInputEnumRoleSelect
    {
        string inputString;
        string inputEnum;
        public string getInputType()
        {
            switch (inputEnum)
            {
                case "select":
                    inputString = "select (default)";
                    break;
                //case "text":
                //    inputString = "text";
                //    break;
                //case "text_area":
                //    inputString = "text_area";
                //    break;
                //case "sstatic":
                //    inputString = "static";
                //    break;
                case "empty":
                    inputString = "";
                    break;
            }
            return inputString;
        }

        public string getComboboxItem(string enumItem)
        {
            switch (enumItem)
            {
                case "select":
                    inputString = "select (default)";
                    break;
                case "empty":
                    inputString = "";
                    break;
            }
            return inputString;
        }

        public void SetInputType(string inputString)
        {
            switch (inputString)
            {
                case "select (default)":
                    inputEnum = InputTypeRoleSelectEnum.select.ToString();
                    break;
                case "":
                    inputEnum = InputTypeRoleSelectEnum.empty.ToString();
                    break;
                default:
                    MessageBox.Show("wrong input type " + inputString);
                    break;
            }
        }
    }
    public class ItemInputEnumCustom
    {
        string inputString;
        string inputEnum;
        public string getInputType()
        {
            switch (inputEnum)
            {
                //case "select":
                //    inputString = "select (default)";
                //    break;
                case "text":
                    inputString = "text (default)";
                    break;
                case "text_area":
                    inputString = "text_area";
                    break;
                case "hex":
                    inputString = "hex";
                    break;
                case "hex8":
                    inputString = "hex8";
                    break;
                case "hex16":
                    inputString = "hex16";
                    break;
                case "hex24":
                    inputString = "hex24";
                    break;
                case "hex32":
                    inputString = "hex32";
                    break;
                case "hex128":
                    inputString = "hex128";
                    break;
                case "integer":
                    inputString = "integer";
                    break;
                case "int_0_255":
                    inputString = "int_0-255";
                    break;
                case "int_1_255":
                    inputString = "int_1-255";
                    break;
                case "int_2_255":
                    inputString = "int_2-255";
                    break;
                case "int_1_127":
                    inputString = "int_1-127";
                    break;
                //case "sstatic":
                //    inputString = "static";
                //    break;
                case "empty":
                    inputString = "";
                    break;
            }
            return inputString;
        }

        public string getComboboxItem(string enumItem)
        {
            switch (enumItem)
            {
                //case "select":
                //    inputString = "select (default)";
                //    break;
                case "text":
                    inputString = "text (default)";
                    break;
                case "text_area":
                    inputString = "text_area";
                    break;
                case "hex":
                    inputString = "hex";
                    break;
                case "hex8":
                    inputString = "hex8";
                    break;
                case "hex16":
                    inputString = "hex16";
                    break;
                case "hex24":
                    inputString = "hex24";
                    break;
                case "hex32":
                    inputString = "hex32";
                    break;
                case "hex128":
                    inputString = "hex128";
                    break;
                case "integer":
                    inputString = "integer";
                    break;
                case "int_0_255":
                    inputString = "int_0-255";
                    break;
                case "int_1_255":
                    inputString = "int_1-255";
                    break;
                case "int_2_255":
                    inputString = "int_2-255";
                    break;
                case "int_1_127":
                    inputString = "int_1-127";
                    break;
                //case "sstatic":
                //    inputString = "static";
                //    break;
                case "empty":
                    inputString = "";
                    break;
            }
            return inputString;
        }

        public void SetInputType(string inputString)
        {
            switch (inputString)
            {
                //case "select (default)":
                //    inputEnum = InputType.select.ToString();
                //    break;
                case "text (default)":
                    inputEnum = InputTypeCustomEnum.text.ToString();
                    break;
                case "text_area":
                    inputEnum = InputTypeCustomEnum.text_area.ToString();
                    break;
                case "hex":
                    inputEnum = InputTypeCustomEnum.hex.ToString();
                    break;
                case "hex8":
                    inputEnum = InputTypeCustomEnum.hex8.ToString();
                    break;
                case "hex16":
                    inputEnum = InputTypeCustomEnum.hex16.ToString();
                    break;
                case "hex24":
                    inputEnum = InputTypeCustomEnum.hex24.ToString();
                    break;
                case "hex32":
                    inputEnum = InputTypeCustomEnum.hex32.ToString();
                    break;
                case "hex128":
                    inputEnum = InputTypeCustomEnum.hex128.ToString();
                    break;
                case "integer":
                    inputEnum = InputTypeCustomEnum.integer.ToString();
                    break;
                case "int_0-255":
                    inputEnum = InputTypeCustomEnum.int_0_255.ToString();
                    break;
                case "int_1-255":
                    inputEnum = InputTypeCustomEnum.int_1_255.ToString();
                    break;
                case "int_2-255":
                    inputEnum = InputTypeCustomEnum.int_2_255.ToString();
                    break;
                case "int_1-127":
                    inputEnum = InputTypeCustomEnum.int_1_127.ToString();
                    break;
                //case "static":
                //    inputEnum = InputType.sstatic.ToString();
                //    break;
                case "":
                    inputEnum = InputTypeCustomEnum.empty.ToString();
                    break;
                default:
                    MessageBox.Show("wrong input type " + inputString);
                    break;
            }
        }
    }

    public class InputTypeRole
    {
        public ItemInputEnumRoleSelect inputRole = new ItemInputEnumRoleSelect();

        public InputTypeRole()
        {

        }

        public InputTypeRole(ItemInputEnumRoleSelect inputRole)
        {
            this.inputRole = inputRole;
        }
    }

    public class InputTypeSelect
    {
        public ItemInputEnumRoleSelect inputSelect = new ItemInputEnumRoleSelect();

        public InputTypeSelect()
        {

        }

        public InputTypeSelect(ItemInputEnumRoleSelect inputSelect)
        {
            this.inputSelect = inputSelect;
        }
    }

    public class InputTypeCustom
    {
        public ItemInputEnumCustom inputCustom = new ItemInputEnumCustom();
        //public string lable { get; set; }
        //public string options { get; set; }

        public InputTypeCustom()
        {

        }

        public InputTypeCustom(ItemInputEnumCustom inputCustom, string lable, string options)
        {
            this.inputCustom = inputCustom;
            //this.lable = lable;
            //this.options = options;
        }
    }

    public class InputTypeCombo
    {
        string inputString;
        string inputEnum;
        public string getInputType()
        {
            switch (inputEnum)
            {
                case "single":
                    inputString = "single (default)";
                    break;
                case "multiple":
                    inputString = "multiple";
                    break;
                case "empty":
                    inputString = "";
                    break;
            }
            return inputString;
        }

        public string getComboboxItem(string enumItem)
        {
            switch (enumItem)
            {
                case "single":
                    inputString = "single (default)";
                    break;
                case "multiple":
                    inputString = "multiple";
                    break;
                case "empty":
                    inputString = "";
                    break;
            }
            return inputString;
        }

        public void SetInputType(string inputString)
        {
            switch (inputString)
            {
                case "single (default)":
                    inputEnum = InputTypeComboEnum.single.ToString();
                    break;
                case "multiple":
                    inputEnum = InputTypeComboEnum.multiple.ToString();
                    break;
                case "":
                    inputEnum = InputTypeComboEnum.empty.ToString();
                    break;
                default:
                    MessageBox.Show("wrong input type " + inputString);
                    break;
            }
        }
    }

    public class InputTypeTest
    {
        public ItemInputEnum inputTest = new ItemInputEnum();
        public string value { get; set; }

        public InputTypeTest()
        {

        }

        public InputTypeTest(ItemInputEnum inputTest, string value)
        {
            this.inputTest = inputTest;
            this.value = value;
        }
    }

    public class ItemInputEnum
    {
        string inputString;
        string inputEnum;
        public string getInputType()
        {
            switch (inputEnum)
            {
                case "select":
                    inputString = "select (default)";
                    break;
                case "text":
                    inputString = "text";
                    break;
                //case "text_area":
                //    inputString = "text_area";
                //    break;
                case "sstatic":
                    inputString = "static";
                    break;
                case "empty":
                    inputString = "";
                    break;
            }
            return inputString;
        }

        public string getComboboxItem(string enumItem)
        {
            switch (enumItem)
            {
                case "select":
                    inputString = "select (default)";
                    break;
                case "text":
                    inputString = "text";
                    break;
                //case "text_area":
                //    inputString = "text_area";
                //    break;
                case "sstatic":
                    inputString = "static";
                    break;
                case "empty":
                    inputString = "";
                    break;
            }
            return inputString;
        }

        public void SetInputType(string inputString)
        {
            switch (inputString)
            {
                case "select (default)":
                    inputEnum = InputTypeEnum.select.ToString();
                    break;
                case "text":
                    inputEnum = InputTypeEnum.text.ToString();
                    break;
                //case "text_area":
                //    inputEnum = InputTypeEnum.text_area.ToString();
                //    break;
                case "static":
                    inputEnum = InputTypeEnum.sstatic.ToString();
                    break;
                case "":
                    inputEnum = InputTypeEnum.empty.ToString();
                    break;
                default:
                    MessageBox.Show("wrong input type " + inputString);
                    break;
            }
        }
    }

   

    public class InputVerification
    {

        private string typeField;

        private string valueField;

       
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

      
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    public partial class InputAdhoc
    {

        private string typeField;

        private string valueField;

      
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

      
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    enum StatusType
    {
        empty, M, O, R, OM, MR, MS, MM
    }

    enum InputTypeEnum
    {
        empty, select, text, sstatic
    }

    enum InputTypeCustomEnum
    {
        empty, text, text_area, hex, hex8, hex16, hex24, hex32, hex128, integer, int_0_255, int_1_255, int_2_255, int_1_127
    }

    enum InputTypeRoleSelectEnum
    {
        empty, select
    }

    enum InputTypeComboEnum
    {
        empty, single, multiple
    }
}
