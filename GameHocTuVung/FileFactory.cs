using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameHocTuVung
{
    public class FileFactory
    {
       public Dictionary<string,string> ReadTextData(string path)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                string line = sr.ReadLine();
                while(line!=null)
                {
                    string[] arr = line.Split('-');
                    dic.Add(arr[0].Trim(), arr[1].Trim());
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception ex)
            {
                
            }
            return dic;
        }
    }
}
