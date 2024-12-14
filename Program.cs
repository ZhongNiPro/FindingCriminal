using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindingCriminal
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CriminalFindingForm form = new CriminalFindingForm();
            Detective class1 = new Detective(form);
            Task.Run(async () => await class1.SearchAsync());

            Application.Run(form);
        }
    }
}
