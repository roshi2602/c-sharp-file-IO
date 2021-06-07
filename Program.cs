using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


//it is used to perform read and write operations
//import using system.io

namespace file_IO
{
  
    class Program
    {
        //------------------------------------------
        //BinaryReader(in main downwards )

        //create two static methods to read and write 
        static void WriteFiles()
        {
            //make binary writer first
            using (BinaryWriter wri = new BinaryWriter(File.Open("e:\\f.txt", FileMode.Create)))
            {
                wri.Write(10);
                wri.Write("this is my file");
            }
        }


        static void ReadFiles()
        {
            //make binary writer first
            using (BinaryReader rea = new BinaryReader(File.Open("e:\\f.txt", FileMode.Open)))
            {
                Console.WriteLine(rea.ReadDouble());
                //    Console.WriteLine(rea.ReadString());



            }
        }


        //----------------------------------------------
        static void Main()
        {
            //first topic starting from here.... 
            //create file stream
            FileStream f = new FileStream("e:\\fileioexample1.txt", FileMode.OpenOrCreate);

            //now write byte into stream
            f.WriteByte(30);

            //close stream now
            f.Close();

            //on running file got created into e drive, check that
            //---------------------------------------------------
            /*
                      //create file stream
                      FileStream ff = new FileStream("e:\\fileioexample2.txt", FileMode.OpenOrCreate);

                      //for multiple files use for loop
                      for(int i=30; i<=50; i++)
                      {
                         f.WriteByte((byte)i);        //writebyte
                      }

                      //close stream now
                      ff.Close();
                */
            //---------------------------------------------------
            //    Reading all bytes from file
            /*
            FileStream f3 = new FileStream("e:\\b.txt", FileMode.OpenOrCreate);
            //use while loop for reading 
            int j = 0;
            while((j=f3.ReadByte()) != 1)
            {
                Console.Write((char)j);
            }
            f.Close();
            //before running , open the file from e drive
            */
            //---------------------------------------------------
            
            //stream writers
            //used to write characters to stream
            //includes write(), writeln() methods to write data in file
            FileStream f4 = new FileStream("e:\\b.txt", FileMode.Create);  //for creating file
            StreamWriter s = new StreamWriter(f4);

            s.WriteLine("hello roshi");
            s.Close();
            f.Close();
            Console.WriteLine("file created");
            //run the console and check b file in e drive, will find hello roshi written there

            //---------------------------------------------------

            //stream reader
            //is used to read string from stream
            //methods used- Read() and ReadLine()

            FileStream f5 = new FileStream("e:\\b.txt", FileMode.OpenOrCreate);
            StreamReader s2 = new StreamReader(f5);

            string st = s2.ReadLine();
            Console.WriteLine(st);
            s2.Close();
            f5.Close();
            //on running console, it will open file b

            //---------------------------------------------------
            //textwriter
            //it is used to write text
            using (TextWriter wr = File.CreateText("e:\\f.txt"))
            {
                wr.WriteLine("c# is important");

            }
            Console.WriteLine("worked");
            //run console and then open f file in e drive. we will find that text is written there

            //---------------------------------------------------
            //textReader
            //it represents that reader can be used to read texts
            using (TextReader tr = File.OpenText("e:\\f.txt"))
            {
                Console.WriteLine(tr.ReadToEnd());
            }

            //---------------------------------------------------
            //BinaryWriter
            //used to write binary information into stream
            string fn = "e:\\f.txt";
            using (BinaryWriter w = new BinaryWriter(File.Open(fn, FileMode.Create)))
            {
                w.Write(10);
                w.Write("heeel");
            }
            Console.WriteLine("it works!");

            //on running console, the words written in the file used above had changed now 


            //---------------------------------------------------

            //BinaryReader
            //is used to read binary information
            //see line 15 to 42
            ReadFiles();
            WriteFiles();
            Console.ReadLine();

            //on running output is-
            /*
            file created
    hello roshi
    worked
    c# is important

    it works!
    2.77580888216477E+180

    */
            //---------------------------------------------------

            //StringWriter
            //is used to write and deal with string data
            //stringWriter()- to create new instance of stringwriter class
            //stringWriter(String Builder)-to create new instance of stringwriter class that writes to specified StringBuilder
            string text = "hey there, roshi this side";

            //now create stringBuileder instance
            StringBuilder sb = new StringBuilder();

            //passing srting builder instance in string writer
            StringWriter sw = new StringWriter(sb);

            //Flush()- clears data and caused any extra data to be written to the file
            sw.WriteLine(text);
            sw.Flush();

            //now close stringWriter
            sw.Close();


            //now create StringReader instance and pass stringBuilder in it
            //ToString()-returns string containing characters of current stringWriter
            StringReader r = new StringReader(sb.ToString());

            //reading data using while loop
            //Peek()-The Peek method returns an integer value in order to determine whether the end of the file, or another error has occurred.
            //This allows a user to first check if the returned value is -1 before casting it to a Char type


            while (r.Peek() > -1)
            {
                Console.WriteLine(r.ReadLine());
            }
            Console.ReadLine();

            //on running console it gives-hey there roshi this side
            //---------------------------------------------------

            //StringReader
            //is used to read data writeen by string writer class
            //it provides constructors to perform read operations

            //constructor- StringReader(string)


            StringWriter sws = new StringWriter();
            sws.WriteLine("write data in it");
            sws.Close();

            //creating stringReader instance and pass stringWriter
            StringReader sr = new StringReader(sws.ToString());

            //read data using while loop
            while (sr.Peek() > -1)
            {
                Console.WriteLine(sr.ReadLine());
            }
            Console.ReadLine();

            //on running console it gives- write data in it
            //---------------------------------------------------

            //FileInfo
            //it provides properties and methods to create, delete files
            //constructor used- FileInfo(String)- for new instance of FileInfo class

            //use try catch here
            try
            {
                //first specify file location
                string lo = "E:\\g.txt";      //creating new file in g , in E drive

                //create fileIfor instance and pass file location in that
                FileInfo fi = new FileInfo(lo);

                //create empty file
                fi.Create();
                Console.Write("we created empty file");


            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }

            //run this then the g file will get empty now which had some string written earlier
            //---------------------------------------------------
           
        }
    }
}
