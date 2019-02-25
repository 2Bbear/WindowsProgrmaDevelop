using DevExpress.Mvvm;
using HowToModule0225.Common;
using System;

namespace HowToModule0225.Main.ViewModels
{
    [Serializable]
    public class NavigationItem : INavigationItem, ISupportState<NavigationItem>
    {
        public string Caption { get; set; }
        public NavigationItem() { }
        public NavigationItem(string caption)
        {
            Caption = caption;
        }

        #region Serialization
        NavigationItem ISupportState<NavigationItem>.SaveState()
        {
            return this;
        }
        void ISupportState<NavigationItem>.RestoreState(NavigationItem state)
        {
            Caption = state.Caption;
        }
        #endregion
    }
}
