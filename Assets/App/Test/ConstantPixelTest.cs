using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ConstantPixelTest : MonoBehaviour {

	public enum Condition {
		Hit,
		NoHit,
		ThrowSystemArgumentNullException,
		ThrowUnknownColliderException,
		ThrowSystemNotImplementedException,
	}
	
	public Condition m_Pass = Condition.Hit;
	public Vector2 m_TargetPoint = new Vector2(0.5f, 0.5f);
	public GameObject m_TargetObject;

	void Update() {
		try {
			var point = new Vector2(m_TargetPoint.x * Screen.width, m_TargetPoint.y * Screen.height);
			var raycast_hit = UIRaycast.RaycastOnConstantPixelView(point).FirstOrDefault();
			if (m_TargetObject != null) {
				if (m_TargetObject == raycast_hit) {
					Pass(Condition.Hit);
				} else {
					Pass(Condition.NoHit);
				}
			} else {
				if (raycast_hit != null) {
					Pass(Condition.Hit);
				} else {
					Pass(Condition.NoHit);
				}
			}
		} catch (System.ArgumentException) {
			Pass(Condition.ThrowSystemArgumentNullException);
		} catch (System.NotImplementedException) {
			Pass(Condition.ThrowSystemNotImplementedException);
		} catch {
			IntegrationTest.Fail(gameObject);
		}
	}

	private void Pass(Condition cond) {
		if (cond == m_Pass) {
			IntegrationTest.Pass(gameObject);
		} else {
			IntegrationTest.Fail(gameObject);
		}
	}
}
