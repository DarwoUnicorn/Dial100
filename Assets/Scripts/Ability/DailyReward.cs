using UnityEngine;
using System;

public class DailyReward : MonoBehaviour, IPersistent
{
    [SerializeField]
    private HammerAbility _hammerAbility;
    [SerializeField]
    private TimerRestoreAbility _timeRestoreAbility;
    [SerializeReference]
    private DescreaseMaxStartValueAbility _decreaseMaxStartValueAbility;
    [SerializeField]
    private string _id;
    [SerializeField] [HideInInspector]
    private int _day;
    [SerializeField]
    private string _previousRewardTime;

    public string Id => _id;

    public void CheckReward()
    {
        if(DateTime.Now - Convert.ToDateTime(_previousRewardTime) < new TimeSpan(1, 0, 0, 0))
        {
            return;
        }
        if(DateTime.Now - Convert.ToDateTime(_previousRewardTime) > new TimeSpan(2, 0, 0, 0))
        {
            _day = 0;
        }
        else
        {
            _day++;
        }
        _previousRewardTime = DateTime.Now.Date.ToString();
        GetReward();
        Save();
    }
    
    public void Load()
    {
        Saver.Load(this);
    }

    public void Save()
    {
        Saver.Save(this);
    }

    private void GetReward()
    {
        int hammerCount = 0;
        int timeRestoreCount = 0;
        int descreaseMaxStartValueCount = 0;
        int count = 0;
        if(_day < 2)
        {
            count = 2;
        }
        else if(_day < 5)
        {
            count = 4;
        }
        else if(_day < 7)
        {
            count = 6;
        }
        for(int i = 0; i < count; i++)
        {
            switch(UnityEngine.Random.Range(0, 3))
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
            _hammerAbility.IncreaseAbilityCount(hammerCount);
        }
        if(timeRestoreCount != 0)
        {
            _timeRestoreAbility.IncreaseAbilityCount(timeRestoreCount);
        }
        if(descreaseMaxStartValueCount != 0)
        {
            _decreaseMaxStartValueAbility.IncreaseAbilityCount(descreaseMaxStartValueCount);
        }
    }

    private void Start()
    {
        Load();
    }
}
