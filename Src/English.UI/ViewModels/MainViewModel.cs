using English.UI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace English.UI.ViewModels;

public class MainViewModel : BaseViewModel
{
    private ObservableCollection<SubjectModel> _subjects;

    public ObservableCollection<SubjectModel> Subjects
    {
        get { return _subjects; }
        set { _subjects = value; }
    }
    private SubjectModel _selectedSubject;

    public SubjectModel SelectedSubject
    {
        get { return _selectedSubject; }
        set { _selectedSubject = value; }
    }
    public ICommand AddCommand { get; }
    public MainViewModel()
    {
        AddCommand = new CommandHandler(Add);
        _subjects = new ObservableCollection<SubjectModel>()
        {
           new SubjectModel() { Id = 1, Name = "I" },
           new SubjectModel() { Id = 1, Name = "We" },
           new SubjectModel() { Id = 1, Name = "You" },
           new SubjectModel() { Id = 3, Name = "He" },
           new SubjectModel() { Id = 4, Name = "She" },
           new SubjectModel() { Id = 4, Name = "It" },
           new SubjectModel() { Id = 4, Name = "They" },
           new SubjectModel() { Id = 4, Name = "My friend and I" },
           new SubjectModel() { Id = 4, Name = "Morteza" },
           new SubjectModel() { Id = 4, Name = "Her dog" },
        };
        _selectedSubject = Subjects.FirstOrDefault() ?? new SubjectModel() { Name = ":(" };
    }

    private void Add()
    {
        Subjects.Add(new SubjectModel() { Name = "New One" });
    }
}
public class SubjectModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}