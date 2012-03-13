using System.Collections.Generic;
using Android.Content;
using Android.GoogleMaps;
using Android.Graphics.Drawables;
using Android.Widget;

namespace Chapter6.MonoAndroidApp
{
    public class MapOverlay : ItemizedOverlay
    {
        private readonly Context _context;
        private readonly IList<OverlayItem> _overlayItems = new List<OverlayItem>();

        public MapOverlay(Drawable marker, Context context)
            : base(BoundCenterBottom(marker))
        {
            _context = context;
        }

        public void Add(GeoPoint point, string title)
        {
            _overlayItems.Add(new OverlayItem(point, title, null));

            Populate();
        }

        protected override Java.Lang.Object CreateItem(int i)
        {
            return _overlayItems[i];
        }

        public override int Size()
        {
            return _overlayItems.Count;
        }

        protected override bool OnTap(int index)
        {
            Toast
                .MakeText(_context, _overlayItems[index].Title, ToastLength.Short)
                .Show();

            return base.OnTap(index);
        }
    }
}