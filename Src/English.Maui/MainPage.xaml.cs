using English.Maui.ViewModel;

namespace English.Maui;

public partial class MainPage : ContentPage
{
    private MainPageViewModel viewModel = new();
    public MainPage()
    {
        InitializeComponent();
        viewModel.Title = "Morteza";
        BindingContext = viewModel;
    }

    private void OnModelChanged(object sender, EventArgs e)
    {
        var sbj = mySubject?.GetSubject();
        var obj = myObject?.GetObject();
        var vrb = myVerb?.GetVerb();

        if (vrb != null)
        {
            var result = $"{mySubject.Result} {vrb.ToStringFor(sbj.BaseSubject)} {myObject.Result}";
            viewModel.Title = result;
        }
    }
}