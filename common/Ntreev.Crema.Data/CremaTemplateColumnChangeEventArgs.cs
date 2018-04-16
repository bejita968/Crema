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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Ntreev.Crema.Data
{
    public class CremaTemplateColumnChangeEventArgs : EventArgs
    {
        private readonly CremaTemplateColumn item;
        private readonly DataRowAction action;
        private readonly string propertyName;
        private readonly object proposedValue;

        internal CremaTemplateColumnChangeEventArgs(DataRowChangeEventArgs e)
        {
            this.item = (e.Row as InternalTemplateColumn).Target;
            this.action = e.Action;
        }

        internal CremaTemplateColumnChangeEventArgs(DataColumnChangeEventArgs e)
        {
            this.item = (e.Row as InternalTemplateColumn).Target;
            this.action = DataRowAction.Nothing; 
            this.propertyName = e.Column.ColumnName;
            this.proposedValue = e.ProposedValue;
        }

        [Obsolete]
        public CremaTemplateColumn Column
        {
            get { return this.item; }
        }

        public CremaTemplateColumn Item
        {
            get { return this.item; }
        }

        public DataRowAction Action
        {
            get { return this.action; }
        }

        public string PropertyName
        {
            get { return this.propertyName ?? string.Empty; }
        }

        public object ProposedValue
        {
            get { return this.proposedValue; }
        }
    }
}