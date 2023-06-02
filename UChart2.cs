using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExtensionLib;


namespace UControlLibrary
{
    public class ZoomedChart : Chart
    {
        #region Поля
        private const string Format = "0.00E+00";

        private readonly zoomModeEnum zoomMode = zoomModeEnum.XY;
        private bool handMovingNow;
        private Point handMovingInitPoint;
        private string labelYFormat;
        private Color lineColor;


        private bool zoomingNow;
        private Rectangle zoomRect;

        public event EventHandler AddedPoints;
        public event EventHandler<ClickPointEventArg> ClickPoint;
        #endregion

        public ZoomedChart()
        {
          
        }


        #region Очищение точек

        public void PointsClear()
        {
            //Log.Trace("PointsClear()");

            var points = Series.FirstOrDefault().Points;
            points?.Clear();
        }

        #endregion




        #region ДобавлениеТочки

        //private void UDataChart_AddedPoints(object sender, EventArgs e)
        //{
        //    PointLimitChecking();
        //}

        //private void PointLimitChecking()
        //{
          

        //    int count = PointsLimit;
        //    int pcount = valueSeries.Points.Count;

        //    for (int i = count; i < pcount; i++)
        //    {
        //        valueSeries.Points.RemoveAt(0);
        //        ResetAutoValues();
        //    }
        //}

        //private void LabelYFormatChecking()
        //{
        //    var axisY = ChartAreas.FirstOrDefault().AxisY;
        //    double lymax = Math.Log10(Math.Abs(axisY.Maximum));
        //    double lymin = Math.Log10(Math.Abs(axisY.Minimum));

        //    if (lymax > 4 || lymin < -2)
        //        LabelYFormat = "{0:0.##E+00}";
        //    else
        //        LabelYFormat = "{0:0.##}";
        //}

        //public void AddData(List<double> list)
        //{
        //    //void DoIt()
        //    //{

        //    //    try
        //    //    {
        //    //        int count = list.Count;
        //    //        //int listCount = list.Count;
        //    //        for (int i = 0; i < count; i++)
        //    //        {
        //    //            valueSeries.Points.AddXY(list[i].Time, list[i].DoubleValue);
        //    //            OnAddedPoints();
        //    //        }
        //    //    }
        //    //    catch (Exception e)
        //    //    {
        //    //        Log.Error(e);
        //    //    }

        //    //}


        //    //try
        //    //{
        //    //    Log.Trace("AddData()_ BeginInvoke(new Action(DoIt))");
        //    //    BeginInvoke(new Action(DoIt));
        //    //}
        //    //catch (Exception)
        //    //{

        //    //}
        //}

