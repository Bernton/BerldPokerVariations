namespace ExhaustiveSimulator
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
            _labelStraightFlush = new Label();
            _labelStraightFlushAmount = new Label();
            _labelTotalAmount = new Label();
            _labelTotal = new Label();
            _timerUpdateValues = new System.Windows.Forms.Timer(components);
            _labelStraightFlushRatio = new Label();
            _labelFourOfAKindRatio = new Label();
            _labelFourOfAKindAmount = new Label();
            _labelFourOfAKind = new Label();
            _labelCombinationsAmount = new Label();
            _labelRoyalFlushRatio = new Label();
            _labelRoyalFlushAmount = new Label();
            _labelRoyalFlush = new Label();
            _labelCombinations = new Label();
            _progressBar = new ProgressBar();
            _labelFullHouseRatio = new Label();
            _labelFullHouseAmount = new Label();
            _labelFullHouse = new Label();
            _labelTime = new Label();
            _labelFlushRatio = new Label();
            _labelFlushAmount = new Label();
            _labelFlush = new Label();
            _labelStraightRatio = new Label();
            _labelStraightAmount = new Label();
            _labelStraight = new Label();
            _labelThreeOfAKindRatio = new Label();
            _labelThreeOfAKindAmount = new Label();
            _labelThreeOfAKind = new Label();
            _labelTwoPairRatio = new Label();
            _labelTwoPairAmount = new Label();
            _labelTwoPair = new Label();
            _labelPairRatio = new Label();
            _labelPairAmount = new Label();
            _labelPair = new Label();
            _labelHighCardRatio = new Label();
            _labelHighCardAmount = new Label();
            _labelHighCard = new Label();
            SuspendLayout();
            // 
            // _labelStraightFlush
            // 
            _labelStraightFlush.AutoSize = true;
            _labelStraightFlush.Location = new Point(12, 34);
            _labelStraightFlush.Name = "_labelStraightFlush";
            _labelStraightFlush.Size = new Size(77, 15);
            _labelStraightFlush.TabIndex = 0;
            _labelStraightFlush.Text = "Straight flush";
            // 
            // _labelStraightFlushAmount
            // 
            _labelStraightFlushAmount.Location = new Point(103, 34);
            _labelStraightFlushAmount.Name = "_labelStraightFlushAmount";
            _labelStraightFlushAmount.RightToLeft = RightToLeft.No;
            _labelStraightFlushAmount.Size = new Size(85, 15);
            _labelStraightFlushAmount.TabIndex = 1;
            _labelStraightFlushAmount.Text = "0";
            _labelStraightFlushAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelTotalAmount
            // 
            _labelTotalAmount.Location = new Point(103, 283);
            _labelTotalAmount.Name = "_labelTotalAmount";
            _labelTotalAmount.RightToLeft = RightToLeft.No;
            _labelTotalAmount.Size = new Size(85, 15);
            _labelTotalAmount.TabIndex = 3;
            _labelTotalAmount.Text = "0";
            _labelTotalAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelTotal
            // 
            _labelTotal.AutoSize = true;
            _labelTotal.Location = new Point(12, 283);
            _labelTotal.Name = "_labelTotal";
            _labelTotal.Size = new Size(32, 15);
            _labelTotal.TabIndex = 2;
            _labelTotal.Text = "Total";
            // 
            // _timerUpdateValues
            // 
            _timerUpdateValues.Enabled = true;
            _timerUpdateValues.Tick += OnTimerUpdateValuesTick;
            // 
            // _labelStraightFlushRatio
            // 
            _labelStraightFlushRatio.Location = new Point(205, 34);
            _labelStraightFlushRatio.Name = "_labelStraightFlushRatio";
            _labelStraightFlushRatio.RightToLeft = RightToLeft.No;
            _labelStraightFlushRatio.Size = new Size(102, 15);
            _labelStraightFlushRatio.TabIndex = 4;
            _labelStraightFlushRatio.Text = "0 %";
            _labelStraightFlushRatio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelFourOfAKindRatio
            // 
            _labelFourOfAKindRatio.Location = new Point(205, 58);
            _labelFourOfAKindRatio.Name = "_labelFourOfAKindRatio";
            _labelFourOfAKindRatio.RightToLeft = RightToLeft.No;
            _labelFourOfAKindRatio.Size = new Size(102, 15);
            _labelFourOfAKindRatio.TabIndex = 8;
            _labelFourOfAKindRatio.Text = "0 %";
            _labelFourOfAKindRatio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelFourOfAKindAmount
            // 
            _labelFourOfAKindAmount.Location = new Point(103, 58);
            _labelFourOfAKindAmount.Name = "_labelFourOfAKindAmount";
            _labelFourOfAKindAmount.RightToLeft = RightToLeft.No;
            _labelFourOfAKindAmount.Size = new Size(85, 15);
            _labelFourOfAKindAmount.TabIndex = 7;
            _labelFourOfAKindAmount.Text = "0";
            _labelFourOfAKindAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelFourOfAKind
            // 
            _labelFourOfAKind.AutoSize = true;
            _labelFourOfAKind.Location = new Point(12, 58);
            _labelFourOfAKind.Name = "_labelFourOfAKind";
            _labelFourOfAKind.Size = new Size(80, 15);
            _labelFourOfAKind.TabIndex = 6;
            _labelFourOfAKind.Text = "Four of a kind";
            // 
            // _labelCombinationsAmount
            // 
            _labelCombinationsAmount.Location = new Point(103, 309);
            _labelCombinationsAmount.Name = "_labelCombinationsAmount";
            _labelCombinationsAmount.RightToLeft = RightToLeft.No;
            _labelCombinationsAmount.Size = new Size(85, 15);
            _labelCombinationsAmount.TabIndex = 9;
            _labelCombinationsAmount.Text = "133784560";
            _labelCombinationsAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelRoyalFlushRatio
            // 
            _labelRoyalFlushRatio.Location = new Point(205, 9);
            _labelRoyalFlushRatio.Name = "_labelRoyalFlushRatio";
            _labelRoyalFlushRatio.RightToLeft = RightToLeft.No;
            _labelRoyalFlushRatio.Size = new Size(102, 15);
            _labelRoyalFlushRatio.TabIndex = 12;
            _labelRoyalFlushRatio.Text = "0 %";
            _labelRoyalFlushRatio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelRoyalFlushAmount
            // 
            _labelRoyalFlushAmount.Location = new Point(103, 9);
            _labelRoyalFlushAmount.Name = "_labelRoyalFlushAmount";
            _labelRoyalFlushAmount.RightToLeft = RightToLeft.No;
            _labelRoyalFlushAmount.Size = new Size(85, 15);
            _labelRoyalFlushAmount.TabIndex = 11;
            _labelRoyalFlushAmount.Text = "0";
            _labelRoyalFlushAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelRoyalFlush
            // 
            _labelRoyalFlush.AutoSize = true;
            _labelRoyalFlush.Location = new Point(12, 9);
            _labelRoyalFlush.Name = "_labelRoyalFlush";
            _labelRoyalFlush.Size = new Size(65, 15);
            _labelRoyalFlush.TabIndex = 10;
            _labelRoyalFlush.Text = "Royal flush";
            // 
            // _labelCombinations
            // 
            _labelCombinations.AutoSize = true;
            _labelCombinations.Location = new Point(12, 309);
            _labelCombinations.Name = "_labelCombinations";
            _labelCombinations.Size = new Size(82, 15);
            _labelCombinations.TabIndex = 13;
            _labelCombinations.Text = "Combinations";
            // 
            // _progressBar
            // 
            _progressBar.Location = new Point(12, 350);
            _progressBar.Maximum = 1000;
            _progressBar.Name = "_progressBar";
            _progressBar.Size = new Size(295, 23);
            _progressBar.TabIndex = 14;
            // 
            // _labelFullHouseRatio
            // 
            _labelFullHouseRatio.Location = new Point(205, 83);
            _labelFullHouseRatio.Name = "_labelFullHouseRatio";
            _labelFullHouseRatio.RightToLeft = RightToLeft.No;
            _labelFullHouseRatio.Size = new Size(102, 15);
            _labelFullHouseRatio.TabIndex = 17;
            _labelFullHouseRatio.Text = "0 %";
            _labelFullHouseRatio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelFullHouseAmount
            // 
            _labelFullHouseAmount.Location = new Point(103, 83);
            _labelFullHouseAmount.Name = "_labelFullHouseAmount";
            _labelFullHouseAmount.RightToLeft = RightToLeft.No;
            _labelFullHouseAmount.Size = new Size(85, 15);
            _labelFullHouseAmount.TabIndex = 16;
            _labelFullHouseAmount.Text = "0";
            _labelFullHouseAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelFullHouse
            // 
            _labelFullHouse.AutoSize = true;
            _labelFullHouse.Location = new Point(12, 83);
            _labelFullHouse.Name = "_labelFullHouse";
            _labelFullHouse.Size = new Size(61, 15);
            _labelFullHouse.TabIndex = 15;
            _labelFullHouse.Text = "Full house";
            // 
            // _labelTime
            // 
            _labelTime.Location = new Point(222, 382);
            _labelTime.Name = "_labelTime";
            _labelTime.RightToLeft = RightToLeft.No;
            _labelTime.Size = new Size(85, 15);
            _labelTime.TabIndex = 18;
            _labelTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelFlushRatio
            // 
            _labelFlushRatio.Location = new Point(205, 108);
            _labelFlushRatio.Name = "_labelFlushRatio";
            _labelFlushRatio.RightToLeft = RightToLeft.No;
            _labelFlushRatio.Size = new Size(102, 15);
            _labelFlushRatio.TabIndex = 21;
            _labelFlushRatio.Text = "0 %";
            _labelFlushRatio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelFlushAmount
            // 
            _labelFlushAmount.Location = new Point(103, 108);
            _labelFlushAmount.Name = "_labelFlushAmount";
            _labelFlushAmount.RightToLeft = RightToLeft.No;
            _labelFlushAmount.Size = new Size(85, 15);
            _labelFlushAmount.TabIndex = 20;
            _labelFlushAmount.Text = "0";
            _labelFlushAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelFlush
            // 
            _labelFlush.AutoSize = true;
            _labelFlush.Location = new Point(12, 108);
            _labelFlush.Name = "_labelFlush";
            _labelFlush.Size = new Size(35, 15);
            _labelFlush.TabIndex = 19;
            _labelFlush.Text = "Flush";
            // 
            // _labelStraightRatio
            // 
            _labelStraightRatio.Location = new Point(205, 133);
            _labelStraightRatio.Name = "_labelStraightRatio";
            _labelStraightRatio.RightToLeft = RightToLeft.No;
            _labelStraightRatio.Size = new Size(102, 15);
            _labelStraightRatio.TabIndex = 24;
            _labelStraightRatio.Text = "0 %";
            _labelStraightRatio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelStraightAmount
            // 
            _labelStraightAmount.Location = new Point(103, 133);
            _labelStraightAmount.Name = "_labelStraightAmount";
            _labelStraightAmount.RightToLeft = RightToLeft.No;
            _labelStraightAmount.Size = new Size(85, 15);
            _labelStraightAmount.TabIndex = 23;
            _labelStraightAmount.Text = "0";
            _labelStraightAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelStraight
            // 
            _labelStraight.AutoSize = true;
            _labelStraight.Location = new Point(12, 133);
            _labelStraight.Name = "_labelStraight";
            _labelStraight.Size = new Size(48, 15);
            _labelStraight.TabIndex = 22;
            _labelStraight.Text = "Straight";
            // 
            // _labelThreeOfAKindRatio
            // 
            _labelThreeOfAKindRatio.Location = new Point(205, 160);
            _labelThreeOfAKindRatio.Name = "_labelThreeOfAKindRatio";
            _labelThreeOfAKindRatio.RightToLeft = RightToLeft.No;
            _labelThreeOfAKindRatio.Size = new Size(102, 15);
            _labelThreeOfAKindRatio.TabIndex = 27;
            _labelThreeOfAKindRatio.Text = "0 %";
            _labelThreeOfAKindRatio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelThreeOfAKindAmount
            // 
            _labelThreeOfAKindAmount.Location = new Point(103, 160);
            _labelThreeOfAKindAmount.Name = "_labelThreeOfAKindAmount";
            _labelThreeOfAKindAmount.RightToLeft = RightToLeft.No;
            _labelThreeOfAKindAmount.Size = new Size(85, 15);
            _labelThreeOfAKindAmount.TabIndex = 26;
            _labelThreeOfAKindAmount.Text = "0";
            _labelThreeOfAKindAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelThreeOfAKind
            // 
            _labelThreeOfAKind.AutoSize = true;
            _labelThreeOfAKind.Location = new Point(12, 160);
            _labelThreeOfAKind.Name = "_labelThreeOfAKind";
            _labelThreeOfAKind.Size = new Size(85, 15);
            _labelThreeOfAKind.TabIndex = 25;
            _labelThreeOfAKind.Text = "Three of a kind";
            // 
            // _labelTwoPairRatio
            // 
            _labelTwoPairRatio.Location = new Point(205, 187);
            _labelTwoPairRatio.Name = "_labelTwoPairRatio";
            _labelTwoPairRatio.RightToLeft = RightToLeft.No;
            _labelTwoPairRatio.Size = new Size(102, 15);
            _labelTwoPairRatio.TabIndex = 30;
            _labelTwoPairRatio.Text = "0 %";
            _labelTwoPairRatio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelTwoPairAmount
            // 
            _labelTwoPairAmount.Location = new Point(103, 187);
            _labelTwoPairAmount.Name = "_labelTwoPairAmount";
            _labelTwoPairAmount.RightToLeft = RightToLeft.No;
            _labelTwoPairAmount.Size = new Size(85, 15);
            _labelTwoPairAmount.TabIndex = 29;
            _labelTwoPairAmount.Text = "0";
            _labelTwoPairAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelTwoPair
            // 
            _labelTwoPair.AutoSize = true;
            _labelTwoPair.Location = new Point(12, 187);
            _labelTwoPair.Name = "_labelTwoPair";
            _labelTwoPair.Size = new Size(51, 15);
            _labelTwoPair.TabIndex = 28;
            _labelTwoPair.Text = "Two pair";
            // 
            // _labelPairRatio
            // 
            _labelPairRatio.Location = new Point(205, 214);
            _labelPairRatio.Name = "_labelPairRatio";
            _labelPairRatio.RightToLeft = RightToLeft.No;
            _labelPairRatio.Size = new Size(102, 15);
            _labelPairRatio.TabIndex = 33;
            _labelPairRatio.Text = "0 %";
            _labelPairRatio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelPairAmount
            // 
            _labelPairAmount.Location = new Point(103, 214);
            _labelPairAmount.Name = "_labelPairAmount";
            _labelPairAmount.RightToLeft = RightToLeft.No;
            _labelPairAmount.Size = new Size(85, 15);
            _labelPairAmount.TabIndex = 32;
            _labelPairAmount.Text = "0";
            _labelPairAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelPair
            // 
            _labelPair.AutoSize = true;
            _labelPair.Location = new Point(12, 214);
            _labelPair.Name = "_labelPair";
            _labelPair.Size = new Size(27, 15);
            _labelPair.TabIndex = 31;
            _labelPair.Text = "Pair";
            // 
            // _labelHighCardRatio
            // 
            _labelHighCardRatio.Location = new Point(205, 241);
            _labelHighCardRatio.Name = "_labelHighCardRatio";
            _labelHighCardRatio.RightToLeft = RightToLeft.No;
            _labelHighCardRatio.Size = new Size(102, 15);
            _labelHighCardRatio.TabIndex = 36;
            _labelHighCardRatio.Text = "0 %";
            _labelHighCardRatio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelHighCardAmount
            // 
            _labelHighCardAmount.Location = new Point(103, 241);
            _labelHighCardAmount.Name = "_labelHighCardAmount";
            _labelHighCardAmount.RightToLeft = RightToLeft.No;
            _labelHighCardAmount.Size = new Size(85, 15);
            _labelHighCardAmount.TabIndex = 35;
            _labelHighCardAmount.Text = "0";
            _labelHighCardAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _labelHighCard
            // 
            _labelHighCard.AutoSize = true;
            _labelHighCard.Location = new Point(12, 241);
            _labelHighCard.Name = "_labelHighCard";
            _labelHighCard.Size = new Size(59, 15);
            _labelHighCard.TabIndex = 34;
            _labelHighCard.Text = "High card";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 408);
            Controls.Add(_labelHighCardRatio);
            Controls.Add(_labelHighCardAmount);
            Controls.Add(_labelHighCard);
            Controls.Add(_labelPairRatio);
            Controls.Add(_labelPairAmount);
            Controls.Add(_labelPair);
            Controls.Add(_labelTwoPairRatio);
            Controls.Add(_labelTwoPairAmount);
            Controls.Add(_labelTwoPair);
            Controls.Add(_labelThreeOfAKindRatio);
            Controls.Add(_labelThreeOfAKindAmount);
            Controls.Add(_labelThreeOfAKind);
            Controls.Add(_labelStraightRatio);
            Controls.Add(_labelStraightAmount);
            Controls.Add(_labelStraight);
            Controls.Add(_labelFlushRatio);
            Controls.Add(_labelFlushAmount);
            Controls.Add(_labelFlush);
            Controls.Add(_labelTime);
            Controls.Add(_labelFullHouseRatio);
            Controls.Add(_labelFullHouseAmount);
            Controls.Add(_labelFullHouse);
            Controls.Add(_progressBar);
            Controls.Add(_labelCombinations);
            Controls.Add(_labelRoyalFlushRatio);
            Controls.Add(_labelRoyalFlushAmount);
            Controls.Add(_labelRoyalFlush);
            Controls.Add(_labelCombinationsAmount);
            Controls.Add(_labelFourOfAKindRatio);
            Controls.Add(_labelFourOfAKindAmount);
            Controls.Add(_labelFourOfAKind);
            Controls.Add(_labelStraightFlushRatio);
            Controls.Add(_labelTotalAmount);
            Controls.Add(_labelTotal);
            Controls.Add(_labelStraightFlushAmount);
            Controls.Add(_labelStraightFlush);
            MaximumSize = new Size(816, 447);
            MinimumSize = new Size(816, 447);
            Name = "FormMain";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label _labelStraightFlush;
        private Label _labelStraightFlushAmount;
        private Label _labelTotalAmount;
        private Label _labelTotal;
        private System.Windows.Forms.Timer _timerUpdateValues;
        private Label _labelStraightFlushRatio;
        private Label _labelFourOfAKindRatio;
        private Label _labelFourOfAKindAmount;
        private Label _labelFourOfAKind;
        private Label _labelCombinationsAmount;
        private Label _labelRoyalFlushRatio;
        private Label _labelRoyalFlushAmount;
        private Label _labelRoyalFlush;
        private Label _labelCombinations;
        private ProgressBar _progressBar;
        private Label _labelFullHouseRatio;
        private Label _labelFullHouseAmount;
        private Label _labelFullHouse;
        private Label _labelTime;
        private Label _labelFlushRatio;
        private Label _labelFlushAmount;
        private Label _labelFlush;
        private Label _labelStraightRatio;
        private Label _labelStraightAmount;
        private Label _labelStraight;
        private Label _labelThreeOfAKindRatio;
        private Label _labelThreeOfAKindAmount;
        private Label _labelThreeOfAKind;
        private Label _labelTwoPairRatio;
        private Label _labelTwoPairAmount;
        private Label _labelTwoPair;
        private Label _labelPairRatio;
        private Label _labelPairAmount;
        private Label _labelPair;
        private Label _labelHighCardRatio;
        private Label _labelHighCardAmount;
        private Label _labelHighCard;
    }
}