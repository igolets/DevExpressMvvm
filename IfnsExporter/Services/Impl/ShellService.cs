using System.Diagnostics;

namespace Cso.IfnsExporter.Services.Impl
{
    public class ShellService : IShellService
    {
        /// <inheritdoc />
        public void OpenFile(string fileName)
        {
            Process.Start(fileName);
        }
    }
}