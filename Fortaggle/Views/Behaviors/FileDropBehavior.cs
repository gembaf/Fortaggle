/// <summary>
/// http://katsuyuzu.hatenablog.jp/entry/20111219/1324313500
/// </summary>

using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Input;
using System;

namespace Fortaggle.Views.Behaviors
{
    class FileDropBehavior : Behavior<Border>
    {
        private Brush _defaultBackground;
        private Brush _defaultForeground;

        #region "DependencyProperty"
        /// <summary>
        /// 親オブジェクトの背景をハイライトするときの Brush を取得または設定します。
        /// </summary>
        public Brush HighlightBackground
        {
            get { return (Brush)GetValue(HighlightBackgroundProperty); }
            set { SetValue(HighlightBackgroundProperty, value); }
        }
        public static readonly DependencyProperty HighlightBackgroundProperty =
            DependencyProperty.Register("HighlightBackground", typeof(Brush), typeof(FileDropBehavior), new PropertyMetadata(null));

        /// <summary>
        /// DescriptionTextBlock の前景をハイライトするときの Brush を取得または設定します。
        /// </summary>
        public Brush HighlightForeground
        {
            get { return (Brush)GetValue(HighlightForegroundProperty); }
            set { SetValue(HighlightForegroundProperty, value); }
        }
        public static readonly DependencyProperty HighlightForegroundProperty =
            DependencyProperty.Register("HighlightForeground", typeof(Brush), typeof(FileDropBehavior), new PropertyMetadata(null));

        /// <summary>
        /// ドロップ領域の説明用のテキストブロックを取得または設定します。
        /// </summary>
        public TextBlock DescriptionTextBlock
        {
            get { return (TextBlock)GetValue(DescriptionTextBlockProperty); }
            set { SetValue(DescriptionTextBlockProperty, value); }
        }
        public static readonly DependencyProperty DescriptionTextBlockProperty =
            DependencyProperty.Register("DescriptionTextBlock", typeof(TextBlock), typeof(FileDropBehavior), new PropertyMetadata(null));

        /// <summary>
        /// ドロップされたときに実行するコマンドを取得または設定します。
        /// </summary>
        public ICommand TargetCommand
        {
            get { return (ICommand)GetValue(TargetCommandProperty); }
            set { SetValue(TargetCommandProperty, value); }
        }
        public static readonly DependencyProperty TargetCommandProperty =
            DependencyProperty.Register("TargetCommand", typeof(ICommand), typeof(FileDropBehavior), new PropertyMetadata(null));
        #endregion

        #region "OnAttached / OnDetaching"
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.DragEnter += OnDragEnter;
            this.AssociatedObject.DragLeave += OnDragLeave;
            this.AssociatedObject.Drop += OnDrop;
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.DragEnter -= OnDragEnter;
            this.AssociatedObject.DragLeave -= OnDragLeave;
            this.AssociatedObject.Drop -= OnDrop;
            base.OnDetaching();
        }
        #endregion

        #region "OnEvent Methods"
        private void OnDragEnter(object sender, DragEventArgs e)
        {
            var backgroundBorder = sender as Border;
            ChangeBrush(backgroundBorder, DescriptionTextBlock);
        }

        private void OnDragLeave(object sender, DragEventArgs e)
        {
            var backgroundBorder = sender as Border;
            RestoreBrush(backgroundBorder, DescriptionTextBlock);
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            var backgroundBorder = sender as Border;
            RestoreBrush(backgroundBorder, DescriptionTextBlock);

            NotifyDrop(e.Data);
        }
        #endregion

        #region "Behavior Methods"
        /// <summary>
        /// 指定のコントロールの Brush をハイライト色に変更します。
        /// </summary>
        /// <param name="backgroundBorder">背景コントロール</param>
        /// <param name="foregroundTextBlock">前景コントロール</param>
        private void ChangeBrush(Border backgroundBorder, TextBlock foregroundTextBlock)
        {
            if (foregroundTextBlock != null)
            {
                // 設定値が無い場合にコントロールの反転色を設定する
                if (HighlightBackground == null) HighlightBackground = foregroundTextBlock.Foreground;
                if (HighlightForeground == null) HighlightForeground = backgroundBorder.Background;

                // 現在の値を保持させてからハイライト色を設定する
                if (_defaultForeground == null) _defaultForeground = foregroundTextBlock.Foreground;
                foregroundTextBlock.Foreground = HighlightForeground;
            }
            if (_defaultBackground == null) _defaultBackground = backgroundBorder.Background;
            backgroundBorder.Background = HighlightBackground;
        }

        /// <summary>
        /// 指定のコントロールの Brush を元の色に戻します。
        /// </summary>
        /// <param name="backgroundBorder">背景コントロール</param>
        /// <param name="foregroundTextBlock">前景コントロール</param>
        private void RestoreBrush(Border backgroundBorder, TextBlock foregroundTextBlock)
        {
            if (foregroundTextBlock != null) foregroundTextBlock.Foreground = _defaultForeground;
            backgroundBorder.Background = _defaultBackground;
        }

        /// <summary>
        /// ドロップされたファイルを通知します。
        /// </summary>
        /// <param name="data">ドロップイベントのデータ</param>
        private void NotifyDrop(IDataObject data)
        {
            if (TargetCommand == null) throw new InvalidOperationException("TargetCommand is null.");
            var fileNames = data.GetData(DataFormats.FileDrop) as string[];
            if (fileNames != null) TargetCommand.Execute(fileNames);
        }
        #endregion
    }
}
