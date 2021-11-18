using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using AutoMapper;
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

        static MainViewModel()
        {
            var mappingConfig = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<CsvModel, DataModel>()
                        .ForMember(
                            d => d.OperationDate,
                            op =>
                                op.MapFrom(
                                    s => s.OperationDate.Replace(" г.", "")))
                        .ForMember(
                            d => d.BuyerLastName,
                            op => op.MapFrom(
                                s => GetLastName(s.BuyerName)))
                        .ForMember(
                            d => d.BuyerPatronymicName,
                            op => op.MapFrom(
                                s => GetPatronymicName(s.BuyerName)))
                        .ForMember(
                            d => d.BuyerFirstName,
                            op => op.MapFrom(
                                s => GetFirstName(s.BuyerName)));

                    cfg.CreateMap<DataModel, CsvWriteModel>()
                        .ForMember(
                            d => d.BuyerName,
                            op => op.MapFrom(
                                s => s.GetBuyerFullName()))
                        .ForMember(d=>d.OperationAmount,
                            op=>op.MapFrom(
                                src=>src.NonTaxableAmount))
                        .ForMember(d=>d.Inn,
                            op=>op.MapFrom(data=>Settings.Default.ИННЮЛ))
                        .ForMember(d=>d.Kpp,
                            op=>op.MapFrom(data=>Settings.Default.КПП));

                    cfg.CreateMap<ExportBillsVladimirBindingItem, DataModel>()
                        .ForMember(
                            d => d.OperationCode,
                            op => op.MapFrom(
                                s => Settings.Default.КодОпер))
                        .ForMember(
                            d => d.OperationName,
                            op => op.MapFrom(
                                s => Settings.Default.OperationName))
                        .ForMember(
                            d => d.NonTaxableAmount,
                            op => op.MapFrom(
                                s => s.PaymentReportItem.TotalPaymentAmount))
                        .ForMember(
                            d => d.BuyerLastName,
                            op => op.MapFrom(
                                s => s.PaymentReportItem.Surname))
                        .ForMember(
                            d => d.BuyerFirstName,
                            op => op.MapFrom(
                                s => s.PaymentReportItem.Name))
                        .ForMember(
                            d => d.BuyerPatronymicName,
                            op => op.MapFrom(
                                s => s.PaymentReportItem.Patronimic))
                        .ForMember(
                            d => d.DocumentName,
                            op => op.MapFrom(
                                s => "договор"))
                        .ForMember(
                            d => d.DocumentNumber,
                            op => op.MapFrom(
                                s =>
                                    string.IsNullOrWhiteSpace(Settings.Default.ЗаменаНомерДоговора)
                                    ? s.ContractNumber
                                    : Settings.Default.ЗаменаНомерДоговора))
                        .ForMember(
                            d => d.OperationDate,
                            op => op.MapFrom(
                                s => s.ContractDate.GetValueOrDefault().ToString(DateFormatString)));

                    cfg.CreateMap<UrgentExportBillsPeriodBindingItem, DataModel>()
                        .ForMember(
                            d => d.OperationCode,
                            op => op.MapFrom(
                                s => Settings.Default.КодОпер))
                        .ForMember(
                            d => d.OperationName,
                            op => op.MapFrom(
                                s => Settings.Default.OperationName))
                        .ForMember(
                            d => d.NonTaxableAmount,
                            op => op.MapFrom(
                                s => s.PaymentAmount))
                        .ForMember(
                            d => d.BuyerLastName,
                            op => op.MapFrom(
                                s => s.Surname))
                        .ForMember(
                            d => d.BuyerFirstName,
                            op => op.MapFrom(
                                s => s.Name))
                        .ForMember(
                            d => d.BuyerPatronymicName,
                            op => op.MapFrom(
                                s => s.Patronimic))
                        .ForMember(
                            d => d.DocumentName,
                            op => op.MapFrom(
                                s => "договор"))
                        .ForMember(
                            d => d.DocumentNumber,
                            op => op.MapFrom(
                                s =>
                                    string.IsNullOrWhiteSpace(Settings.Default.ЗаменаНомерДоговора)
                                        ? (s.ContractNumber ?? "б/н")
                                        : Settings.Default.ЗаменаНомерДоговора))
                        .ForMember(
                            d => d.OperationDate,
                            op => op.MapFrom(
                                s =>
                                    s.ContractDate == null
                                        ? s.FirstServiceDate.ToString(DateFormatString)
                                        : s.ContractDate.Value.ToString(DateFormatString)));

                    cfg.CreateMap<Settings, SettingsEditorViewModel>();

                    cfg.CreateMap<SettingsEditorViewModel, Settings>();
                }
            );
            Mapper = new Mapper(mappingConfig);
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
                    GridData.Add(Mapper.Map<DataModel>(model));
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
                var data = Mapper.Map<List<CsvWriteModel>>(GridData);
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
                        GridData.Add(Mapper.Map<DataModel>(model));
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
                            GridData.Add(Mapper.Map<DataModel>(model));
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
            var set = Mapper.Map<SettingsEditorViewModel>(Settings.Default);

            if (Dialog.ShowDialog(
                MessageButton.OKCancel,
                "Настройки",
                nameof(SettingsEditorView),
                set) == MessageResult.OK)
            {
                Mapper.Map(set, Settings.Default);
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
        
        private static readonly IMapper Mapper;

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
