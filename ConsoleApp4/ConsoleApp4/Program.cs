using System;
using System.Collections.Generic;

// Абстрактний клас GraphicPrimitive
public abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Draw();
    public abstract void Move(int x, int y);
    public abstract void Scale(float factor);
}

// Клас кола
public class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Circle at ({X}, {Y}) with Radius {Radius}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}

// Клас прямокутника
public class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Rectangle at ({X}, {Y}) with Width {Width} and Height {Height}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

// Клас трикутника
public class Triangle : GraphicPrimitive
{
    public override void Draw()
    {
        Console.WriteLine($"Drawing Triangle at ({X}, {Y})");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        // Логіка масштабування трикутника
    }
}

// Клас групи
public class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> elements = new List<GraphicPrimitive>();

    public void AddElement(GraphicPrimitive element)
    {
        elements.Add(element);
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Group at ({X}, {Y})");
        foreach (var element in elements)
        {
            element.Draw();
        }
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
        foreach (var element in elements)
        {
            element.Move(x, y);
        }
    }

    public override void Scale(float factor)
    {
        foreach (var element in elements)
        {
            element.Scale(factor);
        }
    }
}

// Клас редактора графіки
public class GraphicsEditor
{
    private List<GraphicPrimitive> graphics = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        graphics.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var graphic in graphics)
        {
            graphic.Draw();
        }
    }

    public void MoveAll(int x, int y)
    {
        foreach (var graphic in graphics)
        {
            graphic.Move(x, y);
        }
    }

    public void ScaleAll(float factor)
    {
        foreach (var graphic in graphics)
        {
            graphic.Scale(factor);
        }
    }
}

class Program
{
    static void Main()
    {
        GraphicsEditor editor = new GraphicsEditor();

        Circle circle = new Circle { X = 10, Y = 20, Radius = 5 };
        Rectangle rectangle = new Rectangle { X = 30, Y = 40, Width = 8, Height = 12 };
        Triangle triangle = new Triangle { X = 50, Y = 60 };

        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);

        editor.DrawAll();

        editor.MoveAll(5, 5);
        editor.DrawAll();

        editor.ScaleAll(1.5f);
        editor.DrawAll();

        // Група
        Group group = new Group { X = 100, Y = 100 };
        group.AddElement(new Circle { Radius = 3 });
        group.AddElement(new Rectangle { Width = 6, Height = 9 });
        group.AddElement(new Triangle());

        editor.AddPrimitive(group);
        editor.DrawAll();
    }
}
