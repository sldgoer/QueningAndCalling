using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVR100A_U_DSDK;

namespace CVR100U
{
    public class IDScan
    {
        public IDScan() { }

        //-1:erro; 0:closed; 1:initialized
        //readonly int status=0;
        public int Status { get; private set; }

        int iRetUSB = 0, iRetCOM = 0;
        public bool InitializeDevice()
        {
            try
            {

                int iPort;
                for (iPort = 1001; iPort <= 1016; iPort++)
                {
                    iRetUSB = CVRSDK.CVR_InitComm(iPort);
                    if (iRetUSB == 1)
                    {
                        break;
                    }
                }
                if (iRetUSB != 1)
                {
                    for (iPort = 1; iPort <= 4; iPort++)
                    {
                        iRetCOM = CVRSDK.CVR_InitComm(iPort);
                        if (iRetCOM == 1)
                        {
                            break;
                        }
                    }
                }

                if ((iRetCOM == 1) || (iRetUSB == 1))
                {
                    this.Status = 1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IdInfo ReadIdcardData()
        {
            IdInfo idinfo=new IdInfo();
            if (this.Status != 1) { return null; }
            try
            {
                //pictureBox1.ImageLocation = Application.StartupPath + "\\zp.bmp";
                byte[] name = new byte[30];
                int length = 30;
                CVRSDK.GetPeopleName(ref name[0], ref length);
                //MessageBox.Show();
                byte[] number = new byte[30];
                length = 36;
                CVRSDK.GetPeopleIDCode(ref number[0], ref length);
                byte[] people = new byte[30];
                length = 3;
                CVRSDK.GetPeopleNation(ref people[0], ref length);
                byte[] validtermOfStart = new byte[30];
                length = 16;
                CVRSDK.GetStartDate(ref validtermOfStart[0], ref length);
                byte[] birthday = new byte[30];
                length = 16;
                CVRSDK.GetPeopleBirthday(ref birthday[0], ref length);
                byte[] address = new byte[30];
                length = 70;
                CVRSDK.GetPeopleAddress(ref address[0], ref length);
                byte[] validtermOfEnd = new byte[30];
                length = 16;
                CVRSDK.GetEndDate(ref validtermOfEnd[0], ref length);
                byte[] signdate = new byte[30];
                length = 30;
                CVRSDK.GetDepartment(ref signdate[0], ref length);
                byte[] sex = new byte[30];
                length = 3;
                CVRSDK.GetPeopleSex(ref sex[0], ref length);

                byte[] samid = new byte[32];
                CVRSDK.CVR_GetSAMID(ref samid[0]);


                idinfo.address = System.Text.Encoding.GetEncoding("GB2312").GetString(address).Replace("\0", "").Trim();
                idinfo.sex = System.Text.Encoding.GetEncoding("GB2312").GetString(sex).Replace("\0", "").Trim();
                idinfo.birthday = System.Text.Encoding.GetEncoding("GB2312").GetString(birthday).Replace("\0", "").Trim();
                idinfo.signdate = System.Text.Encoding.GetEncoding("GB2312").GetString(signdate).Replace("\0", "").Trim();
                idinfo.number = System.Text.Encoding.GetEncoding("GB2312").GetString(number).Replace("\0", "").Trim();
                idinfo.name = System.Text.Encoding.GetEncoding("GB2312").GetString(name).Replace("\0", "").Trim();
                idinfo.people = System.Text.Encoding.GetEncoding("GB2312").GetString(people).Replace("\0", "").Trim();
                //idinfo.sami = "安全模块号：" + System.Text.Encoding.GetEncoding("GB2312").GetString(samid).Replace("\0", "").Trim();
                idinfo.validtermOfStart = System.Text.Encoding.GetEncoding("GB2312").GetString(validtermOfStart).Replace("\0", "").Trim();
                idinfo.validtermOfEnd = System.Text.Encoding.GetEncoding("GB2312").GetString(validtermOfEnd).Replace("\0", "").Trim();

                return idinfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DisconnectDevice()
        {
            if (this.Status == 1)
            {
                CVRSDK.CVR_CloseComm();
                this.Status = 0;
            }
        }
        
    }
}
