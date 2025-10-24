using System;
using System.Collections.Generic;

[Serializable]
public class HeatMapData
{
    public List<HeatPoint> points = new List<HeatPoint>();

}
[Serializable]

public class HeatPoint
{
    public float x, y;

    public int visits = 1;

    public HeatPoint(float x, float y) => (this.x, this.y) = (x, y);
}
