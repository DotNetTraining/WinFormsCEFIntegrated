using System;
using System.Windows.Forms;

namespace WinFormsCEFIntegrated.Utility
{
    public class Form2Factory : IFormFactory
    {
        public Form GetFormInstance(RenderFrom renderFromType)
        {
            switch (renderFromType)
            {
                case RenderFrom.Cef:
                    return new Form2Cef();
                case RenderFrom.WindowsForm:
                    return new Form2();
                default:
                    throw new ArgumentOutOfRangeException(nameof(renderFromType), renderFromType, "Invalid render type");
            }
        }
    }
}
