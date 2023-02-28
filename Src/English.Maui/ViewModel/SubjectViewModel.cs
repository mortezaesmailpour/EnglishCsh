using English.Persons;
using English.UI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace English.Maui.ViewModel;

public class SubjectViewModel : BaseViewModel
{

    private bool _isSingular;
    public bool IsSingular
    {
        get => _isSingular;
        set
        {
            var person = SelectedSubject.BaseSubject.Person;
            _ = value
                ? person == Person.First ? SelectedSubject = Subjects[1] : person == Person.Third ? SelectedSubject = Subjects[6] : SelectedSubject = Subjects[2]
                : person == Person.First ? SelectedSubject = Subjects[0] : person == Person.Third ? SelectedSubject = Subjects[5] : SelectedSubject = Subjects[2];
            SetField(ref _isSingular, value);
        }
    }


    //================
    public ObservableCollection<SubjectModel> Subjects { get; init; }
    private SubjectModel _selectedSubject;
    public SubjectModel SelectedSubject
    {
        get => _selectedSubject;
        set => SetField(ref _selectedSubject, value);
    }
    public SubjectModel Subject { get; set; }
    public ICommand UpdateCommand { get; }
    public SubjectViewModel()
    {
        Subjects = new ObservableCollection<SubjectModel>();
        foreach (var item in SubjectPersonalPronouns.All)
            Subjects.Add(new SubjectModel(item));
        SelectedSubject = Subjects.FirstOrDefault();
        OnPropertyChanged(nameof(Subjects));
        OnPropertyChanged(nameof(SelectedSubject));


        Subject = new(SubjectPersonalPronouns.She);
        UpdateCommand = new CommandHandler(Update);
        Update();
    }
    public string Name
    {
        get => _name;
        set => SetField(ref _name, value);
    }
    private string _name;
    public void Update()
    {
        Name = Subject.ToString();
    }
}
