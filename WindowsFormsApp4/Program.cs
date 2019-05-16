using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
        class NewProgram
        { 

            RightTriangle[] rTriangles;
            Triangle[] triangles;

        Random rand = new Random();

        public void taskTriangle(TextBox field, int N)
        {
            field.Text = "Все треугольники:\r\n";


            int maxS = 0;

            
                triangles = new Triangle[N];
                for (int i = 0; i < N; i++)
                {
                    float s1 = (float)rand.Next(15) + 1;
                    float s2 = (float)rand.Next(15) + 1;
                    float s3 = (float)rand.Next(15) + 1;

                    while (!Triangle.exists(s1, s2, s3))
                    {
                        s1 = (float)rand.Next(15) + 1;
                        s2 = (float)rand.Next(15) + 1;
                        s3 = (float)rand.Next(15) + 1;
                    }

                    triangles[i] = new Triangle(s1, s2, s3);

                    if (triangles[i].getSquare() > triangles[maxS].getSquare()) maxS = i;

                    field.Text += "Треугольник №" + (i + 1) + "\r\n" + triangles[i].getInfo();
                }
            
            field.Text += "\r\nТреугольник с максимальной площадью:\r\n";
            field.Text += "Треугольник №" + (maxS + 1) + "\r\n" + triangles[maxS].getInfo();
        }

        public void taskRTriangle(TextBox field, int M)
        {
            int minH = 0;

            field.Text = "Все прямоугольные треугольники:\r\n";

           
                rTriangles = new RightTriangle[M];
                for (int i = 0; i < M; i++)
                {
                    float s1 = (float)rand.Next(15) + 1;
                    float s2 = (float)rand.Next(15) + 1;

                    rTriangles[i] = new RightTriangle(s1, s2);

                    if (rTriangles[i].getHypotenuse() < rTriangles[minH].getHypotenuse())
                            minH = i;

                    field.Text += "Треугольник №" + (i + 1) + "\r\n" + rTriangles[i].getInfo();
                }
            
            field.Text += "\r\nТреугольник с минимальной гипотенузой:\r\n";
            field.Text += "Треугольник №" + (minH + 1) + "\r\n" + rTriangles[minH].getInfo();
        }

        public void SaveFile(String save, int N)
        {
            FileStream stream = new FileStream(save,FileMode.OpenOrCreate,FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(stream);
            for(int i = 0; i < N; i++)
            //int i = 0;
            //while(triangles[i] != null)
            {
               writer.Write((double)triangles[i].a);
               writer.Write((double)triangles[i].b);
               writer.Write((double)triangles[i].c);
               // i++;
            }
            writer.Close();
            stream.Close();
        }

        public void LoadFile(String load,int N, TextBox text)
        {
            
            FileStream fileN = new FileStream(load, FileMode.Open, FileAccess.Read);
            BinaryReader readerN = new BinaryReader(fileN);
            
            N = 0;
            /*while (reader.PeekChar() != -1)
            {
               //N++;
            }*/
            while (fileN.CanRead && readerN.BaseStream.Position != readerN.BaseStream.Length)
            {

                float a = (float)readerN.ReadDouble();
                float b = (float)readerN.ReadDouble();
                float c = (float)readerN.ReadDouble();
                N++;
            }
            readerN.Close();
            fileN.Close();

            Triangle[] temp = new Triangle[N];
            int i = 0;

            FileStream file = new FileStream(load, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);

            text.Text = "Все треугольники" + "\r\n";
            int maxS = 0;
            while (file.CanRead && i < N)
            //while (file.CanRead && reader.BaseStream.Position != reader.BaseStream.Length)
            {
                
                float a = (float)reader.ReadDouble();
                float b = (float)reader.ReadDouble();
                float c = (float)reader.ReadDouble();

                /*text.Text = "Треугольник №" + i + "\r\n";
                text.Text = "a=" + a + "\r\n";
                text.Text = "b=" + b + "\r\n";
                text.Text = "c=" + c + "\r\n";*/
                temp[i] = new Triangle(a, b, c);
                text.Text += "Треугольник №" + (i + 1) + "\r\n" + temp[i].getInfo();
     
                if (temp[i].getSquare() > temp[maxS].getSquare()) maxS = i;
                
                i++;
            }
            text.Text += "\r\nТреугольник с максимальной площадью:\r\n";
            text.Text += "Треугольник №" + (maxS + 1) + "\r\n" + temp[maxS].getInfo();
            reader.Close();
            file.Close();
        }
        
        public void SaveFileRT(String SaveRT, int N)
        {
            FileStream streamRT = new FileStream(SaveRT, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter RTwriter = new BinaryWriter(streamRT);
            for (int i = 0; i < N; i++)
            {
                RTwriter.Write((double)rTriangles[i].a);
                RTwriter.Write((double)rTriangles[i].b);
                RTwriter.Write((double)rTriangles[i].c);
            }
            RTwriter.Close();
            streamRT.Close();
        }

        public void LoadFileRT(String LoadRT, int N, TextBox RTtext)
        {
            

            FileStream fileN2 = new FileStream(LoadRT,FileMode.Open,FileAccess.Read);
            BinaryReader N2reader = new BinaryReader(fileN2);

            N = 0;

            while (fileN2.CanRead && N2reader.BaseStream.Position != N2reader.BaseStream.Length)
            {
            
                float s1 = (float)N2reader.ReadDouble();
                float s2 = (float)N2reader.ReadDouble();
                float s3 = (float)N2reader.ReadDouble();

                N++;
            }
            N2reader.Close();
            fileN2.Close();
            RightTriangle[] RTtemp = new RightTriangle[N];

            int i = 0;

            FileStream fileRT = new FileStream(LoadRT, FileMode.Open, FileAccess.Read);
            BinaryReader RTreader = new BinaryReader(fileRT);
            RTtext.Text = "Все треугольники" + "\r\n";
            int minH = 0;
            while (fileRT.CanRead && RTreader.BaseStream.Position != RTreader.BaseStream.Length)
            {

                float s1 = (float)RTreader.ReadDouble();
                float s2 = (float)RTreader.ReadDouble();
                float s3 = (float)RTreader.ReadDouble();


                RTtemp[i] = new RightTriangle(s1, s2);
                RTtext.Text += "Треугольник №" + (i + 1) + "\r\n" + RTtemp[i].getInfo();

                if (RTtemp[i].getHypotenuse() < RTtemp[minH].getHypotenuse())
                    minH = i;
                i++;
            }

            RTtext.Text += "\r\nТреугольник с минимальной гипотенузой:\r\n";
            RTtext.Text += "Треугольник №" + (minH + 1) + "\r\n" + RTtemp[minH].getInfo();

            RTreader.Close();
            fileRT.Close();
        }








        /*public void saveFile(String path, int choVpisat)
        {
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fileStream);

            Triangle[] arr = choVpisat == 1 ? triangles : rTriangles;

            writer.Write(choVpisat);
            writer.Write(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                writer.Write((double)arr[i].a);
                writer.Write((double)arr[i].b);
                writer.Write((double)arr[i].c);
            }

            writer.Close();
            fileStream.Close();
        }*/

       /* public void loadFile(String path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fileStream);

            int choProchest = reader.ReadInt32();
            int length = reader.ReadInt32();

            Triangle[] temp = new Triangle[length];

            int i = 0;
            while (fileStream.CanRead && i < length)
            {
                float a = (float)reader.ReadDouble();
                float b = (float)reader.ReadDouble();
                float c = (float)reader.ReadDouble();
                temp[i] = new Triangle(a, b, c);
                i++;
            }

                if (choProchest == 1) triangles = temp;
                else if (choProchest == 2)
                {
                    RightTriangle[] temp2 = new RightTriangle[length];

                    for (int j = 0; j < length; j++)
                    {
                        temp2[j] = new RightTriangle(temp[i].a, temp[i].b);
                    }

                    rTriangles = temp2;
                }
            }*/
        }
 }
