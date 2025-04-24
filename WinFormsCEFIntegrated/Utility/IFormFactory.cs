using System.Windows.Forms;

namespace WinFormsCEFIntegrated.Utility
{
    public interface IFormFactory
    {
        Form GetFormInstance(RenderFrom renderFromType);
    }
}
