using System.ComponentModel;

namespace English.Maui.Controls;

public partial class SubjectCV : ContentView, INotifyPropertyChanged
{
    public string Text
    {
        get => _text;
        set
        {
            if (_text != value)
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
    }
    private string _text = "ASD";
    public SubjectCV()
	{
		InitializeComponent();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}