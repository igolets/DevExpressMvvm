using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Cso.BOReports;
using Cso.BOReports.ServiceReports.ServicesPaymentsReport;
using Cso.BOReports.Urgent;
using Cso.Common;
using Cso.IfnsExporter.Csv;
using Cso.IfnsExporter.Models;
using Cso.IfnsExporter.Properties;
using Cso.IfnsExporter.Protocol;
using Cso.IfnsExporter.Services;
using Cso.IfnsExporter.Views;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using JetBrains.Annotations;
using Sobes.BOSettings;
using TmAvt.Base.Factories;
using TmAvt.ExceptionHandling;

namespace Cso.IfnsExporter.ViewModels
{
    [POCOViewModel]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class MainViewModel : ViewModelBase
    {
        private const string DateFormatString = "dd.MM.yyyy"; 

        #region Statics

        private static DataModel MapCsvToData(CsvModel model) => new()
        {
            OperationCode = model.OperationCode,
            OperationName = model.OperationName,
            NonTaxableAmount = model.NonTaxableAmount,
            OperationDate = model.OperationDate.Replace(" г.", ""),
            BuyerLastName = GetLastName(model.BuyerName),
            BuyerFirstName = GetFirstName(model.BuyerName),
            BuyerPatronymicName = GetPatronymicName(model.BuyerName),
            DocumentName = model.DocumentName,
            DocumentNumber = model.DocumentNumber
        };

        private static CsvWriteModel MapDataToCsvWrite(DataModel model) => new()
        {
            OperationCode = model.OperationCode,
            OperationName = model.OperationName,
            NonTaxableAmount = model.NonTaxableAmount,
            OperationAmount = model.NonTaxableAmount,
            BuyerName = (string)model.GetBuyerFullName(),
            Inn = Settings.Default.ИННЮЛ,
            Kpp = Settings.Default.КПП,
            DocumentName = model.DocumentName,
            DocumentNumber = model.DocumentNumber,
            OperationDate = model.OperationDate
        };

        private static DataModel MapExportBillsToData(ExportBillsVladimirBindingItem model) => new()
        {
            OperationCode = Settings.Default.КодОпер,
            OperationName = Settings.Default.OperationName,
            NonTaxableAmount = model.PaymentReportItem.TotalPaymentAmount,
            BuyerLastName = model.PaymentReportItem.Surname,
            BuyerFirstName = model.PaymentReportItem.Name,
            BuyerPatronymicName = model.PaymentReportItem.Patronimic,
            DocumentName = "договор",
            DocumentNumber = string.IsNullOrWhiteSpace(Settings.Default.ЗаменаНомерДоговора)
                ? model.ContractNumber
                : Settings.Default.ЗаменаНомерДоговора,
            OperationDate = model.ContractDate.GetValueOrDefault().ToString(DateFormatString)
        };

        private static DataModel MapUrgentExportToData(UrgentExportBillsPeriodBindingItem model) => new()
        {
            OperationCode = Settings.Default.КодОпер,
            OperationName = Settings.Default.OperationName,
            NonTaxableAmount = model.PaymentAmount,
            BuyerLastName = model.Surname,
            BuyerFirstName = model.Name,
            BuyerPatronymicName = model.Patronimic,
            DocumentName = "договор",
            DocumentNumber = string.IsNullOrWhiteSpace(Settings.Default.ЗаменаНомерДоговора)
                ? (model.ContractNumber ?? "б/н")
                : Settings.Default.ЗаменаНомерДоговора,
            OperationDate = (model.ContractDate ?? model.FirstServiceDate).ToString(DateFormatString)
        };

        private static SettingsEditorViewModel MapSettingsToEditor(Settings settings) => new()
        {
            ИННЮЛ = settings.ИННЮЛ,
            КПП = settings.КПП,
            НаимОрг = settings.НаимОрг,
            ПодписантТлф = settings.ПодписантТлф,
            КодНО = settings.КодНО,
            КНД = settings.КНД,
            ПодписантОтчество = settings.ПодписантОтчество,
            ПодписантИмя = settings.ПодписантИмя,
            ПодписантФамилия = settings.ПодписантФамилия,
            ConnectionString = settings.ConnectionString,
            ЗаменаНомерДоговора = settings.ЗаменаНомерДоговора,
            КодОпер = settings.КодОпер,
            OperationName = settings.OperationName
        };

        private static void MapEditorToSettings(SettingsEditorViewModel source, Settings target)
        {
            target.ИННЮЛ = source.ИННЮЛ;
            target.КПП = source.КПП;
            target.НаимОрг = source.НаимОрг;
            target.ПодписантТлф = source.ПодписантТлф;
            target.КодНО = source.КодНО;
            target.КНД = source.КНД;
            target.ПодписантОтчество = source.ПодписантОтчество;
            target.ПодписантИмя = source.ПодписантИмя;
            target.ПодписантФамилия = source.ПодписантФамилия;
            target.ConnectionString = source.ConnectionString;
            target.ЗаменаНомерДоговора = source.ЗаменаНомерДоговора;
            target.КодОпер = source.КодОпер;
            target.OperationName = source.OperationName;
        }

        private static string GetPatronymicName(string byuerName)
        {
            var parts = byuerName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                return null;
            }

            return string.Join(" ", parts.Skip(2));
        }

