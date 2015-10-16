namespace NPOI
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_filePath = new System.Windows.Forms.TextBox();
            this.btn_selctFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_dataType = new System.Windows.Forms.TextBox();
            this.txt_default = new System.Windows.Forms.TextBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.txt_fieldName = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txt_sql = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_startRow = new System.Windows.Forms.TextBox();
            this.txt_endRow = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.txt_tableName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件地址：";
            // 
            // txt_filePath
            // 
            this.txt_filePath.Location = new System.Drawing.Point(92, 20);
            this.txt_filePath.Name = "txt_filePath";
            this.txt_filePath.Size = new System.Drawing.Size(284, 21);
            this.txt_filePath.TabIndex = 1;
            // 
            // btn_selctFile
            // 
            this.btn_selctFile.Location = new System.Drawing.Point(382, 18);
            this.btn_selctFile.Name = "btn_selctFile";
            this.btn_selctFile.Size = new System.Drawing.Size(57, 23);
            this.btn_selctFile.TabIndex = 2;
            this.btn_selctFile.Text = "选择";
            this.btn_selctFile.UseVisualStyleBackColor = true;
            this.btn_selctFile.Click += new System.EventHandler(this.btn_selctFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Field Name：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data Type：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Default：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_remark);
            this.groupBox1.Controls.Add(this.txt_dataType);
            this.groupBox1.Controls.Add(this.txt_default);
            this.groupBox1.Controls.Add(this.txt_tableName);
            this.groupBox1.Controls.Add(this.txt_description);
            this.groupBox1.Controls.Add(this.txt_fieldName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(23, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 142);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性所在列";
            // 
            // txt_dataType
            // 
            this.txt_dataType.Location = new System.Drawing.Point(297, 34);
            this.txt_dataType.Name = "txt_dataType";
            this.txt_dataType.Size = new System.Drawing.Size(100, 21);
            this.txt_dataType.TabIndex = 1;
            // 
            // txt_default
            // 
            this.txt_default.Location = new System.Drawing.Point(102, 72);
            this.txt_default.Name = "txt_default";
            this.txt_default.Size = new System.Drawing.Size(100, 21);
            this.txt_default.TabIndex = 1;
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(297, 72);
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(100, 21);
            this.txt_description.TabIndex = 1;
            // 
            // txt_fieldName
            // 
            this.txt_fieldName.Location = new System.Drawing.Point(102, 34);
            this.txt_fieldName.Name = "txt_fieldName";
            this.txt_fieldName.Size = new System.Drawing.Size(100, 21);
            this.txt_fieldName.TabIndex = 1;
            // 
            // txt_sql
            // 
            this.txt_sql.Location = new System.Drawing.Point(22, 271);
            this.txt_sql.Multiline = true;
            this.txt_sql.Name = "txt_sql";
            this.txt_sql.Size = new System.Drawing.Size(427, 274);
            this.txt_sql.TabIndex = 5;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(49, 242);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 6;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(149, 242);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(75, 23);
            this.btn_Generate.TabIndex = 6;
            this.btn_Generate.Text = "生成";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "-";
            // 
            // txt_startRow
            // 
            this.txt_startRow.Location = new System.Drawing.Point(101, 213);
            this.txt_startRow.Name = "txt_startRow";
            this.txt_startRow.Size = new System.Drawing.Size(100, 21);
            this.txt_startRow.TabIndex = 1;
            // 
            // txt_endRow
            // 
            this.txt_endRow.Location = new System.Drawing.Point(232, 213);
            this.txt_endRow.Name = "txt_endRow";
            this.txt_endRow.Size = new System.Drawing.Size(100, 21);
            this.txt_endRow.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Rows：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.xls;*.txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "TableName：";
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(99, 109);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(100, 21);
            this.txt_remark.TabIndex = 1;
            // 
            // txt_tableName
            // 
            this.txt_tableName.Location = new System.Drawing.Point(297, 109);
            this.txt_tableName.Name = "txt_tableName";
            this.txt_tableName.Size = new System.Drawing.Size(100, 21);
            this.txt_tableName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "Remark：";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 562);
            this.Controls.Add(this.btn_Generate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.txt_sql);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_endRow);
            this.Controls.Add(this.txt_startRow);
            this.Controls.Add(this.btn_selctFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_filePath);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_filePath;
        private System.Windows.Forms.Button btn_selctFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_dataType;
        private System.Windows.Forms.TextBox txt_default;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.TextBox txt_fieldName;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox txt_sql;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_startRow;
        private System.Windows.Forms.TextBox txt_endRow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_tableName;
        private System.Windows.Forms.Label label9;
    }
}

