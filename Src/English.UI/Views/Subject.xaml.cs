using English.UI.Models;
using English.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace English.UI.Views
{
    /// <summary>
    /// Interaction logic for Subject.xaml
    /// </summary>
    public partial class Subject : UserControl
    {
        private string _subject;
        public string SubjectModel
        {
            get { return _subject; }
            set
            {
                _subject = value;
                _viewModel.Name = _subject.ToString();
            }
        }
        private readonly SubjectViewModel _viewModel;

        public static readonly DependencyProperty SetTextProperty =
           DependencyProperty.Register("SetText", typeof(string), typeof(Subject), new
              PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged)));

        public string SetText
        {
            get { return (string)GetValue(SetTextProperty); }
            set { SetValue(SetTextProperty, value); }
        }

        private static void OnSetTextChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            Subject subjectControl = d as Subject;
            subjectControl.OnSetTextChanged(e);
        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            _viewModel.Name =  e.NewValue.ToString();
        }
        public Subject()
        {
            InitializeComponent();
            _viewModel = (SubjectViewModel)this.DataContext;
        }
    }

    public class SubjectModel2
    {
    }
}
