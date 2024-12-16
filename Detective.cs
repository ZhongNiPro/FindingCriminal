using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindingCriminal
{
    internal class Detective
    {
        private readonly ICriminalsProvider _provider;
        private readonly CriminalFindingForm _form;
        private TaskCompletionSource<bool> _buttonClickTaskCompletionSource;

        public Detective(CriminalFindingForm form)
        {
            _provider = new CriminalsProvider();
            _form = form;

            _form.UpdateSearchButtonClicked -= OnUpdateButtonClicked;
            _form.UpdateSearchButtonClicked += OnUpdateButtonClicked;
        }

        public async Task SearchAsync()
        {
            bool isWorking = true;

            List<Criminal> criminals = _provider.CreateCriminals();

            while (isWorking)
            {
                await WaitForButtonClickAsync();

                int minHeight = _form.MinHeight;
                int maxHeight = _form.MaxHeight;
                int minWeight = _form.MinWeight;
                int maxWeight = _form.MaxWeight;
                isWorking = _form.IsWorking;

                List<Criminal> selectedCriminals = criminals.Where(criminal => criminal.Height >= minHeight).
                   Where(criminal => criminal.Height <= maxHeight).
                   Where(criminal => criminal.Weight >= minWeight).
                   Where(criminal => criminal.Weight <= maxWeight).ToList();

                IListingProvider listingProvider = new ListingProvider();

                if (_form.Nationality != listingProvider.GetCountryList()[0])
                {
                    selectedCriminals = selectedCriminals.Where(criminal => criminal.Nationality == _form.Nationality).ToList();
                }

                if (_form.Status == listingProvider.GetStatusList()[0])
                {
                    selectedCriminals = selectedCriminals.Where(criminal => criminal.IsPrisoned == false).ToList();
                }
                else if (_form.Status == listingProvider.GetStatusList()[1])
                {
                    selectedCriminals = selectedCriminals.Where(criminal => criminal.IsPrisoned == true).ToList();
                }

                await _form.ShowCriminals(selectedCriminals);

                selectedCriminals.Clear();
            }
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
