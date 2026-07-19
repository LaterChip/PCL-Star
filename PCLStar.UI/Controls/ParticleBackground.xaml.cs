using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace PCLStar.UI.Controls
{
    public partial class ParticleBackground : UserControl
    {
        private readonly List<Particle> _particles = new List<Particle>();
        private readonly Random _rand = new Random();
        private DispatcherTimer _timer;

        public ParticleBackground()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            CreateParticles(60);
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(30) };
            _timer.Tick += (s, args) => UpdateParticles();
            _timer.Start();
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _timer?.Stop();
        }

        private void CreateParticles(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var ellipse = new System.Windows.Shapes.Ellipse
                {
                    Width = _rand.Next(2, 5),
                    Height = _rand.Next(2, 5),
                    Fill = new SolidColorBrush(Color.FromArgb((byte)_rand.Next(100, 200), 255, 255, 255))
                };
                var x = _rand.Next(0, (int)ActualWidth);
                var y = _rand.Next(0, (int)ActualHeight);
                Canvas.SetLeft(ellipse, x);
                Canvas.SetTop(ellipse, y);
                ParticleCanvas.Children.Add(ellipse);

                _particles.Add(new Particle
                {
                    Element = ellipse,
                    X = x,
                    Y = y,
                    Vx = (float)(_rand.NextDouble() - 0.5) * 1.5f,
                    Vy = (float)(_rand.NextDouble() - 0.5) * 1.5f
                });
            }
        }

        private void UpdateParticles()
        {
            var width = ActualWidth;
            var height = ActualHeight;
            foreach (var p in _particles)
            {
                p.X += p.Vx;
                p.Y += p.Vy;

                if (p.X < 0 || p.X > width) p.Vx *= -1;
                if (p.Y < 0 || p.Y > height) p.Vy *= -1;

                Canvas.SetLeft(p.Element, p.X);
                Canvas.SetTop(p.Element, p.Y);
            }
        }

        private class Particle
        {
            public FrameworkElement Element { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public float Vx { get; set; }
            public float Vy { get; set; }
        }
    }
}
