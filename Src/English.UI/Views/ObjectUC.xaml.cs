using English.Persons;

namespace English.UI.Views;

public partial class ObjectUC : UserControl, INotifyPropertyChanged
{
    public ObservableCollection<ObjectModel> Objects { get; init; }
    public ObjectModel ObjectM
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
    
    private bool _isSingular = true;
    public bool IsSingular
    {
        get => _isSingular;
        set
        {
            if (_isSingular != value)
            {
                _isSingular = value;
                var person = SelectedObject.BaseObject.Person;
                if (person != Person.Second)
                    SelectedObject = Objects.First(x => 
                    x.BaseObject.Number == (value ? Number.Singular : Number.Plural) &&
                    x.BaseObject.Person == person);
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
        SelectedObject = Objects.First();
        ObjectM = SelectedObject;
        OnPropertyChanged(nameof(Objects));
        OnPropertyChanged(nameof(SelectedObject));
        OnPropertyChanged(nameof(ObjectM));
    }
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
        ObjectM = SelectedObject;
        OnPropertyChanged(nameof(ObjectM));
    }
}
