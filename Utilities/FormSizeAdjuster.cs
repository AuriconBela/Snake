using Snake.Model;

namespace Snake.Utilities;

internal static class FormSizeAdjuster
{
    /// <summary>
    /// Adjusts the form size to ensure that all game board cells are rendered as squares, not rectangles.
    /// </summary>
    /// <param name="form">The form to adjust</param>
    /// <param name="pictureBox">The PictureBox containing the game board</param>
    public static void AdjustFormSizeForSquareCells(Form form, PictureBox pictureBox)
    {
        // Calculate the current cell dimensions
        float currentCellWidth = (float)pictureBox.Width / Constants.BoardWidth;
        float currentCellHeight = (float)pictureBox.Height / Constants.BoardHeight;
        
        // Use the smaller dimension to ensure square cells
        float cellSize = Math.Min(currentCellWidth, currentCellHeight);
        
        // Calculate the ideal PictureBox size for square cells
        int idealPictureBoxWidth = (int)(cellSize * Constants.BoardWidth);
        int idealPictureBoxHeight = (int)(cellSize * Constants.BoardHeight);
        
        // Calculate the difference between current and ideal sizes
        int widthDifference = idealPictureBoxWidth - pictureBox.Width;
        int heightDifference = idealPictureBoxHeight - pictureBox.Height;
        
        // Adjust the form size to accommodate the ideal PictureBox size
        form.Width += widthDifference;
        form.Height += heightDifference;
    }
}
