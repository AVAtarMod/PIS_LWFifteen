using System.Windows.Forms;

namespace _3LW
{
    public partial class Fifteen : Form
    {
        private readonly Button[] buttonsArray;
        Game game;
        private Button GetButton(int index)
        {
            return buttonsArray[index];
        }
        public Fifteen()
        {
            InitializeComponent();
            buttonsArray = new Button[] { button0, button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15 };
            game = new Game();
        }
    }
}
