using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultrasonic3DReconstructor
{
    class ConvertFile
    {

        /// <summary>
        /// Short Type Convert to Byte
        /// </summary>
        /// <param name="inShort"></param>
        /// <returns></returns>
        public static byte[,] ShortArrayToByte(short[,] inShort)
        {
            int rows = inShort.GetLength(0);
            int cols = inShort.GetLength(1);
            byte[,] outByte = new byte[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    outByte[i, j] = (byte)inShort[i, j];
                }
            }
            return outByte;
        }


        /// <summary>
        /// OpenCvSharp Convert byteArray to Mat 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public unsafe static Mat ArrayToMat(byte[,] array)
        {
            Mat mat = new Mat(array.GetLength(0), array.GetLength(1), MatType.CV_8UC1);
            int cols = mat.Cols;
            int rows = mat.Rows;
            byte* ptr = (byte*)mat.Data.ToPointer();
            long step = mat.Step();
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    *MatElm_Byte(ptr, step, i, j) = array[j, i];
                }
            }
            return mat;
        }

        /// <summary>
        /// OpenCvSharp Convert shortArray to Mat
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public unsafe static Mat ArrayToMat(short[,] array)
        {
            Mat mat = new Mat(array.GetLength(0), array.GetLength(1), MatType.CV_8UC3);
            int cols = mat.Cols;
            int rows = mat.Rows;
            byte* ptr = (byte*)mat.Data.ToPointer();
            long step = mat.Step();
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    *MatElm_Int16(ptr, step, i, j) = array[j, i];
                }
            }
            return mat;
        }

        public unsafe static byte* MatElm_Byte(byte* ptr, long step, int x, int y)
        {
            return ptr + y * step + x;
        }

        public unsafe static short* MatElm_Int16(byte* ptr, long step, int x, int y)
        {
            return (short*)(ptr + y * step + x * 2);
        }

        /// <summary>
        /// OpenCvSharp Convert Mat to Bitmap
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap MatToBitmap(Mat img)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img);
        }

        /// <summary>
        /// OpenCvSharp Convert Bitmap to Mat
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Mat BitmapToMat(Bitmap bitmap)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
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
