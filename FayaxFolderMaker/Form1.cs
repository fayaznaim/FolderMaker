using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
//https://github.com/fayaznaim/FayaxFolderMaker

namespace FayaxFolderMaker
{
    public partial class fayaxFolderMaker : Form
    {
        public fayaxFolderMaker()
        {
            InitializeComponent();
        }

        FolderBrowserDialog fbd = new FolderBrowserDialog();
        OpenFileDialog ofd = new OpenFileDialog();
  

        /// <summary>
        /// 
        /// todo upload the program to sourceforge.net
        /// todo  make all the simulate foldrers world. 
        /// todo open the dest folder when complete in the first tab
        /// 






        private void fayaxFolderMaker_Load(object sender, EventArgs e)
        {
            openFolderCbx.Checked = true;
        }
        private void browseBtn_Click(object sender, EventArgs e)
        {
           
            //////////////////////////////////////////////
            //
            //  If statement for folder browse
            //
            //////////////////////////////////////////////
            
          if(textBox1.TextLength == 0)
           {
               fbd.SelectedPath = "c:\\";
           }
           else
               {
                   fbd.SelectedPath = (textBox1.Text);
               }
               fbd.ShowDialog();
               textBox1.Text = fbd.SelectedPath;
           }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || startingNumberTbx.TextLength == 0 || numberOfFoldersTbx.TextLength == 0)
            {
                MessageBox.Show("A mandatory field is not specified.\n(Items in blue and with asterisk are mandatory.)", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            int temp;
            if (!int.TryParse(startingNumberTbx.Text, out temp))
            {
                MessageBox.Show("Starting number is not an integer.\nOnly integers are allowed in this field.", "Invalid Entry");
            }
            int temp2;
            if (!int.TryParse(numberOfFoldersTbx.Text, out temp2))
            {
                MessageBox.Show("'Total Folders' is not an integer.\nOnly integers are allowed in this field.", "Invalid Entry");
            }
            else if (textBox1.TextLength != 0)
            {
                richTextBox1.Clear();
                long startingNumber = Convert.ToInt64(startingNumberTbx.Text);
                long numberOfFolders = Convert.ToInt64(numberOfFoldersTbx.Text);
                var parentFolder = textBox1.Text;
                System.IO.Directory.CreateDirectory(parentFolder);
                Directory.SetCurrentDirectory(parentFolder);
                statusLbl.Text = "Making folders...";
                System.Threading.Thread.Sleep(150);
                for (long i = startingNumber; i < (startingNumber+numberOfFolders); ++i)
                {
                    System.IO.Directory.CreateDirectory(i + delimTbx.Text + staticTbx.Text + delim2Tbx.Text+ "\n");
                    richTextBox1.AppendText(i + delimTbx.Text + staticTbx.Text + delim2Tbx.Text + "\n");
                    richTextBox1.Focus();
                    richTextBox1.Select(richTextBox1.Text.Length, 0);  //This puts the cursor at the end
                }
                statusLbl.Text = numberOfFolders + " folders created in "+textBox1.Text;
                Directory.SetCurrentDirectory(@"c:\");      //changing the focus so the created folders can be deleted
                if (openFolderCbx.Checked == true)
                {
                    System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                }
             }           
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void simulateBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || startingNumberTbx.TextLength == 0 || numberOfFoldersTbx.TextLength == 0)
            {
                MessageBox.Show("A mandatory field is not specified.\n(Items in blue and with asterisk are mandatory.)", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            int temp;
            if (!int.TryParse(startingNumberTbx.Text, out temp))
            {
                MessageBox.Show("Starting number is not an integer.\nOnly integers are allowed in this field.", "Invalid Entry");
            }
            int temp2;
            if (!int.TryParse(numberOfFoldersTbx.Text, out temp2))
            {
                MessageBox.Show("'Total Folders' is not an integer.\nOnly integers are allowed in this field.", "Invalid Entry");
                
            }

            else if (textBox1.TextLength != 0)
            {
                richTextBox1.Clear();
                statusLbl.Text = "(Simulation Only) Creating folders...";
                System.Threading.Thread.Sleep(50);
                long startingNumber = Convert.ToInt64(startingNumberTbx.Text);
                long numberOfFolders = Convert.ToInt64(numberOfFoldersTbx.Text);


                for (long i = startingNumber ; i < (numberOfFolders+startingNumber); ++i)
                {
                  richTextBox1.AppendText(i + delimTbx.Text + staticTbx.Text + delim2Tbx.Text+ "\n");
                  richTextBox1.Focus();
                  richTextBox1.Select(richTextBox1.Text.Length, 0);
                }
                statusLbl.Text = numberOfFolders + " folders WILL be created at:\n" + textBox1.Text + " \nif you click 'Make Folders'.";
             }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            staticTbx.Clear();
            richTextBox1.Clear();
            delimTbx.Clear();
            delim2Tbx.Clear();
            statusLbl.Text = "Status";
            startingNumberTbx.Clear();
            numberOfFoldersTbx.Clear();
        }
        private void startingNumberTbx_TextChanged(object sender, EventArgs e)
        {
            //int temp;
            //if (!int.TryParse(startingNumberTbx.Text, out temp))
            //{
            //    MessageBox.Show("Starting number is not an integer.\n Only intergers allowed in this field", "Invalid Entry!");
            //}
        }
        private void staticTbx_TextChanged(object sender, EventArgs e)
        {

        }
        private void numberOfFoldersTbx_TextChanged(object sender, EventArgs e)
        {

        }
        private void delimTbx_TextChanged(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void delim2Tbx_TextChanged(object sender, EventArgs e)
        {

        }
        private void statusLbl_Click(object sender, EventArgs e)
        {

        }
        private void openFolderCbx_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void createDateFolders_Click(object sender, EventArgs e)
        {
            // dow = day of week
            // moy = month of year
            string[] dowFull = new string[7] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] dowBrev = new string[7] {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            string[] moyFull = new string[12] {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] moyBrev = new string[12] {"Jan", "Feb","Mar", "Apr","May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
            string[] moyNums = new string[12] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };

            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("A mandatory field is not specified.\n(Items in blue and with asterisk are mandatory.)", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBox1.TextLength != 0)
            {
                var parentFolder = textBox1.Text;
                System.IO.Directory.CreateDirectory(parentFolder);
                Directory.SetCurrentDirectory(parentFolder);
                statusLbl2.Text = "The following folders created:";

                if (dowFullRbtn.Checked == true && dowBriefCbx.Checked != true)
                {
                    richTextBox2.Clear();
                    for (int i = 0; i <= 6; i++)
                    {
                        System.IO.Directory.CreateDirectory(dowFull[i]);
                        richTextBox2.AppendText(dowFull[i] + "\n");
                    }
                    if (openFolderCbx.Checked == true)
                    {
                        System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                    }
                    Directory.SetCurrentDirectory(@"c:\");      //changing the focus so the created folders can be deleted
                }
                else if (dowFullRbtn.Checked == true && dowBriefCbx.Checked == true)
                {
                    richTextBox2.Clear();
                    for (int i = 0; i <= 6; i++)
                    {
                        System.IO.Directory.CreateDirectory(dowBrev[i]);
                        richTextBox2.AppendText(dowBrev[i] + "\n");
                    }
                    if (openFolderCbx.Checked == true)
                    {
                        System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                    }
                    Directory.SetCurrentDirectory(@"c:\");      //changing the focus so the created folders can be deleted
                }
                // Months Folders
                else if (moyFullBtn.Checked == true && moyBriefCbx.Checked != true)
                {
                    richTextBox2.Clear();
                        for (int i = 0; i <= 11; i++)
                        {
                            if (add2DigitNumsChbx.Checked == false)
                            {
                                System.IO.Directory.CreateDirectory(moyFull[i]);
                                richTextBox2.AppendText(moyFull[i] + yearTbx.Text + "\n");
                            }
                            else if (add2DigitNumsChbx.Checked == true)
                            {
                                System.IO.Directory.CreateDirectory(moyNums[i] + delim3Tbx.Text + moyFull[i] + yearTbx.Text);
                                richTextBox2.AppendText(moyNums[i] + delim3Tbx.Text + moyFull[i] + yearTbx.Text + "\n");
                            }
                        }
                        if (openFolderCbx.Checked == true)
                        {
                            System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                        }
                        Directory.SetCurrentDirectory(@"c:\");      //changing the focus so the created folders can be deleted
                }
                else if (moyFullBtn.Checked == true && moyBriefCbx.Checked == true)
                {
                    richTextBox2.Clear();
                        for (int i = 0; i <= 11; i++)
                        {
                            if (add2DigitNumsChbx.Checked == false)
                            {
                                System.IO.Directory.CreateDirectory(moyBrev[i]);
                                richTextBox2.AppendText(moyBrev[i] + yearTbx.Text + "\n");
                            }
                            else if (add2DigitNumsChbx.Checked == true)
                            {
                                System.IO.Directory.CreateDirectory(moyNums[i] + delim3Tbx.Text + moyBrev[i] + yearTbx.Text);
                                richTextBox2.AppendText(moyNums[i] + delim3Tbx.Text + moyBrev[i] + yearTbx.Text + "\n");
                            }
                        }
                        if (openFolderCbx.Checked == true && richTextBox2.Text != "")
                        {
                            System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                        }
                        Directory.SetCurrentDirectory(@"c:\");      //changing the focus so the created folders can be deleted
                }
            }
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (dowFullRbtn.Checked == true)
            {
                moyBriefCbx.Checked = false;
                add2DigitNumsChbx.Checked = false;
                delim3Tbx.Enabled = false;
                yearTbx.Enabled = false;
                moyBriefCbx.Enabled = false;
                add2DigitNumsChbx.Enabled = false;
                dowBriefCbx.Enabled = true;
            }
        }
        private void dowBriefCbx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void moyFullBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (moyFullBtn.Checked == true)
            {
                dowBriefCbx.Checked = false;
                add2DigitNumsChbx.Enabled = true;
                moyBriefCbx.Enabled = true;
                dowBriefCbx.Enabled = false;
                delim3Tbx.Enabled = true;
                yearTbx.Enabled = true;
            }
        }
        private void moyBriefCbx_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void add2DigitNumsChbx_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void delim3Tbx_TextChanged(object sender, EventArgs e)
        {

        }
        private void conactLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:admin@fe9.org");
        }
        private void yearTbx_TextChanged(object sender, EventArgs e)
        {

        }
        private void customCreateBtn_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            if (textBox1.Text == "")
            {
                MessageBox.Show("A mandatory field is not specified.\n(Items in blue and with asterisk are mandatory.)", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBox1.Text != "")
            {
            var parentFolder = textBox1.Text;
            System.IO.Directory.CreateDirectory(parentFolder);
            Directory.SetCurrentDirectory(@parentFolder);
            
            string cc2 = createcustomTbx2.Text;
            cc2 = cc2.Trim();
            if (cc2 != "")
            {
                System.IO.Directory.CreateDirectory(cc2);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc2 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc3 = createcustomTbx3.Text;
            cc3 = cc3.Trim();
            if (cc3 != "")
            {
                 System.IO.Directory.CreateDirectory(cc3);
                 richTextBox3.Focus();
                 richTextBox3.AppendText(cc3 + "\n");
                 richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc4 = createcustomTbx4.Text;
            cc4 = cc4.Trim();
            if (cc4 != "")
            {
                System.IO.Directory.CreateDirectory(cc4);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc4 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc5 = createcustomTbx5.Text;
            cc5 = cc5.Trim();
            if (cc5 != "")
            {
                System.IO.Directory.CreateDirectory(cc5);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc5 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc6 = createcustomTbx6.Text;
            cc6 = cc6.Trim();
            if (cc6 != "")
            {
                System.IO.Directory.CreateDirectory(cc6);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc6 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }

            string cc7 = createcustomTbx7.Text;
            cc7 = cc7.Trim();
            if (cc7 != "")
            {
                System.IO.Directory.CreateDirectory(cc7);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc7 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc8 = createcustomTbx8.Text;
            cc8 = cc8.Trim();
            if (cc8 != "")
            {
                System.IO.Directory.CreateDirectory(cc8);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc8 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc9 = createcustomTbx9.Text;
            cc9 = cc9.Trim();
            if (cc9 != "")
            {
                System.IO.Directory.CreateDirectory(cc9);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc9 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc10 = createcustomTbx10.Text;
            cc10 = cc10.Trim();
            if (cc10 != "")
            {
                System.IO.Directory.CreateDirectory(cc10);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc10 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc11 = createcustomTbx11.Text;
            cc11 = cc11.Trim();
            if (cc11 != "")
            {
                System.IO.Directory.CreateDirectory(cc11);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc11 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc12 = createcustomTbx12.Text;
            cc12 = cc12.Trim();
            if (cc12 != "")
            {
                System.IO.Directory.CreateDirectory(cc12);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc12 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc20 = createcustomTbx20.Text;
            cc20 = cc20.Trim();
            if (cc20 != "")
            {
                System.IO.Directory.CreateDirectory(cc20);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc20 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc21 = createcustomTbx21.Text;
            cc21 = cc21.Trim();
            if (cc21 != "")
            {
                System.IO.Directory.CreateDirectory(cc21);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc21 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc22 = createcustomTbx22.Text;
            cc22 = cc22.Trim();
            if (cc22 != "")
            {
                System.IO.Directory.CreateDirectory(cc22);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc22 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc23 = createcustomTbx23.Text;
            cc23 = cc23.Trim();
            if (cc23 != "")
            {
                System.IO.Directory.CreateDirectory(cc23);
                richTextBox3.Focus();
                richTextBox3.AppendText(cc23 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc24 = createcustomTbx24.Text;
            cc24 = cc24.Trim();
            if (cc24 != "")
            {
                System.IO.Directory.CreateDirectory(cc24);
                richTextBox3.AppendText(cc24 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc25 = createcustomTbx25.Text;
            cc25 = cc25.Trim();
            if (cc25 != "")
            {
                System.IO.Directory.CreateDirectory(cc25);
                richTextBox3.AppendText(cc25 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc26 = createcustomTbx26.Text;
            cc26 = cc26.Trim();
            if (cc26 != "")
            {
                System.IO.Directory.CreateDirectory(cc26);
                richTextBox3.AppendText(cc26 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc27 = createcustomTbx27.Text;
            cc27 = cc27.Trim();
            if (cc27 != "")
            {
                System.IO.Directory.CreateDirectory(cc27);
                richTextBox3.AppendText(cc27 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc28 = createcustomTbx28.Text;
            cc28 = cc28.Trim();
            if (cc28 != "")
            {
                System.IO.Directory.CreateDirectory(cc28);
                richTextBox3.AppendText(cc28 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc29 = createcustomTbx29.Text;
            cc29 = cc29.Trim();
            if (cc29 != "")
            {
                System.IO.Directory.CreateDirectory(cc29);
                richTextBox3.AppendText(cc29 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc30 = createcustomTbx30.Text;
            cc30 = cc30.Trim();
            if (cc30 != "")
            {
                System.IO.Directory.CreateDirectory(cc30);
                richTextBox3.AppendText(cc30 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            string cc31 = createcustomTbx31.Text;
            cc31 = cc31.Trim();
            if (cc31 != "")
            {
                System.IO.Directory.CreateDirectory(cc31);
                richTextBox3.AppendText(cc31 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }

            string cc32 = createcustomTbx32.Text;
            cc32 = cc32.Trim();
            if (cc32 != "")
            {
                System.IO.Directory.CreateDirectory(cc32);
                richTextBox3.AppendText(cc32 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }

            string cc33 = createcustomTbx33.Text;
            cc33 = cc33.Trim();
            if (cc33 != "")
            {
                System.IO.Directory.CreateDirectory(cc33);
                richTextBox3.AppendText(cc33 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }

            string cc34 = createcustomTbx34.Text;
            cc34 = cc34.Trim();
            if (cc34 != "")
            {
                System.IO.Directory.CreateDirectory(cc34);
                richTextBox3.AppendText(cc34 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }

            string cc35 = createcustomTbx35.Text;
            cc35 = cc35.Trim();
            if (cc35 != "")
            {
                System.IO.Directory.CreateDirectory(cc35);
                richTextBox3.AppendText(cc35 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }

            string cc36 = createcustomTbx36.Text;
            cc36 = cc36.Trim();
            if (cc36 != "")
            {
                System.IO.Directory.CreateDirectory(cc36);
                richTextBox3.AppendText(cc36 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }

            string cc37 = createcustomTbx37.Text;
            cc37 = cc37.Trim();
            if (cc37 != "")
            {
                System.IO.Directory.CreateDirectory(cc37);
                richTextBox3.AppendText(cc37 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }

            string cc38 = createcustomTbx38.Text;
            cc38 = cc38.Trim();
            if (cc38 != "")
            {
                System.IO.Directory.CreateDirectory(cc38);
                richTextBox3.AppendText(cc38 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }

            string cc39 = createcustomTbx39.Text;
            cc39 = cc39.Trim();
            if (cc39 != "")
            {
                System.IO.Directory.CreateDirectory(cc39);
                richTextBox3.AppendText(cc39 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }

            string cc40 = createcustomTbx40.Text;
            cc40 = cc40.Trim();
            if (cc40 != "")
            {
                System.IO.Directory.CreateDirectory(cc40);
                richTextBox3.AppendText(cc40 + "\n");
                richTextBox3.Select(richTextBox3.Text.Length, 0);
            }
            statusLbl3.Text = ("The following folders created.");
            Directory.SetCurrentDirectory(@"c:\"); //changing the focus so the created folders can be deleted for testing
            if (openFolderCbx.Checked == true)
            {
                System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
            }
            }
        }
        private void createcustomTbx2_TextChanged(object sender, EventArgs e)
        {

        }
        private void createcustomTbx3_TextChanged(object sender, EventArgs e)
        {

        }
        private void createcustomTbx4_TextChanged(object sender, EventArgs e)
        {

        }
        private void createcustomTbx5_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx6_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx7_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx8_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx9_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx10_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx11_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx12_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx20_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx21_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx22_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx23_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx24_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx25_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx26_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx27_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx28_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx29_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx30_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx31_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx32_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx33_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx34_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx35_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx36_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx37_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx38_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx39_TextChanged(object sender, EventArgs e)
        {

        }

        private void createcustomTbx40_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void customClearBtn_Click(object sender, EventArgs e)
        {
            createcustomTbx2.Clear();
            createcustomTbx3.Clear();
            createcustomTbx4.Clear();
            createcustomTbx5.Clear();
            createcustomTbx6.Clear();
            createcustomTbx7.Clear();
            createcustomTbx8.Clear();
            createcustomTbx9.Clear();
            createcustomTbx10.Clear();
            createcustomTbx11.Clear();
            createcustomTbx12.Clear();
            createcustomTbx20.Clear();
            createcustomTbx21.Clear();
            createcustomTbx22.Clear();
            createcustomTbx23.Clear();
            createcustomTbx24.Clear();
            createcustomTbx25.Clear();
            createcustomTbx26.Clear();
            createcustomTbx27.Clear();
            createcustomTbx28.Clear();
            createcustomTbx29.Clear();
            createcustomTbx30.Clear();
            createcustomTbx31.Clear();
            createcustomTbx32.Clear();
            createcustomTbx33.Clear();
            createcustomTbx34.Clear();
            createcustomTbx35.Clear();
            createcustomTbx36.Clear();
            createcustomTbx37.Clear();
            createcustomTbx38.Clear();
            createcustomTbx39.Clear();
            createcustomTbx40.Clear();
            richTextBox3.Clear();
            statusLbl3.Text = "Status";
        }

        private void calClearBtn_Click(object sender, EventArgs e)
        {
            dowBriefCbx.Checked = false;
            moyBriefCbx.Checked = false;
            add2DigitNumsChbx.Checked = false;
            delim3Tbx.Clear();
            yearTbx.Clear();
            richTextBox2.Clear();
            dowFullRbtn.Checked = false;  
            moyFullBtn.Checked = false;
            statusLbl2.Text = "Status";
        }
        private void yearLbl_Click(object sender, EventArgs e)
        {

        }
        private void txtfileTbx_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
   //         ofd.ShowDialog();
            ofd.Title = "Choose Text File...";
            ofd.DefaultExt = "txt";
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.ReadOnlyChecked = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtfileTbx.Text = ofd.FileName;
            } 
        }

        private void groupBox3_Enter_1(object sender, EventArgs e)
        {

        }
        private void testFileClearBtn_Click(object sender, EventArgs e)
        {
            txtfileTbx.Clear();
            textBox2.Clear();
            richTextBox4.Clear();
        }

        private void createFromTextFileBtn_Click(object sender, EventArgs e)
        {
            string textFileLines;
            if (txtfileTbx.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("A mandatory field is not specified.\n(Items in blue and with asterisk are mandatory.)", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtfileTbx.Text != "" && textBox1.Text != "")
            {
                richTextBox4.Clear();
                System.IO.StreamReader textFile = new System.IO.StreamReader(txtfileTbx.Text);
                System.IO.Directory.CreateDirectory(textBox1.Text);
                Directory.SetCurrentDirectory(textBox1.Text);

                while ((textFileLines = textFile.ReadLine()) != null)
                {
                    if (textFileLines == "")
                    {
                        richTextBox4.AppendText("<EOF or blank line reached.>");
                        textFile.Close();
                        textFile.Dispose();
                        break;
                    }
                    System.IO.Directory.CreateDirectory(textFileLines);
                    richTextBox4.AppendText(textFileLines + "\n");
                    richTextBox4.Focus();
                    richTextBox4.Select(richTextBox4.Text.Length, 0);
                    statusLbl4.Text = "Creating folders...";
                }
                statusLbl4.Text = "Following folders created.";
                Directory.SetCurrentDirectory(@"c:\");
                if (openFolderCbx.Checked == true)
                {
                    System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string textFileLines;
            if (txtfileTbx.Text == "")
            {
                MessageBox.Show("A mandatory field is not specified.\n(Items in blue and with asterisk are mandatory.)", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (txtfileTbx.Text != "")
            {
                System.IO.StreamReader textFile = new System.IO.StreamReader(txtfileTbx.Text);
                textBox2.Clear();
                while ((textFileLines = textFile.ReadLine()) != null)
                {
                    textBox2.AppendText(textFileLines + "\n");
                    if (textFileLines == "")
                    {
                        textBox2.AppendText("<EOF or blank line reached.>");
                        break;
                    }
                }

            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void tabLeft_Click(object sender, EventArgs e)
        {
            int currentTab;
            currentTab = tabControl1.SelectedIndex;
            if  (currentTab > 0)
            {
                tabControl1.SelectedIndex = currentTab - 1;
            }
        }
        private void tabRight_Click(object sender, EventArgs e)
        {
            int currentTab;
            currentTab = tabControl1.SelectedIndex;
            tabControl1.SelectedIndex = currentTab+1;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string[] usStates = new string[50] {"Alabama", "Alaska", "Arizona",	"Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida" ,"Georgia" ,"Hawaii" ,"Idaho" ,"Illinois" ,"Indiana" ,"Iowa" ,"Kansas" ,"Kentucky" ,"Louisiana","Maine","Maryland",	"Massachusetts" ,"Michigan" ,"Minnesota" ,"Mississippi" ,	"Missouri" ,"Montana" ,	"Nebraska" ,"Nevada" ,"New Hampshire" ,"New Jersey" ,"New Mexico" ,"New York" ,"North Carolina" ,"North Dakota" ,"Ohio" ,"Oklahoma" ,	"Oregon" ,"Pennsylvania" ,"Rhode Island" ,"South Carolina" ,"South Dakota" ,"Tennessee" ,"Texas" ,"Utah" ,"Vermont" ,"Virginia" ,"Washington" ,"West Virginia" ,"Wisconsin" ,"Wyoming"};
           
            string[] animals = new string[52] {"alligator","ant", "bear", "bee", "bird", "camel", "cat", "cheetah", "chicken", "chimpanzee", "cow", "crocodile", "deer", "dog", "dolphin", "duck", "eagle", "elephant", "fish", "fly", "fox", "frog", "giraffe", "goat", "goldfish", "hamster", "hippopotamus", "horse", "kangaroo", "kitten", "lion", "lobster", "monkey", "octopus", "owl", "panda", "pig", "puppy", "rabbit", "rat", "scorpion", "seal", "shark", "sheep", "snail", "snake", "spider", "squirrel", "tiger", "turtle", "wolf", "zebra"};

            string[] countries = new string[233] { "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia-Herzegovina", "Botswana", "Bouvet Island", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Cocos (Keeling) Islands", "Colombia", "Comoros", "Congo, Democratic Republic of the (Zaire)", "Congo, Republic of", "Cook Islands", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe (French)", "Guam (USA)", "Guatemala", "Guinea", "Guinea Bissau", "Guyana", "Haiti", "Holy See", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Ivory Coast (Cote D`Ivoire)", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique (French)", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia (French)", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "North Korea", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Pitcairn Island", "Poland", "Polynesia (French)", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russia", "Rwanda", "Saint Helena", "Saint Kitts and Nevis", "Saint Lucia", "Saint Pierre and Miquelon", "Saint Vincent and Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Georgia and South Sandwich Islands", "South Korea", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Svalbard and Jan Mayen Islands", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste (East Timor)", "Togo", "Tokelau", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam", "Virgin Islands", "Wallis and Futuna Islands", "Yemen", "Zambia", "Zimbabwe" };

            string[] elements = new string[109] { "1 - Hydrogen(H)" ,"2 - Helium(He)","3 - Lithium(Li)", "4 - Beryllium(Be)", "5 - Boron(B)", "6 - Carbon(C)", "7 - Nitrogen(N)", "8 - Oxygen(O)", "9 - Fluorine(F)", "10 - Neon(Ne)", "11 - Sodium(Na)", "12 - Magnesium(Mg)", "13 - Aluminum(Al)", "14 - Silicon(Si)", "15 - Phosphorus(P)", "16 - Sulfur(S)", "17 - Chlorine(Cl)", "18 - Argon(Ar)", "19 - Potassium(K)", "20 - Calcium(Ca)", "21 - Scandium(Sc)", "22 - Titanium(Ti)", "23 - Vanadium(V)", "24 - Chromium(Cr)", "25 - Manganese(Mn)", "26 - Iron(Fe)", "27 - Cobalt(Co)", "28 - Nickel(Ni)", "29 - Copper(Cu)", "30 - Zinc(Zn)", "31 - Gallium(Ga)", "32 - Germanium(Ge)", "33 - Arsenic(As)", "34 - Selenium(Se)", "35 - Bromine(Br)", "36 - Krypton(Kr)", "37 - Rubidium(Rb)", "38 - Strontium(Sr)", "39 - Yttrium(Y)", "40 - Zirconium(Zr)", "41 - Niobium(Nb)", "42 - Molybdenum(Mo)", "43 - Technetium(Tc)", "44 - Ruthenium(Ru)", "45 - Rhodium(Rh)", "46 - Palladium(Pd)", "47 - Silver(Ag)", "48 - Cadmium(Cd)", "49 - Indium(In)", "50 - Tin(Sn)", "51 - Antimony(Sb)", "52 - Tellurium(Te)", "53 - Iodine(I)", "54 - Xenon(Xe)", "55 - Cesium(Cs)", "56 - Barium(Ba)", "57 - Lanthanum(La)", "58 - Cerium(Ce)", "59 - Praseodymium(Pr)", "60 - Neodymium(Nd)", "61 - Promethium(Pm)", "62 - Samarium(Sm)", "63 - Europium(Eu)", "64 - Gadolinium(Gd)", "65 - Terbium(Tb)", "66 - Dysprosium(Dy)", "67 - Holmium(Ho)", "68 - Erbium(Er)", "69 - Thulium(Tm)", "70 - Ytterbium(Yb)", "71 - Lutetium(Lu)", "72 - Hafnium(Hf)", "73 - Tantalum(Ta)", "74 - Tungsten(W)", "75 - Rhenium(Re)", "76 - Osmium(Os)", "77 - Iridium(Ir)", "78 - Platinum(Pt)", "79 - Gold(Au)", "80 - Mercury(Hg)", "81 - Thallium(Tl)", "82 - Lead(Pb)", "83 - Bismuth(Bi)", "84 - Polonium(Po)", "85 - Astatine(At)", "86 - Radon(Rn)", "87 - Francium(Fr)", "88 - Radium(Ra)", "89 - Actinium(Ac)", "90 - Thorium(Th)", "91 - Protactinium(Pa)", "92 - Uranium(U)", "93 - Neptunium(Np)", "94 - Plutonium(Pu)", "95 - Americium(Am)", "96 - Curium(Cm)", "97 - Berkelium(Bk)", "98 - Californium(Cf)", "99 - Einsteinium(Es)", "100 - Fermium(Fm)", "101 - Mendelevium(Md)", "102 - Nobelium(No)", "103 - Lawrencium(Lr)", "104 - Rutherfordium(Rf)", "105 - Dubnium(Db)", "106 - Seaborgium(Sg)", "107 - Bohrium(Bh)", "108 - Hassium(Hs)", "109 - Meitnerium(Mt)"};


            if (textBox1.Text == "")
            {
                MessageBox.Show("A mandatory field is not specified.\n(Items in blue and with asterisk are mandatory.)", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            ////////////////////////////////////////////////////
            //
            //    Creating us states folders
            //
            /////////////////////////////////////////////////////

            if (textBox1.Text != "" && usStatesRbtn.Checked == true)
            {
                richTextBox5.Clear();
                System.IO.Directory.CreateDirectory(textBox1.Text);
                Directory.SetCurrentDirectory(textBox1.Text);
                for (int i = 0; i <=49; i++)
                {
                    System.IO.Directory.CreateDirectory(usStates[i]);
                    statusLbl5.Text = "Creating "+ usStates[i]+ " ";
                    richTextBox5.AppendText(usStates[i]+"\n");
                    richTextBox5.Focus();
                    richTextBox5.Select(richTextBox5.Text.Length, 0);  //This puts the cursor at the end
                }
                statusLbl5.Text = "50 folders created.";
                Directory.SetCurrentDirectory(@"c:\");
                if (openFolderCbx.Checked == true)
                {
                    System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                }
            }
            ////////////////////////////////////////////////////
            //
            //    Creating animals folders
            //
            /////////////////////////////////////////////////////

            if (textBox1.Text != "" && animalsRbtn.Checked == true)
            {
                richTextBox5.Clear();
                System.IO.Directory.CreateDirectory(textBox1.Text);
                Directory.SetCurrentDirectory(textBox1.Text);
                for (int i = 0; i <= 51; i++)
                {
                    System.IO.Directory.CreateDirectory(animals[i]);
                    statusLbl5.Text = "Creating " + animals[i] + " ";
                    richTextBox5.AppendText(animals[i] + "\n");
                    richTextBox5.Focus();
                    richTextBox5.Select(richTextBox5.Text.Length, 0);  //This puts the cursor at the end
                }
                statusLbl5.Text = "Created 52 folders.";
                Directory.SetCurrentDirectory(@"c:\");
                if (openFolderCbx.Checked == true)
                {
                    System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                }
            }
            ////////////////////////////////////////////////////
            //
            //    Creating countries folders
            //
            /////////////////////////////////////////////////////
            if (textBox1.Text != "" && countriesRbtn.Checked == true)
            {
                richTextBox5.Clear();
                System.IO.Directory.CreateDirectory(textBox1.Text);
                Directory.SetCurrentDirectory(textBox1.Text);
                for (int i = 0; i <= 232; i++)
                {
                    System.IO.Directory.CreateDirectory(countries[i]);
                    statusLbl5.Text = "Creating " + countries[i] + " ";
                    richTextBox5.AppendText(countries[i] + "\n");
                    richTextBox5.Focus();
                    richTextBox5.Select(richTextBox5.Text.Length, 0);  //This puts the cursor at the end
                }
                statusLbl5.Text = "Created 233 folders.";
                Directory.SetCurrentDirectory(@"c:\");
                if (openFolderCbx.Checked == true)
                {
                    System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                }
            }
            //////////////////////////////////
            //
            //Creating elements folders
            //
            /////////////////////////////////

            if (textBox1.Text != "" && elementsRbtn.Checked == true)
            {
                richTextBox5.Clear();
                System.IO.Directory.CreateDirectory(textBox1.Text);
                Directory.SetCurrentDirectory(textBox1.Text);
                for (int i = 0; i <=108; i++)
                {
                    System.IO.Directory.CreateDirectory(elements[i]);
                    statusLbl5.Text = "Creating " + elements[i] + " ";
                    richTextBox5.AppendText(elements[i]+"\n");
                    richTextBox5.Focus();
                    richTextBox5.Select(richTextBox5.Text.Length, 0);  //This puts the cursor at the end
                }
                statusLbl5.Text = "Created 109 folders.";
                Directory.SetCurrentDirectory(@"c:\");
                if (openFolderCbx.Checked == true)
                {
                    System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                }
            }

        }

        private void usStatesRbtn_CheckedChanged(object sender, EventArgs e)
        {
            statusLbl5.Text = "Status";
            richTextBox5.Clear();
        }
        private void animalsRbtn_CheckedChanged(object sender, EventArgs e)
        {
            statusLbl5.Text = "Status";
            richTextBox5.Clear();
        }
        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            usStatesRbtn.Checked = false;
            animalsRbtn.Checked = false;
            countriesRbtn.Checked = false;
            elementsRbtn.Checked = false;
            richTextBox5.Clear();
        }
        private void countriesRbtn_CheckedChanged(object sender, EventArgs e)
        {
            statusLbl5.Text = "Status";
            richTextBox5.Clear();
        }

        private void statusLbl2_Click(object sender, EventArgs e)
        {

        }
        private void elementsRbtn_CheckedChanged(object sender, EventArgs e)
        {
            statusLbl5.Text = "Status";
            richTextBox5.Clear();
        }
        private void statusLbl5_Click(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {
            txtfileTbx.Clear();
            textBox2.Clear();
            richTextBox4.Clear();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.fe9.org");
        }

        private void statusLbl4_Click(object sender, EventArgs e)
        {

        }
        private void startingNumberTbx_MouseClick(object sender, MouseEventArgs e)
        {
            startingNumberTbx.SelectAll();
        }
        private void numberOfFoldersTbx_TextChanged_1(object sender, EventArgs e)
        {
            //int temp;
            //if (!int.TryParse(numberOfFoldersTbx.Text, out temp))
            //{
            //    MessageBox.Show("Starting number is not an integer");
            //}
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("no code yet");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("no code yet");
        }


        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("no code yet");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("no code yet");
        }

        #region //simulate button for list to folders. 
        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox7.Clear();  // clear the result rtb

            if (textBox1.TextLength == 0 && richTextBox6.TextLength == 0)
            {
                MessageBox.Show("Two mandatory field(s) missing.\n\nPlease provide the following:\n\n1. Destination location for folders\n2. Name(s) of the folder(s) to create.", "CANNOT COMPLETE TASK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBox1.TextLength == 0 && richTextBox6.TextLength != 0)
            {
                MessageBox.Show("Mandatory field(s) missing.\n\nWhere do you want to create the folders? Please specify...", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBox1.TextLength !=0 && richTextBox6.TextLength == 0)
            {
                MessageBox.Show("Mandatory field(s) missing.\n\nNames of folders? Please specify...", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
            else if (textBox1.TextLength != 0 && richTextBox6.TextLength != 0)
            {
                foreach (string rtb6line in richTextBox6.Lines)
                {
                    if(rtb6line.Length > 0 )
                    {
                        richTextBox7.AppendText(rtb6line + Environment.NewLine);
                    }
                    
                }
            }
            

        }
        #endregion

        #region // create butto for list to folders
        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox7.Clear();
            if (textBox1.TextLength == 0 && richTextBox6.TextLength == 0)
            {
                MessageBox.Show("Two mandatory field(s) missing.\n\nPlease provide the following:\n\n1. Destination location for folders\n2. Name(s) of the folder(s) to create.", "CANNOT COMPLETE TASK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBox1.TextLength == 0 && richTextBox6.TextLength != 0)
            {
                MessageBox.Show("Mandatory field(s) missing.\n\nWhere do you want to create the folders? Please specify...", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBox1.TextLength != 0 && richTextBox6.TextLength == 0)
            {
                MessageBox.Show("Mandatory field(s) missing.\n\nNames of folders? Please specify...", "Cannot complete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBox1.TextLength != 0 && richTextBox6.TextLength != 0)
            {
                foreach (string rtb6line in richTextBox6.Lines)
                {
                    if (rtb6line.Length > 0)
                    {
                        System.IO.Directory.CreateDirectory(textBox1.Text + "\\"+ rtb6line );
                        richTextBox7.AppendText(rtb6line + Environment.NewLine);
                    }
                }
                if (openFolderCbx.Checked == true)
                {
                    System.Diagnostics.Process.Start(textBox1.Text);  // Opens the folder where folders were created
                }
            }
        }
        #endregion

        private void button13_Click(object sender, EventArgs e)
        {
            richTextBox6.Clear();
        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {
            //label17.Text = richTextBox6.Lines.Count().ToString();
            int rtb6lines = richTextBox6.Lines.Count();
                foreach (string o in richTextBox6.Lines)
                {
                    if (o.Length == 0)
                    {
                        rtb6lines =  rtb6lines - 1;
                    }
                }
            label17.Text = rtb6lines.ToString();
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {
            int rtb7lines = richTextBox7.Lines.Count();
            foreach (string o in richTextBox7.Lines)
            {
                if (o.Length == 0)
                {
                    rtb7lines = rtb7lines - 1;
                }
            }
            label18.Text = rtb7lines.ToString();
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
    }
}
