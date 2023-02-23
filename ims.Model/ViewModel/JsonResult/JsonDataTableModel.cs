using System;
using System.Collections.Generic;
using System.Text;

namespace ims.Model.ViewModel.JsonResult
{
    public class JsonDataTableModel: JsonResultModel
    {
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public object aaData { get; set; }
    }
}
