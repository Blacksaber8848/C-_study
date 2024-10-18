using Module40.Student;
using Module40.ViewModels;
using Prism.Common;
using Prism.Regions;
using System.Windows.Controls;

namespace Module40.Views
{
    /// <summary>
    /// Interaction logic for PersonDetail
    /// </summary>
    public partial class StudentDetail : UserControl
    {
        public StudentDetail()
        {
            InitializeComponent();
            RegionContext.GetObservableContext(this).PropertyChanged += PersonDetail_PropertyChanged;
        }

        private void PersonDetail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var context = (ObservableObject<object>)sender;
            var selectedPerson = (Person)context.Value;
            (DataContext as StudentDetailViewModel).SelectedPerson = selectedPerson;
        }
    }
}