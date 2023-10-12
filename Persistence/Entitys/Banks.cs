using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransformationTest.Persistence.Entitys
{
    public class Banks
    {
        [Key]
        public string Bank_ID { get; set; }
        public string Bank_Name { get; set; }
        public int FontID { get; set; }
        public string Def_Account_Mask { get; set; }
        public string Def_User_Micr_Value { get; set; }
        public string MICR_Font { get; set; }
        public string Filler1 { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string Address_3 { get; set; }
        public string Address_4 { get; set; }
        public string Branch_Office_Code { get; set; }
        public string Bank_Code { get; set; }
        public string Transact_Fraction_1 { get; set; }
        public string Transact_Fraction_2 { get; set; }
        public string Transact_Fraction_3 { get; set; }
        public string Def_Transit_MICR { get; set; }
        public int Last_Check_No { get; set; }
        public bool Stamp_Duty { get; set; }
        public int Duty_Stamp_FontID { get; set; }
        public short ProjectKey { get; set; }
        public string Filler2 { get; set; }
        public bool Addenda_YesNo { get; set; }
        public int Addenda_No_Lines { get; set; }
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public string Col4 { get; set; }
        public string Col5 { get; set; }
    }


}
