using System.IO;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace Cso.IfnsExporter.ViewModels
{
    [POCOViewModel]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class SettingsEditorViewModel : ViewModelBase
    {
        // ReSharper disable once InconsistentNaming
        public virtual string ИННЮЛ { get; set; }

        // ReSharper disable once InconsistentNaming
        public virtual string КПП { get; set; }

        public virtual string НаимОрг { get; set; }

        public virtual string ПодписантТлф { get; set; }

        // ReSharper disable once InconsistentNaming
        public virtual string КодНО { get; set; }

        // ReSharper disable once InconsistentNaming
        public virtual string КНД { get; set; }

        public virtual string ПодписантОтчество { get; set; }

        public virtual string ПодписантИмя { get; set; }

        public virtual string ПодписантФамилия { get; set; }

        public virtual string ConnectionString { get; set; }

        public virtual string ЗаменаНомерДоговора { get; set; }

        public virtual string КодОпер { get; set; }

        public virtual string OperationName
        {
            get => _operationName;
            set
            {
                _operationName = value;
                OperationNameChars = value.Length;
                RaisePropertyChanged(nameof(OperationNameChars));
            }
        }

        public virtual int OperationNameChars { get; set; }

        public virtual void GetExcelTemplate()
        {
            SaveFile.DefaultFileName = "ВыгрузкаИфнс";
            SaveFile.DefaultExt = ".xlsx";
            SaveFile.Filter = "Файлы Excel (.xlsx,*.xls)|*.xlsx;*.xls|Все файлы (*.*)|*.*";
            
            if (SaveFile.ShowDialog())
            {
                File.Copy("Шаблон.xlsx", SaveFile.GetFullFileName(), true);
                MessageBox.Show(
                    @"Файл сохранен в указанное местоположение.
Ваши данные добавляйте начиная с 10 строки файла (выделено желтым).
Вставьте нужное количество строк, по одной на каждого получателя услуг после строки 10.
Все остальные данные оставьте как есть, строки с столбцы не удаляйте.",
                    "Готово",
                    MessageButton.OK,
                    MessageIcon.Information,
                    MessageResult.OK);
            }
        }

        private ISaveFileDialogService SaveFile => GetService<ISaveFileDialogService>();

        private IMessageBoxService MessageBox => GetService<IMessageBoxService>();

        private string _operationName;
    }
}