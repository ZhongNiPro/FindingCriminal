namespace FindingCriminal
{
    partial class CriminalFindingForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._minHeightList = new System.Windows.Forms.ComboBox();
            this._criminalsList = new System.Windows.Forms.ListBox();
            this._searchButton = new System.Windows.Forms.Button();
            this._maxHeightList = new System.Windows.Forms.ComboBox();
            this._maxWeightList = new System.Windows.Forms.ComboBox();
            this._minWeightList = new System.Windows.Forms.ComboBox();
            this._minHeighLabel = new System.Windows.Forms.Label();
            this._maxHeighLabel = new System.Windows.Forms.Label();
            this._maxWeighLabel = new System.Windows.Forms.Label();
            this._minWeighLabel = new System.Windows.Forms.Label();
            this._nationalityList = new System.Windows.Forms.ComboBox();
            this._nationalityLabel = new System.Windows.Forms.Label();
            this._prisonedList = new System.Windows.Forms.ComboBox();
            this._statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _minHeightList
            // 
            this._minHeightList.FormattingEnabled = true;
            this._minHeightList.Location = new System.Drawing.Point(24, 43);
            this._minHeightList.Name = "_minHeightList";
            this._minHeightList.Size = new System.Drawing.Size(121, 28);
            this._minHeightList.TabIndex = 0;
            this._minHeightList.SelectedIndexChanged += new System.EventHandler(this.MinHeightListSelectedIndexChanged);
            // 
            // _criminalsList
            // 
            this._criminalsList.FormattingEnabled = true;
            this._criminalsList.ItemHeight = 20;
            this._criminalsList.Location = new System.Drawing.Point(343, 3);
            this._criminalsList.Name = "_criminalsList";
            this._criminalsList.Size = new System.Drawing.Size(702, 604);
            this._criminalsList.TabIndex = 1;
            // 
            // _searchButton
            // 
            this._searchButton.Location = new System.Drawing.Point(57, 528);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(192, 43);
            this._searchButton.TabIndex = 2;
            this._searchButton.Text = "Search";
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this.ClickSearchButton);
            // 
            // _maxHeightList
            // 
            this._maxHeightList.FormattingEnabled = true;
            this._maxHeightList.Location = new System.Drawing.Point(170, 43);
            this._maxHeightList.Name = "_maxHeightList";
            this._maxHeightList.Size = new System.Drawing.Size(121, 28);
            this._maxHeightList.TabIndex = 3;
            this._maxHeightList.SelectedIndexChanged += new System.EventHandler(this.MaxHeightListSelectedIndexChanged);
            // 
            // _maxWeightList
            // 
            this._maxWeightList.FormattingEnabled = true;
            this._maxWeightList.Location = new System.Drawing.Point(170, 108);
            this._maxWeightList.Name = "_maxWeightList";
            this._maxWeightList.Size = new System.Drawing.Size(121, 28);
            this._maxWeightList.TabIndex = 5;
            this._maxWeightList.SelectedIndexChanged += new System.EventHandler(this.MaxWeightListSelectedIndexChanged);
            // 
            // _minWeightList
            // 
            this._minWeightList.FormattingEnabled = true;
            this._minWeightList.Location = new System.Drawing.Point(24, 108);
            this._minWeightList.Name = "_minWeightList";
            this._minWeightList.Size = new System.Drawing.Size(121, 28);
            this._minWeightList.TabIndex = 4;
            this._minWeightList.SelectedIndexChanged += new System.EventHandler(this.MinWeightListSelectedIndexChanged);
            // 
            // _minHeighLabel
            // 
            this._minHeighLabel.AutoSize = true;
            this._minHeighLabel.Location = new System.Drawing.Point(20, 20);
            this._minHeighLabel.Name = "_minHeighLabel";
            this._minHeighLabel.Size = new System.Drawing.Size(76, 20);
            this._minHeighLabel.TabIndex = 6;
            this._minHeighLabel.Text = "MinHeigh";
            // 
            // _maxHeighLabel
            // 
            this._maxHeighLabel.AutoSize = true;
            this._maxHeighLabel.Location = new System.Drawing.Point(166, 20);
            this._maxHeighLabel.Name = "_maxHeighLabel";
            this._maxHeighLabel.Size = new System.Drawing.Size(80, 20);
            this._maxHeighLabel.TabIndex = 7;
            this._maxHeighLabel.Text = "MaxHeigh";
            // 
            // _maxWeighLabel
            // 
            this._maxWeighLabel.AutoSize = true;
            this._maxWeighLabel.Location = new System.Drawing.Point(166, 85);
            this._maxWeighLabel.Name = "_maxWeighLabel";
            this._maxWeighLabel.Size = new System.Drawing.Size(83, 20);
            this._maxWeighLabel.TabIndex = 9;
            this._maxWeighLabel.Text = "MaxWeigh";
            // 
            // _minWeighLabel
            // 
            this._minWeighLabel.AutoSize = true;
            this._minWeighLabel.Location = new System.Drawing.Point(20, 85);
            this._minWeighLabel.Name = "_minWeighLabel";
            this._minWeighLabel.Size = new System.Drawing.Size(79, 20);
            this._minWeighLabel.TabIndex = 8;
            this._minWeighLabel.Text = "MinWeigh";
            // 
            // _nationalityList
            // 
            this._nationalityList.FormattingEnabled = true;
            this._nationalityList.Location = new System.Drawing.Point(24, 175);
            this._nationalityList.Name = "_nationalityList";
            this._nationalityList.Size = new System.Drawing.Size(121, 28);
            this._nationalityList.TabIndex = 10;
            this._nationalityList.SelectedIndexChanged += new System.EventHandler(this._nationalityList_SelectedIndexChanged);
            // 
            // _nationalityLabel
            // 
            this._nationalityLabel.AutoSize = true;
            this._nationalityLabel.Location = new System.Drawing.Point(20, 152);
            this._nationalityLabel.Name = "_nationalityLabel";
            this._nationalityLabel.Size = new System.Drawing.Size(82, 20);
            this._nationalityLabel.TabIndex = 11;
            this._nationalityLabel.Text = "Nationality";
            // 
            // _prisonedList
            // 
            this._prisonedList.FormattingEnabled = true;
            this._prisonedList.Location = new System.Drawing.Point(24, 238);
            this._prisonedList.Name = "_prisonedList";
            this._prisonedList.Size = new System.Drawing.Size(121, 28);
            this._prisonedList.TabIndex = 12;
            this._prisonedList.SelectedIndexChanged += new System.EventHandler(this._prisonedList_SelectedIndexChanged);
            // 
            // _statusLabel
            // 
            this._statusLabel.AutoSize = true;
            this._statusLabel.Location = new System.Drawing.Point(20, 215);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(56, 20);
            this._statusLabel.TabIndex = 13;
            this._statusLabel.Text = "Status";
            // 
            // CriminalFindingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 607);
            this.Controls.Add(this._statusLabel);
            this.Controls.Add(this._prisonedList);
            this.Controls.Add(this._nationalityLabel);
            this.Controls.Add(this._nationalityList);
            this.Controls.Add(this._maxWeighLabel);
            this.Controls.Add(this._minWeighLabel);
            this.Controls.Add(this._maxHeighLabel);
            this.Controls.Add(this._minHeighLabel);
            this.Controls.Add(this._maxWeightList);
            this.Controls.Add(this._minWeightList);
            this.Controls.Add(this._maxHeightList);
            this.Controls.Add(this._searchButton);
            this.Controls.Add(this._criminalsList);
            this.Controls.Add(this._minHeightList);
            this.Name = "CriminalFindingForm";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.LoadCriminalFindingForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _minHeightList;
        private System.Windows.Forms.ListBox _criminalsList;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.ComboBox _maxHeightList;
        private System.Windows.Forms.ComboBox _maxWeightList;
        private System.Windows.Forms.ComboBox _minWeightList;
        private System.Windows.Forms.Label _minHeighLabel;
        private System.Windows.Forms.Label _maxHeighLabel;
        private System.Windows.Forms.Label _maxWeighLabel;
        private System.Windows.Forms.Label _minWeighLabel;
        private System.Windows.Forms.ComboBox _nationalityList;
        private System.Windows.Forms.Label _nationalityLabel;
        private System.Windows.Forms.ComboBox _prisonedList;
        private System.Windows.Forms.Label _statusLabel;
    }
}

