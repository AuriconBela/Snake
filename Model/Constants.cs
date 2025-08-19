namespace Snake.Model;

internal static class Constants
{
    public static int BoardWidth = 40;
    public static int BoardHeight = 40;
    public static TimeSpan RefreshRate = TimeSpan.FromSeconds(0.1);

    public static Color Background = Color.Lime;
    public static Color Snake = Color.Black;
    public static Color Grid = Color.Gray;
    public static Color Food = Color.Red;

    public static Brush BackGroundBrush = new SolidBrush(Background);
    public static Brush SnakeBrush = new SolidBrush(Snake);
    public static Brush FoodBrush = new SolidBrush(Food);
    public static Pen GridPen = new (Grid, 1);

    public static int GridLineWidth = 1;
}
