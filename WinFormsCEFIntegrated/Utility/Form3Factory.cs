using System;
using System.Windows.Forms;

namespace WinFormsCEFIntegrated.Utility
{
    public class Form3Factory : IFormFactory
    {
        public Form GetFormInstance(RenderFrom renderFromType)
        {
            switch (renderFromType)
            {
                case RenderFrom.Cef:
                    return new Form3Cef();
                case RenderFrom.WindowsForm:
                    return new Form3();
                default:
                    throw new ArgumentOutOfRangeException(nameof(renderFromType), renderFromType, "Invalid render type");
            }
        }
    }
}
