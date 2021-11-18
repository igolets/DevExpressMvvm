using System.Windows.Forms;

namespace Cso.IfnsExporter.Services.Impl
{
    public class BindingSourceService : IBindingSourceService
    {
        private readonly BindingSource _bindingSource;

        public BindingSourceService(BindingSource bindingSource)
        {
            _bindingSource = bindingSource;
        }

        /// <inheritdoc />
        public void ResetBindings()
        {
            _bindingSource.ResetBindings(false);
        }
    }
}