using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannelSO : EventChannelBaseSO
{
	public UnityAction OnEventRaised;
	public void RaiseEvent()
	{
		OnEventRaised?.Invoke();
	}
}
