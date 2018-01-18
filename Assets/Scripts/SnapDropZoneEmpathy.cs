using VRTK;

namespace DefaultNamespace
{
    public class SnapDropZoneEmpathy : VRTK_SnapDropZone
    {
        public void SetHighlight(bool highlight)
        {
            this.highlightObject.SetActive(highlight);
        }
    }
}