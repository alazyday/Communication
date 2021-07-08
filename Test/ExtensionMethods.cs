﻿/********************************************************************
 * * 作者： 曹一梁 周俊峰
 * * 说明：ExtensionMethods.cs
********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public static class ExtensionMethods
    {
        public static Task InvokeAsync(this Control ctrl, Action action)
        {
            return Task.Factory.FromAsync(ctrl.BeginInvoke(new Action(() =>
            {
                action?.Invoke();
            })), ctrl.EndInvoke);
        }
        public static Task InvokeAsync<T>(this Control ctrl, Action<T> action, T t)
        {
            return Task.Factory.FromAsync(ctrl.BeginInvoke(new Action<T>(c =>
            {
                action?.Invoke(c);
            }), t), ctrl.EndInvoke);
        }

        public static Task InvokeAsync<T>(this Control ctrl, Func<T> func)
        {
            return Task.Factory.FromAsync(ctrl.BeginInvoke(new Func<T>(() =>
            {
                return func.Invoke();
            })), ctrl.EndInvoke);
        }
    }
}
