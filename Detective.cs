using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindingCriminal
{
    internal class Detective
    {
        private readonly ICriminalsFactory _provider;
        private readonly CriminalFindingForm _form;
        private TaskCompletionSource<bool> _buttonClickTaskCompletionSource;

        public Detective(CriminalFindingForm form)
        {
            _provider = new CriminalsFactory();
            _form = form;

            _form.UpdateSearchButtonClicked -= OnUpdateButtonClicked;
            _form.UpdateSearchButtonClicked += OnUpdateButtonClicked;
        }

        public async Task SearchAsync()
        {
            bool isWorking = true;

            List<Criminal> criminals = _provider.Create();

            while (isWorking)
            {
                await WaitForButtonClickAsync();

                isWorking = _form.IsWorking;

                List<Criminal> selectedCriminals = SelectOnAnthropometry(criminals);
                selectedCriminals = SelectOnNationality(selectedCriminals);
                selectedCriminals = SelectOnStatus(selectedCriminals);

                await _form.ShowCriminals(selectedCriminals);

                selectedCriminals.Clear();
            }
        }

        private List<Criminal> SelectOnAnthropometry(List<Criminal> criminals)
        {
            int minHeight = _form.MinHeight;
            int maxHeight = _form.MaxHeight;
            int minWeight = _form.MinWeight;
            int maxWeight = _form.MaxWeight;

            List<Criminal> selectedCriminals = criminals.
                Where(criminal => criminal.Height >= minHeight
                    && criminal.Height <= maxHeight
                    && criminal.Weight >= minWeight
                    && criminal.Weight <= maxWeight).ToList();

            return selectedCriminals;
        }

        private List<Criminal> SelectOnNationality(List<Criminal> selectedCriminals)
        {
            IListingProvider listingProvider = new ListingProvider();

            if (_form.Nationality != listingProvider.GetCountryList()[0])
            {
                selectedCriminals = selectedCriminals.Where(criminal => criminal.Nationality == _form.Nationality).ToList();
            }

            return selectedCriminals;
        }

        private List<Criminal> SelectOnStatus(List<Criminal> selectedCriminals)
        {
            IListingProvider listingProvider = new ListingProvider();

            if (_form.Status == listingProvider.GetStatusList()[0])
            {
                selectedCriminals = selectedCriminals.Where(criminal => criminal.IsPrisoned == false).ToList();
            }
            else if (_form.Status == listingProvider.GetStatusList()[1])
            {
                selectedCriminals = selectedCriminals.Where(criminal => criminal.IsPrisoned == true).ToList();
            }

            return selectedCriminals;
        }

        private Task WaitForButtonClickAsync()
        {
            if (_buttonClickTaskCompletionSource == null || _buttonClickTaskCompletionSource.Task.IsCompleted)
            {
                Console.WriteLine("wait button...");
                _buttonClickTaskCompletionSource = new TaskCompletionSource<bool>();
            }

            return _buttonClickTaskCompletionSource.Task;
        }

        private void OnUpdateButtonClicked()
        {
            if (_buttonClickTaskCompletionSource != null && !_buttonClickTaskCompletionSource.Task.IsCompleted)
            {
                Console.WriteLine("Button pressed, task completed.");
                _buttonClickTaskCompletionSource.SetResult(true);
            }
            else
            {
                Console.WriteLine("Task already completed. Waiting for button reset.");
            }
        }
    }
}
