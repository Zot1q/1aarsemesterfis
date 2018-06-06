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
    /// <Author>
    /// Newjan
    /// </Author>
    /// <summary>
    /// Class which gets agreements in list
    /// </summary>
    class StatisticAgreementVM : INotifyPropertyChanged
    {
        private List<Agreement> _agreeStatisticList;

        public List<Agreement> AgreeStatisticList
        {
            get { return _agreeStatisticList; }
            set { _agreeStatisticList = value;}
        }

        public StatisticAgreementVM()
        {
            AgreeStatisticList = Statistic.ListAgreements();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
