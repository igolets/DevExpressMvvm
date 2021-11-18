using System.Collections.Generic;
using System.Linq;
using FileHelpers.ExcelNPOIStorage;

namespace Cso.IfnsExporter.Csv
{
    public class FileWriter
    {
        public void WriteFile(string fileName, IEnumerable<CsvWriteModel> data)
        {
            var provider = new ExcelNPOIStorage(typeof (CsvWriteModel))
            {
                ColumnsHeaders = CsvWriteModel.Headers,
                StartColumn = 0,
                FileName = fileName
            };
            provider.InsertRecords(data.Cast<object>().ToArray());
        }
    }
}