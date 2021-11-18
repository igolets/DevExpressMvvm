using System.Linq;
using Cso.IfnsExporter.Models;
using Cso.IfnsExporter.Services.Impl;
using Cso.IfnsExporter.ViewModels;
using DevExpress.Utils.MVVM.Services;

namespace Cso.IfnsExporter.Views
{
    public partial class MainView : DevExpress.XtraEditors.XtraForm
    {
        public MainView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
            {
                _shellService = new ShellService();
                InitializeBindings();
            }
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
            mvvmContext1.RegisterDefaultService(DialogService.CreateXtraDialogService(this));
            mvvmContext1.RegisterService(_shellService);

            fluent.BindCommand(bbiLoadFromDb, model => model.LoadFromDb());
            fluent.BindCommand(bbiLoadExcel,model => model.LoadExcel());
            fluent.BindCommand(bbiSaveXml,model => model.SaveXml());
            fluent.BindCommand(bbiSaveExcel,model => model.SaveExcel());
            fluent.BindCommand(bbiSettings, model => model.ShowSettings());
            fluent.BindCommand(bbiClearData, model=>model.ClearData());

            riPeriod.Items.AddRange(MainViewModel.Periods.OfType<object>().ToArray());

            fluent.SetBinding(beiReqNumber, editItem => editItem.EditValue, model => model.ReqNumber);
            fluent.SetBinding(modelBindingSource, source => source.DataSource, model => model.GridData);
            fluent.SetBinding(beiYear, editItem => editItem.EditValue, model => model.Year);
            fluent.SetBinding(
                beiPeriod,
                dst => dst.EditValue,
                model => model.SelectedPeriod,
                code =>
                {
                    return MainViewModel.Periods.Single(x => x.PriodCode == code);
                },
                o => ((PriodItemModel)o).PriodCode);
        }

        private readonly ShellService _shellService;
    }
}
