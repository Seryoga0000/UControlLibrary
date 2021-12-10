using ExtensionLib;
using NLog;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UControlLibrary
{
    public class UDataChart : Chart, INotifyPropertyChanged
    {
        private const string Format = "0.00E+00";
        private readonly zoomModeEnum zoomMode = zoomModeEnum.XY;
        private ContextMenuStrip graphContextMenu;
        private GraphSettingsForm gsett;
        private string labelYFormat;
        private Color lineColor;
   
        private double maxY = double.NaN;
        private double minY = double.NaN;
        private double stepY = double.NaN;
        private double maxX = double.NaN;
        private double minX = double.NaN;
        private double stepX = double.NaN;
        private ToolStripMenuItem resetAxisScaleToAuto;
        private ToolStripMenuItem showGraphSettingsForm;
        
        
        private bool zoomingNow;
        private Rectangle zoomRect;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler AddedPoints;
        public event EventHandler<ClickPointEventArg> ClickPoint;


        #region Очищение точек

        public void PointsClear()
        {
            //Log.Trace("PointsClear()");

            var points = Series.FirstOrDefault().Points;
            points?.Clear();
        }

        #endregion

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            //Log.Trace($"OnPropertyChanged()_propertyName={propertyName}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Конструктор

        public void DefaultSettings()
        {
            BackColor = Color.White;
            var axisY = ChartAreas.FirstOrDefault().AxisY;
            var axisX = ChartAreas.FirstOrDefault().AxisX;
            var area = ChartAreas.FirstOrDefault();
            var lineSeries = Series.FirstOrDefault();
            axisX.IsLabelAutoFit = false;
            axisX.IsLabelAutoFit = false;
            axisX.IsStartedFromZero = false;
            axisX.LabelStyle.Angle = -30;
            axisX.LabelStyle.Format = "{0:d/MMM HH:mm}";
            Legends.Clear();
            axisX.LabelStyle.IntervalType = DateTimeIntervalType.Auto;
            axisX.MajorGrid.IntervalType = DateTimeIntervalType.Auto;
            axisX.MajorGrid.LineColor = Color.Gray;
            axisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            axisY.IsStartedFromZero = false;
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
            lineSeries.XValueType = ChartValueType.DateTime;
            lineSeries.ToolTip = "#VALY, #VALX";
            //Series.Add(valueSeries);
            //Size = new Size(420, 358);
            Text = "MainChart";
            MouseClick += UDataChart_MouseClick;
            ;
        }

        private void UDataChart_MouseClick(object sender, MouseEventArgs e)
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
            gsett = new GraphSettingsForm(this);
            //gsett.LineColorDialog.ColorChanged += LineColorDialog_ColorChanged;
            //gsett.LineColorDialog.DataBindings.Add("SelectedColor",core.VSett, "GraphPointsColor", true, DataSourceUpdateMode.OnPropertyChanged);
            gsett.LineColorDialog.DataBindings.Add(nameof(gsett.LineColorDialog.SelectedColor), lineSeries,
                nameof(lineSeries.Color),
                true, DataSourceUpdateMode.OnValidation);
            //gsett.PointLimitComboBox.TextChanged += PointLimitComboBox_TextChanged;
            //gsett.PointLimitComboBox.DataBindings.Add("Text", core.VSett, "DataItemsLimit", true, DataSourceUpdateMode.OnPropertyChanged);
            gsett.PointLimitComboBox.DataBindings.Add(nameof(gsett.PointLimitComboBox.Text), this,
                nameof(PointsLimit),
                true, DataSourceUpdateMode.OnValidation);
            //gsett.MaxYComboBox.DataBindings.Add("Text", core.VSett, "GraphYmax", true, DataSourceUpdateMode.OnPropertyChanged);
            gsett.MaxYComboBox.DataBindings.Add(nameof(gsett.MaxYComboBox.Text), axisY, nameof(axisY.Maximum),
                true, DataSourceUpdateMode.OnValidation);
            //gsett.MaxYComboBox.TextChanged += MaxYComboBox_TextChanged;
            //gsett.MinYComboBox.DataBindings.Add("Text", core.VSett, "GraphYmin", true, DataSourceUpdateMode.OnPropertyChanged);
            gsett.MinYComboBox.DataBindings.Add(nameof(gsett.MinYComboBox.Text), axisY, nameof(axisY.Minimum),
                true, DataSourceUpdateMode.OnValidation);
            //gsett.MinYComboBox.TextChanged += MinYComboBox_TextChanged;
            //gsett.StepYComboBox.DataBindings.Add("Text", core.VSett, "GraphYstep", true, DataSourceUpdateMode.OnPropertyChanged);
            gsett.StepYComboBox.DataBindings.Add(nameof(gsett.StepYComboBox.Text), axisY, nameof(axisY.Interval),
                true, DataSourceUpdateMode.OnValidation);
            //gsett.StepYComboBox.TextChanged += StepYComboBox_TextChanged;
            gsett.AxisYDataFormat.DataBindings.Add(nameof(gsett.AxisYDataFormat.Text), this, nameof(LabelYFormat),
                true, DataSourceUpdateMode.OnValidation);
        }

        public void ContextMenuSettings()
        {
            showGraphSettingsForm = new ToolStripMenuItem();
            showGraphSettingsForm.Name = "ShowGraphSettingsForm";
            showGraphSettingsForm.Text = "Настройки";
            //showGraphSettingsForm.Image = Properties.Resources.settings;
            showGraphSettingsForm.Click += ShowGraphSettingsForm_Click;
            ;

            resetAxisScaleToAuto = new ToolStripMenuItem();
            resetAxisScaleToAuto.Name = "ResetAxisScaleToAuto";
            resetAxisScaleToAuto.Text = "АвтоМасштаб";
            resetAxisScaleToAuto.Click += ResetAxisScaleToAuto_Click;
            ;

            graphContextMenu = new ContextMenuStrip();
            graphContextMenu.Items.AddRange(new ToolStripItem[]
            {
                showGraphSettingsForm,
                resetAxisScaleToAuto
            });
            graphContextMenu.Name = "GraphContextMenu";
            ContextMenuStrip = graphContextMenu;
        }

        public void ZoomInitialize()
        {
            //AddedPoints += UDataChart_AddedPoints;
            MouseDown += UDataChart_MouseDown;
            MouseUp += UDataChart_MouseUp;
            MouseMove += UDataChart_MouseMove;
            MouseWheel += UDataChart_MouseWheel;
            PostPaint += UDataChart_PostPaint;
            grid = new Grid();
        }

        public void Initial()
        {
            //mainArea = ChartAreas.FirstOrDefault();
            //valueSeries = Series.FirstOrDefault();
            DefaultSettings();
            InitializeTSett();
            ContextMenuSettings();
            ZoomInitialize();
        }

        public UDataChart()
        {
            #region Логирование

            Log = LogManager.GetCurrentClassLogger();

            #endregion


            //Log.Trace("UDataChart()_DefaultSettings()");
            //DefaultSettings();

            //Log.Trace("UDataChart()_InitializeTSett()");


            //InitializeTSett();


            //Log.Trace("UDataChart()_ContextMenuSettings()");
            //ContextMenuSettings();


            //Log.Trace("UDataChart()_ZoomInitialize()");
            //ZoomInitialize();

            //YReset();
        }

        #endregion

        #region Поля

        #endregion


        #region Свойства

        public Logger Log { get; set; }

        //public Color LineColor
        //{
        //    get => lineColor;
        //    set
        //    {
        //        lineColor = value;
        //        if (valueSeries != null) valueSeries.Color = value;
        //    }
        //}

        public int PointsLimit { get; set; }

        //[TypeConverter(typeof(DoubleToString))]

        public string LabelYFormat
        {
            get => labelYFormat;
            set
            {
                labelYFormat = value;
                OnPropertyChanged(nameof(LabelYFormat));
            }
        }


        //private void SetLineColor(Color value)
        //{
        //    valueSeries.Color = value;
        //    if(gsett.LineColorDialog.SelectedColor != value)
        //    gsett.LineColorDialog.SelectedColor = value;
        //}


        //private void SetDataItemsLimit(int value)
        //{
        //    if(gsett.PointLimitComboBox.Text != value.ToString())
        //    gsett.PointLimitComboBox.Text = value.ToString();
        //}

        //private void SetStepY(double value)
        //{
        //    if (gsett.StepYComboBox.Text != value.ToString())
        //        gsett.StepYComboBox.Text = value.ToString();
        //}
        //private void SetMinY(double value)
        //{
        //    if (gsett.MinYComboBox.Text != value.ToString())
        //        gsett.MinYComboBox.Text = value.ToString();
        //}
        //private void SetMaxY(double value)
        //{
        //    if (gsett.MaxYComboBox.Text != value.ToString())
        //        gsett.MaxYComboBox.Text = value.ToString();
        //}

        #endregion

        #region ОбработчикиСобытийОкнаНастроек

        //private void PointLimitComboBox_TextChanged(object sender, EventArgs e)
        //{
        //    core.VSett.DataItemsLimit = gsett.PointLimit;
        //}

        //private void LineColorDialog_ColorChanged(object sender, EventArgs e)
        //{
        //    UColorDialog s = (UColorDialog)sender;
        //    if (s == null) return;
        //    core.VSett.GraphPointsColor = s.SelectedColor;
        //}

        //private void StepYComboBox_TextChanged(object sender, EventArgs e)
        //{
        //   core.VSett.GraphYstep = gsett.YStep;
        //}

        //private void MinYComboBox_TextChanged(object sender, EventArgs e)
        //{
        //    core.VSett.GraphYmin = gsett.YMin;
        //}

        //private void MaxYComboBox_TextChanged(object sender, EventArgs e)
        //{
        //    core.VSett.GraphYmax = gsett.YMax;
        //}

        #endregion

        #region КонтекстноеМеню

        private void ShowGraphSettingsForm_Click(object sender, EventArgs e)
        {
            gsett.Show();
        }

        private void ResetAxisScaleToAuto_Click(object sender, EventArgs e)
        {
            YReset();
            XReset();
        }

        private void YReset()
        {
            var axisY = ChartAreas.FirstOrDefault().AxisY;
            axisY.Maximum = double.NaN;

            axisY.Minimum = double.NaN;

            axisY.Interval = double.NaN;
          
        }
        private void XReset()
        {
            var axisX = ChartAreas.FirstOrDefault().AxisX;
            axisX.Maximum = double.NaN;

            axisX.Minimum = double.NaN;

            axisX.Interval = double.NaN;
        }

        #endregion

     

        #region ДобавлениеТочки

        //private void UDataChart_AddedPoints(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Log.Trace("UDataChart_AddedPoints_PointLimitChecking()");
        //        PointLimitChecking();
        //    }
        //    catch (Exception exception)
        //    {
        //        Log.Error(exception);
        //    }
        //}

        //private void PointLimitChecking()
        //{
        //    Log.Trace("PointLimitChecking()");

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


        private void UDataChart_MouseDown(object sender, MouseEventArgs e)
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
                        var axX = ((Chart) sender).ChartAreas[0].AxisX;
                        zoomRect.Location = new Point((int) axX.ValueToPixelPosition(axX.Minimum), e.Y);
                        zoomRect.Height = 0;
                        zoomRect.Width = ((Chart) sender).ChartAreas[0].BorderWidth;
                        break;
                    case zoomModeEnum.X:
                        break;
                }

                DrawZoomRect();
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

        private void UDataChart_MouseUp(object sender, MouseEventArgs e)
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
        }

        private void ZoomInToZoomRect()
        {
            if (zoomRect.Width == 0 || zoomRect.Height == 0)
                return;

            Rectangle r = zoomRect;

            //ChartScaleData csd = MainChart.Tag as ChartScaleData;
            //Get overlap of zoomRect and the innerPlotRectangle
            Rectangle ipr = grid.AxisRectangle;
            if (!r.IntersectsWith(ipr))
                return;
            r.Intersect(ipr);
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
            double minValue = Math.Max(axis.Minimum, axis.PixelPositionToValue(pxLow));
            double maxValue = Math.Min(axis.Maximum, axis.PixelPositionToValue(pxHi));
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

        private void UDataChart_MouseMove(object sender, MouseEventArgs e)
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
                        var axX = ((Chart) sender).ChartAreas[0].AxisX;
                        zoomRect.Width = (int) (axX.ValueToPixelPosition(axX.Maximum) -
                                                axX.ValueToPixelPosition(axX.Minimum));
                        zoomRect.Height = e.Y - zoomRect.Top;
                        break;
                    case zoomModeEnum.X:
                        break;
                }

                DrawZoomRect();
            }
        }

        private void UDataChart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            grid.Refresh(ChartAreas[0].AxisX, ChartAreas[0].AxisY);
        }

        private void UDataChart_MouseWheel(object sender, MouseEventArgs e)
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

                    axisY.Maximum = newYmax;
                    axisY.Minimum = newYmin;
                    axisX.Maximum = newXmax;
                    axisX.Minimum = newXmin;
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

                    axisY.Maximum = newYmax;
                    axisY.Minimum = newYmin;
                    axisX.Maximum = newXmax;
                    axisX.Minimum = newXmin;
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

                AxisRectangle = Rectangle.Round(new RectangleF((float) GridBorders.MinX, (float) GridBorders.MaxY,
                    (float) (GridBorders.MaxX - GridBorders.MinX), (float) (GridBorders.MinY - GridBorders.MaxY)));

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
                AxisRectangle = Rectangle.Round(new RectangleF((float) GridBorders.MinX, (float) GridBorders.MaxY,
                    (float) (GridBorders.MaxX - GridBorders.MinX), (float) (GridBorders.MinY - GridBorders.MaxY)));
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

        protected virtual void OnClickPoint(ClickPointEventArg e)
        {
            ClickPoint?.Invoke(this, e);
        }
    }

    public class ClickPointEventArg:EventArgs
    {
        private DataPoint p;
        private int n;

        public ClickPointEventArg(DataPoint p, int n)
        {
            this.p = p;
            this.n = n;
        }

        public DataPoint P => p;

        public int N => n;
    }

    public static class GDI32
    {
        public enum DrawingMode
        {
            R2_NOTXORPEN = 10
        }

        [DllImport("gdi32.dll")]
        public static extern bool Rectangle(IntPtr hDC, int left, int top, int right, int bottom);

        [DllImport("gdi32.dll")]
        public static extern int SetROP2(IntPtr hDC, int fnDrawMode);

        [DllImport("gdi32.dll")]
        public static extern bool MoveToEx(IntPtr hDC, int x, int y, ref Point p);

        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr hdc, int x, int y);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, int crColor);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObj);

        static private Point nullPoint = new Point(0, 0);

        // Convert the Argb from .NET to a gdi32 RGB
        static private int ArgbToRGB(int rgb)
        {
            return ((rgb >> 16 & 0x0000FF) | (rgb & 0x00FF00) | (rgb << 16 & 0xFF0000));
        }
        static public void DrawXORRectangle(Graphics graphics, Pen pen, Rectangle rectangle)
        {
            IntPtr hDC = graphics.GetHdc();
            IntPtr hPen = CreatePen((int)pen.DashStyle, (int)pen.Width, ArgbToRGB(pen.Color.ToArgb()));
            SelectObject(hDC, hPen);
            SetROP2(hDC, (int)GDI32.DrawingMode.R2_NOTXORPEN);
            Rectangle(hDC, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            DeleteObject(hPen);
            graphics.ReleaseHdc(hDC);
        }

        static public void DrawXORLine(Graphics graphics, Pen pen, int x1, int y1, int x2, int y2)
        {
            IntPtr hDC = graphics.GetHdc();
            IntPtr hPen = CreatePen((int)pen.DashStyle, (int)pen.Width, ArgbToRGB(pen.Color.ToArgb()));
            SelectObject(hDC, hPen);
            SetROP2(hDC, (int)GDI32.DrawingMode.R2_NOTXORPEN);
            MoveToEx(hDC, x1, y1, ref nullPoint);
            LineTo(hDC, x2, y2);
            DeleteObject(hPen);
            graphics.ReleaseHdc(hDC);
        }
    }
}