using English.Persons;
using English.UI.ViewModels;

namespace English.UI.Views;

public partial class Subject : UserControl, INotifyPropertyChanged
{
    public ObservableCollection<SubjectModel> Subjects { get; init; }
    public SubjectModel SubjectM
    {
        get => (SubjectModel)GetValue(SubjectModelProperty);
        set => SetValue(SubjectModelProperty, value);
    }
    public SubjectModel SelectedSubject
    {
        get => _selectedSubject;
        set
        {
            if (_selectedSubject != value)
            {
                _selectedSubject = value;
                IsFirst = _selectedSubject.BaseSubject.Person == Person.First;
                IsSecond = _selectedSubject.BaseSubject.Person == Person.Second;
                IsThird = _selectedSubject.BaseSubject.Person == Person.Third;
                IsSingular = _selectedSubject.BaseSubject.Number == Number.Singular;
                IsPlural = _selectedSubject.BaseSubject.Number == Number.Plural;
                //IsMale = _selectedSubject.BaseSubject.Gender == Gender.Male;
                //IsFemale = _selectedSubject.BaseSubject.Gender == Gender.Female;
                //IsNeuter = _selectedSubject.BaseSubject.Gender == Gender.Neuter;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }
    }
    public SubjectModel _selectedSubject;

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
    private string _text = "";

    public bool IsFirstOrThird
    {
        get => _isFirstOrThird;
        set
        {
            if (_isFirstOrThird != value)
            {
                _isFirstOrThird = value;
                OnPropertyChanged(nameof(IsFirstOrThird));
            }
        }
    }
    private bool _isFirstOrThird;

    public bool IsFirst
    {
        get => _isFirst;
        set
        {
            _isFirst = value;
            var bs = SelectedSubject.BaseSubject;
            if (value)
                SelectedSubject = Subjects.First(x =>
                x.BaseSubject.Number == bs.Number &&
                x.BaseSubject.Person == Person.First);
            OnPropertyChanged(nameof(IsFirst));
            IsFirstOrThird = IsFirst || IsThird;
            //OnPropertyChanged(nameof(IsFirstOrThird));
        }
    }
    private bool _isFirst;
    public bool IsSecond
    {
        get => _isSecond;
        set
        {
            _isSecond = value;
            if (value)
                SelectedSubject = Subjects.First(x => x.BaseSubject.Person == Person.Second);
            OnPropertyChanged(nameof(IsSecond));
            IsFirstOrThird = IsFirst || IsThird;
        }
    }
    private bool _isSecond;
    public bool IsThird
    {
        get => _isThird;
        set
        {
            _isThird = value;
            var bs = SelectedSubject.BaseSubject;
            if (value)
                SelectedSubject = Subjects.First(x =>
                x.BaseSubject.Number == bs.Number &&
                x.BaseSubject.Person == Person.Third);
            OnPropertyChanged(nameof(IsThird));
            IsFirstOrThird = IsFirst || IsThird;
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
            }
        }
    }
    private bool _isPlural = true;


    //public bool IsMale
    //{
    //    get => _isMale;
    //    set
    //    {
    //        if (_isMale != value)
    //        {
    //            _isMale = value;
    //            var bs = SelectedSubject.BaseSubject;
    //            if (value && bs.Person == Person.Third && bs.Number == Number.Singular)
    //                SelectedSubject = Subjects.First(x =>
    //                x.BaseSubject.Gender == Gender.Male &&
    //                x.BaseSubject.Number == Number.Singular &&
    //                x.BaseSubject.Person == Person.Third);
    //            OnPropertyChanged(nameof(IsMale));
    //        }
    //    }
    //}
    //private bool _isMale;
    //public bool IsFemale
    //{
    //    get => _isFemale;
    //    set
    //    {
    //        if (_isFemale != value)
    //        {
    //            _isFemale = value;
    //            //var bs = SelectedSubject.BaseSubject;
    //            //if (value && bs.Person == Person.Third && bs.Number == Number.Singular)
    //            //    SelectedSubject = Subjects.First(x =>
    //            //    x.BaseSubject.Gender == Gender.Female &&
    //            //    x.BaseSubject.Number == Number.Singular &&
    //            //    x.BaseSubject.Person == Person.Third);
    //            OnPropertyChanged(nameof(IsFemale));
    //        }
    //    }
    //}
    //private bool _isFemale = true;
    //public bool IsNeuter
    //{
    //    get => _isNeuter;
    //    set
    //    {
    //        if (_isNeuter != value)
    //        {
    //            _isNeuter = value;
    //            var bs = SelectedSubject.BaseSubject;
    //            if (value && bs.Person == Person.Third && bs.Number == Number.Singular)
    //                SelectedSubject = Subjects.First(x =>
    //                x.BaseSubject.Gender == Gender.Neuter &&
    //                x.BaseSubject.Number == Number.Singular &&
    //                x.BaseSubject.Person == Person.Third);
    //            OnPropertyChanged(nameof(IsNeuter));
    //        }
    //    }
    //}
    //private bool _isNeuter = true;
    public Subject()
    {
        InitializeComponent();
        Subjects = new ObservableCollection<SubjectModel>();
        foreach (var item in SubjectPersonalPronouns.All)
            Subjects.Add(new SubjectModel(item));
        SelectedSubject = Subjects.First();
        SubjectM = SelectedSubject;
        OnPropertyChanged(nameof(Subjects));
        OnPropertyChanged(nameof(SelectedSubject));
        OnPropertyChanged(nameof(SubjectM));
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public static readonly DependencyProperty SubjectModelProperty =
        DependencyProperty.Register(nameof(SubjectM), typeof(object),
          typeof(Subject), new PropertyMetadata(""));
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        SubjectM = SelectedSubject;
        OnPropertyChanged(nameof(SubjectM));
    }
}
