using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Infrastructure.Models
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public abstract class PagingParamQuery
    {
        protected int DefaultPage { get; set; } = 1;
        protected int DefaultPageSize { get; set; } = 100;

        private int? _page;
        public int Page
        {
            get => _page ?? DefaultPage;
            set => _page = value;
        }

        private int? _pageSize;
        public int PageSize
        {
            get => _pageSize ?? DefaultPageSize;
            set => _pageSize = value;
        }

    }
}
