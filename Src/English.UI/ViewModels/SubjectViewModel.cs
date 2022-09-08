namespace English.UI.ViewModels;

public class SubjectViewModel : BaseViewModel
{
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
