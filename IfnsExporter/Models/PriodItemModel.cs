using Cso.IfnsExporter.Protocol;

namespace Cso.IfnsExporter.Models
{
    public class PriodItemModel
    {
        public PriodItemModel(string name, PeriodCode priodCode)
        {
            Name = name;
            PriodCode = priodCode;
        }

        private string Name { get; }

        public PeriodCode PriodCode { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }
}