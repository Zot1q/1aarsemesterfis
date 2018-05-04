using _1AarsProjekt.Model.AgreementManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Viewmodel
{
    public class AgreementListVM : INotifyPropertyChanged
    {
        AgreementMethods agree = new AgreementMethods();

        private List<Agreement> agreeList;

        public List<Agreement> AgreeList
        {
            get { return agreeList; }
            set
            {
                agreeList = value;

            }
        }
        public AgreementListVM()
        {
            AgreeList = agree.ListAgreements();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
