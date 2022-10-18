using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.PagerConfig
{
   public class PaginatedItemsDto<TEntity> where TEntity : class
    {

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }

        public IEnumerable<TEntity> Data { get; set; }

        public Pager pager { get;private set; }
        public PaginatedItemsDto(int pageIndex , int pageSize , int count , IEnumerable<TEntity>  data )
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            count = count;
            Data = data;
            pager = new Pager(count, pageIndex, pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex >1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < pager.TotalPages);
            }
        }
    }
}