        private static string GetLastName(string byuerName)
        {
            var parts = byuerName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return parts[0];
        }

        private static string GetFirstName(string byuerName)
        {
            var parts = byuerName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return parts[1];
        }

        #endregion

        public MainViewModel()
        {
            var date = DateTime.Today;
            Year = date.Year;
            SelectedPeriod = date.Month switch
            {
                <=3 => PeriodCode.Quarter4,
                <= 6 => PeriodCode.Quarter1,
                <= 9 => PeriodCode.Quarter2,
                _ => PeriodCode.Quarter3
            };

            if (SelectedPeriod == PeriodCode.Quarter4)
            {
                Year--;
            }

            ReqNumber = Settings.Default.НомерТребования;
        }

        public BindingList<DataModel> GridData { get; } = new();

        /// <summary>
        /// Номер Требования
        /// </summary>
        [UsedImplicitly]
        public int ReqNumber { get; set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public int Year { get; set; }

        public PeriodCode SelectedPeriod
        {
            get;
            // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
            set;
        }

        public void ClearData()
        {
            GridData.Clear();

            this.RaiseCanExecuteChanged(model=>model.SaveXml());
            this.RaiseCanExecuteChanged(model=>model.SaveExcel());
        }

        public void LoadExcel()
        {
            OpenFile.Filter = "Файлы Excel (.xlsx,*.xls)|*.xlsx;*.xls|Все файлы (*.*)|*.*";

            if (OpenFile.ShowDialog())
            {
                var excelFilePath = Path.Combine(OpenFile.File.DirectoryName, OpenFile.File.Name);

                var reader = new FileReader();
                var data = reader.ReadFile(excelFilePath);

                if (data.Any(x => x.OperationCode != Settings.Default.КодОпер))
                {
                    MessageBox.Show(
                        $"Все строки должны иметь код операции {Settings.Default.КодОпер}.",
                        "Ошибка",
                        MessageButton.OK,
                        MessageIcon.Error,
                        MessageResult.OK);
                    return;
                }

                var isDataAdded = GridData.Any();

                foreach (var model in data)
                {
                    GridData.Add(MapCsvToData(model));
                }

                this.RaiseCanExecuteChanged(model=>model.SaveXml());
                this.RaiseCanExecuteChanged(model=>model.SaveExcel());

                if (isDataAdded)
                {
                    ShowNewDataAdded();
                }
            }
        }

        [UsedImplicitly]
        public virtual bool CanSaveXml()
        {
            return GridData.Any();
        }

        public virtual void SaveXml()
        {
            if (SaveFolder.ShowDialog())
            {
                var today = DateTime.Today;
                var fileName = string
                    .Format(
                        "KO_RROBNL_{0}_{0}_{1}{2}_{3:yyyyMMdd}_{4}",
                        Settings.Default.КодНО,
                        Settings.Default.ИННЮЛ,
                        Settings.Default.КПП,
                        today,
                        Guid.NewGuid())
                    .ToUpper();

                Settings.Default.НомерТребования = ReqNumber;
                Settings.Default.Save();

                var exporter = new Exporter();
                exporter.Export(SaveFolder.ResultPath, fileName, Year, SelectedPeriod, GridData.ToArray());

                MessageBox.Show(
                    "Файл создан успешно",
                    "Экспорт",
                    MessageButton.OK,
                    MessageIcon.Information,
                    MessageResult.OK);
            }
        }

        [UsedImplicitly]
        public virtual bool CanSaveExcel()
        {
            return GridData.Any();
        }

        public virtual void SaveExcel()
        {
            SaveFile.DefaultFileName = Periods.Single(x => x.PriodCode == SelectedPeriod) + " " +  Year;
            SaveFile.DefaultExt = ".xlsx";
            SaveFile.Filter = "Файлы Excel (.xlsx,*.xls)|*.xlsx;*.xls|Все файлы (*.*)|*.*";

            if (SaveFile.ShowDialog())
            {
                var fileName = SaveFile.GetFullFileName();
                var writer = new FileWriter();
                var data = GridData.Select(MapDataToCsvWrite).ToList();
                data.Add(new CsvWriteModel
                {
                    OperationDate = "Итого:",
                    OperationAmount = data.Sum(x => x.OperationAmount)
                });
                writer.WriteFile(fileName, data);

                if (MessageBox.Show(
                        "Файл сохранен успешно. Открыть его в Excel?",
                        "Готово",
                        MessageButton.YesNo,
                        MessageIcon.Information,
                        MessageResult.Yes)
                    == MessageResult.Yes)
                {
                    Shell.OpenFile(fileName);
                }
            }
        }

        public void LoadFromDb()
        {
            using var context = DataContextFactory.GetDataContext<ReportsDataContext>(Settings.Default.ConnectionString);

            context.CommandTimeout = 180;

            try
            {
                context.Connection.Open();

                ProgramSettings.Current.DefaultConnectionString = Settings.Default.ConnectionString;
                ProgramSettings.Current.LoadDbSettings(Settings.Default.ConnectionString);

                var mv = new ReportParamsViewModel
                (
                    new DateTime(DateTime.Now.Year, 1, 1),
                    new DateTime(DateTime.Now.Year, 12, 1),
                    context
                        .Departments
                        .Where(d => d.DepartmentTypeID.HasValue)
                        .OrderBy(d => d.DepartmentTypeID)
                        .ThenBy(d => d.Name)
                        .Select(d => new SelectDepartmentModel(d.DepartmentID, d.Name, (DepartmentTypes)d.DepartmentTypeID.Value))
                        .ToArray()
                );

                if (Dialog.ShowDialog(
                        MessageButton.OKCancel,
                        "Параметры",
                        nameof(ReportParamsView),
                        mv)
                    != MessageResult.OK)
                {
                    return;
                }

                Splash.ShowSplashScreen(nameof(WaitFormView));

                var isDataAdded = GridData.Any();

                #region Надомка, ОДП

                var departmentIds = mv.DeptModels
                    .Where(x => x.DepartmentTypeId != DepartmentTypes.OSSO && x.IsChecked)
                    .Select(x => x.DepartmentId)
                    .ToArray();
                var centerDepartment = new Department { DepartmentTypeID = 0, Name = "Центр" };

                if(departmentIds.Any())
                {
                    var data = context.GetExportBillsData(
                        mv.DateFrom,
                        mv.DateTo,
                        null,
                        true,
                        departmentIds,
                        centerDepartment);

                    foreach (var model in data.Where(x => x.PaymentReportItem.TotalPaymentAmount != 0))
                    {
                        GridData.Add(MapExportBillsToData(model));
                    }
                }

                #endregion

                #region Срочка

                if (true)
                {
                    var monthEnd = mv.DateTo.AddMonths(1).AddDays(-1);

                    var ossoDepts = mv.DeptModels
                        .Where(x => x.DepartmentTypeId == DepartmentTypes.OSSO && x.IsChecked)
                        .Select(x => x.DepartmentId)
                        .ToArray();

                    if(ossoDepts.Any())
                    {
                        var ossoData = context.GetUrgentExportBillsPeriodData(mv.DateFrom, monthEnd, ossoDepts);

                        foreach (var model in ossoData.Where(x => x.PaymentAmount > 0))
                        {
                            GridData.Add(MapUrgentExportToData(model));
                        }
                    }
                }

                #endregion

                Splash.HideSplashScreen();

                this.RaiseCanExecuteChanged(model=>model.SaveXml());
                this.RaiseCanExecuteChanged(model=>model.SaveExcel());

                if (isDataAdded)
                {
                    ShowNewDataAdded();
                }
            }
            catch (Exception ex)
            {
                Splash.HideSplashScreen();

                UnhandledExceptionManager.HandleException(ex, false, false);

                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageButton.OK,
                    MessageIcon.Error,
                    MessageResult.OK);
            }
        }

