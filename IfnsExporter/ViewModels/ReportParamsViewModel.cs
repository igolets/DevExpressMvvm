using System;
using System.Linq;
using System.Windows.Forms;
using Cso.IfnsExporter.Models;
using Cso.IfnsExporter.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Utils.Extensions;
using JetBrains.Annotations;

namespace Cso.IfnsExporter.ViewModels
{
    [POCOViewModel]
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class ReportParamsViewModel : ViewModelBase
    {
        #region Constructors

        public ReportParamsViewModel(DateTime dateFrom, DateTime dateTo, SelectDepartmentModel[] deptModels)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            DeptModels = deptModels;

            foreach (var model in deptModels)
            {
                model.PropertyChanged += DeptModelPropertyChanged;
                model.IsChecked = true;
            }

            _allDeptsCheckedState = CheckState.Checked;
        }

        #endregion

        #region Public properties

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public SelectDepartmentModel[] DeptModels { get; set; }

        public CheckState AllDeptsCheckedState
        {
            get => _allDeptsCheckedState;
            set
            {
                _allDeptsCheckedState = value;
                switch (value)
                {
                    case CheckState.Unchecked:
                        DeptModels.ForEach(x => x.IsChecked = false);
                        BsService?.ResetBindings();
                        break;
                    case CheckState.Checked:
                        DeptModels.ForEach(x => x.IsChecked = true);
                        BsService?.ResetBindings();
                        break;
                    case CheckState.Indeterminate:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        #endregion

        #region Private properties

        private IBindingSourceService BsService => GetService<IBindingSourceService>();

        #endregion

        #region Private methods

        private void DeptModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var tmp = DeptModels.Select(model => model.IsChecked).Distinct().ToArray();
            if (tmp.Length > 1)
            {
                _allDeptsCheckedState = CheckState.Indeterminate;
            }
            else
            {
                _allDeptsCheckedState = tmp[0] ? CheckState.Checked : CheckState.Unchecked;
            }
            RaisePropertyChanged(nameof(AllDeptsCheckedState));
        }

        #endregion

        #region Fields

        private CheckState _allDeptsCheckedState;

        #endregion
    }
}