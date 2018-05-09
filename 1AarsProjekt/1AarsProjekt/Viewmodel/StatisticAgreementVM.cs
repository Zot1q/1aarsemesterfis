using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.StatisticManagement;
using _1AarsProjekt.View;
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
    class StatisticAgreementVM : INotifyPropertyChanged
    {
        Statistic statistic = new Statistic();

        private List<Agreement> agreeStatisticList;

        public List<Agreement> AgreeStatisticList
        {
            get { return agreeStatisticList; }
            set { agreeStatisticList = value; }
        }

        public StatisticAgreementVM()
        {
            AgreeStatisticList = statistic.ListAgreements();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
