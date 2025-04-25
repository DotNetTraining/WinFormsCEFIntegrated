using System;

namespace WinFormsCEFIntegrated.Utility
{
    public class FormFactory
    {
        public static IFormFactory GetFactoryForForm(string formName)
        {
            switch (formName)
            {
                case "Form1":
                    return new Form1Factory();
                case "Form2":
                    return new Form2Factory();
                case "Form3":
                    return new Form3Factory();
                case "Form4":
                    return new Form4Factory();
                default:
                    throw new ArgumentException("Invalid form name", nameof(formName));
            }
        }
    }
}
