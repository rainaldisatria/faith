using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/String Event Channel")]
public class StringEventChannelSO : EventChannelBaseSO
{
	public UnityAction<string> OnEventRaised;
	public void RaiseEvent(string value)
	{
		OnEventRaised?.Invoke(value);
	}
}
