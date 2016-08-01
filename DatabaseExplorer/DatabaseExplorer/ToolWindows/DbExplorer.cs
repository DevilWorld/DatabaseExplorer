//------------------------------------------------------------------------------
// <copyright file="DbExplorer.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace DatabaseExplorer.ToolWindows
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;
    using System.ComponentModel.Design;
    using DatabaseExplorer.ToolWindows.Commands;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("6740dce8-4d8b-46a2-9a01-31763be9445f")]
    public class DbExplorer : ToolWindowPane
    {
        public DbExplorerControl control;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbExplorer"/> class.
        /// </summary>
        public DbExplorer() : base(null)
        {
            this.Caption = "DbExplorer";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            //this.Content = new DbExplorerControl();

            control = new DbExplorerControl();
            base.Content = control;

            this.ToolBar = new CommandID(new Guid(DbExplorerCommand.guidDbExplorerPackageCmdSet), DbExplorerCommand.ToolbarID);
            this.ToolBarLocation = (int)VSTWT_LOCATION.VSTWT_TOP;
        }
    }
}
