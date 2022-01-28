namespace UControlLibrary.Menus
{
    public sealed class DataCollectorStatusLabel : BindableStripStatusLabel
    {
        public string labelHead = "###";
        public string labelValue = "___";

        public string LabelHead
        {
            get => labelHead;
            set
            {
                labelHead = value;
                Text = SetText();
            }
        }

        public string LabelValue
        {
            get => labelValue;
            set
            {
                labelValue = value;
                Text = SetText();
            }
        }


        public void SetLabelHead(string h)
        {
            LabelHead = h;
            Text = SetText();
        }

        public void SetLabelValue(string v)
        {
            LabelValue = v;
            Text = SetText();
        }
        public void SetLabelValue(int v)
        {
            LabelValue = v.ToString();
            Text = SetText();
        }
        private string SetText()
        {
            return $@"{LabelHead}: {LabelValue}";
        }
    }
}