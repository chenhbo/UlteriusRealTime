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
            //UlteriusLib.Ulterius.Singleton.setCallback(Ulterius.Singleton.Callback(ulteriusDataDesc, buffer,UlteriusLib.UlteriusDataType.udtBPre,10,1));
            //UlteriusLib.Ulterius.Singleton.setParamCallback(UlteriusLib.Ulterius.Singleton.ParamCallback);

            int sel = -1; int i = -1;
            // do something


            // 
            //delegateUIRefresh(); // 之后把更新时间绑定到该托管
        }

        public void ToggleFreeze()
        {
            //Ulterius.Singleton.toggleFreeze();
            //Console.WriteLine("Toggle Freeze");
            MessageBox.Show("ToggleFreeze");
            // 当窗体按下时，获取当前Freeze状态，根据状态设置Button Color
            
        }
    }
}

