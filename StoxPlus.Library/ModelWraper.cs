using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StoxPlus.Library
{
    public class ModelWraper<T>
    {
        public class PagingInfo
        {

            public int? PageSize { get; set; }
            public int? CurrentPage { get; set; }
            public double TotalPage { get; set; }
            public double TotalRow { get; set; }
            public int? From { get; set; }
            public int? To { get; set; }
            public int? NextPage { get; set; }
            public string NextPageURL { get; set; }
            public int? PreviousPage { get; set; }
            public string PreviousPageURL { get; set; }


        }
        public List<T> Data { get; private set; }

        public PagingInfo Paging { get; private set; }

        public ModelWraper(IEnumerable<T> items, int? pageSize, int? currentPage, string currentBasedPageURL, double rowCount, double pageCount)
        {

            Uri pageURL = new Uri(currentBasedPageURL);

            if (pageURL.Query != "")
            {
                if (!(currentBasedPageURL.ToLower().Contains("pageindex") && currentBasedPageURL.ToLower().Contains("pagesize")))
                {
                    currentBasedPageURL = currentBasedPageURL + "&pageindex=" + currentPage + "&pagesize=" + pageSize;
                }
            }
            else
            {
                if (!(currentBasedPageURL.ToLower().Contains("pageindex") && currentBasedPageURL.ToLower().Contains("pagesize")))
                {
                    currentBasedPageURL = currentBasedPageURL + "?pageindex=" + currentPage + "&pagesize=" + pageSize;
                }
            }
          
            Data = new List<T>(items);
            Paging = new PagingInfo
            {

                PageSize = pageSize,
                CurrentPage = currentPage,
                PreviousPage = currentPage >= 2
                     ? currentPage - 1
                     : null,
                PreviousPageURL = currentPage >= 2
                   ? Regex.Replace(currentBasedPageURL, "pageindex=" + (currentPage), "pageindex=" + (currentPage - 1), RegexOptions.IgnoreCase)
                   : null,
                NextPage = currentPage < pageCount
                    ? currentPage + 1
                    : null,
                NextPageURL = currentPage < pageCount
                   ? Regex.Replace(currentBasedPageURL, "pageindex=" + (currentPage), "pageindex=" + (currentPage + 1), RegexOptions.IgnoreCase)
                   : null,

                TotalPage = pageCount,
                TotalRow = rowCount,
                From = ((currentPage - 1) * pageSize) + 1,
                To = (currentPage * pageSize + 1) - 1

            };
        }

        
    }
}
