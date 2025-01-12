using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

namespace firstAvaloniaApp;

public partial class MainWindow : Window
{

    private float num1 = -1;
    private float num2 = -1;
    private int operatorSelected = -1;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnNumberClick(object sender, RoutedEventArgs e)
    {
        var but = sender as Button;
        string inp = but.Content.ToString();
        int input = int.Parse(inp);

        if (operatorSelected == -1)
        {
            if (num1 == -1)
            {
                num1 = input;
                Input.Content = num1;
            }
            else 
            {
                num1 = num1 * 10 + input;
                Input.Content = num1;
            }
        }

        if (operatorSelected != -1)
        {
            if (num2 == -1)
            {
                num2 = input;
                Input.Content = num2;
            }
            else
            {
                num2 = num2 * 10 + input;
                Input.Content = num2;
            }
        }
    }

    private void OnOperatorClick(object sender, RoutedEventArgs e)
    {
        var but = sender as Button;
        int operatorinput;
        switch (but.Content.ToString())
        {
            case "+":
                operatorinput = 1;
                operatorSelected = operatorinput;
                break;
            case "-":
                operatorinput = 2;
                operatorSelected = operatorinput;
                break;
            case "x":
                operatorinput = 3;
                operatorSelected = operatorinput;
                break;
            case "\u00f7":
                operatorinput = 4;
                operatorSelected = operatorinput;
                break;
        }

        if (operatorSelected != -1 && (Input.Content.ToString() == num1.ToString()))
        {
            Input.Content = "";
        }
    }

    private void OnEqualsClick(object sender, RoutedEventArgs e)
    {
        if (operatorSelected == 1)
        {
            float output = num1 + num2;
            Output.Content = output;
        }
        if (operatorSelected == 2)
        {
            float output = num1 - num2;
            Output.Content = output;
        }
        if (operatorSelected == 3)
        {
            float output = num1 * num2;
            Output.Content = output;
        }
        if (operatorSelected == 4)
        {
            float output = num1 / num2;
            Output.Content = output;
        }
    }

    private void OnClearClick(object sender, RoutedEventArgs e)
    {
        num1 = -1;
        num2 = -1;
        operatorSelected = -1;
        Input.Content = "";
        Output.Content = "";
    }
}