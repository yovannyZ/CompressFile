using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ionic.Zip;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string zipXml = ComprimirXML("E:\\archivo");
            byte[] zipXmlByte = FileToByteArray(zipXml);
            if (zipXmlByte == null)
            {
                MessageBox.Show("Archivo .xml no existe");

            }
            else
            {
                EliminarZip("E:\\archivo");
            }
           

        }

        public string ComprimirXML(string ruta)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(string.Format("{0}.xml", ruta));
                zip.Save(string.Format("{0}.zip", ruta));
                return string.Format("{0}.zip", ruta);
            }
        }
        public static byte[] FileToByteArray(string fileName)
        {
            byte[] fileData = null;
            bool existe = File.Exists(fileName);
            if (File.Exists(fileName))
            {
                using (FileStream fs = File.OpenRead(fileName))
                {
                    var binaryReader = new BinaryReader(fs);
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }

            return fileData;
        }

        public void EliminarZip(string ruta)
        {
            if (File.Exists(string.Format("{0}.zip", ruta)))
            {
                try
                {
                    File.Delete(string.Format("{0}.zip", ruta));
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }
    }
}
