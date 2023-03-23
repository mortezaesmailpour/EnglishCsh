using English.Persons;
using English.UI.Models;

namespace English.Maui.Controls;

public partial class SubjectCV : ContentView, INotifyPropertyChanged
{
    public event EventHandler ModelChanged;
    public SubjectCV()
	{
		InitializeComponent();
        BindingContext = this;
        Subjects = new ObservableCollection<SubjectModel>();
        foreach (var item in SubjectPersonalPronouns.All)
            Subjects.Add(new SubjectModel(item));
        _text = "Mahsa";
        OnPropertyChanged(nameof(Text));
        OnPropertyChanged(nameof(Result));
        _selectedSubject = Subjects.First(s => s.Name=="She");
        OnPropertyChanged(nameof(Subjects));
        OnPropertyChanged(nameof(SelectedSubject));
        UpdateView(_selectedSubject.BaseSubject);
    }

    public SubjectModel GetSubject() => SelectedSubject;

    private void UpdateView(ISubject subject)
    {
        ModelChanged?.Invoke(this, EventArgs.Empty);
        _isFirst = subject.Person == Person.First;
        _isSecond = subject.Person == Person.Second;
        _isThird = subject.Person == Person.Third;
        _isSingular = subject.Number == Number.Singular;
        _isPlural = subject.Number == Number.Plural;
        _isMale = subject.Gender == Gender.Male;
        _isFemale = subject.Gender == Gender.Female;
        _isNeuter = subject.Gender == Gender.Neuter;
        OnPropertyChanged(nameof(IsFirst));
        OnPropertyChanged(nameof(IsSecond));
        OnPropertyChanged(nameof(IsThird));
        OnPropertyChanged(nameof(IsSingular));
        OnPropertyChanged(nameof(IsPlural));
        OnPropertyChanged(nameof(IsMale));
        OnPropertyChanged(nameof(IsFemale));
        OnPropertyChanged(nameof(IsNeuter));
        OnPropertyChanged(nameof(IsFirstOrThird));
        OnPropertyChanged(nameof(IsThirdAndSingular));
        OnPropertyChanged(nameof(IsNotFirstAndSingular));
        OnPropertyChanged(nameof(Result));
    }
    public ObservableCollection<SubjectModel> Subjects { get; init; }

    public SubjectModel SelectedSubject
    {
        get => _selectedSubject;
        set
        {
            if (_selectedSubject != value)
            {
                _selectedSubject = value;
                OnPropertyChanged();
                UpdateView(_selectedSubject.BaseSubject);
            }
        }
    }
    private SubjectModel _selectedSubject;

    public string? Result => string.IsNullOrWhiteSpace(_text) || (IsFirst && IsSingular)
        ? _selectedSubject?.ToString()
        : (IsFirst ? _text + " and I" : IsSecond ? "you and " + _text : _text)
        + " (" + _selectedSubject?.ToString() + ")";

