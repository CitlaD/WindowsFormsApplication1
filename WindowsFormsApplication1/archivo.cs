using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class archivos
    {
        TextWriter archivo;
        String ruta, rutalee;

        public void crear_archivo(TextBox nombre_archivo, RichTextBox texto_del_archivo, ref String mensaje_ventana)
        {
            if (nombre_archivo.Text != "")
            {
                FolderBrowserDialog fod = new FolderBrowserDialog();
                fod.Description = "Seleccione la ruta donde desea guardar el documento";
                fod.RootFolder = Environment.SpecialFolder.Desktop;

                if (fod.ShowDialog() == DialogResult.OK)
                {
                    ruta = fod.SelectedPath;
                    String mensaje;
                    mensaje = texto_del_archivo.Text;
                    archivo = new StreamWriter(ruta + "\\" + nombre_archivo.Text + ".txt");
                    archivo.Write(mensaje);
                    archivo.Close();
                    mensaje_ventana = "Correcto";
                }
            }

            else mensaje_ventana = "no has escrito el nombre del archivo no podemos continuar porfavor escribe algo";
        }

        public void leer_archivo(TextBox textBox2, RichTextBox richTextBox2, ref String mensaje)
        {
            richTextBox2.Text = "";

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Archivos txt(*.txt)|*.txt";
            open.Title = "Archivos .txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                rutalee = open.FileName;
                textBox2.Text = rutalee;
                StreamReader file = new StreamReader(rutalee);
                while (file.Peek() != -1)
                {
                    richTextBox2.Text += file.ReadLine() + "\n";
                }
                file.Close();
                mensaje = "Archivo cargado correctamente";
            }
            open.Dispose();
        }


        public void editar(RichTextBox richTextBox2, ref String ventana_mensaje)
        {
            // textBox2.Text = rutalee;
            String texto_delarchivo;
            texto_delarchivo = richTextBox2.Text;
            archivo = new StreamWriter(rutalee);
            archivo.Write(texto_delarchivo);
            archivo.Close();
            ventana_mensaje = "Edicion correcta";
        }



        public void carga_documento(RichTextBox richTextBox1)
        {
            richTextBox1.Text = "";
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Archivos txt(*.txt)|*.txt";
            open.Title = "Archivos .txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                rutalee = open.FileName;
                StreamReader file = new StreamReader(rutalee);
                while (file.Peek() != -1)
                {
                    richTextBox1.Text += file.ReadLine() + "\n";
                }
                file.Close();
            }
            open.Dispose();
        }

        public void carga_documento2(RichTextBox richTextBox2)
        {
            richTextBox2.Text = "";
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Archivos txt(*.txt)|*.txt";
            open.Title = "Archivos .txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                rutalee = open.FileName;
                StreamReader file = new StreamReader(rutalee);
                while (file.Peek() != -1)
                {
                    richTextBox2.Text += file.ReadLine() + "\n";
                }
                file.Close();
            }
            open.Dispose();
        }

        public void crear_documento_nuevo(TextBox textBox1, RichTextBox richTextBox1, RichTextBox richTextBox2, ref String ventana_mensaje)
        {
            if (textBox1.Text != "" && richTextBox1.Text != "")
            {
                FolderBrowserDialog fod = new FolderBrowserDialog();
                fod.Description = "Seleccione la ruta donde desea guardar el documento";
                fod.RootFolder = Environment.SpecialFolder.Desktop;
                if (fod.ShowDialog() == DialogResult.OK)
                {
                    ruta = fod.SelectedPath;
                    String mensaje;
                    mensaje = richTextBox1.Text + "\n" + richTextBox2.Text;
                    archivo = new StreamWriter(ruta + "\\" + textBox1.Text + ".txt");
                    archivo.Write(mensaje);
                    archivo.Close();
                    ventana_mensaje = "Corrector ";
                }
            }
            else ventana_mensaje = "no has escrito el nombre del archivo no podemos continuar porfavor escribe algo";
        }
    }
}