        protected virtual void OnAddedPoints()
        {
            AddedPoints?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        protected virtual void OnClickPoint(ClickPointEventArg e)
        {
            ClickPoint?.Invoke(this, e);
        }

        #region Инициализация

        public void DefaultSettings()
        {
            BackColor = Color.White;
            var axisY = ChartAreas.FirstOrDefault().AxisY;
            var axisX = ChartAreas.FirstOrDefault().AxisX;
            var area = ChartAreas.FirstOrDefault();
            var lineSeries = Series.FirstOrDefault();
            Legends.Clear();
            axisX.MajorGrid.LineColor = Color.Gray;
            axisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            axisY.IsStartedFromZero = false;
            axisX.IsStartedFromZero = false;
            axisY.MajorGrid.LineColor = Color.Gray;
            axisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.BackColor = Color.White;
            area.CursorX.Interval = 0D;
            area.CursorX.LineColor = Color.Blue;
            area.CursorX.SelectionColor = Color.CornflowerBlue;
            area.CursorY.Interval = 0D;
            area.CursorY.LineColor = Color.Blue;
            area.CursorY.SelectionColor = Color.CornflowerBlue;
            area.Name = "MainArea";
            //ChartAreas.Add(mainArea);
            //Dock = DockStyle.Fill;
            //Location = new Point(0, 0);
            Name = "MainChart";
            lineSeries.ChartArea = "MainArea";
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.Color = Color.Blue;
            lineSeries.Name = "ValueSeries";
            //lineSeries.XValueType = ChartValueType.DateTime;
            lineSeries.ToolTip = "#VALY, #VALX";
            //Series.Add(valueSeries);
            //Size = new Size(420, 358);
            Text = "MainChart";
            MouseClick += ZoomedChart_MouseClick;
        }

      
        private void ZoomedChart_MouseClick(object sender, MouseEventArgs e)
        {
            var r = HitTest(e.X, e.Y);

            if (r.ChartElementType == ChartElementType.DataPoint)
            {
                Series lineSeries = Series.FirstOrDefault();
                DataPoint p = lineSeries.Points[r.PointIndex];
                //p.MarkerSize = 60;
                //p.BorderColor= Color.Red;

                //lineSeries.Points.Remove(p);
                OnClickPoint(new ClickPointEventArg(p, r.PointIndex));
                //p.Color=Color.Red;
                //int index = r.PointIndex;

                //CurrentCell = MainTable[1, index + 0];
            }
        }

        public void InitializeTSett()
        {
            var axisY = ChartAreas.FirstOrDefault().AxisY;
            var axisX = ChartAreas.FirstOrDefault().AxisX;
            var lineSeries = Series.FirstOrDefault();

            //gsett.LineColorDialog.ColorChanged += LineColorDialog_ColorChanged;
            //gsett.LineColorDialog.DataBindings.Add("SelectedColor",core.VSett, "GraphPointsColor", true, DataSourceUpdateMode.OnPropertyChanged);
            //gsett.LineColorDialog.DataBindings.Add(nameof(gsett.LineColorDialog.SelectedColor), lineSeries,
            //    nameof(lineSeries.Color),
            //    true, DataSourceUpdateMode.OnValidation);
            ////gsett.PointLimitComboBox.TextChanged += PointLimitComboBox_TextChanged;
            ////gsett.PointLimitComboBox.DataBindings.Add("Text", core.VSett, "DataItemsLimit", true, DataSourceUpdateMode.OnPropertyChanged);
            //gsett.PointLimitComboBox.DataBindings.Add(nameof(gsett.PointLimitComboBox.Text), this,
            //    nameof(PointsLimit),
            //    true, DataSourceUpdateMode.OnValidation);
            ////gsett.MaxYComboBox.DataBindings.Add("Text", core.VSett, "GraphYmax", true, DataSourceUpdateMode.OnPropertyChanged);
            //gsett.MaxYComboBox.DataBindings.Add(nameof(gsett.MaxYComboBox.Text), axisY, nameof(axisY.Maximum),
            //    true, DataSourceUpdateMode.OnValidation);
            ////gsett.MaxYComboBox.TextChanged += MaxYComboBox_TextChanged;
            ////gsett.MinYComboBox.DataBindings.Add("Text", core.VSett, "GraphYmin", true, DataSourceUpdateMode.OnPropertyChanged);
            //gsett.MinYComboBox.DataBindings.Add(nameof(gsett.MinYComboBox.Text), axisY, nameof(axisY.Minimum),
            //    true, DataSourceUpdateMode.OnValidation);
            ////gsett.MinYComboBox.TextChanged += MinYComboBox_TextChanged;
            ////gsett.StepYComboBox.DataBindings.Add("Text", core.VSett, "GraphYstep", true, DataSourceUpdateMode.OnPropertyChanged);
            //gsett.StepYComboBox.DataBindings.Add(nameof(gsett.StepYComboBox.Text), axisY, nameof(axisY.Interval),
            //    true, DataSourceUpdateMode.OnValidation);
            ////gsett.StepYComboBox.TextChanged += StepYComboBox_TextChanged;
            //gsett.AxisYDataFormat.DataBindings.Add(nameof(gsett.AxisYDataFormat.Text), this, nameof(LabelYFormat),
            //    true, DataSourceUpdateMode.OnValidation);
        }

      

        public void ZoomInitialize()
        {
            //AddedPoints += UDataChart_AddedPoints;
            MouseDown += ZoomedChart_MouseDown;
            MouseUp += ZoomedChart_MouseUp;
            MouseMove += ZoomedChart_MouseMove;
            MouseWheel += ZoomedChart_MouseWheel;
            PostPaint += ZoomedChart_PostPaint;
            grid = new Grid();
        }

        public virtual void Initial()
        {
            //mainArea = ChartAreas.FirstOrDefault();
            //valueSeries = Series.FirstOrDefault();
            bool isChartProperly = CheckChart();
            if (isChartProperly == false) return;

            DefaultSettings();
            InitializeTSett();

            ZoomInitialize();
        }

        private bool CheckChart()
        {
            return true;
        }



        #endregion

       


        #region Свойства


        public int PointsLimit { get; set; }



        #endregion

        public void YReset()
        {
            var axisY = ChartAreas.FirstOrDefault().AxisY;
            axisY.Maximum = double.NaN;

            axisY.Minimum = double.NaN;

            axisY.Interval = double.NaN;
        }

        public void XReset()
        {
            var axisX = ChartAreas.FirstOrDefault().AxisX;
            axisX.Maximum = double.NaN;

            axisX.Minimum = double.NaN;

            axisX.Interval = double.NaN;
        }

      

        #region Zoom

        private Grid grid;
        private readonly bool useGDI32 = false;

        private readonly bool useNiceRoundNumbers = false;

        //double piDiv180 = Math.PI / 180d;
        private enum zoomModeEnum
        {
            XY = 0,
            Y = 1,
            X = 2
        }


        private void ZoomedChart_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                Focus();
                if (e.Button == MouseButtons.Left && e.Clicks == 1 && (ModifierKeys & Keys.Control) != 0 &&
                    sender is Chart)
                {
                    zoomingNow = true;

                    switch (zoomMode)
                    {
                        case zoomModeEnum.XY:
                            zoomRect.Location = e.Location;
                            zoomRect.Width = zoomRect.Height = 0;
                            break;
                        case zoomModeEnum.Y:
                            var axX = ((Chart)sender).ChartAreas[0].AxisX;
                            zoomRect.Location = new Point((int)axX.ValueToPixelPosition(axX.Minimum), e.Y);
                            zoomRect.Height = 0;
                            zoomRect.Width = ((Chart)sender).ChartAreas[0].BorderWidth;
                            break;
                        case zoomModeEnum.X:
                            break;
                    }

                    DrawZoomRect();
                }

                //hand moving
                if (e.Button == MouseButtons.Left && e.Clicks == 1 && (ModifierKeys & Keys.Alt) != 0 &&
                    sender is Chart)
                {
                    handMovingNow = true;
                    handMovingInitPoint = e.Location;
                }
            }
            catch (Exception)
            {

             
            }
        }

