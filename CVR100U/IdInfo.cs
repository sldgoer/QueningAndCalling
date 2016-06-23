using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVR100U
{
    public class IdInfo
    {
        public String name { get; set; }  //姓名
        public String sex { get; set; }      //性别
        public String people { get; set; }    //民族，护照识别时此项为空
        public String birthday { get; set; }   //出生日期
        public String address { get; set; }  //地址，在识别护照时导出的是国籍简码
        public string number { get; set; }  //地址，在识别护照时导出的是国籍简码
        public string signdate { get; set; }   //签发日期，在识别护照时导出的是有效期至 
        public string validtermOfStart { get; set; }  //有效起始日期，在识别护照时为空
        public string validtermOfEnd { get; set; }  //有效截止日期，在识别护照时为空
    }
}