    public string Text
    {
        get => _text;
        set
        {
            if (_text != value)
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(Result));
                ModelChanged?.Invoke(this, new EventArgs());
            }
        }
    }
    private string _text = string.Empty;

    public bool IsFirstOrThird => _isFirst || _isThird;
    public bool IsThirdAndSingular => _isThird && _isSingular;
    public bool IsNotFirstAndSingular => !(_isFirst && _isSingular);

    public bool IsFirst
    {
        get => _isFirst;
        set
        {
            if (_isFirst != value)
            {
                _isFirst = value;
                var bs = SelectedSubject.BaseSubject;
                if (value && bs.Person != Person.First)
                    SelectedSubject = Subjects.First(x =>
                    x.BaseSubject.Number == bs.Number &&
                    x.BaseSubject.Person == Person.First);
                OnPropertyChanged(nameof(IsFirst));
                OnPropertyChanged(nameof(IsFirstOrThird));
                OnPropertyChanged(nameof(IsThirdAndSingular));
            }
        }
    }
    private bool _isFirst;
    public bool IsSecond
    {
        get => _isSecond;
        set
        {
            if (_isSecond != value)
            {
                _isSecond = value;
                var bs = SelectedSubject.BaseSubject;
                if (value && bs.Person != Person.Second)
                    SelectedSubject = Subjects.First(x => x.BaseSubject.Person == Person.Second);
                OnPropertyChanged(nameof(IsSecond));
                OnPropertyChanged(nameof(IsFirstOrThird));
                OnPropertyChanged(nameof(IsThirdAndSingular));
            }
        }
    }
    private bool _isSecond;
    public bool IsThird
    {
        get => _isThird;
        set
        {
            if (_isThird != value)
            {
                _isThird = value;
                var bs = SelectedSubject.BaseSubject;
                if (value && bs.Person != Person.Third)
                    SelectedSubject = Subjects.First(x =>
                    x.BaseSubject.Number == bs.Number &&
                    x.BaseSubject.Gender == bs.Gender &&
                    x.BaseSubject.Person == Person.Third);
                OnPropertyChanged(nameof(IsThird));
                OnPropertyChanged(nameof(IsFirstOrThird));
                OnPropertyChanged(nameof(IsThirdAndSingular));
            }
        }
    }
    private bool _isThird;

    public bool IsSingular
    {
        get => _isSingular;
        set
        {
            if (_isSingular != value)
            {
                _isSingular = value;
                var bs = SelectedSubject.BaseSubject;
                if (value && bs.Person != Person.Second)
                    SelectedSubject = Subjects.First(x =>
                    x.BaseSubject.Number == Number.Singular &&
                    x.BaseSubject.Person == bs.Person);
                OnPropertyChanged(nameof(IsSingular));
                OnPropertyChanged(nameof(IsThirdAndSingular));
            }
        }
    }
    private bool _isSingular;
    public bool IsPlural
    {
        get => _isPlural;
        set
        {
            if (_isPlural != value)
            {
                _isPlural = value;
                var bs = SelectedSubject.BaseSubject;
                if (value && bs.Person != Person.Second)
                    SelectedSubject = Subjects.First(x =>
                    x.BaseSubject.Number == Number.Plural &&
                    x.BaseSubject.Person == bs.Person);
                OnPropertyChanged(nameof(IsPlural));
                OnPropertyChanged(nameof(IsThirdAndSingular));
            }
        }
    }
    private bool _isPlural = true;

    public bool IsMale
    {
        get => _isMale;
        set
        {
            if (_isMale != value)
            {
                _isMale = value;
                var bs = SelectedSubject?.BaseSubject;
                if (value)
                    SelectedSubject = Subjects.First(x =>
                    x.BaseSubject.Person == Person.Third &&
                    x.BaseSubject.Number == Number.Singular &&
                    x.BaseSubject.Gender == Gender.Male);
                OnPropertyChanged(nameof(IsMale));
            }
        }
    }
    private bool _isMale = true;
    public bool IsFemale
    {
        get => _isFemale;
        set
        {
            if (_isFemale != value)
            {
                _isFemale = value;
                var bs = SelectedSubject?.BaseSubject;
                if (value)
                    SelectedSubject = Subjects.First(x =>
                    x.BaseSubject.Person == Person.Third &&
                    x.BaseSubject.Number == Number.Singular &&
                    x.BaseSubject.Gender == Gender.Female);
                OnPropertyChanged(nameof(IsFemale));
            }
        }
    }
    private bool _isFemale = true;
    public bool IsNeuter
    {
        get => _isNeuter;
        set
        {
            if (_isNeuter != value)
            {
                _isNeuter = value;
                if (value)
                    SelectedSubject = Subjects.First(x =>
                    x.BaseSubject.Person == Person.Third &&
                    x.BaseSubject.Number == Number.Singular &&
                    x.BaseSubject.Gender == Gender.Neuter);
                OnPropertyChanged(nameof(IsNeuter));
            }
        }
    }
    private bool _isNeuter = true;
}