        public virtual void ShowSettings()
        {
            var set = MapSettingsToEditor(Settings.Default);

            if (Dialog.ShowDialog(
                MessageButton.OKCancel,
                "Настройки",
                nameof(SettingsEditorView),
                set) == MessageResult.OK)
            {
                MapEditorToSettings(set, Settings.Default);
                Settings.Default.Save();
            }
        }

        private IShellService Shell => GetService<IShellService>();

        private IOpenFileDialogService OpenFile => GetService<IOpenFileDialogService>();

        private ISaveFileDialogService SaveFile => GetService<ISaveFileDialogService>();

        private IFolderBrowserDialogService SaveFolder => GetService<IFolderBrowserDialogService>();

        private IMessageBoxService MessageBox => GetService<IMessageBoxService>();

        private IDialogService Dialog => GetService<IDialogService>();

        private ISplashScreenService Splash => GetService<ISplashScreenService>();

        private void ShowNewDataAdded()
        {
            MessageBox.Show(
                "Новые данные добавлены к уже имеющимся",
                "Загрузка",
                MessageButton.OK,
                MessageIcon.Information,
                MessageResult.OK);
        }
        
        // ReSharper disable once InconsistentNaming
        public static readonly PriodItemModel[] Periods =
        {
            new("1 Квартал", PeriodCode.Quarter1),
            new("2 Квартал", PeriodCode.Quarter2),
            new("3 Квартал", PeriodCode.Quarter3),
            new("4 Квартал", PeriodCode.Quarter4),
        };
    }
}
