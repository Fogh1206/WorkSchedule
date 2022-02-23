using System;

namespace WorkScheduleBlazorApp.Data.Refresh
{
    public interface IRefreshServiceNavMem
    {
        event Action RefreshRequested;
        void CallRequestRefresh();
    }
}