﻿using MonsterCompanySimModel.Models;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCompanySim.ViewModels.Controls
{
    class TargetSelectorViewModel : BindableBase
    {
        public ReactivePropertySlim<Employee> Employee { get; set; } = new();

        public ReactivePropertySlim<bool> IsTarget { get; set; } = new();

        public TargetSelectorViewModel(Employee emp)
        {
            Employee.Value = emp;
            IsTarget.Value = Masters.IsTarget(emp);

            IsTarget.Subscribe(isTarget => ChangeTarget(isTarget));
        }

        private void ChangeTarget(bool isTarget)
        {
            if (isTarget)
            {
                Masters.AddTarget(Employee.Value);
            }
            else
            {
                Masters.DeleteTarget(Employee.Value);
            }
        }
    }
}
