using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP.Models
{
    public class HostelModel
    {
        
        public int H_Id { get; set; }
        
        
        public string H_Name { get; set; }
        

        public string H_Address { get; set; }
        
    
        public string H_Mobile { get; set; }
        
        public string H_Description { get; set; }
        
        public string H_Near_University { get; set; }
        
        public string H_Area { get; set; }
        
        public Nullable<int> H_Total_Room { get; set; }
        
        public Nullable<int> H_Avail_Room { get; set; }
        
        public Nullable<int> H_Security { get; set; }
        
        public Nullable<int> H_Wifi_Charges { get; set; }
        
        public string HC_Name{ get; set; }
        
        public string HF_Name { get; set; }
        
        public string HS_Id { get; set; }
        
        public string U_Id { get; set; }

        public string I_Name { get; set; }

        public float Rating { get; set; }


    }
}