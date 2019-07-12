using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlteriusLib;

namespace UlteriusRealTime
{
    public partial class Form1 : Form
    {
        // Alow open console window
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();

        // define managed types to instantiation a event
        public delegate void DelegateButtonClick();
        public static event DelegateButtonClick ButtonFreeze;

        // 定义托管类型，
        delegate void SetTextCallBack(string text);

        //public static bool buttonFlag = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();         // open console window


        }



        private void button1_Click(object sender, EventArgs e)
        {

            DataAcquire dataAcquire = new DataAcquire();
            //dataAcquire.delegateUIRefresh += RefreshUI;     // 将更新UI的事件绑定到该托管

            Thread dataThread = new Thread(dataAcquire.GetData);

            dataThread.Start();
            Console.WriteLine("Data acquire thread running...");

            //buttonFlag = true;
        }

        public void RefreshUI()
        {

        }

        bool flag = false;
        private void buttonFreeze_Click(object sender, EventArgs e)
        {
            //if(flag)
            //    buttonFreeze.BackColor = SystemColors.Window;
            //else
            //    buttonFreeze.BackColor = SystemColors.Info;

            //flag = !flag;

            //// Raise the event myButtonClick
            //if (ButtonFreeze != null)
            //{
            //    ButtonFreeze();
            //}

            // Toggle Freeze state
            Ulterius.Singleton.toggleFreeze();

            if (Convert.ToBoolean(Ulterius.Singleton.getFreezeState()))
            {
                // Fronze
                buttonFreeze.BackColor = SystemColors.Window;

            }
            else
            {
                // Imaging
                buttonFreeze.BackColor = SystemColors.Info;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string input = "10.19.127.204"; //Use machine IP

            if (!UlteriusLib.Ulterius.Singleton.connect(input))
            {
                Console.WriteLine("Error: Could not connect");
            }
            else
            {
                Console.WriteLine("Successfully connected");
            }

            // Set data type to acquire
            bool iii = Ulterius.Singleton.setDataToAcquire(UlteriusDataType.udtBPost);
            Console.WriteLine(iii);

        }
    }
}

 
