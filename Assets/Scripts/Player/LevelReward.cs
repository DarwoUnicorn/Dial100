using UnityEngine;

public class LevelReward : MonoBehaviour
{
    [SerializeField]
    private HammerAbility _hammerAbility;
    [SerializeField]
    private TimerRestoreAbility _timeRestoreAbility;
    [SerializeReference]
    private DescreaseMaxStartValueAbility _decreaseMaxStartValueAbility;
    [SerializeField]
    private Notification _notification;

    public void OnLevelUp(int level)
    {
        int hammerCount = 0;
        int timeRestoreCount = 0;
        int descreaseMaxStartValueCount = 0;
        int count = (int)Mathf.Ceil(level / 5f);
        if(count < 2)
        {
            count = 2;
        }
        if(count > 6)
        {
            count = 6;
        }
        for(int i = 0; i < count; i++)
        {
            switch(Random.Range(0, 3))
            {
                case 0:
                {
                    hammerCount++;
                    break;
                }
                case 1:
                {
                    timeRestoreCount++;
                    break;
                }
                case 2:
                {
                    descreaseMaxStartValueCount++;
                    break;
                }
            }
        }
        if(hammerCount != 0)
        {
            _notification.SetHammerCount(hammerCount);
            _hammerAbility.IncreaseAbilityCount(hammerCount);
        }
        if(timeRestoreCount != 0)
        {
            _notification.SetTimeRestorerCount(timeRestoreCount);
            _timeRestoreAbility.IncreaseAbilityCount(timeRestoreCount);
        }
        if(descreaseMaxStartValueCount != 0)
        {
            _notification.SetDecreaserCount(descreaseMaxStartValueCount);
            _decreaseMaxStartValueAbility.IncreaseAbilityCount(descreaseMaxStartValueCount);
        }
    }
}
