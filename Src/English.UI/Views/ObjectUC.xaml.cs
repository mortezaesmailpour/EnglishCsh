using English.Persons;

namespace English.UI.Views;

public partial class ObjectUC : UserControl, INotifyPropertyChanged
{
    
    public event PropertyChangedEventHandler? PropertyChanged;

    public static readonly DependencyProperty ObjectModelProperty =
        DependencyProperty.Register(nameof(ObjectM), typeof(object),
          typeof(ObjectUC), new PropertyMetadata(""));
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Result));
        ObjectM = new(_selectedObject.BaseObject, Result);
        UpdateView();
        OnPropertyChanged(nameof(ObjectM));
    }
}
//using English.Persons;

//namespace English.UI.Views;

//public partial class ObjectUC : UserControl, INotifyPropertyChanged
//{
//    public ObservableCollection<ObjectModel> Objects { get; init; }
//    public ObjectModel ObjectM
//    {
//        get => (ObjectModel)GetValue(ObjectModelProperty);
//        set => SetValue(ObjectModelProperty, value);
//    }
//    public ObjectModel SelectedObject
//    {
//        get => _selectedObject;
//        set
//        {
//            if (_selectedObject != value)
//            {
//                _selectedObject = value;
//                OnPropertyChanged();
//                UpdateView();
//            }
//        }
//    }
//    public ObjectModel _selectedObject;

//    private void UpdateView()
//    {
//        _isFirst = _selectedObject.BaseObject.Person == Person.First;
//        _isSecond = _selectedObject.BaseObject.Person == Person.Second;
//        _isThird = _selectedObject.BaseObject.Person == Person.Third;
//        _isSingular = _selectedObject.BaseObject.Number == Number.Singular;
//        _isPlural = _selectedObject.BaseObject.Number == Number.Plural;
//        _isMale = _selectedObject.BaseObject.Gender == Gender.Male;
//        _isFemale = _selectedObject.BaseObject.Gender == Gender.Female;
//        _isNeuter = _selectedObject.BaseObject.Gender == Gender.Neuter;
//        OnPropertyChanged(nameof(IsFirst));
//        OnPropertyChanged(nameof(IsSecond));
//        OnPropertyChanged(nameof(IsFirstOrThird));
//        OnPropertyChanged(nameof(IsThird));
//        OnPropertyChanged(nameof(IsSingular));
//        OnPropertyChanged(nameof(IsThirdAndSingular));
//        OnPropertyChanged(nameof(IsNotFirstAndSingular));
//        OnPropertyChanged(nameof(IsPlural));
//        OnPropertyChanged(nameof(IsMale));
//        OnPropertyChanged(nameof(IsFemale));
//        OnPropertyChanged(nameof(IsNeuter));
//        OnPropertyChanged(nameof(Result));
//    }


//    public string Text
//    {
//        get => _text;
//        set
//        {
//            if (_text != value)
//            {
//                _text = value;
//                OnPropertyChanged(nameof(Text));
//                OnPropertyChanged(nameof(Result));
//                ObjectM = new(_selectedObject.BaseObject, Result);
//                OnPropertyChanged(nameof(ObjectM));
//            }
//        }
//    }
//    private string _text = "";
//    public string? Result => string.IsNullOrWhiteSpace(_text) || (IsFirst && IsSingular)
//        ?
//         _selectedObject?.ToString()
//        :
//            (IsFirst ?
//                _text.EndsWith(" and I") ? _text : _text + " and I"
//            : IsSecond ?
//                _text.StartsWith("you and ") ? _text : "you and " + _text
//            : _text)
//            + " (" + _selectedObject?.ToString() + ")";
//    //     +
//    //+ " (" + _selectedObject?.ToString() + ")";


//    public bool IsFirstOrThird => _isFirst || _isThird;
//    public bool IsThirdAndSingular => _isThird && _isSingular;
//    public bool IsNotFirstAndSingular => !(_isFirst && _isSingular);



