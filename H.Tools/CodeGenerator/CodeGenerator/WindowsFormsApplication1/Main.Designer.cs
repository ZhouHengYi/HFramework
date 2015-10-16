namespace WindowsFormsApplication1
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_Referensh = new System.Windows.Forms.ToolStripButton();
            this.tsb_Logoff = new System.Windows.Forms.ToolStripButton();
            this.Lbx_TableList = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Rtb_ModelCode = new System.Windows.Forms.RichTextBox();
            this.Btn_CreateModelAll = new System.Windows.Forms.Button();
            this.Btn_Model_CreateSel = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Rtb_XmlCode = new System.Windows.Forms.RichTextBox();
            this.Btn_CreateXmlAll = new System.Windows.Forms.Button();
            this.Btn_xml_CreateSel = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.Rtb_InterfaceCode = new System.Windows.Forms.RichTextBox();
            this.Btn_CreateInterfaceAll = new System.Windows.Forms.Button();
            this.Btn_Interface_CreateSel = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Rtb_DACode = new System.Windows.Forms.RichTextBox();
            this.Btn_CreateDAAll = new System.Windows.Forms.Button();
            this.Btn_DA_CreateSel = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.Btn_CreateRestAll = new System.Windows.Forms.Button();
            this.Btn_Rest_CreateSel = new System.Windows.Forms.Button();
            this.Rtb_RestCode = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Btn_CreateFacadeAll = new System.Windows.Forms.Button();
            this.Btn_Facade_CreateSel = new System.Windows.Forms.Button();
            this.Rtb_FacadeCode = new System.Windows.Forms.RichTextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.lit_website = new System.Windows.Forms.RichTextBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.btn_designer2 = new System.Windows.Forms.Button();
            this.btn_aspxcs2 = new System.Windows.Forms.Button();
            this.btn_pageSave = new System.Windows.Forms.Button();
            this.btn_designer = new System.Windows.Forms.Button();
            this.btn_aspx2 = new System.Windows.Forms.Button();
            this.btn_aspxcs = new System.Windows.Forms.Button();
            this.btn_aspx = new System.Windows.Forms.Button();
            this.lit_Aspx = new System.Windows.Forms.RichTextBox();
            this.folder_saveModel = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_saveUrl = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_saveUrl = new System.Windows.Forms.TextBox();
            this.btn_batchGenerate = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Referensh,
            this.tsb_Logoff});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(825, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_Referensh
            // 
            this.tsb_Referensh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_Referensh.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Referensh.Image")));
            this.tsb_Referensh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Referensh.Name = "tsb_Referensh";
            this.tsb_Referensh.Size = new System.Drawing.Size(44, 22);
            this.tsb_Referensh.Text = "刷  新";
            this.tsb_Referensh.Click += new System.EventHandler(this.tsb_Referensh_Click);
            // 
            // tsb_Logoff
            // 
            this.tsb_Logoff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_Logoff.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Logoff.Image")));
            this.tsb_Logoff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Logoff.Name = "tsb_Logoff";
            this.tsb_Logoff.Size = new System.Drawing.Size(44, 22);
            this.tsb_Logoff.Text = "注  销";
            this.tsb_Logoff.Click += new System.EventHandler(this.tsb_Logoff_Click);
            // 
            // Lbx_TableList
            // 
            this.Lbx_TableList.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lbx_TableList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Lbx_TableList.FormattingEnabled = true;
            this.Lbx_TableList.ItemHeight = 12;
            this.Lbx_TableList.Location = new System.Drawing.Point(9, 23);
            this.Lbx_TableList.Margin = new System.Windows.Forms.Padding(0);
            this.Lbx_TableList.Name = "Lbx_TableList";
            this.Lbx_TableList.Size = new System.Drawing.Size(193, 432);
            this.Lbx_TableList.TabIndex = 18;
            this.Lbx_TableList.SelectedIndexChanged += new System.EventHandler(this.Lbx_TableList_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Location = new System.Drawing.Point(205, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 382);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Rtb_ModelCode);
            this.tabPage3.Controls.Add(this.Btn_CreateModelAll);
            this.tabPage3.Controls.Add(this.Btn_Model_CreateSel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(603, 356);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Entity";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Rtb_ModelCode
            // 
            this.Rtb_ModelCode.Location = new System.Drawing.Point(0, 0);
            this.Rtb_ModelCode.Name = "Rtb_ModelCode";
            this.Rtb_ModelCode.Size = new System.Drawing.Size(603, 331);
            this.Rtb_ModelCode.TabIndex = 1;
            this.Rtb_ModelCode.Text = "";
            // 
            // Btn_CreateModelAll
            // 
            this.Btn_CreateModelAll.Location = new System.Drawing.Point(84, 332);
            this.Btn_CreateModelAll.Name = "Btn_CreateModelAll";
            this.Btn_CreateModelAll.Size = new System.Drawing.Size(75, 23);
            this.Btn_CreateModelAll.TabIndex = 0;
            this.Btn_CreateModelAll.Text = "生成全部";
            this.Btn_CreateModelAll.UseVisualStyleBackColor = true;
            this.Btn_CreateModelAll.Click += new System.EventHandler(this.Btn_CreateModelAll_Click);
            // 
            // Btn_Model_CreateSel
            // 
            this.Btn_Model_CreateSel.Location = new System.Drawing.Point(3, 332);
            this.Btn_Model_CreateSel.Name = "Btn_Model_CreateSel";
            this.Btn_Model_CreateSel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Model_CreateSel.TabIndex = 0;
            this.Btn_Model_CreateSel.Text = "生成当前";
            this.Btn_Model_CreateSel.UseVisualStyleBackColor = true;
            this.Btn_Model_CreateSel.Click += new System.EventHandler(this.Btn_Model_CreateSel_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Rtb_XmlCode);
            this.tabPage1.Controls.Add(this.Btn_CreateXmlAll);
            this.tabPage1.Controls.Add(this.Btn_xml_CreateSel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(603, 356);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "DbCommand";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Rtb_XmlCode
            // 
            this.Rtb_XmlCode.Location = new System.Drawing.Point(0, 1);
            this.Rtb_XmlCode.Name = "Rtb_XmlCode";
            this.Rtb_XmlCode.Size = new System.Drawing.Size(603, 331);
            this.Rtb_XmlCode.TabIndex = 7;
            this.Rtb_XmlCode.Text = "";
            // 
            // Btn_CreateXmlAll
            // 
            this.Btn_CreateXmlAll.Location = new System.Drawing.Point(84, 332);
            this.Btn_CreateXmlAll.Name = "Btn_CreateXmlAll";
            this.Btn_CreateXmlAll.Size = new System.Drawing.Size(75, 23);
            this.Btn_CreateXmlAll.TabIndex = 5;
            this.Btn_CreateXmlAll.Text = "生成全部";
            this.Btn_CreateXmlAll.UseVisualStyleBackColor = true;
            this.Btn_CreateXmlAll.Click += new System.EventHandler(this.Btn_CreateXmlAll_Click);
            // 
            // Btn_xml_CreateSel
            // 
            this.Btn_xml_CreateSel.Location = new System.Drawing.Point(3, 332);
            this.Btn_xml_CreateSel.Name = "Btn_xml_CreateSel";
            this.Btn_xml_CreateSel.Size = new System.Drawing.Size(75, 23);
            this.Btn_xml_CreateSel.TabIndex = 6;
            this.Btn_xml_CreateSel.Text = "生成当前";
            this.Btn_xml_CreateSel.UseVisualStyleBackColor = true;
            this.Btn_xml_CreateSel.Click += new System.EventHandler(this.Btn_xml_CreateSel_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.Rtb_InterfaceCode);
            this.tabPage5.Controls.Add(this.Btn_CreateInterfaceAll);
            this.tabPage5.Controls.Add(this.Btn_Interface_CreateSel);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(603, 356);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "IDataAccess";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // Rtb_InterfaceCode
            // 
            this.Rtb_InterfaceCode.Location = new System.Drawing.Point(0, 2);
            this.Rtb_InterfaceCode.Name = "Rtb_InterfaceCode";
            this.Rtb_InterfaceCode.Size = new System.Drawing.Size(603, 331);
            this.Rtb_InterfaceCode.TabIndex = 4;
            this.Rtb_InterfaceCode.Text = "";
            // 
            // Btn_CreateInterfaceAll
            // 
            this.Btn_CreateInterfaceAll.Location = new System.Drawing.Point(84, 334);
            this.Btn_CreateInterfaceAll.Name = "Btn_CreateInterfaceAll";
            this.Btn_CreateInterfaceAll.Size = new System.Drawing.Size(75, 23);
            this.Btn_CreateInterfaceAll.TabIndex = 3;
            this.Btn_CreateInterfaceAll.Text = "生成全部";
            this.Btn_CreateInterfaceAll.UseVisualStyleBackColor = true;
            this.Btn_CreateInterfaceAll.Click += new System.EventHandler(this.Btn_CreateInterfaceAll_Click);
            // 
            // Btn_Interface_CreateSel
            // 
            this.Btn_Interface_CreateSel.Location = new System.Drawing.Point(3, 334);
            this.Btn_Interface_CreateSel.Name = "Btn_Interface_CreateSel";
            this.Btn_Interface_CreateSel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Interface_CreateSel.TabIndex = 2;
            this.Btn_Interface_CreateSel.Text = "生成当前";
            this.Btn_Interface_CreateSel.UseVisualStyleBackColor = true;
            this.Btn_Interface_CreateSel.Click += new System.EventHandler(this.Btn_Interface_CreateSel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Rtb_DACode);
            this.tabPage2.Controls.Add(this.Btn_CreateDAAll);
            this.tabPage2.Controls.Add(this.Btn_DA_CreateSel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(603, 356);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "DataAccess";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Rtb_DACode
            // 
            this.Rtb_DACode.Location = new System.Drawing.Point(0, 2);
            this.Rtb_DACode.Name = "Rtb_DACode";
            this.Rtb_DACode.Size = new System.Drawing.Size(603, 331);
            this.Rtb_DACode.TabIndex = 4;
            this.Rtb_DACode.Text = "";
            // 
            // Btn_CreateDAAll
            // 
            this.Btn_CreateDAAll.Location = new System.Drawing.Point(84, 334);
            this.Btn_CreateDAAll.Name = "Btn_CreateDAAll";
            this.Btn_CreateDAAll.Size = new System.Drawing.Size(75, 23);
            this.Btn_CreateDAAll.TabIndex = 3;
            this.Btn_CreateDAAll.Text = "生成全部";
            this.Btn_CreateDAAll.UseVisualStyleBackColor = true;
            this.Btn_CreateDAAll.Click += new System.EventHandler(this.Btn_CreateDAAll_Click);
            // 
            // Btn_DA_CreateSel
            // 
            this.Btn_DA_CreateSel.Location = new System.Drawing.Point(3, 334);
            this.Btn_DA_CreateSel.Name = "Btn_DA_CreateSel";
            this.Btn_DA_CreateSel.Size = new System.Drawing.Size(75, 23);
            this.Btn_DA_CreateSel.TabIndex = 2;
            this.Btn_DA_CreateSel.Text = "生成当前";
            this.Btn_DA_CreateSel.UseVisualStyleBackColor = true;
            this.Btn_DA_CreateSel.Click += new System.EventHandler(this.Btn_DA_CreateSel_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.Btn_CreateRestAll);
            this.tabPage7.Controls.Add(this.Btn_Rest_CreateSel);
            this.tabPage7.Controls.Add(this.Rtb_RestCode);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(603, 356);
            this.tabPage7.TabIndex = 8;
            this.tabPage7.Text = "RestService";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // Btn_CreateRestAll
            // 
            this.Btn_CreateRestAll.Location = new System.Drawing.Point(84, 333);
            this.Btn_CreateRestAll.Name = "Btn_CreateRestAll";
            this.Btn_CreateRestAll.Size = new System.Drawing.Size(75, 23);
            this.Btn_CreateRestAll.TabIndex = 6;
            this.Btn_CreateRestAll.Text = "生成全部";
            this.Btn_CreateRestAll.UseVisualStyleBackColor = true;
            this.Btn_CreateRestAll.Click += new System.EventHandler(this.Btn_CreateRestAll_Click);
            // 
            // Btn_Rest_CreateSel
            // 
            this.Btn_Rest_CreateSel.Location = new System.Drawing.Point(3, 333);
            this.Btn_Rest_CreateSel.Name = "Btn_Rest_CreateSel";
            this.Btn_Rest_CreateSel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Rest_CreateSel.TabIndex = 7;
            this.Btn_Rest_CreateSel.Text = "生成当前";
            this.Btn_Rest_CreateSel.UseVisualStyleBackColor = true;
            this.Btn_Rest_CreateSel.Click += new System.EventHandler(this.Btn_Rest_CreateSel_Click);
            // 
            // Rtb_RestCode
            // 
            this.Rtb_RestCode.Location = new System.Drawing.Point(0, 3);
            this.Rtb_RestCode.Name = "Rtb_RestCode";
            this.Rtb_RestCode.Size = new System.Drawing.Size(603, 331);
            this.Rtb_RestCode.TabIndex = 5;
            this.Rtb_RestCode.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.Btn_CreateFacadeAll);
            this.tabPage4.Controls.Add(this.Btn_Facade_CreateSel);
            this.tabPage4.Controls.Add(this.Rtb_FacadeCode);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(603, 356);
            this.tabPage4.TabIndex = 9;
            this.tabPage4.Text = "Facade";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Btn_CreateFacadeAll
            // 
            this.Btn_CreateFacadeAll.Location = new System.Drawing.Point(84, 333);
            this.Btn_CreateFacadeAll.Name = "Btn_CreateFacadeAll";
            this.Btn_CreateFacadeAll.Size = new System.Drawing.Size(75, 23);
            this.Btn_CreateFacadeAll.TabIndex = 7;
            this.Btn_CreateFacadeAll.Text = "生成全部";
            this.Btn_CreateFacadeAll.UseVisualStyleBackColor = true;
            this.Btn_CreateFacadeAll.Click += new System.EventHandler(this.Btn_CreateFacadeAll_Click);
            // 
            // Btn_Facade_CreateSel
            // 
            this.Btn_Facade_CreateSel.Location = new System.Drawing.Point(3, 333);
            this.Btn_Facade_CreateSel.Name = "Btn_Facade_CreateSel";
            this.Btn_Facade_CreateSel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Facade_CreateSel.TabIndex = 8;
            this.Btn_Facade_CreateSel.Text = "生成当前";
            this.Btn_Facade_CreateSel.UseVisualStyleBackColor = true;
            this.Btn_Facade_CreateSel.Click += new System.EventHandler(this.Btn_Facade_CreateSel_Click);
            // 
            // Rtb_FacadeCode
            // 
            this.Rtb_FacadeCode.Location = new System.Drawing.Point(0, 3);
            this.Rtb_FacadeCode.Name = "Rtb_FacadeCode";
            this.Rtb_FacadeCode.Size = new System.Drawing.Size(603, 331);
            this.Rtb_FacadeCode.TabIndex = 6;
            this.Rtb_FacadeCode.Text = "";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.lit_website);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(603, 356);
            this.tabPage8.TabIndex = 10;
            this.tabPage8.Text = "Website";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // lit_website
            // 
            this.lit_website.Location = new System.Drawing.Point(0, 3);
            this.lit_website.Name = "lit_website";
            this.lit_website.Size = new System.Drawing.Size(603, 350);
            this.lit_website.TabIndex = 3;
            this.lit_website.Text = "";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.btn_designer2);
            this.tabPage9.Controls.Add(this.btn_aspxcs2);
            this.tabPage9.Controls.Add(this.btn_pageSave);
            this.tabPage9.Controls.Add(this.btn_designer);
            this.tabPage9.Controls.Add(this.btn_aspx2);
            this.tabPage9.Controls.Add(this.btn_aspxcs);
            this.tabPage9.Controls.Add(this.btn_aspx);
            this.tabPage9.Controls.Add(this.lit_Aspx);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(603, 356);
            this.tabPage9.TabIndex = 11;
            this.tabPage9.Text = "WebPage";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // btn_designer2
            // 
            this.btn_designer2.Location = new System.Drawing.Point(504, 333);
            this.btn_designer2.Name = "btn_designer2";
            this.btn_designer2.Size = new System.Drawing.Size(75, 23);
            this.btn_designer2.TabIndex = 9;
            this.btn_designer2.Text = ".designer";
            this.btn_designer2.UseVisualStyleBackColor = true;
            this.btn_designer2.Click += new System.EventHandler(this.btn_designer2_Click);
            // 
            // btn_aspxcs2
            // 
            this.btn_aspxcs2.Location = new System.Drawing.Point(423, 333);
            this.btn_aspxcs2.Name = "btn_aspxcs2";
            this.btn_aspxcs2.Size = new System.Drawing.Size(75, 23);
            this.btn_aspxcs2.TabIndex = 9;
            this.btn_aspxcs2.Text = ".aspx.cs";
            this.btn_aspxcs2.UseVisualStyleBackColor = true;
            this.btn_aspxcs2.Click += new System.EventHandler(this.btn_aspxcs2_Click);
            // 
            // btn_pageSave
            // 
            this.btn_pageSave.Location = new System.Drawing.Point(251, 333);
            this.btn_pageSave.Name = "btn_pageSave";
            this.btn_pageSave.Size = new System.Drawing.Size(75, 23);
            this.btn_pageSave.TabIndex = 9;
            this.btn_pageSave.Text = "保存";
            this.btn_pageSave.UseVisualStyleBackColor = true;
            this.btn_pageSave.Click += new System.EventHandler(this.btn_pageSave_Click);
            // 
            // btn_designer
            // 
            this.btn_designer.Location = new System.Drawing.Point(165, 333);
            this.btn_designer.Name = "btn_designer";
            this.btn_designer.Size = new System.Drawing.Size(75, 23);
            this.btn_designer.TabIndex = 9;
            this.btn_designer.Text = ".designer";
            this.btn_designer.UseVisualStyleBackColor = true;
            this.btn_designer.Click += new System.EventHandler(this.btn_designer_Click);
            // 
            // btn_aspx2
            // 
            this.btn_aspx2.Location = new System.Drawing.Point(342, 333);
            this.btn_aspx2.Name = "btn_aspx2";
            this.btn_aspx2.Size = new System.Drawing.Size(75, 23);
            this.btn_aspx2.TabIndex = 10;
            this.btn_aspx2.Text = ".aspx";
            this.btn_aspx2.UseVisualStyleBackColor = true;
            this.btn_aspx2.Click += new System.EventHandler(this.btn_aspx2_Click);
            // 
            // btn_aspxcs
            // 
            this.btn_aspxcs.Location = new System.Drawing.Point(84, 333);
            this.btn_aspxcs.Name = "btn_aspxcs";
            this.btn_aspxcs.Size = new System.Drawing.Size(75, 23);
            this.btn_aspxcs.TabIndex = 9;
            this.btn_aspxcs.Text = ".aspx.cs";
            this.btn_aspxcs.UseVisualStyleBackColor = true;
            this.btn_aspxcs.Click += new System.EventHandler(this.btn_aspxcs_Click);
            // 
            // btn_aspx
            // 
            this.btn_aspx.Location = new System.Drawing.Point(3, 333);
            this.btn_aspx.Name = "btn_aspx";
            this.btn_aspx.Size = new System.Drawing.Size(75, 23);
            this.btn_aspx.TabIndex = 10;
            this.btn_aspx.Text = ".aspx";
            this.btn_aspx.UseVisualStyleBackColor = true;
            this.btn_aspx.Click += new System.EventHandler(this.btn_aspx_Click);
            // 
            // lit_Aspx
            // 
            this.lit_Aspx.Location = new System.Drawing.Point(-3, 3);
            this.lit_Aspx.Name = "lit_Aspx";
            this.lit_Aspx.Size = new System.Drawing.Size(603, 331);
            this.lit_Aspx.TabIndex = 3;
            this.lit_Aspx.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(205, 434);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(611, 13);
            this.progressBar1.TabIndex = 20;
            // 
            // btn_saveUrl
            // 
            this.btn_saveUrl.Location = new System.Drawing.Point(484, 25);
            this.btn_saveUrl.Name = "btn_saveUrl";
            this.btn_saveUrl.Size = new System.Drawing.Size(50, 23);
            this.btn_saveUrl.TabIndex = 23;
            this.btn_saveUrl.Text = "浏览";
            this.btn_saveUrl.UseVisualStyleBackColor = true;
            this.btn_saveUrl.Click += new System.EventHandler(this.btn_saveUrl_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "保存路径：";
            // 
            // txt_saveUrl
            // 
            this.txt_saveUrl.Enabled = false;
            this.txt_saveUrl.Location = new System.Drawing.Point(286, 26);
            this.txt_saveUrl.Name = "txt_saveUrl";
            this.txt_saveUrl.Size = new System.Drawing.Size(192, 21);
            this.txt_saveUrl.TabIndex = 21;
            // 
            // btn_batchGenerate
            // 
            this.btn_batchGenerate.Location = new System.Drawing.Point(555, 23);
            this.btn_batchGenerate.Name = "btn_batchGenerate";
            this.btn_batchGenerate.Size = new System.Drawing.Size(73, 23);
            this.btn_batchGenerate.TabIndex = 23;
            this.btn_batchGenerate.Text = "生成看看";
            this.btn_batchGenerate.UseVisualStyleBackColor = true;
            this.btn_batchGenerate.Click += new System.EventHandler(this.btn_batchGenerate_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 462);
            this.Controls.Add(this.btn_batchGenerate);
            this.Controls.Add(this.btn_saveUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_saveUrl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Lbx_TableList);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeGenerator Beta 1.0 Main_WCF-Restful";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Referensh;
        private System.Windows.Forms.ToolStripButton tsb_Logoff;
        private System.Windows.Forms.ListBox Lbx_TableList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox Rtb_ModelCode;
        private System.Windows.Forms.Button Btn_CreateModelAll;
        private System.Windows.Forms.Button Btn_Model_CreateSel;
        private System.Windows.Forms.FolderBrowserDialog folder_saveModel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox Rtb_XmlCode;
        private System.Windows.Forms.Button Btn_CreateXmlAll;
        private System.Windows.Forms.Button Btn_xml_CreateSel;
        private System.Windows.Forms.Button btn_saveUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_saveUrl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox Rtb_DACode;
        private System.Windows.Forms.Button Btn_CreateDAAll;
        private System.Windows.Forms.Button Btn_DA_CreateSel;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox Rtb_InterfaceCode;
        private System.Windows.Forms.Button Btn_CreateInterfaceAll;
        private System.Windows.Forms.Button Btn_Interface_CreateSel;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.RichTextBox Rtb_RestCode;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox Rtb_FacadeCode;
        private System.Windows.Forms.Button Btn_CreateRestAll;
        private System.Windows.Forms.Button Btn_Rest_CreateSel;
        private System.Windows.Forms.Button Btn_CreateFacadeAll;
        private System.Windows.Forms.Button Btn_Facade_CreateSel;
        private System.Windows.Forms.Button btn_batchGenerate;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.RichTextBox lit_website;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button btn_aspxcs;
        private System.Windows.Forms.Button btn_aspx;
        private System.Windows.Forms.RichTextBox lit_Aspx;
        private System.Windows.Forms.Button btn_designer;
        private System.Windows.Forms.Button btn_designer2;
        private System.Windows.Forms.Button btn_aspxcs2;
        private System.Windows.Forms.Button btn_aspx2;
        private System.Windows.Forms.Button btn_pageSave;
    }
}