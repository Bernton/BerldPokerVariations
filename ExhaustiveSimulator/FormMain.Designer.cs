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
            this.components = new System.ComponentModel.Container();
            this._labelStraightFlush = new System.Windows.Forms.Label();
            this._labelStraightFlushAmount = new System.Windows.Forms.Label();
            this._labelTotalAmount = new System.Windows.Forms.Label();
            this._labelTotal = new System.Windows.Forms.Label();
            this._timerUpdateValues = new System.Windows.Forms.Timer(this.components);
            this._labelStraightFlushRatio = new System.Windows.Forms.Label();
            this._labelFourOfAKindRatio = new System.Windows.Forms.Label();
            this._labelFourOfAKindAmount = new System.Windows.Forms.Label();
            this._labelFourOfAKind = new System.Windows.Forms.Label();
            this._labelCombinationsAmount = new System.Windows.Forms.Label();
            this._labelRoyalFlushRatio = new System.Windows.Forms.Label();
            this._labelRoyalFlushAmount = new System.Windows.Forms.Label();
            this._labelRoyalFlush = new System.Windows.Forms.Label();
            this._labelCombinations = new System.Windows.Forms.Label();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._labelFullHouseRatio = new System.Windows.Forms.Label();
            this._labelFullHouseAmount = new System.Windows.Forms.Label();
            this._labelFullHouse = new System.Windows.Forms.Label();
            this._labelTime = new System.Windows.Forms.Label();
            this._labelFlushRatio = new System.Windows.Forms.Label();
            this._labelFlushAmount = new System.Windows.Forms.Label();
            this._labelFlush = new System.Windows.Forms.Label();
            this._labelStraightRatio = new System.Windows.Forms.Label();
            this._labelStraightAmount = new System.Windows.Forms.Label();
            this._labelStraight = new System.Windows.Forms.Label();
            this._labelThreeOfAKindRatio = new System.Windows.Forms.Label();
            this._labelThreeOfAKindAmount = new System.Windows.Forms.Label();
            this._labelThreeOfAKind = new System.Windows.Forms.Label();
            this._labelTwoPairRatio = new System.Windows.Forms.Label();
            this._labelTwoPairAmount = new System.Windows.Forms.Label();
            this._labelTwoPair = new System.Windows.Forms.Label();
            this._labelPairRatio = new System.Windows.Forms.Label();
            this._labelPairAmount = new System.Windows.Forms.Label();
            this._labelPair = new System.Windows.Forms.Label();
            this._labelHighCardRatio = new System.Windows.Forms.Label();
            this._labelHighCardAmount = new System.Windows.Forms.Label();
            this._labelHighCard = new System.Windows.Forms.Label();
            this._buttonRestart = new System.Windows.Forms.Button();
            this._buttonStop = new System.Windows.Forms.Button();
            this._labelAmountOfCardsValue = new System.Windows.Forms.TextBox();
            this._labelAmountOfCards = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _labelStraightFlush
            // 
            this._labelStraightFlush.AutoSize = true;
            this._labelStraightFlush.Location = new System.Drawing.Point(488, 34);
            this._labelStraightFlush.Name = "_labelStraightFlush";
            this._labelStraightFlush.Size = new System.Drawing.Size(77, 15);
            this._labelStraightFlush.TabIndex = 0;
            this._labelStraightFlush.Text = "Straight flush";
            // 
            // _labelStraightFlushAmount
            // 
            this._labelStraightFlushAmount.Location = new System.Drawing.Point(579, 34);
            this._labelStraightFlushAmount.Name = "_labelStraightFlushAmount";
            this._labelStraightFlushAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelStraightFlushAmount.Size = new System.Drawing.Size(85, 15);
            this._labelStraightFlushAmount.TabIndex = 1;
            this._labelStraightFlushAmount.Text = "0";
            this._labelStraightFlushAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelTotalAmount
            // 
            this._labelTotalAmount.Location = new System.Drawing.Point(579, 283);
            this._labelTotalAmount.Name = "_labelTotalAmount";
            this._labelTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelTotalAmount.Size = new System.Drawing.Size(85, 15);
            this._labelTotalAmount.TabIndex = 3;
            this._labelTotalAmount.Text = "0";
            this._labelTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelTotal
            // 
            this._labelTotal.AutoSize = true;
            this._labelTotal.Location = new System.Drawing.Point(488, 283);
            this._labelTotal.Name = "_labelTotal";
            this._labelTotal.Size = new System.Drawing.Size(32, 15);
            this._labelTotal.TabIndex = 2;
            this._labelTotal.Text = "Total";
            // 
            // _timerUpdateValues
            // 
            this._timerUpdateValues.Enabled = true;
            this._timerUpdateValues.Tick += new System.EventHandler(this.OnTimerUpdateValuesTick);
            // 
            // _labelStraightFlushRatio
            // 
            this._labelStraightFlushRatio.Location = new System.Drawing.Point(681, 34);
            this._labelStraightFlushRatio.Name = "_labelStraightFlushRatio";
            this._labelStraightFlushRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelStraightFlushRatio.Size = new System.Drawing.Size(102, 15);
            this._labelStraightFlushRatio.TabIndex = 4;
            this._labelStraightFlushRatio.Text = "0 %";
            this._labelStraightFlushRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelFourOfAKindRatio
            // 
            this._labelFourOfAKindRatio.Location = new System.Drawing.Point(681, 58);
            this._labelFourOfAKindRatio.Name = "_labelFourOfAKindRatio";
            this._labelFourOfAKindRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelFourOfAKindRatio.Size = new System.Drawing.Size(102, 15);
            this._labelFourOfAKindRatio.TabIndex = 8;
            this._labelFourOfAKindRatio.Text = "0 %";
            this._labelFourOfAKindRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelFourOfAKindAmount
            // 
            this._labelFourOfAKindAmount.Location = new System.Drawing.Point(579, 58);
            this._labelFourOfAKindAmount.Name = "_labelFourOfAKindAmount";
            this._labelFourOfAKindAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelFourOfAKindAmount.Size = new System.Drawing.Size(85, 15);
            this._labelFourOfAKindAmount.TabIndex = 7;
            this._labelFourOfAKindAmount.Text = "0";
            this._labelFourOfAKindAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelFourOfAKind
            // 
            this._labelFourOfAKind.AutoSize = true;
            this._labelFourOfAKind.Location = new System.Drawing.Point(488, 58);
            this._labelFourOfAKind.Name = "_labelFourOfAKind";
            this._labelFourOfAKind.Size = new System.Drawing.Size(80, 15);
            this._labelFourOfAKind.TabIndex = 6;
            this._labelFourOfAKind.Text = "Four of a kind";
            // 
            // _labelCombinationsAmount
            // 
            this._labelCombinationsAmount.Location = new System.Drawing.Point(579, 309);
            this._labelCombinationsAmount.Name = "_labelCombinationsAmount";
            this._labelCombinationsAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelCombinationsAmount.Size = new System.Drawing.Size(85, 15);
            this._labelCombinationsAmount.TabIndex = 9;
            this._labelCombinationsAmount.Text = "133784560";
            this._labelCombinationsAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelRoyalFlushRatio
            // 
            this._labelRoyalFlushRatio.Location = new System.Drawing.Point(681, 9);
            this._labelRoyalFlushRatio.Name = "_labelRoyalFlushRatio";
            this._labelRoyalFlushRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelRoyalFlushRatio.Size = new System.Drawing.Size(102, 15);
            this._labelRoyalFlushRatio.TabIndex = 12;
            this._labelRoyalFlushRatio.Text = "0 %";
            this._labelRoyalFlushRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelRoyalFlushAmount
            // 
            this._labelRoyalFlushAmount.Location = new System.Drawing.Point(579, 9);
            this._labelRoyalFlushAmount.Name = "_labelRoyalFlushAmount";
            this._labelRoyalFlushAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelRoyalFlushAmount.Size = new System.Drawing.Size(85, 15);
            this._labelRoyalFlushAmount.TabIndex = 11;
            this._labelRoyalFlushAmount.Text = "0";
            this._labelRoyalFlushAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelRoyalFlush
            // 
            this._labelRoyalFlush.AutoSize = true;
            this._labelRoyalFlush.Location = new System.Drawing.Point(488, 9);
            this._labelRoyalFlush.Name = "_labelRoyalFlush";
            this._labelRoyalFlush.Size = new System.Drawing.Size(65, 15);
            this._labelRoyalFlush.TabIndex = 10;
            this._labelRoyalFlush.Text = "Royal flush";
            // 
            // _labelCombinations
            // 
            this._labelCombinations.AutoSize = true;
            this._labelCombinations.Location = new System.Drawing.Point(488, 309);
            this._labelCombinations.Name = "_labelCombinations";
            this._labelCombinations.Size = new System.Drawing.Size(82, 15);
            this._labelCombinations.TabIndex = 13;
            this._labelCombinations.Text = "Combinations";
            // 
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(488, 350);
            this._progressBar.Maximum = 1000;
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(295, 23);
            this._progressBar.TabIndex = 14;
            // 
            // _labelFullHouseRatio
            // 
            this._labelFullHouseRatio.Location = new System.Drawing.Point(681, 83);
            this._labelFullHouseRatio.Name = "_labelFullHouseRatio";
            this._labelFullHouseRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelFullHouseRatio.Size = new System.Drawing.Size(102, 15);
            this._labelFullHouseRatio.TabIndex = 17;
            this._labelFullHouseRatio.Text = "0 %";
            this._labelFullHouseRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelFullHouseAmount
            // 
            this._labelFullHouseAmount.Location = new System.Drawing.Point(579, 83);
            this._labelFullHouseAmount.Name = "_labelFullHouseAmount";
            this._labelFullHouseAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelFullHouseAmount.Size = new System.Drawing.Size(85, 15);
            this._labelFullHouseAmount.TabIndex = 16;
            this._labelFullHouseAmount.Text = "0";
            this._labelFullHouseAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelFullHouse
            // 
            this._labelFullHouse.AutoSize = true;
            this._labelFullHouse.Location = new System.Drawing.Point(488, 83);
            this._labelFullHouse.Name = "_labelFullHouse";
            this._labelFullHouse.Size = new System.Drawing.Size(61, 15);
            this._labelFullHouse.TabIndex = 15;
            this._labelFullHouse.Text = "Full house";
            // 
            // _labelTime
            // 
            this._labelTime.Location = new System.Drawing.Point(694, 382);
            this._labelTime.Name = "_labelTime";
            this._labelTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelTime.Size = new System.Drawing.Size(85, 15);
            this._labelTime.TabIndex = 18;
            this._labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelFlushRatio
            // 
            this._labelFlushRatio.Location = new System.Drawing.Point(681, 108);
            this._labelFlushRatio.Name = "_labelFlushRatio";
            this._labelFlushRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelFlushRatio.Size = new System.Drawing.Size(102, 15);
            this._labelFlushRatio.TabIndex = 21;
            this._labelFlushRatio.Text = "0 %";
            this._labelFlushRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelFlushAmount
            // 
            this._labelFlushAmount.Location = new System.Drawing.Point(579, 108);
            this._labelFlushAmount.Name = "_labelFlushAmount";
            this._labelFlushAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelFlushAmount.Size = new System.Drawing.Size(85, 15);
            this._labelFlushAmount.TabIndex = 20;
            this._labelFlushAmount.Text = "0";
            this._labelFlushAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelFlush
            // 
            this._labelFlush.AutoSize = true;
            this._labelFlush.Location = new System.Drawing.Point(488, 108);
            this._labelFlush.Name = "_labelFlush";
            this._labelFlush.Size = new System.Drawing.Size(35, 15);
            this._labelFlush.TabIndex = 19;
            this._labelFlush.Text = "Flush";
            // 
            // _labelStraightRatio
            // 
            this._labelStraightRatio.Location = new System.Drawing.Point(681, 133);
            this._labelStraightRatio.Name = "_labelStraightRatio";
            this._labelStraightRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelStraightRatio.Size = new System.Drawing.Size(102, 15);
            this._labelStraightRatio.TabIndex = 24;
            this._labelStraightRatio.Text = "0 %";
            this._labelStraightRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelStraightAmount
            // 
            this._labelStraightAmount.Location = new System.Drawing.Point(579, 133);
            this._labelStraightAmount.Name = "_labelStraightAmount";
            this._labelStraightAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelStraightAmount.Size = new System.Drawing.Size(85, 15);
            this._labelStraightAmount.TabIndex = 23;
            this._labelStraightAmount.Text = "0";
            this._labelStraightAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelStraight
            // 
            this._labelStraight.AutoSize = true;
            this._labelStraight.Location = new System.Drawing.Point(488, 133);
            this._labelStraight.Name = "_labelStraight";
            this._labelStraight.Size = new System.Drawing.Size(48, 15);
            this._labelStraight.TabIndex = 22;
            this._labelStraight.Text = "Straight";
            // 
            // _labelThreeOfAKindRatio
            // 
            this._labelThreeOfAKindRatio.Location = new System.Drawing.Point(681, 160);
            this._labelThreeOfAKindRatio.Name = "_labelThreeOfAKindRatio";
            this._labelThreeOfAKindRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelThreeOfAKindRatio.Size = new System.Drawing.Size(102, 15);
            this._labelThreeOfAKindRatio.TabIndex = 27;
            this._labelThreeOfAKindRatio.Text = "0 %";
            this._labelThreeOfAKindRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelThreeOfAKindAmount
            // 
            this._labelThreeOfAKindAmount.Location = new System.Drawing.Point(579, 160);
            this._labelThreeOfAKindAmount.Name = "_labelThreeOfAKindAmount";
            this._labelThreeOfAKindAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelThreeOfAKindAmount.Size = new System.Drawing.Size(85, 15);
            this._labelThreeOfAKindAmount.TabIndex = 26;
            this._labelThreeOfAKindAmount.Text = "0";
            this._labelThreeOfAKindAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelThreeOfAKind
            // 
            this._labelThreeOfAKind.AutoSize = true;
            this._labelThreeOfAKind.Location = new System.Drawing.Point(488, 160);
            this._labelThreeOfAKind.Name = "_labelThreeOfAKind";
            this._labelThreeOfAKind.Size = new System.Drawing.Size(85, 15);
            this._labelThreeOfAKind.TabIndex = 25;
            this._labelThreeOfAKind.Text = "Three of a kind";
            // 
            // _labelTwoPairRatio
            // 
            this._labelTwoPairRatio.Location = new System.Drawing.Point(681, 187);
            this._labelTwoPairRatio.Name = "_labelTwoPairRatio";
            this._labelTwoPairRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelTwoPairRatio.Size = new System.Drawing.Size(102, 15);
            this._labelTwoPairRatio.TabIndex = 30;
            this._labelTwoPairRatio.Text = "0 %";
            this._labelTwoPairRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelTwoPairAmount
            // 
            this._labelTwoPairAmount.Location = new System.Drawing.Point(579, 187);
            this._labelTwoPairAmount.Name = "_labelTwoPairAmount";
            this._labelTwoPairAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelTwoPairAmount.Size = new System.Drawing.Size(85, 15);
            this._labelTwoPairAmount.TabIndex = 29;
            this._labelTwoPairAmount.Text = "0";
            this._labelTwoPairAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelTwoPair
            // 
            this._labelTwoPair.AutoSize = true;
            this._labelTwoPair.Location = new System.Drawing.Point(488, 187);
            this._labelTwoPair.Name = "_labelTwoPair";
            this._labelTwoPair.Size = new System.Drawing.Size(51, 15);
            this._labelTwoPair.TabIndex = 28;
            this._labelTwoPair.Text = "Two pair";
            // 
            // _labelPairRatio
            // 
            this._labelPairRatio.Location = new System.Drawing.Point(681, 214);
            this._labelPairRatio.Name = "_labelPairRatio";
            this._labelPairRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelPairRatio.Size = new System.Drawing.Size(102, 15);
            this._labelPairRatio.TabIndex = 33;
            this._labelPairRatio.Text = "0 %";
            this._labelPairRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelPairAmount
            // 
            this._labelPairAmount.Location = new System.Drawing.Point(579, 214);
            this._labelPairAmount.Name = "_labelPairAmount";
            this._labelPairAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelPairAmount.Size = new System.Drawing.Size(85, 15);
            this._labelPairAmount.TabIndex = 32;
            this._labelPairAmount.Text = "0";
            this._labelPairAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelPair
            // 
            this._labelPair.AutoSize = true;
            this._labelPair.Location = new System.Drawing.Point(488, 214);
            this._labelPair.Name = "_labelPair";
            this._labelPair.Size = new System.Drawing.Size(27, 15);
            this._labelPair.TabIndex = 31;
            this._labelPair.Text = "Pair";
            // 
            // _labelHighCardRatio
            // 
            this._labelHighCardRatio.Location = new System.Drawing.Point(681, 241);
            this._labelHighCardRatio.Name = "_labelHighCardRatio";
            this._labelHighCardRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelHighCardRatio.Size = new System.Drawing.Size(102, 15);
            this._labelHighCardRatio.TabIndex = 36;
            this._labelHighCardRatio.Text = "0 %";
            this._labelHighCardRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelHighCardAmount
            // 
            this._labelHighCardAmount.Location = new System.Drawing.Point(579, 241);
            this._labelHighCardAmount.Name = "_labelHighCardAmount";
            this._labelHighCardAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._labelHighCardAmount.Size = new System.Drawing.Size(85, 15);
            this._labelHighCardAmount.TabIndex = 35;
            this._labelHighCardAmount.Text = "0";
            this._labelHighCardAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelHighCard
            // 
            this._labelHighCard.AutoSize = true;
            this._labelHighCard.Location = new System.Drawing.Point(488, 241);
            this._labelHighCard.Name = "_labelHighCard";
            this._labelHighCard.Size = new System.Drawing.Size(59, 15);
            this._labelHighCard.TabIndex = 34;
            this._labelHighCard.Text = "High card";
            // 
            // _buttonRestart
            // 
            this._buttonRestart.Location = new System.Drawing.Point(16, 350);
            this._buttonRestart.Name = "_buttonRestart";
            this._buttonRestart.Size = new System.Drawing.Size(93, 23);
            this._buttonRestart.TabIndex = 1;
            this._buttonRestart.Text = "Restart";
            this._buttonRestart.UseVisualStyleBackColor = true;
            this._buttonRestart.Click += new System.EventHandler(this.OnButtonRestartClick);
            // 
            // _buttonStop
            // 
            this._buttonStop.Location = new System.Drawing.Point(115, 350);
            this._buttonStop.Name = "_buttonStop";
            this._buttonStop.Size = new System.Drawing.Size(93, 23);
            this._buttonStop.TabIndex = 2;
            this._buttonStop.Text = "Stop";
            this._buttonStop.UseVisualStyleBackColor = true;
            this._buttonStop.Click += new System.EventHandler(this.OnButtonStopClick);
            // 
            // _labelAmountOfCardsValue
            // 
            this._labelAmountOfCardsValue.Location = new System.Drawing.Point(118, 306);
            this._labelAmountOfCardsValue.Name = "_labelAmountOfCardsValue";
            this._labelAmountOfCardsValue.Size = new System.Drawing.Size(49, 23);
            this._labelAmountOfCardsValue.TabIndex = 0;
            this._labelAmountOfCardsValue.Text = "7";
            this._labelAmountOfCardsValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _labelAmountOfCards
            // 
            this._labelAmountOfCards.AutoSize = true;
            this._labelAmountOfCards.Location = new System.Drawing.Point(16, 309);
            this._labelAmountOfCards.Name = "_labelAmountOfCards";
            this._labelAmountOfCards.Size = new System.Drawing.Size(96, 15);
            this._labelAmountOfCards.TabIndex = 40;
            this._labelAmountOfCards.Text = "Amount of cards";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 408);
            this.Controls.Add(this._labelAmountOfCards);
            this.Controls.Add(this._labelAmountOfCardsValue);
            this.Controls.Add(this._buttonStop);
            this.Controls.Add(this._buttonRestart);
            this.Controls.Add(this._labelHighCardRatio);
            this.Controls.Add(this._labelHighCardAmount);
            this.Controls.Add(this._labelHighCard);
            this.Controls.Add(this._labelPairRatio);
            this.Controls.Add(this._labelPairAmount);
            this.Controls.Add(this._labelPair);
            this.Controls.Add(this._labelTwoPairRatio);
            this.Controls.Add(this._labelTwoPairAmount);
            this.Controls.Add(this._labelTwoPair);
            this.Controls.Add(this._labelThreeOfAKindRatio);
            this.Controls.Add(this._labelThreeOfAKindAmount);
            this.Controls.Add(this._labelThreeOfAKind);
            this.Controls.Add(this._labelStraightRatio);
            this.Controls.Add(this._labelStraightAmount);
            this.Controls.Add(this._labelStraight);
            this.Controls.Add(this._labelFlushRatio);
            this.Controls.Add(this._labelFlushAmount);
            this.Controls.Add(this._labelFlush);
            this.Controls.Add(this._labelTime);
            this.Controls.Add(this._labelFullHouseRatio);
            this.Controls.Add(this._labelFullHouseAmount);
            this.Controls.Add(this._labelFullHouse);
            this.Controls.Add(this._progressBar);
            this.Controls.Add(this._labelCombinations);
            this.Controls.Add(this._labelRoyalFlushRatio);
            this.Controls.Add(this._labelRoyalFlushAmount);
            this.Controls.Add(this._labelRoyalFlush);
            this.Controls.Add(this._labelCombinationsAmount);
            this.Controls.Add(this._labelFourOfAKindRatio);
            this.Controls.Add(this._labelFourOfAKindAmount);
            this.Controls.Add(this._labelFourOfAKind);
            this.Controls.Add(this._labelStraightFlushRatio);
            this.Controls.Add(this._labelTotalAmount);
            this.Controls.Add(this._labelTotal);
            this.Controls.Add(this._labelStraightFlushAmount);
            this.Controls.Add(this._labelStraightFlush);
            this.MaximumSize = new System.Drawing.Size(816, 447);
            this.MinimumSize = new System.Drawing.Size(816, 447);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Button _buttonRestart;
        private Button _buttonStop;
        private TextBox _labelAmountOfCardsValue;
        private Label _labelAmountOfCards;
    }
}