using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindingCriminal
{
    public partial class CriminalFindingForm : Form
    {
        private readonly int _minHeightValue = 0;
        private readonly int _maxHeightValue = 250;
        private readonly int _minWeightValue = 0;
        private readonly int _maxWeightValue = 200;

        public CriminalFindingForm()
        {
            MinHeight = _minHeightValue;
            MaxHeight = _maxHeightValue;
            MinWeight = _minWeightValue;
            MaxWeight = _maxWeightValue;

            InitializeComponent();

            _searchButton.Click -= ClickSearchButton;
            _searchButton.Click += ClickSearchButton;
        }

        public int MinHeight { get; private set; }
        public int MaxHeight { get; private set; }
        public int MinWeight { get; private set; }
        public int MaxWeight { get; private set; }
        public string Nationality { get; private set; }
        public string Status { get; private set; }

        internal event Action UpdateButtonClicked;

        internal async Task ShowCriminals(List<Criminal> criminals)
        {
            await Task.Run(() =>
            {
                UpdateUI(() =>
                {
                    string statusPrisoned = "prisoned";
                    string statusUnprisoned = "free";

                    _criminalsList.Items.Clear();

                    foreach (var criminal in criminals)
                    {
                        string status = criminal.IsPrisoned ? statusPrisoned : statusUnprisoned;
                        string record = $"{criminal.Name}\t Co:{criminal.Nationality}\t H:{criminal.Height}\t W:{criminal.Weight}\t St:{status}";
                        
                        _criminalsList.Items.Add(record);
                    }
                });
            });
        }

        private void ClickSearchButton(object sender, EventArgs e)
        {
            UpdateButtonClicked?.Invoke();
        }

        private void LoadCriminalFindingForm(object sender, EventArgs e)
        {
            IListingProvider listingProvider = new ListingProvider();

            _minHeightList.Items.AddRange(listingProvider.GetHeightList().ToArray());
            _minHeightList.Items.RemoveAt(_minHeightList.Items.Count - 1);
            _minHeightList.SelectedIndex = 0;
            _maxHeightList.Items.AddRange(listingProvider.GetHeightList().ToArray());
            _maxHeightList.Items.RemoveAt(0);
            _maxHeightList.SelectedIndex = _minHeightList.Items.Count - 1;

            _minWeightList.Items.AddRange(listingProvider.GetWeightList().ToArray());
            _minWeightList.Items.RemoveAt(_minWeightList.Items.Count - 1);
            _minWeightList.SelectedIndex = 0;
            _maxWeightList.Items.AddRange(listingProvider.GetWeightList().ToArray());
            _maxWeightList.Items.RemoveAt(0);
            _maxWeightList.SelectedIndex = _minWeightList.Items.Count - 1;

            _prisonedList.Items.AddRange(listingProvider.GetStatusList().ToArray());
            _prisonedList.SelectedIndex = _prisonedList.Items.Count - 1;

            _nationalityList.Items.AddRange(listingProvider.GetCountryList().ToArray());
            _nationalityList.SelectedIndex = 0;
        }

        private void UpdateUI(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void MinHeightListSelectedIndexChanged(object sender, EventArgs e)
        {
            MinHeight = GetIntValue(_minHeightList.SelectedItem.ToString(), _minHeightValue, _maxHeightValue, defaultValue: _minHeightValue);

            if (MinHeight > MaxHeight)
            {
                _maxHeightList.SelectedIndex = _minHeightList.SelectedIndex;
            }
        }

        private void MaxHeightListSelectedIndexChanged(object sender, EventArgs e)
        {
            MaxHeight = GetIntValue(_maxHeightList.SelectedItem.ToString(), _minHeightValue, _maxHeightValue, defaultValue: _maxHeightValue);

            if (MinHeight > MaxHeight)
            {
                _minHeightList.SelectedIndex = _maxHeightList.SelectedIndex;
            }
        }

        private void MinWeightListSelectedIndexChanged(object sender, EventArgs e)
        {
            MinWeight = GetIntValue(_minWeightList.SelectedItem.ToString(), _minWeightValue, _maxWeightValue, defaultValue: _minWeightValue);

            if (MinWeight > MaxWeight)
            {
                _maxWeightList.SelectedIndex = _minWeightList.SelectedIndex;
            }
        }

        private void MaxWeightListSelectedIndexChanged(object sender, EventArgs e)
        {
            MaxWeight = GetIntValue(_maxWeightList.SelectedItem.ToString(), _minWeightValue, _maxWeightValue, defaultValue: _maxWeightValue);

            if (MinWeight > MaxWeight)
            {
                _minWeightList.SelectedIndex = _maxWeightList.SelectedIndex;
            }
        }

        private int GetIntValue(string selectedItem, int minValue, int maxValue, int defaultValue)
        {
            bool haveValue = int.TryParse(selectedItem, out int result);

            if (haveValue && result > minValue && result < maxValue)
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }

        private void _nationalityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nationality = _nationalityList.Items[_nationalityList.SelectedIndex].ToString();
        }

        private void _prisonedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Status = _prisonedList.Items[_prisonedList.SelectedIndex].ToString();
        }
    }
}
