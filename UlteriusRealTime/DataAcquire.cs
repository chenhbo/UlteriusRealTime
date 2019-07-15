using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlteriusLib;

namespace UlteriusRealTime
{
    public class DataAcquire
    {
        // static buff to get data and display
        public const int EXIT_FN = 0;
        public const long BUFFERSIZE = 640 * 480;
        public static byte[] gBuffer = new byte[BUFFERSIZE];

        // define delegate of UI refresh
        public delegate void DelegateUIRefresh();
        public DelegateUIRefresh delegateUIRefresh;

        // define managed types to instantiation a event
        public delegate void DelegateButtonClick();
        public static event DelegateButtonClick ButtonFreeze;

        public static bool newFrame(UlteriusDataDesc desc, byte[] buff, UlteriusDataType type, int cine, int frmnum)
        {
            if (buff == null || !Convert.ToBoolean(desc.ss))
            {
                Console.WriteLine("Error: no actual frame data received! ");
                return false;
            }

            // ss: data sample size in bits
            //Console.WriteLine("-> {0} frame, type: {1}, size: {2}", frmnum, type, desc.ss);
            //Console.WriteLine("Image w: {0}, Image h: {1}", desc.w, desc.h);
            //Console.WriteLine(buff.Length);
            //Console.WriteLine();
            //int index = 0;
            //for (int i = 0; i < 480; i++)
            //{
            //    for (int j = 0; j < 640; j++)
            //    {
            //        Console.Write(buff[index++]);
            //    }
            //    Console.WriteLine();
            //}
            Array.Copy(buff, gBuffer, buff.Length);

            // Raise the event myButtonClick
            if (ButtonFreeze != null)
            {
                ButtonFreeze();
            }

            return true;
        }

        public void GetData()
        {
            // 初始化gBuffer
            int index = 0;
            for (int i = 0; i < 480; i++)
            {
                for (int j = 0; j < 640; j++)
                {
                    gBuffer[index++] = 0;
                }
            }

            Console.WriteLine("Come in data acquire thread！\n");

            //Form1.ButtonFreeze += ToggleFreeze; // 将翻转Freeze操作绑定到BUttonFreeze

            string input = "10.19.127.125"; //Use machine IP

            //UlteriusDataDesc ulteriusDataDesc = new UlteriusDataDesc();

            // Set callback
            UlteriusLib.Ulterius.Singleton.setCallback(newFrame);

            // do something

            // 
            //delegateUIRefresh(); // 之后把更新UI绑定到该托管
        }

        public void ToggleFreeze()
        {
            //Ulterius.Singleton.toggleFreeze();
            //Console.WriteLine("Toggle Freeze");
            MessageBox.Show("ToggleFreeze");
            
        }
    }
}

