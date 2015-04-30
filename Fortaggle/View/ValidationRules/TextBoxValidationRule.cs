using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Fortaggle.View.ValidationRules
{
    public class TextBoxValidationRule : ValidationRule
    {
        //--- プロパティ

        public bool CanEmpty { get; set; }

        //--- コンストラクタ

        public TextBoxValidationRule()
        {
            CanEmpty = false;
        }

        //--- ValidationResult

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var v = value as String;

            if (CanEmpty == false && String.IsNullOrEmpty(v))
            {
                return new ValidationResult(false, "入力して下さい");
            }
            return ValidationResult.ValidResult;
        }
    }
}
