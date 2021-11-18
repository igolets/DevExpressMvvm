using Cso.IfnsExporter.Services.Impl;
using Cso.IfnsExporter.ViewModels;
using JetBrains.Annotations;

namespace Cso.IfnsExporter.Views
{
    [UsedImplicitly]
    public partial class ReportParamsView : DevExpress.XtraEditors.XtraUserControl
    {
        public ReportParamsView()
        {
            InitializeComponent();
            _bindingService = new BindingSourceService(bsDepartments);
            if (!mvvmContext1.IsDesignMode)
            {
                InitializeBindings();
            }
        }

        private void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<ReportParamsViewModel>();
            mvvmContext1.RegisterService(_bindingService);
            fluent.SetBinding(deDateFrom, edit => edit.DateTime, model => model.DateFrom);
            fluent.SetBinding(deDateTo, edit => edit.DateTime, model => model.DateTo);
            fluent.SetBinding(bsDepartments, source => source.DataSource, model => model.DeptModels);
            fluent.SetBinding(ceAll, edit => edit.CheckState, model => model.AllDeptsCheckedState);
        }

        private readonly BindingSourceService _bindingService;
    }
}
