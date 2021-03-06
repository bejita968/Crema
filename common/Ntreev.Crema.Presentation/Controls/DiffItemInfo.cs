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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.DataGrid;

namespace Ntreev.Crema.Presentation.Controls
{
    struct DiffItemInfo
    {
        public DiffItemInfo(DataGridContext gridContext, object item)
        {
            this.GridContext = gridContext;
            this.Item = item;
        }

        public DataGridContext GridContext { get; set; }

        public object Item { get; set; }

        public static IEnumerable<DiffItemInfo> GetVisibleItems(DataGridContext gridContext)
        {
            foreach (var item in gridContext.Headers)
            {
                yield return new DiffItemInfo(gridContext, item);
            }

            foreach (var item in gridContext.Items)
            {
                yield return new DiffItemInfo(gridContext, item);

                foreach (var detail in gridContext.DetailConfigurations)
                {
                    var childContext = gridContext.GetChildContext(item, detail);
                    if (childContext != null)
                    {
                        foreach (var i in GetVisibleItems(childContext))
                        {
                            yield return i;
                        }
                    }
                }
            }

            foreach (var item in gridContext.Footers)
            {
                yield return new DiffItemInfo(gridContext, item);
            }
        }

        public static IEnumerable<DiffItemInfo> GetItems(DataGridContext gridContext)
        {
            for (var i = 0; i < gridContext.Items.Count; i++)
            {
                var item = gridContext.Items.GetItemAt(i);
                yield return new DiffItemInfo(gridContext, item);

                for (var j = 0; j < gridContext.DetailConfigurations.Count; j++)
                {
                    var detail = gridContext.DetailConfigurations[j];
                    var childContext = gridContext.GetChildContext(item, detail);
                    if (childContext != null)
                    {
                        foreach (var childItem in GetItems(childContext))
                        {
                            yield return childItem;
                        }
                    }
                }
            }
        }

        public static  IEnumerable<DiffItemInfo> GetReverseItems(DataGridContext gridContext)
        {
            for (var i = gridContext.Items.Count - 1; i >= 0; i--)
            {
                var item = gridContext.Items.GetItemAt(i);

                for (var j = gridContext.DetailConfigurations.Count - 1; j >= 0; j--)
                {
                    var detail = gridContext.DetailConfigurations[j];
                    var childContext = gridContext.GetChildContext(item, detail);
                    if (childContext != null)
                    {
                        foreach (var childItem in GetReverseItems(childContext))
                        {
                            yield return childItem;
                        }
                    }
                }

                yield return new DiffItemInfo(gridContext, item);
            }
        }
    }
}
