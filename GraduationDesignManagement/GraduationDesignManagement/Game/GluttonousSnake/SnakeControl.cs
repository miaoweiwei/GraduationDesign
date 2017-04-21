using System;
using System.Drawing;
using System.Windows.Forms;
using GraduationDesignManagement.Common;
using Excel = Microsoft.Office.Interop.Excel;

namespace GraduationDesignManagement.Game.GluttonousSnake
{
    public partial class SnakeControl : UserControl
    {
        /// <summary> 游戏是否正在运行 True 正在运行</summary>
        private bool _runningState;
        /// <summary> 游戏是否暂停 False没有暂停 </summary>
        private bool _presentBool;

        private static Excel.Workbook _xlWorkbook;
        private static Excel.Worksheet _xlWorksheet;

        /// <summary> 蛇  </summary>
        private SnakeCoreControl _snake;
        /// <summary>蛇的颜色</summary>
        private Color _snakeColor = Color.Red;
        /// <summary>果实的颜色</summary>
        private Color _randomPointColor = Color.Blue;
        /// <summary> 是否处于主题跟随状态</summary>
        private bool _zhuTiGensuiBool;

        /// <summary> 游戏成绩 </summary>
        private string _scorest = "0";
        private int _sizeRow = 35; //活动范围的高就是行数
        private int _sizeCol = 35; //活动范围的宽就是列数
        private double _cellWidth = 0.45;//小方块的宽

        /// <summary> 蛇的默认移动速度 </summary>
        private int _snakeSpeed;
        /// <summary> 蛇的移动速度 </summary>
        private int _defaultSpeed = 500;
        public SnakeControl()
        {
            InitializeComponent();
        }

        #region 游戏界面

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = ExcelHelper.GetXlApplication();
            _xlWorkbook = xlApp.ActiveWorkbook;
            _xlWorksheet = _xlWorkbook.ActiveSheet;
            if (_snake != null)
            {
                SnakeGameOver();
            }
            ExcelDisplay.CellsClear(_xlWorksheet, new Point(1, 1), new Point(_sizeRow, _sizeCol));
            double columnWidth = _cellWidth * 5.24 - 0.7452;
            double rowHeightw = _cellWidth * 28.5 + 0.32;
            ExcelSet.SetCellSize(_xlWorksheet, _sizeRow, _sizeCol, rowHeightw, columnWidth);

            btnSkinColor.Enabled = true;
            btnFruitColor.Enabled = true;

            btnBegin.Enabled = true;
            hSbDifLevel.Enabled = true;

            grbSet.Enabled = true;
            grbTheme.Enabled = true;
        }
        /// <summary> 活动范围的行数 </summary>
        private void nudActivScopeRow_ValueChanged(object sender, EventArgs e)
        {
            int row = (int)nudActivScopeRow.Value;
            if (row < 10)
            {
                nudActivScopeRow.Value = 10;
                return;
            }

            double columnWidth = _cellWidth * 5.24 - 0.7452;
            double rowHeightw = _cellWidth * 28.5 + 0.32;
            _sizeRow = row;
            ExcelSet.SetCellSize(_xlWorksheet, _sizeRow, _sizeCol, rowHeightw, columnWidth);
        }
        /// <summary> 活动范围的列数 </summary>
        private void nudActivScopeCol_ValueChanged(object sender, EventArgs e)
        {
            int col = (int)nudActivScopeCol.Value;
            if (col < 10)
            {
                nudActivScopeCol.Value = 10;
                return;
            }

            double columnWidth = _cellWidth * 5.24 - 0.7452;
            double rowHeightw = _cellWidth * 28.5 + 0.32;
            _sizeCol = col;
            ExcelSet.SetCellSize(_xlWorksheet, _sizeRow, _sizeCol, rowHeightw, columnWidth);
        }
        /// <summary> 单元格的宽度 </summary>
        private void nudCellWidth_ValueChanged(object sender, EventArgs e)
        {
            int cwllwidth = (int)nudCellWidth.Value;
            if (cwllwidth < 30)
            {
                nudCellWidth.Value = 30;
                return;
            }

            _cellWidth = ((double)cwllwidth) / 100;
            double columnWidth = _cellWidth * 5.24 - 0.7452;
            double rowHeightw = _cellWidth * 28.5 + 0.32;
            ExcelSet.SetCellSize(_xlWorksheet, _sizeRow, _sizeCol, rowHeightw, columnWidth);
        }

        #endregion

