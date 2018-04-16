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

using Ntreev.Crema.Client.Base.Properties;
using Ntreev.Crema.ServiceModel;
using Ntreev.Crema.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using Ntreev.ModernUI.Framework.Dialogs.ViewModels;
using Ntreev.Library.ObjectModel;
using Ntreev.Crema.Client.Framework;

namespace Ntreev.Crema.Client.Base.Dialogs.ViewModels
{
    public class RenameDataBaseViewModel : RenameAsyncViewModel
    {
        private readonly Authentication authentication;
        private readonly IDataBase dataBase;

        private RenameDataBaseViewModel(Authentication authentication, IDataBase dataBase)
            : base(dataBase.Name)
        {
            this.authentication = authentication;
            this.authentication.Expired += Authentication_Expired;
            this.dataBase = dataBase;
            this.dataBase.Dispatcher.VerifyAccess();
            this.DisplayName = "이름 변경";
        }

        public static Task<RenameDataBaseViewModel> CreateInstanceAsync(Authentication authentication, IDataBaseDescriptor descriptor)
        {
            if (authentication == null)
                throw new ArgumentNullException(nameof(authentication));
            if (descriptor == null)
                throw new ArgumentNullException(nameof(descriptor));

            if (descriptor.Target is IDataBase dataBase)
            {
                return dataBase.Dispatcher.InvokeAsync(() =>
                {
                    return new RenameDataBaseViewModel(authentication, dataBase);
                });
            }
            else
            {
                throw new ArgumentException("Invalid Target of Descriptor", nameof(descriptor));
            }
        }

        protected async override void VerifyRename(string newName, Action<bool> isVerify)
        {
            var result = await this.dataBase.Dispatcher.InvokeAsync(() =>
            {
                var dataBases = this.dataBase.GetService(typeof(IDataBaseCollection)) as IDataBaseCollection;

                return dataBases.Contains(newName) == false;
            });

            isVerify(result);
        }

        protected override Task RenameAsync(string newName)
        {
            return this.dataBase.Dispatcher.InvokeAsync(() => this.dataBase.Rename(this.authentication, newName));
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);

            if (close == true)
            {
                this.authentication.Expired -= Authentication_Expired;
            }
        }

        private void Authentication_Expired(object sender, EventArgs e)
        {
            this.Dispatcher.InvokeAsync(() => this.TryClose());
        }
    }
}
