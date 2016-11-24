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
    using System.Collections.Generic;
    using System.Windows.Media;
    using System.ComponentModel;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.Shell;
    using System.Diagnostics;
    using System.Drawing;
    using Microsoft.VisualStudio.PlatformUI;
    using System.Linq;

    /// <summary>
    /// Interaction logic for DbExplorerControl.
    /// </summary>
    public partial class DbExplorerControl : UserControl
    {
        public TreeView TreeView
        {
            get { return tvDatabase; }
        }
        
        public ContextMenu BindContextMenusForTreeView
        {
            get
            {
                ContextMenu menu = new ContextMenu();
                menu.Items.Add("hakjchkjfgdj");                
                menu.IsOpen = true;
                return menu;
            }            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbExplorerControl"/> class.
        /// </summary>
        public DbExplorerControl()
        {
            this.InitializeComponent();

            //VSColorPaint();
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

        private void VSColorPaint()
        {
            DbExplorerPackage package = new DbExplorerPackage();

            //getIVSUIShell2
            IVsUIShell2 uiShell2 = Package.GetGlobalService(typeof(SVsUIShell)) as IVsUIShell2;
            Debug.Assert(uiShell2 != null, "failed to get IVsUIShell2");

            if (uiShell2 != null)
            {
                //get the COLORREF structure
                uint win32Color;
                uiShell2.GetVSSysColorEx((int)VSSYSCOLOR.VSCOLOR_DARK, out win32Color);

                //translate it to a managed Color structure
                System.Drawing.Color myColor = ColorTranslator.FromWin32((int)win32Color);
                //use it
                //e.Graphics.FillRectangle(new SolidBrush(myColor), 0, 0, 100, 100);

                var bc = EnvironmentColors.ToolWindowBackgroundColorKey;

                var converter = new BrushConverter();
                var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#" + myColor.Name);
                tvDatabase.Background = brush;
            }
        }

        private void BindContextMenus(TreeViewItem treeViewItem)
        {
            ContextMenu menu = new ContextMenu();
            menu.Items.Add("hakjchkjfgdj");
            menu.PlacementTarget = treeViewItem;
            menu.IsOpen = true;
        }

        private void tvDatabase_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            //TODO Change if condition to check for the node type
            if (!((HeaderedItemsControl)e.Source).Header.ToString().Contains("tbl"))
                e.Handled = true;
        }               
    }
}