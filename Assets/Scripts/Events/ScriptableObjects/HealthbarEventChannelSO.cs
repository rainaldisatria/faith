using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Healthbar Event Channel")]
public class HealthbarEventChannelSO : EventChannelBaseSO
{
	public UnityAction<int, Transform, BattlerData> OnEventRaised;

	public void RaiseEvent(int instanceID, Transform trans, BattlerData data)
	{
		OnEventRaised?.Invoke(instanceID, trans, data);
	}
}
