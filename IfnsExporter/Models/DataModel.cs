namespace Cso.IfnsExporter.Models
{
    public class DataModel
    {
        public string OperationCode { get; set; }

        public string OperationName { get; set; }

        public decimal NonTaxableAmount { get; set; }

        public string BuyerLastName { get; set; }

        public string BuyerFirstName { get; set; }

        public string BuyerPatronymicName { get; set; }

        public string DocumentName { get; set; }

        public string DocumentNumber { get; set; }

        public string OperationDate { get; set; }

        public object GetBuyerFullName()
        {
            return $"{BuyerLastName} {BuyerFirstName} {BuyerPatronymicName}".Trim();
        }
    }
}