using System.Reactive;
using System.Reflection.Metadata;
using ProyectoDeVerdad.Views;
using ReactiveUI;

namespace ProyectoDeVerdad.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
 public ReactiveCommand<Unit, Unit> OptionMenu { get; }
 public ReactiveCommand<Unit, Unit> ExitMainMenu { get; }
 public ReactiveCommand<Unit, Unit> PlayGato1V1 { get; }
 public ReactiveCommand<Unit, Unit> PlayGatoVsAi { get; }
 public ReactiveCommand<Unit, Unit> DeleteGato { get; }
 public ReactiveCommand<Unit, Unit> TrainPPoT { get; }
 public ReactiveCommand<Unit, Unit> PlayPPoT { get; }
 public ReactiveCommand<Unit, Unit> DeletePPoT { get; }
 public ReactiveCommand<Unit, Unit> PlayRisk { get; }
 public ReactiveCommand<Unit, Unit> DeleteRisk { get; }

        public MainWindowViewModel()
        {
            OptionMenu = ReactiveCommand.Create(ExecuteOptionMenu);
            ExitMainMenu = ReactiveCommand.Create(ExecuteExitMainMenu);
            PlayGato1V1 = ReactiveCommand.Create(ExecutePlayGato1V1);
            PlayGatoVsAi = ReactiveCommand.Create(ExecutePlayGatoVsAi);
            DeleteGato = ReactiveCommand.Create(ExecuteDeleteGato);
            TrainPPoT = ReactiveCommand.Create(ExecuteTrainPPoT);
            PlayPPoT = ReactiveCommand.Create(ExecutePlayPPoT);
            DeletePPoT = ReactiveCommand.Create(ExecuteDeletePPoT);
            PlayRisk = ReactiveCommand.Create(ExecutePlayRisk);
            DeleteRisk = ReactiveCommand.Create(ExecuteDeleteRisk);
        }

        private void ExecuteOptionMenu()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        
        private void ExecuteExitMainMenu()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        private void ExecutePlayGato1V1()
        {
            var Gato1V1 = new Game();
            Gato1V1.Show();
        }
        private void ExecutePlayGatoVsAi()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        private void ExecuteDeleteGato()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        private void ExecuteTrainPPoT()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        private void ExecutePlayPPoT()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        private void ExecuteDeletePPoT()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        private void ExecutePlayRisk()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        private void ExecuteDeleteRisk()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        
    }