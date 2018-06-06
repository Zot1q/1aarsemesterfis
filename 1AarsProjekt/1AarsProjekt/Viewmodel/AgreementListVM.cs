using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.View;
using _1AarsProjekt.Viewmodel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _1AarsProjekt.Viewmodel
{
    /// <Author>
    /// Nicolai
    /// </Author>
    /// <summary>
    /// Class defines all that has to do with the AgreementListPage
    /// </summary>
    public class AgreementListVM : INotifyPropertyChanged
    {
        private List<Agreement> _agreementList;

        public  List<Agreement> AgreementList
        {
            get { return _agreementList; }
            set
            {
                _agreementList = value;
                NotifyPropertyChanged();
            }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                NotifyPropertyChanged();
            }
        }

        public MethodCommand AgreementDelete { get; set; }
        public MethodCommand OpenAgreementEditWindow { get; set; }

        public AgreementListVM()
        {
            AgreementDelete = new MethodCommand(DeleteAgreement);
            OpenAgreementEditWindow = new MethodCommand(AgreementEditWindowOpen);
            AgreementList = AgreementMethods.ListAgreements();
        }

        public void DeleteAgreement()
        {
            Agreement selectedAgreement = AgreementList.ElementAt(SelectedIndex);
            AgreementMethods.DeleteAgreement(selectedAgreement);
            AgreementList = AgreementMethods.ListAgreements();
            MessageBox.Show("Aftale slettet!");
        }

        public void AgreementEditWindowOpen()
        {
            AgreementEditWindow agreementEditWindow = new AgreementEditWindow(AgreementList.ElementAt(SelectedIndex));
            agreementEditWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
