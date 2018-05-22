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
    public class AgreementListVM : INotifyPropertyChanged
    {
        AgreementMethods agreeMethod = new AgreementMethods();

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

        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                NotifyPropertyChanged();
            }
        }

        public ChangePageCMD AgreementDelete { get; set; }
        public ChangePageCMD OpenAgreementEditWindow { get; set; }

        public AgreementListVM()
        {
            AgreementDelete = new ChangePageCMD(DeleteAgreement);
            OpenAgreementEditWindow = new ChangePageCMD(AgreementEditWindowOpen);
            AgreementList = agreeMethod.ListAgreements();
        }

        public void DeleteAgreement()
        {
            Agreement selectedAgreement = AgreementList.ElementAt(SelectedIndex);
            agreeMethod.DeleteAgreement(selectedAgreement);
            AgreementList = agreeMethod.ListAgreements();
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
