namespace OmahaSim
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _textBoxCards = new TextBox();
            _labelEquity = new Label();
            _labelEquityValue = new Label();
            _labelCards = new Label();
            _buttonStart = new Button();
            _buttonStop = new Button();
            _labelCardsError = new Label();
            _timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // _textBoxCards
            // 
            _textBoxCards.Location = new Point(147, 40);
            _textBoxCards.Name = "_textBoxCards";
            _textBoxCards.Size = new Size(74, 23);
            _textBoxCards.TabIndex = 0;
            _textBoxCards.Text = "AsKsAhKh";
            // 
            // _labelEquity
            // 
            _labelEquity.AutoSize = true;
            _labelEquity.Location = new Point(12, 9);
            _labelEquity.Name = "_labelEquity";
            _labelEquity.Size = new Size(129, 15);
            _labelEquity.TabIndex = 1;
            _labelEquity.Text = "Equity against random:";
            // 
            // _labelEquityValue
            // 
            _labelEquityValue.Location = new Point(147, 9);
            _labelEquityValue.Name = "_labelEquityValue";
            _labelEquityValue.Size = new Size(74, 24);
            _labelEquityValue.TabIndex = 2;
            _labelEquityValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelCards
            // 
            _labelCards.AutoSize = true;
            _labelCards.Location = new Point(12, 40);
            _labelCards.Name = "_labelCards";
            _labelCards.Size = new Size(65, 15);
            _labelCards.TabIndex = 3;
            _labelCards.Text = "Your cards:";
            // 
            // _buttonStart
            // 
            _buttonStart.Location = new Point(10, 76);
            _buttonStart.Name = "_buttonStart";
            _buttonStart.Size = new Size(75, 23);
            _buttonStart.TabIndex = 4;
            _buttonStart.Text = "Start";
            _buttonStart.UseVisualStyleBackColor = true;
            _buttonStart.Click += OnButtonStartClick;
            // 
            // _buttonStop
            // 
            _buttonStop.Location = new Point(91, 76);
            _buttonStop.Name = "_buttonStop";
            _buttonStop.Size = new Size(75, 23);
            _buttonStop.TabIndex = 5;
            _buttonStop.Text = "Stop";
            _buttonStop.UseVisualStyleBackColor = true;
            _buttonStop.Click += OnButtonStopClick;
            // 
            // _labelCardsError
            // 
            _labelCardsError.AutoSize = true;
            _labelCardsError.ForeColor = Color.Red;
            _labelCardsError.Location = new Point(227, 48);
            _labelCardsError.Name = "_labelCardsError";
            _labelCardsError.Size = new Size(0, 15);
            _labelCardsError.TabIndex = 6;
            // 
            // _timer
            // 
            _timer.Enabled = true;
            _timer.Tick += OnTimerTick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_labelCardsError);
            Controls.Add(_buttonStop);
            Controls.Add(_buttonStart);
            Controls.Add(_labelCards);
            Controls.Add(_labelEquityValue);
            Controls.Add(_labelEquity);
            Controls.Add(_textBoxCards);
            Name = "FormMain";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox _textBoxCards;
        private Label _labelEquity;
        private Label _labelEquityValue;
        private Label _labelCards;
        private Button _buttonStart;
        private Button _buttonStop;
        private Label _labelCardsError;
        private System.Windows.Forms.Timer _timer;
    }
}