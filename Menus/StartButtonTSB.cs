using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UControlLibrary.Properties;

namespace UControlLibrary.Menus
{
    public sealed class StartButtonTSB : ToolStripButton, IBindableComponent
    {
        public enum MeasModeEnum
        {
            Play = 1,
            Stop = 2
        }

        private MeasModeEnum measMode = MeasModeEnum.Stop;

        public StartButtonTSB()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Image;
            Enabled = false;
            Image = Resource1.Start_Button;
            ImageTransparentColor = Color.Magenta;
            Name = "start_Button";
            Size = new Size(23, 22);
            Text = "Запуск";
        }

        public MeasModeEnum MeasMode
        {
            get => measMode;
            set
            {
                MeasModeEnum t = value;
                if (t == MeasModeEnum.Stop) Image = Resource1.Start_Button;
                if (t == MeasModeEnum.Play) Image = Resource1.Stop_Button;
                measMode = t;
            }
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

