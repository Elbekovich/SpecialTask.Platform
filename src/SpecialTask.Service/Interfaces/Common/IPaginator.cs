using SpecialTask.Application.Utils;

namespace SpecialTask.Service.Interfaces.Common
{
    public interface IPaginator
    {
        public void Paginate(long itemsCount, PaginationParams @params);
    }
}
