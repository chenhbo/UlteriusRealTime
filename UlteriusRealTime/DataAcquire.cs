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
        public const long BUFFERSIZE = 4 * 1024 * 1024;
        public static byte[] gBuffer = new byte[BUFFERSIZE];

        // define delegate of UI refresh
        public delegate void DelegateUIRefresh();
        public DelegateUIRefresh delegateUIRefresh;

        // 

        public static bool newFrame(UlteriusDataDesc desc, byte[] buff, UlteriusDataType type, int cine, int frmnum)
        {
            if (buff == null || !Convert.ToBoolean(desc.ss))
            {
                Console.WriteLine("Error: no actual frame data received! ");
                return false;
            }

            // ss: data sample size in bits
            Console.WriteLine("-> {0} frame, type: {1}, size: {2}", frmnum, type, desc.ss);
            Console.WriteLine("Image w: {0}, Image h: {1}", desc.w, desc.h);
            Console.WriteLine();

            Array.Copy(buff, gBuffer, buff.Length);

            return true;
        }

        public void GetData()
        {
            Console.WriteLine(" Come in data acquire thread！");

            Form1.ButtonFreeze += ToggleFreeze; // 将翻转Freeze操作绑定到BUttonFreeze

            string input = "10.19.127.204"; //Use machine IP

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

