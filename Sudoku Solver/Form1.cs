using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Sudoku_Solver
{
    public partial class Form1 : Form
    {
        bool refresh = false;

        List<int[]> tiles = new List<int[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 50;
                board.Rows.Add(row);
            }


        }

        private void startButton_Click(object sender, EventArgs e)
        {
            refresh = refreshBox.Checked;

            //checks that inputs are valid
            foreach (DataGridViewRow row in board.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    int num = -1;
                    if (cell.Value != null && cell.Value.ToString().Length > 1)
                    {
                        MessageBox.Show("Make sure only one number is written in a cell");
                        return;
                    }
                    else if (!int.TryParse(cell.Value.ToString(), out num))
                    {
                        MessageBox.Show("Make sure only numbers are in written in a box. No extra charecters");
                        return;
                    }
                }
            }

            //puts zero into blank cells
            foreach (DataGridViewRow row in board.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        cell.Value = 0;
                    }
                }
            }

            startButton.Hide();
            FileButton.Hide();
            refreshBox.Hide();

            //populate the tiles list
            foreach (DataGridViewRow row in board.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value.ToString() != "0")
                    {
                        tiles.Add(new int[] { cell.ColumnIndex, row.Index });
                        cell.Style.BackColor = Color.LightBlue;
                    }
                }
            }

            board.Refresh();

            bool worked = false;
            int x = 0;
            int y = 0;
            //TODO fix backtracking
            //iterate through y axis (rows)
            for (y = 0; y < 9; y++)
            {
                //iterate through x axis (cells)
                for (x = 0; x < 9; x++)
                {
                    //reset bool
                    worked = false;

                    //check to see if cell can be changed
                    if (protect(x, y))
                    {
                        continue;
                    }
                    //check 1-9 for the cell
                    for (int i = 1; i <= 9; i++)
                    {
                        //increment number and refresh board
                        board.Rows[y].Cells[x].Value = i;
                        if (refresh)
                        {
                            board.Refresh();
                        }
                        //check to see if the change is viable in its row, column, and square
                        if (checkRow(board.Rows[y].Cells[x]) && checkColumn(board.Rows[y].Cells[x]) && checkSquare(board.Rows[y].Cells[x]))
                        {
                            worked = true;
                            break;
                        }
                    }

                    //if the change is legal, move on to the next cell
                    if (worked)
                    {
                        continue;
                    }

                    //if all 1-9 dont work, backtrack
                    board.Rows[y].Cells[x].Value = 0;
                    int[] coords = backtrack(x, y);
                    x = coords[0];
                    y = coords[1];

                }
            }

        }

        public int[] backtrack(int x, int y)
        {
            //marked true when return time
            bool done = false;

            //loop through previous cells
            do
            {
                //checks if going back 1 space wont go out of bounds, otherwise it goes to index 7
                if (x - 1 < 0)
                {
                    x = 8;
                    //takes the row back one. if its out of bounds, messagebox error (1st box has been maxed out)
                    if (y - 1 < 0)
                    {
                        board.Refresh();
                        MessageBox.Show("ERROR backtrack(): backtracked too far");
                    }
                    else
                    {
                        y --;
                    }
                }
                else
                {
                    x --;
                }

                //if the cell can be changed
                if (!protect(x,y))
                {
                    //if the cell isnt maxxed to 9
                    if (int.Parse(board.Rows[y].Cells[x].Value.ToString()) < 9)
                    {
                        //iterates through the numbers from (the num already in the cell - 9)
                        for (int i = int.Parse(board.Rows[y].Cells[x].Value.ToString()) + 1; i <= 9; i++)
                        {
                            board.Rows[y].Cells[x].Value = i;
                            if (refresh)
                            {
                                board.Refresh();
                            }
                            //checks too see if the change is valid
                            if (checkRow(board.Rows[y].Cells[x]) && checkColumn(board.Rows[y].Cells[x]) && checkSquare(board.Rows[y].Cells[x]))
                            {
                                done = true;
                                break;
                            }
                        }
                        if (!done)
                        {
                            board.Rows[y].Cells[x].Value = 0;
                            if (refresh)
                            {
                                board.Refresh();
                            }
                        }
                    }
                    //sets to zero and continue backtracking
                    else
                    {
                        board.Rows[y].Cells[x].Value = 0;
                        if (refresh)
                        {
                            board.Refresh();
                        }
                    }
                }
            } 
            while (!done);

            return new int[] { x, y };
            
        }

        public bool checkRow(DataGridViewCell cell)
        {
            bool found = false;
            DataGridViewRow row = new DataGridViewRow();

            //find the row
            foreach (DataGridViewRow findRow in board.Rows)
            {
                if (cell.RowIndex == findRow.Index)
                {
                    row = findRow;
                    found = true;
                    break;
                }
            }

            //check to see if row was found
            if (found == false)
            {
                MessageBox.Show("checkRow Error: row not found");
            }

            //check to see if row has all independent values
            foreach (DataGridViewCell cell1 in row.Cells)
            {
                if (int.Parse(cell1.Value.ToString()) == 0)
                {
                    continue;
                }
                foreach (DataGridViewCell cell2 in row.Cells)
                {
                    if (int.Parse(cell2.Value.ToString()) == 0)
                    {
                        continue;
                    }
                    if (cell1.Value != null && cell2.Value != null && cell1 != cell2 && cell1.Value.ToString() == cell2.Value.ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool checkColumn(DataGridViewCell cell)
        {
            int idx = cell.ColumnIndex;
            List<int> nums = new List<int>();
            foreach (DataGridViewRow row in board.Rows)
            {
                foreach (DataGridViewCell getNums in row.Cells)
                {
                    if (getNums.Value == null)
                    {
                        nums.Add(-1);
                    }
                    else if (getNums.ColumnIndex == idx)
                    {
                        nums.Add(int.Parse(getNums.Value.ToString()));
                    }
                }
            }

            if (nums.Count != 9)
            {
                MessageBox.Show("checkColumn Error. nums list does not contain 9 numbers");
            }

            int num1IDX = 0;
            foreach (int num1 in nums)
            {
                if (num1 == 0)
                {
                    continue;
                }
                int num2IDX = 0;
                foreach (int num2 in nums)
                {
                    if (num2 == 0)
                    {
                        continue;
                    }
                    if (num1IDX != num2IDX && num1 == num2)
                    {
                        return false;
                    }
                    num2IDX++;
                }
                num1IDX++;
            }

            return true;
        }

        public bool checkSquare(DataGridViewCell cell)
        {
            //x = col
            //y = row
            List<int[]> sqrTiles = new List<int[]>();
            if (cell.RowIndex < 3 && cell.ColumnIndex < 3)
            {
                sqrTiles.Add(new int[] { 0, 0 });
                sqrTiles.Add(new int[] { 0, 1 });
                sqrTiles.Add(new int[] { 0, 2 });
                sqrTiles.Add(new int[] { 1, 0 });
                sqrTiles.Add(new int[] { 1, 1 });
                sqrTiles.Add(new int[] { 1, 2 });
                sqrTiles.Add(new int[] { 2, 0 });
                sqrTiles.Add(new int[] { 2, 1 });
                sqrTiles.Add(new int[] { 2, 2 });

            }
            else if (cell.RowIndex < 3 && cell.ColumnIndex > 2 && cell.ColumnIndex < 6)
            {
                sqrTiles.Add(new int[] { 3, 0 });
                sqrTiles.Add(new int[] { 3, 1 });
                sqrTiles.Add(new int[] { 3, 2 });
                sqrTiles.Add(new int[] { 4, 0 });
                sqrTiles.Add(new int[] { 4, 1 });
                sqrTiles.Add(new int[] { 4, 2 });
                sqrTiles.Add(new int[] { 5, 0 });
                sqrTiles.Add(new int[] { 5, 1 });
                sqrTiles.Add(new int[] { 5, 2 });

            }
            else if (cell.RowIndex < 3 && cell.ColumnIndex > 5)
            {
                sqrTiles.Add(new int[] { 6, 0 });
                sqrTiles.Add(new int[] { 6, 1 });
                sqrTiles.Add(new int[] { 6, 2 });
                sqrTiles.Add(new int[] { 7, 0 });
                sqrTiles.Add(new int[] { 7, 1 });
                sqrTiles.Add(new int[] { 7, 2 });
                sqrTiles.Add(new int[] { 8, 0 });
                sqrTiles.Add(new int[] { 8, 1 });
                sqrTiles.Add(new int[] { 8, 2 });
            }
            //row 2
            else if (cell.RowIndex > 2 && cell.RowIndex < 6 && cell.ColumnIndex < 3)
            {
                sqrTiles.Add(new int[] { 0, 3 });
                sqrTiles.Add(new int[] { 0, 4 });
                sqrTiles.Add(new int[] { 0, 5 });
                sqrTiles.Add(new int[] { 1, 3 });
                sqrTiles.Add(new int[] { 1, 4 });
                sqrTiles.Add(new int[] { 1, 5 });
                sqrTiles.Add(new int[] { 2, 3 });
                sqrTiles.Add(new int[] { 2, 4 });
                sqrTiles.Add(new int[] { 2, 5 });
            }
            else if (cell.RowIndex > 2 && cell.RowIndex < 6 && cell.ColumnIndex > 2 && cell.ColumnIndex < 6)
            {
                sqrTiles.Add(new int[] { 3, 3 });
                sqrTiles.Add(new int[] { 3, 4 });
                sqrTiles.Add(new int[] { 3, 5 });
                sqrTiles.Add(new int[] { 4, 3 });
                sqrTiles.Add(new int[] { 4, 4 });
                sqrTiles.Add(new int[] { 4, 5 });
                sqrTiles.Add(new int[] { 5, 3 });
                sqrTiles.Add(new int[] { 5, 4 });
                sqrTiles.Add(new int[] { 5, 5 });
            }
            else if (cell.RowIndex > 2 && cell.RowIndex < 6 && cell.ColumnIndex > 5)
            {
                sqrTiles.Add(new int[] { 6, 3 });
                sqrTiles.Add(new int[] { 6, 4 });
                sqrTiles.Add(new int[] { 6, 5 });
                sqrTiles.Add(new int[] { 7, 3 });
                sqrTiles.Add(new int[] { 7, 4 });
                sqrTiles.Add(new int[] { 7, 5 });
                sqrTiles.Add(new int[] { 8, 3 });
                sqrTiles.Add(new int[] { 8, 4 });
                sqrTiles.Add(new int[] { 8, 5 });
            }
            //row 3
            else if (cell.RowIndex > 5 && cell.ColumnIndex < 3)
            {
                sqrTiles.Add(new int[] { 0, 6 });
                sqrTiles.Add(new int[] { 0, 7 });
                sqrTiles.Add(new int[] { 0, 8 });
                sqrTiles.Add(new int[] { 1, 6 });
                sqrTiles.Add(new int[] { 1, 7 });
                sqrTiles.Add(new int[] { 1, 8 });
                sqrTiles.Add(new int[] { 2, 6 });
                sqrTiles.Add(new int[] { 2, 7 });
                sqrTiles.Add(new int[] { 2, 8 });
            }
            else if (cell.RowIndex > 5 && cell.ColumnIndex > 2 && cell.ColumnIndex < 6)
            {
                sqrTiles.Add(new int[] { 3, 6 });
                sqrTiles.Add(new int[] { 3, 7 });
                sqrTiles.Add(new int[] { 3, 8 });
                sqrTiles.Add(new int[] { 4, 6 });
                sqrTiles.Add(new int[] { 4, 7 });
                sqrTiles.Add(new int[] { 4, 8 });
                sqrTiles.Add(new int[] { 5, 6 });
                sqrTiles.Add(new int[] { 5, 7 });
                sqrTiles.Add(new int[] { 5, 8 });
            }
            else if (cell.RowIndex > 5 && cell.ColumnIndex > 5)
            {
                sqrTiles.Add(new int[] { 6, 6 });
                sqrTiles.Add(new int[] { 6, 7 });
                sqrTiles.Add(new int[] { 6, 8 });
                sqrTiles.Add(new int[] { 7, 6 });
                sqrTiles.Add(new int[] { 7, 7 });
                sqrTiles.Add(new int[] { 7, 8 });
                sqrTiles.Add(new int[] { 8, 6 });
                sqrTiles.Add(new int[] { 8, 7 });
                sqrTiles.Add(new int[] { 8, 8 });
            }

            if (sqrTiles.Count == 0)
            {
                MessageBox.Show("checkSquare Error: tiles list is empty");
            }

            foreach (int[] tile1 in sqrTiles)
            {
                if (int.Parse(board.Rows[tile1[1]].Cells[tile1[0]].Value.ToString()) == 0)
                {
                    continue;
                }
                foreach (int[] tile2 in sqrTiles)
                {
                    if (int.Parse(board.Rows[tile2[1]].Cells[tile2[0]].Value.ToString()) == 0)
                    {
                        continue;
                    }
                    if (tile1 != tile2 && board.Rows[tile1[1]].Cells[tile1[0]].Value.ToString() == board.Rows[tile2[1]].Cells[tile2[0]].Value.ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool protect(int x, int y)
        {
            foreach (int[] tile in tiles)
            {
                if (tile[0] == x && tile[1] == y)
                {
                    return true;
                }
            }

            return false;
        }

        //paints the black lines to divide the board into 9 squares
        private void board_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //Using red pen to draw border  
            using (var blackPen = new Pen(Color.Black, 3))
            {
                //Get the x coordination value of the left line  
                int left_x = this.board.GetCellDisplayRectangle(0, 0, true).X;

                //Get the x coordination value of the left line  
                int right_x = this.board.GetCellDisplayRectangle(8, 0, true).X + this.board.GetCellDisplayRectangle(8, 0, true).Width;

                //Get the x coordination value of the first middle line  
                int mid1_x = this.board.GetCellDisplayRectangle(3, 0, true).X;

                //Get the x coordination value of the second middle line
                int mid2_x = this.board.GetCellDisplayRectangle(6, 0, true).X;

                //Get the y coordination value of the first middle line
                int mid1_y = this.board.GetCellDisplayRectangle(0, 3, true).Y;

                //Get the y coordination value of the second middle line
                int mid2_y = this.board.GetCellDisplayRectangle(0, 6, true).Y;

                //Get the y coordination value of the top of each line  
                int top_y = this.board.GetCellDisplayRectangle(0, 0, true).Y;

                //Get the y coordination value of the bottom of each line  
                int bottom_y = this.board.GetCellDisplayRectangle(0, 8, true).Y + this.board.GetCellDisplayRectangle(0, 8, true).Height;

                //Draw the lines using red pen and the x, y values above  
                e.Graphics.DrawLine(blackPen, new Point(left_x, top_y), new Point(left_x, bottom_y));
                e.Graphics.DrawLine(blackPen, new Point(right_x, top_y), new Point(right_x, bottom_y));
                e.Graphics.DrawLine(blackPen, new Point(left_x, top_y), new Point(right_x, top_y));
                e.Graphics.DrawLine(blackPen, new Point(left_x, bottom_y), new Point(right_x, bottom_y));
                e.Graphics.DrawLine(blackPen, new Point(left_x, mid1_y), new Point(right_x, mid1_y));
                e.Graphics.DrawLine(blackPen, new Point(left_x, mid2_y), new Point(right_x, mid2_y));
                e.Graphics.DrawLine(blackPen, new Point(mid1_x, top_y), new Point(mid1_x, bottom_y));
                e.Graphics.DrawLine(blackPen, new Point(mid2_x, top_y), new Point(mid2_x, bottom_y));
            }
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            files.ShowDialog();

            String filePath = files.FileName;
            if (filePath == null)
            {
                return;
            }
            IWorkbook wb = new XSSFWorkbook(filePath);
            ISheet ws = wb.GetSheetAt(0);

            for (int x = 0; x < ws.LastRowNum+1; x++)
            {
                IRow row = ws.GetRow(x);

                for (int y = 0; y < 9; y++)
                {
                    board.Rows[x].Cells[y].Value = row.Cells[y].ToString();
                }
            }

            startButton.PerformClick();
        }
    }
}