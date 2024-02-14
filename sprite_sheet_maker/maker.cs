using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace sprite_sheet_maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            FileInfo fi = new FileInfo(Application.StartupPath + "\\setup.ini");
            if (fi.Exists == false)
            {
                make_ini();
            }
            IniFile ini = new IniFile();
            ini.Load(Application.StartupPath + "\\setup.ini");
            textBox_col.Text = ini["Sprite Sheet Config"]["Colums"].ToString();
            textBox_dir.Text = ini["Sprite Sheet Config"]["Directory"].ToString();

            comboBox_type.SelectedItem = ini["Sprite Sheet Config"]["Type"].ToString();
            if (textBox_col.Text == "") textBox_col.Text = "10";
            if (textBox_dir.Text == "") textBox_dir.Text = Application.StartupPath;
            if (comboBox_type.SelectedIndex == -1) comboBox_type.SelectedIndex = 0;
        }
        private void save_ini()
        {
            IniFile ini = new IniFile();
            ini.Load(Application.StartupPath + "\\setup.ini");
            ini["Sprite Sheet Config"]["Colums"] = textBox_col.Text;
            ini["Sprite Sheet Config"]["Directory"] = textBox_dir.Text;
            ini["Sprite Sheet Config"]["Type"] = comboBox_type.Text;
            ini.Save(Application.StartupPath + "\\setup.ini");
        }
        private void make_ini()
        {
            List<string> outputList = new List<string>();
            System.IO.File.WriteAllLines(Application.StartupPath + "\\setup.ini", outputList, Encoding.UTF8);

        }

        private void button_dir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Reset();
            dialog.SelectedPath = textBox_dir.Text;



            dialog.ShowDialog();

            textBox_dir.Text = dialog.SelectedPath;    //선택한 다이얼로그 경로 저장
            save_ini();  //선택한경로 저장
        }





        private void button_make_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            // dialog.InitialDirectory = save_dir;
            dialog.DefaultExt = "png";
            dialog.Filter = "Png files(*.png)|*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //save_dir = dialog.FileName;
                //                textBox_output.Text = dialog.FileName;
                //  Debug.WriteLine("select : " + comboBox_type.SelectedIndex);
                Make_Images(textBox_dir.Text, dialog.FileName);
            }
            save_ini();  //선택한경로 저장
                         //Debug.WriteLine("Start");

        }
        public void Make_Images(String dir_path, String output_file)
        {
            String FolderName = dir_path;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FolderName);

            //파일처리
            String f_path = "", sub_dirname;
            int file_cnt = 0;
            int img_width = 0, img_height = 0, output_width = 0, output_height = 0, col_cnt = 0, row_cnt = 0;





            if (di.Exists)
            {
                foreach (System.IO.FileInfo File in di.GetFiles())
                {
                    f_path = File.FullName;
                    FileInfo file = new FileInfo(f_path);
                    if (file.Exists)
                    {
                        String f_ext = System.IO.Path.GetExtension(File.Name).Replace(".", "").ToLower();
                        if (f_ext == "png" || f_ext == "jpg" || f_ext == "gif" || f_ext == "bmp")
                        {
                            file_cnt++;
                            if (file_cnt == 1)
                            {
                                Bitmap first_img = LoadBitmap(f_path);
                                img_width = first_img.Width;
                                img_height = first_img.Height;
                            }
                        }

                    }
                }

            }
            if (file_cnt > 0)
            {

                if (comboBox_type.SelectedIndex == -1 || comboBox_type.SelectedIndex == 0)
                {
                    col_cnt = Int32.Parse(textBox_col.Text);
                    if (col_cnt > file_cnt) col_cnt = file_cnt;
                    if (col_cnt > 0) row_cnt = Convert.ToInt32(Math.Ceiling(((double)file_cnt / col_cnt)));
                }
                else
                {
                    row_cnt = Int32.Parse(textBox_col.Text);
                    if (row_cnt > file_cnt) row_cnt = file_cnt;
                    if (row_cnt > 0) col_cnt = Convert.ToInt32(Math.Ceiling(((double)file_cnt / row_cnt)));

                }

                output_width = img_width * col_cnt;
                //                double temp_num = ( (double) file_cnt / col_cnt);
                //                Debug.WriteLine(file_cnt +  " / "  + col_cnt  + " / "+ temp_num);





                output_height = img_height * row_cnt;
                int point_x = 0, point_y = 0, x_num, y_num;
                int now_cnt = 0;
                Debug.WriteLine(col_cnt.ToString() + "X" + row_cnt.ToString() + " / " + output_width.ToString() + "X" + output_height.ToString());
                if (output_width > 0 && output_height > 0)
                {
                    Bitmap output_img = new Bitmap(output_width, output_height);
                    foreach (System.IO.FileInfo File in di.GetFiles())
                    {
                        String f_ext = System.IO.Path.GetExtension(File.Name).Replace(".", "").ToLower();
                        f_path = File.FullName;
                        if (f_ext == "png" || f_ext == "jpg" || f_ext == "gif" || f_ext == "bmp")
                        {
                            Bitmap now_img = LoadBitmap(f_path);
                            now_cnt++;
                            x_num = Convert.ToInt32((double)((now_cnt - 1) % col_cnt));
                            y_num = Convert.ToInt32(System.Math.Truncate((double)((now_cnt - 1) / col_cnt)));
                            point_x = x_num * img_width;
                            point_y = y_num * img_height;
                            //Debug.WriteLine( "Now : "+ now_cnt.ToString() + " / x_num : " + x_num.ToString() + " / y_num : " + y_num.ToString() + " / X : " + point_x.ToString() + " / " + "Y : " + point_y.ToString());


                            using (Graphics g = Graphics.FromImage(output_img))
                            {
                                //                                g.FillRectangle(Brushes.Black, 0, 0, croppedBitmap.Width, croppedBitmap.Height);
                                g.DrawImage(now_img, point_x, point_y, img_width, img_height);
                            }

                        }

                    }
                    output_img.Save(output_file, System.Drawing.Imaging.ImageFormat.Png);
                    label_result.Text = "Image creation complete";
                }
                else
                {
                    label_result.Text = "Unable to create object file.";
                }

            }
            else
            {
                label_result.Text = "Image file not found";
            }
        }



        //이미지 파일 메모리에 적재(사용중인 파일 문제 해결)
        public static Bitmap LoadBitmap(string path)
        {
            if (System.IO.File.Exists(path))
            {
                // open file in read only mode
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                // get a binary reader for the file stream
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // copy the content of the file into a memory stream
                    var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                    // make a new Bitmap object the owner of the MemoryStream
                    return new Bitmap(memoryStream);
                }
            }
            else
            {
                //        MessageBox.Show("Error Loading File.", "Error!", MessageBoxButtons.OK);
                return null;
            }
        }



        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length < 1)
            {
                MessageBox.Show("Select a file or directory", "Error!", MessageBoxButtons.OK);
            }
            else 
            {
                DirectoryInfo di = new DirectoryInfo(files[0]);
                if (di.Exists) textBox_dir.Text = files[0];
                else
                {
                  FileInfo fi = new FileInfo(files[0]);
                  if (fi.Exists) textBox_dir.Text = Path.GetDirectoryName(files[0]);
                }

            }
        }

     
    }
}
