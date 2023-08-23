using Microsoft.Xaml.Behaviors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PDFIn.Manager
{
    public class WindowManager : Behavior<Window>
    {
        #region Open window
        private static readonly Hashtable _registerWindow = new();

        public static void Regitster<T>(string key)
        {
            if (!_registerWindow.Contains(key))
            {
                _registerWindow.Add(key, typeof(T));
            }
        }

        public static void Register(string key, Type type)
        {
            if (!_registerWindow.Contains(key))
            {
                _registerWindow.Add(key, type);
            }
        }

        public static void Remove(string key)
        {
            if (_registerWindow.ContainsKey(key))
            {
                _registerWindow.Remove(key);
            }
        }

        public static void Show(string key)
        {
            if (_registerWindow.ContainsKey(key))
            {
                var windowType = _registerWindow[key] as Type;
                if (windowType != null)
                {
                    var window = Activator.CreateInstance(windowType) as Window;
                    if (window != null)
                    {
                        window.Show();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
        }
        public static void Close(string key)
        {
            if (_registerWindow.ContainsKey(key))
            {
                var windowType = _registerWindow[key] as Type;
                if (windowType != null)
                {
                    var window = Activator.CreateInstance(windowType) as Window;
                    if (window != null)
                    {
                        window.Close();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
        }
        #endregion
    }

    public static class WindowCloseBehavior
    {
        public static readonly DependencyProperty CloseWindowProperty =
            DependencyProperty.RegisterAttached(
                "CloseWindow",
                typeof(bool),
                typeof(WindowCloseBehavior),
                new PropertyMetadata(false, OnCloseWindowPropertyChanged));

        public static bool GetCloseWindow(DependencyObject obj)
        {
            return (bool)obj.GetValue(CloseWindowProperty);
        }

        public static void SetCloseWindow(DependencyObject obj, bool value)
        {
            obj.SetValue(CloseWindowProperty, value);
        }

        private static void OnCloseWindowPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                var window = d as Window;
                window?.Close();
            }
        }
    }
}
