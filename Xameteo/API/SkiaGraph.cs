using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using SkiaSharp;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public class GraphIndex
    {
        /// <summary>
        /// </summary>
        public float Y;

        /// <summary>
        /// </summary>
        public bool Hide = false;

        /// <summary>
        /// </summary>
        public string ImageId = null;

        /// <summary>
        /// </summary>
        public string Label = string.Empty;
    }

    /// <summary>
    /// </summary>
    public class SkiaGraph
    {
        /// <summary>
        /// </summary>
        private readonly List<GraphIndex> _graph;

        /// <summary>
        /// </summary>
        private float _minY;

        /// <summary>
        /// </summary>
        private float _maxY;

        /// <summary>
        /// </summary>
        private float _scale;

        /// <summary>
        /// </summary>
        private float _sizeX;

        /// <summary>
        /// </summary>
        private float _sizeY;

        /// <summary>
        /// </summary>
        private float _paddingH;

        /// <summary>
        /// </summary>
        private float _paddingW;

        /// <summary>
        /// </summary>
        private float _availableH;

        /// <summary>
        /// </summary>
        private float _availableW;

        /// <summary>
        /// </summary>
        /// <param name="graph"></param>
        public SkiaGraph(List<GraphIndex> graph)
        {
            _graph = graph;
        }

        /// <summary>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void UpdateReferences(int width, int height)
        {
            const float paddingFactorY = 0.8f;
            const float paddingFactorX = 0.9f;

            _sizeX = _graph.Count;
            _maxY = _graph.Max(i => i.Y);
            _minY = _graph.Min(i => i.Y);
            _sizeY = _maxY - _minY;
            _availableH = height * paddingFactorY;
            _availableW = width * paddingFactorX;
            _paddingW = (width - _availableW) / 2;
            _paddingH = (height - _availableH) / 2;
        }

        /// <summary>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void SetScale(int width, int height)
        {
            _scale = Math.Min(height, width) / 125.0f * 0.3f;
        }

        /// <summary>
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="p"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="scale"></param>
        private static void DrawYVal(SKCanvas canvas, GraphIndex p, float x, float y, float scale)
        {
            using (var paint = new SKPaint())
            {
                if (p.Hide)
                {
                    return;
                }

                paint.Color = SKColors.White;
                paint.TextSize = 18 * scale;
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = 5 * scale;
                paint.IsAntialias = true;

                using (var paint2 = new SKPaint())
                {
                    paint2.Style = SKPaintStyle.Fill;
                    paint2.Color = CalcColor(p.Y);
                    paint2.TextSize = 18 * scale;
                    paint2.FakeBoldText = true;
                    paint2.IsAntialias = true;

                    SKRect textBounds;

                    var yLabel = XameteoApp.Instance.Temperature.Convert(p.Y);

                    paint.MeasureText(yLabel, ref textBounds);
                    canvas.DrawText(yLabel, x - textBounds.MidX, y + 2 * textBounds.Top, paint);
                    canvas.DrawText(yLabel, x - textBounds.MidX, y + 2 * textBounds.Top, paint2);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="p"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="scale"></param>
        private void DrawLabel(SKCanvas canvas, GraphIndex p, float x, float y, float scale)
        {
            using (var paint = new SKPaint())
            {
                if (p.Hide)
                {
                    return;
                }

                SKRect textBounds;

                paint.Color = new SKColor(27, 30, 35);
                paint.StrokeWidth = 1 * scale;
                paint.IsAntialias = true;
                paint.TextSize = 15 * scale;
                paint.Style = SKPaintStyle.StrokeAndFill;
                paint.MeasureText(p.Label, ref textBounds);
                canvas.DrawText(p.Label, x - textBounds.MidX, _availableH - textBounds.Top + _paddingH, paint);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="p"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="scale"></param>
        private void DrawWeatherImag(SKCanvas canvas, GraphIndex p, float x, float y, float scale)
        {
            using (var paint = new SKPaint())
            {
                if (p.Hide || p.ImageId == null)
                {
                    return;
                }

                var assembly = GetType().GetTypeInfo().Assembly;

                using (var stream = assembly.GetManifestResourceStream(p.ImageId))
                using (var skStream = new SKManagedStream(stream))
                {
                    var bitmap = SKBitmap.Decode(skStream);
                    var left = x - scale * bitmap.Width / 2;
                    var top = y - scale * bitmap.Height / 2;
                    var right = left + scale * bitmap.Width * 1.2f;
                    var bottom = top + scale * bitmap.Height * 1.2f;

                    canvas.DrawBitmap(bitmap, new SKRect(left, top, right, bottom));
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private static SKColor CalcColor(float y)
        {
            var colorVal = (int)Math.Round(1530 / (40 + 25) * y + 510);

            if (colorVal <= 0 || colorVal >= 1530)
            {
                return new SKColor(255, 0, 0);
            }

            var state = colorVal / 255;
            var inc = colorVal % 255;

            switch (state)
            {
            case 0:
                return new SKColor(255, 0, (byte)inc);
            case 1:
                return new SKColor((byte)(255 - inc), 0, 255);
            case 2:
                return new SKColor(0, (byte)inc, 255);
            case 3:
                return new SKColor(0, 255, (byte)(255 - inc));
            case 4:
                return new SKColor((byte)inc, 255, 0);
            case 5:
                return new SKColor(255, (byte)(255 - inc), 0);
            default:
                throw new Exception("WTF IS GOING ON");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="i"></param>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        private void DrawLine(SKCanvas canvas, int width, int height, int i, GraphIndex p0, GraphIndex p1)
        {
            using (var paint = new SKPaint())
            {
                paint.Color = SKColors.DarkBlue;
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = 4 * _scale;
                paint.IsAntialias = true;
                paint.StrokeCap = SKStrokeCap.Round;

                var x0 = _paddingW + _availableW * (i - 1) / (_sizeX - 1);
                var y0 = height - (_paddingH * 2f + 0.8f * _availableH * (p0.Y - _minY) / _sizeY);
                var x1 = _paddingW + _availableW * i / (_sizeX - 1);
                var y1 = height - (_paddingH * 2f + 0.8f * _availableH * (p1.Y - _minY) / _sizeY);

                var colors = new[]
                {
                    CalcColor(p0.Y),
                    CalcColor(p1.Y)
                };

                var shader = SKShader.CreateLinearGradient(new SKPoint(x0, y0), new SKPoint(x1, y1), colors, null, SKShaderTileMode.Clamp);

                paint.Shader = shader;
                canvas.DrawLine(x0, y0, x1, y1, paint);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="canvas"></param>
        private void DrawSeparators(SKCanvas canvas)
        {
            using (var paint = new SKPaint())
            {
                paint.Color = new SKColor(166, 186, 219);
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = 1 * _scale;
                paint.IsAntialias = true;

                var lastI = 0;

                for (var i = 1; i < _graph.Count; i++)
                {
                    if (_graph[i].Hide)
                    {
                        continue;
                    }

                    if (lastI == 0)
                    {
                        lastI = i;
                        continue;
                    }

                    var x0 = _paddingW + _availableW * (lastI + (i - lastI) / 2f) / (_sizeX - 1);
                    var y0 = 0.5f * _paddingH;
                    var y1 = _availableH + 1.5f * _paddingH;

                    canvas.DrawLine(x0, y0, x0, y1, paint);
                    lastI = i;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawGraph(SKCanvas canvas, int width, int height)
        {
            UpdateReferences(width, height);
            SetScale(width, height);

            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;

                var colors = new[]
                {
                    SKColors.White,
                    new SKColor(214, 244, 255)
                };

                paint.Shader = SKShader.CreateLinearGradient(
                    new SKPoint(0, 0),
                    new SKPoint(width, height),
                    colors,
                    null,
                    SKShaderTileMode.Clamp
                );

                canvas.DrawPaint(paint);
                paint.StrokeCap = SKStrokeCap.Round;
                paint.IsAntialias = true;
                paint.StrokeJoin = SKStrokeJoin.Round;
                canvas.DrawPaint(paint);
            }

            DrawSeparators(canvas);

            for (var i = 1; i < _graph.Count; i++)
            {
                DrawLine(canvas, width, height, i, _graph[i - 1], _graph[i]);
            }

            for (var i = 0; i < _graph.Count; i++)
            {
                var x = _paddingW + _availableW * i / (_sizeX - 1);
                var y = height - (_paddingH * 2f + 0.8f * _availableH * (_graph[i].Y - _minY) / _sizeY);

                DrawWeatherImag(canvas, _graph[i], x, y, _scale);
                DrawYVal(canvas, _graph[i], x, y, _scale);
                DrawLabel(canvas, _graph[i], x, y, _scale);
            }
        }
    }
}