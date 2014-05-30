namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddMarker = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edId = new System.Windows.Forms.TextBox();
            this.edLatitude = new System.Windows.Forms.TextBox();
            this.edLongitude = new System.Windows.Forms.TextBox();
            this.ckbxDragabble = new System.Windows.Forms.CheckBox();
            this.btnRemoveMarker = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRetrieveMarker = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRetrieveMarker);
            this.panel1.Controls.Add(this.btnRemoveAll);
            this.panel1.Controls.Add(this.btnRemoveMarker);
            this.panel1.Controls.Add(this.ckbxDragabble);
            this.panel1.Controls.Add(this.edLongitude);
            this.panel1.Controls.Add(this.edLatitude);
            this.panel1.Controls.Add(this.edId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnAddMarker);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 74);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(739, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(739, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Show Dev Tools";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddMarker
            // 
            this.btnAddMarker.Location = new System.Drawing.Point(415, 21);
            this.btnAddMarker.Name = "btnAddMarker";
            this.btnAddMarker.Size = new System.Drawing.Size(75, 23);
            this.btnAddMarker.TabIndex = 0;
            this.btnAddMarker.Text = "Add Marker";
            this.btnAddMarker.UseVisualStyleBackColor = true;
            this.btnAddMarker.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Latitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Longitude";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Draggable";
            // 
            // edId
            // 
            this.edId.Location = new System.Drawing.Point(11, 24);
            this.edId.Name = "edId";
            this.edId.Size = new System.Drawing.Size(79, 20);
            this.edId.TabIndex = 7;
            this.edId.Text = "123";
            // 
            // edLatitude
            // 
            this.edLatitude.Location = new System.Drawing.Point(96, 24);
            this.edLatitude.Name = "edLatitude";
            this.edLatitude.Size = new System.Drawing.Size(117, 20);
            this.edLatitude.TabIndex = 8;
            this.edLatitude.Text = "33.43017060777363";
            // 
            // edLongitude
            // 
            this.edLongitude.Location = new System.Drawing.Point(219, 24);
            this.edLongitude.Name = "edLongitude";
            this.edLongitude.Size = new System.Drawing.Size(127, 20);
            this.edLongitude.TabIndex = 9;
            this.edLongitude.Text = "-86.69652080535889";
            // 
            // ckbxDragabble
            // 
            this.ckbxDragabble.AutoSize = true;
            this.ckbxDragabble.Checked = true;
            this.ckbxDragabble.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbxDragabble.Location = new System.Drawing.Point(352, 27);
            this.ckbxDragabble.Name = "ckbxDragabble";
            this.ckbxDragabble.Size = new System.Drawing.Size(15, 14);
            this.ckbxDragabble.TabIndex = 10;
            this.ckbxDragabble.UseVisualStyleBackColor = true;
            // 
            // btnRemoveMarker
            // 
            this.btnRemoveMarker.Location = new System.Drawing.Point(496, 22);
            this.btnRemoveMarker.Name = "btnRemoveMarker";
            this.btnRemoveMarker.Size = new System.Drawing.Size(94, 23);
            this.btnRemoveMarker.TabIndex = 11;
            this.btnRemoveMarker.Text = "Remove Marker";
            this.btnRemoveMarker.UseVisualStyleBackColor = true;
            this.btnRemoveMarker.Click += new System.EventHandler(this.btnRemoveMarker_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(596, 21);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 12;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRetrieveMarker
            // 
            this.btnRetrieveMarker.Location = new System.Drawing.Point(11, 48);
            this.btnRetrieveMarker.Name = "btnRetrieveMarker";
            this.btnRetrieveMarker.Size = new System.Drawing.Size(96, 23);
            this.btnRetrieveMarker.TabIndex = 13;
            this.btnRetrieveMarker.Text = "Retrieve Marker";
            this.btnRetrieveMarker.UseVisualStyleBackColor = true;
            this.btnRetrieveMarker.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 573);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddMarker;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox ckbxDragabble;
        private System.Windows.Forms.TextBox edLongitude;
        private System.Windows.Forms.TextBox edLatitude;
        private System.Windows.Forms.TextBox edId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemoveMarker;
        private System.Windows.Forms.Button btnRetrieveMarker;
    }
}