        private void btnBegin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_runningState) //此次点击的是开始Btn
                {
                    double columnWidth = _cellWidth * 5.24 - 0.7452;
                    double rowHeightw = _cellWidth * 28.5 + 0.32;
                    ExcelSet.SetCellSize(_xlWorksheet, _sizeRow, _sizeCol, rowHeightw, columnWidth);
                    _snakeSpeed = _snakeSpeed != 0 ? _snakeSpeed : _defaultSpeed;
                    _snake = new SnakeCoreControl(_sizeRow, _sizeCol, _snakeSpeed);

                    _snake.SnakePointListChange += _snake_SnakePointListChange;
                    _snake.SnakeRandomPointChange += _snake_SnakeRandomPointChange;
                    _snake.SnakeDie += _snake_SnakeDie;

                    ExcelDisplay.DisplayInit(_xlWorksheet, _snake.SnakePointList, _snakeColor); //画出初始化时的蛇
                    ExcelDisplay.DislayRandomPoint(_xlWorksheet, _snake.SnakeRandomPoint, _randomPointColor); //画出果实

                    _snake.SnakeTimer.Enabled = true;

                    _presentBool = false;
                    _runningState = true;

                    btnBegin.Text = @"结束";

                    btnInit.Enabled = false;
                    btnPause.Enabled = true;

                    grbSet.Enabled = false;
                    hSbDifLevel.Enabled = false;

                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                    btnLeft.Enabled = true;
                    btnRight.Enabled = true;
                }
                else //结束游戏
                {
                    SnakeGameOver();
                    btnBegin.Text = @"开始";

                    btnInit.Enabled = true;
                    grbSet.Enabled = true;

                    btnPause.Enabled = false;
                    hSbDifLevel.Enabled = true;

                    btnUp.Enabled = false;
                    btnDown.Enabled = false;
                    btnLeft.Enabled = false;
                    btnRight.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                LogUtil.Error("贪吃蛇游戏开始：btnBegin_Click(object sender, EventArgs e)" + exception);
            }
        }
        /// <summary> 游戏结束 </summary>
        private void _snake_SnakeDie(object sender, EventArgs e)
        {
            try
            {
                Invoke(new Action(delegate
                {
                    MessageBox.Show(string.Format("游戏结束:\n    成绩：{0}", _snake.SnakeLength));
                    btnBegin.Text = @"开始";
                }));
                SnakeGameOver();
            }
            catch (Exception exception)
            {
                LogUtil.Error("_snake_SnakeDie(object sender, EventArgs e)" + exception);
            }
        }
        /// <summary> 刷新显示蛇身 </summary>
        private void _snake_SnakeRandomPointChange(object sender, EventArgs e)
        {
            try
            {
                if (_zhuTiGensuiBool)
                {
                    _snakeColor = _randomPointColor;
                    _randomPointColor = GetRandomColor();

                    btnSkinColor.BackColor = _snakeColor;
                    btnFruitColor.BackColor = _randomPointColor; 
                }

                ExcelDisplay.DislayRandomPoint(_xlWorksheet, _snake.SnakeRandomPoint, _randomPointColor);
                _scorest = _snake.SnakeLength.ToString();
                Invoke(new Action(delegate
                {
                    labScore.Text = _scorest;
                }));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
        /// <summary> 刷新果实 </summary>
        private void _snake_SnakePointListChange(object sender, EventArgs e)
        {
            ExcelDisplay.Display(_xlWorksheet, _snake.SnakePointList, _snakeColor);
        }

        /// <summary> 结束贪吃蛇游戏 </summary>
        private void SnakeGameOver()
        {
            _presentBool = true;
            _snake.SnakeTimer.Enabled = false;
            _runningState = false;
            _snake = null;
        }

        /// <summary>
        /// 难度改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hSbDifLevel_ValueChanged(object sender, EventArgs e)
        {
            int temp = hSbDifLevel.Value;
            _snakeSpeed = _defaultSpeed - temp;
        }

        #region 贪吃蛇控制

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (_snake != null)
                _snake.CurrentMoveDirection = MoveDirectionEnum.Up;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (_snake != null)
                _snake.CurrentMoveDirection = MoveDirectionEnum.Down;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (_snake != null)
                _snake.CurrentMoveDirection = MoveDirectionEnum.Left;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (_snake != null)
                _snake.CurrentMoveDirection = MoveDirectionEnum.Right;
        }

        #endregion

        #region 主题设置

        /// <summary> 默认主题 </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            _zhuTiGensuiBool = false;
            _snakeColor = Color.Red;
            _randomPointColor = Color.Blue;
            if (_snake != null)
            {
                ExcelDisplay.DislayRandomPoint(_xlWorksheet, _snake.SnakeRandomPoint, _randomPointColor);
            }
        }
        /// <summary> 主题跟随 </summary>
        private void btnTheme_Click(object sender, EventArgs e)
        {
            if (_zhuTiGensuiBool)
            {
                _zhuTiGensuiBool = false;
                btnSkinColor.Enabled = true;
                btnFruitColor.Enabled = true;
            }
            else
            {
                _zhuTiGensuiBool = true;
                btnSkinColor.Enabled = false;
                btnFruitColor.Enabled = false;
            }
        }

        /// <summary>
        /// 获取随机生成的ARGB颜色
        /// </summary>
        /// <returns></returns>
        private Color GetRandomColor()
        {
            var ra = new Random(unchecked((int)DateTime.Now.Ticks));
            var a = ra.Next(0, 255); //A
            var r = ra.Next(0, 255); //R
            var g = ra.Next(0, 255); //G
            var b = ra.Next(0, 255); //B
            var color = Color.FromArgb(a, r, g, b);
            return color;
        }


        #endregion

        private void btnSkinColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog()==DialogResult.OK)
            {
                btnSkinColor.BackColor = colorDialog.Color;
                _snakeColor= colorDialog.Color;
            }
        }

        private void btnFruitColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnFruitColor.BackColor = colorDialog.Color;
                _randomPointColor= colorDialog.Color;
                if (_snake!=null)
                {
                    ExcelDisplay.DislayRandomPoint(_xlWorksheet, _snake.SnakeRandomPoint, _randomPointColor);
                }
            }
        }
    }
}