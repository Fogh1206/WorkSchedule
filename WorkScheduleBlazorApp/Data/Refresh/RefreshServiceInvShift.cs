using System;

namespace WorkScheduleBlazorApp.Data.Refresh
{
    public class RefreshServiceInvShift : IRefreshServiceInvShift
    {
        public event Action RefreshRequested;
        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
    }
}