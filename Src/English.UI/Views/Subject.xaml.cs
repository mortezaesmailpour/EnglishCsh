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
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }
    }
    public SubjectModel _selectedSubject;
    private bool _isSingular = true;
    public bool IsSingular
    {
        get => _isSingular;
        set
        {
            if (_isSingular != value)
            {
                _isSingular = value;
                var bs = SelectedSubject.BaseSubject;
                if (bs.Person != Person.Second)
                    SelectedSubject = Subjects.First(x =>
                    x.BaseSubject.Number == (value ? Number.Singular : Number.Plural) &&
                    x.BaseSubject.Person == bs.Person);
                OnPropertyChanged(nameof(IsSingular));
            }
        }
    }
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
