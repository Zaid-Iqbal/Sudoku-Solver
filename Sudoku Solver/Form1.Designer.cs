namespace Sudoku_Solver
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
            this.board = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.I = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleLabel = new System.Windows.Forms.Label();
            this.initalLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.FileButton = new System.Windows.Forms.Button();
            this.files = new System.Windows.Forms.OpenFileDialog();
            this.refreshBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.AllowUserToAddRows = false;
            this.board.AllowUserToDeleteRows = false;
            this.board.AllowUserToResizeColumns = false;
            this.board.AllowUserToResizeRows = false;
            this.board.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.board.ColumnHeadersVisible = false;
            this.board.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7,
            this.col8,
            this.I});
            this.board.Location = new System.Drawing.Point(9, 124);
            this.board.Name = "board";
            this.board.RowHeadersVisible = false;
            this.board.RowHeadersWidth = 51;
            this.board.RowTemplate.Height = 24;
            this.board.Size = new System.Drawing.Size(605, 560);
            this.board.TabIndex = 1;
            this.board.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.board_CellPainting);
            // 
            // col1
            // 
            this.col1.HeaderText = "A";
            this.col1.MinimumWidth = 6;
            this.col1.Name = "col1";
            this.col1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col1.Width = 50;
            // 
            // col2
            // 
            this.col2.HeaderText = "B";
            this.col2.MinimumWidth = 6;
            this.col2.Name = "col2";
            this.col2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col2.Width = 50;
            // 
            // col3
            // 
            this.col3.HeaderText = "C";
            this.col3.MinimumWidth = 6;
            this.col3.Name = "col3";
            this.col3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col3.Width = 50;
            // 
            // col4
            // 
            this.col4.HeaderText = "D";
            this.col4.MinimumWidth = 6;
            this.col4.Name = "col4";
            this.col4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col4.Width = 50;
            // 
            // col5
            // 
            this.col5.HeaderText = "E";
            this.col5.MinimumWidth = 6;
            this.col5.Name = "col5";
            this.col5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col5.Width = 50;
            // 
            // col6
            // 
            this.col6.HeaderText = "F";
            this.col6.MinimumWidth = 6;
            this.col6.Name = "col6";
            this.col6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col6.Width = 50;
            // 
            // col7
            // 
            this.col7.HeaderText = "G";
            this.col7.MinimumWidth = 6;
            this.col7.Name = "col7";
            this.col7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col7.Width = 50;
            // 
            // col8
            // 
            this.col8.HeaderText = "H";
            this.col8.MinimumWidth = 6;
            this.col8.Name = "col8";
            this.col8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col8.Width = 50;
            // 
            // I
            // 
            this.I.HeaderText = "I";
            this.I.MinimumWidth = 6;
            this.I.Name = "I";
            this.I.Width = 50;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Comic Sans MS", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(149, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(307, 59);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "Sudoku Solver";
            // 
            // initalLabel
            // 
            this.initalLabel.AutoSize = true;
            this.initalLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initalLabel.Location = new System.Drawing.Point(182, 80);
            this.initalLabel.Name = "initalLabel";
            this.initalLabel.Size = new System.Drawing.Size(235, 28);
            this.initalLabel.TabIndex = 7;
            this.initalLabel.Text = "Enter the intial numbers";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(254, 690);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 30);
            this.startButton.TabIndex = 22;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // FileButton
            // 
            this.FileButton.Location = new System.Drawing.Point(545, 690);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(69, 30);
            this.FileButton.TabIndex = 23;
            this.FileButton.Text = "Load";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // files
            // 
            this.files.FileName = "openFileDialog1";
            this.files.InitialDirectory = "C:\\Users\\email\\Desktop\\";
            this.files.Title = "Select a file with a preloaded problem (Excel only)";
            // 
            // refreshBox
            // 
            this.refreshBox.AutoSize = true;
            this.refreshBox.Location = new System.Drawing.Point(9, 695);
            this.refreshBox.Name = "refreshBox";
            this.refreshBox.Size = new System.Drawing.Size(220, 21);
            this.refreshBox.TabIndex = 24;
            this.refreshBox.Text = "View Algorithm during process";
            this.refreshBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 728);
            this.Controls.Add(this.refreshBox);
            this.Controls.Add(this.FileButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.initalLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.board);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView board;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6;
        private System.Windows.Forms.DataGridViewTextBoxColumn col7;
        private System.Windows.Forms.DataGridViewTextBoxColumn col8;
        private System.Windows.Forms.DataGridViewTextBoxColumn I;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label initalLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.OpenFileDialog files;
        private System.Windows.Forms.CheckBox refreshBox;
    }
}

