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

using Ntreev.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;

namespace Ntreev.Crema.Data.Xml.Schema
{
    public class CremaSchemaReadInfo
    {
        private readonly string xsdPath = null;
        private string[] typePaths;
        private string[] relativeTypePaths;

        public CremaSchemaReadInfo(string schemaPath)
        {
            XmlNamespaceManager xnm = new XmlNamespaceManager(new NameTable());
            xnm.AddNamespace("xs", XmlSchema.Namespace);
            var doc = XDocument.Load(schemaPath);

            var query = from item in doc.XPathSelectElements("/xs:schema/xs:import[@schemaLocation]", xnm).ToArray()
                        let attr = item.Attribute(XName.Get("schemaLocation", string.Empty))
                        select attr.Value;

            this.relativeTypePaths = query.ToArray();

            this.typePaths = this.relativeTypePaths.Select(item => UriUtility.Combine(schemaPath, item)).ToArray();
        }

        public string SchemaPath
        {
            get { return this.xsdPath; }
        }

        public string[] TypePaths
        {
            get { return this.typePaths; }
        }

        public string[] RelativeTypePaths
        {
            get { return this.relativeTypePaths; }
        }
    }
}
