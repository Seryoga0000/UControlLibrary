using System.Windows.Forms;
using UControlLibrary.Menus;
using UControlLibrary.Properties;

namespace UControlLibrary.Menus
{
    public class DataCollectorStatusPanel : StatusStrip
    {
        //private ToolStrip mainToolStrip;

        private DataCollectorStatusLabel timeLabel = new DataCollectorStatusLabel();

        private DataCollectorStatusLabel timerLabel = new DataCollectorStatusLabel();

        private DataCollectorStatusLabel counterLabel = new DataCollectorStatusLabel();
        private ToolStripStatusLabel sep1 = new ToolStripStatusLabel()
        {
            Text = @""
        };
        private ToolStripStatusLabel sep2 = new ToolStripStatusLabel()
        {
            Text = @"| "
        };
        private ToolStripStatusLabel sep3 = new ToolStripStatusLabel()
        {
            Text = @"| "
        };
        public DataCollectorStatusLabel TimeLabel => timeLabel;

        public DataCollectorStatusLabel TimerLabel => timerLabel;

        public DataCollectorStatusLabel CounterLabel => counterLabel;


        public void Initial()
        {
            TimeLabel.SetLabelHead(@"Время");
            TimerLabel.SetLabelHead(@"Таймер");
            CounterLabel.SetLabelHead(@"Счетчик");

            #region AddElements
            Items.Add(TimeLabel);
            Items.Add(sep2);
            Items.Add(TimerLabel);
            Items.Add(sep3);
            Items.Add(CounterLabel);
            #endregion
        }

     
    }
}
