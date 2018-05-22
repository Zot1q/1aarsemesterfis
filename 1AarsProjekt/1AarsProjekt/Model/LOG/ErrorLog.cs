using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.LOG
{
    class ErrorLog
    {
        /// <summary>
        /// ID for the database
        /// </summary>
        public int ErrorID { get; set; }
        /// <summary>
        /// Message for the log
        /// </summary>
        public string LogMessage { get; set; }
        /// <summary>
        /// ErrorNr represents system errors : 0 = no error, 1 = dataAccessLayer Error, 2 = User Error etc...
        /// </summary>
        public int ErrorNr { get; set; }

        /// <summary>
        /// The date and time of the error
        /// </summary>
        public string DateAndTime { get; set; }
        /// <summary>
        /// Amount of data inserted in the database
        /// </summary>
        public int AmountOfData { get; set; }

        public ErrorLog(int errorNr, string logMessage, string dateAndTime, int amountOfData)
        {
            ErrorNr = errorNr;
            LogMessage = logMessage;
            DateAndTime = dateAndTime;
            AmountOfData = amountOfData;

        }
    }
}
