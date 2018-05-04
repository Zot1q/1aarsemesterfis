using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Viewmodel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Viewmodel
{
    class AgreementVM : INotifyPropertyChanged
    {
        public Agreement Agreement { get; set; }
        public ChangePageCMD CreateAgreement { get; set; }
        public AgreementVM()
        {
            Agreement = new Agreement();
            CreateAgreement = new ChangePageCMD(CreateAgree);
        }
        public void CreateAgree()
        {
            AgreementMethods agreementMethod = new AgreementMethods();
            agreementMethod.CreateAgreement(Agreement);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
