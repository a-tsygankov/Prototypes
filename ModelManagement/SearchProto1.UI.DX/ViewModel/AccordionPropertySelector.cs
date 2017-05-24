using DevExpress.Xpf.Accordion;
using SearchProto1.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProto1.UI.DX.ViewModel
{
    public class AccordionPropertySelector : IChildrenSelector
    {
        public IEnumerable SelectChildren(object item)
        {
            if (item is Category)
            {
                return ((Category)item).SearchableProperties;
            }
            else return null;
        }
    
    }
}
