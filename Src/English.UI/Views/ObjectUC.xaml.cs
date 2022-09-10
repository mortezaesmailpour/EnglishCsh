using English.Persons;

namespace English.UI.Views;

public partial class ObjectUC : UserControl, INotifyPropertyChanged
{
    public ObservableCollection<ObjectModel> Objects { get; init; }
    public ObjectModel Object
    {
        get => (ObjectModel)GetValue(ObjectModelProperty);
        set => SetValue(ObjectModelProperty, value);
    }
    public ObjectModel SelectedObject
    {
        get => _selectedObject;
        set
        {
            if (_selectedObject != value)
            {
                _selectedObject = value;
                OnPropertyChanged(nameof(SelectedObject));
            }
        }
    }
    private ObjectModel _selectedObject;
    public ObjectModel SelectedSubject
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
    public ObjectModel _selectedSubject;
    private bool _isSingular = true;
    public bool IsSingular
    {
        get => _isSingular;
        set
        {
            if (_isSingular != value)
            {
                _isSingular = value;
                if (SelectedObject?.BaseObject.Person != Person.Second)
                    SelectedObject = Objects.FirstOrDefault(x => 
                    x.BaseObject.Number == (value ? Number.Singular : Number.Plural) &&
                    x.BaseObject.Person == SelectedObject.BaseObject.Person);
                OnPropertyChanged(nameof(IsSingular));
            }
        }
    }
    public ObjectUC()
    {
        InitializeComponent();
        //this.DataContext = new SubjectViewModel();
        Objects = new ObservableCollection<ObjectModel>();
        foreach (var item in ObjectPersonalPronouns.All)
            Objects.Add(new ObjectModel(item));

        SelectedObject = Objects.FirstOrDefault();
        OnPropertyChanged(nameof(Objects));
        OnPropertyChanged(nameof(SelectedObject));
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public static readonly DependencyProperty ObjectModelProperty =
        DependencyProperty.Register("Object", typeof(object),
          typeof(Object), new PropertyMetadata(""));
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //IsSingular = true;
        //OnPropertyChanged(nameof(IsSingular));
        SelectedObject = Objects[3];
        OnPropertyChanged(nameof(SelectedObject));
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        IsSingular = SelectedObject?.BaseObject.Number == Number.Singular;
        OnPropertyChanged(nameof(SelectedObject));
    }
}
