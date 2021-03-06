﻿//------------------------------------------------------------------------------
// <copyright file="DbExplorerCommand.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using DatabaseExplorer.ToolWindows;

namespace DatabaseExplorer.ToolbarCommands
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
        public const uint cmdidWindowsMedia = 0x100;
        public const int cmdidWindowsMediaOpen = 0x132;
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
            var toolbarbtnCmdID = new CommandID(new Guid(DbExplorerCommand.guidDbExplorerPackageCmdSet),
                DbExplorerCommand.cmdidWindowsMediaOpen);
            var menuItem = new MenuCommand(new EventHandler(
                ButtonHandler), toolbarbtnCmdID);
            mcs.AddCommand(menuItem);


            var mcs1 = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            var toolbarbtnCmdID1 = new CommandID(new Guid(DbConnectCommand.guidDbExplorerPackageCmdSet),
                DbConnectCommand.cmdidDbConnect);
            var menuItem1 = new MenuCommand(new EventHandler(
                ButtonHandler), toolbarbtnCmdID1);
            mcs1.AddCommand(menuItem1);
        }

        private void ButtonHandler(object sender, EventArgs arguments)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //DialogResult result = openFileDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    window.control.MediaPlayer.Source = new System.Uri(openFileDialog.FileName);
            //}
            
            
        }
    }
}
