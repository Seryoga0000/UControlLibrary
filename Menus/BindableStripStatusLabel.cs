using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UControlLibrary.Properties;

namespace UControlLibrary.Menus
{
    public class BindableStripStatusLabel : ToolStripStatusLabel, IBindableComponent
    {
      
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
