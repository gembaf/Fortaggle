using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Fortaggle.Views.ValidationRules
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

            if (CanEmpty == false && String.IsNullOrWhiteSpace(v))
            {
                return new ValidationResult(false, "必須入力です");
            }
            return ValidationResult.ValidResult;
        }
    }
}
