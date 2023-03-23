using English.UI.ViewModels;

namespace English.UI.Views;

public partial class VerbUserControl : UserControl
{
    public ObservableCollection<VerbModel> Verbs { get; init; }
    public VerbModel VerbM
    {
        get => (VerbModel)GetValue(VerbModelProperty);
        set => SetValue(VerbModelProperty, value);
    }
    public VerbModel SelectedVerb
    {
        get => _selectedVerb;
        set
        {
            if (_selectedVerb != value)
            {
                _selectedVerb = value;
                OnPropertyChanged(nameof(_selectedVerb));
            }
        }
    }
    private VerbModel _selectedVerb;
    public VerbUserControl()
    {
        InitializeComponent();
        Verbs = new ObservableCollection<VerbModel>();
        var verb = new Verb("fallow");
        foreach (var item in verb.AllTenses)
            Verbs.Add(new VerbModel(item));
        SelectedVerb = Verbs.First();
        VerbM = SelectedVerb;
        OnPropertyChanged(nameof(Verbs));
        OnPropertyChanged(nameof(SelectedVerb));
        OnPropertyChanged(nameof(VerbM));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public static readonly DependencyProperty VerbModelProperty =
        DependencyProperty.Register(nameof(VerbM), typeof(object),
          typeof(VerbUserControl), new PropertyMetadata(""));
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
