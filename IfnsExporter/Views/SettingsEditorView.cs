using System.Drawing;
using Cso.IfnsExporter.ViewModels;
using DevExpress.Mvvm;
using JetBrains.Annotations;

namespace Cso.IfnsExporter.Views
{
    [UsedImplicitly]
    public partial class SettingsEditorView : DevExpress.XtraEditors.XtraUserControl
    {
        public SettingsEditorView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
            {
                InitializeBindings();
            }
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<SettingsEditorViewModel>();

            fluent.SetBinding(teИННЮЛ, edit => edit.Text, model => model.ИННЮЛ);
            fluent.SetBinding(teКПП, edit => edit.Text, model => model.КПП);
            fluent.SetBinding(teНаимОрг, edit => edit.Text, model => model.НаимОрг);
            fluent.SetBinding(teКодНО, edit => edit.Text, model => model.КодНО);
            fluent.SetBinding(teКНД, edit => edit.Text, model => model.КНД);
            fluent.SetBinding(teПодписантТлф, edit => edit.Text, model => model.ПодписантТлф);
            fluent.SetBinding(teПодписантОтчество, edit => edit.Text, model => model.ПодписантОтчество);
            fluent.SetBinding(teПодписантИмя, edit => edit.Text, model => model.ПодписантИмя);
            fluent.SetBinding(teПодписантФамилия, edit => edit.Text, model => model.ПодписантФамилия);
            fluent.SetBinding(teConnectionString, edit => edit.Text, model => model.ConnectionString);
            fluent.SetBinding(teOperationName, edit => edit.Text, model => model.OperationName);
            fluent.SetBinding(teЗаменаНомерДоговора, edit => edit.Text, model => model.ЗаменаНомерДоговора);
            fluent.SetBinding(teКодОпер, edit => edit.Text, model => model.КодОпер);
            fluent.SetBinding(
                lblChars,
                label => label.Text,
                model => model.OperationNameChars,
                s => $"Символов: {s}");
            fluent.SetBinding(
                lblChars,
                label => label.ForeColor,
                model => model.OperationNameChars,
                x => x <= 40 ? Color.Empty : Color.Red);

            var cmd = new DelegateCommand(
                () =>
                {
                    fluent.ViewModel.GetExcelTemplate();
                });
            sbGetExcelTemplate.BindCommand(cmd);
        }
    }
}
