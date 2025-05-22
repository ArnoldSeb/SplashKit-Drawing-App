using SplashKitSDK;
using System.Collections.Generic;

public class DrawingApp
{
    private List<ShapeTool> _shapes = new List<ShapeTool>();
    private Color _currentColor = Color.Black;
    private string _tool = "Circle";

    public void Run()
    {
        SplashKit.OpenWindow("Drawing App", 800, 600);

        while (!SplashKit.WindowCloseRequested("Drawing App"))
        {
            SplashKit.ProcessEvents();
            HandleInput();
            Draw();
            SplashKit.RefreshScreen(60);
        }
    }

    private void HandleInput()
    {
        if (SplashKit.MouseClicked(MouseButton.LeftButton))
        {
            Point2D position = SplashKit.MousePosition();

            if (_tool == "Circle")
                _shapes.Add(new CircleTool(position.X, position.Y, 30, _currentColor));
            else if (_tool == "Rectangle")
                _shapes.Add(new RectangleTool(position.X, position.Y, 60, 40, _currentColor));
        }

        if (SplashKit.KeyTyped(KeyCode.CKey))
            _tool = "Circle";
        if (SplashKit.KeyTyped(KeyCode.RKey))
            _tool = "Rectangle";
        if (SplashKit.KeyTyped(KeyCode.Alpha1Key))
            _currentColor = Color.Red;
        if (SplashKit.KeyTyped(KeyCode.Alpha2Key))
            _currentColor = Color.Green;
        if (SplashKit.KeyTyped(KeyCode.Alpha3Key))
            _currentColor = Color.Blue;
        if (SplashKit.KeyTyped(KeyCode.Alpha4Key))
            _currentColor = Color.Black;
        if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            _shapes.Clear();
    }

    private void Draw()
    {
        SplashKit.ClearScreen(Color.White);

        foreach (var shape in _shapes)
            shape.Draw();

        SplashKit.DrawText($"Tool: {_tool} | Color: {_currentColor}", Color.Black, "Arial", 14, 10, 10);
        SplashKit.DrawText("C: Circle | R: Rectangle | 1-4: Colors | SPACE: Clear", Color.Gray, "Arial", 12, 10, 30);
    }
}