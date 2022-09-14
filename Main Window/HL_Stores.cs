using System;
using System.Collections.Generic;
using System.Text;

namespace Main_Window
{

    public class RootClass
    {
        public List<HL_Stores> Stores { get; set; }
    }
    public class HL_Stores
    {
            //"Store_Number": 1,
            //"Location": "Edmond, OK",
            //"Street_Address": "3160 S. Broadway",
            //"City": "Edmond",
            //"State": "OK"

        public int Store_Number { get; set; }
        public string Location { get; set; }
        public string Street_Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public HL_Stores()
        {
            int Store_Number = 0;
            string Location = string.Empty;
            string Street_Address = string.Empty;
            string City = string.Empty;
            string State = string.Empty;

        }

        public override string ToString()
        {
            //  temp format for viewing
            return $"#: {Store_Number}, Location: {Location}";
        }

    }
}
