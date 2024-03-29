﻿using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlteriusLib;
using Ultrasonic3DReconstructor;

namespace UlteriusRealTime
{
    public partial class Form1 : Form
    {
        // Alow open console window
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();



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


        private void buttonFreeze_Click(object sender, EventArgs e)
        {

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


            string input = "10.19.127.125"; //Use machine IP

            // Connect the machine
            if (!UlteriusLib.Ulterius.Singleton.connect(input))
            {
                Console.WriteLine("Error: Could not connect");
            }
            else
            {
                Console.WriteLine("Successfully connected");
            }

            // Freeze the machien first
            if (!Convert.ToBoolean(Ulterius.Singleton.getFreezeState()))
            {
                // Fronze
                buttonFreeze.BackColor = SystemColors.Window;
                Ulterius.Singleton.toggleFreeze();

            }

            // Set data type to acquire
            if (Ulterius.Singleton.setDataToAcquire(UlteriusDataType.udtBPost))
            {
                Console.WriteLine("Set b8 Type successfully!\n");
            }

            DataAcquire dataAcquire = new DataAcquire();
            //dataAcquire.delegateUIRefresh += RefreshUI;     // 将更新UI的事件绑定到该托管

            Thread dataThread = new Thread(dataAcquire.GetData);

            dataThread.Start();
            Console.WriteLine("Data acquire thread running...");

        }



        private void buttonStart_Click(object sender, EventArgs e)
        {

            DataAcquire.ButtonFreeze += RefreshUI;
            //RefreshUI();

        }

        //public const long BUFFERSIZE = 640 * 480;
        //public static byte[] gBuffer = new byte[BUFFERSIZE];
        public void RefreshUI()
        {
            // 初始化gBuffer
            //int index = 0;
            //for (int i = 0; i < 480; i++)
            //{
            //    for (int j = 0; j < 640; j++)
            //    {
            //        gBuffer[index++] = 1;
            //    }
            //}
            //byte[] array = binaryReader.ReadBytes(arraySize);
            int arraySize = 480*640;
            byte[,] array2 = new byte[480, 640];
            //将一维数组转换为二维数组
            for (int j = 0; j < arraySize; j++)
            {
                array2[j / 640, j % 640] = DataAcquire.gBuffer[j];
            }

            Mat srcG = ConvertFile.ArrayToMat(array2);
            Mat dstG = new Mat();
            Cv2.ApplyColorMap(srcG, dstG, ColormapTypes.Jet);

            Bitmap bitmapG = ConvertFile.MatToBitmap(dstG);
            pictureBox.Image = bitmapG;
        }

        /// <summary>
        /// Convert image to byteArray
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] imgToByteArray(Image img)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.ToArray();
            }
        }

        /// <summary>
        /// Convert byteArray to image
        /// </summary>
        /// <param name="byteArrayIn"></param>
        /// <returns></returns>
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {

            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }


    }
}

 
