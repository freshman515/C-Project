﻿using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyToDo.Extensins {
    //附加属性，支持PasswordBox的数据绑定
    public class PassWordExtension {



        public static string GetPassWord(DependencyObject obj) {
            return (string)obj.GetValue(PassWordProperty);
        }

        public static void SetPassWord(DependencyObject obj, string value) {
            obj.SetValue(PassWordProperty, value);
        }

        // Using a DependencyProperty as the backing store for PassWord.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PassWordProperty =
            DependencyProperty.RegisterAttached("PassWord", typeof(string), typeof(PassWordExtension), new PropertyMetadata(string.Empty, OnPassWordPropertyChanged));

        private static void OnPassWordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            var passWord = sender as PasswordBox;
            string? password = e.NewValue as string; //新的值
            if (passWord != null && passWord.Password != password) {
                passWord.Password = password; 
            }
        }
    }
    public class PasswordBehavior : Behavior<PasswordBox> {
        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
        }

        private void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e) {
            PasswordBox passwordBox = sender as PasswordBox; 
            string password = PassWordExtension.GetPassWord(passwordBox);
            if(passwordBox != null && passwordBox.Password != password) {
                PassWordExtension.SetPassWord(passwordBox, passwordBox.Password);
            }
        }

        protected override void OnDetaching() {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= AssociatedObject_PasswordChanged;

        }

    }
}
