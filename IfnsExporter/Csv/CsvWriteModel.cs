using System.Collections.Generic;
using FileHelpers;

namespace Cso.IfnsExporter.Csv
{
    [DelimitedRecord("|")]
    public class CsvWriteModel : CsvModel
    {
        [FieldNullValue(typeof(decimal), "0")]
        public decimal OperationAmount;

        internal static List<string> Headers = new List<string>
        {
            "Код операции",
            "вид (группа, направление) необлагаемой операции",
            "Сумма необлагаемых операций в разрезе видов (групп, направлений) необлагаемых операции, отраженных в налоговой декларации, руб.",
            "Наименование контрагента (покупателя)",
            "ИНН",
            "КПП",
            "Тип документа (договор, и т.д.)",
            "№",
            "Дата",
            "Сумма операции, руб."
        };
    }
}