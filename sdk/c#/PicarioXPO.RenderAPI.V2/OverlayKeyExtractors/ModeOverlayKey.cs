﻿using System.Collections.Generic;
using System.Linq;

namespace PicarioXPO.RenderAPI.V2.OverlayKeyExtractors
{
    internal class ModeOverlayKey : OverlayKey
    {
        public override string GetValues(IEnumerable<XpoUrlOverlay> overlays)
        {
            var xpoUrlOverlays = overlays as XpoUrlOverlay[] ?? overlays.ToArray();
            var max = xpoUrlOverlays.GetMaxOverlayNumber();

            for (var i = 0; i <= max; i++)
            {
                var urlObject = xpoUrlOverlays.LastOrDefault(x => x.Index == i);
                if (urlObject != null)
                    AddToList(urlObject.OverlayMode);
                else if (i != max)
                    AddEmpty();
            }

            if (IsEmpty()) return "";

            return "p.om=" + GetUrlValue();
        }
    }
}
