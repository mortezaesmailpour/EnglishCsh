using English.Pronouns;
using English.SentenceElements;
using English.UI.Commands;
using English.UI.Models;
using English.UI.Views;
using English.Verbs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace English.UI.ViewModels;

public class MainViewModel : BaseViewModel
{
    public string Subject2
    {
        get => _subject2;
        set => SetField(ref _subject2, value);
    }
    private string _subject2 = "salam";
    public ObservableCollection<SubjectModel> Subjects { get; init; }
    public SubjectModel SelectedSubject { get; set; }
    public ObservableCollection<ObjectModel> Objects { get; init; }
    public ObjectModel SelectedObject { get; set; }
    public ObservableCollection<TenseModel> Tenses { get; init; }
    public TenseModel SelectedTense { get; set; }
    public ICommand UpdateCommand { get; }
    public string Result { get; private set; }
    public MainViewModel()
    {
        UpdateCommand = new CommandHandler(UpdateResult);
        Subjects = new ObservableCollection<SubjectModel>();
        Objects = new ObservableCollection<ObjectModel>();
        Tenses = new ObservableCollection<TenseModel>();
        Verb verb = new Verb("fallow");

        var subject = SubjectPersonalPronouns.She;   
        var @object = ObjectPersonalPronouns.Him;

        foreach (var item in SubjectPersonalPronouns.All)
            Subjects.Add(new SubjectModel(item));
        SelectedSubject = Subjects.FirstOrDefault();

        foreach (var item in ObjectPersonalPronouns.All)
            Objects.Add(new ObjectModel(item));
        SelectedObject = Objects.FirstOrDefault();

        foreach (var item in verb.AllTenses)
            Tenses.Add(new TenseModel(item));
        SelectedTense = Tenses.FirstOrDefault();
        UpdateResult();
    }

    public void UpdateResult()
    {
        var sbj = SelectedSubject?.BaseSubject;
        var obj = SelectedObject?.Object;
        var vrb = SelectedTense?.Verb;
        Result = $"{sbj} {vrb.ToStringFor(sbj)} {obj}";
        OnPropertyChanged(nameof(Result));
    }
}
    public class ObjectModel
    {
        public IObject Object { get; set; }
        public string Name { get; set; }
        public ObjectModel(IObject @object)
        {
            Object = @object;
            Name = Object.ToString() ?? "NULL";
        }

    }

public class TenseModel
{
    public IVerb Verb { get; set; }
    public string Name { get; set; }
    public TenseModel(IVerb verb)
    {
        Verb = verb;
        Name = verb.Tense.ToString() ?? "NULL";
    }
}