using English.Persons;
using English.UI.Models;

namespace English.Maui.Controls;

public partial class ObjectCV : ContentView, INotifyPropertyChanged
{
	public ObjectCV()
	{
		InitializeComponent();
        BindingContext = this;
        Objects = new ObservableCollection<ObjectModel>();
        foreach (var item in ObjectPersonalPronouns.All)
            Objects.Add(new ObjectModel(item));
        _selectedObject = Objects.First();
        OnPropertyChanged(nameof(Objects));
        OnPropertyChanged(nameof(SelectedObject));
        UpdateView(_selectedObject.BaseObject);
    }
    private void UpdateView(IObject @object)
    {
        _isFirst = @object.Person == Person.First;
        _isSecond = @object.Person == Person.Second;
        _isThird = @object.Person == Person.Third;
        _isSingular = @object.Number == Number.Singular;
        _isPlural = @object.Number == Number.Plural;
        _isMale = @object.Gender == Gender.Male;
        _isFemale = @object.Gender == Gender.Female;
        _isNeuter = @object.Gender == Gender.Neuter;
        OnPropertyChanged(nameof(IsFirst));
        OnPropertyChanged(nameof(IsSecond));
        OnPropertyChanged(nameof(IsFirstOrThird));
        OnPropertyChanged(nameof(IsThird));
        OnPropertyChanged(nameof(IsSingular));
        OnPropertyChanged(nameof(IsThirdAndSingular));
        OnPropertyChanged(nameof(IsNotFirstAndSingular));
        OnPropertyChanged(nameof(IsPlural));
        OnPropertyChanged(nameof(IsMale));
        OnPropertyChanged(nameof(IsFemale));
        OnPropertyChanged(nameof(IsNeuter));
        OnPropertyChanged(nameof(Result));
    }

    public ObservableCollection<ObjectModel> Objects { get; init; }

    public ObjectModel SelectedObject
    {
        get => _selectedObject;
        set
        {
            if (_selectedObject != value)
            {
                _selectedObject = value;
                OnPropertyChanged(nameof(SelectedObject));
                UpdateView(_selectedObject.BaseObject);
            }
        }
    }
    private ObjectModel _selectedObject;

    public string? Result => string.IsNullOrWhiteSpace(_text) || (IsFirst && IsSingular)
        ? _selectedObject?.ToString()
        : (IsFirst ? _text + " and I" : IsSecond ? "you and " + _text : _text)
        + " (" + _selectedObject?.ToString() + ")";

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
            _isFirst = value;
            var bs = SelectedObject.BaseObject;
            if (value)
                SelectedObject = Objects.First(x =>
                x.BaseObject.Number == bs.Number &&
                x.BaseObject.Person == Person.First);
            OnPropertyChanged(nameof(IsFirst));
            OnPropertyChanged(nameof(IsFirstOrThird));
            OnPropertyChanged(nameof(IsThirdAndSingular));
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
                SelectedObject = Objects.First(x => x.BaseObject.Person == Person.Second);
            OnPropertyChanged(nameof(IsSecond));
            OnPropertyChanged(nameof(IsFirstOrThird));
            OnPropertyChanged(nameof(IsThirdAndSingular));
        }
    }
    private bool _isSecond;
    public bool IsThird
    {
        get => _isThird;
        set
        {
            _isThird = value;
            var bs = SelectedObject.BaseObject;
            if (value)
                SelectedObject = Objects.First(x =>
                x.BaseObject.Number == bs.Number &&
                x.BaseObject.Person == Person.Third);
            OnPropertyChanged(nameof(IsThird));
            OnPropertyChanged(nameof(IsFirstOrThird));
            OnPropertyChanged(nameof(IsThirdAndSingular));
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
                var bs = SelectedObject.BaseObject;
                if (value && bs.Person != Person.Second)
                    SelectedObject = Objects.First(x =>
                    x.BaseObject.Number == Number.Singular &&
                    x.BaseObject.Person == bs.Person);
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
                var bs = SelectedObject.BaseObject;
                if (value && bs.Person != Person.Second)
                    SelectedObject = Objects.First(x =>
                    x.BaseObject.Number == Number.Plural &&
                    x.BaseObject.Person == bs.Person);
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
                var bs = SelectedObject?.BaseObject;
                if (value)
                    SelectedObject = Objects.First(x =>
                    x.BaseObject.Person == Person.Third &&
                    x.BaseObject.Number == Number.Singular &&
                    x.BaseObject.Gender == Gender.Male);
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
                var bs = SelectedObject?.BaseObject;
                if (value)
                    SelectedObject = Objects.First(x =>
                    x.BaseObject.Person == Person.Third &&
                    x.BaseObject.Number == Number.Singular &&
                    x.BaseObject.Gender == Gender.Female);
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
                    SelectedObject = Objects.First(x =>
                    x.BaseObject.Person == Person.Third &&
                    x.BaseObject.Number == Number.Singular &&
                    x.BaseObject.Gender == Gender.Neuter);
                OnPropertyChanged(nameof(IsNeuter));
            }
        }
    }
    private bool _isNeuter = true;
}