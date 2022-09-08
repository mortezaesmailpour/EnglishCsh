using English.Pronouns;
using English.UI.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace English.UI.Views;

public partial class Subject : UserControl, INotifyPropertyChanged
{
    public ObservableCollection<SubjectModel> Subjects { get; init; }
    public SubjectModel SelectedSubject
    {
        get => (SubjectModel)GetValue(SubjectModelProperty);
        set => SetValue(SubjectModelProperty, value);
    }
    public Subject()
    {
        InitializeComponent();
        Subjects = new ObservableCollection<SubjectModel>();
        foreach (var item in SubjectPersonalPronouns.All)
            Subjects.Add(new SubjectModel(item));
        SelectedSubject = Subjects.FirstOrDefault();
        OnPropertyChanged(nameof(Subjects));
        OnPropertyChanged(nameof(SelectedSubject));
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public static readonly DependencyProperty SubjectModelProperty =
        DependencyProperty.Register("SelectedSubject", typeof(object),
          typeof(Subject), new PropertyMetadata(""));
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
