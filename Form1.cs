using System.IO;
using System.Text;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (this.WindowState != FormWindowState.Minimized)
            {
                
                e.Cancel = true;
                //ʹ�ر�ʱ���������½���С��Ч��
                this.WindowState = FormWindowState.Minimized;
                this.notifyIcon1.Visible = true;
                this.Hide();
                return;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            StreamReader sr = new StreamReader("C:\\Users\\wangt\\Desktop\\cpp_learn\\WinFormsApp1\\mappingconfig.txt");

            string line = sr.ReadLine();

            while (line != null)
            {
                this.listBox1.Items.Add(line);
                line = sr.ReadLine();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str_pre = textBox1.Text;
            String str_post = textBox2.Text + "+" + textBox3.Text;
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("���벻��Ϊ��", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                int[] a = new int[listBox1.Items.Count];
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    //TODO
                    // convert to txt

                    //a[i] = Convert.ToInt32(listBox1.Items[i]);


                }

                listBox1.Items.Add(textBox1.Text + "+" + textBox2.Text + "+" + textBox3.Text);
                //string jsonString = JsonSerializer.Serialize(textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text);
                //File.WriteAllText("C:\\Users\\wangt\\Desktop\\cpp_learn\\WinFormsApp1\\mappingconfig.txt", jsonString);

            }

            StreamWriter sw_config = new StreamWriter("C:\\Users\\wangt\\Desktop\\cpp_learn\\WinFormsApp1\\mappingconfig.txt", false, Encoding.ASCII);


            foreach (string item in this.listBox1.Items)
            {
                sw_config.Write(item);
                sw_config.Write('\n');

                //MessageBox.Show(item);
            }
            sw_config.Close();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }

            else if (this.Visible && e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Minimized;
                this.notifyIcon1.Visible = true;
                this.Hide();
            }
            else if (!this.Visible && e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.Close();
            this.Dispose();
            System.Environment.Exit(0);
        }
    }
}
