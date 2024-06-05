using System;
using System.IO;

namespace Drive_Manager.Models
{
    internal class Drive
    {
        public Drive(DriveInfo d)
        {
            this.Letter = d.Name[0];
            this.Type =Enum.GetName(typeof(DriveType), d.DriveType);
            this.Format = d.DriveFormat;
            this.Label = d.VolumeLabel;
            this.TotalSize = this.BytesToGigabytes(d.TotalSize);
            this.SpaceAvailable = this.BytesToGigabytes(d.TotalFreeSpace);
            this.SpaceUsed = this.TotalSize - this.SpaceAvailable;
            this.ItemLabel = this.Letter + ":    " + this.Label + "     " 
                + this.SpaceUsed.ToString("#.##") + " / " + this.TotalSize.ToString("#.##") + " GB used";
        }

        public char Letter { get; private set; }//drive letter
        public string ?Type { get; private set; }
        public string ?Format {  get; private set; }
        public string ?Label { get; private set; }//The user assigned name of the drive
        public float TotalSize { get; private set; }//Total storage size of the drive in Gigabytes
        public float SpaceAvailable { get; private set; }//Total storage amount unused on the drive in Gigabytes
        public float SpaceUsed { get; private set; }//Total storage amount used on the drive in Gigabytes
        public string ?ItemLabel { get; private set; }//string used for visual in collectionview

        private float BytesToGigabytes(long bytes)
        {
            return (float)bytes / (float)(1024 << 20);
        }
    }
}
