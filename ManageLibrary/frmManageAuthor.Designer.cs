namespace ManageLibrary
{
    partial class frmManageAuthor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageAuthor));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAuthorList = new System.Windows.Forms.DataGridView();
            this.btnAuthorExit = new System.Windows.Forms.Button();
            this.btnAuthorDelete = new System.Windows.Forms.Button();
            this.btnAuthorUpdate = new System.Windows.Forms.Button();
            this.btnAuthorSave = new System.Windows.Forms.Button();
            this.btnAuthorAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAuthorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuthorID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bnAuthorList = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bsAuthorList = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthorList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnAuthorList)).BeginInit();
            this.bnAuthorList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAuthorList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAuthorList);
            this.groupBox2.Location = new System.Drawing.Point(529, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 159);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Tác Giả";
            // 
            // dgvAuthorList
            // 
            this.dgvAuthorList.AllowUserToAddRows = false;
            this.dgvAuthorList.AllowUserToDeleteRows = false;
            this.dgvAuthorList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuthorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuthorList.Location = new System.Drawing.Point(6, 21);
            this.dgvAuthorList.Name = "dgvAuthorList";
            this.dgvAuthorList.RowTemplate.Height = 24;
            this.dgvAuthorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuthorList.Size = new System.Drawing.Size(455, 132);
            this.dgvAuthorList.TabIndex = 0;
            // 
            // btnAuthorExit
            // 
            this.btnAuthorExit.Location = new System.Drawing.Point(804, 268);
            this.btnAuthorExit.Name = "btnAuthorExit";
            this.btnAuthorExit.Size = new System.Drawing.Size(117, 50);
            this.btnAuthorExit.TabIndex = 19;
            this.btnAuthorExit.Text = "Thoát";
            this.btnAuthorExit.UseVisualStyleBackColor = true;
            this.btnAuthorExit.Click += new System.EventHandler(this.btnAuthorExit_Click);
            // 
            // btnAuthorDelete
            // 
            this.btnAuthorDelete.Location = new System.Drawing.Point(627, 268);
            this.btnAuthorDelete.Name = "btnAuthorDelete";
            this.btnAuthorDelete.Size = new System.Drawing.Size(117, 50);
            this.btnAuthorDelete.TabIndex = 18;
            this.btnAuthorDelete.Text = "Xóa";
            this.btnAuthorDelete.UseVisualStyleBackColor = true;
            this.btnAuthorDelete.Click += new System.EventHandler(this.btnAuthorDelete_Click);
            // 
            // btnAuthorUpdate
            // 
            this.btnAuthorUpdate.Location = new System.Drawing.Point(449, 268);
            this.btnAuthorUpdate.Name = "btnAuthorUpdate";
            this.btnAuthorUpdate.Size = new System.Drawing.Size(117, 50);
            this.btnAuthorUpdate.TabIndex = 17;
            this.btnAuthorUpdate.Text = "Sửa";
            this.btnAuthorUpdate.UseVisualStyleBackColor = true;
            this.btnAuthorUpdate.Click += new System.EventHandler(this.btnAuthorUpdate_Click);
            // 
            // btnAuthorSave
            // 
            this.btnAuthorSave.Enabled = false;
            this.btnAuthorSave.Location = new System.Drawing.Point(282, 268);
            this.btnAuthorSave.Name = "btnAuthorSave";
            this.btnAuthorSave.Size = new System.Drawing.Size(117, 50);
            this.btnAuthorSave.TabIndex = 16;
            this.btnAuthorSave.Text = "Lưu";
            this.btnAuthorSave.UseVisualStyleBackColor = true;
            this.btnAuthorSave.Click += new System.EventHandler(this.btnAuthorSave_Click);
            // 
            // btnAuthorAdd
            // 
            this.btnAuthorAdd.Location = new System.Drawing.Point(108, 268);
            this.btnAuthorAdd.Name = "btnAuthorAdd";
            this.btnAuthorAdd.Size = new System.Drawing.Size(117, 50);
            this.btnAuthorAdd.TabIndex = 15;
            this.btnAuthorAdd.Text = "Thêm";
            this.btnAuthorAdd.UseVisualStyleBackColor = true;
            this.btnAuthorAdd.Click += new System.EventHandler(this.btnAuthorAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAuthorName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAuthorID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 159);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Tác Giả";
            // 
            // txtAuthorName
            // 
            this.txtAuthorName.Enabled = false;
            this.txtAuthorName.Location = new System.Drawing.Point(127, 95);
            this.txtAuthorName.Name = "txtAuthorName";
            this.txtAuthorName.Size = new System.Drawing.Size(304, 22);
            this.txtAuthorName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên Tác Giả :";
            // 
            // txtAuthorID
            // 
            this.txtAuthorID.Enabled = false;
            this.txtAuthorID.Location = new System.Drawing.Point(127, 33);
            this.txtAuthorID.Name = "txtAuthorID";
            this.txtAuthorID.Size = new System.Drawing.Size(304, 22);
            this.txtAuthorID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Tác Giả  :";
            // 
            // bnAuthorList
            // 
            this.bnAuthorList.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnAuthorList.CountItem = this.bindingNavigatorCountItem;
            this.bnAuthorList.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnAuthorList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnAuthorList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bnAuthorList.Location = new System.Drawing.Point(0, 0);
            this.bnAuthorList.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnAuthorList.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnAuthorList.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnAuthorList.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnAuthorList.Name = "bnAuthorList";
            this.bnAuthorList.PositionItem = this.bindingNavigatorPositionItem;
            this.bnAuthorList.Size = new System.Drawing.Size(1021, 27);
            this.bnAuthorList.TabIndex = 21;
            this.bnAuthorList.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // frmManageAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 357);
            this.Controls.Add(this.bnAuthorList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAuthorExit);
            this.Controls.Add(this.btnAuthorDelete);
            this.Controls.Add(this.btnAuthorUpdate);
            this.Controls.Add(this.btnAuthorSave);
            this.Controls.Add(this.btnAuthorAdd);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmManageAuthor";
            this.Text = "Quản lý tác giả";
            this.Load += new System.EventHandler(this.frmManageAuthor_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthorList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnAuthorList)).EndInit();
            this.bnAuthorList.ResumeLayout(false);
            this.bnAuthorList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAuthorList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvAuthorList;
        private System.Windows.Forms.Button btnAuthorExit;
        private System.Windows.Forms.Button btnAuthorDelete;
        private System.Windows.Forms.Button btnAuthorUpdate;
        private System.Windows.Forms.Button btnAuthorSave;
        private System.Windows.Forms.Button btnAuthorAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAuthorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAuthorID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingNavigator bnAuthorList;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bsAuthorList;
    }
}