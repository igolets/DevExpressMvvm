namespace Cso.IfnsExporter.Services
{
    public interface IShellService
    {
        /// <summary>
        /// Открыть файл через среду Windows (exe, или известное расширение)
        /// </summary>
        /// <param name="fileName"></param>
        void OpenFile(string fileName);
    }
}