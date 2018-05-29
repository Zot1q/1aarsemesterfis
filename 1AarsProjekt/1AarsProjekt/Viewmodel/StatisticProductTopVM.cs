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
        private List<Agreement> _topList;
        public List<Agreement> TopList
        {
            get
            {
                return _topList;
            }
            set
            {
                _topList = value;
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
                UpdateTopList();
            }

        }

        public StatisticProductTopVM()
        {
            Amount = 10;
            TopList = Statistic.ListTopProductGroup();
            TopList = TopList.GroupBy(x => x.ProductGroup).OrderByDescending(g => g.Count()).Select(x => x.FirstOrDefault()).Take(Amount).ToList();
        }

        public void UpdateTopList()
        {
            TopList = Statistic.ListTopProductGroup();
            TopList = TopList.GroupBy(x => x.ProductGroup).OrderByDescending(g => g.Count()).Select(x => x.FirstOrDefault()).Take(_amount).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
