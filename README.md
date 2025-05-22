
# 🖌️ SplashKit Drawing App: A Detailed Tutorial in C#

**By Arnold Sebastian**

---

## 📘 Introduction

Welcome to the SplashKit Drawing App tutorial. This guide is designed to walk you through every aspect of building a simple paint-like application using the SplashKit SDK in the C# programming language.

This tutorial is suitable for beginners who want to learn how to create graphical applications, as well as advanced students aiming to understand how object-oriented design and real-time event handling can be used in practical scenarios.

We will build the entire app from scratch, explaining each class, method, and principle. By the end, you’ll have a working drawing tool and a strong understanding of OOP concepts, input handling, modular design, and user interactivity.

---

## 🧠 What You'll Learn

- Setting up SplashKit with MSYS2 on Windows.
- Understanding object-oriented programming (OOP): abstraction, encapsulation, inheritance, and polymorphism.
- Real-time event-driven programming using SplashKit.
- Creating a graphical application with mouse and keyboard input.
- Structuring code into reusable, testable modules.
- Building a fully interactive drawing tool.

---

## 🛠️ Required Tools

- Windows 10/11 PC.
- MSYS2 development environment (free).
- .NET Core and SplashKit SDK (open-source).
- A code editor like Visual Studio Code or JetBrains Rider.

Installation will be covered step-by-step in the next section.

---

## 🧰 Installing SplashKit and MSYS2

1. Download and install [MSYS2](https://www.msys2.org/)
2. Open the "MSYS2 MSYS" terminal and run:
   ```bash
   pacman -Syu
   ```
3. Restart the terminal, then run:
   ```bash
   pacman -Su
   ```
4. Install SplashKit for .NET:
   ```bash
   pacman -S splashkit-dotnet
   ```

You now have SplashKit and .NET tools ready for use. You can verify installation by typing `skm --version`.

---

## 📂 Project Structure

```
/SplashKit_DrawingApp/
├── Program.cs
├── DrawingApp.cs
├── Tool.cs
├── Resources/fonts/
└── README.md
```

Each file serves a single responsibility, following clean code architecture.

---

## 🧱 Step-by-Step Code Explanation

### 1. Program.cs

```csharp
public class Program
{
    public static void Main()
    {
        DrawingApp app = new DrawingApp();
        app.Run();
    }
}
```

---

### 2. DrawingApp.cs

```csharp
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
            Point2D pos = SplashKit.MousePosition();
            if (_tool == "Circle") _shapes.Add(new CircleTool(pos.X, pos.Y, 30, _currentColor));
            else if (_tool == "Rectangle") _shapes.Add(new RectangleTool(pos.X, pos.Y, 60, 40, _currentColor));
        }

        if (SplashKit.KeyTyped(KeyCode.CKey)) _tool = "Circle";
        if (SplashKit.KeyTyped(KeyCode.RKey)) _tool = "Rectangle";
        if (SplashKit.KeyTyped(KeyCode.Alpha1Key)) _currentColor = Color.Red;
        if (SplashKit.KeyTyped(KeyCode.Alpha2Key)) _currentColor = Color.Green;
        if (SplashKit.KeyTyped(KeyCode.Alpha3Key)) _currentColor = Color.Blue;
        if (SplashKit.KeyTyped(KeyCode.Alpha4Key)) _currentColor = Color.Black;
        if (SplashKit.KeyTyped(KeyCode.SpaceKey)) _shapes.Clear();
    }

    private void Draw()
    {
        SplashKit.ClearScreen(Color.White);
        foreach (var shape in _shapes) shape.Draw();
        SplashKit.DrawText($"Tool: {_tool} | Color: {_currentColor}", Color.Black, "Arial", 14, 10, 10);
    }
}
```

---

### 3. Tool.cs

```csharp
public abstract class ShapeTool
{
    protected double _x, _y;
    protected Color _color;

    public ShapeTool(double x, double y, Color color)
    {
        _x = x;
        _y = y;
        _color = color;
    }

    public abstract void Draw();
}

public class CircleTool : ShapeTool
{
    private double _radius;

    public CircleTool(double x, double y, double radius, Color color) : base(x, y, color)
    {
        _radius = radius;
    }

    public override void Draw()
    {
        SplashKit.FillCircle(_color, _x, _y, _radius);
    }
}

public class RectangleTool : ShapeTool
{
    private double _width, _height;

    public RectangleTool(double x, double y, double width, double height, Color color) : base(x, y, color)
    {
        _width = width;
        _height = height;
    }

    public override void Draw()
    {
        SplashKit.FillRectangle(_color, _x, _y, _width, _height);
    }
}
```

---

## 🧪 Testing and Validation

- Each shape draws correctly at the mouse cursor.
- All input keys work as expected to toggle tools and colors.
- Screen clears on pressing SPACE.
- No runtime crashes during stress testing or rapid input.

---

## 🏁 Conclusion

This SplashKit Drawing App illustrates how object-oriented programming can be applied in practical UI applications. It uses C# features and SplashKit’s multimedia capabilities to deliver a rich, interactive experience.

Ideal for students and developers, this app serves as both a learning resource and a launchpad for building more advanced drawing tools.


---

## 🚀 How to Run This Code Using MSYS2

To run the SplashKit Drawing App using the MSYS2 environment on Windows:

### 🧩 Prerequisites
- Ensure you've installed SplashKit and MSYS2 as outlined earlier.
- Place your project folder in an accessible path (e.g., `C:/Users/YourName/SplashKit_DrawingApp`).

### 📦 Step-by-Step Execution

1. **Open MSYS2 Terminal**  
   Launch the "MSYS2 MSYS" terminal from your Start Menu.

2. **Navigate to the Project Directory**  
   Example:
   ```bash
   cd /c/Users/YourName/SplashKit_DrawingApp
   ```

3. **Run the Application**  
   Use the SplashKit manager to compile and run the application:
   ```bash
   skm dotnet run
   ```

> This command builds and executes the project. You’ll see a new window open, allowing you to draw with the mouse and keyboard controls.

### 🛠 Common Issues

- **Missing Font Error:** Ensure that a `.ttf` font (like Arial) exists in the correct path if custom fonts are referenced.
- **Path Error:** Use forward slashes `/` in MSYS2 paths. Use `pwd` to verify your working directory.
- **Permission Issues:** Make sure your folder isn’t write-protected or located in a system directory.

---

Now you're ready to use and demonstrate the SplashKit Drawing App in a fully set-up development environment!
