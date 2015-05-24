// (C) 2015 ERAL
// Distributed under the Boost Software License, Version 1.0.
// (See copy at http://www.boost.org/LICENSE_1_0.txt)

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;

public static class UIRaycast {

	public static List<GameObject> RaycastOnConstantPixelView(Vector2 point) {
		var eventData = new PointerEventData(EventSystem.current);
		eventData.Reset();
		eventData.position = point;

		var raycastResults = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, raycastResults);
		var result = raycastResults.Where(x=>x.gameObject != null)
									.Select(x=>x.gameObject)
									.ToList();
		return result;
	}


}
