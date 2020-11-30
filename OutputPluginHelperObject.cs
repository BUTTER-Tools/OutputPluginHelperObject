using System;
using System.Collections.Generic;
using System.Linq;

namespace OutputHelperLib
{
    public class Payload
    {
        public string FileID { get; set; }
        public string Type { get; set; }
        public int TextNumber { get; set; }
        public List<ulong> SegmentNumber { get; set; }
        public List<string> SegmentID { get; set; }
        public List<string> StringList { get; set; }
        public IList<string> StringListIterable { get; set; }
        public List<string[]> StringArrayList { get; set; }
        public List<object> ObjectList {get;set;}
        
        

        public Payload()
        {
            FileID = "";
            Type = "";
            TextNumber = 0;
            SegmentNumber = new List<ulong>();
            SegmentID = new List<string>();
            StringList = new List<string>();
            StringArrayList = new List<string[]>();
            ObjectList = new List<object>();
        }


        public Payload DeepCopy()
        {
            Payload newPload = (Payload)this.MemberwiseClone();
            newPload.FileID = String.Copy(FileID);
            newPload.Type = String.Copy(Type);
            newPload.TextNumber = TextNumber;
            newPload.SegmentNumber = SegmentNumber.Select(item => (ulong)item).ToList();
            newPload.SegmentID = SegmentID.Select(item => String.Copy(item)).ToList();
            newPload.StringList = StringList.Select(item => String.Copy(item)).ToList();
            newPload.StringArrayList = StringArrayList.Select(item => (string[])((string[])item.Clone()).ToArray()).ToList();
            
            //note that this is a SHALLOW copy -- I will need to rework this later
            //and ensure that any object it's trying to copy implements a "Clone()" method of some type
            newPload.ObjectList = new List<object>(ObjectList);
                


            if (StringListIterable != null) { newPload.StringListIterable = StringListIterable.ToList(); }
            else { newPload.StringListIterable = new List<string>(); }
            return newPload;
        }

        


    }

}
