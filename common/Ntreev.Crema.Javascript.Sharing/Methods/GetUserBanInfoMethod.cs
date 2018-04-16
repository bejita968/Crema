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

using Ntreev.Crema.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using Ntreev.Crema.Data.Xml.Schema;

namespace Ntreev.Crema.Javascript.Methods
{
    [Export(typeof(IScriptMethod))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class GetUserBanInfoMethod : ScriptMethodBase
    {
        [Import]
        private Lazy<ICremaHost> cremaHost = null;

        protected override Delegate CreateDelegate()
        {
            return new Func<string, IDictionary<string, object>>(GetUserBanInfo);
        }

        private IDictionary<string, object> GetUserBanInfo(string userID)
        {
            var userContext = this.CremaHost.GetService(typeof(IUserContext)) as IUserContext;
            return userContext.Dispatcher.Invoke(() =>
            {
                var user = userContext.Users[userID];
                var banInfo = user.BanInfo;
                var props = new Dictionary<string, object>
                {
                    { nameof(banInfo.UserID), banInfo.UserID },
                    { nameof(banInfo.Path), banInfo.Path },
                    { nameof(banInfo.Comment), banInfo.Comment },
                    { nameof(DateTime), banInfo.DateTime }
                };
                return props;
            });
        }

        private ICremaHost CremaHost => this.cremaHost.Value;
    }
}
