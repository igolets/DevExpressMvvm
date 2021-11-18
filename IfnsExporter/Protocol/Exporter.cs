using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Cso.IfnsExporter.Models;
using Cso.IfnsExporter.Properties;

namespace Cso.IfnsExporter.Protocol
{
    public class Exporter
    {
        private const string ВерсФорм = "5.02";

        public void Export(string filePath, string fileName, int year, PeriodCode period, DataModel[] data)
        {
            var serializer = new XmlSerializer(typeof(Файл));
            var today = DateTime.Today;

            ФайлДокументПериод periodCode;
            switch (period)
            {
                case PeriodCode.Quarter1:
                    periodCode = ФайлДокументПериод.Item21;
                    break;
                case PeriodCode.Quarter2:
                    periodCode = ФайлДокументПериод.Item22;
                    break;
                case PeriodCode.Quarter3:
                    periodCode = ФайлДокументПериод.Item23;
                    break;
                case PeriodCode.Quarter4:
                    periodCode = ФайлДокументПериод.Item24;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(period), period, null);
            }

            var asm = Assembly.GetEntryAssembly();
            if (asm == null)
            {
                throw new InvalidOperationException("Assembly.GetEntryAssembly() is null");
            }
            var progVersion = $"{asm.GetCustomAttribute<AssemblyProductAttribute>().Product} {asm.GetName().Version.Major}.{asm.GetName().Version.Minor}";

            var exportData = new Файл
            {
                ИдФайл = fileName,
                ВерсПрог = progVersion,
                ВерсФорм = ВерсФорм,
                Документ = new ФайлДокумент
                {
                    КНД = Settings.Default.КНД,
                    ДатаДок = today.ToString("dd.MM.yyyy"),
                    КодНО = Settings.Default.КодНО,
                    ИмяФайлТреб = $"Требование №{Settings.Default.НомерТребования}",
                    СвНП = new ФайлДокументСвНП
                    {
                        Item = new ФайлДокументСвНПНПЮЛ
                        {
                            НаимОрг = Settings.Default.НаимОрг,
                            ИННЮЛ = Settings.Default.ИННЮЛ,
                            КПП = Settings.Default.КПП
                        }
                    },
                    Подписант = new ФайлДокументПодписант
                    {
                        ПрПодп = Settings.Default.ПодписантПрПодп==1?ФайлДокументПодписантПрПодп.Item1:ФайлДокументПодписантПрПодп.Item2,
                        Тлф = Settings.Default.ПодписантТлф,
                        ФИО = new ФайлДокументПодписантФИО
                        {
                            Фамилия = Settings.Default.ПодписантФамилия,
                            Имя = Settings.Default.ПодписантИмя,
                            Отчество = Settings.Default.ПодписантОтчество
                        }
                    },
                    ОтчетГод = year.ToString(),
                    Период = periodCode,
                    ПериодSpecified = true
                }
            };

            var totalSum = data.Sum(x => x.NonTaxableAmount);
            exportData.Документ.РеестрДокПОбНЛ = new[]
            {
                new ФайлДокументРеестрДокПОбНЛ
                {
                    НомРеестр = "1",
                    КодОпер = Settings.Default.КодОпер,
                    ОбщСтНеоблОпВс = totalSum,
                    ОбщСтТовВс = totalSum
                }
            };

            var items = new List<ФайлДокументРеестрДокПОбНЛСведВидОпер>();
            var num = 1;

            foreach (var model in data)
            {
                items.Add(
                    new ФайлДокументРеестрДокПОбНЛСведВидОпер
                    {
                        НомСвВидОп = num.ToString(),
                        ВидОпер = model.OperationName,
                        ОбщСтНеоблОп = model.NonTaxableAmount,
                        ПредТипДог = new[]
                        {
                            new ФайлДокументРеестрДокПОбНЛСведВидОперПредТипДог
                            {
                                НомТипДог = num.ToString(),
                                СведКАгент = new[]
                                {
                                    new ФайлДокументРеестрДокПОбНЛСведВидОперПредТипДогСведКАгент
                                    {
                                        ОбщСтТов = model.NonTaxableAmount,
                                        Item =
                                            new ФайлДокументРеестрДокПОбНЛСведВидОперПредТипДогСведКАгентСведФЛ
                                            {
                                                ФИО =
                                                    new
                                                        ФайлДокументРеестрДокПОбНЛСведВидОперПредТипДогСведКАгентСведФЛФИО
                                                        {
                                                            Фамилия = model.BuyerLastName,
                                                            Имя = model.BuyerFirstName,
                                                            Отчество = model.BuyerPatronymicName
                                                        }
                                            },
                                        ДокПОбНЛ = new[]
                                        {
                                            new
                                                ФайлДокументРеестрДокПОбНЛСведВидОперПредТипДогСведКАгентДокПОбНЛ
                                                {
                                                    ВидДок = model.DocumentName,
                                                    НомДок = model.DocumentNumber,
                                                    ДатаДок = model.OperationDate
                                                }
                                        }
                                    }
                                }
                            }
                        }
                    });

                num++;
            }

            exportData.Документ.РеестрДокПОбНЛ[0].СведВидОпер = items.ToArray();

            var fullFileName = Path.Combine(filePath, fileName);
            fullFileName = Path.ChangeExtension(fullFileName, "xml");

            using var writer = new StreamWriter(fullFileName, false, Encoding.GetEncoding("windows-1251"));
            serializer.Serialize(writer, exportData);
        }
    }
}
