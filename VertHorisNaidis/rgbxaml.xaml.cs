using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using System;

namespace VertHorisNaidis
{
    public partial class rgbxaml : ContentPage
    {
        Slider redSlider, greenSlider, blueSlider;
        Label redLabel, greenLabel, blueLabel;

        BoxView boxView;
        BoxView redBox, greenBox, blueBox;

        Stepper sizeStepper;
        Random rnd = new Random();

        public rgbxaml()
        {
            AbsoluteLayout layout = new AbsoluteLayout();

            Label title = new Label
            {
                Text = "RGB mudel",
                FontSize = 26,
                TextColor = Colors.HotPink
            };
            AbsoluteLayout.SetLayoutBounds(title, new Rect(0.5, 0.05, -1, -1));
            AbsoluteLayout.SetLayoutFlags(title, AbsoluteLayoutFlags.PositionProportional);

            redBox = CreateColorBox(Colors.DarkRed, 0.25);
            greenBox = CreateColorBox(Colors.DarkGreen, 0.5);
            blueBox = CreateColorBox(Colors.DarkBlue, 0.75);

            redSlider = CreateSlider(0.20);
            redLabel = CreateLabel("Red = 0", 0.25);

            greenSlider = CreateSlider(0.30);
            greenLabel = CreateLabel("Green = 0", 0.35);

            blueSlider = CreateSlider(0.40);
            blueLabel = CreateLabel("Blue = 0", 0.45);

            boxView = new BoxView
            {
                Color = Colors.Black
            };
            AbsoluteLayout.SetLayoutBounds(boxView, new Rect(0.5, 0.65, 180, 180));
            AbsoluteLayout.SetLayoutFlags(boxView, AbsoluteLayoutFlags.PositionProportional);

            sizeStepper = new Stepper
            {
                Minimum = 150,
                Maximum = 300,
                Increment = 10,
                Value = 250
            };
            sizeStepper.ValueChanged += OnStepperChanged;
            AbsoluteLayout.SetLayoutBounds(sizeStepper, new Rect(0.5, 0.82, -1, -1));
            AbsoluteLayout.SetLayoutFlags(sizeStepper, AbsoluteLayoutFlags.PositionProportional);

            Button randomBtn = new Button
            {
                Text = "Random color"
            };
            randomBtn.Clicked += OnRandomClicked;
            AbsoluteLayout.SetLayoutBounds(randomBtn, new Rect(0.5, 0.92, 200, 50));
            AbsoluteLayout.SetLayoutFlags(randomBtn, AbsoluteLayoutFlags.PositionProportional);

            layout.Children.Add(title);

            layout.Children.Add(redBox);
            layout.Children.Add(greenBox);
            layout.Children.Add(blueBox);

            layout.Children.Add(redSlider);
            layout.Children.Add(redLabel);

            layout.Children.Add(greenSlider);
            layout.Children.Add(greenLabel);

            layout.Children.Add(blueSlider);
            layout.Children.Add(blueLabel);

            layout.Children.Add(boxView);
            layout.Children.Add(sizeStepper);
            layout.Children.Add(randomBtn);

            Content = layout;
        }

        BoxView CreateColorBox(Color color, double x)
        {
            BoxView box = new BoxView
            {
                Color = color,
                WidthRequest = 60,
                HeightRequest = 60,
                CornerRadius = 15
            };

            AbsoluteLayout.SetLayoutBounds(box, new Rect(x, 0.12, 65, 60));
            AbsoluteLayout.SetLayoutFlags(box, AbsoluteLayoutFlags.PositionProportional);

            return box;
        }

        Slider CreateSlider(double y)
        {
            Slider s = new Slider
            {
                Minimum = 0,
                Maximum = 255
            };

            s.ValueChanged += OnSliderValueChanged;

            AbsoluteLayout.SetLayoutBounds(s, new Rect(0.5, y, 300, 40));
            AbsoluteLayout.SetLayoutFlags(s, AbsoluteLayoutFlags.PositionProportional);

            return s;
        }

        Label CreateLabel(string text, double y)
        {
            Label l = new Label { Text = text };

            AbsoluteLayout.SetLayoutBounds(l, new Rect(0.5, y, -1, -1));
            AbsoluteLayout.SetLayoutFlags(l, AbsoluteLayoutFlags.PositionProportional);

            return l;
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            int r = (int)redSlider.Value;
            int g = (int)greenSlider.Value;
            int b = (int)blueSlider.Value;

            redLabel.Text = $"Red = {r}";
            greenLabel.Text = $"Green = {g}";
            blueLabel.Text = $"Blue = {b}";

            boxView.Color = Color.FromRgb(r, g, b);

            redBox.Color = Color.FromRgb(r, 0, 0);
            greenBox.Color = Color.FromRgb(0, g, 0);
            blueBox.Color = Color.FromRgb(0, 0, b);
        }


        void OnStepperChanged(object sender, ValueChangedEventArgs e)
        {
            double size = e.NewValue;

            AbsoluteLayout.SetLayoutBounds(boxView,
                new Rect(0.5, 0.60, size, size));
        }

        void OnRandomClicked(object sender, EventArgs e)
        {
            redSlider.Value = rnd.Next(0, 256);
            greenSlider.Value = rnd.Next(0, 256);
            blueSlider.Value = rnd.Next(0, 256);
        }
    }
}