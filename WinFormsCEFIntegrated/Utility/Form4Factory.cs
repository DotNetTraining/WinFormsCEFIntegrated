using System;
using System.Windows.Forms;

namespace WinFormsCEFIntegrated.Utility
{
    public class Form4Factory : IFormFactory
    {
        public Form GetFormInstance(RenderFrom renderFromType)
        {
            switch (renderFromType)
            {
                case RenderFrom.Cef:
                    return new Form4Cef();
                case RenderFrom.WindowsForm:
                    return new Form4();
                default:
                    throw new ArgumentOutOfRangeException(nameof(renderFromType), renderFromType, "Invalid render type");
            }
        }
    }
}
