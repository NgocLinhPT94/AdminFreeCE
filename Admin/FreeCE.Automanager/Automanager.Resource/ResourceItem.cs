using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Resource
{
    public class ResourceItem
    {
        private string key;
        private string value;
        private string valueEn;
        private string description;

        public ResourceItem()
        {
        }

        public ResourceItem(string key, string value, string valueEn, string description)
        {
            this.key = key;
            this.value = value;
            this.valueEn = valueEn;
            this.description = description ?? string.Empty;
        }

        public string Key { get => key; set => this.key = value; }
        public string Value { get => value; set => this.value = value; }
        public string ValueEn { get => valueEn; set => this.valueEn = value; }
        public string Description { get => description ?? string.Empty; set => this.description = value ?? string.Empty; }
    }
}
