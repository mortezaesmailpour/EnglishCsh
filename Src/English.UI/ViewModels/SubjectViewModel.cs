using System.Windows.Input;
using English.SentenceElements;
using English.UI.Commands;
using English.UI.Models;

namespace English.UI.ViewModels;

public class SubjectViewModel : BaseViewModel
{
    public SubjectModel Subject { get; set; }
    public ICommand UpdateCommand { get; }
    public SubjectViewModel()
    {
        Subject = new(new Subject());
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
