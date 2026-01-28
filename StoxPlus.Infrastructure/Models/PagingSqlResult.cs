using ProtoBuf;
using System.Collections.Generic;

namespace StoxPlus.Infrastructure.Models
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class PagingSqlResult<TModel>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<TModel> Items { get; set; }
    }
}
