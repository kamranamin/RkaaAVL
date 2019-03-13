using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ArkaServices
{
    public partial class Form1 : Form
    {
        public string myHeader { get; set; }
        public string myLenght { get; set; }
        public string myDataType { get; set; }
        public string  myImei { get; set; }



        public string myVehicleStatus { get; set; }
        public string myDateTime { get; set; }
        public string myBatteryVoltage { get; set; }
        public string mySuplayVoltage { get; set; }
        public string myAdc1 { get; set; }
        public string myAdc2 { get; set; }
        public string myAdc3 { get; set; }
        public string myAdc4 { get; set; }
        public string myTemperatureA { get; set; }
        public string myTemperatureB { get; set; }
        public string myLACCI { get; set; }
        public string myCellId { get; set; }
        public string myGPSSatellites { get; set; }
        public string myGSMsignal { get; set; }
        public int myAngle { get; set; }
        public int mySpeed { get; set; }
        public string myHDOP { get; set; }
        public int myMileage { get; set; }
        public float myLatitude { get; set; }
        public int  myVehicleId { get; set; }
        public string myNS { get; set; }
        public float myLongitude { get; set; }
        public string myEW { get; set; }
        public string mySerialNumber { get; set; }
        public string myChecksum { get; set; }
      
        UdpClient udpClient = new UdpClient(1245);
        string data = "";
      
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRecive_Click(object sender, EventArgs e)
        {
            try
            {
                
              
                udpClient.BeginReceive(new AsyncCallback(Recive), null);
                

            } catch (Exception ex)
            { richtxtRecive.Text += Environment.NewLine + "Erorr:\t" + ex.Message +DateTime.Now; }
        }
        int i = 0;
        void Recive(IAsyncResult result)
        {
            try
            {
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 1246);
                byte[] recived = udpClient.EndReceive(result, ref iPEndPoint);
                data = Encoding.UTF8.GetString(recived);
                int k = data.Length;
                myHeader = data.Substring(0, 2);
                myLenght = data.Substring(2, 4);
                myDataType = data.Substring(6, 2);
                myImei =( data.Substring(8, 15));
                myVehicleStatus = data.Substring(24, 8);
                myDateTime = data.Substring(32, 12);
                myBatteryVoltage = data.Substring(44, 2);
                mySuplayVoltage = data.Substring(46, 2);
                myAdc1 = data.Substring(48, 4);
                myAdc2 = data.Substring(52, 4);
                myAdc3 = data.Substring(56, 4);
                myAdc4 = data.Substring(60, 4);
                myTemperatureA = data.Substring(64, 4);
                myTemperatureB = data.Substring(68, 4);
                myLACCI = data.Substring(72, 4);
                myCellId = data.Substring(76, 4);
                myGPSSatellites = data.Substring(80, 2);
                myGSMsignal = data.Substring(82, 2);
                myAngle = Convert.ToInt16(data.Substring(84, 3));
                mySpeed = Convert.ToInt16(data.Substring(87, 3));
                myHDOP = data.Substring(90, 4);
                myMileage = Convert.ToInt16(data.Substring(94, 7));
                // string s = (data.Substring(101, 9));
                myLatitude = float.Parse(data.Substring(101, 9));
                myNS = data.Substring(110, 1);
                myLongitude = float.Parse(data.Substring(111, 10));
                myEW = data.Substring(121, 1);
                mySerialNumber = data.Substring(122, 4);
                myChecksum = data.Substring(126, 2);
                using (var myContext = new Context())
                {
                    myVehicleId = myContext.Vehicle.First(s => s.Imei == myImei).VehicleId;
                }
                 

                Task.Run(async () => InsertToDB()); 


                this.Invoke(new MethodInvoker(delegate
                {
                    richtxtRecive.Text = i++.ToString();


                }));
                udpClient.BeginReceive(new AsyncCallback(Recive), null);
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void richtxtRecive_TextChanged(object sender, EventArgs e)
        {
           // richtxtRecive.SelectionStart = richtxtRecive.Text.Length;
           //richtxtRecive.ScrollToCaret();
           
        }
        private  async Task InsertToDB( )
        {
           
            using (var context = new Context())
            {
                GpsData gpsDt = new GpsData()
                {
                    Header = myHeader,
                    Lenght = myLenght,
                    DataType = myDataType,
                    Imei = myImei,
                    VehicleStatus = myVehicleStatus,
                    DateTime = myDateTime,
                    BatteryVoltage = myBatteryVoltage,
                    SuplayVoltage = mySuplayVoltage,
                    Adc1 = myAdc1,
                    Adc2 = myAdc2,
                    Adc3 = myAdc3,
                    Adc4 = myAdc4,
                    TemperatureA = myTemperatureA,
                    TemperatureB = myTemperatureB,
                    LACCI = myLACCI,
                    CellId = myCellId,
                    GPSSatellites = myGPSSatellites,
                    GSMsignal = myGSMsignal,
                    Angle = myAngle,
                    Speed = mySpeed,
                    HDOP = myHDOP,
                    Mileage = myMileage,
                    Latitude = myLatitude+0001,
                    NS = myNS,
                    Longitude = myLongitude+ 0001,
                    EW = myEW,
                    SerialNumber = mySerialNumber,
                    Checksum=myChecksum,
                    VehicleId=myVehicleId





                };
                context.GpsData.Add(gpsDt);
                int x = await context.SaveChangesAsync();

            }


        }
        //private static async Task AddStudent()
        //{
          
           
            
        //        context.Students.Add(myStudent);
        //        await context.SaveChangesAsync();
           
        //}
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
