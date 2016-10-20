//------------------------------------------------------------------------------
// <copyright file="DbExplorerCommand.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Data.ConnectionUI;
using System.Windows.Forms;
using PocoGenerator.Domain;
using System.Collections.Generic;

namespace DatabaseExplorer.ToolWindows.Commands
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class DbExplorerCommand
    {
        private DbExplorer window;

        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("7dbe848b-4889-4627-a5ce-c9e1ccc10f93");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        public const string guidDbExplorerPackageCmdSet = "7dbe848b-4889-4627-a5ce-c9e1ccc10f93";  // get the GUID from the .vsct file
        //public const uint cmdidWindowsMedia = 0x100;
        //public const int cmdidWindowsMediaOpen = 0x132;
        public const int cmdidDbConnect = 0x200;
        public const int ToolbarID = 0x1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbExplorerCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private DbExplorerCommand(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.ShowToolWindow, menuCommandID);
                commandService.AddCommand(menuItem);
            }            
        }
        
        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static DbExplorerCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new DbExplorerCommand(package);
        }

        /// <summary>
        /// Shows the tool window when the menu item is clicked.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void ShowToolWindow(object sender, EventArgs e)
        {
            // Get the instance number 0 of this tool window. This window is single instance so this instance
            // is actually the only one.
            // The last flag is set to true so that if the tool window does not exists it will be created.
            window =(DbExplorer) this.package.FindToolWindow(typeof(DbExplorer), 0, true);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("Cannot create tool window");
            }

            IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());

            // Create the handles for the toolbar command. 
            var mcs = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;

            var dbConnectCommandId = new CommandID(new Guid(guidDbExplorerPackageCmdSet), cmdidDbConnect);
            var dbConnectMenuCommand = new MenuCommand(new EventHandler(
                DbConnectCommandHandler), dbConnectCommandId);
            mcs.AddCommand(dbConnectMenuCommand);
        }

        #region Command Handlers

        private void DbConnectCommandHandler(object sender, EventArgs arguments)
        {
            //SQL DataSource
            //var sqlDataSource = new DataSource("MicrosoftSqlServer", "Microsoft SQL SERVER");
            //sqlDataSource.Providers.Add(DataProvider.SqlDataProvider);

            DataConnectionDialog dcd = new DataConnectionDialog();
            dcd.DataSources.Add(DataSource.SqlDataSource);
            dcd.DataSources.Add(DataSource.SqlFileDataSource);

            dcd.SelectedDataSource = DataSource.SqlDataSource;
            dcd.SelectedDataProvider = DataProvider.SqlDataProvider;
            

            //DataSource.AddStandardDataSources(dcd);

            if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
            {
                Global.ConnectionString = dcd.ConnectionString;


                List<string> lstItems = new List<string>();
                lstItems.Add("Apple");
                lstItems.Add("Orange");
                lstItems.Add("Grapes");

                foreach (var item in lstItems)
                {
                    window.control.tvDatabase.Items.Add(item);                    
                }
            }
        }

        #endregion

        #region Helper Methods



        #endregion
    }
}
