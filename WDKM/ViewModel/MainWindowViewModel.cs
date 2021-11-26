using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WDKM.Commands;
using WDKM.Instrumentary;
using WDKM.Model;

namespace WDKM.ViewModel
{
    public class MainWindowViewModel : ViewModel
    {
        private string _Command;
        private string _Result;
        public string Command { get => _Command; set { _Command = value; OnPropertyChanged() ; } }
        public string Result { get => _Result; set { _Result = value; OnPropertyChanged() ; } }
        public static List<string> CommandsList { get; set; }
        public int CommandsListSelectionIndex { get; set; }
        public static DateTimeHandler Date { get; set; }
        public string Version { get; set; }
        public CommandsHandler Handler { get; set; }
        public ICommand Run { get; set; }
        public static ICommand PrintCommand { get; set; }
        public static ICommand CancelPrintCommand { get; set; }
        public ICommand ShowNextCommand { get; set; }
        public ICommand ShowPreviousCommand { get; set; }
        public static ICommand CleanCommand { get; set; }
        public static bool AbleToPrint { get; set; }
        public MainWindowViewModel()
        {
            Version = "0.0.5";

            CommandsList = new List<string>();
            Handler = new CommandsHandler(this);

            Date = new DateTimeHandler();

            Run = new RunCommand(this);
            PrintCommand = new PrintCommand(this);
            CancelPrintCommand = new CancelPrintCommand();
            ShowNextCommand = new ShowNextCommand(this);
            ShowPreviousCommand = new ShowPreviousCommand(this);
            CleanCommand = new CleanCommand(this);

            Print("Loaded");
        }
        public async void Print(string message)
        {
            await Task.Run(() =>
            {
                foreach (var item in message)
                {
                    Result += item;
                    Thread.Sleep(1);
                }
            });
        }
        public async void Print(ICollection<string> message)
        {
            AbleToPrint = true;

            Result += DateTime.Now.ToString("\n\tyyyy.MM.dd \tdddd\t HH:mm:ss\n");

            await Task.Run(() =>
            {
                foreach (var item in message)
                {
                    foreach (var includedItem in item)
                    {
                        if (AbleToPrint)
                        {
                            Result += includedItem;
                            Thread.Sleep(1);
                        }
                        else
                        {
                            AbleToPrint = true;
                            return;
                        }
                    }
                }
            });
        }
        private void Clean()
        {
            if (Result.Length > 1000)
            {
                var temporaryResult = Result.Substring(500);
                Result = temporaryResult;
            }
        }
    }
}
