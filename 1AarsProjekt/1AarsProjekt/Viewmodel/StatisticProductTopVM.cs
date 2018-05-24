using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.StatisticManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Viewmodel
{
    class StatisticProductTopVM : INotifyPropertyChanged
    {
        Statistic statistic = new Statistic();
        private List<Agreement> topList;

        public List<Agreement> TopList
        {
            get
            {
                return topList;
            }
            set
            {
                topList = value;
                NotifyPropertyChanged();
            }
        }
        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                //NotifyPropertyChanged("Amount");
                UpdateTopList();
            }

        }
        public StatisticProductTopVM()
        {
            TopList = statistic.ListTopProductGroup();
            TopList = TopList.GroupBy(x => x.ProductGroup).OrderByDescending(g => g.Count()).Select(x => x.FirstOrDefault()).Take(_amount).ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void UpdateTopList()
        {
            TopList = statistic.ListTopProductGroup();
            TopList = TopList.GroupBy(x => x.ProductGroup).OrderByDescending(g => g.Count()).Select(x => x.FirstOrDefault()).Take(_amount).ToList();
        }
    }
}
