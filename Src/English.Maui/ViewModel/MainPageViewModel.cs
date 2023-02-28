using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Maui.ViewModel;

public class MainPageViewModel : BaseViewModel
{
    public string Title
    {
        get => _title;
        set => SetField(ref _title, value);
    }
    private string _title;
}
