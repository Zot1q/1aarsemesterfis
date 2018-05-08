using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Viewmodel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1AarsProjekt.Viewmodel
{
    class AgreementCreateVM : INotifyPropertyChanged
    {
        AgreementMethods agreementMethod = new AgreementMethods();
        public ChangePageCMD CreateAgreement { get; set; }
        public Agreement Agreement { get; set; }
        public AgreementCreateVM(int custID)
        {
            Agreement = new Agreement();
            Agreement.CustomerID = custID;
            CreateAgreement = new ChangePageCMD(AgreementCreate);
        }
        public void AgreementCreate()
        {
            MessageBox.Show(Agreement.CustomerID.ToString());
            //agreementMethod.CreateAgreementTest();
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
