
namespace FPGrowth
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timluat = new System.Windows.Forms.Panel();
            this.aprioriResults = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.time1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.thucthiapriori = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cachtinh = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numTrans = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.t = new System.Windows.Forms.TextBox();
            this.law = new System.Windows.Forms.TextBox();
            this.results = new System.Windows.Forms.TextBox();
            this.frequency = new System.Windows.Forms.DataGridView();
            this.data = new System.Windows.Forms.DataGridView();
            this.thucthithuattoan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.databasesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDataSet = new FPGrowth.masterDataSet();
            this.masterDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databasesTableAdapter = new FPGrowth.masterDataSetTableAdapters.databasesTableAdapter();
            this.tableAdapterManager = new FPGrowth.masterDataSetTableAdapters.TableAdapterManager();
            this.timluat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databasesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // timluat
            // 
            this.timluat.Controls.Add(this.aprioriResults);
            this.timluat.Controls.Add(this.label13);
            this.timluat.Controls.Add(this.time1);
            this.timluat.Controls.Add(this.label14);
            this.timluat.Controls.Add(this.thucthiapriori);
            this.timluat.Controls.Add(this.label12);
            this.timluat.Controls.Add(this.time);
            this.timluat.Controls.Add(this.label11);
            this.timluat.Controls.Add(this.button2);
            this.timluat.Controls.Add(this.label10);
            this.timluat.Controls.Add(this.label9);
            this.timluat.Controls.Add(this.label8);
            this.timluat.Controls.Add(this.label7);
            this.timluat.Controls.Add(this.label6);
            this.timluat.Controls.Add(this.cachtinh);
            this.timluat.Controls.Add(this.button1);
            this.timluat.Controls.Add(this.numTrans);
            this.timluat.Controls.Add(this.label5);
            this.timluat.Controls.Add(this.t);
            this.timluat.Controls.Add(this.law);
            this.timluat.Controls.Add(this.results);
            this.timluat.Controls.Add(this.frequency);
            this.timluat.Controls.Add(this.data);
            this.timluat.Controls.Add(this.thucthithuattoan);
            this.timluat.Controls.Add(this.label4);
            this.timluat.Controls.Add(this.textBox2);
            this.timluat.Controls.Add(this.textBox1);
            this.timluat.Controls.Add(this.label3);
            this.timluat.Controls.Add(this.label2);
            this.timluat.Controls.Add(this.label1);
            this.timluat.Controls.Add(this.comboBox1);
            this.timluat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timluat.Location = new System.Drawing.Point(0, 0);
            this.timluat.Name = "timluat";
            this.timluat.Size = new System.Drawing.Size(1940, 1062);
            this.timluat.TabIndex = 0;
            // 
            // aprioriResults
            // 
            this.aprioriResults.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aprioriResults.Location = new System.Drawing.Point(834, 699);
            this.aprioriResults.Multiline = true;
            this.aprioriResults.Name = "aprioriResults";
            this.aprioriResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.aprioriResults.Size = new System.Drawing.Size(422, 326);
            this.aprioriResults.TabIndex = 48;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1198, 659);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 17);
            this.label13.TabIndex = 47;
            this.label13.Text = "s";
            // 
            // time1
            // 
            this.time1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time1.Location = new System.Drawing.Point(1107, 652);
            this.time1.Name = "time1";
            this.time1.Size = new System.Drawing.Size(85, 28);
            this.time1.TabIndex = 46;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(880, 655);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(230, 21);
            this.label14.TabIndex = 45;
            this.label14.Text = "Thời gian thực thi Apriori:";
            // 
            // thucthiapriori
            // 
            this.thucthiapriori.BackColor = System.Drawing.Color.White;
            this.thucthiapriori.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thucthiapriori.ForeColor = System.Drawing.Color.Black;
            this.thucthiapriori.Location = new System.Drawing.Point(945, 563);
            this.thucthiapriori.Name = "thucthiapriori";
            this.thucthiapriori.Size = new System.Drawing.Size(197, 80);
            this.thucthiapriori.TabIndex = 43;
            this.thucthiapriori.Text = "THỰC THI THUẬT TOÁN APRIORI";
            this.thucthiapriori.UseVisualStyleBackColor = false;
            this.thucthiapriori.Click += new System.EventHandler(this.thucthiapriori_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1209, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 17);
            this.label12.TabIndex = 42;
            this.label12.Text = "s";
            // 
            // time
            // 
            this.time.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Location = new System.Drawing.Point(1123, 172);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(85, 28);
            this.time.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(865, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(262, 21);
            this.label11.TabIndex = 40;
            this.label11.Text = "Thời gian thực thi FP Growth:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(7, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 62);
            this.button2.TabIndex = 39;
            this.button2.Text = "Hướng dẫn";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(1477, 579);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(271, 24);
            this.label10.TabIndex = 38;
            this.label10.Text = "CÁC LUẬT KẾT HỢP MẠNH";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(1441, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(354, 24);
            this.label9.TabIndex = 37;
            this.label9.Text = "CÁCH TÍNH CÁC LUẬT KẾT HỢP MẠNH";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(890, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(325, 24);
            this.label8.TabIndex = 36;
            this.label8.Text = " BỘ CÁC TẬP MỤC THƯỜNG XUYÊN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(775, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 24);
            this.label7.TabIndex = 35;
            this.label7.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(391, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 24);
            this.label6.TabIndex = 34;
            this.label6.Text = "%";
            // 
            // cachtinh
            // 
            this.cachtinh.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachtinh.Location = new System.Drawing.Point(1289, 214);
            this.cachtinh.Multiline = true;
            this.cachtinh.Name = "cachtinh";
            this.cachtinh.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cachtinh.Size = new System.Drawing.Size(631, 334);
            this.cachtinh.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(1543, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 64);
            this.button1.TabIndex = 32;
            this.button1.Text = "TÌM LUẬT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numTrans
            // 
            this.numTrans.Enabled = false;
            this.numTrans.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTrans.ForeColor = System.Drawing.Color.Black;
            this.numTrans.Location = new System.Drawing.Point(537, 75);
            this.numTrans.Name = "numTrans";
            this.numTrans.Size = new System.Drawing.Size(88, 32);
            this.numTrans.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(421, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "Số giao dịch:";
            // 
            // t
            // 
            this.t.BackColor = System.Drawing.Color.Silver;
            this.t.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t.ForeColor = System.Drawing.Color.Black;
            this.t.Location = new System.Drawing.Point(242, 112);
            this.t.Multiline = true;
            this.t.Name = "t";
            this.t.Size = new System.Drawing.Size(383, 62);
            this.t.TabIndex = 29;
            // 
            // law
            // 
            this.law.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.law.Location = new System.Drawing.Point(1289, 616);
            this.law.Multiline = true;
            this.law.Name = "law";
            this.law.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.law.Size = new System.Drawing.Size(631, 406);
            this.law.TabIndex = 28;
            // 
            // results
            // 
            this.results.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.results.Location = new System.Drawing.Point(834, 206);
            this.results.Multiline = true;
            this.results.Name = "results";
            this.results.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.results.Size = new System.Drawing.Size(422, 334);
            this.results.TabIndex = 1;
            // 
            // frequency
            // 
            this.frequency.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.frequency.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.frequency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.frequency.Enabled = false;
            this.frequency.Location = new System.Drawing.Point(451, 180);
            this.frequency.Name = "frequency";
            this.frequency.RowHeadersWidth = 51;
            this.frequency.RowTemplate.Height = 24;
            this.frequency.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.frequency.Size = new System.Drawing.Size(307, 845);
            this.frequency.TabIndex = 27;
            // 
            // data
            // 
            this.data.AllowUserToAddRows = false;
            this.data.AllowUserToDeleteRows = false;
            this.data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.data.ColumnHeadersHeight = 29;
            this.data.Enabled = false;
            this.data.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.data.Location = new System.Drawing.Point(17, 180);
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.RowHeadersWidth = 51;
            this.data.RowTemplate.Height = 24;
            this.data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data.Size = new System.Drawing.Size(428, 845);
            this.data.TabIndex = 25;
            // 
            // thucthithuattoan
            // 
            this.thucthithuattoan.BackColor = System.Drawing.Color.White;
            this.thucthithuattoan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thucthithuattoan.ForeColor = System.Drawing.Color.Black;
            this.thucthithuattoan.Location = new System.Drawing.Point(937, 55);
            this.thucthithuattoan.Name = "thucthithuattoan";
            this.thucthithuattoan.Size = new System.Drawing.Size(213, 80);
            this.thucthithuattoan.TabIndex = 7;
            this.thucthithuattoan.Text = "THỰC THI THUẬT TOÁN FP-GROWTH";
            this.thucthithuattoan.UseVisualStyleBackColor = false;
            this.thucthithuattoan.Click += new System.EventHandler(this.thucthithuattoan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(680, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(450, 40);
            this.label4.TabIndex = 6;
            this.label4.Text = "THUẬT TOÁN FP-GROWTH";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(739, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(36, 32);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(354, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 32);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(623, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "3. minConf:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "2. minSup:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "1. CSDL:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.databasesBindingSource;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(94, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 32);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // databasesBindingSource
            // 
            this.databasesBindingSource.DataMember = "databases";
            this.databasesBindingSource.DataSource = this.masterDataSet;
            // 
            // masterDataSet
            // 
            this.masterDataSet.DataSetName = "masterDataSet";
            this.masterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // masterDataSetBindingSource
            // 
            this.masterDataSetBindingSource.DataSource = this.masterDataSet;
            this.masterDataSetBindingSource.Position = 0;
            // 
            // databasesTableAdapter
            // 
            this.databasesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = FPGrowth.masterDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1940, 1062);
            this.Controls.Add(this.timluat);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.timluat.ResumeLayout(false);
            this.timluat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databasesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel timluat;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource masterDataSetBindingSource;
        private masterDataSet masterDataSet;
        private System.Windows.Forms.BindingSource databasesBindingSource;
        private masterDataSetTableAdapters.databasesTableAdapter databasesTableAdapter;
        private masterDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox results;
        private System.Windows.Forms.DataGridView frequency;
        private System.Windows.Forms.DataGridView data;
        private System.Windows.Forms.Button thucthithuattoan;
        private System.Windows.Forms.TextBox t;
        private System.Windows.Forms.TextBox law;
        private System.Windows.Forms.TextBox numTrans;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox cachtinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox aprioriResults;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox time1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button thucthiapriori;
    }
}