//    public bool IsFirst
//    {
//        get => _isFirst;
//        set
//        {
//            _isFirst = value;
//            var bs = SelectedObject.BaseObject;
//            if (value)
//                SelectedObject = Objects.First(x =>
//                x.BaseObject.Number == bs.Number &&
//                x.BaseObject.Person == Person.First);
//            OnPropertyChanged(nameof(IsFirst));
//            OnPropertyChanged(nameof(IsFirstOrThird));
//            OnPropertyChanged(nameof(IsThirdAndSingular));
//        }
//    }
//    private bool _isFirst;
//    public bool IsSecond
//    {
//        get => _isSecond;
//        set
//        {
//            _isSecond = value;
//            if (value)
//                SelectedObject = Objects.First(x => x.BaseObject.Person == Person.Second);
//            OnPropertyChanged(nameof(IsSecond));
//            OnPropertyChanged(nameof(IsFirstOrThird));
//            OnPropertyChanged(nameof(IsThirdAndSingular));
//        }
//    }
//    private bool _isSecond;
//    public bool IsThird
//    {
//        get => _isThird;
//        set
//        {
//            _isThird = value;
//            var bs = SelectedObject.BaseObject;
//            if (value)
//                SelectedObject = Objects.First(x =>
//                x.BaseObject.Number == bs.Number &&
//                x.BaseObject.Person == Person.Third);
//            OnPropertyChanged(nameof(IsThird));
//            OnPropertyChanged(nameof(IsFirstOrThird));
//            OnPropertyChanged(nameof(IsThirdAndSingular));
//        }
//    }
//    private bool _isThird;

//    public bool IsSingular
//    {
//        get => _isSingular;
//        set
//        {
//            if (_isSingular != value)
//            {
//                _isSingular = value;
//                var bs = SelectedObject.BaseObject;
//                if (value && bs.Person != Person.Second)
//                    SelectedObject = Objects.First(x =>
//                    x.BaseObject.Number == Number.Singular &&
//                    x.BaseObject.Person == bs.Person);
//                OnPropertyChanged(nameof(IsSingular));
//                OnPropertyChanged(nameof(IsThirdAndSingular));
//            }
//        }
//    }
//    private bool _isSingular;
//    public bool IsPlural
//    {
//        get => _isPlural;
//        set
//        {
//            if (_isPlural != value)
//            {
//                _isPlural = value;
//                var bs = SelectedObject.BaseObject;
//                if (value && bs.Person != Person.Second)
//                    SelectedObject = Objects.First(x =>
//                    x.BaseObject.Number == Number.Plural &&
//                    x.BaseObject.Person == bs.Person);
//                OnPropertyChanged(nameof(IsPlural));
//                OnPropertyChanged(nameof(IsThirdAndSingular));
//            }
//        }
//    }
//    private bool _isPlural = true;

//    public bool IsMale
//    {
//        get => _isMale;
//        set
//        {
//            if (_isMale != value)
//            {
//                _isMale = value;
//                var bs = SelectedObject?.BaseObject;
//                if (value)
//                    SelectedObject = Objects.First(x =>
//                    x.BaseObject.Person == Person.Third &&
//                    x.BaseObject.Number == Number.Singular &&
//                    x.BaseObject.Gender == Gender.Male);
//                OnPropertyChanged(nameof(IsMale));
//            }
//        }
//    }
//    private bool _isMale = true;
//    public bool IsFemale
//    {
//        get => _isFemale;
//        set
//        {
//            if (_isFemale != value)
//            {
//                _isFemale = value;
//                var bs = SelectedObject?.BaseObject;
//                if (value)
//                    SelectedObject = Objects.First(x =>
//                    x.BaseObject.Person == Person.Third &&
//                    x.BaseObject.Number == Number.Singular &&
//                    x.BaseObject.Gender == Gender.Female);
//                OnPropertyChanged(nameof(IsFemale));
//            }
//        }
//    }
//    private bool _isFemale = true;
//    public bool IsNeuter
//    {
//        get => _isNeuter;
//        set
//        {
//            if (_isNeuter != value)
//            {
//                _isNeuter = value;
//                if (value)
//                    SelectedObject = Objects.First(x =>
//                    x.BaseObject.Person == Person.Third &&
//                    x.BaseObject.Number == Number.Singular &&
//                    x.BaseObject.Gender == Gender.Neuter);
//                OnPropertyChanged(nameof(IsNeuter));
//            }
//        }
//    }
//    private bool _isNeuter = true;
//    public ObjectUC()
//    {
//        Objects = new ObservableCollection<ObjectModel>();
//        foreach (var item in ObjectPersonalPronouns.All)
//            Objects.Add(new ObjectModel(item));
//        _selectedObject = Objects.First();
//        ObjectM = new(_selectedObject.BaseObject, Result);
//        OnPropertyChanged(nameof(Objects));
//        OnPropertyChanged(nameof(SelectedObject));
//        UpdateView();
//        OnPropertyChanged(nameof(ObjectM));

//    }
//    public event PropertyChangedEventHandler? PropertyChanged;
    
//    public static readonly DependencyProperty ObjectModelProperty =
//        DependencyProperty.Register(nameof(ObjectM), typeof(object),
//          typeof(ObjectUC), new PropertyMetadata(""));
//    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
//    {
//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//    }

//    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
//    {
//        ObjectM = SelectedObject;
//        OnPropertyChanged(nameof(ObjectM));
//    }
//}
