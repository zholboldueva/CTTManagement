using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CTTManagement.Model
{
    public class ZatsTestsModel : INotifyPropertyChanged
    {

        private string testCaseName;
        private string tcInputKeys;
        private string tcResultKeys;
        private string write;
        private string review;
        private string zwareDate;
        private string powerStripDate;
        private string pirSensorDate;
        private string doorLockDate;
        private string diverseType;
        private string diverseDate;
        private string dUTBasedDiverseType;
        private string dUTBasedDiverseDate;
        private string zCPBasedType;
        private string zCPBasedDate;
        private string comment;
        private string specRevision;
        private string testCaseGroup;
        private string librariesNeeded;


        public string TestCaseName {
            get { return testCaseName; }
            set { testCaseName = value; NotifyPropertyChanged();
                //PropertyChanged?.Invoke(nameof(TestCaseName));
            }
        }
        public string TCInputKeys {
            get { return tcInputKeys; }
            set { tcInputKeys = value; NotifyPropertyChanged(); }
        }
        public string TCResultKeys
        {
            get { return tcResultKeys; }
            set { tcResultKeys = value; NotifyPropertyChanged(); }
        }
        public string Write {
            get { return write; }
            set { write = value; NotifyPropertyChanged(); }
        }
        public string Review
        {
            get { return review; }
            set { review = value; NotifyPropertyChanged(); }
        }
        public string ZWareDate
        {
            get { return zwareDate; }
            set { zwareDate = value; NotifyPropertyChanged(); }
        }
        public string PowerStripDate
        {
            get { return powerStripDate; }
            set { powerStripDate = value; NotifyPropertyChanged(); }
        }
        public string PIRSensorDate {
            get { return pirSensorDate; }
            set { pirSensorDate = value; NotifyPropertyChanged(); }
        }
        public string DoorLockDate {
            get { return doorLockDate; }
            set { doorLockDate = value; NotifyPropertyChanged(); }
        }
        public string DiverseType
        {
            get { return diverseType; }
            set { diverseType = value; NotifyPropertyChanged(); }
        }
        public string DiverseDate {
            get { return diverseDate; }
            set { diverseDate = value; NotifyPropertyChanged(); }
        }
        public string DUTBasedDiverseType
        {
            get { return dUTBasedDiverseType; }
            set { dUTBasedDiverseType = value; NotifyPropertyChanged(); }
        }
        public string DUTBasedDiverseDate
        {
            get { return dUTBasedDiverseDate; }
            set { dUTBasedDiverseDate = value; NotifyPropertyChanged(); }
        }
        public string ZCPBasedType
        {
            get { return zCPBasedType; }
            set { zCPBasedType = value; NotifyPropertyChanged(); }
        }
        public string ZCPBasedDate {
            get { return zCPBasedDate; }
            set { zCPBasedDate = value; NotifyPropertyChanged(); }
        }
        public string Comment {
            get { return comment; }
            set { comment = value; NotifyPropertyChanged(); }
        }
        public string SpecRevision {
            get { return specRevision; }
            set { specRevision = value; NotifyPropertyChanged(); }
        }
        public string TestCaseGroup
        {
            get { return testCaseGroup; }
            set { testCaseGroup = value; NotifyPropertyChanged(); }
        }
        public string LibrariesNeeded {
            get { return librariesNeeded; }
            set { librariesNeeded = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
