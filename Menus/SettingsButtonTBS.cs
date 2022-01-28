using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UControlLibrary.Properties;

namespace UControlLibrary.Menus
{
    public sealed class SettingsButtonTBS : ToolStripButton, IBindableComponent
    {

        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainMenu));

        public SettingsButtonTBS()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Image;
            Enabled = true;
            //Image  = ((Image)(resources.GetObject("save_Button.Image")));
            Image = Resource1.Setting_Button;
            ImageTransparentColor = Color.Magenta;
            Name = "setting_Button";
            Size = new Size(23, 22);
            Text = @"Настройки";
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
