using System.Windows.Forms;
using UControlLibrary.Menus;
using UControlLibrary.Properties;

namespace UControlLibrary.Menus
{
    public class DataCollectorStripPanel : ToolStrip
    {
        //private ToolStrip mainToolStrip;
        private StartButtonTSB start_Button = new StartButtonTSB();
        //private ToolStripButton stop_Button;
        private SettingsButtonTBS setting_Button = new SettingsButtonTBS();
        private SaveButtonTBS save_Button = new SaveButtonTBS();
        private ExcelButtonTBS excel_Button = new ExcelButtonTBS();
        private OpenButtonTBS openDataFolder = new OpenButtonTBS();
        private ToolStripSeparator toolStripSeparator1 = new ToolStripSeparator();
        private ToolStripLabel toolStripLabel2 = new ToolStripLabel();
        private TimerIntervalListTSC timerIntList = new TimerIntervalListTSC();
        private ToolStripLabel intervalLabel = new ToolStripLabel()
        {
            Text=@"Интервал"
        };
        private ToolStripSeparator toolStripSeparator2 = new ToolStripSeparator();
        private ToolStripSeparator toolStripSeparator3 = new ToolStripSeparator();
        private ToolStripButton toolStripTopMost = new ToolStripButton();

        


        public void Initial()
        {
            #region AddElements
            Items.Add(StartButton);
            Items.Add(SettingButton);
            Items.Add(save_Button);
            Items.Add(ExcelButton);
            Items.Add(OpenDataFolder);
            Items.Add(toolStripSeparator1);
            //Items.Add(toolStripLabel2);
            //Items.Add(toolStripSeparator2);
            Items.Add(IntervalLabel);
            Items.Add(TimerIntList);
            Items.Add(toolStripSeparator3);
            Items.Add(toolStripTopMost);
            #endregion
        }

        public StartButtonTSB StartButton => start_Button;
        
        public SettingsButtonTBS SettingButton => setting_Button;

        public ExcelButtonTBS ExcelButton => excel_Button;

        public ToolStripLabel IntervalLabel => intervalLabel;

        public TimerIntervalListTSC TimerIntList => timerIntList;

        public OpenButtonTBS OpenDataFolder => openDataFolder;
    }
}
