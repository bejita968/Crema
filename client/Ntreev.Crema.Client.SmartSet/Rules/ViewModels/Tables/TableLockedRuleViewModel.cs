﻿//Released under the MIT License.
//
//Copyright (c) 2018 Ntreev Soft co., Ltd.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//documentation files (the "Software"), to deal in the Software without restriction, including without limitation the 
//rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit 
//persons to whom the Software is furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the 
//Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
//OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Ntreev.Crema.ServiceModel;
using Ntreev.Crema.Services;
using System.ComponentModel.Composition;
using Ntreev.Crema.Client.Framework;
using Ntreev.Crema.Client.SmartSet.Properties;

namespace Ntreev.Crema.Client.SmartSet.Rules.ViewModels.Tables
{
    [Export(typeof(IRule))]
    class TableLockedRuleViewModel : OperatorRule<bool>
    {
        public TableLockedRuleViewModel()
        {
            this.DisplayName = Resources.Title_TableIsLocked;
        }

        protected override bool GetObjectValue(object obj)
        {
            if (obj is ILockableDescriptor descriptor)
                return descriptor.LockInfo.IsLocked;
            return false;
        }

        public override Type SupportType
        {
            get { return typeof(ITableDescriptor); }
        }
    }
}
