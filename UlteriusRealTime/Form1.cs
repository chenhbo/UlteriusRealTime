using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlteriusRealTime
{
    public partial class Form1 : Form
    {
        //


        // define managed types to instantiation a event
        public delegate void DelegateButtonClick();
        public event DelegateButtonClick myButtonClick;

        // 定义托管类型，
        delegate void SetTextCallBack(string text);

        public static bool buttonFlag = false;
        public Form1()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread getData = new Thread(ThreadFunction);
            getData.Start();
            
        }

        // Thread Process
        private void ThreadFunction()
        {
            myButtonClick += ChangeTextBox; // Bind the delegate to be invoked to receive the ButtonClick 

        }

        private void ChangeTextBox()
        {
            textBox1.Text = "Raise Succsessfully!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Raise the event myButtonClick
            if (myButtonClick != null)
            {
                myButtonClick();
            }
            //buttonFlag = true;
        }
    }
}
