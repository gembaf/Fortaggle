using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Input;

namespace Fortaggle.Views.Behaviors
{
    public class ValidationErrorBehavior : Behavior<DependencyObject>
    {
        // View内でのエラーの数
        private int errroCount;

        // View内でのエラーの有無
        public bool HasViewError
        {
            get { return (bool)GetValue(HasViewErrorProperty); }
            set { SetValue(HasViewErrorProperty, value); }
        }

        public static readonly DependencyProperty HasViewErrorProperty =
            DependencyProperty.Register("HasViewError", typeof(bool), typeof(ValidationErrorBehavior), new UIPropertyMetadata(false));

        protected override void OnAttached()
        {
            base.OnAttached();
            // エラーがあったときのイベントハンドラ登録
            Validation.AddErrorHandler(this.AssociatedObject, this.ErrorHandler);
        }

        protected override void OnDetaching()
        {
            // イベントハンドラ登録解除
            Validation.RemoveErrorHandler(this.AssociatedObject, this.ErrorHandler);
            base.OnDetaching();
        }

        private void ErrorHandler(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                // Actionを見て、エラーが追加の時はカウントアップ
                errroCount++;
            }
            else if (e.Action == ValidationErrorEventAction.Removed)
            {
                // エラーが消えたときはカウントダウン
                errroCount--;
            }
            // エラーの有無をHasViewErrorにセット
            this.HasViewError = this.errroCount != 0;
        }
    }
}
