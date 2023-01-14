using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;

namespace Classes;

public class LogController
{
    public static void WriteLog(string message)
    {
        StringBuilder sb = new StringBuilder();
        message = DateTime.Now.ToString() + "->" + message;
        sb.Append(message);
        try
        {           
        sb.Append("\n"); 
        File.AppendAllText("C:\\Users\\sergiofau\\Desktop\\CosasSergio\\ClaseServidor\\RutaLog\\NombreLog.txt", sb.ToString());
        sb.Append("\n");
        sb.Clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }       
    }
}    