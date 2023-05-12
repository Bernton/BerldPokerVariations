using BerldPokerLibrary;
using BerldPokerLibrary.HandEvaluation;
using BerldPokerLibrary.Omaha;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace OmahaSim
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Deck deck = new Deck();

            List<Card> cards1 = new()
            {
                deck[0],
                deck[2],
                deck[4],
                deck[6]
            };

            List<Card> cards2 = new()
            {
                deck[1],
                deck[3],
                deck[5],
                deck[7]
            };

            List<Card> communityCards = new()
            {
                deck[9],
                deck[10],
                deck[11],
                deck[13],
                deck[15]
            };

            FlowLayoutPanel panel = new()
            {
                Dock = DockStyle.Fill
            };

            HandValue handValue1 = OmahaHand.Determine(cards1, communityCards);

            AddPlayer(panel, cards1, handValue1);

            HandValue handValue2 = OmahaHand.Determine(cards2, communityCards);

            AddPlayer(panel,cards2, handValue2);

            AddCommunity(panel, communityCards);
            
            Controls.Add(panel);

        }

        private static void AddCommunity(FlowLayoutPanel parent, List<Card> communityCards)
        {
            FlowLayoutPanel panel = new();
            panel.Height *= 2;

            foreach (Card holeCard in communityCards)
            {
                Label labelCard = new() { Text = holeCard.ToString() };
                panel.Controls.Add(labelCard);
            }

            parent.Controls.Add(panel);
        }

        private static void AddPlayer(FlowLayoutPanel parent, List<Card> holeCards, HandValue handValue)
        {
            FlowLayoutPanel panel = new();
            panel.Height *= 2;

            foreach (Card holeCard in holeCards)
            {
                Label labelCard = new() { Text = holeCard.ToString() };
                panel.Controls.Add(labelCard);
            }

            Label labelHandValue = new() { Text = handValue.ToString() };
            panel.Controls.Add(labelHandValue);

            parent.Controls.Add(panel);
        }
    }
}