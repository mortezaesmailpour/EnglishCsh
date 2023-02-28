using English.Persons;
using English.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace English.Maui.Controls;

class SubjectVM : INotifyPropertyChanged
{

    //private string _text = "ASD";
    //public string Text
    //{
    //    get => _text;
    //    set
    //    {
    //        if (_text != value)
    //        {
    //            _text = value;
    //            OnPropertyChanged(nameof(Text));
    //        }
    //    }
    //}

    public SubjectVM()
    {
        Subjects = new ObservableCollection<SubjectModel>();
        foreach (var item in SubjectPersonalPronouns.All)
            Subjects.Add(new SubjectModel(item));
        _selectedSubject = Subjects.First();
        OnPropertyChanged(nameof(Subjects));
        OnPropertyChanged(nameof(SelectedSubject));
        UpdateView();
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
                UpdateView();
            }
        }
    }

    private void UpdateView()
    {
        _isFirst = _selectedSubject.BaseSubject.Person == Person.First;
        _isSecond = _selectedSubject.BaseSubject.Person == Person.Second;
        _isThird = _selectedSubject.BaseSubject.Person == Person.Third;
        _isSingular = _selectedSubject.BaseSubject.Number == Number.Singular;
        _isPlural = _selectedSubject.BaseSubject.Number == Number.Plural;
        _isMale = _selectedSubject.BaseSubject.Gender == Gender.Male;
        _isFemale = _selectedSubject.BaseSubject.Gender == Gender.Female;
        _isNeuter = _selectedSubject.BaseSubject.Gender == Gender.Neuter;
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
                OnPropertyChanged(nameof(Result));
            }
        }
    }
    private string _text = "";
    public string? Result => string.IsNullOrWhiteSpace(_text) || (IsFirst && IsSingular)
        ?
         _selectedSubject?.ToString()
        :
            (IsFirst ?
                _text.EndsWith(" and I") ? _text : _text + " and I"
            : IsSecond ?
                _text.StartsWith("you and ") ? _text : "you and " + _text
            : _text)
            + " (" + _selectedSubject?.ToString() + ")";
    //     +
    //+ " (" + _selectedSubject?.ToString() + ")";


    public bool IsFirstOrThird => _isFirst || _isThird;
    public bool IsThirdAndSingular => _isThird && _isSingular;
    public bool IsNotFirstAndSingular => !(_isFirst && _isSingular);



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
                SelectedSubject = Subjects.First(x => x.BaseSubject.Person == Person.Second);
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
            var bs = SelectedSubject.BaseSubject;
            if (value)
                SelectedSubject = Subjects.First(x =>
                x.BaseSubject.Number == bs.Number &&
                x.BaseSubject.Person == Person.Third);
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



    public event PropertyChangedEventHandler PropertyChanged; 
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
