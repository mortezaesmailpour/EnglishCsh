using English.Persons;
using English.Verbs;

namespace English.UI.Views;

public partial class VerbUC : UserControl, INotifyPropertyChanged
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
                var tense = value.BaseVerb.Tense;
                _isContinuous = tense.Is(Tense.Continuous);
                _isPerfect = tense.Is(Tense.Perfect);
                _isPassive = tense.Is(Tense.Passive);
                _isPresent = tense.Is(Tense.Present);
                _isPast = tense.Is(Tense.Past);
                _isFuture = tense.Is(Tense.Future);
                _isConditional = tense.Is(Tense.Conditional);
                OnPropertyChanged(nameof(IsContinuous));
                OnPropertyChanged(nameof(IsPerfect));
                OnPropertyChanged(nameof(IsPassive));
                OnPropertyChanged(nameof(IsPresent));
                OnPropertyChanged(nameof(IsPast));
                OnPropertyChanged(nameof(IsFuture));
                OnPropertyChanged(nameof(IsConditional));
                OnPropertyChanged(nameof(SelectedVerb));
            }
        }
    }
    public VerbModel _selectedVerb;
    public bool IsContinuous
    {
        get => _isContinuous;
        set
        {
            var tense = SelectedVerb?.BaseVerb.Tense ?? Tense.PresentSimple;
            _ = value
                ? SelectedVerb = GetVerbModel(tense | Tense.Continuous)
                : SelectedVerb = GetVerbModel((tense & Tense.Times) | (tense & Tense.Passive) | (tense & Tense.Perfect));
            SetField(ref _isContinuous, value);
        }
    }
    private bool _isContinuous;
    public bool IsPerfect
    {
        get => _isPerfect;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            _ = value
                ? SelectedVerb = GetVerbModel(tense | Tense.Perfect)
                : SelectedVerb = GetVerbModel((tense & Tense.Times) | (tense & Tense.Passive) | (tense & Tense.Continuous));
            SetField(ref _isPerfect, value);
        }
    }
    private bool _isPerfect;

    public bool IsPassive
    {
        get => _isPassive;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            _ = value
                ? SelectedVerb = GetVerbModel(tense | Tense.Passive)
                : SelectedVerb = GetVerbModel((tense & Tense.Times) | (tense & Tense.Perfect) | (tense & Tense.Continuous));
            SetField(ref _isPassive, value);
        }
    }
    private bool _isPassive;

    public bool IsPresent
    {
        get => _isPresent;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            if (value)
                SelectedVerb = GetVerbModel((tense & Tense.Forms) | Tense.Present);
            SetField(ref _isPresent, value);
        }
    }
    private bool _isPresent;
    public bool IsPast
    {
        get => _isPast;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            if (value)
                SelectedVerb = GetVerbModel((tense & Tense.Forms) | Tense.Past);
            SetField(ref _isPast, value);
        }
    }
    private bool _isPast;
    public bool IsFuture
    {
        get => _isFuture;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            if (value)
                SelectedVerb = GetVerbModel((tense & Tense.Forms) | Tense.Future);
            SetField(ref _isFuture, value);
        }
    }
    private bool _isFuture;
    public bool IsConditional
    {
        get => _isConditional;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            if (value)
                SelectedVerb = GetVerbModel((tense & Tense.Forms) | Tense.Conditional);
            SetField(ref _isConditional, value);
        }
    }
    private bool _isConditional;

    VerbModel GetVerbModel(Tense tense) => Verbs.FirstOrDefault(x => tense == x.BaseVerb.Tense) ?? throw new NullReferenceException($"{tense} does not contain Tenses.");

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public VerbUC()
    {
        InitializeComponent();
        Verbs = new ObservableCollection<VerbModel>();
        var verb = new Verb("write","wrote","written");
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
          typeof(VerbUC), new PropertyMetadata(""));
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        VerbM = SelectedVerb;
        OnPropertyChanged(nameof(VerbM));
    }
}
