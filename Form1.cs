using Snake.Model;
using Snake.Representation;
using Snake.Utilities;

namespace Snake;

public partial class Form1 : Form
{
    private Game _game = new();
    private GameDrawer gameDrawer;
    public Form1()
    {
        InitializeComponent();
        gameDrawer = new(pbBoard, _game);
        timer.Interval = (int)Constants.RefreshRate.TotalMilliseconds;
        timer.Start();
        
        // Hook up the Shown event to adjust form size for square cells
        Shown += Form1_Shown;
    }

    private void Form1_Shown(object? sender, EventArgs e)
    {
        FormSizeAdjuster.AdjustFormSizeForSquareCells(this, pbBoard);
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F5)
        {
            _game = new Game();
            gameDrawer = new(pbBoard, _game);
            timer.Start();
        }
        _game.PropagateKeyBoardEvent(e.KeyCode);
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        switch (_game.NextFrame())
        {
            case StepResult.Success:
                pbBoard.Invalidate();
                break;
            case StepResult.Failure:
                timer.Stop();
                MessageBox.Show("You lost, press F5 to start again!");
                break;
            case StepResult.Win:
                timer.Stop();
                MessageBox.Show("You won, press F5 to start again!");
                break;
            default:
                throw new NotImplementedException();
        };
    }
}
