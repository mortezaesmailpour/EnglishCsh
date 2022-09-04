using English.Pronouns;
using English.SentenceElements;
using English.UI.Commands;
using English.Verbs;
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
        _subjects = new ObservableCollection<SubjectModel>();
        Verb verb = new Verb("play");



        var subject = SubjectPersonalPronouns.He;
        foreach (var item in SubjectPersonalPronouns.All)
        {
            _subjects.Add(new SubjectModel() { Subject=item,Name=item.ToString()});
        }
        _selectedSubject = _subjects.FirstOrDefault();
    }

    private void Add()
    {
        //Subjects.Add(new SubjectModel() { Name = "New One" });
    }
}
public class SubjectModel
{
    public ISubject Subject { get; set; }
    public string Name { get; set; }
}