using NameFacilities.ApplicationServices.GetNameFacilityListUseCase;
using NameFacilities.ApplicationServices.Ports;
using NameFacilities.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NameFacilities.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetNameFacilityListUseCase _getNameFacilityListUseCase;

        public MainViewModel(IGetNameFacilityListUseCase getNameFacilityListUseCase)
            => _getNameFacilityListUseCase = getNameFacilityListUseCase;

        private Task<bool> _loadingTask;
        private NameFacility _currentNameFacility;
        private ObservableCollection<NameFacility> _nameFacilities;

        public event PropertyChangedEventHandler PropertyChanged;

        public NameFacility CurrentNameFacility
        {
            get => _currentNameFacility; 
            set
            {
                if (_currentNameFacility != value)
                {
                    _currentNameFacility = value;
                    OnPropertyChanged(nameof(CurrentNameFacility));
                }
            }
        }

        private async Task<bool> LoadNameFacilities()
        {
            var outputPort = new OutputPort();
            bool result = await _getNameFacilityListUseCase.Handle(GetNameFacilityListUseCaseRequest.CreateAllNameFacilitiesRequest(), outputPort);
            if (result)
            {
                NameFacilities = new ObservableCollection<NameFacility>(outputPort.NameFacilities);
            }
            return result;
        }

        public ObservableCollection<NameFacility> NameFacilities
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadNameFacilities();
                }
                
                return _nameFacilities; 
            }
            set
            {
                if (_nameFacilities != value)
                {
                    _nameFacilities = value;
                    OnPropertyChanged(nameof(NameFacilities));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetNameFacilityListUseCaseResponse>
        {
            public IEnumerable<NameFacility> NameFacilities { get; private set; }

            public void Handle(GetNameFacilityListUseCaseResponse response)
            {
                if (response.Success)
                {
                    NameFacilities = new ObservableCollection<NameFacility>(response.NameFacilities);
                }
            }
        }
    }
}
