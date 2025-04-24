using System;
using System.Windows.Forms;

namespace WinFormsCEFIntegrated.Utility
{
    public class Form1Factory : IFormFactory
    {
        public Form GetFormInstance(RenderFrom renderFromType)
        {
            switch (renderFromType)
            {
                case RenderFrom.Cef:
                    return new Form1Cef();
                case RenderFrom.WindowsForm:
                    return new Form1();
                default:
                    throw new ArgumentOutOfRangeException(nameof(renderFromType), renderFromType, "Invalid render type");
            }
        }
    }
}
