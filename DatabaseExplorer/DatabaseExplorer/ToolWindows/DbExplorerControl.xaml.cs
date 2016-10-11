//------------------------------------------------------------------------------
// <copyright file="DbExplorerControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace DatabaseExplorer.ToolWindows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DbExplorerControl.
    /// </summary>
    public partial class DbExplorerControl : UserControl
    {
        //public System.Windows.Controls.MediaElement MediaPlayer
        //{
        //    get { return mediaElement1; }
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="DbExplorerControl"/> class.
        /// </summary>
        public DbExplorerControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "DbExplorer");
        }        
    }
}