        private void DrawZoomRect()
        {
            Pen pen = new Pen(Color.Black, 1.0f);
            pen.DashStyle = DashStyle.Dot;
            try
            {
                GDI32.DrawXORRectangle(CreateGraphics(), pen, zoomRect);
            }
            catch (Exception)
            {
            }
            //if (useGDI32)
            //{

            //    //GDI32.DrawXORRectangle(CreateGraphics(), pen, zoomRect);
            //}
            //else
            //{
            //    Rectangle screenRect = RectangleToScreen(zoomRect);
            //    ControlPaint.DrawReversibleFrame(zoomRect, BackColor, FrameStyle.Dashed);

            //    using (var g = CreateGraphics())
            //    {
            //        g.DrawRectangle(pen, zoomRect);
            //    }
            //}
        }
        private void ZoomedChart_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (zoomingNow)
                {
                    DrawZoomRect();
                    switch (zoomMode)
                    {
                        case zoomModeEnum.XY:
                            zoomRect.Width = e.X - zoomRect.Left;
                            zoomRect.Height = e.Y - zoomRect.Top;
                            break;
                        case zoomModeEnum.Y:
                            var axX = ((Chart)sender).ChartAreas[0].AxisX;
                            zoomRect.Width = (int)(axX.ValueToPixelPosition(axX.Maximum) -
                                axX.ValueToPixelPosition(axX.Minimum));
                            zoomRect.Height = e.Y - zoomRect.Top;
                            break;
                        case zoomModeEnum.X:
                            break;
                    }

                    DrawZoomRect();
                }

