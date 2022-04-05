using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class SelectionItem : IDto
    {
        public SelectionItem()
        { 
        } 
        public SelectionItem(dynamic id, string label)
        {
            Id = id;
            Label = label;
        } 
        public dynamic Id { get; set; } 
        public string Label { get; set; }
        public string ParentId { get; set; }
    }
}
