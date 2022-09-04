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
        Subjects = new ObservableCollection<SubjectModel>()
        {
           new SubjectModel() { Id = 1, Name = "Nirav" },
           new SubjectModel() { Id = 1, Name = "Kapil" },
           new SubjectModel() { Id = 3, Name = "Arvind" },
           new SubjectModel() { Id = 4, Name = "Rajan" },
        };
        SelectedSubject = Subjects.FirstOrDefault() ?? new SubjectModel() { Name = "test" };
    }

    private void Add()
    {
        Subjects.Add(new SubjectModel() { Name = "neeeww" });
    }
}
public class SubjectModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}