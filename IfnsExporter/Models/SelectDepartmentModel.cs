using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cso.Common;
using DevExpress.Mvvm.DataAnnotations;
using JetBrains.Annotations;

namespace Cso.IfnsExporter.Models
{
    [POCOViewModel]
    [UsedImplicitly (ImplicitUseTargetFlags.Members)]
    [DebuggerDisplay("{Description} ({IsChecked})")]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class SelectDepartmentModel : INotifyPropertyChanged
    {
        #region Constructors

        public SelectDepartmentModel(int departmentId, string departmentName, DepartmentTypes departmentTypeId)
        {
            DepartmentId = departmentId;
            Description = departmentName;
            DepartmentTypeId = departmentTypeId;
            _isChecked = true;
        }

        #endregion

        #region Publec events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public properties

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public string Description { get; }

        public DepartmentTypes DepartmentTypeId { get; }

        public int DepartmentId { get; }

        #endregion

        #region Protected methods

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Fields

        private bool _isChecked;

        #endregion
    }
}