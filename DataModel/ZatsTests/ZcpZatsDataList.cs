//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     �nderungen an dieser Datei k�nnen falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Dieser Quellcode wurde automatisch generiert von xsd, Version=4.6.1055.0.
// 
namespace CTTManagement.DataModel.ZatsTests {
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ZcpZatsDataList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private List<ZcpZatsData> zcpZatsDataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ZcpZatsData")]
        public List<ZcpZatsData> ZcpZatsData {
            get {
                return this.zcpZatsDataField;
            }
            set {
                this.zcpZatsDataField = value;
                this.RaisePropertyChanged("ZcpZatsData");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ZcpZatsData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private List<ZatsValue> zatsValuesField;
        
        private List<string> formItemNumbersField;
        
        private List<int> itemIdsField;
        
        private string keyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public List<ZatsValue> ZatsValues {
            get {
                return this.zatsValuesField;
            }
            set {
                this.zatsValuesField = value;
                this.RaisePropertyChanged("ZatsValues");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("FormItemNumber", IsNullable=false)]
        public List<string> FormItemNumbers {
            get {
                return this.formItemNumbersField;
            }
            set {
                this.formItemNumbersField = value;
                this.RaisePropertyChanged("FormItemNumbers");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ItemId", IsNullable=false)]
        public List<int> ItemIds {
            get {
                return this.itemIdsField;
            }
            set {
                this.itemIdsField = value;
                this.RaisePropertyChanged("ItemIds");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("Key");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ZatsValue : object, System.ComponentModel.INotifyPropertyChanged {
        
        private List<string> formItemNumbersField;
        
        private List<int> itemIdsField;
        
        private string valueField;
        
        private InputType dataTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("FormItemNumber", IsNullable=false)]
        public List<string> FormItemNumbers {
            get {
                return this.formItemNumbersField;
            }
            set {
                this.formItemNumbersField = value;
                this.RaisePropertyChanged("FormItemNumbers");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ItemId", IsNullable=false)]
        public List<int> ItemIds {
            get {
                return this.itemIdsField;
            }
            set {
                this.itemIdsField = value;
                this.RaisePropertyChanged("ItemIds");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public InputType DataType {
            get {
                return this.dataTypeField;
            }
            set {
                this.dataTypeField = value;
                this.RaisePropertyChanged("DataType");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    public enum InputType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("[none]")]
        none,
        
        /// <remarks/>
        Text,
        
        /// <remarks/>
        Hex,
        
        /// <remarks/>
        Hex8,
        
        /// <remarks/>
        Hex16,
        
        /// <remarks/>
        Hex24,
        
        /// <remarks/>
        Hex32,
        
        /// <remarks/>
        Hex128,
        
        /// <remarks/>
        Integer,
        
        /// <remarks/>
        Int_0_255,
        
        /// <remarks/>
        Int_1_255,
        
        /// <remarks/>
        Int_2_255,
        
        /// <remarks/>
        Int_1_127,
    }
}
