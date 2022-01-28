using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UControlLibrary.Properties;

namespace UControlLibrary.Menus
{
    public sealed class TimerIntervalListTSC : ToolStripComboBox, IBindableComponent
    {

        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainMenu));

        public TimerIntervalListTSC()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Image;
            Enabled = true;
            //Image  = ((Image)(resources.GetObject("save_Button.Image")));
            //Image = Resource1.Save_Button;
            ImageTransparentColor = Color.Magenta;
            Name = "timerIntList";
            Size = new Size(50, 23);
            Text = @"1000";
            Items.AddRange(new object[] {
                "1000",
                "5000",
                "10000",
                "20000",
                "50000",
                "100000"
            });
        }
        
        #region IBindableComponent Members

        private BindingContext bindingContext;

        private ControlBindingsCollection dataBindings;

        [Browsable(false)]
        public BindingContext BindingContext
        {
            get
            {
                if (bindingContext == null) bindingContext = new BindingContext();
                return bindingContext;
            }

            set => bindingContext = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (dataBindings == null) dataBindings = new ControlBindingsCollection(this);
                return dataBindings;
            }
            set => dataBindings = value;
        }

        #endregion
    }
}
