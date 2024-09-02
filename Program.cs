using System;

public enum ShapeType
{
    Circle,
    Rectangle
}

class Program
{
    const int MAX_SHAPES = 100;

    static int[] shapeIds = new int[MAX_SHAPES];
    static ShapeType[] shapeTypes = new ShapeType[MAX_SHAPES];
    static float[] diameters = new float[MAX_SHAPES];
    static float[] heights = new float[MAX_SHAPES];
    static float[] widths = new float[MAX_SHAPES];

    static int numShapes = 0;
    static float totalArea = 0.0f;
    static float totalAreaRectangles = 0.0f;
    static float totalAreaCircles = 0.0f;
    static int numRectangles = 0;
    static int numCircles = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("1. Add a circle");
        Console.WriteLine("2. Add a rectangle");
        Console.WriteLine("3. List items");
        Console.WriteLine("4. Get statistics");
        Console.WriteLine("5. Exit");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        while (choice != 5)
        {
            switch (choice)
            {
                case 1:
                    AddCircle();
                    break;
                case 2:
                    AddRectangle();
                    break;
                case 3:
                    ListItems();
                    break;
                case 4:
                    GetStatistics();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("1. Add a circle");
            Console.WriteLine("2. Add a rectangle");
            Console.WriteLine("3. List items");
            Console.WriteLine("4. Get statistics");
            Console.WriteLine("5. Exit");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                return;
            }
        }
    }

    static void AddCircle()
    {
        Console.Write("What is the diameter of the circle: ");
        float diameter;
        if (!float.TryParse(Console.ReadLine(), out diameter))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        shapeIds[numShapes] = numShapes + 1;
        shapeTypes[numShapes] = ShapeType.Circle;
        diameters[numShapes] = diameter;

        float area = 3.14159f * diameter * diameter / 4;
        totalArea += area;
        totalAreaCircles += area;
        numCircles++;
        numShapes++;
    }

    static void AddRectangle()
    {
        Console.Write("What is the height of the rectangle: ");
        float height;
        if (!float.TryParse(Console.ReadLine(), out height))
        {
            Console.WriteLine("Invalid input.");
            return;
        }//Check if the user input a valid integer

        Console.Write("What is the width of the rectangle: ");
        float width;
        if (!float.TryParse(Console.ReadLine(), out width))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        shapeIds[numShapes] = numShapes + 1;
        shapeTypes[numShapes] = ShapeType.Rectangle;
        heights[numShapes] = height;
        widths[numShapes] = width;

        float area = height * width;
        totalArea += area;
        totalAreaRectangles += area;
        numRectangles++;
        numShapes++;
    }

    static void ListItems()
    {
        Console.WriteLine("Id\tType\t\tDimensions");
        Console.WriteLine("===================================");
        for (int i = 0; i < numShapes; i++)
        {
            Console.Write(shapeIds[i] + "\t");

            if (shapeTypes[i] == ShapeType.Circle)
            {
                Console.WriteLine("Circle\t\t" + diameters[i].ToString("F2"));
            }
            else if (shapeTypes[i] == ShapeType.Rectangle)
            {
                Console.WriteLine("Rectangle\t" + heights[i].ToString("F2") + " x " + widths[i].ToString("F2"));
            }
        }
    }

    static void GetStatistics()
    {
        Console.WriteLine("Total shapes: " + numShapes);
        Console.WriteLine("Total number of rectangles: " + numRectangles);
        Console.WriteLine("Total number of circles: " + numCircles);
        Console.WriteLine("Total area: " + totalArea.ToString("F2"));

        Console.WriteLine("The total area occupied by rectangles: " + totalAreaRectangles.ToString("F2") +
                          " (" + (totalAreaRectangles / totalArea * 100).ToString("F2") + "%)");

        Console.WriteLine("The total area occupied by circles: " + totalAreaCircles.ToString("F2") +
                          " (" + (totalAreaCircles / totalArea * 100).ToString("F2") + "%)");
    }
} 