                if (handMovingNow)
                {
                    //var left;
                    //var right;
                    //var top;
                    //var bottom;
                    var axisY = ChartAreas.FirstOrDefault().AxisY;
                    var axisX = ChartAreas.FirstOrDefault().AxisX;
                    Cursor = Cursors.Hand;

                    var eX = e.X;
                    var initPointX = handMovingInitPoint.X;

                    var dxP = eX - initPointX;

                    var dxV = axisX.PixelPositionToValue(Math.Abs(dxP)) - axisX.PixelPositionToValue(0);

                    var eY = e.Y;
                    var initPointY = handMovingInitPoint.Y;

                    var dyP = eY - initPointY;

                    var dyV = axisY.PixelPositionToValue(Math.Abs(dyP)) - axisY.PixelPositionToValue(0);
                    //Debug.WriteLine(dxV);
                    //var area = ChartAreas.FirstOrDefault();
                    //var dy = (e.Y - handMovingInitPoint.Y);
                    //var eX = Math.Max(e.X, 0);
                    //eX = Math.Min(eX, 100);
                    //var eX = e.X;
                    //var eXValue = axisX.PixelPositionToValue(eX);
                    //var initPointX = Math.Max(handMovingInitPoint.X, 0);
                    //initPointX = Math.Min(initPointX, 100);
                    //var initPointX = handMovingInitPoint.X;

                    //var initPointXValue = axisX.PixelPositionToValue(initPointX);
                    //var dx = (eXValue - initPointXValue);
                    //SetZoomAxisScale(axisX, r.Left, r.Right);
                    //SetZoomAxisScale(axisY, r.Bottom, r.Top);
                    //SetAxis(axisY, axisY.Maximum - dyV * Math.Sign(dyP), axisY.Minimum - dyV * Math.Sign(dyP));
                    //SetAxis(axisX, axisX.Maximum - dxV * Math.Sign(dxP), axisX.Minimum - dxV * Math.Sign(dxP));

                    double yNewMax;
                    double yNewMin;
                    if (axisY.IsLogarithmic)
                    {
                        yNewMax = Math.Pow(10, axisY.ScaleView.ViewMaximum - dyV * Math.Sign(dyP));
                        yNewMin = Math.Pow(10, axisY.ScaleView.ViewMinimum - dyV * Math.Sign(dyP));
                        //xNewMin = Math.Max(1e-15, xNewMin);
                        //xNewMax = Math.Max(1e-15, xNewMax);
                        if (yNewMin < 1e-15 || yNewMax < 1e-15) { return; }
                        if (yNewMin >= (double)Decimal.MaxValue || yNewMax >= (double)Decimal.MaxValue) { return; }
                        axisY.Maximum = yNewMax;
                        axisY.Minimum = yNewMin;

                    }
                    else
                    {
                        yNewMax = axisY.Maximum - dyV * Math.Sign(dyP);
                        axisY.Maximum = yNewMax;
                        yNewMin = axisY.Minimum - dyV * Math.Sign(dyP);
                        axisY.Minimum = yNewMin;
                    }

                    double xNewMax;
                    double xNewMin;
                    if (axisX.IsLogarithmic)
                    {
                        xNewMax = Math.Pow(10, axisX.ScaleView.ViewMaximum - dxV * Math.Sign(dxP));
                        xNewMin = Math.Pow(10, axisX.ScaleView.ViewMinimum - dxV * Math.Sign(dxP));
                        //xNewMin = Math.Max(1e-15, xNewMin);
                        //xNewMax = Math.Max(1e-15, xNewMax);
                        if (xNewMin < 1e-15 || xNewMax < 1e-15) { return; }
                        if (xNewMin >= (double)Decimal.MaxValue || xNewMax >= (double)Decimal.MaxValue) { return; }
                        axisX.Maximum = xNewMax;
                        axisX.Minimum = xNewMin;

                    }
                    else
                    {
                        xNewMax = axisX.Maximum - dxV * Math.Sign(dxP);
                        axisX.Maximum = xNewMax;
                        xNewMin = axisX.Minimum - dxV * Math.Sign(dxP);
                        axisX.Minimum = xNewMin;
                    }




                    //axisX.Maximum = axisX.Maximum - Math.Pow(10, dxV )* Math.Sign(dxP);
                    //axisX.Minimum = axisX.Minimum - Math.Pow(10, dxV )* Math.Sign(dxP);
                    //double positionMinX = axisX.ValueToPixelPosition(axisX.Minimum) - dx;
                    //axisX.Minimum = axisX.PixelPositionToValue(positionMinX) ;
                    //double positionMaxX = axisX.ValueToPixelPosition(axisX.Maximum) - dx;
                    //axisX.Maximum = axisX.PixelPositionToValue(positionMaxX);
                    //double positionMinY = axisY.ValueToPixelPosition(axisY.Minimum) - dy;
                    //axisY.Minimum = axisY.PixelPositionToValue(positionMinY);
                    //double positionMaxY = axisY.ValueToPixelPosition(axisY.Maximum) - dy;
                    //axisY.Maximum = axisY.PixelPositionToValue(positionMaxY);

                    //axisX.Interval = 2000;
                    //axisY.Interval = 0.1;

                    //axisX.Minimum = axisX.Minimum.Round(2);
                    //axisX.Interval= axisX.ScaleView.ViewMaximum-
                    //axisY.Minimum = axisY.Minimum.Round(2);

                    handMovingInitPoint = e.Location;


                }
            }
            catch (Exception)
            {
                zoomingNow = false;
                handMovingNow = false;

            }
        }
        private void ZoomedChart_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (zoomingNow && e.Button == MouseButtons.Left)
                {
                    DrawZoomRect();
                    if (zoomRect.Width != 0 && zoomRect.Height != 0)
                    {
                        zoomRect = new Rectangle(Math.Min(zoomRect.Left, zoomRect.Right),
                            Math.Min(zoomRect.Top, zoomRect.Bottom), Math.Abs(zoomRect.Width),
                            Math.Abs(zoomRect.Height));
                        ZoomInToZoomRect();
                    }

                    zoomingNow = false;
                }

                if (handMovingNow && e.Button == MouseButtons.Left)
                {
                    Cursor = Cursors.Arrow;
                    handMovingNow = false;
                }
            }
            catch (Exception)
            {
                zoomingNow = false;
                handMovingNow = false;
            }
        }

        private void ZoomInToZoomRect()
        {
            if (zoomRect.Width == 0 || zoomRect.Height == 0)
                return;

            Rectangle r = zoomRect;

            //ChartScaleData csd = MainChart.Tag as ChartScaleData;
            //Get overlap of zoomRect and the innerPlotRectangle
            //Rectangle ipr = grid.AxisRectangle;
            //if (!r.IntersectsWith(ipr))
            //    return;
            //r.Intersect(ipr);
            //if (!csd.isZoomed)
            //{
            //    csd.isZoomed = true;
            //    csd.UpdateAxisBaseData();
            //}


            switch (zoomMode)
            {
                case zoomModeEnum.XY:
                    SetZoomAxisScale(ChartAreas[0].AxisX, r.Left, r.Right);
                    SetZoomAxisScale(ChartAreas[0].AxisY, r.Bottom, r.Top);
                    break;
                case zoomModeEnum.Y:
                    SetZoomAxisScale(ChartAreas[0].AxisY, r.Bottom, r.Top);
                    break;
                case zoomModeEnum.X:
                    break;
            }
        }

        private void SetZoomAxisScale(Axis axis, int pxLow, int pxHi)
        {
            double minValue;
            double maxValue;
            if (axis.IsLogarithmic)
            {
                minValue = Math.Max(axis.Minimum, Math.Pow(10, axis.PixelPositionToValue(pxLow)));
                maxValue = Math.Min(axis.Maximum, Math.Pow(10, axis.PixelPositionToValue(pxHi)));
            }
            else
            {
                minValue = Math.Max(axis.Minimum, axis.PixelPositionToValue(pxLow));
                maxValue = Math.Min(axis.Maximum, axis.PixelPositionToValue(pxHi));
            }
          
            double axisInterval = 0;
            double axisIntMinor = 0;
            if (useNiceRoundNumbers)
                GetNiceRoundNumbers(ref minValue, ref maxValue, ref axisInterval, ref axisIntMinor);
            else
                axisInterval = (maxValue - minValue) / 5d;

            axis.Minimum = minValue;
            axis.Maximum = maxValue;
            //axis.Interval = axisInterval;
            //axis.MinorTickMark.Interval = axisIntMinor;
            //SetAxisFormats();
        }

        private readonly double[] roundMantissa =
            {1.00d, 1.20d, 1.40d, 1.60d, 1.80d, 2.00d, 2.50d, 3.00d, 4.00d, 5.00d, 6.00d, 8.00d, 10.00d};

        private readonly double[] roundInterval =
            {0.20d, 0.20d, 0.20d, 0.20d, 0.20d, 0.50d, 0.50d, 0.50d, 0.50d, 1.00d, 1.00d, 2.00d, 2.00d};

        private readonly double[] roundIntMinor =
            {0.05d, 0.05d, 0.05d, 0.05d, 0.05d, 0.10d, 0.10d, 0.10d, 0.10d, 0.20d, 0.20d, 0.50d, 0.50d};

        private void GetNiceRoundNumbers(ref double minValue, ref double maxValue, ref double interval,
            ref double intMinor)
        {
            double min = Math.Min(minValue, maxValue);
            double max = Math.Max(minValue, maxValue);
            double delta = max - min; //The full range
            //Special handling for zero full range
            if (delta == 0)
            {
                //When min == max == 0, choose arbitrary range of 0 - 1
                if (min == 0)
                {
                    minValue = 0;
                    maxValue = 1;
                    interval = 0.2;
                    intMinor = 0.5;
                    return;
                }

                //min == max, but not zero, so set one to zero
                if (min < 0)
                    max = 0; //min-max are -|min| to 0
                else
                    min = 0; //min-max are 0 to +|max|
                delta = max - min;
            }

            int N = Base10Exponent(delta);
            double tenToN = Math.Pow(10, N);
            double A = delta / tenToN;
            //At this point delta = A x Exp10(N), where
            // 1.0 <= A < 10.0 and N = integer exponent value
            //Now, based on A select a nice round interval and maximum value
            for (int i = 0; i < roundMantissa.Length; i++)
                if (A <= roundMantissa[i])
                {
                    interval = roundInterval[i] * tenToN;
                    intMinor = roundIntMinor[i] * tenToN;
                    break;
                }

            minValue = interval * Math.Floor(min / interval);
            maxValue = interval * Math.Ceiling(max / interval);
        }

        private void GetNiceRoundNumbers2(ref double minValue, ref double maxValue, ref double interval,
            ref double intMinor)
        {
            string smax = maxValue.ToString(Format, CultureInfo.InvariantCulture);
            string smin = minValue.ToString(Format, CultureInfo.InvariantCulture);

            maxValue = smax.ToDouble();
            minValue = smin.ToDouble();
        }



        public int Base10Exponent(double num)
        {
            if (num == 0)
                return -int.MaxValue;
            return Convert.ToInt32(Math.Floor(Math.Log10(Math.Abs(num))));
        }

       

        private void ZoomedChart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            try
            {
                //grid.Refresh(ChartAreas[0].AxisX, ChartAreas[0].AxisY);
            }
            catch (Exception)
            {

              
            }
        }

        private void ZoomedChart_MouseWheel(object sender, MouseEventArgs e)
        {
            void Resize(bool isIncrease = true)
            {
                var axisY = ChartAreas.FirstOrDefault().AxisY;
                var axisX = ChartAreas.FirstOrDefault().AxisX;
                double ymax = axisY.ScaleView.ViewMaximum;
                double xmax = axisX.ScaleView.ViewMaximum;
                double ymin = axisY.ScaleView.ViewMinimum;
                double xmin = axisX.ScaleView.ViewMinimum;
                double delta = ymax - ymin;
                double deltaX = xmax - xmin;
                double ymouse = axisY.PixelPositionToValue(e.Location.Y);
                double xmouse = axisX.PixelPositionToValue(e.Location.X);
                double ycenter = (ymax + ymin) / 2;
                double xcenter = (xmax + xmin) / 2;
                //double procentymouse = mainArea.AxisY.GetPosition(e.Location.Y);
                //double rateWeight = (ymax - ymouse) / delta;
                double rate = 0.1;
                if (isIncrease)
                {
                    //double newShift = (ymouse-(ymax+ymin)/2)*(1+2*rate);


                    double newYmax = ymax - rate * delta;
                    double newXmax = xmax - rate * deltaX;
                    double newYmin = ymin + rate * delta;
                    double newXmin = xmin + rate * deltaX;
                    double newShift = ymouse - ycenter - (ymouse - ycenter) * (newYmax - ycenter) / (ymax - ycenter);
                    double newShiftX = xmouse - xcenter - (xmouse - xcenter) * (newXmax - xcenter) / (xmax - xcenter);
                    newYmax += newShift;
                    newYmin += newShift;
                    newXmax += newShiftX;
                    newXmin += newShiftX;
                    if (useNiceRoundNumbers)
                    {
                        double axisInterval = 0;
                        double axisIntMinor = 0;
                        GetNiceRoundNumbers2(ref newYmin, ref newYmax, ref axisInterval, ref axisIntMinor);
                        GetNiceRoundNumbers2(ref newXmin, ref newXmax, ref axisInterval, ref axisIntMinor);
                    }
                    else
                    {
                        if (newYmin >= newYmax) return;
                        if (newXmin >= newXmax) return;
                    }

                    //if (newYmin >= newYmax) return;

                    SetAxis(axisY, newYmax, newYmin);
                    SetAxis(axisX, newXmax, newXmin);
                }
                else
                {
                    double newYmax = ymax + rate * delta;
                    double newXmax = xmax + rate * deltaX;
                    double newYmin = ymin - rate * delta;
                    double newXmin = xmin - rate * deltaX;
                    double newShift = ymouse - ycenter - (ymouse - ycenter) * (newYmax - ycenter) / (ymax - ycenter);
                    double newShiftX = xmouse - xcenter - (xmouse - xcenter) * (newXmax - xcenter) / (xmax - xcenter);
                    newYmax += newShift;
                    newYmin += newShift;
                    newXmax += newShiftX;
                    newXmin += newShiftX;
                    if (useNiceRoundNumbers)
                    {
                        double axisInterval = 0;
                        double axisIntMinor = 0;
                        GetNiceRoundNumbers2(ref newYmin, ref newYmax, ref axisInterval, ref axisIntMinor);
                        GetNiceRoundNumbers2(ref newXmin, ref newXmax, ref axisInterval, ref axisIntMinor);
                    }
                    else
                    {
                        if (newYmin >= newYmax) return;
                        if (newXmin >= newXmax) return;
                    }

                    //if (newYmin >= newYmax) return;

                    SetAxis(axisY, newYmax, newYmin);
                    SetAxis(axisX, newXmax, newXmin);
                }
            }


            try
            {
                if (e.Delta > 0)
                    Resize();
                else if (e.Delta < 0) Resize(false);
            }
            catch (Exception)
            {
            }
        }

        private static void SetAxis(Axis axis, double newmax, double newmin)
        {
            if (axis.IsLogarithmic)
            {
                double max = Math.Pow(10, newmax);
                double min = Math.Pow(10, newmin);
                if (max <= 0 || min <= 0) return;
                if (max >= (double)Decimal.MaxValue || min >= (double)Decimal.MaxValue) return;
                if (max <= min) return;
                axis.Maximum = max;
                axis.Minimum = min;
            }
            else
            {
                axis.Maximum = newmax;
                axis.Minimum = newmin;
            }
           
        }

        private void ZoomedChart_MouseWheel3(object sender, MouseEventArgs e)
        {
            // Get the Chart control
            Chart chart = (Chart)sender;

            // Get the X and Y axis of the first chart area (assuming only one chart area exists)
            Axis xAxis = chart.ChartAreas[0].AxisX;
            Axis yAxis = chart.ChartAreas[0].AxisY;

            // Get the mouse wheel delta
            int delta = e.Delta;

            // Adjust the axis minimum and maximum values based on the mouse wheel delta
            if (delta > 0)
            {
                // Zoom in
                double zoomFactor = 0.1; // Adjust zoom factor as needed

                double xMin = xAxis.Minimum + (xAxis.Maximum - xAxis.Minimum) * zoomFactor;
                double xMax = xAxis.Maximum - (xAxis.Maximum - xAxis.Minimum) * zoomFactor;
                double yMin = yAxis.Minimum + (yAxis.Maximum - yAxis.Minimum) * zoomFactor;
                double yMax = yAxis.Maximum - (yAxis.Maximum - yAxis.Minimum) * zoomFactor;

                xAxis.Minimum = xMin;
                xAxis.Maximum = xMax;
                yAxis.Minimum = yMin;
                yAxis.Maximum = yMax;
            }
            else if (delta < 0)
            {
                // Zoom out
                double zoomFactor = 0.1; // Adjust zoom factor as needed

                double xMin = xAxis.Minimum - (xAxis.Maximum - xAxis.Minimum) * zoomFactor;
                double xMax = xAxis.Maximum + (xAxis.Maximum - xAxis.Minimum) * zoomFactor;
                double yMin = yAxis.Minimum - (yAxis.Maximum - yAxis.Minimum) * zoomFactor;
                double yMax = yAxis.Maximum + (yAxis.Maximum - yAxis.Minimum) * zoomFactor;

                xAxis.Minimum = xMin;
                xAxis.Maximum = xMax;
                yAxis.Minimum = yMin;
                yAxis.Maximum = yMax;
            }
        }
        private void ZoomedChart_MouseWheel2(object sender, MouseEventArgs e)
        {
            {
                // Get the Chart control
                Chart chart = (Chart)sender;

                // Get the X and Y axis of the first chart area (assuming only one chart area exists)
                Axis xAxis = chart.ChartAreas[0].AxisX;
                Axis yAxis = chart.ChartAreas[0].AxisY;

                // Get the mouse wheel delta
                int delta = e.Delta;

                // Adjust the axis scales based on the mouse wheel delta
                if (delta > 0)
                {
                    // Zoom in
                    xAxis.ScaleView.ZoomReset();
                    yAxis.ScaleView.ZoomReset();
                }
                else if (delta < 0)
                {
                    // Zoom out
                    double zoomFactor = 1.1; // Adjust zoom factor as needed
                    double xMin = xAxis.ScaleView.ViewMinimum;
                    double xMax = xAxis.ScaleView.ViewMaximum;
                    double yMin = yAxis.ScaleView.ViewMinimum;
                    double yMax = yAxis.ScaleView.ViewMaximum;

                    double posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / (2 * zoomFactor);
                    double posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / (2 * zoomFactor);
                    double posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / (2 * zoomFactor);
                    double posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / (2 * zoomFactor);

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
        }
        public struct GridStepStruct
        {
            public double X { get; set; }

            public double Y { get; set; }
        }

        public struct GridBordersStruct
        {
            public double MinX { get; set; }

            public double MinY { get; set; }

            public double MaxX { get; set; }

            public double MaxY { get; set; }
        }

        public class Grid
        {
            public Grid()
            {
            }

            public Grid(Axis AxX, Axis AxY)
            {
                AxisX = AxX;
                AxisY = AxY;
                GridBorders = new GridBordersStruct
                {
                    MinX = AxisX.ValueToPixelPosition(AxisX.Minimum),
                    MinY = AxisY.ValueToPixelPosition(AxisY.Minimum),
                    MaxX = AxisX.ValueToPixelPosition(AxisX.Maximum),
                    MaxY = AxisY.ValueToPixelPosition(AxisY.Maximum)
                };

                AxisRectangle = Rectangle.Round(new RectangleF((float)GridBorders.MinX, (float)GridBorders.MaxY,
                    (float)(GridBorders.MaxX - GridBorders.MinX), (float)(GridBorders.MinY - GridBorders.MaxY)));

                double StepX = AxisX.Interval;
                double StepY = AxisY.Interval;
                GridStep = new GridStepStruct
                {
                    X = AxisX.ValueToPixelPosition(AxisX.Minimum + StepX) - AxisX.ValueToPixelPosition(AxisX.Minimum),
                    Y = AxisY.ValueToPixelPosition(AxisY.Minimum) - AxisY.ValueToPixelPosition(AxisY.Minimum + StepY)
                };
                //GridStep.X = AxisX.ValueToPixelPosition(AxisX.Minimum + StepX) - AxisX.ValueToPixelPosition(AxisX.Minimum);
                //GridStep.Y = AxisY.ValueToPixelPosition(AxisY.Minimum) - AxisY.ValueToPixelPosition(AxisY.Minimum + StepY);
            }

            //public
            public GridBordersStruct GridBorders { get; set; }
            public GridStepStruct GridStep { get; set; }

            public Axis AxisX { get; set; }

            public Axis AxisY { get; set; }

            public Rectangle AxisRectangle { get; set; }

            public void Refresh(Axis AxX, Axis AxY)
            {
                AxisX = AxX;
                AxisY = AxY;
                GridBorders = new GridBordersStruct
                {
                    MinX = AxisX.ValueToPixelPosition(AxisX.Minimum),
                    MinY = AxisY.ValueToPixelPosition(AxisY.Minimum),
                    MaxX = AxisX.ValueToPixelPosition(AxisX.Maximum),
                    MaxY = AxisY.ValueToPixelPosition(AxisY.Maximum)
                };
                AxisRectangle = Rectangle.Round(new RectangleF((float)GridBorders.MinX, (float)GridBorders.MaxY,
                    (float)(GridBorders.MaxX - GridBorders.MinX), (float)(GridBorders.MinY - GridBorders.MaxY)));
                double StepX = AxisX.Interval;
                double StepY = AxisY.Interval;
                GridStep = new GridStepStruct
                {
                    X = AxisX.ValueToPixelPosition(AxisX.Minimum + StepX) - AxisX.ValueToPixelPosition(AxisX.Minimum),
                    Y = AxisY.ValueToPixelPosition(AxisY.Minimum) - AxisY.ValueToPixelPosition(AxisY.Minimum + StepY)
                };
                //GridStep.X = AxisX.ValueToPixelPosition(AxisX.Minimum + StepX) - AxisX.ValueToPixelPosition(AxisX.Minimum);
                //GridStep.Y = AxisY.ValueToPixelPosition(AxisY.Minimum) - AxisY.ValueToPixelPosition(AxisY.Minimum + StepY);
            }
        }

        //private class XY
        //{
        //    public XY(DateTime x, double y)
        //    {
        //        X = x;
        //        Y = y;
        //    }

        //    public DateTime X { get; }
        //    public double Y { get; }
        //}

        #endregion


        public void CreateLineExample1()
        {
            var lineSeries = Series.FirstOrDefault();
            var rnd = new Random();

            for(int i= 0; i < 100; i++)
            {
                lineSeries.Points.AddXY(i, rnd.NextDouble());
            }
        }
        public void CreateLineExampleLog(int imax=100)
        {
            var lineSeries = Series.FirstOrDefault();
            var rnd = new Random();

            for (int i = 1; i < imax; i++)
            {
                lineSeries.Points.AddXY(Math.Pow(1.1,i), rnd.NextDouble());
            }
        }
    }

   
    
}