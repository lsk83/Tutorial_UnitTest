using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace Tutorial_UnitTest.Model
{    
    public partial class Car : ObservableObject
    {
        [ObservableProperty]
        public string _name = string.Empty;

        [ObservableProperty]
        public int _price;

    }
}
