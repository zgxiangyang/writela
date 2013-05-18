using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text;
namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("D:\\360data\\重要数据\\我的文档\\Visual Studio 2012\\Projects\\雅虎hack\\ConsoleApplication1 - 副本\\ConsoleApplication1\\at.txt",Encoding.Default);
            string s;
            while ((s = sr.ReadLine()) != null)
            {


                String URLString = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20google.search%20where%20q%20%3D%20%22"+s+"车%22&diagnostics=true&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
            XmlTextReader reader = new XmlTextReader(URLString);
                String outdir="out/"+s+".txt";
                FileStream fs = new FileStream(outdir, FileMode.Append);
                StreamWriter outxt = new StreamWriter(fs);
                    int i=0;
            while (reader.Read())
            {
                
                if (reader.Name == "content")
                {
                    //while (reader.MoveToNextAttribute())
                    //{ Console.Write(reader.Value); }
                    i++;
                    if (i % 2 == 1)
                    {
                        reader.Read();
                        outxt.Write("[" + (i/2+1) + "]");
                        outxt.Write(reader.Value);
                        outxt.WriteLine();
                    }
                //switch (reader.NodeType)
                //{
                //    case XmlNodeType.Element: // The node is an element.
                //        //Console.Write("<" + reader.Name);
                //        //Console.WriteLine(">");
                //        break;
                //    case XmlNodeType.Text: //Display the text in each element.
                //        Console.WriteLine(reader.Value);
                //        break;
                //    case XmlNodeType.EndElement: //Display the end of the element.
                //        //Console.Write("</" + reader.Name);
                //        //Console.WriteLine(">");
                //        break;
                } 
            }Console.Write(i);outxt.Flush();outxt.Close();fs.Close();
            }
        }
       
    }
}
