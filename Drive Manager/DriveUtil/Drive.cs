using System;
using System.Diagnostics;
using System.IO;

namespace Drive_Manager.DriveUtil
{
    public class Drive
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

        public char Letter { get; }//drive letter
        public string ?Type { get;}
        public string ?Format {  get; }
        public string ?Label { get; }//The user assigned name of the drive
        public float TotalSize { get; }//Total storage size of the drive in Gigabytes
        public float SpaceAvailable { get; }//Total storage amount unused on the drive in Gigabytes
        public float SpaceUsed { get; }//Total storage amount used on the drive in Gigabytes
        public string ?ItemLabel { get; }//string used for visual in CollectionView

        private float BytesToGigabytes(long bytes)
        {
            return (float)bytes / (float)(1024 << 20);
        }

    }
}
