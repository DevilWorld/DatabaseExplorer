using PocoGenerator.Domain.Models.Dto;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DatabaseExplorer.Enums;

namespace DatabaseExplorer.ToolWindows.ViewModel
{
    public class DbObjectViewModel : INotifyPropertyChanged
    {
        #region Data

        bool? _isChecked = false;
        DbObjectViewModel _parent;

        #endregion // Data

        public static List<DbObjectViewModel> CreateDbTreeStructure(IEnumerable<TablesWithColumnsDto> tables)
        {
            //DbObjectViewModel root = new DbObjectViewModel("Weapons")
            //{
            //    IsInitiallySelected = true,
            //    Children =
            //    {             
            //        new DbObjectViewModel("Blades")
            //        {
            //            Children =
            //            {
            //                new DbObjectViewModel("Dagger"),
            //                new DbObjectViewModel("Machete"),
            //                new DbObjectViewModel("Sword"),
            //            }
            //        },
            //        new DbObjectViewModel("Vehicles")
            //        {
            //            Children =
            //            {
            //                new DbObjectViewModel("Apache Helicopter"),
            //                new DbObjectViewModel("Submarine"),
            //                new DbObjectViewModel("Tank"),
            //            }
            //        },
            //        new DbObjectViewModel("Guns")
            //        {
            //            Children =
            //            {
            //                new DbObjectViewModel("AK 47"),
            //                new DbObjectViewModel("Beretta"),
            //                new DbObjectViewModel("Uzi"),
            //            }
            //        },
            //    }
            //};

            var root = new DbObjectViewModel("School");

            root.Children = tables.Select(x =>
            {
                var node = new DbObjectViewModel(x.Name)
                {
                    Children = x.Columns.Select(col =>
                    {
                        var child = new DbObjectViewModel(col.name);
                        child.NodeType = NodeType.Column;
                        return child;
                    }).ToList() 
                };

                node.NodeType = NodeType.Table;

                return node;
            }).ToList();

            root.Initialize();
            return new List<DbObjectViewModel> { root };
        }

        DbObjectViewModel(string name)
        {
            this.Name = name;
            this.Children = new List<DbObjectViewModel>();
        }

        void Initialize()
        {
            foreach (DbObjectViewModel child in this.Children)
            {
                child._parent = this;
                child.Initialize();
            }
        }

        #region Properties

        public List<DbObjectViewModel> Children { get; private set; }

        public bool IsInitiallySelected { get; private set; }

        public string Name { get; private set; }

        public bool IsEmpty { get { return !this.Children.Any(); } }

        #region IsChecked

        /// <summary>
        /// Gets/sets the state of the associated UI toggle (ex. CheckBox).
        /// The return value is calculated based on the check state of all
        /// child FooViewModels.  Setting this property to true or false
        /// will set all children to the same check state, and setting it 
        /// to any value will cause the parent to verify its check state.
        /// </summary>
        public bool? IsChecked
        {
            get { return _isChecked; }
            set { this.SetIsChecked(value, true, true); }
        }

        void SetIsChecked(bool? value, bool updateChildren, bool updateParent)
        {
            if (value == _isChecked)
                return;

            _isChecked = value;

            if (updateChildren && _isChecked.HasValue)
                this.Children.ForEach(c => c.SetIsChecked(_isChecked, true, false));

            if (updateParent && _parent != null)
                _parent.VerifyCheckState();

            this.OnPropertyChanged("IsChecked");
        }

        void VerifyCheckState()
        {
            bool? state = null;
            for (int i = 0; i < this.Children.Count; ++i)
            {
                bool? current = this.Children[i].IsChecked;
                if (i == 0)
                {
                    state = current;
                }
                else if (state != current)
                {
                    state = null;
                    break;
                }
            }
            this.SetIsChecked(state, false, true);
        }

        #endregion // IsChecked

        internal NodeType NodeType { get; private set; }

        #endregion // Properties

        #region INotifyPropertyChanged Members

        void OnPropertyChanged(string prop)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
