using English.Maui.ViewModel;

namespace English.Maui;

public partial class MainPage : ContentPage
{
    int count = 0;
    private MainPageViewModel viewModel = new();
    public MainPage()
    {
        InitializeComponent();
        viewModel.Title = "Morteza";
        BindingContext = viewModel;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        viewModel.Title = "Morteza"+count;
        //viewModel.MoP = "Morteza"+count;
        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}