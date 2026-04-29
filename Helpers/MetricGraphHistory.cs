namespace Kil0bitSystemMonitor.Helpers;

public sealed class MetricGraphHistory
{
    private readonly Queue<float> _values = new();

    public MetricGraphHistory(int capacity)
    {
        Capacity = Math.Max(2, capacity);
    }

    public int Capacity { get; private set; }

    public void SetCapacity(int capacity)
    {
        Capacity = Math.Max(2, capacity);
        while (_values.Count > Capacity)
        {
            _values.Dequeue();
        }
    }

    public void Add(float value)
    {
        _values.Enqueue(value);
        while (_values.Count > Capacity)
        {
            _values.Dequeue();
        }
    }

    public float[] GetValues()
    {
        return _values.ToArray();
    }
}

public static class MetricGraphNormalizer
{
    public static float NormalizePercent(float value)
    {
        return Math.Clamp(value, 0f, 100f);
    }

    public static float[] NormalizeSeries(float[] values, float dynamicRangeFloor = 100f)
    {
        if (values.Length == 0)
        {
            return values;
        }

        float max = values.Max();
        float min = values.Min();
        float range = Math.Max(dynamicRangeFloor, max - min);

        return values
            .Select(v => Math.Clamp((v - min) / range * 100f, 0f, 100f))
            .ToArray();
    }
}
