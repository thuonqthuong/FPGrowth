
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
            this.textBox3 = new System.Windows.Forms.TextBox();
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
            this.timluat.Controls.Add(this.textBox3);
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
            this.timluat.Size = new System.Drawing.Size(1788, 841);
            this.timluat.TabIndex = 0;
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
            this.label10.Location = new System.Drawing.Point(1346, 552);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(236, 24);
            this.label10.TabIndex = 38;
            this.label10.Text = "Các luật kết hợp mạnh";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(1299, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(297, 24);
            this.label9.TabIndex = 37;
            this.label9.Text = "Cách tính các luật kết hợp mạnh";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(797, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 24);
            this.label8.TabIndex = 36;
            this.label8.Text = " Bộ các tập mục thường xuyên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(738, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 24);
            this.label7.TabIndex = 35;
            this.label7.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(385, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 24);
            this.label6.TabIndex = 34;
            this.label6.Text = "%";
            // 
            // cachtinh
            // 
            this.cachtinh.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachtinh.Location = new System.Drawing.Point(1132, 180);
            this.cachtinh.Multiline = true;
            this.cachtinh.Name = "cachtinh";
            this.cachtinh.Size = new System.Drawing.Size(635, 353);
            this.cachtinh.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(1392, 69);
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
            this.numTrans.Location = new System.Drawing.Point(538, 75);
            this.numTrans.Name = "numTrans";
            this.numTrans.Size = new System.Drawing.Size(36, 32);
            this.numTrans.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(422, 80);
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
            this.t.Location = new System.Drawing.Point(236, 112);
            this.t.Multiline = true;
            this.t.Name = "t";
            this.t.Size = new System.Drawing.Size(339, 58);
            this.t.TabIndex = 29;
            // 
            // law
            // 
            this.law.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.law.Location = new System.Drawing.Point(1132, 579);
            this.law.Multiline = true;
            this.law.Name = "law";
            this.law.Size = new System.Drawing.Size(635, 250);
            this.law.TabIndex = 28;
            // 
            // results
            // 
            this.results.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.results.Location = new System.Drawing.Point(764, 180);
            this.results.Multiline = true;
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(354, 658);
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
            this.frequency.Size = new System.Drawing.Size(291, 658);
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
            this.data.Size = new System.Drawing.Size(419, 658);
            this.data.TabIndex = 25;
            // 
            // thucthithuattoan
            // 
            this.thucthithuattoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.thucthithuattoan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thucthithuattoan.ForeColor = System.Drawing.Color.Black;
            this.thucthithuattoan.Location = new System.Drawing.Point(864, 70);
            this.thucthithuattoan.Name = "thucthithuattoan";
            this.thucthithuattoan.Size = new System.Drawing.Size(158, 64);
            this.thucthithuattoan.TabIndex = 7;
            this.thucthithuattoan.Text = "THỰC THI";
            this.thucthithuattoan.UseVisualStyleBackColor = false;
            this.thucthithuattoan.Click += new System.EventHandler(this.thucthithuattoan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(580, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(450, 40);
            this.label4.TabIndex = 6;
            this.label4.Text = "THUẬT TOÁN FP-GROWTH";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(707, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(36, 32);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(348, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 32);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(591, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "3. minConf:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 79);
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
            this.comboBox1.Location = new System.Drawing.Point(88, 74);
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1065, 79);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(281, 23);
            this.textBox3.TabIndex = 40;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1788, 841);
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
        private System.Windows.Forms.TextBox textBox3;
    }
}

