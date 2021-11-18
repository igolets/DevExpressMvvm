using System.Linq;
using FileHelpers.ExcelNPOIStorage;

namespace Cso.IfnsExporter.Csv
{
    public class FileReader
    {
        public CsvModel[] ReadFile(string fileName)
        {
            var provider = new ExcelNPOIStorage(typeof (CsvModel))
            {
                StartRow = 8,
                StartColumn = 0,
                FileName = fileName
            };
            var res = (CsvModel[]) provider.ExtractRecords();
            return res.Skip(1).TakeWhile(x => x.OperationCode != "ИТОГО").ToArray();
        }
    }
}
