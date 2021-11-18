using FileHelpers;

namespace Cso.IfnsExporter.Csv
{
    [DelimitedRecord("|")]
    public class CsvModel
    {
        public string OperationCode;

        public string OperationName;

        [FieldNullValue(typeof(decimal), "0")]
        public decimal NonTaxableAmount;

        public string BuyerName;

        public string Inn;

        public string Kpp;

        public string DocumentName;

        public string DocumentNumber;

        public string OperationDate;
    }
}
