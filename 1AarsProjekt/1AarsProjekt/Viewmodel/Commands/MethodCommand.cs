using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _1AarsProjekt.Viewmodel.Commands
{
    /// <Author>
    /// Nicolai and Newjan
    /// </Author>
    /// <summary>
    /// This class is used to run a method through the ICommand interface
    /// </summary>
    public class MethodCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute; // Delegate containing the sent method

        /// <summary>
        /// Takes the _execute parameter and equals it with the local one
        /// </summary>
        /// <param name="execute"></param>
        public MethodCommand(Action execute)
        {
            _execute = execute; 
        }
        /// <summary>
        /// Used to verify data. Returning true, because it can always execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }
        /// <summary>
        /// Invokes the execute and runs the method.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
