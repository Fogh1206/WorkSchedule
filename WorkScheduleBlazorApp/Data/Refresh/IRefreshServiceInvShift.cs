using System;

namespace WorkScheduleBlazorApp.Data.Refresh
{
    public interface IRefreshServiceInvShift
    {
        event Action RefreshRequested;
        void CallRequestRefresh();
    }
}