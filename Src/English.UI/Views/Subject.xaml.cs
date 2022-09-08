using English.UI.ViewModels;

namespace English.UI.Views;

public partial class Subject : UserControl, INotifyPropertyChanged
{
    public ObservableCollection<SubjectModel> Subjects { get; init; }
    public SubjectModel SelectedSubject
    {
        get => (SubjectModel)GetValue(SubjectModelProperty);
        set => SetValue(SubjectModelProperty, value);
    }
    private bool _isSingular = true;
    public bool IsSingular
    {
        get => _isSingular;
        set
        {
            if (_isSingular != value)
            {
                _isSingular = value;
                OnPropertyChanged(nameof(IsSingular));
            }
        }
    }
    //public static readonly DependencyProperty IsSingularProperty =
    //    DependencyProperty.Register("IsSingular", typeof(object),
    //      typeof(Subject), new PropertyMetadata(""));
    public Subject()
    {
        InitializeComponent();
        //this.DataContext = new SubjectViewModel();
        Subjects = new ObservableCollection<SubjectModel>();
        foreach (var item in SubjectPersonalPronouns.All)
            Subjects.Add(new SubjectModel(item));
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public static readonly DependencyProperty SubjectModelProperty =
        DependencyProperty.Register("SelectedSubject", typeof(object),
          typeof(Subject), new PropertyMetadata(""));
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //IsSingular = true;
        //OnPropertyChanged(nameof(IsSingular));
        SelectedSubject = Subjects[3];
        OnPropertyChanged(nameof(SelectedSubject));
    }
}
