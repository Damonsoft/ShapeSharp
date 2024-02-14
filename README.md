# ShapeSharp
 
A simple 2D geometry library.

### Table of Contents
 * [Rectangle](#rectangle)
 * [Circle](#circle)
 * [Line](#line)
 * [Slope](#slope)
 
## Rectangle

```cs
var rect = Rect.Create<float>(0f, 0f, 100f, 100f);
```

## Circle

```cs
var circle = Circle.Create<float>(0f, 0f, 100f);
```

Getting the point's along the edges of the circle is just as easy.

```cs
var circle = new Circle<float>(0f, 0f, 100f);
            
for(int i = 0; i < 360; i++)
{
    V2<float> point = circle.PointAt(Degrees.ToRadians(i));

    Console.WriteLine($"{i}°: ({point.X},{point.Y})");
}
```

## Line

```cs
Line<int> line = new(0, 0, 3, 3);

foreach(var point in Slope.Enumerate<int>(line.Source, line.Slope, 4))
{
    Console.WriteLine($"({point.X},{point.Y})");
}
```

## Slope

```cs
var source = new V2<int>(0, 0);
var slope = new Slope<int>(1, 1);

foreach(var v in Slope.Enumerate<int>(source, slope, 5))
{
    Console.WriteLine($"({v.X},{v.Y})");
}
```

##
