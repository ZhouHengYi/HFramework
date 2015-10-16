using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace H.Core.Utility
{
    static class PDFGenerator
    {
        static float pageWidth = 594.0f;

        static float pageDepth = 828.0f;

        static float pageMargin = 30.0f;

        static float fontSize = 20.0f;

        static float leadSize = 10.0f;

        static StreamWriter pPDF = new StreamWriter("E:\\www.fanganwang.com.pdf");

        static MemoryStream mPDF = new MemoryStream();

        static void ConvertToByteAndAddtoStream(string strMsg)
        {

            Byte[] buffer = null;

            buffer = ASCIIEncoding.ASCII.GetBytes(strMsg);

            mPDF.Write(buffer, 0, buffer.Length);

            buffer = null;

        }

        static string xRefFormatting(long xValue)
        {

            string strMsg = xValue.ToString();

            int iLen = strMsg.Length;

            if (iLen < 10)
            {

                StringBuilder s = new StringBuilder();

                int i = 10 - iLen;

                s.Append('0', i);

                strMsg = s.ToString() + strMsg;

            }

            return strMsg;

        }

    }

}
